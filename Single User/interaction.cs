using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinical_Management
{
    public partial class interaction : Form
    {
        public static string inter_str="",inter_color;
        public interaction()
        {
            InitializeComponent();
        }

        private void interaction_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Res\\Interaction\\" + inter_color + ".jpg");
            }
            catch { }

            richTextBox1.Text = inter_str;
            this.Top = 700;
            this.Left = 700;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Top = this.Top - 2;
            if (this.Top == 510)
                timer1.Enabled = false;
        }
    }
}