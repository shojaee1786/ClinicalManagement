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
    public partial class rpx2 : Form
    {
        public static string str_rpx2 = "";
        public rpx2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_rpx2 == "")
                        str_rpx2 = str_rpx2 + checkedListBox1.Items[i].ToString();
                    else
                        str_rpx2 = str_rpx2 + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void rpx2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_rpx2 = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct px2 from secondvisit where px2<>'' and fpx2 = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["px2"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}