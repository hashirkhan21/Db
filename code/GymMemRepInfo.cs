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
    public partial class Form9 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form9()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {

            DataTable dataTable = GetData();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private DataTable GetData()
        {

            conn.Open();
            string query = "SELECT * from memberTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            return dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();   
            mm.Show();
            this.Hide();
        }

        private void experienceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by customer satisfaction
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from memberTable ORDER BY customerSatisfaction DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by regular gym membership
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from memberTable where memberShipType = 'Regular'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void premiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by premium gym membership
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from memberTable where memberShipType = 'Premium'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void vIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by VIP membership type
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from memberTable where memberShipType = 'VIP'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by duration
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * FROM memberTable ORDER BY "
                            + " CASE WHEN memberShipDuration LIKE '%months' THEN CAST(REPLACE(memberShipDuration, ' months', '') AS INT) "
                            + "WHEN memberShipDuration LIKE '%month' THEN CAST(REPLACE(memberShipDuration, ' month', '') AS INT)   ELSE 0   END DESC; ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
