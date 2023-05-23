using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinical_Management
{
    public partial class title : Form
    {
        public static string str_title = "";
        public title()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            str_title = listBox1.SelectedItem.ToString();
            this.Close();
           
        }

        private void title_Load(object sender, EventArgs e)
        {
            this.Top = 50;
            this.Left = 870;

        }
    }
}