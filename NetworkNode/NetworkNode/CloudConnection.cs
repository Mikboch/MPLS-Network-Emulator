using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameLib;

namespace NetworkNode
{
    class CloudConnection
    {
        //do wczytania z config
        private readonly int CloudPort = 9999;
        private static bool connected = false;
        private static NetworkStream stream;
        public static ushort[] ClientPorts;
        public static string ClientIP;
        public static string[,] MPLSTab;

        public CloudConnection() {
            try {
                TcpClient tcpClient = new TcpClient("localhost", CloudPort);
                stream = tcpClient.GetStream();

                connected = true;
                GUIWindow.PrintLog("Connection with Cloud has been established");

                SendRegistrationRequest();
                GUIWindow.PrintLog("Sent registration request to Cloud");

                new Thread(ReceiveMessages).Start();
            } catch (SocketException se) {
                GUIWindow.PrintLog("Connection with Cloud has NOT been established");
                connected = false;
            }
        }

        public void ReceiveMessages() {
            while (true) {
                byte[] receivedBuffer = new byte[8192];
                try {
                    stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                }
                catch {
                    break;
                }

                Frame frame = (Frame)DeserializeObject(receivedBuffer);
                GUIWindow.PrintLog("Received message addressed to " + frame.DestinationIP);

                ModifyFrame(frame);
                GUIWindow.PrintLog("Redirecting message through port " + frame.SourcePort);

                SendMessage(frame);
            }
        }

        private void ModifyFrame(Frame f) {
            int layer_check = 1;
            for (int i = 0; i < MPLSTab.GetLength(0); i++) {
                if (MPLSTab[i, 1].Equals(f.RouterInPort.ToString()) && MPLSTab[i,2].Equals(f.MPLSlabels.Peek()) && MPLSTab[i,7].Equals(layer_check.ToString())) {
                    if (MPLSTab[i, 3].Equals("SWAP")) {
                        GUIWindow.PrintLog("MPLS label has been swapped from " + f.MPLSlabels.Peek() + " to " + MPLSTab[i, 5]);
                        f.MPLSlabels.Pop();
                        f.MPLSlabels.Push(MPLSTab[i,5]);
                        if(MPLSTab[i,6].Equals("0")) f.SourcePort = Convert.ToUInt16(MPLSTab[i, 4]);
                        f.SourceIP = ClientIP;
                        if (!MPLSTab[i, 6].Equals("0")) {                          
                            f.MPLSlabels.Push(MPLSTab[int.Parse(MPLSTab[i, 6]) - 1, 5]);
                            GUIWindow.PrintLog("MPLS label " + MPLSTab[int.Parse(MPLSTab[i, 6]) - 1, 5] + " has been pushed.");
                            f.SourcePort = Convert.ToUInt16(MPLSTab[int.Parse(MPLSTab[i, 6]) - 1, 4]);
                        }
                    } else if(MPLSTab[i, 3].Equals("POP")) {
                        GUIWindow.PrintLog("Peek MPLS label has been popped (Label: " + f.MPLSlabels.Peek() + ")");
                        f.MPLSlabels.Pop();
                        i = 0;
                        layer_check++;
                        continue;
                        //ModifyFrame(f);
                    }
                    break;
                }             
            }  
        }

        private void SendRegistrationRequest() {
            string addressWithoutMask = ClientIP.Split('/')[0];
            //string addressWithoutMask = ConfigLoader.ip;
            Frame registrationFrame = new Frame(addressWithoutMask, 0, "", 0, "_register_");

            byte[] data = SerializeObject(registrationFrame);
            stream.Write(data, 0, data.Length);
        }

        public static void SendMessage(Frame frame) {

            if (connected) {
                byte[] bytes = SerializeObject(frame);
                stream.Write(bytes, 0, bytes.Length);
            }
            else {
                GUIWindow.PrintLog("Connect with Cloud to send a message...");
            }

        }

        public static byte[] SerializeObject(object o) {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream.ToArray();
        }

        public static object DeserializeObject(byte[] bytes) {
            MemoryStream stream = new MemoryStream(bytes);
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream);
        }
    }
}
