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
    public partial class User_Home_Page : Form
    {
        public User_Home_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Report_Police urp = new User_Report_Police();
            urp.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_News user_News = new User_News();
            user_News.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_HomePage2 user_Home_Page = new User_HomePage2();
            user_Home_Page.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Dangerous_Map user_Dangerous_Map = new User_Dangerous_Map();
            user_Dangerous_Map.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Transportation_Details user_Transportation_Details = new User_Transportation_Details();
            user_Transportation_Details.Show();
            this.Hide();
        }
    }
}
