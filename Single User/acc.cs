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
    public partial class acc : Form
    {
        public static object[] acc_row = new object[25];
        public static bool acc_flag = false;
        public static bool acc_edit_flag = false;
        public static bool acc_insert = false;
        public static bool acc_insert_double = false;
        public static string my_finyear;
        public static bool old_finyear = false;

        public acc()
        {
            InitializeComponent();
        }

        private void acc_Load(object sender, EventArgs e)
        {
            old_finyear = false;
            acc_insert_double = false;
            LanguageSelector.KeyboardLayout.Farsi();
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
                for (int i = 0; i < 14; i++)
                   dataGridView2.Columns[i].Width = Int32.Parse(data[i + 1].ToString());//"'"+s+"'"
            }
            data.Close();



            sqlcmd.CommandText = "select * from acc where finyear=' ' order by row";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                acc_row[0] = "";
                acc_row[1] = data["row"].ToString();
                acc_row[2] = data["date1"].ToString();
                acc_row[3] = data["op"].ToString();
                acc_row[4] = data["par"].ToString();
                acc_row[5] = data["sanad"].ToString();
                acc_row[6] = data["bank"].ToString();
                acc_row[7] = data["checkdate"].ToString();
                acc_row[8] = data["variz"].ToString();
                acc_row[9] = data["hospital"].ToString();
                acc_row[10] = data["remainder"].ToString();
                acc_row[11] = data["outcome"].ToString();
                acc_row[12] = data["income"].ToString();
                acc_row[13] = data["remaining"].ToString();
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, acc_row);
            }
            data.Close();

            sqlconn.Close();
        }

        private void acc_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count - 1)
            {
                //acc_row[0] = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(); 
                acc_row[1] = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                acc_row[2] = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                acc_row[3] = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                acc_row[4] = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                acc_row[5] = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                acc_row[6] = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                acc_row[7] = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                acc_row[8] = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                acc_row[9] = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                acc_row[10] = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                acc_row[11] = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
                acc_row[12] = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                //acc_row[13] = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                //acc_row[14] = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
                //acc_row[15] = dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString();


                acc2 frm = new acc2();
                frm.ShowDialog();

                if (acc_edit_flag == true)
                {
                    acc_edit_flag = false;
                    for (i = 2; i <= 13; i++)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[i].Value = acc_row[i].ToString();
                    }
                }

            }
            
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void acc_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] my_str = new string[55];

            if (old_finyear == true)
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            sqlconn2.Open();
            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;

            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14) values('" + this.Name + "','" + dataGridView2.Columns[0].Width + "','" + dataGridView2.Columns[1].Width + "','" + dataGridView2.Columns[2].Width + "','" + dataGridView2.Columns[3].Width + "','" + dataGridView2.Columns[4].Width + "','" + dataGridView2.Columns[5].Width + "','" + dataGridView2.Columns[6].Width + "','" + dataGridView2.Columns[7].Width + "','" + dataGridView2.Columns[8].Width + "','" + dataGridView2.Columns[9].Width + "','" + dataGridView2.Columns[10].Width + "','" + dataGridView2.Columns[11].Width + "','" + dataGridView2.Columns[12].Width + "','" + dataGridView2.Columns[13].Width + "')";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Delete from acc_temp2";
            sqlcmd.ExecuteNonQuery();

            if (acc_insert_double == false)
            {
                sqlcmd.CommandText = "select * from acc where finyear=' ' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    my_str[1] = data["row"].ToString();
                    my_str[2] = data["date1"].ToString();
                    my_str[3] = data["op"].ToString();
                    my_str[4] = data["par"].ToString();
                    my_str[5] = data["sanad"].ToString();
                    my_str[6] = data["bank"].ToString();
                    my_str[7] = data["checkdate"].ToString();
                    my_str[8] = data["variz"].ToString();
                    my_str[9] = data["hospital"].ToString();
                    my_str[10] = data["remainder"].ToString();
                    my_str[11] = data["outcome"].ToString();
                    my_str[12] = data["income"].ToString();
                    my_str[13] = data["remaining"].ToString();

                    sqlcmd2.CommandText = "insert into acc_temp2(finyear,row,date1,op,par,sanad,bank,checkdate,variz,hospital,remainder,outcome,income,remaining) values(' ','" + my_str[1] + "','" + my_str[2] + "','" + my_str[3] + "','" + my_str[4] + "','" + my_str[5] + "','" + my_str[6] + "','" + my_str[7] + "','" + my_str[8] + "','" + my_str[9] + "','" + my_str[10] + "','" + my_str[11] + "','" + my_str[12] + "','" + my_str[13] + "')";
                    sqlcmd2.ExecuteNonQuery();
                }
                data.Close();

                sqlcmd.CommandText = "Delete from acc where finyear=' ' ";
                sqlcmd.ExecuteNonQuery();

                try
                {
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        sqlcmd.CommandText = "insert into acc(finyear,row,date1,op,par,sanad,bank,checkdate,variz,hospital,remainder,outcome,income,remaining) values(' ','" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[13].Value.ToString() + "')";
                        sqlcmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    sqlcmd.CommandText = "Delete from acc where finyear=' ' ";
                    sqlcmd.ExecuteNonQuery();

                    sqlcmd.CommandText = "select * from acc_temp2 where finyear=' ' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        my_str[1] = data["row"].ToString();
                        my_str[2] = data["date1"].ToString();
                        my_str[3] = data["op"].ToString();
                        my_str[4] = data["par"].ToString();
                        my_str[5] = data["sanad"].ToString();
                        my_str[6] = data["bank"].ToString();
                        my_str[7] = data["checkdate"].ToString();
                        my_str[8] = data["variz"].ToString();
                        my_str[9] = data["hospital"].ToString();
                        my_str[10] = data["remainder"].ToString();
                        my_str[11] = data["outcome"].ToString();
                        my_str[12] = data["income"].ToString();
                        my_str[13] = data["remaining"].ToString();

                        sqlcmd2.CommandText = "insert into acc(finyear,row,date1,op,par,sanad,bank,checkdate,variz,hospital,remainder,outcome,income,remaining) values(' ','" + my_str[1] + "','" + my_str[2] + "','" + my_str[3] + "','" + my_str[4] + "','" + my_str[5] + "','" + my_str[6] + "','" + my_str[7] + "','" + my_str[8] + "','" + my_str[9] + "','" + my_str[10] + "','" + my_str[11] + "','" + my_str[12] + "','" + my_str[13] + "')";
                        sqlcmd2.ExecuteNonQuery();
                    }
                    data.Close();

                }
            }
            sqlconn.Close();

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (old_finyear == true)
                    return;

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from acc where finyear=' ' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    sqlcmd.CommandText = "insert into acc(finyear,row,date1,op,par,sanad,bank,checkdate,variz,hospital,remainder,outcome,income,remaining) values(' ','" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[13].Value.ToString() + "')";
                    sqlcmd.ExecuteNonQuery();
                }
                acc_insert_double = true;

                Int64 income = 0, outcome = 0, remainder = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    remainder += Int64.Parse(dataGridView2.Rows[i].Cells[10].Value.ToString());
                }
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    outcome += Int64.Parse(dataGridView2.Rows[i].Cells[11].Value.ToString());
                }
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    income += Int64.Parse(dataGridView2.Rows[i].Cells[12].Value.ToString());
                }

                total2.remainder = remainder;
                total2.outcome = outcome;
                total2.income = income;
                my_finyear = " ";
                total2 frm = new total2();
                frm.ShowDialog();
                dataGridView2.Rows.Clear();
                sqlcmd.CommandText = "select * from acc where finyear='"+ my_finyear +"'";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    acc_row[0] = "";
                    acc_row[1] = data["row"].ToString();
                    acc_row[2] = data["date1"].ToString();
                    acc_row[3] = data["op"].ToString();
                    acc_row[4] = data["par"].ToString();
                    acc_row[5] = data["sanad"].ToString();
                    acc_row[6] = data["bank"].ToString();
                    acc_row[7] = data["checkdate"].ToString();
                    acc_row[8] = data["variz"].ToString();
                    acc_row[9] = data["hospital"].ToString();
                    acc_row[10] = data["remainder"].ToString();
                    acc_row[11] = data["outcome"].ToString();
                    acc_row[12] = data["income"].ToString();
                    acc_row[13] = data["remaining"].ToString();
                    dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, acc_row);
                }
                data.Close();

                sqlconn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (old_finyear == true)
                return;

            acc2 frm = new acc2();
            acc2.insert_mode = true;
            frm.ShowDialog();

            if (acc_flag == true)
            {
                acc_flag = false;
                acc_row[0] = "";
                acc_row[1] = " ";
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, acc_row);
            }
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 1; i <= 9; i++)
            {

                if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value == null)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = " ";
                }
            }
            for (int i = 10; i <= 13; i++)
            {

                if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value == null)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = "0";
                }
            }
        }
    }
}