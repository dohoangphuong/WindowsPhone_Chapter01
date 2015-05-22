using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chapter02_Download_Image.Resources;
using System.IO;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Media;
using System.Text;
using Windows.Storage;

namespace Chapter02_Download_Image
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       // WebClient Wc = new WebClient();//Để tải file về dùng cái này;
        string pathweb;
        private async void btDown_Click(object sender, RoutedEventArgs e)
        {
            pathweb = txtPathWebDown.Text.Trim();
            Uri FileUrl = new Uri(pathweb);//Uri để tạo đầu vào cho Wc tải về, Trim để xóa kí tự rỗng ở 2 đầu
            image.Source = new BitmapImage(FileUrl);
            MessageBox.Show("Đã load ảnh xong!");
        }
    }
}