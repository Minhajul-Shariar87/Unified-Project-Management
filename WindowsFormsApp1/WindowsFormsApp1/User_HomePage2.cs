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
    public partial class User_HomePage2 : Form
    {
        public User_HomePage2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_Home_Page user_Home_Page = new User_Home_Page();
            user_Home_Page.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Shopping user_Shopping = new User_Shopping();
            user_Shopping.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Volunteer user_Volunteer = new User_Volunteer();
            user_Volunteer.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Report user_Report = new User_Report();
            user_Report.Show();
            this.Hide();
        }
    }
}
