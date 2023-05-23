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
    public partial class adr_tel : Form
    {
        public adr_tel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adr_tel_Load(object sender, EventArgs e)
        {
            desc1_t.Items.Clear();
            desc2_t.Items.Clear();
            desc3_t.Items.Clear();
            desc4_t.Items.Clear();
            desc5_t.Items.Clear();
            desc6_t.Items.Clear();
            desc7_t.Items.Clear();
            desc8_t.Items.Clear();
            desc9_t.Items.Clear();
            desc10_t.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Select distinct desc1 from tel_tmp where desc1<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            string s = "";
            while(data.Read())
            {
                s = data["desc1"].ToString();
                
                
               
                desc1_t.Items.Add(s);
                desc2_t.Items.Add(s);
                desc3_t.Items.Add(s);
                desc4_t.Items.Add(s);
                desc5_t.Items.Add(s);
                desc6_t.Items.Add(s);
                desc7_t.Items.Add(s);
                desc8_t.Items.Add(s);
                desc9_t.Items.Add(s);
                desc10_t.Items.Add(s);
            }
            data.Close();

            sqlconn.Close();
            
            tel1_t.Text = all_info.tel1;
            tel2_t.Text = all_info.tel2;
            tel3_t.Text = all_info.tel3;
            tel4_t.Text = all_info.tel4;
            tel5_t.Text = all_info.tel5;
            tel6_t.Text = all_info.tel6;
            tel7_t.Text = all_info.tel7;
            tel8_t.Text = all_info.tel8;
            tel9_t.Text = all_info.tel9;
            tel10_t.Text = all_info.tel10;

            desc1_t.Text = all_info.desc1;
            desc2_t.Text = all_info.desc2;
            desc3_t.Text = all_info.desc3;
            desc4_t.Text = all_info.desc4;
            desc5_t.Text = all_info.desc5;
            desc6_t.Text = all_info.desc6;
            desc7_t.Text = all_info.desc7;
            desc8_t.Text = all_info.desc8;
            desc9_t.Text = all_info.desc9;
            desc10_t.Text = all_info.desc10;

            adr_t.Text = all_info.adr;
            adr2_t.Text = all_info.adr2;
            adr3_t.Text = all_info.adr3;
            adr4_t.Text = all_info.adr4;
            adr5_t.Text = all_info.adr5;
        }

        private void adr_tel_FormClosing(object sender, FormClosingEventArgs e)
        {
            all_info.tel1 = tel1_t.Text;
            all_info.tel2 = tel2_t.Text;
            all_info.tel3 = tel3_t.Text;
            all_info.tel4 = tel4_t.Text;
            all_info.tel5 = tel5_t.Text;
            all_info.tel6 = tel6_t.Text;
            all_info.tel7 = tel7_t.Text;
            all_info.tel8 = tel8_t.Text;
            all_info.tel9 = tel9_t.Text;
            all_info.tel10 = tel10_t.Text;

            all_info.desc1 = desc1_t.Text;
            all_info.desc2 = desc2_t.Text;
            all_info.desc3 = desc3_t.Text;
            all_info.desc4 = desc4_t.Text;
            all_info.desc5 = desc5_t.Text;
            all_info.desc6 = desc6_t.Text;
            all_info.desc7 = desc7_t.Text;
            all_info.desc8 = desc8_t.Text;
            all_info.desc9 = desc9_t.Text;
            all_info.desc10 = desc10_t.Text;

            all_info.adr = adr_t.Text;
            all_info.adr2 = adr2_t.Text;
            all_info.adr3 = adr3_t.Text;
            all_info.adr4 = adr4_t.Text;
            all_info.adr5 = adr5_t.Text;
        }
    }
}