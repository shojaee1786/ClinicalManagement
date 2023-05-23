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
    public partial class Alter_Envelop : Form
    {
        public Alter_Envelop()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mylistbox.Items.Clear();
            mytextbox.Text = "";

            if (comboBox1.SelectedItem.ToString() == "��� ������� �����")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct doctor from print_tmp where doctor<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    mylistbox.Items.Insert(i, data["doctor"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mytextbox.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                SqlDataReader data;

                if (comboBox1.Text == "��� ������� �����")
                {
                     sqlcmd.CommandText = "select count(*) from print_tmp where doctor = '" + mytextbox.Text + "' ";
                     if (sqlcmd.ExecuteScalar().ToString() == "0")
                     {
                         sqlcmd.CommandText = "Insert into print_tmp(doctor) values('" + mytextbox.Text + "') ";
                         sqlcmd.ExecuteNonQuery();
                     }

                    mylistbox.Items.Clear();
                    mytextbox.Text = "";
                    sqlcmd.CommandText = "select distinct doctor from print_tmp where doctor<>'' ";
                    data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        mylistbox.Items.Insert(i, data["doctor"].ToString());
                        i++;
                    }
                    data.Close();
                }

                sqlconn.Close();
            } // End of IF(Mytext...)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;

                if (comboBox1.Text == "��� ������� �����")
                {

                    sqlcmd.CommandText = "Update print_tmp set doctor = '' where doctor = '"+ mytextbox.Text +"' ";
                    sqlcmd.ExecuteNonQuery();

                    comboBox1_SelectedIndexChanged(sender, e);
                }

                sqlconn.Close();

            }
            catch { }
        }

        private void Alter_Envelop_Load(object sender, EventArgs e)
        {
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

            sqlconn.Close();
            
        }

        private void Alter_Envelop_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void mylistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mytextbox.Text = mylistbox.SelectedItem.ToString();
            }
            catch { }
        }

        private void mytextbox_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }
    }
}