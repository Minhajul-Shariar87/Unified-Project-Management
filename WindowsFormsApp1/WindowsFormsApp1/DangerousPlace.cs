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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class DangerousPlace : Form
    {
        public DangerousPlace()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp= new HomePage();
            hp.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string dt = comboBox1.Text;
            string district = comboBox2.Text;
            string city = comboBox3.Text;
            string postal = textBox5.Text.Trim();
            if (!int.TryParse(postal, out int parsedpostal))
            {
                MessageBox.Show("Postal code must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string address = richTextBox1.Text;
            string write_news= richTextBox2.Text;
            string written_by = textBox1.Text;
            string dos = dateTimePicker1.Text;
            string id = textBox2.Text;
            if (!int.TryParse(id, out int parsedId))
            {
                MessageBox.Show("ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool flag = false;




            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

           // string query1 = "SELECT COUNT(*) FROM Admin WHERE ADMIN_ID = @Id AND NAME = @Name";
             string query1 = "SELECT COUNT(*) FROM Admin WHERE ADMIN_ID = @Id AND NAME COLLATE SQL_Latin1_General_CP1_CS_AS = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Id",parsedId);
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

            if (string.IsNullOrWhiteSpace(dt) || string.IsNullOrWhiteSpace(district) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(postal)|| string.IsNullOrEmpty(address)|| string.IsNullOrEmpty(write_news)|| string.IsNullOrEmpty(written_by)|| string.IsNullOrEmpty(id))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO DangerousPlace (DANGEROUS_TYPE,DISTRICT,CITY,POSTAL_CODE,ADDRESS,WRITE_NEWS,WRITTEN_BY,DATE_TIME,ADMIN_ID) VALUES (@Dangerous_type, @District, @City, @Postal_code,@Address,@Write_news,@Written_by,@Date_time,@Admin_id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Dangerous_type", dt);
                    command.Parameters.AddWithValue("@District", district);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Postal_code", parsedpostal);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Write_news", write_news);
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Written_by", written_by);
                    }
                    else
                    {
                        //command.Parameters.AddWithValue("@Written_by", "ERROR");
                        return;
                    }
                 
                    command.Parameters.AddWithValue("@Date_time", dos);
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Admin_id", parsedId);
                    }
                    else
                    {
                        // command.Parameters.AddWithValue("@Admin_id", 0);
                        return;
                    }
                    

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0 && flag)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DangerousPlace_Management dm = new DangerousPlace_Management();
            dm.Show();
            this.Hide();
        }

        private void DangerousPlace_Load(object sender, EventArgs e)
        {

        }
    }
    }

