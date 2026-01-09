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
    public partial class User_News_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public User_News_Show(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();


        }
        private void LoadDetails()
        {
            string query = "SELECT NEWS_ID,TITLE,TOPIC,WRITTEN_BY,ADMIN_ID,REFERANCE_NAME,WRITE_NEWS FROM News WHERE NEWS_ID = @Id";


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
                        textBox1.Text = reader["NEWS_ID"].ToString();
                        textBox2.Text = reader["TITLE"].ToString();
                        textBox3.Text = reader["TOPIC"].ToString();
                        textBox4.Text = reader["WRITTEN_BY"].ToString();
                        textBox5.Text = reader["ADMIN_ID"].ToString();
                        textBox6.Text = reader["REFERANCE_NAME"].ToString();

                        richTextBox1.Text = reader["WRITE_NEWS"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }

        private void User_News_Show_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_News un = new User_News();
            un.Show();
            this.Hide();
        }
    }
}
