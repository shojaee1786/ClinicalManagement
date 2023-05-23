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
    public partial class moein : Form
    {
        string[] mycol = new string[50];
        public moein()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void moein_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct op from acc where finyear=' ' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            string[] mycol = new string[50];
            //int[] sum = new int[50];
            int sum;
            object[] mycol_o = new object[25];
           
          
            int i = 0;
            for (i = 0; i < 25; i++)
            {
                mycol_o[i] = "";
            }
            i = 0;
            dataGridView2.Rows.Insert(0, mycol_o);

            while (data.Read())
            {
                mycol[i] = data["op"].ToString();
                dataGridView1.Columns[i].HeaderText = mycol[i];
                dataGridView2.Columns[i].HeaderText = mycol[i];
                i++;
            }
            data.Close();

            string income_s,outcome_s;
            int counter;
            for (int j = 0; j < i; j++)
            {
                for (i = 0; i < 25; i++)
                {
                    mycol_o[i] = "";
                }
                sqlcmd.CommandText = "select income,outcome from acc where op ='" + mycol[j] + "' and finyear=' ' ";
                data = sqlcmd.ExecuteReader();
                sum = 0;
                counter = 0;
                while (data.Read())
                {
                    income_s = data["income"].ToString();
                    outcome_s = data["outcome"].ToString();
                    if (income_s == "0" && outcome_s == "0")
                    {
                        try
                        {
                            dataGridView1.Rows[counter].Cells[j].Value = "0";
                        }
                        catch 
                        {
                            mycol_o[j] = "0";
                            dataGridView1.Rows.Insert(dataGridView1.Rows.Count, mycol_o);
                        }
                    }
                    else
                    if (income_s == "0")
                    {
                        sum += Int32.Parse(outcome_s);
                        try
                        {
                            dataGridView1.Rows[counter].Cells[j].Value = outcome_s;
                        }
                        catch
                        {
                            mycol_o[j] = outcome_s;
                            dataGridView1.Rows.Insert(dataGridView1.Rows.Count, mycol_o);
                        }
                    }
                    else
                        if (outcome_s == "0")
                        {
                            sum += Int32.Parse(income_s);
                            try
                            {
                                dataGridView1.Rows[counter].Cells[j].Value = income_s;
                            }
                            catch
                            {
                                mycol_o[j] = income_s;
                                dataGridView1.Rows.Insert(dataGridView1.Rows.Count, mycol_o);
                            }
                        }
                    counter++;
                }
                dataGridView2.Rows[0].Cells[j].Value = sum.ToString();
                data.Close();
            }
           
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

            sqlconn.Close();
        }

        private void moein_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }
    }
}