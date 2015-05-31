using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chapter05_VS02_Multiple_screen_automatic_add_items.Resources;
using Microsoft.Phone.Info;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Chapter05_VS02_Multiple_screen_automatic_add_items
{
    public partial class MainPage : PhoneApplicationPage
    {
        double intx = Application.Current.Host.Content.ActualWidth;
        double inty = Application.Current.Host.Content.ActualHeight;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LoadImage(7);
        }

        private void LoadImage(int countImage)
        {
            for (int i = 0; i < countImage; i++)
            {
                LoadItem("Resources/012" + i.ToString() + ".jpg");
            }
        }
        private void LoadItem(string path)
        {
            Image images = new Image();
            images.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            images.Margin = new Thickness(0, 0, 0, 0);
            images.Width = intx;
            images.Height = inty;
            images.Stretch = Stretch.Uniform;
            PanoramaItem items = new PanoramaItem();
            items.Content = images;
            pano.Items.Add(items);
        }


    }
}