using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Clinical_Management
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from temp where form='" + this.Name + "' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "select * from sw";
            data = sqlcmd.ExecuteReader();

            Int64 sw1timer, sw2timer, sw3timer;
            sw1timer = sw2timer = sw3timer = 5000;
            while (data.Read())
            {
                sw1timer = Int32.Parse(data["sw1timer"].ToString());
                sw2timer = Int32.Parse(data["sw2timer"].ToString());
                sw3timer = Int32.Parse(data["sw3timer"].ToString());
            }
            data.Close();

            sw1timer /= 1000;
            sw2timer /= 1000;
            sw3timer /= 1000;

            if (sw1timer <= 59)
            {
                second_r_sb1.Checked = true;
                second_n_sb1.Value = sw1timer;
            }
            else
            {
                sw1timer /= 60;

                if (sw1timer <= 59)
                {
                    minute_r_sb1.Checked = true;
                    minute_n_sb1.Value = sw1timer;
                }
                else
                {
                    sw1timer /= 60;
                    hour_r_sb1.Checked = true;
                    hour_n_sb1.Value = sw1timer;
                }
            }
            ////////
            if (sw2timer <= 59)
            {
                second_r_sb2.Checked = true;
                second_n_sb2.Value = sw2timer;
            }
            else
            {
                sw2timer /= 60;

                if (sw2timer <= 59)
                {
                    minute_r_sb2.Checked = true;
                    minute_n_sb2.Value = sw2timer;
                }
                else
                {
                    sw2timer /= 60;
                    hour_r_sb2.Checked = true;
                    hour_n_sb2.Value = sw2timer;
                }
            }
            /////////
            //if (sw3timer <= 59)
            //{
            //    second_r_sb3.Checked = true;
            //    second_n_sb3.Value = sw3timer;
            //}
            //else
            //{
            //    sw3timer /= 60;

            //    if (sw3timer <= 59)
            //    {
            //        minute_r_sb3.Checked = true;
            //        minute_n_sb3.Value = sw3timer;
            //    }
            //    else
            //    {
            //        sw3timer /= 60;
            //        hour_r_sb3.Checked = true;
            //        hour_n_sb3.Value = sw3timer;
            //    }
            //}





            //if (SW1.titlebar == 1)
            //    radioButton5.Checked = true;
            //else
            //    radioButton6.Checked = true;
            sqlconn.Close();

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SW1.titlebar = 1;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            SW1.titlebar = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB1\\Sound");
            }
            catch { }
        }

        private void hour_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb1.Enabled = true;
            minute_n_sb1.Enabled = false;
            second_n_sb1.Enabled = false;


        }

        private void minute_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb1.Enabled = false;
            minute_n_sb1.Enabled = true;
            second_n_sb1.Enabled = false;

        }

        private void second_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb1.Enabled = false;
            minute_n_sb1.Enabled = false;
            second_n_sb1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB1\\Photo");
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (hour_n_sb1.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + hour_n.Value * 3600000 + "')";
                sqlcmd.CommandText = "Update sw set sw1timer ='" + hour_n_sb1.Value * 3600000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            if (minute_n_sb1.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + minute_n.Value * 60000 + "')";
                sqlcmd.CommandText = "Update sw set sw1timer ='" + minute_n_sb1.Value * 60000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            if (second_n_sb1.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + second_n.Value * 1000 + "')";
                sqlcmd.CommandText = "Update sw set sw1timer ='" + second_n_sb1.Value * 1000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB2\\Photo");
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB3\\Sound");
            }
            catch { }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB3\\Photo");
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (hour_n_sb2.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + hour_n.Value * 3600000 + "')";
                sqlcmd.CommandText = "Update sw set sw2timer ='" + hour_n_sb2.Value * 3600000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            if (minute_n_sb2.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + minute_n.Value * 60000 + "')";
                sqlcmd.CommandText = "Update sw set sw2timer ='" + minute_n_sb2.Value * 60000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            if (second_n_sb2.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + second_n.Value * 1000 + "')";
                sqlcmd.CommandText = "Update sw set sw2timer ='" + second_n_sb2.Value * 1000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            //if (hide_p_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set paziresh = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set paziresh = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_b_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set search = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set search = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_t_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set tel = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set tel = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_a1_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set acc = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set acc = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_a2_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set acc2 = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set acc2 = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_a_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set all_info = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set all_info = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_n_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set nobat = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set nobat = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            //if (hide_r_r.Checked == true)
            //{
            //    sqlcmd.CommandText = "Update net set reminder = '0' ";
            //    sqlcmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    sqlcmd.CommandText = "Update net set reminder = '1' ";
            //    sqlcmd.ExecuteNonQuery();
            //}




            sqlconn.Close();
        }

        private void hour_r_sb2_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb2.Enabled = true;
            minute_n_sb2.Enabled = false;
            second_n_sb2.Enabled = false;
        }

        private void minute_r_sb2_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb2.Enabled = false;
            minute_n_sb2.Enabled = true;
            second_n_sb2.Enabled = false;
        }

        private void second_r_sb2_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb2.Enabled = false;
            minute_n_sb2.Enabled = false;
            second_n_sb2.Enabled = true;

        }

        private void tabPage18_Enter(object sender, EventArgs e)
        {
            chat_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct chat from consult where chat<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                chat_c.Items.Insert(i, data["chat"].ToString());
            }
            data.Close();

            sqlconn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string chat = "";

            chat = chat_c.Text;
            if (chat == "")
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse to find '" + chat + "' ";
            dlg.Filter = "Application Files(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update consult set chat_src = '" + dlg.FileName + "' where chat = '" + chat + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void tabPage21_Enter(object sender, EventArgs e)
        {
            p1_c.Items.Clear();
            p2_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct p1 from research where p1<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                p1_c.Items.Insert(i, data["p1"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct p2 from research where p2<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                p2_c.Items.Insert(i, data["p2"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void p1_b_Click(object sender, EventArgs e)
        {
            if (p1_c.Text == "")
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse to find '" + p1_c.Text + "' ";
            dlg.Filter = "Application Files(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update research set p1_src = '" + dlg.FileName + "' where p1 = '" + p1_c.Text + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void p2_b_Click(object sender, EventArgs e)
        {
            if (p2_c.Text == "")
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse to find '" + p2_c.Text + "' ";
            dlg.Filter = "Application Files(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update research set p2_src = '" + dlg.FileName + "' where p2 = '" + p2_c.Text + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (title_c.Text == "")
                return;

            int gender = 3, bar = 3, marray = 1, child = 1, job = 1, life = 1, busy = 1, tahsil = 1;

            //// gender //// 
            if (male_r.Checked == true)
            {
                gender = 1;
            }

            if (female_r.Checked == true)
            {
                gender = 2;
            }

            if (select_r.Checked == true)
            {
                gender = 3;
            }
            ////// bar ////////
            if (bar1_r.Checked == true)
            {
                bar = 1;
            }

            if (bar2_r.Checked == true)
            {
                bar = 2;
            }
            if (bar3_r.Checked == true)
            {
                bar = 3;
            }

            if (bar4_r.Checked == true)
            {
                bar = 4;
            }
            //// marray ///////
            if (marray1_r.Checked == true)
            {
                marray = 1;
            }

            if (marray2_r.Checked == true)
            {
                marray = 2;
            }
            //// child ///////
            if (child1_r.Checked == true)
            {
                child = 1;
            }

            if (child2_r.Checked == true)
            {
                child = 2;
            }
            //// job ///////
            if (job1_r.Checked == true)
            {
                job = 1;
            }

            if (job2_r.Checked == true)
            {
                job = 2;
            }
            //// life ///////
            if (life1_r.Checked == true)
            {
                life = 1;
            }

            if (life2_r.Checked == true)
            {
                life = 2;
            }
            //// busy ///////
            if (busy1_r.Checked == true)
            {
                busy = 1;
            }

            if (busy2_r.Checked == true)
            {
                busy = 2;
            }
            //// tahsil ///////
            if (tahsil1_r.Checked == true)
            {
                tahsil = 1;
            }

            if (tahsil2_r.Checked == true)
            {
                tahsil = 2;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete from set1 where title = '" + title_c.Text + "'", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into set1(title,gender,bar,marray,child,job,life,busy,tahsil) values('" + title_c.Text + "','" + gender.ToString() + "','" + bar.ToString() + "','" + marray.ToString() + "','" + child.ToString() + "','" + job.ToString() + "','" + life.ToString() + "','" + busy.ToString() + "','" + tahsil.ToString() + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void tabPage26_Enter(object sender, EventArgs e)
        {
            title_c.Items.Clear();
            marray_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct title from info where title<>''  ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                title_c.Items.Insert(i, data["title"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct marray from info where marray<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                marray_c.Items.Insert(i, data["marray"].ToString());
                i++;
            }
            data.Close();


            sqlconn.Close();
        }

        private void title_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from set1 where title = '" + title_c.Text + "' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                switch (data["gender"].ToString())
                {
                    case "1":
                        {
                            male_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            female_r.Checked = true;
                            break;
                        }
                    case "3":
                        {
                            select_r.Checked = true;
                            break;
                        }
                }

                switch (data["bar"].ToString())
                {
                    case "1":
                        {
                            bar1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            bar2_r.Checked = true;
                            break;
                        }
                    case "3":
                        {
                            bar3_r.Checked = true;
                            break;
                        }
                    case "4":
                        {
                            bar4_r.Checked = true;
                            break;
                        }
                }

                switch (data["marray"].ToString())
                {
                    case "1":
                        {
                            marray1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            marray2_r.Checked = true;
                            break;
                        }
                }

                switch (data["child"].ToString())
                {
                    case "1":
                        {
                            child1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            child2_r.Checked = true;
                            break;
                        }
                }

                switch (data["job"].ToString())
                {
                    case "1":
                        {
                            job1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            job2_r.Checked = true;
                            break;
                        }
                }

                switch (data["life"].ToString())
                {
                    case "1":
                        {
                            life1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            life2_r.Checked = true;
                            break;
                        }
                }

                switch (data["busy"].ToString())
                {
                    case "1":
                        {
                            busy1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            busy2_r.Checked = true;
                            break;
                        }
                }

                switch (data["tahsil"].ToString())
                {
                    case "1":
                        {
                            tahsil1_r.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            tahsil2_r.Checked = true;
                            break;
                        }
                }
            }
            data.Close();
            sqlconn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (marray_c.Text == "")
                return;

            int bar = 3, child = 1;
            ////// bar ////////
            if (bar1.Checked == true)
            {
                bar = 1;
            }

            if (bar2.Checked == true)
            {
                bar = 2;
            }
            if (bar3.Checked == true)
            {
                bar = 3;
            }

            if (bar4.Checked == true)
            {
                bar = 4;
            }
            //// child ///////
            if (child1.Checked == true)
            {
                child = 1;
            }

            if (child2.Checked == true)
            {
                child = 2;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete from set1 where title = '" + title_c.Text + "'", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into set2(marray,bar,child) values('" + marray_c.Text + "','" + bar.ToString() + "','" + child.ToString() + "') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void marray_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from set2 where marray = '" + marray_c.Text + "' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                switch (data["bar"].ToString())
                {
                    case "1":
                        {
                            bar1.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            bar2.Checked = true;
                            break;
                        }
                    case "3":
                        {
                            bar3.Checked = true;
                            break;
                        }
                    case "4":
                        {
                            bar4.Checked = true;
                            break;
                        }
                }

                switch (data["child"].ToString())
                {
                    case "1":
                        {
                            child1.Checked = true;
                            break;
                        }
                    case "2":
                        {
                            child2.Checked = true;
                            break;
                        }
                }

            }
            data.Close();
            sqlconn.Close();
        }

        private void tabPage25_Enter(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "select callerid from sw";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["callerid"].ToString()) == 0)
                    cid_u.Checked = true;
                else
                    cid_h.Checked = true;
            }
            data.Close();

            sqlcmd.CommandText = "select physician from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["physician"].ToString()) == 0)
                    ph_u.Checked = true;
                else
                    ph_h.Checked = true;
            }
            data.Close();

            sqlconn.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (cid_h.Checked == true)
            {
                sqlcmd.CommandText = "Update sw set callerid='" + 1 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            {
                sqlcmd.CommandText = "Update sw set callerid='" + 0 + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (ph_h.Checked == true)
            {
                sqlcmd.CommandText = "Update sw set physician='" + 1 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            {
                sqlcmd.CommandText = "Update sw set physician='" + 0 + "' ";
                sqlcmd.ExecuteNonQuery();
            }


            sqlconn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse to find Advanced Call Center... ";
            dlg.Filter = "Application Files(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update sw set acc = '" + dlg.FileName + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse to find Automated Answering Service... ";
            dlg.Filter = "Application Files(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update sw set answering = '" + dlg.FileName + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for photo...";
            dlg.Filter = "Picture files Files(*.jpg)|*.jpg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update sw set pj = '" + dlg.FileName + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void tabPage36_Enter(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            if (login.log_username != "admin")
            {
                dataGridView1.Visible = false;
                button16.Visible = false;
                panel13.Visible = true;

                sqlcmd.CommandText = "select * from doctor where username = '" + login.log_username + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    user_t.Text = data["username"].ToString();
                    pass10_t.Text = cm.MyDecoding(data["pass"].ToString());
                    pass20_t.Text = pass10_t.Text;
                }
                data.Close();


            }

            dataGridView1.Rows.Clear();


            sqlcmd.CommandText = "select * from doctor ";
            data = sqlcmd.ExecuteReader();

            object[] ob = new object[6];
            while (data.Read())
            {
                ob[0] = "تغيير مشخصات";
                ob[1] = "حذف";
                ob[2] = data["name"].ToString();
                ob[3] = data["family"].ToString();
                ob[4] = data["prf"].ToString();
                ob[5] = data["username"].ToString();

                dataGridView1.Rows.Add(ob);
            }
            data.Close();

            sqlconn.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            doctor2.doctor_ins_mode = true;

            doctor2 frm = new doctor2();
            frm.ShowDialog();

            tabPage36_Enter(sender, e);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (e.ColumnIndex == 0)
                {
                    doctor2.doctor_username = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    doctor2 frm = new doctor2();
                    frm.ShowDialog();

                    tabPage36_Enter(sender, e);
                }
                else
                    if (e.ColumnIndex == 1)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "admin")
                        {
                            MessageBox.Show("Administrator can not be omitted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (MessageBox.Show("Are you sure you want to delete the selected physician ?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;
                            sqlcmd.CommandText = "Delete from doctor where username = '" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + "' ";
                            sqlcmd.ExecuteNonQuery();
                            sqlconn.Close();

                            tabPage36_Enter(sender, e);
                        }
                    }
            }
        }

        private void tabPage36_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (pass10_t.Text == "")
            {
                MessageBox.Show("Please, Complete password field", "Notification");
                return;
            }

            if (pass10_t.Text.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters", "Notification");
                return;
            }

            if (pass10_t.Text != pass20_t.Text)
            {
                MessageBox.Show("The passwords do not match", "Notification");
                return;
            }

            string mypass = cm.MyEncoding(pass10_t.Text);

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "Update doctor set pass= '" + mypass + "' where username = '" + user_t.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            MessageBox.Show("The password has been set");

            sqlconn.Close();
        }

        private void tabPage13_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage13_Leave(object sender, EventArgs e)
        {


        }

        private void button19_Click(object sender, EventArgs e)
        {
            //printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage); 
            //printDialog1.ShowDialog();
            //pageSetupDialog1.PageSettings.Paper
            if (pageSetupDialog1.PageSettings.PaperSize.Kind != PaperKind.A5)
                pageSetupDialog1.ShowDialog();

            printPreviewDialog1.ShowDialog();


            //printDocument1.Print();
        }
        /////////////////////////////////////////////////
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // e.PageSettings.Landscape = true;
            //Font ff = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            //Font ff2 = new Font("Arial", 14, System.Drawing.FontStyle.Bold);
            //Font ff3 = new Font("Mistral", 12);

            //            StringFormat fo = new StringFormat();
            //fo.Alignment = StringAlignment.Far;
            //          fo.LineAlignment = StringAlignment.Far;
            //e.Graphics.DrawString("sfd",ff,dsf,10,10,


            // Print Logo
            if (logo_ch.Checked == true)
            {
                try
                {
                    e.Graphics.DrawImageUnscaled(Image.FromFile(Application.StartupPath + "\\10.gif"), 60, 60);
                }
                catch { }
            }
            //


            /////////////////// Print Header
            if (hb1.Checked == true)
                e.Graphics.DrawString(hl1.Text, new Font(font1_c.Text, float.Parse(hsize1.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(hx1.Value.ToString()), Int32.Parse(hy1.Value.ToString()));
            else
                e.Graphics.DrawString(hl1.Text, new Font(font1_c.Text, float.Parse(hsize1.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(hx1.Value.ToString()), Int32.Parse(hy1.Value.ToString()));

            if (hb2.Checked == true)
                e.Graphics.DrawString(hl2.Text, new Font(font2_c.Text, float.Parse(hsize2.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Navy, Int32.Parse(hx2.Value.ToString()), Int32.Parse(hy2.Value.ToString()));
            else
                e.Graphics.DrawString(hl2.Text, new Font(font2_c.Text, float.Parse(hsize2.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Navy, Int32.Parse(hx2.Value.ToString()), Int32.Parse(hy2.Value.ToString()));

            if (hb3.Checked == true)
                e.Graphics.DrawString(hl3.Text, new Font("Arial", float.Parse(hsize3.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(hx3.Value.ToString()), Int32.Parse(hy3.Value.ToString()));
            else
                e.Graphics.DrawString(hl3.Text, new Font("Arial", float.Parse(hsize3.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(hx3.Value.ToString()), Int32.Parse(hy3.Value.ToString()));

            if (hb4.Checked == true)
                e.Graphics.DrawString(hl4.Text, new Font("Arial", float.Parse(hsize4.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Navy, Int32.Parse(hx4.Value.ToString()), Int32.Parse(hy4.Value.ToString()));
            else
                e.Graphics.DrawString(hl4.Text, new Font("Arial", float.Parse(hsize4.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Navy, Int32.Parse(hx4.Value.ToString()), Int32.Parse(hy4.Value.ToString()));

            if (hb5.Checked == true)
                e.Graphics.DrawString(hl5.Text, new Font(font3_c.Text, float.Parse(hsize5.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(hx5.Value.ToString()), Int32.Parse(hy5.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl5.Text, new Font(font3_c.Text, float.Parse(hsize5.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(hx5.Value.ToString()), Int32.Parse(hy5.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (hb6.Checked == true)
                e.Graphics.DrawString(hl6.Text, new Font(font4_c.Text, float.Parse(hsize6.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Navy, Int32.Parse(hx6.Value.ToString()), Int32.Parse(hy6.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl6.Text, new Font(font4_c.Text, float.Parse(hsize6.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Navy, Int32.Parse(hx6.Value.ToString()), Int32.Parse(hy6.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (hb7.Checked == true)
                e.Graphics.DrawString(hl7.Text, new Font("Arial", float.Parse(hsize7.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.MediumBlue, Int32.Parse(hx7.Value.ToString()), Int32.Parse(hy7.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl7.Text, new Font("Arial", float.Parse(hsize7.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.MediumBlue, Int32.Parse(hx7.Value.ToString()), Int32.Parse(hy7.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (hb8.Checked == true)
                e.Graphics.DrawString(hl8.Text, new Font("Arial", float.Parse(hsize8.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Blue, Int32.Parse(hx8.Value.ToString()), Int32.Parse(hy8.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl8.Text, new Font("Arial", float.Parse(hsize8.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Blue, Int32.Parse(hx8.Value.ToString()), Int32.Parse(hy8.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            /////////////////////// End of Print Header

            //////////////////////////// Print Body
            if (b1_ch.Checked == true)
                e.Graphics.DrawString(l1.Text, new Font("Arial", float.Parse(size1.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x1.Value.ToString()), Int32.Parse(y1.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l1.Text, new Font("Arial", float.Parse(size1.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x1.Value.ToString()), Int32.Parse(y1.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b2_ch.Checked == true)
                e.Graphics.DrawString(l2.Text, new Font("Arial", float.Parse(size2.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x2.Value.ToString()), Int32.Parse(y2.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l2.Text, new Font("Arial", float.Parse(size2.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x2.Value.ToString()), Int32.Parse(y2.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b3_ch.Checked == true)
                e.Graphics.DrawString(l3.Text, new Font("Arial", float.Parse(size3.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x3.Value.ToString()), Int32.Parse(y3.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l3.Text, new Font("Arial", float.Parse(size3.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x3.Value.ToString()), Int32.Parse(y3.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b4_ch.Checked == true)
                e.Graphics.DrawString(l4.Text, new Font("Arial", float.Parse(size4.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x4.Value.ToString()), Int32.Parse(y4.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l4.Text, new Font("Arial", float.Parse(size4.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x4.Value.ToString()), Int32.Parse(y4.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b5_ch.Checked == true)
                e.Graphics.DrawString(l5.Text, new Font("Arial", float.Parse(size5.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x5.Value.ToString()), Int32.Parse(y5.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l5.Text, new Font("Arial", float.Parse(size5.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x5.Value.ToString()), Int32.Parse(y5.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b6_ch.Checked == true)
                e.Graphics.DrawString(l6.Text, new Font("Arial", float.Parse(size6.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x6.Value.ToString()), Int32.Parse(y6.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l6.Text, new Font("Arial", float.Parse(size6.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x6.Value.ToString()), Int32.Parse(y6.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b7_ch.Checked == true)
                e.Graphics.DrawString(l7.Text, new Font("Arial", float.Parse(size7.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x7.Value.ToString()), Int32.Parse(y7.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l7.Text, new Font("Arial", float.Parse(size7.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x7.Value.ToString()), Int32.Parse(y7.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b8_ch.Checked == true)
                e.Graphics.DrawString(l8.Text, new Font("Arial", float.Parse(size8.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x8.Value.ToString()), Int32.Parse(y8.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l8.Text, new Font("Arial", float.Parse(size8.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x8.Value.ToString()), Int32.Parse(y8.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b9_ch.Checked == true)
                e.Graphics.DrawString(l9.Text, new Font("Arial", float.Parse(size9.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x9.Value.ToString()), Int32.Parse(y9.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l9.Text, new Font("Arial", float.Parse(size9.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x9.Value.ToString()), Int32.Parse(y9.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b10_ch.Checked == true)
                e.Graphics.DrawString(l10.Text, new Font("Arial", float.Parse(size10.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x10.Value.ToString()), Int32.Parse(y10.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l10.Text, new Font("Arial", float.Parse(size10.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x10.Value.ToString()), Int32.Parse(y10.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b11_ch.Checked == true)
                e.Graphics.DrawString(l11.Text, new Font("Arial", float.Parse(size11.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x11.Value.ToString()), Int32.Parse(y11.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l11.Text, new Font("Arial", float.Parse(size11.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x11.Value.ToString()), Int32.Parse(y11.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b12_ch.Checked == true)
                e.Graphics.DrawString(l12.Text, new Font("Arial", float.Parse(size12.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x12.Value.ToString()), Int32.Parse(y12.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l12.Text, new Font("Arial", float.Parse(size12.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(x12.Value.ToString()), Int32.Parse(y12.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            ////////////////////////// End of Print Body

            //////////// Print Address
            if (adr_b.Checked == true)
                e.Graphics.DrawString(adr_t.Text, new Font("Arial", float.Parse(adr_size.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(adr_x.Value.ToString()), Int32.Parse(adr_y.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(adr_t.Text, new Font("Arial", float.Parse(adr_size.Value.ToString()), System.Drawing.FontStyle.Regular), Brushes.Black, Int32.Parse(adr_x.Value.ToString()), Int32.Parse(adr_y.Value.ToString()), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            ///////// End of Print Address
            // e.Graphics.DrawString("df",new Font("Arial",FontStyle.Bold,Brushes.Black),new PointF(10,20),new StringFormat(StringFormatFlags.DirectionRightToLeft),1);



            //  e.Graphics.DrawString("گواهي مي شود", ff2, Brushes.Black, 370, 60);
            //e.Graphics.DrawString("مبلغ " + textBox1.Text + "  تومان", ff2, Brushes.Black, 450, 260, fo);
            // e.Graphics.DrawString("از", ff2, Brushes.Black, 370, 60);
            // e.Graphics.DrawString(s, ff, Brushes.Black, 0, 0);
            //e.Graphics.DrawString("Salaam", ff2, Brushes.Blue, 500, 100);

            //pp.Color = System.Drawing.Color.Aqua;

            //"Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //e.Graphics.DrawImage(

            // e.PageSettings.Landscape = true;
            //PaperKind.A5

            //MessageBox.Show(e.PageSettings.PaperSize.Kind.ToString());

            //e.PageSettings.PaperSize.Kind.ToString() = PaperKind.A5;

        }

        private void p_adr_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Update print_t set hx5 = '" + Int32.Parse(hx5.Value.ToString()) + "',hx6 = '" + Int32.Parse(hx6.Value.ToString()) + "',hx7 = '" + Int32.Parse(hx7.Value.ToString()) + "',hx8 = '" + Int32.Parse(hx8.Value.ToString()) + "',hx1 = '" + Int32.Parse(hx1.Value.ToString()) + "',hx2 = '" + Int32.Parse(hx2.Value.ToString()) + "',hx3 = '" + Int32.Parse(hx3.Value.ToString()) + "',hx4 = '" + Int32.Parse(hx4.Value.ToString()) + "',adr_x = '" + Int32.Parse(adr_x.Value.ToString()) + "',adr_y = '" + Int32.Parse(adr_y.Value.ToString()) + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set hy5 = '" + Int32.Parse(hy5.Value.ToString()) + "',hy6 = '" + Int32.Parse(hy6.Value.ToString()) + "',hy7 = '" + Int32.Parse(hy7.Value.ToString()) + "',hy8 = '" + Int32.Parse(hy8.Value.ToString()) + "',hy1 = '" + Int32.Parse(hy1.Value.ToString()) + "',hy2 = '" + Int32.Parse(hy2.Value.ToString()) + "',hy3 = '" + Int32.Parse(hy3.Value.ToString()) + "',hy4 = '" + Int32.Parse(hy4.Value.ToString()) + "',adr_s = '" + Int32.Parse(adr_size.Value.ToString()) + "',adr_t = '" + adr_t.Text + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set hl5 = '" + hl5.Text + "',hl6 = '" + hl6.Text + "',hl7 = '" + hl7.Text + "',hl8 = '" + hl8.Text + "',hl1 = '" + hl1.Text + "',hl2 = '" + hl2.Text + "',hl3 = '" + hl3.Text + "',hl4 = '" + hl4.Text + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set hs5 = '" + hsize5.Value + "',hs6 = '" + hsize6.Value + "',hs7 = '" + hsize7.Value + "',hs8 = '" + hsize8.Value + "',hs1 = '" + hsize1.Value + "',hs2 = '" + hsize2.Value + "',hs3 = '" + hsize3.Value + "',hs4 = '" + hsize4.Value + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set hb5 = '" + hb5.Checked.ToString() + "',hb6 = '" + hb6.Checked.ToString() + "',hb7 = '" + hb7.Checked.ToString() + "',hb8 = '" + hb8.Checked.ToString() + "',hb1 = '" + hb1.Checked.ToString() + "',hb2 = '" + hb2.Checked.ToString() + "',hb3 = '" + hb3.Checked.ToString() + "',hb4 = '" + hb4.Checked.ToString() + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set l1 = '" + l1.Text + "',l2 = '" + l2.Text + "',l3 = '" + l3.Text + "',l4 = '" + l4.Text + "',l5 = '" + l5.Text + "',l6 = '" + l6.Text + "',l7 = '" + l7.Text + "',l8 = '" + l8.Text + "',l9 = '" + l9.Text + "',l10 = '" + l10.Text + "',l11 = '" + l11.Text + "',l12 = '" + l12.Text + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set x1 = '" + x1.Value + "',x2 = '" + x2.Value + "',x3 = '" + x3.Value + "',x4 = '" + x4.Value + "',x5 = '" + x5.Value + "',x6 = '" + x6.Value + "',x7 = '" + x7.Value + "',x8 = '" + x8.Value + "',x9 = '" + x9.Value + "',x10 = '" + x10.Value + "',x11 = '" + x11.Value + "',x12 = '" + x12.Value + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set y1 = '" + y1.Value + "',y2 = '" + y2.Value + "',y3 = '" + y3.Value + "',y4 = '" + y4.Value + "',y5 = '" + y5.Value + "',y6 = '" + y6.Value + "',y7 = '" + y7.Value + "',y8 = '" + y8.Value + "',y9 = '" + y9.Value + "',y10 = '" + y10.Value + "',y11 = '" + y11.Value + "',y12 = '" + y12.Value + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set s1 = '" + size1.Value + "',s2 = '" + size2.Value + "',s3 = '" + size3.Value + "',s4 = '" + size4.Value + "',s5 = '" + size5.Value + "',s6 = '" + size6.Value + "',s7 = '" + size7.Value + "',s8 = '" + size8.Value + "',s9 = '" + size9.Value + "',s10 = '" + size10.Value + "',s11 = '" + size11.Value + "',s12 = '" + size12.Value + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Update print_t set b1 = '" + b1_ch.Checked.ToString() + "',b2 = '" + b2_ch.Checked.ToString() + "',b3 = '" + b3_ch.Checked.ToString() + "',b4 = '" + b4_ch.Checked.ToString() + "',b5 = '" + b5_ch.Checked.ToString() + "',b6 = '" + b6_ch.Checked.ToString() + "',b7 = '" + b7_ch.Checked.ToString() + "',b8 = '" + b8_ch.Checked.ToString() + "',b9 = '" + b9_ch.Checked.ToString() + "',b10 = '" + b10_ch.Checked.ToString() + "',b11 = '" + b11_ch.Checked.ToString() + "',b12 = '" + b12_ch.Checked.ToString() + "',adr_b = '" + adr_b.Checked.ToString() + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            int i;
            if (logo_ch.Checked == true)
                i = 1;
            else
                i = 0;

            sqlcmd.CommandText = "Update print_t set font1 = '" + font1_c.Text + "',font2 = '" + font2_c.Text + "',font3 = '" + font3_c.Text + "',font4 = '" + font4_c.Text + "',logo = '" + i + "' where template = '" + template_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();
        }

        private void tabPage42_Enter(object sender, EventArgs e)
        {
            template_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Select distinct template from print_t where template<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                template_c.Items.Add(data["template"].ToString());
            }
            data.Close();

            //font1_c.SelectedIndex = 0;
            //font2_c.SelectedIndex = 0;
            //font3_c.SelectedIndex = 0;
            //font4_c.SelectedIndex = 0;

            sqlconn.Close();
        }

        private void template_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Select * from print_t where template = '" + template_c.Text + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                // Read Font And Logo
                if (Int32.Parse(data["logo"].ToString()) == 1)
                    logo_ch.Checked = true;
                else
                    logo_ch.Checked = false;

                font1_c.Text = data["font1"].ToString();
                font2_c.Text = data["font2"].ToString();
                font3_c.Text = data["font3"].ToString();
                font4_c.Text = data["font4"].ToString();
                //End of Read Font And Logo


                // Read Header
                hl1.Text = data["hl1"].ToString();
                hl2.Text = data["hl2"].ToString();
                hl3.Text = data["hl3"].ToString();
                hl4.Text = data["hl4"].ToString();
                hl5.Text = data["hl5"].ToString();
                hl6.Text = data["hl6"].ToString();
                hl7.Text = data["hl7"].ToString();
                hl8.Text = data["hl8"].ToString();

                try
                {
                    hx1.Value = Int32.Parse(data["hx1"].ToString());
                    hx2.Value = Int32.Parse(data["hx2"].ToString());
                    hx3.Value = Int32.Parse(data["hx3"].ToString());
                    hx4.Value = Int32.Parse(data["hx4"].ToString());
                    hx5.Value = Int32.Parse(data["hx5"].ToString());
                    hx6.Value = Int32.Parse(data["hx6"].ToString());
                    hx7.Value = Int32.Parse(data["hx7"].ToString());
                    hx8.Value = Int32.Parse(data["hx8"].ToString());

                    hy1.Value = Int32.Parse(data["hy1"].ToString());
                    hy2.Value = Int32.Parse(data["hy2"].ToString());
                    hy3.Value = Int32.Parse(data["hy3"].ToString());
                    hy4.Value = Int32.Parse(data["hy4"].ToString());
                    hy5.Value = Int32.Parse(data["hy5"].ToString());
                    hy6.Value = Int32.Parse(data["hy6"].ToString());
                    hy7.Value = Int32.Parse(data["hy7"].ToString());
                    hy8.Value = Int32.Parse(data["hy8"].ToString());

                    hsize1.Value = Int32.Parse(data["hs1"].ToString());
                    hsize2.Value = Int32.Parse(data["hs2"].ToString());
                    hsize3.Value = Int32.Parse(data["hs3"].ToString());
                    hsize4.Value = Int32.Parse(data["hs4"].ToString());
                    hsize5.Value = Int32.Parse(data["hs5"].ToString());
                    hsize6.Value = Int32.Parse(data["hs6"].ToString());
                    hsize7.Value = Int32.Parse(data["hs7"].ToString());
                    hsize8.Value = Int32.Parse(data["hs8"].ToString());
                }
                catch { }
                if (data["hb1"].ToString() == "True")
                    hb1.Checked = true;
                else
                    hb1.Checked = false;

                if (data["hb2"].ToString() == "True")
                    hb2.Checked = true;
                else
                    hb2.Checked = false;

                if (data["hb3"].ToString() == "True")
                    hb3.Checked = true;
                else
                    hb3.Checked = false;

                if (data["hb4"].ToString() == "True")
                    hb4.Checked = true;
                else
                    hb4.Checked = false;

                if (data["hb5"].ToString() == "True")
                    hb5.Checked = true;
                else
                    hb5.Checked = false;

                if (data["hb6"].ToString() == "True")
                    hb6.Checked = true;
                else
                    hb6.Checked = false;

                if (data["hb7"].ToString() == "True")
                    hb7.Checked = true;
                else
                    hb7.Checked = false;

                if (data["hb8"].ToString() == "True")
                    hb8.Checked = true;
                else
                    hb8.Checked = false;
                // End of Read Header

                // Read Body
                l1.Text = data["l1"].ToString();
                l2.Text = data["l2"].ToString();
                l3.Text = data["l3"].ToString();
                l4.Text = data["l4"].ToString();
                l5.Text = data["l5"].ToString();
                l6.Text = data["l6"].ToString();
                l7.Text = data["l7"].ToString();
                l8.Text = data["l8"].ToString();
                l9.Text = data["l9"].ToString();
                l10.Text = data["l10"].ToString();
                l11.Text = data["l11"].ToString();
                l12.Text = data["l12"].ToString();

                try
                {
                    x1.Value = Int32.Parse(data["x1"].ToString());
                    x2.Value = Int32.Parse(data["x2"].ToString());
                    x3.Value = Int32.Parse(data["x3"].ToString());
                    x4.Value = Int32.Parse(data["x4"].ToString());
                    x5.Value = Int32.Parse(data["x5"].ToString());
                    x6.Value = Int32.Parse(data["x6"].ToString());
                    x7.Value = Int32.Parse(data["x7"].ToString());
                    x8.Value = Int32.Parse(data["x8"].ToString());
                    x9.Value = Int32.Parse(data["x9"].ToString());
                    x10.Value = Int32.Parse(data["x10"].ToString());
                    x11.Value = Int32.Parse(data["x11"].ToString());
                    x12.Value = Int32.Parse(data["x12"].ToString());

                    y1.Value = Int32.Parse(data["y1"].ToString());
                    y2.Value = Int32.Parse(data["y2"].ToString());
                    y3.Value = Int32.Parse(data["y3"].ToString());
                    y4.Value = Int32.Parse(data["y4"].ToString());
                    y5.Value = Int32.Parse(data["y5"].ToString());
                    y6.Value = Int32.Parse(data["y6"].ToString());
                    y7.Value = Int32.Parse(data["y7"].ToString());
                    y8.Value = Int32.Parse(data["y8"].ToString());
                    y9.Value = Int32.Parse(data["y9"].ToString());
                    y10.Value = Int32.Parse(data["y10"].ToString());
                    y11.Value = Int32.Parse(data["y11"].ToString());
                    y12.Value = Int32.Parse(data["y12"].ToString());

                    size1.Value = Int32.Parse(data["s1"].ToString());
                    size2.Value = Int32.Parse(data["s2"].ToString());
                    size3.Value = Int32.Parse(data["s3"].ToString());
                    size4.Value = Int32.Parse(data["s4"].ToString());
                    size5.Value = Int32.Parse(data["s5"].ToString());
                    size6.Value = Int32.Parse(data["s6"].ToString());
                    size7.Value = Int32.Parse(data["s7"].ToString());
                    size8.Value = Int32.Parse(data["s8"].ToString());
                    size9.Value = Int32.Parse(data["s9"].ToString());
                    size10.Value = Int32.Parse(data["s10"].ToString());
                    size11.Value = Int32.Parse(data["s11"].ToString());
                    size12.Value = Int32.Parse(data["s12"].ToString());
                }
                catch { }

                if (data["b1"].ToString() == "True")
                    b1_ch.Checked = true;
                else
                    b1_ch.Checked = false;

                if (data["b2"].ToString() == "True")
                    b2_ch.Checked = true;
                else
                    b2_ch.Checked = false;

                if (data["b3"].ToString() == "True")
                    b3_ch.Checked = true;
                else
                    b3_ch.Checked = false;

                if (data["b4"].ToString() == "True")
                    b4_ch.Checked = true;
                else
                    b4_ch.Checked = false;

                if (data["b5"].ToString() == "True")
                    b5_ch.Checked = true;
                else
                    b5_ch.Checked = false;

                if (data["b6"].ToString() == "True")
                    b6_ch.Checked = true;
                else
                    b6_ch.Checked = false;

                if (data["b7"].ToString() == "True")
                    b7_ch.Checked = true;
                else
                    b7_ch.Checked = false;

                if (data["b8"].ToString() == "True")
                    b8_ch.Checked = true;
                else
                    b8_ch.Checked = false;

                if (data["b9"].ToString() == "True")
                    b9_ch.Checked = true;
                else
                    b9_ch.Checked = false;

                if (data["b10"].ToString() == "True")
                    b10_ch.Checked = true;
                else
                    b10_ch.Checked = false;

                if (data["b11"].ToString() == "True")
                    b11_ch.Checked = true;
                else
                    b11_ch.Checked = false;

                if (data["b12"].ToString() == "True")
                    b12_ch.Checked = true;
                else
                    b12_ch.Checked = false;

                // End of Read Body

                // Read Address
                adr_t.Text = data["adr_t"].ToString();
                try
                {
                    adr_y.Value = Int32.Parse(data["adr_y"].ToString());
                    adr_x.Value = Int32.Parse(data["adr_x"].ToString());
                    adr_size.Value = Int32.Parse(data["adr_s"].ToString());
                }
                catch { }

                if (data["adr_b"].ToString() == "True")
                    adr_b.Checked = true;
                else
                    adr_b.Checked = false;

                // End of Read Address
            }
            data.Close();

            sqlconn.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (template_t.Text == "")
                MessageBox.Show("Please enter template name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;

                int i;
                if (logo_ch.Checked == true)
                    i = 1;
                else
                    i = 0;

                sqlcmd.CommandText = "Insert into print_t(template,hl1,hl2,hl3,hl4,hl5,hl6,hl7,hl8,hx1,hx2,hx3,hx4,hx5,hx6,hx7,hx8,hy1,hy2,hy3,hy4,hy5,hy6,hy7,hy8,hs1,hs2,hs3,hs4,hs5,hs6,hs7,hs8,hb1,hb2,hb3,hb4,hb5,hb6,hb7,hb8,l1,l2,l3,l4,l5,l6,l7,l8,l9,l10,l11,l12,x1,x2,x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,y1,y2,y3,y4,y5,y6,y7,y8,y9,y10,y11,y12,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b11,b12,adr_t,adr_x,adr_y,adr_s,adr_b,font1,font2,font3,font4,logo) values('" + template_t.Text + "','" + hl1.Text + "','" + hl2.Text + "','" + hl3.Text + "','" + hl4.Text + "','" + hl5.Text + "','" + hl6.Text + "','" + hl7.Text + "','" + hl8.Text + "','" + hx1.Value + "','" + hx2.Value + "','" + hx3.Value + "','" + hx4.Value + "','" + hx5.Value + "','" + hx6.Value + "','" + hx7.Value + "','" + hx8.Value + "','" + hy1.Value + "','" + hy2.Value + "','" + hy3.Value + "','" + hy4.Value + "','" + hy5.Value + "','" + hy6.Value + "','" + hy7.Value + "','" + hy8.Value + "','" + hsize1.Value + "','" + hsize2.Value + "','" + hsize3.Value + "','" + hsize4.Value + "','" + hsize5.Value + "','" + hsize6.Value + "','" + hsize7.Value + "','" + hsize8.Value + "','" + hb1.Checked.ToString() + "','" + hb2.Checked.ToString() + "','" + hb3.Checked.ToString() + "','" + hb4.Checked.ToString() + "','" + hb5.Checked.ToString() + "','" + hb6.Checked.ToString() + "','" + hb7.Checked.ToString() + "','" + hb8.Checked.ToString() + "','" + l1.Text + "','" + l2.Text + "','" + l3.Text + "','" + l4.Text + "','" + l5.Text + "','" + l6.Text + "','" + l7.Text + "','" + l8.Text + "','" + l9.Text + "','" + l10.Text + "','" + l11.Text + "','" + l12.Text + "','" + x1.Value + "','" + x2.Value + "','" + x3.Value + "','" + x4.Value + "','" + x5.Value + "','" + x6.Value + "','" + x7.Value + "','" + x8.Value + "','" + x9.Value + "','" + x10.Value + "','" + x11.Value + "','" + x12.Value + "','" + y1.Value + "','" + y2.Value + "','" + y3.Value + "','" + y4.Value + "','" + y5.Value + "','" + y6.Value + "','" + y7.Value + "','" + y8.Value + "','" + y9.Value + "','" + y10.Value + "','" + y11.Value + "','" + y12.Value + "','" + size1.Value + "','" + size2.Value + "','" + size3.Value + "','" + size4.Value + "','" + size5.Value + "','" + size6.Value + "','" + size7.Value + "','" + size8.Value + "','" + size9.Value + "','" + size10.Value + "','" + size11.Value + "','" + size12.Value + "','" + b1_ch.Checked.ToString() + "','" + b2_ch.Checked.ToString() + "','" + b3_ch.Checked.ToString() + "','" + b4_ch.Checked.ToString() + "','" + b5_ch.Checked.ToString() + "','" + b6_ch.Checked.ToString() + "','" + b7_ch.Checked.ToString() + "','" + b8_ch.Checked.ToString() + "','" + b9_ch.Checked.ToString() + "','" + b10_ch.Checked.ToString() + "','" + b11_ch.Checked.ToString() + "','" + b12_ch.Checked.ToString() + "','" + adr_t.Text + "','" + adr_x.Value + "','" + adr_y.Value + "','" + adr_size.Value + "','" + adr_b.Checked.ToString() + "','" + font1_c.Text + "','" + font2_c.Text + "','" + font3_c.Text + "','" + font4_c.Text + "','" + i + "') ";
                sqlcmd.ExecuteNonQuery();

                sqlconn.Close();
            }

        }

        private void hl5_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void hl6_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void hl7_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void hl8_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void hl5_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void hl6_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void hl7_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void hl8_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void l1_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l2_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l3_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l4_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l5_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l6_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l7_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l8_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l9_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l10_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l11_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void l12_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void template_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void tabPage41_Enter(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "select gy,pd from sw ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["gy"].ToString()) == 1)
                {
                    gy_unhide_r.Checked = true;
                }
                else
                {
                    gy_hide_r.Checked = true;
                }

                if (Int32.Parse(data["pd"].ToString()) == 1)
                {
                    pd_unhide_r.Checked = true;
                }
                else
                {
                    pd_hide_r.Checked = true;
                }
            }
            data.Close();

            sqlconn.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (pc_pro_c.Text == "")
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse to find '" + pc_pro_c.Text + "' Program ";
            dlg.Filter = "Application Files(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update pc_program set p_src = '" + dlg.FileName + "' where p = '" + pc_pro_c.Text + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void tabPage43_Enter(object sender, EventArgs e)
        {
            pc_pro_c.Items.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Select distinct p from pc_program where p<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                pc_pro_c.Items.Add(data["p"].ToString());
            }
            data.Close();

            sqlconn.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Printer.doc");
            }
            catch { }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (family_t.Text == "")
            {
                MessageBox.Show("Please, Complete secretary's family field", "Notification");
                return;
            }

            if (username_t.Text == "")
            {
                MessageBox.Show("Please, Complete secretary's username field", "Notification");
                return;
            }

            if (pass_t.Text == "")
            {
                MessageBox.Show("Please, Complete secretary's password field", "Notification");
                return;
            }

            if (pass_t.Text.Length < 5)
            {
                MessageBox.Show("The password must be at least 5 characters", "Notification");
                return;
            }

            if (pass_t.Text != pass2_t.Text)
            {
                MessageBox.Show("Passwords do not match", "Notification");
                return;
            }

            string mypass = cm.MyEncoding(pass_t.Text);

            int paz, search, nobat, acc, reminder, all_info, tel;
            paz = search = nobat = acc = reminder = all_info = tel = 0;

            if (paziresh_ch.Checked == true)
                paz = 1;
            if (tel_ch.Checked == true)
                tel = 1;
            if (all_info_ch.Checked == true)
                all_info = 1;
            if (acc_ch.Checked == true)
                acc = 1;
            if (Search_ch.Checked == true)
                search = 1;
            if (reminder_ch.Checked == true)
                reminder = 1;
            if (nobat_ch.Checked == true)
                nobat = 1;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (button17.Text == "درج")
            {
                sqlcmd.CommandText = "select count(*) from monshi where username = '" + username_t.Text + "' and type = 1 ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "insert into monshi(name,family,username,pass,doctor,type,paziresh,nobat,search,tel,acc,reminder,all_info) values('" + name_t.Text + "','" + family_t.Text + "','" + username_t.Text + "','" + mypass + "','" + login.log_username + "','" + 1 + "','" + paz + "','" + nobat + "','" + search + "','" + tel + "','" + acc + "','" + reminder + "','" + all_info + "')";
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
                sqlcmd.CommandText = "Update monshi set name = '" + name_t.Text + "',family= '" + family_t.Text + "',pass= '" + mypass + "',paziresh = '" + paz + "',nobat = '" + nobat + "',search = '" + search + "',tel = '" + tel + "',acc = '" + acc + "',reminder = '" + reminder + "',all_info = '" + all_info + "' where username = '" + username_t.Text + "' and type = 1 ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();
        }

        private void tabPage37_Enter(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            sqlcmd.CommandText = "select count(*) from monshi where doctor = '" + login.log_username + "' and type = 1 ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                button17.Text = "درج";
            }
            else
            {
                username_t.ReadOnly = true;

                sqlcmd.CommandText = "select * from monshi where doctor = '" + login.log_username + "' and type = 1 ";
                data = sqlcmd.ExecuteReader();
                int paz, search, nobat, acc, reminder, all_info, tel;
                paz = search = nobat = acc = reminder = all_info = tel = 0;
                while (data.Read())
                {
                    name_t.Text = data["name"].ToString();
                    family_t.Text = data["family"].ToString();
                    username_t.Text = data["username"].ToString();
                    pass_t.Text = cm.MyDecoding(data["pass"].ToString());
                    pass2_t.Text = pass_t.Text;

                    paz = Int32.Parse(data["paziresh"].ToString());
                    search = Int32.Parse(data["search"].ToString());
                    nobat = Int32.Parse(data["nobat"].ToString());
                    acc = Int32.Parse(data["acc"].ToString());
                    reminder = Int32.Parse(data["reminder"].ToString());
                    all_info = Int32.Parse(data["all_info"].ToString());
                    tel = Int32.Parse(data["tel"].ToString());

                }
                data.Close();

                if (paz == 1)
                    paziresh_ch.Checked = true;
                if (tel == 1)
                    tel_ch.Checked = true;
                if (all_info == 1)
                    all_info_ch.Checked = true;
                if (acc == 1)
                    acc_ch.Checked = true;
                if (search == 1)
                    Search_ch.Checked = true;
                if (reminder == 1)
                    reminder_ch.Checked = true;
                if (nobat == 1)
                    nobat_ch.Checked = true;

            }

            sqlconn.Close();
        }

        private void tabPage19_Enter(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            sqlcmd.CommandText = "select count(*) from monshi where doctor = '" + login.log_username + "' and type = 2 ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                button28.Text = "درج";
            }
            else
            {
                username2_t.ReadOnly = true;

                sqlcmd.CommandText = "select * from monshi where doctor = '" + login.log_username + "' and type = 2 ";
                data = sqlcmd.ExecuteReader();
                int paz, search, nobat, acc, reminder, all_info, tel;
                paz = search = nobat = acc = reminder = all_info = tel = 0;
                while (data.Read())
                {
                    name2_t.Text = data["name"].ToString();
                    family2_t.Text = data["family"].ToString();
                    username2_t.Text = data["username"].ToString();
                    pass_t2.Text = cm.MyDecoding(data["pass"].ToString());
                    pass2_t2.Text = pass_t.Text;

                    paz = Int32.Parse(data["paziresh"].ToString());
                    search = Int32.Parse(data["search"].ToString());
                    nobat = Int32.Parse(data["nobat"].ToString());
                    acc = Int32.Parse(data["acc"].ToString());
                    reminder = Int32.Parse(data["reminder"].ToString());
                    all_info = Int32.Parse(data["all_info"].ToString());
                    tel = Int32.Parse(data["tel"].ToString());

                }
                data.Close();

                if (paz == 1)
                    paziresh2_ch.Checked = true;
                if (tel == 1)
                    tel2_ch.Checked = true;
                if (all_info == 1)
                    all_info2_ch.Checked = true;
                if (acc == 1)
                    acc2_ch.Checked = true;
                if (search == 1)
                    Search2_ch.Checked = true;
                if (reminder == 1)
                    reminder2_ch.Checked = true;
                if (nobat == 1)
                    nobat2_ch.Checked = true;

            }

            sqlconn.Close();
        }

        private void name_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void family_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void name2_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void family2_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void family2_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void name2_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void name_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void family_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void button28_Click(object sender, EventArgs e)
        {

            if (family2_t.Text == "")
            {
                MessageBox.Show("Please, Complete secretary's family field", "Notification");
                return;
            }

            if (username2_t.Text == "")
            {
                MessageBox.Show("Please, Complete secretary's username field", "Notification");
                return;
            }

            if (pass_t2.Text == "")
            {
                MessageBox.Show("Please, Complete secretary's password field", "Notification");
                return;
            }

            if (pass_t2.Text.Length < 5)
            {
                MessageBox.Show("The password must be at least 5 characters", "Notification");
                return;
            }

            if (pass_t2.Text != pass2_t2.Text)
            {
                MessageBox.Show("Passwords do not match", "Notification");
                return;
            }


            //if (family2_t.Text == "")
            //{
            //    MessageBox.Show("لطفاً فيلد مربوط به نام خانوادگي منشی را تكميل نماييد", "توجه");
            //    return;
            //}

            //if (username2_t.Text == "")
            //{
            //    MessageBox.Show("لطفاً فيلد مربوط به نام كاربري منشی را تكميل نماييد", "توجه");
            //    return;
            //}

            //if (pass_t2.Text == "")
            //{
            //    MessageBox.Show("لطفاً فيلد مربوط به كلمه عبور منشی را تكميل نماييد", "توجه");
            //    return;
            //}

            //if (pass_t2.Text.Length < 5)
            //{
            //    MessageBox.Show("كلمه عبور حداقل بايد پنج حرفي باشد", "توجه");
            //    return;
            //}

            //if (pass_t2.Text != pass2_t2.Text)
            //{
            //    MessageBox.Show("كلمات عبور با هم يكسان نيستند", "توجه");
            //    return;
            //}

            string mypass = cm.MyEncoding(pass_t2.Text);

            int paz, search, nobat, acc, reminder, all_info, tel;
            paz = search = nobat = acc = reminder = all_info = tel = 0;

            if (paziresh2_ch.Checked == true)
                paz = 1;
            if (tel2_ch.Checked == true)
                tel = 1;
            if (all_info2_ch.Checked == true)
                all_info = 1;
            if (acc2_ch.Checked == true)
                acc = 1;
            if (Search2_ch.Checked == true)
                search = 1;
            if (reminder2_ch.Checked == true)
                reminder = 1;
            if (nobat2_ch.Checked == true)
                nobat = 1;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (button28.Text == "درج")
            {
                sqlcmd.CommandText = "select count(*) from monshi where username = '" + username2_t.Text + "' and type = 2 ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "insert into monshi(name,family,username,pass,doctor,type,paziresh,nobat,search,tel,acc,reminder,all_info) values('" + name2_t.Text + "','" + family2_t.Text + "','" + username2_t.Text + "','" + mypass + "','" + login.log_username + "','" + 2 + "','" + paz + "','" + nobat + "','" + search + "','" + tel + "','" + acc + "','" + reminder + "','" + all_info + "')";
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
                sqlcmd.CommandText = "Update monshi set name = '" + name2_t.Text + "',family= '" + family2_t.Text + "',pass= '" + mypass + "',paziresh = '" + paz + "',nobat = '" + nobat + "',search = '" + search + "',tel = '" + tel + "',acc = '" + acc + "',reminder = '" + reminder + "',all_info = '" + all_info + "' where username = '" + username2_t.Text + "' and type = 2 ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Manage_Template frm = new Manage_Template();
            frm.ShowDialog();
        }

        private void tabControl3_Enter(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "select gy,pd from sw ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["gy"].ToString()) == 1)
                {
                    gy_unhide_r.Checked = true;
                }
                else
                {
                    gy_hide_r.Checked = true;
                }

                if (Int32.Parse(data["pd"].ToString()) == 1)
                {
                    pd_unhide_r.Checked = true;
                }
                else
                {
                    pd_hide_r.Checked = true;
                }
            }
            data.Close();

            sqlconn.Close();
        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\CM-Help-Main.pdf");
            //}
            //catch { }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Chm Farsi.chm");
            }
            catch { }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\CM-Help-Main.pdf");
            }
            catch { }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Chm English.chm");
            }
            catch { }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\CM-Help-Main-En.pdf");
            }
            catch { }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (gy_hide_r.Checked == true)
            {
                sqlcmd.CommandText = "Update sw set gy = '" + 0 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            {
                sqlcmd.CommandText = "Update sw set gy = '" + 1 + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (pd_hide_r.Checked == true)
            {
                sqlcmd.CommandText = "Update sw set pd = '" + 0 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            {
                sqlcmd.CommandText = "Update sw set pd = '" + 1 + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();

        }
        /////////////////////////////////////////////////
    }
}