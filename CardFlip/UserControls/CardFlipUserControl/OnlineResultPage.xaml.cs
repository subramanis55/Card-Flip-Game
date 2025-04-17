using CardFlip.Classes;
using CardFlip.Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardFlip.UserControls.CardFlipUserControl
{
    /// <summary>
    /// Interaction logic for OnlineResultPage.xaml
    /// </summary>
    public partial class OnlineResultPage : UserControl
    {
        private List<Result> results;
        private int position;
        private bool IsMemeImageShow=true;
        public List<Result> Results
        {
            set
            {
                results = value;
                ResultShow();
            }
            get
            {
                return results;
            }
        }
        private int PlayerPosition
        {
            set
            {
                if (position == value)
                    return;
                position = value;
                if (!IsMemeImageShow)
                    ImageContainer.Visibility = Visibility.Collapsed;
                else
                    ImageContainer.Visibility = Visibility.Visible;
                switch (position)
                {
                    case 1:
                        MemeImage.Image = ConvertBitMapImage(Properties.Resources.FirstPlaceMeme);
                        break;
                    case 2:
                        MemeImage.Image = ConvertBitMapImage(Properties.Resources.SecondPlaceMeme);
                        break;
                    case 3:
                        MemeImage.Image = ConvertBitMapImage(Properties.Resources.ThirdPlaceMeme);
                        break;
                   default:
                        MemeImage.Image = ConvertBitMapImage(Properties.Resources.AfterThirdPlace);
                        break;
                }
            }
            get
            {
                return position;
            }
        }

        private BitmapImage ConvertBitMapImage(System.Drawing.Bitmap bmp)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
            return null;
        }

        private void ResultShow()
        {
            if (results == null)
                return;
            resultPanel.Children.Clear();
            foreach (var control in resultPanel.Children)
            {
                if (control is ProfileResultControl)
                {
                    (control as ProfileResultControl).DisposeObject();
                }
            }
            for (int i = 0; i < Results.Count; i++)
            {
                if (Results[i].IpAddress == Tcp.SystemIpAddress)
                    PlayerPosition = i + 1;
                resultPanel.Children.Add(new ProfileResultControl(Results[i]) { Height = 42 });
            }
        }

        public OnlineResultPage(List<Result> results)
        {
            InitializeComponent();
            Results = results;
        }



        private void resultcontrolSizeChanged(object sender, SizeChangedEventArgs e)
        {

            AdjustLayout();
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            Results = DBManager.GetOnlineGameResults();
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
        private void AdjustLayout()
        {
            if (container.ActualWidth > 900)
            {
                // Horizontal layout: two columns
                Grid.SetRow(ScrollViewerContainer, 0);
                Grid.SetColumn(ScrollViewerContainer, 0);

                Grid.SetRow(ImageContainer, 0);
                Grid.SetColumn(ImageContainer, 1);

                container.RowDefinitions.Clear();
                container.ColumnDefinitions.Clear();

                container.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                container.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            else
            {
                // Vertical layout: two rows
                Grid.SetRow(ScrollViewerContainer, 0);
                Grid.SetColumn(ScrollViewerContainer, 0);

                Grid.SetRow(ImageContainer, 1);
                Grid.SetColumn(ImageContainer, 0);

                container.ColumnDefinitions.Clear();
                container.RowDefinitions.Clear();

                container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }
        }
    }
}
