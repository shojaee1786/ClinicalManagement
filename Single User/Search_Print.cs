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
    public partial class Search_Print : Form
    {
        public Search_Print()
        {
            InitializeComponent();
        }

        private void Search_Print_Load(object sender, EventArgs e)
        {
            Invoice.Checked = true;
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



            sqlconn.Close();
        }

        private void Search_Print_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            if (radioButton1.Checked == true)
            {
                dataGridView1.Columns.Add("‰«„ Ê ‰«„ Œ«‰Ê«œêÌ", "‰«„ Ê ‰«„ Œ«‰Ê«œêÌ");
                dataGridView1.Columns.Add("„»·€ ﬂ·Ì", "„»·€ ﬂ·Ì");
                dataGridView1.Columns.Add(" «—ÌŒ", " «—ÌŒ");
                dataGridView1.Columns.Add("”—ÊÌ” «Ê·", "”—ÊÌ” «Ê·");
                dataGridView1.Columns.Add("„»·€ «Ê·", "„»·€ «Ê·");
                dataGridView1.Columns.Add("”—ÊÌ” œÊ„", "”—ÊÌ” œÊ„");
                dataGridView1.Columns.Add("„»·€ œÊ„", "„»·€ œÊ„");
                dataGridView1.Columns.Add("”—ÊÌ” ”Ê„", "”—ÊÌ” ”Ê„");
                dataGridView1.Columns.Add("„»·€ ”Ê„", "„»·€ ”Ê„");
                dataGridView1.Columns.Add("”—ÊÌ” çÂ«—„", "”—ÊÌ” çÂ«—„");
                dataGridView1.Columns.Add("„»·€ çÂ«—„", "„»·€ çÂ«—„");
            }

          

        }

        private void Invoice_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            if (Invoice.Checked == true)
            {
                dataGridView1.Columns.Add("‰«„ Ê ‰«„ Œ«‰Ê«œêÌ", "‰«„ Ê ‰«„ Œ«‰Ê«œêÌ");
                dataGridView1.Columns.Add("„»·€ ﬂ·Ì", "„»·€ ﬂ·Ì");
                dataGridView1.Columns.Add(" «—ÌŒ", " «—ÌŒ");
                dataGridView1.Columns.Add("”—ÊÌ” «Ê·", "”—ÊÌ” «Ê·");
                dataGridView1.Columns.Add("„»·€ «Ê·", "„»·€ «Ê·");
                dataGridView1.Columns.Add("”—ÊÌ” œÊ„", "”—ÊÌ” œÊ„");
                dataGridView1.Columns.Add("„»·€ œÊ„", "„»·€ œÊ„");
                dataGridView1.Columns.Add("”—ÊÌ” ”Ê„", "”—ÊÌ” ”Ê„");
                dataGridView1.Columns.Add("„»·€ ”Ê„", "„»·€ ”Ê„");
                dataGridView1.Columns.Add("”—ÊÌ” çÂ«—„", "”—ÊÌ” çÂ«—„");
                dataGridView1.Columns.Add("„»·€ çÂ«—„", "„»·€ çÂ«—„");
            }

           
        }

        private void rest_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            if (rest.Checked == true)
            {
                
                dataGridView1.Columns.Add("‰«„ Ê ‰«„ Œ«‰Ê«œêÌ", "‰«„ Ê ‰«„ Œ«‰Ê«œêÌ");
                dataGridView1.Columns[0].Width = 300;
                dataGridView1.Columns.Add("⁄·  «” —«Õ ", "⁄·  «” —«Õ ");
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns.Add(" «—ÌŒ ‘—Ê⁄", " «—ÌŒ ‘—Ê⁄");
                dataGridView1.Columns.Add(" «—ÌŒ Å«Ì«‰", " «—ÌŒ Å«Ì«‰");
            }

          
        }

        private void name_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void search_b_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string s = name_t.Text;
            s = s.Replace(" ", "  ");
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            if (radioButton1.Checked == true)
            {
                // Receipt
                object[] ob = new object[11];
                sqlcmd.CommandText = "Select * from receipt where name like '%' + '" + name_t.Text + "' + '%' or name like '%' + '" + s + "' + '%' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    ob[0] = data["name"].ToString();
                    ob[1] = data["price"].ToString();
                    ob[2] = data["date1"].ToString();
                    ob[3] = data["service1"].ToString();
                    ob[4] = data["price1"].ToString();
                    ob[5] = data["service2"].ToString();
                    ob[6] = data["price2"].ToString();
                    ob[7] = data["service3"].ToString();
                    ob[8] = data["price3"].ToString();
                    ob[9] = data["service4"].ToString();
                    ob[10] = data["price4"].ToString();

                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count-1, ob);
                }
                data.Close();
            }

            if (Invoice.Checked == true)
            {
                object[] ob = new object[11];
                sqlcmd.CommandText = "Select * from invoice where name like '%' + '" + name_t.Text + "' + '%' or name like '%' + '" + s + "' + '%' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    ob[0] = data["name"].ToString();
                    ob[1] = data["price"].ToString();
                    ob[2] = data["date1"].ToString();
                    ob[3] = data["service1"].ToString();
                    ob[4] = data["price1"].ToString();
                    ob[5] = data["service2"].ToString();
                    ob[6] = data["price2"].ToString();
                    ob[7] = data["service3"].ToString();
                    ob[8] = data["price3"].ToString();
                    ob[9] = data["service4"].ToString();
                    ob[10] = data["price4"].ToString();

                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count - 1, ob);
                }
                data.Close();
            }

            if (rest.Checked == true)
            {
                object[] ob = new object[11];
                sqlcmd.CommandText = "Select * from rest where name like '%' + '" + name_t.Text + "' + '%' or name like '%' + '" + s + "' + '%' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    ob[0] = data["name"].ToString();
                    ob[1] = data["cause"].ToString();
                    ob[2] = data["date1"].ToString();
                    ob[3] = data["date2"].ToString();

                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count - 1, ob);
                }
                data.Close();
            }


            sqlconn.Close();

            if (dataGridView1.RowCount == 1)
                Del_print.Enabled = false;
            else
                Del_print.Enabled = true;
        }

        private void Del_print_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to delete selected database ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (MessageBox.Show("Are you sure you want to delete the chosen database ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;

                    if (radioButton1.Checked == true)
                    {
                        // Receipt
                        sqlcmd.CommandText = "Delete from receipt";
                        sqlcmd.ExecuteNonQuery();
                    }

                    if (Invoice.Checked == true)
                    {
                        sqlcmd.CommandText = "Delete from invoice";
                        sqlcmd.ExecuteNonQuery();
                    }

                    if (rest.Checked == true)
                    {
                        sqlcmd.CommandText = "Delete from rest";
                        sqlcmd.ExecuteNonQuery();
                    }


                    sqlconn.Close();
                }
            }
        }
    }
}