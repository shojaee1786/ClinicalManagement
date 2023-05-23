using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using FarsiLibrary.Utils;

namespace Clinical_Management
{
    public partial class SW3 : Form
    {
        private static string dir;

        private List<Image> backgroundImages;

        private int currentImageIndex;

        private List<string> imageExtensions = new List<string>(new string[] { "*.bmp", "*.gif", "*.png", "*.jpg", "*.jpeg" });

        public SW3()
        {
            InitializeComponent();
        }

        private void SW3_MouseMove(object sender, MouseEventArgs e)
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
            nobat frm = new nobat();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Paziresh frm = new Paziresh();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            all_info frm = new all_info();
            frm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Algorithm frm = new Algorithm();
            frm.Show();
           
        }

        private void SW3_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void SW3_Load(object sender, EventArgs e)
        {
            dir = Application.StartupPath + "\\SB3\\Photo";
            
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

            sqlcmd.CommandText = "select sw3timer from sw where sw3timer<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                timer1.Interval = Int32.Parse(data["sw3timer"].ToString());
            data.Close();

            sqlcmd.CommandText = "select * from monshi where username = '"+ login2.log_username_monshi  +"' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                if (Int32.Parse(data["paziresh"].ToString()) == 0)
                    paziresh_pic.Visible = false;
                if (data["nobat"].ToString() == "0")
                    nobat_pic.Visible = false;
                if (data["acc"].ToString() == "0")
                    acc_pic.Visible = false;
                if (data["tel"].ToString() == "0")
                    tel_pic.Visible = false;
                if (data["reminder"].ToString() == "0")
                    reminder_pic.Visible = false;
                if (data["search"].ToString() == "0")
                    search_pic.Visible = false;
                if (data["all_info"].ToString() == "0")
                    all_info_pic.Visible = false;
            }
            data.Close();

            //sqlconn.Close();

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

            PersianDate pd = PersianDate.Now;
            string today;
            today = pd.ToString().Substring(0, 10);
            //MessageBox.Show(today);

            sqlcmd.CommandText = "select day1,month1,year1 from reminder";
            data = sqlcmd.ExecuteReader();
            string mytemp, mymonth;
            mymonth = "00";
            while (data.Read())
            {
                switch (data["month1"].ToString())
                {
                    case "›—Ê—œÌ‰":
                        {
                            mymonth = "01";
                            break;
                        }
                    case "«—œÌ»Â‘ ":
                        {
                            mymonth = "02";
                            break;
                        }
                    case "Œ—œ«œ":
                        {
                            mymonth = "03";
                            break;
                        }
                    case " Ì—":
                        {
                            mymonth = "04";
                            break;
                        }
                    case "„—œ«œ":
                        {
                            mymonth = "05";
                            break;
                        }
                    case "‘Â—ÌÊ—":
                        {
                            mymonth = "06";
                            break;
                        }
                    case "„Â—":
                        {
                            mymonth = "07";
                            break;
                        }
                    case "¬»«‰":
                        {
                            mymonth = "08";
                            break;
                        }
                    case "¬–—":
                        {
                            mymonth = "09";
                            break;
                        }
                    case "œÌ":
                        {
                            mymonth = "10";
                            break;
                        }
                    case "»Â„‰":
                        {
                            mymonth = "11";
                            break;
                        }
                    case "«”›‰œ":
                        {
                            mymonth = "12";
                            break;
                        }
                }
                mytemp = data["year1"].ToString() + "/" + mymonth + "/" + data["day1"].ToString();
                if (mytemp == today)
                {
                    Reminder_Alarm frm = new Reminder_Alarm();
                    frm.ShowDialog();
                }
            }
            data.Close();

            sqlconn.Close();


        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;
            pictureBox12.Image = backgroundImages[currentImageIndex];
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Tel frm = new Tel();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Reminder frm = new Reminder();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            acc frm = new acc();
            frm.Show();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            try
            {
                Audio aa = new Audio();
                aa.Play(Application.StartupPath + "\\SB3\\Sound\\logo.wav");
            }
            catch { }
        }

        private void pictureBox12_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wmplayer.exe");
        }

        private void pictureBox11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Secretary Help.doc");
                }
                catch { }
            }
            else
            {
                setting2 frm = new setting2();
                frm.ShowDialog();
                
            }
        }

    }
}