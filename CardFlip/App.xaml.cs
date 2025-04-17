using CardFlip.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using CardFlip.Properties;
using System.Xml.Serialization;
using CardFlip.Classes;
using System.Runtime;
using CardFlip.Forms;
using GoLibrary;

namespace CardFlip
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Tcp.initialize();
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSetting));

            string settingsFilePath = Path.Combine(DBManager.ApplicationDebugPath, "Settings.xml");

            if (!File.Exists(settingsFilePath))
            {
                using (FileStream fs = new FileStream(settingsFilePath, FileMode.Create))
                {
                    DBManager.ApplicationSetting = new ApplicationSetting() { OnlineServerDatabaseName = "CardFlipGame", OnlineServerUserName = "root", OnlineServerHostName = Tcp.HostName, OnlineServerIpAddress = Tcp.SystemIpAddress, OnlineServerPassword = "cardgame*", OnlineServerPort = "20000" };
                    serializer.Serialize(fs, DBManager.ApplicationSetting);
                    fs.Close();
                }
            }
            else
            {
                using (FileStream fs = new FileStream(settingsFilePath, FileMode.Open))
                {
                    DBManager.ApplicationSetting = (ApplicationSetting)serializer.Deserialize(fs);
                    fs.Close();
                }
            }

            if (DBManager.ApplicationSetting.Name == ""|| DBManager.ApplicationSetting.Name.IsNullOrEmpty()|| DBManager.ApplicationSetting.Name.Length>20)
            {
                Login login = new Login();
                login.Show();
            }
            else
            {
                MainWindow main = new MainWindow();
                DBManager.SystemProfile= new Profile() { Name = DBManager.ApplicationSetting.Name, Hostname = Tcp.HostName, Ipaddress = Tcp.SystemIpAddress, Gender = DBManager.ApplicationSetting.Gender };
                main.Profile = DBManager.SystemProfile;
                main.Show();
            }
         
        }
    }
}
