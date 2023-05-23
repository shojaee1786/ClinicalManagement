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
    public partial class default_time : Form
    {
        public static string default_time_s = "";
        
        public default_time()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
                    
            
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            // ÊÇííÏ

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "Update sw set default_time = '"+ default_time_s +"' ";
            sqlcmd.ExecuteNonQuery();

            sqlconn.Close();

            this.Close();
        }
    }
}