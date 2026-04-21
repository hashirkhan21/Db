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
    public partial class Form16 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0M735RV\\SQLEXPRESS;Initial Catalog=DB_project;Integrated Security=True");
        SqlCommand cm;
        public Form16()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form16_Load(object sender, EventArgs e)
        {
            
            DataTable dataTable = GetData(); 
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private DataTable GetData()
        {

            conn.Open();
            string query = "SELECT * from gymTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            return dt;
        }

        private void ratingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Filter gyms by opening time
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * FROM gymTable " +
                           "ORDER BY " +
                           "CASE " +
                           "    WHEN gymOpeningTime = '24 Hours' THEN 0 " +
                           "    ELSE 1 " +
                           "END, " +
                           "CASE " +
                           "    WHEN gymOpeningTime LIKE '%AM%' THEN gymOpeningTime " +
                           "END";
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
            // Filter gyms by closing time
            DataTable dt = new DataTable();
            conn.Open();
            string query = @"
        SELECT *
        FROM gymTable
        ORDER BY 
            CASE 
                WHEN gymOpeningTime = '24 Hours' THEN 0  
                ELSE 1
            END,
            CASE 
                WHEN gymClosingTime LIKE '%24 Hours%' THEN 0 
                WHEN gymClosingTime LIKE '%PM%' THEN 1  
                WHEN gymClosingTime LIKE '%AM%' THEN 2  
                ELSE 3  
            END,
            CASE 
                WHEN gymClosingTime LIKE '%PM%' THEN RIGHT('0' + SUBSTRING(gymClosingTime, 1, CHARINDEX(':', gymClosingTime) - 1), 2) + SUBSTRING(gymClosingTime, CHARINDEX(':', gymClosingTime), LEN(gymClosingTime))
                ELSE '00:00 AM'  
            END,
            CASE 
                WHEN gymClosingTime LIKE '%AM%' THEN gymClosingTime  
            END";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }


        private void malesOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Filter gyms exclusively for males
            DataTable dt = new DataTable();
            conn.Open();
            string query = @"
        SELECT *
        FROM gymTable
        WHERE gymDesc LIKE '% Males Only%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }


        private void femalesOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Filter gyms exclusively for males
            DataTable dt = new DataTable();
            conn.Open();
            string query = @"
        SELECT *
        FROM gymTable
        WHERE gymDesc LIKE '%Females Only%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }


        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by small gyms 
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from gymTable where gymDesc LIKE '%Small%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(dt);
            conn.Close();
            ReportDataSource rDS = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rDS);
            this.reportViewer1.RefreshReport();
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filter by large gyms
            DataTable dt = new DataTable();
            conn.Open();
            string query = "SELECT * from gymTable where gymDesc LIKE '%Large%' OR gymDesc LIKE '%Big%'";
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
