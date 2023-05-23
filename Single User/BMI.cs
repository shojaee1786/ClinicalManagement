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
    public partial class BMI : Form
    {
        public static string bmi_wg, bmi_ht, bmi_age;
        public BMI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select p_src from pc_program where p = 'Diet' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    s = data["p_src"].ToString();
                data.Close();
                sqlconn.Close();

                System.Diagnostics.Process.Start(s);

            }
            catch
            {
                MessageBox.Show("Please first install 'Antropometery' Program then Go to the Setting to configure it ", "Notification");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double bmi = double.Parse(wg_t.Text) / ((double.Parse(ht_t.Text) / 100) * (double.Parse(ht_t.Text) / 100));

                bmi_t.Text = bmi.ToString().Substring(0, 5);

                if (female_r.Checked == true)
                {
                    double bee = 655.1 + (9.56 * double.Parse(wg_t.Text)) + (1.85 * double.Parse(ht_t.Text)) - (4.68 * double.Parse(age_t.Text));
                    bee_t.Text = bee.ToString();

                    if (Ambu_r.Checked == true)
                        bee = bee * 2.2;
                    else
                        if (bedrest_r.Checked == true)
                            bee = bee * 1.2;
                        else
                            bee = bee * 1.7;

                    cr_t.Text = bee.ToString();

                    if (comboBox1.SelectedIndex == 0)
                        cr_t.Text = (bee * 1.1).ToString();
                    if (comboBox1.SelectedIndex == 1)
                        cr_t.Text = (bee * 1.4).ToString();
                    if (comboBox1.SelectedIndex == 2)
                        cr_t.Text = (bee * 1.2).ToString();
                    if (comboBox1.SelectedIndex == 3)
                        cr_t.Text = (bee * 1.6).ToString();
                    if (comboBox1.SelectedIndex == 4)
                        cr_t.Text = (bee * 1.2).ToString();
                    if (comboBox1.SelectedIndex == 5)
                        cr_t.Text = (bee * 1.3).ToString();
                    if (comboBox1.SelectedIndex == 6)
                        cr_t.Text = (bee * 1.2).ToString();
                    if (comboBox1.SelectedIndex == 7)
                        cr_t.Text = (bee * 1.2).ToString();

                }
                else
                {
                    double bee = 66.47 + (13.75 * double.Parse(wg_t.Text)) + (5 * double.Parse(ht_t.Text)) - (6.76 * double.Parse(age_t.Text));
                    bee_t.Text = bee.ToString();

                    if (Ambu_r.Checked == true)
                        bee = bee * 2.2;
                    else
                        if (bedrest_r.Checked == true)
                            bee = bee * 1.2;
                        else
                            bee = bee * 1.7;


                    cr_t.Text = bee.ToString();

                    if (comboBox1.SelectedIndex == 0)
                        cr_t.Text = (bee * 1.1).ToString();
                    if (comboBox1.SelectedIndex == 1)
                        cr_t.Text = (bee * 1.4).ToString();
                    if (comboBox1.SelectedIndex == 2)
                        cr_t.Text = (bee * 1.2).ToString();
                    if (comboBox1.SelectedIndex == 3)
                        cr_t.Text = (bee * 1.6).ToString();
                    if (comboBox1.SelectedIndex == 4)
                        cr_t.Text = (bee * 1.2).ToString();
                    if (comboBox1.SelectedIndex == 5)
                        cr_t.Text = (bee * 1.3).ToString();
                    if (comboBox1.SelectedIndex == 6)
                        cr_t.Text = (bee * 1.2).ToString();
                    if (comboBox1.SelectedIndex == 7)
                        cr_t.Text = (bee * 1.2).ToString();

                }

            }
            catch 
            {
                MessageBox.Show("Please, Fill out the blank box.");
            }
        }

        private void BMI_FormClosing(object sender, FormClosingEventArgs e)
        {
            bmi_wg = wg_t.Text;
            bmi_ht = ht_t.Text;

            if (save_ch.Checked == true)
            {
                string temp="";
                
                if (bmi_t.Text != "")
                    temp = "BMI : " + bmi_t.Text + "  Kg/m2";

                ////
                if (bee_t.Text != "")
                {
                 if(temp == "")
                    temp = "BEE : " + bee_t.Text + "  KCal/Day";
                 else
                    temp = temp + "\n" + "BEE : " + bee_t.Text + "  KCal/Day";
                }
                ////
                if (cr_t.Text != "")
                {
                    if (temp == "")
                        temp = "Cal. Req. : " + cr_t.Text + "  KCal/Day";
                    else
                        temp = temp + "\n" + "Cal. Req. : " + cr_t.Text + "  KCal/Day";
                }

                if (Preventive.record_pc == "")
                {
                    Preventive.record_pc = temp;
                }
                else
                    Preventive.record_pc = Preventive.record_pc + "\n" + temp;
            }
        }

        private void BMI_Load(object sender, EventArgs e)
        {
            wg_t.Text = bmi_wg;
            ht_t.Text = bmi_ht;
            age_t.Text = bmi_age;
        }
    }
}