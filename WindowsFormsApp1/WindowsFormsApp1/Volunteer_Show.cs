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
    public partial class Volunteer_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
        public Volunteer_Show(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();
        }

        private void LoadDetails()
        {
            string query = "SELECT VOLUNTEER_ID, NAME, USER_ID, AGE, INSTITUTION_NAME, INTERESTED_IN,QUESTION_ANSWER FROM Volunteer WHERE VOLUNTEER_ID = @Id";


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
                        textBox5.Text = reader["VOLUNTEER_ID"].ToString();
                        textBox4.Text = reader["NAME"].ToString();
                        textBox7.Text = reader["USER_ID"].ToString();
                        textBox1.Text = reader["AGE"].ToString();
                        textBox2.Text = reader["INSTITUTION_NAME"].ToString();
                        textBox6.Text = reader["INTERESTED_IN"].ToString();
                        richTextBox1.Text = reader["QUESTION_ANSWER"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }
        public Volunteer_Show()
        {
            InitializeComponent();
        }

        private void Volunteer_Show_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string newName = textBox4.Text.Trim();
            string newAge= textBox1.Text.Trim();
            string newInsName = textBox2.Text;
            string newIntin = textBox6.Text;

            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newAge) || string.IsNullOrWhiteSpace(newInsName)|| string.IsNullOrWhiteSpace(newIntin))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Volunteer SET NAME = @Name, AGE = @Age, INSTITUTION_NAME = @Institution_name, INTERESTED_IN=@Interested_in WHERE VOLUNTEER_ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", newName);
                    command.Parameters.AddWithValue("@Age", newAge);
                    command.Parameters.AddWithValue("@Institution_name", newInsName);
                    command.Parameters.AddWithValue("@Interested_in", newIntin);

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Are you sure you want to delete this profile?",
    "Confirm Deletion",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning
);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Volunteer WHERE VOLUNTEER_ID = @Id";

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
            Hire_Volunteer_Management hv= new Hire_Volunteer_Management();
            hv.Show();
            this.Hide();
        }
    }
}
