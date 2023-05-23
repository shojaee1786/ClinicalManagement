using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarsiLibrary.Utils;
using System.Data.SqlClient;

namespace Clinical_Management
{
    public partial class Paziresh : Form
    {
        public static object[] paziresh_row = new object[25];
        public static bool paziresh_flag = false;
        public static bool paziresh_edit_flag = false;
        public static bool paziresh_to_pp, paziresh_to_pj;
        public static string pp_row;
        public static string pp_par;

        public Paziresh()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);
            // int i;
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                switch (e.ColumnIndex)
                {
                    ///// ›—„ ⁄„ÊœÌ ////
                    case 0:
                        {
                            timer1.Enabled = false;

                            paziresh_row[0] = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                            paziresh_row[1] = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                            paziresh_row[2] = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                            paziresh_row[3] = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                            paziresh_row[4] = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                            paziresh_row[5] = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
                            paziresh_row[6] = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                            paziresh_row[7] = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
                            paziresh_row[8] = dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString();
                            paziresh_row[9] = dataGridView2.Rows[e.RowIndex].Cells[16].Value.ToString();
                            paziresh_row[10] = dataGridView2.Rows[e.RowIndex].Cells[17].Value.ToString();
                            paziresh_row[11] = dataGridView2.Rows[e.RowIndex].Cells[18].Value.ToString();
                            paziresh_row[12] = dataGridView2.Rows[e.RowIndex].Cells[19].Value.ToString();
                            paziresh_row[13] = dataGridView2.Rows[e.RowIndex].Cells[20].Value.ToString();
                            paziresh_row[14] = dataGridView2.Rows[e.RowIndex].Cells[21].Value.ToString();
                            paziresh_row[15] = dataGridView2.Rows[e.RowIndex].Cells[22].Value.ToString();
                            paziresh_row[16] = dataGridView2.Rows[e.RowIndex].Cells[23].Value.ToString();
                            paziresh_row[17] = dataGridView2.Rows[e.RowIndex].Cells[24].Value.ToString();

                            paziresh2.myrow = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                            paziresh2 frm = new paziresh2();
                            frm.ShowDialog();
                            if (paziresh_edit_flag == true)
                            {
                                paziresh_edit_flag = false;
                                //for (i = 6; i <= 22; i++)
                                //{
                                //    dataGridView2.Rows[e.RowIndex].Cells[i].Value = paziresh_row[i].ToString();
                                //}
                                this.pazireshTableAdapter.FillBy(this.cmDataSet12.paziresh);
                            }
                            timer1.Enabled = true;
                            break;
                        }
                    case 1:
                        {
                            Del_Paz frm = new Del_Paz();
                            frm.ShowDialog();

                            if (Del_Paz.del_confirm == true)
                            {
                                SqlConnection sqlconn = new SqlConnection(cm.cs);
                                sqlconn.Open();

                                SqlCommand sqlcmd = new SqlCommand();
                                sqlcmd.Connection = sqlconn;
                                sqlcmd.CommandText = "Delete from paziresh where date1='" + today + "' and row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' ";
                                sqlcmd.ExecuteNonQuery();
                                this.pazireshTableAdapter.FillBy(this.cmDataSet12.paziresh);
                                sqlconn.Close();
                            }
                            break;
                        }
                    //////// «‰ Œ«» Å“‘ﬂ //////
                    case 3:
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();

                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;

                            bool exitflag = false;
                            //this.pazireshTableAdapter.FillBy(this.cmDataSet12.paziresh);

                            if (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() == "")
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (dataGridView2.Rows[i].Cells[3].Value.ToString() == "Ê—Êœ" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Ê—Êœ")
                                        exitflag = true;
                                }
                                if (exitflag == true)
                                    return;

                                dataGridView2.Rows[e.RowIndex].Cells[3].Value = "Ê—Êœ";
                                dataGridView2.Rows[e.RowIndex].Cells[5].Value = "«‘€«·";

                                sqlcmd.CommandText = "Update paziresh set dselect = 'Ê—Êœ' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                sqlcmd.ExecuteNonQuery();
                                sqlcmd.CommandText = "Update paziresh set mselect = '«‘€«·' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            else
                                if (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() == "Ê—Êœ")
                                {
                                    dataGridView2.Rows[e.RowIndex].Cells[3].Value = "«‘€«·";
                                    sqlcmd.CommandText = "Update paziresh set dselect = '«‘€«·' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                                else
                                    if (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() == "«‘€«·")
                                    {
                                        dataGridView2.Rows[e.RowIndex].Cells[3].Value = "« „«„";
                                        dataGridView2.Rows[e.RowIndex].Cells[5].Value = "« „«„";
                                        sqlcmd.CommandText = "Update paziresh set dselect = '« „«„' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                        sqlcmd.ExecuteNonQuery();

                                        sqlcmd.CommandText = "Update paziresh set mselect = '« „«„' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                            //else
                            //    if (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() == "« „«„")
                            //    {
                            //        dataGridView2.Rows[e.RowIndex].Cells[3].Value = "";
                            //        sqlcmd.CommandText = "Update paziresh set dselect = '' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                            //        sqlcmd.ExecuteNonQuery();
                            //    }

                            sqlconn.Close();
                            break;
                        }
                    /////// Patient Profile ///////
                    case 4:
                        {
                            if (Patient.IsOpen == true)
                            {
                                alert2 frm2 = new alert2();
                                frm2.ShowDialog();
                                return;
                            }

                            Patient.first = false;
                            try
                            {
                                Patient.par = Int64.Parse(dataGridView2.Rows[e.RowIndex].Cells[24].Value.ToString());
                            }
                            catch
                            {
                                Patient.first = true;
                                Patient.par = 0;
                            }

                            paziresh_to_pp = true;
                            Patient.pp_paz_row = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();


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
                            break;
                        }
                    ////// «‰ Œ«» „‰‘Ì //////
                    case 5:
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();

                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;
                            bool exitflag = false;
                            if (dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString() == "")
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (dataGridView2.Rows[i].Cells[3].Value.ToString() == "Ê—Êœ" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Ê—Êœ")
                                        exitflag = true;
                                }
                                if (exitflag == true)
                                    return;

                                dataGridView2.Rows[e.RowIndex].Cells[5].Value = "Ê—Êœ";
                                dataGridView2.Rows[e.RowIndex].Cells[3].Value = "«‘€«·";

                                sqlcmd.CommandText = "Update paziresh set mselect = 'Ê—Êœ' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                sqlcmd.ExecuteNonQuery();

                                sqlcmd.CommandText = "Update paziresh set dselect = '«‘€«·' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            //else
                            //    if (dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString() == "Ê—Êœ")
                            //    {
                            //        dataGridView2.Rows[e.RowIndex].Cells[5].Value = "«‘€«·";
                            //        sqlcmd.CommandText = "Update paziresh set mselect = '«‘€«·' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                            //        sqlcmd.ExecuteNonQuery();
                            //    }
                            //    else
                            //        if (dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString() == "«‘€«·")
                            //        {
                            //            dataGridView2.Rows[e.RowIndex].Cells[5].Value = "« „«„";
                            //            sqlcmd.CommandText = "Update paziresh set mselect = '« „«„' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                            //            sqlcmd.ExecuteNonQuery();
                            //        }
                            //        //else
                            //        //    if (dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString() == "« „«„")
                            //        //    {
                            //        //        dataGridView2.Rows[e.RowIndex].Cells[5].Value = null;
                            //        //        sqlcmd.CommandText = "Update paziresh set mselect = '' where row = '" + dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and date1 = '" + today + "' ";
                            //        //        sqlcmd.ExecuteNonQuery();
                            //        //    }
                            sqlconn.Close();
                            break;
                        }
                    ////// Å—Ê‰œÂ ÃœÌœ //////
                    case 6:
                        {

                            paziresh_to_pj = true;
                            pp_par = dataGridView2.Rows[e.RowIndex].Cells[24].Value.ToString();
                            pp_row = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                            all_info frm = new all_info();
                            frm.Show();

                            break;
                        }
                } // End of Switch Case

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            paziresh2 frm = new paziresh2();
            paziresh2.insert_mode = true;
            frm.ShowDialog();
            this.pazireshTableAdapter.FillBy(this.cmDataSet12.paziresh);

