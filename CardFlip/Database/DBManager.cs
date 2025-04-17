using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatabaseLibrary;
using System.Net;
using System.Net.Sockets;
using System.IO;
using CardFlip.Properties;
using CardFlip.Classes;
using System.Data;
using System.Windows.Markup;
using CardFlip.Classes.DataTableConstants;

namespace CardFlip.Database
{
    public static class DBManager
    {

        public static string ApplicationDebugPath{
            get{
                return AppDomain.CurrentDomain.BaseDirectory;
            }
            }
        public static ApplicationSetting ApplicationSetting { get; set; }

        private static DatabaseManager connection;

        private static Profile systemProfile=null;

        public static Profile SystemProfile {
            get
            {
                if (systemProfile == null)
                    systemProfile = GetSystemProfile(Tcp.HostName);
                return systemProfile;
            } 
            set
            {           
                systemProfile = value;
            }

        }

        public static bool Intialize(ApplicationSetting applicationSetting)
        {
            ApplicationSetting=applicationSetting;
             connection = new MySqlHandler(ApplicationSetting.OnlineServerHostName, ApplicationSetting.OnlineServerUserName, ApplicationSetting.OnlineServerPassword, ApplicationSetting.OnlineServerDatabaseName);
           var result= connection.Connect();
            connection.CheckAndCreateDatabase();
            CheckAndCreateTable();
           return result.Result;
        }

        private static void CheckAndCreateTable()
        {
            if (!connection.TableExists("Results"))
            {
                connection.CreateTable("Results", new ColumnDetails[]
                {
                    new ColumnDetails(ResultTable.Ipaddress,dataType:BaseDatatypes.VARCHAR,length:30,indexType:IndexType.PrimaryKey),
                    new ColumnDetails(ResultTable.Hostname,dataType:BaseDatatypes.VARCHAR,length:30),
                    new ColumnDetails(ResultTable.Name,dataType:BaseDatatypes.VARCHAR,length:50),
                     new ColumnDetails(ResultTable.Gender,dataType:BaseDatatypes.VARCHAR,length:50),
                    new ColumnDetails(ResultTable.Duration,dataType:BaseDatatypes.TIME,notNull:false),
                    new ColumnDetails(ResultTable.Played,dataType:BaseDatatypes.BOOLEAN)
                });
                var result=connection.ExecuteNonQuery($"GRANT ALL PRIVILEGES ON {DBManager.ApplicationSetting.OnlineServerDatabaseName}.* TO '{DBManager.ApplicationSetting.OnlineServerUserName}'@'{DBManager.ApplicationSetting.OnlineServerHostName}' IDENTIFIED BY '{DBManager.ApplicationSetting.OnlineServerPassword}';\r\nFLUSH PRIVILEGES;");
            }
        }

        public static bool AddOrUpdateUser(Profile profile)
        {
            return AddOrUpdateDataToDataBase(profile);
        }

        public static int UpdateResult(TimeSpan time)
        {
            string hostName = Tcp.HostName;
            string ipAddress = Tcp.SystemIpAddress;
            var prevSpan = connection.FetchSingleData("Results", ResultTable.Duration, $"{ResultTable.Ipaddress} = '{ipAddress}'").Value;
            //if(prevSpan is TimeSpan)
            //{
            //    time = (time.CompareTo((TimeSpan)prevSpan) == -1) ? (TimeSpan)prevSpan : time;
            //}
            if (prevSpan is TimeSpan)
                return GetPosition(ipAddress);
            string command = $"UPDATE Results SET {ResultTable.Duration} = @time , {ResultTable.Played} = true WHERE {ResultTable.Ipaddress} = '{ipAddress}'";
            var t = connection.ExecuteNonQuery(command, new ParameterData("time", time));
            return GetPosition(ipAddress);
        }

        private static int GetPosition(string ipAddress)
        {
            var column = connection.FetchColumn("Results", ResultTable.Ipaddress, $"{ResultTable.Duration} is NOT NULL", orderBy: ResultTable.Duration);
            if (column.Value == null)
                return -1;
            return column.Value.IndexOf(ipAddress) + 1;
        }

        public static Profile GetSystemProfile(string hostName)
        {
            var data = connection.FetchData("Results", $"Where {ResultTable.Hostname}={hostName}");
            if (data.Result&&data.Value.Count>0)
            {
                return new Profile(data.Value[ResultTable.Name][0].ToString(), (Gender)Enum.Parse(typeof(Gender),data.Value[ResultTable.Gender][0].ToString()), data.Value[ResultTable.Hostname][0].ToString(), data.Value[ResultTable.Ipaddress][0].ToString());
            }
            return null;
        }
        public static bool IsProfileExits(string ipAddress)
        {
            var result = connection.ValueExists("results", ResultTable.Ipaddress, ipAddress);
            return result;
        }
        public static bool Ishostnameexits(string hostname)
        {
            var result = connection.ValueExists("results", ResultTable.Hostname, hostname);
            return result;
        }

        private static bool AddOrUpdateDataToDataBase(Profile profile)
        {
            string query = $"INSERT INTO Results values(@{ResultTable.Ipaddress},@{ResultTable.Hostname},@{ResultTable.Name},@{ResultTable.Gender},@{ResultTable.Duration},@{ResultTable.Played});";       
            if (!Ishostnameexits(Tcp.HostName))
            {
                return connection.ExecuteNonQuery(query, new ParameterData[]
                {
                new ParameterData(ResultTable.Ipaddress,profile.Ipaddress),
                new ParameterData(ResultTable.Hostname,profile.Hostname),
                new ParameterData(ResultTable.Name,profile.Name),
                 new ParameterData(ResultTable.Gender,profile.Gender.ToString()),
                new ParameterData(ResultTable.Duration,null),
                new ParameterData(ResultTable.Played,false)
                });
            }
            else
            {
                return connection.UpdateData("results", $"hostname=\"{profile.Hostname}\"", new ParameterData[]
                {
                new ParameterData(ResultTable.Name,profile.Name),
                new ParameterData(ResultTable.Ipaddress,profile.Ipaddress),
                });
            }
        }

        public static List<(string, TimeSpan)> GetFinishedData()
        {
            List<(string, TimeSpan)> list = new List<(string, TimeSpan)>();

            var data = connection.FetchData("Results", $"{ResultTable.Duration} IS NOT NULL", orderBy: ResultTable.Duration);

            if (data.Value.Count == 0)
                return list;
            for (int i = 0; i < data.Value[ResultTable.Ipaddress].Count; i++)
            {
                list.Add(((string)data.Value[ResultTable.Name][i], (TimeSpan)data.Value[ResultTable.Duration][i]));
            }

            return list;
        }

        public static void Close()
        {
            connection?.CloseConnection();
        }

        internal static List<Result> GetOnlineGameResults()
        {
            List<Result> result = new List<Result>();
            var data = connection.FetchData("Results", $"{ResultTable.Duration} IS NOT NULL && {ResultTable.Played}=true", orderBy: ResultTable.Duration);
            if (data.Value.Count == 0)
                return result;
            for (int i = 0; i < data.Value[ ResultTable.Ipaddress].Count; i++)
            {
                result.Add(new Result(data.Value[ResultTable.Name][i].ToString(), i + 1, data.Value[ResultTable.Hostname][i].ToString(),data.Value[ResultTable.Ipaddress][i].ToString(),  (TimeSpan)data.Value[ResultTable.Duration][i]));
            }    
            return result;
        }
    }
}
