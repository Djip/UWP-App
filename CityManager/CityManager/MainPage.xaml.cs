using CityManager.Models;
using CityManager.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CityManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();    
        }

        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GridViewItem g = (GridViewItem)sender;
            //Debug.WriteLine("TAG: " + g.Tag);
            this.Frame.Navigate(typeof(ArduinoPage), g.Tag);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ViewModel vm = (ViewModel)this.DataContext;
            //vm.OnGridClick();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            XMLmanager.Instance.CloseEvent();
            Debug.WriteLine("MAIN PAGE UNLOADED!");
        }
    }
}
