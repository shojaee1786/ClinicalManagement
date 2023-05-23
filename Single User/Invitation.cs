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

namespace Clinical_Management
{
    public partial class Invitation : Form
    {

        string hl1, hl2, hl3, hl4, hl5, hl6, hl7, hl8;
        float hs1, hs2, hs3, hs4, hs5, hs6, hs7, hs8;
        int hx1, hx2, hx3, hx4, hx5, hx6, hx7, hx8;
        int hy1, hy2, hy3, hy4, hy5, hy6, hy7, hy8;
        string hb1, hb2, hb3, hb4, hb5, hb6, hb7, hb8;

        string l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12;
        float s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, adr_s;
        int x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12;
        int y1, y2, y3, y4, y5, y6, y7, y8, y9, y10, y11, y12;
        string b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12;
        string adr_t, adr_b;
        Int32 adr_x, adr_y;
        string font1, font2, font3, font4;
        int logo;

        public static string Invitation_name="";

        public Invitation()
        {
            InitializeComponent();
        }

        private void Invitation_MouseMove(object sender, MouseEventArgs e)
        {
          
            if (Int32.Parse(e.Y.ToString()) >= 630)
            {
                if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
            
        }


      
        private void Invitation_Load(object sender, EventArgs e)
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



            refer_c.Items.Clear();

            sqlcmd.CommandText = "select doctor from print_tmp where doctor<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                refer_c.Items.Add(data["doctor"].ToString());
            }
            data.Close();


            string src = "";
            sqlcmd.CommandText = "select Invitation from sw where Invitation<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                src = data["Invitation"].ToString();
            data.Close();

            try
            {
                panel1.BackgroundImage = Image.FromFile(src);
            }
            catch { }

