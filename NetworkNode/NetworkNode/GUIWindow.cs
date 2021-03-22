using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NetworkNode {
    public partial class GUIWindow : Form {

        private static GUIWindow instance;
        private List<string> logBuffer = new List<string>();

        public GUIWindow() {
            InitializeComponent();
            instance = this;
            lock (Program.waiterConfig) {
                Monitor.Pulse(Program.waiterConfig);
            }
        }

        public static void AddMPLSData(LinkedList<string[]> rows) {

            instance.RoutingTable.Rows.Clear();
            instance.RoutingTable.Refresh();

            instance.RoutingTable.ColumnCount = 8;
            instance.RoutingTable.Columns[0].Name = "ID";
            instance.RoutingTable.Columns[1].Name = "In Port";
            instance.RoutingTable.Columns[2].Name = "In Label";
            instance.RoutingTable.Columns[3].Name = "Action";
            instance.RoutingTable.Columns[4].Name = "Out Port";
            instance.RoutingTable.Columns[5].Name = "Out Label";
            instance.RoutingTable.Columns[6].Name = "Next Action";
            instance.RoutingTable.Columns[7].Name = "Layer";
            //PrintLog(rows.First.Value.Length.ToString());

            foreach (string[] row in rows) {
                instance.RoutingTable.Rows.Add(row);
            }

            foreach (DataGridViewColumn column in instance.RoutingTable.Columns) {
                column.Width = instance.RoutingTable.Size.Width / 8;
            }
        }

        private void OnClosing(Object sender, FormClosingEventArgs e) {
            Environment.Exit(0);
        }

        private string TimeStamp() {
            string hms = DateTime.Now.ToString("HH:mm:ss");
            string millis = DateTime.Now.Millisecond.ToString();
            string prefix = "";
            for (int i = 0; i < 3 - millis.Length; i++)
                prefix += "0";
            return "[" + hms + "." + prefix + millis + "] ";
        }

        public static void PrintLog(String message) {

            if (instance.PauseLogsCheckBox.Checked) {
                instance.logBuffer.Add(instance.TimeStamp() + message);
                return;
            }

            instance.LogBox.Invoke((MethodInvoker)delegate {
                if (!instance.LogBox.Text.Equals(""))
                    instance.LogBox.AppendText(Environment.NewLine);
                instance.LogBox.AppendText(instance.TimeStamp() + message);
            });
        }

        public static void PrintLogNoTimeStamp(String message) {

            if (instance.PauseLogsCheckBox.Checked) {
                instance.logBuffer.Add(instance.TimeStamp() + message);
                return;
            }

            instance.LogBox.Invoke((MethodInvoker)delegate {
                if (!instance.LogBox.Text.Equals(""))
                    instance.LogBox.AppendText(Environment.NewLine);
                instance.LogBox.AppendText(message);
            });
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            LogBox.Text = "";
            logBuffer.Clear();
        }

        private void PauseLogsCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (!PauseLogsCheckBox.Checked) {
                foreach(string log in logBuffer)
                    PrintLogNoTimeStamp(log);
                logBuffer.Clear();
            }
        }

        public static void ChangeWindowName(string newName) {
            instance.Invoke((MethodInvoker)delegate {
                instance.Text = newName;
            });

            instance.NameLabel.Invoke((MethodInvoker)delegate {
                instance.NameLabel.Text = newName;
            });
        }

        public static void ChangeIP(string ip) {
            instance.ownIP.Invoke((MethodInvoker)delegate {
                instance.ownIP.Text = ip;
            });
        }
    }
}
