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
    public partial class Transportation_Details : Form
    {
        public Transportation_Details()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp= new HomePage();
            hp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string title = textBox4.Text;
            string topic = textBox3.Text;
            string written_by = textBox1.Text.Trim();
            string id = textBox5.Text.Trim();
            //if (!int.TryParse(age, out int parsedAge))
            //{
            //    MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            bool flag = false;




            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

            string query1 = "SELECT COUNT(*) FROM Admin WHERE ADMIN_ID = @Id AND NAME = @Name";
            // string query = "SELECT COUNT(*) FROM section WHERE Id = @Id AND Name COLLATE SQL_Latin1_General_CP1_CS_AS = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", written_by);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID and Name Found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        flag = true;


                    }
                    else
                    {
                        MessageBox.Show("Invalid Id / Name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            string bname = textBox2.Text;
            string status = comboBox1.Text;
            string route = textBox6.Text;
            string write_news = richTextBox5.Text;
            string dos = dateTimePicker1.Text;

            string query = "INSERT INTO Transportation (INCIDENT_TITLE,INCIDENT_TOPIC,WRITTEN_BY,ADMIN_ID,BUS_NAME,STATUS,ROUTE,WRITE_NEWS,DATE) VALUES (@Incident_title, @Incident_topic, @Written_by, @Admin_id,@Bus_name,@Status,@Route,@Write_news,@Date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Incident_title", title);
                    command.Parameters.AddWithValue("@Incident_Topic", topic);
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Written_by", written_by);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Written_by", "ERROR");
                    }
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Admin_id", id);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Admin_id", 0);
                    }
                   
                    command.Parameters.AddWithValue("@Bus_name",bname);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Route", route);
                    command.Parameters.AddWithValue("@Write_news", write_news);
                    command.Parameters.AddWithValue("@Date", dos);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0&&flag)
                    {
                        MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
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
