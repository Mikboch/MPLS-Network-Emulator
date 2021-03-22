namespace ManagementCenter {
    partial class GUIWindow {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.PauseLogsCheckBox = new System.Windows.Forms.CheckBox();
            this.Logs = new System.Windows.Forms.TabPage();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RepairButton = new System.Windows.Forms.Button();
            this.Logs.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Management Center";
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClearButton.Location = new System.Drawing.Point(342, 43);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(110, 30);
            this.ClearButton.TabIndex = 14;
            this.ClearButton.Text = "CLEAR LOGS";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // PauseLogsCheckBox
            // 
            this.PauseLogsCheckBox.AutoSize = true;
            this.PauseLogsCheckBox.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PauseLogsCheckBox.Location = new System.Drawing.Point(342, 12);
            this.PauseLogsCheckBox.Name = "PauseLogsCheckBox";
            this.PauseLogsCheckBox.Size = new System.Drawing.Size(93, 19);
            this.PauseLogsCheckBox.TabIndex = 15;
            this.PauseLogsCheckBox.Text = "Pause Logs";
            this.PauseLogsCheckBox.UseVisualStyleBackColor = true;
            this.PauseLogsCheckBox.CheckedChanged += new System.EventHandler(this.PauseLogsCheckBox_CheckedChanged);
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.LogBox);
            this.Logs.Location = new System.Drawing.Point(4, 24);
            this.Logs.Name = "Logs";
            this.Logs.Padding = new System.Windows.Forms.Padding(3);
            this.Logs.Size = new System.Drawing.Size(432, 396);
            this.Logs.TabIndex = 0;
            this.Logs.Text = "Logs";
            this.Logs.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.White;
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogBox.Location = new System.Drawing.Point(3, 3);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(426, 390);
            this.LogBox.TabIndex = 8;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Logs);
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TabControl.Location = new System.Drawing.Point(12, 55);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(440, 424);
            this.TabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.RepairButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(432, 396);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Repair";
            // 
            // RepairButton
            // 
            this.RepairButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RepairButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RepairButton.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RepairButton.Location = new System.Drawing.Point(3, 3);
            this.RepairButton.Name = "RepairButton";
            this.RepairButton.Size = new System.Drawing.Size(426, 68);
            this.RepairButton.TabIndex = 0;
            this.RepairButton.Text = "Redirect Route";
            this.RepairButton.UseVisualStyleBackColor = true;
            this.RepairButton.Click += new System.EventHandler(this.RepairButton_Click);
            // 
            // GUIWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 491);
            this.Controls.Add(this.PauseLogsCheckBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GUIWindow";
            this.Text = "ManagementCenter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Logs.ResumeLayout(false);
            this.Logs.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox PauseLogsCheckBox;
        private System.Windows.Forms.TabPage Logs;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button RepairButton;
    }
}

