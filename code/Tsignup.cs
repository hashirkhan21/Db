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
    public partial class Tsignup : Form
    {
        public Tsignup()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tlogin regForm = new Tlogin();
            regForm.Show();
            this.Hide();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void signIn_Click(object sender, EventArgs e)
        {
            string str1 = textBox7.Text, str2 = textBox6.Text;
            if (str1 != str2)
            {
                errorProvider1.SetError(textBox7, "Passwords do not match!");
            }
            else {
                Tview form3 = new Tview();
                form3.Show();
                this.Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
                return;
            LB1.Items.Add(textBox7.Text);
            textBox7.Clear();
            textBox7.Focus();
        }

        private void LB1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
                return;
            LB2.Items.Add(textBox8.Text);
            textBox8.Clear();
            textBox8.Focus();
        }

        private void LB2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LB1.Items.Count > 0 && LB1.SelectedIndex != -1)
                LB1.Items.RemoveAt(LB1.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LB2.Items.Count > 0 && LB2.SelectedIndex != -1)
                LB2.Items.RemoveAt(LB2.SelectedIndex);
        }
    }
}
