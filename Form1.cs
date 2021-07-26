using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string query = "SELECT * FROM Login WHERE usernames='"+username+"' AND passwords='"+password+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Program.con);
                DataTable table = new DataTable();
                sda.Fill(table);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Please Enter Valied Details....", "Failed");
                }
                else
                {
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed....","Error");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
    }

