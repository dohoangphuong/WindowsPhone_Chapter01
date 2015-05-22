using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chapter04_Save_Open_file_Image_Uri_to_Web.Resources;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;

namespace Chapter04_Save_Open_file_Image_Uri_to_Web
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        //----------------------------------------------------------------
        //----------------------LƯU Ý-----------------------------------
        /*
                UriKind.: Absolute: đường dẫn tuyệt đối-> tên ảnh trên web
         *                  Relative: tương đối-> tên ảnh trong project
         *                  RelativeOrAbsolute: không xác định
         */
        //-----------------------------------------------------------------
        string pathName;
        string pathWeb;
        private void save_Click(object sender, RoutedEventArgs e)
        {
            pathWeb = txtWebImage.Text.Trim() + txtNameImage.Text.Trim() + ".jpg";
            pathName = txtNameImage.Text.Trim() + ".jpg";
            //pathWeb = txtWebImage.Text.Trim();
            //pathName = txtNameImage.Text.Trim();
            SaveImageWeb();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            pathName = txtNameImage.Text.Trim() + ".jpg";
            //pathName = txtNameImage.Text.Trim();
            OpenFile();
        }
        public void SaveImageWeb()
        {
            string url = string.Format(pathWeb);

            WebClient m_webClient = new WebClient();
            try
            {
            Uri m_uri = new Uri(url);
            m_webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
            m_webClient.OpenReadAsync(m_uri); //lưu trữ vào IsolatedStorage
            }
            catch
            {     }
        }

        public void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            int count;
            try
            {
                

                byte[] buffer = new byte[1024];

                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    long spaceAvail = isf.AvailableFreeSpace;       //lấy vùng nhớ
                    if (e.Result.Length > spaceAvail)               // nếu IsolatedStorage không còn không gian vùng nhớ
                    {
                        MessageBox.Show("Vui lòng kiểm tra dung lượng lưu trữ hoặc xóa bớt các hình ảnh.", "LỖI DUNG LƯỢNG LƯU TRỮ.", MessageBoxButton.OK); ;
                    }
                    else
                    {
                        Stream stream;
                        try
                        {
                            stream = e.Result;
                            using (System.IO.IsolatedStorage.IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(pathName, FileMode.Create, isf))
                            {
                                count = 0;

                                while (0 < (count = stream.Read(buffer, 0, buffer.Length)))
                                {
                                    isfs.Write(buffer, 0, count);
                                }

                                stream.Close();
                                isfs.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Vui lòng kiểm tra kết nối thiết bị", "LỖI GHI FILE.", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra kết nối mạng.", "LỖI DOWNLOAD.", MessageBoxButton.OK);
            }
        }

        private void OpenFile()
        {
            BitmapImage bi = new BitmapImage();
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(pathName, FileMode.Open, FileAccess.Read))
                    {
                        bi.SetSource(fileStream);
                    }
                }
                this.image.Source = bi;
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra tên file.", "LỖI MỞ FILE.", MessageBoxButton.OK);
            }
        }
    }
}