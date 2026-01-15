using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Police_Report_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public Police_Report_Show(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();
        }
        private void LoadDetails()
        {
            string query = "SELECT REPORT_POLICE_ID,NAME,AGE,DISTRICT,ADDRESS,DATE_TIME,USER_ID FROM Report_Police WHERE REPORT_POLICE_ID = @Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate the text boxes with the retrieved data
                        textBox1.Text = reader["USER_ID"].ToString();
                        textBox2.Text = reader["NAME"].ToString();
                        textBox3.Text = reader["AGE"].ToString();
                        comboBox1.Text = reader["DISTRICT"].ToString();
                        richTextBox1.Text = reader["ADDRESS"].ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }


        private void Police_Report_Show_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Police_Report police_Report = new Police_Report();
            police_Report.Show();
            this.Hide();
        }
    }
}
