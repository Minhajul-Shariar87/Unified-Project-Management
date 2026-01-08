using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Buy_Items : Form
    {
        public Buy_Items()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HomePage2 hp2 = new HomePage2();
            hp2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Personal_Safety ps= new Personal_Safety();
            ps.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Personal_Safety ps = new Personal_Safety();
            ps.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Personal_Safety ps = new Personal_Safety();
            ps.Show();
            this.Hide();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Personal_Safety ps = new Personal_Safety();
            ps.Show();

            this.Hide();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Buy_Items_Management bim= new Buy_Items_Management();
            bim.Show();
            this.Hide();
        }
    }
}
