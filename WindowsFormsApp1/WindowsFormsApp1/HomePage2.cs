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
    public partial class HomePage2 : Form
    {
        public HomePage2()
        {
            InitializeComponent();
        }

        private void HomePage2_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            //HomePage hp= new HomePage();
            //hp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hire_Volunteer hv = new Hire_Volunteer();
            hv.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buy_Items bi= new Buy_Items();
            bi.Show();
            this.Hide();
        }
    }
}
