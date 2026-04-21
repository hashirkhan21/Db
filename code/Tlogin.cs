using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp6
{
    public partial class Tlogin : Form
    {
        public Tlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text, str2 = textBox2.Text;
            if (string.IsNullOrEmpty(str2))
            {
                errorProvider3.SetError(textBox2, "Password cannot be left blank!");
            }
            else if (string.IsNullOrEmpty(str)) {
                errorProvider2.SetError(textBox1, "Username cannot be left blank!");
            }
            else if (str.Length > 16)
            {
                errorProvider1.SetError(textBox1, "Username must be less than 16 characters long!");
            }
            else {
                Tview form3 = new Tview();
                form3.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void signIn_Validating(object sender, CancelEventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tsignup regForm = new Tsignup();
            regForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(); 
            mainMenu.Show();    
            this.Hide();
        }
    }
}
