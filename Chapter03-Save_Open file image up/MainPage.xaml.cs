using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chapter03_Save_Open_file_image_up.Resources;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;

namespace Chapter03_Save_Open_file_image_up
{
    public partial class MainPage : PhoneApplicationPage
    {
        //----------------------------------------------------------------
        //----------------------LƯU Ý-----------------------------------
        /*
                UriKind.: Absolute: đường dẫn tuyệt đối-> tên ảnh trên web
         *                  Relative: tương đối-> tên ảnh trong project
         *                  RelativeOrAbsolute: không xác định
         */
        //-----------------------------------------------------------------
        string fileImage;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private void save_Click_1(object sender, RoutedEventArgs e)
        {
            fileImage = txtImage.Text.Trim();
            SavePhoto();
        }

        private void open_Click_1(object sender, RoutedEventArgs e)
        {
            fileImage = txtImage.Text.Trim();
            OpenFile();
        }

        //private async void btDown_Click(object sender, RoutedEventArgs e)
        //{
        //    DownloadFileVerySimle(new Uri(pathweb), "0101.jpg");
        //}
        //public static void DownloadFileVerySimle(Uri fileAdress, string fileName)
        //{
        //    WebClient client = new WebClient();
        //    IsolatedStorageFile ISF=null;
        //    client.DownloadStringCompleted += (s, ev) =>
        //    {
        //        using (ISF = IsolatedStorageFile.GetUserStoreForApplication())
        //        using (StreamWriter writeToFile = new StreamWriter(ISF.CreateFile(fileName)))
        //            writeToFile.Write(ev.Result);
        //    };
        //    client.DownloadStringAsync(fileAdress);
        //}

       
        static public void saveImageLocally(string barcode, BitmapImage anImage)
        {
            WriteableBitmap wb = new WriteableBitmap(anImage);

            using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var fs = isf.CreateFile(barcode + ".jpg"))
                {
                    wb.SaveJpeg(fs, wb.PixelWidth, wb.PixelHeight, 0, 100);
                }
            }
        }
        private void SavePhoto()
        {
            
            // tên file hình
            String tempJPEG = fileImage;
          //  StreamWriter a = new StreamWriter(ISF.CreateFile(fileName));
            

            image.Source = new BitmapImage(new Uri(fileImage, UriKind.Relative));
           
            // Khởi tạo đối tượng kết tối tới Isolated Storage
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();
                // Kiểm tra nếu file tồn tại thì xóa file 
                if (myIsolatedStorage.FileExists(tempJPEG))
                {
                    myIsolatedStorage.DeleteFile(tempJPEG);
                }
                // Dùng Isolated Storage để tạo file tempJPEG 
                IsolatedStorageFileStream fileStream = null;
                using (fileStream = myIsolatedStorage.CreateFile(tempJPEG))
                {
                    if (fileStream == null)
                        MessageBox.Show("lỗi!");
                    // Dùng StreamResourceInfo để đọc file từ Resource
                    StreamResourceInfo sri = null;
                    Uri uri = new Uri(fileImage, UriKind.Relative);
                    sri = Application.GetResourceStream(uri);

                    // Load Resource vào hình ảnh Bitmap 
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(sri.Stream);
                    // dùng WriableBitmap để ghi file dưới dạng nhị phân vào bộ nhớ
                    WriteableBitmap wb = new WriteableBitmap(bitmap);

                    // Mã hóa và lưu dữ liệu ảnh vào file tempJPG
                    Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                }
                // Cách khác
                //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                fileStream.Close();
            }
        }

        private void OpenFile()
        {
            BitmapImage bi = new BitmapImage();

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileImage, FileMode.Open, FileAccess.Read))
                {
                    bi.SetSource(fileStream);
                    //this.image.Height = bi.PixelHeight;
                   // this.image.Width = bi.PixelWidth;
                }
            }
            this.image.Source = bi;
        }
    }
}