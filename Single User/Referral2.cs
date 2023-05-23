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
    public partial class Referral2 : Form
    {
       // private static string tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10, tel11, desc11, adr2, adr3, adr4, adr5, adr6, email2, edr2, email3, edr3, email4, edr4, email5, edr5, email6, edr6, email7, edr7, email8, edr8, email9, edr9, email10, edr10, email11, edr11;
        public static object[] ref_row = new object[14];
        public Referral2()
        {
            InitializeComponent();
        }

        private void Referral2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Referral2_Load(object sender, EventArgs e)
        {
          //  tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = tel11 = desc11 = adr2 = adr3 = adr4 = adr5 = adr6 = email2 = edr2 = email3 = edr3 = email4 = edr4 = email5 = edr5 = email6 = edr6 = email7 = edr7 = email8 = edr8 = email9 = edr9 = email10 = edr10 = email11 = edr11 = "";

            place_t.Focus();

            place_t.Text = ref_row[2].ToString();
            title_t.Text = ref_row[3].ToString();
            fname_t.Text = ref_row[4].ToString();
            family_t.Text = ref_row[5].ToString();
            tel_t.Text = ref_row[6].ToString();
            desc_t.Text = ref_row[7].ToString();
            city_t.Text = ref_row[8].ToString();
            adr_t.Text = ref_row[9].ToString();
            zip_t.Text = ref_row[10].ToString();
            edr_t.Text = ref_row[11].ToString();
            email_c.Text = ref_row[12].ToString();
            job_t.Text = ref_row[13].ToString();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select * from temp where form='" + this.Name + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();

            sqlconn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select * from tel where place = '" + place_t.Text + "' and title = '" + title_t.Text + "' and fname = '" + fname_t.Text + "' and family = '" + family_t.Text + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                ref_tel.ref_tel2 = data["tel2"].ToString();
                ref_tel.ref_tel3 = data["tel3"].ToString();
                ref_tel.ref_tel4 = data["tel4"].ToString();
                ref_tel.ref_tel5 = data["tel5"].ToString();
                ref_tel.ref_tel6 = data["tel6"].ToString();
                ref_tel.ref_tel7 = data["tel7"].ToString();
                ref_tel.ref_tel8 = data["tel8"].ToString();
                ref_tel.ref_tel9 = data["tel9"].ToString();
                ref_tel.ref_tel10 = data["tel10"].ToString();

                ref_tel.ref_desc2 = data["desc2"].ToString();
                ref_tel.ref_desc3 = data["desc3"].ToString();
                ref_tel.ref_desc4 = data["desc4"].ToString();
                ref_tel.ref_desc5 = data["desc5"].ToString();
                ref_tel.ref_desc6 = data["desc6"].ToString();
                ref_tel.ref_desc7 = data["desc7"].ToString();
                ref_tel.ref_desc8 = data["desc8"].ToString();
                ref_tel.ref_desc9 = data["desc9"].ToString();
                ref_tel.ref_desc10 = data["desc10"].ToString();

                ref_email.ref_edr2 = data["edr2"].ToString();
                ref_email.ref_edr3 = data["edr3"].ToString();
                ref_email.ref_edr4 = data["edr4"].ToString();
                ref_email.ref_edr5 = data["edr5"].ToString();
                ref_email.ref_edr6 = data["edr6"].ToString();
                ref_email.ref_edr7 = data["edr7"].ToString();
                ref_email.ref_edr8 = data["edr8"].ToString();
                ref_email.ref_edr9 = data["edr9"].ToString();
                ref_email.ref_edr10 = data["edr10"].ToString();

                ref_email.ref_email2 = data["email2"].ToString();
                ref_email.ref_email3 = data["email3"].ToString();
                ref_email.ref_email4 = data["email4"].ToString();
                ref_email.ref_email5 = data["email5"].ToString();
                ref_email.ref_email6 = data["email6"].ToString();
                ref_email.ref_email7 = data["email7"].ToString();
                ref_email.ref_email8 = data["email8"].ToString();
                ref_email.ref_email9 = data["email9"].ToString();
                ref_email.ref_email10 = data["email10"].ToString();

                ref_adr.ref_adr2 = data["adr2"].ToString();
                ref_adr.ref_adr3 = data["adr3"].ToString();
                ref_adr.ref_adr4 = data["adr4"].ToString();
                ref_adr.ref_adr5 = data["adr5"].ToString();

            }
            data.Close();

            sqlconn.Close();


            ref_tel frm = new ref_tel();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ref_adr frm = new ref_adr();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ref_email frm = new ref_email();
            frm.ShowDialog();
        }

    }
}