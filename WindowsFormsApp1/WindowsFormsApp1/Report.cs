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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage2 hp2 = new HomePage2();
            hp2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string name = textBox1.Text.Trim();
            string userId = textBox2.Text.Trim();
            bool flag = false;
           

            

            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

            string query1 = "SELECT COUNT(*) FROM Register WHERE USER_ID = @Id AND NAME = @Name";
            // string query = "SELECT COUNT(*) FROM section WHERE Id = @Id AND Name COLLATE SQL_Latin1_General_CP1_CS_AS = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Id", userId);
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID Found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //HomePage hp = new HomePage();
                        //hp.Show();
                        flag = true;
                        

                    }
                    else
                    {
                        MessageBox.Show("Invalid Id.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //if (!int.TryParse(id, out int parsedid))
            //{
            //    MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            string report_to = comboBox1.Text;
            string reason = richTextBox1.Text;
            string dos = dateTimePicker1.Text;
            
            string query = "INSERT INTO Report (USERNAME, REPORT_TO,REASON, DATE_TIME,USER_ID) VALUES (@Name, @Report, @Reason, @Datetime,@id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Name", name);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Name", "ERROR");
                    }
                    
                    command.Parameters.AddWithValue("@Report", report_to);
                    command.Parameters.AddWithValue("@Reason", reason);
                    command.Parameters.AddWithValue("@Datetime", dos);
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@id", userId);
                    }
                    else {
                        command.Parameters.AddWithValue("@id", 0);
                    }


                        connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0&& flag)
                    {
                        MessageBox.Show("Report created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
