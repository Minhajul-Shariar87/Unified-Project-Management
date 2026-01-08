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
    public partial class Buy_Items_Show : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public Buy_Items_Show(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();
        }
        private void LoadDetails()
        {
            string query = "SELECT BILLING_ID,NAME,ID,PRODUCT,UNIT_PRICE,QUANTITY,TOTAL_PRICE FROM Billing WHERE BILLING_ID = @Id";


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
                        textBox6.Text = reader["BILLING_ID"].ToString();
                        textBox1.Text = reader["NAME"].ToString();
                        textBox2.Text = reader["ID"].ToString();
                        comboBox1.Text = reader["PRODUCT"].ToString();
                        textBox3.Text = reader["UNIT_PRICE"].ToString();
                        textBox4.Text = reader["QUANTITY"].ToString();
                        textBox5.Text = reader["TOTAL_PRICE"].ToString();
                        
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
            DialogResult result = MessageBox.Show(
   "Are you sure you want to delete this profile?",
   "Confirm Deletion",
   MessageBoxButtons.YesNo,
   MessageBoxIcon.Warning
);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Billing WHERE BILLING_ID = @Id";

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
    }
}
