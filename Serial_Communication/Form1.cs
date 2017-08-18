using System;
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

                    btnOpenPort.Enabled = false;
                    btnClosePort.Enabled = true;
                    metroTextBox1.Enabled = true;
                    btnSend.Enabled = true;
                    btnRead.Enabled = true;
                }
            }
            catch(UnauthorizedAccessException)
            {
                metroTextBox2.Text = "UnAuthorized Access";
            }
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
                serialPort1.Close();

                metroProgressBar1.Value = 0;
                btnOpenPort.Enabled = true;
                btnClosePort.Enabled = false;
                metroTextBox1.Enabled = false;
                btnSend.Enabled = false;
                btnRead.Enabled = false;
        }
    }
}
