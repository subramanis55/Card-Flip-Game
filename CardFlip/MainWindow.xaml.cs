using CardFlip.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using GoLibrary;
using CardFlip.UserControls.CardFlipUserControl;
using CardFlip.Classes;
using CardFlip.Properties;
using CardFlip.UserControls.Common;


namespace CardFlip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       
        private GameHomePage gameHomePage = new GameHomePage();
        private Profile profile;
        public static NotificationManager notificationManager = new NotificationManager();
        public Profile Profile
        {
            set
            {
              profile = value;
                NameLabel.Content= profile.Name;
            }
            get
            {
                return profile;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
      
            AddHomePage();
        }
        private void AddHomePage()
        {
            homePageButton.Visibility = Visibility.Hidden;
            PageGrid.Children.Clear();
            gameHomePage.OnClickOffline += GameHomePageOnClickOffline;
            gameHomePage.OnClickOnline += GameHomePageOnClickOnline;
            PageGrid.Children.Add(gameHomePage);
        }

        private void GameHomePageOnClickOffline(object sender, EventArgs e)
        {
            removeHomePage();
            AddGamePage(GameMode.Offline);
        }

        private void GameHomePageOnClickOnline(object sender, EventArgs e)
        {
           bool isconnectedwithserverDatabase= DBManager.Intialize(DBManager.ApplicationSetting);
            if (isconnectedwithserverDatabase)
            {
                bool result = true;
                if (!DBManager.IsProfileExits(Tcp.SystemIpAddress))
                {
                    result = DBManager.AddOrUpdateUser(new Classes.Profile() { Name = "" + DBManager.ApplicationSetting.Name, Ipaddress = Tcp.SystemIpAddress, Hostname = Tcp.HostName, Gender = DBManager.ApplicationSetting.Gender });
                }
                if (result == true)
                {
                    removeHomePage();
                    AddGamePage(GameMode.Online);
                }
                else
                {
                }
            }
            else
            {
                notificationManager.CreateNotification("Server Database connection fail",NotificationType.Information);
            }
           
        }

        public void AddGamePage(GameMode gameMode)
        {
            homePageButton.Visibility = Visibility.Visible;
            PageGrid.Children.Clear();
            GamePage gamePage=new GamePage(gameMode);
            gamePage.GameFinished += GamePageGameFinished;
            PageGrid.Children.Add(gamePage);

        }

        public void RemoveGamePage()
        {
            foreach (var control in PageGrid.Children)
            {
                if (control is GamePage)
                {
                    (control as GamePage).GameFinished -= GamePageGameFinished; 
                    (control as GamePage).DisposeObject();
                }
            }
            PageGrid.Children.Clear();
        }

        private void AddResultPage()
        {
            PageGrid.Children.Clear();
            homePageButton.Visibility = Visibility.Visible;
            List<Result> results = DBManager.GetOnlineGameResults();
            OnlineResultPage onlineResultPage = new OnlineResultPage(results);
            PageGrid.Children.Add(onlineResultPage);
        }
        private void GamePageGameFinished(object sender, GameMode e)
        {
            if (e == GameMode.Online)
            {
                RemoveGamePage();
                AddResultPage();
            }
        }

        private void removeHomePage()
        {
           foreach(var control in PageGrid.Children)
            {
                if(control is GameHomePage)
                {
                    (control as GameHomePage).DisposeObject();
                }
            }
            gameHomePage.OnClickOffline -= GameHomePageOnClickOffline;
            gameHomePage.OnClickOnline -= GameHomePageOnClickOnline;
            PageGrid.Children.Clear();
        }

        private void MaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
                WindowState = WindowState.Maximized;
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TopPanelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            e.Handled = true;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Tcp.Close();
            DBManager.Close();
        }

        private void HomePageButtonClick(object sender, RoutedEventArgs e)
        {
            RemoveGamePage();
            AddHomePage();
        }
    }
}
