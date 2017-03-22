using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CityManager.Viewmodel;

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
            using (StringReader stringReader = new StringReader(xml))
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
