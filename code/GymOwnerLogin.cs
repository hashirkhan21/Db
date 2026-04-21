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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        private string valueToSend;
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // login button
            // go to gym owner menu
            conn.Open();
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

            string query = "SELECT * from gymOwnerTable where gymOwnerEmail = '" + email + "' AND gymOwnerPassword  = '" + password + "'";

            //sql reader
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //string query2 = "SELECT gymOwnerID from gymOwnerTable where gymOwnerEmail = ' " + email + " '";
                //SqlCommand command2 = new SqlCommand(query2, conn);
                //SqlDataReader reader2 = command2.ExecuteReader();
                //object gymOwnerID = command2.ExecuteScalar();
                //int valueToSend = (int)gymOwnerID;

                MessageBox.Show("Login Successful!");
                Form f4 = new Form4();
                f4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password!");
            }
            conn.Dispose();
            conn.Close();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // sign up button
            // go to gym owner registration
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // exit the interface 
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }
    }
}
