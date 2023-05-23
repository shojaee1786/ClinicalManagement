using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clinical_Management
{
    public partial class ChangeForm : Form
    {
        public static string rdate, rsb, rob, ras, rpl, rdd, rpx, rrx, rip, rop, rco, rpc;
        public static Int64 par;
        public static int visit;
        
        public ChangeForm()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            
            sqlcmd.CommandText = "select count(*) from sick2 where par='" + par + "' and visit='" + visit + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "insert into sick2(par,visit,rdate,sb,ob,ass,pl,dd,px,rx,ip,op,co,pc) values('" + par + "','" + visit + "','" + rdate + "','" + rsb + "','" + rob + "','" + ras + "','" + rpl + "','" + rdd + "','" + rpx + "','" + rrx + "','" + rip + "','" + rop + "','" + rco + "','" + rpc + "')";
                sqlcmd.ExecuteNonQuery();
                if (visit == Patient.maxpage)
                {
                   sqlcmd.CommandText = "Update var1 set lastvisit=lastvisit+1 where par='" + par + "'";
                   sqlcmd.ExecuteNonQuery();
                }
            }
            else
            {
                sqlcmd.CommandText = "Update sick2 set visit='" + visit + "',rdate='" + rdate + "',sb='" + rsb + "',ob='" + rob + "',ass='" + ras + "',pl='" + rpl + "',dd='" + rdd + "',px='" + rpx + "',rx='" + rrx + "',ip='" + rip + "',op='" + rop + "',co='" + rco + "',pc='" + rpc + "' where par='" + par + "' and visit='" + visit + "' ";
                sqlcmd.ExecuteNonQuery();
            }


            sqlconn.Close();           
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}