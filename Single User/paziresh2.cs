using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Utils;


namespace Clinical_Management
{
    public partial class paziresh2 : Form
    {
        public static bool paziresh2_conflict;
        public static bool insert_mode = false;
        public static string myrow;
        public paziresh2()
        {
            InitializeComponent();
        }

        private void paziresh2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void paziresh2_Load(object sender, EventArgs e)
        {
            if (login.log_username != "admin")
            {
                doctor_t.Text = "œﬂ — " + login.log_name + " " + login.log_family;
                doctor_t.ReadOnly = true;

                prf_t.Text = login.log_prf;
                prf_t.ReadOnly = true;
            }

            paziresh2_conflict = false;

            LanguageSelector.KeyboardLayout.Farsi();
            title_t.Focus();
            if (insert_mode == true)
            {
                button1.Text = "œ—Ã œ— Å–Ì—‘";
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
                button1.Text = " €ÌÌ—«  À»  ‘Êœ";

                doctor_t.Text = Paziresh.paziresh_row[0].ToString();
                prf_t.Text = Paziresh.paziresh_row[1].ToString();
                title_t.Text = Paziresh.paziresh_row[2].ToString();
                fname_t.Text = Paziresh.paziresh_row[3].ToString();
                family_t.Text = Paziresh.paziresh_row[4].ToString();
                cause_t.Text = Paziresh.paziresh_row[5].ToString();
                bimeh_t.Text = Paziresh.paziresh_row[6].ToString();
                bimehno_t.Text = Paziresh.paziresh_row[7].ToString();
                expire_t.Text = Paziresh.paziresh_row[8].ToString();
                serial_t.Text = Paziresh.paziresh_row[9].ToString();
                nid_t.Text = Paziresh.paziresh_row[10].ToString();
                visit_t.Text = Paziresh.paziresh_row[11].ToString();
                consult_t.Text = Paziresh.paziresh_row[12].ToString();
                service1_t.Text = Paziresh.paziresh_row[13].ToString();
                service2_t.Text = Paziresh.paziresh_row[14].ToString();
                income_t.Text = Paziresh.paziresh_row[15].ToString();
                ret_t.Text = Paziresh.paziresh_row[16].ToString();
                par_t.Text = Paziresh.paziresh_row[17].ToString();
            }

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

            string s;
            int i = 0;
            sqlcmd.CommandText = "select distinct title from info where title<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["title"].ToString();
                title_t.AutoCompleteCustomSource.Add(s);
                title_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            //sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    family_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            //data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct cause from paziresh_tmp where cause<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["cause"].ToString();
                cause_t.AutoCompleteCustomSource.Add(s);
                cause_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select * from doctor ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = "œﬂ — " + data["name"].ToString() + " " + data["family"].ToString();
                doctor_t.AutoCompleteCustomSource.Add(s);
                doctor_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct prf from paziresh_tmp where prf<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["prf"].ToString();
                prf_t.AutoCompleteCustomSource.Add(s);
                prf_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct bimeh from info where bimeh<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["bimeh"].ToString();
                bimeh_t.AutoCompleteCustomSource.Add(s);
                bimeh_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            //sqlcmd.CommandText = "select distinct serial from paziresh_tmp where serial<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    serial_t.AutoCompleteCustomSource.Add(data["serial"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct nid from info where nid<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    nid_t.AutoCompleteCustomSource.Add(data["nid"].ToString());
            //data.Close();


            sqlconn.Close();

            timer1.Enabled = true;
        }

