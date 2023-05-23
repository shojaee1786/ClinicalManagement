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
    public partial class Preventive : Form
    {
        private static string myfile;
        public static string record_pc;
        string s = "";

        public Preventive()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            phe_adult_note frm = new phe_adult_note();
            frm.ShowDialog();

            phe_adult_note_t.Text += phe_adult_note.str_phe_adult_note;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            chem_note frm = new chem_note();
            frm.ShowDialog();

            chem_note_t.Text += chem_note.str_chem_note;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            imm_adult_note frm = new imm_adult_note();
            frm.ShowDialog();

            imm_adult_note_t.Text += imm_adult_note.str_imm_adult_note;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            imm_child_note frm = new imm_child_note();
            frm.ShowDialog();

            imm_child_note_t.Text += imm_child_note.str_imm_child_note;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            screen_note frm = new screen_note();
            frm.ShowDialog();

            screen_note_t.Text += screen_note.str_screen_note;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            coun_note frm = new coun_note();
            frm.ShowDialog();

            coun_note_t.Text += coun_note.str_coun_note;

        }

     
        private void button22_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMI frm = new BMI();
                frm.Show();
            }
            else
                if (e.Button == MouseButtons.Right)
            {
                System.Diagnostics.Process.Start("Anthro.exe");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            phe_child_note frm = new phe_child_note();
            frm.ShowDialog();

            phe_child_note_t.Text += phe_child_note.str_phe_child_note;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            DrugStore frm = new DrugStore();
            frm.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Rx frm = new Rx();
            frm.Show();
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            chem_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct chem from preventive where chem<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                chem_c.Items.Insert(i, data["chem"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            imm_child_c.Items.Clear();
            imm_adult_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct imm_child from preventive where imm_child<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                imm_child_c.Items.Insert(i, data["imm_child"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct imm_adult from preventive where imm_adult<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                imm_adult_c.Items.Insert(i, data["imm_adult"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void Preventive_Load(object sender, EventArgs e)
        {
            record_pc = "";
            Int64 par = Patient.par;
 
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

            //if (par == 0)
            //{
            //    sqlconn.Close();
            //    return;
            //}

            string a1, a2, a3, a4;
            string ci1, ci2, ci3, ci4;
            string s;
            sqlcmd.CommandText = "select * from ppc where par = '"+ par +"' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                a1 = data["a1"].ToString();
                a2 = data["a2"].ToString();
                a3 = data["a3"].ToString();
                a4 = data["a4"].ToString();

                ci1 = data["c1"].ToString();
                ci2 = data["c2"].ToString();
                ci3 = data["c3"].ToString();
                ci4 = data["c4"].ToString();
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = a1.IndexOf("|");
                    s = a1.Substring(0,index);
                    foreach (Control c1 in tabPage14.Controls)
                    {
                        if (c1.Name == "a1t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    a1 = a1.Substring(index + 1, a1.Length - index - 1);
                } // End of for
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = a2.IndexOf("|");
                    s = a2.Substring(0, index);
                    foreach (Control c1 in tabPage15.Controls)
                    {
                        if (c1.Name == "a2t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    a2 = a2.Substring(index + 1, a2.Length - index - 1);
                } // End of for
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = a3.IndexOf("|");
                    s = a3.Substring(0, index);
                    foreach (Control c1 in tabPage16.Controls)
                    {
                        if (c1.Name == "a3t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    a3 = a3.Substring(index + 1, a3.Length - index - 1);
                } // End of for
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = a4.IndexOf("|");
                    s = a4.Substring(0, index);
                    foreach (Control c1 in tabPage17.Controls)
                    {
                        if (c1.Name == "a4t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    a4 = a4.Substring(index + 1, a4.Length - index - 1);
                } // End of for
                //////////////////////////////
                //////////////////////////////
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = ci1.IndexOf("|");
                    s = ci1.Substring(0, index);
                    foreach (Control c1 in tabPage10.Controls)
                    {
                        if (c1.Name == "c1t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    ci1 = ci1.Substring(index + 1, ci1.Length - index - 1);
                } // End of for
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = ci2.IndexOf("|");
                    s = ci2.Substring(0, index);
                    foreach (Control c1 in tabPage11.Controls)
                    {
                        if (c1.Name == "c2t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    ci2 = ci2.Substring(index + 1, ci2.Length - index - 1);
                } // End of for
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = ci3.IndexOf("|");
                    s = ci3.Substring(0, index);
                    foreach (Control c1 in tabPage12.Controls)
                    {
                        if (c1.Name == "c3t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    ci3 = ci3.Substring(index + 1, ci3.Length - index - 1);
                } // End of for
                //////////////////////////////
                for (int i = 1; i <= 60; i++)
                {
                    int index = ci4.IndexOf("|");
                    s = ci4.Substring(0, index);
                    foreach (Control c1 in tabPage13.Controls)
                    {
                        if (c1.Name == "c4t" + i.ToString())
                        {
                            c1.Text = s;
                        }
                    } // End of foreach
                    ci4 = ci4.Substring(index + 1, ci4.Length - index - 1);
                } // End of for
                //////////////////////////////

                phe_adult_board_t.Text = data["phe_adult_board"].ToString();
                phe_adult_note_t.Text = data["phe_adult_note"].ToString();
                phe_child_board_t.Text = data["phe_child_board"].ToString();
                phe_child_note_t.Text = data["phe_child_note"].ToString();

                if (data["ch1"].ToString() == "True")
                    ch1.Checked = true;
                else
                    ch1.Checked = false;

                if (data["ch2"].ToString() == "True")
                    ch2.Checked = true;
                else
                    ch2.Checked = false;

                if (data["ch3"].ToString() == "True")
                    ch3.Checked = true;
                else
                    ch3.Checked = false;

                if (data["ch4"].ToString() == "True")
                    ch4.Checked = true;
                else
                    ch4.Checked = false;

                if (data["ch5"].ToString() == "True")
                    ch5.Checked = true;
                else
                    ch5.Checked = false;

                if (data["ch6"].ToString() == "True")
                    ch6.Checked = true;
                else
                    ch6.Checked = false;

                if (data["ch7"].ToString() == "True")
                    ch7.Checked = true;
                else
                    ch7.Checked = false;

                if (data["ch8"].ToString() == "True")
                    ch8.Checked = true;
                else
                    ch8.Checked = false;

                if (data["ch9"].ToString() == "True")
                    ch9.Checked = true;
                else
                    ch9.Checked = false;

                coun_note_t.Text = data["coun_note"].ToString();
                screen_note_t.Text = data["screen_note"].ToString();
                imm_adult_board_t.Text = data["imm_adult_board"].ToString();
                imm_adult_note_t.Text = data["imm_adult_note"].ToString();
                imm_child_board_t.Text = data["imm_child_board"].ToString();
                imm_child_note_t.Text = data["imm_child_note"].ToString();
                chem_note_t.Text = data["chem_note"].ToString();



            }
            data.Close();


            sqlconn.Close();
        }

        private void Preventive_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");
            }

            //if (par == 0)
            //    return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(Bitmap Files)|*.bmp";
            dlg.InitialDirectory = Application.StartupPath + "\\Graph Template";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int i = dlg.FileName.LastIndexOf("\\");

                myfile = dlg.FileName.Substring(i + 1, dlg.FileName.Length - i - 1);

                if (File.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile) == true)
                {
                    if (MessageBox.Show("This file already exist, Do you want overwrite this file ?", "Overwrite", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
                        File.Copy(dlg.FileName, Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
                    }
                }
                else
                {
                    File.Copy(dlg.FileName, Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
                }

                System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
            }

           
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            string s = Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\Adults.xls";
            //if (par == 0)
            //    return;

            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph"))
            {
                if (File.Exists(s))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(s);
                    }
                    catch
                    {
                        MessageBox.Show("Please first install Microsoft Excel");
                    }
                }
                else
                {
                    if (File.Exists(Application.StartupPath + "\\Graph Template\\Adults.xls"))
                    {
                        File.Copy(Application.StartupPath + "\\Graph Template\\Adults.xls", s);
                        try
                        {
                            System.Diagnostics.Process.Start(s);
                        }
                        catch
                        {
                            MessageBox.Show("Please first install Microsoft Excel");
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");
                File.Copy(Application.StartupPath + "\\Graph Template\\Adults.xls", s);
                try
                {
                    System.Diagnostics.Process.Start(s);
                }
                catch
                {
                    MessageBox.Show("Please first install Microsoft Excel");
                }
            }
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            phe_adult_c.Items.Clear();
            phe_child_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct phe_child from preventive where phe_child<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                phe_child_c.Items.Insert(i, data["phe_child"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct phe_adult from preventive where phe_adult<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                phe_adult_c.Items.Insert(i, data["phe_adult"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            coun_contra_c.Items.Clear();
            coun_dental_c.Items.Clear();
            coun_diet_c.Items.Clear();
            coun_injury_c.Items.Clear();
            coun_life_c.Items.Clear();
            coun_sex_c.Items.Clear();
            coun_therapy_c.Items.Clear();
            coun_tobbacco_c.Items.Clear();
            coun_vitamin_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct coun_contra from preventive where coun_contra<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                coun_contra_c.Items.Insert(i, data["coun_contra"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_dental from preventive where coun_dental<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_dental_c.Items.Insert(i, data["coun_dental"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_diet from preventive where coun_diet<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_diet_c.Items.Insert(i, data["coun_diet"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_injury from preventive where coun_injury<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_injury_c.Items.Insert(i, data["coun_injury"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_life from preventive where coun_life<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_life_c.Items.Insert(i, data["coun_life"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_sex from preventive where coun_sex<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_sex_c.Items.Insert(i, data["coun_sex"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_therapy from preventive where coun_therapy<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_therapy_c.Items.Insert(i, data["coun_therapy"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_tobbacco from preventive where coun_tobbacco<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_tobbacco_c.Items.Insert(i, data["coun_tobbacco"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct coun_vitamin from preventive where coun_vitamin<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                coun_vitamin_c.Items.Insert(i, data["coun_vitamin"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            screen_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct screen from preventive where screen<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                screen_c.Items.Insert(i, data["screen"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void Preventive_FormClosing(object sender, FormClosingEventArgs e)
        {
            phe_adult_note_t.Text = phe_adult_note_t.Text.Replace("'", "''");
            phe_child_note_t.Text = phe_child_note_t.Text.Replace("'", "''");
            coun_note_t.Text = coun_note_t.Text.Replace("'", "''");
            screen_note_t.Text = screen_note_t.Text.Replace("'", "''");
            imm_adult_note_t.Text = imm_adult_note_t.Text.Replace("'", "''");
            imm_child_note_t.Text = imm_child_note_t.Text.Replace("'", "''");
            chem_note_t.Text = chem_note_t.Text.Replace("'", "''");

            Int64 par = Patient.par;

            //if (par == 0)
            //   return;

            string a1, a2, a3, a4;
            string c1, c2, c3, c4;
            a1 = a2 = a3 = a4 = "";
            c1 = c2 = c3 = c4 = "";

            a1 = a1t1.Text + "|" + a1t2.Text + "|" + a1t3.Text + "|" + a1t4.Text + "|" + a1t5.Text + "|" + a1t6.Text + "|" + a1t7.Text + "|" + a1t8.Text + "|";
            a1 += a1t9.Text + "|" + a1t10.Text + "|" + a1t11.Text + "|" + a1t12.Text + "|" + a1t13.Text + "|" + a1t14.Text + "|" + a1t15.Text + "|" + a1t16.Text + "|";
            a1 += a1t17.Text + "|" + a1t18.Text + "|" + a1t19.Text + "|" + a1t20.Text + "|" + a1t21.Text + "|" + a1t22.Text + "|" + a1t23.Text + "|" + a1t24.Text + "|";
            a1 += a1t25.Text + "|" + a1t26.Text + "|" + a1t27.Text + "|" + a1t28.Text + "|" + a1t29.Text + "|" + a1t30.Text + "|" + a1t31.Text + "|" + a1t32.Text + "|";
            a1 += a1t33.Text + "|" + a1t34.Text + "|" + a1t35.Text + "|" + a1t36.Text + "|" + a1t37.Text + "|" + a1t38.Text + "|" + a1t39.Text + "|" + a1t40.Text + "|";
            a1 += a1t41.Text + "|" + a1t42.Text + "|" + a1t43.Text + "|" + a1t44.Text + "|" + a1t45.Text + "|" + a1t46.Text + "|" + a1t47.Text + "|" + a1t48.Text + "|";
            a1 += a1t49.Text + "|" + a1t50.Text + "|" + a1t51.Text + "|" + a1t52.Text + "|" + a1t53.Text + "|" + a1t54.Text + "|" + a1t55.Text + "|" + a1t56.Text + "|";
            a1 += a1t57.Text + "|" + a1t58.Text + "|" + a1t59.Text + "|" + a1t60.Text + "|";

            a2 = a2t1.Text + "|" + a2t2.Text + "|" + a2t3.Text + "|" + a2t4.Text + "|" + a2t5.Text + "|" + a2t6.Text + "|" + a2t7.Text + "|" + a2t8.Text + "|";
            a2 += a2t9.Text + "|" + a2t10.Text + "|" + a2t11.Text + "|" + a2t12.Text + "|" + a2t13.Text + "|" + a2t14.Text + "|" + a2t15.Text + "|" + a2t16.Text + "|";
            a2 += a2t17.Text + "|" + a2t18.Text + "|" + a2t19.Text + "|" + a2t20.Text + "|" + a2t21.Text + "|" + a2t22.Text + "|" + a2t23.Text + "|" + a2t24.Text + "|";
            a2 += a2t25.Text + "|" + a2t26.Text + "|" + a2t27.Text + "|" + a2t28.Text + "|" + a2t29.Text + "|" + a2t30.Text + "|" + a2t31.Text + "|" + a2t32.Text + "|";
            a2 += a2t33.Text + "|" + a2t34.Text + "|" + a2t35.Text + "|" + a2t36.Text + "|" + a2t37.Text + "|" + a2t38.Text + "|" + a2t39.Text + "|" + a2t40.Text + "|";
            a2 += a2t41.Text + "|" + a2t42.Text + "|" + a2t43.Text + "|" + a2t44.Text + "|" + a2t45.Text + "|" + a2t46.Text + "|" + a2t47.Text + "|" + a2t48.Text + "|";
            a2 += a2t49.Text + "|" + a2t50.Text + "|" + a2t51.Text + "|" + a2t52.Text + "|" + a2t53.Text + "|" + a2t54.Text + "|" + a2t55.Text + "|" + a2t56.Text + "|";
            a2 += a2t57.Text + "|" + a2t58.Text + "|" + a2t59.Text + "|" + a2t60.Text + "|";

            a3 = a3t1.Text + "|" + a3t2.Text + "|" + a3t3.Text + "|" + a3t4.Text + "|" + a3t5.Text + "|" + a3t6.Text + "|" + a3t7.Text + "|" + a3t8.Text + "|";
            a3 += a3t9.Text + "|" + a3t10.Text + "|" + a3t11.Text + "|" + a3t12.Text + "|" + a3t13.Text + "|" + a3t14.Text + "|" + a3t15.Text + "|" + a3t16.Text + "|";
            a3 += a3t17.Text + "|" + a3t18.Text + "|" + a3t19.Text + "|" + a3t20.Text + "|" + a3t21.Text + "|" + a3t22.Text + "|" + a3t23.Text + "|" + a3t24.Text + "|";
            a3 += a3t25.Text + "|" + a3t26.Text + "|" + a3t27.Text + "|" + a3t28.Text + "|" + a3t29.Text + "|" + a3t30.Text + "|" + a3t31.Text + "|" + a3t32.Text + "|";
            a3 += a3t33.Text + "|" + a3t34.Text + "|" + a3t35.Text + "|" + a3t36.Text + "|" + a3t37.Text + "|" + a3t38.Text + "|" + a3t39.Text + "|" + a3t40.Text + "|";
            a3 += a3t41.Text + "|" + a3t42.Text + "|" + a3t43.Text + "|" + a3t44.Text + "|" + a3t45.Text + "|" + a3t46.Text + "|" + a3t47.Text + "|" + a3t48.Text + "|";
            a3 += a3t49.Text + "|" + a3t50.Text + "|" + a3t51.Text + "|" + a3t52.Text + "|" + a3t53.Text + "|" + a3t54.Text + "|" + a3t55.Text + "|" + a3t56.Text + "|";
            a3 += a3t57.Text + "|" + a3t58.Text + "|" + a3t59.Text + "|" + a3t60.Text + "|";

            a4 = a4t1.Text + "|" + a4t2.Text + "|" + a4t3.Text + "|" + a4t4.Text + "|" + a4t5.Text + "|" + a4t6.Text + "|" + a4t7.Text + "|" + a4t8.Text + "|";
            a4 += a4t9.Text + "|" + a4t10.Text + "|" + a4t11.Text + "|" + a4t12.Text + "|" + a4t13.Text + "|" + a4t14.Text + "|" + a4t15.Text + "|" + a4t16.Text + "|";
            a4 += a4t17.Text + "|" + a4t18.Text + "|" + a4t19.Text + "|" + a4t20.Text + "|" + a4t21.Text + "|" + a4t22.Text + "|" + a4t23.Text + "|" + a4t24.Text + "|";
            a4 += a4t25.Text + "|" + a4t26.Text + "|" + a4t27.Text + "|" + a4t28.Text + "|" + a4t29.Text + "|" + a4t30.Text + "|" + a4t31.Text + "|" + a4t32.Text + "|";
            a4 += a4t33.Text + "|" + a4t34.Text + "|" + a4t35.Text + "|" + a4t36.Text + "|" + a4t37.Text + "|" + a4t38.Text + "|" + a4t39.Text + "|" + a4t40.Text + "|";
            a4 += a4t41.Text + "|" + a4t42.Text + "|" + a4t43.Text + "|" + a4t44.Text + "|" + a4t45.Text + "|" + a4t46.Text + "|" + a4t47.Text + "|" + a4t48.Text + "|";
            a4 += a4t49.Text + "|" + a4t50.Text + "|" + a4t51.Text + "|" + a4t52.Text + "|" + a4t53.Text + "|" + a4t54.Text + "|" + a4t55.Text + "|" + a4t56.Text + "|";
            a4 += a4t57.Text + "|" + a4t58.Text + "|" + a4t59.Text + "|" + a4t60.Text + "|";

            // Child 
            c1 = c1t1.Text + "|" + c1t2.Text + "|" + c1t3.Text + "|" + c1t4.Text + "|" + c1t5.Text + "|" + c1t6.Text + "|" + c1t7.Text + "|" + c1t8.Text + "|";
            c1 += c1t9.Text + "|" + c1t10.Text + "|" + c1t11.Text + "|" + c1t12.Text + "|" + c1t13.Text + "|" + c1t14.Text + "|" + c1t15.Text + "|" + c1t16.Text + "|";
            c1 += c1t17.Text + "|" + c1t18.Text + "|" + c1t19.Text + "|" + c1t20.Text + "|" + c1t21.Text + "|" + c1t22.Text + "|" + c1t23.Text + "|" + c1t24.Text + "|";
            c1 += c1t25.Text + "|" + c1t26.Text + "|" + c1t27.Text + "|" + c1t28.Text + "|" + c1t29.Text + "|" + c1t30.Text + "|" + c1t31.Text + "|" + c1t32.Text + "|";
            c1 += c1t33.Text + "|" + c1t34.Text + "|" + c1t35.Text + "|" + c1t36.Text + "|" + c1t37.Text + "|" + c1t38.Text + "|" + c1t39.Text + "|" + c1t40.Text + "|";
            c1 += c1t41.Text + "|" + c1t42.Text + "|" + c1t43.Text + "|" + c1t44.Text + "|" + c1t45.Text + "|" + c1t46.Text + "|" + c1t47.Text + "|" + c1t48.Text + "|";
            c1 += c1t49.Text + "|" + c1t50.Text + "|" + c1t51.Text + "|" + c1t52.Text + "|" + c1t53.Text + "|" + c1t54.Text + "|" + c1t55.Text + "|" + c1t56.Text + "|";
            c1 += c1t57.Text + "|" + c1t58.Text + "|" + c1t59.Text + "|" + c1t60.Text + "|";

            c2 = c2t1.Text + "|" + c2t2.Text + "|" + c2t3.Text + "|" + c2t4.Text + "|" + c2t5.Text + "|" + c2t6.Text + "|" + c2t7.Text + "|" + c2t8.Text + "|";
            c2 += c2t9.Text + "|" + c2t10.Text + "|" + c2t11.Text + "|" + c2t12.Text + "|" + c2t13.Text + "|" + c2t14.Text + "|" + c2t15.Text + "|" + c2t16.Text + "|";
            c2 += c2t17.Text + "|" + c2t18.Text + "|" + c2t19.Text + "|" + c2t20.Text + "|" + c2t21.Text + "|" + c2t22.Text + "|" + c2t23.Text + "|" + c2t24.Text + "|";
            c2 += c2t25.Text + "|" + c2t26.Text + "|" + c2t27.Text + "|" + c2t28.Text + "|" + c2t29.Text + "|" + c2t30.Text + "|" + c2t31.Text + "|" + c2t32.Text + "|";
            c2 += c2t33.Text + "|" + c2t34.Text + "|" + c2t35.Text + "|" + c2t36.Text + "|" + c2t37.Text + "|" + c2t38.Text + "|" + c2t39.Text + "|" + c2t40.Text + "|";
            c2 += c2t41.Text + "|" + c2t42.Text + "|" + c2t43.Text + "|" + c2t44.Text + "|" + c2t45.Text + "|" + c2t46.Text + "|" + c2t47.Text + "|" + c2t48.Text + "|";
            c2 += c2t49.Text + "|" + c2t50.Text + "|" + c2t51.Text + "|" + c2t52.Text + "|" + c2t53.Text + "|" + c2t54.Text + "|" + c2t55.Text + "|" + c2t56.Text + "|";
            c2 += c2t57.Text + "|" + c2t58.Text + "|" + c2t59.Text + "|" + c2t60.Text + "|";

            c3 = c3t1.Text + "|" + c3t2.Text + "|" + c3t3.Text + "|" + c3t4.Text + "|" + c3t5.Text + "|" + c3t6.Text + "|" + c3t7.Text + "|" + c3t8.Text + "|";
            c3 += c3t9.Text + "|" + c3t10.Text + "|" + c3t11.Text + "|" + c3t12.Text + "|" + c3t13.Text + "|" + c3t14.Text + "|" + c3t15.Text + "|" + c3t16.Text + "|";
            c3 += c3t17.Text + "|" + c3t18.Text + "|" + c3t19.Text + "|" + c3t20.Text + "|" + c3t21.Text + "|" + c3t22.Text + "|" + c3t23.Text + "|" + c3t24.Text + "|";
            c3 += c3t25.Text + "|" + c3t26.Text + "|" + c3t27.Text + "|" + c3t28.Text + "|" + c3t29.Text + "|" + c3t30.Text + "|" + c3t31.Text + "|" + c3t32.Text + "|";
            c3 += c3t33.Text + "|" + c3t34.Text + "|" + c3t35.Text + "|" + c3t36.Text + "|" + c3t37.Text + "|" + c3t38.Text + "|" + c3t39.Text + "|" + c3t40.Text + "|";
            c3 += c3t41.Text + "|" + c3t42.Text + "|" + c3t43.Text + "|" + c3t44.Text + "|" + c3t45.Text + "|" + c3t46.Text + "|" + c3t47.Text + "|" + c3t48.Text + "|";
            c3 += c3t49.Text + "|" + c3t50.Text + "|" + c3t51.Text + "|" + c3t52.Text + "|" + c3t53.Text + "|" + c3t54.Text + "|" + c3t55.Text + "|" + c3t56.Text + "|";
            c3 += c3t57.Text + "|" + c3t58.Text + "|" + c3t59.Text + "|" + c3t60.Text + "|";

            c4 = c4t1.Text + "|" + c4t2.Text + "|" + c4t3.Text + "|" + c4t4.Text + "|" + c4t5.Text + "|" + c4t6.Text + "|" + c4t7.Text + "|" + c4t8.Text + "|";
            c4 += c4t9.Text + "|" + c4t10.Text + "|" + c4t11.Text + "|" + c4t12.Text + "|" + c4t13.Text + "|" + c4t14.Text + "|" + c4t15.Text + "|" + c4t16.Text + "|";
            c4 += c4t17.Text + "|" + c4t18.Text + "|" + c4t19.Text + "|" + c4t20.Text + "|" + c4t21.Text + "|" + c4t22.Text + "|" + c4t23.Text + "|" + c4t24.Text + "|";
            c4 += c4t25.Text + "|" + c4t26.Text + "|" + c4t27.Text + "|" + c4t28.Text + "|" + c4t29.Text + "|" + c4t30.Text + "|" + c4t31.Text + "|" + c4t32.Text + "|";
            c4 += c4t33.Text + "|" + c4t34.Text + "|" + c4t35.Text + "|" + c4t36.Text + "|" + c4t37.Text + "|" + c4t38.Text + "|" + c4t39.Text + "|" + c4t40.Text + "|";
            c4 += c4t41.Text + "|" + c4t42.Text + "|" + c4t43.Text + "|" + c4t44.Text + "|" + c4t45.Text + "|" + c4t46.Text + "|" + c4t47.Text + "|" + c4t48.Text + "|";
            c4 += c4t49.Text + "|" + c4t50.Text + "|" + c4t51.Text + "|" + c4t52.Text + "|" + c4t53.Text + "|" + c4t54.Text + "|" + c4t55.Text + "|" + c4t56.Text + "|";
            c4 += c4t57.Text + "|" + c4t58.Text + "|" + c4t59.Text + "|" + c4t60.Text + "|";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Delete From ppc where par = '"+ par +"' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Insert into ppc(par,phe_adult_board,phe_adult_note,phe_child_board,phe_child_note,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8,ch9,coun_note,screen_note,imm_adult_note,imm_adult_board,imm_child_note,imm_child_board,chem_note,a1,a2,a3,a4,c1,c2,c3,c4) values('" + par + "','" + phe_adult_board_t.Text + "','" + phe_adult_note_t.Text + "','" + phe_child_board_t.Text + "','" + phe_child_note_t.Text + "','" + ch1.Checked.ToString() + "','" + ch2.Checked.ToString() + "','" + ch3.Checked.ToString() + "','" + ch4.Checked.ToString() + "','" + ch5.Checked.ToString() + "','" + ch6.Checked.ToString() + "','" + ch7.Checked.ToString() + "','" + ch8.Checked.ToString() + "','" + ch9.Checked.ToString() + "','" + coun_note_t.Text + "','" + screen_note_t.Text + "','" + imm_adult_note_t.Text + "','" + imm_adult_board_t.Text + "','" + imm_child_note_t.Text + "','" + imm_child_board_t.Text + "','" + chem_note_t.Text + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + c1 + "','" + c2 + "','" + c3 + "','" + c4 + "') ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            string s = Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\Children.xls";
            //if (par == 0)
            //    return;

            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph"))
            {
                if (File.Exists(s))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(s);
                    }
                    catch
                    {
                        MessageBox.Show("Please first install Microsoft Excel");
                    }
                }
                else
                {
                    if (File.Exists(Application.StartupPath + "\\Graph Template\\Children.xls"))
                    {
                        File.Copy(Application.StartupPath + "\\Graph Template\\Children.xls", s);
                        try
                        {
                            System.Diagnostics.Process.Start(s);
                        }
                        catch
                        {
                            MessageBox.Show("Please first install Microsoft Excel");
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");
                File.Copy(Application.StartupPath + "\\Graph Template\\Children.xls", s);
                try
                {
                    System.Diagnostics.Process.Start(s);
                }
                catch
                {
                    MessageBox.Show("Please first install Microsoft Excel");
                }
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {

        }

        private void button57_Click(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            if (par == 0)
                return;

            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph") == false)
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");

            if (File.Exists("c:\\" + myfile))
            {
                File.Move("c:\\" + myfile, Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
            }
            
        }

        private void button58_Click(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");
            }

            //if (par == 0)
            //    return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(Bitmap Files)|*.bmp";
            dlg.InitialDirectory = Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(dlg.FileName);
            }


        }

        private void button59_Click(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");
            }

            //if (par == 0)
            //    return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(Bitmap Files)|*.bmp";
            dlg.InitialDirectory = Application.StartupPath + "\\Graph Template";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int i = dlg.FileName.LastIndexOf("\\");

                myfile = dlg.FileName.Substring(i + 1, dlg.FileName.Length - i - 1);

                if (File.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile) == true)
                {
                    if (MessageBox.Show("This file already exist, Do you want overwrite this file ?", "Overwrite", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
                        File.Copy(dlg.FileName, Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
                    }
                }
                else
                {
                    File.Copy(dlg.FileName, Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
                }

                System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph\\" + myfile);
            }
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            Int64 par = Patient.par;
            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph");
            }

            //if (par == 0)
            //    return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(Bitmap Files)|*.bmp";
            dlg.InitialDirectory = Application.StartupPath + "\\Patient Files\\" + par.ToString() + "\\Graph";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(dlg.FileName);
            }


        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = chem_c.Text;
            else
                record_pc = record_pc + "\n" + chem_c.Text;
        }

        private void button49_Click(object sender, EventArgs e)
        {
           
        }

        private void button39_Click(object sender, EventArgs e)
        {
           
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_adult_note_t.Text;
            else
                record_pc = record_pc + "\n" + imm_adult_note_t.Text;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_child_c.Text;
            else
                record_pc = record_pc + "\n" + imm_child_c.Text;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_child_note_t.Text;
            else
                record_pc = record_pc + "\n" + imm_child_note_t.Text;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = screen_c.Text;
            else
                record_pc = record_pc + "\n" + screen_c.Text;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = screen_note_t.Text;
            else
                record_pc = record_pc + "\n" + screen_note_t.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_dental_c.Text;
            else
                record_pc = record_pc + "\n" + coun_dental_c.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_injury_c.Text;
            else
                record_pc = record_pc + "\n" + coun_injury_c.Text;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_sex_c.Text;
            else
                record_pc = record_pc + "\n" + coun_sex_c.Text;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_tobbacco_c.Text;
            else
                record_pc = record_pc + "\n" + coun_tobbacco_c.Text;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_contra_c.Text;
            else
                record_pc = record_pc + "\n" + coun_contra_c.Text;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_diet_c.Text;
            else
                record_pc = record_pc + "\n" + coun_diet_c.Text;

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_vitamin_c.Text;
            else
                record_pc = record_pc + "\n" + coun_vitamin_c.Text;

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_life_c.Text;
            else
                record_pc = record_pc + "\n" + coun_life_c.Text;

        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_therapy_c.Text;
            else
                record_pc = record_pc + "\n" + coun_therapy_c.Text;

        }

        private void button37_Click(object sender, EventArgs e)
        {
            
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_child_c.Text;
            else
                record_pc = record_pc + "\n" + phe_child_c.Text;

        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_child_note_t.Text;
            else
                record_pc = record_pc + "\n" + phe_child_note_t.Text;

        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_adult_c.Text;
            else
                record_pc = record_pc + "\n" + phe_adult_c.Text;

        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_adult_note_t.Text;
            else
                record_pc = record_pc + "\n" + phe_adult_note_t.Text;

        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = chem_note_t.Text;
            else
                record_pc = record_pc + "\n" + chem_note_t.Text;
        }

        private void button55_Click_1(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_adult_c.Text;
            else
                record_pc = record_pc + "\n" + imm_adult_c.Text;
        }

        private void button39_Click_1(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_adult_note_t.Text;
            else
                record_pc = record_pc + "\n" + imm_adult_note_t.Text;
        }

        private void button40_Click_1(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_child_c.Text;
            else
                record_pc = record_pc + "\n" + imm_child_c.Text;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = imm_child_note_t.Text;
            else
                record_pc = record_pc + "\n" + imm_child_note_t.Text;
        }

        private void button73_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_child_c.Text;
            else
                record_pc = record_pc + "\n" + phe_child_c.Text;
        }

        private void button74_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_child_note_t.Text;
            else
                record_pc = record_pc + "\n" + phe_child_note_t.Text;

        }

        private void button71_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_adult_c.Text;
            else
                record_pc = record_pc + "\n" + phe_adult_c.Text;
        }

        private void button72_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = phe_adult_note_t.Text;
            else
                record_pc = record_pc + "\n" + phe_adult_note_t.Text;

        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_dental_c.Text;
            else
                record_pc = record_pc + "\n" + coun_dental_c.Text;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_injury_c.Text;
            else
                record_pc = record_pc + "\n" + coun_injury_c.Text;
        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_sex_c.Text;
            else
                record_pc = record_pc + "\n" + coun_sex_c.Text;
        }

        private void button64_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_tobbacco_c.Text;
            else
                record_pc = record_pc + "\n" + coun_tobbacco_c.Text;
        }

        private void button65_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_contra_c.Text;
            else
                record_pc = record_pc + "\n" + coun_contra_c.Text;
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_diet_c.Text;
            else
                record_pc = record_pc + "\n" + coun_diet_c.Text;
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_vitamin_c.Text;
            else
                record_pc = record_pc + "\n" + coun_vitamin_c.Text;
        }

        private void button68_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_life_c.Text;
            else
                record_pc = record_pc + "\n" + coun_life_c.Text;
        }

        private void button69_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_therapy_c.Text;
            else
                record_pc = record_pc + "\n" + coun_therapy_c.Text;
        }

        private void button70_Click(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = coun_note_t.Text;
            else
                record_pc = record_pc + "\n" + coun_note_t.Text;

        }

        private void button47_Click_1(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = screen_note_t.Text;
            else
                record_pc = record_pc + "\n" + screen_note_t.Text;
        }

        private void button48_Click_1(object sender, EventArgs e)
        {
            if (record_pc == "")
                record_pc = screen_c.Text;
            else
                record_pc = record_pc + "\n" + screen_c.Text;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_life_c.Text);
            }
            catch { }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_therapy_c.Text);
            }
            catch { }
        }

        private void button28_Click(object sender, EventArgs e)
        {
             try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_vitamin_c.Text);
            }
            catch { }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            
             try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_diet_c.Text);
            }
            catch { }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            
             try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_contra_c.Text);
            }
            catch { }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
              try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_tobbacco_c.Text);
            }
            catch { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
             try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_sex_c.Text);
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
              try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_injury_c.Text);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
             try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + coun_dental_c.Text);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Dental Care' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Dental Care' Program then Go to the Setting to configure it ", "Notification");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Accidents' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Fall and Accidents' Program then Go to the Setting to configure it ", "Notification");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Sexual' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Sexual Disease Preventions' Program then Go to the Setting to configure it ", "Notification");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Addiction' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Addiction counseling' Program then Go to the Setting to configure it ", "Notification");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Contraceptive method recommendations

            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Contraception' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Contraceptive methods' Program then Go to the Setting to configure it ", "Notification");
            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            // Vitamin supplement Rcc./Treat
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Supplements' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Vitamin supplement' Program then Go to the Setting to configure it ", "Notification");
            }



        }

        private void button30_Click(object sender, EventArgs e)
        {
            // Exercise / Change of life style recommendations
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Life Style' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'life style' Program then Go to the Setting to configure it ", "Notification");
            }


        }

        private void button34_Click(object sender, EventArgs e)
        {
            // Alternative therapy (Alternative medicine)

            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Alternative Th.' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Alternative therapy' Program then Go to the Setting to configure it ", "Notification");
            }


        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'SCREENING' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Screening' Program then Go to the Setting to configure it ", "Notification");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'CHEMOTHERAPY' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Chemotrapy' Program then Go to the Setting to configure it ", "Notification");
            }
        }

    }
}