using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Management;
using BrightnessControl;

//using System.Diagnostics;
//using System.Windows;
//using System.Windows.Input;
using System.IO.Ports;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        Double CurrentBrightness = 0;
        Double NewBrightness = 0;
        DisplayConfiguration.PHYSICAL_MONITOR[] physicalMonitors;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Starting...");
            GetBrightness(sender, e);
            timerSensor_Tick(sender, e);
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          SEARCH SENSOR
        /// Description:    Search the brightness sensor on all existing COM ports by sending a "SensorQuery" command and waiting for a "BrightnessSensor" reply.
        ///                 At the end of the search the serialportPc will be closed.
        /// </summary>
        /// 
        /// <returns>
        /// Boolean:
        ///     - TRUE: sensor found;
        ///     - FALSE: Sensor not found
        /// </returns>
        /// 
        private bool SearchSensor()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                serialportPc.PortName = port;
                try
                {
                    serialportPc.Open();
                    serialportPc.DiscardOutBuffer();
                    serialportPc.WriteLine("SensorQuery");
                    serialportPc.DiscardInBuffer();     // The input buffer of the serial port must be discarded before reading a new string
                    string portread = serialportPc.ReadLine();
                    serialportPc.Close();
                    if (portread.StartsWith("BrightnessSensor"))
                    {
                        System.Diagnostics.Debug.WriteLine("Sensor found on " + port);
                        labelStatusSensor.Text = "sensor found";
                        labelSensorPort.Text = port;
                        labelSensorPort.ForeColor = System.Drawing.Color.Green;
                        return true;
                    }
                }
                catch
                {
                    serialportPc.Close();
                }
            }
            serialportPc.PortName = "NULL";
            System.Diagnostics.Debug.WriteLine("Sensor not found!");
            labelStatusSensor.Text = "sensor not found!";
            labelSensorPort.Text = "sensor not found!";
            labelSensorPort.ForeColor = System.Drawing.Color.Red;
            return false;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          TRACKBAR
        /// Description:    The trackbar can be used by the user to manually change the brightness of his monitor.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void trackbarBrightness_Scroll(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TRACKBAR = " + trackbarBrightness.Value);
            NewBrightness = Convert.ToDouble(trackbarBrightness.Value) / 100;
            SetBrightness(sender, e);

            // When the user manually changes the monitor brightness, Auto-update feature will be disabled.
            checkboxAuto.Checked = false;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          CHECKBOX AUTO
        /// Description:    The Checkbox is used to enable/disable the Auto-brightness feature and then the reading of the Arduino sensor. 
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void checkboxAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkboxAuto.Checked)
            {
                timerSensor.Stop();
            }
            else
            {
                timerSensor_Tick(sender, e);
            }
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          UPDATE OBJECTS
        /// Description:    this function updates the application gadgets with the CurrentBrightness.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void UpdateObjects(object sender, EventArgs e)
        {
            trackbarBrightness.Value = Convert.ToInt16(CurrentBrightness * 100);
            
            numericBrightness.ValueChanged -= numericBrightness_ValueChanged;
            numericBrightness.Value = Convert.ToInt16(CurrentBrightness * 100);
            numericBrightness.ValueChanged += numericBrightness_ValueChanged;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          GET BRIGHTNESS
        /// Description:    this function gets the list of handles to all monitors and register their current brightness in CurrentBrightness.  
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void GetBrightness(object sender, EventArgs e)
        {
            physicalMonitors = DisplayConfiguration.GetPhysicalMonitors(DisplayConfiguration.GetCurrentMonitor());
            foreach (DisplayConfiguration.PHYSICAL_MONITOR physicalMonitor in physicalMonitors)
            {
                try
                {
                    CurrentBrightness = DisplayConfiguration.GetMonitorBrightness(physicalMonitor);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("ERROR: cannot get brightness!");
                }
            }

            UpdateObjects(sender, e);
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          SET BRIGHTNESS
        /// Description:    this function gets the list of handles to all monitors and sets their brightness to the value NewBrightness. 
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void SetBrightness (object sender, EventArgs e)
        {
            if (NewBrightness != CurrentBrightness)
            {
                // Get current monitors
                physicalMonitors = DisplayConfiguration.GetPhysicalMonitors(DisplayConfiguration.GetCurrentMonitor());

                foreach (DisplayConfiguration.PHYSICAL_MONITOR physicalMonitor in physicalMonitors)
                {
                    try
                    {
                        DisplayConfiguration.SetMonitorBrightness(physicalMonitor, NewBrightness);
                        DisplayConfiguration.SetMonitorContrast(physicalMonitor, NewBrightness);
                        CurrentBrightness = NewBrightness;
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: cannot set brightness!");
                    }
                }
            }

            UpdateObjects(sender, e);
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          ACQUIRE BRIGHTNESS
        /// Description:    this function request a new acquisition to the sensor.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// <returns>
        /// Result [Boolean]:
        ///     - TRUE: acquisition failed;
        ///     - FALSE: acquisition succeded;
        /// </returns>
        /// 
        private bool AcquireBrightness (object sender, EventArgs e)
        {

            /// Trying to open the serialPort of the sensor. 
            /// If the serial port does not open, it tries to search the sensor on other serial ports.
            try
            {
                serialportPc.Open();
                labelStatusSensor.Text = "working";
            }
            catch
            {
                if (SearchSensor())
                {
                    serialportPc.Open();
                }
                else
                {
                    return true;
                }
            }

            try
            {
                /// Preparing serial port
                serialportPc.DiscardInBuffer();

                /// Demand a new measure to the sensor
                serialportPc.DiscardOutBuffer();
                serialportPc.WriteLine("SensorQuery");
                string indata = serialportPc.ReadLine();
                serialportPc.Close();

                /// The first 18 characters containing the string "BrightnessSensor: " are discarded here
                indata = indata.Substring(18);
                System.Diagnostics.Debug.WriteLine("SENSOR = " + indata);

                /// Try to parse an integer value from the aquired string.
                /// The sensor values is between 0 and 1024
                int SensorValue;
                int.TryParse(indata, out SensorValue);

                /// Convert the SensorValue to a double between 0 and 1.
                NewBrightness = Convert.ToDouble(SensorValue) / 1024;

                /// Brightness calibration
                //NewBrightness -= 0.1;   

                return false;
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("ERROR: serial port unavailable!");
                labelStatusSensor.Text = "serial port unavailable!";
                return true;
            }

        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          TIMER SENSOR
        /// Description:    At every tick of this timer a new brightness value is read from the Arduino Sensor and the brightness monitor is set with it.
        ///                 This function calls itself every period.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void timerSensor_Tick(object sender, EventArgs e)
        {
            /// Preparing next call to this function 
            timerSensor.Start();

            /// The monitor brightness will be set only if there is a sostantial difference between the new brightness and the old brightness.
            if (!AcquireBrightness(sender, e) && (NewBrightness > (CurrentBrightness + 0.05) || NewBrightness < (CurrentBrightness - 0.05)))
            {
                SetBrightness(sender, e);
            }
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          BUTTON UPDATE
        /// Description:    Used by the user to update the monitor brightness using the sensor.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            /// The monitor brightness will be set only if there is a sostantial difference between the new brightness and the old brightness.
            if (!AcquireBrightness(sender, e))
            {
                SetBrightness(sender, e);
            }
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          NUMERIC BRIGHTNESS
        /// Description:    Used by the user to manually set the monitor brightness and show the current one.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericBrightness_ValueChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("NUMERIC = " + numericBrightness.Value);
            NewBrightness = Convert.ToDouble(numericBrightness.Value) / 100;
            checkboxAuto.Checked = false;
            SetBrightness(sender, e);
        }

   
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          NUMERIC UPDATE PERIOD
        /// Description:    Used by the user to change the frequency with which the application reads the sensor and update the monitor brightness.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void numericUpdatePeriod_ValueChanged(object sender, EventArgs e)
        {
            this.timerSensor.Interval = Convert.ToInt32(numericUpdatePeriod.Value*1000);
            timerSensor.Start();
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          FORM1 RESIZE
        /// Description:    The Resize event has been re-defined in order to put the application in the Windows system tray when minimized.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyiconApp.Visible = true;   
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyiconApp.Visible = false;
                this.ShowInTaskbar = true;
                this.Show();
            }
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          NOTIFYICON APP
        /// Description:    When double clicking on the notification icon in the system tray we restor the application window.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void notifyiconApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          MENU ITEM AUTO-UPDATE
        /// Description:    Enable/disbale the auto-update of the monitor brightness using the sensor.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void menuitemAutoUpdate_Click(object sender, EventArgs e)
        {
            if (menuitemAutoUpdate.Checked) 
                menuitemAutoUpdate.Checked = false;
            else
                menuitemAutoUpdate.Checked = true;

            checkboxAuto.Checked = menuitemAutoUpdate.Checked;
            checkboxAuto_CheckedChanged(sender, e);
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Title:          MENU ITEM CLOSE
        /// Description:    Terminate the application.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void menuitemClose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
