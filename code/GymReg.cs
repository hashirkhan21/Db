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
using static System.Windows.Forms.LinkLabel;

namespace WindowsFormsApp6
{
    public partial class Form5 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
            conn.Open();
            string gymName = textBox1.Text;
            string location = textBox2.Text;
            string openTime = textBox3.Text;
            string closeTime = textBox4.Text;
            string Desc = textBox5.Text;

            string getGymOwnerIDQuery = "SELECT COUNT(*) from PotentialGymOwnerTable";
            cm = new SqlCommand(getGymOwnerIDQuery, conn);
            int gymOwnerID = ( Convert.ToInt32(cm.ExecuteScalar()) * 2 ) + 200;

            string insertOwnerQuery = "UPDATE PotentialGymOwnerTable "
                                       + " SET PotentialGymName = @gymName, PotentialGymLocation = @location, PotentialGymOpeningTime = @openTime, PotentialGymClosingTime = @closeTime, PotentialGymDesc = @desc "
                                       + " where PotentialGymOwnerID = @gymOwnerID";
            cm = new SqlCommand(insertOwnerQuery, conn);
            cm.Parameters.AddWithValue("@gymName", gymName);
            cm.Parameters.AddWithValue("@location", location);
            cm.Parameters.AddWithValue("@openTime", openTime);
            cm.Parameters.AddWithValue("@closeTime", closeTime);
            cm.Parameters.AddWithValue("@desc", Desc);
            cm.Parameters.AddWithValue("@gymOwnerID", gymOwnerID);
            cm.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Please wait for the admin to approve of the registration :)");

            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();   
            mm.Show();
            this.Hide();
        }
    }
}
