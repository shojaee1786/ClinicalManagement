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
    public partial class ref_tel : Form
    {
        public static string ref_tel2, ref_tel3, ref_tel4, ref_tel5, ref_tel6, ref_tel7, ref_tel8, ref_tel9, ref_tel10;
        public static string ref_desc2, ref_desc3, ref_desc4, ref_desc5, ref_desc6, ref_desc7, ref_desc8, ref_desc9, ref_desc10;

        public ref_tel()
        {
            InitializeComponent();
        }

        private void ref_tel_Load(object sender, EventArgs e)
        {
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

            tel1_t.Text = ref_tel2;
            tel2_t.Text = ref_tel3;
            tel3_t.Text = ref_tel4;
            tel4_t.Text = ref_tel5;
            tel5_t.Text = ref_tel6;
            tel6_t.Text = ref_tel7;
            tel7_t.Text = ref_tel8;
            tel8_t.Text = ref_tel9;
            tel9_t.Text = ref_tel10;

            desc1_t.Text = ref_desc2;
            desc2_t.Text = ref_desc3;
            desc3_t.Text = ref_desc4;
            desc4_t.Text = ref_desc5;
            desc5_t.Text = ref_desc6;
            desc6_t.Text = ref_desc7;
            desc7_t.Text = ref_desc8;
            desc8_t.Text = ref_desc9;
            desc9_t.Text = ref_desc10;
        }

        private void ref_tel_ResizeEnd(object sender, EventArgs e)
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