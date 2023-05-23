using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinical_Management
{
    public partial class Del_Paz : Form
    {
        public static bool del_confirm;
        public Del_Paz()
        {
            InitializeComponent();
        }

        private void No_Click(object sender, EventArgs e)
        {
            del_confirm = false;
            this.Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            del_confirm = true;
            this.Close();
        }

        private void Del_Paz_Load(object sender, EventArgs e)
        {
            del_confirm = false;
        }

    }
}