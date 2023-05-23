using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PrintControl;
using System.Drawing.Printing;

namespace Clinical_Management
{
    public partial class Print_DP : Form
    {
        private static int mycolumn;
        public Print_DP()
        {
            InitializeComponent();
        }

        private void Print_DP_Load(object sender, EventArgs e)
        {
            mycolumn = 0;

            doctor_c.Items.Clear();
            

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

            sqlcmd.CommandText = "select distinct bimeh from info where bimeh<>'' ";
            data = sqlcmd.ExecuteReader();
            int i =0;
            while (data.Read())
            {
                bimeh_c.Items.Insert(i, data["bimeh"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct moaref from info where moaref<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                moaref_c.Items.Insert(i, data["moaref"].ToString());
                i++;
            }
            data.Close();


            if (login.log_username != "admin")
            {
                doctor_c.Text = "œﬂ — " + login.log_name + " " + login.log_family;
                doctor_c.Enabled = false;
            }
            else
            {
                sqlcmd.CommandText = "select distinct doctor from paziresh where doctor<>'' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    doctor_c.Items.Add(data["doctor"].ToString());
                }
                data.Close();
            }

            sqlconn.Close();
        }

        private void Print_DP_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void ok_b_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (sday.Text == "" || smonth.Text == "" || syear.Text == "" || fday.Text == "" || fmonth.Text == "" || fyear.Text == "")
            {
                MessageBox.Show("·ÿ›«  «—ÌŒ —« »Â œ—” Ì Ê«—œ ‰„«ÌÌœ");
                return;
            }
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            sqlcmd.CommandText = "Update paziresh set flag = 0 ";
            sqlcmd.ExecuteNonQuery();

            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            sqlconn2.Open();
            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;

            Int64 start_date = cm.date2day(syear.Text + "/" + smonth.Text + "/" + sday.Text);
            Int64 finish_date = cm.date2day(fyear.Text + "/" + fmonth.Text + "/" + fday.Text);
            Int64 mydate;
            string s;

            sqlcmd.CommandText = "Select date1 from paziresh where date1<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["date1"].ToString();
                mydate = cm.date2day(s);
                if (mydate >= start_date && mydate <= finish_date)
                {
                    sqlcmd2.CommandText = "Update paziresh set flag = 1 where date1 = '"+ s +"' ";
                    sqlcmd2.ExecuteNonQuery();
                }
            }
            data.Close();
            
            sqlconn2.Close();


            string condition = "where flag = 1 and doctor = '" + doctor_c.Text +"' ";
            if (bimeh_r.Checked == true)
                condition += " and bimeh = '" + bimeh_c.Text + "'";

            if (moaref_r.Checked == true)
                condition += " and moaref = '" + moaref_c.Text + "'";

            object[] ob = new object[20];
            string mytemp = "Select * from paziresh " + condition;
            sqlcmd.CommandText = mytemp;
            data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    switch (dataGridView1.Columns[j].HeaderText)
                    {
                        case "—œÌ›":
                            {
                                ob[j] = (i+1).ToString();
                                break;
                            }
                        case " «—ÌŒ ÊÌ“Ì ":
                            {
                                ob[j] = data["date1"].ToString();
                                break;
                            }
                        case "‰«„":
                            {
                                ob[j] = data["fname"].ToString();
                                break;
                            }
                        case "‰«„ Œ«‰Ê«œêÌ":
                            {
                                ob[j] = data["family"].ToString();
                                break;
                            }

                        case " «—ÌŒ «⁄ »«—":
                            {
                                ob[j] = data["expire"].ToString();
                                break;
                            }
                        case "‘„«—Â œ› —çÂ »Ì„Â":
                            {
                                ob[j] = data["bimehno"].ToString();
                                break;
                            }
                        case "‘„«—Â ”—Ì«· »Ì„Â":
                            {
                                ob[j] = data["serial"].ToString();
                                break;
                            }
                        case "Õﬁ ÊÌ“Ì ":
                            {
                                ob[j] = data["visit"].ToString();
                                break;
                            }
                        case "Õﬁ „‘«Ê—Â":
                            {
                                ob[j] = data["consult"].ToString();
                                break;
                            }
                        case "”—ÊÌ”Â«Ì œÌê—":
                            {
                                ob[j] = data["service1"].ToString();
                                break;
                            }
                        case "”—ÊÌ”Â«Ì œÌê—*":
                            {
                                ob[j] = data["service2"].ToString();
                                break;
                            }
                        case "œ—¬„œÂ«Ì œÌê—":
                            {
                                ob[j] = data["income"].ToString();
                                break;
                            }

                        default:
                            {
                                ob[j] = "";
                                break;
                            }
                    } // End of Switch
                } // End of For
                dataGridView1.Rows.Insert(i,ob);
                i++;
            } // End of While(data.Read())
            data.Close();

            sqlconn.Close();
        }

        private void row_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (row_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "—œÌ›";
                    mycolumn++;
                }
            }
            catch { }
           
        }

        private void date_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (date_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = " «—ÌŒ ÊÌ“Ì ";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void name_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (name_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "‰«„";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void family_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (family_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "‰«„ Œ«‰Ê«œêÌ";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void expire_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (expire_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = " «—ÌŒ «⁄ »«—";
                    mycolumn++;
                }
            }
            catch { }
        }


        private void bimehno_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (bimehno_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "‘„«—Â œ› —çÂ »Ì„Â";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void serial_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (serial_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "‘„«—Â ”—Ì«· »Ì„Â";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void visit_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (visit_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "Õﬁ ÊÌ“Ì ";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void consult_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (consult_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "Õﬁ „‘«Ê—Â";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void service1_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (service1_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "”—ÊÌ”Â«Ì œÌê—";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void service2_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (service2_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "”—ÊÌ”Â«Ì œÌê—*";
                    mycolumn++;
                }
            }
            catch { }

        }

        private void income_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (income_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = "œ—¬„œÂ«Ì œÌê—";
                    mycolumn++;
                }
            }
            catch { }
        }

        private void empty_ch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (empty_ch.Checked == true)
                {
                    dataGridView1.Columns[mycolumn].HeaderText = empty_t.Text;
                    mycolumn++;
                }
            }
            catch { }
        }

        private void print_b_Click(object sender, EventArgs e)
        {
            cm.Print_DataGridView(dataGridView1);

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string temp = "";
            int i;
            for (i = 1; i <= dataGridView1.ColumnCount; i++)
            {
                if (dataGridView1.Columns[i-1].HeaderText != "")
                {
                    temp += dataGridView1.Columns[i - 1].HeaderText + "    ";
                }
            }

            e.Graphics.DrawString(temp, new Font("Arial", 12, System.Drawing.FontStyle.Bold), Brushes.Black, 800, 100, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            temp = "-----------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(temp, new Font("Arial", 12, System.Drawing.FontStyle.Bold), Brushes.Black, 800, 120, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            temp ="";
            for (i = 1; i <= dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j <= dataGridView1.Columns.Count; j++)
                {
                    try
                    {
                        temp += dataGridView1.Rows[i - 1].Cells[j - 1].Value.ToString() + "    ";
                    }
                    catch { }
                }

                e.Graphics.DrawString(temp, new Font("Arial", 12, System.Drawing.FontStyle.Bold), Brushes.Black, 800, 120 + (i*50), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                temp = "-----------------------------------------------------------------------------------------------------------------------------------";
                e.Graphics.DrawString(temp, new Font("Arial", 12, System.Drawing.FontStyle.Bold), Brushes.Black, 800, 120 + (i * 50) + 20, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                temp = "";
                

            }
        }
    }
}