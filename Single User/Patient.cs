using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Utils;
using System.IO;

namespace Clinical_Management
{
    public partial class Patient : Form
    {
        public static bool IsOpen = false;
        //public static bool pp_conflict1;
        //public static bool pp_conflict2;
        public static bool myflag1, myflag2;
        private static string mycontrol;
        public static string pp_paz_row;
        private static Int64 pilength, cclength, dxlength, phlength, fhlength, pelength, ddlength, pxlength, rxlength, iplength, oplength, pclength;
        private static Int64 rsblength, roblength, raslength, rpllength, rddlength, rpxlength, rrxlength, riplength, roplength, rcolength, rpclength;
        public static string filter = "General";
        public static bool flag_all;
        public static string title_all, fname_all, mname_all, lname_all, day_all, month_all, year_all, bdate_all, city_all, bplace_all, father_all, id_all, sodor_all, job_all, malol_all, age_all, gender_all, marray_all, child_all, bar_all, moaref_all, zip_all, nid_all, tahsil_all, bimeh_all, adr_all;
        public static string othercode_all, life_all, busy_all, others_all;
        public static string bimehno_all, serial_all, expire_all, bimeh2_all, bimehno2_all, serial2_all, expire2_all, bimeh3_all, bimehno3_all, serial3_all, expire3_all, bimeh4_all, bimehno4_all, serial4_all, expire4_all;
        public static string adr2_all, adr3_all, adr4_all, adr5_all, tel1_all, desc1_all, tel2_all, desc2_all, tel3_all, desc3_all, tel4_all, desc4_all, tel5_all, desc5_all, tel6_all, desc6_all, tel7_all, desc7_all, tel8_all, desc8_all, tel9_all, desc9_all, tel10_all, desc10_all;
        public static string edr1_all, email1_all, edr2_all, email2_all, edr3_all, email3_all, edr4_all, email4_all, edr5_all, email5_all, edr6_all, email6_all, edr7_all, email7_all, edr8_all, email8_all, edr9_all, email9_all, edr10_all, email10_all;
        
        public static int cc_i, dx_i, pi_i, ph_i, fh_i, pe_i, dd_i, px_i, rx_i, ip_i, op_i, pc_i;
        public static int cc_j, dx_j, pi_j, ph_j, fh_j, pe_j, dd_j, px_j, rx_j, ip_j, op_j, pc_j;

        public static int rsb_i, rob_i, ras_i, rpl_i, rdd_i, rpx_i, rrx_i, rip_i, rop_i, rco_i, rpc_i;
        public static int rsb_j, rob_j, ras_j, rpl_j, rdd_j, rpx_j, rrx_j, rip_j, rop_j, rco_j, rpc_j;

        public static bool first = true;
        public static Int64 par;
        public static bool sb_flag , ob_flag, as_flag, pl_flag, dd_flag, px_flag, rx_flag, ip_flag, op_flag, co_flag, pc_flag;

        const int disp = 40;
        public static int maxpage = 2;
        //string txt_name;
        
     
        public Patient()
        {
            InitializeComponent();
            cct1.Focus();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            IsOpen = true;
            //if (pp_conflict1 == true)  // for preventing more than one green form
            //{
            //    pp_conflict2 = true;
            //    alert2 frm1 = new alert2();
            //    frm1.ShowDialog();
            //    this.Close();
            //}
            //else
            //    pp_conflict1 = true;

            cm_menu.Visible = true;
            cm_menu.Top = 38;
            cm_menu.Left = 0;
            cm_menu.Visible = false;

            myflag1= myflag2 = false;
            mycontrol = "cct1";

            pilength = cclength = dxlength = phlength = fhlength = pelength = ddlength = pxlength = rxlength = iplength = oplength = pclength = 0;
            rsblength = roblength = raslength = rpllength = rddlength = rpxlength = rrxlength = riplength = roplength = rcolength = rpclength = 0;

            othercode_all = life_all = busy_all = others_all = "";
            bimehno_all = serial_all = expire_all = bimeh2_all = bimehno2_all = serial2_all = expire2_all = bimeh3_all = bimehno3_all = serial3_all = expire3_all = bimeh4_all = bimehno4_all = serial4_all = expire4_all = "";
            adr2_all = adr3_all = adr4_all = adr5_all = tel1_all = desc1_all = tel2_all = desc2_all = tel3_all = desc3_all = tel4_all = desc4_all = tel5_all = desc5_all = tel6_all = desc6_all = tel7_all = desc7_all = tel8_all = desc8_all = tel9_all = desc9_all = tel10_all = desc10_all = "";
            edr1_all = email1_all = edr2_all = email2_all = edr3_all = email3_all = edr4_all = email4_all = edr5_all = email5_all = edr6_all = email6_all = edr7_all = email7_all = edr8_all = email8_all = edr9_all = email9_all = edr10_all = email10_all = "";
            flag_all = false;
           
            sb_flag = ob_flag = as_flag = pl_flag = dd_flag = px_flag = rx_flag = ip_flag = op_flag = co_flag = pc_flag = false;
         

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            //sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            //data.Close();

            ////// Hide Or UnHide For Gravid,...
            sqlcmd.CommandText = "select gy,pd from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["gy"].ToString()) == 0)
                {
                    g1_l.Visible = g1t1.Visible = p1_l.Visible = a1_l.Visible = atxt.Visible = l1_l.Visible = ltxt.Visible = g2_l.Visible = g2t1.Visible = false;
                }
                else
                    g1_l.Visible = g1t1.Visible = p1_l.Visible = a1_l.Visible = atxt.Visible = l1_l.Visible = ltxt.Visible = g2_l.Visible = g2t1.Visible = true;


                if (Int32.Parse(data["pd"].ToString()) == 0)
                {
                    hc_l.Visible = hct1.Visible = false;
                }
                else
                    hc_l.Visible = hct1.Visible = true;

            }
            data.Close();
            ////////

            int i = 0;
            string s = "";
            sqlcmd.CommandText = "select distinct title,-titlef from info where title<>'' order by -titlef ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["title"].ToString();
                title_c.Items.Insert(i, s);
                title_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            filter = "General";
            if (par != 0)
            {
                sqlcmd.CommandText = "select filter from filter_t where par = '" + par + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    filter = data["filter"].ToString();
                data.Close();
            }

            //sqlcmd.CommandText = "select distinct mname from info where mname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    mname_t.AutoCompleteCustomSource.Add(data["mname"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    lname_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct age from info where age<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    age_t.AutoCompleteCustomSource.Add(data["age"].ToString());
            //data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct job from info where job<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["job"].ToString();
                job_c.Items.Insert(i, s);
                job_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            //i = 0;
            //sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //{
            //    s = data["bplace"].ToString();
            //    bplace_c.Items.Insert(i, s);
            //    bplace_t.AutoCompleteCustomSource.Add(s);
            //    i++;
            //}
            //data.Close();

            sqlcmd.CommandText = "select distinct bimeh from info where bimeh<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                bimeh_t.AutoCompleteCustomSource.Add(data["bimeh"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct marray from info where marray<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["marray"].ToString();
                marray_c.Items.Insert(i, s);
                marray_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            //sqlcmd.CommandText = "select distinct child from info where child<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    child_t.AutoCompleteCustomSource.Add(data["child"].ToString());
            //data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct moaref from info where moaref<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["moaref"].ToString();
                moaref_c.Items.Insert(i, s);
                moaref_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            //sqlcmd.CommandText = "select distinct father from info where father<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
            //data.Close();

            sqlcmd.CommandText = "select distinct id from info where id<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                id_t.AutoCompleteCustomSource.Add(data["id"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct nid from info where nid<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                nid_t.AutoCompleteCustomSource.Add(data["nid"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct zip from info where zip<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                zip_t.AutoCompleteCustomSource.Add(data["zip"].ToString());
            data.Close();

            //i = 0;
            //sqlcmd.CommandText = "select distinct city from info where city<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //{
            //    s = data["city"].ToString();
            //    city_c.Items.Insert(i, s);
            //    city_t.AutoCompleteCustomSource.Add(s);
            //    i++;
            //}
            //data.Close();

            //i = 0;
            //sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //{
            //    s = data["sodor"].ToString();
            //    sodor_c.Items.Insert(i, s);
            //    sodor_t.AutoCompleteCustomSource.Add(s);
            //    i++;
            //}
            //data.Close();

            sqlcmd.CommandText = "select distinct malol from info where malol<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                malol_t.AutoCompleteCustomSource.Add(data["malol"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct adr from info where adr<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                adr_t.AutoCompleteCustomSource.Add(data["adr"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct tahsil from info where tahsil<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["tahsil"].ToString();
                tahsil_c.Items.Insert(i, s);
                tahsil_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();



            sqlcmd.CommandText ="select * from temp where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();
            

            

            PersianDate pd = PersianDate.Now;
            label36.Text = pd.ToString().Substring(0,10);
           
