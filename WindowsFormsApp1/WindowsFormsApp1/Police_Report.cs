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
    public partial class Police_Report : Form
    {
        string connectionString = "data source=DESKTOP-N5C571F\\SQLEXPRESS; database=Women_Protection; integrated security=SSPI";

        public Police_Report()
        {
            InitializeComponent();

            string query = "SELECT * FROM Report_Police ";
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

        private void Police_Report_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idText = dataGridView1.SelectedRows[0].Cells["REPORT_POLICE_ID"].Value.ToString();

                if (int.TryParse(idText, out int selectedId))
                {
                    Police_Report_Show vs = new Police_Report_Show(selectedId);
                    vs.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ID is not a valid number.");
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

            string query = @"SELECT * FROM Report_Police
                     WHERE REPORT_POLICE_ID LIKE @searchTerm 
                        OR NAME LIKE @searchTerm 
                        OR AGE LIKE @searchTerm
                        
                        OR DISTRICT LIKE @searchTerm
                        OR ADDRESS LIKE @searchTerm
                        OR DATE_TIME LIKE @searchTerm
                        OR USER_ID LIKE @searchTerm
                       ";



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
            User_Dashboard ud= new User_Dashboard();
            ud.Show();
            this.Hide();
        }
    }
}
