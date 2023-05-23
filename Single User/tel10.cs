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
    public partial class tel10 : Form
    {
       // public static string tel10_place, tel10_title, tel10_fname, tel10_family;
        public tel10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tel2.desc2 = desc1_t.Text;
            Tel2.desc3 = desc2_t.Text;
            Tel2.desc4 = desc3_t.Text;
            Tel2.desc5 = desc4_t.Text;
            Tel2.desc6 = desc5_t.Text;
            Tel2.desc7 = desc6_t.Text;
            Tel2.desc8 = desc7_t.Text;
            Tel2.desc9 = desc8_t.Text;
            Tel2.desc10 = desc9_t.Text;

            Tel2.tel2 = tel1_t.Text;
            Tel2.tel3 = tel2_t.Text;
            Tel2.tel4 = tel3_t.Text;
            Tel2.tel5 = tel4_t.Text;
            Tel2.tel6 = tel5_t.Text;
            Tel2.tel7 = tel6_t.Text;
            Tel2.tel8 = tel7_t.Text;
            Tel2.tel9 = tel8_t.Text;
            Tel2.ttel10 = tel9_t.Text;

            this.Close();
        }

        private void tel10_Load(object sender, EventArgs e)
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

            sqlcmd.CommandText = "Select distinct desc1 from tel_tmp where desc1<>'' ";
            data = sqlcmd.ExecuteReader();
            string s = "";
            while (data.Read())
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
            }
            data.Close();

            sqlconn.Close();

            desc1_t.Text = Tel2.desc2;
            desc2_t.Text = Tel2.desc3;
            desc3_t.Text = Tel2.desc4;
            desc4_t.Text = Tel2.desc5;
            desc5_t.Text = Tel2.desc6;
            desc6_t.Text = Tel2.desc7;
            desc7_t.Text = Tel2.desc8;
            desc8_t.Text = Tel2.desc9;
            desc9_t.Text = Tel2.desc10;

            tel1_t.Text = Tel2.tel2;
            tel2_t.Text = Tel2.tel3;
            tel3_t.Text = Tel2.tel4;
            tel4_t.Text = Tel2.tel5;
            tel5_t.Text = Tel2.tel6;
            tel6_t.Text = Tel2.tel7;
            tel7_t.Text = Tel2.tel8;
            tel8_t.Text = Tel2.tel9;
            tel9_t.Text = Tel2.ttel10;
        }

        private void tel10_ResizeEnd(object sender, EventArgs e)
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