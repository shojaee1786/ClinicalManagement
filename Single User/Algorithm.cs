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
    public partial class Algorithm : Form
    {
        
        public Algorithm()
        {
            InitializeComponent();
        }

        private void Algorithm_MouseMove(object sender, MouseEventArgs e)
        {
          
            if (Int32.Parse(e.Y.ToString()) >= 630)
            {
                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("winword");
            }
            catch 
            {
                MessageBox.Show("Please first install MS Word then Go to the Setting to configure word", "Notification");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string word = "", cc = "";
            
            openFileDialog1.ShowDialog();
            
            word = openFileDialog1.FileName.ToString();
            if (word != "")
            {

                cc = comboBox1.Text;
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("delete algorithm where cc = '" + cc + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "insert into algorithm(cc,word) values('" + cc + "','" + word + "')";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

                try
                {
                    System.Diagnostics.Process.Start(word);
                }
                catch { }
            }
        }

        private void Algorithm_Load(object sender, EventArgs e)
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

            comboBox1.Items.Clear();
            sqlcmd.CommandText = "select distinct cc from firstvisit where cc<>'' ";
            data = sqlcmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                comboBox1.Items.Insert(i, data["cc"].ToString());
                i++;
            }
            data.Close();

            sqlconn.Close();

            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("tb");
            }
            catch 
            {
                MessageBox.Show("Please first install Text Bridge & Go to Setting for configure OCR");
            }
        }

        private void Algorithm_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Algorithm.doc");
            }
            catch
            {
            }
        }
    }
}