            if (first == true)
            {
                reception_t.Text = label36.Text;
                if (Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "select * from paziresh where row='" + pp_paz_row + "' and date1 = '" + label36.Text + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        title_t.Text = data["title"].ToString();
                        fname_t.Text = data["fname"].ToString();
                        mname_t.Text = data["mname"].ToString();
                        lname_t.Text = data["lname"].ToString();
                        age_t.Text = data["age"].ToString();
                        job_t.Text = data["job"].ToString();
                        bplace_t.Text = data["bplace"].ToString();

                        // Get Bimeh from DB
                        bimeh_t.Text = data["bimeh"].ToString();
                        if (data["bimeh2"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh2"].ToString();

                        if (data["bimeh3"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh3"].ToString();

                        if (data["bimeh4"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh4"].ToString();

                        marray_t.Text = data["marray"].ToString();
                        child_t.Text = data["child"].ToString();
                        bar_t.Text = data["bar"].ToString();
                        gender_t.Text = data["gender"].ToString();
                        moaref_t.Text = data["moaref"].ToString();
                        //reception_t.Text = data["reception"].ToString();
                        father_t.Text = data["father"].ToString();
                        id_t.Text = data["id"].ToString();
                        bdate_t.Text = data["bdate"].ToString();
                        if (bdate_t.Text.Length == 10)
                        {
                            year.Text = bdate_t.Text.Substring(2, 2);
                            month.Text = bdate_t.Text.Substring(5, 2);
                            day.Text = bdate_t.Text.Substring(8, 2);
                        }

                        nid_t.Text = data["nid"].ToString();
                        zip_t.Text = data["zip"].ToString();
                        city_t.Text = data["city"].ToString();
                        sodor_t.Text = data["sodor"].ToString();
                        malol_t.Text = data["malol"].ToString();
                        adr_t.Text = data["adr"].ToString();
                        tahsil_t.Text = data["tahsil"].ToString();
                    }
                    data.Close();
                }
            }
            else
            {
                if (Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "select * from paziresh where row='" + pp_paz_row + "' and date1 = '" + label36.Text + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        title_t.Text = data["title"].ToString();
                        fname_t.Text = data["fname"].ToString();
                        mname_t.Text = data["mname"].ToString();
                        lname_t.Text = data["lname"].ToString();
                        age_t.Text = data["age"].ToString();
                        job_t.Text = data["job"].ToString();
                        bplace_t.Text = data["bplace"].ToString();
                        
                        // Get Bimeh from DB
                        bimeh_t.Text = data["bimeh"].ToString();
                        if (data["bimeh2"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh2"].ToString();

                        if (data["bimeh3"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh3"].ToString();

                        if (data["bimeh4"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh4"].ToString();

                        marray_t.Text = data["marray"].ToString();
                        child_t.Text = data["child"].ToString();
                        bar_t.Text = data["bar"].ToString();
                        gender_t.Text = data["gender"].ToString();
                        moaref_t.Text = data["moaref"].ToString();
                        reception_t.Text = data["reception"].ToString();
                        father_t.Text = data["father"].ToString();
                        id_t.Text = data["id"].ToString();
                        bdate_t.Text = data["bdate"].ToString();
                        if (bdate_t.Text.Length == 10)
                        {
                            year.Text = bdate_t.Text.Substring(2, 2);
                            month.Text = bdate_t.Text.Substring(5, 2);
                            day.Text = bdate_t.Text.Substring(8, 2);
                        }

                        nid_t.Text = data["nid"].ToString();
                        zip_t.Text = data["zip"].ToString();
                        city_t.Text = data["city"].ToString();
                        sodor_t.Text = data["sodor"].ToString();
                        malol_t.Text = data["malol"].ToString();
                        adr_t.Text = data["adr"].ToString();
                        tahsil_t.Text = data["tahsil"].ToString();
                    }
                    data.Close();

                    sqlcmd.CommandText = "select * from sick1 where par='" + par + "'";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        cct1.Text = data["cc"].ToString();
                        dxt1.Text = data["dx"].ToString();
                        pit1.Text = data["pi"].ToString();
                        pht1.Text = data["ph"].ToString();
                        fht1.Text = data["fh"].ToString();
                        pet1.Text = data["pe"].ToString();
                        g1t1.Text = data["g"].ToString();
                        ptxt.Text = data["p"].ToString();
                        atxt.Text = data["a"].ToString();
                        ltxt.Text = data["l"].ToString();
                        g2t1.Text = data["d"].ToString();
                        hct1.Text = data["hc"].ToString();
                        htt1.Text = data["ht"].ToString();
                        wgt1.Text = data["wg"].ToString();
                        bpt1.Text = data["bp"].ToString();
                        ddt1.Text = data["dd"].ToString();
                        pxt1.Text = data["px"].ToString();
                        rxt1.Text = data["rx"].ToString();
                        ipt1.Text = data["ip"].ToString();
                        opt1.Text = data["op"].ToString();
                        pct1.Text = data["pc"].ToString();
                    }
                    data.Close();

                    sqlcmd.CommandText = "select lastvisit from var1 where par='" + par + "'";
                    data = sqlcmd.ExecuteReader();
                    bool existdata = false;
                    while (data.Read())
                    {
                        maxpage = Int32.Parse(data["lastvisit"].ToString()) + 1;

                        if (maxpage.ToString().Length == 1)
                            label35.Text = "00" + maxpage.ToString();
                        if (maxpage.ToString().Length == 2)
                            label35.Text = "0" + maxpage.ToString();
                        if (maxpage.ToString().Length == 3)
                            label35.Text = maxpage.ToString();

                        existdata = true;
                    }
                    data.Close();
                    if (existdata == false)
                    {
                        maxpage = 2;
                        label35.Text = "00" + maxpage.ToString();
                    }
                } // End of first = false and Paziresh_to_pp = true
                else
                {
                    // First = false and Paziresh_to_pp = false
                    sqlcmd.CommandText = "select * from sick1 where par='" + par + "'";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        title_t.Text = data["title"].ToString();
                        fname_t.Text = data["fname"].ToString();
                        mname_t.Text = data["mname"].ToString();
                        lname_t.Text = data["lname"].ToString();
                        age_t.Text = data["age"].ToString();
                        job_t.Text = data["job"].ToString();
                        bplace_t.Text = data["bplace"].ToString();

                        // Get Bimeh from DB
                        bimeh_t.Text = data["bimeh"].ToString();
                        if (data["bimeh2"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh2"].ToString();

                        if (data["bimeh3"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh3"].ToString();

                        if (data["bimeh4"].ToString() != "")
                            bimeh_t.Text += " + " + data["bimeh4"].ToString();
                       
                        marray_t.Text = data["marray"].ToString();
                        child_t.Text = data["child"].ToString();
                        bar_t.Text = data["bar"].ToString();
                        gender_t.Text = data["gender"].ToString();
                        moaref_t.Text = data["moaref"].ToString();
                        reception_t.Text = data["reception"].ToString();
                        father_t.Text = data["father"].ToString();
                        id_t.Text = data["id"].ToString();
                        bdate_t.Text = data["bdate"].ToString();
                        if (bdate_t.Text.Length == 10)
                        {
                            year.Text = bdate_t.Text.Substring(2, 2);
                            month.Text = bdate_t.Text.Substring(5, 2);
                            day.Text = bdate_t.Text.Substring(8, 2);
                        }

                        nid_t.Text = data["nid"].ToString();
                        zip_t.Text = data["zip"].ToString();
                        city_t.Text = data["city"].ToString();
                        sodor_t.Text = data["sodor"].ToString();
                        malol_t.Text = data["malol"].ToString();
                        adr_t.Text = data["adr"].ToString();
                        tahsil_t.Text = data["tahsil"].ToString();

                        cct1.Text = data["cc"].ToString();
                        dxt1.Text = data["dx"].ToString();
                        pit1.Text = data["pi"].ToString();
                        pht1.Text = data["ph"].ToString();
                        fht1.Text = data["fh"].ToString();
                        pet1.Text = data["pe"].ToString();
                        g1t1.Text = data["g"].ToString();
                        ptxt.Text = data["p"].ToString();
                        atxt.Text = data["a"].ToString();
                        ltxt.Text = data["l"].ToString();
                        g2t1.Text = data["d"].ToString();
                        hct1.Text = data["hc"].ToString();
                        htt1.Text = data["ht"].ToString();
                        wgt1.Text = data["wg"].ToString();
                        bpt1.Text = data["bp"].ToString();
                        ddt1.Text = data["dd"].ToString();
                        pxt1.Text = data["px"].ToString();
                        rxt1.Text = data["rx"].ToString();
                        ipt1.Text = data["ip"].ToString();
                        opt1.Text = data["op"].ToString();
                        pct1.Text = data["pc"].ToString();
                    }
                    data.Close();

                    //sqlcmd.CommandText = "select lastvisit from var1 where par='" + par + "'";
                    //data = sqlcmd.ExecuteReader();
                    // Chage find lat visit search to SQL max
                    sqlcmd.CommandText = "Select max(visit) from sick2 where par='" + par + "'";
                    try
                    {
                        maxpage = Int32.Parse(sqlcmd.ExecuteScalar().ToString()) + 1;
                    }
                    catch
                    {
                        maxpage = 2;
                    }

                    if (maxpage.ToString().Length == 1)
                        label35.Text = "00" + maxpage.ToString();
                    if (maxpage.ToString().Length == 2)
                        label35.Text = "0" + maxpage.ToString();
                    if (maxpage.ToString().Length == 3)
                        label35.Text = maxpage.ToString();

                    //bool existdata = false;
                    //while (data.Read())
                    //{
                    //    maxpage = Int32.Parse(data["lastvisit"].ToString()) + 1;

                    //    if (maxpage.ToString().Length == 1)
                    //        label35.Text = "00" + maxpage.ToString();
                    //    if (maxpage.ToString().Length == 2)
                    //        label35.Text = "0" + maxpage.ToString();
                    //    if (maxpage.ToString().Length == 3)
                    //        label35.Text = maxpage.ToString();

                    //    existdata = true;
                    //}
                    //data.Close();
                    //if (existdata == false)
                    //{
                    //    maxpage = 2;
                    //    label35.Text = "00" + maxpage.ToString();
                    //}

                }
            }

            sqlconn.Close();
            cct1.Focus();

            if (reception_t.Text == "")
                reception_t.Text = label36.Text;


            timer1.Enabled = true;
        }

        private void all_info_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            
            flag_all = true;

            title_all = title_t.Text;
            fname_all = fname_t.Text;
            mname_all = mname_t.Text;
            lname_all = lname_t.Text;
            age_all = age_t.Text;
            day_all = day.Text;
            month_all = month.Text;
            year_all = year.Text;
            bplace_all = bplace_t.Text;
            bdate_all = bdate_t.Text;
            father_all = father_t.Text;
            id_all = id_t.Text;
            sodor_all = sodor_t.Text;
            city_all = city_t.Text;
            job_all = job_t.Text;
            malol_all = malol_t.Text;
            gender_all = gender_t.Text;
            marray_all = marray_t.Text;
            child_all = child_t.Text;
            bar_all = bar_t.Text;
            zip_all = zip_t.Text;
            nid_all = nid_t.Text;
            moaref_all = moaref_t.Text;
            tahsil_all = tahsil_t.Text;
            adr_all = adr_t.Text;

            // Send bimeh to All_info
            bimeh_all = "";
            bimeh2_all = "";
            bimeh3_all = "";
            bimeh4_all = "";
            string b_temp = bimeh_t.Text;
            if (b_temp.Contains("+") == true)
            {
                bimeh_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                if (b_temp.Contains("+") == true)
                {
                    bimeh2_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                    b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                    if (b_temp.Contains("+") == true)
                    {
                        bimeh3_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                        b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                        if (b_temp.Contains("+") == true)
                        {
                            bimeh4_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                        }
                        else
                        {
                            bimeh4_all = b_temp;
                        }
                    }
                    else
                    {
                        bimeh3_all = b_temp;
                    }
                }
                else
                {
                    bimeh2_all = b_temp;
                }
            }
            else
            {
                bimeh_all = b_temp;
            }

            all_info frm = new all_info();
            frm.ShowDialog();

            title_t.Text = title_all;
            fname_t.Text = fname_all;
            mname_t.Text = mname_all;
            lname_t.Text = lname_all;
            age_t.Text = age_all;
            day.Text = day_all;
            month.Text = month_all;
            year.Text = year_all;
            bplace_t.Text = bplace_all;
            bdate_t.Text = bdate_all;
            father_t.Text = father_all;
            id_t.Text = id_all;
            sodor_t.Text = sodor_all;
            city_t.Text = city_all;
            job_t.Text = job_all;
            malol_t.Text = malol_all;
            gender_t.Text = gender_all;
            marray_t.Text = marray_all;
            child_t.Text = child_all;
            bar_t.Text = bar_all;
            zip_t.Text = zip_all;
            nid_t.Text = nid_all;
            moaref_t.Text = moaref_all;
            tahsil_t.Text = tahsil_all;
            adr_t.Text = adr_all;
            
            // Get Bimeh from All_info
            bimeh_t.Text = bimeh_all;
            if(bimeh2_all != "")
                bimeh_t.Text += " + " + bimeh2_all;

            if (bimeh3_all != "")
                bimeh_t.Text += " + " + bimeh3_all;

            if (bimeh4_all != "")
                bimeh_t.Text += " + " + bimeh4_all;
            
           
        }

        private void switch_profile_Click(object sender, EventArgs e)
        {
            bdate_t.Text = label3.Text + year.Text + "/" + month.Text + "/" + day.Text;
            if (year.Text != "" && month.Text != "" && day.Text != "")
            {
                try
                {
                    Int32 y, m, d;

                    y = 1300 + Int32.Parse(year.Text);
                    m = Int32.Parse(month.Text);
                    d = Int32.Parse(day.Text);

                    y = PersianDate.Now.Year - y;
                    m = PersianDate.Now.Month - m;
                    d = PersianDate.Now.Day - d;

                    if (d < 0)
                    {
                        m--;
                        d += 30;
                    }

                    if (m < 0)
                    {
                        y--;
                        m += 12;
                    }
                    age_t.Text = y.ToString() + "/" + m.ToString() + "/" + d.ToString();
                }
                catch { }
            }

            // Visible Group 1
            profile1_p.Visible = true;
            // Invisible Group 2
            profile2_p.Visible = false;

            title_t.Focus();
        }

        private void cm_Click(object sender, EventArgs e)
        {
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

        private void switch_profile1_Click(object sender, EventArgs e)
        {
            moaref_c.Visible = false;
            // Invisible Group 1
            profile1_p.Visible = false;
            // Visible Group 2
            profile2_p.Top = 1;
            profile2_p.Visible = true;
            

            father_t.Focus();
        }

        private void cm2_Click(object sender, EventArgs e)
        {
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


        /////////////// Set Keyboard to favorites Languages /////////        
        private void profile1_p_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void RightPnl_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void LeftPnl_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void profile2_p_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }
        /////////////////////////////////////////////////////////////        

        private void profile1_p_MouseMove(object sender, MouseEventArgs e)
        {
            if (Int32.Parse(e.Y.ToString()) <= 7)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            else
                if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
        }

        private void profile2_p_MouseMove(object sender, MouseEventArgs e)
        {
            if (Int32.Parse(e.Y.ToString()) <= 7)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            else
                if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
        }
      
        private void title_t_Click(object sender, EventArgs e)
        {
            title_c.Width = 17;
            title_c.Visible = true;
        }

        private void gender_t_Click(object sender, EventArgs e)
        {
           
            gender_c.Width = 18;
            gender_c.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            title_t.Text = title_c.Text;
            title_c.Width = 17;
            title_c.Visible = false;
            title_t.Focus();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("Update info set titlef = titlef + 1 where title = '" + title_t.Text + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            title_c.Width = 22 + title_t.Width;
            title_c.SendToBack();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (title_c.Width != 22 + title_t.Width)
                title_c.Width = 22 + title_t.Width;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            if (gender_c.Width != 22 + gender_t.Width)
                gender_c.Width = 22 + gender_t.Width;
        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            gender_c.Width = 22 + gender_t.Width;
            gender_c.SendToBack();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender_t.Text = gender_c.Text;
            gender_c.Width = 18;
            gender_c.Visible = false;
            gender_t.Focus();
        }

        private void fname_t_Enter(object sender, EventArgs e)
        {
            title_c.Visible = false;
            
          
        }

        private void moaref_t_Enter(object sender, EventArgs e)
        {
            gender_c.Visible = false;
        }

        private void bimeh_t_MouseClick(object sender, MouseEventArgs e)
        {
            Form frm = new Bimeh();
            frm.Top = 80;
            frm.Left = 840;
            frm.ShowDialog();
            if (Bimeh.str_bimeh != "")
            {
                if (bimeh_t.Text == "")
                    bimeh_t.Text = Bimeh.str_bimeh;
                else
                    bimeh_t.Text = bimeh_t.Text + " + " + Bimeh.str_bimeh;
            }

            // Clear Bimeh TextBox
          if (Bimeh.str_bimeh == "1")
              bimeh_t.Text = "";

        }

        private void bar_t_Click(object sender, EventArgs e)
        {
            bar_c.Width = 17;
            bar_c.Visible = true;
        }

        private void bar_t1_MouseHover(object sender, EventArgs e)
        {
            bar_c.Width = 22 + bar_t.Width;
            bar_c.SendToBack();
        }

        private void bar_t1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar_t.Text = bar_c.Text;
            bar_c.Width = 17;
            bar_c.Visible = false;
            bar_t.Focus();
        }

        private void job_t_Click(object sender, EventArgs e)
        {
            job_c.Width = 17;
            job_c.Visible = true;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (job_c.Width != 22 + job_t.Width)
                job_c.Width = 22 + job_t.Width;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            job_t.Text = job_c.Text;
            job_c.Width = 17;
            job_c.Visible = false;
            job_t.Focus();
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            if (bplace_c.Width != 22 + bplace_t.Width)
                bplace_c.Width = 22 + bplace_t.Width;
        }

        private void bplace_t_Click(object sender, EventArgs e)
        {
            bplace_c.Width = 17;
            bplace_c.Visible = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            bplace_t.Text = bplace_c.Text;
            bplace_c.Width = 17;
            bplace_c.Visible = false;
            bplace_t.Focus();
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            if (marray_c.Width != 22 + marray_t.Width)
                marray_c.Width = 22 + marray_t.Width;
        }

        private void comboBox5_MouseHover(object sender, EventArgs e)
        {
            marray_c.Width = 22 + marray_t.Width;
            marray_c.SendToBack();

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            marray_t.Text = marray_c.Text;
            marray_c.Width = 17;
            marray_c.Visible = false;
            marray_t.Focus();
        }

        private void marray_t_Click(object sender, EventArgs e)
        {

            marray_c.Width = 17;
            marray_c.Visible = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            moaref_t.Text = moaref_c.Text;
            moaref_c.Width = 17;
            moaref_c.Visible = false;
            moaref_t.Focus();
        }

        private void comboBox6_MouseHover(object sender, EventArgs e)
        {
            moaref_c.Width = 22 + moaref_t.Width;
            moaref_c.SendToBack();
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            if (moaref_c.Width != 22 + moaref_t.Width)
                moaref_c.Width = 22 + moaref_t.Width;
        }

        private void moaref_t_Click(object sender, EventArgs e)
        {
            moaref_c.Width = 17;
            moaref_c.Visible = true;
        }

        private void bplace_t_Enter(object sender, EventArgs e)
        {
            job_c.Visible = false;
        }

        private void gender_t_Enter(object sender, EventArgs e)
        {
            bar_c.Visible = false;
        }

        private void reception_t_Enter(object sender, EventArgs e)
        {
            moaref_c.Visible = false;
        }

        private void malol_t_MouseClick(object sender, MouseEventArgs e)
        {
            Form frm = new Malol();
            frm.Top = 80;
            frm.Left = 650;
            frm.ShowDialog();
            if (Malol.str_malol != "")
                malol_t.Text = Malol.str_malol;
            if (Malol.str_malol == "1")
                malol_t.Text = "";
           

        }

        /////////////// MouseClick Events For Labels on the Left Panel ///////////////
        private void cc_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new CC();
                frm.Top = 120;
                frm.Left = 47;
                frm.ShowDialog();
                
                if (CC.myword != "")
                {
                    try
                    {
                        System.Diagnostics.Process.Start(CC.myword);
                    }
                    catch
                    {
                        MessageBox.Show("Algorithm not found");
                    }
                
                }


                try
                {
                    CC.str = CC.str.Replace("\n", " ");
                    CC.str = CC.str.Replace("\r", " ");
                }
                catch { }

                if (cct1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (CC.str.Contains(","))
                            {
                                while (CC.str[i] != ',')
                                    i--;
                                i++;
                            }

                            CC.str = CC.str.Insert(i, "\n");
                        }
                    }
                    catch { }
                    cct1.Text = CC.str;
                }
                else
                    if (cct1.Text != "" && CC.str != "")
                    {
                        cct1.Text = cct1.Text.Replace("\n", " ");
                        CC.str = cct1.Text + ", " + CC.str;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (CC.str.Contains(","))
                                {
                                    while (CC.str[i] != ' ')
                                        i--;
                                    i++;
                                }

                                CC.str = CC.str.Insert(i, "\n");
                            }
                        }
                        catch { }
                        cct1.Text = CC.str;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                     AV_Folder.pic_name = "";
                    if (cct1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-CC";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlconn;
                        sqlcmd.CommandText = "select count(*) from firstvisit where cc='" + cct1.SelectedText + "' ";
                        if (sqlcmd.ExecuteScalar().ToString() == "0")
                        {
                            sqlcmd.CommandText = "insert into firstvisit(cc) values('" + cct1.SelectedText + "') ";
                            sqlcmd.ExecuteNonQuery();
                        }
                        sqlconn.Close();
                    }

                }
           
        }

        private void dx_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new Dx();
                frm.Top = 120;
                frm.Left = 400;
                frm.ShowDialog();

                try
                {
                    Dx.str_Dx = Dx.str_Dx.Replace("\n", " ");
                    Dx.str_Dx = Dx.str_Dx.Replace("\r", " ");
                }
                catch { }

                if (dxt1.Text == "")
                {
                    try
                    {
                        for (int i = 20; i < 5500; i += 20)
                        {
                            if (Dx.str_Dx.Contains(" "))
                            {
                                while (Dx.str_Dx[i] != ' ')
                                    i--;
                                i++;
                            }

                            Dx.str_Dx = Dx.str_Dx.Insert(i, "\n");
                        }
                    }
                    catch { }
                    dxt1.Text = Dx.str_Dx;
                }
                else
                    if (dxt1.Text != "" && Dx.str_Dx != "")
                    {
                        dxt1.Text = dxt1.Text.Replace("\n", " ");
                        Dx.str_Dx = dxt1.Text + ", " + Dx.str_Dx;
                        try
                        {
                            for (int i = 20; i < 5500; i += 20)
                            {
                                if (Dx.str_Dx.Contains(" "))
                                {
                                    while (Dx.str_Dx[i] != ' ')
                                        i--;
                                    i++;
                                }

                                Dx.str_Dx = Dx.str_Dx.Insert(i, "\n");
                            }
                        }
                        catch { }
                        dxt1.Text = Dx.str_Dx;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (dxt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-Dx";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }

                    //SqlConnection sqlconn = new SqlConnection(cm.cs);
                    //sqlconn.Open();
                    //SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(dx) values('" + dxt1.SelectedText + "')", sqlconn);
                    //sqlcmd.ExecuteNonQuery();
                    //sqlconn.Close();

                }
        }

        private void pi_l_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new PI();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "pi_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 42;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 42;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    PI.str_PI = PI.str_PI.Replace("\n", " ");
                    PI.str_PI = PI.str_PI.Replace("\r", " ");
                }
                catch { }
                if (pit1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (PI.str_PI.Contains(" "))
                            {
                                while (PI.str_PI[i] != ' ')
                                    i--;
                                i++;
                            }

                            PI.str_PI = PI.str_PI.Insert(i, "\n");
                        }
                    }
                    catch { }
                    pit1.Text = PI.str_PI;
                }
                else
                    if (pit1.Text != "" && PI.str_PI != "")
                    {
                        pit1.Text = pit1.Text.Replace("\n", " ");
                        PI.str_PI = pit1.Text + ", " + PI.str_PI;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (PI.str_PI.Contains(" "))
                                {
                                    while (PI.str_PI[i] != ' ')
                                        i--;
                                    i++;
                                }

                                PI.str_PI = PI.str_PI.Insert(i, "\n");
                            }
                        }
                        catch { }
                        pit1.Text = PI.str_PI;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    //if (par == 0)
                    //{

                    //    return;
                    //}

                    AV_Folder.pic_name = "";
                    if (pit1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name  + "-PI";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(pi,fpi) values('" + pit1.SelectedText + "','"+ filter +"')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void ph_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new PH();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "ph_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    PH.str_ph = PH.str_ph.Replace("\n", " ");
                    PH.str_ph = PH.str_ph.Replace("\r", " ");
                }
                catch { }

                if (pht1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (PH.str_ph.Contains(" "))
                            {
                                while (PH.str_ph[i] != ' ')
                                    i--;
                                i++;
                            }

                            PH.str_ph = PH.str_ph.Insert(i, "\n");
                        }
                    }
                    catch { }
                    pht1.Text = PH.str_ph;
                }
                else
                    if (pht1.Text != "" && PH.str_ph != "")
                    {
                        pht1.Text = pht1.Text.Replace("\n", " ");
                        PH.str_ph = pht1.Text + ", " + PH.str_ph;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (PH.str_ph.Contains(" "))
                                {
                                    while (PH.str_ph[i] != ' ')
                                        i--;
                                    i++;
                                }

                                PH.str_ph = PH.str_ph.Insert(i, "\n");
                            }
                        }
                        catch { }
                        pht1.Text = PH.str_ph;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    //if (par == 0)
                    //    return;

                    AV_Folder.pic_name = "";
                    if (pht1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-PH";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(ph,fph) values('" + pht1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void fh_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new FH();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "fh_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    FH.str_fh = FH.str_fh.Replace("\n", " ");
                    FH.str_fh = FH.str_fh.Replace("\r", " ");
                }
                catch { }

