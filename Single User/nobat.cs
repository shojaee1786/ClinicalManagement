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
    public partial class nobat : Form
    {
        public static bool conflict;
        private static string date1;
        private static bool time1 = false;
        private static bool time2 = false;
        private static int hstart1, mstart1, hfinish1;
        private static int hstart2, mstart2, hfinish2;
        private static int cnt1, cnt2,disp;

        public static bool reset_t, shab, def, del_d;
        
        public nobat()
        {
            InitializeComponent();
        }

        private void faMonthView1_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            string h, n, f, t, r;
            h = n = f = t = r = "";

            if (date1 == "")
            {
                //string mymonth = "", myday = "";

                //if (faMonthView1.Month.ToString().Length == 1)
                //    mymonth = "0" + faMonthView1.Month.ToString();
                //else
                //    mymonth = faMonthView1.Month.ToString();

                //if (faMonthView1.Day.ToString().Length == 1)
                //    myday = "0" + faMonthView1.Day.ToString();
                //else
                //    myday = faMonthView1.Day.ToString();


               // date1 = faMonthView1.Year.ToString() + "/" + mymonth + "/" + myday;
                    date1 = faMonthView1.Year.ToString() + "/" + faMonthView1.Month.ToString() + "/" + faMonthView1.Day.ToString();
                
                sqlcmd.CommandText = "select * from nobat where doctor = '" + doctor_c.Text + "' and date1 = '" + date1 + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    h = data["hour1"].ToString();
                    n = data["name"].ToString();
                    f = data["family"].ToString();
                    t = data["tel"].ToString();
                    r = data["row"].ToString();
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + r)
                        {
                            c1.Text = h;
                        }
                        if (c1.Name == "fname" + r)
                        {
                            c1.Text = n;
                        }
                        if (c1.Name == "family" + r)
                        {
                            c1.Text = f;
                        }
                        if (c1.Name == "telno" + r)
                        {
                            c1.Text = t;
                        }
                    }

                }
                data.Close();
            }
            else
            {
                sqlcmd.CommandText = "delete nobat where date1='" + date1 + "' and doctor = '" + doctor_c.Text + "'  ";
                sqlcmd.ExecuteNonQuery();
                for (int i = 1; i < 39; i++)
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + i.ToString())
                        {
                            h = c1.Text;
                        }
                        if (c1.Name == "fname" + i.ToString())
                        {
                            n = c1.Text;
                        }
                        if (c1.Name == "family" + i.ToString())
                        {
                            f = c1.Text;
                        }
                        if (c1.Name == "telno" + i.ToString())
                        {
                            t = c1.Text;
                        }
                    }
                    sqlcmd.CommandText = "Insert into nobat(doctor,date1,row,hour1,name,family,tel) values('" + doctor_c.Text + "','" + date1 + "','" + i.ToString() + "','" + h + "','" + n + "','" + f + "','" + t + "') ";
                    sqlcmd.ExecuteNonQuery();
                    h = n = f = t = r = "";
                }
                for (int i = 1; i < 39; i++)
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + i.ToString())
                        {
                            c1.Text = "";
                        }
                        if (c1.Name == "fname" + i.ToString())
                        {
                            c1.Text = "";
                        }
                        if (c1.Name == "family" + i.ToString())
                        {
                            c1.Text = "";
                        }
                        if (c1.Name == "telno" + i.ToString())
                        {
                            c1.Text = "";
                        }
                    }

                }

                sqlcmd.CommandText = "Delete from cnt where date1 = '"+ date1 +"' and doctor = '"+ doctor_c.Text +"' ";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Insert into cnt(date1,doctor,cnt1,cnt2,disp) values('" + date1 +"','" + doctor_c.Text +"','" + cnt1 +"','" + cnt2 +"','" + disp +"') ";
                sqlcmd.ExecuteNonQuery();

                //string mymonth = "", myday = "";

                //if (faMonthView1.Month.ToString().Length == 1)
                //    mymonth = "0" + faMonthView1.Month.ToString();
                //else
                //    mymonth = faMonthView1.Month.ToString();

                //if (faMonthView1.Day.ToString().Length == 1)
                //    myday = "0" + faMonthView1.Day.ToString();
                //else
                //    myday = faMonthView1.Day.ToString();


                //date1 = faMonthView1.Year.ToString() + "/" + mymonth + "/" + myday;
                
                date1 = faMonthView1.Year.ToString() + "/" + faMonthView1.Month.ToString() + "/" + faMonthView1.Day.ToString();

                sqlcmd.CommandText = "select * from nobat where doctor = '"+ doctor_c.Text +"' and date1 = '"+ date1 +"' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    h = data["hour1"].ToString();
                    n = data["name"].ToString();
                    f = data["family"].ToString();
                    t = data["tel"].ToString();
                    r = data["row"].ToString();
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + r)
                        {
                            c1.Text = h;
                        }
                        if (c1.Name == "fname" + r)
                        {
                            c1.Text = n;
                        }
                        if (c1.Name == "family" + r)
                        {
                            c1.Text = f;
                        }
                        if (c1.Name == "telno" + r)
                        {
                            c1.Text = t;
                        }
                    }

                }
                data.Close();
            }

            cnt1 = 0;
            cnt2 = 0;
            disp = 0;
            sqlcmd.CommandText = "select * from cnt where doctor = '" + doctor_c.Text + "' and date1 = '" + date1 + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                cnt1 = Int32.Parse(data["cnt1"].ToString());
                cnt2 = Int32.Parse(data["cnt2"].ToString());
                disp = Int32.Parse(data["disp"].ToString());
            }
            data.Close();




            if (hour1.Text == "" && hour2.Text == "" && hour3.Text == "" &&
                fname1.Text == "" && fname2.Text == "" && fname3.Text == "" &&
                family1.Text == "" && family2.Text == "" && family3.Text == "")
            {
                sqlcmd.CommandText = "select default_time from sw where default_time<>'' ";
                data = sqlcmd.ExecuteReader();
                string my_temp24 = "";
                while (data.Read())
                {
                    my_temp24 = data["default_time"].ToString();
                }
                data.Close();

                int index;
                for (int i = 1; i < 125; i++)
                {
                    index = my_temp24.IndexOf("|");
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + i.ToString())
                        {
                            c1.Text = my_temp24.Substring(0, index);
                            if (i == 124)
                                break;

                            my_temp24 = my_temp24.Substring(index + 1, my_temp24.Length - index - 1);
                        }
                    }

                }


            }

            sqlconn.Close();

            if (cnt1 <= 0 && cnt2 <= 0)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name.Substring(0, 4) == "hour" && c1.Text != "")
                    {
                        cnt1++;
                    }
                }

            }

        }
        private void nobat_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            if (login.log_username == "admin")
            {
                doctor_c.Visible = true;
                sqlcmd.CommandText = "select * from doctor where username<>'admin' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    doctor_c.Items.Add(data["prf"].ToString() + " - " + " دكتر" + data["name"].ToString() + " " + data["family"].ToString());
                }
                data.Close();
                try
                {
                    doctor_c.SelectedIndex = 0;
                }
                catch { }
                //  جراح اعصاب - دکتر پرویز محیط
            }
            else
            {
                string  dr = "دكتر " + login.log_name + " " + login.log_family;
                string prf = login.log_prf;

                doctor_c.Text = prf + " - " + dr;
            }

            shab = false;
            def = false;
            del_d = false;
            reset_t = false;
            conflict = false;

            date1 = "";
            fname1.Focus();
            hstart1 = mstart1 = 0;
            hstart2 = mstart2 = 0;
            cnt1 = cnt2 = disp = 0;

            time1 = false;
            time2 = false;

            
            LanguageSelector.KeyboardLayout.Farsi();

            faMonthView1.SelectedDateTime = FarsiLibrary.Utils.PersianDate.Now;

            

            sqlcmd.CommandText =  "select * from temp where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "select callerid from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["callerid"].ToString()) == 0)
                    tel_t.Visible = true;
                else
                    tel_t.Visible = false;
            }
            data.Close();


            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);
          
            sqlcmd.CommandText = "select * from paziresh where date1 = '" + today + "'";
            try
            {
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Update sw set counter = '" + 1 + "' ";
                    sqlcmd.ExecuteNonQuery();
                }
            }
            catch
            {
                sqlcmd.CommandText = "Update sw set counter = '" + 1 + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            //sqlcmd.CommandText = "select physician from sw";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //{
            //    if (Int32.Parse(data["physician"].ToString()) == 0)
            //        doctor_c.Visible = true;
            //    else
            //        doctor_c.Visible = false;
            //}
            //data.Close();

           
            sqlconn.Close();

            timer1.Enabled = true;
        }

        private void nobat_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void p1_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 1;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 1;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }
                        
                    }


                }
            }
            p1_1.Visible = false;
            p1_2.Visible = true;
        }

        private void p2_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 2;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 2;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p2_1.Visible = false;
            p2_2.Visible = true;
        }

        private void p3_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 3;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 3;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }
                }
            }
            p3_1.Visible = false;
            p3_2.Visible = true;
        }

        private void p4_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 4;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 4;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }
                }
            }
            p4_1.Visible = false;
            p4_2.Visible = true;

        }

        private void p5_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 5;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 5;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p5_1.Visible = false;
            p5_2.Visible = true;
        }

        private void p6_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 6;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 6;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p6_1.Visible = false;
            p6_2.Visible = true;
        }

        private void p7_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 7;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 7;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p7_1.Visible = false;
            p7_2.Visible = true;
        }

        private void p8_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 8;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 8;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p8_1.Visible = false;
            p8_2.Visible = true;
        }

        private void p9_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 9;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 9;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p9_1.Visible = false;
            p9_2.Visible = true;
        }

        private void p10_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 10;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 10;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p10_1.Visible = false;
            p10_2.Visible = true;
        }

        private void p11_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 11;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 11;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p11_1.Visible = false;
            p11_2.Visible = true;
        }

        private void p12_1_Click(object sender, EventArgs e)
        {
            if (time1 == true)
                return;
            if (hstart1 == 0 && mstart1 == 0)
            {
                hstart1 = 0;
                mstart1 = 0;
            }
            else
            {
                time1 = true;
                hfinish1 = 12;
                if (cnt2 == 0)
                {
                    hour1.Text = hstart1.ToString() + ":00";
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = 2; i <= cnt1; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }

                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt2 + 1).ToString())
                            c1.Text = hstart1.ToString() + ":00";
                    }
                    cnt1 = (hfinish1 - hstart1) * 4;
                    for (int i = cnt2 + 2; i <= cnt1 + cnt2; i++)
                    {
                        mstart1 += 15;
                        if (mstart1 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":" + mstart1.ToString();
                            }
                        }
                        else
                        {
                            mstart1 = 0;
                            hstart1++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart1.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p12_1.Visible = false;
            p12_2.Visible = true;
        }

        private void p13_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 13;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 13;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p13_1.Visible = false;
            p13_2.Visible = true;
        }

        private void p14_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 14;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 14;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p14_1.Visible = false;
            p14_2.Visible = true;

        }

        private void p15_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 15;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 15;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p15_1.Visible = false;
            p15_2.Visible = true;

        }

        private void p16_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 16;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 16;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p16_1.Visible = false;
            p16_2.Visible = true;

        }

        private void p17_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 17;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 17;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p17_1.Visible = false;
            p17_2.Visible = true;

        }

        private void p18_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 18;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 18;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p18_1.Visible = false;
            p18_2.Visible = true;

        }

        private void p19_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 19;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 19;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p19_1.Visible = false;
            p19_2.Visible = true;

        }

        private void p20_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 20;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 20;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p20_1.Visible = false;
            p20_2.Visible = true;

        }

        private void p21_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 21;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 21;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p21_1.Visible = false;
            p21_2.Visible = true;

        }

        private void p22_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 22;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 22;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p22_1.Visible = false;
            p22_2.Visible = true;

        }

        private void p23_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 23;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 23;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }

            p23_1.Visible = false;
            p23_2.Visible = true;
        }

        private void p24_1_Click(object sender, EventArgs e)
        {
            if (time2 == true)
                return;
            if (hstart2 == 0 && mstart2 == 0)
            {
                hstart2 = 24;
                mstart2 = 0;
            }
            else
            {
                time2 = true;
                hfinish2 = 24;
                if (cnt1 == 0)
                {
                    hour1.Text = hstart2.ToString() + ":00";
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = 2; i <= cnt2; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }

                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }

                        }
                    }
                }
                else
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + (cnt1 + disp + 1).ToString())
                            c1.Text = hstart2.ToString() + ":00";
                    }
                    cnt2 = (hfinish2 - hstart2) * 4;
                    for (int i = cnt1 + disp + 2; i <= cnt1 + cnt2 + disp; i++)
                    {
                        mstart2 += 15;
                        if (mstart2 != 60)
                        {
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":" + mstart2.ToString();
                            }
                        }
                        else
                        {
                            mstart2 = 0;
                            hstart2++;
                            foreach (Control c1 in panel1.Controls)
                            {
                                if (c1.Name == "hour" + i.ToString())
                                    c1.Text = hstart2.ToString() + ":00";
                            }
                        }

                    }


                }
            }
            p24_1.Visible = false;
            p24_2.Visible = true;
        }

        private void add1_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 1)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }

        }

        private void add2_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 2)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }

        }

        private void add3_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 3)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }

        }

        private void add4_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 4)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }

        }

        private void add5_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 5)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }

        }

        private void add6_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 6)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }

        }

        private void add7_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 7)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add8_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 8)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add9_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 9)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add10_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 10)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add11_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 11)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add12_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 12)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add13_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 13)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add14_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 14)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add15_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 15)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add16_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 16)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add17_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 17)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add18_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 18)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void add19_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 19)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void cm1_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;

            if (cm_menu.Visible == false)
            {
                cm_menu.Visible = true;
                cm_menu.Top = 38;
                cm_menu.Left = 0;

            }
            else
            {
                cm_menu.Visible = false;
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible == false)
            {
                menuStrip1.Visible = true;
                menuStrip1.Top = 65;
                menuStrip1.Left = 0;

            }
            else
            {
                menuStrip1.Visible = false;
            }
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;

            reset_time frm = new reset_time();
            frm.ShowDialog();

            if (reset_t == true)
            {
                for (int i = 1; i <= 38; i++)
                {
                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + i.ToString())
                            c1.Text = "";
                    }
                }
                hstart1 = mstart1 = 0;
                hstart2 = mstart2 = 0;
                cnt1 = cnt2 = disp = 0;

                time1 = false;
                time2 = false;

                p1_1.Visible = true;
                p2_1.Visible = true;
                p3_1.Visible = true;
                p4_1.Visible = true;
                p5_1.Visible = true;
                p6_1.Visible = true;
                p7_1.Visible = true;
                p8_1.Visible = true;
                p9_1.Visible = true;
                p10_1.Visible = true;
                p11_1.Visible = true;
                p12_1.Visible = true;

                p1_2.Visible = false;
                p2_2.Visible = false;
                p3_2.Visible = false;
                p4_2.Visible = false;
                p5_2.Visible = false;
                p6_2.Visible = false;
                p7_2.Visible = false;
                p8_2.Visible = false;
                p9_2.Visible = false;
                p10_2.Visible = false;
                p11_2.Visible = false;
                p12_2.Visible = false;

                p13_1.Visible = true;
                p14_1.Visible = true;
                p15_1.Visible = true;
                p16_1.Visible = true;
                p17_1.Visible = true;
                p18_1.Visible = true;
                p19_1.Visible = true;
                p20_1.Visible = true;
                p21_1.Visible = true;
                p22_1.Visible = true;
                p23_1.Visible = true;
                p24_1.Visible = true;

                p13_2.Visible = false;
                p14_2.Visible = false;
                p15_2.Visible = false;
                p16_2.Visible = false;
                p17_2.Visible = false;
                p18_2.Visible = false;
                p19_2.Visible = false;
                p20_2.Visible = false;
                p21_2.Visible = false;
                p22_2.Visible = false;
                p23_2.Visible = false;
                p24_2.Visible = false;

            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;

            default_time.default_time_s = "";
            for (int i = 1; i < 125; i++)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                        default_time.default_time_s = default_time.default_time_s + c1.Text + "|";
                }
            }

            default_time frm = new default_time();
            frm.ShowDialog();
        }

        private void شبانهروزيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            
            shab_roz frm = new shab_roz();
            frm.ShowDialog();

            if (shab == true)
            {
                String sh, sm;
                Int32 h, m, i;
                h = 0;
                m = 15;
                i = 1;
                bool flag = true;

                while (flag == true)
                {
                    sh = h.ToString();
                    if (sh.Length == 1)
                        sh = "0" + sh;

                    sm = m.ToString();
                    if (sm.Length == 1)
                        sm = "0" + sm;

                    foreach (Control c1 in panel1.Controls)
                    {
                        if (c1.Name == "hour" + i.ToString())
                            c1.Text = sh + ":" + sm;
                    }

                    m = m + 15;
                    if (m == 60)
                    {
                        m = 0;
                        h = h + 1;
                    }
                    i++;

                    if (h == 24 && m == 15)
                        flag = false;
                }
            }
        }

        private void حذفتماميروزهايگذشتهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;

            del_days frm = new del_days();
            frm.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            all_info frm = new all_info();
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Reminder frm = new Reminder();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            acc frm = new acc();
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Referral frm = new Referral();
            frm.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Consultation frm = new Consultation();
            frm.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Medical_Library frm = new Medical_Library();
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            DrugStore frm = new DrugStore();
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Algorithm frm = new Algorithm();
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Photo_Archive frm = new Photo_Archive();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Risk_Factor frm = new Risk_Factor();
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Research frm = new Research();
            frm.Show();
        }

        private void nobat_FormClosing(object sender, FormClosingEventArgs e)
        {
            string h, n, f, t;
            h = n = f = t = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "delete nobat where date1='" + date1 + "' and doctor = '" + doctor_c.Text + "'  ";
            sqlcmd.ExecuteNonQuery();
            for (int i = 1; i < 39; i++)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        h = c1.Text;
                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        n = c1.Text;
                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        f = c1.Text;
                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        t = c1.Text;
                    }
                }
                sqlcmd.CommandText = "Insert into nobat(doctor,date1,row,hour1,name,family,tel) values('" + doctor_c.Text + "','" + date1 + "','" + i.ToString() + "','" + h + "','" + n + "','" + f + "','" + t + "') ";
                sqlcmd.ExecuteNonQuery();
                h = n = f = t = "";
            }

            sqlcmd.CommandText = "Delete from cnt where date1 = '" + date1 + "' and doctor = '" + doctor_c.Text + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into cnt(date1,doctor,cnt1,cnt2,disp) values('" + date1 + "','" + doctor_c.Text + "','" + cnt1 + "','" + cnt2 + "','" + disp + "') ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();


        }

        private void tel1_Click(object sender, EventArgs e)
        { 
            if (family1.Text == "") 
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname1.Text + "','" + family1.Text + "','" + telno1.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (family2.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname2.Text + "','" + family2.Text + "','" + telno2.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (family3.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname3.Text + "','" + family3.Text + "','" + telno3.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (family4.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname4.Text + "','" + family4.Text + "','" + telno4.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (family5.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname5.Text + "','" + family5.Text + "','" + telno5.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (family6.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname6.Text + "','" + family6.Text + "','" + telno6.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (family7.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname7.Text + "','" + family7.Text + "','" + telno7.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (family8.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname8.Text + "','" + family8.Text + "','" + telno8.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (family9.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname9.Text + "','" + family9.Text + "','" + telno9.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (family10.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname10.Text + "','" + family10.Text + "','" + telno10.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (family11.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname11.Text + "','" + family11.Text + "','" + telno11.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (family12.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname12.Text + "','" + family12.Text + "','" + telno12.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (family13.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname13.Text + "','" + family13.Text + "','" + telno13.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (family14.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname14.Text + "','" + family14.Text + "','" + telno14.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (family15.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname15.Text + "','" + family15.Text + "','" + telno15.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (family16.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname16.Text + "','" + family16.Text + "','" + telno16.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (family17.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname17.Text + "','" + family17.Text + "','" + telno17.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (family18.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname18.Text + "','" + family18.Text + "','" + telno18.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if (family19.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname19.Text + "','" + family19.Text + "','" + telno19.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            if (family20.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname20.Text + "','" + family20.Text + "','" + telno20.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button91_Click(object sender, EventArgs e)
        {
            if (family21.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname21.Text + "','" + family21.Text + "','" + telno21.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            if (family22.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname22.Text + "','" + family22.Text + "','" + telno22.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            if (family23.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname23.Text + "','" + family23.Text + "','" + telno23.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            if (family24.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname24.Text + "','" + family24.Text + "','" + telno24.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            if (family25.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname25.Text + "','" + family25.Text + "','" + telno25.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            if (family26.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname26.Text + "','" + family26.Text + "','" + telno26.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            if (family27.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname27.Text + "','" + family27.Text + "','" + telno27.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            if (family28.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname28.Text + "','" + family28.Text + "','" + telno28.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (family29.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname29.Text + "','" + family29.Text + "','" + telno29.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            if (family30.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname30.Text + "','" + family30.Text + "','" + telno30.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (family31.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname31.Text + "','" + family31.Text + "','" + telno31.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            if (family32.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname32.Text + "','" + family32.Text + "','" + telno32.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (family33.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname33.Text + "','" + family33.Text + "','" + telno33.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (family34.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname34.Text + "','" + family34.Text + "','" + telno34.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (family35.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname35.Text + "','" + family35.Text + "','" + telno35.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (family36.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname36.Text + "','" + family36.Text + "','" + telno36.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (family37.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname37.Text + "','" + family37.Text + "','" + telno37.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (family38.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname38.Text + "','" + family38.Text + "','" + telno38.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void paziresh1_Click(object sender, EventArgs e)
        {
            if (family1.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;

            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname1.Text + "' and lname = '" + family1.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname1.Text + "' and mname = '" + family1.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname1.Text;
                Search2.search2_family = family1.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname1.Text + "','" + family1.Text + "','" + family1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname1.Text + "','" + family1.Text + "','" + family1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }

            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();

           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select acc from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                string s ="";
                while(data.Read())
                    s = data["acc"].ToString();
                data.Close();

                sqlconn.Close();

                System.Diagnostics.Process.Start(s);
            }
            catch
            {
                MessageBox.Show("Please first install 'Advanced Call Center' then go to setting and browse...", "Notification");
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select answering from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                string s = "";
                while (data.Read())
                    s = data["answering"].ToString();
                data.Close();

                sqlconn.Close();

                System.Diagnostics.Process.Start(s);
            }
            catch
            {
                MessageBox.Show("Please first install from any automating answering software program, then go to setting and browse...","Notification");
            }
        }

        private void nobat_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            cm_menu.Visible = false;
        }

        private void hour54_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (family2.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname2.Text + "' and lname = '" + family2.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname2.Text + "' and mname = '" + family2.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname2.Text;
                Search2.search2_family = family2.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname2.Text + "','" + family2.Text + "','" + family2.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname2.Text + "','" + family2.Text + "','" + family2.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (family3.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname3.Text + "' and lname = '" + family3.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname3.Text + "' and mname = '" + family3.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname3.Text;
                Search2.search2_family = family3.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname3.Text + "','" + family3.Text + "','" + family3.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname3.Text + "','" + family3.Text + "','" + family3.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (family4.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname4.Text + "' and lname = '" + family4.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname4.Text + "' and mname = '" + family4.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname4.Text;
                Search2.search2_family = family4.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname4.Text + "','" + family4.Text + "','" + family4.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname4.Text + "','" + family4.Text + "','" + family4.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (family5.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname5.Text + "' and lname = '" + family5.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname5.Text + "' and mname = '" + family5.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname5.Text;
                Search2.search2_family = family5.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname5.Text + "','" + family5.Text + "','" + family5.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname5.Text + "','" + family5.Text + "','" + family5.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (family6.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname6.Text + "' and lname = '" + family6.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname6.Text + "' and mname = '" + family6.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname6.Text;
                Search2.search2_family = family6.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname6.Text + "','" + family6.Text + "','" + family6.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname6.Text + "','" + family6.Text + "','" + family6.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (family7.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname7.Text + "' and lname = '" + family7.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname7.Text + "' and mname = '" + family7.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname7.Text;
                Search2.search2_family = family7.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname7.Text + "','" + family7.Text + "','" + family7.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname7.Text + "','" + family7.Text + "','" + family7.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (family8.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname8.Text + "' and lname = '" + family8.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname8.Text + "' and mname = '" + family8.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname8.Text;
                Search2.search2_family = family8.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname8.Text + "','" + family8.Text + "','" + family8.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname8.Text + "','" + family8.Text + "','" + family8.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (family9.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname9.Text + "' and lname = '" + family9.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname9.Text + "' and mname = '" + family9.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname9.Text;
                Search2.search2_family = family9.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname9.Text + "','" + family9.Text + "','" + family9.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname9.Text + "','" + family9.Text + "','" + family9.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (family10.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname10.Text + "' and lname = '" + family10.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname10.Text + "' and mname = '" + family10.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname10.Text;
                Search2.search2_family = family10.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname10.Text + "','" + family10.Text + "','" + family10.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname10.Text + "','" + family10.Text + "','" + family10.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (family11.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname11.Text + "' and lname = '" + family11.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname11.Text + "' and mname = '" + family11.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname11.Text;
                Search2.search2_family = family11.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname11.Text + "','" + family11.Text + "','" + family11.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname11.Text + "','" + family11.Text + "','" + family11.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (family12.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname12.Text + "' and lname = '" + family12.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname12.Text + "' and mname = '" + family12.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname12.Text;
                Search2.search2_family = family12.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname12.Text + "','" + family12.Text + "','" + family12.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname12.Text + "','" + family12.Text + "','" + family12.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (family13.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname13.Text + "' and lname = '" + family13.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname13.Text + "' and mname = '" + family13.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname13.Text;
                Search2.search2_family = family13.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname13.Text + "','" + family13.Text + "','" + family13.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname13.Text + "','" + family13.Text + "','" + family13.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (family14.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname14.Text + "' and lname = '" + family14.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname14.Text + "' and mname = '" + family14.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname14.Text;
                Search2.search2_family = family14.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname14.Text + "','" + family14.Text + "','" + family14.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname14.Text + "','" + family14.Text + "','" + family14.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (family15.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname15.Text + "' and lname = '" + family15.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname15.Text + "' and mname = '" + family15.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname15.Text;
                Search2.search2_family = family15.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname15.Text + "','" + family15.Text + "','" + family15.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname15.Text + "','" + family15.Text + "','" + family15.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (family16.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname16.Text + "' and lname = '" + family16.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname16.Text + "' and mname = '" + family16.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname16.Text;
                Search2.search2_family = family16.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname16.Text + "','" + family16.Text + "','" + family16.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname16.Text + "','" + family16.Text + "','" + family16.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (family17.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname17.Text + "' and lname = '" + family17.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname17.Text + "' and mname = '" + family17.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname17.Text;
                Search2.search2_family = family17.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname17.Text + "','" + family17.Text + "','" + family17.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname17.Text + "','" + family17.Text + "','" + family17.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (family18.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname18.Text + "' and lname = '" + family18.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname18.Text + "' and mname = '" + family18.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname18.Text;
                Search2.search2_family = family18.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname18.Text + "','" + family18.Text + "','" + family18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname18.Text + "','" + family18.Text + "','" + family18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (family19.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname19.Text + "' and lname = '" + family19.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname19.Text + "' and mname = '" + family19.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname19.Text;
                Search2.search2_family = family19.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname19.Text + "','" + family19.Text + "','" + family19.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname19.Text + "','" + family19.Text + "','" + family19.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button93_Click(object sender, EventArgs e)
        {
            if (family20.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname20.Text + "' and lname = '" + family20.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname20.Text + "' and mname = '" + family20.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname20.Text;
                Search2.search2_family = family20.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname20.Text + "','" + family20.Text + "','" + family20.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname20.Text + "','" + family20.Text + "','" + family20.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button90_Click(object sender, EventArgs e)
        {
            if (family21.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname21.Text + "' and lname = '" + family21.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname21.Text + "' and mname = '" + family21.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname21.Text;
                Search2.search2_family = family21.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname21.Text + "','" + family21.Text + "','" + family21.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname21.Text + "','" + family21.Text + "','" + family21.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            if (family22.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname22.Text + "' and lname = '" + family22.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname22.Text + "' and mname = '" + family22.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname22.Text;
                Search2.search2_family = family22.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname22.Text + "','" + family22.Text + "','" + family22.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname22.Text + "','" + family22.Text + "','" + family22.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            if (family23.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname23.Text + "' and lname = '" + family23.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname23.Text + "' and mname = '" + family23.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname23.Text;
                Search2.search2_family = family23.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname23.Text + "','" + family23.Text + "','" + family23.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname23.Text + "','" + family23.Text + "','" + family23.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            if (family24.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname24.Text + "' and lname = '" + family24.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname24.Text + "' and mname = '" + family24.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname24.Text;
                Search2.search2_family = family24.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname24.Text + "','" + family24.Text + "','" + family24.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname24.Text + "','" + family24.Text + "','" + family24.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            if (family25.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname25.Text + "' and lname = '" + family25.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname25.Text + "' and mname = '" + family25.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname25.Text;
                Search2.search2_family = family25.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname25.Text + "','" + family25.Text + "','" + family25.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname25.Text + "','" + family25.Text + "','" + family25.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            if (family26.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname26.Text + "' and lname = '" + family26.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname26.Text + "' and mname = '" + family26.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname26.Text;
                Search2.search2_family = family26.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname26.Text + "','" + family26.Text + "','" + family26.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname26.Text + "','" + family26.Text + "','" + family26.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            if (family27.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname27.Text + "' and lname = '" + family27.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname27.Text + "' and mname = '" + family27.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname27.Text;
                Search2.search2_family = family27.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname27.Text + "','" + family27.Text + "','" + family27.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname27.Text + "','" + family27.Text + "','" + family27.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            if (family28.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname28.Text + "' and lname = '" + family28.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname28.Text + "' and mname = '" + family28.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname28.Text;
                Search2.search2_family = family28.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname28.Text + "','" + family28.Text + "','" + family28.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname28.Text + "','" + family28.Text + "','" + family28.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (family29.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname29.Text + "' and lname = '" + family29.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname29.Text + "' and mname = '" + family29.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname29.Text;
                Search2.search2_family = family29.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname29.Text + "','" + family29.Text + "','" + family29.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname29.Text + "','" + family29.Text + "','" + family29.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (family30.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname30.Text + "' and lname = '" + family30.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname30.Text + "' and mname = '" + family30.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname30.Text;
                Search2.search2_family = family30.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname30.Text + "','" + family30.Text + "','" + family30.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname30.Text + "','" + family30.Text + "','" + family30.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (family31.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname31.Text + "' and lname = '" + family31.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname31.Text + "' and mname = '" + family31.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname31.Text;
                Search2.search2_family = family31.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname31.Text + "','" + family31.Text + "','" + family31.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname31.Text + "','" + family31.Text + "','" + family31.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (family32.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname32.Text + "' and lname = '" + family32.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname32.Text + "' and mname = '" + family32.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname32.Text;
                Search2.search2_family = family32.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname32.Text + "','" + family32.Text + "','" + family32.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname32.Text + "','" + family32.Text + "','" + family32.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (family33.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname33.Text + "' and lname = '" + family33.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname33.Text + "' and mname = '" + family33.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname33.Text;
                Search2.search2_family = family33.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname33.Text + "','" + family33.Text + "','" + family33.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname33.Text + "','" + family33.Text + "','" + family33.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (family34.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname34.Text + "' and lname = '" + family34.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname34.Text + "' and mname = '" + family34.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname34.Text;
                Search2.search2_family = family34.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname34.Text + "','" + family34.Text + "','" + family34.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname34.Text + "','" + family34.Text + "','" + family34.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (family35.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname35.Text + "' and lname = '" + family35.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname35.Text + "' and mname = '" + family35.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname35.Text;
                Search2.search2_family = family35.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname35.Text + "','" + family35.Text + "','" + family35.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname35.Text + "','" + family35.Text + "','" + family35.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (family36.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname36.Text + "' and lname = '" + family36.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname36.Text + "' and mname = '" + family36.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname36.Text;
                Search2.search2_family = family36.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname36.Text + "','" + family36.Text + "','" + family36.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname36.Text + "','" + family36.Text + "','" + family36.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (family37.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname37.Text + "' and lname = '" + family37.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname37.Text + "' and mname = '" + family37.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname37.Text;
                Search2.search2_family = family37.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname37.Text + "','" + family37.Text + "','" + family37.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname37.Text + "','" + family37.Text + "','" + family37.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (family38.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname38.Text + "' and lname = '" + family38.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname38.Text + "' and mname = '" + family38.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname38.Text;
                Search2.search2_family = family38.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname38.Text + "','" + family38.Text + "','" + family38.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname38.Text + "','" + family38.Text + "','" + family38.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 38)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 37)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button110_Click(object sender, EventArgs e)
        {
            if (family39.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname39.Text + "','" + family39.Text + "','" + telno39.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button107_Click(object sender, EventArgs e)
        {
            if (family40.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname40.Text + "','" + family40.Text + "','" + telno40.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button104_Click(object sender, EventArgs e)
        {
            if (family41.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname41.Text + "','" + family41.Text + "','" + telno41.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button101_Click(object sender, EventArgs e)
        {
            if (family42.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname42.Text + "','" + family42.Text + "','" + telno42.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button98_Click(object sender, EventArgs e)
        {
            if (family43.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname43.Text + "','" + family43.Text + "','" + telno43.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (family44.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname44.Text + "','" + family44.Text + "','" + telno44.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button128_Click(object sender, EventArgs e)
        {
            if (family45.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname45.Text + "','" + family45.Text + "','" + telno45.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button125_Click(object sender, EventArgs e)
        {
            if (family46.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname46.Text + "','" + family46.Text + "','" + telno46.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button122_Click(object sender, EventArgs e)
        {
            if (family47.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname47.Text + "','" + family47.Text + "','" + telno47.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button119_Click(object sender, EventArgs e)
        {
            if (family48.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname48.Text + "','" + family48.Text + "','" + telno48.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button116_Click(object sender, EventArgs e)
        {
            if (family49.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname49.Text + "','" + family49.Text + "','" + telno49.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button113_Click(object sender, EventArgs e)
        {
            if (family50.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname50.Text + "','" + family50.Text + "','" + telno50.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button185_Click(object sender, EventArgs e)
        {
            if (family51.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname51.Text + "','" + family51.Text + "','" + telno51.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button182_Click(object sender, EventArgs e)
        {
            if (family52.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname52.Text + "','" + family52.Text + "','" + telno52.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button179_Click(object sender, EventArgs e)
        {
            if (family53.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname53.Text + "','" + family53.Text + "','" + telno53.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button176_Click(object sender, EventArgs e)
        {
            if (family54.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname54.Text + "','" + family54.Text + "','" + telno54.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button173_Click(object sender, EventArgs e)
        {
            if (family55.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname55.Text + "','" + family55.Text + "','" + telno55.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button170_Click(object sender, EventArgs e)
        {
            if (family56.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname56.Text + "','" + family56.Text + "','" + telno56.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button167_Click(object sender, EventArgs e)
        {
            if (family57.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname57.Text + "','" + family57.Text + "','" + telno57.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button164_Click(object sender, EventArgs e)
        {
            if (family58.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname58.Text + "','" + family58.Text + "','" + telno58.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button161_Click(object sender, EventArgs e)
        {
            if (family59.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname59.Text + "','" + family59.Text + "','" + telno59.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button158_Click(object sender, EventArgs e)
        {
            if (family60.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname60.Text + "','" + family60.Text + "','" + telno60.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button155_Click(object sender, EventArgs e)
        {
            if (family61.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname61.Text + "','" + family61.Text + "','" + telno61.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button152_Click(object sender, EventArgs e)
        {
            if (family62.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname62.Text + "','" + family62.Text + "','" + telno62.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button149_Click(object sender, EventArgs e)
        {
            if (family63.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname63.Text + "','" + family63.Text + "','" + telno63.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button146_Click(object sender, EventArgs e)
        {
            if (family64.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname64.Text + "','" + family64.Text + "','" + telno64.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button143_Click(object sender, EventArgs e)
        {
            if (family65.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname65.Text + "','" + family65.Text + "','" + telno65.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button140_Click(object sender, EventArgs e)
        {
            if (family66.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname66.Text + "','" + family66.Text + "','" + telno66.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button137_Click(object sender, EventArgs e)
        {
            if (family67.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname67.Text + "','" + family67.Text + "','" + telno67.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button134_Click(object sender, EventArgs e)
        {
            if (family68.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname68.Text + "','" + family68.Text + "','" + telno68.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button131_Click(object sender, EventArgs e)
        {
            if (family69.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname69.Text + "','" + family69.Text + "','" + telno69.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button242_Click(object sender, EventArgs e)
        {
            if (family70.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname70.Text + "','" + family70.Text + "','" + telno70.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button239_Click(object sender, EventArgs e)
        {
            if (family71.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname71.Text + "','" + family71.Text + "','" + telno71.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button236_Click(object sender, EventArgs e)
        {
            if (family72.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname72.Text + "','" + family72.Text + "','" + telno72.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button233_Click(object sender, EventArgs e)
        {
            if (family73.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname73.Text + "','" + family73.Text + "','" + telno73.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button230_Click(object sender, EventArgs e)
        {
            if (family74.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname74.Text + "','" + family74.Text + "','" + telno74.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button227_Click(object sender, EventArgs e)
        {
            if (family75.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname75.Text + "','" + family75.Text + "','" + telno75.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button224_Click(object sender, EventArgs e)
        {
            if (family76.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname76.Text + "','" + family76.Text + "','" + telno76.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button221_Click(object sender, EventArgs e)
        {
            if (family77.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname77.Text + "','" + family77.Text + "','" + telno77.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button218_Click(object sender, EventArgs e)
        {
            if (family78.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname78.Text + "','" + family78.Text + "','" + telno78.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button215_Click(object sender, EventArgs e)
        {
            if (family79.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname79.Text + "','" + family79.Text + "','" + telno79.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button212_Click(object sender, EventArgs e)
        {
            if (family80.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname80.Text + "','" + family80.Text + "','" + telno80.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button209_Click(object sender, EventArgs e)
        {
            if (family81.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname81.Text + "','" + family81.Text + "','" + telno81.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button206_Click(object sender, EventArgs e)
        {
            if (family82.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname82.Text + "','" + family82.Text + "','" + telno82.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button203_Click(object sender, EventArgs e)
        {
            if (family83.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname83.Text + "','" + family83.Text + "','" + telno83.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button200_Click(object sender, EventArgs e)
        {
            if (family84.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname84.Text + "','" + family84.Text + "','" + telno84.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button197_Click(object sender, EventArgs e)
        {
            if (family85.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname85.Text + "','" + family85.Text + "','" + telno85.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button194_Click(object sender, EventArgs e)
        {
            if (family86.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname86.Text + "','" + family86.Text + "','" + telno86.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button191_Click(object sender, EventArgs e)
        {
            if (family87.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname87.Text + "','" + family87.Text + "','" + telno87.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button188_Click(object sender, EventArgs e)
        {
            if (family88.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname88.Text + "','" + family88.Text + "','" + telno88.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button299_Click(object sender, EventArgs e)
        {
            if (family89.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname89.Text + "','" + family89.Text + "','" + telno89.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button296_Click(object sender, EventArgs e)
        {
            if (family90.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname90.Text + "','" + family90.Text + "','" + telno90.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button293_Click(object sender, EventArgs e)
        {
            if (family91.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname91.Text + "','" + family91.Text + "','" + telno91.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button290_Click(object sender, EventArgs e)
        {
            if (family92.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname92.Text + "','" + family92.Text + "','" + telno92.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button287_Click(object sender, EventArgs e)
        {
            if (family93.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname93.Text + "','" + family93.Text + "','" + telno93.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button284_Click(object sender, EventArgs e)
        {
            if (family94.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname94.Text + "','" + family94.Text + "','" + telno94.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button281_Click(object sender, EventArgs e)
        {
            if (family95.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname95.Text + "','" + family95.Text + "','" + telno95.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button278_Click(object sender, EventArgs e)
        {
            if (family96.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname96.Text + "','" + family96.Text + "','" + telno96.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button275_Click(object sender, EventArgs e)
        {
            if (family97.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname97.Text + "','" + family97.Text + "','" + telno97.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button272_Click(object sender, EventArgs e)
        {
            if (family98.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname98.Text + "','" + family98.Text + "','" + telno98.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button269_Click(object sender, EventArgs e)
        {
            if (family99.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname99.Text + "','" + family99.Text + "','" + telno99.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button266_Click(object sender, EventArgs e)
        {
            if (family100.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname100.Text + "','" + family100.Text + "','" + telno100.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button263_Click(object sender, EventArgs e)
        {
            if (family101.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname101.Text + "','" + family101.Text + "','" + telno101.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button260_Click(object sender, EventArgs e)
        {
            if (family102.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname102.Text + "','" + family102.Text + "','" + telno102.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button257_Click(object sender, EventArgs e)
        {
            if (family103.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname103.Text + "','" + family103.Text + "','" + telno103.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button254_Click(object sender, EventArgs e)
        {
            if (family104.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname104.Text + "','" + family104.Text + "','" + telno104.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button251_Click(object sender, EventArgs e)
        {
            if (family105.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname105.Text + "','" + family105.Text + "','" + telno105.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button248_Click(object sender, EventArgs e)
        {
            if (family106.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname106.Text + "','" + family106.Text + "','" + telno106.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button245_Click(object sender, EventArgs e)
        {
            if (family107.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname107.Text + "','" + family107.Text + "','" + telno107.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button356_Click(object sender, EventArgs e)
        {
            if (family108.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname108.Text + "','" + family108.Text + "','" + telno108.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button353_Click(object sender, EventArgs e)
        {
            if (family109.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname109.Text + "','" + family109.Text + "','" + telno109.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button350_Click(object sender, EventArgs e)
        {
            if (family110.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname110.Text + "','" + family110.Text + "','" + telno110.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button347_Click(object sender, EventArgs e)
        {
            if (family111.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname111.Text + "','" + family111.Text + "','" + telno111.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button344_Click(object sender, EventArgs e)
        {
            if (family112.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname112.Text + "','" + family112.Text + "','" + telno112.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button341_Click(object sender, EventArgs e)
        {
            if (family113.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname113.Text + "','" + family113.Text + "','" + telno113.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button3114_Click(object sender, EventArgs e)
        {
           
        }

        private void button3115_Click(object sender, EventArgs e)
        {
          
        }

        private void button338_Click(object sender, EventArgs e)
        {
            if (family114.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname114.Text + "','" + family114.Text + "','" + telno114.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button335_Click(object sender, EventArgs e)
        {
            if (family115.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname115.Text + "','" + family115.Text + "','" + telno115.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button332_Click(object sender, EventArgs e)
        {
            if (family116.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname116.Text + "','" + family116.Text + "','" + telno116.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button329_Click(object sender, EventArgs e)
        {
            if (family117.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname117.Text + "','" + family117.Text + "','" + telno117.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button326_Click(object sender, EventArgs e)
        {
            if (family118.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname118.Text + "','" + family118.Text + "','" + telno118.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button323_Click(object sender, EventArgs e)
        {
            if (family119.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname119.Text + "','" + family119.Text + "','" + telno119.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button320_Click(object sender, EventArgs e)
        {
            if (family120.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname120.Text + "','" + family120.Text + "','" + telno120.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button317_Click(object sender, EventArgs e)
        {
            if (family121.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname121.Text + "','" + family121.Text + "','" + telno121.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button314_Click(object sender, EventArgs e)
        {
            if (family122.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname122.Text + "','" + family122.Text + "','" + telno122.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button311_Click(object sender, EventArgs e)
        {
            if (family123.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname123.Text + "','" + family123.Text + "','" + telno123.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button308_Click(object sender, EventArgs e)
        {
            if (family124.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into tel(fname,family,tel1,profession,job) values('" + fname124.Text + "','" + family124.Text + "','" + telno124.Text + "','Patient','بيمار') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button109_Click(object sender, EventArgs e)
        {
            if (family39.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname39.Text + "' and lname = '" + family39.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname39.Text + "' and mname = '" + family39.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname39.Text;
                Search2.search2_family = family39.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname39.Text + "','" + family39.Text + "','" + family39.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname39.Text + "','" + family39.Text + "','" + family39.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button106_Click(object sender, EventArgs e)
        {
            if (family40.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname40.Text + "' and lname = '" + family40.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname40.Text + "' and mname = '" + family40.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname40.Text;
                Search2.search2_family = family40.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname40.Text + "','" + family40.Text + "','" + family40.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname40.Text + "','" + family40.Text + "','" + family40.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button103_Click(object sender, EventArgs e)
        {
            if (family41.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname41.Text + "' and lname = '" + family41.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname41.Text + "' and mname = '" + family41.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname41.Text;
                Search2.search2_family = family41.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname41.Text + "','" + family41.Text + "','" + family41.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname41.Text + "','" + family41.Text + "','" + family41.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button100_Click(object sender, EventArgs e)
        {
            if (family42.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname42.Text + "' and lname = '" + family42.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname42.Text + "' and mname = '" + family42.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname42.Text;
                Search2.search2_family = family42.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname42.Text + "','" + family42.Text + "','" + family42.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname42.Text + "','" + family42.Text + "','" + family42.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button97_Click(object sender, EventArgs e)
        {
            if (family43.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname43.Text + "' and lname = '" + family43.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname43.Text + "' and mname = '" + family43.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname43.Text;
                Search2.search2_family = family43.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname43.Text + "','" + family43.Text + "','" + family43.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname43.Text + "','" + family43.Text + "','" + family43.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (family44.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname44.Text + "' and lname = '" + family44.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname44.Text + "' and mname = '" + family44.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname44.Text;
                Search2.search2_family = family44.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname44.Text + "','" + family44.Text + "','" + family44.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname44.Text + "','" + family44.Text + "','" + family44.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button127_Click(object sender, EventArgs e)
        {
            if (family45.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname45.Text + "' and lname = '" + family45.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname45.Text + "' and mname = '" + family45.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname45.Text;
                Search2.search2_family = family45.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname45.Text + "','" + family45.Text + "','" + family45.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname45.Text + "','" + family45.Text + "','" + family45.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button124_Click(object sender, EventArgs e)
        {
            if (family46.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname46.Text + "' and lname = '" + family46.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname46.Text + "' and mname = '" + family46.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname46.Text;
                Search2.search2_family = family46.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname46.Text + "','" + family46.Text + "','" + family46.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname46.Text + "','" + family46.Text + "','" + family46.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button121_Click(object sender, EventArgs e)
        {
            if (family47.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname47.Text + "' and lname = '" + family47.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname47.Text + "' and mname = '" + family47.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname47.Text;
                Search2.search2_family = family47.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname47.Text + "','" + family47.Text + "','" + family47.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname47.Text + "','" + family47.Text + "','" + family47.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button118_Click(object sender, EventArgs e)
        {
            if (family48.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname48.Text + "' and lname = '" + family48.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname48.Text + "' and mname = '" + family48.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname48.Text;
                Search2.search2_family = family48.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname48.Text + "','" + family48.Text + "','" + family48.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname48.Text + "','" + family48.Text + "','" + family48.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button115_Click(object sender, EventArgs e)
        {
            if (family49.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname49.Text + "' and lname = '" + family49.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname49.Text + "' and mname = '" + family49.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname49.Text;
                Search2.search2_family = family49.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname49.Text + "','" + family49.Text + "','" + family49.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname49.Text + "','" + family49.Text + "','" + family49.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button112_Click(object sender, EventArgs e)
        {
            if (family50.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname50.Text + "' and lname = '" + family50.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname50.Text + "' and mname = '" + family50.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname50.Text;
                Search2.search2_family = family50.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname50.Text + "','" + family50.Text + "','" + family50.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname50.Text + "','" + family50.Text + "','" + family50.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button184_Click(object sender, EventArgs e)
        {
            if (family51.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname51.Text + "' and lname = '" + family51.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname51.Text + "' and mname = '" + family51.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname51.Text;
                Search2.search2_family = family51.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname51.Text + "','" + family51.Text + "','" + family51.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname51.Text + "','" + family51.Text + "','" + family51.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button181_Click(object sender, EventArgs e)
        {
            if (family52.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname52.Text + "' and lname = '" + family52.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname52.Text + "' and mname = '" + family52.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname52.Text;
                Search2.search2_family = family52.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname52.Text + "','" + family52.Text + "','" + family52.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname52.Text + "','" + family52.Text + "','" + family52.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button178_Click(object sender, EventArgs e)
        {
            if (family53.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname53.Text + "' and lname = '" + family53.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname53.Text + "' and mname = '" + family53.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname53.Text;
                Search2.search2_family = family53.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname53.Text + "','" + family53.Text + "','" + family53.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname53.Text + "','" + family53.Text + "','" + family53.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button175_Click(object sender, EventArgs e)
        {
            if (family54.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname54.Text + "' and lname = '" + family54.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname54.Text + "' and mname = '" + family54.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname54.Text;
                Search2.search2_family = family54.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname54.Text + "','" + family54.Text + "','" + family54.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname54.Text + "','" + family54.Text + "','" + family54.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button172_Click(object sender, EventArgs e)
        {
            if (family55.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname55.Text + "' and lname = '" + family55.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname55.Text + "' and mname = '" + family55.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname55.Text;
                Search2.search2_family = family55.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname55.Text + "','" + family55.Text + "','" + family55.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname55.Text + "','" + family55.Text + "','" + family55.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button169_Click(object sender, EventArgs e)
        {
            if (family56.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname56.Text + "' and lname = '" + family56.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname56.Text + "' and mname = '" + family56.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname56.Text;
                Search2.search2_family = family56.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname56.Text + "','" + family56.Text + "','" + family56.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname56.Text + "','" + family56.Text + "','" + family56.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button166_Click(object sender, EventArgs e)
        {
            if (family57.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname57.Text + "' and lname = '" + family57.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname57.Text + "' and mname = '" + family57.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname57.Text;
                Search2.search2_family = family57.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname57.Text + "','" + family57.Text + "','" + family57.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname57.Text + "','" + family57.Text + "','" + family57.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button163_Click(object sender, EventArgs e)
        {
            if (family58.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname58.Text + "' and lname = '" + family58.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname58.Text + "' and mname = '" + family58.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname58.Text;
                Search2.search2_family = family58.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname58.Text + "','" + family58.Text + "','" + family58.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname58.Text + "','" + family58.Text + "','" + family58.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button160_Click(object sender, EventArgs e)
        {
            if (family59.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname59.Text + "' and lname = '" + family59.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname59.Text + "' and mname = '" + family59.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname59.Text;
                Search2.search2_family = family59.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname59.Text + "','" + family59.Text + "','" + family59.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname59.Text + "','" + family59.Text + "','" + family59.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button157_Click(object sender, EventArgs e)
        {
            if (family60.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname60.Text + "' and lname = '" + family60.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname60.Text + "' and mname = '" + family60.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname60.Text;
                Search2.search2_family = family60.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname60.Text + "','" + family60.Text + "','" + family60.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname60.Text + "','" + family60.Text + "','" + family60.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button154_Click(object sender, EventArgs e)
        {
            if (family61.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname61.Text + "' and lname = '" + family61.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname61.Text + "' and mname = '" + family61.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname61.Text;
                Search2.search2_family = family61.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname61.Text + "','" + family61.Text + "','" + family61.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname61.Text + "','" + family61.Text + "','" + family61.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button151_Click(object sender, EventArgs e)
        {
            if (family62.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname62.Text + "' and lname = '" + family62.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname62.Text + "' and mname = '" + family62.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname62.Text;
                Search2.search2_family = family62.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname62.Text + "','" + family62.Text + "','" + family62.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname62.Text + "','" + family62.Text + "','" + family62.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button148_Click(object sender, EventArgs e)
        {
            if (family63.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname63.Text + "' and lname = '" + family63.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname63.Text + "' and mname = '" + family63.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname63.Text;
                Search2.search2_family = family63.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname63.Text + "','" + family63.Text + "','" + family63.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname63.Text + "','" + family63.Text + "','" + family63.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button145_Click(object sender, EventArgs e)
        {
            if (family64.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname64.Text + "' and lname = '" + family64.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname64.Text + "' and mname = '" + family64.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname64.Text;
                Search2.search2_family = family64.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname64.Text + "','" + family64.Text + "','" + family64.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname64.Text + "','" + family64.Text + "','" + family64.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button142_Click(object sender, EventArgs e)
        {
            if (family65.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname65.Text + "' and lname = '" + family65.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname65.Text + "' and mname = '" + family65.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname65.Text;
                Search2.search2_family = family65.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname65.Text + "','" + family65.Text + "','" + family65.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname65.Text + "','" + family65.Text + "','" + family65.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button139_Click(object sender, EventArgs e)
        {
            if (family66.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname66.Text + "' and lname = '" + family66.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname66.Text + "' and mname = '" + family66.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname66.Text;
                Search2.search2_family = family66.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname66.Text + "','" + family66.Text + "','" + family66.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname66.Text + "','" + family66.Text + "','" + family66.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button136_Click(object sender, EventArgs e)
        {
            if (family67.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname67.Text + "' and lname = '" + family67.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname67.Text + "' and mname = '" + family67.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname67.Text;
                Search2.search2_family = family67.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname67.Text + "','" + family67.Text + "','" + family67.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname67.Text + "','" + family67.Text + "','" + family67.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button133_Click(object sender, EventArgs e)
        {
            if (family68.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname68.Text + "' and lname = '" + family68.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname68.Text + "' and mname = '" + family68.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname68.Text;
                Search2.search2_family = family68.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname68.Text + "','" + family68.Text + "','" + family68.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname68.Text + "','" + family68.Text + "','" + family68.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button130_Click(object sender, EventArgs e)
        {
            if (family69.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname69.Text + "' and lname = '" + family69.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname69.Text + "' and mname = '" + family69.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname69.Text;
                Search2.search2_family = family69.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname69.Text + "','" + family69.Text + "','" + family69.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname69.Text + "','" + family69.Text + "','" + family69.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button241_Click(object sender, EventArgs e)
        {
            if (family70.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname70.Text + "' and lname = '" + family70.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname70.Text + "' and mname = '" + family70.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname70.Text;
                Search2.search2_family = family70.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname70.Text + "','" + family70.Text + "','" + family70.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname70.Text + "','" + family70.Text + "','" + family70.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

       

        private void button238_Click(object sender, EventArgs e)
        {
            if (family71.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname71.Text + "' and lname = '" + family71.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname71.Text + "' and mname = '" + family71.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname71.Text;
                Search2.search2_family = family71.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname71.Text + "','" + family71.Text + "','" + family71.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname71.Text + "','" + family71.Text + "','" + family71.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button235_Click(object sender, EventArgs e)
        {
            if (family72.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname72.Text + "' and lname = '" + family72.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname72.Text + "' and mname = '" + family72.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname72.Text;
                Search2.search2_family = family72.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname72.Text + "','" + family72.Text + "','" + family72.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname72.Text + "','" + family72.Text + "','" + family72.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button232_Click(object sender, EventArgs e)
        {
            if (family73.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname73.Text + "' and lname = '" + family73.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname73.Text + "' and mname = '" + family73.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname73.Text;
                Search2.search2_family = family73.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname73.Text + "','" + family73.Text + "','" + family73.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname73.Text + "','" + family73.Text + "','" + family73.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button229_Click(object sender, EventArgs e)
        {
            if (family74.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname74.Text + "' and lname = '" + family74.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname74.Text + "' and mname = '" + family74.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname74.Text;
                Search2.search2_family = family74.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname74.Text + "','" + family74.Text + "','" + family74.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname74.Text + "','" + family74.Text + "','" + family74.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button226_Click(object sender, EventArgs e)
        {
            if (family75.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname75.Text + "' and lname = '" + family75.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname75.Text + "' and mname = '" + family75.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname75.Text;
                Search2.search2_family = family75.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname75.Text + "','" + family75.Text + "','" + family75.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname75.Text + "','" + family75.Text + "','" + family75.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button223_Click(object sender, EventArgs e)
        {
            if (family76.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname76.Text + "' and lname = '" + family76.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname76.Text + "' and mname = '" + family76.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname76.Text;
                Search2.search2_family = family76.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname76.Text + "','" + family76.Text + "','" + family76.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname76.Text + "','" + family76.Text + "','" + family76.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button220_Click(object sender, EventArgs e)
        {
            if (family77.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname77.Text + "' and lname = '" + family77.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname77.Text + "' and mname = '" + family77.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname77.Text;
                Search2.search2_family = family77.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname77.Text + "','" + family77.Text + "','" + family77.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname77.Text + "','" + family77.Text + "','" + family77.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button217_Click(object sender, EventArgs e)
        {
            if (family78.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname78.Text + "' and lname = '" + family78.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname78.Text + "' and mname = '" + family78.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname78.Text;
                Search2.search2_family = family78.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname78.Text + "','" + family78.Text + "','" + family78.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname78.Text + "','" + family78.Text + "','" + family78.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button214_Click(object sender, EventArgs e)
        {
            if (family79.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname79.Text + "' and lname = '" + family79.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname79.Text + "' and mname = '" + family79.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname79.Text;
                Search2.search2_family = family79.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname79.Text + "','" + family79.Text + "','" + family79.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname79.Text + "','" + family79.Text + "','" + family79.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button211_Click(object sender, EventArgs e)
        {
            if (family80.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname80.Text + "' and lname = '" + family80.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname80.Text + "' and mname = '" + family80.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname80.Text;
                Search2.search2_family = family80.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname80.Text + "','" + family80.Text + "','" + family80.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname80.Text + "','" + family80.Text + "','" + family80.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button208_Click(object sender, EventArgs e)
        {
            if (family81.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname81.Text + "' and lname = '" + family81.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname81.Text + "' and mname = '" + family81.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname81.Text;
                Search2.search2_family = family81.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname81.Text + "','" + family81.Text + "','" + family81.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname81.Text + "','" + family81.Text + "','" + family81.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button205_Click(object sender, EventArgs e)
        {
            if (family82.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname82.Text + "' and lname = '" + family82.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname82.Text + "' and mname = '" + family82.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname82.Text;
                Search2.search2_family = family82.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname82.Text + "','" + family82.Text + "','" + family82.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname82.Text + "','" + family82.Text + "','" + family82.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button202_Click(object sender, EventArgs e)
        {
            if (family83.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname83.Text + "' and lname = '" + family83.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname83.Text + "' and mname = '" + family83.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname83.Text;
                Search2.search2_family = family83.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname83.Text + "','" + family83.Text + "','" + family83.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname83.Text + "','" + family83.Text + "','" + family83.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button199_Click(object sender, EventArgs e)
        {
            if (family84.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname84.Text + "' and lname = '" + family84.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname84.Text + "' and mname = '" + family84.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname84.Text;
                Search2.search2_family = family84.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname84.Text + "','" + family84.Text + "','" + family84.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname84.Text + "','" + family84.Text + "','" + family84.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button196_Click(object sender, EventArgs e)
        {
            if (family85.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname85.Text + "' and lname = '" + family85.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname85.Text + "' and mname = '" + family85.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname85.Text;
                Search2.search2_family = family85.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname85.Text + "','" + family85.Text + "','" + family85.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname85.Text + "','" + family85.Text + "','" + family85.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button193_Click(object sender, EventArgs e)
        {
            if (family86.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname86.Text + "' and lname = '" + family86.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname86.Text + "' and mname = '" + family86.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname86.Text;
                Search2.search2_family = family86.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname86.Text + "','" + family86.Text + "','" + family86.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname86.Text + "','" + family86.Text + "','" + family86.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button190_Click(object sender, EventArgs e)
        {
            if (family87.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname87.Text + "' and lname = '" + family87.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname87.Text + "' and mname = '" + family87.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname87.Text;
                Search2.search2_family = family87.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname87.Text + "','" + family87.Text + "','" + family87.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname87.Text + "','" + family87.Text + "','" + family87.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button187_Click(object sender, EventArgs e)
        {
            if (family88.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname88.Text + "' and lname = '" + family88.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname88.Text + "' and mname = '" + family88.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname88.Text;
                Search2.search2_family = family88.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname88.Text + "','" + family88.Text + "','" + family88.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname88.Text + "','" + family88.Text + "','" + family88.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button298_Click(object sender, EventArgs e)
        {
            if (family89.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname89.Text + "' and lname = '" + family89.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname89.Text + "' and mname = '" + family89.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname89.Text;
                Search2.search2_family = family89.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname89.Text + "','" + family89.Text + "','" + family89.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname89.Text + "','" + family89.Text + "','" + family89.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button295_Click(object sender, EventArgs e)
        {
            if (family90.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname90.Text + "' and lname = '" + family90.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname90.Text + "' and mname = '" + family90.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname90.Text;
                Search2.search2_family = family90.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname90.Text + "','" + family90.Text + "','" + family90.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname90.Text + "','" + family90.Text + "','" + family90.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button292_Click(object sender, EventArgs e)
        {
            if (family91.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname91.Text + "' and lname = '" + family91.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname91.Text + "' and mname = '" + family91.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname91.Text;
                Search2.search2_family = family91.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname91.Text + "','" + family91.Text + "','" + family91.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname91.Text + "','" + family91.Text + "','" + family91.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button289_Click(object sender, EventArgs e)
        {
            if (family92.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname92.Text + "' and lname = '" + family92.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname92.Text + "' and mname = '" + family92.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname92.Text;
                Search2.search2_family = family92.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname92.Text + "','" + family92.Text + "','" + family92.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname92.Text + "','" + family92.Text + "','" + family92.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button286_Click(object sender, EventArgs e)
        {
            if (family93.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname93.Text + "' and lname = '" + family93.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname93.Text + "' and mname = '" + family93.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname93.Text;
                Search2.search2_family = family93.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname93.Text + "','" + family93.Text + "','" + family93.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname93.Text + "','" + family93.Text + "','" + family93.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button283_Click(object sender, EventArgs e)
        {
            if (family94.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname94.Text + "' and lname = '" + family94.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname94.Text + "' and mname = '" + family94.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname94.Text;
                Search2.search2_family = family94.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname94.Text + "','" + family94.Text + "','" + family94.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname94.Text + "','" + family94.Text + "','" + family94.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button280_Click(object sender, EventArgs e)
        {
            if (family95.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname95.Text + "' and lname = '" + family95.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname95.Text + "' and mname = '" + family95.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname95.Text;
                Search2.search2_family = family95.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname95.Text + "','" + family95.Text + "','" + family95.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname95.Text + "','" + family95.Text + "','" + family95.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button277_Click(object sender, EventArgs e)
        {
            if (family96.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname96.Text + "' and lname = '" + family96.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname96.Text + "' and mname = '" + family96.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname96.Text;
                Search2.search2_family = family96.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname96.Text + "','" + family96.Text + "','" + family96.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname96.Text + "','" + family96.Text + "','" + family96.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button274_Click(object sender, EventArgs e)
        {
            if (family97.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname97.Text + "' and lname = '" + family97.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname97.Text + "' and mname = '" + family97.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname97.Text;
                Search2.search2_family = family97.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname97.Text + "','" + family97.Text + "','" + family97.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname97.Text + "','" + family97.Text + "','" + family97.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button271_Click(object sender, EventArgs e)
        {
            if (family98.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname98.Text + "' and lname = '" + family98.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname98.Text + "' and mname = '" + family98.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname98.Text;
                Search2.search2_family = family98.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname98.Text + "','" + family98.Text + "','" + family98.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname98.Text + "','" + family98.Text + "','" + family98.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button268_Click(object sender, EventArgs e)
        {
            if (family99.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname99.Text + "' and lname = '" + family99.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname99.Text + "' and mname = '" + family99.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname99.Text;
                Search2.search2_family = family99.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname99.Text + "','" + family99.Text + "','" + family99.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname99.Text + "','" + family99.Text + "','" + family99.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button265_Click(object sender, EventArgs e)
        {
            if (family100.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname100.Text + "' and lname = '" + family100.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname100.Text + "' and mname = '" + family100.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname100.Text;
                Search2.search2_family = family100.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname100.Text + "','" + family100.Text + "','" + family100.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname100.Text + "','" + family100.Text + "','" + family100.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button262_Click(object sender, EventArgs e)
        {
            if (family101.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname101.Text + "' and lname = '" + family101.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname101.Text + "' and mname = '" + family101.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname101.Text;
                Search2.search2_family = family101.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname101.Text + "','" + family101.Text + "','" + family101.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname101.Text + "','" + family101.Text + "','" + family101.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button259_Click(object sender, EventArgs e)
        {
            if (family102.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname102.Text + "' and lname = '" + family102.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname102.Text + "' and mname = '" + family102.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname102.Text;
                Search2.search2_family = family102.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname102.Text + "','" + family102.Text + "','" + family102.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname102.Text + "','" + family102.Text + "','" + family102.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button256_Click(object sender, EventArgs e)
        {
            if (family103.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname103.Text + "' and lname = '" + family103.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname103.Text + "' and mname = '" + family103.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname103.Text;
                Search2.search2_family = family103.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname103.Text + "','" + family103.Text + "','" + family103.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname103.Text + "','" + family103.Text + "','" + family103.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button253_Click(object sender, EventArgs e)
        {
            if (family104.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname104.Text + "' and lname = '" + family104.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname104.Text + "' and mname = '" + family104.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname104.Text;
                Search2.search2_family = family104.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname104.Text + "','" + family104.Text + "','" + family104.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname104.Text + "','" + family104.Text + "','" + family104.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button250_Click(object sender, EventArgs e)
        {
            if (family105.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname105.Text + "' and lname = '" + family105.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname105.Text + "' and mname = '" + family105.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname105.Text;
                Search2.search2_family = family105.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname105.Text + "','" + family105.Text + "','" + family105.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname105.Text + "','" + family105.Text + "','" + family105.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button247_Click(object sender, EventArgs e)
        {
            if (family106.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname106.Text + "' and lname = '" + family106.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname106.Text + "' and mname = '" + family106.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname106.Text;
                Search2.search2_family = family106.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname106.Text + "','" + family106.Text + "','" + family106.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname106.Text + "','" + family106.Text + "','" + family106.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button244_Click(object sender, EventArgs e)
        {
            if (family107.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname107.Text + "' and lname = '" + family107.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname107.Text + "' and mname = '" + family107.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname107.Text;
                Search2.search2_family = family107.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname107.Text + "','" + family107.Text + "','" + family107.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname107.Text + "','" + family107.Text + "','" + family107.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button355_Click(object sender, EventArgs e)
        {
            if (family108.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname108.Text + "' and lname = '" + family108.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname108.Text + "' and mname = '" + family108.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname108.Text;
                Search2.search2_family = family108.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname108.Text + "','" + family108.Text + "','" + family108.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname108.Text + "','" + family108.Text + "','" + family108.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button352_Click(object sender, EventArgs e)
        {
            if (family109.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname109.Text + "' and lname = '" + family109.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname109.Text + "' and mname = '" + family109.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname109.Text;
                Search2.search2_family = family109.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname109.Text + "','" + family109.Text + "','" + family109.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname109.Text + "','" + family109.Text + "','" + family109.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button349_Click(object sender, EventArgs e)
        {
            if (family110.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname110.Text + "' and lname = '" + family110.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname110.Text + "' and mname = '" + family110.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname110.Text;
                Search2.search2_family = family110.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname110.Text + "','" + family110.Text + "','" + family110.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname110.Text + "','" + family110.Text + "','" + family110.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button346_Click(object sender, EventArgs e)
        {
            if (family111.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname111.Text + "' and lname = '" + family111.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname111.Text + "' and mname = '" + family111.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname111.Text;
                Search2.search2_family = family111.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname111.Text + "','" + family111.Text + "','" + family111.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname111.Text + "','" + family111.Text + "','" + family111.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button343_Click(object sender, EventArgs e)
        {
            if (family112.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname112.Text + "' and lname = '" + family112.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname112.Text + "' and mname = '" + family112.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname112.Text;
                Search2.search2_family = family112.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname112.Text + "','" + family112.Text + "','" + family112.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname112.Text + "','" + family112.Text + "','" + family112.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button340_Click(object sender, EventArgs e)
        {
            if (family113.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname113.Text + "' and lname = '" + family113.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname113.Text + "' and mname = '" + family113.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname113.Text;
                Search2.search2_family = family113.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname113.Text + "','" + family113.Text + "','" + family113.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname113.Text + "','" + family113.Text + "','" + family113.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button337_Click(object sender, EventArgs e)
        {
            if (family114.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname114.Text + "' and lname = '" + family114.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname114.Text + "' and mname = '" + family114.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname114.Text;
                Search2.search2_family = family114.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname114.Text + "','" + family114.Text + "','" + family114.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname114.Text + "','" + family114.Text + "','" + family114.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button334_Click(object sender, EventArgs e)
        {
            if (family115.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname115.Text + "' and lname = '" + family115.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname115.Text + "' and mname = '" + family115.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname115.Text;
                Search2.search2_family = family115.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname115.Text + "','" + family115.Text + "','" + family115.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname115.Text + "','" + family115.Text + "','" + family115.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button331_Click(object sender, EventArgs e)
        {
            if (family116.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname116.Text + "' and lname = '" + family116.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname116.Text + "' and mname = '" + family116.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname116.Text;
                Search2.search2_family = family116.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname116.Text + "','" + family116.Text + "','" + family116.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname116.Text + "','" + family116.Text + "','" + family116.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button328_Click(object sender, EventArgs e)
        {
            if (family117.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname117.Text + "' and lname = '" + family117.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname117.Text + "' and mname = '" + family117.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname117.Text;
                Search2.search2_family = family117.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname117.Text + "','" + family117.Text + "','" + family117.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname117.Text + "','" + family117.Text + "','" + family117.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button325_Click(object sender, EventArgs e)
        {
            if (family118.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname118.Text + "' and lname = '" + family118.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname118.Text + "' and mname = '" + family118.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname118.Text;
                Search2.search2_family = family118.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname118.Text + "','" + family118.Text + "','" + family118.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname118.Text + "','" + family118.Text + "','" + family118.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button322_Click(object sender, EventArgs e)
        {
            if (family119.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname119.Text + "' and lname = '" + family119.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname119.Text + "' and mname = '" + family119.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname119.Text;
                Search2.search2_family = family119.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname119.Text + "','" + family119.Text + "','" + family119.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname119.Text + "','" + family119.Text + "','" + family119.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button319_Click(object sender, EventArgs e)
        {
            if (family120.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname120.Text + "' and lname = '" + family120.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname120.Text + "' and mname = '" + family120.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname120.Text;
                Search2.search2_family = family120.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname120.Text + "','" + family120.Text + "','" + family120.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname120.Text + "','" + family120.Text + "','" + family120.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button316_Click(object sender, EventArgs e)
        {
            if (family121.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname121.Text + "' and lname = '" + family121.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname121.Text + "' and mname = '" + family121.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname121.Text;
                Search2.search2_family = family121.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname121.Text + "','" + family121.Text + "','" + family121.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname121.Text + "','" + family121.Text + "','" + family121.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button313_Click(object sender, EventArgs e)
        {
            if (family122.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname122.Text + "' and lname = '" + family122.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname122.Text + "' and mname = '" + family122.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname122.Text;
                Search2.search2_family = family122.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname122.Text + "','" + family122.Text + "','" + family122.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname122.Text + "','" + family122.Text + "','" + family122.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button310_Click(object sender, EventArgs e)
        {
            if (family123.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname123.Text + "' and lname = '" + family123.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname123.Text + "' and mname = '" + family123.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname123.Text;
                Search2.search2_family = family123.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname123.Text + "','" + family123.Text + "','" + family123.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname123.Text + "','" + family123.Text + "','" + family123.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button307_Click(object sender, EventArgs e)
        {
            if (family124.Text == "")
                return;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string dr, prf;

            if (login.log_username == "admin")
            {
                int i = 0;
                int l = doctor_c.Text.Length;
                dr = "";
                prf = "";
                if (doctor_c.Text.Contains("-"))
                {
                    i = doctor_c.Text.IndexOf("-");
                    prf = doctor_c.Text.Substring(0, i).Trim();
                    dr = doctor_c.Text.Substring(i + 1, l - i - 1).Trim();
                }
                else
                {
                    dr = doctor_c.Text;
                }
            }
            else
            {
                dr = "دكتر " + login.log_name + " " + login.log_family;
                prf = login.log_prf;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname124.Text + "' and lname = '" + family124.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname124.Text + "' and mname = '" + family124.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            if (sickcount > 0)
            {
                Search2.search2_fname = fname124.Text;
                Search2.search2_family = family124.Text;
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

                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname124.Text + "','" + family124.Text + "','" + family124.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (conflict == true)
            {
                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();

                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "insert into paziresh(row,date1,fname,family,lname,visit,consult,service1,service2,income,ret,doctor,prf) values('" + cnt.ToString() + "','" + today + "','" + fname124.Text + "','" + family124.Text + "','" + family124.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + dr + "','" + prf + "')";
                sqlcmd.ExecuteNonQuery();
                conflict = false;
            }
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void add20_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 20)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button92_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 21)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button89_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 22)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button86_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 23)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button83_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 24)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button80_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 25)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 26)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 27)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 28)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 29)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 30)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 31)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 32)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 33)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 34)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 35)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 36)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button111_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 39)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button108_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 40)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button105_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 41)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button102_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 42)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button99_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 43)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 44)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button129_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 45)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button126_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 46)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button123_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 47)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button120_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 48)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button117_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 49)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button114_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 50)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button186_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 51)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button183_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 52)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button180_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 53)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button177_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 54)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button174_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 55)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button171_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 56)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button168_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 57)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button165_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 58)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button162_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 59)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button159_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 60)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button156_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 61)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button153_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 62)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button150_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 63)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button147_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 64)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button144_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 65)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button141_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 66)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button138_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 67)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button135_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 68)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button132_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 69)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button243_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 70)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button240_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 71)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button237_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 72)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button234_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 73)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button231_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 74)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button228_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 75)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button225_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 76)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button222_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 77)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button219_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 78)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button216_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 79)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button213_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 80)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button210_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 81)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button207_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 82)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button204_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 83)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button201_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 84)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button198_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 85)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button195_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 86)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button192_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 87)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button189_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 88)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button300_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 89)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button297_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 90)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button294_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 91)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button291_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 92)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button288_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 93)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button285_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 94)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button282_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 95)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button279_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 96)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button276_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 97)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button273_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 98)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button270_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 99)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button267_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 100)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button264_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 101)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button261_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 102)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button258_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 103)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button255_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 104)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button252_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 105)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button249_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 106)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button246_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 107)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button357_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 108)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button354_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 109)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button351_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 110)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button348_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 111)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button345_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 112)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button342_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 113)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button339_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 114)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button336_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 115)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button333_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 116)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button330_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 117)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button327_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 118)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button324_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 119)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button321_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 120)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button318_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 121)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button315_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 122)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button312_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 123)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void button309_Click(object sender, EventArgs e)
        {
            int i = cnt1 + cnt2 + disp;
            disp++;
            string txt;
            while (i > 124)
            {
                foreach (Control c1 in panel1.Controls)
                {
                    if (c1.Name == "hour" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "hour" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "fname" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "fname" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "family" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "family" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }
                    if (c1.Name == "telno" + i.ToString())
                    {
                        txt = c1.Text;
                        c1.Text = "";
                        foreach (Control c2 in panel1.Controls)
                        {
                            if (c2.Name == "telno" + (i + 1).ToString())
                            {
                                c2.Text = txt;
                            }
                        }

                    }

                }
                i--;
            }
        }

        private void doctor_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (doctor_c.SelectedIndex)
            {
                case 0:
                    {
                        panel1.BackColor = System.Drawing.Color.Linen;
                        break;
                    }
                case 1:
                    {
                        panel1.BackColor = System.Drawing.Color.Khaki;
                        break;
                    }
                case 2:
                    {
                        panel1.BackColor = System.Drawing.Color.Silver;
                        break;
                    }
                case 3:
                    {
                        panel1.BackColor = System.Drawing.Color.Gainsboro;
                        break;
                    }
                case 4:
                    {
                        panel1.BackColor = System.Drawing.Color.LightPink;
                        break;
                    }
                case 5:
                    {
                        panel1.BackColor = System.Drawing.Color.MediumPurple;
                        break;
                    }
                case 6:
                    {
                        panel1.BackColor = System.Drawing.Color.Thistle;
                        break;
                    }
                case 7:
                    {
                        panel1.BackColor = System.Drawing.Color.LightGray;
                        break;
                    }
                case 8:
                    {
                        panel1.BackColor = System.Drawing.Color.LightSkyBlue;
                        break;
                    }
                case 9:
                    {
                        panel1.BackColor = System.Drawing.Color.Pink;
                        break;
                    }
                case 10:
                    {
                        panel1.BackColor = System.Drawing.Color.SkyBlue;
                        break;
                    }
                case 11:
                    {
                        panel1.BackColor = System.Drawing.Color.SlateGray;
                        break;
                    }
                case 12:
                    {
                        panel1.BackColor = System.Drawing.Color.SlateBlue;
                        break;
                    }
                case 13:
                    {
                        panel1.BackColor = System.Drawing.Color.PowderBlue;
                        break;
                    }
                case 14:
                    {
                        panel1.BackColor = System.Drawing.Color.LightCyan;
                        break;
                    }
                case 15:
                    {
                        panel1.BackColor = System.Drawing.Color.PaleGreen;
                        break;
                    }
                case 16:
                    {
                        panel1.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    }
                case 17:
                    {
                        panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
                        break;
                    }
                case 18:
                    {
                        panel1.BackColor = System.Drawing.Color.LightYellow;
                        break;
                    }
                case 19:
                    {
                        panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
                        break;
                    }


            }
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
                fname_tmp.AutoCompleteCustomSource.Add(data["fname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct mname from info where mname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                family_tmp.AutoCompleteCustomSource.Add(data["mname"].ToString());
            data.Close();

            fname1.AutoCompleteCustomSource = fname_tmp.AutoCompleteCustomSource;
            fname2.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname3.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname4.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname5.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname6.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname7.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname8.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname9.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname10.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname11.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname12.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname13.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname14.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname15.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname16.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname17.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname18.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname19.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname20.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname21.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname22.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname23.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname24.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname25.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname26.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname27.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname28.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname29.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname30.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname31.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname32.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname33.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname34.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname35.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname36.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname37.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname38.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname39.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname40.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname41.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname42.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname43.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname44.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname45.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname46.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname47.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname48.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname49.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname50.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname51.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname52.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname53.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname54.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname55.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname56.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname57.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname58.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname59.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname60.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname61.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname62.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname63.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname64.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname65.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname66.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname67.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname68.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname69.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname70.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname71.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname72.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname73.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname74.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;
            fname75.AutoCompleteCustomSource = fname1.AutoCompleteCustomSource;


            family1.AutoCompleteCustomSource = family_tmp.AutoCompleteCustomSource;
            family2.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family3.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family4.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family5.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family6.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family7.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family8.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family9.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family10.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family11.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family12.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family13.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family14.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family15.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family16.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family17.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family18.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family19.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family20.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family21.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family22.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family23.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family24.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family25.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family26.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family27.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family28.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family29.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family30.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family31.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family32.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family33.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family34.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family35.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family36.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family37.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family38.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family39.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family40.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family41.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family42.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family43.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family44.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family45.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family46.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family47.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family48.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family49.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family50.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family51.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family52.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family53.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family54.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family55.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family56.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family57.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family58.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family59.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family60.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family61.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family62.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family63.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family64.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family65.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family66.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family67.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family68.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family69.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family70.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family71.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family72.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family73.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family74.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;
            family75.AutoCompleteCustomSource = family1.AutoCompleteCustomSource;

            sqlconn.Close();

            timer1.Enabled = false;
        }
    }
}