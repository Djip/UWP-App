using CityManager.Models;
using CityManager.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CityManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArduinoPage : Page
    {
        private string arduinoTag;

        public ArduinoPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            arduinoTag = e.Parameter.ToString();
            generatePage();
        }

        private void generatePage()
        {
            ViewModel vm = new ViewModel();
            ObservableCollection<Arduino> oc = vm.Arduinos;

            foreach (Arduino a in oc)
            {
                if (a.Ip.Equals(arduinoTag))
                {
                    Debug.WriteLine("CURRENT TAG: " + a.Ip + " " + a.Name);
                }
            }
        }
    }
}
