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
    public partial class setting2 : Form
    {
        public setting2()
        {
            InitializeComponent();
        }

        private void setting2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from temp where form='" + this.Name + "' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();
            sqlconn.Close();

        }

        private void setting2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB3\\instruction.doc");
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB3\\Photo");
            }
            catch { }
        }

        private void second_r_sb1_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb1.Enabled = false;
            minute_n_sb1.Enabled = false;
            second_n_sb1.Enabled = true;
        }

        private void hour_r_sb1_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb1.Enabled = true;
            minute_n_sb1.Enabled = false;
            second_n_sb1.Enabled = false;
        }

        private void minute_r_sb1_CheckedChanged(object sender, EventArgs e)
        {
            hour_n_sb1.Enabled = false;
            minute_n_sb1.Enabled = true;
            second_n_sb1.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            if (hour_n_sb1.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + hour_n.Value * 3600000 + "')";
                sqlcmd.CommandText = "Update sw set sw3timer ='" + hour_n_sb1.Value * 3600000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            if (minute_n_sb1.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + minute_n.Value * 60000 + "')";
                sqlcmd.CommandText = "Update sw set sw3timer ='" + minute_n_sb1.Value * 60000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            if (second_n_sb1.Enabled == true)
            {
                //sqlcmd.CommandText = "Insert into sw(sw1timer) values('" + second_n.Value * 1000 + "')";
                sqlcmd.CommandText = "Update sw set sw3timer ='" + second_n_sb1.Value * 1000 + "' ";
                sqlcmd.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SB3\\Sound");
            }
            catch { }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Secretary Help.pdf");
            }
            catch { }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Secretary Help.doc");
            }
            catch { }

        }
    }
}