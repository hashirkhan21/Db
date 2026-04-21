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
    public partial class CreateUserDP : Form
    {
        public CreateUserDP()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUserDM createUserDM = new CreateUserDM();
            createUserDM.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserMenu userMenu = new UserMenu();
            userMenu.Show();
        }
    }
}
