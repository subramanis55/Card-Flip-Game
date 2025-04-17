using CardFlip.Classes;
using ScoreBoard.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScoreBoard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TCP.initialize();
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSetting));
           
            string settingsFilePath = Path.Combine(DBManager.ApplicationDebugPath, "Settings.xml");

            if (!File.Exists(settingsFilePath))
            {
                using (FileStream fs = new FileStream(settingsFilePath, FileMode.Create))
                {
                    DBManager.ApplicationSetting = new ApplicationSetting() { OnlineServerDatabaseName = "CardFlipGame", OnlineServerUserName = "root", OnlineServerHostName = TCP.HostName, OnlineServerIpAddress = TCP.SystemIpAddress, OnlineServerPassword = "cardgame*", OnlineServerPort = "20000" };
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
            Application.Run(new Form1());
        }
    }
}
