﻿#pragma checksum "D:\Hoc Tap\Visual Studio\WindowsPhone\Session01\WindowsPhone_Chapter01\Chapter04-Save_Open file Image Uri to Web\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "653C9E7D0B43A9F2D1F013C8D4A29221"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Chapter04_Save_Open_file_Image_Uri_to_Web {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox txtWebImage;
        
        internal System.Windows.Controls.Image image;
        
        internal System.Windows.Controls.Button save;
        
        internal System.Windows.Controls.Button open;
        
        internal System.Windows.Controls.TextBox txtNameImage;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Chapter04-Save_Open%20file%20Image%20Uri%20to%20Web;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtWebImage = ((System.Windows.Controls.TextBox)(this.FindName("txtWebImage")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
            this.save = ((System.Windows.Controls.Button)(this.FindName("save")));
            this.open = ((System.Windows.Controls.Button)(this.FindName("open")));
            this.txtNameImage = ((System.Windows.Controls.TextBox)(this.FindName("txtNameImage")));
        }
    }
}

