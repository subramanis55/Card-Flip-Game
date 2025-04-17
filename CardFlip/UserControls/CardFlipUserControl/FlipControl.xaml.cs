using GoLibrary;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialLibrary.MaterialDropDown;

namespace CardFlip.UserControls.CardFlipUserControl
{
    /// <summary>
    /// Interaction logic for FlipControl.xaml
    /// </summary>
    public partial class FlipControl : UserControl
    {
        public event EventHandler FlipChanged;

        private bool isFlip;

        public bool IsDentified { get; set; }
        public int ImageID { set; get; }

        public ImageSource ImageSource
        {
            set
            {
                if (this.ImageSource != null)
                    imageControl.Source.DisposeObject();
                imageControl.Source = value;
            }
            get
            {
                return imageControl.Source;
            }
        }
        public bool IsFlip
        {
            set
            {
                isFlip = value;

                if (imageControl.Visibility == Visibility.Visible)
                    imageControl.Visibility = Visibility.Hidden;
                    var flipOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(150));
                    flipOut.Completed += (s, _) =>
                    {
                        // Flip back in
                        var flipIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
                        CardScale.BeginAnimation(ScaleTransform.ScaleXProperty, flipIn);
                        imageControl.Visibility = isFlip ? Visibility.Visible : Visibility.Collapsed;
                    };
                    CardScale.BeginAnimation(ScaleTransform.ScaleXProperty, flipOut);

            }
            get
            {
                return isFlip;
            }
        }

        public FlipControl(int imageID, ImageSource imageSource)
        {
            InitializeComponent();
            ImageID = imageID;
            imageControl.Source = imageSource;
        }
        public FlipControl()
        {
            InitializeComponent();
        }

        internal void Reset()
        {
            imageControl.Visibility = Visibility.Collapsed;
            isFlip = false;
            IsDentified = false;
        }
    }
}
