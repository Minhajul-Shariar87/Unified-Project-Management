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
    public partial class Transportation_Management : Form
    {
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";


        public Transportation_Management()
        {
            InitializeComponent();
            
            string query = "SELECT * FROM Transportation ";
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
       

        private void Transportation_Management_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idText = dataGridView1.SelectedRows[0].Cells["TRANSPORTATION_ID"].Value.ToString();

                if (int.TryParse(idText, out int selectedId))
                {
                   Transportation_Show vs = new Transportation_Show(selectedId);
                    vs.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Transportation ID is not a valid number.");
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Transportation";
            FillDataGridView(query);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM Transportation
                     WHERE TRANSPORTATION_ID LIKE @searchTerm 
                        OR INCIDENT_TITLE LIKE @searchTerm 
                        OR INCIDENT_TOPIC LIKE @searchTerm
                        
                        OR WRITTEN_BY LIKE @searchTerm
                        OR ADMIN_ID LIKE @searchTerm
                        OR BUS_NAME LIKE @searchTerm
                        OR STATUS LIKE @searchTerm
                        OR ROUTE LIKE @searchTerm  
                        OR WRITE_NEWS LIKE @searchTerm  
                         OR DATE LIKE @searchTerm";



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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Transportation_Details td= new Transportation_Details();
            td.Show();
            this.Hide();
        }
    }
}
