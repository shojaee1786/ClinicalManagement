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
    public partial class As2 : Form
    {
        public static string str_as2 = "";
        public As2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_as2 == "")
                        str_as2 = str_as2 + checkedListBox1.Items[i].ToString();
                    else
                        str_as2 = str_as2 + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void As2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_as2 = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct ass2 from secondvisit where ass2<>'' and fas2 = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["ass2"].ToString());
            data.Close();
            sqlconn.Close();
        }
    }
}