﻿using CityManager.Models;
using CityManager.Viewmodel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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
        private Arduino currentArduino = null;
        private ViewModelArduino vma = null;

        public ArduinoPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vma = new ViewModelArduino();
            //we use the arduinos ip as a uniqe id
            //we then send that id over to this page so we know what arduino we are working with
            arduinoTag = e.Parameter.ToString();
            GeneratePage();
            
        }

        //generates the page based on the XML vars we have
        private void GeneratePage()
        {
            //ViewModelArduino page = new ViewModelArduino();
 
            Debug.WriteLine("arduinoTag " + arduinoTag);


            //Debug.WriteLine("ARDUINO " + vm.Arduinos.Count);
            //ObservableCollection<Arduino> oc = vm.Arduinos;

            //Find our arduino useing the tag/ip we got from the previes page
            foreach (Arduino a in XMLmanager.Instance.ArduinoCollection.Arduinos)
            {
                if (a.Ip.Equals(arduinoTag))
                {
                    currentArduino = a;

                    if (a != null)
                    {
                        GenerateNameTextbox(a);
                    }
                    else
                    {
                        Debug.WriteLine("NO ARDUINO");
                    }
                }
            }
        }

        //genarates a textblock contaning the arduinos name
        private void GenerateNameTextbox(Arduino a)
        {
            TextBlock t = new TextBlock();
            t.Text = a.Name;
            t.MinHeight = 50;
            t.MinWidth = 60;
            t.FontSize = 36;
            t.TextAlignment = TextAlignment.Center;
            t.FontWeight = Windows.UI.Text.FontWeights.Bold;

            //add the textblock to our page
            //we use a predefined stack panel as our base page
            StackBase.Children.Add(t);
            GenerateMethodControls();
        }

        private TextBlock GenerateMethodLabel(string text)
        {
            TextBlock t = new TextBlock();
            t.Text = text;
            t.FontWeight = Windows.UI.Text.FontWeights.Bold;
            return t;
        }

        //adds whatever controls the arduino has
        private void GenerateMethodControls()
        {
            //generate core controls
            foreach (ArduinoMethod am in currentArduino.CoreMethods)
            {
                StackBase.Children.Add(GenerateMethodLabel(am.Name));
                StackBase.Children.Add(FindControlType(am.MinValue, am.MaxValue));
            }

            //add a new label so we can see what controls are core and groups
            StackBase.Children.Add(new TextBlock() { Text = "Groups", TextAlignment = TextAlignment.Center, FontSize = 36, FontWeight = Windows.UI.Text.FontWeights.Bold }); //<- pro way of creating a new object :P

            //generate group controls
            foreach (ArduinoMethod am in currentArduino.GroupMethods)
            {
                StackBase.Children.Add(GenerateMethodLabel(am.Name));

                for (int i = 0; i < am.UnitCount; i++)
                {
                    //there are no uniqe names for units in groups so we just call them unit + number
                    StackBase.Children.Add(new TextBlock() {Text = "Unit " + i });
                    StackBase.Children.Add(FindControlType(am.MinValue, am.MaxValue));
                }
            }
        }

        //returns the appropriate control for the values given by the xml
        private Control FindControlType(int min, int max)
        {
            if (min == 0 && max == 1)
            {
                ToggleSwitch ts = new ToggleSwitch();

                return ts;
            }
            else //if (max > 1)
            {
                Slider s = new Slider();
                s.Minimum = min;
                s.Maximum = max;
                s.Orientation = Orientation.Horizontal;

                return s;
            }
        }

        //allows os to go back to the main page
        private void button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        
    }
}
