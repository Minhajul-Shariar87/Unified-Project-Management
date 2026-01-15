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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked) {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int userid;
            
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string name = textBox6.Text.Trim();
            string age = textBox7.Text.Trim();

            if (!int.TryParse(age, out int parsedAge)&&age.Length>2&&age==null)
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string dob = dateTimePicker2.Text;
            string gender;
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }
            else {
                gender = radioButton3.Text;
            }

            string blood_group = textBox5.Text;
            if (blood_group.Length>3&&blood_group.Length<1&&blood_group==null&&((blood_group!="A+")|| (blood_group != "B+")|| (blood_group != "A-")|| (blood_group != "B-")|| (blood_group != "AB+")|| (blood_group != "AB-")|| (blood_group != "O+")|| (blood_group != "O+"))) {
                MessageBox.Show("Blood Group must be valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string dyhap;
            string pet_name;
            string breed;
            bool check = false;
            if (radioButton4.Checked) {
                dyhap = radioButton4.Text;
                pet_name = textBox3.Text;
                breed = textBox4.Text;
                check = true;
            } else  { 
            dyhap= radioButton5.Text;
                pet_name = "No Information";
                breed = "No Information";
                check = false;
            }

            string address = richTextBox2.Text;
            string phone = textBox1.Text;
            if (phone.Length>11) {
                MessageBox.Show("Phone number must be valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!int.TryParse(phone, out int parsedPhone))
            {
                MessageBox.Show("Phone no must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string password = textBox2.Text;
            string dos = dateTimePicker1.Text;
            if (check)
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(age) || string.IsNullOrEmpty(blood_group) || string.IsNullOrEmpty(dyhap) || string.IsNullOrEmpty(pet_name) || string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(age) || string.IsNullOrEmpty(blood_group) || string.IsNullOrEmpty(dyhap)|| string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

                string query = "INSERT INTO Register (NAME, AGE, DATE_OF_BIRTH, GENDER,BLOOD_GROUP,PET_Y_N,PET_NAME,BREED,ADDRESS,PHONE,PASSWORD,DATE_AND_TIME) VALUES (@Name, @Age, @Dob, @Gender,@Blood_group,@Pet_y_n,@Pet_name,@Breed,@Address,@Phone,@Password,@Date_and_time)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", parsedAge);
                    command.Parameters.AddWithValue("@Dob", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Blood_group", blood_group);
                    command.Parameters.AddWithValue("@Pet_y_n", dyhap);
                    command.Parameters.AddWithValue("@Pet_name", pet_name);
                    command.Parameters.AddWithValue("@Breed", breed);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone", parsedPhone);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Date_and_time", dos);


                    connection.Open();
                    
                    command.CommandText += "; SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    object result = command.ExecuteScalar();
                    userid = Convert.ToInt32(result);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                        MessageBox.Show("Profile created successfully! See your ID and password for further access to profile", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Show_ID_and_Pass sip = new Show_ID_and_Pass(userid,password);
                        sip.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
