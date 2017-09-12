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
    public partial class AddUser : Form
    {
        public AddUser(int isAdmin)
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteToAccessDB();
            //WriteToSQLDB();    
        }

        private void WriteToAccessDB()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = P:\\Access Databases\\ChromaTesting.accdb";

            conn.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO [Table] (USERNAME, [PASSWORD], ROLE) VALUES (@USERNAME,@PASSWORD,@ROLE)", conn);
            cmd.Connection = conn;
                        
            cmd.Parameters.AddWithValue("@USERNAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", textBox2.Text);

            if (checkBox1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ROLE", "admin");
            }
            else
            {
                cmd.Parameters.AddWithValue("@ROLE", "");
            }

            cmd.ExecuteNonQuery();
            MessageBox.Show("        Success!  ");
            this.Hide();
        }

        private void WriteToSQLDB()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill out all fields");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match.");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\clavan\Documents\ChromaLoginDB.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Table] (USERNAME, PASSWORD, ROLE) VALUES (@USERNAME,@PASSWORD,@ROLE)", con);
                cmd.Parameters.AddWithValue("@USERNAME", textBox1.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", textBox2.Text);

                if (checkBox1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ROLE", "admin");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ROLE", "");
                }

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}