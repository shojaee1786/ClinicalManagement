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
    public partial class imm_adult_note2 : Form
    {
        public static string str_imm_adult_note2 = "";
        public imm_adult_note2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_imm_adult_note2 == "")
                        str_imm_adult_note2 = str_imm_adult_note2 + checkedListBox1.Items[i].ToString();
                    else
                        str_imm_adult_note2 = str_imm_adult_note2 + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void imm_adult_note2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_imm_adult_note2 = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct imm_adult_parag from preventive where imm_adult_parag<>'' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["imm_adult_parag"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}