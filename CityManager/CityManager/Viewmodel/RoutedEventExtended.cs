using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CityManager.Viewmodel
{
    public class RoutedEventExtended : RoutedEventArgs
    {
        private string unitName;
        private string unitCount;

        public string UnitName
        {
            get
            {
                return unitName;
            }

            set
            {
                unitName = value;
            }
        }

        public string UnitCount
        {
            get
            {
                return unitCount;
            }

            set
            {
                unitCount = value;
            }
        }

        public RoutedEventExtended() : base()
        {
        }

        public RoutedEventExtended(RoutedEvent R, string unitName, string unitCount) : base()
        {

            this.UnitCount = unitCount;
            this.UnitName = unitName;
        }
    }
}
