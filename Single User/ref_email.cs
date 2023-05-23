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
    public partial class ref_email : Form
    {
        public static string ref_email2, ref_email3, ref_email4, ref_email5, ref_email6, ref_email7, ref_email8, ref_email9, ref_email10;
        public static string ref_edr2, ref_edr3, ref_edr4, ref_edr5, ref_edr6, ref_edr7, ref_edr8, ref_edr9, ref_edr10;

        public ref_email()
        {
            InitializeComponent();
        }

        private void ref_email_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
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


            edr2_t.Text = ref_edr2;
            edr3_t.Text = ref_edr3;
            edr4_t.Text = ref_edr4;
            edr5_t.Text = ref_edr5;
            edr6_t.Text = ref_edr6;
            edr7_t.Text = ref_edr7;
            edr8_t.Text = ref_edr8;
            edr9_t.Text = ref_edr9;
            edr10_t.Text = ref_edr10;

            ref_email2_c.Text = ref_email2;
            ref_email3_c.Text = ref_email3;
            ref_email4_c.Text = ref_email4;
            ref_email5_c.Text = ref_email5;
            ref_email6_c.Text = ref_email6;
            ref_email7_c.Text = ref_email7;
            ref_email8_c.Text = ref_email8;
            ref_email9_c.Text = ref_email9;
            ref_email10_c.Text = ref_email10;
        }

        private void ref_email_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }
    }
}