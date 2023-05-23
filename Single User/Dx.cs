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
    public partial class Dx : Form
    {
        public static string str_Dx = "";

        public Dx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, m, n;

            str_Dx = "";

            i = 0;
            while (i < treeView1.Nodes.Count)
            {
                if (treeView1.Nodes[i].Checked == true)
                    if (str_Dx == "")
                    {
                        str_Dx = treeView1.Nodes[i].Text;
                    }
                    else
                    {
                        str_Dx += " " + treeView1.Nodes[i].Text;
                    }
                j = 0;
                while (j < treeView1.Nodes[i].Nodes.Count)
                {
                    if (treeView1.Nodes[i].Nodes[j].Checked == true)
                        if (str_Dx == "")
                        {
                            str_Dx = treeView1.Nodes[i].Nodes[j].Text;
                        }
                        else
                        {
                            str_Dx += " " + treeView1.Nodes[i].Nodes[j].Text;
                        }

                    m = 0;
                    while (m < treeView1.Nodes[i].Nodes[j].Nodes.Count)
                    {
                        if (treeView1.Nodes[i].Nodes[j].Nodes[m].Checked == true)
                            if (str_Dx == "")
                            {
                                str_Dx = treeView1.Nodes[i].Nodes[j].Nodes[m].Text;
                            }
                            else
                            {
                                str_Dx += " " + treeView1.Nodes[i].Nodes[j].Nodes[m].Text;
                            }
                        n = 0;
                        while (n < treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes.Count)
                        {
                            if (treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Checked == true)
                                if (str_Dx == "")
                                {
                                    str_Dx = treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Text;
                                }
                                else
                                {
                                    str_Dx += " " + treeView1.Nodes[i].Nodes[j].Nodes[m].Nodes[n].Text;
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

        private void Dx_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            sqlconn.Open();
            sqlconn2.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from dx1", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();

            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;
            SqlDataReader data2;

            string generic, trade, c, g, t;
            int myindex, myindex1, i, j, k;
            myindex1 = myindex = i = j = k = 0;
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

                    sqlcmd2.CommandText = "select * from dx2 where d2='" + c + '|' + g + "' ";
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
        }
    }
}