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
    public partial class Malol : Form
    {
        public static string str_malol = "";
        public Malol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_malol == "")
                        str_malol = str_malol + checkedListBox1.Items[i].ToString();
                    else
                        str_malol = str_malol + " + " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void Malol_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_malol = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct malol from info where malol<>''", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["malol"].ToString());
            data.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            str_malol = "1";
            this.Close();
        }
    }
}