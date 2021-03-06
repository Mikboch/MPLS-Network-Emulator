using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkNode {
    class ConfigLoader {

		public static int nodeID; 
		public static String ip;
		public static readonly LinkedList<int> ports = new LinkedList<int>();	    //ID|IP|PORT

		public static void LoadConfig(string file, string id) {

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(file);
			XmlElement root = doc.DocumentElement;
			XmlNodeList routerNodesList = root.SelectNodes("/config/routers/router");

			nodeID = Int32.Parse(id); 

			foreach (XmlNode node in routerNodesList) {
				if (nodeID == Int32.Parse(node.Attributes["id"].Value)) {
					ip = node.SelectSingleNode("router-ip").InnerText;

					XmlNodeList routerPortsList = node.SelectNodes("router-ports/router-port");
					foreach (XmlNode portNode in routerPortsList) {
						ports.AddLast(Int32.Parse(portNode.InnerText));
					}
					break;
				}
			}
			String msg = "";
			int iter = 0;
			ushort[] tmpPorts = new ushort[ports.Count];
			foreach (int i in ports) {
				msg = msg + "|" + i;
				tmpPorts[iter] = (ushort)ports.ToArray()[iter];
				iter++;
			}

			CloudConnection.ClientIP = ip + "/24";
			CloudConnection.ClientPorts = tmpPorts;
			GUIWindow.PrintLog("Config loaded: " + id + "|" + ip + msg);
			GUIWindow.ChangeWindowName("Router" + nodeID);
            GUIWindow.ChangeIP(ip);
		}
	}
    
}
