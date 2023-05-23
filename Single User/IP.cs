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
    public partial class IP : Form
    {
        public static string str_ip = "";
        public IP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_ip == "")
                        str_ip = str_ip + checkedListBox1.Items[i].ToString();
                    else
                        str_ip = str_ip + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new IP2();

            if (this.Top < 300)
                frm.Top = this.Top + 220;
            else
                frm.Top = this.Top - 230;

            frm.Left = this.Left;
            frm.ShowDialog();

            str_ip = IP2.str_ip2;
        }

        private void IP_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_ip = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct ip from firstvisit where ip<>'' and fip = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["ip"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}