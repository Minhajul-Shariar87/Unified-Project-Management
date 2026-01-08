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
    public partial class DangerousPlace_Management : Form
    {
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public DangerousPlace_Management()
        {
            InitializeComponent();
            string query = "SELECT * FROM DangerousPlace ";
            FillDataGridView(query);
        }
        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DangerousPlace dp = new DangerousPlace();
            dp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idText = dataGridView1.SelectedRows[0].Cells["DANGEROUS_PLACE_ID"].Value.ToString();

                if (int.TryParse(idText, out int selectedId))
                {
                    DangerousPlace_Show vs = new DangerousPlace_Show(selectedId);
                    vs.Show();
                }
                else
                {
                    MessageBox.Show("Dangerous Place ID is not a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Please select a ID first.",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM DangerousPlace
                     WHERE DANGEROUS_PLACE_ID LIKE @searchTerm 
                        OR DANGEROUS_TYPE LIKE @searchTerm 
                        OR DISTRICT LIKE @searchTerm
                        
                        OR CITY LIKE @searchTerm
                        OR POSTAL_CODE LIKE @searchTerm
                        OR ADDRESS LIKE @searchTerm
                        OR WRITE_NEWS LIKE @searchTerm
                        OR WRITTEN_BY LIKE @searchTerm
                        OR DATE_TIME LIKE @searchTerm  
                        OR ADMIN_ID LIKE @searchTerm";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");

                    /* SqlDataAdapter adapter = new SqlDataAdapter(command); //adapter acts as a bridge between a DataSet (or DataTable) and the SQL database.
                 DataTable dataTable = new DataTable();  //Instantiates a new, empty DataTable object to store the retrieved data
                 adapter.Fill(dataTable);  // Executes the SQL command and fills the dataTable with the result set returned from the database
                    dataGridView1.DataSource = dataTable;
*/
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM DangerousPlace ";
            FillDataGridView(query);
        }
    }
}
