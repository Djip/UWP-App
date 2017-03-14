using CityManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CityManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            deserialize();
        }


        public void deserialize()
        {
            
            string xml = "<ArduinoCollection><Arduinos><Arduino><name>Tog</name><ip>192.168.40.3</ip><core><ArduinoMethod><name>driveForward</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>driveBackwards</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>stopTrain</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group></group></Arduino><Arduino><name>Bil</name><ip>192.168.40.4</ip><core><ArduinoMethod><name>driveForward</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>driveBackwards</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>stopTrain</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group></group></Arduino><Arduino><name>Lyskryds</name><ip>192.168.40.4</ip><core><ArduinoMethod><name>turnOnLights</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>turnOffLights</name><default>1</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>emergencyLights</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group><ArduinoMethod><name>turnOnlight</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName>lyskryds</unitName><unitCount>4</unitCount></ArduinoMethod><ArduinoMethod><name>turnOfflight</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName>lyskryds</unitName><unitCount>4</unitCount></ArduinoMethod></group></Arduino></Arduinos></ArduinoCollection>";
            //string xml = "<ArduinoCollection><Arduinos><Arduino><name>Tog</name><ip>192.168.40.3</ip></Arduino><Arduino><name>Bil</name><ip>192.168.40.4</ip></Arduino><Arduino><name>Lyskryds</name><ip>192.168.40.4</ip></Arduino></Arduinos></ArduinoCollection>";

            XmlSerializer serializer = new XmlSerializer(typeof(ArduinoCollection));

            using (StringReader stringReader = new StringReader(xml))
            {
                try
                {
                    ArduinoCollection arduinoCollection = (ArduinoCollection)serializer.Deserialize(stringReader);
                    Debug.WriteLine(arduinoCollection.Arduinos.Length);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
                
            }
        }
    }
}
