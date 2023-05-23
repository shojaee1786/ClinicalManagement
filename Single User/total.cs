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
    public partial class total : Form
    {
        public static Int64 visit , consult , service1 , service2 , income, ret; 
        public total()
        {
            InitializeComponent();
        }

        private void total_Load(object sender, EventArgs e)
        {
            visit_t.Text = visit.ToString();
            consult_t.Text = consult.ToString();
            service1_t.Text = service1.ToString();
            service2_t.Text = service2.ToString();
            income_t.Text = income.ToString();
            ret_t.Text = ret.ToString();
        }

      

        private void cm1_Click(object sender, EventArgs e)
        {
            if (cm_menu.Visible == false)
                cm_menu.Visible = true;
            else
                cm_menu.Visible = false;
        }

      

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            paziresh_archive frm = new paziresh_archive();
            frm.Show();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible == false)
                menuStrip1.Visible = true;
            else
                menuStrip1.Visible = false;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            nobat frm = new nobat();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            all_info frm = new all_info();
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Reminder frm = new Reminder();
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            acc frm = new acc();
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Referral frm = new Referral();
            frm.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Consultation frm = new Consultation();
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Photo_Archive frm = new Photo_Archive();
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Medical_Library frm = new Medical_Library();
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Research frm = new Research();
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Algorithm frm = new Algorithm();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Risk_Factor frm = new Risk_Factor();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            paziresh_archive frm = new paziresh_archive();
            frm.Show();
        }

        private void total_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            cm_menu.Visible = false;
        }
    }
}