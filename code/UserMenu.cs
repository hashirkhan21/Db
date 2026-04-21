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
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUserWP createUserWP = new CreateUserWP();
            createUserWP.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUserDP createUserDP = new CreateUserDP();
            createUserDP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserExisitingWP userExisitingWP = new UserExisitingWP();
            userExisitingWP.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserExistingDP userLogin = new UserExistingDP();
            userLogin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserFeedback userFeedback = new UserFeedback();
            userFeedback.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserBooking userBooking = new UserBooking();
            userBooking.Show();
        }
    }

}
