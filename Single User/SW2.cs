using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinical_Management
{
    public partial class SW2 : Form
    {
        private static string dir;

        private List<Image> backgroundImages;

        private int currentImageIndex;

        private List<string> imageExtensions = new List<string>(new string[] { "*.bmp", "*.gif", "*.png", "*.jpg", "*.jpeg" });

        public SW2()
        {
            InitializeComponent();
        }

        private void SW2_MouseMove(object sender, MouseEventArgs e)
        {
            //if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            //{
            //    if (Int32.Parse(e.Y.ToString()) >= 760 &&
            //        this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //    else
            //        if (Int32.Parse(e.Y.ToString()) <= 500 &&
            //            Int32.Parse(e.Y.ToString()) > 4 && 
            //            this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
            //                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //        else
            //            if (Int32.Parse(e.Y.ToString()) <= 4 &&
            //                this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
            frm.Show();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Algorithm frm = new Algorithm();
            frm.Show();
           
        }

        private void SW2_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void SW2_Load(object sender, EventArgs e)
        {
            dir = Application.StartupPath + "\\SB2\\Photo";

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

            sqlcmd.CommandText = "select sw2timer from sw where sw2timer<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                timer1.Interval = Int32.Parse(data["sw2timer"].ToString());
            data.Close();

            sqlcmd.CommandText = "select * from net where client = 'administrator' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (data["acc2"].ToString() == "0")
                    acc_pic.Visible = false;
            }
            data.Close();

            sqlconn.Close();

            backgroundImages = new List<Image>();

            currentImageIndex = 0;

            if (Directory.Exists(dir))
            {
                try
                {
                    DirectoryInfo backgroundImageDir = new DirectoryInfo(dir);
                    // For each image extension (.jpg, .bmp, etc.)
                    foreach (string imageExtension in imageExtensions)
                    {
                        // For each file in the directory provided by the user
                        foreach (FileInfo file in backgroundImageDir.GetFiles(imageExtension))
                        {
                            // Try to load the image
                            try
                            {
                                Image image = Image.FromFile(file.FullName);
                                backgroundImages.Add(image);
                            }
                            catch (OutOfMemoryException)
                            {
                                // If the image can't be loaded, move on.
                                continue;
                            }
                        }
                    }


                    if (backgroundImages.Count != 0)
                    {
                        currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;
                        pictureBox12.Image = backgroundImages[currentImageIndex];
                        timer1.Enabled = true;
                    }
                }
                catch
                {
                }

            }
            else
            {
                MessageBox.Show("Please set the pictures folder");
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;
            pictureBox12.Image = backgroundImages[currentImageIndex];
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            nobat frm = new nobat();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            acc frm = new acc();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            all_info frm = new all_info();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Reminder frm = new Reminder();
            frm.Show();
        }

        private void SW2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SW1 frm = new SW1();
            //foreach (Control c1 in frm.Controls)
            //    if (c1.Name == "Timer1")
            //        c1.Enabled = true;
        }

        private void pictureBox12_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wmplayer.exe");
        }
    }
}