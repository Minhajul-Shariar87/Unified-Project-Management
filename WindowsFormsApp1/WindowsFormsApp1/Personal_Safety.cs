using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Personal_Safety : Form
    {
        public Personal_Safety()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";
            string name = textBox4.Text.Trim();
            string id = textBox1.Text.Trim();
            bool flag = false;




            //string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

            string query1 = "SELECT COUNT(*) FROM Admin WHERE ADMIN_ID = @Id AND NAME = @Name";
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
                        MessageBox.Show("ID and Name Found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        flag = true;


                    }
                    else
                    {
                        MessageBox.Show("Invalid Id / Name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            string product = comboBox1.Text;
            string price = textBox2.Text.Trim();
            if (!int.TryParse(price, out int parsedPrice))
            {
                MessageBox.Show("Price must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string quantity = textBox3.Text;
            if (!int.TryParse(quantity, out int parsedQuantity))
            {
                MessageBox.Show("Qunatity must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tp = textBox5.Text.Trim();

            
            if (!int.TryParse(tp, out int parsedTp))
            {
                MessageBox.Show("Total price must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO Billing (NAME,ID,PRODUCT,UNIT_PRICE,QUANTITY,TOTAL_PRICE) VALUES (@Name, @Id, @Product, @Unit_price,@Quantity,@Total_price)";

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
                    if (flag)
                    {
                        command.Parameters.AddWithValue("@Id", id);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Id", 0);
                    }
                    
                    
                    command.Parameters.AddWithValue("@Product",product);
                    command.Parameters.AddWithValue("@Unit_price",parsedPrice);
                    command.Parameters.AddWithValue("@Quantity", parsedQuantity);
                    command.Parameters.AddWithValue("@Total_price", tp);
                   

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Personal Safety Alarm")
            {
                textBox2.Text = 750.ToString();
                
            }
            else if (comboBox1.Text == "Self Defense Stun Gun")
            {
                textBox2.Text = 630.ToString();
               

            }
            else if (comboBox1.Text == "Pepper Sparay for Woman Safety-55ml")
            {
                textBox2.Text = 1250.ToString();
                
            }
            else if (comboBox1.Text == "Safety Flashlight")
            {
                textBox2.Text = 953.ToString();
                
            }
            else
            {
                textBox2.Text = 0.ToString();
                
            }
            //CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (int.TryParse(textBox2.Text, out int unitPrice) &&
        int.TryParse(textBox3.Text, out int quantity))
            {
                int total = unitPrice * quantity;
                textBox5.Text = total.ToString();
            }
            else
            {
                textBox5.Text = "0";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
    }
}
