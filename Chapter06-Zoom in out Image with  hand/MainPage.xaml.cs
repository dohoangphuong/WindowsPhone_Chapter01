using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chapter06_Zoom_in_out_Image_with__hand.Resources;
using System.Windows.Media;

namespace Chapter06_Zoom_in_out_Image_with__hand
{
    public partial class MainPage : PhoneApplicationPage
    {
        private double m_Zoom = 1;
        private double m_Width = 0;
        private double m_Height = 0;
        private double intx = Application.Current.Host.Content.ActualWidth;
        private double inty = Application.Current.Host.Content.ActualHeight;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void image_Loaded(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show(viewport.ActualHeight.ToString(), viewport.ActualWidth.ToString(), MessageBoxButton.OK);
           // viewport.Width = intx;
           // viewport.Height = inty;
            image.Width = intx;
            image.Height = inty;
            m_Width = image.ActualWidth;
            m_Height = image.ActualHeight;
            // Initaialy we put Stretch to None in XAML part, so we can read image ActualWidth i ActualHeight (otherwise values are strange)
            // After that we set Stretch to UniformToFill in order to be able to resize image
            
            image.Stretch = Stretch.Uniform;
            //viewport.Bounds = new Rect(0, 0, image.ActualWidth, image.ActualHeight);
            viewport.Bounds = new Rect(0, 0, intx,inty);
        }


        private void viewport_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            if (e.PinchManipulation != null)
            {

                double newWidth, newHieght;


                if (m_Width < m_Height)  // box new size between image size and viewport actual size
                {
                    newHieght = m_Height * m_Zoom * e.PinchManipulation.CumulativeScale;
                    newHieght = Math.Max(viewport.ActualHeight, newHieght);//lay kich thuoc khung anh hien tai va zoom nao to hon
                    newHieght = Math.Min(newHieght, m_Height);// lay kich thuoc anh to voi kich thuoc that
                    newWidth = newHieght * m_Width / m_Height;
                }
                else
                {
                    newWidth = m_Width * m_Zoom * e.PinchManipulation.CumulativeScale;
                    newWidth = Math.Max(viewport.ActualWidth, newWidth);
                    newWidth = Math.Min(newWidth, m_Width);
                    newHieght = newWidth * m_Height / m_Width;
                }


                if (newWidth < m_Width && newHieght < m_Height)
                {
                    // Tells image positione in viewport (offset)
                    MatrixTransform transform = image.TransformToVisual(viewport) as MatrixTransform;
                    // Calculate center of pinch gesture on image (not screen)
                    Point pinchCenterOnImage = transform.Transform(e.PinchManipulation.Original.Center);
                    // Calculate relative point (0-1) of pinch center in image
                    Point relativeCenter = new Point(e.PinchManipulation.Original.Center.X / image.Width, e.PinchManipulation.Original.Center.Y / image.Height);
                    // Calculate and set new origin point of viewport
                    Point newOriginPoint = new Point(relativeCenter.X * newWidth - pinchCenterOnImage.X, relativeCenter.Y * newHieght - pinchCenterOnImage.Y);
                    viewport.SetViewportOrigin(newOriginPoint);
                }
                image.Width = newWidth;
                image.Height = newHieght;
                image.Stretch = Stretch.Uniform;
               // Set new view port bound
                viewport.Bounds = new Rect(0, 0, newWidth, newHieght);
            }
        }

        private void viewport_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            m_Zoom = image.Width / m_Width;
        }

        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}