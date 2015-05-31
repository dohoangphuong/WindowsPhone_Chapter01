using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chapter05_VS03_Multiple_screen_Url_web.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Chapter05_VS03_Multiple_screen_Url_web
{
    public partial class MainPage : PhoneApplicationPage
    {
        private double intx = Application.Current.Host.Content.ActualWidth;
        private double inty = Application.Current.Host.Content.ActualHeight;
        private Panorama pano = new Panorama();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LoadImage(41);
        }
        //http://st.vechai.info/2014/12/2120/O-Long-Vien-chap-2-18102-html-40.jpg
        private void LoadImage(int countImage)
        {
            try
            {
                pano.Width = intx;
                pano.Height = inty;
                for (int i = 0; i < countImage; i++)
                {
                    LoadItem("http://st.vechai.info/2014/12/2120/O-Long-Vien-chap-2-18102-html-" + i.ToString() + ".jpg");
                }
            }
            catch {
            }
        }
        private void LoadItem(string path)
        {
            try
            {
                Image images = new Image();
                images.Source = new BitmapImage(new Uri((string)path, UriKind.Absolute));
                images.Margin = new Thickness(0, 0, 0, 0);
                images.Width = intx;
                images.Height = inty;
                images.Stretch = Stretch.Uniform;
                pano.Items.Add(images);
            }
            catch {
            }
        }

    }
}