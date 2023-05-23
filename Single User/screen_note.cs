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
    public partial class screen_note : Form
    {
        public static string str_screen_note = "";
        public screen_note()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_screen_note == "")
                        str_screen_note = str_screen_note + checkedListBox1.Items[i].ToString();
                    else
                        str_screen_note = str_screen_note + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new screen_note2();

            if(this.Top < 300)
              frm.Top = this.Top + 220;
            else
              frm.Top = this.Top - 230;

            frm.Left = this.Left;
            frm.ShowDialog();

            str_screen_note = screen_note2.str_screen_note2;
        }

        private void screen_note_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_screen_note = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct screen_note from preventive where screen_note<>'' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["screen_note"].ToString());
            data.Close();

            sqlconn.Close();
        }
    }
}