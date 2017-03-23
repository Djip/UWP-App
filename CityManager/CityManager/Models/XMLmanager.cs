using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CityManager.Viewmodel;
using System.Xml;

namespace CityManager.Models
{
    public class XMLmanager
    {
        private static XMLmanager instance;
        private ArduinoCollection arduinoCollection = new ArduinoCollection();

        private XMLmanager() { }

        public static XMLmanager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XMLmanager();
                }
                return instance;
            }
        }

        public ArduinoCollection ArduinoCollection
        {
            get
            {
                return arduinoCollection;
            }

            set
            {
                arduinoCollection = value;
            }
        }

        public event EventHandler SomethingHappened;

        public void DoSomething()
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void CloseEvent()
        {
            SomethingHappened = null;
        }

        public void deserlize(string xml)
        {
            ArduinoCollection = null;
            XmlSerializer serializer = new XmlSerializer(typeof(ArduinoCollection));

            string selfXml = "";

            ArduinoMethod c = new ArduinoMethod {Name = "Core TEst", CurrentValue = 1, DefaultValue = 1, MaxValue = 1, MinValue = 0, UnitCount = 0, UnitName = ""  };
            ArduinoMethod g = new ArduinoMethod { Name = "Core TEst", CurrentValue = 1, DefaultValue = 1, MaxValue = 1, MinValue = 0, UnitCount = 3, UnitName = "TEST" };
            ArduinoMethod[] core = new ArduinoMethod[1];
            core[0] = c;
            ArduinoMethod[] group = new ArduinoMethod[1];
            group[0] = g;
            Arduino a = new Arduino {Name = "TEST A", Ip = "1.1.1.1.1", CoreMethods = core, GroupMethods = group };
            Arduino[] ars = new Arduino[1];
            ars[0] = a;
            ArduinoCollection ac = new ArduinoCollection {Arduinos = ars };

            //XmlSerializer xmls = new XmlSerializer(typeof(ArduinoCollection));
            //using (StringWriter sw = new StringWriter())
            //{
            //    using (XmlWriter writer = XmlWriter.Create(sw))
            //    {
            //        xmls.Serialize(writer, ac);
            //        Debug.WriteLine(sw.ToString());
            //        selfXml = sw.ToString();
            //    }
            //}



            Debug.WriteLine(xml);


            Debug.WriteLine(xml.Replace("\r\n",String.Empty));



            using (StringReader stringReader = new StringReader(xml.Replace("\n", "") /*selfXml*/))
            {
                try
                {
                    ArduinoCollection = (ArduinoCollection)serializer.Deserialize(stringReader);
                    Debug.WriteLine("What is arduino collection after xml?: "+ArduinoCollection.Arduinos.Count());

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
                DoSomething();
                //foreach (var item in arduinoCollection.Arduinos)
                //{
                //    vm.Arduinos.Add(item);
                //}
            }
        }
    }
}
