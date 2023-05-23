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
    public partial class doctor2 : Form
    {
        public static bool doctor_ins_mode = false;
        public static string doctor_username;
        public doctor2()
        {
            InitializeComponent();
        }

        private void doctor2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void doctor2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            name_t.Focus();
            SqlDataReader data;

            if (doctor_ins_mode == true)
                button1.Text = "œ—Ã";
            else
            {
                button1.Text = " €ÌÌ—«  À»  ‘Êœ";

                sqlcmd.CommandText = "select * from doctor where username = '"+ doctor_username +"' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    name_t.Text = data["name"].ToString();
                    family_t.Text = data["family"].ToString();
                    prf_t.Text = data["prf"].ToString();
                    username_t.Text = data["username"].ToString();
                    pass_t.Text = cm.MyDecoding(data["pass"].ToString());
                    pass2_t.Text = pass_t.Text;

                    username_t.ReadOnly = true;
                }
                data.Close();
            }
            
            sqlcmd.CommandText = "select * from temp where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (family_t.Text == "")
            {
                MessageBox.Show("·ÿ›« ›Ì·œ „—»Êÿ »Â ‰«„ Œ«‰Ê«œêÌ Å“‘ﬂ —«  ﬂ„Ì· ‰„«ÌÌœ", " ÊÃÂ");
                return;
            }

            if (username_t.Text == "")
            {
                MessageBox.Show("·ÿ›« ›Ì·œ „—»Êÿ »Â ‰«„ ﬂ«—»—Ì Å“‘ﬂ —«  ﬂ„Ì· ‰„«ÌÌœ", " ÊÃÂ");
                return;
            }

            if (pass_t.Text == "")
            {
                MessageBox.Show("·ÿ›« ›Ì·œ „—»Êÿ »Â ﬂ·„Â ⁄»Ê— Å“‘ﬂ —«  ﬂ„Ì· ‰„«ÌÌœ", " ÊÃÂ");
                return;
            }

            if (pass_t.Text.Length < 5)
            {
                MessageBox.Show("ﬂ·„Â ⁄»Ê— Õœ«ﬁ· »«Ìœ Å‰Ã Õ—›Ì »«‘œ", " ÊÃÂ");
                return;
            }

            if (pass_t.Text != pass2_t.Text)
            {
                MessageBox.Show("ﬂ·„«  ⁄»Ê— »« Â„ Ìﬂ”«‰ ‰Ì” ‰œ", " ÊÃÂ");
                return;
            }

            string mypass = cm.MyEncoding(pass_t.Text);

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (button1.Text == "œ—Ã")
            {
                sqlcmd.CommandText = "select count(*) from doctor where username = '"+ username_t.Text +"' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "insert into doctor(name,family,prf,username,pass) values('" + name_t.Text + "','" + family_t.Text + "','" + prf_t.Text + "','" + username_t.Text + "','" + mypass + "')";
                    sqlcmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("This User Name already exist.");
                    return;
                }
            }
            else
            {
                sqlcmd.CommandText = "Update doctor set name = '" + name_t.Text +"',family= '" + family_t.Text +"',prf= '" + prf_t.Text +"',pass= '" + mypass +"' where username = '"+ username_t.Text +"' ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();

            this.Close();
        }

        private void username_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void pass_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void pass2_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void name_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void family_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void prf_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void doctor2_FormClosing(object sender, FormClosingEventArgs e)
        {
            doctor_ins_mode = false;
        }

     
    }
}