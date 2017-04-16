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
            ((System.ComponentModel.ISupportInitialize)(this.trackbarBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // trackbarBrightness
            // 
            this.trackbarBrightness.LargeChange = 1;
            this.trackbarBrightness.Location = new System.Drawing.Point(12, 12);
            this.trackbarBrightness.Maximum = 100;
            this.trackbarBrightness.Name = "trackbarBrightness";
            this.trackbarBrightness.Size = new System.Drawing.Size(242, 45);
            this.trackbarBrightness.TabIndex = 0;
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
            this.checkboxAuto.Location = new System.Drawing.Point(261, 13);
            this.checkboxAuto.Name = "checkboxAuto";
            this.checkboxAuto.Size = new System.Drawing.Size(48, 17);
            this.checkboxAuto.TabIndex = 1;
            this.checkboxAuto.Text = "Auto";
            this.checkboxAuto.UseVisualStyleBackColor = true;
            this.checkboxAuto.CheckedChanged += new System.EventHandler(this.checkboxAuto_CheckedChanged);
            // 
            // timerSensor
            // 
            this.timerSensor.Enabled = true;
            this.timerSensor.Interval = 10000;
            this.timerSensor.Tick += new System.EventHandler(this.timerSensor_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 63);
            this.Controls.Add(this.checkboxAuto);
            this.Controls.Add(this.trackbarBrightness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Monitor Brightness Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackbarBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackbarBrightness;
        private System.IO.Ports.SerialPort serialportPc;
        private System.Windows.Forms.CheckBox checkboxAuto;
        private System.Windows.Forms.Timer timerSensor;
    }
}

