using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinical_Management
{
    public partial class gender : Form
    {
        public static string str_gender = "";
        public gender()
        {
            InitializeComponent();
        }

        private void gender_Load(object sender, EventArgs e)
        {
            this.Top = 70;
            this.Left = 300;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            str_gender = listBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}