using CardFlip.Classes;
using CardFlip.Database;
using CardFlip.Properties;
using GoLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CardFlip.Forms
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSetting));
                
                string settingsFilePath = System.IO.Path.Combine(DBManager.ApplicationDebugPath, "Settings.xml");
                if (File.Exists(settingsFilePath))
                {
                    using (FileStream fs = new FileStream(settingsFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        DBManager.ApplicationSetting.Name = NameTextBox.AnimatedText;
                        DBManager.ApplicationSetting.Gender = Gender.Male;
                        serializer.Serialize(fs, DBManager.ApplicationSetting);
                    }
                }
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                DBManager.SystemProfile = new Profile() { Name = DBManager.ApplicationSetting.Name, Hostname = Tcp.HostName, Ipaddress = Tcp.SystemIpAddress, Gender = DBManager.ApplicationSetting.Gender };
                mainWindow.Profile= new Profile() { Name = DBManager.ApplicationSetting.Name, Hostname = Tcp.HostName, Ipaddress = Tcp.SystemIpAddress, Gender = DBManager.ApplicationSetting.Gender }; ;
                    mainWindow.Show();  
            }
        }

        private bool Validate()
        {
            if (NameTextBox.AnimatedText.IsNullOrEmpty() || NameTextBox.AnimatedText.Contains("'") ||NameTextBox.AnimatedText.Length>20)
            {

                NameTextBox.AnimatedTextBoxForeground = new SolidColorBrush(Color.FromRgb(225, 87, 57));
                return false;
            }
            return true;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Tcp.Close();
            DBManager.Close();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
                WindowState = WindowState.Maximized;
        }
    }
}
