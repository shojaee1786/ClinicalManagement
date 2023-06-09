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
    public partial class Risk2 : Form
    {
        private static int num_check, num_check2;
        public static string MyRisk;
        public Risk2()
        {
            InitializeComponent();
        }

        private void Risk2_Load(object sender, EventArgs e)
        {
            MyRisk = "";
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

            //i = 0;
            //sqlcmd.CommandText = "select distinct dx from firstvisit where dx<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //{
            //    s = data["dx"].ToString();
            //    dx_t.AutoCompleteCustomSource.Add(s);
            //    dx_c.Items.Insert(i, s);
            //    i++;
            //}
            //data.Close();

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

        private void Risk2_ResizeEnd(object sender, EventArgs e)
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

        private void doctor_t_Click(object sender, EventArgs e)
        {
            doctor_c.Width = 17;
            doctor_c.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Risk2_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyRisk = "";

            //if (doctor_ch.Checked == true)
            //    MyRisk = MyRisk + " " + doctor_t.Text;

            if (title_ch.Checked == true)
                MyRisk = MyRisk + "title|" + title_t.Text + "|";

            if (age_ch.Checked == true)
                MyRisk = MyRisk + "age|" + syear_t.Text + "/" + smonth_t.Text + "/" + sday_t.Text + "<age<" + fyear_t.Text + "/" + fmonth_t.Text + "/" + fday_t.Text + "|";

            if (bplace_ch.Checked == true)
                MyRisk = MyRisk + "bplace|" + bplace_t.Text + "|";

            if (job_ch.Checked == true)
                MyRisk = MyRisk + "job|" + job_t.Text + "|";

            if (malol_ch.Checked == true)
                MyRisk = MyRisk + "malol|" + malol_t.Text + "|";

            if (gender_ch.Checked == true)
                MyRisk = MyRisk + "gender|" + gender_t.Text + "|";

            if (marray_ch.Checked == true)
                MyRisk = MyRisk + "marray|" + marray_t.Text + "|";

            if (child_ch.Checked == true)
                MyRisk = MyRisk + "child|" + child_t.Text + "|";

            if (bar_ch.Checked == true)
                MyRisk = MyRisk + "bar|" + bar_t.Text + "|";

            if (bimeh_ch.Checked == true)
                MyRisk = MyRisk + "bimeh|" + bimeh_t.Text + "|";

            if (life_ch.Checked == true)
                MyRisk = MyRisk + "life|" + life_t.Text + "|";

            if (busy_ch.Checked == true)
                MyRisk = MyRisk + "busy|" + busy_t.Text + "|";

            if (reception_ch.Checked == true)
                MyRisk = MyRisk + "reception|" + syear.Text + "/" + smonth.Text + "/" + sday.Text + "<reception<" + fyear.Text + "/" + fmonth.Text + "/" + fday.Text + "|";

            if (tahsil_ch.Checked == true)
                MyRisk = MyRisk + "tahsil|" + tahsil_t.Text + "|";

            if (moaref_ch.Checked == true)
                MyRisk = MyRisk + "moaref|" + moaref_t.Text + "|";

            if (city_ch.Checked == true)
                MyRisk = MyRisk + "city|" + city_t.Text + "|";

            if (cc_ch.Checked == true)
                MyRisk = MyRisk + "cc|" + cc_t.Text + "|";

            if (dx_ch.Checked == true)
                MyRisk = MyRisk + "dx|" + dx_t.Text + "|";

            if (pi_ch.Checked == true)
                MyRisk = MyRisk + "pi|" + pi_t.Text + "|";

            if (ph_ch.Checked == true)
                MyRisk = MyRisk + "ph|" + ph_t.Text + "|";

            if (fh_ch.Checked == true)
                MyRisk = MyRisk + "fh|" + fh_t.Text + "|";

            if (pe_ch.Checked == true)
                MyRisk = MyRisk + "pe|" + pe_t.Text + "|";

            if (g_ch.Checked == true)
                MyRisk = MyRisk + "g|" + g1_t.Text + "<g<" + g2_t.Text + "|";

            if (p_ch.Checked == true)
                MyRisk = MyRisk + "p|" + p1_t.Text + "<p<" + p2_t.Text + "|";

            if (a_ch.Checked == true)
                MyRisk = MyRisk + "a|" + a1_t.Text + "<a<" + a2_t.Text + "|";

            if (l_ch.Checked == true)
                MyRisk = MyRisk + "l|" + l1_t.Text + "<l<" + l2_t.Text + "|";

            if (d_ch.Checked == true)
                MyRisk = MyRisk + "d|" + d1_t.Text + "<d<" + d2_t.Text + "|";

            if (hc_ch.Checked == true)
                MyRisk = MyRisk + "hc|" + hc1_t.Text + "<hc<" + hc2_t.Text + "|";

            if (ht_ch.Checked == true)
                MyRisk = MyRisk + "ht|" + ht1_t.Text + "<ht<" + ht2_t.Text + "|";

            if (wg_ch.Checked == true)
                MyRisk = MyRisk + "wg|" + wg1_t.Text + "<wg<" + wg2_t.Text + "|";

            if (bp_ch.Checked == true)
                MyRisk = MyRisk + "bp|" + bp_t.Text + "|";

            if (dd_ch.Checked == true)
                MyRisk = MyRisk + "dd|" + dd_t.Text + "|";

            if (px_ch.Checked == true)
                MyRisk = MyRisk + "px|" + px_t.Text + "|";

            if (rx_ch.Checked == true)
                MyRisk = MyRisk + "rx|" + rx_t.Text + "|";

            if (ip_ch.Checked == true)
                MyRisk = MyRisk + "ip|" + ip_t.Text + "|";

            if (op_ch.Checked == true)
                MyRisk = MyRisk + "op|" + op_t.Text + "|";

            if (pc_ch.Checked == true)
                MyRisk = MyRisk + "pc|" + pc_t.Text + "|";

            if (sb_ch.Checked == true)
                MyRisk = MyRisk + "sb|" + sb_t.Text + "|";

            if (ncc_ch.Checked == true)
                MyRisk = MyRisk + "ncc|" + ncc_t.Text + "|";

            if (ob_ch.Checked == true)
                MyRisk = MyRisk + "ob|" + ob_t.Text + "|";

            if (as_ch.Checked == true)
                MyRisk = MyRisk + "as|" + as_t.Text + "|";

            if (pl_ch.Checked == true)
                MyRisk = MyRisk + "pl|" + pl_t.Text + "|";

            if (dd2_ch.Checked == true)
                MyRisk = MyRisk + "dd2|" + dd2_t.Text + "|";

            if (px2_ch.Checked == true)
                MyRisk = MyRisk + "px2|" + px2_t.Text + "|";

            if (rx2_ch.Checked == true)
                MyRisk = MyRisk + "rx2|" + rx2_t.Text + "|";

            if (ip2_ch.Checked == true)
                MyRisk = MyRisk + "ip2|" + ip2_t.Text + "|";

            if (op2_ch.Checked == true)
                MyRisk = MyRisk + "op2|" + op2_t.Text + "|";

            if (co2_ch.Checked == true)
                MyRisk = MyRisk + "co2|" + co2_t.Text + "|";

            if (pc2_ch.Checked == true)
                MyRisk = MyRisk + "pc2|" + pc2_t.Text + "|";

        }
    }
}