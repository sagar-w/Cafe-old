using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Print : Form
    {
        public Print(string tno, object data)
        {
            InitializeComponent();
            lblCName.Text = tno;
            DataTable dt = new DataTable();
            dt.Load((IDataReader)data);
            dataGridView1.DataSource = dt;
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 9, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 10, 10);

        }
    }
}
