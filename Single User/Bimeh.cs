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
    public partial class Bimeh : Form
    {
        public static string str_bimeh = "";
        public Bimeh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_bimeh == "")
                        str_bimeh = str_bimeh + checkedListBox1.Items[i].ToString();
                    else
                        str_bimeh = str_bimeh + " + " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void Bimeh_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_bimeh = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct bimeh from info where bimeh<>''", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["bimeh"].ToString());
            data.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            str_bimeh = "1";
            this.Close();
        }
    }
}