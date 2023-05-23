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
    public partial class Manage_Template : Form
    {
        public Manage_Template()
        {
            InitializeComponent();
        }

        private void Manage_Template_Load(object sender, EventArgs e)
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

            sqlcmd.CommandText = "Select distinct template from print_t where template<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                tem_c.Items.Add(data["template"].ToString());
            }
            data.Close();


            op_c.Items.Clear();
            op_c.Items.Add("—”Ìœ ÊÃÂ");
            op_c.Items.Add("êÊ«ÂÌ «” —«Õ ");
            op_c.Items.Add("’Ê— Õ”«»");
            op_c.Items.Add("‰«„Â Â«Ì „ ›—ﬁÂ");
            op_c.Items.Add("Prescription");
            op_c.Items.Add("Referral");

            sqlcmd.CommandText = "Select distinct d1 from px1 where d1<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                op_c.Items.Add(data["d1"].ToString());
            }
            data.Close();


            template_l.Items.Clear();
            temp2_t.Text = "";
            sqlcmd.CommandText = "select distinct template from print_t where template<>'' ";
            data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                template_l.Items.Insert(i, data["template"].ToString());
                i++;
            }
            data.Close();


            sqlconn.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Insert into template(template,op) values('" + tem_c.Text + "','" + op_c.Text + "') ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void template_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                temp2_t.Text = template_l.SelectedItem.ToString();
            }
            catch { }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                if (temp2_t.Text != "")
                {
                    temp2_t.Text = temp2_t.Text.Replace("'", "''");
                    ///////////////////
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update template set template='" + temp2_t.Text.Trim() + "' where fadesc='" + template_l.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    
                    sqlcmd.CommandText = "update print_t set template = '" + temp2_t.Text.Trim() + "' where template = '" + template_l.SelectedItem.ToString() + "' ";
                    sqlcmd.ExecuteNonQuery();


                    template_l.Items.Clear();
                    temp2_t.Text = "";
                    sqlcmd.CommandText = "select distinct template from print_t where template<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        template_l.Items.Insert(i, data["template"].ToString());
                        i++;
                    }
                    data.Close();

                    sqlconn.Close();
                }
            }
            catch { }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from template where template='" + template_l.SelectedItem.ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = "Delete from print_t where template = '"+ template_l.SelectedItem.ToString() +"' ";
                sqlcmd.ExecuteNonQuery();

                template_l.Items.Clear();
                temp2_t.Text = "";
                sqlcmd.CommandText = "select distinct template from print_t where template<>'' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    template_l.Items.Insert(i, data["template"].ToString());
                    i++;
                }
                data.Close();

                sqlconn.Close();
            }
            catch { }
        }

        private void Manage_Template_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void tem_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            op_c.Text = "";
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;
            
            sqlcmd.CommandText = "Select op from template where template = '"+ tem_c.Text +"' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                op_c.Text = data["op"].ToString();
            }
            data.Close();

            sqlconn.Close();
        }
    }
}