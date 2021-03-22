﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkNode {
    class ManagementCenterConnection {
        //do wczytania z config
        private readonly int centerPort = 8888;
        private static bool connected = false;
        private static NetworkStream stream;
        private static StreamReader reader;
        private static StreamWriter writer;
        private static ushort[] ClientPorts;
        private static string ClientIP;


        public ManagementCenterConnection() {
            try {
                TcpClient tcpClient = new TcpClient("localhost", centerPort);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                connected = true;
                GUIWindow.PrintLog("Connection with Management Center has been established");

                //SendRegistrationRequest();
                GUIWindow.PrintLog("Sent registration request to Management Center");
                SendRegistrationRequest();
                RecieveRegistrationInfo();
                ReceiveMPLSTable();

                //new Thread(ReceiveMessages).Start();
                lock (Program.waiterCloud) {
                    Monitor.Pulse(Program.waiterCloud);
                }

                while(true) {
                    ReceiveMPLSTable();
                }
            } catch (SocketException se) {
                GUIWindow.PrintLog("Connection with Management Center has NOT been established");
                connected = false;
            }
        }

        private void SendRegistrationRequest() {
            writer.WriteLine("REGISTRATION:ROUTER:" + ConfigLoader.ip + ":" + ConfigLoader.nodeID);
            writer.Flush();
        }

        private void RecieveRegistrationInfo() {
            //for (int i = 0; i < 2; i++) {
            try {
                string msg = reader.ReadLine();
                string[] parameters = msg.Split(':');

                if (parameters[0].Equals("REGISTRATION") && parameters[1].Equals("OK")) {
                    GUIWindow.PrintLog("Managment Center accepted registration request");
                }
                else {
                    GUIWindow.PrintLog("Managment Center denied registration request");
                }
            } catch (IOException e) {
                GUIWindow.PrintLog(e.Message);
            }
            //}
        }

        private void ReceiveMPLSTable() {
            byte[] receivedBuffer = new byte[8192];
            try {
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
            } catch (IOException e) {
                return;
            }

            LinkedList<string[]> rows = (LinkedList<string[]>)CloudConnection.DeserializeObject(receivedBuffer);
            GUIWindow.PrintLog("Received MPLS table from Management Center");
            GUIWindow.AddMPLSData(rows);

            if (rows.Count == 0) {
                CloudConnection.MPLSTab = new string[0, 0];
                return;
            }
            
            CloudConnection.MPLSTab = new string[rows.Count, rows.First.Value.Length];

            int i = 0;
            foreach (string[] row in rows) {
                for (int j = 0; j < row.Length; j++)
                    CloudConnection.MPLSTab[i, j] = row[j];
                i++;
            }

            /*
            for (int a = 0; a < CloudConnection.MPLSTab.GetLength(0); a++) {
                string s = "";
                for (int b = 0; b < CloudConnection.MPLSTab.GetLength(1); b++) {
                    s += CloudConnection.MPLSTab[a, b] + " ";
                }
                GUIWindow.PrintLog(s);
            }
            */
        }

        public void RecieveConfig() {
            try {
                String msg = reader.ReadLine();
                String[] parameters = msg.Split(':');

                if (parameters[0].Equals("CONFIG")) {
                    ClientIP = parameters[1];

                    ClientPorts = new ushort[parameters.Length - 3];


                    int iter = 0;
                    String ports = "";

                    for (int i = 2; i < parameters.Length - 1; i++) {
                        ClientPorts[iter] = ushort.Parse(parameters[i]);
                        ports += "|" + ClientPorts[iter];
                        iter++;
                    }

                    CloudConnection.ClientIP = ClientIP + "/24";
                    CloudConnection.ClientPorts = ClientPorts;

                    int routerID = int.Parse(parameters[parameters.Length - 1]);
                    GUIWindow.ChangeWindowName("Router" + routerID);

                    GUIWindow.PrintLog("Config received: " + ClientIP + ports + " (" + "Router" + routerID + ")");
                }
                else {
                    GUIWindow.PrintLog("Managment Center denied registration request");
                }
            } catch (IOException) {

            }

        }
    }
}
