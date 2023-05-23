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
    public partial class Tel2 : Form
    {
        public static bool insert_mode = false;
        public static string tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, ttel10, desc10, adr2, adr3, adr4, tadr5, email2, edr2, email3, edr3, email4, edr4, email5, edr5, email6, edr6, email7, edr7, email8, edr8, email9, edr9, email10, edr10;
        public Tel2()
        {
            InitializeComponent();
        }

        private void Tel2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Tel2_Load(object sender, EventArgs e)
        {
            if (Tel.tel_flag_search == true)
                button1.Visible = false;


            tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = ttel10 = desc10 = adr2 = adr3 = adr4 = tadr5 = email2 = edr2 = email3 = edr3 = email4 = edr4 = email5 = edr5 = email6 = edr6 = email7 = edr7 = email8 = edr8 = email9 = edr9 = email10 = edr10 = "";
            LanguageSelector.KeyboardLayout.Farsi();
            place_t.Focus();
            if (insert_mode == true)
                button1.Text = "œ—Ã œ— œ› —çÂ  ·›‰";
            else
            {
                button1.Text = " €ÌÌ—«  À»  ‘Êœ";
                place_t.Text = Tel.tel_row[0].ToString();
                title_t.Text = Tel.tel_row[1].ToString();
                fname_t.Text = Tel.tel_row[2].ToString();
                family_t.Text = Tel.tel_row[3].ToString();
                profession_t.Text = Tel.tel_row[4].ToString();
                job_t.Text = Tel.tel_row[5].ToString();
                tel_t.Text = Tel.tel_row[6].ToString();
                desc_t.Text = Tel.tel_row[7].ToString();
                city_t.Text = Tel.tel_row[8].ToString();
                adr_t.Text = Tel.tel_row[9].ToString();
                zip_t.Text = Tel.tel_row[10].ToString();
                email_c.Text = Tel.tel_row[11].ToString();
                edr_t.Text = Tel.tel_row[12].ToString();
                
                email2 = Tel.tel_row[13].ToString();
                email3 = Tel.tel_row[14].ToString();
                email4 = Tel.tel_row[15].ToString();
                email5 = Tel.tel_row[16].ToString();
                email6 = Tel.tel_row[17].ToString();
                email7 = Tel.tel_row[18].ToString();
                email8 = Tel.tel_row[19].ToString();
                email9 = Tel.tel_row[20].ToString();
                email10 = Tel.tel_row[21].ToString();

                edr2 = Tel.tel_row[22].ToString();
                edr3 = Tel.tel_row[23].ToString();
                edr4 = Tel.tel_row[24].ToString();
                edr5 = Tel.tel_row[25].ToString();
                edr6 = Tel.tel_row[26].ToString();
                edr7 = Tel.tel_row[27].ToString();
                edr8 = Tel.tel_row[28].ToString();
                edr9 = Tel.tel_row[29].ToString();
                edr10 = Tel.tel_row[30].ToString();

                adr2 = Tel.tel_row[31].ToString();
                adr3 = Tel.tel_row[32].ToString();
                adr4 = Tel.tel_row[33].ToString();
                tadr5 = Tel.tel_row[34].ToString();

                tel2 = Tel.tel_row[35].ToString();
                tel3 = Tel.tel_row[36].ToString();
                tel4 = Tel.tel_row[37].ToString();
                tel5 = Tel.tel_row[38].ToString();
                tel6 = Tel.tel_row[39].ToString();
                tel7 = Tel.tel_row[40].ToString();
                tel8 = Tel.tel_row[41].ToString();
                tel9 = Tel.tel_row[42].ToString();
                ttel10 = Tel.tel_row[43].ToString();

                desc2 = Tel.tel_row[44].ToString();
                desc3 = Tel.tel_row[45].ToString();
                desc4 = Tel.tel_row[46].ToString();
                desc5 = Tel.tel_row[47].ToString();
                desc6 = Tel.tel_row[48].ToString();
                desc7 = Tel.tel_row[49].ToString();
                desc8 = Tel.tel_row[50].ToString();
                desc9 = Tel.tel_row[51].ToString();
                desc10 = Tel.tel_row[52].ToString();
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
            sqlcmd.CommandText = "select distinct place from tel_tmp where place<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["place"].ToString();
                place_t.AutoCompleteCustomSource.Add(s);
                place_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct profession from tel_tmp where profession<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["profession"].ToString();
                profession_t.AutoCompleteCustomSource.Add(s);
                prf_c.Items.Insert(i, s);
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
            sqlcmd.CommandText = "select distinct desc1 from tel_tmp where desc1<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["desc1"].ToString();
                desc_t.AutoCompleteCustomSource.Add(s);
                desc_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct tel from tel_tmp where tel<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                tel_t.AutoCompleteCustomSource.Add(data["tel"].ToString());
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

            sqlcmd.CommandText = "select distinct adr from info where adr<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                adr_t.AutoCompleteCustomSource.Add(data["adr"].ToString());
            data.Close();

            //sqlcmd.CommandText = "select distinct zip from info where zip<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    zip_t.AutoCompleteCustomSource.Add(data["zip"].ToString());
            //data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct email from tel_tmp where email<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["email"].ToString();
                email_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct edr from tel_tmp where edr<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                edr_t.AutoCompleteCustomSource.Add(data["edr"].ToString());
            data.Close();

            sqlconn.Close();

            timer1.Enabled = true;
        }

        private void Tel2_FormClosing(object sender, FormClosingEventArgs e)
        {
            insert_mode = false;
            //button1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tel10 frm = new tel10();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            email frm = new email();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adr5 frm = new adr5();
            frm.ShowDialog();
        }

        private void edr_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "œ—Ã œ— œ› —çÂ  ·›‰")
            {
                Tel.tel_flag = true;

                Tel.tel_row[1] = place_t.Text;
                Tel.tel_row[2] = title_t.Text;
                Tel.tel_row[3] = fname_t.Text;
                Tel.tel_row[4] = family_t.Text;
                Tel.tel_row[5] = profession_t.Text;
                Tel.tel_row[6] = job_t.Text;
                Tel.tel_row[7] = tel_t.Text;
                Tel.tel_row[8] = desc_t.Text;
                Tel.tel_row[9] = city_t.Text;
                Tel.tel_row[10] = adr_t.Text;
                Tel.tel_row[11] = zip_t.Text;
                Tel.tel_row[12] = email_c.Text;
                Tel.tel_row[13] = edr_t.Text;

                Tel.tel_row[14] = email2;
                Tel.tel_row[15] = email3;
                Tel.tel_row[16] = email4;
                Tel.tel_row[17] = email5;
                Tel.tel_row[18] = email6;
                Tel.tel_row[19] = email7;
                Tel.tel_row[20] = email8;
                Tel.tel_row[21] = email9;
                Tel.tel_row[22] = email10;

                Tel.tel_row[23] = edr2;
                Tel.tel_row[24] = edr3;
                Tel.tel_row[25] = edr4;
                Tel.tel_row[26] = edr5;
                Tel.tel_row[27] = edr6;
                Tel.tel_row[28] = edr7;
                Tel.tel_row[29] = edr8;
                Tel.tel_row[30] = edr9;
                Tel.tel_row[31] = edr10;

                Tel.tel_row[32] = adr2;
                Tel.tel_row[33] = adr3;
                Tel.tel_row[34] = adr4;
                Tel.tel_row[35] = tadr5;

                Tel.tel_row[36] = tel2;
                Tel.tel_row[37] = tel3;
                Tel.tel_row[38] = tel4;
                Tel.tel_row[39] = tel5;
                Tel.tel_row[40] = tel6;
                Tel.tel_row[41] = tel7;
                Tel.tel_row[42] = tel8;
                Tel.tel_row[43] = tel9;
                Tel.tel_row[44] = ttel10;

                Tel.tel_row[45] = desc2;
                Tel.tel_row[46] = desc3;
                Tel.tel_row[47] = desc4;
                Tel.tel_row[48] = desc5;
                Tel.tel_row[49] = desc6;
                Tel.tel_row[50] = desc7;
                Tel.tel_row[51] = desc8;
                Tel.tel_row[52] = desc9;
                Tel.tel_row[53] = desc10;

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "insert into tel(place,title,fname,family,profession,job,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,city,adr1,adr2,adr3,adr4,adr5,zip,email1,edr1,email2,edr2,email3,edr3,email4,edr4,email5,edr5,email6,edr6,email7,edr7,email8,edr8,email9,edr9,email10,edr10) values('" + place_t.Text + "','" + title_t.Text + "','" + fname_t.Text + "','" + family_t.Text + "','" + profession_t.Text + "','" + job_t.Text + "','" + tel_t.Text + "','" + desc_t.Text + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + ttel10 + "','" + desc10 + "','" + city_t.Text + "','" + adr_t.Text + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + tadr5 + "','" + zip_t.Text + "','" + email_c.Text + "','" + edr_t.Text + "','" + email2 + "','" + edr2 + "','" + email3 + "','" + edr3 + "','" + email4 + "','" + edr4 + "','" + email5 + "','" + edr5 + "','" + email6 + "','" + edr6 + "','" + email7 + "','" + edr7 + "','" + email8 + "','" + edr8 + "','" + email9 + "','" + edr9 + "','" + email10 + "','" + edr10 + "')";
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = "insert into tel_tmp(profession,tel,desc1,email,edr) values('" + profession_t.Text + "','" + tel_t.Text + "','" + desc_t.Text + "','" + email_c.Text + "','" + edr_t.Text + "')";
                sqlcmd.ExecuteNonQuery();

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

                sqlcmd.CommandText = "select count(*) from info where job='" + job_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(job) values('" + job_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlcmd.CommandText = "select count(*) from info where city='" + city_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(city) values('" + city_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlcmd.CommandText = "select count(*) from info where adr='" + adr_t.Text + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    sqlcmd.CommandText = "Insert into info(adr) values('" + adr_t.Text + "') ";
                    sqlcmd.ExecuteNonQuery();
                }

                sqlconn.Close();
            }
            else
            {
                Tel.tel_edit_flag = true;

                Tel.tel_row[1] = place_t.Text;
                Tel.tel_row[2] = title_t.Text;
                Tel.tel_row[3] = fname_t.Text;
                Tel.tel_row[4] = family_t.Text;
                Tel.tel_row[5] = profession_t.Text;
                Tel.tel_row[6] = job_t.Text;
                Tel.tel_row[7] = tel_t.Text;
                Tel.tel_row[8] = desc_t.Text;
                Tel.tel_row[9] = city_t.Text;
                Tel.tel_row[10] = adr_t.Text;
                Tel.tel_row[11] = zip_t.Text;
                Tel.tel_row[12] = email_c.Text;
                Tel.tel_row[13] = edr_t.Text;

                Tel.tel_row[14] = email2;
                Tel.tel_row[15] = email3;
                Tel.tel_row[16] = email4;
                Tel.tel_row[17] = email5;
                Tel.tel_row[18] = email6;
                Tel.tel_row[19] = email7;
                Tel.tel_row[20] = email8;
                Tel.tel_row[21] = email9;
                Tel.tel_row[22] = email10;

                Tel.tel_row[23] = edr2;
                Tel.tel_row[24] = edr3;
                Tel.tel_row[25] = edr4;
                Tel.tel_row[26] = edr5;
                Tel.tel_row[27] = edr6;
                Tel.tel_row[28] = edr7;
                Tel.tel_row[29] = edr8;
                Tel.tel_row[30] = edr9;
                Tel.tel_row[31] = edr10;

                Tel.tel_row[32] = adr2;
                Tel.tel_row[33] = adr3;
                Tel.tel_row[34] = adr4;
                Tel.tel_row[35] = tadr5;

                Tel.tel_row[36] = tel2;
                Tel.tel_row[37] = tel3;
                Tel.tel_row[38] = tel4;
                Tel.tel_row[39] = tel5;
                Tel.tel_row[40] = tel6;
                Tel.tel_row[41] = tel7;
                Tel.tel_row[42] = tel8;
                Tel.tel_row[43] = tel9;
                Tel.tel_row[44] = ttel10;

                Tel.tel_row[45] = desc2;
                Tel.tel_row[46] = desc3;
                Tel.tel_row[47] = desc4;
                Tel.tel_row[48] = desc5;
                Tel.tel_row[49] = desc6;
                Tel.tel_row[50] = desc7;
                Tel.tel_row[51] = desc8;
                Tel.tel_row[52] = desc9;
                Tel.tel_row[53] = desc10;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tel.tel_flag_search = true;
            Tel.tel_query = "select * from tel";
            bool flag = false;
            if (place_ch.Checked == true)
            {
                Tel.tel_query += " where place='" + place_t.Text + "' ";
                flag = true;
            }
            if (title_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where title='" + title_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and title='" + title_t.Text + "' ";
            }

            if (fname_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where fname='" + fname_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and fname='" + fname_t.Text + "' ";
            }

            if (family_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where family='" + family_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and family='" + family_t.Text + "' ";
            }

            if (profession_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where profession='" + profession_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and profession='" + profession_t.Text + "' ";
            }

            if (job_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where job='" + job_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and job='" + job_t.Text + "' ";
            }

            if (tel_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where tel1='" + tel_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and tel1='" + tel_t.Text + "' ";
            }

            if (desc_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where desc1='" + desc_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and desc1='" + desc_t.Text + "' ";
            }

            if (city_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where city='" + city_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and city='" + city_t.Text + "' ";
            }

            if (adr_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where adr1='" + adr_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and adr1='" + adr_t.Text + "' ";
            }

            if (zip_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where zip='" + zip_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and zip='" + zip_t.Text + "' ";
            }

            if (email_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where email1='" + email_c.Text + "' ";
                }
                else
                    Tel.tel_query += " and email1='" + email_c.Text + "' ";
            }

            if (edr_ch.Checked == true)
            {
                if (flag == false)
                {
                    flag = true;
                    Tel.tel_query += " where edr1='" + edr_t.Text + "' ";
                }
                else
                    Tel.tel_query += " and edr1='" + edr_t.Text + "' ";
            }

            this.Close();

        }

        private void title_t_Enter(object sender, EventArgs e)
        {
            place_c.Visible = false;
        }

        private void fname_t_Enter(object sender, EventArgs e)
        {
            title_c.Visible = false;
        }

        private void job_t_Enter(object sender, EventArgs e)
        {
            prf_c.Visible = false;
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void tel_t_Enter(object sender, EventArgs e)
        {
            job_c.Visible = false;
        }

        private void city_t_Enter(object sender, EventArgs e)
        {
            desc_c.Visible = false;
        }

        private void adr_t_Enter(object sender, EventArgs e)
        {
            city_c.Visible = false;
        }

        private void place_t_Click(object sender, EventArgs e)
        {
            place_c.Width = 17;
            place_c.Visible = true;
        }

        private void title_t_Click(object sender, EventArgs e)
        {
            title_c.Width = 17;
            title_c.Visible = true;
        }

        private void profession_t_Click(object sender, EventArgs e)
        {
            prf_c.Width = 17;
            prf_c.Visible = true;
        }

        private void job_t_Click(object sender, EventArgs e)
        {
            job_c.Width = 17;
            job_c.Visible = true;
        }

        private void desc_t_Click(object sender, EventArgs e)
        {
            desc_c.Width = 17;
            desc_c.Visible = true;
        }

        private void city_t_Click(object sender, EventArgs e)
        {
            city_c.Width = 17;
            city_c.Visible = true;
        }

        private void place_c_Click(object sender, EventArgs e)
        {
            if (place_c.Width != 22 + place_t.Width)
                place_c.Width = 22 + place_t.Width;
        }

        private void title_c_Click(object sender, EventArgs e)
        {
            if (title_c.Width != 22 + title_t.Width)
                title_c.Width = 22 + title_t.Width;
        }

        private void prf_c_Click(object sender, EventArgs e)
        {
            if (prf_c.Width != 22 + profession_t.Width)
                prf_c.Width = 22 + profession_t.Width;
        }

        private void job_c_Click(object sender, EventArgs e)
        {
            if (job_c.Width != 22 + job_t.Width)
                job_c.Width = 22 + job_t.Width;
        }

        private void desc_c_Click(object sender, EventArgs e)
        {
            if (desc_c.Width != 22 + desc_t.Width)
                desc_c.Width = 22 + desc_t.Width;
        }

        private void city_c_Click(object sender, EventArgs e)
        {
            if (city_c.Width != 22 + city_t.Width)
                city_c.Width = 22 + city_t.Width;
        }

        private void place_c_MouseHover(object sender, EventArgs e)
        {
            place_c.Width = 22 + place_t.Width;
            place_c.SendToBack();
        }

        private void title_c_MouseHover(object sender, EventArgs e)
        {
            title_c.Width = 22 + title_t.Width;
            title_c.SendToBack();
        }

        private void prf_c_MouseHover(object sender, EventArgs e)
        {
            prf_c.Width = 22 + profession_t.Width;
            prf_c.SendToBack();
        }

        private void job_c_MouseHover(object sender, EventArgs e)
        {
            job_c.Width = 22 + job_t.Width;
            job_c.SendToBack();
        }

        private void desc_c_MouseHover(object sender, EventArgs e)
        {
            desc_c.Width = 22 + desc_t.Width;
            desc_c.SendToBack();
        }

        private void city_c_MouseHover(object sender, EventArgs e)
        {
            city_c.Width = 22 + city_t.Width;
            city_c.SendToBack();
        }

        private void place_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            place_t.Text = place_c.Text;
            place_c.Width = 17;
            place_c.Visible = false;
            place_t.Focus();
        }

        private void title_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            title_t.Text = title_c.Text;
            title_c.Width = 17;
            title_c.Visible = false;
            title_t.Focus();
        }

        private void prf_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            profession_t.Text = prf_c.Text;
            prf_c.Width = 17;
            prf_c.Visible = false;
            profession_t.Focus();
        }

        private void job_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            job_t.Text = job_c.Text;
            job_c.Width = 17;
            job_c.Visible = false;
            job_t.Focus();
        }

        private void desc_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            desc_t.Text = desc_c.Text;
            desc_c.Width = 17;
            desc_c.Visible = false;
            desc_t.Focus();
        }

        private void city_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            city_t.Text = city_c.Text;
            city_c.Width = 17;
            city_c.Visible = false;
            city_t.Focus();
        }

        private void profession_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void email_c_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void cm1_Click(object sender, EventArgs e)
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
            nobat frm = new nobat();
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

        private void Tel2_Click(object sender, EventArgs e)
        {
            cm_menu.Visible = false;
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