using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Clinical_Management
{
    public partial class Medical_File_Closet : Form
    {
        public static bool full;
        public Medical_File_Closet()
        {
            InitializeComponent();
        }

        private void Medical_File_Closet_Load(object sender, EventArgs e)
        {
            full = false;
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

           

            object[] ob = new object[10];
            ob[0] = "txt.";
            ob[1] = "cm.";
            ob[2] = "Del";
            //ob[7] = "";
            ob[9] = "AV Folder";

            if (login.log_username == "admin")
            {
                dataGridView1.Rows.Clear();
                sqlcmd.CommandText = "select * from sick1";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    ob[3] = data["par"].ToString();
                    ob[4] = data["fname"].ToString();
                    ob[5] = (data["mname"].ToString() + " " + data["lname"].ToString()).Trim();
                    ob[6] = data["reception"].ToString();
                    ob[7] = data["reception"].ToString();
                    ob[8] = data["doctor"].ToString();

                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count - 1, ob);
                }
                data.Close();


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sqlcmd.CommandText = "select rdate from sick2 where par = '" + dataGridView1.Rows[i].Cells[3].Value + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        dataGridView1.Rows[i].Cells[7].Value = data["rdate"].ToString();
                    }
                    data.Close();
                }

                sqlcmd.CommandText = "select count(*) from sick1";
                total_t.Text = sqlcmd.ExecuteScalar().ToString();

            }
            else
            {
                //dataGridView1.Rows.Clear();
                string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;

                DataView dv;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlada = new SqlDataAdapter();
                sqlcmd.CommandText = "select par as [شماره پرونده],fname as [نام اول],mname as [نام میانی],lname as [نام آخر],reception as [تاريخ تشكيل پرونده],doctor as [نام پزشك] from sick1 where doctor = '" + mytemp2 + "' ";
                sqlada.SelectCommand = sqlcmd;
                sqlada.Fill(ds);
                dv = new DataView(ds.Tables[0]);

                dataGridView1.DataSource = dv;

                sqlcmd.CommandText = "select count(*) from sick1 where doctor = '" + mytemp2 + "' ";
                total_t.Text = sqlcmd.ExecuteScalar().ToString();

            }

            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                for (int i = 0; i < 10; i++)
                    dataGridView1.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
            }
            data.Close();


            sqlconn.Close();
        }

        private void Medical_File_Closet_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Medical_File_Closet_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10) values('" + this.Name + "','" + dataGridView1.Columns[0].Width + "','" + dataGridView1.Columns[1].Width + "','" + dataGridView1.Columns[2].Width + "','" + dataGridView1.Columns[3].Width + "','" + dataGridView1.Columns[4].Width + "','" + dataGridView1.Columns[5].Width + "','" + dataGridView1.Columns[6].Width + "','" + dataGridView1.Columns[7].Width + "','" + dataGridView1.Columns[8].Width + "','" + dataGridView1.Columns[9].Width + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        {
                            Full_Summary frm = new Full_Summary();
                            frm.ShowDialog();

                            if (full == true)
                            {
                                SaveFileDialog dlg = new SaveFileDialog();
                                dlg.Filter = "Text Documents(*.txt)|*.txt";
                                dlg.Title = "Export as Notepad...";
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                                    sqlconn.Open();
                                    SqlCommand sqlcmd = new SqlCommand();
                                    sqlcmd.Connection = sqlconn;
                                    sqlcmd.CommandText = "select * from sick1 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ";
                                    SqlDataReader data = sqlcmd.ExecuteReader();
                                    int i = 0;
                                    string[] s = new string[1000000];
                                    //s[0] = "";

                                    //File.WriteAllLines(dlg.FileName, s);

                                    string temp = "";
                                    
                                    while (data.Read())
                                    {
                                        temp = "        " + "عنوان = ";
                                        temp += data["title"].ToString();
                                        temp += "        " + "نام اول = " + data["fname"].ToString();
                                        temp += "        " + "نام مياني = " + data["mname"].ToString();
                                        temp += "        " + "نام آخر = " + data["lname"].ToString();
                                        temp += "        " + "سن = " + data["age"].ToString();
                                        temp += "        " + "شغل = " + data["job"].ToString();
                                        temp += "        " + "محل تولد = " + data["bplace"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "نوع بيمه = " + data["bimeh"].ToString();
                                        temp += "        " + "وضعيت تاهل = " + data["marray"].ToString();
                                        temp += "        " + "تعداد فرزندان = " + data["child"].ToString();
                                        temp += "        " + "بارداري = " + data["bar"].ToString();
                                        temp += "        " + "جنسيت = " + data["gender"].ToString();
                                        temp += "        " + "معرف = " + data["moaref"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "تاريخ پذيرش = " + data["reception"].ToString();
                                        temp += "        " + "نام پدر = " + data["father"].ToString();
                                        temp += "        " + "شماره شناسنامه = " + data["id"].ToString();
                                        temp += "        " + "تاريخ تولد = " + data["bdate"].ToString();
                                        temp += "        " + "كد ملي = " + data["nid"].ToString();
                                        temp += "        " + "كد پستي = " + data["zip"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "شهر يا روستا = " + data["city"].ToString();
                                        temp += "        " + "محل صدور شناسنامه = " + data["sodor"].ToString();
                                        temp += "        " + "معلوليت = " + data["malol"].ToString();
                                        temp += "        " + "آدرس محل سكونت = " + data["adr"].ToString();
                                        temp += "        " + "تحصيلات = " + data["tahsil"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "             ------------------------------------------------------------------";
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "CC: " + data["cc"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Dx: " + data["dx"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PI: " + data["pi"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PH: " + data["ph"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "FH: " + data["fh"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PE: " + data["pe"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "G: " + data["g"].ToString() + "  ";
                                        temp += "        " + "P: " + data["p"].ToString() + "  ";
                                        temp += "        " + "A: " + data["a"].ToString() + "  ";
                                        temp += "        " + "L: " + data["l"].ToString() + "  ";
                                        temp += "        " + "D: " + data["d"].ToString() + "  ";
                                        temp += "        " + "HC: " + data["hc"].ToString() + "  ";
                                        temp += "        " + "HT: " + data["ht"].ToString() + "  ";
                                        temp += "        " + "Wg: " + data["wg"].ToString() + "  ";
                                        temp += "        " + "BP: " + data["bp"].ToString() + "  ";
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "DD: " + data["dd"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Px: " + data["px"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Rx: " + data["rx"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "IP: " + data["ip"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "OP: " + data["op"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PC: " + data["pc"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";

                                    }
                                    data.Close();
                                    sqlcmd.CommandText = "select * from sick2 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' order by visit ";
                                    data = sqlcmd.ExecuteReader();
                                    while (data.Read())
                                    {
                                        temp += "             ------------------------------------------------------------------";
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Revisit Date : " + data["rdate"].ToString() + "    No. of visit :" + data["visit"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "NCC/Sb: " + data["sb"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Ob: " + data["ob"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "As: " + data["ass"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Pl: " + data["pl"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "DD: " + data["dd"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Px: " + data["px"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Rx: " + data["rx"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "IP: " + data["ip"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "OP: " + data["op"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Co: " + data["co"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PC: " + data["pc"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                    }
                                    data.Close();

                                    File.WriteAllLines(dlg.FileName, s);
                                    //File.WriteAllText(dlg.FileName, temp);

                                    sqlconn.Close();
                                    //File.Create(dlg.FileName);
                                    //File.WriteAllText(dlg.FileName, "ghs\\njhgdjf");
                                }

                            }
                            else
                            {
                                SaveFileDialog dlg = new SaveFileDialog();
                                dlg.Filter = "Text Documents(*.txt)|*.txt";
                                dlg.Title = "Export as Notepad...";
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                                    sqlconn.Open();
                                    SqlCommand sqlcmd = new SqlCommand();
                                    sqlcmd.Connection = sqlconn;
                                    sqlcmd.CommandText = "select * from sick1 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ";
                                    sqlcmd.ExecuteNonQuery();

                                    int i = 0;
                                    string[] s = new string[1000000];
                                    //s[0] = "";

                                    //File.WriteAllLines(dlg.FileName, s);

                                    string temp = "";
                                    SqlDataReader data = sqlcmd.ExecuteReader();
                                    while (data.Read())
                                    {
                                        temp = "        ";
                                        temp += data["title"].ToString();
                                        temp += "    " + data["fname"].ToString();
                                        temp += "    " + data["mname"].ToString();
                                        temp += "    " + data["lname"].ToString();
                                        temp += "    " + data["age"].ToString();
                                        temp += " ساله" + "        "  + data["job"].ToString();
                                        temp += "        " + "تاريخ پذيرش = " + data["reception"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        
                                        temp += "             ------------------------------------------------------------------";
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "CC: " + data["cc"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Dx: " + data["dx"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PI: " + data["pi"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PH: " + data["ph"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "FH: " + data["fh"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PE: " + data["pe"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "G: " + data["g"].ToString() + "  ";
                                        temp += "        " + "P: " + data["p"].ToString() + "  ";
                                        temp += "        " + "A: " + data["a"].ToString() + "  ";
                                        temp += "        " + "L: " + data["l"].ToString() + "  ";
                                        temp += "        " + "D: " + data["d"].ToString() + "  ";
                                        temp += "        " + "HC: " + data["hc"].ToString() + "  ";
                                        temp += "        " + "HT: " + data["ht"].ToString() + "  ";
                                        temp += "        " + "Wg: " + data["wg"].ToString() + "  ";
                                        temp += "        " + "BP: " + data["bp"].ToString() + "  ";
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "DD: " + data["dd"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Px: " + data["px"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Rx: " + data["rx"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "IP: " + data["ip"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "OP: " + data["op"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PC: " + data["pc"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";

                                    }
                                    data.Close();
                                    sqlcmd.CommandText = "select * from sick2 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' order by visit ";
                                    data = sqlcmd.ExecuteReader();
                                    while (data.Read())
                                    {
                                        temp += "             ------------------------------------------------------------------";
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Revisit Date : " + data["rdate"].ToString() + "    No. of visit :" + data["visit"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "NCC/Sb: " + data["sb"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Ob: " + data["ob"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "As: " + data["ass"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Pl: " + data["pl"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "DD: " + data["dd"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Px: " + data["px"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Rx: " + data["rx"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "IP: " + data["ip"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "OP: " + data["op"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "Co: " + data["co"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                        temp += "        " + "PC: " + data["pc"].ToString();
                                        s[i] = temp;
                                        i++;
                                        temp = "";
                                    }
                                    data.Close();

                                    File.WriteAllLines(dlg.FileName, s);
                                    //File.WriteAllText(dlg.FileName, temp);

                                    sqlconn.Close();
                                    //File.Create(dlg.FileName);
                                    //File.WriteAllText(dlg.FileName, "ghs\\njhgdjf");
                                }
                            }
                            break;
                        }
                    case 1:// Export as .cm
                        {
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.Filter = "Clinical Management Files(*.cm)|*.cm";
                            dlg.Title = "Export as Patient's File...";
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                string temp = "";

                                SqlConnection sqlconn = new SqlConnection(cm.cs);
                                sqlconn.Open();
                                SqlCommand sqlcmd = new SqlCommand();
                                sqlcmd.Connection = sqlconn;
                                sqlcmd.CommandText = "select * from sick1 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ";
                                SqlDataReader data = sqlcmd.ExecuteReader();
                                while (data.Read())
                                {
                                    temp += "title|" + data["title"].ToString() + "|";
                                    temp += "fname|" + data["fname"].ToString() + "|";
                                    temp += "mname|" + data["mname"].ToString() + "|";
                                    temp += "lname|" + data["lname"].ToString() + "|";

                                    temp += "doctor|" + data["doctor"].ToString() + "|";
                                    temp += "prf|" + data["prf"].ToString() + "|";

                                    temp += "age|" + data["age"].ToString() + "|";
                                    temp += "job|" + data["job"].ToString() + "|";
                                    temp += "bplace|" + data["bplace"].ToString() + "|";
                                    temp += "bimeh|" + data["bimeh"].ToString() + "|";
                                    temp += "bimehno|" + data["bimehno"].ToString() + "|";
                                    temp += "serial|" + data["serial"].ToString() + "|";
                                    temp += "expire|" + data["expire"].ToString() + "|";

                                    temp += "bimeh2|" + data["bimeh2"].ToString() + "|";
                                    temp += "bimehno2|" + data["bimehno2"].ToString() + "|";
                                    temp += "serial2|" + data["serial2"].ToString() + "|";
                                    temp += "expire2|" + data["expire2"].ToString() + "|";

                                    temp += "bimeh3|" + data["bimeh3"].ToString() + "|";
                                    temp += "bimehno3|" + data["bimehno3"].ToString() + "|";
                                    temp += "serial3|" + data["serial3"].ToString() + "|";
                                    temp += "expire|3" + data["expire3"].ToString() + "|";

                                    temp += "bimeh|4" + data["bimeh4"].ToString() + "|";
                                    temp += "bimehno4|" + data["bimehno4"].ToString() + "|";
                                    temp += "serial4|" + data["serial4"].ToString() + "|";
                                    temp += "expire|4" + data["expire4"].ToString() + "|";

                                    temp += "marray|" + data["marray"].ToString() + "|";
                                    temp += "child|" + data["child"].ToString() + "|";
                                    temp += "bar|" + data["bar"].ToString() + "|";
                                    temp += "gender|" + data["gender"].ToString() + "|";
                                    temp += "moaref|" + data["moaref"].ToString() + "|";
                                    temp += "reception|" + data["reception"].ToString() + "|";
                                    temp += "father|" + data["father"].ToString() + "|";
                                    temp += "id|" + data["id"].ToString() + "|";
                                    temp += "bdate|" + data["bdate"].ToString() + "|";
                                    temp += "nid|" + data["nid"].ToString() + "|";
                                    temp += "zip|" + data["zip"].ToString() + "|";
                                    temp += "city|" + data["city"].ToString() + "|";
                                    temp += "sodor|" + data["sodor"].ToString() + "|";
                                    temp += "malol|" + data["malol"].ToString() + "|";
                                    temp += "adr|" + data["adr"].ToString() + "|";
                                    temp += "adr2|" + data["adr2"].ToString() + "|";
                                    temp += "adr3|" + data["adr3"].ToString() + "|";
                                    temp += "adr4|" + data["adr4"].ToString() + "|";
                                    temp += "adr5|" + data["adr5"].ToString() + "|";

                                    temp += "tel1|" + data["tel1"].ToString() + "|";
                                    temp += "desc1|" + data["desc1"].ToString() + "|";
                                    temp += "tel2|" + data["tel2"].ToString() + "|";
                                    temp += "desc2|" + data["desc2"].ToString() + "|";
                                    temp += "tel3|" + data["tel3"].ToString() + "|";
                                    temp += "desc3|" + data["desc3"].ToString() + "|";
                                    temp += "tel4|" + data["tel4"].ToString() + "|";
                                    temp += "desc4|" + data["desc4"].ToString() + "|";
                                    temp += "tel5|" + data["tel5"].ToString() + "|";
                                    temp += "desc5|" + data["desc5"].ToString() + "|";
                                    temp += "tel6|" + data["tel6"].ToString() + "|";
                                    temp += "desc6|" + data["desc6"].ToString() + "|";
                                    temp += "tel7|" + data["tel7"].ToString() + "|";
                                    temp += "desc7|" + data["desc7"].ToString() + "|";
                                    temp += "tel8|" + data["tel8"].ToString() + "|";
                                    temp += "desc8|" + data["desc8"].ToString() + "|";
                                    temp += "tel9|" + data["tel9"].ToString() + "|";
                                    temp += "desc9|" + data["desc9"].ToString() + "|";
                                    temp += "tel10|" + data["tel10"].ToString() + "|";
                                    temp += "desc10|" + data["desc10"].ToString() + "|";


                                    temp += "tahsil|" + data["tahsil"].ToString() + "|";
                                    temp += "othercode|" + data["othercode"].ToString() + "|";
                                    temp += "life|" + data["life"].ToString() + "|";
                                    temp += "busy|" + data["busy"].ToString() + "|";
                                    temp += "others|" + data["others"].ToString() + "|";

                                    temp += "edr1|" + data["edr1"].ToString() + "|";
                                    temp += "email1|" + data["email1"].ToString() + "|";
                                    temp += "edr2|" + data["edr2"].ToString() + "|";
                                    temp += "email2|" + data["email2"].ToString() + "|";
                                    temp += "edr3|" + data["edr3"].ToString() + "|";
                                    temp += "email3|" + data["email3"].ToString() + "|";
                                    temp += "edr4|" + data["edr4"].ToString() + "|";
                                    temp += "email4|" + data["email4"].ToString() + "|";
                                    temp += "edr5|" + data["edr5"].ToString() + "|";
                                    temp += "email5|" + data["email5"].ToString() + "|";
                                    temp += "edr6|" + data["edr6"].ToString() + "|";
                                    temp += "email6|" + data["email6"].ToString() + "|";
                                    temp += "edr7|" + data["edr7"].ToString() + "|";
                                    temp += "email7|" + data["email7"].ToString() + "|";
                                    temp += "edr8|" + data["edr8"].ToString() + "|";
                                    temp += "email8|" + data["email8"].ToString() + "|";
                                    temp += "edr9|" + data["edr9"].ToString() + "|";
                                    temp += "email9|" + data["email9"].ToString() + "|";
                                    temp += "edr10|" + data["edr10"].ToString() + "|";
                                    temp += "email10|" + data["email10"].ToString() + "|";

                                    temp += "cc|" + data["cc"].ToString() + "|";
                                    temp += "dx|" + data["dx"].ToString() + "|";
                                    temp += "pi|" + data["pi"].ToString() + "|";
                                    temp += "ph|" + data["ph"].ToString() + "|";
                                    temp += "fh|" + data["fh"].ToString() + "|";
                                    temp += "pe|" + data["pe"].ToString() + "|";
                                    temp += "g|" + data["g"].ToString() + "|";
                                    temp += "p|" + data["p"].ToString() + "|";
                                    temp += "a|" + data["a"].ToString() + "|";
                                    temp += "l|" + data["l"].ToString() + "|";
                                    temp += "d|" + data["d"].ToString() + "|";
                                    temp += "hc|" + data["hc"].ToString() + "|";
                                    temp += "ht|" + data["ht"].ToString() + "|";
                                    temp += "wg|" + data["wg"].ToString() + "|";
                                    temp += "bp|" + data["bp"].ToString() + "|";
                                    temp += "dd|" + data["dd"].ToString() + "|";
                                    temp += "dx|" + data["dx"].ToString() + "|";
                                    temp += "rx|" + data["rx"].ToString() + "|";
                                    temp += "ip|" + data["ip"].ToString() + "|";
                                    temp += "op|" + data["op"].ToString() + "|";
                                    temp += "pc|" + data["pc"].ToString() + "|";
                                }
                                data.Close();

                                sqlcmd.CommandText = "select * from sick2 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' order by visit ";
                                data = sqlcmd.ExecuteReader();
                                while(data.Read())
                                {
                                    temp += "visit|" + data["visit"].ToString() + "|";
                                    temp += "rdate|" + data["rdate"].ToString() + "|";
                                    temp += "sb|" + data["sb"].ToString() + "|";
                                    temp += "ob|" + data["ob"].ToString() + "|";
                                    temp += "as|" + data["ass"].ToString() + "|";
                                    temp += "pl|" + data["pl"].ToString() + "|";
                                    temp += "dd2|" + data["dd"].ToString() + "|";
                                    temp += "px2|" + data["px"].ToString() + "|";
                                    temp += "rx2|" + data["rx"].ToString() + "|";
                                    temp += "ip2|" + data["ip"].ToString() + "|";
                                    temp += "op2|" + data["op"].ToString() + "|";
                                    temp += "co|" + data["co"].ToString() + "|";
                                    temp += "pc2|" + data["pc"].ToString() + "|";
                                }

                                data.Close();

                                File.WriteAllText(dlg.FileName, temp);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (MessageBox.Show("Do you want to delete the whole patient's file from your system ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (MessageBox.Show("Are you sure you want to delete the whole file from your system ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        Directory.Delete(Application.StartupPath + "\\Patient Files\\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), true);
                                    }
                                    catch { }
                                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                                    sqlconn.Open();
                                    SqlCommand sqlcmd = new SqlCommand();
                                    sqlcmd.Connection = sqlconn;
                                    sqlcmd.CommandText = "Delete from sick1 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                    sqlcmd.CommandText = "Delete from sick2 where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                    sqlcmd.CommandText = "Delete from paziresh where par = '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                                    sqlconn.Close();
                                    
                                    total_t.Text = (Int64.Parse(total_t.Text) - 1).ToString();
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                if (Directory.Exists(Application.StartupPath + "\\Patient Files\\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "\\A - V Folder") == true)
                                   System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files\\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "\\A - V Folder");
                                else
                                {
                                    Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "\\A - V Folder");
                                    System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files\\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "\\A - V Folder");
                                }
                            }
                            catch { }

                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete all files from your system ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (MessageBox.Show("Are you sure you want to delete all files from your system ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (MessageBox.Show("If you click YES your system clears all patient's files and will reset your software ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                    {
                        if (login.log_username == "admin")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;
                            sqlcmd.CommandText = "Delete from sick1 ";
                            sqlcmd.ExecuteNonQuery();
                            sqlcmd.CommandText = "Delete from sick2 ";
                            sqlcmd.ExecuteNonQuery();
                            dataGridView1.Rows.Clear();
                            sqlconn.Close();
                            total_t.Text = "0";
                            Directory.Delete(Application.StartupPath + "\\Patient Files", true);
                            Directory.CreateDirectory(Application.StartupPath + "\\Patient Files");
                        }
                        else
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;

                            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
                            sqlconn2.Open();
                            SqlCommand sqlcmd2 = new SqlCommand();
                            sqlcmd2.Connection = sqlconn2;


                            string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;
                            sqlcmd.CommandText = "select par from sick1 where doctor = '"+ mytemp2 +"' ";
                            SqlDataReader data = sqlcmd.ExecuteReader();
                            while (data.Read())
                            {
                                Int64 temp_par = Int64.Parse(data["par"].ToString());
                                sqlcmd2.CommandText = "Delete from sick2 where par = '"+ temp_par +"' ";
                                sqlcmd2.ExecuteNonQuery();
                            }
                            data.Close();

                            sqlcmd.CommandText = "Delete from sick1  where doctor = '" + mytemp2 + "' ";
                            sqlcmd.ExecuteNonQuery();
                            
                            dataGridView1.Rows.Clear();

                            sqlconn.Close();
                            sqlconn2.Close();

                            total_t.Text = "0";
                            Directory.Delete(Application.StartupPath + "\\Patient Files", true);
                            Directory.CreateDirectory(Application.StartupPath + "\\Patient Files");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title, fname, mname, lname,doctor,prf ,age, job, bplace, bimeh, bimehno, serial, expire, bimeh2, bimehno2, serial2, expire2, bimeh3, bimehno3, serial3, expire3, bimeh4, bimehno4, serial4, expire4, marray, child, bar, gender, moaref, reception;
            string father, id, bdate, nid, zip, city, sodor, malol, tahsil, othercode, life, busy, others;
            string adr, adr2, adr3, adr4, adr5;
            string tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10;
            string edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;
            string cc, dx, pi, ph, fh, pe, g, p, a, l, d, hc, ht, wg, bp, dd, px, rx, ip, op, pc;
            string sb, ob, ass, pl, dd2, px2, rx2, ip2, op2, co, pc2;
            title = fname = mname = lname = age = job = bplace = bimeh = marray = child = bar = gender = moaref = reception =doctor= prf="";
            father = id = bdate = nid = zip = city = sodor = malol = adr = tahsil = othercode = life = busy = "";
            cc = dx = pi = ph = fh = pe = g = p = a = l = d = hc = ht = wg = bp = dd = px = rx = ip = op = pc = "";
            sb = ob = ass = pl = dd2 = px2 = rx2 = ip2 = op2 = co = pc2 = "";
            tel1 = desc1 = tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = "";
            edr1 = email1 = edr2 = email2 = edr3 = email3 = edr4 = email4 = edr5 = email5 = edr6 = email6 = edr7 = email7 = edr8 = email8 = edr9 = email9 = edr10 = email10 = "";
            bimehno = serial = expire = bimeh2 = bimehno2 = serial2 = expire2 = bimeh3 = bimehno3 = serial3 = expire3 = bimeh4 = bimehno4 = serial4 = expire4 = "";
            others = adr2 = adr3 = adr4 = adr5 = "";
            int visit = 2;
            Int64 par = 0;
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for Patient's Files...";
            dlg.Filter = "Clinical Management Files(*.cm)|*.cm";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string query = File.ReadAllText(dlg.FileName);
                string mylabel, mydata;
                int myindex;
                bool flag = true;
                try
                {
                    while (flag == true)
                    {
                        myindex = query.IndexOf('|');
                        mylabel = query.Substring(0, myindex);
                        if (query.Substring(myindex + 1, 1) == "|")
                        {
                            mydata = "";
                            try
                            {
                                query = query.Substring(myindex + 2, query.Length - myindex - 2);
                            }
                            catch 
                            {
                                query = "";
                                flag = false;
                            }
                        }
                        else
                        {
                            query = query.Substring(myindex + 1, query.Length - myindex - 1);
                            myindex = query.IndexOf('|');
                            mydata = query.Substring(0, myindex);
                            try
                            {
                                query = query.Substring(myindex + 1, query.Length - myindex - 1);
                            }
                            catch
                            {
                                query = "";
                                flag = false;
                            }
                        }

                        switch (mylabel)
                        {
                            case "title":
                                {
                                    title = mydata;
                                    break;
                                }
                            case "fname":
                                {
                                    fname = mydata;
                                    break;
                                }
                            case "mname":
                                {
                                    mname = mydata;
                                    break;
                                }
                            case "lname":
                                {
                                    lname = mydata;
                                    break;
                                }

                            case "doctor":
                                {
                                    doctor = mydata;
                                    break;
                                }
                            case "prf":
                                {
                                    prf = mydata;
                                    break;
                                }

                            case "bplace":
                                {
                                    bplace = mydata;
                                    break;
                                }
                            case "age":
                                {
                                    age = mydata;
                                    break;
                                }
                            case "job":
                                {
                                    job = mydata;
                                    break;
                                }
                            case "bimeh":
                                {
                                    bimeh = mydata;
                                    break;
                                }
                            case "bimehno":
                                {
                                    bimehno = mydata;
                                    break;
                                }
                            case "serial":
                                {
                                    serial = mydata;
                                    break;
                                }
                            case "expire":
                                {
                                    expire = mydata;
                                    break;
                                }
                            case "bimeh2":
                                {
                                    bimeh2 = mydata;
                                    break;
                                }
                            case "bimehno2":
                                {
                                    bimehno2 = mydata;
                                    break;
                                }
                            case "serial2":
                                {
                                    serial2 = mydata;
                                    break;
                                }
                            case "expire2":
                                {
                                    expire2 = mydata;
                                    break;
                                }
                            case "bimeh3":
                                {
                                    bimeh3 = mydata;
                                    break;
                                }
                            case "bimehno3":
                                {
                                    bimehno3 = mydata;
                                    break;
                                }
                            case "serial3":
                                {
                                    serial3 = mydata;
                                    break;
                                }
                            case "expire3":
                                {
                                    expire3 = mydata;
                                    break;
                                }
                            case "bimeh4":
                                {
                                    bimeh4 = mydata;
                                    break;
                                }
                            case "bimehno4":
                                {
                                    bimehno4 = mydata;
                                    break;
                                }
                            case "serial4":
                                {
                                    serial4 = mydata;
                                    break;
                                }
                            case "expire4":
                                {
                                    expire4 = mydata;
                                    break;
                                }

                            case "gender":
                                {
                                    gender = mydata;
                                    break;
                                }
                            case "marray":
                                {
                                    marray = mydata;
                                    break;
                                }
                            case "child":
                                {
                                    child = mydata;
                                    break;
                                }
                            case "bar":
                                {
                                    bar = mydata;
                                    break;
                                }
                            case "moaref":
                                {
                                    moaref = mydata;
                                    break;
                                }
                            case "reception":
                                {
                                    reception = mydata;
                                    break;
                                }
                            case "father":
                                {
                                    father = mydata;
                                    break;
                                }
                            case "id":
                                {
                                    id = mydata;
                                    break;
                                }
                            case "bdate":
                                {
                                    bdate = mydata;
                                    break;
                                }
                            case "nid":
                                {
                                    nid = mydata;
                                    break;
                                }
                            case "zip":
                                {
                                    zip = mydata;
                                    break;
                                }
                            case "city":
                                {
                                    city = mydata;
                                    break;
                                }
                            case "sodor":
                                {
                                    sodor = mydata;
                                    break;
                                }
                            case "malol":
                                {
                                    malol = mydata;
                                    break;
                                }
                            case "adr":
                                {
                                    adr = mydata;
                                    break;
                                }
                            case "adr2":
                                {
                                    adr2 = mydata;
                                    break;
                                }
                            case "adr3":
                                {
                                    adr3 = mydata;
                                    break;
                                }
                            case "adr4":
                                {
                                    adr4 = mydata;
                                    break;
                                }
                            case "adr5":
                                {
                                    adr5 = mydata;
                                    break;
                                }

                            case "tel1":
                                {
                                    tel1 = mydata;
                                    break;
                                }
                            case "desc1":
                                {
                                    desc1 = mydata;
                                    break;
                                }
                            case "tel2":
                                {
                                    tel2 = mydata;
                                    break;
                                }
                            case "desc2":
                                {
                                    desc2 = mydata;
                                    break;
                                }
                            case "tel3":
                                {
                                    tel3 = mydata;
                                    break;
                                }
                            case "desc3":
                                {
                                    desc3 = mydata;
                                    break;
                                }
                            case "tel4":
                                {
                                    tel4 = mydata;
                                    break;
                                }
                            case "desc4":
                                {
                                    desc4 = mydata;
                                    break;
                                }
                            case "tel5":
                                {
                                    tel5 = mydata;
                                    break;
                                }
                            case "desc5":
                                {
                                    desc5 = mydata;
                                    break;
                                }
                            case "tel6":
                                {
                                    tel6 = mydata;
                                    break;
                                }
                            case "desc6":
                                {
                                    desc6 = mydata;
                                    break;
                                }
                            case "tel7":
                                {
                                    tel7 = mydata;
                                    break;
                                }
                            case "desc7":
                                {
                                    desc7 = mydata;
                                    break;
                                }
                            case "tel8":
                                {
                                    tel8 = mydata;
                                    break;
                                }
                            case "desc8":
                                {
                                    desc8 = mydata;
                                    break;
                                }
                            case "tel9":
                                {
                                    tel9 = mydata;
                                    break;
                                }
                            case "desc9":
                                {
                                    desc9 = mydata;
                                    break;
                                }
                            case "tel10":
                                {
                                    tel10 = mydata;
                                    break;
                                }
                            case "desc10":
                                {
                                    desc10 = mydata;
                                    break;
                                }
                            case "tahsil":
                                {
                                    tahsil = mydata;
                                    break;
                                }
                            case "othercode":
                                {
                                    othercode = mydata;
                                    break;
                                }
                            case "life":
                                {
                                    life = mydata;
                                    break;
                                }
                            case "busy":
                                {
                                    busy = mydata;
                                    break;
                                }
                            case "others":
                                {
                                    others = mydata;
                                    break;
                                }
                            case "edr1":
                                {
                                    edr1 = mydata;
                                    break;
                                }
                            case "email1":
                                {
                                    email1 = mydata;
                                    break;
                                }
                            case "edr2":
                                {
                                    edr2 = mydata;
                                    break;
                                }
                            case "email2":
                                {
                                    email2 = mydata;
                                    break;
                                }
                            case "edr3":
                                {
                                    edr3 = mydata;
                                    break;
                                }
                            case "email3":
                                {
                                    email3 = mydata;
                                    break;
                                }
                            case "edr4":
                                {
                                    edr4 = mydata;
                                    break;
                                }
                            case "email4":
                                {
                                    email4 = mydata;
                                    break;
                                }
                            case "edr5":
                                {
                                    edr5 = mydata;
                                    break;
                                }
                            case "email5":
                                {
                                    email5 = mydata;
                                    break;
                                }
                            case "edr6":
                                {
                                    edr6 = mydata;
                                    break;
                                }
                            case "email6":
                                {
                                    email6 = mydata;
                                    break;
                                }
                            case "edr7":
                                {
                                    edr7 = mydata;
                                    break;
                                }
                            case "email7":
                                {
                                    email7 = mydata;
                                    break;
                                }
                            case "edr8":
                                {
                                    edr8 = mydata;
                                    break;
                                }
                            case "email8":
                                {
                                    email8 = mydata;
                                    break;
                                }
                            case "edr9":
                                {
                                    edr9 = mydata;
                                    break;
                                }
                            case "email9":
                                {
                                    email9 = mydata;
                                    break;
                                }
                            case "edr10":
                                {
                                    edr10 = mydata;
                                    break;
                                }
                            case "email10":
                                {
                                    email10 = mydata;
                                    break;
                                }
                            ////////
                            case "cc":
                                {
                                    cc = mydata;
                                    break;
                                }
                            case "dx":
                                {
                                    dx = mydata;
                                    break;
                                }
                            case "pi":
                                {
                                    pi = mydata;
                                    break;
                                }
                            case "ph":
                                {
                                    ph = mydata;
                                    break;
                                }
                            case "fh":
                                {
                                    fh = mydata;
                                    break;
                                }
                            case "pe":
                                {
                                    pe = mydata;
                                    break;
                                }
                            case "g":
                                {
                                    g = mydata;
                                    break;
                                }
                            case "p":
                                {
                                    p = mydata;
                                    break;
                                }
                            case "a":
                                {
                                    a = mydata;
                                    break;
                                }
                            case "l":
                                {
                                    l = mydata;
                                    break;
                                }
                            case "d":
                                {
                                    d = mydata;
                                    break;
                                }
                            case "hc":
                                {
                                    hc = mydata;
                                    break;
                                }
                            case "wg":
                                {
                                    wg = mydata;
                                    break;
                                }
                            case "bp":
                                {
                                    bp = mydata;
                                    break;
                                }
                            case "dd":
                                {
                                    dd = mydata;
                                    break;
                                }
                            case "px":
                                {
                                    px = mydata;
                                    break;
                                }
                            case "rx":
                                {
                                    rx = mydata;
                                    break;
                                }
                            case "ip":
                                {
                                    ip = mydata;
                                    break;
                                }
                            case "op":
                                {
                                    op = mydata;
                                    break;
                                }
                            case "pc":
                                {
                                    pc = mydata;
                                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                                    sqlconn.Open();
                                    SqlCommand sqlcmd = new SqlCommand();
                                    sqlcmd.Connection = sqlconn;
                                    sqlcmd.CommandText = "Insert into sick1(doctor,prf,title,fname,mname,lname,age,job,bplace,bimeh,marray,child,bar,gender,moaref,reception,father,id,bdate,nid,zip,city,sodor,malol,adr,tahsil,othercode,life,busy,cc,dx,pi,ph,fh,pe,g,p,a,l,d,hc,ht,wg,bp,dd,px,rx,ip,op,pc,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('" + doctor + "','" + prf + "','" + title + "','" + fname + "','" + mname + "','" + lname + "','" + age + "','" + job + "','" + bplace + "','" + bimeh + "','" + marray + "','" + child + "','" + bar + "','" + gender + "','" + moaref + "','" + reception + "','" + father + "','" + id + "','" + bdate + "','" + nid + "','" + zip + "','" + city + "','" + sodor + "','" + malol + "','" + adr + "','" + tahsil + "','" + othercode + "','" + life + "','" + busy + "','" + cc + "','" + dx + "','" + pi + "','" + ph + "','" + fh + "','" + pe + "','" + g + "','" + p + "','" + a + "','" + l + "','" + d + "','" + hc + "','" + ht + "','" + wg + "','" + bp + "','" + dd + "','" + px + "','" + rx + "','" + ip + "','" + op + "','" + pc + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                    sqlconn.Close();

                                    flag = false;

                                    break;
                                }
                        } // End Of Switch Case 1
                       
                    } // End of While 1

                    
                    if (query != "")
                    {
                        flag = true;
                        string rdate = "";
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlconn;
                        sqlcmd.CommandText = "Select max(par) from sick1";
                        par = Int64.Parse(sqlcmd.ExecuteScalar().ToString());
                        sqlconn.Close();

                        while (flag == true)
                        {
                            if (query == "")
                                break;
                            myindex = query.IndexOf('|');
                            mylabel = query.Substring(0, myindex);
                            if (query.Substring(myindex + 1, 1) == "|")
                            {
                                mydata = "";
                                try
                                {
                                    query = query.Substring(myindex + 2, query.Length - myindex - 2);
                                }
                                catch
                                {
                                    query = "";
                                    flag = false;
                                }
                            }
                            else
                            {
                                query = query.Substring(myindex + 1, query.Length - myindex - 1);
                                myindex = query.IndexOf('|');
                                mydata = query.Substring(0, myindex);
                                try
                                {
                                    query = query.Substring(myindex + 1, query.Length - myindex - 1);
                                }
                                catch
                                {
                                    query = "";
                                    flag = false;
                                }
                            }

                            switch (mylabel)
                            {
                                case "visit":
                                    {
                                        visit = Int32.Parse(mydata);
                                        break;
                                    }
                                case "rdate":
                                    {
                                        rdate = mydata;
                                        break;
                                    }

                                case "sb":
                                    {
                                        sb = mydata;
                                        break;
                                    }
                                case "ob":
                                    {
                                        ob = mydata;
                                        break;
                                    }
                                case "as":
                                    {
                                        ass = mydata;
                                        break;
                                    }
                                case "pl":
                                    {
                                        pl = mydata;
                                        break;
                                    }
                                case "dd2":
                                    {
                                        dd2 = mydata;
                                        break;
                                    }
                                case "px2":
                                    {
                                        px2 = mydata;
                                        break;
                                    }
                                case "rx2":
                                    {
                                        rx2 = mydata;
                                        break;
                                    }
                                case "ip2":
                                    {
                                        ip2 = mydata;
                                        break;
                                    }
                                case "op2":
                                    {
                                        op2 = mydata;
                                        break;
                                    }
                                case "co":
                                    {
                                        co = mydata;
                                        break;
                                    }
                                case "pc2":
                                    {
                                        pc2 = mydata;
                                        SqlConnection sqlconn2 = new SqlConnection(cm.cs);
                                        sqlconn2.Open();
                                        SqlCommand sqlcmd2 = new SqlCommand();
                                        sqlcmd2.Connection = sqlconn2;
                                        sqlcmd2.CommandText = "Insert into sick2(par,visit,rdate,sb,ob,ass,pl,dd,px,rx,ip,op,co,pc) values('" + par + "','" + visit + "','" + rdate + "','" + sb + "','" + ob + "','" + ass + "','" + pl + "','" + dd2 + "','" + px2 + "','" + rx2 + "','" + ip2 + "','" + op2 + "','" + co + "','" + pc2 + "') ";
                                        sqlcmd2.ExecuteNonQuery();
                                        sqlcmd2.CommandText = "select count(*) from var1 where par = '"+ par +"' ";
                                        if(sqlcmd2.ExecuteScalar().ToString() == "0")
                                        {
                                            sqlcmd2.CommandText = "Insert into var1(par,lastvisit) values('"+ par +"','"+ visit +"')";
                                            sqlcmd2.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            sqlcmd2.CommandText = "Update var1 set lastvisit = '"+ visit +"' where par = '"+ par +"' ";
                                            sqlcmd2.ExecuteNonQuery();
                                        }
                                        sqlconn2.Close();
                                        break;
                                    }
                            } // End of switch case 2
                        } // End of While 2
                    } // End of if(Query != "")
                }
                catch
                {
                    MessageBox.Show("متاسفانه پرونده قابل بازيابي نمي باشد");
                }

                Medical_File_Closet_Load(sender, e);
              

            }// End  of If(saveDialog == OK)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Clinical Management Backup Files(*.cbk)|*.cbk";
            dlg.Title = "Export as all Patient's Files...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string temp = "";

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;

                SqlConnection sqlconn2 = new SqlConnection(cm.cs);
                sqlconn2.Open();
                SqlCommand sqlcmd2 = new SqlCommand();
                sqlcmd2.Connection = sqlconn2;
                SqlDataReader data2;
                Int64 sick_par = 0;
                
                string mytemp2 = "دكتر " + login.log_name + " " + login.log_family;

                if (login.log_username == "admin")
                {
                    sqlcmd2.CommandText = "select par from sick1 ";
                    data2 = sqlcmd2.ExecuteReader();
                }
                else
                {
                    sqlcmd2.CommandText = "select par from sick1 where doctor = '" + mytemp2 + "' ";
                    data2 = sqlcmd2.ExecuteReader();
                }
                while (data2.Read())
                {
                    sick_par = Int64.Parse(data2["par"].ToString());

                    sqlcmd.CommandText = "select * from sick1 where par = '" + sick_par + "' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                      
                        temp += "title|" + data["title"].ToString() + "|";
                        temp += "fname|" + data["fname"].ToString() + "|";
                        temp += "mname|" + data["mname"].ToString() + "|";
                        temp += "lname|" + data["lname"].ToString() + "|";

                        temp += "doctor|" + data["doctor"].ToString() + "|";
                        temp += "prf|" + data["prf"].ToString() + "|";

                        temp += "age|" + data["age"].ToString() + "|";
                        temp += "job|" + data["job"].ToString() + "|";
                        temp += "bplace|" + data["bplace"].ToString() + "|";
                        temp += "bimeh|" + data["bimeh"].ToString() + "|";
                        temp += "bimehno|" + data["bimehno"].ToString() + "|";
                        temp += "serial|" + data["serial"].ToString() + "|";
                        temp += "expire|" + data["expire"].ToString() + "|";

                        temp += "bimeh2|" + data["bimeh2"].ToString() + "|";
                        temp += "bimehno2|" + data["bimehno2"].ToString() + "|";
                        temp += "serial2|" + data["serial2"].ToString() + "|";
                        temp += "expire2|" + data["expire2"].ToString() + "|";

                        temp += "bimeh3|" + data["bimeh3"].ToString() + "|";
                        temp += "bimehno3|" + data["bimehno3"].ToString() + "|";
                        temp += "serial3|" + data["serial3"].ToString() + "|";
                        temp += "expire|3" + data["expire3"].ToString() + "|";

                        temp += "bimeh|4" + data["bimeh4"].ToString() + "|";
                        temp += "bimehno4|" + data["bimehno4"].ToString() + "|";
                        temp += "serial4|" + data["serial4"].ToString() + "|";
                        temp += "expire|4" + data["expire4"].ToString() + "|";

                        temp += "marray|" + data["marray"].ToString() + "|";
                        temp += "child|" + data["child"].ToString() + "|";
                        temp += "bar|" + data["bar"].ToString() + "|";
                        temp += "gender|" + data["gender"].ToString() + "|";
                        temp += "moaref|" + data["moaref"].ToString() + "|";
                        temp += "reception|" + data["reception"].ToString() + "|";
                        temp += "father|" + data["father"].ToString() + "|";
                        temp += "id|" + data["id"].ToString() + "|";
                        temp += "bdate|" + data["bdate"].ToString() + "|";
                        temp += "nid|" + data["nid"].ToString() + "|";
                        temp += "zip|" + data["zip"].ToString() + "|";
                        temp += "city|" + data["city"].ToString() + "|";
                        temp += "sodor|" + data["sodor"].ToString() + "|";
                        temp += "malol|" + data["malol"].ToString() + "|";
                        temp += "adr|" + data["adr"].ToString() + "|";
                        temp += "adr2|" + data["adr2"].ToString() + "|";
                        temp += "adr3|" + data["adr3"].ToString() + "|";
                        temp += "adr4|" + data["adr4"].ToString() + "|";
                        temp += "adr5|" + data["adr5"].ToString() + "|";

                        temp += "tel1|" + data["tel1"].ToString() + "|";
                        temp += "desc1|" + data["desc1"].ToString() + "|";
                        temp += "tel2|" + data["tel2"].ToString() + "|";
                        temp += "desc2|" + data["desc2"].ToString() + "|";
                        temp += "tel3|" + data["tel3"].ToString() + "|";
                        temp += "desc3|" + data["desc3"].ToString() + "|";
                        temp += "tel4|" + data["tel4"].ToString() + "|";
                        temp += "desc4|" + data["desc4"].ToString() + "|";
                        temp += "tel5|" + data["tel5"].ToString() + "|";
                        temp += "desc5|" + data["desc5"].ToString() + "|";
                        temp += "tel6|" + data["tel6"].ToString() + "|";
                        temp += "desc6|" + data["desc6"].ToString() + "|";
                        temp += "tel7|" + data["tel7"].ToString() + "|";
                        temp += "desc7|" + data["desc7"].ToString() + "|";
                        temp += "tel8|" + data["tel8"].ToString() + "|";
                        temp += "desc8|" + data["desc8"].ToString() + "|";
                        temp += "tel9|" + data["tel9"].ToString() + "|";
                        temp += "desc9|" + data["desc9"].ToString() + "|";
                        temp += "tel10|" + data["tel10"].ToString() + "|";
                        temp += "desc10|" + data["desc10"].ToString() + "|";

                        temp += "tahsil|" + data["tahsil"].ToString() + "|";
                        temp += "othercode|" + data["othercode"].ToString() + "|";
                        temp += "life|" + data["life"].ToString() + "|";
                        temp += "busy|" + data["busy"].ToString() + "|";
                        temp += "others|" + data["others"].ToString() + "|";

                        temp += "edr1|" + data["edr1"].ToString() + "|";
                        temp += "email1|" + data["email1"].ToString() + "|";
                        temp += "edr2|" + data["edr2"].ToString() + "|";
                        temp += "email2|" + data["email2"].ToString() + "|";
                        temp += "edr3|" + data["edr3"].ToString() + "|";
                        temp += "email3|" + data["email3"].ToString() + "|";
                        temp += "edr4|" + data["edr4"].ToString() + "|";
                        temp += "email4|" + data["email4"].ToString() + "|";
                        temp += "edr5|" + data["edr5"].ToString() + "|";
                        temp += "email5|" + data["email5"].ToString() + "|";
                        temp += "edr6|" + data["edr6"].ToString() + "|";
                        temp += "email6|" + data["email6"].ToString() + "|";
                        temp += "edr7|" + data["edr7"].ToString() + "|";
                        temp += "email7|" + data["email7"].ToString() + "|";
                        temp += "edr8|" + data["edr8"].ToString() + "|";
                        temp += "email8|" + data["email8"].ToString() + "|";
                        temp += "edr9|" + data["edr9"].ToString() + "|";
                        temp += "email9|" + data["email9"].ToString() + "|";
                        temp += "edr10|" + data["edr10"].ToString() + "|";
                        temp += "email10|" + data["email10"].ToString() + "|";

                        temp += "cc|" + data["cc"].ToString() + "|";
                        temp += "dx|" + data["dx"].ToString() + "|";
                        temp += "pi|" + data["pi"].ToString() + "|";
                        temp += "ph|" + data["ph"].ToString() + "|";
                        temp += "fh|" + data["fh"].ToString() + "|";
                        temp += "pe|" + data["pe"].ToString() + "|";
                        temp += "g|" + data["g"].ToString() + "|";
                        temp += "p|" + data["p"].ToString() + "|";
                        temp += "a|" + data["a"].ToString() + "|";
                        temp += "l|" + data["l"].ToString() + "|";
                        temp += "d|" + data["d"].ToString() + "|";
                        temp += "hc|" + data["hc"].ToString() + "|";
                        temp += "ht|" + data["ht"].ToString() + "|";
                        temp += "wg|" + data["wg"].ToString() + "|";
                        temp += "bp|" + data["bp"].ToString() + "|";
                        temp += "dd|" + data["dd"].ToString() + "|";
                        temp += "dx|" + data["dx"].ToString() + "|";
                        temp += "rx|" + data["rx"].ToString() + "|";
                        temp += "ip|" + data["ip"].ToString() + "|";
                        temp += "op|" + data["op"].ToString() + "|";
                        temp += "pc|" + data["pc"].ToString() + "|";
                    }
                    data.Close();

                    sqlcmd.CommandText = "select * from sick2 where par = '" + sick_par + "' order by visit";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += "visit|" + data["visit"].ToString() + "|";
                        temp += "rdate|" + data["rdate"].ToString() + "|";
                        temp += "sb|" + data["sb"].ToString() + "|";
                        temp += "ob|" + data["ob"].ToString() + "|";
                        temp += "as|" + data["ass"].ToString() + "|";
                        temp += "pl|" + data["pl"].ToString() + "|";
                        temp += "dd2|" + data["dd"].ToString() + "|";
                        temp += "px2|" + data["px"].ToString() + "|";
                        temp += "rx2|" + data["rx"].ToString() + "|";
                        temp += "ip2|" + data["ip"].ToString() + "|";
                        temp += "op2|" + data["op"].ToString() + "|";
                        temp += "co|" + data["co"].ToString() + "|";
                        temp += "pc2|" + data["pc"].ToString() + "|";
                    }

                    data.Close();
                } // End of While(data2.Read())
                data2.Close();

                File.WriteAllText(dlg.FileName, temp);
                sqlconn.Close();
                sqlconn2.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string title, fname, mname, lname,doctor,prf , age, job, bplace, bimeh,bimehno,serial,expire, bimeh2,bimehno2,serial2,expire2, bimeh3,bimehno3,serial3,expire3, bimeh4,bimehno4,serial4,expire4, marray, child, bar, gender, moaref, reception;
            string father, id, bdate, nid, zip, city, sodor, malol, tahsil, othercode, life, busy, others;
            string adr, adr2, adr3, adr4, adr5;
            string tel1, desc1, tel2, desc2, tel3, desc3, tel4, desc4, tel5, desc5, tel6, desc6, tel7, desc7, tel8, desc8, tel9, desc9, tel10, desc10;
            string edr1, email1, edr2, email2, edr3, email3, edr4, email4, edr5, email5, edr6, email6, edr7, email7, edr8, email8, edr9, email9, edr10, email10;
            string cc, dx, pi, ph, fh, pe, g, p, a, l, d, hc, ht, wg, bp, dd, px, rx, ip, op, pc;
            string sb, ob, ass, pl, dd2, px2, rx2, ip2, op2, co, pc2;
            title = fname = mname = lname = age = job = bplace = bimeh = marray = child = bar = gender = moaref = reception = doctor = prf ="";
            father = id = bdate = nid = zip = city = sodor = malol = adr = tahsil = othercode = life = busy = "";
            cc = dx = pi = ph = fh = pe = g = p = a = l = d = hc = ht = wg = bp = dd = px = rx = ip = op = pc = "";
            sb = ob = ass = pl = dd2 = px2 = rx2 = ip2 = op2 = co = pc2 = "";
            tel1 = desc1 = tel2 = desc2 = tel3 = desc3 = tel4 = desc4 = tel5 = desc5 = tel6 = desc6 = tel7 = desc7 = tel8 = desc8 = tel9 = desc9 = tel10 = desc10 = "";
            edr1 = email1 = edr2 = email2 = edr3 = email3 = edr4 = email4 = edr5 = email5 = edr6 = email6 = edr7 = email7 = edr8 = email8 = edr9 = email9 = edr10 = email10 = "";
            bimehno = serial = expire = bimeh2 = bimehno2 = serial2 = expire2 = bimeh3 = bimehno3 = serial3 = expire3 = bimeh4 = bimehno4 = serial4 = expire4 = "";
            others = adr2 = adr3 = adr4 = adr5 = "";

            int visit = 2;
            Int64 par = 0;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for Back up Patient's Files...";
            dlg.Filter = "Clinical Management Back up Files(*.cbk)|*.cbk";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string total_str = File.ReadAllText(dlg.FileName);
                string query;
                string mylabel, mydata;
                int myindex;
                bool flag = true;
                int myindex3;
                while (total_str.Contains("title|") == true)
                {
                    flag = true;
                    //myindex2 = total_str.IndexOf("title|");
                    total_str = total_str.Substring(6, total_str.Length - 6);
                    if(total_str.Contains("title|") == true)
                    {
                        myindex3 = total_str.IndexOf("title|");
                        query = total_str.Substring(0, myindex3);
                        total_str = total_str.Substring(myindex3, total_str.Length - myindex3);
                        query = "title|" + query;
                    }
                    else
                    {
                        query = "title|" + total_str;
                    }
                    try
                    {
                        while (flag == true)
                        {
                            myindex = query.IndexOf('|');
                            mylabel = query.Substring(0, myindex);
                            if (query.Substring(myindex + 1, 1) == "|")
                            {
                                mydata = "";
                                try
                                {
                                    query = query.Substring(myindex + 2, query.Length - myindex - 2);
                                }
                                catch
                                {
                                    query = "";
                                    flag = false;
                                }
                            }
                            else
                            {
                                query = query.Substring(myindex + 1, query.Length - myindex - 1);
                                myindex = query.IndexOf('|');
                                mydata = query.Substring(0, myindex);
                                try
                                {
                                    query = query.Substring(myindex + 1, query.Length - myindex - 1);
                                }
                                catch
                                {
                                    query = "";
                                    flag = false;
                                }
                            }

                            switch (mylabel)
                            {
                                case "title":
                                    {
                                        title = mydata;
                                        break;
                                    }
                                case "fname":
                                    {
                                        fname = mydata;
                                        break;
                                    }
                                case "mname":
                                    {
                                        mname = mydata;
                                        break;
                                    }
                                case "lname":
                                    {
                                        lname = mydata;
                                        break;
                                    }
                                case "doctor":
                                    {
                                        doctor = mydata;
                                        break;
                                    }
                                case "prf":
                                    {
                                        prf = mydata;
                                        break;
                                    }
                                case "bplace":
                                    {
                                        bplace = mydata;
                                        break;
                                    }
                                case "age":
                                    {
                                        age = mydata;
                                        break;
                                    }
                                case "job":
                                    {
                                        job = mydata;
                                        break;
                                    }
                                case "bimeh":
                                    {
                                        bimeh = mydata;
                                        break;
                                    }
                                case "bimehno":
                                    {
                                        bimehno = mydata;
                                        break;
                                    }
                                case "serial":
                                    {
                                        serial = mydata;
                                        break;
                                    }
                                case "expire":
                                    {
                                        expire = mydata;
                                        break;
                                    }
                                case "bimeh2":
                                    {
                                        bimeh2 = mydata;
                                        break;
                                    }
                                case "bimehno2":
                                    {
                                        bimehno2 = mydata;
                                        break;
                                    }
                                case "serial2":
                                    {
                                        serial2 = mydata;
                                        break;
                                    }
                                case "expire2":
                                    {
                                        expire2 = mydata;
                                        break;
                                    }
                                case "bimeh3":
                                    {
                                        bimeh3 = mydata;
                                        break;
                                    }
                                case "bimehno3":
                                    {
                                        bimehno3 = mydata;
                                        break;
                                    }
                                case "serial3":
                                    {
                                        serial3 = mydata;
                                        break;
                                    }
                                case "expire3":
                                    {
                                        expire3 = mydata;
                                        break;
                                    }
                                case "bimeh4":
                                    {
                                        bimeh4 = mydata;
                                        break;
                                    }
                                case "bimehno4":
                                    {
                                        bimehno4 = mydata;
                                        break;
                                    }
                                case "serial4":
                                    {
                                        serial4 = mydata;
                                        break;
                                    }
                                case "expire4":
                                    {
                                        expire4 = mydata;
                                        break;
                                    }

                                case "gender":
                                    {
                                        gender = mydata;
                                        break;
                                    }
                                case "marray":
                                    {
                                        marray = mydata;
                                        break;
                                    }
                                case "child":
                                    {
                                        child = mydata;
                                        break;
                                    }
                                case "bar":
                                    {
                                        bar = mydata;
                                        break;
                                    }
                                case "moaref":
                                    {
                                        moaref = mydata;
                                        break;
                                    }
                                case "reception":
                                    {
                                        reception = mydata;
                                        break;
                                    }
                                case "father":
                                    {
                                        father = mydata;
                                        break;
                                    }
                                case "id":
                                    {
                                        id = mydata;
                                        break;
                                    }
                                case "bdate":
                                    {
                                        bdate = mydata;
                                        break;
                                    }
                                case "nid":
                                    {
                                        nid = mydata;
                                        break;
                                    }
                                case "zip":
                                    {
                                        zip = mydata;
                                        break;
                                    }
                                case "city":
                                    {
                                        city = mydata;
                                        break;
                                    }
                                case "sodor":
                                    {
                                        sodor = mydata;
                                        break;
                                    }
                                case "malol":
                                    {
                                        malol = mydata;
                                        break;
                                    }
                                case "adr":
                                    {
                                        adr = mydata;
                                        break;
                                    }
                                case "adr2":
                                    {
                                        adr2 = mydata;
                                        break;
                                    }
                                case "adr3":
                                    {
                                        adr3 = mydata;
                                        break;
                                    }
                                case "adr4":
                                    {
                                        adr4 = mydata;
                                        break;
                                    }
                                case "adr5":
                                    {
                                        adr5 = mydata;
                                        break;
                                    }

                                case "tel1":
                                    {
                                        tel1 = mydata;
                                        break;
                                    }
                                case "desc1":
                                    {
                                        desc1 = mydata;
                                        break;
                                    }
                                case "tel2":
                                    {
                                        tel2 = mydata;
                                        break;
                                    }
                                case "desc2":
                                    {
                                        desc2 = mydata;
                                        break;
                                    }
                                case "tel3":
                                    {
                                        tel3 = mydata;
                                        break;
                                    }
                                case "desc3":
                                    {
                                        desc3 = mydata;
                                        break;
                                    }
                                case "tel4":
                                    {
                                        tel4 = mydata;
                                        break;
                                    }
                                case "desc4":
                                    {
                                        desc4 = mydata;
                                        break;
                                    }
                                case "tel5":
                                    {
                                        tel5 = mydata;
                                        break;
                                    }
                                case "desc5":
                                    {
                                        desc5 = mydata;
                                        break;
                                    }
                                case "tel6":
                                    {
                                        tel6 = mydata;
                                        break;
                                    }
                                case "desc6":
                                    {
                                        desc6 = mydata;
                                        break;
                                    }
                                case "tel7":
                                    {
                                        tel7 = mydata;
                                        break;
                                    }
                                case "desc7":
                                    {
                                        desc7 = mydata;
                                        break;
                                    }
                                case "tel8":
                                    {
                                        tel8 = mydata;
                                        break;
                                    }
                                case "desc8":
                                    {
                                        desc8 = mydata;
                                        break;
                                    }
                                case "tel9":
                                    {
                                        tel9 = mydata;
                                        break;
                                    }
                                case "desc9":
                                    {
                                        desc9 = mydata;
                                        break;
                                    }
                                case "tel10":
                                    {
                                        tel10 = mydata;
                                        break;
                                    }
                                case "desc10":
                                    {
                                        desc10 = mydata;
                                        break;
                                    }


                                case "tahsil":
                                    {
                                        tahsil = mydata;
                                        break;
                                    }
                                case "othercode":
                                    {
                                        othercode = mydata;
                                        break;
                                    }
                                case "life":
                                    {
                                        life = mydata;
                                        break;
                                    }
                                case "busy":
                                    {
                                        busy = mydata;
                                        break;
                                    }
                                case "others":
                                    {
                                        others = mydata;
                                        break;
                                    }

                                case "edr1":
                                    {
                                        edr1 = mydata;
                                        break;
                                    }
                                case "email1":
                                    {
                                        email1 = mydata;
                                        break;
                                    }
                                case "edr2":
                                    {
                                        edr2 = mydata;
                                        break;
                                    }
                                case "email2":
                                    {
                                        email2 = mydata;
                                        break;
                                    }
                                case "edr3":
                                    {
                                        edr3 = mydata;
                                        break;
                                    }
                                case "email3":
                                    {
                                        email3 = mydata;
                                        break;
                                    }
                                case "edr4":
                                    {
                                        edr4 = mydata;
                                        break;
                                    }
                                case "email4":
                                    {
                                        email4 = mydata;
                                        break;
                                    }
                                case "edr5":
                                    {
                                        edr5 = mydata;
                                        break;
                                    }
                                case "email5":
                                    {
                                        email5 = mydata;
                                        break;
                                    }
                                case "edr6":
                                    {
                                        edr6 = mydata;
                                        break;
                                    }
                                case "email6":
                                    {
                                        email6 = mydata;
                                        break;
                                    }
                                case "edr7":
                                    {
                                        edr7 = mydata;
                                        break;
                                    }
                                case "email7":
                                    {
                                        email7 = mydata;
                                        break;
                                    }
                                case "edr8":
                                    {
                                        edr8 = mydata;
                                        break;
                                    }
                                case "email8":
                                    {
                                        email8 = mydata;
                                        break;
                                    }
                                case "edr9":
                                    {
                                        edr9 = mydata;
                                        break;
                                    }
                                case "email9":
                                    {
                                        email9 = mydata;
                                        break;
                                    }
                                case "edr10":
                                    {
                                        edr10 = mydata;
                                        break;
                                    }
                                case "email10":
                                    {
                                        email10 = mydata;
                                        break;
                                    }
                                ////////
                                case "cc":
                                    {
                                        cc = mydata;
                                        break;
                                    }
                                case "dx":
                                    {
                                        dx = mydata;
                                        break;
                                    }
                                case "pi":
                                    {
                                        pi = mydata;
                                        break;
                                    }
                                case "ph":
                                    {
                                        ph = mydata;
                                        break;
                                    }
                                case "fh":
                                    {
                                        fh = mydata;
                                        break;
                                    }
                                case "pe":
                                    {
                                        pe = mydata;
                                        break;
                                    }
                                case "g":
                                    {
                                        g = mydata;
                                        break;
                                    }
                                case "p":
                                    {
                                        p = mydata;
                                        break;
                                    }
                                case "a":
                                    {
                                        a = mydata;
                                        break;
                                    }
                                case "l":
                                    {
                                        l = mydata;
                                        break;
                                    }
                                case "d":
                                    {
                                        d = mydata;
                                        break;
                                    }
                                case "hc":
                                    {
                                        hc = mydata;
                                        break;
                                    }
                                case "wg":
                                    {
                                        wg = mydata;
                                        break;
                                    }
                                case "bp":
                                    {
                                        bp = mydata;
                                        break;
                                    }
                                case "dd":
                                    {
                                        dd = mydata;
                                        break;
                                    }
                                case "px":
                                    {
                                        px = mydata;
                                        break;
                                    }
                                case "rx":
                                    {
                                        rx = mydata;
                                        break;
                                    }
                                case "ip":
                                    {
                                        ip = mydata;
                                        break;
                                    }
                                case "op":
                                    {
                                        op = mydata;
                                        break;
                                    }
                                case "pc":
                                    {
                                        pc = mydata;
                                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                                        sqlconn.Open();
                                        SqlCommand sqlcmd = new SqlCommand();
                                        sqlcmd.Connection = sqlconn;
                                        sqlcmd.CommandText = "Insert into sick1(doctor,prf,title,fname,mname,lname,age,job,bplace,bimeh,marray,child,bar,gender,moaref,reception,father,id,bdate,nid,zip,city,sodor,malol,adr,tahsil,othercode,life,busy,cc,dx,pi,ph,fh,pe,g,p,a,l,d,hc,ht,wg,bp,dd,px,rx,ip,op,pc,bimehno,serial,expire,bimeh2,bimehno2,serial2,expire2,bimeh3,bimehno3,serial3,expire3,bimeh4,bimehno4,serial4,expire4,adr2,adr3,adr4,adr5,tel1,desc1,tel2,desc2,tel3,desc3,tel4,desc4,tel5,desc5,tel6,desc6,tel7,desc7,tel8,desc8,tel9,desc9,tel10,desc10,others,edr1,email1,edr2,email2,edr3,email3,edr4,email4,edr5,email5,edr6,email6,edr7,email7,edr8,email8,edr9,email9,edr10,email10) values('"+ doctor +"','"+ prf +"','" + title + "','" + fname + "','" + mname + "','" + lname + "','" + age + "','" + job + "','" + bplace + "','" + bimeh + "','" + marray + "','" + child + "','" + bar + "','" + gender + "','" + moaref + "','" + reception + "','" + father + "','" + id + "','" + bdate + "','" + nid + "','" + zip + "','" + city + "','" + sodor + "','" + malol + "','" + adr + "','" + tahsil + "','" + othercode + "','" + life + "','" + busy + "','" + cc + "','" + dx + "','" + pi + "','" + ph + "','" + fh + "','" + pe + "','" + g + "','" + p + "','" + a + "','" + l + "','" + d + "','" + hc + "','" + ht + "','" + wg + "','" + bp + "','" + dd + "','" + px + "','" + rx + "','" + ip + "','" + op + "','" + pc + "','" + bimehno + "','" + serial + "','" + expire + "','" + bimeh2 + "','" + bimehno2 + "','" + serial2 + "','" + expire2 + "','" + bimeh3 + "','" + bimehno3 + "','" + serial3 + "','" + expire3 + "','" + bimeh4 + "','" + bimehno4 + "','" + serial4 + "','" + expire4 + "','" + adr2 + "','" + adr3 + "','" + adr4 + "','" + adr5 + "','" + tel1 + "','" + desc1 + "','" + tel2 + "','" + desc2 + "','" + tel3 + "','" + desc3 + "','" + tel4 + "','" + desc4 + "','" + tel5 + "','" + desc5 + "','" + tel6 + "','" + desc6 + "','" + tel7 + "','" + desc7 + "','" + tel8 + "','" + desc8 + "','" + tel9 + "','" + desc9 + "','" + tel10 + "','" + desc10 + "','" + others + "','" + edr1 + "','" + email1 + "','" + edr2 + "','" + email2 + "','" + edr3 + "','" + email3 + "','" + edr4 + "','" + email4 + "','" + edr5 + "','" + email5 + "','" + edr6 + "','" + email6 + "','" + edr7 + "','" + email7 + "','" + edr8 + "','" + email8 + "','" + edr9 + "','" + email9 + "','" + edr10 + "','" + email10 + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                        sqlconn.Close();

                                        flag = false;

                                        break;
                                    }
                            } // End Of Switch Case 1

                        } // End of While 1


                        if (query != "")
                        {
                            flag = true;
                            string rdate = "";
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;
                            sqlcmd.CommandText = "Select max(par) from sick1";
                            par = Int64.Parse(sqlcmd.ExecuteScalar().ToString());
                            sqlconn.Close();

                            while (flag == true)
                            {
                                if (query == "")
                                    break;
                                myindex = query.IndexOf('|');
                                mylabel = query.Substring(0, myindex);
                                if (query.Substring(myindex + 1, 1) == "|")
                                {
                                    mydata = "";
                                    try
                                    {
                                        query = query.Substring(myindex + 2, query.Length - myindex - 2);
                                    }
                                    catch
                                    {
                                        query = "";
                                        flag = false;
                                    }
                                }
                                else
                                {
                                    query = query.Substring(myindex + 1, query.Length - myindex - 1);
                                    myindex = query.IndexOf('|');
                                    mydata = query.Substring(0, myindex);
                                    try
                                    {
                                        query = query.Substring(myindex + 1, query.Length - myindex - 1);
                                    }
                                    catch
                                    {
                                        query = "";
                                        flag = false;
                                    }
                                }

                                switch (mylabel)
                                {
                                    case "visit":
                                        {
                                            visit = Int32.Parse(mydata);
                                            break;
                                        }
                                    case "rdate":
                                        {
                                            rdate = mydata;
                                            break;
                                        }

                                    case "sb":
                                        {
                                            sb = mydata;
                                            break;
                                        }
                                    case "ob":
                                        {
                                            ob = mydata;
                                            break;
                                        }
                                    case "as":
                                        {
                                            ass = mydata;
                                            break;
                                        }
                                    case "pl":
                                        {
                                            pl = mydata;
                                            break;
                                        }
                                    case "dd2":
                                        {
                                            dd2 = mydata;
                                            break;
                                        }
                                    case "px2":
                                        {
                                            px2 = mydata;
                                            break;
                                        }
                                    case "rx2":
                                        {
                                            rx2 = mydata;
                                            break;
                                        }
                                    case "ip2":
                                        {
                                            ip2 = mydata;
                                            break;
                                        }
                                    case "op2":
                                        {
                                            op2 = mydata;
                                            break;
                                        }
                                    case "co":
                                        {
                                            co = mydata;
                                            break;
                                        }
                                    case "pc2":
                                        {
                                            pc2 = mydata;
                                            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
                                            sqlconn2.Open();
                                            SqlCommand sqlcmd2 = new SqlCommand();
                                            sqlcmd2.Connection = sqlconn2;
                                            sqlcmd2.CommandText = "Insert into sick2(par,visit,rdate,sb,ob,ass,pl,dd,px,rx,ip,op,co,pc) values('" + par + "','" + visit + "','" + rdate + "','" + sb + "','" + ob + "','" + ass + "','" + pl + "','" + dd2 + "','" + px2 + "','" + rx2 + "','" + ip2 + "','" + op2 + "','" + co + "','" + pc2 + "') ";
                                            sqlcmd2.ExecuteNonQuery();
                                            sqlcmd2.CommandText = "select count(*) from var1 where par = '" + par + "' ";
                                            if (sqlcmd2.ExecuteScalar().ToString() == "0")
                                            {
                                                sqlcmd2.CommandText = "Insert into var1(par,lastvisit) values('" + par + "','" + visit + "')";
                                                sqlcmd2.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                sqlcmd2.CommandText = "Update var1 set lastvisit = '" + visit + "' where par = '" + par + "' ";
                                                sqlcmd2.ExecuteNonQuery();
                                            }
                                            sqlconn2.Close();
                                            break;
                                        }
                                } // End of switch case 2
                            } // End of While 2
                        } // End of if(Query != "")
                    }
                    catch
                    {
                        MessageBox.Show("متاسفانه پرونده قابل بازيابي نمي باشد");
                    }
                }

                // Reload Grid
                Medical_File_Closet_Load(sender, e);

               
              


            }// End  of If(saveDialog == OK)
        }

    }
}