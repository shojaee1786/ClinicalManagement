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
    public partial class acc2 : Form
    {
        public static bool insert_mode = false;
        public acc2()
        {
            InitializeComponent();
        }

        private void acc2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void acc2_Load(object sender, EventArgs e)
        {
            date_t.Focus();
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
            sqlcmd.CommandText = "select distinct op from acc_tmp where op<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["op"].ToString();
                op_t.AutoCompleteCustomSource.Add(s);
                op_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct bank from acc_tmp where bank<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["bank"].ToString();
                bank_t.AutoCompleteCustomSource.Add(s);
                bank_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct variz from acc_tmp where variz<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["variz"].ToString();
                variz_t.AutoCompleteCustomSource.Add(s);
                variz_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct hospital from acc_tmp where hospital<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["hospital"].ToString();
                hospital_t.AutoCompleteCustomSource.Add(s);
                hospital_c.Items.Insert(i, s);
                i++;
            }
            data.Close();
            
            sqlconn.Close();

            if (insert_mode == true)
                button1.Text = "œ—Ã";
            else
            {
                button1.Text = " €ÌÌ—«  À»  ‘Êœ";
                date_t.Text = acc.acc_row[1].ToString();
                op_t.Text = acc.acc_row[2].ToString();
                par_t.Text = acc.acc_row[3].ToString();
                sanad_t.Text = acc.acc_row[4].ToString();
                bank_t.Text = acc.acc_row[5].ToString();
                checkdate_t.Text = acc.acc_row[6].ToString();
                variz_t.Text = acc.acc_row[7].ToString();
                hospital_t.Text = acc.acc_row[8].ToString();
                remainder_t.Text = acc.acc_row[9].ToString();
                outcome_t.Text = acc.acc_row[10].ToString();
                income_t.Text = acc.acc_row[11].ToString();
                remaining_t.Text = acc.acc_row[12].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "œ—Ã";
            if (button1.Text == "œ—Ã")
            {
                acc.acc_flag = true;

                acc.acc_row[2] = date_t.Text;
                acc.acc_row[3] = op_t.Text;
                acc.acc_row[4] = par_t.Text;
                acc.acc_row[5] = sanad_t.Text;
                acc.acc_row[6] = bank_t.Text;
                acc.acc_row[7] = checkdate_t.Text;
                acc.acc_row[8] = variz_t.Text;
                acc.acc_row[9] = hospital_t.Text;
                acc.acc_row[10] = remainder_t.Text;
                acc.acc_row[11] = outcome_t.Text;
                acc.acc_row[12] = income_t.Text;
                acc.acc_row[13] = (Int64.Parse(income_t.Text) - Int64.Parse(outcome_t.Text) - Int64.Parse(remainder_t.Text)).ToString();

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                //sqlcmd.CommandText = "insert into acc(date1,op,par,sanad,bank,checkdate,variz,hospital,remainder,outcome,income,remaining) values('" + date_t.Text + "','" + op_t.Text + "','" + par_t.Text + "','" + sanad_t.Text + "','" + bank_t.Text + "','" + checkdate_t.Text + "','" + variz_t.Text + "','" + hospital_t.Text + "','" + remainder_t.Text + "','" + outcome_t.Text + "','" + income_t.Text + "','" + remaining_t.Text + "')";
                //sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "insert into acc_tmp(op,bank,variz,hospital) values('" + op_t.Text + "','" + bank_t.Text + "','" + variz_t.Text + "','" + hospital_t.Text + "')";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            else
            {
                acc.acc_edit_flag = true;

                acc.acc_row[2] = date_t.Text;
                acc.acc_row[3] = op_t.Text;
                acc.acc_row[4] = par_t.Text;
                acc.acc_row[5] = sanad_t.Text;
                acc.acc_row[6] = bank_t.Text;
                acc.acc_row[7] = checkdate_t.Text;
                acc.acc_row[8] = variz_t.Text;
                acc.acc_row[9] = hospital_t.Text;
                acc.acc_row[10] = remainder_t.Text;
                acc.acc_row[11] = outcome_t.Text;
                acc.acc_row[12] = income_t.Text;
                acc.acc_row[13] = (Int64.Parse(income_t.Text) - Int64.Parse(outcome_t.Text) - Int64.Parse(remainder_t.Text)).ToString();
            }

            this.Close();
        }

        private void op_t_Click(object sender, EventArgs e)
        {
            op_c.Width = 17;
            op_c.Visible = true;
        }

        private void bank_t_Click(object sender, EventArgs e)
        {
            bank_c.Width = 17;
            bank_c.Visible = true;
        }

        private void variz_t_Click(object sender, EventArgs e)
        {
            variz_c.Width = 17;
            variz_c.Visible = true;
        }

        private void hospital_t_Click(object sender, EventArgs e)
        {
            hospital_c.Width = 17;
            hospital_c.Visible = true;
        }

        private void par_t_Enter(object sender, EventArgs e)
        {
            op_c.Visible = false;
        }

        private void checkdate_t_Enter(object sender, EventArgs e)
        {
            bank_c.Visible = false;
        }

        private void hospital_t_Enter(object sender, EventArgs e)
        {
            variz_c.Visible = false;
        }

        private void remainder_t_Enter(object sender, EventArgs e)
        {
            hospital_c.Visible = false;
        }

        private void op_c_Click(object sender, EventArgs e)
        {
            if (op_c.Width != 22 + op_t.Width)
                op_c.Width = 22 + op_t.Width;
        }

        private void bank_c_Click(object sender, EventArgs e)
        {
            if (bank_c.Width != 22 + bank_t.Width)
                bank_c.Width = 22 + bank_t.Width;
        }

        private void variz_c_Click(object sender, EventArgs e)
        {
            if (variz_c.Width != 22 + variz_t.Width)
                variz_c.Width = 22 + variz_t.Width;
        }

        private void hospital_c_Click(object sender, EventArgs e)
        {
            if (hospital_c.Width != 22 + hospital_t.Width)
                hospital_c.Width = 22 + hospital_t.Width;
        }

        private void op_c_MouseHover(object sender, EventArgs e)
        {
            op_c.Width = 22 + op_t.Width;
            op_c.SendToBack();
        }

        private void bank_c_MouseHover(object sender, EventArgs e)
        {
            bank_c.Width = 22 + bank_t.Width;
            bank_c.SendToBack();
        }

        private void variz_c_MouseHover(object sender, EventArgs e)
        {
            variz_c.Width = 22 + variz_t.Width;
            variz_c.SendToBack();
        }

        private void hospital_c_MouseHover(object sender, EventArgs e)
        {
            hospital_c.Width = 22 + hospital_t.Width;
            hospital_c.SendToBack();
        }

        private void op_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            op_t.Text = op_c.Text;
            op_c.Width = 17;
            op_c.Visible = false;
            op_t.Focus();
        }

        private void bank_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            bank_t.Text = bank_c.Text;
            bank_c.Width = 17;
            bank_c.Visible = false;
            bank_t.Focus();
        }

        private void variz_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            variz_t.Text = variz_c.Text;
            variz_c.Width = 17;
            variz_c.Visible = false;
            variz_t.Focus();
        }

        private void hospital_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            hospital_t.Text = hospital_c.Text;
            hospital_c.Width = 17;
            hospital_c.Visible = false;
            hospital_t.Focus();
        }

        private void acc2_FormClosing(object sender, FormClosingEventArgs e)
        {
            insert_mode = false;
        }

        private void income_t_Leave(object sender, EventArgs e)
        {
            remaining_t.Text = (Int64.Parse(income_t.Text) - Int64.Parse(outcome_t.Text) - Int64.Parse(remainder_t.Text)).ToString();
        }

        private void outcome_t_Leave(object sender, EventArgs e)
        {
            remaining_t.Text = (Int64.Parse(income_t.Text) - Int64.Parse(outcome_t.Text) - Int64.Parse(remainder_t.Text)).ToString();
        }
    }
}