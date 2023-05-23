using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinical_Management
{
    public partial class total2 : Form
    {
        public static Int64 income, outcome, remainder;
        public total2()
        {
            InitializeComponent();
        }

        private void total2_Load(object sender, EventArgs e)
        {
            income_t.Text = income.ToString();
            outcome_t.Text = outcome.ToString();
            remainder_t.Text = remainder.ToString();
            remaining_t.Text = (income - outcome).ToString();
        }

        private void ÃœÊ·„⁄Ì‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moein frm = new moein();
            frm.ShowDialog();
        }

        private void ”«·„«·ÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            finyear frm = new finyear();
            frm.ShowDialog();
        }

        private void algoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algorithm frm = new Algorithm();
            frm.Show();
        }

        private void ‰Ê» œÂÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nobat frm = new nobat();
            frm.Show();
        }

        private void Å–Ì—‘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void »«Ìê«‰ÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

        private void Å—Ê‰œÂÃœÌœToolStripMenuItem_Click(object sender, EventArgs e)
        {
            all_info frm = new all_info();
            frm.Show();
        }

        private void Ì«œ¬Ê—ÌÂ«ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reminder frm = new Reminder();
            frm.Show();
        }

        private void ¬œ—”œÂÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
            frm.Show();
        }

        private void referralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Referral frm = new Referral();
            frm.Show();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultation frm = new Consultation();
            frm.Show();
        }

        private void photoArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Photo_Archive frm = new Photo_Archive();
            frm.Show();
        }

        private void patientProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Patient.IsOpen == true)
            {
                alert2 frm2 = new alert2();
                frm2.ShowDialog();
                return;
            }

            int i = 0;
            string s;
            Patient frm = new Patient();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct mname from info where mname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.mname_t.AutoCompleteCustomSource.Add(data["mname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.lname_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["bplace"].ToString();
                frm.bplace_c.Items.Insert(i, s);
                frm.bplace_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct father from info where father<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct city from info where city<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["city"].ToString();
                frm.city_c.Items.Insert(i, s);
                frm.city_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["sodor"].ToString();
                frm.sodor_c.Items.Insert(i, s);
                frm.sodor_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();


            sqlconn.Close();

            frm.Show();
        }

        private void medicalLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medical_Library frm = new Medical_Library();
            frm.Show();
        }

        private void researchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Research frm = new Research();
            frm.Show();
        }

        private void ê“«—‘»Ì„ÂToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print_DP frm = new Print_DP();
            frm.Show();
        }

        private void ’Ê— Õ”«»ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm = new Invoice();
            frm.Show();
        }

        private void ‰«„Â«Ì„ ›—ﬁÂToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invitation frm = new Invitation();
            frm.Show();
        }
    }
}