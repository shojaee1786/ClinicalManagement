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
    public partial class Photo_Archive : Form
    {
        public Photo_Archive()
        {
            InitializeComponent();
        }

        private void Photo_Archive_Load(object sender, EventArgs e)
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

            sqlconn.Close();
        }

        private void Photo_Archive_ResizeEnd(object sender, EventArgs e)
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
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            string slim = "";

            sqlcmd.CommandText = "Select slim from sw ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                slim = data["slim"].ToString();
            }
            data.Close();


            if (File.Exists(slim) == false)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Removable Device Program ...";
                dlg.Filter = "Application Programs(*.exe)|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    sqlcmd.CommandText = "Update sw set slim = '" + dlg.FileName + "' ";
                    sqlcmd.ExecuteNonQuery();
                    slim = dlg.FileName;
                }
            }

            sqlconn.Close();

            try
            {
                System.Diagnostics.Process.Start(slim);
            }
            catch
            { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Patient Files") == false)
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files");

            System.Diagnostics.Process.Start(Application.StartupPath + "\\Patient Files");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Peripherals");
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            string camera = "";

            sqlcmd.CommandText = "Select camera from sw ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                camera = data["camera"].ToString();
            }
            data.Close();


            if (File.Exists(camera) == false)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for Camera Program ...";
                dlg.Filter = "Application Programs(*.exe)|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    sqlcmd.CommandText = "Update sw set camera = '" + dlg.FileName + "' ";
                    sqlcmd.ExecuteNonQuery();
                    camera = dlg.FileName;
                }
            }

            sqlconn.Close();

            try
            {
                System.Diagnostics.Process.Start(camera);
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("sndrec32");
            }
            catch
            {
                System.Diagnostics.Process.Start("soundrecorder.exe");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Patient Files\\New") == false)
                Directory.CreateDirectory(Application.StartupPath + "\\Patient Files\\New");

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            string MySrc = "";

            sqlcmd.CommandText = "Select mysrc from sw where mysrc<>'' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                MySrc = data["mysrc"].ToString() + "\\";
            }
            data.Close();


            if (Directory.Exists(MySrc) == false)
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Please Select the My Picture Folder ...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    sqlcmd.CommandText = "Update sw set mysrc = '" + dlg.SelectedPath.ToString() + "' ";
                    sqlcmd.ExecuteNonQuery();
                    MySrc = dlg.SelectedPath.ToString() + "\\";
                }
            }

            sqlconn.Close();

            string MyDest = Application.StartupPath + "\\Patient Files\\New\\";

            ////////////////////////////////////////
            ///////////  Export Pictures  //////////
            ////////////////////////////////////////
            int i = 1;
            if (File.Exists(MySrc + "Picture 001.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 001.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 002.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 002.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 003.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 003.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 004.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 004.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 005.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 005.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 006.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 006.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 007.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 007.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 008.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 008.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 009.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 009.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 010.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 010.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 011.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 011.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 012.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 012.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 013.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 013.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 014.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 014.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 015.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 015.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 016.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 016.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 017.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 017.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 018.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 018.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 019.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 019.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }

            i = 1;
            if (File.Exists(MySrc + "Picture 020.jpg"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".jpg") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move(MySrc + "Picture 020.jpg", MyDest + i.ToString() + ".jpg");
                        break;
                    }
                }
            }
            ////////////////////////////////////////
            ///////////  Export Audio   ////////////
            ////////////////////////////////////////
            i = 1;
            if (File.Exists("d:\\1.wav"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".wav") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move("d:\\1.wav", MyDest + i.ToString() + ".wav");
                        break;
                    }
                }
            }
            ////////////////////////////////////////
            ///////////  Export Video   ////////////
            ////////////////////////////////////////
            i = 1;
            
            if (File.Exists("d:\\Video.avi"))
            {
                while (true)
                {
                    if (File.Exists(MyDest + i.ToString() + ".avi") == true)
                    {
                        i++;
                    }
                    else
                    {
                        File.Move("d:\\Video.avi", MyDest + i.ToString() + ".avi");
                        break;
                    }
                }
            }
            ///// End of Export /////
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Photo Archive.doc");
            }
            catch { }
        }
    }
}