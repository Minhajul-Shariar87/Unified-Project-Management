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
    public partial class Hire_Volunteer : Form
    {
        public Hire_Volunteer()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage2 hp2= new HomePage2();
            hp2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string name = textBox4.Text.Trim();
            string id = textBox7.Text.Trim();
            if (!int.TryParse(id, out int parsedId))
            {
                MessageBox.Show("ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool flag = false;




            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

            //string query1 = "SELECT COUNT(*) FROM Register WHERE ADMIN_ID = @Id AND NAME = @Name";
             string query1 = "SELECT COUNT(*) FROM Register WHERE USER_ID = @Id AND NAME COLLATE SQL_Latin1_General_CP1_CS_AS = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Id", parsedId);
                    command.Parameters.AddWithValue("@Name", name);

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
            string age = textBox1.Text.Trim();
            string insname = textBox2.Text;
            if (!int.TryParse(age, out int parsedAge))
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (age.Length > 2 || age.Length < 1 || int.Parse(age) < 1)
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string insin = textBox6.Text;
            string ques = richTextBox1.Text;
            string dos = dateTimePicker1.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(insname)|| string.IsNullOrEmpty(insin)|| string.IsNullOrEmpty(insname)|| string.IsNullOrEmpty(ques))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO Volunteer (NAME,USER_ID,AGE,INSTITUTION_NAME,INTERESTED_IN,QUESTION_ANSWER,DATE) VALUES (@Name, @Id, @Age, @Institution_name,@Interested_in,@Question_answer,@Date)";


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
                        //command.Parameters.AddWithValue("@Name", "ERROR");
                        return;
                    }
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Id", id);
                    }
                    else
                    {
                        //command.Parameters.AddWithValue("@Id", 0);
                        return;
                    }
                    
                    command.Parameters.AddWithValue("@Age", parsedAge);
                    command.Parameters.AddWithValue("@Institution_name",insname);
                    command.Parameters.AddWithValue("@Interested_in", insin);
                    command.Parameters.AddWithValue("@Question_answer", ques);
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hire_Volunteer_Management hm = new Hire_Volunteer_Management();
            hm.Show();
            this.Hide();
        }

        private void Hire_Volunteer_Load(object sender, EventArgs e)
        {

        }
    }
}
