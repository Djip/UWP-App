using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityManager.Models
{
    public static class ArduinoList
    {
        static ArduinoCollection ac = XMLmanager.Instance.ArduinoCollection;
        private static ObservableCollection<Arduino> arduinos = new ObservableCollection<Arduino>();

        public static ObservableCollection<Arduino> Arduinos
        {
            get
            {
                return arduinos;
            }

            set
            {
                arduinos = value;
            }
        }
    }
}
