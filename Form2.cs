using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
        }
        double ttl = 0;
        private void button2_Click(object sender, EventArgs e)
        {
           
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            this.Close();
        }
        Bitmap bitmap;
        private void CaptureScreen() {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y,0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCoffee.Text != "")
                {
                    string ppi = "150";
                    string q = txtQCoffee.Text;
                    string t = (Convert.ToDouble(q) * Convert.ToDouble(ppi)).ToString();
                    dataGridView1.Rows.Add(cbCoffee.Text, q, ppi, t);
                    cbCoffee.Text = "";
                }
                if (cbFF.Text != "")
                {
                    string ppi = "199";
                    string q = txtFF.Text;
                    string t = (Convert.ToDouble(q) * Convert.ToDouble(ppi)).ToString();
                    dataGridView1.Rows.Add(cbFF.Text, q, ppi, t);
                    cbFF.Text = "";
                }
                if (cbWC.Text != "")
                {
                    string ppi = "299";
                    string q = txtWC.Text;
                    string t = (Convert.ToDouble(q) * Convert.ToDouble(ppi)).ToString();
                    dataGridView1.Rows.Add(cbWC.Text, q, ppi, t);
                    cbWC.Text = "";
                }
                txtFF.Clear();
                txtQCoffee.Clear();
                txtWC.Clear();
            }
            catch 
            {
                MessageBox.Show("Please Check Entered Information...");
            }
        }

        private void buttontotal_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ttl = ttl + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

            }
            txtTotal.Text = ttl.ToString();
            button2.Visible = true;
        }
    }
}
