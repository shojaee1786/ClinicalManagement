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
    public partial class imm_child_note : Form
    {
        public static string str_imm_child_note = "";
        public imm_child_note()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_imm_child_note == "")
                        str_imm_child_note = str_imm_child_note + checkedListBox1.Items[i].ToString();
                    else
                        str_imm_child_note = str_imm_child_note + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new imm_child_note2();

            if(this.Top < 300)
              frm.Top = this.Top + 220;
            else
              frm.Top = this.Top - 230;

            frm.Left = this.Left;
            frm.ShowDialog();

            str_imm_child_note = imm_child_note2.str_imm_child_note2;
        }

        private void imm_child_note_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_imm_child_note = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct imm_child_note from preventive where imm_child_note<>'' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["imm_child_note"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}