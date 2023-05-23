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
    public partial class Rx : Form
    {
        public Rx()
        {
            InitializeComponent();
        }

        private void Rx_Load(object sender, EventArgs e)
        {
            side_effect.drug_count = 0;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            sqlconn2.Open();
            sqlconn.Open();
            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;
            SqlCommand sqlcmd = new SqlCommand("select * from category2 ORDER BY - freq", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            string s;
            int c = 0;
            
            while (data.Read())
            {
                s = data["name"].ToString();
                dataGridView1.Columns.Add(s, s);
                c++;
            }
            data.Close();
            int i = 0, myindex = 0,j = 0;
            Int64 myfreq = 0;
            object[] ss = new object[1000];
            
            SqlDataReader data2;

            while (i < c)
            {
                
                sqlcmd.CommandText = "select generic from category where name = '"+dataGridView1.Columns[i].HeaderText+"' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    s = data["generic"].ToString();
                    while (s != "")
                    {
                        myindex = s.IndexOf('?');

                        sqlcmd2.CommandText = "select freq from generic2 where name = '" + dataGridView1.Columns[i].HeaderText + '?' + s.Substring(0, myindex) + "' ";
                        data2 = sqlcmd2.ExecuteReader();
                        while (data2.Read())
                        {
                            myfreq = Int64.Parse(data2["freq"].ToString());
                        }
                        data2.Close();

                        sqlcmd2.CommandText = "insert into sort_generic(generic,freq) values('" + s.Substring(0, myindex) + "','"+myfreq+"')";
                        sqlcmd2.ExecuteNonQuery();



                        if (s.Length <= (myindex + 1))
                            s = "";
                        else
                            s = s.Substring(myindex + 1, s.Length - (myindex + 1));
                    }
                }
                
                data.Close();

                sqlcmd2.CommandText = "select generic from sort_generic order by -freq";
                data2 = sqlcmd2.ExecuteReader();
                j = 0;
                while (data2.Read())
                {
                    if (i > 0) ss[i - 1] = null;
                    ss[i] = data2["generic"].ToString();
                    try
                    {
                        dataGridView1.Rows[j].Cells[i].Value = ss[i].ToString();
                    }
                    catch
                    {
                        dataGridView1.Rows.Insert(dataGridView1.Rows.Count, ss);
                    }
                    j++;
                }
                data2.Close();

                sqlcmd2.CommandText = "delete from sort_generic";
                sqlcmd2.ExecuteNonQuery();
                
                i++;
            }

            sqlconn2.Close();


            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                try
                {
                    for (i = 0; i < 24; i++)
                        dataGridView1.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
                }
                catch { }
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

            sqlconn.Close();
        }

        private void Rx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.Columns.Count == 0)
                return;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();


            int c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18;
            c1 = c2 = c3 = c4 = c5 = c6 = c7 = c8 = c9 = c10 = c11 = c12 = c13 = c14 = c15 = c16 = c17 = c18 = 50;

            try
            {
                c1 = dataGridView1.Columns[0].Width;
                c2 = dataGridView1.Columns[1].Width;
                c3 = dataGridView1.Columns[2].Width;
                c4 = dataGridView1.Columns[3].Width;
                c5 = dataGridView1.Columns[4].Width;
                c6 = dataGridView1.Columns[5].Width;
                c7 = dataGridView1.Columns[6].Width;
                c8 = dataGridView1.Columns[7].Width;
                c9 = dataGridView1.Columns[8].Width;
                c10 = dataGridView1.Columns[9].Width;
                c11 = dataGridView1.Columns[10].Width;
                c12 = dataGridView1.Columns[11].Width;
                c13 = dataGridView1.Columns[12].Width;
                c14 = dataGridView1.Columns[13].Width;
                c15 = dataGridView1.Columns[14].Width;
                c16 = dataGridView1.Columns[15].Width;
                c17 = dataGridView1.Columns[16].Width;
                c18 = dataGridView1.Columns[17].Width;

            }
            catch { }

            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14,c15,c16,c17,c18) values('" + this.Name + "','" + c1 + "','" + c2 + "','" + c3 + "','" + c4 + "','" + c5 + "','" + c6 + "','" + c7 + "','" + c8 + "','" + c9 + "','" + c10 + "','" + c11 + "','" + c12 + "','" + c13 + "','" + c14 + "','" + c15 + "','" + c16 + "','" + c17 + "','" + c18 + "') ";
            sqlcmd.ExecuteNonQuery();

            
            sqlconn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    return;
            }
            catch
            {
                return;
            }

            string mytemp = "";
            int i = 1;
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                try
                {
                    sqlcmd.CommandText = "Update category2 set freq = freq + 1 where name = '" + dataGridView1.Columns[e.ColumnIndex].HeaderText + "' ";
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.CommandText = "Update generic2 set freq = freq + 1 where name = '" + dataGridView1.Columns[e.ColumnIndex].HeaderText + '?' + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' ";
                    sqlcmd.ExecuteNonQuery();
                }
                catch
                {
                    sqlcmd.CommandText = "Update generic2 set freq = 0 ";
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.CommandText = "Update category2 set freq = 0 ";
                    sqlcmd.ExecuteNonQuery();
                }


                if (richTextBox1.Lines.Length == 0)
                    richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                else
                {
                    richTextBox1.Text = richTextBox1.Text + "\n" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                sqlcmd.CommandText = "select side,sidecolor,sideexp from generic2 where name = '" + dataGridView1.Columns[e.ColumnIndex].HeaderText + '?' + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    side_effect.side_str = data["side"].ToString();
                    side_effect.side_color = data["sidecolor"].ToString();
                    mytemp = data["sideexp"].ToString();
                }
                data.Close();

                side_effect.drug_count++;
                side_effect.drug[side_effect.drug_count] = dataGridView1.Columns[e.ColumnIndex].HeaderText + "?" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                
                sqlcmd.CommandText = "select side_inter from sw";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                    i = Int32.Parse(data["side_inter"].ToString());
                data.Close();

                sqlconn.Close();
            }
            catch { }

            if (i == 1 && side_effect.side_str != "" && side_effect.side_str != null)
            {
                if (mytemp != "")
                    side_effect.side_str = side_effect.side_str + "\n" + mytemp;

                side_effect f1 = new side_effect();
                f1.ShowDialog();
            }
            else
            {
                // Interaction must check at here because drug 1 hasn't any side effects
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;

                sqlconn.Close();
            }

        }

        private void Rx_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void changeall_b_Click(object sender, EventArgs e)
        {
            side_effect.drug_count = 0;
            richTextBox1.Clear();
        }

        private void change_b_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                s = richTextBox1.Text;
                int i = s.LastIndexOf('\n');
                richTextBox1.Text = s.Remove(i);
                side_effect.drug_count--;
            }
            catch
            {
                richTextBox1.Clear();
                side_effect.drug_count = 0;
            }
        }

        private void ok_b_Click(object sender, EventArgs e)
        {
            Dosage frm = new Dosage();
            frm.Show();
        }

    }
}