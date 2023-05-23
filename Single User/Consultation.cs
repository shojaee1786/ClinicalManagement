using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Clinical_Management
{
    public partial class Consultation : Form
    {
        public static bool consult_pp;
        public Consultation()
        {
            InitializeComponent();
        }

        private void Consultation_Load(object sender, EventArgs e)
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

            sqlcmd.CommandText = "select distinct site from consult where site<>'' ";
            data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                site_c.Items.Insert(i, data["site"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct chat from consult where chat<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                chat_c.Items.Insert(i, data["chat"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void Consultation_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s =site_c.Text;
            try
            {

                System.Diagnostics.Process.Start(s);
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consult_pp == false)
            {
                Medical_File_Closet frm = new Medical_File_Closet();
                frm.Show();
            }
            else
            {
                Int64 par = Patient.par;

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text Documents(*.txt)|*.txt";
                dlg.Title = "Export as Notepad...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select * from sick1 where par = '" + par.ToString() + "' ";
                    sqlcmd.ExecuteNonQuery();

                    int i = 0;
                    string[] s = new string[1000000];
                    //s[0] = "";

                    //File.WriteAllLines(dlg.FileName, s);

                    string temp = "";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp = "        ";
                        temp += data["title"].ToString();
                        temp += "    " + data["fname"].ToString();
                        temp += "    " + data["mname"].ToString();
                        temp += "    " + data["lname"].ToString();
                        temp += "    " + data["age"].ToString();
                        temp += " ”«·Â" + "        " + data["job"].ToString();
                        temp += "        " + " «—ÌŒ Å–Ì—‘ = " + data["reception"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";

                        temp += "             ------------------------------------------------------------------";
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "CC: " + data["cc"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Dx: " + data["dx"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "PI: " + data["pi"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "PH: " + data["ph"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "FH: " + data["fh"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "PE: " + data["pe"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "G: " + data["g"].ToString() + "  ";
                        temp += "        " + "P: " + data["p"].ToString() + "  ";
                        temp += "        " + "A: " + data["a"].ToString() + "  ";
                        temp += "        " + "L: " + data["l"].ToString() + "  ";
                        temp += "        " + "D: " + data["d"].ToString() + "  ";
                        temp += "        " + "HC: " + data["hc"].ToString() + "  ";
                        temp += "        " + "HT: " + data["ht"].ToString() + "  ";
                        temp += "        " + "Wg: " + data["wg"].ToString() + "  ";
                        temp += "        " + "BP: " + data["bp"].ToString() + "  ";
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "DD: " + data["dd"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Px: " + data["px"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Rx: " + data["rx"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "IP: " + data["ip"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "OP: " + data["op"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "PC: " + data["pc"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";

                    }
                    data.Close();
                    sqlcmd.CommandText = "select * from sick2 where par = '" + par.ToString() + "' order by visit ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += "             ------------------------------------------------------------------";
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Revisit Date : " + data["rdate"].ToString() + "    No. of visit :" + data["visit"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "NCC/Sb: " + data["sb"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Ob: " + data["ob"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "As: " + data["ass"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Pl: " + data["pl"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "DD: " + data["dd"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Px: " + data["px"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Rx: " + data["rx"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "IP: " + data["ip"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "OP: " + data["op"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "Co: " + data["co"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                        temp += "        " + "PC: " + data["pc"].ToString();
                        s[i] = temp;
                        i++;
                        temp = "";
                    }
                    data.Close();

                    File.WriteAllLines(dlg.FileName, s);
                    //File.WriteAllText(dlg.FileName, temp);

                    sqlconn.Close();
                }

            }
        }

        private void Consultation_FormClosing(object sender, FormClosingEventArgs e)
        {
            consult_pp = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (consult_pp == false)
            {
                if (Directory.Exists(Application.StartupPath + "\\Patient Files") == false)
                    Directory.CreateDirectory(Application.StartupPath + "\\Patient Files");

                System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files");
            }
            else
            {
                Int64 par = Patient.par;
                if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\A - V Folder") == false)
                    Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\A - V Folder");

                System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\A - V Folder");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chat_c.Text == "")
                return;
            string s = chat_c.Text;
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select chat_src from consult where chat = '"+ s +"' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["chat_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install '"+chat_c.Text+"' Messenger then Go to the Setting to configure '"+ chat_c.Text +"' ","Notification");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Consultation.doc");
            }
            catch
            {
            }
        }
    }
}