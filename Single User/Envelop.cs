using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using FarsiLibrary.Utils;
using System.IO;

namespace Clinical_Management
{
    public partial class Envelop : Form
    {

        //string hl1, hl2, hl3, hl4, hl5, hl6, hl7, hl8;
        //float hs1, hs2, hs3, hs4, hs5, hs6, hs7, hs8;
        //int hx1, hx2, hx3, hx4, hx5, hx6, hx7, hx8;
        //int hy1, hy2, hy3, hy4, hy5, hy6, hy7, hy8;
        //string hb1, hb2, hb3, hb4, hb5, hb6, hb7, hb8;

        //string l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12;
        //float s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, adr_s;
        //int x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12;
        //int y1, y2, y3, y4, y5, y6, y7, y8, y9, y10, y11, y12;
        //string b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12;
        //string adr_t, adr_b;
        //Int32 adr_x, adr_y;
        //string font1, font2, font3, font4;
        //int logo;

        public static string Envelop_name="";

        public Envelop()
        {
            InitializeComponent();
        }

        private void Envelop_MouseMove(object sender, MouseEventArgs e)
        {
          
            if (Int32.Parse(e.Y.ToString()) >= 630)
            {
                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
            
        }


      
        private void Envelop_Load(object sender, EventArgs e)
        {
            font1_c.Text = "Mistral";
            font2_c.Text = "Mistral";

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

            


            string src = "";
            sqlcmd.CommandText = "select Envelop from sw where Envelop<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                src = data["Envelop"].ToString();
            data.Close();

            try
            {
                pictureBox1.Image = Image.FromFile(src);
            }
            catch { }

            refer_c.Items.Clear();

            sqlcmd.CommandText = "select doctor from print_tmp where doctor<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                refer_c.Items.Add(data["doctor"].ToString());
            }
            data.Close();

            sqlcmd.CommandText = "Select adr from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                adr3_t.Text = data["adr"].ToString();
            }
            data.Close();

            sqlcmd.CommandText = "Select envelope1 from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                ht1.Text = data["envelope1"].ToString();
            }
            data.Close();

            sqlcmd.CommandText = "Select envelope2 from sw";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                ht2.Text = data["envelope2"].ToString();
            }
            data.Close();

            sqlconn.Close();


            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

          

        }

        private void Envelop_ResizeEnd(object sender, EventArgs e)
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
            //if (pageSetupDialog1.PageSettings.PaperSize.Kind != PaperKind.APlus)
            pageSetupDialog1.ShowDialog();

            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {
                e.Graphics.DrawImageUnscaled(Image.FromFile(Application.StartupPath + "\\20.gif"), 320, 10);
            }
            catch { }

            e.Graphics.DrawString(ht1.Text, new Font(font1_c.Text, 14, System.Drawing.FontStyle.Bold), Brushes.Black, 350, 60, new StringFormat(StringFormatFlags.DirectionVertical));
            e.Graphics.DrawString(ht2.Text, new Font(font2_c.Text, 14, System.Drawing.FontStyle.Bold), Brushes.Black, 325, 75, new StringFormat(StringFormatFlags.DirectionVertical));
            e.Graphics.DrawString(refer_c.Text, new Font("Arial", Int32.Parse(s1.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x1.Value.ToString()), Int32.Parse(y1.Value.ToString()), new StringFormat(StringFormatFlags.DirectionVertical));
            e.Graphics.DrawString(adr1_t.Text, new Font("Arial", Int32.Parse(s2.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x2.Value.ToString()), Int32.Parse(y2.Value.ToString()), new StringFormat(StringFormatFlags.DirectionVertical));
            e.Graphics.DrawString(adr2_t.Text, new Font("Arial", Int32.Parse(s3.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x3.Value.ToString()), Int32.Parse(y3.Value.ToString()), new StringFormat(StringFormatFlags.DirectionVertical));
            e.Graphics.DrawString(adr3_t.Text, new Font("Arial", Int32.Parse(s4.Value.ToString()), System.Drawing.FontStyle.Bold), Brushes.Black, Int32.Parse(x4.Value.ToString()), Int32.Parse(y4.Value.ToString()), new StringFormat(StringFormatFlags.DirectionVertical));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for photo...";
            dlg.Filter = "Picture files Files(*.jpg)|*.jpg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "Update sw set Envelop = '" + dlg.FileName + "' ";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alter_Envelop frm = new Alter_Envelop();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void Envelop_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "Update sw set adr = '"+ adr3_t.Text +"' ";
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Update sw set envelope1 = '" + ht1.Text + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Update sw set envelope2 = '" + ht2.Text + "' ";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\address.txt") == true)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\address.txt");
            }
            else
                File.Create(Application.StartupPath + "\\address.txt");
        }
    }
}