        private void paziresh2_FormClosing(object sender, FormClosingEventArgs e)
        {
            insert_mode = false;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fname_t.Text == "" || family_t.Text == "")
            {
                alert frm1 = new alert();
                frm1.ShowDialog();
                return;
            }


            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            if (button1.Text == "œ—Ã œ— Å–Ì—‘")
            {
                Paziresh.paziresh_flag = true;


                //Paziresh.paziresh_row[6] = title_t.Text;
                //Paziresh.paziresh_row[7] = fname_t.Text;
                //Paziresh.paziresh_row[8] = family_t.Text;
                //Paziresh.paziresh_row[9] = cause_t.Text;
                //Paziresh.paziresh_row[10] = doctor_t.Text;
                //Paziresh.paziresh_row[11] = prf_t.Text;
                //Paziresh.paziresh_row[12] = bimeh_t.Text;
                //Paziresh.paziresh_row[13] = bimehno_t.Text;
                //Paziresh.paziresh_row[14] = expire_t.Text;
                //Paziresh.paziresh_row[15] = serial_t.Text;
                //Paziresh.paziresh_row[16] = nid_t.Text;
                //Paziresh.paziresh_row[17] = visit_t.Text;
                //Paziresh.paziresh_row[18] = consult_t.Text;
                //Paziresh.paziresh_row[19] = service1_t.Text;
                //Paziresh.paziresh_row[20] = service2_t.Text;
                //Paziresh.paziresh_row[21] = income_t.Text;
                //Paziresh.paziresh_row[22] = ret_t.Text;
                //Paziresh.paziresh_row[23] = " "; // par_t.Text


                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                int sickcount = 0;
                sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname_t.Text + "' and lname = '" + family_t.Text + "' ";
                sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
                sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname_t.Text + "' and mname = '" + family_t.Text + "' ";
                sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

                if (sickcount > 0)
                {
                    Search2.search2_fname = fname_t.Text;
                    Search2.search2_family = family_t.Text;
                    Search2 frm = new Search2();
                    frm.ShowDialog();
                }
                else
                {
                    sqlcmd.CommandText = "select counter from sw";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    Int64 cnt = 1;
                    while (data.Read())
                        cnt = Int64.Parse(data["counter"].ToString());
                    data.Close();

                    sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                    sqlcmd.ExecuteNonQuery();

                    sqlcmd.CommandText = "Insert into paziresh(lname,row,title,fname,family,cause,doctor,prf,bimeh,bimehno,expire,serial,nid,visit,consult,service1,service2,income,ret,date1,date2,dselect,mselect) values('" + family_t.Text + "','" + cnt.ToString() + "','" + title_t.Text + "','" + fname_t.Text + "','" + family_t.Text + "','" + cause_t.Text + "','" + doctor_t.Text + "','" + prf_t.Text + "','" + bimeh_t.Text + "','" + bimehno_t.Text + "','" + expire_t.Text + "','" + serial_t.Text + "','" + nid_t.Text + "','" + visit_t.Text + "','" + consult_t.Text + "','" + service1_t.Text + "','" + service2_t.Text + "','" + income_t.Text + "','" + ret_t.Text + "','" + today + "','" + today + "','','')";
                    sqlcmd.ExecuteNonQuery();

                    sqlcmd.CommandText = "Insert into paziresh_tmp(cause,doctor,prf,serial) values('" + cause_t.Text + "','" + doctor_t.Text + "','" + prf_t.Text + "','" + serial_t.Text + "')";
                    sqlcmd.ExecuteNonQuery();
                }

                if (paziresh2_conflict == true)
                {
                    paziresh2_conflict = false;

                    sqlcmd.CommandText = "select counter from sw";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    Int64 cnt = 1;
                    while (data.Read())
                        cnt = Int64.Parse(data["counter"].ToString());
                    data.Close();

                    sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                    sqlcmd.ExecuteNonQuery();

                    sqlcmd.CommandText = "Insert into paziresh(lname,row,title,fname,family,cause,doctor,prf,bimeh,bimehno,expire,serial,nid,visit,consult,service1,service2,income,ret,date1,date2,dselect,mselect) values('" + family_t.Text + "','" + cnt.ToString() + "','" + title_t.Text + "','" + fname_t.Text + "','" + family_t.Text + "','" + cause_t.Text + "','" + doctor_t.Text + "','" + prf_t.Text + "','" + bimeh_t.Text + "','" + bimehno_t.Text + "','" + expire_t.Text + "','" + serial_t.Text + "','" + nid_t.Text + "','" + visit_t.Text + "','" + consult_t.Text + "','" + service1_t.Text + "','" + service2_t.Text + "','" + income_t.Text + "','" + ret_t.Text + "','" + today + "','" + today + "','','')";
                    sqlcmd.ExecuteNonQuery();

                    sqlcmd.CommandText = "Insert into paziresh_tmp(cause,doctor,prf,serial) values('" + cause_t.Text + "','" + doctor_t.Text + "','" + prf_t.Text + "','" + serial_t.Text + "')";
                    sqlcmd.ExecuteNonQuery();
                }


                sqlcmd.CommandText = "select count(*) from info where title='" + title_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(title) values('" + title_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlcmd.CommandText = "select count(*) from info where fname='" + fname_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(fname) values('" + fname_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlcmd.CommandText = "select count(*) from info where lname='" + family_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(lname) values('" + family_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlcmd.CommandText = "select count(*) from info where bimeh='" + bimeh_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(bimeh) values('" + bimeh_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlconn.Close();
            }
            else
            {
                Paziresh.paziresh_edit_flag = true;

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update paziresh set title = '" + title_t.Text + "',fname = '" + fname_t.Text + "',family = '" + family_t.Text + "',cause = '" + cause_t.Text + "',doctor = '" + doctor_t.Text + "',prf = '" + prf_t.Text + "',bimeh = '" + bimeh_t.Text + "',bimehno = '" + bimehno_t.Text + "',expire = '" + expire_t.Text + "',serial = '" + serial_t.Text + "',nid = '" + nid_t.Text + "',visit = '" + visit_t.Text + "',consult = '" + consult_t.Text + "',service1 = '" + service1_t.Text + "',service2 = '" + service2_t.Text + "',income = '" + income_t.Text + "', ret = '" + ret_t.Text +"' where row = '"+ myrow +"' and date1 = '"+ today +"' ";
                sqlcmd.ExecuteNonQuery();

                sqlconn.Close();

            }

            this.Close();
        }

        private void title_t_Click(object sender, EventArgs e)
        {
            title_c.Width = 17;
            title_c.Visible = true;
        }

        private void cause_t_Click(object sender, EventArgs e)
        {
            cause_c.Width = 17;
            cause_c.Visible = true;
        }

        private void doctor_t_Click(object sender, EventArgs e)
        {
            if (login.log_username == "admin")
            {
                doctor_c.Width = 17;
                doctor_c.Visible = true;
            }
        }

        private void prf_t_Click(object sender, EventArgs e)
        {
            if (login.log_username == "admin")
            {
                prf_c.Width = 17;
                prf_c.Visible = true;
            }
        }

        private void bimeh_t_Click(object sender, EventArgs e)
        {
            bimeh_c.Width = 17;
            bimeh_c.Visible = true;
        }

        private void title_c_Click(object sender, EventArgs e)
        {
            if (title_c.Width != 22 + title_t.Width)
                title_c.Width = 22 + title_t.Width;
        }

        private void cause_c_Click(object sender, EventArgs e)
        {
            if (cause_c.Width != 22 + cause_t.Width)
                cause_c.Width = 22 + cause_t.Width;
        }

        private void doctor_c_Click(object sender, EventArgs e)
        {
            if (doctor_c.Width != 22 + doctor_t.Width)
                doctor_c.Width = 22 + doctor_t.Width;
        }

        private void prf_c_Click(object sender, EventArgs e)
        {
            if (prf_c.Width != 22 + prf_t.Width)
                prf_c.Width = 22 + prf_t.Width;
        }

        private void bimeh_c_Click(object sender, EventArgs e)
        {
            if (bimeh_c.Width != 22 + bimeh_t.Width)
                bimeh_c.Width = 22 + bimeh_t.Width;
        }

        private void title_c_MouseHover(object sender, EventArgs e)
        {
            title_c.Width = 22 + title_t.Width;
            title_c.SendToBack();
        }

        private void cause_c_MouseHover(object sender, EventArgs e)
        {
            cause_c.Width = 22 + cause_t.Width;
            cause_c.SendToBack();
        }

        private void doctor_c_MouseHover(object sender, EventArgs e)
        {
            doctor_c.Width = 22 + doctor_t.Width;
            doctor_c.SendToBack();
        }

        private void prf_c_MouseHover(object sender, EventArgs e)
        {
            prf_c.Width = 22 + prf_t.Width;
            prf_c.SendToBack();
        }

        private void bimeh_c_MouseHover(object sender, EventArgs e)
        {
            bimeh_c.Width = 22 + bimeh_t.Width;
            bimeh_c.SendToBack();
        }

        private void title_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            title_t.Text = title_c.Text;
            title_c.Width = 17;
            title_c.Visible = false;
            title_t.Focus();
        }

