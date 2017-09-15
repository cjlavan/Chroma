using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace WindowsFormsApplication2
{
    public partial class MainProgram : Form
    {
        //Get default COM Settings
        public string InsComPort = SerialPort.GetPortNames()[0];
        public string BCRComPort = SerialPort.GetPortNames()[1];
        public string InsBaudRate = "9600";
        public string BCRBaudRate = "38400";

        //Variable Declarations
        int fileReaderCounter = 0;
        string line;
        int setupIndex = 0;
        int isAdmin2;
        string userName2;
        string mystring = "";
        string testString = "";
        int testFlag = 0;
        int i = 0;
        int j = 0;
        int k = 0;
        int l = 0;
        int TestInfoFlag = 0;

        string[] LCDEV = new string[6];
        string[] LCLines = new string[6];
        string[] LCGswi = new string[6];
        string[] LCMETER = new string[6];
        string[] LCLIMIT = new string[6];
        string[] LCLIMLOW = new string[6];
        string[] LCPOWMODE = new string[6];
        string[] LCTESTTIME = new string[6];
        string[] LCCHAN = new string[6];

        string GBLEVEL;
        string GBLIMIT;
        string GBLIMITLOW;
        string GBTIME;
        string GBTPORT;

        string ACVOLTAGE;
        string ACLIMIT;
        string ACLIMITLOW;
        string ACLIMITARC;
        string ACLIMITARCFILTER;
        string ACTIME;
        string ACTIMERAMP;
        string ACCHAN;
        string ACCHANLOW;

        


        string[][] serDataArray = new string[4][]
        { new string[8], new string[8], new string[8], new string[8] };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Location = Owner.Location;
            this.Size = Owner.Size; //Makes new form same size as previous screen
        }

        public MainProgram(int isAdmin, string userName)
        {
            InitializeComponent();
                       
            isAdmin2 = isAdmin;                                         //Create local variable for admin priviledges
            userName2 = userName;

            if (isAdmin2 == 1)                                          //Enable menu items if admin, disable if not
            {
                addUserToolStripMenuItem.Enabled = true;
                ProgramBtn.Enabled = true;
            }
            else
            {
                addUserToolStripMenuItem.Enabled = false;
                ProgramBtn.Enabled = false;
            }
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            this.myDelegate = new AddDataDelegate(AddDataMethod);       //Initialize to handle incoming serial events on serialPort1
            this.myDelegate2 = new AddDataDelegate2(AddDataMethod2);    //Initialize to handle incoming serial events on serialPort2

            InsComPortTextBox.Text = InsComPort;
            InsBaudRateTextBox.Text = InsBaudRate;
            BCRComPortTextBox.Text = BCRComPort;
            BCRBaudRateTextBox.Text = BCRBaudRate;
        }

        private void OpenPortBtn_Click(object sender, EventArgs e)
        {
            
            try
            {//Open Chroma COM Port
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = InsComPortTextBox.Text;
                    serialPort1.BaudRate = Convert.ToInt32(InsBaudRateTextBox.Text);
                    serialPort1.Open();
                    OpenPortBtn.Enabled = true;
                    Debug.WriteLine("serialPort1.Open");
                    //serialPort1.Write("*IDN?\r\n");  //Test COM Port   
                    serialPort1.Write("SAFE:RES:AREP ON\r\n");  //Turn on Auto Reporting
                    setupIndex = 6;
                    //StatusBox.BackColor = System.Drawing.Color.Green;
                    OpenPortBtn.BackColor = System.Drawing.Color.Green;
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox2.Text = "Unauthorized Access";
            }
            
            try
            {//Open Barcode Reader COM Port 
                if (!serialPort2.IsOpen)
                {
                    serialPort2.PortName = BCRComPortTextBox.Text;
                    serialPort2.BaudRate = Convert.ToInt32(BCRBaudRateTextBox.Text);
                    serialPort2.Open();
                    OpenPortBtn.Enabled = true;
                    Debug.WriteLine("serialPort2.Open");
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox2.Text = "Unauthorized Access";
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("No COM");
            }
            else if (IlluminatorSN.Text=="" || WorkOrderNum.Text=="" || ModelNum.Text == "" || BallastSN.Text == "" || LampSN.Text == "" || PartNum.Text == "")
            {
                MessageBox.Show("Make sure all fields are filled");
            }
            else
            {
                GetSetupInfo();
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("SAFE:STOP\r\n");
            textBox2.Text = "Stopped";
        }

        private void SetupBtn_Click(object sender, EventArgs e)
        {
            SetupForm newform = new SetupForm();
            newform.StartPosition = FormStartPosition.CenterParent;
            newform.ShowDialog();

            InsComPort = SetupForm.InsComPort;
            InsBaudRate = SetupForm.InsBaudRate;
            BCRComPort = SetupForm.BCRComPort;
            BCRBaudRate = SetupForm.BCRBaudRate;

            InsComPortTextBox.Text = InsComPort;
            InsBaudRateTextBox.Text = InsBaudRate;
            BCRComPortTextBox.Text = BCRComPort;
            BCRBaudRateTextBox.Text = BCRBaudRate;

            Debug.WriteLine(InsComPort);
            Debug.WriteLine(InsBaudRate);
            Debug.WriteLine(BCRComPort);
            Debug.WriteLine(BCRBaudRate);
        }

        private void ProgramBtn_Click(object sender, EventArgs e)
        {
            //Check for serial port
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("No COM Port");
            }
            else
            {
                StreamReader tempFile = new StreamReader("C:\\Users\\clavan\\Desktop\\ChromaTestProfile.txt");
                while ((line = tempFile.ReadLine()) != null)
                {
                    serialPort1.Write(line + "\n\r");
                    fileReaderCounter++;
                }
                tempFile.Close();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser newform = new AddUser(isAdmin2);
            newform.StartPosition = FormStartPosition.CenterParent;
            newform.ShowDialog();
        }

        private void programMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();                        //Closes all forms and process on exit
        }

        private void GetTestResults()
        {
            testFlag = 1;                                                           //Set testFlag for test data string
            serialPort1.WriteLine("SAFE:RES:ALL:MODE?\n\r");    Thread.Sleep(500);  //Get the mode of all steps
            serialPort1.WriteLine("SAFE: RES:ALL:OMET?\n\r");   Thread.Sleep(500);  //Get the OUTPUT METER voltage readers for each step
            serialPort1.WriteLine("SAFE:RES:ALL:MMET?\n\r");    Thread.Sleep(500);  //Returns the MEASURE METER readings for each step
            serialPort1.WriteLine("SAFE:RES:ALL?\n\r");         Thread.Sleep(500);  //Returns judgement results of all steps ex:
        }
        
        private void GetSetupInfo()
        {
            TestInfoFlag = 1;

            //SAFE:STEP1:GB?
            //SAFE:STEP1:GB:LIM?
            //SAFE:STEP1:GB:LIM:LOW?
            //SAFE:STEP1:GB:TIME?
            //SAFE:STEP1:GB:TPOR?
            
            //SAFE:STEP2:LC:DEV?
            serialPort1.Write("SAFE:STEP1:LC:DEV?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:DEV?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:DEV?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:DEV?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:DEV?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:DEV?\r\n");
            //SAFE:STEP2:LC:LINE?
            serialPort1.Write("SAFE:STEP1:LC:LINE?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:LINE?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:LINE?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:LINE?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:LINE?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:LINE?\r\n");
            //SAFE:STEP2:LC:GSWI?
            serialPort1.Write("SAFE:STEP1:LC:GSWI?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:GSWI?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:GSWI?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:GSWI?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:GSWI?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:GSWI?\r\n");
            //SAFE:STEP2:LC:METE?
            serialPort1.Write("SAFE:STEP1:LC:METE?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:METE?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:METE?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:METE?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:METE?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:METE?\r\n");
            //SAFE:STEP2:LC:LIM?
            serialPort1.Write("SAFE:STEP1:LC:LIM?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:LIM?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:LIM?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:LIM?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:LIM?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:LIM?\r\n");
            //SAFE:STEP2:LC:LIM:LOW?
            serialPort1.Write("SAFE:STEP1:LC:LIM:LOW?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:LIM:LOW?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:LIM:LOW?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:LIM:LOW?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:LIM:LOW?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:LIM:LOW?\r\n");
            //SAFE:STEP2:LC:POW:MODE?
            serialPort1.Write("SAFE:STEP1:LC:POW:MODE?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:POW:MODE?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:POW:MODE?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:POW:MODE?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:POW:MODE?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:POW:MODE?\r\n");
            //SAFE:STEP2:LC:TIME?
            serialPort1.Write("SAFE:STEP1:LC:TIME?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:TIME?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:TIME?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:TIME?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:TIME?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:TIME?\r\n");
            //SAFE:STEP3:LC:CHAN?
            serialPort1.Write("SAFE:STEP1:LC:CHAN?\r\n");
            serialPort1.Write("SAFE:STEP2:LC:CHAN?\r\n");
            serialPort1.Write("SAFE:STEP3:LC:CHAN?\r\n");
            serialPort1.Write("SAFE:STEP4:LC:CHAN?\r\n");
            serialPort1.Write("SAFE:STEP5:LC:CHAN?\r\n");
            serialPort1.Write("SAFE:STEP6:LC:CHAN?\r\n");
            //SAFE:STEP7:AC
            serialPort1.Write("SAFE:STEP7:AC?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:LIM?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:LIM:LOW?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:LIM:ARC?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:LIM:ARC:FILT?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:TIME?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:TIME:RAMP?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:CHAN?\r\n");
            serialPort1.Write("SAFE:STEP7:AC:CHAN:LOW?\r\n");

            serialPort1.Write("SAFE:START\r\n");
            textBox2.Text = "Testing";
        }

        private void ReceiveSetupInfo(string mySerString)
        {
            
            /*if (setupIndex == 1)
            {// GB
                GBLEVEL = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 2)
            {// GBLIMIT
                GBLIMIT= mySerString;
                setupIndex++;
            }
            else if (setupIndex == 3)
            {// GBLIMITLOW
                GBLIMITLOW = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 4)
            {// GBTIME
                GBTIME = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 5)
            {// GBTPORT
                GBTPORT = mySerString;
                setupIndex++;
            }*/  
            if (setupIndex == 6)
            {// LCDEV
                LCDEV[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 7)
            {// LCLINE
                LCLines[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 8)
            {// LCGSWI
                LCGswi[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 9)
            {// LCMETER
                LCMETER[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 10)
            {// LCLIMIT
                LCLIMIT[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 11)
            {// LCLIMLOW
                LCLIMLOW[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 12)
            {// LCPOWMODE
                LCPOWMODE[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 13)
            {// LCTESTTIME
                LCTESTTIME[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 14)
            {// LCCHAN
                LCCHAN[j] = mySerString;
                j++;
                if (j >= 6)
                {
                    j = 0;
                    setupIndex++;
                }
            }
            else if (setupIndex == 15)
            {// ACVOLTAGE
                ACVOLTAGE = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 16)
            {// ACLIMIT
                ACLIMIT = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 17)
            {// ACLIMITLOW
                ACLIMITLOW = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 18)
            {// ACLIMITARC
                ACLIMITARC = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 19)
            {// ACLIMITARCFILTER
                ACLIMITARCFILTER = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 20)
            {// ACTIME
                ACTIME = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 21)
            {// ACTIMERAMP
                ACTIMERAMP = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 22)
            {// ACCHAN
                ACCHAN = mySerString;
                setupIndex++;
            }
            else if (setupIndex == 23)
            {// ACCHANLOW
                ACCHANLOW = mySerString;
                setupIndex++;
            }
        }

        private void WriteToDB()
        {
            for (int count = 0; count < 7; count++)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\clavan\Downloads\FRPSE4ZGA1BD540\C#\ChromaLoginDB.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [TestData] (Username, TestDate, IlluminatorSN, OMET, MMET, Judgement, WorkOrderNumber, ModelNumber, PartNumber, BallastSN, LampSN, ChromaModel, ChromaSerial, ChromaCalDate, Mode, LCDEV, LCLine, LCGswi, LCMETER, LCLIMIT, LCLIMLOW, LCPOWMODE, TestTime, LCCHAN, GBLEVEL, GBLIMIT, GBLIMITLOW, GBTIME, GBTPORT, ACVOLTAGE, ACLIMIT, ACLIMITLOW, ACLIMITARC, ACLIMITARCFILTER, ACTIME, ACTIMERAMP, ACCHAN, ACCHANLOW) VALUES (@Username, @TestDate, @IlluminatorSN, @OMET, @MMET, @Judgement, @WorkOrderNumber, @ModelNumber, @PartNumber, @BallastSN, @LampSN, @ChromaModel, @ChromaSerial, @ChromaCalDate, @Mode, @LCDEV, @LCLine, @LCGswi, @LCMETER, @LCLIMIT, @LCLIMLOW, @LCPOWMODE, @TestTime, @LCCHAN, @GBLEVEL, @GBLIMIT, @GBLIMITLOW, @GBTIME, @GBTPORT, @ACVOLTAGE, @ACLIMIT, @ACLIMITLOW, @ACLIMITARC, @ACLIMITARCFILTER, @ACTIME, @ACTIMERAMP, @ACCHAN, @ACCHANLOW)", con);

                cmd.Parameters.AddWithValue("@Username", userName2);
                cmd.Parameters.AddWithValue("@TestDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@IlluminatorSN", IlluminatorSN.Text);
                cmd.Parameters.AddWithValue("@OMET", serDataArray[1][count]);
                cmd.Parameters.AddWithValue("@MMET", serDataArray[2][count]);
                cmd.Parameters.AddWithValue("@Judgement", serDataArray[3][count]);
                cmd.Parameters.AddWithValue("@WorkOrderNumber", WorkOrderNum.Text);
                cmd.Parameters.AddWithValue("@ModelNumber", ModelNum.Text);
                cmd.Parameters.AddWithValue("@PartNumber", PartNum.Text);
                cmd.Parameters.AddWithValue("@BallastSN", BallastSN.Text);
                cmd.Parameters.AddWithValue("@LampSN", LampSN.Text);
                cmd.Parameters.AddWithValue("@ChromaModel", ChromaModelTextBox.Text);
                cmd.Parameters.AddWithValue("@ChromaSerial", ChromaSerialTextBox.Text);
                cmd.Parameters.AddWithValue("@ChromaCalDate", ChromaCalDateTextBox.Text);
                cmd.Parameters.AddWithValue("@Mode", serDataArray[0][count]);

                if (String.Equals(serDataArray[0][count].Substring(0, 2), "LC", StringComparison.Ordinal))
                {
                    cmd.Parameters.AddWithValue("@LCDEV", LCDEV[count]);
                    cmd.Parameters.AddWithValue("@LCLine", LCLines[count]);
                    cmd.Parameters.AddWithValue("@LCGswi", LCGswi[count]);
                    cmd.Parameters.AddWithValue("@LCMETER", LCMETER[count]);
                    cmd.Parameters.AddWithValue("@LCLIMIT", LCLIMIT[count]);
                    cmd.Parameters.AddWithValue("@LCLIMLOW", LCLIMLOW[count]);
                    cmd.Parameters.AddWithValue("@LCPOWMODE", LCPOWMODE[count]);
                    cmd.Parameters.AddWithValue("@TestTime", LCTESTTIME[count]);
                    cmd.Parameters.AddWithValue("@LCCHAN", LCCHAN[count]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@LCDEV", "N/A");
                    cmd.Parameters.AddWithValue("@LCLine", "N/A");
                    cmd.Parameters.AddWithValue("@LCGswi", "N/A");
                    cmd.Parameters.AddWithValue("@LCMETER", "N/A");
                    cmd.Parameters.AddWithValue("@LCLIMIT", "N/A");
                    cmd.Parameters.AddWithValue("@LCLIMLOW", "N/A");
                    cmd.Parameters.AddWithValue("@LCPOWMODE", "N/A");
                    cmd.Parameters.AddWithValue("@TestTime", "N/A");
                    cmd.Parameters.AddWithValue("@LCCHAN", "N/A");
                }

                if (String.Equals(serDataArray[0][count].Substring(0, 2), "GB", StringComparison.Ordinal))
                {
                    cmd.Parameters.AddWithValue("@GBLEVEL", GBLEVEL);
                    cmd.Parameters.AddWithValue("@GBLIMIT", GBLIMIT);
                    cmd.Parameters.AddWithValue("@GBLIMITLOW", GBLIMITLOW);
                    cmd.Parameters.AddWithValue("@GBTIME", GBTIME);
                    cmd.Parameters.AddWithValue("@GBTPORT", GBTPORT);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GBLEVEL", "N/A");
                    cmd.Parameters.AddWithValue("@GBLIMIT", "N/A");
                    cmd.Parameters.AddWithValue("@GBLIMITLOW", "N/A");
                    cmd.Parameters.AddWithValue("@GBTIME", "N/A");
                    cmd.Parameters.AddWithValue("@GBTPORT", "N/A");
                }

                if (String.Equals(serDataArray[0][count].Substring(0, 2), "AC", StringComparison.Ordinal))
                {
                    cmd.Parameters.AddWithValue("@ACVOLTAGE", ACVOLTAGE);
                    cmd.Parameters.AddWithValue("@ACLIMIT", ACLIMIT);
                    cmd.Parameters.AddWithValue("@ACLIMITLOW", ACLIMITLOW);
                    cmd.Parameters.AddWithValue("@ACLIMITARC", ACLIMITARC);
                    cmd.Parameters.AddWithValue("@ACLIMITARCFILTER", ACLIMITARCFILTER);
                    cmd.Parameters.AddWithValue("@ACTIME", ACTIME);
                    cmd.Parameters.AddWithValue("@ACTIMERAMP", ACTIMERAMP);
                    cmd.Parameters.AddWithValue("@ACCHAN", ACCHAN);
                    cmd.Parameters.AddWithValue("@ACCHANLOW", ACCHANLOW);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ACVOLTAGE", "N/A");
                    cmd.Parameters.AddWithValue("@ACLIMIT", "N/A");
                    cmd.Parameters.AddWithValue("@ACLIMITLOW", "N/A");
                    cmd.Parameters.AddWithValue("@ACLIMITARC", "N/A");
                    cmd.Parameters.AddWithValue("@ACLIMITARCFILTER", "N/A");
                    cmd.Parameters.AddWithValue("@ACTIME", "N/A");
                    cmd.Parameters.AddWithValue("@ACTIMERAMP", "N/A");
                    cmd.Parameters.AddWithValue("@ACCHAN", "N/A");
                    cmd.Parameters.AddWithValue("@ACCHANLOW", "N/A");
                }

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void WriteToAccessDB()
        {
            for (int count = 0; count < 7; count++)
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = P:\\Access Databases\\ChromaTesting.accdb";

                conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [TestData] (Username, TestDate, IlluminatorSN, OMET, MMET, Judgement, WorkOrderNumber, ModelNumber, PartNumber, BallastSN, LampSN, ChromaModel, ChromaSerial, ChromaCalDate, Mode, LCDEV, LCLine, LCGswi, LCMETER, LCLIMIT, LCLIMLOW, LCPOWMODE, TestTime, LCCHAN, GBLEVEL, GBLIMIT, GBLIMITLOW, GBTIME, GBTPORT, ACVOLTAGE, ACLIMIT, ACLIMITLOW, ACLIMITARC, ACLIMITARCFILTER, ACTIME, ACTIMERAMP, ACCHAN, ACCHANLOW) VALUES (@Username, @TestDate, @IlluminatorSN, @OMET, @MMET, @Judgement, @WorkOrderNumber, @ModelNumber, @PartNumber, @BallastSN, @LampSN, @ChromaModel, @ChromaSerial, @ChromaCalDate, @Mode, @LCDEV, @LCLine, @LCGswi, @LCMETER, @LCLIMIT, @LCLIMLOW, @LCPOWMODE, @TestTime, @LCCHAN, @GBLEVEL, @GBLIMIT, @GBLIMITLOW, @GBTIME, @GBTPORT, @ACVOLTAGE, @ACLIMIT, @ACLIMITLOW, @ACLIMITARC, @ACLIMITARCFILTER, @ACTIME, @ACTIMERAMP, @ACCHAN, @ACCHANLOW)", conn);
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@Username", userName2);
                cmd.Parameters.AddWithValue("@TestDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@IlluminatorSN", IlluminatorSN.Text);
                cmd.Parameters.AddWithValue("@OMET", serDataArray[1][count]);
                cmd.Parameters.AddWithValue("@MMET", serDataArray[2][count]);
                cmd.Parameters.AddWithValue("@Judgement", serDataArray[3][count]);
                cmd.Parameters.AddWithValue("@WorkOrderNumber", WorkOrderNum.Text);
                cmd.Parameters.AddWithValue("@ModelNumber", ModelNum.Text);
                cmd.Parameters.AddWithValue("@PartNumber", PartNum.Text);
                cmd.Parameters.AddWithValue("@BallastSN", BallastSN.Text);
                cmd.Parameters.AddWithValue("@LampSN", LampSN.Text);
                cmd.Parameters.AddWithValue("@ChromaModel", ChromaModelTextBox.Text);
                cmd.Parameters.AddWithValue("@ChromaSerial", ChromaSerialTextBox.Text);
                cmd.Parameters.AddWithValue("@ChromaCalDate", ChromaCalDateTextBox.Text);
                cmd.Parameters.AddWithValue("@Mode", serDataArray[0][count]);

                if (String.Equals(serDataArray[0][count].Substring(0, 2), "LC", StringComparison.Ordinal))
                {
                    cmd.Parameters.AddWithValue("@LCDEV", LCDEV[count]);
                    cmd.Parameters.AddWithValue("@LCLine", LCLines[count]);
                    cmd.Parameters.AddWithValue("@LCGswi", LCGswi[count]);
                    cmd.Parameters.AddWithValue("@LCMETER", LCMETER[count]);
                    cmd.Parameters.AddWithValue("@LCLIMIT", LCLIMIT[count]);
                    cmd.Parameters.AddWithValue("@LCLIMLOW", LCLIMLOW[count]);
                    cmd.Parameters.AddWithValue("@LCPOWMODE", LCPOWMODE[count]);
                    cmd.Parameters.AddWithValue("@TestTime", LCTESTTIME[count]);
                    cmd.Parameters.AddWithValue("@LCCHAN", LCCHAN[count]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@LCDEV", "N/A");
                    cmd.Parameters.AddWithValue("@LCLine", "N/A");
                    cmd.Parameters.AddWithValue("@LCGswi", "N/A");
                    cmd.Parameters.AddWithValue("@LCMETER", "N/A");
                    cmd.Parameters.AddWithValue("@LCLIMIT", "N/A");
                    cmd.Parameters.AddWithValue("@LCLIMLOW", "N/A");
                    cmd.Parameters.AddWithValue("@LCPOWMODE", "N/A");
                    cmd.Parameters.AddWithValue("@TestTime", "N/A");
                    cmd.Parameters.AddWithValue("@LCCHAN", "N/A");
                }

                if (String.Equals(serDataArray[0][count].Substring(0, 2), "GB", StringComparison.Ordinal))
                {
                    cmd.Parameters.AddWithValue("@GBLEVEL", GBLEVEL);
                    cmd.Parameters.AddWithValue("@GBLIMIT", GBLIMIT);
                    cmd.Parameters.AddWithValue("@GBLIMITLOW", GBLIMITLOW);
                    cmd.Parameters.AddWithValue("@GBTIME", GBTIME);
                    cmd.Parameters.AddWithValue("@GBTPORT", GBTPORT);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GBLEVEL", "N/A");
                    cmd.Parameters.AddWithValue("@GBLIMIT", "N/A");
                    cmd.Parameters.AddWithValue("@GBLIMITLOW", "N/A");
                    cmd.Parameters.AddWithValue("@GBTIME", "N/A");
                    cmd.Parameters.AddWithValue("@GBTPORT", "N/A");
                }

                if (String.Equals(serDataArray[0][count].Substring(0, 2), "AC", StringComparison.Ordinal))
                {
                    cmd.Parameters.AddWithValue("@ACVOLTAGE", ACVOLTAGE);
                    cmd.Parameters.AddWithValue("@ACLIMIT", ACLIMIT);
                    cmd.Parameters.AddWithValue("@ACLIMITLOW", ACLIMITLOW);
                    cmd.Parameters.AddWithValue("@ACLIMITARC", ACLIMITARC);
                    cmd.Parameters.AddWithValue("@ACLIMITARCFILTER", ACLIMITARCFILTER);
                    cmd.Parameters.AddWithValue("@ACTIME", ACTIME);
                    cmd.Parameters.AddWithValue("@ACTIMERAMP", ACTIMERAMP);
                    cmd.Parameters.AddWithValue("@ACCHAN", ACCHAN);
                    cmd.Parameters.AddWithValue("@ACCHANLOW", ACCHANLOW);
                }
                else
                {
                    {
                        cmd.Parameters.AddWithValue("@ACVOLTAGE", "N/A");
                        cmd.Parameters.AddWithValue("@ACLIMIT", "N/A");
                        cmd.Parameters.AddWithValue("@ACLIMITLOW", "N/A");
                        cmd.Parameters.AddWithValue("@ACLIMITARC", "N/A");
                        cmd.Parameters.AddWithValue("@ACLIMITARCFILTER", "N/A");
                        cmd.Parameters.AddWithValue("@ACTIME", "N/A");
                        cmd.Parameters.AddWithValue("@ACTIMERAMP", "N/A");
                        cmd.Parameters.AddWithValue("@ACCHAN", "N/A");
                        cmd.Parameters.AddWithValue("@ACCHANLOW", "N/A");
                    }
                }
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void GenerateReport()
        {
            TestResults TestResultsForm = new TestResults();
            TestResultsForm.StartPosition = FormStartPosition.CenterParent;
            TestResultsForm.ShowDialog();
        }

        //----------------Serial Port 1 Listener------------------------
        public delegate void AddDataDelegate(String mySerString);
        public AddDataDelegate myDelegate;
        private void AddDataMethod(String mySerString)
        {
            textBox2.Text = mySerString;
            Debug.WriteLine("Serial Recieved on serialPort1");

            ReceiveSetupInfo(mySerString);

            if ((testFlag == 1) && (i < 4)) // 4 for MODE, OMET, MMET, RES:ALL
            {
                //Parse string & create array
                string[] serDataString = mySerString.Split(',');

                for (int counter = 0; counter < 7; counter++)
                {
                    Debug.WriteLine(serDataString[counter]);
                    if ((serDataString[counter].Length >= 3) && (String.Equals(serDataString[counter].Substring(0, 3), "116", StringComparison.Ordinal)))
                    { serDataString[counter] = "PASS"; }
                    else if ((serDataString[counter].Length >= 3) && (String.Equals(serDataString[counter].Substring(0, 3), "115", StringComparison.Ordinal)))
                    { serDataString[counter] = "TESTING"; }
                    else if ((serDataString[counter].Length >= 3) && (String.Equals(serDataString[counter].Substring(0, 3), "114", StringComparison.Ordinal)))
                    { serDataString[counter] = "CAN NOT TEST"; }
                    else if ((serDataString[counter].Length >= 3) && (String.Equals(serDataString[counter].Substring(0, 3), "113", StringComparison.Ordinal)))
                    { serDataString[counter] = "USER STOP"; }
                    else if ((serDataString[counter].Length >= 3) && (String.Equals(serDataString[counter].Substring(0, 3), "112", StringComparison.Ordinal)))
                    { serDataString[counter] = "STOP"; }
                }
                serDataArray[i] = serDataString;

                i++;

                if (i == 4)
                {
                    i = 0;
                    testFlag = 0;
                    WriteToDB();
                    WriteToAccessDB();
                    GenerateReport();
                }
            }

            //Look for PASS/FAIL
            if (mySerString.Length >= 6)
            {
                if (String.Equals(mySerString.Substring(0, 6), "\"PASS\"", StringComparison.Ordinal))
                {
                    GetTestResults();
                }
                else if (String.Equals(mySerString.Substring(0, 6), "\"FAIL\"", StringComparison.Ordinal))
                {
                    MessageBox.Show("FAIL");
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string newSerString = this.serialPort1.ReadLine();
            newSerString = newSerString.TrimEnd('\r');
            Debug.WriteLine(newSerString);
            testString = newSerString;
            textBox2.Invoke(this.myDelegate, new Object[] { newSerString });
        }

        //----------------Serial Port 2 Listener------------------------
        public delegate void AddDataDelegate2(String indata);
        public AddDataDelegate2 myDelegate2;
        private void AddDataMethod2(String indata)
        {
            Debug.WriteLine("AddDataMethod2");
            if (String.Equals(indata.Substring(0, 6), "CHROMA", StringComparison.Ordinal))
            {
                string[] ChromaInfo = indata.Split('X');
                ChromaModelTextBox.Text = ChromaInfo[0];
                ChromaSerialTextBox.Text = ChromaInfo[1];
                ChromaCalDateTextBox.Text = ChromaInfo[2];
            }
            else if (String.Equals(indata.Substring(0, 2), "WO", StringComparison.Ordinal))
            {
                Debug.WriteLine("Work Order Detected");
                WorkOrderNum.Text = indata;
            }
            else if (String.Equals(indata.Substring(0, 4), "+$$+", StringComparison.Ordinal))
            {
                Debug.WriteLine("Unit Serial Number Detected");
                string[] snparsed = indata.Split('+', '/');
                IlluminatorSN.Text = snparsed[2];
            }
            else if (String.Equals(indata.Substring(0, 6), "TX450D", StringComparison.Ordinal))
            {
                Debug.WriteLine("Part Number Detected");
                PartNum.Text = indata;
            }
            else if (indata.Length >= 6 && indata.Length >= 9 && String.Equals(indata.Substring(0, 9), "TITANX450", StringComparison.Ordinal))
            {
                Debug.WriteLine("Model Number Detected");
                ModelNum.Text = indata;
            }
            else if (indata.Length >= 6 && indata.Length >= 6 && String.Equals(indata.Substring(0, 7), "1234567", StringComparison.Ordinal))
            {
                Debug.WriteLine("Ballast SN Detected");
                BallastSN.Text = indata;
            }
            else if (indata.Length == 7)
            {
                Debug.WriteLine("Lamp Serial Number Detected");
                LampSN.Text = indata;
            }
        }
        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Debug.WriteLine("Serial Recieved on serialPort2");

            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();  //sp.ReadLine wasn't working

            indata = indata.TrimEnd('\r');
            Debug.WriteLine(indata);
            WorkOrderNum.Invoke(this.myDelegate2, new Object[] { indata });
        }
    }
}
