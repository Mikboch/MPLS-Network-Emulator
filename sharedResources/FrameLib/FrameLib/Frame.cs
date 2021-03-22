using System;
using System.Collections;

namespace FrameLib {
    [Serializable]
    public class Frame
    {
        public string SourceIP;
        public ushort SourcePort;
        public string DestinationIP;
        public ushort DestinationPort;
        public string OriginIP;
        public ushort OriginPort;
        public ushort RouterInPort;
        public string Message;
        public Stack MPLSlabels = new Stack();

        public Frame(string SrcIP, ushort SrcP, string DesIP, ushort DesP, string Mes) {
            SourceIP = SrcIP;
            SourcePort = SrcP;
            DestinationIP = DesIP;
            DestinationPort = DesP;
            OriginIP = SourceIP;
            OriginPort = SourcePort;
            Message = Mes;
        }

        override public string ToString() {
            return "Source IP: " + SourceIP + " Source Port: " + SourcePort + " Destination IP: " + DestinationIP + " Destination Port: " + DestinationPort + " Message: " + Message + " :) ";
        }
    }
}
