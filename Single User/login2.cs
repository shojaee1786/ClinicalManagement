using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;


namespace Clinical_Management
{
    public partial class login2 : Form
    {
        public static string log_username_monshi;
        public login2()
        {
            InitializeComponent();
        }

        private void login2_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
            if (File.Exists(Application.StartupPath + "\\info2.ini") == true)
            {
                try
                {
                    string defaultpass = "";
                    string defaultuser = File.ReadAllText(Application.StartupPath + "\\info2.ini");
                    defaultuser = cm.MyDecoding(defaultuser).Replace("\0", "");
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    SqlDataReader data;
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select pass from monshi where username ='" + defaultuser + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        defaultpass = cm.MyDecoding(data["pass"].ToString()).Replace("\0", "");
                    }
                    data.Close();

                    sqlconn.Close();

                    if (defaultpass != "")
                    {
                        username_t.Text = defaultuser;
                        pass_t.Text = defaultpass;
                        login_ch.Checked = true;
                    }
                }
                catch { }
            }
            username_t.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + "\\info2.ini");
            }
            catch { }


            log_username_monshi = username_t.Text;

            string mydoctor="";

            string mypass = cm.MyEncoding(pass_t.Text);

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select count(*) from monshi where username ='"+ username_t.Text +"' and pass = '"+ mypass +"' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                MessageBox.Show("‰«„ ﬂ«—»—Ì Ê Ì« ﬂ·„Â ⁄»Ê— „⁄ »— ‰„Ì »«‘œ", " ÊÃÂ");
            }
            else
            {
                if (login_ch.Checked == true)
                {
                    try
                    {
                        File.WriteAllText(Application.StartupPath + "\\info2.ini", cm.MyEncoding(username_t.Text));
                    }
                    catch { }
                }

                sqlcmd.CommandText = "select * from monshi where username ='" + username_t.Text + "' and pass = '" + mypass + "' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    mydoctor = data["doctor"].ToString();
                    
                }

                data.Close();

                sqlcmd.CommandText = "select * from doctor where username ='" + mydoctor + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    login.log_name = data["name"].ToString();
                    login.log_family = data["family"].ToString();
                    login.log_prf = data["prf"].ToString();
                    login.log_username = data["username"].ToString();
                    login.log_pass = data["pass"].ToString();
                }
                data.Close();

                this.Visible = false;

                //SW1 frm = new SW1();
                //frm.ShowDialog();

                SW3 frm = new SW3();
                frm.ShowDialog();

                this.Close();
            }
            sqlconn.Close();
        }

        private void pass_t_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + "\\info2.ini");
            }
            catch { }

            log_username_monshi = username_t.Text;

            if (e.KeyCode == Keys.Enter)
            {
                string mydoctor = "";

                string mypass = cm.MyEncoding(pass_t.Text);

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select count(*) from monshi where username ='" + username_t.Text + "' and pass = '" + mypass + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    MessageBox.Show("‰«„ ﬂ«—»—Ì Ê Ì« ﬂ·„Â ⁄»Ê— „⁄ »— ‰„Ì »«‘œ", " ÊÃÂ");
                }
                else
                {
                    if (login_ch.Checked == true)
                    {
                        try
                        {
                            File.WriteAllText(Application.StartupPath + "\\info2.ini", cm.MyEncoding(username_t.Text));
                        }
                        catch { }
                    }

                    sqlcmd.CommandText = "select * from monshi where username ='" + username_t.Text + "' and pass = '" + mypass + "' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        mydoctor = data["doctor"].ToString();
                    }

                    data.Close();

                    sqlcmd.CommandText = "select * from doctor where username ='" + mydoctor + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        login.log_name = data["name"].ToString();
                        login.log_family = data["family"].ToString();
                        login.log_prf = data["prf"].ToString();
                        login.log_username = data["username"].ToString();
                        login.log_pass = data["pass"].ToString();
                    }
                    data.Close();

                    this.Visible = false;

                    //SW1 frm = new SW1();
                    //frm.ShowDialog();

                    SW3 frm = new SW3();
                    frm.ShowDialog();

                    this.Close();
                }
                sqlconn.Close();
            }
        }

    }
}