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
    public partial class email : Form
    {
        public email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tel2.email2 = email2_c.Text;
            Tel2.email3 = email3_c.Text;
            Tel2.email4 = email4_c.Text;
            Tel2.email5 = email5_c.Text;
            Tel2.email6 = email6_c.Text;
            Tel2.email7 = email7_c.Text;
            Tel2.email8 = email8_c.Text;
            Tel2.email9 = email9_c.Text;
            Tel2.email10 = email10_c.Text;

            Tel2.edr2 = edr2_t.Text;
            Tel2.edr3 = edr3_t.Text;
            Tel2.edr4 = edr4_t.Text;
            Tel2.edr5 = edr5_t.Text;
            Tel2.edr6 = edr6_t.Text;
            Tel2.edr7 = edr7_t.Text;
            Tel2.edr8 = edr8_t.Text;
            Tel2.edr9 = edr9_t.Text;
            Tel2.edr10 = edr10_t.Text;
            
            this.Close();
        }

        private void email_Load(object sender, EventArgs e)
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

            int i;
            i = 0;
            string s = "";
            sqlcmd.CommandText = "select distinct email from tel_tmp where email<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["email"].ToString();
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

            email2_c.Text = Tel2.email2;
            email3_c.Text = Tel2.email3;
            email4_c.Text = Tel2.email4;
            email5_c.Text = Tel2.email5;
            email6_c.Text = Tel2.email6;
            email7_c.Text = Tel2.email7;
            email8_c.Text = Tel2.email8;
            email9_c.Text = Tel2.email9;
            email10_c.Text = Tel2.email10;

            edr2_t.Text = Tel2.edr2;
            edr3_t.Text = Tel2.edr3;
            edr4_t.Text = Tel2.edr4;
            edr5_t.Text = Tel2.edr5;
            edr6_t.Text = Tel2.edr6;
            edr7_t.Text = Tel2.edr7;
            edr8_t.Text = Tel2.edr8;
            edr9_t.Text = Tel2.edr9;
            edr10_t.Text = Tel2.edr10;
        }

        private void email_ResizeEnd(object sender, EventArgs e)
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