using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace WindowsFormsApplication2
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAccess();
            //GetSQL();
        }

        private void GetSQL()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\clavan\Downloads\FRPSE4ZGA1BD540\C#\ChromaLoginDB.mdf;Integrated Security=True;Connect Timeout=30");     //set up SQL Database Connection

            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From [Table] where USERNAME='" + UserNameTextBox.Text + "' and PASSWORD = '" + PasswordTextBox.Text + "'", con);   //Check db for user name and password
            DataTable dt = new DataTable();
            sda.Fill(dt);

            SqlDataAdapter sda2 = new SqlDataAdapter("Select Count(*) From [Table] where USERNAME='" + UserNameTextBox.Text + "' and PASSWORD = '" + PasswordTextBox.Text + "' and ROLE = 'admin'", con);   //Check db for user name, password, AND admin
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);

            int isAdmin = 0;

            //Check credentials against database, send permissions if admin
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    isAdmin = 1;                    //if db entry has admin role set isAdmin to 1
                }
                else
                {
                    isAdmin = 0;                    //else set isAdmin to 0
                }

                this.Hide();                        //hide current window, launch main program
                MainProgram ss = new MainProgram(isAdmin, UserNameTextBox.Text);
                ss.Show(this);
            }
            else
            {
                MessageBox.Show("Please check Username and Password.");
            }
        }

        private void GetAccess()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = P:\\Access Databases\\ChromaTesting.accdb";
            OleDbDataAdapter sda = new OleDbDataAdapter("Select Count(*) From [Table] where USERNAME='" + UserNameTextBox.Text + "' and PASSWORD = '" + PasswordTextBox.Text + "'", conn);   //Check db for user name and password
            DataTable dt = new DataTable();
            sda.Fill(dt);

            OleDbDataAdapter sda2 = new OleDbDataAdapter("Select Count(*) From [Table] where USERNAME='" + UserNameTextBox.Text + "' and PASSWORD = '" + PasswordTextBox.Text + "' and ROLE = 'admin'", conn);   //Check db for user name, password, AND admin
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);

            int isAdmin = 0;

            //Check credentials against database, send permissions if admin
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    isAdmin = 1;                    //if db entry has admin role set isAdmin to 1
                }
                else
                {
                    isAdmin = 0;                    //else set isAdmin to 0
                }

                this.Hide();                        //hide current window, launch main program
                MainProgram ss = new MainProgram(isAdmin, UserNameTextBox.Text);
                ss.Show(this);
            }
            else
            {
                MessageBox.Show("Please check Username and Password.");
            }
        }
    }
}