                if (fht1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (FH.str_fh.Contains(" "))
                            {
                                while (FH.str_fh[i] != ' ')
                                    i--;
                                i++;
                            }

                            FH.str_fh = FH.str_fh.Insert(i, "\n");
                        }
                    }
                    catch { }
                    fht1.Text = FH.str_fh;
                }
                else
                    if (fht1.Text != "" && FH.str_fh != "")
                    {
                        fht1.Text = fht1.Text.Replace("\n", " ");
                        FH.str_fh = fht1.Text + ", " + FH.str_fh;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (FH.str_fh.Contains(" "))
                                {
                                    while (FH.str_fh[i] != ' ')
                                        i--;
                                    i++;
                                }

                                FH.str_fh = FH.str_fh.Insert(i, "\n");
                            }
                        }
                        catch { }
                        fht1.Text = FH.str_fh;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (fht1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-FH";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(fh,ffh) values('" + fht1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void pe_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new PE();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "pe_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    PE.str_pe = PE.str_pe.Replace("\n", " ");
                    PE.str_pe = PE.str_pe.Replace("\r", " ");
                }
                catch { }

                if (pet1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (PE.str_pe.Contains(" "))
                            {
                                while (PE.str_pe[i] != ' ')
                                    i--;
                                i++;
                            }

                            PE.str_pe = PE.str_pe.Insert(i, "\n");
                        }
                    }
                    catch { }
                    pet1.Text = PE.str_pe;
                }
                else
                    if (pet1.Text != "" && PE.str_pe != "")
                    {
                        pet1.Text = pet1.Text.Replace("\n", " ");
                        PE.str_pe = pet1.Text + ", " + PE.str_pe;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (PE.str_pe.Contains(" "))
                                {
                                    while (PE.str_pe[i] != ' ')
                                        i--;
                                    i++;
                                }

                                PE.str_pe = PE.str_pe.Insert(i, "\n");
                            }
                        }
                        catch { }
                        pet1.Text = PE.str_pe;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (pet1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-PE";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(pe,fpe) values('" + pet1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void dd_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new DD();
                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "dd_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }
                frm.ShowDialog();
                try
                {
                    DD.str_DD = DD.str_DD.Replace("\n", " ");
                    DD.str_DD = DD.str_DD.Replace("\r", " ");
                }
                catch { }

                if (ddt1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (DD.str_DD.Contains(" "))
                            {
                                while (DD.str_DD[i] != ' ')
                                    i--;
                                i++;
                            }

                            DD.str_DD = DD.str_DD.Insert(i, "\n");
                        }
                    }
                    catch { }
                    ddt1.Text = DD.str_DD;
                }
                else
                    if (ddt1.Text != "" && DD.str_DD != "")
                    {
                        ddt1.Text = ddt1.Text.Replace("\n", " ");
                        DD.str_DD = ddt1.Text + " " + DD.str_DD;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (DD.str_DD.Contains(" "))
                                {
                                    while (DD.str_DD[i] != ' ')
                                        i--;
                                    i++;
                                }

                                DD.str_DD = DD.str_DD.Insert(i, "\n");
                            }
                        }
                        catch { }
                        ddt1.Text = DD.str_DD;
                    }
            }
            //else
            //    if (e.Button == MouseButtons.Right)
            //    {
            //        SqlConnection sqlconn = new SqlConnection(cm.cs);
            //        sqlconn.Open();
            //        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(dd) values('" + ddt1.SelectedText + "')", sqlconn);
            //        sqlcmd.ExecuteNonQuery();
            //        sqlconn.Close();

            //    }
        }

        private void px_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Printer_Px.Printer_Px_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();
                Printer_Px.Printer_Px_cc = cct1.Text;
                Printer_Px.Printer_Px_dx = dxt1.Text;
                try
                {
                    Printer_Px.Printer_Px_pi = pit1.Lines[0].ToString();
                }
                catch 
                {
                    Printer_Px.Printer_Px_pi = "";
                }

                Form frm = new PX();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "px_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    PX.str_px = PX.str_px.Replace("\n", " ");
                    PX.str_px = PX.str_px.Replace("\r", " ");
                }
                catch { }
                if (pxt1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (PX.str_px.Contains(" "))
                            {
                                while (PX.str_px[i] != ' ')
                                    i--;
                                i++;
                            }

                            PX.str_px = PX.str_px.Insert(i, "\n");
                        }
                    }
                    catch { }
                    pxt1.Text = PX.str_px;
                }
                else
                    if (pxt1.Text != "" && PX.str_px != "")
                    {
                        pxt1.Text = pxt1.Text.Replace("\n", " ");
                        PX.str_px = pxt1.Text + ", " + PX.str_px;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (PX.str_px.Contains(" "))
                                {
                                    while (PX.str_px[i] != ' ')
                                        i--;
                                    i++;
                                }

                                PX.str_px = PX.str_px.Insert(i, "\n");
                            }
                        }
                        catch { }
                        pxt1.Text = PX.str_px;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (pxt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-Px";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(px,fpx) values('" + pxt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void rx_l_MouseClick(object sender, MouseEventArgs e)
        {
            Prescription.Prescription_age = "";
            Prescription.Prescription_name = "";
            Prescription.Prescription_ccdx = "";



            Prescription.Prescription_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();
            if (age_t.Text.Length > 3)
            {
                Prescription.Prescription_age = age_t.Text.Substring(0, age_t.Text.IndexOf('/'))  + " " + "ساله";
            }

            if (dxt1.Text != "")
            {
                if (dxt1.Text.Contains(",") == true)
                {
                    Prescription.Prescription_ccdx = "Dx: " + dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                }
                else
                    Prescription.Prescription_ccdx = "Dx: " + dxt1.Text;
            }
            else
            {
                if (cct1.Text.Contains(",") == true)
                {
                    Prescription.Prescription_ccdx = "CC: " + cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                }
                else
                    Prescription.Prescription_ccdx = "CC: " + cct1.Text;
            }

            Prescription.Prescription_ccdx = Prescription.Prescription_ccdx.Replace("\n"," ");
             
            Dosage.wg = wgt1.Text;
            Dosage.record = "";

            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            Rx frm = new Rx();
            frm.ShowDialog();

            rxt1.Text = rxt1.Text + Dosage.record;
        }

        private void ip_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new IP();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "ip_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    IP.str_ip = IP.str_ip.Replace("\n", " ");
                    IP.str_ip = IP.str_ip.Replace("\r", " ");
                }
                catch { }

                if (ipt1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (IP.str_ip.Contains(" "))
                            {
                                while (IP.str_ip[i] != ' ')
                                    i--;
                                i++;
                            }

                            IP.str_ip = IP.str_ip.Insert(i, "\n");
                        }
                    }
                    catch { }
                    ipt1.Text = IP.str_ip;
                }
                else
                    if (ipt1.Text != "" && IP.str_ip != "")
                    {
                        ipt1.Text = ipt1.Text.Replace("\n", " ");
                        IP.str_ip = ipt1.Text + ", " + IP.str_ip;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (IP.str_ip.Contains(" "))
                                {
                                    while (IP.str_ip[i] != ' ')
                                        i--;
                                    i++;
                                }

                                IP.str_ip = IP.str_ip.Insert(i, "\n");
                            }
                        }
                        catch { }
                        ipt1.Text = IP.str_ip;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (ipt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-IP";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(ip,fip) values('" + ipt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void op_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new OP();

                foreach (Control c1 in LeftPnl.Controls)
                {
                    if (c1.Name.ToString() == "op_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 47;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    OP.str_op = OP.str_op.Replace("\n", " ");
                    OP.str_op = OP.str_op.Replace("\r", " ");
                }
                catch { }

                if (opt1.Text == "")
                {
                    try
                    {
                        for (int i = 55; i < 5500; i += 55)
                        {
                            if (OP.str_op.Contains(" "))
                            {
                                while (OP.str_op[i] != ' ')
                                    i--;
                                i++;
                            }

                            OP.str_op = OP.str_op.Insert(i, "\n");
                        }
                    }
                    catch { }
                    opt1.Text = OP.str_op;
                }
                else
                    if (opt1.Text != "" && OP.str_op != "")
                    {
                        opt1.Text = opt1.Text.Replace("\n", " ");
                        OP.str_op = opt1.Text + ", " + OP.str_op;
                        try
                        {
                            for (int i = 55; i < 5500; i += 55)
                            {
                                if (OP.str_op.Contains(" "))
                                {
                                    while (OP.str_op[i] != ' ')
                                        i--;
                                    i++;
                                }

                                OP.str_op = OP.str_op.Insert(i, "\n");
                            }
                        }
                        catch { }
                        opt1.Text = OP.str_op;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (opt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-OP";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(op,fop) values('" + opt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }
                }

        }

        private void pc_l_MouseClick(object sender, MouseEventArgs e)
        {
            //Dosage.wg = wgt1.Text;
            //Dosage.record = "";
            if (e.Button == MouseButtons.Left)
            {
                BMI.bmi_ht = htt1.Text;
                BMI.bmi_wg = wgt1.Text;
                try
                {
                    BMI.bmi_age = age_t.Text.Substring(0, age_t.Text.IndexOf("/"));
                }
                catch
                {
                    BMI.bmi_age = "1";
                }

                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

                Form frm = new Preventive();
                frm.ShowDialog();

                htt1.Text = BMI.bmi_ht;
                wgt1.Text = BMI.bmi_wg;

                if (pct1.Text == "")
                    pct1.Text = Preventive.record_pc;
                else
                    pct1.Text = pct1.Text + "\n" + Preventive.record_pc;
                //rxt1.Text = rxt1.Text + Dosage.record;
            }
            else
            {
                AV_Folder.pic_name = "";
                    if (pct1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-PC";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
            }
            

        }

        /////////////// TextChange Events For TextBoxes on the Left Panel //////////////
        private void cct1_TextChanged(object sender, EventArgs e)
        {

            if (cct1.Text.Length % 28 == 0 && cct1.Text.Length > cclength)
            {
                cct1.AppendText("\n");
            }
            cclength = cct1.Text.Length;
            
            if (cct1.Lines.Length == 0 || cct1.Lines.Length == 1)
                cct1.Height = 24;
            else
            {
                if (cct1.Lines.Length < 5)
                    cct1.Height = 24 + (cct1.Lines.Length - 1) * 31;
                else
                    cct1.Height = 24 + (cct1.Lines.Length - 1) * 25;

            }

            if (cct1.Height > dxt1.Height)
            {
                pictureBox1.Top = cct1.Top + cct1.Height + 14;
                pi_l.Top = pictureBox1.Top + pictureBox1.Height + 3;
                pit1.Top = pi_l.Top + 8;
                
                ph_l.Top = pit1.Top + pit1.Height + 9;
                pht1.Top = ph_l.Top + 8;
                
                fh_l.Top = pht1.Top + pht1.Height + 9;
                fht1.Top = fh_l.Top + 8;

                pe_l.Top = fht1.Top + fht1.Height + 9;
                pet1.Top = pe_l.Top + 8;

                g1_l.Top = pet1.Top + pet1.Height + 19;
                g1t1.Top = g1_l.Top + 4;
                p1_l.Top = g1_l.Top;
                ptxt.Top = g1_l.Top + 4;
                a1_l.Top = g1_l.Top;
                atxt.Top = g1_l.Top + 4;
                l1_l.Top = g1_l.Top;
                ltxt.Top = g1_l.Top + 4;
                g2_l.Top = g1_l.Top;
                g2t1.Top = g1_l.Top + 4;
                hc_l.Top = g1_l.Top;
                hct1.Top = g1_l.Top + 4;
                ht_l.Top = g1_l.Top;
                htt1.Top = g1_l.Top + 4;
                wg_l.Top = g1_l.Top;
                wgt1.Top = g1_l.Top + 4;
                kg_l.Top = g1_l.Top + 6;
                bp_l.Top = g1_l.Top;
                bpt1.Top = g1_l.Top + 4;

                dd_l.Top = pet1.Top + pet1.Height + 62;
                ddt1.Top = dd_l.Top + 8;

                px_l.Top = ddt1.Top + ddt1.Height + 9;
                pxt1.Top = px_l.Top + 8;

                rx_l.Top = pxt1.Top + pxt1.Height + 9;
                rxt1.Top = rx_l.Top + 8;

                ip_l.Top = rxt1.Top + rxt1.Height + 9;
                ipt1.Top = ip_l.Top + 8;

                op_l.Top = ipt1.Top + ipt1.Height + 9;
                opt1.Top = op_l.Top + 8;

                pc_l.Top = opt1.Top + opt1.Height + 9;
                pct1.Top = pc_l.Top + 8;

                endl.Top = pct1.Top + pct1.Height + 120;


            }
            else
            {
                pictureBox1.Top = dxt1.Top + dxt1.Height + 14;
                pi_l.Top = pictureBox1.Top + pictureBox1.Height + 3;
                pit1.Top = pi_l.Top + 8;

                ph_l.Top = pit1.Top + pit1.Height + 9;
                pht1.Top = ph_l.Top + 8;

                fh_l.Top = pht1.Top + pht1.Height + 9;
                fht1.Top = fh_l.Top + 8;

                pe_l.Top = fht1.Top + fht1.Height + 9;
                pet1.Top = pe_l.Top + 8;

                g1_l.Top = pet1.Top + pet1.Height + 19;
                g1t1.Top = g1_l.Top + 4;
                p1_l.Top = g1_l.Top;
                ptxt.Top = g1_l.Top + 4;
                a1_l.Top = g1_l.Top;
                atxt.Top = g1_l.Top + 4;
                l1_l.Top = g1_l.Top;
                ltxt.Top = g1_l.Top + 4;
                g2_l.Top = g1_l.Top;
                g2t1.Top = g1_l.Top + 4;
                hc_l.Top = g1_l.Top;
                hct1.Top = g1_l.Top + 4;
                ht_l.Top = g1_l.Top;
                htt1.Top = g1_l.Top + 4;
                wg_l.Top = g1_l.Top;
                wgt1.Top = g1_l.Top + 4;
                kg_l.Top = g1_l.Top + 6;
                bp_l.Top = g1_l.Top;
                bpt1.Top = g1_l.Top + 4;

                dd_l.Top = pet1.Top + pet1.Height + 62;
                ddt1.Top = dd_l.Top + 8;

                px_l.Top = ddt1.Top + ddt1.Height + 9;
                pxt1.Top = px_l.Top + 8;

                rx_l.Top = pxt1.Top + pxt1.Height + 9;
                rxt1.Top = rx_l.Top + 8;

                ip_l.Top = rxt1.Top + rxt1.Height + 9;
                ipt1.Top = ip_l.Top + 8;

                op_l.Top = ipt1.Top + ipt1.Height + 9;
                opt1.Top = op_l.Top + 8;

                pc_l.Top = opt1.Top + opt1.Height + 9;
                pct1.Top = pc_l.Top + 8;

                endl.Top = pct1.Top + pct1.Height + 120;

            }

            

        }

        private void dxt1_TextChanged(object sender, EventArgs e)
        {

            if (dxt1.Text.Length % 20 == 0 && dxt1.Text.Length > dxlength)
            {
                dxt1.AppendText("\n");
            }
            dxlength = dxt1.Text.Length;

            if (dxt1.Lines.Length == 0 || dxt1.Lines.Length == 1)
                dxt1.Height = 24;
            else
            {
                if (dxt1.Lines.Length < 5)
                    dxt1.Height = 24 + (dxt1.Lines.Length - 1) * 31;
                else
                    dxt1.Height = 24 + (dxt1.Lines.Length - 1) * 25;

            }

            if (cct1.Height > dxt1.Height)
            {
                pictureBox1.Top = cct1.Top + cct1.Height + 14;
                pi_l.Top = pictureBox1.Top + pictureBox1.Height + 3;
                pit1.Top = pi_l.Top + 8;

                ph_l.Top = pit1.Top + pit1.Height + 9;
                pht1.Top = ph_l.Top + 8;

                fh_l.Top = pht1.Top + pht1.Height + 9;
                fht1.Top = fh_l.Top + 8;

                pe_l.Top = fht1.Top + fht1.Height + 9;
                pet1.Top = pe_l.Top + 8;

                g1_l.Top = pet1.Top + pet1.Height + 19;
                g1t1.Top = g1_l.Top + 4;
                p1_l.Top = g1_l.Top;
                ptxt.Top = g1_l.Top + 4;
                a1_l.Top = g1_l.Top;
                atxt.Top = g1_l.Top + 4;
                l1_l.Top = g1_l.Top;
                ltxt.Top = g1_l.Top + 4;
                g2_l.Top = g1_l.Top;
                g2t1.Top = g1_l.Top + 4;
                hc_l.Top = g1_l.Top;
                hct1.Top = g1_l.Top + 4;
                ht_l.Top = g1_l.Top;
                htt1.Top = g1_l.Top + 4;
                wg_l.Top = g1_l.Top;
                wgt1.Top = g1_l.Top + 4;
                kg_l.Top = g1_l.Top + 6;
                bp_l.Top = g1_l.Top;
                bpt1.Top = g1_l.Top + 4;

                dd_l.Top = pet1.Top + pet1.Height + 62;
                ddt1.Top = dd_l.Top + 8;

                px_l.Top = ddt1.Top + ddt1.Height + 9;
                pxt1.Top = px_l.Top + 8;

                rx_l.Top = pxt1.Top + pxt1.Height + 9;
                rxt1.Top = rx_l.Top + 8;

                ip_l.Top = rxt1.Top + rxt1.Height + 9;
                ipt1.Top = ip_l.Top + 8;

                op_l.Top = ipt1.Top + ipt1.Height + 9;
                opt1.Top = op_l.Top + 8;

                pc_l.Top = opt1.Top + opt1.Height + 9;
                pct1.Top = pc_l.Top + 8;

                endl.Top = pct1.Top + pct1.Height + 120;


            }
            else
            {
                pictureBox1.Top = dxt1.Top + dxt1.Height + 14;
                pi_l.Top = pictureBox1.Top + pictureBox1.Height + 3;
                pit1.Top = pi_l.Top + 8;

                ph_l.Top = pit1.Top + pit1.Height + 9;
                pht1.Top = ph_l.Top + 8;

                fh_l.Top = pht1.Top + pht1.Height + 9;
                fht1.Top = fh_l.Top + 8;

                pe_l.Top = fht1.Top + fht1.Height + 9;
                pet1.Top = pe_l.Top + 8;

                g1_l.Top = pet1.Top + pet1.Height + 19;
                g1t1.Top = g1_l.Top + 4;
                p1_l.Top = g1_l.Top;
                ptxt.Top = g1_l.Top + 4;
                a1_l.Top = g1_l.Top;
                atxt.Top = g1_l.Top + 4;
                l1_l.Top = g1_l.Top;
                ltxt.Top = g1_l.Top + 4;
                g2_l.Top = g1_l.Top;
                g2t1.Top = g1_l.Top + 4;
                hc_l.Top = g1_l.Top;
                hct1.Top = g1_l.Top + 4;
                ht_l.Top = g1_l.Top;
                htt1.Top = g1_l.Top + 4;
                wg_l.Top = g1_l.Top;
                wgt1.Top = g1_l.Top + 4;
                kg_l.Top = g1_l.Top + 6;
                bp_l.Top = g1_l.Top;
                bpt1.Top = g1_l.Top + 4;

                dd_l.Top = pet1.Top + pet1.Height + 62;
                ddt1.Top = dd_l.Top + 8;

                px_l.Top = ddt1.Top + ddt1.Height + 9;
                pxt1.Top = px_l.Top + 8;

                rx_l.Top = pxt1.Top + pxt1.Height + 9;
                rxt1.Top = rx_l.Top + 8;

                ip_l.Top = rxt1.Top + rxt1.Height + 9;
                ipt1.Top = ip_l.Top + 8;

                op_l.Top = ipt1.Top + ipt1.Height + 9;
                opt1.Top = op_l.Top + 8;

                pc_l.Top = opt1.Top + opt1.Height + 9;
                pct1.Top = pc_l.Top + 8;

                endl.Top = pct1.Top + pct1.Height + 120;

            }

        }

        private void pit1_TextChanged(object sender, EventArgs e)
        {
            if (pit1.Text.Length % 55 == 0 && pit1.Text.Length > pilength)
            {
                pit1.AppendText("\n");
            }
            pilength = pit1.Text.Length;
            if (pit1.Lines.Length == 0 || pit1.Lines.Length == 1)
                pit1.Height = 24;
            else
            {
                if (pit1.Lines.Length < 5)
                    pit1.Height = 24 + (pit1.Lines.Length - 1) * 31;
                else
                    pit1.Height = 24 + (pit1.Lines.Length - 1) * 25;

            }

                ph_l.Top = pit1.Top + pit1.Height + 9;
                pht1.Top = ph_l.Top + 8;

                fh_l.Top = pht1.Top + pht1.Height + 9;
                fht1.Top = fh_l.Top + 8;

                pe_l.Top = fht1.Top + fht1.Height + 9;
                pet1.Top = pe_l.Top + 8;

                g1_l.Top = pet1.Top + pet1.Height + 19;
                g1t1.Top = g1_l.Top + 4;
                p1_l.Top = g1_l.Top;
                ptxt.Top = g1_l.Top + 4;
                a1_l.Top = g1_l.Top;
                atxt.Top = g1_l.Top + 4;
                l1_l.Top = g1_l.Top;
                ltxt.Top = g1_l.Top + 4;
                g2_l.Top = g1_l.Top;
                g2t1.Top = g1_l.Top + 4;
                hc_l.Top = g1_l.Top;
                hct1.Top = g1_l.Top + 4;
                ht_l.Top = g1_l.Top;
                htt1.Top = g1_l.Top + 4;
                wg_l.Top = g1_l.Top;
                wgt1.Top = g1_l.Top + 4;
                kg_l.Top = g1_l.Top + 6;
                bp_l.Top = g1_l.Top;
                bpt1.Top = g1_l.Top + 4;

                dd_l.Top = pet1.Top + pet1.Height + 62;
                ddt1.Top = dd_l.Top + 8;

                px_l.Top = ddt1.Top + ddt1.Height + 9;
                pxt1.Top = px_l.Top + 8;

                rx_l.Top = pxt1.Top + pxt1.Height + 9;
                rxt1.Top = rx_l.Top + 8;

                ip_l.Top = rxt1.Top + rxt1.Height + 9;
                ipt1.Top = ip_l.Top + 8;

                op_l.Top = ipt1.Top + ipt1.Height + 9;
                opt1.Top = op_l.Top + 8;

                pc_l.Top = opt1.Top + opt1.Height + 9;
                pct1.Top = pc_l.Top + 8;

                endl.Top = pct1.Top + pct1.Height + 120;

        }

        private void pht1_TextChanged(object sender, EventArgs e)
        {

            if (pht1.Text.Length % 55 == 0 && pht1.Text.Length > phlength)
            {
                pht1.AppendText("\n");
            }
            phlength = pht1.Text.Length;

            if (pht1.Lines.Length == 0 || pht1.Lines.Length == 1)
                pht1.Height = 24;
            else
            {
                if (pht1.Lines.Length < 5)
                    pht1.Height = 24 + (pht1.Lines.Length - 1) * 31;
                else
                    pht1.Height = 24 + (pht1.Lines.Length - 1) * 25;

            }

            fh_l.Top = pht1.Top + pht1.Height + 9;
            fht1.Top = fh_l.Top + 8;

            pe_l.Top = fht1.Top + fht1.Height + 9;
            pet1.Top = pe_l.Top + 8;

            g1_l.Top = pet1.Top + pet1.Height + 19;
            g1t1.Top = g1_l.Top + 4;
            p1_l.Top = g1_l.Top;
            ptxt.Top = g1_l.Top + 4;
            a1_l.Top = g1_l.Top;
            atxt.Top = g1_l.Top + 4;
            l1_l.Top = g1_l.Top;
            ltxt.Top = g1_l.Top + 4;
            g2_l.Top = g1_l.Top;
            g2t1.Top = g1_l.Top + 4;
            hc_l.Top = g1_l.Top;
            hct1.Top = g1_l.Top + 4;
            ht_l.Top = g1_l.Top;
            htt1.Top = g1_l.Top + 4;
            wg_l.Top = g1_l.Top;
            wgt1.Top = g1_l.Top + 4;
            kg_l.Top = g1_l.Top + 6;
            bp_l.Top = g1_l.Top;
            bpt1.Top = g1_l.Top + 4;

            dd_l.Top = pet1.Top + pet1.Height + 62;
            ddt1.Top = dd_l.Top + 8;

            px_l.Top = ddt1.Top + ddt1.Height + 9;
            pxt1.Top = px_l.Top + 8;

            rx_l.Top = pxt1.Top + pxt1.Height + 9;
            rxt1.Top = rx_l.Top + 8;

            ip_l.Top = rxt1.Top + rxt1.Height + 9;
            ipt1.Top = ip_l.Top + 8;

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;

        }

        private void fht1_TextChanged(object sender, EventArgs e)
        {

            if (fht1.Text.Length % 55 == 0 && fht1.Text.Length > fhlength)
            {
                fht1.AppendText("\n");
            }
            fhlength = fht1.Text.Length;

            if (fht1.Lines.Length == 0 || fht1.Lines.Length == 1)
                fht1.Height = 24;
            else
            {
                if (fht1.Lines.Length < 5)
                    fht1.Height = 24 + (fht1.Lines.Length - 1) * 31;
                else
                    fht1.Height = 24 + (fht1.Lines.Length - 1) * 25;

            }

            pe_l.Top = fht1.Top + fht1.Height + 9;
            pet1.Top = pe_l.Top + 8;

            g1_l.Top = pet1.Top + pet1.Height + 19;
            g1t1.Top = g1_l.Top + 4;
            p1_l.Top = g1_l.Top;
            ptxt.Top = g1_l.Top + 4;
            a1_l.Top = g1_l.Top;
            atxt.Top = g1_l.Top + 4;
            l1_l.Top = g1_l.Top;
            ltxt.Top = g1_l.Top + 4;
            g2_l.Top = g1_l.Top;
            g2t1.Top = g1_l.Top + 4;
            hc_l.Top = g1_l.Top;
            hct1.Top = g1_l.Top + 4;
            ht_l.Top = g1_l.Top;
            htt1.Top = g1_l.Top + 4;
            wg_l.Top = g1_l.Top;
            wgt1.Top = g1_l.Top + 4;
            kg_l.Top = g1_l.Top + 6;
            bp_l.Top = g1_l.Top;
            bpt1.Top = g1_l.Top + 4;

            dd_l.Top = pet1.Top + pet1.Height + 62;
            ddt1.Top = dd_l.Top + 8;

            px_l.Top = ddt1.Top + ddt1.Height + 9;
            pxt1.Top = px_l.Top + 8;

            rx_l.Top = pxt1.Top + pxt1.Height + 9;
            rxt1.Top = rx_l.Top + 8;

            ip_l.Top = rxt1.Top + rxt1.Height + 9;
            ipt1.Top = ip_l.Top + 8;

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;

        }

        private void pet1_TextChanged(object sender, EventArgs e)
        {

            if (pet1.Text.Length % 55 == 0 && pet1.Text.Length > pelength)
            {
                pet1.AppendText("\n");
            }
            pelength = pet1.Text.Length;

            if (pet1.Lines.Length == 0 || pet1.Lines.Length == 1)
                pet1.Height = 24;
            else
            {
                if (pet1.Lines.Length < 5)
                    pet1.Height = 24 + (pet1.Lines.Length - 1) * 31;
                else
                    pet1.Height = 24 + (pet1.Lines.Length - 1) * 25;

            }

            g1_l.Top = pet1.Top + pet1.Height + 19;
            g1t1.Top = g1_l.Top + 4;
            p1_l.Top = g1_l.Top;
            ptxt.Top = g1_l.Top + 4;
            a1_l.Top = g1_l.Top;
            atxt.Top = g1_l.Top + 4;
            l1_l.Top = g1_l.Top;
            ltxt.Top = g1_l.Top + 4;
            g2_l.Top = g1_l.Top;
            g2t1.Top = g1_l.Top + 4;
            hc_l.Top = g1_l.Top;
            hct1.Top = g1_l.Top + 4;
            ht_l.Top = g1_l.Top;
            htt1.Top = g1_l.Top + 4;
            wg_l.Top = g1_l.Top;
            wgt1.Top = g1_l.Top + 4;
            kg_l.Top = g1_l.Top + 6;
            bp_l.Top = g1_l.Top;
            bpt1.Top = g1_l.Top + 4;

            dd_l.Top = pet1.Top + pet1.Height + 62;
            ddt1.Top = dd_l.Top + 8;

            px_l.Top = ddt1.Top + ddt1.Height + 9;
            pxt1.Top = px_l.Top + 8;

            rx_l.Top = pxt1.Top + pxt1.Height + 9;
            rxt1.Top = rx_l.Top + 8;

            ip_l.Top = rxt1.Top + rxt1.Height + 9;
            ipt1.Top = ip_l.Top + 8;

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;

        }

        private void ddt1_TextChanged(object sender, EventArgs e)
        {

            if (ddt1.Text.Length % 55 == 0 && ddt1.Text.Length > ddlength)
            {
                ddt1.AppendText("\n");
            }
            ddlength = ddt1.Text.Length;

            if (ddt1.Lines.Length == 0 || ddt1.Lines.Length == 1)
                ddt1.Height = 24;
            else
            {
                if (ddt1.Lines.Length < 5)
                    ddt1.Height = 24 + (ddt1.Lines.Length - 1) * 31;
                else
                    ddt1.Height = 24 + (ddt1.Lines.Length - 1) * 25;

            }

            px_l.Top = ddt1.Top + ddt1.Height + 9;
            pxt1.Top = px_l.Top + 8;

            rx_l.Top = pxt1.Top + pxt1.Height + 9;
            rxt1.Top = rx_l.Top + 8;

            ip_l.Top = rxt1.Top + rxt1.Height + 9;
            ipt1.Top = ip_l.Top + 8;

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;
        }

        private void pxt1_TextChanged(object sender, EventArgs e)
        {

            if (pxt1.Text.Length % 55 == 0 && pxt1.Text.Length > pxlength)
            {
                pxt1.AppendText("\n");
            }
            pxlength = pxt1.Text.Length;

            if (pxt1.Lines.Length == 0 || pxt1.Lines.Length == 1)
                pxt1.Height = 24;
            else
            {
                if (pxt1.Lines.Length < 5)
                    pxt1.Height = 24 + (pxt1.Lines.Length - 1) * 31;
                else
                    pxt1.Height = 24 + (pxt1.Lines.Length - 1) * 25;

            }

            rx_l.Top = pxt1.Top + pxt1.Height + 9;
            rxt1.Top = rx_l.Top + 8;

            ip_l.Top = rxt1.Top + rxt1.Height + 9;
            ipt1.Top = ip_l.Top + 8;

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;
        }

        private void rxt1_TextChanged(object sender, EventArgs e)
        {

            if (rxt1.Text.Length % 55 == 0 && rxt1.Text.Length > rxlength)
            {
                rxt1.AppendText("\n");
            }
            rxlength = rxt1.Text.Length;

            if (rxt1.Lines.Length == 0 || rxt1.Lines.Length == 1)
                rxt1.Height = 24;
            else
            {
                if (rxt1.Lines.Length < 5)
                    rxt1.Height = 24 + (rxt1.Lines.Length - 1) * 31;
                else
                    rxt1.Height = 24 + (rxt1.Lines.Length - 1) * 25;

            }

            ip_l.Top = rxt1.Top + rxt1.Height + 9;
            ipt1.Top = ip_l.Top + 8;

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;
        }

        private void ipt1_TextChanged(object sender, EventArgs e)
        {

            if (ipt1.Text.Length % 55 == 0 && ipt1.Text.Length > iplength)
            {
                ipt1.AppendText("\n");
            }
            iplength = ipt1.Text.Length;

            if (ipt1.Lines.Length == 0 || ipt1.Lines.Length == 1)
                ipt1.Height = 24;
            else
            {
                if (ipt1.Lines.Length < 5)
                    ipt1.Height = 24 + (ipt1.Lines.Length - 1) * 31;
                else
                    ipt1.Height = 24 + (ipt1.Lines.Length - 1) * 25;

            }

            op_l.Top = ipt1.Top + ipt1.Height + 9;
            opt1.Top = op_l.Top + 8;

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;
        }

        private void opt1_TextChanged(object sender, EventArgs e)
        {

            if (opt1.Text.Length % 55 == 0 && opt1.Text.Length > oplength)
            {
                opt1.AppendText("\n");
            }
            oplength = opt1.Text.Length;

            if (opt1.Lines.Length == 0 || opt1.Lines.Length == 1)
                opt1.Height = 24;
            else
            {
                if (opt1.Lines.Length < 5)
                    opt1.Height = 24 + (opt1.Lines.Length - 1) * 31;
                else
                    opt1.Height = 24 + (opt1.Lines.Length - 1) * 25;

            }

            pc_l.Top = opt1.Top + opt1.Height + 9;
            pct1.Top = pc_l.Top + 8;

            endl.Top = pct1.Top + pct1.Height + 120;
        }

        private void pct1_TextChanged(object sender, EventArgs e)
        {

            if (pct1.Text.Length % 55 == 0 && pct1.Text.Length > pclength)
            {
                pct1.AppendText("\n");
            }
            pclength = pct1.Text.Length;

            if (pct1.Lines.Length == 0 || pct1.Lines.Length == 1)
                pct1.Height = 24;
            else
            {
                if (pct1.Lines.Length < 5)
                    pct1.Height = 24 + (pct1.Lines.Length - 1) * 31;
                else
                    pct1.Height = 24 + (pct1.Lines.Length - 1) * 25;

            }

            endl.Top = pct1.Top + pct1.Height + 120;
        }

        /////////////// MouseClick Events For Labels on the Right Panel ///////////////
        private void rnc_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new CC();
                frm.Top = 175;
                frm.Left = 700;
                frm.ShowDialog();
                
                if (CC.myword != "")
                {
                    try
                    {
                        System.Diagnostics.Process.Start(CC.myword);
                    }
                    catch
                    {
                        MessageBox.Show("Algorithm not found");
                    }

                }

                try
                {
                    CC.str = CC.str.Replace("\n", " ");
                    CC.str = CC.str.Replace("\r", " ");
                }
                catch { }

                if (rsbt1.Text == "")
                {
                    try
                    {
                        for (int i = 23; i < 5500; i += 23)
                        {
                            if (CC.str.Substring(i-23,23).Contains(","))
                            {
                                while (CC.str[i] != ',')
                                    i--;
                                i++;
                            }

                            CC.str = CC.str.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rsbt1.Text = CC.str;
                }
                else
                    if (rsbt1.Text != "" && CC.str != "")
                    {
                        rsbt1.Text = rsbt1.Text.Replace("\n", " ");
                        CC.str = rsbt1.Text + ", " + CC.str;
                        try
                        {
                            for (int i = 23; i < 5500; i += 23)
                            {
                                if (CC.str.Substring(i-23,23).Contains(","))
                                {
                                    while (CC.str[i] != ',')
                                        i--;
                                    i++;
                                }

                                CC.str = CC.str.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rsbt1.Text = CC.str;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                     AV_Folder.pic_name = "";
                    if (rsbt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-NCC";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    
                    //SqlConnection sqlconn = new SqlConnection(cm.cs);
                    //sqlconn.Open();
                    //SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(cc) values('" + rsbt1.SelectedText + "')", sqlconn);
                    //sqlcmd.ExecuteNonQuery();
                    //sqlconn.Close();

                }
        }

        private void rsb_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new  Sb();
                frm.Top = 175;
                frm.Left = 700;
                frm.ShowDialog();
                try
                {
                    Sb.str_sb = Sb.str_sb.Replace("\n", " ");
                    Sb.str_sb = Sb.str_sb.Replace("\r", " ");
                }
                catch { }


                if (rsbt1.Text == "")
                {
                    try
                    {
                        for (int i = 23; i < 5500; i += 23)
                        {
                            if (Sb.str_sb.Substring(i-23,23).Contains(","))
                            {
                                while (Sb.str_sb[i] != ',')
                                    i--;
                                i++;
                            }

                            Sb.str_sb = Sb.str_sb.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rsbt1.Text = Sb.str_sb;
                }
                else
                    if (rsbt1.Text != "" && Sb.str_sb != "")
                    {
                        rsbt1.Text = rsbt1.Text.Replace("\n", " ");
                        Sb.str_sb = rsbt1.Text + ", " + Sb.str_sb;
                        try
                        {
                            for (int i = 23; i < 5500; i += 23)
                            {
                                if (Sb.str_sb.Substring(i - 23, 23).Contains(","))
                                {
                                    while (Sb.str_sb[i] != ',')
                                        i--;
                                    i++;
                                }

                                Sb.str_sb = Sb.str_sb.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rsbt1.Text = Sb.str_sb;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (rsbt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-Sb";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {

                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(sb,fsb) values('" + rsbt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void rob_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new Ob();
                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "rob_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }
                frm.ShowDialog();
                try
                {
                    Ob.str_ob = Ob.str_ob.Replace("\n", " ");
                    Ob.str_ob = Ob.str_ob.Replace("\r", " ");
                }
                catch { }

                if (robt1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (Ob.str_ob.Substring(i - 28, 28).Contains(","))
                            {
                                while (Ob.str_ob[i] != ',')
                                    i--;
                                i += 2;
                            }

                            Ob.str_ob = Ob.str_ob.Insert(i, "\n");
                        }
                    }
                    catch { }
                    robt1.Text = Ob.str_ob;
                }
                else
                    if (robt1.Text != "" && Ob.str_ob != "")
                    {
                        robt1.Text = robt1.Text.Replace("\n", " ");
                        Ob.str_ob = robt1.Text + ", " + Ob.str_ob;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (Ob.str_ob.Substring(i - 28, 28).Contains(","))
                                {
                                    while (Ob.str_ob[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                Ob.str_ob = Ob.str_ob.Insert(i, "\n");
                            }
                        }
                        catch { }
                        robt1.Text = Ob.str_ob;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (robt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-Ob";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {

                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(ob,fob) values('" + robt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void ras_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new As();
                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "ras_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }
                frm.ShowDialog();
                try
                {
                    As.str_as = As.str_as.Replace("\n", " ");
                    As.str_as = As.str_as.Replace("\r", " ");
                }
                catch { }

                if (rast1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (As.str_as.Substring(i - 28, 28).Contains(","))
                            {
                                while (As.str_as[i] != ',')
                                    i--;
                                i += 2;
                            }

                            As.str_as = As.str_as.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rast1.Text = As.str_as;
                }
                else
                    if (rast1.Text != "" && As.str_as != "")
                    {
                        rast1.Text = rast1.Text.Replace("\n", " ");
                        As.str_as = rast1.Text + ", " + As.str_as;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (As.str_as.Substring(i - 28, 28).Contains(","))
                                {
                                    while (As.str_as[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                As.str_as = As.str_as.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rast1.Text = As.str_as;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (rast1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-As";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(ass,fas) values('" + rast1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void rpl_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new PL();
                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "rpl_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }
                frm.ShowDialog();
                try
                {
                    PL.str_pl = PL.str_pl.Replace("\n", " ");
                    PL.str_pl = PL.str_pl.Replace("\r", " ");
                }
                catch { }

                if (rplt1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (PL.str_pl.Substring(i - 28, 28).Contains(","))
                            {
                                while (PL.str_pl[i] != ',')
                                    i--;
                                i += 2;
                            }

                            PL.str_pl = PL.str_pl.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rplt1.Text = PL.str_pl;
                }
                else
                    if (rplt1.Text != "" && PL.str_pl != "")
                    {
                        rplt1.Text = rplt1.Text.Replace("\n", " ");
                        PL.str_pl = rplt1.Text + ", " + PL.str_pl;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (PL.str_pl.Substring(i - 28, 28).Contains(","))
                                {
                                    while (PL.str_pl[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                PL.str_pl = PL.str_pl.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rplt1.Text = PL.str_pl;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (rplt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-PL";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(pl,fpl) values('" + rplt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void rdd_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new rDD();

                if (rdd_l.Top < 450)
                {
                    frm.Top = rdd_l.Top + 110;
                    frm.Left = rdd_l.Left + 700;
                }
                else
                {
                    frm.Top = rdd_l.Top - 120;
                    frm.Left = rdd_l.Left + 700;
                }
                frm.ShowDialog();
                try
                {
                    rDD.str_rDD = rDD.str_rDD.Replace("\n", " ");
                    rDD.str_rDD = rDD.str_rDD.Replace("\r", " ");
                }
                catch { }

                if (rddt1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (rDD.str_rDD.Substring(i - 28, 28).Contains(" "))
                            {
                                while (rDD.str_rDD[i] != ' ')
                                    i--;
                                i++;
                            }

                            rDD.str_rDD = rDD.str_rDD.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rddt1.Text = rDD.str_rDD;
                }
                else
                    if (rddt1.Text != "" && rDD.str_rDD != "")
                    {
                        rddt1.Text = rddt1.Text.Replace("\n", " ");
                        rDD.str_rDD = rddt1.Text + " " + rDD.str_rDD;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (rDD.str_rDD.Substring(i - 28, 28).Contains(" "))
                                {
                                    while (rDD.str_rDD[i] != ' ')
                                        i--;
                                    i++;
                                }

                                rDD.str_rDD = rDD.str_rDD.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rddt1.Text = rDD.str_rDD;

                    }
            }
            //else
            //    if (e.Button == MouseButtons.Right)
            //    {
            //        SqlConnection sqlconn = new SqlConnection(cm.cs);
            //        sqlconn.Open();
            //        SqlCommand sqlcmd = new SqlCommand("Insert into firstvisit(dd) values('" + ddt1.SelectedText + "')", sqlconn);
            //        sqlcmd.ExecuteNonQuery();
            //        sqlconn.Close();

            //    }
        }

        private void rpx_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Printer_Px.Printer_Px_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();
                Printer_Px.Printer_Px_cc = cct1.Text;
                Printer_Px.Printer_Px_dx = dxt1.Text;
                try
                {
                    Printer_Px.Printer_Px_pi = pit1.Lines[0].ToString();
                }
                catch
                {
                    Printer_Px.Printer_Px_pi = "";
                }

                Form frm = new rpx();

                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "rpx_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    rpx.str_rpx = rpx.str_rpx.Replace("\n", " ");
                    rpx.str_rpx = rpx.str_rpx.Replace("\r", " ");
                }
                catch { }

                if (rpxt1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (rpx.str_rpx.Substring(i - 28, 28).Contains(","))
                            {
                                while (rpx.str_rpx[i] != ',')
                                    i--;
                                i += 2;
                            }

                            rpx.str_rpx = rpx.str_rpx.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rpxt1.Text = rpx.str_rpx;
                }
                else
                    if (rpxt1.Text != "" && rpx.str_rpx != "")
                    {
                        rpxt1.Text = rpxt1.Text.Replace("\n", " ");
                        rpx.str_rpx = rpxt1.Text + ", " + rpx.str_rpx;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (rpx.str_rpx.Substring(i - 28, 28).Contains(","))
                                {
                                    while (rpx.str_rpx[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                rpx.str_rpx = rpx.str_rpx.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rpxt1.Text = rpx.str_rpx;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (rpxt1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-PX";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(px,fpx) values('" + rpxt1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void rrx_l_MouseClick(object sender, MouseEventArgs e)
        {
            Prescription.Prescription_age = "";
            Prescription.Prescription_name = "";
            Prescription.Prescription_ccdx = "";

            Prescription.Prescription_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();
            if (age_t.Text.Length > 3)
            {
                Prescription.Prescription_age = age_t.Text.Substring(0, age_t.Text.IndexOf('/')) + " " + "ساله";
            }

            if (dxt1.Text != "")
            {
                if (dxt1.Text.Contains(",") == true)
                {
                    Prescription.Prescription_ccdx = "Dx: " + dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                }
                else
                    Prescription.Prescription_ccdx = "Dx: " + dxt1.Text;
            }
            else
            {
                if (cct1.Text.Contains(",") == true)
                {
                    Prescription.Prescription_ccdx = "CC: " + cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                }
                else
                    Prescription.Prescription_ccdx = "CC: " + cct1.Text;
            }

            Prescription.Prescription_ccdx = Prescription.Prescription_ccdx.Replace("\n", " ");
             
            
            Dosage.wg = wgt1.Text;
            Dosage.record = "";

            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            Rx frm = new Rx();
            frm.ShowDialog();

            rrxt1.Text = rrxt1.Text + Dosage.record;
        }

        private void rip_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new rip();

                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "rip_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    rip.str_rip = rip.str_rip.Replace("\n", " ");
                    rip.str_rip = rip.str_rip.Replace("\r", " ");
                }
                catch { }

                if (ript1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (rip.str_rip.Substring(i - 28, 28).Contains(","))
                            {
                                while (rip.str_rip[i] != ',')
                                    i--;
                                i += 2;
                            }

                            rip.str_rip = rip.str_rip.Insert(i, "\n");
                        }
                    }
                    catch { }
                    ript1.Text = rip.str_rip;
                }
                else
                    if (ript1.Text != "" && rip.str_rip != "")
                    {
                        ript1.Text = ript1.Text.Replace("\n", " ");
                        rip.str_rip = ript1.Text + ", " + rip.str_rip;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (rip.str_rip.Substring(i - 28, 28).Contains(","))
                                {
                                    while (rip.str_rip[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                rip.str_rip = rip.str_rip.Insert(i, "\n");
                            }
                        }
                        catch { }
                        ript1.Text = rip.str_rip;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (ript1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-IP";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(ip,fip) values('" + ript1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                }
        }

        private void rop_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new rop();

                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "rop_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    rop.str_rop = rop.str_rop.Replace("\n", " ");
                    rop.str_rop = rop.str_rop.Replace("\r", " ");
                }
                catch { }

                if (ropt1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (rop.str_rop.Substring(i - 28, 28).Contains(","))
                            {
                                while (rop.str_rop[i] != ',')
                                    i--;
                                i += 2;
                            }

                            rop.str_rop = rop.str_rop.Insert(i, "\n");
                        }
                    }
                    catch { }
                    ropt1.Text = rop.str_rop;
                }
                else
                    if (ropt1.Text != "" && rop.str_rop != "")
                    {
                        ropt1.Text = ropt1.Text.Replace("\n", " ");
                        rop.str_rop = ropt1.Text + ", " + rop.str_rop;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (rop.str_rop.Substring(i - 28, 28).Contains(","))
                                {
                                    while (rop.str_rop[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                rop.str_rop = rop.str_rop.Insert(i, "\n");
                            }
                        }
                        catch { }
                        ropt1.Text = rop.str_rop;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                   AV_Folder.pic_name = "";
                   if (ropt1.SelectedText == "")
                   {
                       if (dxt1.Text != "")
                       {
                           if (dxt1.Text.Contains(","))
                           {
                               AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                           }
                           else
                           {
                               AV_Folder.pic_name = dxt1.Text;
                           }
                       }
                       else
                       {
                           if (cct1.Text != "")
                           {
                               if (cct1.Text.Contains(","))
                               {
                                   AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                               }
                               else
                               {
                                   AV_Folder.pic_name = cct1.Text;
                               }
                           }
                       }
                       AV_Folder.pic_name = AV_Folder.pic_name + "-OP";
                       AV_Folder frm = new AV_Folder();
                       frm.Show();
                   }
                   else
                   {
                       SqlConnection sqlconn = new SqlConnection(cm.cs);
                       sqlconn.Open();
                       SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(op,fop) values('" + ropt1.SelectedText + "','" + filter + "')", sqlconn);
                       sqlcmd.ExecuteNonQuery();
                       sqlconn.Close();
                   }
                }

        }

        private void rco_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form frm = new rco();

                foreach (Control c1 in RightPnl.Controls)
                {
                    if (c1.Name.ToString() == "rco_l")
                    {
                        if (c1.Top < 450)
                        {
                            frm.Top = c1.Top + 110;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                        else
                        {
                            frm.Top = c1.Top - 120;
                            frm.Left = c1.Left + 700;
                            break;
                        }
                    }
                }

                frm.ShowDialog();
                try
                {
                    rco.str_rco = rco.str_rco.Replace("\n", " ");
                    rco.str_rco = rco.str_rco.Replace("\r", " ");
                }
                catch { }

                if (rcot1.Text == "")
                {
                    try
                    {
                        for (int i = 28; i < 5500; i += 28)
                        {
                            if (rco.str_rco.Substring(i - 28, 28).Contains(","))
                            {
                                while (rco.str_rco[i] != ',')
                                    i--;
                                i += 2;
                            }

                            rco.str_rco = rco.str_rco.Insert(i, "\n");
                        }
                    }
                    catch { }
                    rcot1.Text = rco.str_rco;
                }
                else
                    if (rcot1.Text != "" && rco.str_rco != "")
                    {
                        rcot1.Text = rcot1.Text.Replace("\n", " ");
                        rco.str_rco = rcot1.Text + ", " + rco.str_rco;
                        try
                        {
                            for (int i = 28; i < 5500; i += 28)
                            {
                                if (rco.str_rco.Substring(i - 28, 28).Contains(","))
                                {
                                    while (rco.str_rco[i] != ',')
                                        i--;
                                    i += 2;
                                }

                                rco.str_rco = rco.str_rco.Insert(i, "\n");
                            }
                        }
                        catch { }
                        rcot1.Text = rco.str_rco;
                    }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (rcot1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-Co";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                    else
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Insert into secondvisit(co,fco) values('" + rcot1.SelectedText + "','" + filter + "')", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }
                }
        }

        private void rpc_l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMI.bmi_ht = htt1.Text;
                BMI.bmi_wg = wgt1.Text;
                try
                {
                    BMI.bmi_age = age_t.Text.Substring(0, age_t.Text.IndexOf("/"));
                }
                catch
                {
                    BMI.bmi_age = "1";
                }


                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

                Form frm = new Preventive();
                frm.ShowDialog();

                htt1.Text = BMI.bmi_ht;
                wgt1.Text = BMI.bmi_wg;

                if (rpct1.Text == "")
                    rpct1.Text = Preventive.record_pc;
                else
                    rpct1.Text = rpct1.Text + "\n" + Preventive.record_pc;
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    AV_Folder.pic_name = "";
                    if (rpct1.SelectedText == "")
                    {
                        if (dxt1.Text != "")
                        {
                            if (dxt1.Text.Contains(","))
                            {
                                AV_Folder.pic_name = dxt1.Text.Substring(0, dxt1.Text.IndexOf(','));
                            }
                            else
                            {
                                AV_Folder.pic_name = dxt1.Text;
                            }
                        }
                        else
                        {
                            if (cct1.Text != "")
                            {
                                if (cct1.Text.Contains(","))
                                {
                                    AV_Folder.pic_name = cct1.Text.Substring(0, cct1.Text.IndexOf(','));
                                }
                                else
                                {
                                    AV_Folder.pic_name = cct1.Text;
                                }
                            }
                        }
                        AV_Folder.pic_name = AV_Folder.pic_name + "-PC";
                        AV_Folder frm = new AV_Folder();
                        frm.Show();
                    }
                }
        }

        /////////////// TextChange Events For TextBoxes on the Right Panel //////////////
        private void rsbt1_TextChanged(object sender, EventArgs e)
        {

            if (rsbt1.Text.Length % 23 == 0 && rsbt1.Text.Length > rsblength)
            {
                rsbt1.AppendText("\n");
            }
            rsblength = rsbt1.Text.Length;

            sb_flag = true;
            if (rsbt1.Lines.Length == 0 || rsbt1.Lines.Length == 1)
                rsbt1.Height = 24;
            else
            {
                if (rsbt1.Lines.Length < 5)
                    rsbt1.Height = 24 + (rsbt1.Lines.Length - 1) * 31;
                else
                    rsbt1.Height = 24 + (rsbt1.Lines.Length - 1) * 25;

            }

            rob_l.Top = rsbt1.Top + rsbt1.Height + 9;
            robt1.Top = rob_l.Top + 8;

            ras_l.Top = robt1.Top + robt1.Height + 9;
            rast1.Top = ras_l.Top + 8;

            rpl_l.Top = rast1.Top + rast1.Height + 9;
            rplt1.Top = rpl_l.Top + 8;

            rdd_l.Top = rplt1.Top + rplt1.Height + 9;
            rddt1.Top = rdd_l.Top + 6;

            rpx_l.Top = rddt1.Top + rddt1.Height + 9;
            rpxt1.Top = rpx_l.Top + 8;

            rrx_l.Top = rpxt1.Top + rpxt1.Height + 9;
            rrxt1.Top = rrx_l.Top + 8;

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        private void robt1_TextChanged(object sender, EventArgs e)
        {
            if (robt1.Text.Length % 27 == 0 && robt1.Text.Length > roblength)
            {
                robt1.AppendText("\n");
            }
            roblength = robt1.Text.Length;

            ob_flag = true;
            if (robt1.Lines.Length == 0 || robt1.Lines.Length == 1)
                robt1.Height = 24;
            else
            {
                if (robt1.Lines.Length < 5)
                    robt1.Height = 24 + (robt1.Lines.Length - 1) * 31;
                else
                    robt1.Height = 24 + (robt1.Lines.Length - 1) * 25;

            }

            ras_l.Top = robt1.Top + robt1.Height + 9;
            rast1.Top = ras_l.Top + 8;

            rpl_l.Top = rast1.Top + rast1.Height + 9;
            rplt1.Top = rpl_l.Top + 8;

            rdd_l.Top = rplt1.Top + rplt1.Height + 9;
            rddt1.Top = rdd_l.Top + 6;

            rpx_l.Top = rddt1.Top + rddt1.Height + 9;
            rpxt1.Top = rpx_l.Top + 8;

            rrx_l.Top = rpxt1.Top + rpxt1.Height + 9;
            rrxt1.Top = rrx_l.Top + 8;

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;

        }

        private void rast1_TextChanged(object sender, EventArgs e)
        {
            if (rast1.Text.Length % 27 == 0 && rast1.Text.Length > raslength)
            {
                rast1.AppendText("\n");
            }
            raslength = rast1.Text.Length;
            as_flag = true;
            if (rast1.Lines.Length == 0 || rast1.Lines.Length == 1)
                rast1.Height = 24;
            else
            {
                if (rast1.Lines.Length < 5)
                    rast1.Height = 24 + (rast1.Lines.Length - 1) * 31;
                else
                    rast1.Height = 24 + (rast1.Lines.Length - 1) * 25;

            }

            rpl_l.Top = rast1.Top + rast1.Height + 9;
            rplt1.Top = rpl_l.Top + 8;

            rdd_l.Top = rplt1.Top + rplt1.Height + 9;
            rddt1.Top = rdd_l.Top + 6;

            rpx_l.Top = rddt1.Top + rddt1.Height + 9;
            rpxt1.Top = rpx_l.Top + 8;

            rrx_l.Top = rpxt1.Top + rpxt1.Height + 9;
            rrxt1.Top = rrx_l.Top + 8;

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;

        }

        private void rplt1_TextChanged(object sender, EventArgs e)
        {
            if (rplt1.Text.Length % 27 == 0 && rplt1.Text.Length > rpllength)
            {
                rplt1.AppendText("\n");
            }
            rpllength = rplt1.Text.Length;

            pl_flag = true;
            if (rplt1.Lines.Length == 0 || rplt1.Lines.Length == 1)
                rplt1.Height = 24;
            else
            {
                if (rplt1.Lines.Length < 5)
                    rplt1.Height = 24 + (rplt1.Lines.Length - 1) * 31;
                else
                    rplt1.Height = 24 + (rplt1.Lines.Length - 1) * 25;

            }

            rdd_l.Top = rplt1.Top + rplt1.Height + 9;
            rddt1.Top = rdd_l.Top + 6;

            rpx_l.Top = rddt1.Top + rddt1.Height + 9;
            rpxt1.Top = rpx_l.Top + 8;

            rrx_l.Top = rpxt1.Top + rpxt1.Height + 9;
            rrxt1.Top = rrx_l.Top + 8;

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;

        }

        private void rddt1_TextChanged(object sender, EventArgs e)
        {
            if (rddt1.Text.Length % 27 == 0 && rddt1.Text.Length > rddlength)
            {
                rddt1.AppendText("\n");
            }
            rddlength = rddt1.Text.Length;

            dd_flag = true;
            if (rddt1.Lines.Length == 0 || rddt1.Lines.Length == 1)
                rddt1.Height = 24;
            else
            {
                if (rddt1.Lines.Length < 5)
                    rddt1.Height = 24 + (rddt1.Lines.Length - 1) * 31;
                else
                    rddt1.Height = 24 + (rddt1.Lines.Length - 1) * 25;

            }

            rpx_l.Top = rddt1.Top + rddt1.Height + 9;
            rpxt1.Top = rpx_l.Top + 8;

            rrx_l.Top = rpxt1.Top + rpxt1.Height + 9;
            rrxt1.Top = rrx_l.Top + 8;

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;

        }

        private void rpxt1_TextChanged(object sender, EventArgs e)
        {
            if (rpxt1.Text.Length % 27 == 0 && rpxt1.Text.Length > rpxlength)
            {
                rpxt1.AppendText("\n");
            }
            rpxlength = rpxt1.Text.Length;
            px_flag = true;
            if (rpxt1.Lines.Length == 0 || rpxt1.Lines.Length == 1)
                rpxt1.Height = 24;
            else
            {
                if (rpxt1.Lines.Length < 5)
                    rpxt1.Height = 24 + (rpxt1.Lines.Length - 1) * 31;
                else
                    rpxt1.Height = 24 + (rpxt1.Lines.Length - 1) * 25;

            }

            rrx_l.Top = rpxt1.Top + rpxt1.Height + 9;
            rrxt1.Top = rrx_l.Top + 8;

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        private void rrxt1_TextChanged(object sender, EventArgs e)
        {
            if (rrxt1.Text.Length % 27 == 0 && rrxt1.Text.Length > rrxlength)
            {
                rrxt1.AppendText("\n");
            }
            rrxlength = rrxt1.Text.Length;

            rx_flag = true;
            if (rrxt1.Lines.Length == 0 || rrxt1.Lines.Length == 1)
                rrxt1.Height = 24;
            else
            {
                if (rrxt1.Lines.Length < 5)
                    rrxt1.Height = 24 + (rrxt1.Lines.Length - 1) * 31;
                else
                    rrxt1.Height = 24 + (rrxt1.Lines.Length - 1) * 25;

            }

            rip_l.Top = rrxt1.Top + rrxt1.Height + 9;
            ript1.Top = rip_l.Top + 8;

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        private void ript1_TextChanged(object sender, EventArgs e)
        {
            if (ript1.Text.Length % 27 == 0 && ript1.Text.Length > riplength)
            {
                ript1.AppendText("\n");
            }
            riplength = ript1.Text.Length;
            ip_flag = true;
            if (ript1.Lines.Length == 0 || ript1.Lines.Length == 1)
                ript1.Height = 24;
            else
            {
                if (ript1.Lines.Length < 5)
                    ript1.Height = 24 + (ript1.Lines.Length - 1) * 31;
                else
                    ript1.Height = 24 + (ript1.Lines.Length - 1) * 25;

            }

            rop_l.Top = ript1.Top + ript1.Height + 9;
            ropt1.Top = rop_l.Top + 8;

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        private void ropt1_TextChanged(object sender, EventArgs e)
        {
            if (ropt1.Text.Length % 27 == 0 && ropt1.Text.Length > roplength)
            {
                ropt1.AppendText("\n");
            }
            roplength = ropt1.Text.Length;

            op_flag = true;
            if (ropt1.Lines.Length == 0 || ropt1.Lines.Length == 1)
                ropt1.Height = 24;
            else
            {
                if (ropt1.Lines.Length < 5)
                    ropt1.Height = 24 + (ropt1.Lines.Length - 1) * 31;
                else
                    ropt1.Height = 24 + (ropt1.Lines.Length - 1) * 25;

            }

            rco_l.Top = ropt1.Top + ropt1.Height + 9;
            rcot1.Top = rco_l.Top + 8;

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        private void rcot1_TextChanged(object sender, EventArgs e)
        {
            if (rcot1.Text.Length % 27 == 0 && rcot1.Text.Length > rcolength)
            {
                rcot1.AppendText("\n");
            }
            rcolength = rcot1.Text.Length;

            co_flag = true;
            if (rcot1.Lines.Length == 0 || rcot1.Lines.Length == 1)
                rcot1.Height = 24;
            else
            {
                if (rcot1.Lines.Length < 5)
                    rcot1.Height = 24 + (rcot1.Lines.Length - 1) * 31;
                else
                    rcot1.Height = 24 + (rcot1.Lines.Length - 1) * 25;

            }

            rpc_l.Top = rcot1.Top + rcot1.Height + 9;
            rpct1.Top = rpc_l.Top + 8;

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        private void rpct1_TextChanged(object sender, EventArgs e)
        {
            if (rpct1.Text.Length % 27 == 0 && rpct1.Text.Length > rpclength)
            {
                rpct1.AppendText("\n");
            }
            rpclength = rpct1.Text.Length;
            pc_flag = true;
            if (rpct1.Lines.Length == 0 || rpct1.Lines.Length == 1)
                rpct1.Height = 24;
            else
            {
                if (rpct1.Lines.Length < 5)
                    rpct1.Height = 24 + (rpct1.Lines.Length - 1) * 31;
                else
                    rpct1.Height = 24 + (rpct1.Lines.Length - 1) * 25;

            }

            rend.Top = rpct1.Top + rpct1.Height + 120;
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (pp_conflict2 == false)
            //    pp_conflict1 = false;
            //else
            //{
            //    pp_conflict2 = false;
            //    return;
            //}

            myflag2 = false;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;
            if (myflag1 == false)
            {
                int i = 1;
                sqlcmd.CommandText = "select risk from sw";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    i = Int32.Parse(data["risk"].ToString());
                data.Close();

                if (i == 1)
                {
                    sqlcmd.CommandText = "select * from risk ";
                    data = sqlcmd.ExecuteReader();
                    i = 0;
                    int myindex = 0;
                    string query = "", mylabel = "", mydata = "";
                    bool[] arr_bool = new bool[50];
                    bool sum_bool = false;
                    int y, m, d, sy, sm, sd, fy, fm, fd;
                    y = m = d = sy = sm = sd = fy = fm = fd = 0;
                    string f, s;
                    int i1;
                    f = s = "";
                    while (data.Read())
                    {
                        i = 0;
                        query = data["query"].ToString();

                        while (true)
                        {
                            myindex = query.IndexOf('|');
                            mylabel = query.Substring(0, myindex);
                            query = query.Substring(myindex + 1, query.Length - myindex - 1);
                            myindex = query.IndexOf('|');
                            mydata = query.Substring(0, myindex);

                            switch (mylabel)
                            {
                                case "title":
                                    {
                                        if (title_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "bplace":
                                    {
                                        if (bplace_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "age":
                                    {

                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        ////////////
                                        i1 = s.IndexOf('/');
                                        if (i1 != 0)
                                            sy = Int32.Parse(s.Substring(0, i1));
                                        else
                                            sy = 0;

                                        s = s.Substring(i1 + 1, s.Length - i1 - 1);
                                        i1 = s.IndexOf('/');
                                        if (i1 != 0)
                                            sm = Int32.Parse(s.Substring(0, i1));
                                        else
                                            sm = 0;

                                        try
                                        {
                                            s = s.Substring(i1 + 1, s.Length - i1 - 1);
                                            if (i1 != 0)
                                                sd = Int32.Parse(s.Substring(0, i1));
                                            else
                                                sd = 0;
                                        }
                                        catch
                                        {
                                            sd = 0;
                                        }
                                        /////////
                                        i1 = f.IndexOf('/');
                                        if (i1 != 0)
                                            fy = Int32.Parse(f.Substring(0, i1));
                                        else
                                            fy = 0;

                                        f = f.Substring(i1 + 1, f.Length - i1 - 1);
                                        i1 = f.IndexOf('/');
                                        if (i1 != 0)
                                            fm = Int32.Parse(f.Substring(0, i1));
                                        else
                                            fm = 0;

                                        try
                                        {
                                            f = f.Substring(i1 + 1, f.Length - i1 - 1);
                                            if (i1 != 0)
                                                fd = Int32.Parse(f.Substring(0, i1));
                                            else
                                                fd = 0;
                                        }
                                        catch
                                        {
                                            fd = 0;
                                        }
                                        /////////
                                        string temp = age_t.Text;
                                        if (temp.Contains("/") == false)
                                        {
                                            y = 0;
                                            m = 0;
                                            d = 0;
                                        }
                                        else
                                        {
                                            i1 = temp.IndexOf('/');
                                            if (i1 != 0)
                                                y = Int32.Parse(temp.Substring(0, i1));
                                            else
                                                y = 0;

                                            temp = temp.Substring(i1 + 1, temp.Length - i1 - 1);
                                            i1 = temp.IndexOf('/');
                                            if (i1 != 0)
                                                m = Int32.Parse(temp.Substring(0, i1));
                                            else
                                                m = 0;

                                            try
                                            {
                                                temp = temp.Substring(i1 + 1, temp.Length - i1 - 1);
                                                if (i1 != 0)
                                                    d = Int32.Parse(temp.Substring(0, i1));
                                                else
                                                    d = 0;
                                            }
                                            catch
                                            {
                                                d = 0;
                                            }
                                        } // end of else
                                        sd = (sy * 365) + (sm * 30) + sd;
                                        fd = (fy * 365) + (fm * 30) + fd;
                                        d = (y * 365) + (m * 30) + d;

                                        if (d >= sd && d <= fd)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "job":
                                    {
                                        if (job_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "malol":
                                    {
                                        if (malol_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "gender":
                                    {
                                        if (gender_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "marray":
                                    {
                                        if (marray_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "child":
                                    {
                                        if (child_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "bar":
                                    {
                                        if (bar_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "bimeh":
                                    {
                                        if (bimeh_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                //case "life":
                                //    {
                                //        if (life_t.Text == mydata)
                                //            arr_bool[i] = true;
                                //        else
                                //            arr_bool[i] = false;

                                //        i++;
                                //        break;
                                //    }
                                //case "busy":
                                //    {
                                //        if (busy_t.Text == mydata)
                                //            arr_bool[i] = true;
                                //        else
                                //            arr_bool[i] = false;

                                //        i++;
                                //        break;
                                //    }
                                case "reception":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        ////////////
                                        i1 = s.IndexOf('/');
                                        if (i1 != 0)
                                            sy = Int32.Parse(s.Substring(0, i1));
                                        else
                                            sy = 0;

                                        s = s.Substring(i1 + 1, s.Length - i1 - 1);
                                        i1 = s.IndexOf('/');
                                        if (i1 != 0)
                                            sm = Int32.Parse(s.Substring(0, i1));
                                        else
                                            sm = 0;

                                        try
                                        {
                                            s = s.Substring(i1 + 1, s.Length - i1 - 1);
                                            if (i1 != 0)
                                                sd = Int32.Parse(s.Substring(0, i1));
                                            else
                                                sd = 0;
                                        }
                                        catch
                                        {
                                            sd = 0;
                                        }
                                        /////////
                                        i1 = f.IndexOf('/');
                                        if (i1 != 0)
                                            fy = Int32.Parse(f.Substring(0, i1));
                                        else
                                            fy = 0;

                                        f = f.Substring(i1 + 1, f.Length - i1 - 1);
                                        i1 = f.IndexOf('/');
                                        if (i1 != 0)
                                            fm = Int32.Parse(f.Substring(0, i1));
                                        else
                                            fm = 0;

                                        try
                                        {
                                            f = f.Substring(i1 + 1, f.Length - i1 - 1);
                                            if (i1 != 0)
                                                fd = Int32.Parse(f);
                                            else
                                                fd = 0;
                                        }
                                        catch
                                        {
                                            fd = 0;
                                        }
                                        /////////
                                        string temp = reception_t.Text;
                                        if (temp.Contains("/") == false)
                                        {
                                            y = 0;
                                            m = 0;
                                            d = 0;
                                        }
                                        else
                                        {
                                            i1 = temp.IndexOf('/');
                                            if (i1 != 0)
                                                y = Int32.Parse(temp.Substring(0, i1));
                                            else
                                                y = 0;

                                            temp = temp.Substring(i1 + 1, temp.Length - i1 - 1);
                                            i1 = temp.IndexOf('/');
                                            if (i1 != 0)
                                                m = Int32.Parse(temp.Substring(0, i1));
                                            else
                                                m = 0;

                                            try
                                            {
                                                temp = temp.Substring(i1 + 1, temp.Length - i1 - 1);
                                                if (i1 != 0)
                                                    d = Int32.Parse(temp.Substring(0, i1));
                                                else
                                                    d = 0;
                                            }
                                            catch
                                            {
                                                d = 0;
                                            }
                                        } // end of else
                                        sd = (sy * 365) + (sm * 30) + sd;
                                        fd = (fy * 365) + (fm * 30) + fd;
                                        d = (y * 365) + (m * 30) + d;

                                        if (d >= sd && d <= fd)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "tahsil":
                                    {
                                        if (tahsil_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "moaref":
                                    {
                                        if (moaref_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "city":
                                    {
                                        if (city_t.Text == mydata)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                ////////
                                case "cc":
                                    {
                                        if (cct1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "dx":
                                    {
                                        if (dxt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "pi":
                                    {
                                        if (pit1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "ph":
                                    {
                                        if (pht1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "fh":
                                    {
                                        if (fht1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "pe":
                                    {
                                        if (pet1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "g":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int g;
                                        try
                                        {
                                            g = Int32.Parse(g1t1.Text);
                                        }
                                        catch
                                        {
                                            g = 0;
                                        }

                                        int gstart, gfinish;
                                        try
                                        {
                                            gstart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            gstart = 0;
                                        }

                                        try
                                        {
                                            gfinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            gfinish = 0;
                                        }

                                        if (g >= gstart && g <= gfinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "p":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int p;
                                        try
                                        {
                                            p = Int32.Parse(ptxt.Text);
                                        }
                                        catch
                                        {
                                            p = 0;
                                        }

                                        int pstart, pfinish;
                                        try
                                        {
                                            pstart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            pstart = 0;
                                        }

                                        try
                                        {
                                            pfinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            pfinish = 0;
                                        }

                                        if (p >= pstart && p <= pfinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "a":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int a;
                                        try
                                        {
                                            a = Int32.Parse(atxt.Text);
                                        }
                                        catch
                                        {
                                            a = 0;
                                        }

                                        int astart, afinish;
                                        try
                                        {
                                            astart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            astart = 0;
                                        }

                                        try
                                        {
                                            afinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            afinish = 0;
                                        }

                                        if (a >= astart && a <= afinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "l":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int l;
                                        try
                                        {
                                            l = Int32.Parse(ltxt.Text);
                                        }
                                        catch
                                        {
                                            l = 0;
                                        }

                                        int lstart, lfinish;
                                        try
                                        {
                                            lstart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            lstart = 0;
                                        }

                                        try
                                        {
                                            lfinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            lfinish = 0;
                                        }

                                        if (l >= lstart && l <= lfinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "d":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int d1;
                                        try
                                        {
                                            d1 = Int32.Parse(g2t1.Text);
                                        }
                                        catch
                                        {
                                            d1 = 0;
                                        }

                                        int dstart, dfinish;
                                        try
                                        {
                                            dstart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            dstart = 0;
                                        }

                                        try
                                        {
                                            dfinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            dfinish = 0;
                                        }

                                        if (d1 >= dstart && d1 <= dfinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "hc":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int hc;
                                        try
                                        {
                                            hc = Int32.Parse(hct1.Text);
                                        }
                                        catch
                                        {
                                            hc = 0;
                                        }

                                        int hcstart, hcfinish;
                                        try
                                        {
                                            hcstart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            hcstart = 0;
                                        }

                                        try
                                        {
                                            hcfinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            hcfinish = 0;
                                        }

                                        if (hc >= hcstart && hc <= hcfinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "wg":
                                    {
                                        i1 = mydata.LastIndexOf('<');

                                        s = mydata.Substring(0, mydata.IndexOf('<'));
                                        f = mydata.Substring(i1 + 1, mydata.Length - i1 - 1);
                                        int wg;
                                        try
                                        {
                                            wg = Int32.Parse(wgt1.Text);
                                        }
                                        catch
                                        {
                                            wg = 0;
                                        }

                                        int wgstart, wgfinish;
                                        try
                                        {
                                            wgstart = Int32.Parse(s);
                                        }
                                        catch
                                        {
                                            wgstart = 0;
                                        }

                                        try
                                        {
                                            wgfinish = Int32.Parse(f);
                                        }
                                        catch
                                        {
                                            wgfinish = 0;
                                        }

                                        if (wg >= wgstart && wg <= wgfinish)

                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "bp":
                                    {
                                        if (bpt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "dd":
                                    {
                                        if (ddt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "px":
                                    {
                                        if (pxt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "rx":
                                    {
                                        if (rxt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "ip":
                                    {
                                        if (ipt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "op":
                                    {
                                        if (opt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "pc":
                                    {
                                        if (pct1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                //////////
                                case "sb":
                                    {
                                        if (rsbt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "ncc":
                                    {
                                        if (rsbt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "ob":
                                    {
                                        if (robt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "as":
                                    {
                                        if (rast1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "pl":
                                    {
                                        if (rplt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "dd2":
                                    {
                                        if (rddt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "px2":
                                    {
                                        if (rpxt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "rx2":
                                    {
                                        if (rrxt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "ip2":
                                    {
                                        if (ript1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "op2":
                                    {
                                        if (ropt1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "co2":
                                    {
                                        if (rcot1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                                case "pc2":
                                    {
                                        if (rpct1.Text.Contains(mydata) == true)
                                            arr_bool[i] = true;
                                        else
                                            arr_bool[i] = false;

                                        i++;
                                        break;
                                    }
                            } // End Of Switch Case

                            if (query.Length == myindex + 1)
                            {
                                sum_bool = arr_bool[0];
                                for (int j = 1; j < i; j++)
                                {
                                    sum_bool = sum_bool && arr_bool[j];
                                }
                                if (sum_bool == true)
                                {
                                    // MessageBox.Show(data["taction"].ToString());

                                    Risk_Factor_Alarm.risk_color = data["color"].ToString();
                                    Risk_Factor_Alarm.risk_action = data["taction"].ToString();
                                    Risk_Factor_Alarm.risk_query = data["query"].ToString();
                                    Risk_Factor_Alarm frm = new Risk_Factor_Alarm();
                                    frm.ShowDialog();
                                    myflag1 = true;
                                    myflag2 = true;
                                }

                                break;
                            }
                            else
                                query = query.Substring(myindex + 1, query.Length - myindex - 1);

                        } // End of While
                    }
                    data.Close();
                } // end of if (Active Risk Factor)
            }

            if (myflag2 == true)
            {
                e.Cancel = true;
                return;
            }
            //Paziresh.paziresh_to_pp = false;

            CloseForm frm1 = new CloseForm();
            CloseForm.par = par;
            ////////////////////////
            CloseForm.title = title_t.Text;
            CloseForm.fname = fname_t.Text;
            CloseForm.mname = mname_t.Text;
            CloseForm.lname = lname_t.Text;
            CloseForm.age = age_t.Text;
            CloseForm.job = job_t.Text;
            CloseForm.bplace = bplace_t.Text;
            
            // Semd bimeh to CloseForm
            bimeh_all = "";
            bimeh2_all = "";
            bimeh3_all = "";
            bimeh4_all = "";
            string b_temp = bimeh_t.Text;
            if (b_temp.Contains("+") == true)
            {
                bimeh_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                if (b_temp.Contains("+") == true)
                {
                    bimeh2_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                    b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                    if (b_temp.Contains("+") == true)
                    {
                        bimeh3_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                        b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                        if (b_temp.Contains("+") == true)
                        {
                            bimeh4_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                        }
                        else
                        {
                            bimeh4_all = b_temp;
                        }
                    }
                    else
                    {
                        bimeh3_all = b_temp;
                    }
                }
                else
                {
                    bimeh2_all = b_temp;
                }
            }
            else
            {
                bimeh_all = b_temp;
            }

            CloseForm.bimeh = bimeh_all;

            CloseForm.marray = marray_t.Text;
            CloseForm.child = child_t.Text;
            CloseForm.bar = bar_t.Text;
            CloseForm.gender = gender_t.Text;
            CloseForm.moaref = moaref_t.Text;
            CloseForm.reception = reception_t.Text;
            CloseForm.father = father_t.Text;
            CloseForm.id = id_t.Text;
            CloseForm.bdate = bdate_t.Text;
            CloseForm.nid = nid_t.Text;
            CloseForm.zip = zip_t.Text;
            CloseForm.city = city_t.Text;
            CloseForm.sodor = sodor_t.Text;
            CloseForm.malol = malol_t.Text;
            CloseForm.adr = adr_t.Text;
            CloseForm.tahsil = tahsil_t.Text;
            ////////////////////////
            CloseForm.bimehno = bimehno_all;
            CloseForm.serial = serial_all;
            CloseForm.expire = expire_all;
            CloseForm.bimeh2 = bimeh2_all;
            CloseForm.bimehno2 = bimehno2_all;
            CloseForm.serial2 = serial2_all;
            CloseForm.expire2 = expire2_all;
            CloseForm.bimeh3 = bimeh3_all;
            CloseForm.bimehno3 = bimehno3_all;
            CloseForm.serial3 = serial3_all;
            CloseForm.expire3 = expire3_all;
            CloseForm.bimeh4 = bimeh4_all;
            CloseForm.bimehno4 = bimehno4_all;
            CloseForm.serial4 = serial4_all;
            CloseForm.expire4 = expire4_all;
            CloseForm.adr2 = adr2_all;
            CloseForm.adr3 = adr3_all;
            CloseForm.adr4 = adr4_all;
            CloseForm.adr5 = adr5_all;
            CloseForm.tel1 = tel1_all;
            CloseForm.desc1 = desc1_all;
            CloseForm.tel2 = tel2_all;
            CloseForm.desc2 = desc2_all;
            CloseForm.tel3 = tel3_all;
            CloseForm.desc3 = desc3_all;
            CloseForm.tel4 = tel4_all;
            CloseForm.desc4 = desc4_all;
            CloseForm.tel5 = tel5_all;
            CloseForm.desc5 = desc5_all;
            CloseForm.tel6 = tel6_all;
            CloseForm.desc6 = desc6_all;
            CloseForm.tel7 = tel7_all;
            CloseForm.desc7 = desc7_all;
            CloseForm.tel8 = tel8_all;
            CloseForm.desc8 = desc8_all;
            CloseForm.tel9 = tel9_all;
            CloseForm.desc9 = desc9_all;
            CloseForm.tel10 = tel10_all;
            CloseForm.desc10 = desc10_all;
            CloseForm.othercode = othercode_all;
            CloseForm.life = life_all;
            CloseForm.busy = busy_all;
            CloseForm.others = others_all;
            CloseForm.edr1 = edr1_all;
            CloseForm.email1 = email1_all;
            CloseForm.edr2 = edr2_all;
            CloseForm.email2 = email2_all;
            CloseForm.edr3 = edr3_all;
            CloseForm.email3 = email3_all;
            CloseForm.edr4 = edr4_all;
            CloseForm.email4 = email4_all;
            CloseForm.edr5 = edr5_all;
            CloseForm.email5 = email5_all;
            CloseForm.edr6 = edr6_all;
            CloseForm.email6 = email6_all;
            CloseForm.edr7 = edr7_all;
            CloseForm.email7 = email7_all;
            CloseForm.edr8 = edr8_all;
            CloseForm.email8 = email8_all;
            CloseForm.edr9 = edr9_all;
            CloseForm.email9 = email9_all;
            CloseForm.edr10 = edr10_all;
            CloseForm.email10 = email10_all;
            ////////////////////////
            cct1.Text = cct1.Text.Replace("'", "''");
            dxt1.Text = dxt1.Text.Replace("'","''");
            pit1.Text = pit1.Text.Replace("'", "''");
            pht1.Text = pht1.Text.Replace("'", "''");
            fht1.Text = fht1.Text.Replace("'", "''");
            ddt1.Text = ddt1.Text.Replace("'", "''");
            pxt1.Text = pxt1.Text.Replace("'", "''");
            rxt1.Text = rxt1.Text.Replace("'", "''");
            ipt1.Text = ipt1.Text.Replace("'", "''");
            opt1.Text = opt1.Text.Replace("'", "''");
            pct1.Text = pct1.Text.Replace("'", "''");
            ////////////////////////
            CloseForm.cc = cct1.Text;
            CloseForm.dx = dxt1.Text;
            CloseForm.pi = pit1.Text;
            CloseForm.ph = pht1.Text;
            CloseForm.fh = fht1.Text;
            CloseForm.pe = pet1.Text;
            CloseForm.g = g1t1.Text;
            CloseForm.p = ptxt.Text;
            CloseForm.a = atxt.Text;
            CloseForm.l = ltxt.Text;
            CloseForm.d = g2t1.Text;
            CloseForm.hc = hct1.Text;
            CloseForm.ht = htt1.Text;
            CloseForm.wg = wgt1.Text;
            CloseForm.bp = bpt1.Text;
            CloseForm.dd = ddt1.Text;
            CloseForm.px = pxt1.Text;
            CloseForm.rx = rxt1.Text;
            CloseForm.ip = ipt1.Text;
            CloseForm.op = opt1.Text;
            CloseForm.pc = pct1.Text;
            ////////////////////////
            if (!(rsbt1.Text == "" && robt1.Text == "" && rast1.Text == "" && rplt1.Text == "" &&
                   rddt1.Text == "" && rpxt1.Text == "" && rrxt1.Text == "" &&
                   ript1.Text == "" && ropt1.Text == "" && rcot1.Text == "" && rpct1.Text == ""))
            {
                CloseForm.flag = true;
                CloseForm.rdate = label36.Text;
                CloseForm.visit = Int32.Parse(label35.Text);

                rsbt1.Text = rsbt1.Text.Replace("'", "''");
                robt1.Text = robt1.Text.Replace("'", "''");
                rast1.Text = rast1.Text.Replace("'", "''");
                rplt1.Text = rplt1.Text.Replace("'", "''");
                rddt1.Text = rddt1.Text.Replace("'", "''");
                rpxt1.Text = rpxt1.Text.Replace("'", "''");
                rrxt1.Text = rrxt1.Text.Replace("'", "''");
                ript1.Text = ript1.Text.Replace("'", "''");
                ropt1.Text = ropt1.Text.Replace("'", "''");
                rcot1.Text = rcot1.Text.Replace("'", "''");
                rpct1.Text = rpct1.Text.Replace("'", "''");

                CloseForm.rsb = rsbt1.Text;
                CloseForm.rob = robt1.Text;
                CloseForm.ras = rast1.Text;
                CloseForm.rpl = rplt1.Text;
                CloseForm.rdd = rddt1.Text;
                CloseForm.rpx = rpxt1.Text;
                CloseForm.rrx = rrxt1.Text;
                CloseForm.rip = ript1.Text;
                CloseForm.rop = ropt1.Text;
                CloseForm.rco = rcot1.Text;
                CloseForm.rpc = rpct1.Text;
            }
            else
                CloseForm.flag = false;

            frm1.ShowDialog();

            e.Cancel = CloseForm.mycancel;
            if (e.Cancel == true)
                return;


            // Save for AutoComplete And ComboBox
            //SqlConnection sqlconn = new SqlConnection(cm.cs);
            //sqlconn.Open();
            //SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.Connection = sqlconn;
           

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

            sqlcmd.CommandText = "select count(*) from info where mname='" + mname_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(mname) values('" + mname_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where lname='" + lname_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(lname) values('" + lname_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where job='" + job_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(job) values('" + job_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where bplace='" + bplace_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(bplace) values('" + bplace_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            //sqlcmd.CommandText = "select count(*) from info where bimeh='" + bimeh_t.Text + "' ";
            //if (sqlcmd.ExecuteScalar().ToString() == "0")
            //{
            //    sqlcmd.CommandText = "Insert into info(bimeh) values('" + bimeh_t.Text + "') ";
            //    sqlcmd.ExecuteNonQuery();
            //}

            sqlcmd.CommandText = "select count(*) from info where marray='" + marray_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(marray) values('" + marray_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where moaref='" + moaref_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(moaref) values('" + moaref_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where father='" + father_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(father) values('" + father_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where city='" + city_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(city) values('" + city_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where sodor='" + sodor_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(sodor) values('" + sodor_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where malol='" + malol_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(malol) values('" + malol_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where adr='" + adr_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(adr) values('" + adr_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where tahsil='" + tahsil_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(tahsil) values('" + tahsil_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();
            // End Save for AutoComplete And ComboBox
            IsOpen = false;
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            if (city_c.Width != 22 + city_t.Width)
                city_c.Width = 22 + city_t.Width;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            city_t.Text = city_c.Text;
            city_c.Width = 17;
            city_c.Visible = false;
            city_t.Focus();
        }

        private void city_t_Click(object sender, EventArgs e)
        {
            city_c.Width = 17;
            city_c.Visible = true;
        }

        private void sodor_t_Enter(object sender, EventArgs e)
        {
            city_c.Visible = false;
        }

        private void sodor_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            sodor_t.Text = sodor_c.Text;
            sodor_c.Width = 17;
            sodor_c.Visible = false;
            sodor_t.Focus();
        }

        private void sodor_c_MouseHover(object sender, EventArgs e)
        {
            sodor_c.Width = 22 + sodor_t.Width;
            sodor_c.SendToBack();
        }

        private void sodor_c_Click(object sender, EventArgs e)
        {
            if (sodor_c.Width != 22 + sodor_t.Width)
                sodor_c.Width = 22 + sodor_t.Width;
        }

        private void sodor_t_Click(object sender, EventArgs e)
        {
            sodor_c.Width = 17;
            sodor_c.Visible = true;
        }

        private void Patient_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void LeftPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
             {
              if (Int32.Parse(e.Y.ToString()) >= 630)
                 this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
              else
                 if (Int32.Parse(e.Y.ToString()) <= 230)
                  if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             }
        }

        private void RightPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (Int32.Parse(e.Y.ToString()) >= 630)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                else
                    if (Int32.Parse(e.Y.ToString()) <= 230)
                        if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
        }

        private void tahsil_t_Click(object sender, EventArgs e)
        {
            tahsil_c.Width = 17;
            tahsil_c.Visible = true;
        }

        private void tahsil_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            tahsil_t.Text = tahsil_c.Text;
            tahsil_c.Width = 17;
            tahsil_c.Visible = false;
        }

        private void tahsil_c_Click(object sender, EventArgs e)
        {
            if (tahsil_c.Width != 22 + tahsil_t.Width)
                tahsil_c.Width = 22 + tahsil_t.Width;
        }

        private void cct1_Enter(object sender, EventArgs e)
        {
            tahsil_c.Visible = false;
        }

        private void cct1_KeyDown(object sender, KeyEventArgs e)
        {
            string word = "" ,  select = "";
            select = cct1.SelectedText;
            if (select != "")
            {

                if (e.KeyCode.ToString() == "F9")
                {
                    try
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select word from algorithm where cc='" + select + "'", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        while (data.Read())
                            word = data["word"].ToString();
                        data.Close();
                        sqlconn.Close();
                        System.Diagnostics.Process.Start(word);
                    }
                    catch
                    {
                        MessageBox.Show("Algorithm not found");
                    }

                }
            }
        }

        private void city_c_MouseHover(object sender, EventArgs e)
        {
            city_c.Width = 22 + city_t.Width;
            city_c.SendToBack();
        }

        private void tahsil_c_MouseHover(object sender, EventArgs e)
        {
            tahsil_c.Width = 22 + tahsil_t.Width;
            tahsil_c.SendToBack();
        }

        private void reception_t_Leave(object sender, EventArgs e)
        {
            moaref_c.Visible = false;
            // Invisible Group 1
            profile1_p.Visible = false;
            // Visible Group 2
            profile2_p.Top = 1;
            profile2_p.Visible = true;
            father_t.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (first == true)
                return;
            if ((Int32.Parse(label35.Text)-1) >= 2)
            {
                if ((sb_flag || ob_flag || as_flag || pl_flag || dd_flag
                    || px_flag || rx_flag || ip_flag || op_flag ||
                    co_flag || pc_flag) == true)
                {
                    ChangeForm frm = new ChangeForm();

                    ChangeForm.par = par;
                    ChangeForm.rdate = label36.Text;
                    ChangeForm.visit = Int32.Parse(label35.Text);
                    ChangeForm.rsb = rsbt1.Text;
                    ChangeForm.rob = robt1.Text;
                    ChangeForm.ras = rast1.Text;
                    ChangeForm.rpl = rplt1.Text;
                    ChangeForm.rdd = rddt1.Text;
                    ChangeForm.rpx = rpxt1.Text;
                    ChangeForm.rrx = rrxt1.Text;
                    ChangeForm.rip = ript1.Text;
                    ChangeForm.rop = ropt1.Text;
                    ChangeForm.rco = rcot1.Text;
                    ChangeForm.rpc = rpct1.Text;

                    frm.ShowDialog();
                }
                int temp =Int32.Parse(label35.Text)-1;
                if (temp.ToString().Length == 1)
                    label35.Text = "00" + temp.ToString();
                if (temp.ToString().Length == 2)
                    label35.Text = "0" + temp.ToString();
                if (temp.ToString().Length == 3)
                    label35.Text = temp.ToString();


                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select * from sick2 where par='"+par+"' and visit ='"+temp+"' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    label36.Text = data["rdate"].ToString();
                    rsbt1.Text = data["sb"].ToString();
                    robt1.Text = data["ob"].ToString();
                    rast1.Text = data["ass"].ToString();
                    rplt1.Text = data["pl"].ToString();
                    rddt1.Text = data["dd"].ToString();
                    rpxt1.Text = data["px"].ToString();
                    rrxt1.Text = data["rx"].ToString();
                    ript1.Text = data["ip"].ToString();
                    ropt1.Text = data["op"].ToString();
                    rcot1.Text = data["co"].ToString();
                    rpct1.Text = data["pc"].ToString();
                }
                data.Close();
                sqlconn.Close();

               
                sb_flag = ob_flag = as_flag = pl_flag = dd_flag = px_flag = rx_flag = ip_flag = op_flag = co_flag = pc_flag = false;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (first == true)
                return;

            if ((Int32.Parse(label35.Text) + 1) <= maxpage)
            {
                
                if ((sb_flag || ob_flag || as_flag || pl_flag || dd_flag
                    || px_flag || rx_flag || ip_flag || op_flag ||
                    co_flag || pc_flag) == true)
                {
                    ChangeForm frm = new ChangeForm();

                    ChangeForm.par = par;
                    ChangeForm.rdate = label36.Text;
                    ChangeForm.visit = Int32.Parse(label35.Text);
                    ChangeForm.rsb = rsbt1.Text;
                    ChangeForm.rob = robt1.Text;
                    ChangeForm.ras = rast1.Text;
                    ChangeForm.rpl = rplt1.Text;
                    ChangeForm.rdd = rddt1.Text;
                    ChangeForm.rpx = rpxt1.Text;
                    ChangeForm.rrx = rrxt1.Text;
                    ChangeForm.rip = ript1.Text;
                    ChangeForm.rop = ropt1.Text;
                    ChangeForm.rco = rcot1.Text;
                    ChangeForm.rpc = rpct1.Text;

                    frm.ShowDialog();
                }
                int temp = Int32.Parse(label35.Text) + 1;
                if (temp.ToString().Length == 1)
                    label35.Text = "00" + temp.ToString();
                if (temp.ToString().Length == 2)
                    label35.Text = "0" + temp.ToString();
                if (temp.ToString().Length == 3)
                    label35.Text = temp.ToString();


                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select * from sick2 where par='" + par + "' and visit ='" + temp + "' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                bool readflag = false;
                while (data.Read())
                {
                    readflag = true;
                    label36.Text = data["rdate"].ToString();
                    rsbt1.Text = data["sb"].ToString();
                    robt1.Text = data["ob"].ToString();
                    rast1.Text = data["ass"].ToString();
                    rplt1.Text = data["pl"].ToString();
                    rddt1.Text = data["dd"].ToString();
                    rpxt1.Text = data["px"].ToString();
                    rrxt1.Text = data["rx"].ToString();
                    ript1.Text = data["ip"].ToString();
                    ropt1.Text = data["op"].ToString();
                    rcot1.Text = data["co"].ToString();
                    rpct1.Text = data["pc"].ToString();
                }
                data.Close();
                sqlconn.Close();

                if (readflag == false)
                {
                    rsbt1.Text = "";
                    robt1.Text = "";
                    rast1.Text = "";
                    rplt1.Text = "";
                    rddt1.Text = "";
                    rpxt1.Text = "";
                    rrxt1.Text = "";
                    ript1.Text = "";
                    ropt1.Text = "";
                    rcot1.Text = "";
                    rpct1.Text = "";
                    PersianDate pd = PersianDate.Now;
                    label36.Text = pd.ToString().Substring(0, 10);
                }


                sb_flag = ob_flag = as_flag = pl_flag = dd_flag = px_flag = rx_flag = ip_flag = op_flag = co_flag = pc_flag = false;
            }
            

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Search frm = new Search();
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            flag_all = true;

            title_all = title_t.Text;
            fname_all = fname_t.Text;
            mname_all = mname_t.Text;
            lname_all = lname_t.Text;
            age_all = age_t.Text;
            day_all = day.Text;
            month_all = month.Text;
            year_all = year.Text;
            bplace_all = bplace_t.Text;
            bdate_all = bdate_t.Text;
            father_all = father_t.Text;
            id_all = id_t.Text;
            sodor_all = sodor_t.Text;
            city_all = city_t.Text;
            job_all = job_t.Text;
            malol_all = malol_t.Text;
            gender_all = gender_t.Text;
            marray_all = marray_t.Text;
            child_all = child_t.Text;
            bar_all = bar_t.Text;
            zip_all = zip_t.Text;
            nid_all = nid_t.Text;
            moaref_all = moaref_t.Text;
            tahsil_all = tahsil_t.Text;
            adr_all = adr_t.Text;

            // Send bimeh to All_info
            bimeh_all = "";
            bimeh2_all = "";
            bimeh3_all = "";
            bimeh4_all = "";
            string b_temp = bimeh_t.Text;
            if (b_temp.Contains("+") == true)
            {
                bimeh_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                if (b_temp.Contains("+") == true)
                {
                    bimeh2_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                    b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                    if (b_temp.Contains("+") == true)
                    {
                        bimeh3_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                        b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                        if (b_temp.Contains("+") == true)
                        {
                            bimeh4_all = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                        }
                        else
                        {
                            bimeh4_all = b_temp;
                        }
                    }
                    else
                    {
                        bimeh3_all = b_temp;
                    }
                }
                else
                {
                    bimeh2_all = b_temp;
                }
            }
            else
            {
                bimeh_all = b_temp;
            }

            all_info frm = new all_info();
            frm.ShowDialog();

            title_t.Text = title_all;
            fname_t.Text = fname_all;
            mname_t.Text = mname_all;
            lname_t.Text = lname_all;
            age_t.Text = age_all;
            day.Text = day_all;
            month.Text = month_all;
            year.Text = year_all;
            bplace_t.Text = bplace_all;
            bdate_t.Text = bdate_all;
            father_t.Text = father_all;
            id_t.Text = id_all;
            sodor_t.Text = sodor_all;
            city_t.Text = city_all;
            job_t.Text = job_all;
            malol_t.Text = malol_all;
            gender_t.Text = gender_all;
            marray_t.Text = marray_all;
            child_t.Text = child_all;
            bar_t.Text = bar_all;
            zip_t.Text = zip_all;
            nid_t.Text = nid_all;
            moaref_t.Text = moaref_all;
            tahsil_t.Text = tahsil_all;
            adr_t.Text = adr_all;

            // Get Bimeh from All_info
            bimeh_t.Text = bimeh_all;
            if (bimeh2_all != "")
                bimeh_t.Text += " + " + bimeh2_all;

            if (bimeh3_all != "")
                bimeh_t.Text += " + " + bimeh3_all;

            if (bimeh4_all != "")
                bimeh_t.Text += " + " + bimeh4_all;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Tel frm = new Tel();
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            nobat frm = new nobat();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            acc frm = new acc();
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            //Reminder.reminder_pp = true;
            //Reminder.reminder_row[12] = title_t.Text;
            //Reminder.reminder_row[13] = fname_t.Text;
            //Reminder.reminder_row[14] = (mname_t.Text + " " + lname_t.Text).Trim();
            if (fname_t.Text == "" && mname_t.Text == "" && lname_t.Text == "")
            {
            }
            else
            {
                PersianDate pd = PersianDate.Now;
                string today;
                today = pd.ToString().Substring(0, 10);

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;

                string mymail = "";
                if (edr1_all != "")
                {
                    mymail = edr1_all + email1_all;
                }
                else
                {
                    sqlcmd.CommandText = "select edr1,email1,tel1 from paziresh where date1 = '"+ today +"' and row = '"+ pp_paz_row +"' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        edr1_all = data["edr1"].ToString();
                        email1_all = data["email1"].ToString();
                        tel1_all = data["tel1"].ToString();
                    }
                    data.Close();
                    mymail = edr1_all + email1_all;
                }
                
                sqlcmd.CommandText = "Insert into reminder(title,fname,family,email,tel) values('" + title_t.Text + "','" + fname_t.Text + "','" + (mname_t.Text + " " + lname_t.Text).Trim() + "','"+ mymail.Trim() +"','"+ tel1_all.Trim() +"') ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }

            Reminder frm = new Reminder();
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Referral.referral_pp = true;
            Referral.fname = fname_t.Text;
            Referral.family = (mname_t.Text + " " + lname_t.Text).Trim();
            Printer_Referral.Printer_Referral_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();
            Printer_Referral.Printer_Referral_dx = dxt1.Text;
            Printer_Referral.Printer_Referral_cc = cct1.Text;
            Printer_Referral.Printer_Referral_pi = pit1.Text;
            Printer_Referral.Printer_Referral_ddx = ddt1.Text;

            Referral frm = new Referral();
            frm.ShowDialog();

            if (label35.Text == "000")
            {
                pxt1.Text = pxt1.Text + Referral.px;
            }
            else
            {
                rpxt1.Text = rpxt1.Text + Referral.px;
            }


        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Consultation.consult_pp = true;
            Consultation frm = new Consultation();
            frm.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Medical_Library frm = new Medical_Library();
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            DrugStore frm = new DrugStore();
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Algorithm frm = new Algorithm();
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Photo_Archive frm = new Photo_Archive();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Risk_Factor frm = new Risk_Factor();
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            cm_menu.Visible = false;

            Research frm = new Research();
            frm.Show();
        }

        private void rsbt1_KeyDown(object sender, KeyEventArgs e)
        {
            //string word = "", select = "";
            //select = rsbt1.SelectedText;
            //if (select != "")
            //{

            //    if (e.KeyCode.ToString() == "F9")
            //    {
            //        try
            //        {
            //            SqlConnection sqlconn = new SqlConnection(cm.cs);
            //            sqlconn.Open();
            //            SqlCommand sqlcmd = new SqlCommand("select word from algorithm where cc='" + select + "'", sqlconn);
            //            SqlDataReader data = sqlcmd.ExecuteReader();
            //            while (data.Read())
            //                word = data["word"].ToString();
            //            data.Close();
            //            sqlconn.Close();
            //            System.Diagnostics.Process.Start(word);
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Algorithm not found");
            //        }

            //    }
            //}
        }

       

        private void job_t_Enter(object sender, EventArgs e)
        {
             if (mname_t.Text == "" || lname_t.Text == "")
            {
                alert frm1 = new alert();
                frm1.ShowDialog();
            }
        }

        private void label36_Click(object sender, EventArgs e)
        {
            
        }

        private void selectAllCtrlAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            if (mycontrol == "cct1")
            {
                cct1.Focus();
                cct1.SelectAll();
            }
            if (mycontrol == "dxt1")
            {
                dxt1.Focus();
                dxt1.SelectAll();
            }
            if (mycontrol == "pit1")
            {
                pit1.Focus();
                pit1.SelectAll();
            }
            if (mycontrol == "pht1")
            {
                pht1.Focus();
                pht1.SelectAll();
            }
            if (mycontrol == "fht1")
            {
                fht1.Focus();
                fht1.SelectAll();
            }
            if (mycontrol == "pet1")
            {
                pet1.Focus();
                pet1.SelectAll();
            }
            if (mycontrol == "ddt1")
            {
                ddt1.Focus();
                ddt1.SelectAll();
            }
            if (mycontrol == "pxt1")
            {
                pxt1.Focus();
                pxt1.SelectAll();
            }
            if (mycontrol == "rxt1")
            {
                rxt1.Focus();
                rxt1.SelectAll();
            }
            if (mycontrol == "ipt1")
            {
                ipt1.Focus();
                ipt1.SelectAll();
            }
            if (mycontrol == "opt1")
            {
                opt1.Focus();
                opt1.SelectAll();
            }
            if (mycontrol == "pct1")
            {
                pct1.Focus();
                pct1.SelectAll();
            }

            if (mycontrol == "rsbt1")
            {
                rsbt1.Focus();
                rsbt1.SelectAll();
            }
            if (mycontrol == "robt1")
            {
                robt1.Focus();
                robt1.SelectAll();
            }
            if (mycontrol == "rast1")
            {
                rast1.Focus();
                rast1.SelectAll();
            }
            if (mycontrol == "rplt1")
            {
                rplt1.Focus();
                rplt1.SelectAll();
            }
            if (mycontrol == "rddt1")
            {
                rddt1.Focus();
                rddt1.SelectAll();
            }
            if (mycontrol == "rpxt1")
            {
                rpxt1.Focus();
                rpxt1.SelectAll();
            }
            if (mycontrol == "rrxt1")
            {
                rrxt1.Focus();
                rrxt1.SelectAll();
            }
            if (mycontrol == "ript1")
            {
                ript1.Focus();
                ript1.SelectAll();
            }
            if (mycontrol == "ropt1")
            {
                ropt1.Focus();
                ropt1.SelectAll();
            }
            if (mycontrol == "rcot1")
            {
                rcot1.Focus();
                rcot1.SelectAll();
            }
            if (mycontrol == "rpct1")
            {
                rpct1.Focus();
                rpct1.SelectAll();
            }
        }

        private void copyCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            if (mycontrol == "cct1")
            {
                cct1.Focus();
                cct1.Copy();
            }
            if (mycontrol == "dxt1")
            {
                dxt1.Focus();
                dxt1.Copy();
            }
            if (mycontrol == "pit1")
            {
                pit1.Focus();
                pit1.Copy();
            }
            if (mycontrol == "pht1")
            {
                pht1.Focus();
                pht1.Copy();
            }
            if (mycontrol == "fht1")
            {
                fht1.Focus();
                fht1.Copy();
            }
            if (mycontrol == "pet1")
            {
                pet1.Focus();
                pet1.Copy();
            }
            if (mycontrol == "ddt1")
            {
                ddt1.Focus();
                ddt1.Copy();
            }
            if (mycontrol == "pxt1")
            {
                pxt1.Focus();
                pxt1.Copy();
            }
            if (mycontrol == "rxt1")
            {
                rxt1.Focus();
                rxt1.Copy();
            }
            if (mycontrol == "ipt1")
            {
                ipt1.Focus();
                ipt1.Copy();
            }
            if (mycontrol == "opt1")
            {
                opt1.Focus();
                opt1.Copy();
            }
            if (mycontrol == "pct1")
            {
                pct1.Focus();
                pct1.Copy();
            }

            if (mycontrol == "rsbt1")
            {
                rsbt1.Focus();
                rsbt1.Copy();
            }
            if (mycontrol == "robt1")
            {
                robt1.Focus();
                robt1.Copy();
            }
            if (mycontrol == "rast1")
            {
                rast1.Focus();
                rast1.Copy();
            }
            if (mycontrol == "rplt1")
            {
                rplt1.Focus();
                rplt1.Copy();
            }
            if (mycontrol == "rddt1")
            {
                rddt1.Focus();
                rddt1.Copy();
            }
            if (mycontrol == "rpxt1")
            {
                rpxt1.Focus();
                rpxt1.Copy();
            }
            if (mycontrol == "rrxt1")
            {
                rrxt1.Focus();
                rrxt1.Copy();
            }
            if (mycontrol == "ript1")
            {
                ript1.Focus();
                ript1.Copy();
            }
            if (mycontrol == "ropt1")
            {
                ropt1.Focus();
                ropt1.Copy();
            }
            if (mycontrol == "rcot1")
            {
                rcot1.Focus();
                rcot1.Copy();
            }
            if (mycontrol == "rpct1")
            {
                rpct1.Focus();
                rpct1.Copy();
            }
        }

        private void undoCtrlZToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            if (mycontrol == "cct1")
            {
                cct1.Focus();
                cct1.Undo();
            }
            if (mycontrol == "dxt1")
            {
                dxt1.Focus();
                dxt1.Undo();
            }
            if (mycontrol == "pit1")
            {
                pit1.Focus();
                pit1.Undo();
            }
            if (mycontrol == "pht1")
            {
                pht1.Focus();
                pht1.Undo();
            }
            if (mycontrol == "fht1")
            {
                fht1.Focus();
                fht1.Undo();
            }
            if (mycontrol == "pet1")
            {
                pet1.Focus();
                pet1.Undo();
            }
            if (mycontrol == "ddt1")
            {
                ddt1.Focus();
                ddt1.Undo();
            }
            if (mycontrol == "pxt1")
            {
                pxt1.Focus();
                pxt1.Undo();
            }
            if (mycontrol == "rxt1")
            {
                rxt1.Focus();
                rxt1.Undo();
            }
            if (mycontrol == "ipt1")
            {
                ipt1.Focus();
                ipt1.Undo();
            }
            if (mycontrol == "opt1")
            {
                opt1.Focus();
                opt1.Undo();
            }
            if (mycontrol == "pct1")
            {
                pct1.Focus();
                pct1.Undo();
            }

            if (mycontrol == "rsbt1")
            {
                rsbt1.Focus();
                rsbt1.Undo();
            }
            if (mycontrol == "robt1")
            {
                robt1.Focus();
                robt1.Undo();
            }
            if (mycontrol == "rast1")
            {
                rast1.Focus();
                rast1.Undo();
            }
            if (mycontrol == "rplt1")
            {
                rplt1.Focus();
                rplt1.Undo();
            }
            if (mycontrol == "rddt1")
            {
                rddt1.Focus();
                rddt1.Undo();
            }
            if (mycontrol == "rpxt1")
            {
                rpxt1.Focus();
                rpxt1.Undo();
            }
            if (mycontrol == "rrxt1")
            {
                rrxt1.Focus();
                rrxt1.Undo();
            }
            if (mycontrol == "ript1")
            {
                ript1.Focus();
                ript1.Undo();
            }
            if (mycontrol == "ropt1")
            {
                ropt1.Focus();
                ropt1.Undo();
            }
            if (mycontrol == "rcot1")
            {
                rcot1.Focus();
                rcot1.Undo();
            }
            if (mycontrol == "rpct1")
            {
                rpct1.Focus();
                rpct1.Undo();
            }
        }

        private void cct1_Leave(object sender, EventArgs e)
        {
            mycontrol = "cct1";
        }

        private void pit1_Leave(object sender, EventArgs e)
        {
            mycontrol = "pit1";
        }

        private void dxt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "dxt1";
        }

        private void pht1_Leave(object sender, EventArgs e)
        {
            mycontrol = "pht1";
        }

        private void fht1_Leave(object sender, EventArgs e)
        {
            mycontrol = "fht1";
        }

        private void pet1_Leave(object sender, EventArgs e)
        {
            mycontrol = "pet1";
        }

        private void ddt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "ddt1";
        }

        private void pxt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "pxt1";
        }

        private void rxt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rxt1";
        }

        private void ipt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "ipt1";
        }

        private void opt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "opt1";
        }

        private void pct1_Leave(object sender, EventArgs e)
        {
            mycontrol = "pct1";
        }

        private void rsbt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rsbt1";
        }

        private void robt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "robt1";
        }

        private void rast1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rast1";
        }

        private void rplt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rplt1";
        }

        private void rddt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rddt1";
        }

        private void rpxt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rpxt1";
        }

        private void rrxt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rrxt1";
        }

        private void ript1_Leave(object sender, EventArgs e)
        {
            mycontrol = "ript1";
        }

        private void ropt1_Leave(object sender, EventArgs e)
        {
            mycontrol = "ropt1";
        }

        private void rcot1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rcot1";
        }

        private void rpct1_Leave(object sender, EventArgs e)
        {
            mycontrol = "rpct1";
        }

        private void pasteCtrlVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            if (mycontrol == "cct1")
            {
                cct1.Focus();
                cct1.Paste();
            }
            if (mycontrol == "dxt1")
            {
                dxt1.Focus();
                dxt1.Paste();
            }
            if (mycontrol == "pit1")
            {
                pit1.Focus();
                pit1.Paste();
            }
            if (mycontrol == "pht1")
            {
                pht1.Focus();
                pht1.Paste();
            }
            if (mycontrol == "fht1")
            {
                fht1.Focus();
                fht1.Paste();
            }
            if (mycontrol == "pet1")
            {
                pet1.Focus();
                pet1.Paste();
            }
            if (mycontrol == "ddt1")
            {
                ddt1.Focus();
                ddt1.Paste();
            }
            if (mycontrol == "pxt1")
            {
                pxt1.Focus();
                pxt1.Paste();
            }
            if (mycontrol == "rxt1")
            {
                rxt1.Focus();
                rxt1.Paste();
            }
            if (mycontrol == "ipt1")
            {
                ipt1.Focus();
                ipt1.Paste();
            }
            if (mycontrol == "opt1")
            {
                opt1.Focus();
                opt1.Paste();
            }
            if (mycontrol == "pct1")
            {
                pct1.Focus();
                pct1.Paste();
            }

            if (mycontrol == "rsbt1")
            {
                rsbt1.Focus();
                rsbt1.Paste();
            }
            if (mycontrol == "robt1")
            {
                robt1.Focus();
                robt1.Paste();
            }
            if (mycontrol == "rast1")
            {
                rast1.Focus();
                rast1.Paste();
            }
            if (mycontrol == "rplt1")
            {
                rplt1.Focus();
                rplt1.Paste();
            }
            if (mycontrol == "rddt1")
            {
                rddt1.Focus();
                rddt1.Paste();
            }
            if (mycontrol == "rpxt1")
            {
                rpxt1.Focus();
                rpxt1.Paste();
            }
            if (mycontrol == "rrxt1")
            {
                rrxt1.Focus();
                rrxt1.Paste();
            }
            if (mycontrol == "ript1")
            {
                ript1.Focus();
                ript1.Paste();
            }
            if (mycontrol == "ropt1")
            {
                ropt1.Focus();
                ropt1.Paste();
            }
            if (mycontrol == "rcot1")
            {
                rcot1.Focus();
                rcot1.Paste();
            }
            if (mycontrol == "rpct1")
            {
                rpct1.Focus();
                rpct1.Paste();
            }
        }

        private void cutCtrlXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            if (mycontrol == "cct1")
            {
                cct1.Focus();
                cct1.Cut();
            }
            if (mycontrol == "dxt1")
            {
                dxt1.Focus();
                dxt1.Cut();
            }
            if (mycontrol == "pit1")
            {
                pit1.Focus();
                pit1.Cut();
            }
            if (mycontrol == "pht1")
            {
                pht1.Focus();
                pht1.Cut();
            }
            if (mycontrol == "fht1")
            {
                fht1.Focus();
                fht1.Cut();
            }
            if (mycontrol == "pet1")
            {
                pet1.Focus();
                pet1.Cut();
            }
            if (mycontrol == "ddt1")
            {
                ddt1.Focus();
                ddt1.Cut();
            }
            if (mycontrol == "pxt1")
            {
                pxt1.Focus();
                pxt1.Cut();
            }
            if (mycontrol == "rxt1")
            {
                rxt1.Focus();
                rxt1.Cut();
            }
            if (mycontrol == "ipt1")
            {
                ipt1.Focus();
                ipt1.Cut();
            }
            if (mycontrol == "opt1")
            {
                opt1.Focus();
                opt1.Cut();
            }
            if (mycontrol == "pct1")
            {
                pct1.Focus();
                pct1.Cut();
            }

            if (mycontrol == "rsbt1")
            {
                rsbt1.Focus();
                rsbt1.Cut();
            }
            if (mycontrol == "robt1")
            {
                robt1.Focus();
                robt1.Cut();
            }
            if (mycontrol == "rast1")
            {
                rast1.Focus();
                rast1.Cut();
            }
            if (mycontrol == "rplt1")
            {
                rplt1.Focus();
                rplt1.Cut();
            }
            if (mycontrol == "rddt1")
            {
                rddt1.Focus();
                rddt1.Cut();
            }
            if (mycontrol == "rpxt1")
            {
                rpxt1.Focus();
                rpxt1.Cut();
            }
            if (mycontrol == "rrxt1")
            {
                rrxt1.Focus();
                rrxt1.Cut();
            }
            if (mycontrol == "ript1")
            {
                ript1.Focus();
                ript1.Cut();
            }
            if (mycontrol == "ropt1")
            {
                ropt1.Focus();
                ropt1.Cut();
            }
            if (mycontrol == "rcot1")
            {
                rcot1.Focus();
                rcot1.Cut();
            }
            if (mycontrol == "rpct1")
            {
                rpct1.Focus();
                rpct1.Cut();
            }
        }

        private void switchWindowAltTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;
        }

        private void redoCtrlYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            if (mycontrol == "cct1")
            {
                cct1.Focus();
                cct1.Redo();
            }
            if (mycontrol == "dxt1")
            {
                dxt1.Focus();
                dxt1.Redo();
            }
            if (mycontrol == "pit1")
            {
                pit1.Focus();
                pit1.Redo();
            }
            if (mycontrol == "pht1")
            {
                pht1.Focus();
                pht1.Redo();
            }
            if (mycontrol == "fht1")
            {
                fht1.Focus();
                fht1.Redo();
            }
            if (mycontrol == "pet1")
            {
                pet1.Focus();
                pet1.Redo();
            }
            if (mycontrol == "ddt1")
            {
                ddt1.Focus();
                ddt1.Redo();
            }
            if (mycontrol == "pxt1")
            {
                pxt1.Focus();
                pxt1.Redo();
            }
            if (mycontrol == "rxt1")
            {
                rxt1.Focus();
                rxt1.Redo();
            }
            if (mycontrol == "ipt1")
            {
                ipt1.Focus();
                ipt1.Redo();
            }
            if (mycontrol == "opt1")
            {
                opt1.Focus();
                opt1.Redo();
            }
            if (mycontrol == "pct1")
            {
                pct1.Focus();
                pct1.Redo();
            }

            if (mycontrol == "rsbt1")
            {
                rsbt1.Focus();
                rsbt1.Redo();
            }
            if (mycontrol == "robt1")
            {
                robt1.Focus();
                robt1.Redo();
            }
            if (mycontrol == "rast1")
            {
                rast1.Focus();
                rast1.Redo();
            }
            if (mycontrol == "rplt1")
            {
                rplt1.Focus();
                rplt1.Redo();
            }
            if (mycontrol == "rddt1")
            {
                rddt1.Focus();
                rddt1.Redo();
            }
            if (mycontrol == "rpxt1")
            {
                rpxt1.Focus();
                rpxt1.Redo();
            }
            if (mycontrol == "rrxt1")
            {
                rrxt1.Focus();
                rrxt1.Redo();
            }
            if (mycontrol == "ript1")
            {
                ript1.Focus();
                ript1.Redo();
            }
            if (mycontrol == "ropt1")
            {
                ropt1.Focus();
                ropt1.Redo();
            }
            if (mycontrol == "rcot1")
            {
                rcot1.Focus();
                rcot1.Redo();
            }
            if (mycontrol == "rpct1")
            {
                rpct1.Focus();
                rpct1.Redo();
            }
        }

        private void bar_c_Click(object sender, EventArgs e)
        {
            if (bar_c.Width != 22 + bar_t.Width)
                bar_c.Width = 22 + bar_t.Width;
        }

        private void job_c_MouseHover(object sender, EventArgs e)
        {
            job_c.Width = 22 + job_t.Width;
            job_c.SendToBack();
        }

        private void bplace_c_MouseHover(object sender, EventArgs e)
        {
            bplace_c.Width = 22 + bplace_t.Width;
            bplace_c.SendToBack();
        }

        private void title_t_Leave(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from set1 where title='" + title_t.Text + "'", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                string gg = data["gender"].ToString();
                string bb = data["bar"].ToString();
                string marray = data["marray"].ToString();
                string child = data["child"].ToString();
                string job = data["job"].ToString();
                string tahsil = data["tahsil"].ToString();

                if (gg == "1")
                    gender_t.Text = "مذكر";
                if (gg == "2")
                    gender_t.Text = "مونث";

                if (bb == "1")
                {
                    bar_t.Text = "بلي";
                }

                if (bb == "2")
                {
                    bar_t.Text = "خير";
                }

                if (bb == "3")
                {
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (bb == "4")
                {
                    bar_l.ForeColor = System.Drawing.Color.Gray;
                }

                if (marray == "1")
                {
                    marray_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (marray == "2")
                {
                    marray_l.ForeColor = System.Drawing.Color.Gray;
                }

                if (child == "1")
                {
                    child_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (child == "2")
                {
                    child_l.ForeColor = System.Drawing.Color.Gray;
                }

                if (job == "1")
                {
                    job_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (job == "2")
                {
                    job_l.ForeColor = System.Drawing.Color.Gray;
                }

                if (tahsil == "1")
                {
                    tahsil_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (tahsil == "2")
                {
                    tahsil_l.ForeColor = System.Drawing.Color.Gray;
                }
            }

            data.Close();
            sqlconn.Close();
        }

        private void marray_t_Leave(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from set2 where marray='" + marray_c.Text + "'", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                string child = data["child"].ToString();
                string bar = data["bar"].ToString();

                if (child == "1")
                {
                    child_l.ForeColor = System.Drawing.Color.Yellow;

                }
                if (child == "2")
                {
                    child_l.ForeColor = System.Drawing.Color.Gray;
                }

                if (bar == "1")
                {
                    bar_t.Text = "بلي";
                }

                if (bar == "2")
                {
                    bar_t.Text = "خير";
                }
                if (bar == "3")
                {
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (bar == "4")
                {
                    bar_l.ForeColor = System.Drawing.Color.Gray;
                }
            }

            data.Close();
            sqlconn.Close();
        }

        private void چاپرسيدوجهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Receipt.receipt_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();

            Receipt frm = new Receipt();
            frm.ShowDialog();

            cm_menu.Visible = false;
        }

        private void چاپگواهيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rest.Rest_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();

            Rest frm = new Rest();
            frm.ShowDialog();

            cm_menu.Visible = false;
        }

        private void چاپفرممتفرقهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice.Invoice_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();

            Invoice frm = new Invoice();
            frm.Show();

            cm_menu.Visible = false;
        }

        private void cct1_Enter_1(object sender, EventArgs e)
        {
            //SqlConnection sqlconn = new SqlConnection(cm.cs);
            //sqlconn.Open();
            //SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.Connection = sqlconn;
            //SqlDataReader data;

            //sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            //data.Close();


            //sqlconn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fname_t.AutoCompleteCustomSource.Count == 0)
            {
                int i = 0;
                string s;
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                SqlDataReader data;

                sqlcmd.CommandText = "select distinct fname from info where fname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
                data.Close();

                sqlcmd.CommandText = "select distinct mname from info where mname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    mname_t.AutoCompleteCustomSource.Add(data["mname"].ToString());
                data.Close();

                sqlcmd.CommandText = "select distinct lname from info where lname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    lname_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
                data.Close();

                i = 0;
                sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["bplace"].ToString();
                    bplace_c.Items.Insert(i, s);
                    bplace_t.AutoCompleteCustomSource.Add(s);
                    i++;
                }
                data.Close();

                sqlcmd.CommandText = "select distinct father from info where father<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
                data.Close();

                i = 0;
                sqlcmd.CommandText = "select distinct city from info where city<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["city"].ToString();
                    city_c.Items.Insert(i, s);
                    city_t.AutoCompleteCustomSource.Add(s);
                    i++;
                }
                data.Close();

                i = 0;
                sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["sodor"].ToString();
                    sodor_c.Items.Insert(i, s);
                    sodor_t.AutoCompleteCustomSource.Add(s);
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }

            timer1.Enabled = false;
        }

        private void throubleshootingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            Help frm = new Help();
            frm.ShowDialog();
        }

        private void جستجويگواهيهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            Search_Print frm = new Search_Print();
            frm.ShowDialog();
        } 
       

    }
}