            sqlconn.Close();


            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);

            
        }

        private void Invitation_ResizeEnd(object sender, EventArgs e)
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
            if (pageSetupDialog1.PageSettings.PaperSize.Kind != PaperKind.A5)
                pageSetupDialog1.ShowDialog();

            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "select template from template where op = '‰«„Â Â«Ì „ ›—ﬁÂ' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            string temp = "";
            while (data.Read())
            {
                temp = data["template"].ToString();
            }
            data.Close();

            sqlcmd.CommandText = "select count(*) from print_t where template = '" + temp + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlconn.Close();
                MessageBox.Show("·ÿ›« «» œ« «·êÊÌ „—»ÊÿÂ —« «ÌÃ«œ ‰„«ÌÌœ");
                return;
            }

            sqlcmd.CommandText = "select * from print_t where template = '" + temp + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                font1 = data["font1"].ToString();
                font2 = data["font2"].ToString();
                font3 = data["font3"].ToString();
                font4 = data["font4"].ToString();
                logo = Int32.Parse(data["logo"].ToString());

                // Print Header
                hl1 = data["hl1"].ToString();
                hl2 = data["hl2"].ToString();
                hl3 = data["hl3"].ToString();
                hl4 = data["hl4"].ToString();
                hl5 = data["hl5"].ToString();
                hl6 = data["hl6"].ToString();
                hl7 = data["hl7"].ToString();
                hl8 = data["hl8"].ToString();

                hs1 = float.Parse(data["hs1"].ToString());
                hs2 = float.Parse(data["hs2"].ToString());
                hs3 = float.Parse(data["hs3"].ToString());
                hs4 = float.Parse(data["hs4"].ToString());
                hs5 = float.Parse(data["hs5"].ToString());
                hs6 = float.Parse(data["hs6"].ToString());
                hs7 = float.Parse(data["hs7"].ToString());
                hs8 = float.Parse(data["hs8"].ToString());

                hx1 = Int32.Parse(data["hx1"].ToString());
                hx2 = Int32.Parse(data["hx2"].ToString());
                hx3 = Int32.Parse(data["hx3"].ToString());
                hx4 = Int32.Parse(data["hx4"].ToString());
                hx5 = Int32.Parse(data["hx5"].ToString());
                hx6 = Int32.Parse(data["hx6"].ToString());
                hx7 = Int32.Parse(data["hx7"].ToString());
                hx8 = Int32.Parse(data["hx8"].ToString());

                hy1 = Int32.Parse(data["hy1"].ToString());
                hy2 = Int32.Parse(data["hy2"].ToString());
                hy3 = Int32.Parse(data["hy3"].ToString());
                hy4 = Int32.Parse(data["hy4"].ToString());
                hy5 = Int32.Parse(data["hy5"].ToString());
                hy6 = Int32.Parse(data["hy6"].ToString());
                hy7 = Int32.Parse(data["hy7"].ToString());
                hy8 = Int32.Parse(data["hy8"].ToString());

                hb1 = data["hb1"].ToString();
                hb2 = data["hb2"].ToString();
                hb3 = data["hb3"].ToString();
                hb4 = data["hb4"].ToString();
                hb5 = data["hb5"].ToString();
                hb6 = data["hb6"].ToString();
                hb7 = data["hb7"].ToString();
                hb8 = data["hb8"].ToString();
                // End of Print Header

                // Print Body
                l1 = data["l1"].ToString();
                l2 = data["l2"].ToString();
                l3 = data["l3"].ToString();
                l4 = data["l4"].ToString();
                l5 = data["l5"].ToString();
                l6 = data["l6"].ToString();
                l7 = data["l7"].ToString();
                l8 = data["l8"].ToString();
                l9 = data["l9"].ToString();
                l10 = data["l10"].ToString();
                l11 = data["l11"].ToString();
                l12 = data["l12"].ToString();

                s1 = float.Parse(data["s1"].ToString());
                s2 = float.Parse(data["s2"].ToString());
                s3 = float.Parse(data["s3"].ToString());
                s4 = float.Parse(data["s4"].ToString());
                s5 = float.Parse(data["s5"].ToString());
                s6 = float.Parse(data["s6"].ToString());
                s7 = float.Parse(data["s7"].ToString());
                s8 = float.Parse(data["s8"].ToString());
                s9 = float.Parse(data["s9"].ToString());
                s10 = float.Parse(data["s10"].ToString());
                s11 = float.Parse(data["s11"].ToString());
                s12 = float.Parse(data["s12"].ToString());


                x1 = Int32.Parse(data["x1"].ToString());
                x2 = Int32.Parse(data["x2"].ToString());
                x3 = Int32.Parse(data["x3"].ToString());
                x4 = Int32.Parse(data["x4"].ToString());
                x5 = Int32.Parse(data["x5"].ToString());
                x6 = Int32.Parse(data["x6"].ToString());
                x7 = Int32.Parse(data["x7"].ToString());
                x8 = Int32.Parse(data["x8"].ToString());
                x9 = Int32.Parse(data["x9"].ToString());
                x10 = Int32.Parse(data["x10"].ToString());
                x11 = Int32.Parse(data["x11"].ToString());
                x12 = Int32.Parse(data["x12"].ToString());

                y1 = Int32.Parse(data["y1"].ToString());
                y2 = Int32.Parse(data["y2"].ToString());
                y3 = Int32.Parse(data["y3"].ToString());
                y4 = Int32.Parse(data["y4"].ToString());
                y5 = Int32.Parse(data["y5"].ToString());
                y6 = Int32.Parse(data["y6"].ToString());
                y7 = Int32.Parse(data["y7"].ToString());
                y8 = Int32.Parse(data["y8"].ToString());
                y9 = Int32.Parse(data["y9"].ToString());
                y10 = Int32.Parse(data["y10"].ToString());
                y11 = Int32.Parse(data["y11"].ToString());
                y12 = Int32.Parse(data["y12"].ToString());

                b1 = data["b1"].ToString();
                b2 = data["b2"].ToString();
                b3 = data["b3"].ToString();
                b4 = data["b4"].ToString();
                b5 = data["b5"].ToString();
                b6 = data["b6"].ToString();
                b7 = data["b7"].ToString();
                b8 = data["b8"].ToString();
                b9 = data["b9"].ToString();
                b10 = data["b10"].ToString();
                b11 = data["b11"].ToString();
                b12 = data["b12"].ToString();
                // End of Print Body

                // Print Address
                adr_t = data["adr_t"].ToString();
                adr_x = Int32.Parse(data["adr_x"].ToString());
                adr_y = Int32.Parse(data["adr_y"].ToString());
                adr_b = data["adr_b"].ToString();
                adr_s = float.Parse(data["adr_s"].ToString());
                // End of Print Address
            }
            data.Close();

            sqlconn.Close();



            if (logo == 1)
            {
                try
                {
                    e.Graphics.DrawImageUnscaled(Image.FromFile(Application.StartupPath + "\\10.gif"), 60, 60);
                }
                catch { }
            }


            if (hb1 == "True")
                e.Graphics.DrawString(hl1, new Font(font1, hs1, System.Drawing.FontStyle.Bold), Brushes.Black, hx1, hy1);
            else
                e.Graphics.DrawString(hl1, new Font(font1, hs1, System.Drawing.FontStyle.Regular), Brushes.Black, hx1, hy1);

            if (hb2 == "True")
                e.Graphics.DrawString(hl2, new Font(font2, hs2, System.Drawing.FontStyle.Bold), Brushes.Navy, hx2, hy2);
            else
                e.Graphics.DrawString(hl2, new Font(font2, hs2, System.Drawing.FontStyle.Regular), Brushes.Navy, hx2, hy2);

            if (hb3 == "True")
                e.Graphics.DrawString(hl3, new Font("Arial", hs3, System.Drawing.FontStyle.Bold), Brushes.Black, hx3, hy3);
            else
                e.Graphics.DrawString(hl3, new Font("Arial", hs3, System.Drawing.FontStyle.Regular), Brushes.Black, hx3, hy3);

            if (hb4 == "True")
                e.Graphics.DrawString(hl4, new Font("Arial", hs4, System.Drawing.FontStyle.Bold), Brushes.Navy, hx4, hy4);
            else
                e.Graphics.DrawString(hl4, new Font("Arial", hs4, System.Drawing.FontStyle.Regular), Brushes.Navy, hx4, hy4);

            if (hb5 == "True")
                e.Graphics.DrawString(hl5, new Font(font3, hs5, System.Drawing.FontStyle.Bold), Brushes.Black, hx5, hy5, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl5, new Font(font3, hs5, System.Drawing.FontStyle.Regular), Brushes.Black, hx5, hy5, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (hb6 == "True")
                e.Graphics.DrawString(hl6, new Font(font4, hs6, System.Drawing.FontStyle.Bold), Brushes.Navy, hx6, hy6, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl6, new Font(font4, hs6, System.Drawing.FontStyle.Regular), Brushes.Navy, hx6, hy6, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (hb7 == "True")
                e.Graphics.DrawString(hl7, new Font("Arial", hs7, System.Drawing.FontStyle.Bold), Brushes.MediumBlue, hx7, hy7, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl7, new Font("Arial", hs7, System.Drawing.FontStyle.Regular), Brushes.MediumBlue, hx7, hy7, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (hb8 == "True")
                e.Graphics.DrawString(hl8, new Font("Arial", hs8, System.Drawing.FontStyle.Bold), Brushes.Blue, hx8, hy8, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(hl8, new Font("Arial", hs8, System.Drawing.FontStyle.Regular), Brushes.Blue, hx8, hy8, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            /////////////////////// End of Print Header

            //////////////////////////// Print Body
            if (b1 == "True")
                e.Graphics.DrawString(l1, new Font("Arial", s1, System.Drawing.FontStyle.Bold), Brushes.Black, x1, y1, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l1, new Font("Arial", s1, System.Drawing.FontStyle.Regular), Brushes.Black, x1, y1, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b2 == "True")
                e.Graphics.DrawString(l2, new Font("Arial", s2, System.Drawing.FontStyle.Bold), Brushes.Black, x2, y2, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l2, new Font("Arial", s2, System.Drawing.FontStyle.Regular), Brushes.Black, x2, y2, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b3 == "True")
                e.Graphics.DrawString(l3, new Font("Arial", s3, System.Drawing.FontStyle.Bold), Brushes.Black, x3, y3, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l3, new Font("Arial", s3, System.Drawing.FontStyle.Regular), Brushes.Black, x3, y3, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b4 == "True")
                e.Graphics.DrawString(l4, new Font("Arial", s4, System.Drawing.FontStyle.Bold), Brushes.Black, x4, y4, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l4, new Font("Arial", s4, System.Drawing.FontStyle.Regular), Brushes.Black, x4, y4, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b5 == "True")
                e.Graphics.DrawString(l5, new Font("Arial", s5, System.Drawing.FontStyle.Bold), Brushes.Black, x5, y5, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l5, new Font("Arial", s5, System.Drawing.FontStyle.Regular), Brushes.Black, x5, y5, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b6 == "True")
                e.Graphics.DrawString(l6, new Font("Arial", s6, System.Drawing.FontStyle.Bold), Brushes.Black, x6, y6, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l6, new Font("Arial", s6, System.Drawing.FontStyle.Regular), Brushes.Black, x6, y6, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b7 == "True")
                e.Graphics.DrawString(l7, new Font("Arial", s7, System.Drawing.FontStyle.Bold), Brushes.Black, x7, y7, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l7, new Font("Arial", s7, System.Drawing.FontStyle.Regular), Brushes.Black, x7, y7, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b8 == "True")
                e.Graphics.DrawString(l8, new Font("Arial", s8, System.Drawing.FontStyle.Bold), Brushes.Black, x8, y8, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l8, new Font("Arial", s8, System.Drawing.FontStyle.Regular), Brushes.Black, x8, y8, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b9 == "True")
                e.Graphics.DrawString(l9, new Font("Arial", s9, System.Drawing.FontStyle.Bold), Brushes.Black, x9, y9, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l9, new Font("Arial", s9, System.Drawing.FontStyle.Regular), Brushes.Black, x9, y9, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b10 == "True")
                e.Graphics.DrawString(l10, new Font("Arial", s10, System.Drawing.FontStyle.Bold), Brushes.Black, x10, y10, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l10, new Font("Arial", s10, System.Drawing.FontStyle.Regular), Brushes.Black, x10, y10, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b11 == "True")
                e.Graphics.DrawString(l11, new Font("Arial", s11, System.Drawing.FontStyle.Bold), Brushes.Black, x11, y11, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l11, new Font("Arial", s11, System.Drawing.FontStyle.Regular), Brushes.Black, x11, y11, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            if (b12 == "True")
                e.Graphics.DrawString(l12, new Font("Arial", s12, System.Drawing.FontStyle.Bold), Brushes.Black, x12, y12, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(l12, new Font("Arial", s12, System.Drawing.FontStyle.Regular), Brushes.Black, x12, y12, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            ////////////////////////// End of Print Body

            //////////// Print Address
            if (adr_b == "True")
                e.Graphics.DrawString(adr_t, new Font("Arial", adr_s, System.Drawing.FontStyle.Bold), Brushes.Black, adr_x, adr_y, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            else
                e.Graphics.DrawString(adr_t, new Font("Arial", adr_s, System.Drawing.FontStyle.Regular), Brushes.Black, adr_x, adr_y, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            ///////// End of Print Address


            // Print Content
            e.Graphics.DrawString(refer_c.Text, new Font("Arial", 12, System.Drawing.FontStyle.Bold), Brushes.Black,500,230,new StringFormat(StringFormatFlags.DirectionRightToLeft));
            
            // End of Print Content
        
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
                sqlcmd.CommandText = "Update sw set Invitation = '" + dlg.FileName + "' ";
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

    }
}