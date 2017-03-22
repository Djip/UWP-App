using CityManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityManager.Viewmodel
{
    public class ViewModelArduino : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Arduino unit = new Arduino();

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

        }
    }
}
