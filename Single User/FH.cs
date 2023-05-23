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
    public partial class FH : Form
    {
        public static string str_fh = "";
        public FH()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_fh == "")
                        str_fh = str_fh + checkedListBox1.Items[i].ToString();
                    else
                        str_fh = str_fh + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new FH2();

            if(this.Top < 300)
              frm.Top = this.Top + 220;
            else
              frm.Top = this.Top - 230;

            frm.Left = this.Left;
            frm.ShowDialog();

            str_fh = FH2.str_fh2;
        }

        private void FH_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_fh = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct fh from firstvisit where fh<>''  and ffh = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["fh"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}