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
    public partial class Diagnostic : Form
    {
        public Diagnostic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, m, n;
            int line=0;
            string  str = "";

            i = 0;
            while (i < treeView1.Nodes.Count)
            {
                if (treeView1.Nodes[i].Checked == true)
                    if (str == "")
                    {
                        str = treeView1.Nodes[i].Text + ":";
                    }
                    else
                    {
                        str += ", " + treeView1.Nodes[i].Text;
                    }
                j = 0;
                while (j < treeView1.Nodes[i].Nodes.Count)
                {
                    if (treeView1.Nodes[i].Nodes[j].Checked == true)
                        if (str == "")
                        {
                            str = treeView1.Nodes[i].Nodes[j].Text;
                        }
                        else
                        {
                            str += treeView1.Nodes[i].Nodes[j].Text;
                        }

                    m = 0;
                    while (m < treeView1.Nodes[i].Nodes[j].Nodes.Count)
                    {
                        if (treeView1.Nodes[i].Nodes[j].Nodes[m].Checked == true)
                            if (str == "")
                            {
                                str = treeView1.Nodes[i].Nodes[j].Nodes[m].Text;
                            }
                            else
                            {
                                str += ", " + treeView1.Nodes[i].Nodes[j].Nodes[m].Text;
                            }
                        n = 0;
                        while (n < treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes.Count)
                        {
                            if (treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Checked == true)
                                if (str == "")
                                {
                                    str = treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Text;
                                }
                                else
                                {
                                    str += ", " + treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Text;
                                }
                            n++;
                        }
                        m++;
                    }
                    j++;
                }
                i++;

                if (str != "")
                {
                    if (line == 0)
                    {
                        richTextBox1.Text = str;
                        str = "";
                        line++;
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "\n" + str;
                        str = "";
                    }
                }
            }

        }

        private void Diagnostic_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            SqlConnection sqlconn3 = new SqlConnection(cm.cs);
            SqlConnection sqlconn4 = new SqlConnection(cm.cs);
            SqlConnection sqlconn5 = new SqlConnection(cm.cs);
            SqlConnection sqlconn6 = new SqlConnection(cm.cs);
            SqlConnection sqlconn7 = new SqlConnection(cm.cs);
            SqlConnection sqlconn8 = new SqlConnection(cm.cs);
            SqlConnection sqlconn9 = new SqlConnection(cm.cs);
            sqlconn.Open();
            sqlconn2.Open();
            sqlconn3.Open();
            sqlconn4.Open();
            sqlconn5.Open();
            sqlconn6.Open();
            sqlconn7.Open();
            sqlconn8.Open();
            sqlconn9.Open();

            SqlCommand sqlcmd = new SqlCommand("select * from px1", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();

            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;
            SqlDataReader data2;

            SqlCommand sqlcmd3 = new SqlCommand();
            sqlcmd3.Connection = sqlconn3;
            SqlDataReader data3;

            SqlCommand sqlcmd4 = new SqlCommand();
            sqlcmd4.Connection = sqlconn4;
            SqlDataReader data4;

            SqlCommand sqlcmd5 = new SqlCommand();
            sqlcmd5.Connection = sqlconn5;
            SqlDataReader data5;

            SqlCommand sqlcmd6 = new SqlCommand();
            sqlcmd6.Connection = sqlconn6;
            SqlDataReader data6;

            SqlCommand sqlcmd7 = new SqlCommand();
            sqlcmd7.Connection = sqlconn7;
            SqlDataReader data7;

            SqlCommand sqlcmd8 = new SqlCommand();
            sqlcmd8.Connection = sqlconn8;
            SqlDataReader data8;

            SqlCommand sqlcmd9 = new SqlCommand();
            sqlcmd9.Connection = sqlconn9;
            SqlDataReader data9;

            string generic, trade, c, g, t, lvl4, lvl4_str, lvl5, lvl5_str, lvl6, lvl6_str, lvl7, lvl7_str, lvl8, lvl8_str, lvl9, lvl9_str, lvl10, lvl10_str;
            int myindex, myindex1, i, j, k, myindex4, myindex5, myindex6, myindex7, myindex8, myindex9, myindex10, i4,i5,i6,i7,i8,i9,i10;
            myindex1 = myindex = myindex4 = myindex5 = myindex6 = myindex7 = myindex8 = myindex9 = myindex10 = i = j = k = i4 = i5 = i6 = i7 = i8 = i9 = i10 = 0;
            while (data.Read())
            {
                c = data["d1"].ToString();
                treeView1.Nodes.Insert(i, c);
                generic = data["d2"].ToString();
                j = 0;
                while (generic != "")
                {
                    myindex = generic.IndexOf('|');
                    g = generic.Substring(0, myindex);

                    treeView1.Nodes[i].Nodes.Insert(j, g);

                    sqlcmd2.CommandText = "select * from px2 where d2='" + c + '|' + g + "' ";
                    data2 = sqlcmd2.ExecuteReader();
                    while (data2.Read())
                    {
                        trade = data2["d3"].ToString();
                        k = 0;
                        while (trade != "")
                        {
                            myindex1 = trade.IndexOf('|');
                            t = trade.Substring(0, myindex1);

                            treeView1.Nodes[i].Nodes[j].Nodes.Insert(k, t);

                            sqlcmd3.CommandText = "select * from px3 where d3 = '" + c + '|' + g + '|' + t + "' ";
                            data3 = sqlcmd3.ExecuteReader();
                            while (data3.Read())
                            {
                                lvl4_str = data3["d4"].ToString();
                                i4 = 0;
                                while (lvl4_str != "")
                                {
                                    myindex4 = lvl4_str.IndexOf("|");
                                    lvl4 = lvl4_str.Substring(0, myindex4);

                                    treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes.Insert(i4, lvl4);

                                    sqlcmd4.CommandText = "select * from px4 where d4 = '" + c + '|' + g + '|' + t + '|' + lvl4 + "' ";
                                    data4 = sqlcmd4.ExecuteReader();
                                    while (data4.Read())
                                    {
                                        lvl5_str = data4["d5"].ToString();
                                        i5 = 0;
                                        while (lvl5_str != "")
                                        {
                                            myindex5 = lvl5_str.IndexOf("|");
                                            lvl5 = lvl5_str.Substring(0, myindex5);
                                            treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes.Insert(i5, lvl5);

                                            sqlcmd5.CommandText = "select * from px5 where d5 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + "' ";
                                            data5 = sqlcmd5.ExecuteReader();
                                            while (data5.Read())
                                            {
                                                lvl6_str = data5["d6"].ToString();
                                                i6 = 0;
                                                while (lvl6_str != "")
                                                {
                                                    myindex6 = lvl6_str.IndexOf("|");
                                                    lvl6 = lvl6_str.Substring(0, myindex6);
                                                    treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes[i5].Nodes.Insert(i6, lvl6);

                                                    sqlcmd6.CommandText = "select * from px6 where d6 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + '|' + lvl6 + "' ";
                                                    data6 = sqlcmd6.ExecuteReader();
                                                    while (data6.Read())
                                                    {
                                                        lvl7_str = data6["d7"].ToString();
                                                        i7 = 0;
                                                        while (lvl7_str != "")
                                                        {
                                                            myindex7 = lvl7_str.IndexOf("|");
                                                            lvl7 = lvl7_str.Substring(0, myindex7);
                                                            treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes[i5].Nodes[i6].Nodes.Insert(i7, lvl7);

                                                            sqlcmd7.CommandText = "select * from px7 where d7 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + '|' + lvl6 + '|' + lvl7 + "' ";
                                                            data7 = sqlcmd7.ExecuteReader();
                                                            while (data7.Read())
                                                            {
                                                                lvl8_str = data7["d8"].ToString();
                                                                i8 = 0;
                                                                while (lvl8_str != "")
                                                                {
                                                                    myindex8 = lvl8_str.IndexOf("|");
                                                                    lvl8 = lvl8_str.Substring(0, myindex8);
                                                                    treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes.Insert(i8, lvl8);

                                                                    sqlcmd8.CommandText = "select * from px8 where d8 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + '|' + lvl6 + '|' + lvl7 + '|' + lvl8 + "' ";
                                                                    data8 = sqlcmd8.ExecuteReader();
                                                                    while (data8.Read())
                                                                    {
                                                                        lvl9_str = data8["d9"].ToString();
                                                                        i9 = 0;
                                                                        while (lvl9_str != "")
                                                                        {
                                                                            myindex9 = lvl9_str.IndexOf("|");
                                                                            lvl9 = lvl9_str.Substring(0, myindex9);
                                                                            treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes.Insert(i9, lvl9);

                                                                            sqlcmd9.CommandText = "select * from px9 where d9 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + '|' + lvl6 + '|' + lvl7 + '|' + lvl8 + '|' + lvl9 + "' ";
                                                                            data9 = sqlcmd9.ExecuteReader();
                                                                            while (data9.Read())
                                                                            {
                                                                                lvl10_str = data9["d10"].ToString();
                                                                                i10 = 0;
                                                                                while (lvl10_str != "")
                                                                                {
                                                                                    myindex10 = lvl10_str.IndexOf("|");
                                                                                    lvl10 = lvl10_str.Substring(0, myindex10);
                                                                                    treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes[i9].Nodes.Insert(i10, lvl10);

                                                                                    if (lvl10_str.Length <= (myindex10 + 1))
                                                                                        lvl10_str = "";
                                                                                    else
                                                                                        lvl10_str = lvl10_str.Substring(myindex10 + 1, lvl10_str.Length - (myindex10 + 1));

                                                                                    i10++;
                                                                                }
                                                                            }
                                                                            data9.Close();

                                                                            if (lvl9_str.Length <= (myindex9 + 1))
                                                                                lvl9_str = "";
                                                                            else
                                                                                lvl9_str = lvl9_str.Substring(myindex9 + 1, lvl9_str.Length - (myindex9 + 1));

                                                                            i9++;
                                                                        }
                                                                    }
                                                                    data8.Close();

                                                                    if (lvl8_str.Length <= (myindex8 + 1))
                                                                        lvl8_str = "";
                                                                    else
                                                                        lvl8_str = lvl8_str.Substring(myindex8 + 1, lvl8_str.Length - (myindex8 + 1));

                                                                    i8++;
                                                                }
                                                            }
                                                            data7.Close();

                                                            if (lvl7_str.Length <= (myindex7 + 1))
                                                                lvl7_str = "";
                                                            else
                                                                lvl7_str = lvl7_str.Substring(myindex7 + 1, lvl7_str.Length - (myindex7 + 1));

                                                            i7++;
                                                        }
                                                    }
                                                    data6.Close();
                                                    if (lvl6_str.Length <= (myindex6 + 1))
                                                        lvl6_str = "";
                                                    else
                                                        lvl6_str = lvl6_str.Substring(myindex6 + 1, lvl6_str.Length - (myindex6 + 1));

                                                    i6++;
                                                }
                                            }
                                            data5.Close();
                                            if (lvl5_str.Length <= (myindex5 + 1))
                                                lvl5_str = "";
                                            else
                                                lvl5_str = lvl5_str.Substring(myindex5 + 1, lvl5_str.Length - (myindex5 + 1));

                                            i5++;
                                        }
                                    }
                                    data4.Close();
                                    if (lvl4_str.Length <= (myindex4 + 1))
                                        lvl4_str = "";
                                    else
                                        lvl4_str = lvl4_str.Substring(myindex4 + 1, lvl4_str.Length - (myindex4 + 1));

                                    i4++;
                                }
                            }
                            data3.Close();
                            if (trade.Length <= (myindex1 + 1))
                                trade = "";
                            else
                                trade = trade.Substring(myindex1 + 1, trade.Length - (myindex1 + 1));

                            k++;
                        }
                    }
                    data2.Close();

                    if (generic.Length <= (myindex + 1))
                        generic = "";
                    else
                        generic = generic.Substring(myindex + 1, generic.Length - (myindex + 1));

                    j++;
                }
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

            sqlconn.Close();
            sqlconn2.Close();
            sqlconn3.Close();
            sqlconn4.Close();
            sqlconn5.Close();
            sqlconn6.Close();
            sqlconn7.Close();
            sqlconn8.Close();
            sqlconn9.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PX.str_px = richTextBox1.Text;
            rpx.str_rpx = richTextBox1.Text;
        }

        private void Diagnostic_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int ii = 0; ii < 50; ii++)
            {
                Printer_Px.Printer_Px_Array[ii] = "";
            }

                if (richTextBox1.Text == "")
                {
                    MessageBox.Show("Please select diagnostic procedures", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            Printer_Px.max_counter_print_px = richTextBox1.Lines.Length;

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                if (richTextBox1.Lines[i].ToString().Contains(":") == true)
                {
                    Printer_Px.Printer_Px_Array[i] = richTextBox1.Lines[i].ToString();
                }
            }

            Printer_Px frm = new Printer_Px();
            frm.ShowDialog();
        }
    }
}