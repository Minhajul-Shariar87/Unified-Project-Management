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
    public partial class Show_ID_and_Pass : Form
    {
        public Show_ID_and_Pass()
        {
            InitializeComponent();
        }
        public Show_ID_and_Pass(int id,string password)
        {
            InitializeComponent();
            textBox1.Text = id.ToString();
            textBox2.Text= password;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
            Register r=new Register();
            r.Hide();
        }

        private void Show_ID_and_Pass_Load(object sender, EventArgs e)
        {

        }
    }
}
