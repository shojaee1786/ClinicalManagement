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
    public partial class As : Form
    {
        public static string str_as = "";
        public As()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str_as == "")
                        str_as = str_as + checkedListBox1.Items[i].ToString();
                    else
                        str_as = str_as + ", " + checkedListBox1.Items[i].ToString();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new As2();

            if(this.Top < 300)
              frm.Top = this.Top + 220;
            else
              frm.Top = this.Top - 230;

            frm.Left = this.Left;
            frm.ShowDialog();

            str_as = As2.str_as2;
        }

        private void As_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str_as = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct ass from secondvisit where ass<>'' and fas = '" + Patient.filter + "' ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["ass"].ToString());
            data.Close();
            sqlconn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkedListBox1.Width = checkedListBox1.Width + 20;
            this.Width = this.Width + 20;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Width >= 320)
            {
                checkedListBox1.Width = checkedListBox1.Width - 20;
                this.Width = this.Width - 20;
            }
        }
    }
}