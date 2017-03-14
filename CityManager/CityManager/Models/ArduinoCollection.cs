using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CityManager.Models
{
    [XmlRoot("ArduinoCollection")]

    public class ArduinoCollection
    {
        [XmlArray("Arduinos")]
        [XmlArrayItem("Arduino", typeof(Arduino))]
        public Arduino[] Arduinos { get; set; }

        public static ArduinoCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArduinoCollection();
                }
                return instance;
            }
        }

        private static ArduinoCollection instance;
        private ArduinoCollection() { }
        
    }
}
