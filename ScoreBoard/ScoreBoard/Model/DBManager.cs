using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardFlip.Classes;
using CardFlip.Classes.DataTableConstants;
using DatabaseLibrary;

namespace ScoreBoard.Model
{
    public  static class DBManager
    {
        public static string ApplicationDebugPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        public static ApplicationSetting ApplicationSetting { get; set; }

        private static DatabaseManager connection;

        private static Profile systemProfile = null;

       
        public static bool Intialize(ApplicationSetting applicationSetting)
        {
            ApplicationSetting = applicationSetting;
            connection = new MySqlHandler(ApplicationSetting.OnlineServerHostName, ApplicationSetting.OnlineServerUserName, ApplicationSetting.OnlineServerPassword, ApplicationSetting.OnlineServerDatabaseName);
            var result = connection.Connect();
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
                connection.ExecuteNonQuery($"GRANT ALL PRIVILEGES ON {DBManager.ApplicationSetting.OnlineServerDatabaseName}.* TO '{DBManager.ApplicationSetting.OnlineServerUserName}'@'{DBManager.ApplicationSetting.OnlineServerHostName}' IDENTIFIED BY '{DBManager.ApplicationSetting.OnlineServerPassword}';\r\nFLUSH PRIVILEGES;");
            }
        }

        public static List<(string ip, string hostName, string name, object duration, bool isPlayed)> GetAllData()
        {
            List<(string, string, string, object, bool)> list = new List<(string, string, string, object, bool)>();

            var data = connection.FetchData("Results", "", orderBy: ResultTable.Duration);
            if (data.Value.Count == 0)
                return list;
            for (int i = 0; i < data.Value[ResultTable.Ipaddress].Count; i++)
            {
                list.Add(((string)data.Value[ResultTable.Ipaddress][i], (string)data.Value[ResultTable.Hostname][i], (string)data.Value[ResultTable.Name][i], data.Value[ResultTable.Duration][i], (bool)data.Value[ResultTable.Played][i]));
            }

            return list;
        }

        public static void ResetPlay()
        {
            string query = $"UPDATE Results SET {ResultTable.Played} = false , {ResultTable.Duration} = NULL";
            connection.ExecuteNonQuery(query);
        }
    }
}
