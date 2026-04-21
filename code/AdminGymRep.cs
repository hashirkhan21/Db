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
    public partial class Form15 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form15()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Show();
            //this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();   
            mm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchID = textBox1.Text;

            conn.Open();

            string query = "SELECT * FROM gymTable WHERE gymID = @SearchID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SearchID", searchID);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd; // Set the SelectCommand property

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
    }
}
