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
    public partial class User_Report_Police : Form
    {
        public User_Report_Police()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_Home_Page uhp = new User_Home_Page();
            uhp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string id = textBox4.Text.Trim();
            string name = textBox3.Text.Trim();

            bool flag = false;




            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

            string query1 = "SELECT COUNT(*) FROM Register WHERE USER_ID = @Id AND NAME = @Name";
            // string query = "SELECT COUNT(*) FROM section WHERE Id = @Id AND Name COLLATE SQL_Latin1_General_CP1_CS_AS = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID Found & Name Found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //HomePage hp = new HomePage();
                        //hp.Show();
                        flag = true;


                    }
                    else
                    {
                        MessageBox.Show("Invalid Id/Invalid Name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            string age = textBox2.Text.Trim();
            string district = comboBox2.Text;
            if (!int.TryParse(age, out int parsedAge))
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string address = richTextBox5.Text;
            string dos = dateTimePicker1.Text;
            string query = "INSERT INTO Report_Police (NAME, AGE, DISTRICT, ADDRESS, DATE_TIME,USER_ID) VALUES (@Name, @Age, @District,@Address,@Date_time,@Id)";

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

                    command.Parameters.AddWithValue("@Age", parsedAge);
                    command.Parameters.AddWithValue("@District", district);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Date_time", dos);
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@id", id);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@id", 0);
                    }


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0 && flag)
                    {
                        MessageBox.Show("Report Police created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Hide();
                        //Form1 f1 = new Form1();
                        //f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the report. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        
    }
    }
}
