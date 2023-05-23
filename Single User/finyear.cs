using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Clinical_Management
{
    public partial class finyear : Form
    {
        public finyear()
        {
            InitializeComponent();
        }

        private void finyear_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
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

            sqlcmd.CommandText = "select distinct finyear from acc where finyear<>' ' ";
            data = sqlcmd.ExecuteReader();
            int i = 0;
            finyear_c.Items.Clear();
            while (data.Read())
            {
                finyear_c.Items.Insert(i, data["finyear"].ToString());
                i++;
            }
         
            data.Close();
            sqlconn.Close();
        }

        private void finyear_ResizeEnd(object sender, EventArgs e)
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
            if (finyear_t.Text == "")
            {
                MessageBox.Show("·ÿ›« Ìﬂ ‰«„ „‰«”» »—«Ì «Ì‰ ”«· „«·Ì «‰ Œ«» ‰„«ÌÌœ");
            }
            else
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Update acc set finyear='"+ finyear_t.Text +"' where finyear = ' ' ", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (finyear_c.Text != "")
            {
                acc.my_finyear = finyear_c.Text;
                acc.old_finyear = true;
                this.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (finyear_c.Text != "")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Delete from acc where finyear = '" + finyear_c.Text + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    finyear_c.Items.RemoveAt(finyear_c.SelectedIndex);
                    sqlconn.Close();
                }
            }
            catch { }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            object[] my_row = new object[25];

            dataGridView2.Rows.Clear();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "Select * from acc where finyear = '" + finyear_c.Text + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                my_row[0] = data["row"].ToString();
                my_row[1] = data["date1"].ToString();
                my_row[2] = data["op"].ToString();
                my_row[3] = data["par"].ToString();
                my_row[4] = data["sanad"].ToString();
                my_row[5] = data["bank"].ToString();
                my_row[6] = data["checkdate"].ToString();
                my_row[7] = data["variz"].ToString();
                my_row[8] = data["hospital"].ToString();
                my_row[9] = data["remainder"].ToString();
                my_row[10] = data["outcome"].ToString();
                my_row[11] = data["income"].ToString();
                my_row[12] = data["remaining"].ToString();
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, my_row);
            }
            data.Close();

            sqlconn.Close();

            cm.Print_DataGridView(dataGridView2);
        }

       
    }
}