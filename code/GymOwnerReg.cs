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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // form for gym details
            conn.Open();
            string fName = textBox1.Text;
            string LName = textBox2.Text;
            string DOB = textBox3.Text;
            string gymOwnerEmail = textBox4.Text;
            string gymOwnerPassword = textBox5.Text;

            string insertOwnerQuery = "INSERT INTO PotentialGymOwnerTable(fName, LName, PotentialGymOwnerEmail, PotentialGymOwnerPassword, PotentialGymOwnerDOB) "
                            + " VALUES (@fName, @LName, @gymOwnerEmail, @gymOwnerPassword, @DOB) ";
            cm = new SqlCommand(insertOwnerQuery, conn);
            cm.Parameters.AddWithValue("@fName", fName);
            cm.Parameters.AddWithValue("@LName", LName);
            cm.Parameters.AddWithValue("@gymOwnerEmail", gymOwnerEmail);
            cm.Parameters.AddWithValue("@gymOwnerPassword", gymOwnerPassword);
            cm.Parameters.AddWithValue("@DOB", DOB);
            cm.ExecuteNonQuery();

            conn.Close();

            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
