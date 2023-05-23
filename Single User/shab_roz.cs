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
    public partial class shab_roz : Form
    {
        public static string rdate, rsb, rob, ras, rpl, rdd, rpx, rrx, rip, rop, rco, rpc;
        public static Int64 par;
        public static int visit;
        
        public shab_roz()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            nobat.shab = true;        
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            nobat.shab = false;
            this.Close();
        }
    }
}