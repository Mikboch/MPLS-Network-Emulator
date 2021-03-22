namespace ClientNode {
    partial class GUIWindow {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        private void InitializeComponent() {
            this.NameLabel = new System.Windows.Forms.Label();
            this.Destination = new System.Windows.Forms.ComboBox();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.LogLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.PeriodLabel = new System.Windows.Forms.Label();
            this.PeriodBox = new System.Windows.Forms.NumericUpDown();
            this.ToggleButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.PauseLogsCheckBox = new System.Windows.Forms.CheckBox();
            this.ownIP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Roboto Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(112, 40);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Host";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Destination
            // 
            this.Destination.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Destination.FormattingEnabled = true;
            this.Destination.Location = new System.Drawing.Point(118, 435);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(196, 23);
            this.Destination.TabIndex = 1;
            // 
            // MessageBox
            // 
            this.MessageBox.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessageBox.Location = new System.Drawing.Point(102, 411);
            this.MessageBox.MaxLength = 50;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(350, 23);
            this.MessageBox.TabIndex = 2;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.White;
            this.LogBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogBox.Location = new System.Drawing.Point(8, 67);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(444, 338);
            this.LogBox.TabIndex = 3;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessageLabel.Location = new System.Drawing.Point(4, 410);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(92, 24);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Text = "Message:";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogLabel
            // 
            this.LogLabel.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogLabel.Location = new System.Drawing.Point(4, 40);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(92, 24);
            this.LogLabel.TabIndex = 5;
            this.LogLabel.Text = "Logs:";
            this.LogLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DestinationLabel.Location = new System.Drawing.Point(4, 434);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(108, 24);
            this.DestinationLabel.TabIndex = 6;
            this.DestinationLabel.Text = "Destination:";
            this.DestinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PeriodLabel
            // 
            this.PeriodLabel.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PeriodLabel.Location = new System.Drawing.Point(4, 458);
            this.PeriodLabel.Name = "PeriodLabel";
            this.PeriodLabel.Size = new System.Drawing.Size(175, 24);
            this.PeriodLabel.TabIndex = 7;
            this.PeriodLabel.Text = "Repeat period [ms]:";
            this.PeriodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PeriodBox
            // 
            this.PeriodBox.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PeriodBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.PeriodBox.Location = new System.Drawing.Point(185, 459);
            this.PeriodBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PeriodBox.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.PeriodBox.Name = "PeriodBox";
            this.PeriodBox.Size = new System.Drawing.Size(129, 23);
            this.PeriodBox.TabIndex = 9;
            this.PeriodBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ToggleButton
            // 
            this.ToggleButton.BackColor = System.Drawing.Color.LightGray;
            this.ToggleButton.FlatAppearance.BorderSize = 2;
            this.ToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleButton.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToggleButton.Location = new System.Drawing.Point(320, 437);
            this.ToggleButton.Name = "ToggleButton";
            this.ToggleButton.Size = new System.Drawing.Size(132, 49);
            this.ToggleButton.TabIndex = 10;
            this.ToggleButton.Text = "START";
            this.ToggleButton.UseVisualStyleBackColor = false;
            this.ToggleButton.Click += new System.EventHandler(this.ToggleButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClearButton.Location = new System.Drawing.Point(347, 32);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(110, 30);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "CLEAR LOGS";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // PauseLogsCheckBox
            // 
            this.PauseLogsCheckBox.AutoSize = true;
            this.PauseLogsCheckBox.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PauseLogsCheckBox.Location = new System.Drawing.Point(347, 7);
            this.PauseLogsCheckBox.Name = "PauseLogsCheckBox";
            this.PauseLogsCheckBox.Size = new System.Drawing.Size(93, 19);
            this.PauseLogsCheckBox.TabIndex = 14;
            this.PauseLogsCheckBox.Text = "Pause Logs";
            this.PauseLogsCheckBox.UseVisualStyleBackColor = true;
            this.PauseLogsCheckBox.CheckedChanged += new System.EventHandler(this.PauseLogsCheckBox_CheckedChanged);
            // 
            // ownIP
            // 
            this.ownIP.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ownIP.Location = new System.Drawing.Point(98, 12);
            this.ownIP.Name = "ownIP";
            this.ownIP.Size = new System.Drawing.Size(216, 24);
            this.ownIP.TabIndex = 15;
            this.ownIP.Text = "255.255.255.255/24";
            this.ownIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GUIWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(464, 491);
            this.Controls.Add(this.ownIP);
            this.Controls.Add(this.PauseLogsCheckBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ToggleButton);
            this.Controls.Add(this.PeriodBox);
            this.Controls.Add(this.PeriodLabel);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GUIWindow";
            this.Text = "Host";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ComboBox Destination;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.Label PeriodLabel;
        private System.Windows.Forms.NumericUpDown PeriodBox;
        private System.Windows.Forms.Button ToggleButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox PauseLogsCheckBox;
        private System.Windows.Forms.Label ownIP;
    }
}

