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
    public partial class Reminder_Alarm : Form
    {
        public Reminder_Alarm()
        {
            InitializeComponent();
        }

        private void Reminder_Alarm_Load(object sender, EventArgs e)
        {
            this.Top = 700;
            this.Left = 728;
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