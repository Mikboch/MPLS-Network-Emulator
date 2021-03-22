using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace ManagementCenter
{
    class HostConnection
    {
        private readonly Host host;
        private readonly TcpClient client;
        private readonly int id;
        private readonly Server server;

        public HostConnection(Host host, TcpClient client, int id, Server server) {
            this.host = host;
            this.client = client;
            this.id = id;
            this.server = server;

            new Thread(ListenForPrompts).Start();
        }

        public int GetID() {
            return id;
        }

        public Host GetHost() {
            return host;
        }

        private void ListenForPrompts() {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            while (true) {

                string request;
                try {
                    request = reader.ReadLine();
                } catch (IOException ioe) {
                    server.RemoveHostConnection(this);
                    reader.Close();
                    writer.Close();
                    stream.Close();
                    return;
                }
                /*
                string[] keyWords = request.Split(' '); 
                switch(keyWords[0]) {
                    case "GET_LABEL":
                        try {
                            int targetHostID = Convert.ToInt32(keyWords[1]);
                            GUIWindow.PrintLog("Received MPLS label request from Host #" + id + " (target host is Host #" + targetHostID + ")");
                            bool labelFound = false;

                            foreach (Tuple<int, Tuple<int, int, int>> tuple in ConfigLoader.hostPossibleDestinations) {
                                if (tuple.Item1 == id) {
                                    Tuple<int, int, int> info = tuple.Item2;
                                    if (info.Item2 == targetHostID) {
                                        writer.WriteLine("SEND_LABEL " + info.Item3);
                                        writer.Flush();
                                        GUIWindow.PrintLog("Sending MPLS label " + info.Item3 + " to Host #" + id);
                                        labelFound = true;
                                        break;
                                    }
                                }
                            }
                            if (!labelFound) {
                                GUIWindow.PrintLog("Could not find MPLS label for target Host #" + targetHostID +
                                    ". Denying Host #" + id + " connection");
                                writer.WriteLine("SEND_LABEL -1");
                                writer.Flush();
                            }
                        }
                        catch (Exception ex) {
                            writer.WriteLine("SEND_LABEL -1");
                            writer.Flush();
                            GUIWindow.PrintLog("There was an error, while parsing an MPLS label request...");
                        }
                        break;

                }
               */
            }
        }
    }
}
