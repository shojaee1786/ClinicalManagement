using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Clinical_Management
{
    public partial class Register : Form
    {
        public static string first_id,second_id;
        public static int close = 1;
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            string s = first_id;
            string ss = "";

            for (int i = 0; i < 10; i++)
            {
                switch (s[i])
                {
                    case '0':
                        {
                            if (i == 0)
                                ss = ss + "SU4";
                            else
                                ss = ss + "Y";

                            break;
                        }
                    case '1':
                        {
                            if (i == 0)
                                ss = ss + "SU9";
                            else
                                ss = ss + "2";

                            break;
                        }
                    case '2':
                        {
                            if (i == 0)
                                ss = ss + "SU7";
                            else
                                ss = ss + "D";

                            break;
                        }
                    case '3':
                        {
                            if (i == 0)
                                ss = ss + "SU3";
                            else
                                ss = ss + "1";

                            break;
                        }
                    case '4':
                        {
                            if (i == 0)
                                ss = ss + "SU8";
                            else
                                ss = ss + "Q";

                            break;
                        }
                    case '5':
                        {
                            if (i == 0)
                                ss = ss + "SU2";
                            else
                                ss = ss + "Z";

                            break;
                        }
                    case '6':
                        {
                            if (i == 0)
                                ss = ss + "SU6";
                            else
                                ss = ss + "X";

                            break;
                        }
                    case '7':
                        {
                            if (i == 0)
                                ss = ss + "SU5";
                            else
                                ss = ss + "F";

                            break;
                        }
                    case '8':
                        {
                            if (i == 0)
                                ss = ss + "SU0";
                            else
                                ss = ss + "W";

                            break;
                        }
                    case '9':
                        {
                            if (i == 0)
                                ss = ss + "SU1";
                            else
                                ss = ss + "T";

                            break;
                        }

                }
            } // end of for

            t1.Text = ss.Substring(0, 3);
            t2.Text = ss.Substring(3, 3);
            t3.Text = ss.Substring(6, 3);
            t4.Text = ss.Substring(9, 3);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 3)
                textBox2.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 3)
                textBox3.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 3)
                textBox4.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (second_id == textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text)
            {
                MessageBox.Show("Thank you for Purchase", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = File.ReadAllText(Application.StartupPath + "\\userenv.cmm");
                query = query.Replace("|||000000000000", "|||" + second_id);
                File.WriteAllText(Application.StartupPath + "\\userenv.cmm", query);
                close = 0;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Authorization Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      
    }
}