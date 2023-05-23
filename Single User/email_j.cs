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
    public partial class email_j : Form
    {
        public email_j()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void email_j_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct email from tel_tmp where email<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            string s = "";
            while (data.Read())
            {
                s = data["email"].ToString();
                email1_c.Items.Insert(i, s);
                email2_c.Items.Insert(i, s);
                email3_c.Items.Insert(i, s);
                email4_c.Items.Insert(i, s);
                email5_c.Items.Insert(i, s);
                email6_c.Items.Insert(i, s);
                email7_c.Items.Insert(i, s);
                email8_c.Items.Insert(i, s);
                email9_c.Items.Insert(i, s);
                email10_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            sqlconn.Close();

            edr1_t.Text = all_info.edr1;
            edr2_t.Text = all_info.edr2;
            edr3_t.Text = all_info.edr3;
            edr4_t.Text = all_info.edr4;
            edr5_t.Text = all_info.edr5;
            edr6_t.Text = all_info.edr6;
            edr7_t.Text = all_info.edr7;
            edr8_t.Text = all_info.edr8;
            edr9_t.Text = all_info.edr9;
            edr10_t.Text = all_info.edr10;

            email1_c.Text = all_info.email1;
            email2_c.Text = all_info.email2;
            email3_c.Text = all_info.email3;
            email4_c.Text = all_info.email4;
            email5_c.Text = all_info.email5;
            email6_c.Text = all_info.email6;
            email7_c.Text = all_info.email7;
            email8_c.Text = all_info.email8;
            email9_c.Text = all_info.email9;
            email10_c.Text = all_info.email10;
            

        }

        private void email_j_FormClosing(object sender, FormClosingEventArgs e)
        {
            all_info.email1 = email1_c.Text;
            all_info.email2 = email2_c.Text;
            all_info.email3 = email3_c.Text;
            all_info.email4 = email4_c.Text;
            all_info.email5 = email5_c.Text;
            all_info.email6 = email6_c.Text;
            all_info.email7 = email7_c.Text;
            all_info.email8 = email8_c.Text;
            all_info.email9 = email9_c.Text;
            all_info.email10 = email10_c.Text;

            all_info.edr1 = edr1_t.Text;
            all_info.edr2 = edr2_t.Text;
            all_info.edr3 = edr3_t.Text;
            all_info.edr4 = edr4_t.Text;
            all_info.edr5 = edr5_t.Text;
            all_info.edr6 = edr6_t.Text;
            all_info.edr7 = edr7_t.Text;
            all_info.edr8 = edr8_t.Text;
            all_info.edr9 = edr9_t.Text;
            all_info.edr10 = edr10_t.Text;
        }
    }
}