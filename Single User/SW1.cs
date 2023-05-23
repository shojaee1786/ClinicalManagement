using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using FarsiLibrary.Utils;

namespace Clinical_Management
{
    public partial class SW1 : Form
    {
        private static string dir;
        public static int titlebar = 1;

        private List<Image> backgroundImages;

        private int currentImageIndex;

        private List<string> imageExtensions = new List<string>(new string[] { "*.bmp", "*.gif", "*.png", "*.jpg", "*.jpeg" });

        public SW1()
        {
            InitializeComponent();
        }

        private void SW1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (titlebar == 0)
            //{
            //    if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            //    {
            //        if (Int32.Parse(e.Y.ToString()) >= 760 &&
            //            this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //        else
            //            if (Int32.Parse(e.Y.ToString()) <= 500 &&
            //                Int32.Parse(e.Y.ToString()) > 4 &&
            //                this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
            //                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //            else
            //                if (Int32.Parse(e.Y.ToString()) <= 4 &&
            //                    this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //    }
            //}
            //else
            //{
            //   if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //}
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            SW2 frm = new SW2();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Patient.IsOpen == true)
            {
                alert2 frm2 = new alert2();
                frm2.ShowDialog();
                return;
            }


            int i = 0;
            string s;
            Patient frm = new Patient();

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct mname from info where mname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.mname_t.AutoCompleteCustomSource.Add(data["mname"].ToString());
            data.Close();

            sqlcmd.CommandText = "select distinct lname from info where lname<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.lname_t.AutoCompleteCustomSource.Add(data["lname"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct bplace from info where bplace<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["bplace"].ToString();
                frm.bplace_c.Items.Insert(i, s);
                frm.bplace_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            sqlcmd.CommandText = "select distinct father from info where father<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                frm.father_t.AutoCompleteCustomSource.Add(data["father"].ToString());
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct city from info where city<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["city"].ToString();
                frm.city_c.Items.Insert(i, s);
                frm.city_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct sodor from info where sodor<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["sodor"].ToString();
                frm.sodor_c.Items.Insert(i, s);
                frm.sodor_t.AutoCompleteCustomSource.Add(s);
                i++;
            }
            data.Close();


            sqlconn.Close();


            Patient.par = 0;

            
            
            //frm.fname_t.AutoCompleteCustomSource = tmp_t.AutoCompleteCustomSource;
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            DrugStore frm = new DrugStore();
            frm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable)
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Algorithm frm = new Algorithm();
            frm.Show();

           
        }

        private void SW1_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void SW1_Load(object sender, EventArgs e)
        {
            dir = Application.StartupPath + "\\SB1\\Photo";

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
            
            sqlcmd.CommandText = "select sw1timer from sw where sw1timer<>'' ";
            data = sqlcmd.ExecuteReader();
            while(data.Read())
                timer1.Interval = Int32.Parse(data["sw1timer"].ToString());
            data.Close();


           
       
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
                //MessageBox.Show(mytemp);
                if (mytemp == today)
                {
                    // MessageBox.Show("·ÿ›« »Â Ì«œ¬Ê—Ì Â« „—«Ã⁄Â ‘Êœ"," ÊÃÂ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    Reminder_Alarm frm = new Reminder_Alarm();
                    frm.ShowDialog();
                }
            }
            data.Close();

            sqlconn.Close();

         

    }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Research frm = new Research();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;
            pictureBox12.Image = backgroundImages[currentImageIndex];
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Photo_Archive frm = new Photo_Archive();
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Risk_Factor frm = new Risk_Factor();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Referral frm = new Referral();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Consultation frm = new Consultation();
            frm.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Medical_Library frm = new Medical_Library();
            frm.Show();
        }

        private void pictureBox11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Medical_File_Closet frm = new Medical_File_Closet();
                frm.ShowDialog();
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    Setting frm = new Setting();
                    frm.ShowDialog();
                }
        }

        private void pictureBox12_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wmplayer.exe");
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            try
            {
                Audio aa = new Audio();
                aa.Play(Application.StartupPath + "\\SB1\\Sound\\logo.wav");
            }
            catch { }
        }

        private void SW1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}