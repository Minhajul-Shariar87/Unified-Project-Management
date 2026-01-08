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
    public partial class News_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public News_Show(int i)
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

        private void News_Show_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string newTitle = textBox2.Text.Trim();
            string newTop = textBox3.Text.Trim();
            string newRef = textBox6.Text;
            string newWritenews = richTextBox1.Text;
            

            if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newTop) || string.IsNullOrWhiteSpace(newRef) || string.IsNullOrWhiteSpace(newWritenews))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE News SET TITLE=@Title,TOPIC = @Topic,REFERANCE_NAME = @Name, WRITE_NEWS=@News  WHERE NEWS_ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", newTitle);
                    command.Parameters.AddWithValue("@Topic", newTop);
                    command.Parameters.AddWithValue("@Name", newRef);
                    command.Parameters.AddWithValue("@News", newWritenews);
                    

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close(); // Optionally close the form after a successful update
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
   "Are you sure you want to delete this profile?",
   "Confirm Deletion",
   MessageBoxButtons.YesNo,
   MessageBoxIcon.Warning
);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM News WHERE NEWS_ID = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No profile was found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            News_Management nm = new News_Management();
            nm.Show();
            this.Hide();

        }
    }
    }

