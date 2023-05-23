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
    public partial class FH2 : Form
    {
        public static string str_fh2 = "";
        public FH2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_fh2 == "")
                        str_fh2 = str_fh2 + checkedListBox1.Items[i].ToString();
                    else
                        str_fh2 = str_fh2 + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void FH2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_fh2 = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct fh2 from firstvisit where fh2<>'' and ffh2 = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["fh2"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}