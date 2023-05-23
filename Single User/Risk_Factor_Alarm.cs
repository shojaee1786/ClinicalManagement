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
    public partial class Risk_Factor_Alarm : Form
    {
        //public static string side_str;
        public static string risk_action, risk_query, risk_color;

       
        public Risk_Factor_Alarm()
        {
            InitializeComponent();
        }

        private void Risk_Factor_Alarm_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Res\\Risk Factor\\" + risk_color + ".jpg");
            }
            catch { }


            risk_query = risk_query.Replace("|", "\n");

            action_t.Text = risk_action;
            query_t.Text = risk_query;
            
            this.Top = 700;
            this.Left = 700;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Top = this.Top - 1;
            if (this.Top == 530)
            {
                timer1.Enabled = false;
            }

        }

    }
}