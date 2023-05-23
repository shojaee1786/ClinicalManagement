using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using FarsiLibrary.Utils;

namespace Clinical_Management
{
    public partial class CloseForm : Form
    {
        public static bool mycancel;
        public static string title, fname, mname, lname, age, job, bplace, bimeh, marray, child, bar, gender, moaref, reception, father, id, bdate, nid, zip, city, sodor, malol, adr, tahsil;
        public static string cc, dx, pi, ph, fh, pe, g, p, a, l, d, hc, ht, wg, bp, dd, px, rx, ip, op, pc;
        public static string rdate, rsb, rob, ras, rpl, rdd, rpx, rrx, rip, rop, rco, rpc;
        public static string bimehno, serial, expire, bimeh2, bimehno2, serial2, expire2, bimeh3, bimehno3, serial3, expire3, bimeh4, bimehno4, serial4, expire4, adr2, adr3, adr4, adr5, tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10;
        public static string othercode, life, busy, others, edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;
        public static Int64 par;
        public static int visit;
        public static bool flag;
        public CloseForm()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            if (lname == "")
            {
                alert frm = new alert();
                frm.ShowDialog();
                mycancel = true;
                this.Close();
                return;
            }
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

           
         

            if (Patient.first == true)
            {
                //string b1;
                //b1 = "";
                //int len = bimeh.Length;
                //int i = 0;
                //while (len > 0)
                //{
                //    if (bimeh[i] != '+')
                //        b1 += bimeh[i];
                //    else
                //        break;
                //    i++;

                //    len--;
                //}

                if (Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "select * from paziresh where date1 = '"+ today +"' and row = '"+ Patient.pp_paz_row +"' ";
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
                        bimehno3 = data["bimehno3"].ToString();
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
                    string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;
                    sqlcmd.CommandText = "insert into sick1(doctor,prf,title,fname,mname,lname,age,job,bplace,bimeh,marray,child,bar,gender,moaref,reception,father,id,bdate,nid,zip,city,sodor,malol,adr,tahsil,cc,dx,pi,ph,fh,pe,g,p,a,l,d,hc,ht,wg,bp,dd,px,rx,ip,op,pc,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('"+ mytemp2 +"','"+ login.log_prf +"','" + title.Trim() + "','" + fname.Trim() + "','" + mname.Trim() + "','" + lname.Trim() + "','" + age.Trim() + "','" + job.Trim() + "','" + bplace.Trim() + "','" + bimeh.Trim() + "','" + marray.Trim() + "','" + child.Trim() + "','" + bar.Trim() + "','" + gender.Trim() + "','" + moaref.Trim() + "','" + reception.Trim() + "','" + father.Trim() + "','" + id.Trim() + "','" + bdate.Trim() + "','" + nid.Trim() + "','" + zip.Trim() + "','" + city.Trim() + "','" + sodor.Trim() + "','" + malol.Trim() + "','" + adr.Trim() + "','" + tahsil.Trim() + "','" + cc.Trim() + "','" + dx.Trim() + "','" + pi.Trim() + "','" + ph.Trim() + "','" + fh.Trim() + "','" + pe.Trim() + "','" + g.Trim() + "','" + p.Trim() + "','" + a.Trim() + "','" + l.Trim() + "','" + d.Trim() + "','" + hc.Trim() + "','" + ht.Trim() + "','" + wg.Trim() + "','" + bp.Trim() + "','" + dd.Trim() + "','" + px.Trim() + "','" + rx.Trim() + "','" + ip.Trim() + "','" + op.Trim() + "','" + pc.Trim() + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + othercode + "','" + life + "','" + busy + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
                    sqlcmd.ExecuteNonQuery();


                }
                else
                {
                    string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;
                    sqlcmd.CommandText = "insert into sick1(doctor,prf,title,fname,mname,lname,age,job,bplace,bimeh,marray,child,bar,gender,moaref,reception,father,id,bdate,nid,zip,city,sodor,malol,adr,tahsil,cc,dx,pi,ph,fh,pe,g,p,a,l,d,hc,ht,wg,bp,dd,px,rx,ip,op,pc,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('" + mytemp2 + "','" + login.log_prf + "','" + title.Trim() + "','" + fname.Trim() + "','" + mname.Trim() + "','" + lname.Trim() + "','" + age.Trim() + "','" + job.Trim() + "','" + bplace.Trim() + "','" + bimeh.Trim() + "','" + marray.Trim() + "','" + child.Trim() + "','" + bar.Trim() + "','" + gender.Trim() + "','" + moaref.Trim() + "','" + reception.Trim() + "','" + father.Trim() + "','" + id.Trim() + "','" + bdate.Trim() + "','" + nid.Trim() + "','" + zip.Trim() + "','" + city.Trim() + "','" + sodor.Trim() + "','" + malol.Trim() + "','" + adr.Trim() + "','" + tahsil.Trim() + "','" + cc.Trim() + "','" + dx.Trim() + "','" + pi.Trim() + "','" + ph.Trim() + "','" + fh.Trim() + "','" + pe.Trim() + "','" + g.Trim() + "','" + p.Trim() + "','" + a.Trim() + "','" + l.Trim() + "','" + d.Trim() + "','" + hc.Trim() + "','" + ht.Trim() + "','" + wg.Trim() + "','" + bp.Trim() + "','" + dd.Trim() + "','" + px.Trim() + "','" + rx.Trim() + "','" + ip.Trim() + "','" + op.Trim() + "','" + pc.Trim() + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + othercode + "','" + life + "','" + busy + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlcmd.CommandText = "select max(par) from sick1 ";
                Int64 mymax = Int64.Parse(sqlcmd.ExecuteScalar().ToString());

                sqlcmd.CommandText = "Update ppc set par = '" + mymax + "' where par = 0 ";
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = "Update picture set par = '" + mymax + "' where par = 0 ";
                sqlcmd.ExecuteNonQuery();

                if (Directory.Exists(Application.StartupPath + "\\Patient Files\\0") == true)
                {
                    try
                    {
                        Directory.Move(Application.StartupPath + "\\Patient Files\\0", Application.StartupPath + "\\Patient Files\\" + mymax.ToString());
                    }
                    catch 
                    {
                        // MessageBox.Show("انتقال تصاویر انجام نگردید، لطفاً تصاویر را به صورت دستی از پوشه شماره صفر به پوشه پرونده مورد نظر انتقال دهید");
                        alert3 frm = new alert3();
                        frm.ShowDialog();
                    }
                }

                sqlcmd.CommandText = "select count(*) from filter_t where par = '"+mymax+"' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into filter_t(par,filter) values('" + mymax + "','" + Patient.filter + "') ";
                    sqlcmd.ExecuteNonQuery();
                }
               // Paziresh_to_pp = True and first = true
                if (Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "Update paziresh set par = '"+ mymax +"',family = '" + (mname + " " + lname).Trim() + "',title='" + title + "',fname='" + fname + "',mname='" + mname + "',lname='" + lname + "',age='" + age + "',job='" + job + "',bplace='" + bplace + "',bimeh='" + bimeh + "',bimehno='" + bimehno + "',serial='" + serial + "',expire='" + expire + "',bimeh2='" + bimeh2 + "',bimehno2='" + bimehno2 + "',serial2='" + serial2 + "',expire2='" + expire2 + "',bimeh3='" + bimeh3 + "',bimehno3='" + bimehno3 + "',serial3='" + serial3 + "',expire3='" + expire3 + "',bimeh4='" + bimeh4 + "',bimehno4='" + bimehno4 + "',serial4='" + serial4 + "',expire4='" + expire4 + "',marray = '" + marray + "',child = '" + child + "',bar = '" + bar + "',gender = '" + gender + "',moaref = '" + moaref + "',father = '" + father + "',id = '" + id + "',bdate = '" + bdate + "',nid = '" + nid + "',zip = '" + zip + "',city = '" + city + "',sodor = '" + sodor + "',malol = '" + malol + "',adr = '" + adr + "',adr2 = '" + adr2 + "',adr3 = '" + adr3 + "',adr4 = '" + adr4 + "',adr5 = '" + adr5 + "',tel1 = '" + tel1 + "',desc1 = '" + desc1 + "',tel2 = '" + tel2 + "',desc2 = '" + desc2 + "',tel3 = '" + tel3 + "',desc3 = '" + desc3 + "',tel4 = '" + tel4 + "',desc4 = '" + desc4 + "',tel5 = '" + tel5 + "',desc5 = '" + desc5 + "',tel6 = '" + tel6 + "',desc6 = '" + desc6 + "',tel7 = '" + tel7 + "',desc7 = '" + desc7 + "',tel8 = '" + tel8 + "',desc8 = '" + desc8 + "',tel9 = '" + tel9 + "',desc9 = '" + desc9 + "',tel10 = '" + tel10 + "',desc10 = '" + desc10 + "',tahsil = '" + tahsil + "',othercode = '" + othercode + "',life = '" + life + "',busy = '" + busy + "',others = '" + others + "',edr1 = '" + edr1 + "',email1 = '" + email1 + "',edr2 = '" + edr2 + "',email2 = '" + email2 + "',edr3 = '" + edr3 + "',email3 = '" + email3 + "',edr4 = '" + edr4 + "',email4 = '" + email4 + "',edr5 = '" + edr5 + "',email5 = '" + email5 + "',edr6 = '" + edr6 + "',email6 = '" + email6 + "',edr7 = '" + edr7 + "',email7 = '" + email7 + "',edr8 = '" + edr8 + "',email8 = '" + email8 + "',edr9 = '" + edr9 + "',email9 = '" + email9 + "',edr10 = '" + edr10 + "',email10 = '" + email10 + "' where row = '" + Patient.pp_paz_row + "' and date1 = '" + today + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

            }
            else
            {
                if (Paziresh.paziresh_to_pp == true)
                {
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
                        bimehno3 = data["bimehno3"].ToString();
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

                }
               
                sqlcmd.CommandText = "Delete from filter_t where par ='" + par + "' ";
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = "Insert into filter_t(par,filter) values('" + par + "','"+ Patient.filter +"') ";
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = "Update sick1 set title='" + title + "',fname='" + fname + "',mname='" + mname + "',lname='" + lname + "',age='" + age + "',job='" + job + "',bplace='" + bplace + "',bimeh='" + bimeh + "',marray='" + marray + "',child='" + child + "',bar='" + bar + "',gender='" + gender + "',moaref='" + moaref + "',reception='" + reception + "',father='" + father + "',id='" + id + "',bdate='" + bdate + "',nid='" + nid + "',zip='" + zip + "',city='" + city + "',sodor='" + sodor + "',malol='" + malol + "',adr='" + adr + "',tahsil='" + tahsil + "',cc='" + cc + "',dx='" + dx + "',pi='" + pi + "',ph='" + ph + "',fh='" + fh + "',pe='" + pe + "',ht='" + ht + "',wg='" + wg + "',bp='" + bp + "',dd='" + dd + "',px='" + px + "',rx='" + rx + "',ip='" + ip + "',op='" + op + "',pc='" + pc + "',bimehno = '" + bimehno + "',serial = '" + serial + "',expire = '" + expire + "',bimeh2 = '" + bimeh2 + "',bimehno2 = '" + bimehno2 + "',serial2 = '" + serial2 + "',expire2 = '" + expire2 + "',bimeh3 = '" + bimeh3 + "',bimehno3 = '" + bimehno3 + "',serial3 = '" + serial3 + "',expire3 = '" + expire3 + "',bimeh4 = '" + bimeh4 + "',bimehno4 = '" + bimehno4 + "',serial4 = '" + serial4 + "',expire4 = '" + expire4 + "',adr2 = '" + adr2 + "',adr3 = '" + adr3 + "',adr4 = '" + adr4 + "',adr5 = '" + adr5 + "',tel1 = '" + tel1 + "',desc1 = '" + desc1 + "',tel2 = '" + tel2 + "',desc2 = '" + desc2 + "',tel3 = '" + tel3 + "',desc3 = '" + desc3 + "',tel4 = '" + tel4 + "',desc4 = '" + desc4 + "',tel5 = '" + tel5 + "',desc5 = '" + desc5 + "',tel6 = '" + tel6 + "',desc6 = '" + desc6 + "',tel7 = '" + tel7 + "',desc7 = '" + desc7 + "',tel8 = '" + tel8 + "',desc8 = '" + desc8 + "',tel9 = '" + tel9 + "',desc9 = '" + desc9 + "',tel10 = '" + tel10 + "',desc10 = '" + desc10 + "',othercode = '" + othercode + "',life = '" + life + "',busy = '" + busy + "',others = '" + others + "',edr1 = '" + edr1 + "',email1 = '" + email1 + "',edr2 = '" + edr2 + "',email2 = '" + email2 + "',edr3 = '" + edr3 + "',email3 = '" + email3 + "',edr4 = '" + edr4 + "',email4 = '" + email4 + "',edr5 = '" + edr5 + "',email5 = '" + email5 + "',edr6 = '" + edr6 + "',email6 = '" + email6 + "',edr7 = '" + edr7 + "',email7 = '" + email7 + "',edr8 = '" + edr8 + "',email8 = '" + email8 + "',edr9 = '" + edr9 + "',email9 = '" + email9 + "',edr10 = '" + edr10 + "',email10 = '" + email10 + "' where par = '" + par + "'";
                sqlcmd.ExecuteNonQuery();

                // Paziresh_to_pp = True and  first = false
                if (Paziresh.paziresh_to_pp == true)
                {
                    sqlcmd.CommandText = "Update paziresh set family = '" + (mname + " " + lname).Trim() + "',title='" + title + "',fname='" + fname + "',mname='" + mname + "',lname='" + lname + "',age='" + age + "',job='" + job + "',bplace='" + bplace + "',bimeh='" + bimeh + "',bimehno='" + bimehno + "',serial='" + serial + "',expire='" + expire + "',bimeh2='" + bimeh2 + "',bimehno2='" + bimehno2 + "',serial2='" + serial2 + "',expire2='" + expire2 + "',bimeh3='" + bimeh3 + "',bimehno3='" + bimehno3 + "',serial3='" + serial3 + "',expire3='" + expire3 + "',bimeh4='" + bimeh4 + "',bimehno4='" + bimehno4 + "',serial4='" + serial4 + "',expire4='" + expire4 + "',marray = '" + marray + "',child = '" + child + "',bar = '" + bar + "',gender = '" + gender + "',moaref = '" + moaref + "',father = '" + father + "',id = '" + id + "',bdate = '" + bdate + "',nid = '" + nid + "',zip = '" + zip + "',city = '" + city + "',sodor = '" + sodor + "',malol = '" + malol + "',adr = '" + adr + "',adr2 = '" + adr2 + "',adr3 = '" + adr3 + "',adr4 = '" + adr4 + "',adr5 = '" + adr5 + "',tel1 = '" + tel1 + "',desc1 = '" + desc1 + "',tel2 = '" + tel2 + "',desc2 = '" + desc2 + "',tel3 = '" + tel3 + "',desc3 = '" + desc3 + "',tel4 = '" + tel4 + "',desc4 = '" + desc4 + "',tel5 = '" + tel5 + "',desc5 = '" + desc5 + "',tel6 = '" + tel6 + "',desc6 = '" + desc6 + "',tel7 = '" + tel7 + "',desc7 = '" + desc7 + "',tel8 = '" + tel8 + "',desc8 = '" + desc8 + "',tel9 = '" + tel9 + "',desc9 = '" + desc9 + "',tel10 = '" + tel10 + "',desc10 = '" + desc10 + "',tahsil = '" + tahsil + "',othercode = '" + othercode + "',life = '" + life + "',busy = '" + busy + "',others = '" + others + "',edr1 = '" + edr1 + "',email1 = '" + email1 + "',edr2 = '" + edr2 + "',email2 = '" + email2 + "',edr3 = '" + edr3 + "',email3 = '" + email3 + "',edr4 = '" + edr4 + "',email4 = '" + email4 + "',edr5 = '" + edr5 + "',email5 = '" + email5 + "',edr6 = '" + edr6 + "',email6 = '" + email6 + "',edr7 = '" + edr7 + "',email7 = '" + email7 + "',edr8 = '" + edr8 + "',email8 = '" + email8 + "',edr9 = '" + edr9 + "',email9 = '" + email9 + "',edr10 = '" + edr10 + "',email10 = '" + email10 + "' where row = '" + Patient.pp_paz_row + "' and date1 = '" + today + "' ";
                    sqlcmd.ExecuteNonQuery();
                }
                ////////////////
                if (flag == true)
                {
                    flag = false;
                    if (visit == Patient.maxpage)
                    {
                        sqlcmd.CommandText = "select count(*) from var1 where par = '" + par + "' ";
                        if (sqlcmd.ExecuteScalar().ToString() == "0")
                        {
                            sqlcmd.CommandText = "insert into var1(par,lastvisit) values('" + par + "','" + 2 + "')";
                            sqlcmd.ExecuteNonQuery();
                        }
                        else
                        {
                            sqlcmd.CommandText = "Update var1 set lastvisit=lastvisit+1 where par='" + par + "'";
                            sqlcmd.ExecuteNonQuery();
                        }
                    }
                    ////////////////
                    sqlcmd.CommandText = "select count(*) from sick2 where par='" + par + "' and visit='" + visit + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "insert into sick2(par,visit,rdate,sb,ob,ass,pl,dd,px,rx,ip,op,co,pc) values('" + par + "','" + visit + "','" + rdate + "','" + rsb + "','" + rob + "','" + ras + "','" + rpl + "','" + rdd + "','" + rpx + "','" + rrx + "','" + rip + "','" + rop + "','" + rco + "','" + rpc + "')";
                        sqlcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sqlcmd.CommandText = "Update sick2 set visit='" + visit + "',rdate='" + rdate + "',sb='" + rsb + "',ob='" + rob + "',ass='" + ras + "',pl='" + rpl + "',dd='" + rdd + "',px='" + rpx + "',rx='" + rrx + "',ip='" + rip + "',op='" + rop + "',co='" + rco + "',pc='" + rpc + "' where par='" + par + "' and visit='" + visit + "' ";
                        sqlcmd.ExecuteNonQuery();
                    }
                    ////////////////
                }

                sqlcmd.CommandText = "Update ppc set par = '" + par + "' where par = 0 ";
                sqlcmd.ExecuteNonQuery();

            }

        

            sqlconn.Close();

            Paziresh.paziresh_to_pp = false;
            Patient.first = true;
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            Paziresh.paziresh_to_pp = false;
            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\0") == true)
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "\\Patient Files\\0", true);
                }
                catch { }
            }
            Patient.first = true;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            
            sqlcmd.CommandText = "Delete from ppc where par = 0  ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();

            this.Close();
        }

        private void CloseForm_Load(object sender, EventArgs e)
        {
            mycancel = false;
        }

        private void Cancel_b_Click(object sender, EventArgs e)
        {
            mycancel = true;
            this.Close();
        }
    }
}