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
    public partial class rDD : Form
    {
        public static string str_rDD = "";

        public rDD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, m, n;

            str_rDD = "";

            i = 0;
            while (i < treeView1.Nodes.Count)
            {
                if (treeView1.Nodes[i].Checked == true)
                    if (str_rDD == "")
                    {
                        str_rDD = treeView1.Nodes[i].Text;
                    }
                    else
                    {
                        str_rDD += " " + treeView1.Nodes[i].Text;
                    }
                j = 0;
                while (j < treeView1.Nodes[i].Nodes.Count)
                {
                    if (treeView1.Nodes[i].Nodes[j].Checked == true)
                        if (str_rDD == "")
                        {
                            str_rDD = treeView1.Nodes[i].Nodes[j].Text;
                        }
                        else
                        {
                            str_rDD += " " + treeView1.Nodes[i].Nodes[j].Text;
                        }

                    m = 0;
                    while (m < treeView1.Nodes[i].Nodes[j].Nodes.Count)
                    {
                        if (treeView1.Nodes[i].Nodes[j].Nodes[m].Checked == true)
                            if (str_rDD == "")
                            {
                                str_rDD = treeView1.Nodes[i].Nodes[j].Nodes[m].Text;
                            }
                            else
                            {
                                str_rDD += " " + treeView1.Nodes[i].Nodes[j].Nodes[m].Text;
                            }
                        n = 0;
                        while (n < treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes.Count)
                        {
                            if (treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Checked == true)
                                if (str_rDD == "")
                                {
                                    str_rDD = treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Text;
                                }
                                else
                                {
                                    str_rDD += " " + treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Text;
                                }
                            n++;
                        }
                        m++;
                    }
                    j++;
                }
                i++;
            }
            this.Close();
        }

        private void rDD_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            SqlConnection sqlconn3 = new SqlConnection(cm.cs);
            SqlConnection sqlconn4 = new SqlConnection(cm.cs);
            SqlConnection sqlconn5 = new SqlConnection(cm.cs);
            sqlconn.Open();
            sqlconn2.Open();
            sqlconn3.Open();
            sqlconn4.Open();
            sqlconn5.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from rdd1", sqlconn);
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


            string generic, trade, c, g, t, lvl4, lvl4_str, lvl5, lvl5_str, lvl6, lvl6_str;
            int myindex, myindex1, i, j, k, myindex4, myindex5, myindex6,i4,i5,i6;
            myindex1 = myindex = myindex4 = myindex5 = myindex6 = i = j = k = i4 = i5 = i6 = 0;
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

                    sqlcmd2.CommandText = "select * from rdd2 where d2='" + c + '|' + g + "' ";
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

                            sqlcmd3.CommandText = "select * from rdd3 where d3 = '" + c + '|' + g + '|' + t + "' ";
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

                                    sqlcmd4.CommandText = "select * from rdd4 where d4 = '" + c + '|' + g + '|' + t + '|' + lvl4 + "' ";
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

                                            sqlcmd5.CommandText = "select * from rdd5 where d5 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + "' ";
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

                                                    //
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
            sqlconn.Close();
            sqlconn2.Close();
            sqlconn3.Close();
            sqlconn4.Close();
            sqlconn5.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Width = treeView1.Width + 20;
            this.Width = this.Width + 20;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Width >= 320)
            {
                treeView1.Width = treeView1.Width - 20;
                this.Width = this.Width - 20;
            }
        }

    }
}