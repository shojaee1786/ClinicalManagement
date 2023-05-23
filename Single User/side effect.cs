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
    public partial class side_effect : Form
    {
        public static string side_str,side_color;
        public static string[] drug = new string[200];
        public static int drug_count = 0;
        public side_effect()
        {
            InitializeComponent();
        }

        private void side_effect_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Res\\Side Effects\\" + side_color + ".jpg");
            }
            catch { }


            richTextBox1.Text = side_str;
            this.Top = 700;
            this.Left = 700;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Top = this.Top - 1;
            if (this.Top == 670)
            {
                timer1.Enabled = false;
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                SqlDataReader data;

                int i, j;
                string s;
                i = drug_count;
                for (j = 1; j <= drug_count - 1; j++)
                {
                    sqlcmd.CommandText = "select exp,color from interaction where drug1='" + drug[i - j].Substring(drug[i - j].IndexOf('?') + 1, drug[i - j].Length - drug[i - j].IndexOf('?') - 1) + "' and drug2='" + drug[i].Substring(drug[i].IndexOf("?") + 1 , drug[i].Length - drug[i].IndexOf("?") - 1) + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        s = data["exp"].ToString();
                        interaction.inter_color = data["color"].ToString();
                        if (s != "")
                        {
                            interaction.inter_str = s;
                            interaction frm = new interaction();
                            frm.ShowDialog();
                        }
                    }
                    data.Close();
                }

                //// Added Code
                i = drug_count;
                for (j = 1; j <= drug_count - 1; j++)
                {
                    sqlcmd.CommandText = "select exp,color from interaction where drug1='" + drug[drug_count] + "' and drug2='" + drug[i] + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        s = data["exp"].ToString();
                        interaction.inter_color = data["color"].ToString();
                        if (s != "")
                        {
                            interaction.inter_str = s;
                            interaction frm = new interaction();
                            frm.ShowDialog();
                        }
                    }
                    data.Close();
                }
                ///////////////
            }

        }

    }
}