            timer1.Enabled = true;


            //if (paziresh_flag == true)
            //{
            //    paziresh_row[0] = "";
            //    paziresh_row[1] = " ";
            //    paziresh_row[2] = "";
            //    paziresh_row[3] = "";
            //    paziresh_row[4] = "";
            //    paziresh_row[5] = "";
            //    paziresh_flag = false;
            //    dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1,paziresh_row);
            //}
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                Int64 visit = 0, consult = 0, service1 = 0, service2 = 0, income = 0, ret = 0;
                try
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        visit += Int32.Parse(dataGridView2.Rows[i].Cells[18].Value.ToString());
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        consult += Int32.Parse(dataGridView2.Rows[i].Cells[19].Value.ToString());
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        service1 += Int32.Parse(dataGridView2.Rows[i].Cells[20].Value.ToString());
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        service2 += Int32.Parse(dataGridView2.Rows[i].Cells[21].Value.ToString());
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        income += Int32.Parse(dataGridView2.Rows[i].Cells[22].Value.ToString());
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        ret += Int32.Parse(dataGridView2.Rows[i].Cells[23].Value.ToString());
                    }
                }
                catch { }
                total.visit = visit;
                total.consult = consult;
                total.service1 = service1;
                total.service2 = service2;
                total.income = income;
                total.ret = ret;
                total frm = new total();
                frm.ShowDialog();
            }
        }

        private void Paziresh_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
            //paziresh_flag = false;
            paziresh_to_pp = false;
            paziresh_to_pj = false;
            pp_par = "";
            pp_row = "";

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

            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                for (int i = 0; i < 24; i++)
                    dataGridView2.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
            }
            data.Close();

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);
            sqlcmd.CommandText = "Update paziresh set date2 = '" + today + "' ";
            sqlcmd.ExecuteNonQuery();

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


            //sqlcmd.CommandText = "select * from paziresh where date1='"+ today +"' ";
            //data = sqlcmd.ExecuteReader();
            //dataGridView2.Rows.Clear();
            //while (data.Read())
            //{
            //    paziresh_row[0] = "";
            //    paziresh_row[1] = data["row"].ToString();
            //    paziresh_row[2] = "";
            //    paziresh_row[3] = "";
            //    paziresh_row[4] = "";
            //    paziresh_row[5] = "";
            //    paziresh_row[6] = data["title"].ToString();
            //    paziresh_row[7] = data["fname"].ToString();
            //    paziresh_row[8] = data["family"].ToString();
            //    paziresh_row[9] = data["cause"].ToString();
            //    paziresh_row[10] = data["doctor"].ToString();
            //    paziresh_row[11] = data["prf"].ToString();
            //    paziresh_row[12] = data["bimeh"].ToString();
            //    paziresh_row[13] = data["bimehno"].ToString();
            //    paziresh_row[14] = data["expire"].ToString();
            //    paziresh_row[15] = data["serial"].ToString();
            //    paziresh_row[16] = data["nid"].ToString();
            //    paziresh_row[17] = data["visit"].ToString();
            //    paziresh_row[18] = data["consult"].ToString();
            //    paziresh_row[19] = data["service1"].ToString();
            //    paziresh_row[20] = data["service2"].ToString();
            //    paziresh_row[21] = data["income"].ToString();
            //    paziresh_row[22] = data["ret"].ToString();
            //    paziresh_row[23] = data["par"].ToString();

            //    dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, paziresh_row);
            //}
            //data.Close();

            sqlconn.Close();
            this.pazireshTableAdapter.FillBy(this.cmDataSet12.paziresh);
            timer1.Enabled = true;

        }

        private void Paziresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14,c15,c16,c17,c18,c19,c20,c21,c22,c23,c24) values('" + this.Name + "','" + dataGridView2.Columns[0].Width + "','" + dataGridView2.Columns[1].Width + "','" + dataGridView2.Columns[2].Width + "','" + dataGridView2.Columns[3].Width + "','" + dataGridView2.Columns[4].Width + "','" + dataGridView2.Columns[5].Width + "','" + dataGridView2.Columns[6].Width + "','" + dataGridView2.Columns[7].Width + "','" + dataGridView2.Columns[8].Width + "','" + dataGridView2.Columns[9].Width + "','" + dataGridView2.Columns[10].Width + "','" + dataGridView2.Columns[11].Width + "','" + dataGridView2.Columns[12].Width + "','" + dataGridView2.Columns[13].Width + "','" + dataGridView2.Columns[14].Width + "','" + dataGridView2.Columns[15].Width + "','" + dataGridView2.Columns[16].Width + "','" + dataGridView2.Columns[17].Width + "','" + dataGridView2.Columns[18].Width + "','" + dataGridView2.Columns[19].Width + "','" + dataGridView2.Columns[20].Width + "','" + dataGridView2.Columns[21].Width + "','" + dataGridView2.Columns[22].Width + "','" + dataGridView2.Columns[23].Width + "')";
            sqlcmd.ExecuteNonQuery();

            //PersianDate pd = PersianDate.Now;
            //string today;
            //today = pd.ToString().Substring(0, 10);

            //sqlcmd.CommandText = "Delete from paziresh where date1 = '"+today+"' ";
            //sqlcmd.ExecuteNonQuery();

            //for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //{
            //    sqlcmd.CommandText = "insert into paziresh(date1,row,title,fname,family,cause,doctor,prf,bimeh,bimehno,expire,serial,nid,visit,consult,service1,service2,income,ret,par) values('"+ today +"','" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[22].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[23].Value.ToString() + "')";
            //    sqlcmd.ExecuteNonQuery();
            //}

            sqlconn.Close();

        }

        private void Paziresh_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //SqlConnection sqlconn = new SqlConnection(cm.cs);
            //sqlconn.Open();
            //SqlCommand sqlcmd = new SqlCommand("delete paziresh where fname = '" + e.Row.Cells[7].Value.ToString() + "' and family = '" + e.Row.Cells[8].Value.ToString() + "'", sqlconn);
            //sqlcmd.ExecuteNonQuery();
            //sqlconn.Close();
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 6; i <= 16; i++)
            {

                if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value == null)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = " ";
                }
            }


            if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[1].Value == null)
            {
                dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[1].Value = " ";
            }
            if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[23].Value == null)
            {
                dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[23].Value = " ";
            }
            for (int i = 17; i <= 22; i++)
            {

                if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value == null)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = "0";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.pazireshTableAdapter.FillBy(this.cmDataSet12.paziresh);

            try
            {
                // Scroll to the last row
                dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
                // Select the last row
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Selected = true;
            }
            catch { }

        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {

            }
            //e.NewValue = 100;
        }





    }
}