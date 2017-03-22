using CityManager.Common;
using CityManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CityManager.Viewmodel
{
    public class ViewModelArduino : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Arduino unit = new Arduino();

        private ICommand onValueChanged;

        public ICommand OnValueChanged
        {
            get
            {
                return onValueChanged;
            }

            set
            {
                onValueChanged = value;
            }
        }

        public Arduino Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }
        public ViewModelArduino()
        {
            //OnValueChanged = new RelayCommand(ControlToggled, () => true);
        }
    }
}
