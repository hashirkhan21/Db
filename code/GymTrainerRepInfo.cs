using Microsoft.Reporting.WinForms;
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

namespace WindowsFormsApp6
{
    public partial class Form11 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form11()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            DataTable dataTable = GetData();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
        private DataTable GetData()
        {

            conn.Open();
            string query = "SELECT * from trainerTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            return dt;
        }
        private void experienceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by experience in years
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from trainerTable ORDER BY trainerExp DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void ratingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by average rating 
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from trainerTable ORDER BY trainerRating DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }
    }
}
