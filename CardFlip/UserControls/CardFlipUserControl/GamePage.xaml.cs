using CardFlip.Classes;
using CardFlip.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CardFlip.UserControls.CardFlipUserControl
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : UserControl,IDisposable
    {

        public event EventHandler<GameMode> GameFinished;


        public GamePage(GameMode gameMode)
        {
            InitializeComponent();
            gameGrid.Visibility = Visibility.Hidden;
            GameMode = gameMode;
            methodSubcribe();

        }
        private int col=4,row=4;

        private bool isOnline;
        private bool startPlay;
        private bool isResetFirstClick;
        private Stopwatch stopwatch = new Stopwatch();
        private bool NameEntered;
        private FlipControl firstClicked = null;
        private FlipControl secondClicked = null;
        private Random rand = new Random();
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon() { Visible = true };
        private DispatcherTimer flipBackTimer = new DispatcherTimer();
        private DispatcherTimer timeUpdateTimer = new DispatcherTimer();
        private DispatcherTimer gamestartTimer = new DispatcherTimer();
        Random random = new Random();
        private int CountDown = 0;

        private List<KeyValuePair<int, ImageSource>> icons;

        string[] distractions = new string[]
        {
            "God Bless you Mamae...",
            "Namma thaa yeppaiyume..Nammathaa",
            "Oops, your mouse is acting weird",
            "Try closing your eyes this time!",
            "Did that card just blink at you?",
            $"Hi , {DBManager.SystemProfile.Name}"
        };

        private bool isGameStarted = false;

        private GameMode gameMode;

        public bool IsGameStarted
        {
            set
            {
                isGameStarted = value;
            }
            get
            {
                return isGameStarted;
            }
        }

        public GameMode GameMode
        {
            set
            {
                gameMode = value;
                resetBtn.Visibility = gameMode == GameMode.Online ? Visibility.Hidden : Visibility.Visible;

                if (GameMode == GameMode.Online)
                {
                    OnlineModeGameSetUp();
                }
                else if (GameMode == GameMode.Offline)
                {
                    StartTimeLabel.Visibility = Visibility.Hidden;
                    Start.Visibility = Visibility.Visible;
                }
            }
            get
            {
                return gameMode;
            }
        }

        private bool OnlineModeGameSetUp()
        {
            try
            {
                Tcp.TcpConnect(DBManager.ApplicationSetting.OnlineServerIpAddress);
                Tcp.StartGame += TcpClientStartGame;
                Tcp.StopGame += TcpClientStopGame;
                Start.Visibility = Visibility.Hidden;
                StartTimeLabel.Visibility = Visibility.Visible;
                StartTimeLabel.Content = "Please Wait..";
                return true;
            }
            catch (Exception ex)
            {
                MainWindow.notificationManager.CreateNotification("Online game request server/n didn't respond", Common.NotificationType.Information);
                return false;
            }

        }

        private void TcpClientStopGame(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                OnlineGameStop();
            }));
            lock (this)
            {
                startPlay = false;
            }
        }

        private void TcpClientStartGame(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                OnlineGamestart();
            }));
            lock (this)
            {
                startPlay = true;
            }
        }

        private void OnlineGamestart()
        {
            StartTimeLabel.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Visible;
            //Start.Foreground = Brushes.Black;
           Start.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#16B60C"));
        }

        private void OnlineGameStop()
        {

        }

        public void GameStart()
        {
            CountDown = 3;
            gamestartTimer.Start();
        }
        private void methodSubcribe()
        {
            gamestartTimer.Interval = TimeSpan.FromMilliseconds(800);
            gamestartTimer.Tick += GamestartTimerTick;
            timeUpdateTimer.Interval = TimeSpan.FromMilliseconds(800);
            timeUpdateTimer.Tick += TimeUpdateTimerTick;
            isResetFirstClick = true;
            Loaded += MainWindowLoaded;
        }

        private void GamestartTimerTick(object sender, EventArgs e)
        {
            if (CountDown > 0)
            {
                CountDown--;
                StartTimeLabel.Content = CountDown;
            }
            else if (CountDown == 0)
            {
                StartTimeLabel.Content = "0";
            }
            else if (CountDown < 0)
            {
                StartTimeLabel.Content = "Start";
            }
            else
            {
                gamestartTimer.Stop();
            }

        }

        private void TimeUpdateTimerTick(object sender, EventArgs e)
        {
            timeLabel.Content = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            createRowAndColumns(row, col, gameGrid);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    AddControlsIngrid(gameGrid, new FlipControl(), i, j);
                }
            }
            AssignIcons();
            flipBackTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            flipBackTimer.Tick += FlipBackTimerTick;
        }

        private void FlipBackTimerTick(object sender, EventArgs e)
        {
            flipBackTimer.Stop();
            firstClicked.IsFlip = false;
            secondClicked.IsFlip = false;
            firstClicked = null;
            secondClicked = null;
        }

        private void AssignIcons()
        {

            var Icons = SVGImageManager.GetRandomImages(gameGrid.Children.Count / 2);
            List<KeyValuePair<int, ImageSource>> icons = new List<KeyValuePair<int, ImageSource>>();
            foreach (Control control in gameGrid.Children)
            {
                if (control is FlipControl flipControl)
                {
                    flipControl.Reset();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var j in Icons)
                {
                    icons.Add(new KeyValuePair<int, ImageSource>(j.Key, j.Value));
                }
            }
            foreach (Control control in gameGrid.Children)
            {
                if (control is FlipControl flipControl)
                {
                    int index = rand.Next(icons.Count);
                    flipControl.ImageID = icons[index].Key;
                    flipControl.ImageSource = icons[index].Value;
                    flipControl.Margin = new Thickness(8);
                    flipControl.MouseDown += CardClick;
                    icons.RemoveAt(index);
                }
            }
        }

        private void StopwatchStart()
        {
            isGameStarted = true;
            timeLabelContainer.Visibility = Visibility.Visible;
            stopwatch.Reset();
            stopwatch.Start();
            timeUpdateTimer.Start();
        }
        private void StopwatchStop()
        {
            stopwatch.Stop();
            timeUpdateTimer.Stop();
        }
        int IdentifiedCount = 0;
        private void CardClick(object sender, EventArgs e)
        {
            FlipControl clicked = sender as FlipControl;
            if (isResetFirstClick)
            {
                isResetFirstClick = false;
            }

            if (flipBackTimer.IsEnabled) return;

            if (clicked == null || clicked.IsDentified|| clicked.IsFlip) return;

            clicked.IsFlip=true;

            if (firstClicked == null)
            {
                firstClicked = clicked;
                if (!isGameStarted)
                    StopwatchStart();
                return;
            }
            createDistraction();

            secondClicked = clicked;

            if (firstClicked.ImageID == secondClicked.ImageID)
            {
                IdentifiedCount = IdentifiedCount + 2;
                secondClicked= firstClicked = null;

                if (IdentifiedCount==gameGrid.Children.Count)
                {
                    StopwatchStop();
                    if (GameMode == GameMode.Online)
                    {
                        DBManager.UpdateResult(stopwatch.Elapsed);
                        GameFinished?.Invoke(this, GameMode);
                    }
                    else if(GameMode == GameMode.Offline)
                    {
                        LucidDesk.UserControls.MessageBox messageBox = new LucidDesk.UserControls.MessageBox();
                        messageBox.ShowMessageBox($" Time Completed : {FormatTimeSpanSmart(stopwatch.Elapsed)}", "You Won", LucidDesk.UserControls.MessageBoxType.Ok);
                        //GameFinished?.Invoke(this, GameMode);
                    }  
                }
            }
            else
            {
                flipBackTimer.Start();
            }
        }

        private void createDistraction()
        {
            string msg = distractions[random.Next(distractions.Length)];
            if (random.Next(0, 10) < 6)
            {
                notifyIcon.Icon = BitmapToIcon(Properties.Resources.whatsappIcon);
                notifyIcon.BalloonTipTitle = "Message";
                notifyIcon.BalloonTipText = msg;
                notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.None;
                notifyIcon.ShowBalloonTip(2000);
            }
        }

        public static string FormatTimeSpanSmart(TimeSpan timeSpan)
        {
            List<string> parts = new List<string>();

            if (timeSpan.Hours > 0)
                parts.Add($"{timeSpan.Hours:D2} hrs");

            if (timeSpan.Minutes > 0)
                parts.Add($"{timeSpan.Minutes:D2} min");

            // Always include seconds (even if 0)
            parts.Add($"{timeSpan.Seconds:D2} sec");

            return string.Join(" ", parts);
        }

        System.Drawing.Icon BitmapToIcon(System.Drawing.Bitmap bmp)
        {
            using (var ms = new MemoryStream())
            {
                // Save bitmap to stream as PNG or BMP (BMP preferred for Icon conversion)
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                using (var iconBmp = new System.Drawing.Bitmap(ms))
                {
                    IntPtr hIcon = iconBmp.GetHicon();
                    System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(hIcon);
                    return icon;
                }
            }
        }

        private bool AllMatched()
        {
            foreach (Control control in gameGrid.Children)
            {
                if (control is Button btn && btn.Content == "")
                    return false;
            }
            return true;
        }

        public void createRowAndColumns(int row, int col, Grid grid)
        {
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
            // Add  Columns
            for (int i = 0; i < col; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(colDef);
            }
            // Add  Rows
            for (int i = 0; i < row; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(rowDef);
            }
        }

        public void AddControlsIngrid(Grid grid, FlipControl flipcard, int row, int col)
        {
            Grid.SetRow(flipcard, row);
            Grid.SetColumn(flipcard, col);
            grid.Children.Add(flipcard);
        }

        private void RestartClick(object sender, RoutedEventArgs e)
        {
            isGameStarted = false;
            firstClicked = null;
            secondClicked = null;
            isResetFirstClick = true;
            IdentifiedCount = 0;
            stopwatch.Stop();
            stopwatch.Reset();
            timeLabel.Content = "00:00:00";
            timeUpdateTimer.Stop();
              AssignIcons();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            gameGrid.Visibility = Visibility.Visible;
        }

        public void Dispose()
        {
            Tcp.Close();
        }
    }
}
