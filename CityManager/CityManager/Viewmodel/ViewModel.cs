using CityManager.Common;
using CityManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace CityManager.Viewmodel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Arduino> arduinos = new ObservableCollection<Arduino>();

        public ObservableCollection<Arduino> Arduinos
        {
            get
            {
                return arduinos;
            }

            set
            {
                arduinos = value;
                OnPropertyChanged("Arduinos");
            }
        }

        private ICommand onGridClickCommand;
        public ICommand OnGridClickCommand
        {
            get
            {
                return onGridClickCommand;
            }

            set
            {
                onGridClickCommand = value;
            }
        }

        public ViewModel() {
            //DO NOT REMOVE!
            OnGridClickCommand = new RelayCommand(OnGridClick, ()=>true);

            //TODO make deserlize class/XMLmanager
            string xml = "<ArduinoCollection><Arduinos><Arduino><name>Tog</name><ip>192.168.40.3</ip><core><ArduinoMethod><name>driveForward</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>driveBackwards</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>stopTrain</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group></group></Arduino><Arduino><name>Bil</name><ip>192.168.40.4</ip><core><ArduinoMethod><name>driveForward</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>driveBackwards</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>stopTrain</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group></group></Arduino><Arduino><name>Lyskryds</name><ip>192.168.40.4</ip><core><ArduinoMethod><name>turnOnLights</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>turnOffLights</name><default>1</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>emergencyLights</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group><ArduinoMethod><name>turnOnlight</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName>lyskryds</unitName><unitCount>4</unitCount></ArduinoMethod><ArduinoMethod><name>turnOfflight</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName>lyskryds</unitName><unitCount>4</unitCount></ArduinoMethod></group></Arduino></Arduinos></ArduinoCollection>";
            //string xml = "<ArduinoCollection><Arduinos><Arduino><name>Tog</name><ip>192.168.40.3</ip></Arduino><Arduino><name>Bil</name><ip>192.168.40.4</ip></Arduino><Arduino><name>Lyskryds</name><ip>192.168.40.4</ip></Arduino></Arduinos></ArduinoCollection>";

            XmlSerializer serializer = new XmlSerializer(typeof(ArduinoCollection));
            ArduinoCollection arduinoCollection = null;
            using (StringReader stringReader = new StringReader(xml))
            {
                try
                {
                     arduinoCollection = (ArduinoCollection)serializer.Deserialize(stringReader);
                
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }

            }

            foreach (var item in arduinoCollection.Arduinos)
            {
                Arduinos.Add(item);
            }
        }

        public void OnGridClick()
        {

        }

        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
