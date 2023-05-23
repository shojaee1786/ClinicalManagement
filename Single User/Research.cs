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
    public partial class Research : Form
    {
        public Research()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(button2.Visible == false)
            {
            richTextBox1.Visible = true;
            button2.Visible = true;
            }
            else
            {
                richTextBox1.Visible = false;
                button2.Visible = false;
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (button1.Visible == true)
                button1.Visible = false;
            else
                button1.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (p1_c.Visible == true)
            {
                p1_c.Visible = false;
                ok_b.Visible = false;
            }
            else
            {
                p1_c.Visible = true;
                ok_b.Visible = true;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (p2_c.Visible == true)
            {
                p2_c.Visible = false;
                ok2_b.Visible = false;
            }
            else
            {
                p2_c.Visible = true;
                ok2_b.Visible = true;
            }

        }

        private void Research_Click(object sender, EventArgs e)
        {
            if (button2.Visible == false)
            {
                richTextBox1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                p1_c.Visible = true;
                p2_c.Visible = true;
                ok_b.Visible = true;
                ok2_b.Visible = true;
            }
            else
            {
                richTextBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                p1_c.Visible = false;
                p2_c.Visible = false;
                ok_b.Visible = false;
                ok2_b.Visible = false;
            }
        }

        private void Research_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select * from temp where form='" + this.Name + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "select proposal from research";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                richTextBox1.Text = data["proposal"].ToString();
            data.Close();

            int i = 0;
            sqlcmd.CommandText = "select distinct p1 from research where p1<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                p1_c.Items.Insert(i,data["p1"].ToString());
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct p2 from research where p2<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                p2_c.Items.Insert(i, data["p2"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void Research_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Replace("'", "''");
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Update research set proposal = '" + richTextBox1.Text + "'  ", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch
            {
                MessageBox.Show("Characters must be limited to less than 8000");
            }

            richTextBox1.Text = richTextBox1.Text.Replace("''", "'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p1_c.Text == "")
                return;
            string s = p1_c.Text;
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p1_src from research where p1 = '" + s + "' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p1_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please install '" + p1_c.Text + "' first by going to the settings and configuring '" + p1_c.Text + "' program with appropriate installation icon ", "Notification");
            }
        }

        private void p1_c_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search_data frm = new search_data();
            frm.ShowDialog();
        }

        private void ok2_b_Click(object sender, EventArgs e)
        {
            if (p2_c.Text == "")
                return;
            string s = p2_c.Text;
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p2_src from research where p2 = '" + s + "' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p2_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please install '" + p2_c.Text + "' first by going to the settings and configuring '" + p2_c.Text + "' program with appropriate installation icon ", "Notification");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Research.doc");
            }
            catch { }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}