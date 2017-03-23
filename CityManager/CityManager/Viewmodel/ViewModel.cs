using CityManager.Common;
using CityManager.Models;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Windows.System.Threading;
using Windows.UI.Xaml;

namespace CityManager.Viewmodel
{
    public class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Arduino> arduinos = new ObservableCollection<Arduino>();

        public ObservableCollection<Arduino> Arduinos
        {
            get
            {
                return arduinos;
            }

            set
            {
                arduinos = value;
                OnPropertyChanged("Arduinos");
            }
        }

        private ICommand onGridClickCommand;
        public ICommand OnGridClickCommand
        {
            get
            {
                return onGridClickCommand;
            }

            set
            {
                onGridClickCommand = value;
            }
        }

        public ViewModel() {
            OnGridClickCommand = new RelayCommand(OnGridClick, ()=>true);          
            XMLmanager.Instance.SomethingHappened += modelchanged;
            Debug.WriteLine("NEW VIEWMODEL!");
            WebSocketManager.Instance.InitWebSockets();
            DispatcherHelper.Initialize();
        }
        delegate void Del();

        private void modelchanged(object sender, EventArgs e)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(
                                                    () =>
                                                    {
                                                        test();
                                                    });
        }
        private void test()
        {
            ArduinoCollection ac = XMLmanager.Instance.ArduinoCollection;          
            Debug.WriteLine("test");

            //Debug.WriteLine("er der mange" + Arduinos.Count());
            //foreach (Arduino item in ac.Arduinos)
            //{
            //    Arduinos.Add(item);
            //    Debug.WriteLine("Er vi her? foreach");
            //}
            //Arduinos.Count();
            Arduinos = new ObservableCollection<Arduino>(ac.Arduinos);
        }

        public void OnGridClick()
        {

        }

        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
