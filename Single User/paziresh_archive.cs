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
    public partial class paziresh_archive : Form
    {
        public static bool archive_to_pj;
        public paziresh_archive()
        {
            InitializeComponent();
        }

        private void paziresh_archive_Load(object sender, EventArgs e)
        {
            faMonthView1.SelectedDateTime = FarsiLibrary.Utils.PersianDate.Now;
            archive_to_pj = false;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from temp where form='" + this.Name + "'", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();
            sqlconn.Close();
        }

        private void paziresh_archive_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void faMonthView1_SelectedDateTimeChanged(object sender, EventArgs e)
        {

            dataGridView2.Rows.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            string mymonth = "", myday = "";

            if (faMonthView1.Month.ToString().Length == 1)
                mymonth = "0" + faMonthView1.Month.ToString();
            else
                mymonth = faMonthView1.Month.ToString();

            if (faMonthView1.Day.ToString().Length == 1)
                myday = "0" + faMonthView1.Day.ToString();
            else
                myday = faMonthView1.Day.ToString();


            string date1 = faMonthView1.Year.ToString() + "/" + mymonth + "/" + myday;

            object[] ob = new object[20];
            sqlcmd.CommandText = "select * from paziresh where date1 = '" + date1 + "' order by row ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                ob[0] = "«‰ ﬁ«· »Â Å–Ì—‘";
                ob[1] = data["row"].ToString();
                ob[2] = data["title"].ToString();
                ob[3] = data["fname"].ToString();
                ob[4] = data["family"].ToString();
                ob[5] = data["cause"].ToString();
                ob[6] = data["doctor"].ToString();
                ob[7] = data["prf"].ToString();
                ob[8] = data["bimeh"].ToString();
                ob[9] = data["bimehno"].ToString();
                ob[10] = data["expire"].ToString();
                ob[11] = data["serial"].ToString();
                ob[12] = data["nid"].ToString();
                ob[13] = data["visit"].ToString();
                ob[14] = data["consult"].ToString();
                ob[15] = data["service1"].ToString();
                ob[16] = data["service2"].ToString();
                ob[17] = data["income"].ToString();
                ob[18] = data["ret"].ToString();
                ob[19] = data["par"].ToString();
                
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count, ob);
            }
            data.Close();

            sqlconn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            string mymonth = "", myday = "";

            if (faMonthView1.Month.ToString().Length == 1)
                mymonth = "0" + faMonthView1.Month.ToString();
            else
                mymonth = faMonthView1.Month.ToString();

            if (faMonthView1.Day.ToString().Length == 1)
                myday = "0" + faMonthView1.Day.ToString();
            else
                myday = faMonthView1.Day.ToString();


            string date1 = faMonthView1.Year.ToString() + "/" + mymonth + "/" + myday;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            if (today != date1)
            {
                sqlcmd.CommandText = "delete from paziresh where date1 = '"+ date1 +"' ";
                sqlcmd.ExecuteNonQuery();
                dataGridView2.Rows.Clear();
            }

            sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            sqlcmd.CommandText = "delete from paziresh where date1 <> '" + today + "' ";
            sqlcmd.ExecuteNonQuery();
            dataGridView2.Rows.Clear();

            sqlconn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            string mymonth = "", myday = "";

            if (faMonthView1.Month.ToString().Length == 1)
                mymonth = "0" + faMonthView1.Month.ToString();
            else
                mymonth = faMonthView1.Month.ToString();

            if (faMonthView1.Day.ToString().Length == 1)
                myday = "0" + faMonthView1.Day.ToString();
            else
                myday = faMonthView1.Day.ToString();


            string date1 = faMonthView1.Year.ToString() + "/" + mymonth + "/" + myday;

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count && e.ColumnIndex == 0)
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


                
                string title, fname, family, cause, doctor, prf, bimeh, bimehno, expire, serial, nid;
                string service1, service2, income, ret, par, mname, lname, age, job, bplace, bimeh2, bimehno2, serial2, expire2;
                string bimeh3, bimehno3, serial3, expire3, bimeh4, bimehno4, serial4, expire4;
                string marray, child, bar, gender, moaref, father, id, bdate, zip;
                string city, sodor, malol, adr, adr2, adr3, adr4, adr5;
                string tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10, tahsil, othercode;
                string edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;
                string life, busy, others;

                title= fname= family= cause= doctor= prf= bimeh= bimehno= expire= serial= nid="";
                service1 = service2 = income = ret = par = mname = lname = age = job = bplace = bimeh2 = bimehno2 = serial2 = expire2 = "";
                bimeh3 = bimehno3 = serial3 = expire3 = bimeh4 = bimehno4 = serial4 = expire4 = marray = child = bar = gender = moaref = father = id = bdate = zip = city = sodor = malol = adr = adr2 = adr3 = adr4 = adr5 = tel1 = desc1 = tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = tahsil = othercode = edr1 = email1 = edr2 = email2 = edr3 = email3 = edr4 = email4 = edr5 = email5 = edr6 = email6 = edr7 = email7 = edr8 = email8 = edr9 = email9 = edr10 = email10 = life = busy = others = "";

                sqlcmd.CommandText = "select * from paziresh where date1 = '" + date1 + "' and row ='"+ dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() +"' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                     title = data["title"].ToString();
                     fname = data["fname"].ToString();
                     family = data["family"].ToString();
                     cause = data["cause"].ToString();
                     doctor = data["doctor"].ToString();
                     prf = data["prf"].ToString();
                     bimeh = data["bimeh"].ToString();
                     bimehno = data["bimehno"].ToString();
                     expire = data["expire"].ToString();
                     serial = data["serial"].ToString();
                     //visit = "0";
                     //consult = "0";
                     //service1 = "0";
                     //service2 = "0";
                     //income = "0";
                     //ret = "0";
                     par = data["par"].ToString();
                     mname = data["mname"].ToString();
                     lname = data["lname"].ToString();
                     age = data["age"].ToString();
                     job = data["job"].ToString();
                     bplace = data["bplace"].ToString();
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
                     desc1 = data["desc1"].ToString();

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

                sqlcmd.CommandText = "Insert into paziresh(par,row,date1,date2,dselect,mselect,title,fname,mname,lname,family,visit,consult,service1,service2,income,ret,age,job,bplace,bimeh,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,marray,child,bar,gender,moaref,father,id,bdate,nid,zip,city,sodor,malol,adr,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,tahsil,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('"+ par +"','" + cnt.ToString() + "','" + today + "','" + today + "','','','" + title + "','" + fname + "','" + mname + "','" + lname + "','" + (mname + " " + lname).Trim() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + age + "','" + job + "','" + bplace + "','" + bimeh + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + marray + "','" + child + "','" + bar + "','" + gender + "','" + moaref + "','" + father + "','" + id + "','" + bplace + "','" + nid + "','" + zip + "','" + city + "','" + sodor + "','" + malol + "','" + adr + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + tahsil + "','" + othercode + "','" + life + "','" + busy + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
                sqlcmd.ExecuteNonQuery();

                sqlconn.Close();
            }
        }
    }
}