        private void cause_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            cause_t.Text = cause_c.Text;
            cause_c.Width = 17;
            cause_c.Visible = false;
            cause_t.Focus();
        }

        private void doctor_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctor_t.Text = doctor_c.Text;
            doctor_c.Width = 17;
            doctor_c.Visible = false;
            doctor_t.Focus();
        }

        private void prf_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            prf_t.Text = prf_c.Text;
            prf_c.Width = 17;
            prf_c.Visible = false;
            prf_t.Focus();
        }

        private void bimeh_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bimeh_t.Text = bimeh_c.Text;
            bimeh_c.Width = 17;
            bimeh_c.Visible = false;
            bimeh_t.Focus();
        }

        private void fname_t_Enter(object sender, EventArgs e)
        {
            title_c.Visible = false;
        }

        private void doctor_t_Enter(object sender, EventArgs e)
        {
            cause_c.Visible = false;
        }

        private void prf_t_Enter(object sender, EventArgs e)
        {
            doctor_c.Visible = false;
        }

        private void bimeh_t_Enter(object sender, EventArgs e)
        {
            prf_c.Visible = false;
        }

        private void bimehno_t_Enter(object sender, EventArgs e)
        {
            bimeh_c.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible == false)
                menuStrip1.Visible = true;
            else
                menuStrip1.Visible = false;
        }

        private void paziresh2_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Receipt.receipt_name = (title_t.Text + " "  + fname_t.Text + " " + family_t.Text).Trim();

            Receipt frm = new Receipt();
            frm.ShowDialog();

            menuStrip1.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rest.Rest_name = (title_t.Text + " " + fname_t.Text + " " + family_t.Text).Trim();

            Rest frm = new Rest();
            frm.ShowDialog();

            menuStrip1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                tmp_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            data.Close();

            
            sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                tmp2_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            data.Close();
            
            sqlconn.Close();

            timer1.Enabled = false;

            fname_t.AutoCompleteCustomSource = tmp_t.AutoCompleteCustomSource;

            family_t.AutoCompleteCustomSource = tmp2_t.AutoCompleteCustomSource;

        }


    }
}