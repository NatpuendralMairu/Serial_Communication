using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO.Ports;

namespace Serial_Communication
{
    public partial class Serial_Comm : MetroFramework.Forms.MetroForm
    {
        public Serial_Comm()
        {
            InitializeComponent();
            getAvailablePortNames();
        }

        void getAvailablePortNames()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPorts.Text =="" || comboBoxBaudRt.Text == "")
                {
                    metroTextBox2.Text = "Please Select the Port Settings";
                }
                else
                {
                    serialPort1.PortName = comboBoxPorts.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudRt.Text);
                    serialPort1.Open();
                    metroProgressBar1.Value = 100;

                    metroButton1.Enabled = false;
                    metroButton2.Enabled = true;
                    metroTextBox1.Enabled = true;
                    metroButton3.Enabled = true;
                    metroButton4.Enabled = true;
                }
            }
            catch(UnauthorizedAccessException)
            {
                metroTextBox2.Text = "UnAuthorized Access";
            }
        }
    }
}
