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
using FrameLib;

namespace ClientNode {
    public partial class GUIWindow : Form {

        private static GUIWindow instance;
        private List<string> logBuffer = new List<string>();
        private readonly Dictionary<string, string> hostIPs = new Dictionary<string, string>();
        private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public GUIWindow() {
            InitializeComponent();

            instance = this;

            SetButtonGreen();

            lock (Program.waiterConfig) {
                Monitor.Pulse(Program.waiterConfig);
            }

            timer.Tick += new EventHandler(SendOutPacket);
            timer.Enabled = false;
            timer.Stop();
        }

        private void OnClosing(Object sender, FormClosingEventArgs e) {
            new Thread(() => {
                Thread.Sleep(10);
                Environment.Exit(0);
            }).Start();

            Program.cloudConnection.DisconnectFromCloud();
        }

        private void ToggleButton_Click(object sender, EventArgs e) {
            switch (ToggleButton.Text) {
                case "START":

                    if (Destination.Text.Length == 0) {
                        GUIWindow.PrintLog("Select correct destination!");
                        break;
                    }

                    ToggleButton.Text = "STOP";
                    SetButtonRed();

                    SendOutPacket(null, null);

                    timer.Interval = Convert.ToInt32(Math.Round(PeriodBox.Value, 0));
                    timer.Enabled = true;
                    timer.Start();

                    break;

                case "STOP":
                    ToggleButton.Text = "START";
                    SetButtonGreen();

                    timer.Enabled = false;
                    timer.Stop();

                    break;
            }
        }

        private void SendOutPacket(object sender, EventArgs e) {
            //string request = "GET_LABEL " + Destination.Text[Destination.Text.Length - 1];
            //ManagementCenterConnection.SendLabelRequest(request);
            //PrintLog("Sending MPLS label request to Management Center");
            SendMessage();
        }

        public static void SendMessage(string initialLabel) {
            string ip = "";
            instance.Destination.Invoke((MethodInvoker)delegate {
                instance.hostIPs.TryGetValue(instance.Destination.Text, out ip);
            });

            instance.MessageBox.Invoke((MethodInvoker)delegate {
                CloudConnection.SendMessage(instance.MessageBox.Text, ip, initialLabel);
            });
        }

        public static void SendMessage() {
            string ip = "";
            instance.Destination.Invoke((MethodInvoker)delegate {
                instance.hostIPs.TryGetValue(instance.Destination.Text, out ip);
            });

            string txt = instance.Destination.Text;
            string[] arr = txt.Split(' ');
            string initialLabel = arr[1].Split('#')[1];

            instance.MessageBox.Invoke((MethodInvoker)delegate {
                CloudConnection.SendMessage(instance.MessageBox.Text, ip, initialLabel);
            });
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            LogBox.Text = "";
        }

        private void SetButtonGreen() {
            ToggleButton.ForeColor = Color.FromArgb(125, 166, 125);
            ToggleButton.BackColor = Color.FromArgb(192, 255, 192);
            ToggleButton.FlatAppearance.BorderColor = Color.FromArgb(163, 217, 163);
        }

        private void SetButtonRed() {
            ToggleButton.ForeColor = Color.FromArgb(166, 125, 125);
            ToggleButton.BackColor = Color.FromArgb(255, 192, 192);
            ToggleButton.FlatAppearance.BorderColor = Color.FromArgb(217, 163, 163);
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

        private void PauseLogsCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (!PauseLogsCheckBox.Checked) {
                foreach (string log in logBuffer)
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

        public static void AddDestinations() {
            instance.Destination.Invoke((MethodInvoker)delegate {
                //foreach (Tuple<int, string, int> t in ConfigLoader.otherHosts) {
                foreach (Tuple<int, string, int, int> t in ConfigLoader.otherAvailableHosts) {
                    string key = "Host" + (t.Item1) + " #" + (t.Item4);
                    instance.Destination.Items.Add(key);
                    instance.hostIPs.Add(key, t.Item2 + "/24");
                }

            });
        }
    }
}
