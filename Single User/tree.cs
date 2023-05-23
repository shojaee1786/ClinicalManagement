using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Clinical_Management
{
    public partial class tree : Form
    {
        //public static List<string> l1 = new List<string>();
        //public static List<string> l2 = new List<string>();
        //public static List<string> l3 = new List<string>();
        public static int index;
        public tree()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i4, i5, i6, i7, i8, i9;
            
            treeView1.Nodes.Clear();

            switch (comboBox1.SelectedIndex)
            {
                case 0: // Dx
                    {
                        index = 0;
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


                        break;
                    }
                case 1: // DD for Left Panel
                    {
                        index = 1;
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
                        SqlCommand sqlcmd = new SqlCommand("select * from ldd1", sqlconn);
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
                        int myindex, myindex1, i, j, k, myindex4, myindex5, myindex6;
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

                                sqlcmd2.CommandText = "select * from ldd2 where d2='" + c + '|' + g + "' ";
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

                                        sqlcmd3.CommandText = "select * from ldd3 where d3 = '"+ c + '|' + g + '|' + t +"' ";
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

                                                sqlcmd4.CommandText = "select * from ldd4 where d4 = '" + c + '|' + g + '|' + t + '|' + lvl4 + "' ";
                                                data4 = sqlcmd4.ExecuteReader();
                                                while (data4.Read())
                                                {
                                                    lvl5_str = data4["d5"].ToString();
                                                    i5 = 0;
                                                    while(lvl5_str != "")
                                                    {
                                                        myindex5 = lvl5_str.IndexOf("|");
                                                        lvl5 = lvl5_str.Substring(0,myindex5);
                                                        treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes[i4].Nodes.Insert(i5, lvl5);

                                                        sqlcmd5.CommandText = "select * from ldd5 where d5 = '" + c + '|' + g + '|' + t + '|' + lvl4 + '|' + lvl5 + "' ";
                                                        data5 = sqlcmd5.ExecuteReader();
                                                        while (data5.Read())
                                                        {
                                                            lvl6_str = data5["d6"].ToString();
                                                            i6 = 0;
                                                            while (lvl6_str != "")
                                                            {
                                                                myindex6 = lvl6_str.IndexOf("|");
                                                                lvl6 = lvl6_str.Substring(0,myindex6);
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

                        break;
                    }
                case 2: // DD for Right Panel
                    {
                        index = 2;
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
                        int myindex, myindex1, i, j, k, myindex4, myindex5, myindex6;
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


                        break;
                    }
                case 3: // Px
                    {
                        index = 3;
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
                        int myindex, myindex1, i, j, k, myindex4, myindex5, myindex6 ,myindex7, myindex8, myindex9,myindex10,i10;
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
                        sqlconn.Close();
                        sqlconn2.Close();
                        sqlconn3.Close();
                        sqlconn4.Close();
                        sqlconn5.Close();
                        sqlconn6.Close();
                        sqlconn7.Close();
                        sqlconn8.Close();
                        sqlconn9.Close();

                        break;
                    }
                case 4: // Drug Store
                    {
                        index = 4;
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        SqlConnection sqlconn2 = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        sqlconn2.Open();
                        SqlCommand sqlcmd = new SqlCommand("select name,generic from category", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();

                        SqlCommand sqlcmd2 = new SqlCommand();
                        sqlcmd2.Connection = sqlconn2;
                        SqlDataReader data2;

                        string generic, trade, c, g, t;
                        int myindex, myindex1, i, j, k;
                        myindex1 = myindex = i = j = k = 0;
                        while (data.Read())
                        {
                            c = data["name"].ToString();
                            treeView1.Nodes.Insert(i, c);
                            generic = data["generic"].ToString();
                            j = 0;
                            while (generic != "")
                            {
                                myindex = generic.IndexOf('?');
                                g = generic.Substring(0, myindex);

                                treeView1.Nodes[i].Nodes.Insert(j, g);

                                sqlcmd2.CommandText = "select name,trade from generic where name='" + c + '?' + g + "' ";
                                data2 = sqlcmd2.ExecuteReader();
                                while (data2.Read())
                                {
                                    trade = data2["trade"].ToString();
                                    k = 0;
                                    while (trade != "")
                                    {
                                        myindex1 = trade.IndexOf('?');
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


                        break;


                    }
                   
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i1, i2, i3, i4, i5, i6, i7, i8, i9;

            switch (index)
            {
                case 0:
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Delete from dx1", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from dx2";
                        sqlcmd.ExecuteNonQuery();


                        i1 = 0;
                        while (i1 < treeView1.Nodes.Count)
                        {
                            sqlcmd.CommandText = "insert into dx1(d1) values('" + treeView1.Nodes[i1].Text + "')";
                            sqlcmd.ExecuteNonQuery();
                            
                            i2 = 0;
                            while (i2 < treeView1.Nodes[i1].Nodes.Count)
                            {
                                sqlcmd.CommandText = "insert into dx2(d2) values('" + treeView1.Nodes[i1].Text + '|'+ treeView1.Nodes[i1].Nodes[i2].Text + "')";
                                sqlcmd.ExecuteNonQuery();
                                sqlcmd.CommandText = "update dx1 set d2 = IsNull(d2,'') + '" + treeView1.Nodes[i1].Nodes[i2].Text + "'+'|' where d1 ='" + treeView1.Nodes[i1].Text + "' ";
                                sqlcmd.ExecuteNonQuery();

                                i3 = 0;
                                while (i3 < treeView1.Nodes[i1].Nodes[i2].Nodes.Count)
                                {
                                    sqlcmd.CommandText = "update dx2 set d3 = IsNull(d3,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "'+'|' where d2 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                    i3++;
                                }
                                i2++;
                            }
                            i1++;
                        }

                        sqlconn.Close();
                        break;
                    }
                case 1:
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Delete from ldd1", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from ldd2";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from ldd3";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from ldd4";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from ldd5";
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            i1 = 0;
                            while (i1 < treeView1.Nodes.Count)
                            {
                                sqlcmd.CommandText = "insert into ldd1(d1) values('" + treeView1.Nodes[i1].Text + "')";
                                sqlcmd.ExecuteNonQuery();

                                i2 = 0;
                                while (i2 < treeView1.Nodes[i1].Nodes.Count)
                                {
                                    sqlcmd.CommandText = "insert into ldd2(d2) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "')";
                                    sqlcmd.ExecuteNonQuery();
                                    sqlcmd.CommandText = "update ldd1 set d2 = IsNull(d2,'') + '" + treeView1.Nodes[i1].Nodes[i2].Text + "'+'|' where d1 ='" + treeView1.Nodes[i1].Text + "' ";
                                    sqlcmd.ExecuteNonQuery();

                                    i3 = 0;
                                    while (i3 < treeView1.Nodes[i1].Nodes[i2].Nodes.Count)
                                    {
                                        sqlcmd.CommandText = "insert into ldd3(d3) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "')";
                                        sqlcmd.ExecuteNonQuery();
                                        sqlcmd.CommandText = "update ldd2 set d3 = IsNull(d3,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "'+'|' where d2 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                        sqlcmd.ExecuteNonQuery();

                                        i4 = 0;
                                        while (i4 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes.Count)
                                        {
                                            sqlcmd.CommandText = "insert into ldd4(d4) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "')";
                                            sqlcmd.ExecuteNonQuery();
                                            sqlcmd.CommandText = "update ldd3 set d4 = IsNull(d4,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "'+'|' where d3 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "' ";
                                            sqlcmd.ExecuteNonQuery();

                                            i5 = 0;
                                            while (i5 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes.Count)
                                            {
                                                sqlcmd.CommandText = "insert into ldd5(d5) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "')";
                                                sqlcmd.ExecuteNonQuery();
                                                sqlcmd.CommandText = "update ldd4 set d5 = IsNull(d5,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "'+'|' where d4 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "' ";
                                                sqlcmd.ExecuteNonQuery();

                                                i6 = 0;
                                                while (i6 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes.Count)
                                                {
                                                    sqlcmd.CommandText = "update ldd5 set d6 = IsNull(d6,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + "'+'|' where d5 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "' ";
                                                    sqlcmd.ExecuteNonQuery();

                                                    i6++;
                                                }
                                                i5++;
                                            }
                                            i4++;
                                        }
                                        i3++;
                                    }
                                    i2++;
                                }
                                i1++;
                            }

                        }
                        catch { }

                        sqlconn.Close();

                        break;
                    }
                case 2:
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Delete from rdd1", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from rdd2";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from rdd3";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from rdd4";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from rdd5";
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            i1 = 0;
                            while (i1 < treeView1.Nodes.Count)
                            {
                                sqlcmd.CommandText = "insert into rdd1(d1) values('" + treeView1.Nodes[i1].Text + "')";
                                sqlcmd.ExecuteNonQuery();

                                i2 = 0;
                                while (i2 < treeView1.Nodes[i1].Nodes.Count)
                                {
                                    sqlcmd.CommandText = "insert into rdd2(d2) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "')";
                                    sqlcmd.ExecuteNonQuery();
                                    sqlcmd.CommandText = "update rdd1 set d2 = IsNull(d2,'') + '" + treeView1.Nodes[i1].Nodes[i2].Text + "'+'|' where d1 ='" + treeView1.Nodes[i1].Text + "' ";
                                    sqlcmd.ExecuteNonQuery();

                                    i3 = 0;
                                    while (i3 < treeView1.Nodes[i1].Nodes[i2].Nodes.Count)
                                    {
                                        sqlcmd.CommandText = "insert into rdd3(d3) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "')";
                                        sqlcmd.ExecuteNonQuery();
                                        sqlcmd.CommandText = "update rdd2 set d3 = IsNull(d3,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "'+'|' where d2 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                        sqlcmd.ExecuteNonQuery();

                                        i4 = 0;
                                        while (i4 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes.Count)
                                        {
                                            sqlcmd.CommandText = "insert into rdd4(d4) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "')";
                                            sqlcmd.ExecuteNonQuery();
                                            sqlcmd.CommandText = "update rdd3 set d4 = IsNull(d4,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "'+'|' where d3 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "' ";
                                            sqlcmd.ExecuteNonQuery();

                                            i5 = 0;
                                            while (i5 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes.Count)
                                            {
                                                sqlcmd.CommandText = "insert into rdd5(d5) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "')";
                                                sqlcmd.ExecuteNonQuery();
                                                sqlcmd.CommandText = "update rdd4 set d5 = IsNull(d5,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "'+'|' where d4 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "' ";
                                                sqlcmd.ExecuteNonQuery();

                                                i6 = 0;
                                                while (i6 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes.Count)
                                                {
                                                    sqlcmd.CommandText = "update rdd5 set d6 = IsNull(d6,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + "'+'|' where d5 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "' ";
                                                    sqlcmd.ExecuteNonQuery();

                                                    i6++;
                                                }
                                                i5++;
                                            }
                                            i4++;
                                        }
                                        i3++;
                                    }
                                    i2++;
                                }
                                i1++;
                            }

                        }
                        catch { }

                        sqlconn.Close();
                        break;
                    }
                case 3:
                    { // Apply Changes for Px
                        int i10 = 0;
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Delete from px1", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px2";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px3";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px4";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px5";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px6";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px7";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px8";
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from px9";
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            i1 = 0;
                            while (i1 < treeView1.Nodes.Count)
                            {
                                sqlcmd.CommandText = "insert into px1(d1) values('" + treeView1.Nodes[i1].Text + "')";
                                sqlcmd.ExecuteNonQuery();

                                i2 = 0;
                                while (i2 < treeView1.Nodes[i1].Nodes.Count)
                                {
                                    sqlcmd.CommandText = "insert into px2(d2) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "')";
                                    sqlcmd.ExecuteNonQuery();
                                    sqlcmd.CommandText = "update px1 set d2 = IsNull(d2,'') + '" + treeView1.Nodes[i1].Nodes[i2].Text + "'+'|' where d1 ='" + treeView1.Nodes[i1].Text + "' ";
                                    sqlcmd.ExecuteNonQuery();

                                    i3 = 0;
                                    while (i3 < treeView1.Nodes[i1].Nodes[i2].Nodes.Count)
                                    {
                                        sqlcmd.CommandText = "insert into px3(d3) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "')";
                                        sqlcmd.ExecuteNonQuery();
                                        sqlcmd.CommandText = "update px2 set d3 = IsNull(d3,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "'+'|' where d2 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                        sqlcmd.ExecuteNonQuery();

                                        i4 = 0;
                                        while (i4 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes.Count)
                                        {
                                            sqlcmd.CommandText = "insert into px4(d4) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "')";
                                            sqlcmd.ExecuteNonQuery();
                                            sqlcmd.CommandText = "update px3 set d4 = IsNull(d4,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "'+'|' where d3 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "' ";
                                            sqlcmd.ExecuteNonQuery();

                                            i5 = 0;
                                            while (i5 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes.Count)
                                            {
                                                sqlcmd.CommandText = "insert into px5(d5) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "')";
                                                sqlcmd.ExecuteNonQuery();
                                                sqlcmd.CommandText = "update px4 set d5 = IsNull(d5,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "'+'|' where d4 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + "' ";
                                                sqlcmd.ExecuteNonQuery();

                                                i6 = 0;
                                                while (i6 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes.Count)
                                                {
                                                    sqlcmd.CommandText = "insert into px6(d6) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + "')";
                                                    sqlcmd.ExecuteNonQuery();
                                                    sqlcmd.CommandText = "update px5 set d6 = IsNull(d6,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + "'+'|' where d5 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + "' ";
                                                    sqlcmd.ExecuteNonQuery();

                                                    i7 = 0;
                                                    while (i7 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes.Count)
                                                    {
                                                        sqlcmd.CommandText = "insert into px7(d7) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + "')";
                                                        sqlcmd.ExecuteNonQuery();
                                                        sqlcmd.CommandText = "update px6 set d7 = IsNull(d7,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + "'+'|' where d6 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + "' ";
                                                        sqlcmd.ExecuteNonQuery();

                                                        i8 = 0;
                                                        while (i8 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes.Count)
                                                        {
                                                            sqlcmd.CommandText = "insert into px8(d8) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Text + "')";
                                                            sqlcmd.ExecuteNonQuery();
                                                            sqlcmd.CommandText = "update px7 set d8 = IsNull(d8,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Text + "'+'|' where d7 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + "' ";
                                                            sqlcmd.ExecuteNonQuery();

                                                            i9 = 0;
                                                            while (i9 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes.Count)
                                                            {
                                                                sqlcmd.CommandText = "insert into px9(d9) values('" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes[i9].Text + "')";
                                                                sqlcmd.ExecuteNonQuery();
                                                                sqlcmd.CommandText = "update px8 set d9 = IsNull(d9,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes[i9].Text + "'+'|' where d8 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Text + "' ";
                                                                sqlcmd.ExecuteNonQuery();

                                                                i10 = 0;
                                                                while (i10 < treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes[i9].Nodes.Count)
                                                                {
                                                                    sqlcmd.CommandText = "update px9 set d10 = IsNull(d10,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes[i9].Nodes[i10].Text + "'+'|' where d9 ='" + treeView1.Nodes[i1].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Text + '|' + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Nodes[i5].Nodes[i6].Nodes[i7].Nodes[i8].Nodes[i9].Text + "' ";
                                                                    sqlcmd.ExecuteNonQuery();

                                                                    i10++;
                                                                }
                                                                i9++;
                                                            }
                                                            i8++;
                                                        }
                                                        i7++;
                                                    }
                                                    i6++;
                                                }
                                                i5++;
                                            }
                                            i4++;
                                        }
                                        i3++;
                                    }
                                    i2++;
                                }
                                i1++;
                            }

                        }
                        catch { }

                        sqlconn.Close();

                        break;
                    }
                case 4: // Drug Store
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Delete from category", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.CommandText = "Delete from generic";
                        sqlcmd.ExecuteNonQuery();

                        sqlcmd.CommandText = "Update category2 set tick = '" + 0 + "' ";
                        sqlcmd.ExecuteNonQuery();

                        sqlcmd.CommandText = "Update generic2 set tick = '" + 0 + "' ";
                        sqlcmd.ExecuteNonQuery();

                        i1 = 0;
                        while (i1 < treeView1.Nodes.Count)
                        {
                            sqlcmd.CommandText = "insert into category(name) values('" + treeView1.Nodes[i1].Text + "')";
                            sqlcmd.ExecuteNonQuery();
                            sqlcmd.CommandText = "select count(*) from category2 where name='" + treeView1.Nodes[i1].Text + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into category2(name,freq,tick) values('" + treeView1.Nodes[i1].Text + "',0,1)";
                                sqlcmd.ExecuteNonQuery();
                            }
                            else
                            {
                                sqlcmd.CommandText = "Update category2 set tick = 1 where name = '" + treeView1.Nodes[i1].Text + "' ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            i2 = 0;
                            while (i2 < treeView1.Nodes[i1].Nodes.Count)
                            {
                                sqlcmd.CommandText = "insert into generic(name) values('" + treeView1.Nodes[i1].Text + '?' + treeView1.Nodes[i1].Nodes[i2].Text + "')";
                                sqlcmd.ExecuteNonQuery();
                                sqlcmd.CommandText = "update category set generic = IsNull(generic,'') + '" + treeView1.Nodes[i1].Nodes[i2].Text + "'+'?' where name ='" + treeView1.Nodes[i1].Text + "' ";
                                sqlcmd.ExecuteNonQuery();
                                sqlcmd.CommandText = "select count(*) from generic2 where name = '" + treeView1.Nodes[i1].Text + '?' + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into generic2(name,freq,tick) values('" + treeView1.Nodes[i1].Text + '?' + treeView1.Nodes[i1].Nodes[i2].Text + "',0,1)";
                                    sqlcmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    sqlcmd.CommandText = "Update generic2 set tick = 1 where name = '" + treeView1.Nodes[i1].Text + '?' + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                }

                                i3 = 0;
                                while (i3 < treeView1.Nodes[i1].Nodes[i2].Nodes.Count)
                                {
                                    sqlcmd.CommandText = "select count(*) from trade where name='" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into trade(name) values('" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "')";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                    sqlcmd.CommandText = "update generic set trade = IsNull(trade,'') + '" + treeView1.Nodes[i1].Nodes[i2].Nodes[i3].Text + "'+'?' where name ='" + treeView1.Nodes[i1].Text + "' + '?' + '" + treeView1.Nodes[i1].Nodes[i2].Text + "' ";
                                    sqlcmd.ExecuteNonQuery();
                                    i3++;
                                }
                                i2++;
                            }
                            i1++;
                        }


                        sqlcmd.CommandText = "Delete from category2 where tick = 0 ";
                        sqlcmd.ExecuteNonQuery();

                        sqlcmd.CommandText = "Delete from generic2 where tick = 0 ";
                        sqlcmd.ExecuteNonQuery();


                        sqlconn.Close();

                        break;
                    }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Instruction frm = new Instruction();
            frm.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the whole data from this system?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (comboBox1.Text == "Drug")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from category", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from generic";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from trade";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from category2";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from generic2";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                treeView1.Nodes.Clear();
            }
            
            if (comboBox1.Text == "Dx")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from Dx1", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from Dx2";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                treeView1.Nodes.Clear();
            }
            if (comboBox1.Text == "DD for Left Panel")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from ldd1", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from ldd2";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from ldd3";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from ldd4";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from ldd5";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                treeView1.Nodes.Clear();
            }
            if (comboBox1.Text == "DD for Right Panel")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from rdd1", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from rdd2";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from rdd3";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from rdd4";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from rdd5";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                treeView1.Nodes.Clear();
            }
            if (comboBox1.Text == "Px")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from px1", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px2";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px3";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px4";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px5";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px6";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px7";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px8";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Delete from px9";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                treeView1.Nodes.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Import Trees
            if (comboBox1.Text == "Drug")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Drug Store Files...";
                dlg.Filter = "Drug Store Files(*.rx)|*.rx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string query = File.ReadAllText(dlg.FileName);
                    string dx1_str, dx2_str;
                    string d1, d2;
                    int myindex;
                    bool flag = true;

                    myindex = query.IndexOf("MyRx2:");
                    dx1_str = query.Substring(0, myindex);
                    dx2_str = query.Substring(myindex + 6, query.Length - myindex - 6);

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;

                    while (flag == true)
                    {
                        myindex = dx1_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dx1_str.Substring(0, myindex);
                        dx1_str = dx1_str.Substring(myindex + 1, dx1_str.Length - myindex - 1);
                        myindex = dx1_str.IndexOf(";");
                        d2 = dx1_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into category(name,generic) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();

                        sqlcmd.CommandText = "select count(*) from category2 where name='" + d1 + "' ";
                        if (sqlcmd.ExecuteScalar().ToString() == "0")
                        {
                            sqlcmd.CommandText = "Insert into category2(name,freq,tick) values('" + d1 + "','" + 0 + "',0)";
                            sqlcmd.ExecuteNonQuery();
                        }

                        dx1_str = dx1_str.Substring(myindex + 1, dx1_str.Length - myindex - 1);
                    }
                    bool testflag;
                    int uindex;
                    string mytrade;

                    while (flag == true)
                    {
                        myindex = dx2_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dx2_str.Substring(0, myindex);
                        dx2_str = dx2_str.Substring(myindex + 1, dx2_str.Length - myindex - 1);
                        myindex = dx2_str.IndexOf(";");
                        d2 = dx2_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into generic(name,trade) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();

                        sqlcmd.CommandText = "select count(*) from generic2 where name='" + d1 + "' ";
                        if (sqlcmd.ExecuteScalar().ToString() == "0")
                        {
                            sqlcmd.CommandText = "Insert into generic2(name,freq,tick) values('" + d1 + "','" + 0 + "',0)";
                            sqlcmd.ExecuteNonQuery();
                        }

                        testflag = true;
                        while (testflag == true)
                        {
                            uindex = d2.IndexOf("?");
                            if (uindex == -1)
                                break;
                            else
                            {
                                mytrade = d2.Substring(0, uindex);
                                sqlcmd.CommandText = "select count(*) from trade where name='" + mytrade + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "Insert into trade(name) values('" + mytrade + "')";
                                    sqlcmd.ExecuteNonQuery();
                                }
                                try
                                {
                                    d2 = d2.Substring(uindex + 1, d2.Length - uindex - 1);
                                }
                                catch
                                {
                                    testflag = false;
                                }
                            }
                        }


                        dx2_str = dx2_str.Substring(myindex + 1, dx2_str.Length - myindex - 1);
                    }

                    sqlconn.Close();
                }
            } // End of Rx 

            if (comboBox1.Text == "Dx")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Definitive Diagnosis Files...";
                dlg.Filter = "Definitive Diagnosis Files(*.dx)|*.dx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string query = File.ReadAllText(dlg.FileName);
                    string dx1_str, dx2_str;
                    string d1, d2;
                    int myindex;
                    bool flag = true;

                    myindex = query.IndexOf("MyDx2:");
                    dx1_str = query.Substring(0, myindex);
                    dx2_str = query.Substring(myindex + 6, query.Length - myindex - 6);

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;

                    while (flag == true)
                    {
                        myindex = dx1_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dx1_str.Substring(0, myindex);
                        dx1_str = dx1_str.Substring(myindex + 1, dx1_str.Length - myindex - 1);
                        myindex = dx1_str.IndexOf(";");
                        d2 = dx1_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into dx1(d1,d2) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dx1_str = dx1_str.Substring(myindex + 1, dx1_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dx2_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dx2_str.Substring(0, myindex);
                        dx2_str = dx2_str.Substring(myindex + 1, dx2_str.Length - myindex - 1);
                        myindex = dx2_str.IndexOf(";");
                        d2 = dx2_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into dx2(d2,d3) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dx2_str = dx2_str.Substring(myindex + 1, dx2_str.Length - myindex - 1);
                    }

                    sqlconn.Close();
                }
            } // End of Dx 

            if (comboBox1.Text == "DD for Left Panel")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Definitive Diagnosis Files For Left Panel...";
                dlg.Filter = "Differential Diagnosis Files(*.dd)|*.dd";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string query = File.ReadAllText(dlg.FileName);
                    string dd1_str, dd2_str, dd3_str, dd4_str, dd5_str;
                    string d1, d2;
                    int myindex;
                    bool flag = true;

                    myindex = query.IndexOf("Myldd2:");
                    dd1_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 7, query.Length - myindex - 7);
                    myindex = query.IndexOf("Myldd3:");
                    dd2_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 7, query.Length - myindex - 7);
                    myindex = query.IndexOf("Myldd4:");
                    dd3_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 7, query.Length - myindex - 7);
                    myindex = query.IndexOf("Myldd5:");
                    dd4_str = query.Substring(0, myindex);
                    dd5_str = query.Substring(myindex + 7, query.Length - myindex - 7);

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;

                    while (flag == true)
                    {
                        myindex = dd1_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd1_str.Substring(0, myindex);
                        dd1_str = dd1_str.Substring(myindex + 1, dd1_str.Length - myindex - 1);
                        myindex = dd1_str.IndexOf(";");
                        d2 = dd1_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into ldd1(d1,d2) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd1_str = dd1_str.Substring(myindex + 1, dd1_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd2_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd2_str.Substring(0, myindex);
                        dd2_str = dd2_str.Substring(myindex + 1, dd2_str.Length - myindex - 1);
                        myindex = dd2_str.IndexOf(";");
                        d2 = dd2_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into ldd2(d2,d3) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd2_str = dd2_str.Substring(myindex + 1, dd2_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd3_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd3_str.Substring(0, myindex);
                        dd3_str = dd3_str.Substring(myindex + 1, dd3_str.Length - myindex - 1);
                        myindex = dd3_str.IndexOf(";");
                        d2 = dd3_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into ldd3(d3,d4) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd3_str = dd3_str.Substring(myindex + 1, dd3_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd4_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd4_str.Substring(0, myindex);
                        dd4_str = dd4_str.Substring(myindex + 1, dd4_str.Length - myindex - 1);
                        myindex = dd4_str.IndexOf(";");
                        d2 = dd4_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into ldd4(d4,d5) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd4_str = dd4_str.Substring(myindex + 1, dd4_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd5_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd5_str.Substring(0, myindex);
                        dd5_str = dd5_str.Substring(myindex + 1, dd5_str.Length - myindex - 1);
                        myindex = dd5_str.IndexOf(";");
                        d2 = dd5_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into ldd5(d5,d6) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd5_str = dd5_str.Substring(myindex + 1, dd5_str.Length - myindex - 1);
                    }




                    sqlconn.Close();
                }
            } // End of DD for left panel


            if (comboBox1.Text == "DD for Right Panel")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Definitive Diagnosis Files For Right Panel...";
                dlg.Filter = "Differential Diagnosis Files(*.dd)|*.dd";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string query = File.ReadAllText(dlg.FileName);
                    string dd1_str, dd2_str, dd3_str, dd4_str, dd5_str;
                    string d1, d2;
                    int myindex;
                    bool flag = true;

                    myindex = query.IndexOf("Myldd2:");
                    dd1_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 7, query.Length - myindex - 7);
                    myindex = query.IndexOf("Myldd3:");
                    dd2_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 7, query.Length - myindex - 7);
                    myindex = query.IndexOf("Myldd4:");
                    dd3_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 7, query.Length - myindex - 7);
                    myindex = query.IndexOf("Myldd5:");
                    dd4_str = query.Substring(0, myindex);
                    dd5_str = query.Substring(myindex + 7, query.Length - myindex - 7);

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;

                    while (flag == true)
                    {
                        myindex = dd1_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd1_str.Substring(0, myindex);
                        dd1_str = dd1_str.Substring(myindex + 1, dd1_str.Length - myindex - 1);
                        myindex = dd1_str.IndexOf(";");
                        d2 = dd1_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into rdd1(d1,d2) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd1_str = dd1_str.Substring(myindex + 1, dd1_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd2_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd2_str.Substring(0, myindex);
                        dd2_str = dd2_str.Substring(myindex + 1, dd2_str.Length - myindex - 1);
                        myindex = dd2_str.IndexOf(";");
                        d2 = dd2_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into rdd2(d2,d3) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd2_str = dd2_str.Substring(myindex + 1, dd2_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd3_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd3_str.Substring(0, myindex);
                        dd3_str = dd3_str.Substring(myindex + 1, dd3_str.Length - myindex - 1);
                        myindex = dd3_str.IndexOf(";");
                        d2 = dd3_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into rdd3(d3,d4) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd3_str = dd3_str.Substring(myindex + 1, dd3_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd4_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd4_str.Substring(0, myindex);
                        dd4_str = dd4_str.Substring(myindex + 1, dd4_str.Length - myindex - 1);
                        myindex = dd4_str.IndexOf(";");
                        d2 = dd4_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into rdd4(d4,d5) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd4_str = dd4_str.Substring(myindex + 1, dd4_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd5_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd5_str.Substring(0, myindex);
                        dd5_str = dd5_str.Substring(myindex + 1, dd5_str.Length - myindex - 1);
                        myindex = dd5_str.IndexOf(";");
                        d2 = dd5_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into rdd5(d5,d6) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd5_str = dd5_str.Substring(myindex + 1, dd5_str.Length - myindex - 1);
                    }

                    sqlconn.Close();
                }
            } // End of DD for left panel




            if (comboBox1.Text == "Px")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Diagnostic Procedure Files...";
                dlg.Filter = "Diagnostic Procedure Files(*.px)|*.px";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string query = File.ReadAllText(dlg.FileName);
                    string dd1_str, dd2_str, dd3_str, dd4_str, dd5_str, dd6_str, dd7_str, dd8_str, dd9_str;
                    string d1, d2;
                    int myindex;
                    bool flag = true;

                    myindex = query.IndexOf("Mypx2:");
                    dd1_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx3:");
                    dd2_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx4:");
                    dd3_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx5:");
                    dd4_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx6:");
                    dd5_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx7:");
                    dd6_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx8:");
                    dd7_str = query.Substring(0, myindex);
                    query = query.Substring(myindex + 6, query.Length - myindex - 6);
                    myindex = query.IndexOf("Mypx9:");
                    dd8_str = query.Substring(0, myindex);
                    dd9_str = query.Substring(myindex + 6, query.Length - myindex - 6);


                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;

                    while (flag == true)
                    {
                        myindex = dd1_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd1_str.Substring(0, myindex);
                        dd1_str = dd1_str.Substring(myindex + 1, dd1_str.Length - myindex - 1);
                        myindex = dd1_str.IndexOf(";");
                        d2 = dd1_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px1(d1,d2) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd1_str = dd1_str.Substring(myindex + 1, dd1_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd2_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd2_str.Substring(0, myindex);
                        dd2_str = dd2_str.Substring(myindex + 1, dd2_str.Length - myindex - 1);
                        myindex = dd2_str.IndexOf(";");
                        d2 = dd2_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px2(d2,d3) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd2_str = dd2_str.Substring(myindex + 1, dd2_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd3_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd3_str.Substring(0, myindex);
                        dd3_str = dd3_str.Substring(myindex + 1, dd3_str.Length - myindex - 1);
                        myindex = dd3_str.IndexOf(";");
                        d2 = dd3_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px3(d3,d4) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd3_str = dd3_str.Substring(myindex + 1, dd3_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd4_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd4_str.Substring(0, myindex);
                        dd4_str = dd4_str.Substring(myindex + 1, dd4_str.Length - myindex - 1);
                        myindex = dd4_str.IndexOf(";");
                        d2 = dd4_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px4(d4,d5) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd4_str = dd4_str.Substring(myindex + 1, dd4_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd5_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd5_str.Substring(0, myindex);
                        dd5_str = dd5_str.Substring(myindex + 1, dd5_str.Length - myindex - 1);
                        myindex = dd5_str.IndexOf(";");
                        d2 = dd5_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px5(d5,d6) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd5_str = dd5_str.Substring(myindex + 1, dd5_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd6_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd6_str.Substring(0, myindex);
                        dd6_str = dd6_str.Substring(myindex + 1, dd6_str.Length - myindex - 1);
                        myindex = dd6_str.IndexOf(";");
                        d2 = dd6_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px6(d6,d7) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd6_str = dd6_str.Substring(myindex + 1, dd6_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd7_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd7_str.Substring(0, myindex);
                        dd7_str = dd7_str.Substring(myindex + 1, dd7_str.Length - myindex - 1);
                        myindex = dd7_str.IndexOf(";");
                        d2 = dd7_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px7(d7,d8) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd7_str = dd7_str.Substring(myindex + 1, dd7_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd8_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd8_str.Substring(0, myindex);
                        dd8_str = dd8_str.Substring(myindex + 1, dd8_str.Length - myindex - 1);
                        myindex = dd8_str.IndexOf(";");
                        d2 = dd8_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px8(d8,d9) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd8_str = dd8_str.Substring(myindex + 1, dd8_str.Length - myindex - 1);
                    }

                    while (flag == true)
                    {
                        myindex = dd9_str.IndexOf(";");
                        if (myindex == -1)
                        {
                            break;
                        }
                        d1 = dd9_str.Substring(0, myindex);
                        dd9_str = dd9_str.Substring(myindex + 1, dd9_str.Length - myindex - 1);
                        myindex = dd9_str.IndexOf(";");
                        d2 = dd9_str.Substring(0, myindex);
                        sqlcmd.CommandText = "Insert into px9(d9,d10) values('" + d1 + "','" + d2 + "')";
                        sqlcmd.ExecuteNonQuery();
                        dd9_str = dd9_str.Substring(myindex + 1, dd9_str.Length - myindex - 1);
                    }



                    sqlconn.Close();
                }
            } // End of Px

            
            button1_Click(button1,e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Export Trees
            if (comboBox1.Text == "Drug")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Drug Store Files(*.rx)|*.rx";
                dlg.Title = "Export as Drug Store File...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string temp = "";

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select * from category ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["name"].ToString() + ";";
                        temp += data["generic"].ToString() + ";";
                    }
                    data.Close();

                    temp += "MyRx2:";

                    sqlcmd.CommandText = "select * from generic ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["name"].ToString() + ";";
                        temp += data["trade"].ToString() + ";";
                    }

                    data.Close();
                    sqlconn.Close();

                    File.WriteAllText(dlg.FileName, temp);
                } // End of Save Dialog
            } // End of If Rx

            if (comboBox1.Text == "Dx")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Definitive Diagnosis Files(*.dx)|*.dx";
                dlg.Title = "Export as Definitive Diagnosis File...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string temp = "";

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select * from dx1 ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d1"].ToString() + ";";
                        temp += data["d2"].ToString() + ";";
                    }
                    data.Close();

                    temp += "MyDx2:";

                    sqlcmd.CommandText = "select * from dx2 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d2"].ToString() + ";";
                        temp += data["d3"].ToString() + ";";
                    }

                    data.Close();
                    sqlconn.Close();

                    File.WriteAllText(dlg.FileName, temp);
                } // End of Save Dialog
            } // End of If Dx

            if (comboBox1.Text == "DD for Left Panel")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Differential Diagnosis Files(*.dd)|*.dd";
                dlg.Title = "Export as Differential Diagnosis File for Left Panel...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string temp = "";

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select * from ldd1 ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d1"].ToString() + ";";
                        temp += data["d2"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd2:";

                    sqlcmd.CommandText = "select * from ldd2 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d2"].ToString() + ";";
                        temp += data["d3"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd3:";

                    sqlcmd.CommandText = "select * from ldd3 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d3"].ToString() + ";";
                        temp += data["d4"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd4:";

                    sqlcmd.CommandText = "select * from ldd4 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d4"].ToString() + ";";
                        temp += data["d5"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd5:";

                    sqlcmd.CommandText = "select * from ldd5 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d5"].ToString() + ";";
                        temp += data["d6"].ToString() + ";";
                    }
                    data.Close();

                    sqlconn.Close();

                    File.WriteAllText(dlg.FileName, temp);
                } // End of Save Dialog
            } // End of If DD for Left Panel

            if (comboBox1.Text == "DD for Right Panel")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Differential Diagnosis Files(*.dd)|*.dd";
                dlg.Title = "Export as Differential Diagnosis File for Right Panel...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string temp = "";

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select * from rdd1 ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d1"].ToString() + ";";
                        temp += data["d2"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd2:";

                    sqlcmd.CommandText = "select * from rdd2 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d2"].ToString() + ";";
                        temp += data["d3"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd3:";

                    sqlcmd.CommandText = "select * from rdd3 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d3"].ToString() + ";";
                        temp += data["d4"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd4:";

                    sqlcmd.CommandText = "select * from rdd4 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d4"].ToString() + ";";
                        temp += data["d5"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Myldd5:";

                    sqlcmd.CommandText = "select * from rdd5 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d5"].ToString() + ";";
                        temp += data["d6"].ToString() + ";";
                    }
                    data.Close();

                    sqlconn.Close();

                    File.WriteAllText(dlg.FileName, temp);
                } // End of Save Dialog
            } // End of If DD for Right Panel

            if (comboBox1.Text == "Px")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Diagnostic Procedure Files(*.px)|*.px";
                dlg.Title = "Export as Diagnostic Procedure File...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string temp = "";

                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select * from px1 ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d1"].ToString() + ";";
                        temp += data["d2"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx2:";

                    sqlcmd.CommandText = "select * from px2 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d2"].ToString() + ";";
                        temp += data["d3"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx3:";

                    sqlcmd.CommandText = "select * from px3 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d3"].ToString() + ";";
                        temp += data["d4"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx4:";

                    sqlcmd.CommandText = "select * from px4 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d4"].ToString() + ";";
                        temp += data["d5"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx5:";

                    sqlcmd.CommandText = "select * from px5 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d5"].ToString() + ";";
                        temp += data["d6"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx6:";

                    sqlcmd.CommandText = "select * from px6 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d6"].ToString() + ";";
                        temp += data["d7"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx7:";

                    sqlcmd.CommandText = "select * from px7 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d7"].ToString() + ";";
                        temp += data["d8"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx8:";

                    sqlcmd.CommandText = "select * from px8 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d8"].ToString() + ";";
                        temp += data["d9"].ToString() + ";";
                    }
                    data.Close();

                    temp += "Mypx9:";

                    sqlcmd.CommandText = "select * from px9 ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        temp += data["d9"].ToString() + ";";
                        temp += data["d10"].ToString() + ";";
                    }
                    data.Close();


                    sqlconn.Close();

                    File.WriteAllText(dlg.FileName, temp);
                } // End of Save Dialog
            } // End of If DD for Right Panel

        }
    }
}