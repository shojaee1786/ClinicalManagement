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
    public partial class reset_time : Form
    {
        public static string rdate, rsb, rob, ras, rpl, rdd, rpx, rrx, rip, rop, rco, rpc;
        public static Int64 par;
        public static int visit;
        
        public reset_time()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            nobat.reset_t = true;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            nobat.reset_t = false;
            this.Close();
        }

    }
}