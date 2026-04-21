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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // login button
            // go to admin menu
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            bool check = true;
            string email = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Please enter your email!");
                check = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider2.SetError(textBox2, "Please enter your password!");
                check = false;
            }

            if (check == false) { return; }

            string query = "SELECT * from adminTable where adminEmail = '" + email + "' AND adminPassword  = '" + password + "'";

            //sql reader
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Login Successful!");
                Form8 f8 = new Form8();
                f8.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password!");
            }
            conn.Dispose();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // exit the system
            MainMenu mm = new MainMenu();   
            mm.Show();
            this.Hide();
        }
    }
}
