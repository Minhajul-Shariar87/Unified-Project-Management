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

namespace WindowsFormsApp1
{
    public partial class User_Dangerous_Map_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public User_Dangerous_Map_Show(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();


        }
        private void LoadDetails()
        {
            string query = "SELECT DANGEROUS_PLACE_ID,DANGEROUS_TYPE,DISTRICT,CITY,POSTAL_CODE,ADDRESS,WRITE_NEWS,WRITTEN_BY,DATE_TIME,ADMIN_ID FROM DangerousPlace WHERE DANGEROUS_PLACE_ID = @Id";


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
                        comboBox1.Text = reader["DANGEROUS_TYPE"].ToString();
                        comboBox2.Text = reader["DISTRICT"].ToString();
                        comboBox3.Text = reader["CITY"].ToString();
                        textBox1.Text = reader["POSTAL_CODE"].ToString();
                        richTextBox1.Text = reader["ADDRESS"].ToString();
                        richTextBox2.Text = reader["WRITE_NEWS"].ToString();
                        textBox2.Text = reader["WRITTEN_BY"].ToString();
                        textBox3.Text = reader["ADMIN_ID"].ToString();
                        textBox4.Text = reader["DANGEROUS_PLACE_ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_Dangerous_Map user_Dangerous_Map = new User_Dangerous_Map();
            user_Dangerous_Map.Show();
            this.Hide();
        }

        private void User_Dangerous_Map_Show_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            User_Dangerous_Map user_Dangerous_Map = new User_Dangerous_Map();
            user_Dangerous_Map.Show();
            this.Hide();
        }
    }
}
