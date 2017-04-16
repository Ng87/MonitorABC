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
        DisplayConfiguration.PHYSICAL_MONITOR[] physicalMonitors;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Starting...");
            timerSensor_Tick(sender, e);
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /// SEARCHSENSOR
        /// Search the brightness sensor on all available COM ports.
        /// </summary>
        /// <returns>
        /// Boolean:
        ///     - TRUE: sensor found;
        ///     - FALSE: Sensor not found
        /// </returns>
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
                    if (portread.StartsWith("BrightnessSensor: "))
                    {
                        System.Diagnostics.Debug.WriteLine("Sensor found on " + port);
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
            return false;
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /// TRACKBAR
        /// The trackbar can be used by the user to manually change the brightness of his monitor.
        /// The Scroll event of the Trackbar causes the call to this function. 
        /// The Trackbar gives an integrer value from 0 to 100, the monitor accepts a double value from 0 to 1.
        /// This function disables the Auto-Brightness feature.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void trackbarBrightness_Scroll(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TRACKBAR = " + trackbarBrightness.Value);
            physicalMonitors = DisplayConfiguration.GetPhysicalMonitors(DisplayConfiguration.GetCurrentMonitor());  // Get current monitors

            foreach (DisplayConfiguration.PHYSICAL_MONITOR physicalMonitor in physicalMonitors)
            {
                try
                {
                    CurrentBrightness = Convert.ToDouble(trackbarBrightness.Value) / 100;
                    DisplayConfiguration.SetMonitorBrightness(physicalMonitor, CurrentBrightness);
                    DisplayConfiguration.SetMonitorContrast(physicalMonitor, CurrentBrightness);
                    checkboxAuto.Checked = false;
                }
                catch
                {
                }
            }
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// /// CHECKBOX
        /// <summary>
        /// The Checkbox is used to enable/disable the Auto-brightness feature and then the reading of the Arduino sensor. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        /// /// TIMER SENSOR
        /// <summary>
        /// At every tick of this timer a new brightness value is read from the Arduino Sensor and the brightness monitor is set with it.
        /// This function calls itself every 10 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void timerSensor_Tick(object sender, EventArgs e)
        {
            /// Preparing next call to this function 
            timerSensor.Start();

            /// Trying to open the serialPort of the sensor. 
            /// If the serial port does not open, it tries to search the sensor on other serial ports.
            try
            {
                serialportPc.Open();
            }
            catch
            {  
                if (SearchSensor())
                    serialportPc.Open();
                else
                    return;
            }

            // Get current monitors
            physicalMonitors = DisplayConfiguration.GetPhysicalMonitors(DisplayConfiguration.GetCurrentMonitor());

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
                Double NewBrightness = Convert.ToDouble(SensorValue) / 1024;

                /// Brightness calibration
                //NewBrightness -= 0.1;   

                           
                foreach (DisplayConfiguration.PHYSICAL_MONITOR physicalMonitor in physicalMonitors)
                {
                    try
                    {
                        CurrentBrightness = DisplayConfiguration.GetMonitorBrightness(physicalMonitor);

                        /// The monitor brightness will be set only if there is a sostantial difference between the new brightness and the old brightness.
                        if (NewBrightness > (CurrentBrightness + 0.05) || NewBrightness < (CurrentBrightness - 0.05))
                        {
                            CurrentBrightness = NewBrightness;

                            DisplayConfiguration.SetMonitorBrightness(physicalMonitor, CurrentBrightness);
                            DisplayConfiguration.SetMonitorContrast(physicalMonitor, CurrentBrightness);
                        }

                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: cannot set brightness!");
                    }
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("ERROR: serial port unavailable!");
            }

            trackbarBrightness.Value = Convert.ToInt16(CurrentBrightness * 100);
        }
        





    }
}
