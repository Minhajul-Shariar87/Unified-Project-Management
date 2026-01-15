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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class News : Form
    {
        public News()
        {
            InitializeComponent();
        }

        private void News_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp=new HomePage();
            hp.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string title = textBox4.Text.Trim();
            string topic = textBox3.Text.Trim();
            string written_by = textBox1.Text.Trim();
            string id = textBox5.Text.Trim();
            if (!int.TryParse(id, out int parsedId))
            {
                MessageBox.Show("ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool flag = false;




            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

            //string query1 = "SELECT COUNT(*) FROM Admin WHERE ADMIN_ID = @Id AND NAME = @Name";
            string query1 = "SELECT COUNT(*) FROM Admin WHERE ADMIN_ID = @Id AND NAME COLLATE SQL_Latin1_General_CP1_CS_AS = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Id", parsedId);
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
            //if (!int.TryParse(age, out int parsedAge))
            //{
            //    MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            string refName = textBox2.Text;
            string dos = dateTimePicker1.Text;
            string write_news = richTextBox5.Text;
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(topic) || string.IsNullOrWhiteSpace(written_by) || string.IsNullOrWhiteSpace(id)|| string.IsNullOrEmpty(refName)|| string.IsNullOrEmpty(write_news))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO News (TITLE,TOPIC,WRITTEN_BY,ADMIN_ID,REFERANCE_NAME,DATE,WRITE_NEWS) VALUES (@Title, @Topic, @Written_by, @Admin_id,@Referance_name,@Date,@Write_news)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title",title);
                    command.Parameters.AddWithValue("@Topic",topic);
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Written_by", written_by);
                    }
                    else
                    {
                        //command.Parameters.AddWithValue("@Written_by", "ERROR");
                        return;
                    }
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Admin_id", parsedId);
                    }
                    else
                    {
                        // command.Parameters.AddWithValue("@Admin_id", 0);
                        return;
                    }
                    
                    command.Parameters.AddWithValue("@Referance_name", refName);
                    command.Parameters.AddWithValue("@Date", dos);
                    command.Parameters.AddWithValue("@Write_news", write_news);


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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            News_Management nm = new News_Management();
            nm.Show();
            this.Hide();
        }
    }
}
