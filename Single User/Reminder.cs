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
    public partial class Reminder : Form
    {
        public static object[] reminder_row = new object[25];
        public static bool reminder_flag = false;
        public static bool reminder_edit_flag = false;
        public static bool reminder_result = false;
        
        public Reminder()
        {
            InitializeComponent();
        }

        private void Reminder_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
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

            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                for (int i = 0; i < 20; i++)
                    dataGridView2.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "select * from reminder";
            data = sqlcmd.ExecuteReader();
            reminder_row[0] = "";
            while (data.Read())
            {
                reminder_row[1] = data["row"].ToString();
                reminder_row[2] = data["who"].ToString();
                reminder_row[3] = data["hour1"].ToString();
                reminder_row[4] = data["days"].ToString();
                reminder_row[5] = data["day1"].ToString();
                reminder_row[6] = data["month1"].ToString();
                reminder_row[7] = data["year1"].ToString();
                reminder_row[8] = data["what"].ToString();
                reminder_row[9] = data["instance"].ToString();
                reminder_row[10] = data["place"].ToString();
                reminder_row[11] = data["op"].ToString();
                reminder_row[12] = data["title"].ToString();
                reminder_row[13] = data["fname"].ToString();
                reminder_row[14] = data["family"].ToString();
                reminder_row[15] = data["tel"].ToString();
                reminder_row[16] = data["email"].ToString();
                reminder_row[17] = data["cause"].ToString();
                reminder_row[18] = data["desc1"].ToString();
                reminder_row[19] = data["tick"].ToString();
                
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, reminder_row);

                if (reminder_row[19].ToString() == "1")
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[19].Value = "True";
                else
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[19].Value = "False";
                
            }
            data.Close();

            sqlconn.Close();

        }

        private void Reminder_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Reminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] my_str = new string[55];

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            sqlconn2.Open();
            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;

            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14,c15,c16,c17,c18,c19,c20) values('" + this.Name + "','" + dataGridView2.Columns[0].Width + "','" + dataGridView2.Columns[1].Width + "','" + dataGridView2.Columns[2].Width + "','" + dataGridView2.Columns[3].Width + "','" + dataGridView2.Columns[4].Width + "','" + dataGridView2.Columns[5].Width + "','" + dataGridView2.Columns[6].Width + "','" + dataGridView2.Columns[7].Width + "','" + dataGridView2.Columns[8].Width + "','" + dataGridView2.Columns[9].Width + "','" + dataGridView2.Columns[10].Width + "','" + dataGridView2.Columns[11].Width + "','" + dataGridView2.Columns[12].Width + "','" + dataGridView2.Columns[13].Width + "','" + dataGridView2.Columns[14].Width + "','" + dataGridView2.Columns[15].Width + "','" + dataGridView2.Columns[16].Width + "','" + dataGridView2.Columns[17].Width + "','" + dataGridView2.Columns[18].Width + "','" + dataGridView2.Columns[19].Width + "')";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Delete from reminder_temp2";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "select * from reminder";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                my_str[1] = data["row"].ToString();
                my_str[2] = data["who"].ToString();
                my_str[3] = data["hour1"].ToString();
                my_str[4] = data["days"].ToString();
                my_str[5] = data["day1"].ToString();
                my_str[6] = data["month1"].ToString();
                my_str[7] = data["year1"].ToString();
                my_str[8] = data["what"].ToString();
                my_str[9] = data["instance"].ToString();
                my_str[10] = data["place"].ToString();
                my_str[11] = data["op"].ToString();
                my_str[12] = data["title"].ToString();
                my_str[13] = data["fname"].ToString();
                my_str[14] = data["family"].ToString();
                my_str[15] = data["tel"].ToString();
                my_str[16] = data["email"].ToString();
                my_str[17] = data["cause"].ToString();
                my_str[18] = data["desc1"].ToString();
                my_str[19] = data["tick"].ToString();

                string my_bit = "0";
                if (my_str[19] == "True")
                    my_bit = "1";
                else
                    my_bit = "0";

                sqlcmd2.CommandText = "Insert into reminder_temp2(row,who,hour1,days,day1,month1,year1,what,instance,place,op,title,fname,family,tel,email,cause,desc1,tick) values('" + my_str[1] + "','" + my_str[2] + "','" + my_str[3] + "','" + my_str[4] + "','" + my_str[5] + "','" + my_str[6] + "','" + my_str[7] + "','" + my_str[8] + "','" + my_str[9] + "','" + my_str[10] + "','" + my_str[11] + "','" + my_str[12] + "','" + my_str[13] + "','" + my_str[14] + "','" + my_str[15] + "','" + my_str[16] + "','" + my_str[17] + "','" + my_str[18] + "','" + my_bit + "')";
                sqlcmd2.ExecuteNonQuery();
            }
            data.Close();


            sqlcmd.CommandText = "Delete from reminder";
            sqlcmd.ExecuteNonQuery();

            try
            {

                string tt;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    try
                    {
                        if (dataGridView2.Rows[i].Cells[19].Value.ToString() == "True")
                            tt = "1";
                        else
                            tt = "0";
                    }
                    catch
                    {
                        tt = "0";
                    }

                    sqlcmd.CommandText = "Insert into reminder(row,who,hour1,days,day1,month1,year1,what,instance,place,op,title,fname,family,tel,email,cause,desc1,tick) values('" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[18].Value.ToString() + "','" + tt + "')";
                    sqlcmd.ExecuteNonQuery();
                }
            }
            catch
            {
                sqlcmd.CommandText = "Delete from reminder";
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = "select * from reminder_temp2";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    my_str[1] = data["row"].ToString();
                    my_str[2] = data["who"].ToString();
                    my_str[3] = data["hour1"].ToString();
                    my_str[4] = data["days"].ToString();
                    my_str[5] = data["day1"].ToString();
                    my_str[6] = data["month1"].ToString();
                    my_str[7] = data["year1"].ToString();
                    my_str[8] = data["what"].ToString();
                    my_str[9] = data["instance"].ToString();
                    my_str[10] = data["place"].ToString();
                    my_str[11] = data["op"].ToString();
                    my_str[12] = data["title"].ToString();
                    my_str[13] = data["fname"].ToString();
                    my_str[14] = data["family"].ToString();
                    my_str[15] = data["tel"].ToString();
                    my_str[16] = data["email"].ToString();
                    my_str[17] = data["cause"].ToString();
                    my_str[18] = data["desc1"].ToString();
                    my_str[19] = data["tick"].ToString();

                    string my_bit = "0";
                    if (my_str[19] == "True")
                        my_bit = "1";
                    else
                        my_bit = "0";

                    sqlcmd2.CommandText = "Insert into reminder(row,who,hour1,days,day1,month1,year1,what,instance,place,op,title,fname,family,tel,email,cause,desc1,tick) values('" + my_str[1] + "','" + my_str[2] + "','" + my_str[3] + "','" + my_str[4] + "','" + my_str[5] + "','" + my_str[6] + "','" + my_str[7] + "','" + my_str[8] + "','" + my_str[9] + "','" + my_str[10] + "','" + my_str[11] + "','" + my_str[12] + "','" + my_str[13] + "','" + my_str[14] + "','" + my_str[15] + "','" + my_str[16] + "','" + my_str[17] + "','" + my_str[18] + "','" + my_bit + "')";
                    sqlcmd2.ExecuteNonQuery();
                }
                data.Close();
            }

            sqlconn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            int i;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count - 1)
            {
                for (i = 0; i < 16; i++)
                    reminder_row[i] = "";
                reminder_row[0] = e.RowIndex.ToString();
                   
                reminder_row[1] = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                reminder_row[2] = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                reminder_row[3] = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                reminder_row[4] = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                reminder_row[5] = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                reminder_row[6] = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                reminder_row[7] = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                reminder_row[8] = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                reminder_row[9] = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                reminder_row[10] = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                reminder_row[11] = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
                reminder_row[12] = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                reminder_row[13] = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
                reminder_row[14] = dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString();
                reminder_row[15] = dataGridView2.Rows[e.RowIndex].Cells[16].Value.ToString();
                reminder_row[16] = dataGridView2.Rows[e.RowIndex].Cells[17].Value.ToString();
                reminder_row[17] = dataGridView2.Rows[e.RowIndex].Cells[18].Value.ToString();
                try
                {
                    reminder_row[18] = dataGridView2.Rows[e.RowIndex].Cells[19].Value.ToString();
                }
                catch { }


                Reminder3 frm = new Reminder3();
              

                sqlcmd.CommandText = "select distinct fname from info where fname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    frm.fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
                data.Close();

                sqlcmd.CommandText = "select distinct lname from info where lname<>''";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    frm.family_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
                data.Close();

                sqlconn.Close();
                

                frm.ShowDialog();
                if (reminder_edit_flag == true)
                {
                    reminder_edit_flag = false;
                    for (i = 1; i <= 17; i++)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[i + 1].Value = reminder_row[i].ToString();
                    }
                    if(reminder_row[18].ToString() == "True")
                        dataGridView2.Rows[e.RowIndex].Cells[19].Value = "True";
                    else
                        dataGridView2.Rows[e.RowIndex].Cells[19].Value = "False";
                }

              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;
            Reminder2 frm = new Reminder2();

            sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.family_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            data.Close();

            sqlconn.Close();

            Reminder2.insert_mode = true;
            frm.ShowDialog();
            if (reminder_flag == true)
            {
                reminder_row[0] = "";
                reminder_flag = false;
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, reminder_row);
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //SqlConnection sqlconn = new SqlConnection(cm.cs);
            //sqlconn.Open();
            //SqlCommand sqlcmd = new SqlCommand("delete reminder where who = '" + e.Row.Cells[2].Value.ToString() + "' and hour1 = '" + e.Row.Cells[3].Value.ToString() + "' and  days = '" + e.Row.Cells[4].Value.ToString() + "' and day1 = '" + e.Row.Cells[5].Value.ToString() + "' and  month1 = '" + e.Row.Cells[6].Value.ToString() + "' and year1 = '" + e.Row.Cells[7].Value.ToString() + "' ", sqlconn);
            //sqlcmd.ExecuteNonQuery();
            //sqlconn.Close();
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 1; i <= 18; i++)
            {

                if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value == null)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = " ";
                }
            }
        }
    }
}