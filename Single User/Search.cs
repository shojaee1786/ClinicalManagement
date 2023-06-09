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
    public partial class Search : Form
    {
        private static bool search;
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search = true;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            string s = "select par as [شماره پرونده],fname as [نام اول],mname as [نام میانی],lname as [نام آخر],bplace as [محل تولد],moaref as [معرف],father as [نام پدر],id as [شماره شناسنامه],bdate as [تاریخ تولد],nid as [کد ملی],zip as [کد پستی],sodor as [محل صدور شناسنامه],bimehno as [شماره دفترچه بیمه] from sick1";
            bool flag = false;
            if (fname_t.Text != "")
            {
                s += " where fname='" + fname_t.Text + "' ";
                flag = true;
            }
            if (par_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where par='" + par_t.Text + "' ";
                }
                else
                    s += " and par='" + par_t.Text + "' ";
            }
            if (mname_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where mname='" + mname_t.Text + "' ";
                }
                else
                    s += " and mname='" + mname_t.Text + "' ";
                
            }
            if (lname_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where lname='" + lname_t.Text + "' ";
                }
                else
                    s += " and lname='" + lname_t.Text + "' ";

            }
            if (bdate_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where bdate='" + bdate_t.Text + "' ";
                }
                else
                    s += " and bdate='" + bdate_t.Text + "' ";

            }
            if (bplace_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where bplace='" + bplace_t.Text + "' ";
                }
                else
                    s += " and bplace='" + bplace_t.Text + "' ";

            }
            if (father_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where father='" + father_t.Text + "' ";
                }
                else
                    s += " and father='" + father_t.Text + "' ";

            }
            if (id_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where id='" + id_t.Text + "' ";
                }
                else
                    s += " and id='" + id_t.Text + "' ";

            }
            if (sodor_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where sodor='" + sodor_t.Text + "' ";
                }
                else
                    s += " and sodor='" + sodor_t.Text + "' ";

            }
            if (nid_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where nid='" + nid_t.Text + "' ";
                }
                else
                    s += " and nid='" + nid_t.Text + "' ";

            }
            if (zip_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where zip='" + zip_t.Text + "' ";
                }
                else
                    s += " and zip='" + zip_t.Text + "' ";

            }
            if (moaref_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where moaref='" + moaref_t.Text + "' ";
                }
                else
                    s += " and moaref='" + moaref_t.Text + "' ";

            }
            if (bimehno_t.Text != "")
            {
                if (flag == false)
                {
                    flag = true;
                    s += " where bimehno='" + bimehno_t.Text + "' ";
                }
                else
                    s += " and bimehno='" + bimehno_t.Text + "' ";

            }

            if (login.log_username != "admin")
            {
                string mytemp2;
                mytemp2 = "دكتر " + login.log_name + " " + login.log_family;
                if (flag == false)
                {
                    flag = true;
                    s += " where doctor='" + mytemp2 + "' and prf = '" + login.log_prf + "' ";
                }
                else
                    s += " and doctor='" + mytemp2 + "' and prf = '" + login.log_prf + "' ";
            }
             DataView dv;
             DataSet ds = new DataSet();
             SqlDataAdapter sqlada = new SqlDataAdapter();
             sqlcmd.CommandText = s;
             sqlada.SelectCommand = sqlcmd;
             sqlada.Fill(ds);
             dv = new DataView(ds.Tables[0]);

             dataGridView1.DataSource = dv;

            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            SqlDataReader  data = sqlcmd.ExecuteReader();

             while (data.Read())
             {
                 for (int i = 0; i < 14; i++)
                     dataGridView1.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
             }
             data.Close(); 
            
            //DataGridViewAutoSizeColumnMode.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //for(int i=2;i<12;i++)
            //  dataGridView1.Columns[i].Width = 60;

            

            //SqlDataReader data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //{
            //    listBox1.Items.Insert(i, data["نام اول"].ToString()+ " " + data["mname"].ToString() + " فرزند " + data["father"].ToString());
            //    parv[i++] = Int64.Parse(data["par"].ToString());
            //}

            //data.Close();

            sqlconn.Close();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            search = false;
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


            //sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            //data.Close();

           
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

            //sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    bplace_t.AutoCompleteCustomSource.Add(data["bplace"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct father from info where father<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    sodor_t.AutoCompleteCustomSource.Add(data["sodor"].ToString());
            //data.Close();


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


            sqlconn.Close();

            LanguageSelector.KeyboardLayout.Farsi();

            fname_t.Focus();

            timer1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                visit.Visible = reception.Visible = true;
                bool flag = false;
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select rdate from sick2 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "'", sqlconn);

                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    visit.Text = data["rdate"].ToString();
                    flag = true;
                }

                data.Close();

                sqlcmd.CommandText = "select * from sick1 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "' ";

                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    par.Text = data["par"].ToString();
                    reception.Text = data["reception"].ToString();
                    if (flag == false)
                        visit.Text = data["reception"].ToString();

                    fname_t.Text = data["fname"].ToString();
                    mname_t.Text = data["mname"].ToString();
                    lname_t.Text = data["lname"].ToString();
                    bdate_t.Text = data["bdate"].ToString();
                    bplace_t.Text = data["bplace"].ToString();
                    father_t.Text = data["father"].ToString();
                    id_t.Text = data["id"].ToString();
                    sodor_t.Text = data["sodor"].ToString();
                    nid_t.Text = data["nid"].ToString();
                    zip_t.Text = data["zip"].ToString();
                    moaref_t.Text = data["moaref"].ToString();
                    bimehno_t.Text = data["bimehno"].ToString();

                    title_t.Text = data["title"].ToString();
                    bimeh_t.Text = data["bimeh"].ToString();
                    serial_t.Text = data["serial"].ToString();
                    par_t.Text = data["par"].ToString();
                }
                data.Close();

                pictureBox1.Image = Clinical_Management.Properties.Resources.fe_nopic;
                sqlcmd.CommandText = "Select count(*) from picture where par = '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "' ";
                if(sqlcmd.ExecuteScalar().ToString() != "0")
                {
                    sqlcmd.CommandText = "select pic from picture where par = '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "' ";
                    byte[] b = (byte[])sqlcmd.ExecuteScalar();
                    MemoryStream mem = new MemoryStream(b);
                    try
                    {
                        pictureBox1.Image = Image.FromStream(mem);
                    }
                    catch
                    {
                        pictureBox1.Image = Clinical_Management.Properties.Resources.fe_nopic;
                    }
                }

                sqlconn.Close();
                
            }
            else
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    if (Patient.IsOpen == true)
                    {
                        alert2 frm2 = new alert2();
                        frm2.ShowDialog();
                        return;
                    }

                    Patient.first = false;
                    Patient.par = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

                    int i = 0;
                    string s;
                    Patient frm = new Patient();

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

        private void button2_Click(object sender, EventArgs e)
        {
            fname_t.Text = "";
            mname_t.Text = "";
            lname_t.Text = "";
            bdate_t.Text = "";
            bplace_t.Text = "";
            father_t.Text = "";
            id_t.Text = "";
            sodor_t.Text = "";
            nid_t.Text = "";
            zip_t.Text = "";
            moaref_t.Text = "";
            bimehno_t.Text = "";
            par_t.Text = "";
            visit.Text = "";
            reception.Text = "";
        }

        private void Search_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (search == false)
                return;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14,c15) values('" + this.Name + "','" + dataGridView1.Columns[0].Width + "','" + dataGridView1.Columns[1].Width + "','" + dataGridView1.Columns[2].Width + "','" + dataGridView1.Columns[3].Width + "','" + dataGridView1.Columns[4].Width + "','" + dataGridView1.Columns[5].Width + "','" + dataGridView1.Columns[6].Width + "','" + dataGridView1.Columns[7].Width + "','" + dataGridView1.Columns[8].Width + "','" + dataGridView1.Columns[9].Width + "','" + dataGridView1.Columns[10].Width + "','" + dataGridView1.Columns[11].Width + "','" + dataGridView1.Columns[12].Width + "','" + dataGridView1.Columns[13].Width + "','" + dataGridView1.Columns[14].Width + "')";
            sqlcmd.ExecuteNonQuery();


            sqlconn.Close();
        }

        private void وقتدهیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            all_info frm = new all_info();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void پذیرشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void آدرسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
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

        private void algorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algorithm frm = new Algorithm();
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

        private void نوبتدهيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nobat frm = new nobat();
            frm.Show();
        }

        private void انتقالبهپذيرشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (par.Text == "par")
            {
                cm_menu.Visible = false;
                return;
            }
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

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

            string doctor, prf, age, job, bimeh, bimehno, serial, expire, bimeh2, bimehno2, serial2, expire2, bimeh3, bimehno3, serial3, expire3, bimeh4, bimehno4, serial4, expire4, marray, child, bar, gender, moaref, reception, father, id, bdate, nid, zip, city, sodor, malol, adr, adr2, adr3, adr4, adr5;
            string tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10;
            string tahsil, othercode, life, busy, others, edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;
            string bplace, fname, lname, mname, title;

            doctor = prf = age = job = bimeh = bimehno = serial = expire = bimeh2 = bimehno2 = serial2 = expire2 = bimeh3 = bimehno3 = serial3 = expire3 = bimeh4 = bimehno4 = serial4 = expire4 = marray = child = bar = gender = moaref = reception = father = id = bdate = nid = zip = city = sodor = malol = adr = adr2 = adr3 = adr4 = adr5 = "";
            tel1 = desc1 = tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = "";
            tahsil = othercode = life = busy = others = edr1 = email1 = edr2 = email2 = edr3 = email3 = edr4 = email4 = edr5 = email5 = edr6 = email6 = edr7 = email7 = edr8 = email8 = edr9 = email9 = edr10 = email10 = "";
            bplace = fname = lname = mname = title = "";

            sqlcmd.CommandText = "select * from sick1 where par = '" + par.Text + "' ";
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

            sqlcmd.CommandText = "Insert into paziresh(par,reception,doctor,prf,row,date1,date2,dselect,mselect,title,fname,mname,lname,family,visit,consult,service1,service2,income,ret,age,job,bplace,bimeh,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,marray,child,bar,gender,moaref,father,id,bdate,nid,zip,city,sodor,malol,adr,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,tahsil,othercode,life,busy,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('" + par.Text + "','"+ reception +"','" + doctor + "','" + prf + "','" + cnt.ToString() + "','" + today + "','" + today + "','','','" + title + "','" + fname + "','" + mname + "','" + lname + "','" + (mname + " " + lname).Trim() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + age + "','" + job + "','" + bplace + "','" + bimeh + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + marray + "','" + child + "','" + bar + "','" + gender + "','" + moaref + "','" + father + "','" + id + "','" + bdate + "','" + nid + "','" + zip + "','" + city + "','" + sodor + "','" + malol + "','" + adr + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + tahsil + "','" + othercode + "','" + life + "','" + busy + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "')";
            sqlcmd.ExecuteNonQuery();

            //sqlcmd.CommandText = "insert into paziresh(row,title,bimeh,serial,date2,dselect,mselect,date1,fname,family,bimehno,visit,consult,service1,service2,income,ret,par,nid) values('" + cnt.ToString() + "','"+ title_t.Text +"','"+ bimeh_t.Text +"','"+ serial_t.Text +"','" + today + "','','','" + today + "','" + fname_t.Text + "','" + family.Trim() + "','" + bimehno_t.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + par.Text + "','" + nid_t.Text + "')";
            //sqlcmd.ExecuteNonQuery();

            sqlconn.Close();

            cm_menu.Visible = false;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;
            menuStrip1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;
            menuStrip1.Visible = false;
        }

        private void انتقالبهپروندهپزشكيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (par.Text == "par")
            {
                cm_menu.Visible = false;
                return;
            }

            if (Patient.IsOpen == true)
            {
                alert2 frm2 = new alert2();
                frm2.ShowDialog();
                return;
            }


            Patient.first = false;
            Patient.par = Int64.Parse(par.Text);

            Patient frm = new Patient();
            frm.Show();

            cm_menu.Visible = false;
        }

        private void برنامهمنشیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (par.Text == "par")
            {
                cm_menu.Visible = false;
                return;
            }

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("Insert into reminder(title,fname,family) values('" + title_t.Text + "','" + fname_t.Text + "','" + (mname_t.Text + " " + lname_t.Text).Trim() + "') ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

            cm_menu.Visible = false;
        }

        private void رسيدوجهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (par.Text == "par")
            {
                cm_menu.Visible = false;
                return;
            }

            Receipt.receipt_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();

            Receipt frm = new Receipt();
            frm.ShowDialog();

            cm_menu.Visible = false;
        }

        private void گواهيهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (par.Text == "par")
            {
                cm_menu.Visible = false;
                return;
            }

            Rest.Rest_name = (title_t.Text + " " + fname_t.Text + " " + mname_t.Text + " " + lname_t.Text).Trim();

            Rest frm = new Rest();
            frm.ShowDialog();

            cm_menu.Visible = false;
        }

        private void حذفپروندهموقتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invitation frm = new Invitation();
            frm.Show();
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
                fname_temp.AutoCompleteCustomSource.Add(data["fname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct mname from info where mname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                mname_temp.AutoCompleteCustomSource.Add(data["mname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                lname_temp.AutoCompleteCustomSource.Add(data["lname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                bplace_t.AutoCompleteCustomSource.Add(data["bplace"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct father from info where father<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                sodor_t.AutoCompleteCustomSource.Add(data["sodor"].ToString());
            data.Close();

            sqlconn.Close();

            fname_t.AutoCompleteCustomSource = fname_temp.AutoCompleteCustomSource;
            mname_t.AutoCompleteCustomSource = mname_temp.AutoCompleteCustomSource;
            lname_t.AutoCompleteCustomSource = lname_temp.AutoCompleteCustomSource;

            timer1.Enabled = false;
        }

        private void جستجويگواهيهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;

            Search_Print frm = new Search_Print();
            frm.ShowDialog();
        }

      
    }
}