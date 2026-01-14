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
    public partial class User_Shopping : Form
    {
        public User_Shopping()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_Billing ub = new User_Billing();
            ub.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            User_Billing ub = new User_Billing();
            ub.Show();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            User_Billing ub = new User_Billing();
            ub.Show();
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            User_Billing ub = new User_Billing();
            ub.Show();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            User_HomePage2 uhp2 = new User_HomePage2();
            uhp2.Show();
            this.Hide();
        }
    }
}
