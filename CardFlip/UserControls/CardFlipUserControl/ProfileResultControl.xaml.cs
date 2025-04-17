using CardFlip.Classes;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
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
using CardFlip.Classes;
using CardFlip.Database;

namespace CardFlip.UserControls.CardFlipUserControl
{
    /// <summary>
    /// Interaction logic for ProfileResultControl.xaml
    /// </summary>
    public partial class ProfileResultControl : UserControl
    {
        private CardFlip.Classes.Result result;
        private bool isSelected;
        BrushConverter converter= new BrushConverter();
        public CardFlip.Classes.Result Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;

                positionLabel.Content = result.Position;
                switch (result.Position)
                {
                    case 1:
                        positionborder.Background = (SolidColorBrush)(converter.ConvertFrom("#FFF424"));
                        break;
                    case 2:
                        positionborder.Background = Brushes.Silver;
                        break;
                    case 3:
                        positionborder.Background = (SolidColorBrush)(converter.ConvertFrom("#C5A981"));
                        break;
                    default:
                        positionborder.Background = (SolidColorBrush)Application.Current.Resources["SubColorBrush"];
                        positionborder.BorderThickness = new Thickness(0);
                        break;
                }
               nameLabel.Content = result.Name;
               durationTimeLabel.Content = FormatTimeSpanSmart(result.Duration);
                if(Tcp.SystemIpAddress==result.IpAddress)
                {
                    IsSelected = true;
                }
            }
        }

        public bool IsSelected
        {
            set
            {
                isSelected = value;
                if (isSelected)
                {
                    backgroundContainer.Background= (SolidColorBrush)(converter.ConvertFrom("#C5E2FF"));
                }
            }
            get
            {
                return isSelected;
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
        public ProfileResultControl()
        {
            InitializeComponent();
        }
        public ProfileResultControl(CardFlip.Classes.Result result)
        {
            InitializeComponent();
            Result = result;
        }
    }
}
