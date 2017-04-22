namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trackbarBrightness = new System.Windows.Forms.TrackBar();
            this.serialportPc = new System.IO.Ports.SerialPort(this.components);
            this.checkboxAuto = new System.Windows.Forms.CheckBox();
            this.timerSensor = new System.Windows.Forms.Timer(this.components);
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.groupboxSensor = new System.Windows.Forms.GroupBox();
            this.labelOffset = new System.Windows.Forms.Label();
            this.numericOffset = new System.Windows.Forms.NumericUpDown();
            this.labelSensorPort = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelUpdatePeriod = new System.Windows.Forms.Label();
            this.numericUpdatePeriod = new System.Windows.Forms.NumericUpDown();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatusTitle = new System.Windows.Forms.Label();
            this.numericBrightness = new System.Windows.Forms.NumericUpDown();
            this.notifyiconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextmenustripSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemAutoUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarBrightness)).BeginInit();
            this.groupboxSensor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpdatePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBrightness)).BeginInit();
            this.contextmenustripSystemTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackbarBrightness
            // 
            this.trackbarBrightness.LargeChange = 100;
            this.trackbarBrightness.Location = new System.Drawing.Point(49, 39);
            this.trackbarBrightness.Maximum = 100;
            this.trackbarBrightness.Name = "trackbarBrightness";
            this.trackbarBrightness.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackbarBrightness.Size = new System.Drawing.Size(45, 165);
            this.trackbarBrightness.SmallChange = 10;
            this.trackbarBrightness.TabIndex = 1;
            this.trackbarBrightness.TickFrequency = 10;
            this.trackbarBrightness.Scroll += new System.EventHandler(this.trackbarBrightness_Scroll);
            // 
            // serialportPc
            // 
            this.serialportPc.PortName = "NULL";
            this.serialportPc.ReadTimeout = 100;
            // 
            // checkboxAuto
            // 
            this.checkboxAuto.AutoSize = true;
            this.checkboxAuto.Checked = true;
            this.checkboxAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAuto.Location = new System.Drawing.Point(15, 91);
            this.checkboxAuto.Name = "checkboxAuto";
            this.checkboxAuto.Size = new System.Drawing.Size(86, 17);
            this.checkboxAuto.TabIndex = 2;
            this.checkboxAuto.Text = "Auto-Update";
            this.checkboxAuto.UseVisualStyleBackColor = true;
            this.checkboxAuto.CheckedChanged += new System.EventHandler(this.checkboxAuto_CheckedChanged);
            // 
            // timerSensor
            // 
            this.timerSensor.Enabled = true;
            this.timerSensor.Interval = 10000;
            this.timerSensor.Tick += new System.EventHandler(this.timerSensor_Tick);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(80, 184);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(24, 13);
            this.labelMin.TabIndex = 2;
            this.labelMin.Text = "Min";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(80, 46);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(27, 13);
            this.labelMax.TabIndex = 3;
            this.labelMax.Text = "Max";
            // 
            // groupboxSensor
            // 
            this.groupboxSensor.Controls.Add(this.labelOffset);
            this.groupboxSensor.Controls.Add(this.numericOffset);
            this.groupboxSensor.Controls.Add(this.labelSensorPort);
            this.groupboxSensor.Controls.Add(this.labelPort);
            this.groupboxSensor.Controls.Add(this.labelUpdatePeriod);
            this.groupboxSensor.Controls.Add(this.numericUpdatePeriod);
            this.groupboxSensor.Controls.Add(this.buttonUpdate);
            this.groupboxSensor.Controls.Add(this.checkboxAuto);
            this.groupboxSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupboxSensor.Location = new System.Drawing.Point(144, 19);
            this.groupboxSensor.Name = "groupboxSensor";
            this.groupboxSensor.Size = new System.Drawing.Size(181, 192);
            this.groupboxSensor.TabIndex = 4;
            this.groupboxSensor.TabStop = false;
            this.groupboxSensor.Text = "Sensor";
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(68, 157);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(52, 13);
            this.labelOffset.TabIndex = 11;
            this.labelOffset.Text = "Offset [%]";
            // 
            // numericOffset
            // 
            this.numericOffset.Location = new System.Drawing.Point(15, 153);
            this.numericOffset.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOffset.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.numericOffset.Name = "numericOffset";
            this.numericOffset.Size = new System.Drawing.Size(46, 20);
            this.numericOffset.TabIndex = 10;
            this.numericOffset.ValueChanged += new System.EventHandler(this.numericOffset_ValueChanged);
            // 
            // labelSensorPort
            // 
            this.labelSensorPort.AutoSize = true;
            this.labelSensorPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSensorPort.ForeColor = System.Drawing.Color.Red;
            this.labelSensorPort.Location = new System.Drawing.Point(41, 22);
            this.labelSensorPort.Name = "labelSensorPort";
            this.labelSensorPort.Size = new System.Drawing.Size(63, 13);
            this.labelSensorPort.TabIndex = 9;
            this.labelSensorPort.Text = "Not found";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(12, 22);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 8;
            this.labelPort.Text = "Port:";
            // 
            // labelUpdatePeriod
            // 
            this.labelUpdatePeriod.AutoSize = true;
            this.labelUpdatePeriod.Location = new System.Drawing.Point(67, 127);
            this.labelUpdatePeriod.Name = "labelUpdatePeriod";
            this.labelUpdatePeriod.Size = new System.Drawing.Size(88, 13);
            this.labelUpdatePeriod.TabIndex = 7;
            this.labelUpdatePeriod.Text = "Update period [s]";
            // 
            // numericUpdatePeriod
            // 
            this.numericUpdatePeriod.Location = new System.Drawing.Point(15, 123);
            this.numericUpdatePeriod.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpdatePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpdatePeriod.Name = "numericUpdatePeriod";
            this.numericUpdatePeriod.Size = new System.Drawing.Size(46, 20);
            this.numericUpdatePeriod.TabIndex = 3;
            this.numericUpdatePeriod.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpdatePeriod.ValueChanged += new System.EventHandler(this.numericUpdatePeriod_ValueChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(15, 51);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(126, 24);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(48, 214);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(96, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "searching sensor...";
            // 
            // labelStatusTitle
            // 
            this.labelStatusTitle.AutoSize = true;
            this.labelStatusTitle.Location = new System.Drawing.Point(2, 214);
            this.labelStatusTitle.Name = "labelStatusTitle";
            this.labelStatusTitle.Size = new System.Drawing.Size(40, 13);
            this.labelStatusTitle.TabIndex = 2;
            this.labelStatusTitle.Text = "Status:";
            // 
            // numericBrightness
            // 
            this.numericBrightness.Location = new System.Drawing.Point(39, 13);
            this.numericBrightness.Name = "numericBrightness";
            this.numericBrightness.Size = new System.Drawing.Size(47, 20);
            this.numericBrightness.TabIndex = 0;
            this.numericBrightness.ValueChanged += new System.EventHandler(this.numericBrightness_ValueChanged);
            // 
            // notifyiconApp
            // 
            this.notifyiconApp.ContextMenuStrip = this.contextmenustripSystemTray;
            this.notifyiconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyiconApp.Icon")));
            this.notifyiconApp.Text = "Monitor Brightness Control";
            this.notifyiconApp.Visible = true;
            this.notifyiconApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyiconApp_MouseDoubleClick);
            // 
            // contextmenustripSystemTray
            // 
            this.contextmenustripSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemAutoUpdate,
            this.menuitemClose});
            this.contextmenustripSystemTray.Name = "contextMenuStrip1";
            this.contextmenustripSystemTray.Size = new System.Drawing.Size(144, 48);
            // 
            // menuitemAutoUpdate
            // 
            this.menuitemAutoUpdate.Checked = true;
            this.menuitemAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuitemAutoUpdate.Name = "menuitemAutoUpdate";
            this.menuitemAutoUpdate.Size = new System.Drawing.Size(143, 22);
            this.menuitemAutoUpdate.Text = "Auto-Update";
            this.menuitemAutoUpdate.Click += new System.EventHandler(this.menuitemAutoUpdate_Click);
            // 
            // menuitemClose
            // 
            this.menuitemClose.Name = "menuitemClose";
            this.menuitemClose.Size = new System.Drawing.Size(143, 22);
            this.menuitemClose.Text = "Close";
            this.menuitemClose.Click += new System.EventHandler(this.menuitemClose_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 229);
            this.Controls.Add(this.numericBrightness);
            this.Controls.Add(this.groupboxSensor);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelStatusTitle);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.trackbarBrightness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(353, 268);
            this.MinimumSize = new System.Drawing.Size(353, 268);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Monitor Brightness Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackbarBrightness)).EndInit();
            this.groupboxSensor.ResumeLayout(false);
            this.groupboxSensor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpdatePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBrightness)).EndInit();
            this.contextmenustripSystemTray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackbarBrightness;
        private System.IO.Ports.SerialPort serialportPc;
        private System.Windows.Forms.CheckBox checkboxAuto;
        private System.Windows.Forms.Timer timerSensor;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.GroupBox groupboxSensor;
        private System.Windows.Forms.Label labelStatusTitle;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelUpdatePeriod;
        private System.Windows.Forms.NumericUpDown numericUpdatePeriod;
        private System.Windows.Forms.NumericUpDown numericBrightness;
        private System.Windows.Forms.Label labelSensorPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.NotifyIcon notifyiconApp;
        private System.Windows.Forms.ContextMenuStrip contextmenustripSystemTray;
        private System.Windows.Forms.ToolStripMenuItem menuitemClose;
        private System.Windows.Forms.ToolStripMenuItem menuitemAutoUpdate;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.NumericUpDown numericOffset;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

