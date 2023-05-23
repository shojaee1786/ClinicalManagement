using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinical_Management
{
    public partial class Full_Summary : Form
    {
        public Full_Summary()
        {
            InitializeComponent();
        }

        private void summary_r_Click(object sender, EventArgs e)
        {
            //Medical_File_Closet.full = false;
            //this.Close();
        }

        private void full_r_Click(object sender, EventArgs e)
        {
            Medical_File_Closet.full = true;
            this.Close();
        }

        private void summary_r_MouseClick(object sender, MouseEventArgs e)
        {
            Medical_File_Closet.full = false;
            this.Close();
        }
    }
}