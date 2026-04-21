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
    public partial class CreateUserDM : Form
    {
        public CreateUserDM()
        {
            InitializeComponent();
        }

        private void CreateUserDM_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserMenu userMenu = new UserMenu(); 
            userMenu.Show();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            CreateUserAllergen createUserAllergen = new CreateUserAllergen();   
            createUserAllergen.Show();
            this.Hide();

        }
    }
}
