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
    public partial class DrugStore : Form
    {
        public DrugStore()
        {
            InitializeComponent();
        }

        private void DrugStore_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct name from category where name<>'' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                cat_c.Items.Insert(i, data["name"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select * from temp where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();

            form_l.Items.Clear();
            form_t.Text = "";
            sqlcmd.CommandText = "select distinct form from drug_tmp where form<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                form_l.Items.Insert(i, data["form"].ToString());
                i++;
            }
            data.Close();

            strength_l.Items.Clear();
            strength_t.Text = "";
            sqlcmd.CommandText = "select distinct strength from drug_tmp where strength<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                strength_l.Items.Insert(i, data["strength"].ToString());
                i++;
            }
            data.Close();

            frequency_l.Items.Clear();
            frequency_t.Text = "";
            sqlcmd.CommandText = "select distinct frequency from drug_tmp where frequency<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                frequency_l.Items.Insert(i, data["frequency"].ToString());
                i++;
            }
            data.Close();

            period_l.Items.Clear();
            period_t.Text = "";
            sqlcmd.CommandText = "select distinct period from drug_tmp where period<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                period_l.Items.Insert(i, data["period"].ToString());
                i++;
            }
            data.Close();

            route_l.Items.Clear();
            route_t.Text = "";
            sqlcmd.CommandText = "select distinct route from drug_tmp where route<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                route_l.Items.Insert(i, data["route"].ToString());
                i++;
            }
            data.Close();


            sig_l.Items.Clear();
            sig_t.Text = "";
            sqlcmd.CommandText = "select distinct sig from drug_tmp where sig<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                sig_l.Items.Insert(i, data["sig"].ToString());
                i++;
            }
            data.Close();

            fadesc_t.Text = "";
            sqlcmd.CommandText = "select distinct fadesc from drug_tmp where fadesc<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                fadesc_t.AutoCompleteCustomSource.Add(data["fadesc"].ToString());
            data.Close();

            gendesc_t.Text = "";
            sqlcmd.CommandText = "select distinct gendesc from drug_tmp where gendesc<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                gendesc_t.AutoCompleteCustomSource.Add(data["gendesc"].ToString());
            data.Close();

            alarm_t.Text = "";
            sqlcmd.CommandText = "select distinct alarm from drug_tmp where alarm<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                alarm_t.AutoCompleteCustomSource.Add(data["alarm"].ToString());
            data.Close();

            advise_t.Text = "";
            sqlcmd.CommandText = "select distinct advise from drug_tmp where advise<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                advise_t.AutoCompleteCustomSource.Add(data["advise"].ToString());
            data.Close();

            // Fill Drug2 Combo
            sqlcmd.CommandText = "select distinct name from generic2 where name<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                string s = data["name"].ToString();
                inter_c.Items.Insert(i, s.Substring(s.IndexOf("?") + 1 ,s.Length - s.IndexOf("?") - 1));
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select side_inter from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                i = Int32.Parse(data["side_inter"].ToString());
            data.Close();

            if (i == 1)
            {
                active_r.Checked = true;
            }
            else
            {
                inactive_r.Checked = true;
            }

            sqlconn.Close();

        }

        private void cat_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            gen_c.Text = "";
            gen_c.Items.Clear();
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand("select generic from category where name='" + cat_c.Text + "' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            string s;
            int i = 0, myindex = 0;
            while (data.Read())
            {
                s = data["generic"].ToString();
                while (s != "")
                {
                    myindex = s.IndexOf('?');
                    gen_c.Items.Insert(i, s.Substring(0, myindex));
                    i++;

                    if (s.Length <= (myindex + 1))
                        s = "";
                    else
                        s = s.Substring(myindex + 1, s.Length - (myindex + 1));
                }
            }
            data.Close();
            sqlconn.Close();
        }

        private void gen_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            dosage_t.Text = "";
            sidecolor_c.Text = "";
            side_t.Text = "";
            sideexp_t.Text = "";
            trade_c.Text = "";
            intercolor_c.Text = "";
            inter_c.Text = "";
            interexp_t.Text = "";
            
            
            trade_c.Items.Clear();
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            string ttt = cat_c.Text + "?" + gen_c.Text;
            SqlCommand sqlcmd = new SqlCommand("select trade from generic where name='" + ttt + "' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            string s;
            int i = 0, myindex = 0;
            while (data.Read())
            {
                s = data["trade"].ToString();
                while (s != "")
                {
                    myindex = s.IndexOf('?');
                    trade_c.Items.Insert(i, s.Substring(0, myindex));
                    i++;

                    if (s.Length <= (myindex + 1))
                        s = "";
                    else
                        s = s.Substring(myindex + 1, s.Length - (myindex + 1));
                }
            }
            data.Close();

            sqlcmd.CommandText = "select dosage,sidecolor,side,sideexp,fadesc,gendesc,alarm,advise from generic2 where name = '" + ttt + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                dosage_t.Text = data["dosage"].ToString();
                sidecolor_c.Text = data["sidecolor"].ToString();
                side_t.Text = data["side"].ToString();
                sideexp_t.Text = data["sideexp"].ToString();
                //fadesc_t.Text = data["fadesc"].ToString();
                //gendesc_t.Text = data["gendesc"].ToString();
                //alarm_t.Text = data["alarm"].ToString();
                //advise_t.Text = data["advise"].ToString();
            }
            data.Close();

            sqlcmd.CommandText = "select * from interaction where drug1 = '" + gen_c.Text + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                intercolor_c.Text = data["color"].ToString();
                inter_c.Text = data["drug2"].ToString();
                interexp_t.Text = data["exp"].ToString();
            }
            data.Close();

            sqlconn.Close();
        }

        private void DrugStore_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tree frm = new tree();
            frm.Show();

        }

        private void save_b_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (gen_r.Checked == true)
            {
                sqlcmd.CommandText = "Update generic2 set dosage = '" + dosage_t.Text + "',sidecolor = '" + sidecolor_c.Text + "',side = '" + side_t.Text + "',sideexp = '" + sideexp_t.Text + "' where name = '" + cat_c.Text + '?' + gen_c.Text + "'";
                sqlcmd.ExecuteNonQuery();

                if (inter_c.Text != "")
                {
                    sqlcmd.CommandText = "select count(*) from interaction where drug1 = '" + gen_c.Text + "' and drug2 = '" + inter_c.Text + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "Insert into interaction(drug1,drug2,exp,color) values('" + gen_c.Text + "','" + inter_c.Text + "','" + interexp_t.Text + "','" + intercolor_c.Text + "')";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Insert into interaction(drug2,drug1,exp,color) values('" + gen_c.Text + "','" + inter_c.Text + "','" + interexp_t.Text + "','" + intercolor_c.Text + "')";
                        sqlcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sqlcmd.CommandText = "Update interaction set exp = '" + interexp_t.Text + "',color = '" + intercolor_c.Text + "' where drug1 = '" + gen_c.Text + "' and drug2 = '" + inter_c.Text + "' ";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Update interaction set exp = '" + interexp_t.Text + "',color = '" + intercolor_c.Text + "' where drug2 = '" + gen_c.Text + "' and drug1 = '" + inter_c.Text + "' ";
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                sqlcmd.CommandText = "Update trade set dosage = '" + dosage_t.Text + "',sidecolor = '" + sidecolor_c.Text + "',side = '" + side_t.Text + "',sideexp = '" + sideexp_t.Text + "' where name = '" + trade_c.Text + "' ";
                sqlcmd.ExecuteNonQuery();

                if (inter_c.Text != "")
                {
                    sqlcmd.CommandText = "select count(*) from interaction where drug1 = '" + trade_c.Text + "' and drug2 = '" + inter_c.Text + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "Insert into interaction(drug1,drug2,exp,color) values('" + trade_c.Text + "','" + inter_c.Text + "','" + interexp_t.Text + "','" + intercolor_c.Text + "')";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Insert into interaction(drug2,drug1,exp,color) values('" + trade_c.Text + "','" + inter_c.Text + "','" + interexp_t.Text + "','" + intercolor_c.Text + "')";
                        sqlcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sqlcmd.CommandText = "Update interaction set exp = '" + interexp_t.Text + "',color = '" + intercolor_c.Text + "' where drug1 = '" + trade_c.Text + "' and drug2 = '" + inter_c.Text + "' ";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Update interaction set exp = '" + interexp_t.Text + "',color = '" + intercolor_c.Text + "' where drug2 = '" + trade_c.Text + "' and drug1 = '" + inter_c.Text + "' ";
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }

            sqlcmd.CommandText = "Insert into drug_tmp(advise,alarm,fadesc,gendesc,side,sideexp,interexp) values('" + advise_t.Text + "','" + alarm_t.Text + "','" + fadesc_t.Text + "','" + gendesc_t.Text + "','" + side_t.Text + "','" + sideexp_t.Text + "','" + interexp_t.Text + "')";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();
        }

        private void form_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                form_t.Text = form_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void strength_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                strength_t.Text = strength_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void frequency_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                frequency_t.Text = frequency_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void period_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                period_t.Text = period_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void route_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                route_t.Text = route_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (form_t.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(form) values('" + form_t.Text.Trim() + "') ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                form_l.Items.Clear();
                form_t.Text = "";
                sqlcmd.CommandText = "select distinct form from drug_tmp where form<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    form_l.Items.Insert(i, data["form"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (strength_t.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(strength) values('" + strength_t.Text.Trim() + "') ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                strength_l.Items.Clear();
                strength_t.Text = "";
                sqlcmd.CommandText = "select distinct strength from drug_tmp where strength<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    strength_l.Items.Insert(i, data["strength"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (frequency_t.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(frequency) values('" + frequency_t.Text.Trim() + "') ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                frequency_l.Items.Clear();
                frequency_t.Text = "";
                sqlcmd.CommandText = "select distinct frequency from drug_tmp where frequency<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    frequency_l.Items.Insert(i, data["frequency"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (period_t.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(period) values('" + period_t.Text.Trim() + "') ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                period_l.Items.Clear();
                period_t.Text = "";
                sqlcmd.CommandText = "select distinct period from drug_tmp where period<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    period_l.Items.Insert(i, data["period"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (route_t.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(route) values('" + route_t.Text.Trim() + "') ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                route_l.Items.Clear();
                route_t.Text = "";
                sqlcmd.CommandText = "select distinct route from drug_tmp where route<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    route_l.Items.Insert(i, data["route"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from drug_tmp where form='" + form_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                form_l.Items.Clear();
                form_t.Text = "";
                sqlcmd.CommandText = "select distinct form from drug_tmp where form<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    form_l.Items.Insert(i, data["form"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from drug_tmp where strength='" + strength_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                strength_l.Items.Clear();
                strength_t.Text = "";
                sqlcmd.CommandText = "select distinct strength from drug_tmp where strength<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    strength_l.Items.Insert(i, data["strength"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from drug_tmp where frequency='" + frequency_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                frequency_l.Items.Clear();
                frequency_t.Text = "";
                sqlcmd.CommandText = "select distinct frequency from drug_tmp where frequency<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    frequency_l.Items.Insert(i, data["frequency"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from drug_tmp where period='" + period_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                period_l.Items.Clear();
                period_t.Text = "";
                sqlcmd.CommandText = "select distinct period from drug_tmp where period<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    period_l.Items.Insert(i, data["period"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from drug_tmp where route='" + route_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                route_l.Items.Clear();
                route_t.Text = "";
                sqlcmd.CommandText = "select distinct route from drug_tmp where route<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    route_l.Items.Insert(i, data["route"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void desc_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void trade_r_CheckedChanged(object sender, EventArgs e)
        {
            if (trade_r.Checked == true && trade_c.Text != "")
            {
                dosage_t.Text = "";
                sidecolor_c.Text = "";
                side_t.Text = "";
                sideexp_t.Text = "";
                intercolor_c.Text = "";
                inter_c.Text = "";
                interexp_t.Text = "";

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select dosage,sidecolor,side,sideexp,fadesc,gendesc,alarm,advise from trade where name = '" + trade_c.Text + "' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    dosage_t.Text = data["dosage"].ToString();
                    sidecolor_c.Text = data["sidecolor"].ToString();
                    side_t.Text = data["side"].ToString();
                    sideexp_t.Text = data["sideexp"].ToString();
                    //fadesc_t.Text = data["fadesc"].ToString();
                    //gendesc_t.Text = data["gendesc"].ToString();
                    //alarm_t.Text = data["alarm"].ToString();
                    //advise_t.Text = data["advise"].ToString();
                }
                data.Close();

                sqlcmd.CommandText = "select * from interaction where drug1 = '" + trade_c.Text + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    intercolor_c.Text = data["color"].ToString();
                    inter_c.Text = data["drug2"].ToString();
                    interexp_t.Text = data["exp"].ToString();
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void gen_r_CheckedChanged(object sender, EventArgs e)
        {
            if (gen_r.Checked == true && gen_c.Text != "")
            {
                dosage_t.Text = "";
                sidecolor_c.Text = "";
                side_t.Text = "";
                sideexp_t.Text = "";
                intercolor_c.Text = "";
                inter_c.Text = "";
                interexp_t.Text = "";

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select dosage,sidecolor,side,sideexp,fadesc,gendesc,alarm,advise from generic2 where name = '" + cat_c.Text + '?' + gen_c.Text + "' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    dosage_t.Text = data["dosage"].ToString();
                    sidecolor_c.Text = data["sidecolor"].ToString();
                    side_t.Text = data["side"].ToString();
                    sideexp_t.Text = data["sideexp"].ToString();
                    //fadesc_t.Text = data["fadesc"].ToString();
                    //gendesc_t.Text = data["gendesc"].ToString();
                    //alarm_t.Text = data["alarm"].ToString();
                    //advise_t.Text = data["advise"].ToString();
                }
                data.Close();

                sqlcmd.CommandText = "select * from interaction where drug1 = '" + gen_c.Text + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    intercolor_c.Text = data["color"].ToString();
                    inter_c.Text = data["drug2"].ToString();
                    interexp_t.Text = data["exp"].ToString();
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void DrugStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            if (active_r.Checked == true)
            {
                sqlcmd.CommandText = "Update sw set side_inter='" + 1 + "'  ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            {
                sqlcmd.CommandText = "Update sw set side_inter='" + 0 + "'  ";
                sqlcmd.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        private void trade_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trade_r.Checked == true && trade_c.Text != "")
            {
                dosage_t.Text = "";
                sidecolor_c.Text = "";
                side_t.Text = "";
                sideexp_t.Text = "";
                intercolor_c.Text = "";
                inter_c.Text = "";
                interexp_t.Text = "";

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select dosage,sidecolor,side,sideexp,fadesc,gendesc,alarm,advise from trade where name = '" + trade_c.Text + "' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    dosage_t.Text = data["dosage"].ToString();
                    sidecolor_c.Text = data["sidecolor"].ToString();
                    side_t.Text = data["side"].ToString();
                    sideexp_t.Text = data["sideexp"].ToString();
                    //fadesc_t.Text = data["fadesc"].ToString();
                    //gendesc_t.Text = data["gendesc"].ToString();
                    //alarm_t.Text = data["alarm"].ToString();
                    //advise_t.Text = data["advise"].ToString();
                }
                data.Close();

                sqlcmd.CommandText = "select * from interaction where drug1 = '" + trade_c.Text + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    intercolor_c.Text = data["color"].ToString();
                    inter_c.Text = data["drug2"].ToString();
                    interexp_t.Text = data["exp"].ToString();
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (sig_t.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(sig) values('" + sig_t.Text.Trim() + "') ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                sig_l.Items.Clear();
                sig_t.Text = "";
                sqlcmd.CommandText = "select distinct sig from drug_tmp where sig<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    sig_l.Items.Insert(i, data["sig"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from drug_tmp where sig='" + sig_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                sig_l.Items.Clear();
                sig_t.Text = "";
                sqlcmd.CommandText = "select distinct sig from drug_tmp where sig<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    sig_l.Items.Insert(i, data["sig"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void gendesc_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void alarm_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void advise_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void advise_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void alarm_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void gendesc_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void fadesc_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void sig_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sig_t.Text = sig_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Replace("'", "''");
                ///////////////////
                if (comboBox1.SelectedItem.ToString() == " Ê÷ÌÕ« ")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "Select count(*) from drug_tmp where fadesc= '"+ textBox1.Text.Trim() +"' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "insert into drug_tmp(fadesc) values('" + textBox1.Text.Trim() + "') ";
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                    }
                    sqlconn.Close();
                }

                if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«Ì ﬂ·Ì")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "Select count(*) from drug_tmp where gendesc= '" + textBox1.Text.Trim() + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "insert into drug_tmp(gendesc) values('" + textBox1.Text.Trim() + "') ";
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                    }
                    sqlconn.Close();
                }


                if (comboBox1.SelectedItem.ToString() == "«Œÿ«—Â«")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "Select count(*) from drug_tmp where alarm= '" + textBox1.Text.Trim() + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "insert into drug_tmp(alarm) values('" + textBox1.Text.Trim() + "') ";
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                    }
                    sqlconn.Close();
                }


                if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "Select count(*) from drug_tmp where advise= '" + textBox1.Text.Trim() + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "insert into drug_tmp(advise) values('" + textBox1.Text.Trim() + "') ";
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                    }
                    sqlconn.Close();
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";

            if (comboBox1.SelectedItem.ToString() == " Ê÷ÌÕ« ")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct fadesc from drug_tmp where fadesc<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["fadesc"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«Ì ﬂ·Ì")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct gendesc from drug_tmp where gendesc<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["gendesc"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "«Œÿ«—Â«")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct alarm from drug_tmp where alarm<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["alarm"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct advise from drug_tmp where advise<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["advise"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox1.Text = textBox1.Text.Replace("'", "''");
                    ///////////////////
                    if (comboBox1.SelectedItem.ToString() == " Ê÷ÌÕ« ")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set fadesc='" + textBox1.Text.Trim() + "' where fadesc='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«Ì ﬂ·Ì")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set gendesc='" + textBox1.Text.Trim() + "' where gendesc='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedItem.ToString() == "«Œÿ«—Â«")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set alarm='" + textBox1.Text.Trim() + "' where alarm='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set advise='" + textBox1.Text.Trim() + "' where advise='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }


                }
            }
            catch { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ///////////////////
                if (comboBox1.SelectedItem.ToString() == " Ê÷ÌÕ« ")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set fadesc='' where fadesc='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }

                if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«Ì ﬂ·Ì")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set gendesc='' where gendesc='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }

                if (comboBox1.SelectedItem.ToString() == "«Œÿ«—Â«")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set alarm='' where alarm='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }

                if (comboBox1.SelectedItem.ToString() == " Ê’ÌÂ Â«")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set advise='' where advise='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
            }
            catch { }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            catch { }
        }
    }
}