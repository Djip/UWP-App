using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityManager.Models
{
    class ObservableCollection : ObservableCollection<Arduino>
    {
        public ObservableCollection()
        {
            foreach (Arduino a in ArduinoCollection.Instance.Arduinos)
            {
                Add(a);
            }
            
        }

    }
}
