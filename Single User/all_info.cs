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
    public partial class all_info : Form
    {
        public static bool pj_conflict;
        private static int num;
        public static string bimeh, bimehno, serial, expire, bimeh2, bimehno2, serial2, expire2, bimeh3, bimehno3, serial3, expire3, bimeh4, bimehno4, serial4, expire4;
        public static string adr, adr2, adr3, adr4, adr5, tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10;
        public static string edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;
        
        public static string paz_row;

        public all_info()
        {
            InitializeComponent();
        }

        private void all_info_MouseMove(object sender, MouseEventArgs e)
        {
            if (Int32.Parse(e.Y.ToString()) <= 7)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            else
                if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                {
                    if (Int32.Parse(e.Y.ToString()) >= 760)
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    else
                        if (Int32.Parse(e.Y.ToString()) <= 230)
                            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            title_c.Visible = false;
            if (name_b.Text == "+")
            {
                num++;
                name_p.Visible = true;
                name_b.Text = "-";
                pictureBox1.Visible = false;
                fname_t.Focus();
            }
            else
            {
                name_p.Visible = false;
                name_b.Text = "+";
                num--;
                if (num == 0)
                    pictureBox1.Visible = true;
            }

            
        }

        private void all_info_Load(object sender, EventArgs e)
        {
            pj_conflict = false;

            // Bimeh Info
            bimeh = bimehno = serial = expire = bimeh2 = bimehno2 = serial2 = expire2 = bimeh3 = bimehno3 = serial3 = expire3 = bimeh4 = bimehno4 = serial4 = expire4 = "";

            // Address
            adr = adr2 = adr3 = adr4 = adr5 = "";

            // Telephones
            tel1 = desc1 = tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = "";
            tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = "";

            /// Emails
            edr1 = email1 = edr2 = email2 = edr3 = email3 = edr4 = email4 = edr5 = email5 = "";
            edr6 = email6 = edr7 = email7 = edr8 = email8 = edr9 = email9 = edr10 = email10 = "";

            LanguageSelector.KeyboardLayout.Farsi();
            title_t.Focus();
            num = 0;
            pictureBox1.Top = 32;
            pictureBox1.Left = 24;
            pictureBox1.Width = 743;
            pictureBox1.Height = 710;

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
            sqlcmd.CommandText = "select distinct title,-titlef from info where title<>'' order by -titlef ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["title"].ToString();
                title_t.AutoCompleteCustomSource.Add(s);
                title_c.Items.Insert(i,s);
                i++;
            }
            data.Close();

            string src = "";
            sqlcmd.CommandText = "select pj from sw where pj<>''";
            data = sqlcmd.ExecuteReader();
            while(data.Read())
                src = data["pj"].ToString();
            data.Close();

            try
            {
                pictureBox1.Image = Image.FromFile(src);
            }
            catch { }
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

            sqlcmd.CommandText = "select distinct others from info where others<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                others_t.AutoCompleteCustomSource.Add(data["others"].ToString());
            data.Close();


            sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                lname_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["sodor"].ToString();
                sodor_t.AutoCompleteCustomSource.Add(s);
                sodor_c.Items.Insert(i, s);
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

            sqlcmd.CommandText = "select distinct father from info where father<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["bplace"].ToString();
                bplace_t.AutoCompleteCustomSource.Add(s);
                bplace_c.Items.Insert(i,s);
            }
            data.Close();

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

            if (Paziresh.paziresh_to_pj == true)
            {
                //try
                //{
                //    Int64 par = Int64.Parse(Paziresh.pp_par);
                //    sqlcmd.CommandText = "select * from sick1 where par = '"+ par +"' ";
                //    data = sqlcmd.ExecuteReader();
                //    while (data.Read())
                //    {
                //        title_t.Text = data["title"].ToString();
                //        fname_t.Text = data["fname"].ToString();
                //        mname_t.Text = data["mname"].ToString();
                //        lname_t.Text = data["lname"].ToString();
                //        age_t.Text = data["age"].ToString();
                //        child_t.Text = data["child"].ToString();
                //        sodor_t.Text = data["sodor"].ToString();
                //        id_t.Text = data["id"].ToString();
                //        bdate_t.Text = data["bdate"].ToString();
                //       // if(bdate_t.Text != "")
                //        string bdate = bdate_t.Text;
                //        try
                //        {
                //            if (bdate.IndexOf('/') == 4)
                //            {
                //                year.Text = bdate.Substring(2, 2);
                //                bdate = bdate.Substring(5, bdate.Length - 5);
                //                month.Text = bdate.Substring(0, bdate.IndexOf('/'));
                //                bdate = bdate.Substring(bdate.IndexOf('/') + 1, bdate.Length - bdate.IndexOf('/') - 1);
                //                day.Text = bdate;
                //            }
                //        }
                //        catch { }
                        
                //        string mygender = data["gender"].ToString();
                //        if (mygender.Contains("مذ"))
                //            male.Checked = true;
                //        if (mygender == "مونث")
                //            female.Checked = true;

                //        string bar = data["bar"].ToString();
                //        if (bar == "بلي")
                //            yes.Checked = true;
                //        if (bar == "خير")
                //            no.Checked = true;


                //        bplace_t.Text = data["bplace"].ToString();
                //        father_t.Text = data["father"].ToString();
                //        malol_t.Text = data["malol"].ToString();
                //        job_t.Text = data["job"].ToString();
                //        moaref_t.Text = data["moaref"].ToString();
                //        zip_t.Text = data["zip"].ToString();
                //        nid_t.Text = data["nid"].ToString();
                //        tahsil_t.Text = data["tahsil"].ToString();
                //        marray_t.Text = data["marray"].ToString();
                //        city_t.Text = data["city"].ToString();
                //        othercode_t.Text = data["othercode"].ToString();
                //        life_t.Text = data["life"].ToString();
                //        busy_t.Text = data["busy"].ToString();
                //        others_t.Text = data["others"].ToString();

                //        // Bimeh Info
                //        bimeh = data["bimeh"].ToString();
                //        bimehno = data["bimehno"].ToString();
                //        serial = data["serial"].ToString();
                //        expire = data["expire"].ToString();

                //        bimeh2 = data["bimeh2"].ToString();
                //        bimehno2 = data["bimehno2"].ToString();
                //        serial2 = data["serial2"].ToString();
                //        expire2 = data["expire2"].ToString();

                //        bimeh3 = data["bimeh3"].ToString();
                //        bimehno3 = data["bimehno3"].ToString();
                //        serial3 = data["serial3"].ToString();
                //        expire3 = data["expire3"].ToString();

                //        bimeh4 = data["bimeh4"].ToString();
                //        bimehno4 = data["bimehno4"].ToString();
                //        serial4 = data["serial4"].ToString();
                //        expire4 = data["expire4"].ToString();

                //        // Address
                //        adr = data["adr"].ToString();
                //        adr2 = data["adr2"].ToString();
                //        adr3 = data["adr3"].ToString();
                //        adr4 = data["adr4"].ToString();
                //        adr5 = data["adr5"].ToString();


                //        // Telephones
                //        tel1 = data["tel1"].ToString();
                //        desc1 = data["desc1"].ToString();

                //        tel2 = data["tel2"].ToString();
                //        desc2 = data["desc2"].ToString();

                //        tel3 = data["tel3"].ToString();
                //        desc3 = data["desc3"].ToString();

                //        tel4 = data["tel4"].ToString();
                //        desc4 = data["desc4"].ToString();

                //        tel5 = data["tel5"].ToString();
                //        desc5 = data["desc5"].ToString();

                //        tel6 = data["tel6"].ToString();
                //        desc6 = data["desc6"].ToString();

                //        tel7 = data["tel7"].ToString();
                //        desc7 = data["desc7"].ToString();

                //        tel8 = data["tel8"].ToString();
                //        desc8 = data["desc8"].ToString();

                //        tel9 = data["tel9"].ToString();
                //        desc9 = data["desc9"].ToString();

                //        tel10 = data["tel10"].ToString();
                //        desc10 = data["desc10"].ToString();

                //        /// Emails
                //        edr1 = data["edr1"].ToString();
                //        email1 = data["email1"].ToString();

                //        edr2 = data["edr2"].ToString();
                //        email2 = data["email2"].ToString();

                //        edr3 = data["edr3"].ToString();
                //        email3 = data["email3"].ToString();

                //        edr4 = data["edr4"].ToString();
                //        email4 = data["email4"].ToString();

                //        edr5 = data["edr5"].ToString();
                //        email5 = data["email5"].ToString();

                //        edr6 = data["edr6"].ToString();
                //        email6 = data["email6"].ToString();

                //        edr7 = data["edr7"].ToString();
                //        email7 = data["email7"].ToString();

                //        edr8 = data["edr8"].ToString();
                //        email8 = data["email8"].ToString();

                //        edr9 = data["edr9"].ToString();
                //        email9 = data["email9"].ToString();

                //        edr10 = data["edr10"].ToString();
                //        email10 = data["email10"].ToString();
                //    }
                //    data.Close();
                //}
                //catch
                //{

                    PersianDate pd = PersianDate.Now;
                    string today;
                    today = pd.ToString().Substring(0, 10);

                    sqlcmd.CommandText = "select * from paziresh where row ='"+ Paziresh.pp_row +"' and date1 = '"+ today +"' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        title_t.Text = data["title"].ToString();
                        fname_t.Text = data["fname"].ToString();
                        mname_t.Text = data["mname"].ToString();
                        lname_t.Text = data["lname"].ToString();

                        if (lname_t.Text == "")
                        {
                            lname_t.Text = data["family"].ToString();
                        }

                        age_t.Text = data["age"].ToString();
                        child_t.Text = data["child"].ToString();
                        sodor_t.Text = data["sodor"].ToString();
                        id_t.Text = data["id"].ToString();
                        bdate_t.Text = data["bdate"].ToString();
                        string bdate = bdate_t.Text;
                        try
                        {
                            if (bdate.IndexOf('/') == 4)
                            {
                                year.Text = bdate.Substring(2, 2);
                                bdate = bdate.Substring(5, bdate.Length - 5);
                                month.Text = bdate.Substring(0, bdate.IndexOf('/'));
                                bdate = bdate.Substring(bdate.IndexOf('/') + 1, bdate.Length - bdate.IndexOf('/') - 1);
                                day.Text = bdate;
                            }
                        }
                        catch { }

                        gender_t.Text = data["gender"].ToString();

                        bar_t.Text = data["bar"].ToString();

                        bplace_t.Text = data["bplace"].ToString();
                        father_t.Text = data["father"].ToString();
                        malol_t.Text = data["malol"].ToString();
                        job_t.Text = data["job"].ToString();
                        moaref_t.Text = data["moaref"].ToString();
                        zip_t.Text = data["zip"].ToString();
                        nid_t.Text = data["nid"].ToString();
                        tahsil_t.Text = data["tahsil"].ToString();
                        marray_t.Text = data["marray"].ToString();
                        city_t.Text = data["city"].ToString();
                        othercode_t.Text = data["othercode"].ToString();
                        life_t.Text = data["life"].ToString();
                        busy_t.Text = data["busy"].ToString();
                        others_t.Text = data["others"].ToString();

                        // Bimeh Info
                        bimeh = data["bimeh"].ToString();
                        bimehno = data["bimehno"].ToString();
                        serial = data["serial"].ToString();
                        expire = data["expire"].ToString();

                        bimeh2 = data["bimeh2"].ToString();
                        bimehno2 = data["bimehno2"].ToString();
                        serial2 = data["serial2"].ToString();
                        expire2 = data["expire2"].ToString();

                        bimeh3 = data["bimeh3"].ToString();
                        bimehno3 = data["bimehno3"].ToString();
                        serial3 = data["serial3"].ToString();
                        expire3 = data["expire3"].ToString();

                        bimeh4 = data["bimeh4"].ToString();
                        bimehno4 = data["bimehno4"].ToString();
                        serial4 = data["serial4"].ToString();
                        expire4 = data["expire4"].ToString();

                        // Address
                        adr = data["adr"].ToString();
                        adr2 = data["adr2"].ToString();
                        adr3 = data["adr3"].ToString();
                        adr4 = data["adr4"].ToString();
                        adr5 = data["adr5"].ToString();


                        // Telephones
                        tel1 = data["tel1"].ToString();
                        desc1 = data["desc1"].ToString();

                        tel2 = data["tel2"].ToString();
                        desc2 = data["desc2"].ToString();

                        tel3 = data["tel3"].ToString();
                        desc3 = data["desc3"].ToString();

                        tel4 = data["tel4"].ToString();
                        desc4 = data["desc4"].ToString();

                        tel5 = data["tel5"].ToString();
                        desc5 = data["desc5"].ToString();

                        tel6 = data["tel6"].ToString();
                        desc6 = data["desc6"].ToString();

                        tel7 = data["tel7"].ToString();
                        desc7 = data["desc7"].ToString();

                        tel8 = data["tel8"].ToString();
                        desc8 = data["desc8"].ToString();

                        tel9 = data["tel9"].ToString();
                        desc9 = data["desc9"].ToString();

                        tel10 = data["tel10"].ToString();
                        desc10 = data["desc10"].ToString();

                        /// Emails
                        edr1 = data["edr1"].ToString();
                        email1 = data["email1"].ToString();

                        edr2 = data["edr2"].ToString();
                        email2 = data["email2"].ToString();

                        edr3 = data["edr3"].ToString();
                        email3 = data["email3"].ToString();

                        edr4 = data["edr4"].ToString();
                        email4 = data["email4"].ToString();

                        edr5 = data["edr5"].ToString();
                        email5 = data["email5"].ToString();

                        edr6 = data["edr6"].ToString();
                        email6 = data["email6"].ToString();

                        edr7 = data["edr7"].ToString();
                        email7 = data["email7"].ToString();

                        edr8 = data["edr8"].ToString();
                        email8 = data["email8"].ToString();

                        edr9 = data["edr9"].ToString();
                        email9 = data["email9"].ToString();

                        edr10 = data["edr10"].ToString();
                        email10 = data["email10"].ToString();
                    }
                    data.Close();

                //}
            }
            ////////////////  End of Paziresh to PJ   ///////////

            ////////////////  Start of Paziresh_Archive to PJ   ///////////
            if (paziresh_archive.archive_to_pj == true)
            {

            }
            ////////////////  End of Paziresh_Archive to PJ   ///////////
            
            
            ////////////////  Start of Patient Profile to PJ   ///////////
            if (Patient.flag_all == true)
            {
                title_t.Text = Patient.title_all;
                fname_t.Text = Patient.fname_all;
                mname_t.Text = Patient.mname_all;
                lname_t.Text = Patient.lname_all;
                age_t.Text = Patient.age_all;
                child_t.Text = Patient.child_all;
                sodor_t.Text = Patient.sodor_all;
                id_t.Text = Patient.id_all;
                day.Text = Patient.day_all;
                month.Text = Patient.month_all;
                year.Text = Patient.year_all;
                bdate_t.Text = Patient.bdate_all;
                bplace_t.Text = Patient.bplace_all;
                father_t.Text = Patient.father_all;
                malol_t.Text = Patient.malol_all;
                job_t.Text = Patient.job_all;
                moaref_t.Text = Patient.moaref_all;
                zip_t.Text = Patient.zip_all;
                nid_t.Text = Patient.nid_all;
                tahsil_t.Text = Patient.tahsil_all;
                marray_t.Text = Patient.marray_all;
                city_t.Text = Patient.city_all;

                //string b_temp = Patient.bimeh_all;
                //if (b_temp.Contains("+") == true)
                //{
                //    bimeh = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                //    b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                //    if (b_temp.Contains("+") == true)
                //    {
                //        bimeh2 = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                //        b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                //        if (b_temp.Contains("+") == true)
                //        {
                //            bimeh3 = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                //            b_temp = b_temp.Substring(b_temp.IndexOf("+") + 2, b_temp.Length - b_temp.IndexOf("+") - 2);
                //            if (b_temp.Contains("+") == true)
                //            {
                //                bimeh4 = b_temp.Substring(0, b_temp.IndexOf("+") - 1);
                //            }
                //            else
                //            {
                //                bimeh4 = b_temp;
                //            }
                //        }
                //        else
                //        {
                //            bimeh3 = b_temp;
                //        }
                //    }
                //    else
                //    {
                //        bimeh2 = b_temp;
                //    }
                //}
                //else
                //{
                //    bimeh = b_temp;
                //}





                bimeh = Patient.bimeh_all;
                bimeh2 = Patient.bimeh2_all;
                bimeh3 = Patient.bimeh3_all;
                bimeh4 = Patient.bimeh4_all;
                adr = Patient.adr_all;

                gender_t.Text = Patient.gender_all;

                bar_t.Text = Patient.bar_all;

                PersianDate pd = PersianDate.Now;
                string today;
                today = pd.ToString().Substring(0, 10);

                if (Patient.par == 0)
                {
                    if (Paziresh.paziresh_to_pp == true)
                    {
                        // Start of par = 0  and paziresh_to_pp = true
                        sqlcmd.CommandText = "select * from paziresh where date1 = '"+today+"' and row = '"+ Patient.pp_paz_row +"' ";
                        data = sqlcmd.ExecuteReader();
                        while(data.Read())
                        {
                            bimehno = data["bimehno"].ToString();
                            serial = data["serial"].ToString();
                            expire = data["expire"].ToString();

                            //bimeh2 = data["bimeh2"].ToString();
                            bimehno2 = data["bimehno2"].ToString();
                            serial2 = data["serial2"].ToString();
                            expire2 = data["expire2"].ToString();
            
                            //bimeh3 = data["bimeh3"].ToString();
                            bimehno2 = data["bimehno3"].ToString();
                            serial3 = data["serial3"].ToString();
                            expire3 = data["expire3"].ToString();

                            //bimeh4 = data["bimeh4"].ToString();
                            bimehno4 = data["bimehno4"].ToString();
                            serial4 = data["serial4"].ToString();
                            expire4 = data["expire4"].ToString();

                            adr2 = data["adr2"].ToString();
                            adr3 = data["adr3"].ToString();
                            adr4 = data["adr4"].ToString();
                            adr5 = data["adr5"].ToString();

                            tel1 = data["tel1"].ToString();
                            desc1 = data["desc1"].ToString();
                            tel2 = data["tel2"].ToString();
                            desc2 = data["desc2"].ToString();
                            tel3 = data["tel3"].ToString();
                            desc3 = data["desc3"].ToString();
                            tel4 = data["tel4"].ToString();
                            desc4 = data["desc4"].ToString();
                            tel5 = data["tel5"].ToString();
                            desc5 = data["desc5"].ToString();
                            tel6 = data["tel6"].ToString();
                            desc6 = data["desc6"].ToString();
                            tel7 = data["tel7"].ToString();
                            desc7 = data["desc7"].ToString();
                            tel8 = data["tel8"].ToString();
                            desc8 = data["desc8"].ToString();
                            tel9 = data["tel9"].ToString();
                            desc9 = data["desc9"].ToString();
                            tel10 = data["tel10"].ToString();
                            desc10 = data["desc10"].ToString();

                            othercode_t.Text = data["othercode"].ToString();
                            life_t.Text = data["life"].ToString();
                            busy_t.Text = data["busy"].ToString();
                            others_t.Text = data["others"].ToString();

                            edr1 = data["edr1"].ToString();
                            email1 = data["email1"].ToString();
                            edr2 = data["edr2"].ToString();
                            email2 = data["email2"].ToString();
                            edr3 = data["edr3"].ToString();
                            email3 = data["email3"].ToString();
                            edr4 = data["edr4"].ToString();
                            email4 = data["email4"].ToString();
                            edr5 = data["edr5"].ToString();
                            email5 = data["email5"].ToString();
                            edr6 = data["edr6"].ToString();
                            email6 = data["email6"].ToString();
                            edr7 = data["edr7"].ToString();
                            email7 = data["email7"].ToString();
                            edr8 = data["edr8"].ToString();
                            email8 = data["email8"].ToString();
                            edr9 = data["edr9"].ToString();
                            email9 = data["email9"].ToString();
                            edr10 = data["edr10"].ToString();
                            email10 = data["email10"].ToString();
                        }
                        data.Close();
                        // End of par = 0 and paziresh_to_pp = true
                    }
                    else
                    {
                        // Start of par = 0 and paziresh_to_pp = false
                        othercode_t.Text = Patient.othercode_all;
                        life_t.Text = Patient.life_all;
                        busy_t.Text = Patient.busy_all;
                        others_t.Text = Patient.others_all;

                        bimehno = Patient.bimehno_all;
                        serial = Patient.serial_all;
                        expire = Patient.expire_all;

                        bimeh2 = Patient.bimeh2_all;
                        bimehno2 = Patient.bimehno2_all;
                        serial2 = Patient.serial2_all;
                        expire2 = Patient.expire2_all;

                        bimeh3 = Patient.bimeh3_all;
                        bimehno3 = Patient.bimehno3_all;
                        serial3 = Patient.serial3_all;
                        expire3 = Patient.expire3_all;

                        bimeh4 = Patient.bimeh4_all;
                        bimehno4 = Patient.bimehno4_all;
                        serial4 = Patient.serial4_all;
                        expire4 = Patient.expire4_all;

                        adr2 = Patient.adr2_all;
                        adr3 = Patient.adr3_all;
                        adr4 = Patient.adr4_all;
                        adr5 = Patient.adr5_all;

                        tel1 = Patient.tel1_all;
                        desc1 = Patient.desc1_all;
                        tel2 = Patient.tel2_all;
                        desc2 = Patient.desc2_all;
                        tel3 = Patient.tel3_all;
                        desc3 = Patient.desc3_all;
                        tel4 = Patient.tel4_all;
                        desc4 = Patient.desc4_all;
                        tel5 = Patient.tel5_all;
                        desc5 = Patient.desc5_all;
                        tel6 = Patient.tel6_all;
                        desc6 = Patient.desc6_all;
                        tel7 = Patient.tel7_all;
                        desc7 = Patient.desc7_all;
                        tel8 = Patient.tel8_all;
                        desc8 = Patient.desc8_all;
                        tel9 = Patient.tel9_all;
                        desc9 = Patient.desc9_all;
                        tel10 = Patient.tel10_all;
                        desc10 = Patient.desc10_all;

                        edr1 = Patient.edr1_all;
                        email1 = Patient.email1_all;
                        edr2 = Patient.edr2_all;
                        email2 = Patient.email2_all;
                        edr3 = Patient.edr3_all;
                        email3 = Patient.email3_all;
                        edr4 = Patient.edr4_all;
                        email4 = Patient.email4_all;
                        edr5 = Patient.edr5_all;
                        email5 = Patient.email5_all;
                        edr6 = Patient.edr6_all;
                        email6 = Patient.email6_all;
                        edr7 = Patient.edr7_all;
                        email7 = Patient.email7_all;
                        edr8 = Patient.edr8_all;
                        email8 = Patient.email8_all;
                        edr9 = Patient.edr9_all;
                        email9 = Patient.email9_all;
                        edr10 = Patient.edr10_all;
                        email10 = Patient.email10_all;
                        // End of par = 0 and paziresh_to_pp = false
                    }
                }
                else
                {
                    // par != 0
                    if (Paziresh.paziresh_to_pp == true)
                    {
                        // Start of par != 0 and paziresh_to_pp = true
                        sqlcmd.CommandText = "select * from paziresh where date1 = '" + today + "' and row = '" + Patient.pp_paz_row + "' ";
                        data = sqlcmd.ExecuteReader();
                        while (data.Read())
                        {
                            bimehno = data["bimehno"].ToString();
                            serial = data["serial"].ToString();
                            expire = data["expire"].ToString();

                            //bimeh2 = data["bimeh2"].ToString();
                            bimehno2 = data["bimehno2"].ToString();
                            serial2 = data["serial2"].ToString();
                            expire2 = data["expire2"].ToString();

                            //bimeh3 = data["bimeh3"].ToString();
                            bimehno2 = data["bimehno3"].ToString();
                            serial3 = data["serial3"].ToString();
                            expire3 = data["expire3"].ToString();

                            //bimeh4 = data["bimeh4"].ToString();
                            bimehno4 = data["bimehno4"].ToString();
                            serial4 = data["serial4"].ToString();
                            expire4 = data["expire4"].ToString();

                            adr2 = data["adr2"].ToString();
                            adr3 = data["adr3"].ToString();
                            adr4 = data["adr4"].ToString();
                            adr5 = data["adr5"].ToString();

                            tel1 = data["tel1"].ToString();
                            desc1 = data["desc1"].ToString();
                            tel2 = data["tel2"].ToString();
                            desc2 = data["desc2"].ToString();
                            tel3 = data["tel3"].ToString();
                            desc3 = data["desc3"].ToString();
                            tel4 = data["tel4"].ToString();
                            desc4 = data["desc4"].ToString();
                            tel5 = data["tel5"].ToString();
                            desc5 = data["desc5"].ToString();
                            tel6 = data["tel6"].ToString();
                            desc6 = data["desc6"].ToString();
                            tel7 = data["tel7"].ToString();
                            desc7 = data["desc7"].ToString();
                            tel8 = data["tel8"].ToString();
                            desc8 = data["desc8"].ToString();
                            tel9 = data["tel9"].ToString();
                            desc9 = data["desc9"].ToString();
                            tel10 = data["tel10"].ToString();
                            desc10 = data["desc10"].ToString();

                            othercode_t.Text = data["othercode"].ToString();
                            life_t.Text = data["life"].ToString();
                            busy_t.Text = data["busy"].ToString();
                            others_t.Text = data["others"].ToString();

                            edr1 = data["edr1"].ToString();
                            email1 = data["email1"].ToString();
                            edr2 = data["edr2"].ToString();
                            email2 = data["email2"].ToString();
                            edr3 = data["edr3"].ToString();
                            email3 = data["email3"].ToString();
                            edr4 = data["edr4"].ToString();
                            email4 = data["email4"].ToString();
                            edr5 = data["edr5"].ToString();
                            email5 = data["email5"].ToString();
                            edr6 = data["edr6"].ToString();
                            email6 = data["email6"].ToString();
                            edr7 = data["edr7"].ToString();
                            email7 = data["email7"].ToString();
                            edr8 = data["edr8"].ToString();
                            email8 = data["email8"].ToString();
                            edr9 = data["edr9"].ToString();
                            email9 = data["email9"].ToString();
                            edr10 = data["edr10"].ToString();
                            email10 = data["email10"].ToString();
                        }
                        data.Close();
                        // End of par != 0 and paziresh_to_pp = true
                    }
                    else
                    {
                        // Start of par != 0 and paziresh_to_pp == false
                        sqlcmd.CommandText = "select * from sick1 where par = '" + Patient.par + "' ";
                        data = sqlcmd.ExecuteReader();
                        while (data.Read())
                        {
                            othercode_t.Text = data["othercode"].ToString();
                            life_t.Text = data["life"].ToString();
                            busy_t.Text = data["busy"].ToString();
                            others_t.Text = data["others"].ToString();

                            // Bimeh Info
                            //bimeh = data["bimeh"].ToString();
                            bimehno = data["bimehno"].ToString();
                            serial = data["serial"].ToString();
                            expire = data["expire"].ToString();

                            //bimeh2 = data["bimeh2"].ToString();
                            bimehno2 = data["bimehno2"].ToString();
                            serial2 = data["serial2"].ToString();
                            expire2 = data["expire2"].ToString();

                            //bimeh3 = data["bimeh3"].ToString();
                            bimehno3 = data["bimehno3"].ToString();
                            serial3 = data["serial3"].ToString();
                            expire3 = data["expire3"].ToString();

                            //bimeh4 = data["bimeh4"].ToString();
                            bimehno4 = data["bimehno4"].ToString();
                            serial4 = data["serial4"].ToString();
                            expire4 = data["expire4"].ToString();

                            // Address
                            //adr = data["adr"].ToString();
                            adr2 = data["adr2"].ToString();
                            adr3 = data["adr3"].ToString();
                            adr4 = data["adr4"].ToString();
                            adr5 = data["adr5"].ToString();


                            // Telephones
                            tel1 = data["tel1"].ToString();
                            desc1 = data["desc1"].ToString();

                            tel2 = data["tel2"].ToString();
                            desc2 = data["desc2"].ToString();

                            tel3 = data["tel3"].ToString();
                            desc3 = data["desc3"].ToString();

                            tel4 = data["tel4"].ToString();
                            desc4 = data["desc4"].ToString();

                            tel5 = data["tel5"].ToString();
                            desc5 = data["desc5"].ToString();

                            tel6 = data["tel6"].ToString();
                            desc6 = data["desc6"].ToString();

                            tel7 = data["tel7"].ToString();
                            desc7 = data["desc7"].ToString();

                            tel8 = data["tel8"].ToString();
                            desc8 = data["desc8"].ToString();

                            tel9 = data["tel9"].ToString();
                            desc9 = data["desc9"].ToString();

                            tel10 = data["tel10"].ToString();
                            desc10 = data["desc10"].ToString();

                            /// Emails
                            edr1 = data["edr1"].ToString();
                            email1 = data["email1"].ToString();

                            edr2 = data["edr2"].ToString();
                            email2 = data["email2"].ToString();

                            edr3 = data["edr3"].ToString();
                            email3 = data["email3"].ToString();

                            edr4 = data["edr4"].ToString();
                            email4 = data["email4"].ToString();

                            edr5 = data["edr5"].ToString();
                            email5 = data["email5"].ToString();

                            edr6 = data["edr6"].ToString();
                            email6 = data["email6"].ToString();

                            edr7 = data["edr7"].ToString();
                            email7 = data["email7"].ToString();

                            edr8 = data["edr8"].ToString();
                            email8 = data["email8"].ToString();

                            edr9 = data["edr9"].ToString();
                            email9 = data["email9"].ToString();

                            edr10 = data["edr10"].ToString();
                            email10 = data["email10"].ToString();


                        }
                        data.Close();
                        // End of par != 0 and paziresh_to_pp == false
                    } 
                }
            }
            ////////////////  End of Patient Profile to PJ   ///////////

            sqlconn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mname_t.Text == ""  || lname_t.Text == "")
            {
                alert frm1 = new alert();
                frm1.ShowDialog();
            }
            title_c.Visible = false;
            if (pinfo_b.Text == "+")
            {
                num++;
                pinfo_p.Visible = true;
                pinfo_b.Text = "-";
                pictureBox1.Visible = false;
                day.Focus();
            }
            else
            {
                pinfo_p .Visible = false;
                pinfo_b.Text = "+";

                num--;
                if (num == 0)
                    pictureBox1.Visible = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cm_menu.Visible == false)
            {
                cm_menu.Visible = true;
                //cm_menu.Top = 38;
                //cm_menu.Left = 0;

            }
            else
            {
                cm_menu.Visible = false;
            }
        }

        private void all_info_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void finfo_b_Click(object sender, EventArgs e)
        {
            title_c.Visible = false;
            if (finfo_b.Text == "+")
            {
                num++;
                finfo_p.Visible = true;
                finfo_b.Text = "-";
                pictureBox1.Visible = false;
                marray_t.Focus();
            }
            else
            {
                finfo_p.Visible = false;
                finfo_b.Text = "+";
                num--;
                if (num == 0)
                    pictureBox1.Visible = true;
            }
        }

        private void code_b_Click(object sender, EventArgs e)
        {
            title_c.Visible = false;
            if (code_b.Text == "+")
            {
                num++;
                code_p.Visible = true;
                code_b.Text = "-";
                pictureBox1.Visible = false;
                nid_t.Focus();
            }
            else
            {
                code_p.Visible = false;
                code_b.Text = "+";
                num--;
                if (num == 0)
                    pictureBox1.Visible = true;
            }
        }

        private void other_b_Click(object sender, EventArgs e)
        {
            title_c.Visible = false;
            if (other_b.Text == "+")
            {
                num++;
                other_p.Visible = true;
                other_b.Text = "-";
                pictureBox1.Visible = false;
                life_t.Focus();
            }
            else
            {
                other_p.Visible = false;
                other_b.Text = "+";
                num--;
                if (num == 0)
                    pictureBox1.Visible = true;
            }
        }

        private void email_b_Click(object sender, EventArgs e)
        {
            email_j frm = new email_j();
            frm.ShowDialog();
        }

        private void year_Leave(object sender, EventArgs e)
        {
            bdate_t.Text = label10.Text + year.Text + "/" + month.Text + "/" + day.Text;
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
        }

        private void title_c_Click(object sender, EventArgs e)
        {
            if (title_c.Width != 102)
                title_c.Width = 102;
        }

        private void title_c_MouseHover(object sender, EventArgs e)
        {
            title_c.Width = 102;
            title_c.SendToBack();
        }

        private void title_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            title_t.Text = title_c.Text;
            title_c.Width = 17;
            title_c.Visible = false;
            title_t.Focus();


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

        private void sodor_t_Click(object sender, EventArgs e)
        {
            sodor_c.Width = 17;
            sodor_c.Visible = true;
        }

        private void job_t_Click(object sender, EventArgs e)
        {
            job_c.Width = 17;
            job_c.Visible = true;
        }

        private void moaref_t_Click(object sender, EventArgs e)
        {
            moaref_c.Width = 17;
            moaref_c.Visible = true;
        }

        private void tahsil_t_Click(object sender, EventArgs e)
        {
            tahsil_c.Width = 17;
            tahsil_c.Visible = true;
        }

        private void marray_t_Click(object sender, EventArgs e)
        {
            marray_c.Width = 17;
            marray_c.Visible = true;
        }

        private void bplace_c_Click(object sender, EventArgs e)
        {
            if (bplace_c.Width != 22 + bplace_t.Width)
                bplace_c.Width = 22 + bplace_t.Width;
        }

        private void bplace_c_MouseHover(object sender, EventArgs e)
        {
            bplace_c.Width = 22 + bplace_t.Width;
            bplace_c.SendToBack();
        }

        private void bplace_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bplace_t.Text = bplace_c.Text;
            bplace_c.Width = 17;
            bplace_c.Visible = false;
            bplace_t.Focus();
        }

        private void sodor_c_Click(object sender, EventArgs e)
        {
            if (sodor_c.Width != 22 + sodor_t.Width)
                sodor_c.Width = 22 + sodor_t.Width;
        }

        private void sodor_c_MouseHover(object sender, EventArgs e)
        {
            sodor_c.Width = 22 + sodor_t.Width;
            sodor_c.SendToBack();
        }

        private void sodor_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            sodor_t.Text = sodor_c.Text;
            sodor_c.Width = 17;
            sodor_c.Visible = false;
            sodor_t.Focus();
        }

        private void job_c_Click(object sender, EventArgs e)
        {
            if (job_c.Width != 22 + job_t.Width)
                job_c.Width = 22 + job_t.Width;
        }

        private void job_c_MouseHover(object sender, EventArgs e)
        {
            job_c.Width = 22 + job_t.Width;
            job_c.SendToBack();
        }

        private void job_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            job_t.Text = job_c.Text;
            job_c.Width = 17;
            job_c.Visible = false;
            job_t.Focus();
        }

        private void marray_c_Click(object sender, EventArgs e)
        {
            if (marray_c.Width != 22 + marray_t.Width)
                marray_c.Width = 22 + marray_t.Width;
        }

        private void marray_c_MouseHover(object sender, EventArgs e)
        {
            marray_c.Width = 22 + marray_t.Width;
            marray_c.SendToBack();
        }

        private void marray_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            marray_t.Text = marray_c.Text;
            marray_c.Width = 17;
            marray_c.Visible = false;
            marray_t.Focus();
        }

        private void tahsil_c_Click(object sender, EventArgs e)
        {
            if (tahsil_c.Width != 22 + tahsil_t.Width)
                tahsil_c.Width = 22 + tahsil_t.Width;
        }

        private void tahsil_c_MouseHover(object sender, EventArgs e)
        {
            tahsil_c.Width = 22 + tahsil_t.Width;
            tahsil_c.SendToBack();
        }

        private void tahsil_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            tahsil_t.Text = tahsil_c.Text;
            tahsil_c.Width = 17;
            tahsil_c.Visible = false;
            tahsil_t.Focus();
        }

        private void moaref_c_Click(object sender, EventArgs e)
        {
            if (moaref_c.Width != 22 + moaref_t.Width)
                moaref_c.Width = 22 + moaref_t.Width;
        }

        private void moaref_c_MouseHover(object sender, EventArgs e)
        {
            moaref_c.Width = 22 + moaref_t.Width;
            moaref_c.SendToBack();
        }

        private void moaref_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            moaref_t.Text = moaref_c.Text;
            moaref_c.Width = 17;
            moaref_c.Visible = false;
            moaref_t.Focus();
        }

        private void cm1_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible == false)
            {
                menuStrip1.Visible = true;
                //cm_menu.Top = 38;
                //cm_menu.Left = 0;

            }
            else
            {
                menuStrip1.Visible = false;
            }
        }

        private void tel_b_Click(object sender, EventArgs e)
        {
            adr_tel frm = new adr_tel();
            frm.ShowDialog();
        }

        private void all_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fname_t.Text == "")
            {
                alert frm1 = new alert();
                frm1.ShowDialog();
                e.Cancel = true;
                return;
            }

            if (mname_t.Text == "" && lname_t.Text == "")
            {
                alert frm1 = new alert();
                frm1.ShowDialog();
                e.Cancel = true;
                return;
            }
            
            
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string family = (mname_t.Text + " " + lname_t.Text).Trim();

            string bar = "", gender = "";
            bar = bar_t.Text;
            gender = gender_t.Text;
            

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (Paziresh.paziresh_to_pj == true)
            {
                Paziresh.paziresh_to_pj = false;

                sqlcmd.CommandText = "Update paziresh set family = '" + family + "',title='" + title_t.Text + "',fname='" + fname_t.Text + "',mname='" + mname_t.Text + "',lname='" + lname_t.Text + "',age='" + age_t.Text + "',job='" + job_t.Text + "',bplace='" + bplace_t.Text + "',bimeh='" + bimeh + "',bimehno='" + bimehno + "',serial='" + serial + "',expire='" + expire + "',bimeh2='" + bimeh2 + "',bimehno2='" + bimehno2 + "',serial2='" + serial2 + "',expire2='" + expire2 + "',bimeh3='" + bimeh3 + "',bimehno3='" + bimehno3 + "',serial3='" + serial3 + "',expire3='" + expire3 + "',bimeh4='" + bimeh4 + "',bimehno4='" + bimehno4 + "',serial4='" + serial4 + "',expire4='" + expire4 + "',marray = '" + marray_t.Text + "',child = '" + child_t.Text + "',bar = '" + bar + "',gender = '" + gender + "',moaref = '" + moaref_t.Text + "',father = '" + father_t.Text + "',id = '" + id_t.Text + "',bdate = '" + bdate_t.Text + "',nid = '" + nid_t.Text + "',zip = '" + zip_t.Text + "',city = '" + city_t.Text + "',sodor = '" + sodor_t.Text + "',malol = '" + malol_t.Text + "',adr = '" + adr + "',adr2 = '" + adr2 + "',adr3 = '" + adr3 + "',adr4 = '" + adr4 + "',adr5 = '" + adr5 + "',tel1 = '" + tel1 + "',desc1 = '" + desc1 + "',tel2 = '" + tel2 + "',desc2 = '" + desc2 + "',tel3 = '" + tel3 + "',desc3 = '" + desc3 + "',tel4 = '" + tel4 + "',desc4 = '" + desc4 + "',tel5 = '" + tel5 + "',desc5 = '" + desc5 + "',tel6 = '" + tel6 + "',desc6 = '" + desc6 + "',tel7 = '" + tel7 + "',desc7 = '" + desc7 + "',tel8 = '" + tel8 + "',desc8 = '" + desc8 + "',tel9 = '" + tel9 + "',desc9 = '" + desc9 + "',tel10 = '" + tel10 + "',desc10 = '" + desc10 + "',tahsil = '" + tahsil_t.Text + "',othercode = '" + othercode_t.Text + "',life = '" + life_t.Text + "',busy = '" + busy_t.Text + "',others = '" + others_t.Text + "',edr1 = '" + edr1 + "',email1 = '" + email1 + "',edr2 = '" + edr2 + "',email2 = '" + email2 + "',edr3 = '" + edr3 + "',email3 = '" + email3 + "',edr4 = '" + edr4 + "',email4 = '" + email4 + "',edr5 = '" + edr5 + "',email5 = '" + email5 + "',edr6 = '" + edr6 + "',email6 = '" + email6 + "',edr7 = '" + edr7 + "',email7 = '" + email7 + "',edr8 = '" + edr8 + "',email8 = '" + email8 + "',edr9 = '" + edr9 + "',email9 = '" + email9 + "',edr10 = '" + edr10 + "',email10 = '" + email10 + "' where row = '" + Paziresh.pp_row + "' and date1 = '" + today + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (Patient.flag_all == true)
            {
                Patient.flag_all = false;

                Patient.title_all = title_t.Text;
                Patient.fname_all = fname_t.Text;
                Patient.mname_all = mname_t.Text;
                Patient.lname_all = lname_t.Text;
                Patient.age_all = age_t.Text;
                Patient.job_all = job_t.Text;
                Patient.bplace_all = bplace_t.Text;

                Patient.bimeh_all = bimeh;
                Patient.bimeh2_all = bimeh2;
                Patient.bimeh3_all = bimeh3;
                Patient.bimeh4_all = bimeh4;

                Patient.marray_all = marray_t.Text;
                Patient.child_all = child_t.Text;
                Patient.bar_all = bar;
                Patient.gender_all = gender;
                Patient.moaref_all = moaref_t.Text;
                Patient.father_all = father_t.Text;
                Patient.id_all = id_t.Text;
                Patient.bdate_all = bdate_t.Text;
                Patient.day_all = day.Text;
                Patient.month_all = month.Text;
                Patient.year_all = year.Text;
                Patient.nid_all = nid_t.Text;
                Patient.zip_all = zip_t.Text;
                Patient.city_all = city_t.Text;
                Patient.sodor_all = sodor_t.Text;
                Patient.malol_all = malol_t.Text;
                Patient.adr_all = adr;
                Patient.tahsil_all = tahsil_t.Text;

                if (Patient.par == 0 && Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "Update paziresh set family = '" + family + "',title='" + title_t.Text + "',fname='" + fname_t.Text + "',mname='" + mname_t.Text + "',lname='" + lname_t.Text + "',age='" + age_t.Text + "',job='" + job_t.Text + "',bplace='" + bplace_t.Text + "',bimeh='" + bimeh + "',bimehno='" + bimehno + "',serial='" + serial + "',expire='" + expire + "',bimeh2='" + bimeh2 + "',bimehno2='" + bimehno2 + "',serial2='" + serial2 + "',expire2='" + expire2 + "',bimeh3='" + bimeh3 + "',bimehno3='" + bimehno3 + "',serial3='" + serial3 + "',expire3='" + expire3 + "',bimeh4='" + bimeh4 + "',bimehno4='" + bimehno4 + "',serial4='" + serial4 + "',expire4='" + expire4 + "',marray = '" + marray_t.Text + "',child = '" + child_t.Text + "',bar = '" + bar + "',gender = '" + gender + "',moaref = '" + moaref_t.Text + "',father = '" + father_t.Text + "',id = '" + id_t.Text + "',bdate = '" + bdate_t.Text + "',nid = '" + nid_t.Text + "',zip = '" + zip_t.Text + "',city = '" + city_t.Text + "',sodor = '" + sodor_t.Text + "',malol = '" + malol_t.Text + "',adr = '" + adr + "',adr2 = '" + adr2 + "',adr3 = '" + adr3 + "',adr4 = '" + adr4 + "',adr5 = '" + adr5 + "',tel1 = '" + tel1 + "',desc1 = '" + desc1 + "',tel2 = '" + tel2 + "',desc2 = '" + desc2 + "',tel3 = '" + tel3 + "',desc3 = '" + desc3 + "',tel4 = '" + tel4 + "',desc4 = '" + desc4 + "',tel5 = '" + tel5 + "',desc5 = '" + desc5 + "',tel6 = '" + tel6 + "',desc6 = '" + desc6 + "',tel7 = '" + tel7 + "',desc7 = '" + desc7 + "',tel8 = '" + tel8 + "',desc8 = '" + desc8 + "',tel9 = '" + tel9 + "',desc9 = '" + desc9 + "',tel10 = '" + tel10 + "',desc10 = '" + desc10 + "',tahsil = '" + tahsil_t.Text + "',othercode = '" + othercode_t.Text + "',life = '" + life_t.Text + "',busy = '" + busy_t.Text + "',others = '" + others_t.Text + "',edr1 = '" + edr1 + "',email1 = '" + email1 + "',edr2 = '" + edr2 + "',email2 = '" + email2 + "',edr3 = '" + edr3 + "',email3 = '" + email3 + "',edr4 = '" + edr4 + "',email4 = '" + email4 + "',edr5 = '" + edr5 + "',email5 = '" + email5 + "',edr6 = '" + edr6 + "',email6 = '" + email6 + "',edr7 = '" + edr7 + "',email7 = '" + email7 + "',edr8 = '" + edr8 + "',email8 = '" + email8 + "',edr9 = '" + edr9 + "',email9 = '" + email9 + "',edr10 = '" + edr10 + "',email10 = '" + email10 + "' where row = '" + Patient.pp_paz_row + "' and date1 = '" + today + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (Patient.par == 0 && Paziresh.paziresh_to_pp == false)
                {
                    Patient.bimehno_all = bimehno;
                    Patient.serial_all = serial;
                    Patient.expire_all = expire;

                    Patient.bimeh2_all = bimeh2;
                    Patient.bimehno2_all = bimehno2;
                    Patient.serial2_all = serial2;
                    Patient.expire2_all = expire2;

                    Patient.bimeh3_all = bimeh3;
                    Patient.bimehno3_all = bimehno3;
                    Patient.serial3_all = serial3;
                    Patient.expire3_all = expire3;

                    Patient.bimeh4_all = bimeh4;
                    Patient.bimehno4_all = bimehno4;
                    Patient.serial4_all = serial4;
                    Patient.expire4_all = expire4;

                    Patient.adr2_all = adr2;
                    Patient.adr3_all = adr3;
                    Patient.adr4_all = adr4;
                    Patient.adr5_all = adr5;

                    Patient.tel1_all = tel1;
                    Patient.desc1_all = desc1;
                    Patient.tel2_all = tel2;
                    Patient.desc2_all = desc2;
                    Patient.tel3_all = tel3;
                    Patient.desc3_all = desc3;
                    Patient.tel4_all = tel4;
                    Patient.desc4_all = desc4;
                    Patient.tel5_all = tel5;
                    Patient.desc5_all = desc5;
                    Patient.tel6_all = tel6;
                    Patient.desc6_all = desc6;
                    Patient.tel7_all = tel7;
                    Patient.desc7_all = desc7;
                    Patient.tel8_all = tel8;
                    Patient.desc8_all = desc8;
                    Patient.tel9_all = tel9;
                    Patient.desc9_all = desc9;
                    Patient.tel10_all = tel10;
                    Patient.desc10_all = desc10;

                    Patient.othercode_all = othercode_t.Text;
                    Patient.life_all = life_t.Text;
                    Patient.busy_all = busy_t.Text;
                    Patient.others_all = others_t.Text;

                    Patient.edr1_all = edr1;
                    Patient.email1_all = email1;
                    Patient.edr2_all = edr2;
                    Patient.email2_all = email2;
                    Patient.edr3_all = edr3;
                    Patient.email3_all = email3;
                    Patient.edr4_all = edr4;
                    Patient.email4_all = email4;
                    Patient.edr5_all = edr5;
                    Patient.email5_all = email5;
                    Patient.edr6_all = edr6;
                    Patient.email6_all = email6;
                    Patient.edr7_all = edr7;
                    Patient.email7_all = email7;
                    Patient.edr8_all = edr8;
                    Patient.email8_all = email8;
                    Patient.edr9_all = edr9;
                    Patient.email9_all = email9;
                    Patient.edr10_all = edr10;
                    Patient.email10_all = email10;
                }

                if (Patient.par != 0 && Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "Update paziresh set family = '" + family + "',title='" + title_t.Text + "',fname='" + fname_t.Text + "',mname='" + mname_t.Text + "',lname='" + lname_t.Text + "',age='" + age_t.Text + "',job='" + job_t.Text + "',bplace='" + bplace_t.Text + "',bimeh='" + bimeh + "',bimehno='" + bimehno + "',serial='" + serial + "',expire='" + expire + "',bimeh2='" + bimeh2 + "',bimehno2='" + bimehno2 + "',serial2='" + serial2 + "',expire2='" + expire2 + "',bimeh3='" + bimeh3 + "',bimehno3='" + bimehno3 + "',serial3='" + serial3 + "',expire3='" + expire3 + "',bimeh4='" + bimeh4 + "',bimehno4='" + bimehno4 + "',serial4='" + serial4 + "',expire4='" + expire4 + "',marray = '" + marray_t.Text + "',child = '" + child_t.Text + "',bar = '" + bar + "',gender = '" + gender + "',moaref = '" + moaref_t.Text + "',father = '" + father_t.Text + "',id = '" + id_t.Text + "',bdate = '" + bdate_t.Text + "',nid = '" + nid_t.Text + "',zip = '" + zip_t.Text + "',city = '" + city_t.Text + "',sodor = '" + sodor_t.Text + "',malol = '" + malol_t.Text + "',adr = '" + adr + "',adr2 = '" + adr2 + "',adr3 = '" + adr3 + "',adr4 = '" + adr4 + "',adr5 = '" + adr5 + "',tel1 = '" + tel1 + "',desc1 = '" + desc1 + "',tel2 = '" + tel2 + "',desc2 = '" + desc2 + "',tel3 = '" + tel3 + "',desc3 = '" + desc3 + "',tel4 = '" + tel4 + "',desc4 = '" + desc4 + "',tel5 = '" + tel5 + "',desc5 = '" + desc5 + "',tel6 = '" + tel6 + "',desc6 = '" + desc6 + "',tel7 = '" + tel7 + "',desc7 = '" + desc7 + "',tel8 = '" + tel8 + "',desc8 = '" + desc8 + "',tel9 = '" + tel9 + "',desc9 = '" + desc9 + "',tel10 = '" + tel10 + "',desc10 = '" + desc10 + "',tahsil = '" + tahsil_t.Text + "',othercode = '" + othercode_t.Text + "',life = '" + life_t.Text + "',busy = '" + busy_t.Text + "',others = '" + others_t.Text + "',edr1 = '" + edr1 + "',email1 = '" + email1 + "',edr2 = '" + edr2 + "',email2 = '" + email2 + "',edr3 = '" + edr3 + "',email3 = '" + email3 + "',edr4 = '" + edr4 + "',email4 = '" + email4 + "',edr5 = '" + edr5 + "',email5 = '" + email5 + "',edr6 = '" + edr6 + "',email6 = '" + email6 + "',edr7 = '" + edr7 + "',email7 = '" + email7 + "',edr8 = '" + edr8 + "',email8 = '" + email8 + "',edr9 = '" + edr9 + "',email9 = '" + email9 + "',edr10 = '" + edr10 + "',email10 = '" + email10 + "' where row = '" + Patient.pp_paz_row + "' and date1 = '" + today + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (Patient.par != 0 && Paziresh.paziresh_to_pp == false)
                {
                    Patient.bimehno_all = bimehno;
                    Patient.serial_all = serial;
                    Patient.expire_all = expire;

                    Patient.bimeh2_all = bimeh2;
                    Patient.bimehno2_all = bimehno2;
                    Patient.serial2_all = serial2;
                    Patient.expire2_all = expire2;

                    Patient.bimeh3_all = bimeh3;
                    Patient.bimehno3_all = bimehno3;
                    Patient.serial3_all = serial3;
                    Patient.expire3_all = expire3;

                    Patient.bimeh4_all = bimeh4;
                    Patient.bimehno4_all = bimehno4;
                    Patient.serial4_all = serial4;
                    Patient.expire4_all = expire4;

                    Patient.adr2_all = adr2;
                    Patient.adr3_all = adr3;
                    Patient.adr4_all = adr4;
                    Patient.adr5_all = adr5;

                    Patient.tel1_all = tel1;
                    Patient.desc1_all = desc1;
                    Patient.tel2_all = tel2;
                    Patient.desc2_all = desc2;
                    Patient.tel3_all = tel3;
                    Patient.desc3_all = desc3;
                    Patient.tel4_all = tel4;
                    Patient.desc4_all = desc4;
                    Patient.tel5_all = tel5;
                    Patient.desc5_all = desc5;
                    Patient.tel6_all = tel6;
                    Patient.desc6_all = desc6;
                    Patient.tel7_all = tel7;
                    Patient.desc7_all = desc7;
                    Patient.tel8_all = tel8;
                    Patient.desc8_all = desc8;
                    Patient.tel9_all = tel9;
                    Patient.desc9_all = desc9;
                    Patient.tel10_all = tel10;
                    Patient.desc10_all = desc10;

                    Patient.othercode_all = othercode_t.Text;
                    Patient.life_all = life_t.Text;
                    Patient.busy_all = busy_t.Text;
                    Patient.others_all = others_t.Text;

                    Patient.edr1_all = edr1;
                    Patient.email1_all = email1;
                    Patient.edr2_all = edr2;
                    Patient.email2_all = email2;
                    Patient.edr3_all = edr3;
                    Patient.email3_all = email3;
                    Patient.edr4_all = edr4;
                    Patient.email4_all = email4;
                    Patient.edr5_all = edr5;
                    Patient.email5_all = email5;
                    Patient.edr6_all = edr6;
                    Patient.email6_all = email6;
                    Patient.edr7_all = edr7;
                    Patient.email7_all = email7;
                    Patient.edr8_all = edr8;
                    Patient.email8_all = email8;
                    Patient.edr9_all = edr9;
                    Patient.email9_all = email9;
                    Patient.edr10_all = edr10;
                    Patient.email10_all = email10;
                }
            } // End of if (flag_all == true)

            // Save for AutoComplete And ComboBox
            sqlcmd.CommandText = "select count(*) from info where title='"+ title_t.Text +"' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(title) values('"+ title_t.Text +"') ";
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

            sqlcmd.CommandText = "select count(*) from info where bimeh='" + bimeh + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(bimeh) values('" + bimeh + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where bimeh='" + bimeh2 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(bimeh) values('" + bimeh2 + "') ";
                sqlcmd.ExecuteNonQuery();
            }
            
            sqlcmd.CommandText = "select count(*) from info where bimeh='" + bimeh3 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(bimeh) values('" + bimeh3 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where bimeh='" + bimeh4 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(bimeh) values('" + bimeh4 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

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

            sqlcmd.CommandText = "select count(*) from info where adr='" + adr + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(adr) values('" + adr + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where adr='" + adr2 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(adr) values('" + adr2 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where adr='" + adr3 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(adr) values('" + adr3 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where adr='" + adr4 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(adr) values('" + adr4 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from tel_tmp where desc1='" + desc1 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into tel_tmp(desc1) values('" + desc1 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from tel_tmp where desc1='" + desc2 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into tel_tmp(desc1) values('" + desc2 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from tel_tmp where desc1='" + desc3 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into tel_tmp(desc1) values('" + desc3 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from tel_tmp where desc1='" + desc4 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into tel_tmp(desc1) values('" + desc4 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from tel_tmp where desc1='" + desc5 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into tel_tmp(desc1) values('" + desc5 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from tel_tmp where desc1='" + desc6 + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into tel_tmp(desc1) values('" + desc6 + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where tahsil='" + tahsil_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(tahsil) values('" + tahsil_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where life='" + life_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(life) values('" + life_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "select count(*) from info where busy='" + busy_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into info(busy) values('" + busy_t.Text + "') ";
                sqlcmd.ExecuteNonQuery();
            }

            

            sqlconn.Close();

        }

        private void bimeh_b_Click(object sender, EventArgs e)
        {
            Bimeh_j frm = new Bimeh_j();
            frm.ShowDialog();
        }

        private void پذیرشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void بایگانیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

        private void آدرسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
            frm.Show();
        }

        private void وقتدهیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nobat frm = new nobat();
            frm.Show();
        }

        private void حسابداریوبیمهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acc frm = new acc();
            frm.Show();
        }

        private void یادآوریهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reminder frm = new Reminder();
            frm.Show();
        }

        private void autoreferalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Referral frm = new Referral();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Consultation frm = new Consultation();
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Medical_Library frm = new Medical_Library();
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DrugStore frm = new DrugStore();
            frm.Show();
        }

        private void ReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Receipt frm = new Receipt();
            frm.Show();
        }

        private void photoArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Photo_Archive frm = new Photo_Archive();
            frm.Show();
        }

        private void riskFactorAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Risk_Factor frm = new Risk_Factor();
            frm.Show();
        }

        private void researchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Research frm = new Research();
            frm.Show();
        }

        private void father_t_Enter(object sender, EventArgs e)
        {
            bplace_c.Visible = false;
        }

        private void job_t_Enter(object sender, EventArgs e)
        {
            sodor_c.Visible = false;
        }

        private void malol_t_Enter(object sender, EventArgs e)
        {
            job_c.Visible = false;
        }

        private void child_t_Enter(object sender, EventArgs e)
        {
            marray_c.Visible = false;
        }

        private void moaref_t_Enter(object sender, EventArgs e)
        {
            tahsil_c.Visible = false;
        }

        private void city_t_Click(object sender, EventArgs e)
        {
            city_c.Width = 17;
            city_c.Visible = true;
        }

        private void city_c_Click(object sender, EventArgs e)
        {
            if (city_c.Width != 22 + city_t.Width)
                city_c.Width = 22 + city_t.Width;
        }

        private void city_c_MouseHover(object sender, EventArgs e)
        {
            city_c.Width = 22 + city_t.Width;
            city_c.SendToBack();
        }

        private void city_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            city_t.Text = city_c.Text;
            city_c.Width = 17;
            city_c.Visible = false;
            city_t.Focus();
        }

        private void city_t_Enter(object sender, EventArgs e)
        {
            bplace_c.Visible = false;
            sodor_c.Visible = false;
            job_c.Visible = false;
        }

        private void life_t_Click(object sender, EventArgs e)
        {
            life_c.Width = 17;
            life_c.Visible = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            busy_c.Width = 17;
            busy_c.Visible = true;
        }

        private void busy_t_Enter(object sender, EventArgs e)
        {
            life_c.Visible = false;
        }

        private void tahsil_t_Enter(object sender, EventArgs e)
        {
            busy_c.Visible = false;
            life_c.Visible = false;
        }

        private void life_c_Click(object sender, EventArgs e)
        {
            if (life_c.Width != 22 + life_t.Width)
                life_c.Width = 22 + life_t.Width;
        }

        private void busy_c_Click(object sender, EventArgs e)
        {
            if (busy_c.Width != 22 + busy_t.Width)
                busy_c.Width = 22 + busy_t.Width;
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
                string life = data["life"].ToString();
                string busy = data["busy"].ToString();
                string tahsil = data["tahsil"].ToString();

                if (gg == "1")
                    gender_t.Text = "مذكر";
                if (gg == "2")
                    gender_t.Text = "مونث";

                if (bb == "1")
                {
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                    bar_t.Text = "بلي";
                }

                if (bb == "2")
                {
                  
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                    bar_t.Text = "خير";
                }

                if (bb == "3")
                {
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (bb == "4")
                {
                    
                    bar_l.ForeColor = System.Drawing.Color.RoyalBlue;
                }

                if (marray == "1")
                {
                    marray_l.ForeColor = System.Drawing.Color.Yellow;
                    marray_c.Visible = false;
                }

                if (marray == "2")
                {
                    marray_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    marray_t.Visible = true;
                    marray_c.Visible = false;
                }

                if (child == "1")
                {
                    child_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (child == "2")
                {
                    child_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    child_t.Visible = true;
                }

                if (job == "1")
                {
                    job_l.ForeColor = System.Drawing.Color.Yellow;
                    job_c.Visible = false;
                }

                if (job == "2")
                {
                    job_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    job_t.Visible = true;
                    job_c.Visible = false;
                }

                if (life == "1")
                {
                    life_l.ForeColor = System.Drawing.Color.Yellow;
                    life_c.Visible = false;
                }

                if (life == "2")
                {
                    life_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    life_t.Visible = true;
                    life_c.Visible = false;
                }

                if (busy == "1")
                {
                    busy_l.ForeColor = System.Drawing.Color.Yellow;
                    busy_t.Visible = true;
                    busy_c.Visible = false;
                }

                if (busy == "2")
                {
                    busy_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    busy_t.Visible = true;
                    busy_c.Visible = false;
                }

                if (tahsil == "1")
                {
                    tahsil_l.ForeColor = System.Drawing.Color.Yellow;
                    tahsil_c.Visible = false;
                }

                if (tahsil == "2")
                {
                    tahsil_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    tahsil_t.Visible = true;
                    tahsil_c.Visible = false;
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
                    child_l.ForeColor = System.Drawing.Color.RoyalBlue;
                }

                if (bar == "1")
                {
                  
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                    bar_t.Text = "بلي";


                }

                if (bar == "2")
                {
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                    bar_t.Text = "خير";
                }
                if (bar == "3")
                {
                    bar_l.ForeColor = System.Drawing.Color.Yellow;
                }

                if (bar == "4")
                {
                    bar_l.ForeColor = System.Drawing.Color.RoyalBlue;
                    bar_t.Text = "خير";
                }
            }

            data.Close();
            sqlconn.Close();
        }

        private void others_t_Enter(object sender, EventArgs e)
        {
            moaref_c.Visible = false;
        }

        private void marray_t_Enter(object sender, EventArgs e)
        {
            city_c.Visible = false;
        }

        private void برنامهمنشیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);
            string gender = "", bar = "";
            bar = bar_t.Text;
            gender = gender_t.Text;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            int sickcount = 0;
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname_t.Text + "' and lname = '" + lname_t.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());
            sqlcmd.CommandText = "select count(*) from sick1 where fname = '" + fname_t.Text + "' and mname = '" + lname_t.Text + "' ";
            sickcount += Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            string mytemp2;
            mytemp2 = "دكتر " + login.log_name + " " + login.log_family;

            if (sickcount > 0)
            {
                Search2.search2_fname = fname_t.Text;
                Search2.search2_family = lname_t.Text;
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


                sqlcmd.CommandText = "Insert into paziresh(doctor,prf,row,date1,date2,dselect,mselect,title,fname,mname,lname,family,visit,consult,service1,service2,income,ret,age,job,bplace,bimeh,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,marray,child,bar,gender,moaref,father,id,bdate,nid,zip,city,sodor,malol,adr,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,tahsil,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('"+ mytemp2 +"','"+ login.log_prf +"','" + cnt.ToString() + "','" + today + "','" + today + "','','','" + title_t.Text + "','" + fname_t.Text + "','" + mname_t.Text + "','" + lname_t.Text + "','" + (mname_t.Text + " " + lname_t.Text).Trim() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + age_t.Text + "','" + job_t.Text + "','" + bplace_t.Text + "','" + bimeh + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + marray_t.Text + "','" + child_t.Text + "','" + bar + "','" + gender + "','" + moaref_t.Text + "','" + father_t.Text + "','" + id_t.Text + "','" + bdate_t.Text + "','" + nid_t.Text + "','" + zip_t.Text + "','" + city_t.Text + "','" + sodor_t.Text + "','" + malol_t.Text + "','" + adr + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + tahsil_t.Text + "','" + othercode_t.Text + "','" + life_t.Text + "','" + busy_t.Text + "','" + others_t.Text + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
                sqlcmd.ExecuteNonQuery();
            }

            if (pj_conflict == true)
            {
                pj_conflict = false;

                sqlcmd.CommandText = "select counter from sw";
                SqlDataReader data = sqlcmd.ExecuteReader();
                Int64 cnt = 1;
                while (data.Read())
                    cnt = Int64.Parse(data["counter"].ToString());
                data.Close();
                sqlcmd.CommandText = "update sw set counter = counter + 1 ";
                sqlcmd.ExecuteNonQuery();


                sqlcmd.CommandText = "Insert into paziresh(doctor,prf,row,date1,date2,dselect,mselect,title,fname,mname,lname,family,visit,consult,service1,service2,income,ret,age,job,bplace,bimeh,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,marray,child,bar,gender,moaref,father,id,bdate,nid,zip,city,sodor,malol,adr,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,tahsil,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('" + mytemp2 + "','" + login.log_prf + "','" + cnt.ToString() + "','" + today + "','" + today + "','','','" + title_t.Text + "','" + fname_t.Text + "','" + mname_t.Text + "','" + lname_t.Text + "','" + (mname_t.Text + " " + lname_t.Text).Trim() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + age_t.Text + "','" + job_t.Text + "','" + bplace_t.Text + "','" + bimeh + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + marray_t.Text + "','" + child_t.Text + "','" + bar + "','" + gender + "','" + moaref_t.Text + "','" + father_t.Text + "','" + id_t.Text + "','" + bplace_t.Text + "','" + nid_t.Text + "','" + zip_t.Text + "','" + city_t.Text + "','" + sodor_t.Text + "','" + malol_t.Text + "','" + adr + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + tahsil_t.Text + "','" + othercode_t.Text + "','" + life_t.Text + "','" + busy_t.Text + "','" + others_t.Text + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();

            cm_menu.Visible = false;
        }

        private void all_info_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;
            menuStrip1.Visible = false;
        }

        private void malol_t_Click(object sender, EventArgs e)
        {
            malol_c.Width = 17;
            malol_c.Visible = true;
        }

        private void age_t_Click(object sender, EventArgs e)
        {
           
        }

        private void age_t_Enter(object sender, EventArgs e)
        {
            malol_c.Visible = false;
        }

        private void malol_c_Click(object sender, EventArgs e)
        {
            if (malol_c.Width != 22 + malol_t.Width)
                malol_c.Width = 22 + malol_t.Width;
        }

        private void malol_c_MouseHover(object sender, EventArgs e)
        {
            malol_c.Width = 22 + malol_t.Width;
            malol_c.SendToBack();
        }

        private void malol_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            malol_t.Text = malol_c.Text;
            malol_c.Width = 17;
            malol_c.Visible = false;
            malol_t.Focus();
        }

        private void bar_t_Click(object sender, EventArgs e)
        {
            bar_c.Width = 17;
            bar_c.Visible = true;
        }

        private void bar_c_Click(object sender, EventArgs e)
        {
            if (bar_c.Width != 22 + bar_t.Width)
                bar_c.Width = 22 + bar_t.Width;
        }

        private void bar_c_MouseHover(object sender, EventArgs e)
        {
            bar_c.Width = 22 + bar_t.Width;
            bar_c.SendToBack();
        }

        private void bar_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar_t.Text = bar_c.Text;
            bar_c.Width = 17;
            bar_c.Visible = false;
            bar_t.Focus();
        }

        private void gender_t_Click(object sender, EventArgs e)
        {
            gender_c.Width = 18;
            gender_c.Visible = true;
        }

        private void gender_c_Click(object sender, EventArgs e)
        {
            if (gender_c.Width != 22 + gender_t.Width)
                gender_c.Width = 22 + gender_t.Width;
        }

        private void gender_c_MouseHover(object sender, EventArgs e)
        {
            gender_c.Width = 22 + gender_t.Width;
            gender_c.SendToBack();
        }

        private void gender_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender_t.Text = gender_c.Text;
            gender_c.Width = 18;
            gender_c.Visible = false;
            gender_t.Focus();
        }
       

    }
}