using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Utils;
using System.Threading;

namespace Clinical_Management
{
    public partial class del_days : Form
    {
        public static string rdate, rsb, rob, ras, rpl, rdd, rpx, rrx, rip, rop, rco, rpc;
        public static Int64 par;
        public static int visit;
        
        public del_days()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            // ÊÇííÏ
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "Delete from nobat";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();

            this.Close();
            
        }

        void MyDel()
        {
            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            Int64 mytoday = cm.date2day(today);

            //try
            //{
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;

                sqlcmd.CommandText = "select date1 from nobat where date1<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();

                String sdate;
                Int64 idate;

                SqlConnection sqlconn2 = new SqlConnection(cm.cs);
                
                sqlconn2.Open();
            
                SqlCommand sqlcmd2 = new SqlCommand();
                sqlcmd2.Connection = sqlconn2;
                sqlcmd2.CommandTimeout = 1000;

                while (data.Read())
                {
                    sdate = data["date1"].ToString();
                    idate = cm.date2day(sdate);
                    if (idate < mytoday)
                    {
                        sqlcmd2.CommandText = "Delete from nobat where date1 = '" + sdate + "' ";
                        sqlcmd2.ExecuteNonQuery();
                    }
                }
                data.Close();


                sqlconn.Close();
                sqlconn2.Close();

            //}
            //catch {
                MessageBox.Show("d");
            //}



            this.Close();
        }






        private void No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(TestDel));
            t.Name = "Test Del";
            t.IsBackground = true;
            t.Start();
        }

        void TestDel()
        {
          
           
            nobat frmm = new nobat();
            frmm.faMonthView1.SelectedDateTime = FarsiLibrary.Utils.PersianDate.Now;
            string date1 = frmm.faMonthView1.Year.ToString() + "/" + frmm.faMonthView1.Month.ToString() + "/" + frmm.faMonthView1.Day.ToString();
            MessageBox.Show(date1);

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "DROP TABLE [dbo].[nobat2]";
            sqlcmd.ExecuteNonQuery();
            
            sqlcmd.CommandText = "CREATE TABLE [dbo].[nobat2](	[doctor] [varchar](50) NULL,	[date1] [varchar](50) NULL,	[row] [varchar](50) NULL,	[hour1] [varchar](50) NULL,	[name] [varchar](50) NULL,	[family] [varchar](50) NULL,	[tel] [varchar](50) NULL) ON [PRIMARY]";
            sqlcmd.ExecuteNonQuery();

            SqlConnection sqlconn2 = new SqlConnection(cm.cs);

            sqlconn2.Open();

            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;

             string d = "";
                string h = "";
                string n = "";
                string f = "";
                string t = "";
                string r = "";

            sqlcmd.CommandText = "select * from nobat where date1 = '" + date1 + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                 d = data["doctor"].ToString();
                 h = data["hour1"].ToString();
                 n = data["name"].ToString();
                 f = data["family"].ToString();
                 t = data["tel"].ToString();
                 r = data["row"].ToString();

                 sqlcmd2.CommandText = "Insert into nobat2(date1,doctor,hour1,name,family,tel,row) values('" + date1 + "','" + d + "','" + h + "','" + n + "','" + f + "','" + t + "','" + r + "')";
                 sqlcmd2.ExecuteNonQuery();
            }
            data.Close();





            sqlcmd.CommandText = "delete from nobat ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();
            sqlconn2.Close();

        }

        



    }
}