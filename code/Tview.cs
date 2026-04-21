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
    public partial class Tview : Form
    {
        public Tview()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tlogin regForm = new Tlogin();
            regForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TWplan regForm = new TWplan();
            regForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TallW regForm = new TallW();
            regForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TDplan regForm = new TDplan();
            regForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tappoint regForm = new Tappoint();
            regForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tfeed regForm = new Tfeed();
            regForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TallD regForm = new TallD();
            regForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
