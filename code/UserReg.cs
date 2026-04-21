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
    public partial class UserReg : Form
    {
        public UserReg()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textbox6.Text))
            {
                label10.Text = "Incomplete ";
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                label11.Text = "Incomplete ";
            }
        }


        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                label12.Text = "Incomplete ";
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                label13.Text = "Incomplete ";
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                label14.Text = "Incomplete ";
            }
        }
        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                label15.Text = "Incomplete ";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Validating_1(object sender, CancelEventArgs e)
        {

        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox4.Text)
                || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text)
               || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textbox6.Text))
            { 
            
            }
            else
            {
                this.Hide();
                UserLogin userLogin = new UserLogin();
                userLogin.Show();
            }
        
        }
    }
}
