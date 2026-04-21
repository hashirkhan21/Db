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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                label6.Text = "Email Can Not Be Empty";
            }
            else if(String.IsNullOrEmpty(txtPassword.Text))
            {
                label6.Text = "Password Can Not Be Empty";

            }
            else
            {
                this.Hide();
                UserMenu userMenu = new UserMenu();
                userMenu.Show();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserReg userreg = new UserReg();
            userreg.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
