using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;


namespace WindowsFormsApplication2
{
    public partial class SetupForm : Form
    {
        public static string InsComPort;
        public static string InsBaudRate;
        public static string BCRComPort;
        public static string BCRBaudRate;

        public SetupForm()
        {
            InitializeComponent();

            String[] ports = SerialPort.GetPortNames();                 //Search computer for available COM Ports
            InsComPortComboBox.Items.AddRange(ports);
            BCRComPortComboBox.Items.AddRange(ports);
            
            InsComPortComboBox.SelectedIndex = 0;
            InsBaudRateComboBox.SelectedIndex = 5;

            BCRComPortComboBox.SelectedIndex = 1;
            BCRBaudRateComboBox.SelectedIndex = 9;

            InsComPort = InsComPortComboBox.Text;
            InsBaudRate = InsBaudRateComboBox.Text;
            BCRComPort = BCRComPortComboBox.Text;
            BCRBaudRate = BCRBaudRateComboBox.Text;
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {

        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            InsComPort = InsComPortComboBox.Text;
            InsBaudRate = InsBaudRateComboBox.Text;
            BCRComPort = BCRComPortComboBox.Text;
            BCRBaudRate = BCRBaudRateComboBox.Text;

            Debug.WriteLine("**************");
            Debug.WriteLine(InsComPort);
            Debug.WriteLine(InsBaudRate);
            Debug.WriteLine(BCRComPort);
            Debug.WriteLine(BCRBaudRate);
            Debug.WriteLine("**************"); 
            this.Hide();
        }
    }
}
