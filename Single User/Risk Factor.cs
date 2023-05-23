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
    public partial class Risk_Factor : Form
    {
        public Risk_Factor()
        {
            InitializeComponent();
        }

        private void Risk_Factor_Load(object sender, EventArgs e)
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

            sqlcmd.CommandText = "select distinct query from risk where query<>'' ";
            data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                query_c.Items.Insert(i,data["query"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct taction from risk where taction<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                action_t.AutoCompleteCustomSource.Add(data["taction"].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "select risk from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                i = Int32.Parse(data["risk"].ToString());
            data.Close();

            if (i == 1)
            {
                active_r.Checked = true;
            }
            else
            {
                inactive_r.Checked = true;
            }

            sqlconn.Close();
        }

        private void Risk_Factor_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Risk2 frm = new Risk2();
            frm.ShowDialog();

            if (Risk2.MyRisk != "")
            {
                query_c.Items.Insert(0, Risk2.MyRisk);
                query_c.SelectedIndex = 0;
            }

        }

        private void save_b_Click(object sender, EventArgs e)
        {
            if (color_c.Text == "" || action_t.Text == "" || query_c.Text == "")
            {
                MessageBox.Show("Please Follow steps in instrauction and complete all critria asked", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (query_c.Text != "")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Delete from risk where query = '"+ query_c.Text +"' ", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "Insert into risk(query,taction,color) values('" + query_c.Text + "','" + action_t.Text + "','" + color_c.Text + "') ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }

            Risk_Factor_Alarm.risk_color = color_c.Text;
            Risk_Factor_Alarm.risk_action = action_t.Text;
            Risk_Factor_Alarm.risk_query = query_c.Text;

            query_c.Text = "";
            action_t.Text = "";
            color_c.Text = "";


            Risk_Factor_Alarm frm = new Risk_Factor_Alarm();
            frm.ShowDialog();
        }

        private void query_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            action_t.Text = "";
            color_c.Text = "";
            
            if (query_c.Text == "")
                return;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select taction,color from risk where query = '"+ query_c.Text +"' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                action_t.Text = data["taction"].ToString();
                color_c.Text = data["color"].ToString();
            }
            data.Close();
             
            sqlconn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Risk Factor.doc");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("Delete risk where query = '"+ query_c.Text +"' ", sqlconn);
            sqlcmd.ExecuteNonQuery();

            query_c.Items.Clear();

            sqlcmd.CommandText = "select distinct query from risk where query<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                query_c.Items.Insert(i, data["query"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();

            query_c.Text = "";
            action_t.Text = "";
            color_c.Text = "";


        }

        private void action_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void Risk_Factor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            if (active_r.Checked == true)
            {
                sqlcmd.CommandText = "Update sw set risk='" + 1 + "'  ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            {
                sqlcmd.CommandText = "Update sw set risk='" + 0 + "'  ";
                sqlcmd.ExecuteNonQuery();
            }
            sqlconn.Close();
        }
    }
}