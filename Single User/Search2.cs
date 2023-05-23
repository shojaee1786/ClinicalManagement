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
    public partial class Search2 : Form
    {
        public static string search2_fname, search2_family;
        public Search2()
        {

            InitializeComponent();
        }

        private void Search2_Load(object sender, EventArgs e)
        {
            object[] ob = new object[6];
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            
            //string mytemp2;
            //mytemp2 = "ÏßÊÑ " + login.log_name + " " + login.log_family;

            sqlcmd.CommandText = "select * from sick1 where fname = '" + search2_fname + "' and lname = '" + search2_family + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                ob[0] = "ÇäÊÎÇÈ";
                ob[1] = data["fname"].ToString();
                ob[2] = data["mname"].ToString();
                ob[3] = data["lname"].ToString();
                ob[4] = data["father"].ToString();
                ob[5] = data["par"].ToString();
                
                dataGridView1.Rows.Insert(dataGridView1.Rows.Count, ob);
            }
            data.Close();

            sqlcmd.CommandText = "select * from sick1 where fname = '" + search2_fname + "' and mname = '" + search2_family + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                ob[0] = "ÇäÊÎÇÈ";
                ob[1] = data["fname"].ToString();
                ob[2] = data["mname"].ToString();
                ob[3] = data["lname"].ToString();
                ob[4] = data["father"].ToString();
                ob[5] = data["par"].ToString();

                dataGridView1.Rows.Insert(dataGridView1.Rows.Count , ob);
            }
            data.Close();

            sqlconn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nobat.conflict = true;
            paziresh2.paziresh2_conflict = true;
            all_info.pj_conflict = true;

            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                par.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "select counter from sw";
            SqlDataReader data = sqlcmd.ExecuteReader();
            Int64 cnt = 1;
            while (data.Read())
                cnt = Int64.Parse(data["counter"].ToString());
            data.Close();

            sqlcmd.CommandText = "update sw set counter = counter + 1 ";
            sqlcmd.ExecuteNonQuery();


            string title, fname, mname, lname, bplace, doctor, prf, age, job, bimeh, bimehno, serial, expire, bimeh2, bimehno2, serial2, expire2, bimeh3, bimehno3, serial3, expire3, bimeh4, bimehno4, serial4, expire4, marray, child, bar, gender, moaref, reception, father, id, bdate, nid, zip, city, sodor, malol, adr, adr2, adr3, adr4, adr5;
            string tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10;
            string tahsil, othercode, life, busy, others, edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;

            doctor = prf = age = job = bimeh = bimehno = serial = expire = bimeh2 = bimehno2 = serial2 = expire2 = bimeh3 = bimehno3 = serial3 = expire3 = bimeh4 = bimehno4 = serial4 = expire4 = marray = child = bar = gender = moaref = reception = father = id = bdate = nid = zip = city = sodor = malol = adr = adr2 = adr3 = adr4 = adr5 = "";
            tel1 = desc1 = tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = "";
            tahsil = othercode = life = busy = others = edr1 = email1 = edr2 = email2 = edr3 = email3 = edr4 = email4 = edr5 = email5 = edr6 = email6 = edr7 = email7 = edr8 = email8 = edr9 = email9 = edr10 = email10 = "";
            title = fname = mname = lname = bplace = "";


            string mytemp2;
            mytemp2 = "ÏßÊÑ " + login.log_name + " " + login.log_family;

            sqlcmd.CommandText = "select * from sick1 where par = '" + Int64.Parse(par.Text) + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                title = data["title"].ToString();
                fname = data["fname"].ToString();
                mname = data["mname"].ToString();
                lname = data["lname"].ToString();
                bplace = data["bplace"].ToString();

                doctor = data["doctor"].ToString();
                prf = data["prf"].ToString();
                age = data["age"].ToString();
                job = data["job"].ToString();

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

                marray = data["marray"].ToString();
                child = data["child"].ToString();
                bar = data["bar"].ToString();
                gender = data["gender"].ToString();
                moaref = data["moaref"].ToString();
                reception = data["reception"].ToString();
                father = data["father"].ToString();
                id = data["id"].ToString();
                bdate = data["bdate"].ToString();
                nid = data["nid"].ToString();
                zip = data["zip"].ToString();
                city = data["city"].ToString();
                sodor = data["sodor"].ToString();
                malol = data["malol"].ToString();
                adr = data["adr"].ToString();
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

                tahsil = data["tahsil"].ToString();
                othercode = data["othercode"].ToString();
                life = data["life"].ToString();
                busy = data["busy"].ToString();
                others = data["others"].ToString();

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

            string family = mname + " " + lname;
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            //sqlcmd.CommandText = "insert into paziresh(row,title,bimeh,serial,date2,dselect,mselect,date1,fname,family,bimehno,visit,consult,service1,service2,income,ret,par,nid) values('" + cnt.ToString() + "','" + title + "','" + bimeh + "','" + serial + "','" + today + "','','','" + today + "','" + fname + "','" + family.Trim() + "','" + bimehno + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + par.Text + "','" + nid + "')";
            //sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Insert into paziresh(par,reception,doctor,prf,row,date1,date2,dselect,mselect,title,fname,mname,lname,family,visit,consult,service1,service2,income,ret,age,job,bplace,bimeh,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,marray,child,bar,gender,moaref,father,id,bdate,nid,zip,city,sodor,malol,adr,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,tahsil,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('" + par.Text + "','" + reception + "','" + doctor + "','" + prf + "','" + cnt.ToString() + "','" + today + "','" + today + "','','','" + title + "','" + fname + "','" + mname + "','" + lname + "','" + family.Trim() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + age + "','" + job + "','" + bplace + "','" + bimeh + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + marray + "','" + child + "','" + bar + "','" + gender + "','" + moaref + "','" + father + "','" + id + "','" + bdate + "','" + nid + "','" + zip + "','" + city + "','" + sodor + "','" + malol + "','" + adr + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + tahsil + "','" + othercode + "','" + life + "','" + busy + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
            sqlcmd.ExecuteNonQuery();

            this.Close();

            //sqlcmd.CommandText = "Insert into paziresh(lname,row,title,fname,family,cause,doctor,prf,bimeh,bimehno,expire,serial,nid,visit,consult,service1,service2,income,ret,date1,date2,dselect,mselect) values('" + family_t.Text + "','" + cnt.ToString() + "','" + title_t.Text + "','" + fname_t.Text + "','" + family_t.Text + "','" + cause_t.Text + "','" + doctor_t.Text + "','" + prf_t.Text + "','" + bimeh_t.Text + "','" + bimehno_t.Text + "','" + expire_t.Text + "','" + serial_t.Text + "','" + nid_t.Text + "','" + visit_t.Text + "','" + consult_t.Text + "','" + service1_t.Text + "','" + service2_t.Text + "','" + income_t.Text + "','" + ret_t.Text + "','" + today + "','" + today + "','','')";
            //sqlcmd.ExecuteNonQuery();

        }
    }
}