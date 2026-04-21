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

namespace WindowsFormsApp6
{
    public partial class Form19 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form19()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void FILLDGV()
        {
            conn.Open();
            string query = "SELECT * from gymTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                FILLDGV();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //remove the gym
            conn.Open();
            string removeGymID = textBox1.Text;
            string memQuery = "DELETE from memberTable where gymID = @removeGymID";
            string trainerQeury = "DELETE from trainerGoesToGym where gymID = @removeGymID";
            string gymQuery = "DELETE from gymTable where gymID = @removeGymID";
            
            cm = new SqlCommand(memQuery, conn);
            cm.Parameters.AddWithValue("@removeGymID", removeGymID);
            cm.ExecuteNonQuery();

            cm = new SqlCommand(trainerQeury, conn);
            cm.Parameters.AddWithValue("@removeGymID", removeGymID);
            cm.ExecuteNonQuery();

            cm = new SqlCommand(gymQuery, conn);
            cm.Parameters.AddWithValue("@removeGymID", removeGymID);
            cm.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Gym deleted successfully");
        }
    }
}
