using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Clinical_Management
{
    public partial class Referral : Form
    {
        public static bool referral_pp;
        public static string fname, family, px;
        public Referral()
        {
            InitializeComponent();
        }

        private void Referral_Load(object sender, EventArgs e)
        {
            if (referral_pp == true)
            {
                
                fname_l.Text = fname;
                family_l.Text = family;
            }
            else
            {
                fname_l.Text = "";
                family_l.Text = "";
            }
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

            sqlcmd.CommandText = "select distinct profession from tel_tmp where profession<>'' and profession<>'Patient' ";
            data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                prf_c.Items.Insert(i, data["profession"].ToString());
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct form from referral where form<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            while (data.Read())
            {
                form_c.Items.Insert(i, data["form"].ToString());
                i++;
            }
            data.Close();


            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                for (i = 0; i < 14; i++)
                    dataGridView2.Columns[i].Width = Int32.Parse(data[i + 1].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "select distinct refer from referral where refer<>'' ";
            data = sqlcmd.ExecuteReader();
            i = 0;
            string s;
            while (data.Read())
            {
                s = data["refer"].ToString();
                dr_t.AutoCompleteCustomSource.Add(s);
                dr_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            sqlconn.Close();
        }

        private void Referral_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Referral_FormClosing(object sender, FormClosingEventArgs e)
        {
            referral_pp = false;

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14) values('" + this.Name + "','" + dataGridView2.Columns[0].Width + "','" + dataGridView2.Columns[1].Width + "','" + dataGridView2.Columns[2].Width + "','" + dataGridView2.Columns[3].Width + "','" + dataGridView2.Columns[4].Width + "','" + dataGridView2.Columns[5].Width + "','" + dataGridView2.Columns[6].Width + "','" + dataGridView2.Columns[7].Width + "','" + dataGridView2.Columns[8].Width + "','" + dataGridView2.Columns[9].Width + "','" + dataGridView2.Columns[10].Width + "','" + dataGridView2.Columns[11].Width + "','" + dataGridView2.Columns[12].Width + "','" + dataGridView2.Columns[13].Width + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void go_b_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from tel where profession = '"+ prf_c.Text +"' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            object[] ob = new object[14];
            while (data.Read())
            {
                ob[0] = "";
                ob[1] = "ÇäÊÎÇÈ";
                ob[2] = data["place"].ToString();
                ob[3] = data["title"].ToString();
                ob[4] = data["fname"].ToString();
                ob[5] = data["family"].ToString();
                ob[6] = data["tel1"].ToString();
                ob[7] = data["desc1"].ToString();
                ob[8] = data["city"].ToString();
                ob[9] = data["adr1"].ToString();
                ob[10] = data["zip"].ToString();
                ob[11] = data["edr1"].ToString();
                ob[12] = data["email1"].ToString();
                ob[13] = data["job"].ToString();
               
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1 ,ob);
            }
            data.Close();
            
            sqlconn.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            object[] ob = new object[14];
            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count - 1)
            {
                for (i = 2; i <= 13; i++)
                    ob[i] = dataGridView2.Rows[e.RowIndex].Cells[i].Value.ToString();

                dataGridView2.Rows.Clear();
                ob[0] = "";
                ob[1] = "ÇäÊÎÇÈ";
                dataGridView2.Rows.Insert(0, ob);
            }

            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count - 1)
            {
                
                for (i = 2; i <= 13; i++)
                    Referral2.ref_row[i] = dataGridView2.Rows[e.RowIndex].Cells[i].Value.ToString();

                Referral2 frm = new Referral2();
                frm.ShowDialog();
            }
        }

        private void Record_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("Insert into referral(refer) values('"+ dr_t.Text +"')", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

            px = "Refer to " + dr_t.Text;
        }

        private void dr_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void dr_t_Click(object sender, EventArgs e)
        {
            dr_c.Width = 17;
            dr_c.Visible = true;
        }

        private void dr_c_Click(object sender, EventArgs e)
        {
            if (dr_c.Width != 22 + dr_t.Width)
                dr_c.Width = 22 + dr_t.Width;
        }

        private void dr_c_MouseHover(object sender, EventArgs e)
        {
            dr_c.Width = 22 + dr_t.Width;
            dr_c.SendToBack();
        }

        private void dr_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr_t.Text = dr_c.Text;
            dr_c.Width = 17;
            dr_c.Visible = false;
            dr_t.Focus();
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (file_ch.Checked == false)
            {
                Printer_Referral.Printer_Referral_cc = "";
                Printer_Referral.Printer_Referral_dx = "";
                Printer_Referral.Printer_Referral_ddx = "";
                Printer_Referral.Printer_Referral_pi = "";
            }

            Printer_Referral frm = new Printer_Referral();
            frm.Show();
        }

        private void Envelop_Click(object sender, EventArgs e)
        {
            Envelop frm = new Envelop();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Application.StartupPath + "\\Printer\\" + form_c.Text) == false)
                    Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + form_c.Text);

                System.Diagnostics.Process.Start(Application.StartupPath + "\\Printer\\" + form_c.Text);
            }
            catch { }
        }
    }
}