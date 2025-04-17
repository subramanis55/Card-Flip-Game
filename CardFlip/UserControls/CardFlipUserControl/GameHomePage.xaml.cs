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

namespace CardFlip.UserControls.CardFlipUserControl
{
    /// <summary>
    /// Interaction logic for GameHomePage.xaml
    /// </summary>
    public partial class GameHomePage : UserControl
    {
        public event EventHandler OnClickOnline;
        public event EventHandler OnClickOffline;
        public GameHomePage()
        {
            InitializeComponent();
        }

        private void OnlineClick(object sender, RoutedEventArgs e)
        {
            OnClickOnline?.Invoke(this, e); 
        }

        private void OfflineClick(object sender, RoutedEventArgs e)
        {
            OnClickOffline?.Invoke(this, e);
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
