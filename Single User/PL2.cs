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
    public partial class PL2 : Form
    {
        public static string str_pl2 = "";
        public PL2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_pl2 == "")
                        str_pl2 = str_pl2 + checkedListBox1.Items[i].ToString();
                    else
                        str_pl2 = str_pl2 + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void PL2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_pl2 = "";
            
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct pl2 from secondvisit where pl2<>'' and fpl2 = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["pl2"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}