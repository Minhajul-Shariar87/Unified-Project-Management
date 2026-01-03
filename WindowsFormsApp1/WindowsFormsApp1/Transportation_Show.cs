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
    public partial class Transportation_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
        public Transportation_Show(int i)
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
        public Transportation_Show()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string newIncTitle = textBox4.Text.Trim();
            string newIncTop = textBox3.Text.Trim();
            string newBus = textBox2.Text;
            string newStatus = comboBox1.Text;
            string newRoute= textBox6.Text;

            if (string.IsNullOrWhiteSpace(newIncTitle) || string.IsNullOrWhiteSpace(newIncTop) || string.IsNullOrWhiteSpace(newIncTop) || string.IsNullOrWhiteSpace(newBus)|| string.IsNullOrWhiteSpace(newStatus)|| string.IsNullOrWhiteSpace(newRoute))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Transportation SET INCIDENT_TITLE= @Incident_title, INCIDENT_TOPIC = @Incident_topic, BUS_NAME = @Bus_name, STATUS=@Status, ROUTE= @Route  WHERE TRANSPORTATION_ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Incident_title", newIncTitle);
                    command.Parameters.AddWithValue("@Incident_topic", newIncTop);
                    command.Parameters.AddWithValue("@Bus_name", newBus);
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@Route", newRoute);

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
                string query = "DELETE FROM Transportation WHERE TRANSPORTATION_ID = @Id";

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
            Transportation_Management tm = new Transportation_Management();
            tm.Show();
            this.Hide();
        }
    }
}
