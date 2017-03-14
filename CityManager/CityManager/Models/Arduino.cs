using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CityManager.Models
{

    public class Arduino
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("ip")]
        public string Ip { get; set; }
        [XmlArray("core")]
        [XmlArrayItem("ArduinoMethod", typeof(ArduinoMethod))]
        public ArduinoMethod[] CoreMethods { get; set; }
        [XmlArray("group")]
        [XmlArrayItem("ArduinoMethod", typeof(ArduinoMethod))]
        public ArduinoMethod[] GroupMethods { get; set; }
    }
}
