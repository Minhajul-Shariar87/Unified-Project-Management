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
    public partial class DangerousPlace_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public DangerousPlace_Show(int i)
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
                        textBox1.Text = reader["WRITTEN_BY"].ToString();
                        textBox2.Text = reader["ADMIN_ID"].ToString();
                        textBox3.Text = reader["DANGEROUS_PLACE_ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string newDT = comboBox1.Text.Trim();
            string newDist = comboBox2.Text.Trim();
            string newCity = comboBox3.Text;
            string newPostal = textBox1.Text.Trim();
            string newAddress = richTextBox1.Text;
            string newWrite=richTextBox2.Text;


            if (string.IsNullOrWhiteSpace(newDT) || string.IsNullOrWhiteSpace(newDist) || string.IsNullOrWhiteSpace(newCity) || string.IsNullOrWhiteSpace(newPostal) || string.IsNullOrWhiteSpace(newAddress)|| string.IsNullOrWhiteSpace(newWrite))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE DangerousPlace SET  DANGEROUS_TYPE=@Dangerous_type, DISTRICT = @District, CITY = @City, POSTAL_CODE=@Postal_code, ADDRESS= @Address , WRITE_NEWS=@Write_news WHERE DANGEROUS_PLACE_ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Dangerous_type", newDT);
                    command.Parameters.AddWithValue("@District", newDist);
                    command.Parameters.AddWithValue("@City", newCity);
                    command.Parameters.AddWithValue("@Postal_code", newPostal);
                    command.Parameters.AddWithValue("@Address", newAddress);
                    command.Parameters.AddWithValue("@Write_News", newWrite);

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
                string query = "DELETE FROM DangerousPlace WHERE DANGEROUS_PLACE_ID = @Id";

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
            DangerousPlace_Management dangerousPlace_Management = new DangerousPlace_Management();
            dangerousPlace_Management.Show();
            this.Hide();
        }

        private void DangerousPlace_Show_Load(object sender, EventArgs e)
        {

        }
    }
}
