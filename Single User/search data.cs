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
    public partial class search_data : Form
    {
        private static int num_check, num_check2;
        private static string[] str_par;// = new string[];
        public search_data()
        {
            InitializeComponent();
        }

        private void search_data_Load(object sender, EventArgs e)
        {
            string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;

            if (login.log_username != "admin")
            {
                doctor_t.ReadOnly = true;
                
                doctor_t.Text = "دكتر " + login.log_name + " " + login.log_family;
                doctor_ch.Checked = true;
                doctor_ch.Enabled = false;
            }
            int i;
            num_check = 0;
            num_check2 = 0;
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

            if (login.log_username == "admin")
            {
                sqlcmd.CommandText = "select count(*) from sick1 ";
                total_t.Text = sqlcmd.ExecuteScalar().ToString();
            }
            else
            {
                sqlcmd.CommandText = "select count(*) from sick1 where doctor = '"+ mytemp2 +"' ";
                total_t.Text = sqlcmd.ExecuteScalar().ToString();
            }
            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                for (i = 0; i < 6; i++)
                    dataGridView1.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
            }
            data.Close();

            //Added for size of array
            str_par = new string[Int64.Parse(total_t.Text) + 10];

            string s;
            i = 0;
            sqlcmd.CommandText = "select distinct doctor from sick1 where doctor<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["doctor"].ToString();
                doctor_t.AutoCompleteCustomSource.Add(s);
                doctor_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
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

            i = 0;
            sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["bplace"].ToString();
                bplace_t.AutoCompleteCustomSource.Add(s);
                bplace_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct job from info where job<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["job"].ToString();
                job_t.AutoCompleteCustomSource.Add(s);
                job_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct malol from info where malol<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["malol"].ToString();
                malol_t.AutoCompleteCustomSource.Add(s);
                malol_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct marray from info where marray<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["marray"].ToString();
                marray_t.AutoCompleteCustomSource.Add(s);
                marray_c.Items.Insert(i, s);
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

            i = 0;
            sqlcmd.CommandText = "select distinct life from info where life<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["life"].ToString();
                life_t.AutoCompleteCustomSource.Add(s);
                life_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct busy from info where busy<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["busy"].ToString();
                busy_t.AutoCompleteCustomSource.Add(s);
                busy_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct tahsil from info where tahsil<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["tahsil"].ToString();
                tahsil_t.AutoCompleteCustomSource.Add(s);
                tahsil_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct moaref from info where moaref<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["moaref"].ToString();
                moaref_t.AutoCompleteCustomSource.Add(s);
                moaref_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct city from info where city<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["city"].ToString();
                city_t.AutoCompleteCustomSource.Add(s);
                city_c.Items.Insert(i, s);
                i++;
            }
            data.Close();


            ////////// Second Panel ///////////
            i = 0;
            sqlcmd.CommandText = "select distinct cc from firstvisit where cc<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["cc"].ToString();
                cc_t.AutoCompleteCustomSource.Add(s);
                cc_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct d1 from dx1 where d1<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["d1"].ToString();
                dx_t.AutoCompleteCustomSource.Add(s);
                dx_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct pi from firstvisit where pi<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                pi_t.AutoCompleteCustomSource.Add(data["pi"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct ph from firstvisit where ph<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                ph_t.AutoCompleteCustomSource.Add(data["ph"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct fh from firstvisit where fh<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                fh_t.AutoCompleteCustomSource.Add(data["fh"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct pe from firstvisit where pe<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                pe_t.AutoCompleteCustomSource.Add(data["pe"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct bp from firstvisit where bp<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                bp_t.AutoCompleteCustomSource.Add(data["bp"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct dd from firstvisit where dd<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    dd_t.AutoCompleteCustomSource.Add(data["dd"].ToString());
            //data.Close();

            sqlcmd.CommandText = "select distinct px from firstvisit where px<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                px_t.AutoCompleteCustomSource.Add(data["px"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct rx from firstvisit where rx<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    rx_t.AutoCompleteCustomSource.Add(data["rx"].ToString());
            //data.Close();

            sqlcmd.CommandText = "select distinct ip from firstvisit where ip<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                ip_t.AutoCompleteCustomSource.Add(data["ip"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct op from firstvisit where op<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                op_t.AutoCompleteCustomSource.Add(data["op"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct pc from firstvisit where pc<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    pc_t.AutoCompleteCustomSource.Add(data["pc"].ToString());
            //data.Close();

            //////////////
            sqlcmd.CommandText = "select distinct sb from secondvisit where sb<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                sb_t.AutoCompleteCustomSource.Add(data["sb"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct cc from firstvisit where cc<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["cc"].ToString();
                ncc_t.AutoCompleteCustomSource.Add(s);
                ncc_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct ob from secondvisit where ob<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                ob_t.AutoCompleteCustomSource.Add(data["ob"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct ass from secondvisit where ass<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                as_t.AutoCompleteCustomSource.Add(data["ass"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct pl from secondvisit where pl<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                pl_t.AutoCompleteCustomSource.Add(data["pl"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct dd from secondvisit where dd<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    dd2_t.AutoCompleteCustomSource.Add(data["dd"].ToString());
            //data.Close();

            sqlcmd.CommandText = "select distinct px from secondvisit where px<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                px2_t.AutoCompleteCustomSource.Add(data["px"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct rx from secondvisit where rx<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    rx2_t.AutoCompleteCustomSource.Add(data["rx"].ToString());
            //data.Close();

            sqlcmd.CommandText = "select distinct ip from secondvisit where ip<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                ip2_t.AutoCompleteCustomSource.Add(data["ip"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct op from secondvisit where op<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                op2_t.AutoCompleteCustomSource.Add(data["op"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct co from secondvisit where co<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                co2_t.AutoCompleteCustomSource.Add(data["co"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct pc from secondvisit where pc<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    pc2_t.AutoCompleteCustomSource.Add(data["pc"].ToString());
            //data.Close();

            sqlconn.Close();
        }

        private void search_data_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void title_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (title_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void job_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (job_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void bplace_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (bplace_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void bimeh_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (bimeh_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void marray_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (marray_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void age_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (age_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void bar_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (bar_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void gender_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (gender_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void reception_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (reception_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void city_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (city_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void tahsil_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (tahsil_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void doctor_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (doctor_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (moaref_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (busy_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void life_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (life_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void child_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (child_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void malol_ch_CheckedChanged(object sender, EventArgs e)
        {
             if (malol_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();

            doctor_c.Visible = true;
            title_c.Visible = true;
            bplace_c.Visible = true;
            job_c.Visible = true;
            malol_c.Visible = true;
            gender_c.Visible = true;
            marray_c.Visible = true;
            bar_c.Visible = true;
            bimeh_c.Visible = true;
            life_c.Visible = true;
            busy_c.Visible = true;
            tahsil_c.Visible = true;
            moaref_c.Visible = true;
            city_c.Visible = true;

            doctor_c.Visible = false;
            title_c.Visible = false;
            bplace_c.Visible = false;
            job_c.Visible = false;
            malol_c.Visible = false;
            gender_c.Visible = false;
            marray_c.Visible = false;
            bar_c.Visible = false;
            bimeh_c.Visible = false;
            life_c.Visible = false;
            busy_c.Visible = false;
            tahsil_c.Visible = false;
            moaref_c.Visible = false;
            city_c.Visible = false;

            cc_c.Visible = false;
            dx_c.Visible = false;
            ncc_c.Visible = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool[] array_bool = new bool[50];
            bool sum_bool = false;
            int counter = 0;
            string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;



            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            if (login.log_username == "admin")
            {
                sqlcmd.CommandText = "select * from sick1";
                data = sqlcmd.ExecuteReader();
            }
            else
            {
                sqlcmd.CommandText = "select * from sick1 where doctor = '" + mytemp2 + "'";
                data = sqlcmd.ExecuteReader();
            }
            // where doctor = '" + mytemp2 + "' 
            int i;
            string s = "";
            while (data.Read())
            {
                i = 0;
                if (title_ch.Checked == true)
                {
                    s = data["title"].ToString();
                    if (s == title_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (job_ch.Checked == true)
                {
                    s = data["job"].ToString();
                    if (s.Contains(job_t.Text.Trim()) == true || s == job_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (bplace_ch.Checked == true)
                {
                    s = data["bplace"].ToString();
                    if (s.Contains(bplace_t.Text.Trim()) == true || s == bplace_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (bimeh_ch.Checked == true)
                {
                    s = data["bimeh"].ToString();
                    if (s.Contains(bimeh_t.Text.Trim()) == true || s == bimeh_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                /////////
                if (age_ch.Checked == true)
                {
                    int start, finish;
                    start = 0;
                    finish = 0;

                    s = data["age"].ToString();
                    int year, month, day;
                    day = 0;
                    if (s.Contains("/") == true)
                    {
                        year = Int32.Parse(s.Substring(0, s.IndexOf('/')));
                        s = s.Substring(s.IndexOf('/') + 1, s.Length - s.IndexOf('/') - 1);
                        month = Int32.Parse(s.Substring(0, s.IndexOf('/')));
                        s = s.Substring(s.IndexOf('/') + 1, s.Length - s.IndexOf('/') - 1);
                        day = Int32.Parse(s);

                        day = (year * 365) + (month * 30) + (day);

                        int a, b, c;
                        try
                        {
                            a = Int32.Parse(syear_t.Text);
                        }
                        catch
                        {
                            a = 0;
                        }

                        try
                        {
                            b = Int32.Parse(smonth_t.Text);
                        }
                        catch
                        {
                            b = 0;
                        }

                        try
                        {
                            c = Int32.Parse(sday_t.Text);
                        }
                        catch
                        {
                            c = 0;
                        }

                        start = (a * 365) + (b * 30) + (c);

                        try
                        {
                            a = Int32.Parse(fyear_t.Text);
                        }
                        catch
                        {
                            a = 0;
                        }

                        try
                        {
                            b = Int32.Parse(fmonth_t.Text);
                        }
                        catch
                        {
                            b = 0;
                        }

                        try
                        {
                            c = Int32.Parse(fday_t.Text);
                        }
                        catch
                        {
                            c = 0;
                        }

                        finish = (a * 365) + (b * 30) + (c);


                        if (day >= start && day <= finish)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check; j++)
                                sum_bool = sum_bool && array_bool[j];

                            if (sum_bool == true)
                            {
                                str_par[counter] = data["par"].ToString();
                                counter++;
                            }
                        }
                    }

                }
                /////////
                if (marray_ch.Checked == true)
                {
                    s = data["marray"].ToString();
                    if (s.Contains(marray_t.Text.Trim()) == true || s == marray_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (doctor_ch.Checked == true && login.log_username == "admin")
                {
                    s = data["doctor"].ToString();
                    if (s.Contains(doctor_t.Text.Trim()) == true || s == doctor_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (malol_ch.Checked == true)
                {
                    s = data["malol"].ToString();
                    if (s.Contains(malol_t.Text.Trim()) == true || s == malol_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (gender_ch.Checked == true)
                {
                    s = data["gender"].ToString();
                    if (s.Contains(gender_t.Text.Trim()) == true || s == gender_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (child_ch.Checked == true)
                {
                    s = data["child"].ToString();
                    if (s.Contains(child_t.Text.Trim()) == true || s == child_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (bar_ch.Checked == true)
                {
                    s = data["bar"].ToString();
                    if (s.Contains(bar_t.Text.Trim()) == true || s == bar_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (life_ch.Checked == true)
                {
                    s = data["life"].ToString();
                    if (s.Contains(life_t.Text.Trim()) == true || s == life_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (busy_ch.Checked == true)
                {
                    s = data["busy"].ToString();
                    if (s.Contains(busy_t.Text.Trim()) == true || s == busy_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (tahsil_ch.Checked == true)
                {
                    s = data["tahsil"].ToString();
                    if (s.Contains(tahsil_t.Text.Trim()) == true || s == tahsil_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (moaref_ch.Checked == true)
                {
                    s = data["moaref"].ToString();
                    if (s.Contains(moaref_t.Text.Trim()) == true || s == moaref_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (city_ch.Checked == true)
                {
                    s = data["city"].ToString();
                    if (s.Contains(city_t.Text.Trim()) == true || s == city_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (reception_ch.Checked == true)
                {
                    int start, finish;
                    start = 0;
                    finish = 0;

                    s = data["reception"].ToString();
                    int year, month, day;
                    day = 0;
                    if (s.Contains("/") == true)
                    {
                        year = Int32.Parse(s.Substring(0, s.IndexOf('/')));
                        s = s.Substring(s.IndexOf('/') + 1, s.Length - s.IndexOf('/') - 1);
                        month = Int32.Parse(s.Substring(0, s.IndexOf('/')));
                        s = s.Substring(s.IndexOf('/') + 1, s.Length - s.IndexOf('/') - 1);
                        day = Int32.Parse(s);

                        day = (year * 365) + (month * 30) + (day);

                        start = ((Int32.Parse(syear.Text)) * 365) + ((Int32.Parse(smonth.Text)) * 30) + ((Int32.Parse(sday.Text)));
                        finish = ((Int32.Parse(fyear.Text)) * 365) + ((Int32.Parse(fmonth.Text)) * 30) + ((Int32.Parse(fday.Text)));

                        if (day >= start && day <= finish)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check; j++)
                                sum_bool = sum_bool && array_bool[j];

                            if (sum_bool == true)
                            {
                                str_par[counter] = data["par"].ToString();
                                counter++;
                            }
                        }
                    }

                }
                //////////
                if (cc_ch.Checked == true)
                {
                    s = data["cc"].ToString();
                    if (s.Contains(cc_t.Text.Trim()) == true || s == cc_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (dx_ch.Checked == true)
                {
                    s = data["dx"].ToString();
                    if (s.Contains(dx_t.Text.Trim()) == true || s == dx_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (pi_ch.Checked == true)
                {
                    s = data["pi"].ToString();
                    if (s.Contains(pi_t.Text.Trim()) == true || s == pi_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (ph_ch.Checked == true)
                {
                    s = data["ph"].ToString();
                    if (s.Contains(ph_t.Text.Trim()) == true || s == ph_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (fh_ch.Checked == true)
                {
                    s = data["fh"].ToString();
                    if (s.Contains(fh_t.Text.Trim()) == true || s == fh_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (pe_ch.Checked == true)
                {
                    s = data["pe"].ToString();
                    if (s.Contains(pe_t.Text.Trim()) == true || s == pe_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (bp_ch.Checked == true)
                {
                    s = data["bp"].ToString();
                    if (s.Contains(bp_t.Text.Trim()) == true || s == bp_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (dd_ch.Checked == true)
                {
                    s = data["dd"].ToString();
                    if (s.Contains(dd_t.Text.Trim()) == true || s == dd_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (px_ch.Checked == true)
                {
                    s = data["px"].ToString();
                    if (s.Contains(px_t.Text.Trim()) == true || s == px_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (rx_ch.Checked == true)
                {
                    s = data["rx"].ToString();
                    if (s.Contains(rx_t.Text.Trim()) == true || s == rx_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (ip_ch.Checked == true)
                {
                    s = data["ip"].ToString();
                    if (s.Contains(ip_t.Text.Trim()) == true || s == ip_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (op_ch.Checked == true)
                {
                    s = data["op"].ToString();
                    if (s.Contains(op_t.Text.Trim()) == true || s == op_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (pc_ch.Checked == true)
                {
                    s = data["pc"].ToString();
                    if (s.Contains(pc_t.Text.Trim()) == true || s == pc_t.Text)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }
                }
                //////////
                if (g_ch.Checked == true)
                {
                    int start, finish, g;
                    start = 0;
                    finish = 0;

                    try
                    {
                        g = Int32.Parse(data["g"].ToString());
                    }
                    catch
                    {
                        g = -1;
                    }

                    try
                    {
                        start = Int32.Parse(g1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(g2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (g >= start && g <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (p_ch.Checked == true)
                {
                    int start, finish, p;
                    start = 0;
                    finish = 0;

                    try
                    {
                        p = Int32.Parse(data["p"].ToString());
                    }
                    catch
                    {
                        p = -1;
                    }

                    try
                    {
                        start = Int32.Parse(p1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(p2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (p >= start && p <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (a_ch.Checked == true)
                {
                    int start, finish, a;
                    start = 0;
                    finish = 0;

                    try
                    {
                        a = Int32.Parse(data["a"].ToString());
                    }
                    catch
                    {
                        a = -1;
                    }

                    try
                    {
                        start = Int32.Parse(a1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(a2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (a >= start && a <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (l_ch.Checked == true)
                {
                    int start, finish, l;
                    start = 0;
                    finish = 0;

                    try
                    {
                        l = Int32.Parse(data["l"].ToString());
                    }
                    catch
                    {
                        l = -1;
                    }

                    try
                    {
                        start = Int32.Parse(l1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(l2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (l >= start && l <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (d_ch.Checked == true)
                {
                    int start, finish, d;
                    start = 0;
                    finish = 0;

                    try
                    {
                        d = Int32.Parse(data["d"].ToString());
                    }
                    catch
                    {
                        d = -1;
                    }

                    try
                    {
                        start = Int32.Parse(d1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(d2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (d >= start && d <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (hc_ch.Checked == true)
                {
                    int start, finish, hc;
                    start = 0;
                    finish = 0;

                    try
                    {
                        hc = Int32.Parse(data["hc"].ToString());
                    }
                    catch
                    {
                        hc = -1;
                    }

                    try
                    {
                        start = Int32.Parse(hc1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(hc2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (hc >= start && hc <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (ht_ch.Checked == true)
                {
                    int start, finish, ht;
                    start = 0;
                    finish = 0;

                    try
                    {
                        ht = Int32.Parse(data["ht"].ToString());
                    }
                    catch
                    {
                        ht = -1;
                    }

                    try
                    {
                        start = Int32.Parse(ht1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(ht2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (ht >= start && ht <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
                if (wg_ch.Checked == true)
                {
                    int start, finish, wg;
                    start = 0;
                    finish = 0;

                    try
                    {
                        wg = Int32.Parse(data["wg"].ToString());
                    }
                    catch
                    {
                        wg = -1;
                    }

                    try
                    {
                        start = Int32.Parse(wg1_t.Text);
                    }
                    catch
                    {
                        start = 0;
                    }

                    try
                    {
                        finish = Int32.Parse(wg2_t.Text);
                    }
                    catch
                    {
                        finish = 0;
                    }

                    if (wg >= start && wg <= finish)
                        array_bool[i] = true;
                    else
                        array_bool[i] = false;

                    i++;
                    if (i == num_check)
                    {
                        sum_bool = array_bool[0];
                        for (int j = 1; j < num_check; j++)
                            sum_bool = sum_bool && array_bool[j];

                        if (sum_bool == true)
                        {
                            str_par[counter] = data["par"].ToString();
                            counter++;
                        }
                    }

                }
                /////////
               

            }
            data.Close();

            Int64 ppar, counter2 = 0;
            Int64[] ppar_arr = new Int64[1000];
            bool best_flag = false;

            if (num_check2 == 0)
            {
                counter2 = counter;
            }
            //////////////////////////////////////////////
            if (num_check == 0)
            {
                sqlcmd.CommandText = "select * from sick2";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    i = 0;
                    //////////
                    if (sb_ch.Checked == true)
                    {
                        s = data["sb"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(sb_t.Text.Trim()) == true || s == sb_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (ncc_ch.Checked == true)
                    {
                        s = data["sb"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(ncc_t.Text.Trim()) == true || s == ncc_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (ob_ch.Checked == true)
                    {
                        s = data["ob"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(ob_t.Text.Trim()) == true || s == ob_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (as_ch.Checked == true)
                    {
                        s = data["ass"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(as_t.Text.Trim()) == true || s == as_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (pl_ch.Checked == true)
                    {
                        s = data["pl"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(pl_t.Text.Trim()) == true || s == pl_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (dd2_ch.Checked == true)
                    {
                        s = data["dd"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(dd2_t.Text.Trim()) == true || s == dd2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (px2_ch.Checked == true)
                    {
                        s = data["px"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(px2_t.Text.Trim()) == true || s == px2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (rx2_ch.Checked == true)
                    {
                        s = data["rx"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(rx2_t.Text.Trim()) == true || s == rx2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (ip2_ch.Checked == true)
                    {
                        s = data["ip"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(ip2_t.Text.Trim()) == true || s == ip2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (op2_ch.Checked == true)
                    {
                        s = data["op"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(op2_t.Text.Trim()) == true || s == op2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (co2_ch.Checked == true)
                    {
                        s = data["co"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(co2_t.Text.Trim()) == true || s == co2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (pc2_ch.Checked == true)
                    {
                        s = data["pc"].ToString();
                        ppar = Int64.Parse(data["par"].ToString());

                        if (s.Contains(pc2_t.Text.Trim()) == true || s == pc2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                }
                data.Close();
            }
            //////////////////////////////////////////////

            for (int k = 0; k < counter; k++)
            {
                ppar = Int64.Parse(str_par[k]);

                sqlcmd.CommandText = "select * from sick2 where par = '"+ ppar +"' ";
                data = sqlcmd.ExecuteReader();

                while (data.Read())
                {
                    i = 0;
                    //////////
                    if (sb_ch.Checked == true)
                    {
                        s = data["sb"].ToString();
                        if (s.Contains(sb_t.Text.Trim()) == true || s == sb_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (ncc_ch.Checked == true)
                    {
                        s = data["sb"].ToString();

                        if (s.Contains(ncc_t.Text.Trim()) == true || s == ncc_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (ob_ch.Checked == true)
                    {
                        s = data["ob"].ToString();

                        if (s.Contains(ob_t.Text.Trim()) == true || s == ob_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (as_ch.Checked == true)
                    {
                        s = data["ass"].ToString();

                        if (s.Contains(as_t.Text.Trim()) == true || s == as_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (pl_ch.Checked == true)
                    {
                        s = data["pl"].ToString();

                        if (s.Contains(pl_t.Text.Trim()) == true || s == pl_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (dd2_ch.Checked == true)
                    {
                        s = data["dd"].ToString();

                        if (s.Contains(dd2_t.Text.Trim()) == true || s == dd2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (px2_ch.Checked == true)
                    {
                        s = data["px"].ToString();

                        if (s.Contains(px2_t.Text.Trim()) == true || s == px2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (rx2_ch.Checked == true)
                    {
                        s = data["rx"].ToString();

                        if (s.Contains(rx2_t.Text.Trim()) == true || s == rx2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (ip2_ch.Checked == true)
                    {
                        s = data["ip"].ToString();

                        if (s.Contains(ip2_t.Text.Trim()) == true || s == ip2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (op2_ch.Checked == true)
                    {
                        s = data["op"].ToString();
                        

                        if (s.Contains(op2_t.Text.Trim()) == true || s == op2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (co2_ch.Checked == true)
                    {
                        s = data["co"].ToString();

                        if (s.Contains(co2_t.Text.Trim()) == true || s == co2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////
                    if (pc2_ch.Checked == true)
                    {
                        s = data["pc"].ToString();
                        if (s.Contains(pc2_t.Text.Trim()) == true || s == pc2_t.Text)
                            array_bool[i] = true;
                        else
                            array_bool[i] = false;

                        i++;
                        if (i == num_check2)
                        {
                            sum_bool = array_bool[0];
                            for (int j = 1; j < num_check2; j++)
                                sum_bool = sum_bool && array_bool[j];

                            best_flag = false;
                            if (sum_bool == true)
                            {
                                for (int i2 = 0; i2 < counter2; i2++)
                                {
                                    if (ppar == ppar_arr[i2])
                                        best_flag = true;
                                }
                                if (best_flag == false)
                                {
                                    ppar_arr[counter2] = ppar;
                                    counter2++;
                                }
                            }
                        }
                    }
                    //////////

                } // End Of While
                data.Close();
            } // End of For

            filter_t.Text = counter2.ToString();
            //MessageBox.Show(counter2.ToString());

            //DataView dv;
            //DataSet ds = new DataSet();
            //SqlDataAdapter sqlada = new SqlDataAdapter();
            //sqlcmd.CommandText = "select par as [شماره پرونده],fname as [نام اول],mname as [نام میانی],lname as [نام آخر],bplace as [محل تولد],moaref as [معرف],father as [نام پدر],id as [شماره شناسنامه],bdate as [تاریخ تولد],nid as [کد ملی],zip as [کد پستی],sodor as [محل صدور شناسنامه],bid as [شماره دفترچه بیمه] from sick1";;
            //sqlada.SelectCommand = sqlcmd;
            //sqlada.Fill(ds);
            //dv = new DataView(ds.Tables[0]);
            //dataGridView1.DataSource = dv;

            object[] myob = new object[20];

            dataGridView1.Rows.Clear();
            for (i = 0; i < counter2; i++)
            {
                if (num_check2 == 0)
                {
                    sqlcmd.CommandText = "select * from sick1 where par = '" + str_par[i] + "' ";
                    data = sqlcmd.ExecuteReader();

                }
                else
                {
                    sqlcmd.CommandText = "select * from sick1 where par = '" + ppar_arr[i] + "' ";
                    data = sqlcmd.ExecuteReader();
                }
                while (data.Read())
                {
                    myob[1] = data["par"].ToString();
                    myob[2] = data["fname"].ToString();
                    myob[3] = data["mname"].ToString() + " " + data["lname"].ToString();
                    myob[4] = data["reception"].ToString();
                    myob[5] = data["doctor"].ToString();

                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count, myob);
                }
                data.Close();
            }


            sqlconn.Close();

        }

        private void cc_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (cc_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void dx_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (dx_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void pi_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (pi_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void ph_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (ph_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void fh_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (fh_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void pe_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (pe_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void g_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (g_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void p_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void a_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (a_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void l_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (l_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void d_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (d_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void hc_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (hc_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void ht_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (ht_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void wg_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (wg_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void bp_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (bp_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void dd_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (dd_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void px_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (px_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void rx_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (rx_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void ip_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (ip_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void op_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (op_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void pc_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (pc_ch.Checked == true)
                num_check++;
            else
                num_check--;
        }

        private void sb_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (sb_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void ncc_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (ncc_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void ob_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (ob_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void as_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (as_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void pl_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (pl_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void dd2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (dd2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void px2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (px2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void rx2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (rx2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void ip2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (ip2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void op2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (op2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void co2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (co2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void pc2_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (pc2_ch.Checked == true)
                num_check2++;
            else
                num_check2--;
        }

        private void panel3_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();

            cc_c.Visible = true;
            dx_c.Visible = true;
            ncc_c.Visible = true;

            cc_c.Visible = false;
            dx_c.Visible = false;
            ncc_c.Visible = false;

            doctor_c.Visible = false;
            title_c.Visible = false;
            bplace_c.Visible = false;
            job_c.Visible = false;
            malol_c.Visible = false;
            gender_c.Visible = false;
            marray_c.Visible = false;
            bar_c.Visible = false;
            bimeh_c.Visible = false;
            life_c.Visible = false;
            busy_c.Visible = false;
            tahsil_c.Visible = false;
            moaref_c.Visible = false;
            city_c.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (Patient.IsOpen == true)
                {
                    alert2 frm2 = new alert2();
                    frm2.ShowDialog();
                    return;
                }

                Patient.first = false;
                Patient.par = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                Patient frm = new Patient();

                int i = 0;
                string s;
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select distinct fname from info where fname<>''";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    frm.fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
                data.Close();

                sqlcmd.CommandText = "select distinct mname from info where mname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    frm.mname_t.AutoCompleteCustomSource.Add(data["mname"].ToString());
                data.Close();

                sqlcmd.CommandText = "select distinct lname from info where lname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    frm.lname_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
                data.Close();

                i = 0;
                sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["bplace"].ToString();
                    frm.bplace_c.Items.Insert(i, s);
                    frm.bplace_t.AutoCompleteCustomSource.Add(s);
                    i++;
                }
                data.Close();

                sqlcmd.CommandText = "select distinct father from info where father<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    frm.father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
                data.Close();

                i = 0;
                sqlcmd.CommandText = "select distinct city from info where city<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["city"].ToString();
                    frm.city_c.Items.Insert(i, s);
                    frm.city_t.AutoCompleteCustomSource.Add(s);
                    i++;
                }
                data.Close();

                i = 0;
                sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["sodor"].ToString();
                    frm.sodor_c.Items.Insert(i, s);
                    frm.sodor_t.AutoCompleteCustomSource.Add(s);
                    i++;
                }
                data.Close();


                sqlconn.Close();

                frm.Show();

            }
        }

        private void search_data_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void search_data_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6) values('" + this.Name + "','" + dataGridView1.Columns[0].Width + "','" + dataGridView1.Columns[1].Width + "','" + dataGridView1.Columns[2].Width + "','" + dataGridView1.Columns[3].Width + "','" + dataGridView1.Columns[4].Width + "','" + dataGridView1.Columns[5].Width + "')";
            sqlcmd.ExecuteNonQuery();
           
            sqlconn.Close();

        }

        private void doctor_t_Click(object sender, EventArgs e)
        {
            if (login.log_username == "admin")
            {
                doctor_c.Width = 17;
                doctor_c.Visible = true;
            }
        }

        private void title_t_Click(object sender, EventArgs e)
        {
            title_c.Width = 17;
            title_c.Visible = true;
        }

        private void bplace_t_Click(object sender, EventArgs e)
        {
            bplace_c.Width = 17;
            bplace_c.Visible = true;
        }

        private void job_t_Click(object sender, EventArgs e)
        {
            job_c.Width = 17;
            job_c.Visible = true;

        }

        private void malol_t_Click(object sender, EventArgs e)
        {
            malol_c.Width = 17;
            malol_c.Visible = true;

        }

        private void gender_t_Click(object sender, EventArgs e)
        {
            gender_c.Width = 17;
            gender_c.Visible = true;

        }

        private void marray_t_Click(object sender, EventArgs e)
        {
            marray_c.Width = 17;
            marray_c.Visible = true;

        }

        private void bar_t_Click(object sender, EventArgs e)
        {
            bar_c.Width = 17;
            bar_c.Visible = true;

        }

        private void bimeh_t_Click(object sender, EventArgs e)
        {
            bimeh_c.Width = 17;
            bimeh_c.Visible = true;

        }

        private void life_t_Click(object sender, EventArgs e)
        {
            life_c.Width = 17;
            life_c.Visible = true;

        }

        private void tahsil_t_Click(object sender, EventArgs e)
        {
            tahsil_c.Width = 17;
            tahsil_c.Visible = true;

        }

        private void moaref_t_Click(object sender, EventArgs e)
        {
            moaref_c.Width = 17;
            moaref_c.Visible = true;

        }

        private void city_t_Click(object sender, EventArgs e)
        {
            city_c.Width = 17;
            city_c.Visible = true;

        }

        private void doctor_c_Click(object sender, EventArgs e)
        {
            if (doctor_c.Width != 22 + doctor_t.Width)
                doctor_c.Width = 22 + doctor_t.Width;
        }

        private void title_c_Click(object sender, EventArgs e)
        {
            if (title_c.Width != 22 + title_t.Width)
                title_c.Width = 22 + title_t.Width;
        }

        private void bplace_c_Click(object sender, EventArgs e)
        {
            if (bplace_c.Width != 22 + bplace_t.Width)
                bplace_c.Width = 22 + bplace_t.Width;
        }

        private void job_c_Click(object sender, EventArgs e)
        {
            if (job_c.Width != 22 + job_t.Width)
                job_c.Width = 22 + job_t.Width;
        }

        private void malol_c_Click(object sender, EventArgs e)
        {
            if (malol_c.Width != 22 + malol_t.Width)
                malol_c.Width = 22 + malol_t.Width;
        }

        private void gender_c_Click(object sender, EventArgs e)
        {
            if (gender_c.Width != 22 + gender_t.Width)
                gender_c.Width = 22 + gender_t.Width;
        }

        private void marray_c_Click(object sender, EventArgs e)
        {
            if (marray_c.Width != 22 + marray_t.Width)
                marray_c.Width = 22 + marray_t.Width;
        }

        private void bar_c_Click(object sender, EventArgs e)
        {
            if (bar_c.Width != 22 + bar_t.Width)
                bar_c.Width = 22 + bar_t.Width;
        }

        private void bimeh_c_Click(object sender, EventArgs e)
        {
            if (bimeh_c.Width != 22 + bimeh_t.Width)
                bimeh_c.Width = 22 + bimeh_t.Width;
        }

        private void life_c_Click(object sender, EventArgs e)
        {
            if (life_c.Width != 22 + life_t.Width)
                life_c.Width = 22 + life_t.Width;
        }

        private void tahsil_c_Click(object sender, EventArgs e)
        {
            if (tahsil_c.Width != 22 + tahsil_t.Width)
                tahsil_c.Width = 22 + tahsil_t.Width;
        }

        private void moaref_c_Click(object sender, EventArgs e)
        {
            if (moaref_c.Width != 22 + moaref_t.Width)
                moaref_c.Width = 22 + moaref_t.Width;
        }

        private void city_c_Click(object sender, EventArgs e)
        {
            if (city_c.Width != 22 + city_t.Width)
                city_c.Width = 22 + city_t.Width;
        }

        private void title_t_Enter(object sender, EventArgs e)
        {
            doctor_c.Visible = false;
        }

        private void bplace_t_Enter(object sender, EventArgs e)
        {
            title_c.Visible = false;
        }

        private void job_t_Enter(object sender, EventArgs e)
        {
            bplace_c.Visible = false;
        }

        private void malol_t_Enter(object sender, EventArgs e)
        {
            job_c.Visible = false;
        }

        private void gender_t_Enter(object sender, EventArgs e)
        {
            malol_c.Visible = false;
        }

        private void marray_t_Enter(object sender, EventArgs e)
        {
            gender_c.Visible = false;
        }

        private void child_t_Enter(object sender, EventArgs e)
        {
            marray_c.Visible = false;
        }

        private void bimeh_t_Enter(object sender, EventArgs e)
        {
            bar_c.Visible = false;
        }

        private void life_t_Enter(object sender, EventArgs e)
        {
            bimeh_c.Visible = false;
        }

        private void busy_t_Enter(object sender, EventArgs e)
        {
            life_c.Visible = false;
        }

        private void sday_Enter(object sender, EventArgs e)
        {
            busy_c.Visible = false;
        }

        private void moaref_t_Enter(object sender, EventArgs e)
        {
            tahsil_c.Visible = false;
        }

        private void city_t_Enter(object sender, EventArgs e)
        {
            moaref_c.Visible = false;
        }

        private void doctor_c_MouseHover(object sender, EventArgs e)
        {
            doctor_c.Width = 22 + doctor_t.Width;
            doctor_c.SendToBack();
        }

        private void title_c_MouseHover(object sender, EventArgs e)
        {
            title_c.Width = 22 + title_t.Width;
            title_c.SendToBack();
        }

        private void bplace_c_MouseHover(object sender, EventArgs e)
        {
            bplace_c.Width = 22 + bplace_t.Width;
            bplace_c.SendToBack();
        }

        private void job_c_MouseHover(object sender, EventArgs e)
        {
            job_c.Width = 22 + job_t.Width;
            job_c.SendToBack();
        }

        private void malol_c_MouseHover(object sender, EventArgs e)
        {
            malol_c.Width = 22 + malol_t.Width;
            malol_c.SendToBack();
        }

        private void gender_c_MouseHover(object sender, EventArgs e)
        {
            gender_c.Width = 22 + gender_t.Width;
            gender_c.SendToBack();
        }

        private void marray_c_MouseHover(object sender, EventArgs e)
        {
            marray_c.Width = 22 + marray_t.Width;
            marray_c.SendToBack();
        }

        private void bar_c_MouseHover(object sender, EventArgs e)
        {
            bar_c.Width = 22 + bar_t.Width;
            bar_c.SendToBack();
        }

        private void bimeh_c_MouseHover(object sender, EventArgs e)
        {
            bimeh_c.Width = 22 + bimeh_t.Width;
            bimeh_c.SendToBack();
        }

        private void life_c_MouseHover(object sender, EventArgs e)
        {
            life_c.Width = 22 + life_t.Width;
            life_c.SendToBack();
        }

        private void busy_c_MouseHover(object sender, EventArgs e)
        {
            busy_c.Width = 22 + busy_t.Width;
            busy_c.SendToBack();
        }

        private void tahsil_c_MouseHover(object sender, EventArgs e)
        {
            tahsil_c.Width = 22 + tahsil_t.Width;
            tahsil_c.SendToBack();
        }

        private void moaref_c_MouseHover(object sender, EventArgs e)
        {
            moaref_c.Width = 22 + moaref_t.Width;
            moaref_c.SendToBack();
        }

        private void city_c_MouseHover(object sender, EventArgs e)
        {
            city_c.Width = 22 + city_t.Width;
            city_c.SendToBack();
        }

        private void doctor_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctor_t.Text = doctor_c.Text;
            doctor_c.Width = 17;
            doctor_c.Visible = false;
            doctor_t.Focus();
        }

        private void title_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            title_t.Text = title_c.Text;
            title_c.Width = 17;
            title_c.Visible = false;
            title_t.Focus();
        }

        private void bplace_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bplace_t.Text = bplace_c.Text;
            bplace_c.Width = 17;
            bplace_c.Visible = false;
            bplace_t.Focus();
        }

        private void job_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            job_t.Text = job_c.Text;
            job_c.Width = 17;
            job_c.Visible = false;
            job_t.Focus();
        }

        private void malol_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            malol_t.Text = malol_c.Text;
            malol_c.Width = 17;
            malol_c.Visible = false;
            malol_t.Focus();
        }

        private void gender_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender_t.Text = gender_c.Text;
            gender_c.Width = 17;
            gender_c.Visible = false;
            gender_t.Focus();
        }

        private void marray_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            marray_t.Text = marray_c.Text;
            marray_c.Width = 17;
            marray_c.Visible = false;
            marray_t.Focus();
        }

        private void bar_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar_t.Text = bar_c.Text;
            bar_c.Width = 17;
            bar_c.Visible = false;
            bar_t.Focus();
        }

        private void bimeh_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bimeh_t.Text = bimeh_c.Text;
            bimeh_c.Width = 17;
            bimeh_c.Visible = false;
            bimeh_t.Focus();
        }

        private void life_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            life_t.Text = life_c.Text;
            life_c.Width = 17;
            life_c.Visible = false;
            life_t.Focus();
        }

        private void busy_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            busy_t.Text = busy_c.Text;
            busy_c.Width = 17;
            busy_c.Visible = false;
            busy_t.Focus();
        }

        private void tahsil_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            tahsil_t.Text = tahsil_c.Text;
            tahsil_c.Width = 17;
            tahsil_c.Visible = false;
            tahsil_t.Focus();
        }

        private void moaref_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            moaref_t.Text = moaref_c.Text;
            moaref_c.Width = 17;
            moaref_c.Visible = false;
            moaref_t.Focus();
        }

        private void city_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            city_t.Text = city_c.Text;
            city_c.Width = 17;
            city_c.Visible = false;
            city_t.Focus();
        }

        private void busy_t_Click(object sender, EventArgs e)
        {
            busy_c.Width = 17;
            busy_c.Visible = true;
        }

        private void cc_t_Click(object sender, EventArgs e)
        {
            cc_c.Width = 17;
            cc_c.Visible = true;
        }

        private void dx_t_Click(object sender, EventArgs e)
        {
            cc_c.Visible = false;

            dx_c.Width = 17;
            dx_c.Visible = true;
        }

        private void ncc_t_Click(object sender, EventArgs e)
        {
            ncc_c.Width = 17;
            ncc_c.Visible = true;
        }

        private void ob_t_Enter(object sender, EventArgs e)
        {
            ncc_c.Visible = false;
        }

        private void pi_t_Enter(object sender, EventArgs e)
        {
            dx_c.Visible = false;
        }

        private void cc_c_Click(object sender, EventArgs e)
        {
            if (cc_c.Width != 22 + cc_t.Width)
                cc_c.Width = 22 + cc_t.Width;
        }

        private void dx_c_Click(object sender, EventArgs e)
        {
            if (dx_c.Width != 22 + dx_t.Width)
                dx_c.Width = 22 + dx_t.Width;
        }

        private void ncc_c_Click(object sender, EventArgs e)
        {
            if (ncc_c.Width != 22 + ncc_t.Width)
                ncc_c.Width = 22 + ncc_t.Width;
        }

        private void cc_c_MouseHover(object sender, EventArgs e)
        {
            cc_c.Width = 22 + cc_t.Width;
            cc_c.SendToBack();
        }

        private void dx_c_MouseHover(object sender, EventArgs e)
        {
            dx_c.Width = 22 + dx_t.Width;
            dx_c.SendToBack();
        }

        private void ncc_c_MouseHover(object sender, EventArgs e)
        {
            ncc_c.Width = 22 + ncc_t.Width;
            ncc_c.SendToBack();
        }

        private void cc_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc_t.Text = cc_c.Text;
            cc_c.Width = 17;
            cc_c.Visible = false;
            cc_t.Focus();
        }

        private void dx_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            dx_t.Text = dx_c.Text;
            dx_c.Width = 17;
            dx_c.Visible = false;
            dx_t.Focus();
        }

        private void ncc_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            ncc_t.Text = ncc_c.Text;
            ncc_c.Width = 17;
            ncc_c.Visible = false;
            ncc_t.Focus();
        }
    }
}