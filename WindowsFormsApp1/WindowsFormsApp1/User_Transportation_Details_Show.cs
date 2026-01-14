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
    public partial class User_Transportation_Details_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public User_Transportation_Details_Show(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();
        }
        private void LoadDetails()
        {
            string query = "SELECT TRANSPORTATION_ID, INCIDENT_TITLE, INCIDENT_TOPIC, WRITTEN_BY,ADMIN_ID,BUS_NAME,STATUS,ROUTE,WRITE_NEWS FROM Transportation WHERE TRANSPORTATION_ID = @Id";


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
                        textBox7.Text = reader["TRANSPORTATION_ID"].ToString();
                        textBox4.Text = reader["INCIDENT_TITLE"].ToString();
                        textBox3.Text = reader["INCIDENT_TOPIC"].ToString();
                        textBox1.Text = reader["WRITTEN_BY"].ToString();
                        textBox5.Text = reader["ADMIN_ID"].ToString();
                        textBox2.Text = reader["BUS_NAME"].ToString();
                        comboBox1.Text = reader["STATUS"].ToString();
                        textBox6.Text = reader["ROUTE"].ToString();
                        richTextBox5.Text = reader["WRITE_NEWS"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }

        private void User_Transportation_Details_Show_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_Transportation_Details utd = new User_Transportation_Details();
            utd.Show();
            this.Hide();
        }
    }
}
