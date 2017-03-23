using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using CityManager.Viewmodel;
using System.Xml.Serialization;
using System.IO;
using CityManager.Models;

namespace CityManager.Models
{
    public class WebSocketManager
    {
        MessageWebSocket webSock = null;

        public async void InitWebSockets()
        {
            /*MessageWebSocket*/ webSock = new MessageWebSocket();
            //In this case we will be sending/receiving a string so we need to set the MessageType to Utf8.
            webSock.Control.MessageType = SocketMessageType.Utf8;
            Debug.WriteLine("InitWebSockets - We made it!");
            //await Task.Delay(2000);
            //Add the MessageReceived event handler.
            webSock.MessageReceived += WebSock_MessageReceived;
            //Add the Closed event handler.
            webSock.Closed += WebSock_Closed;
            //Uri serverUri = new Uri("ws://echo.websocket.org");
            Uri serverUri = new Uri("ws://192.168.1.100:8080/ArduinoServer/websocket");

            //Connect to the server.
            await webSock.ConnectAsync(serverUri);
            Debug.WriteLine("serverUri " + serverUri);

            /// Denne del er kun til test
            //try
            //{
            //    //Connect to the server.
            //    await webSock.ConnectAsync(serverUri);
            //    Debug.WriteLine("serverUri " + serverUri);
            //    //Send a message to the server.
            //    await WebSock_SendMessage(webSock, "<ArduinoCollection><Arduinos><Arduino><name>Tog</name><ip>192.168.40.3</ip><core><ArduinoMethod><name>driveForward</name><default>0</default><minimum>0</minimum><maximum>30</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>driveBackwards</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>stopTrain</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group></group></Arduino><Arduino><name>Bil</name><ip>192.168.40.4</ip><core><ArduinoMethod><name>driveForward</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>driveBackwards</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>stopTrain</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group></group></Arduino><Arduino><name>Lyskryds</name><ip>192.168.40.5</ip><core><ArduinoMethod><name>turnOnLights</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>turnOffLights</name><default>1</default><minimum>0</minimum><maximum>1</maximum><current>1</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod><ArduinoMethod><name>emergencyLights</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName></unitName><unitCount>0</unitCount></ArduinoMethod></core><group><ArduinoMethod><name>turnOnlight</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName>lyskryds</unitName><unitCount>4</unitCount></ArduinoMethod><ArduinoMethod><name>turnOfflight</name><default>0</default><minimum>0</minimum><maximum>1</maximum><current>0</current><unitName>lyskryds</unitName><unitCount>4</unitCount></ArduinoMethod></group></Arduino></Arduinos></ArduinoCollection>");
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("server: " + ex);
            //}
            /// her til
        }
        //The MessageReceived event handler.
        public void WebSock_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
        {
            DataReader messageReader = args.GetDataReader();
            messageReader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            string messageString = messageReader.ReadString(messageReader.UnconsumedBufferLength);
            Debug.WriteLine("Websocket " + messageString);
            XMLmanager.Instance.deserlize(messageString);
        }
        //The Closed event handler
        private void WebSock_Closed(IWebSocket sender, WebSocketClosedEventArgs args)
        {
            //Add code here to do something when the connection is closed locally or by the server
        }
        //Send a message to the server.
        private async Task WebSock_SendMessage(MessageWebSocket webSock, string message)
        {
            DataWriter messageWriter = new DataWriter(webSock.OutputStream);
            messageWriter.WriteString(message);
            await messageWriter.StoreAsync();
        }

        public async Task SendMethodCall(string msg)
        {
            await WebSock_SendMessage(webSock, msg);
        }
    }
}
