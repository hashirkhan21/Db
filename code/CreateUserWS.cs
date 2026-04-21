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
    public partial class CreateUserWS : Form
    {
        public CreateUserWS()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserMenu userMenu = new UserMenu();
            userMenu.Show();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {

        }
    }
}
