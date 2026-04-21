using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form17 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        private int selectedRowIndex = -1;
        public Form17()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void FILLDGV()
        {
            conn.Open();
            string query = "SELECT CONCAT(fName, ' ', LName) AS GymOwner, PotentialGymOwnerEmail, PotentialGymOwnerID, PotentialGymName, PotentialGymLocation, PotentialGymOpeningTime, PotentialGymClosingTime, PotentialGymDesc from PotentialGymOwnerTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex != -1)
            {
                conn.Open();
                string gymName = dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymName"].Value.ToString();
                string gymLocation = dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymLocation"].Value.ToString();
                string gymOpeningTime = dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymOpeningTime"].Value.ToString();
                string gymClosingTime = dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymClosingTime"].Value.ToString();
                string gymDesc = dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymDesc"].Value.ToString();

                // Insert potential gym owner details into gymOwnerTable
                string insertOwnerQuery = "INSERT INTO gymOwnerTable (fName, LName, gymOwnerEmail, gymOwnerPassword, gymOwnerDOB) " +
                                          "SELECT fName, LName, PotentialGymOwnerEmail, PotentialGymOwnerPassword, PotentialGymOwnerDOB " +
                                          "FROM PotentialGymOwnerTable " +
                                          "WHERE PotentialGymOwnerID = @PotentialGymOwnerID";

                cm = new SqlCommand(insertOwnerQuery, conn);
                cm.Parameters.AddWithValue("@PotentialGymOwnerID", dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymOwnerID"].Value.ToString());
                cm.ExecuteNonQuery();

                string getGymOwnerIDQuery = "SELECT COUNT(*) from gymOwnerTable";
                cm = new SqlCommand(getGymOwnerIDQuery, conn);
                // adding 209 because the i deleted a lot of tables 
                int gymOwnerID = Convert.ToInt32(cm.ExecuteScalar()) + 209;

                Console.WriteLine(gymOwnerID);
                // Insert potential gym details into gymTable
                string insertGymQuery = "INSERT INTO gymTable (gymOwnerID, gymName, gymLocation, gymOpeningTime, gymClosingTime, gymDesc) " +
                                        "VALUES (@gymOwnerID, @gymName, @gymLocation, @gymOpeningTime, @gymClosingTime, @gymDesc)";

                cm = new SqlCommand(insertGymQuery, conn);
                cm.Parameters.AddWithValue("@gymOwnerID", gymOwnerID); // Get the gymOwnerID of the newly inserted gym owner
                cm.Parameters.AddWithValue("@gymName", gymName);
                cm.Parameters.AddWithValue("@gymLocation", gymLocation);
                cm.Parameters.AddWithValue("@gymOpeningTime", gymOpeningTime);
                cm.Parameters.AddWithValue("@gymClosingTime", gymClosingTime);
                cm.Parameters.AddWithValue("@gymDesc", gymDesc);
                cm.ExecuteNonQuery();

                // Delete potential gym owner details from PotentialGymOwnerTable
                string deleteQuery = "DELETE FROM PotentialGymOwnerTable WHERE PotentialGymOwnerID = @PotentialGymOwnerID";
                cm = new SqlCommand(deleteQuery, conn);
                cm.Parameters.AddWithValue("@PotentialGymOwnerID", dataGridView1.Rows[selectedRowIndex].Cells["PotentialGymOwnerID"].Value.ToString());
                cm.ExecuteNonQuery();

                conn.Close();

                // Refresh DataGridView
                FILLDGV();
            }
            else
            {
                MessageBox.Show("Please select a row to add.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
