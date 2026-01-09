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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePage2 hp2 = new HomePage2();
            hp2.Show();
            this.Hide();
        }

        private void HomePage2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            News n= new News();
            n.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportPolice rp= new ReportPolice();
            rp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DangerousPlace dp = new DangerousPlace();
            dp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transportation_Details td = new Transportation_Details();
            td.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login login = new Login(); 
            login.Show();
            this.Hide();
        }
    }
}
