using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CityManager.Models
{
    public class ArduinoMethod
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("defaultValue")]
        public int DefaultValue { get; set; }
        [XmlElement("minValue")]
        public int MinValue { get; set; }
        [XmlElement("maxValue")]
        public int MaxValue { get; set; }
        [XmlElement("currentValue")]
        public int CurrentValue { get; set; }
        [XmlElement("unitName")]
        public string UnitName { get; set; }
        [XmlElement("unitCount")]
        public int UnitCount { get; set; }
    }
}
