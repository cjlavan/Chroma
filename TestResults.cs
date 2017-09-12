using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;
using NewLabelPrinter;
using PrintReportSample;
using System.Data.OleDb;



namespace WindowsFormsApplication2
{
    public partial class TestResults : Form
    {

        public TestResults()
        {
            InitializeComponent();
        }

        //public virtual void PrintToPrinter(int nCopies, bool collated, int startPageN, int endPageN);

        private void TestResults_Load(object sender, EventArgs e)
        {
            //SQLPop();
            AccPop();

        }

        private void AutoPrint()
        {
            ReportPrintDocument autoprintme = new ReportPrintDocument(reportViewer1.LocalReport);
            autoprintme.Print();
        }

        private void SetReportParameters()
        {
            ReportParameter[] parameters = new ReportParameter[11];
            parameters[0] = new ReportParameter("WorkOrderNumber", "123456789");
            parameters[1] = new ReportParameter("IlluminatorSerialNumber", "987654231");
            parameters[2] = new ReportParameter("ModelNumber", "987654231");
            parameters[3] = new ReportParameter("PartNumber", "987654231");
            parameters[4] = new ReportParameter("LampSerialNumber", "987654231");
            parameters[5] = new ReportParameter("BallastSerialNumber", "987654231");
            parameters[6] = new ReportParameter("ESTModel", "987654231");
            parameters[7] = new ReportParameter("ESTSN", "987654231");
            parameters[8] = new ReportParameter("ESTCD", "987654231");
            parameters[9] = new ReportParameter("TestedBy", "987654231");
            parameters[10] = new ReportParameter("Date", "987654231");
            this.reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.TestDataTableAdapter.FillBy(this.ChromaLoginDBDataSet.TestData);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void SQLPop()
        {
            // TODO: This line of code loads data into the 'ChromaLoginDBDataSet.TestData' table. You can move, or remove it, as needed.
            this.TestDataTableAdapter.Fill(this.ChromaLoginDBDataSet.TestData);
            // TODO: This line of code loads data into the 'ChromaLoginDBDataSet.TestData' table. You can move, or remove it, as needed.
            this.TestDataTableAdapter.Fill(this.ChromaLoginDBDataSet.TestData);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\clavan\Downloads\FRPSE4ZGA1BD540\C#\ChromaLoginDB.mdf;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlDataAdapter reportDBTableAdapter = new SqlDataAdapter("SELECT Top 7 * FROM  [TestData] order by ID DESC", conn);
            DataTable polinaDBDataSet = new DataTable();
            reportDBTableAdapter.Fill(polinaDBDataSet);
            conn.Close();

            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportPath = @"C:\Users\clavan\Downloads\FRPSE4ZGA1BD540\C#\Report2.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", polinaDBDataSet);//"DataSet1" is the name of your dataset. Go to .rdlc form>VIEW>Report Data>"Right click on dataset">Dataset Properties
            this.reportViewer1.LocalReport.DataSources.Add(rds);





            PageSettings newPageSettings = new PageSettings();
            newPageSettings.Margins = new Margins(50, 50, 50, 50);
            reportViewer1.SetPageSettings(newPageSettings);

            SetReportParameters();

            this.reportViewer1.RefreshReport();

            //AutoPrint();
        }

        private void AccPop()
        {
            // TODO: This line of code loads data into the 'ChromaLoginDBDataSet.TestData' table. You can move, or remove it, as needed.
            this.TestDataTableAdapter.Fill(this.ChromaLoginDBDataSet.TestData);
            // TODO: This line of code loads data into the 'ChromaLoginDBDataSet.TestData' table. You can move, or remove it, as needed.
            this.TestDataTableAdapter.Fill(this.ChromaLoginDBDataSet.TestData);

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = P:\\Access Databases\\ChromaTesting.accdb";
            conn.Open();
            OleDbDataAdapter reportDBTableAdapter = new OleDbDataAdapter("SELECT Top 7 * FROM  [TestData] order by ID DESC", conn);
            DataTable polinaDBDataSet = new DataTable();
            reportDBTableAdapter.Fill(polinaDBDataSet);
            conn.Close();

            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportPath = @"C:\Users\clavan\Downloads\FRPSE4ZGA1BD540\C#\Report2.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", polinaDBDataSet);//"DataSet1" is the name of your dataset. Go to .rdlc form>VIEW>Report Data>"Right click on dataset">Dataset Properties
            this.reportViewer1.LocalReport.DataSources.Add(rds);





            PageSettings newPageSettings = new PageSettings();
            newPageSettings.Margins = new Margins(50, 50, 50, 50);
            reportViewer1.SetPageSettings(newPageSettings);

            SetReportParameters();

            this.reportViewer1.RefreshReport();

            //AutoPrint();
        }
    }
}

