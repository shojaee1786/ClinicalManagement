using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Clinical_Management
{
    public partial class Dosage : Form
    {
        public static string wg = "";
        public static string record;
        public static int astrix_index;


        public Dosage()
        {
            InitializeComponent();
        }

        private void Dosage_Load(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
            record = "";
            astrix_index = -1;
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;
            string s;
            weight_t.Text = wg;
            int j = 0;
            int i;
            string temp_drug;
            int index_drug;
            for (i = 0; i < side_effect.drug_count; i++)
            {
                temp_drug = side_effect.drug[i + 1];
                index_drug = temp_drug.IndexOf("?");
                try
                {
                    if (index_drug != 0 && index_drug != -1)
                        temp_drug = temp_drug.Substring(index_drug + 1, temp_drug.Length - index_drug - 1);
                }
                catch { }
                drug_l.Items.Insert(i + j, temp_drug);
                sqlcmd.CommandText = "select trade from generic where name='" + side_effect.drug[i + 1] + "' ";
                data = sqlcmd.ExecuteReader();

                int myindex = 0;
                while (data.Read())
                {
                    s = data["trade"].ToString();
                    while (s != "")
                    {
                        myindex = s.IndexOf('?');
                        drug_l.Items.Insert(i + j + 1, "   " + s.Substring(0, myindex));
                        j++;

                        if (s.Length <= (myindex + 1))
                            s = "";
                        else
                            s = s.Substring(myindex + 1, s.Length - (myindex + 1));
                    }
                }
                data.Close();
            }


            sqlcmd.CommandText = "select distinct disp,refill,generic,form,strength,sig,route,period,frequency,fadesc,gendesc,advise,alarm from drug_tmp ";
            data = sqlcmd.ExecuteReader();

            int i1, i2, i3, i4, i5, i6;
            i1 = i2 = i3 = i4 = i5 = i6 = 0;
            while (data.Read())
            {
                s = data["form"].ToString();
                if (s != "")
                {
                    form_c.Items.Insert(i1, s);
                    i1++;
                }
                s = data["strength"].ToString();
                if (s != "")
                {
                    strength_c.Items.Insert(i2, s);
                    i2++;
                }
                s = data["frequency"].ToString();
                if (s != "")
                {
                    freq_c.Items.Insert(i3, s);
                    i3++;
                }
                s = data["sig"].ToString();
                if (s != "")
                {
                    sig_c.Items.Insert(i4, s);
                    i4++;
                }
                s = data["route"].ToString();
                if (s != "")
                {
                    route_c.Items.Insert(i5, s);
                    i5++;
                }
                s = data["period"].ToString();
                if (s != "")
                {
                    period_c.Items.Insert(i6, s);
                    i6++;
                }
                int new_index1 = 0;
                s = data["fadesc"].ToString();
                if (s != "")
                {
                    fadesc_t.AutoCompleteCustomSource.Add(s);
                    fadesc_c.Items.Insert(new_index1, s);
                    new_index1++;
                }
                int new_index2 = 0;
                s = data["gendesc"].ToString();
                if (s != "")
                {
                    gendesc_t.AutoCompleteCustomSource.Add(s);
                    gendesc_c.Items.Insert(new_index2, s);
                    new_index2++;
                }
                int new_index3 = 0;
                s = data["advise"].ToString();
                if (s != "")
                {
                    advise_t.AutoCompleteCustomSource.Add(s);
                    advise_c.Items.Insert(new_index3, s);
                    new_index3++;
                }
                int new_index4 = 0;
                s = data["alarm"].ToString();
                if (s != "")
                {
                    alarm_t.AutoCompleteCustomSource.Add(s);
                    alarm_c.Items.Insert(new_index4, s);
                    new_index4++;
                }
                s = data["disp"].ToString();
                if (s != "")
                {
                    disp_c.Items.Add(s);
                }
                s = data["refill"].ToString();
                if (s != "")
                {
                    refill_c.Items.Add(s);
                }
                s = data["generic"].ToString();
                if (s != "")
                {
                    generic_c.Items.Add(s);
                }
            }
            data.Close();



            sqlconn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch { }
        }

        private void drug_l_SelectedIndexChanged(object sender, EventArgs e)
        {
            ideal_t.Text = "";
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            SqlDataReader data;

            string mytemp = "";

            try
            {
                if (drug_l.SelectedItem.ToString().Substring(0, 2) == "  ")
                {
                    sqlcmd.CommandText = "select * from trade where name='" + drug_l.SelectedItem.ToString().Trim() + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        dos_t.Text = data["dosage"].ToString();
                        fadesc_t.Text = data["fadesc"].ToString();
                        gendesc_t.Text = data["gendesc"].ToString();
                        advise_t.Text = data["advise"].ToString();
                        alarm_t.Text = data["alarm"].ToString();


                        //// Added Code
                        mytemp = data["sideexp"].ToString();
                        side_effect.side_str = data["side"].ToString();
                        side_effect.side_color = data["sidecolor"].ToString();
                       ///////////////

                    }
                    data.Close();

                    //// Added Code
                    if (side_effect.side_str != "" && side_effect.side_str != null)
                    {
                        side_effect.drug_count++;
                        side_effect.drug[side_effect.drug_count] = drug_l.SelectedItem.ToString().Trim();
                        if (mytemp != "")
                            side_effect.side_str = side_effect.side_str + "\n" + mytemp;
                        side_effect frm = new side_effect();
                        frm.ShowDialog();
                    }
                    ///////////////

                }
                else
                {
                    int cnt = 1;
                    for (int i = 0; i < drug_l.SelectedIndex; i++)
                    {
                        if (drug_l.SelectedItem.ToString().Substring(0, 1) != " ")
                            cnt++;
                    }
                    sqlcmd.CommandText = "select * from generic2 where name='" + side_effect.drug[cnt] + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        dos_t.Text = data["dosage"].ToString();
                        fadesc_t.Text = data["fadesc"].ToString();
                        gendesc_t.Text = data["gendesc"].ToString();
                        advise_t.Text = data["advise"].ToString();
                        alarm_t.Text = data["alarm"].ToString();
                    }
                    data.Close();
                }
            }
            catch
            {
                int cnt = 1;
                for (int i = 0; i < drug_l.SelectedIndex; i++)
                {
                    if (drug_l.SelectedItem.ToString().Substring(0, 1) != " ")
                        cnt++;
                }
                sqlcmd.CommandText = "select * from generic2 where name='" + side_effect.drug[cnt] + "' ";
                data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    dos_t.Text = data["dosage"].ToString();
                    fadesc_t.Text = data["fadesc"].ToString();
                    gendesc_t.Text = data["gendesc"].ToString();
                    advise_t.Text = data["advise"].ToString();
                    alarm_t.Text = data["alarm"].ToString();
                }
                data.Close();
            }
            sqlconn.Close();

            if (weight_t.Text != "" && dos_t.Text != "")
            {
                try
                {
                    ideal_t.Text = (float.Parse(weight_t.Text) * float.Parse(dos_t.Text)).ToString();
                }
                catch { }
            }

            astrix_index++;
            if (astrix_index > 11)
                astrix_index = 0;

            if (richTextBox2.Text == "")
                richTextBox2.Text = astrix_c.Items[astrix_index].ToString() + drug_l.SelectedItem.ToString().Trim();
            else
            {
                richTextBox2.Text = richTextBox2.Text + "\n" + astrix_c.Items[astrix_index].ToString() + drug_l.SelectedItem.ToString().Trim();
            }



        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (weight_t.Text != "" && dos_t.Text != "")
            {
                try
                {
                    ideal_t.Text = (float.Parse(weight_t.Text) * float.Parse(dos_t.Text)).ToString();
                }
                catch { }
            }
        }

        private void fadesc_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void gendesc_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void alarm_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void advise_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void advise_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void del_b_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectedText = "";
            richTextBox1.SelectedText = "";
        }

        private void form_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + form_c.Text;
        }

        private void strength_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + strength_c.Text;
        }

        private void disp_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + disp_c.Text;
        }

        private void freq_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + freq_c.Text;
        }

        private void astrix_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + astrix_c.Text;
        }

        private void route_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + route_c.Text;
        }

        private void period_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + period_c.Text;
        }

        private void refill_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + refill_c.Text;
        }

        private void generic_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + generic_c.Text;
        }

        private void sig_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox2.Text + "   " + sig_c.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (astrix_index == -1)
            {
                MessageBox.Show("Please first select the drug.");
                return;
            }

            if (richTextBox1.Text == "")
            {
                if (fadesc_t.Text != "")
                    richTextBox1.Text = astrix_c.Items[astrix_index].ToString() + " " + fadesc_t.Text;

                if (gendesc_t.Text != "")
                {
                    if (richTextBox1.Text == "")
                        richTextBox1.Text = astrix_c.Items[astrix_index].ToString() + " " + gendesc_t.Text;
                    else
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + gendesc_t.Text;
                }
                if (alarm_t.Text != "")
                {
                    if (richTextBox1.Text == "")
                        richTextBox1.Text = astrix_c.Items[astrix_index].ToString() + " " + alarm_t.Text;
                    else
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + alarm_t.Text;
                }
                if (advise_t.Text != "")
                {
                    if (richTextBox1.Text == "")
                        richTextBox1.Text = astrix_c.Items[astrix_index].ToString() + " " + advise_t.Text;
                    else
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + advise_t.Text;
                }
            }
            else
                if (richTextBox1.Text != "")
                {
                    if (fadesc_t.Text != "")
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + fadesc_t.Text;
                    if (gendesc_t.Text != "")
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + gendesc_t.Text;
                    if (alarm_t.Text != "")
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + alarm_t.Text;
                    if (advise_t.Text != "")
                        richTextBox1.Text = richTextBox1.Text + "\n" + astrix_c.Items[astrix_index].ToString() + " " + advise_t.Text;
                }

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void exit_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void record_b_Click(object sender, EventArgs e)
        {
            record = richTextBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Clear();
        }

        private void print_b_Click(object sender, EventArgs e)
        {
            for (int ii = 0; ii < 65; ii++)
            {
                Prescription.p_t[ii] = "";
            }

            string temp = "";
            int j = 1;
            for (int k = 0; k < richTextBox2.Lines.Length; k++)
            {
                Prescription.p_t[j] = richTextBox2.Lines[k].ToString();
                Prescription.p_f[j] = 0;
                j++;

                if (Prescription.p_t[j - 1].Substring(0, 1) == "*")
                    temp = "*";
                if (Prescription.p_t[j - 1].Substring(0, 2) == "**")
                    temp = "**";
                if (Prescription.p_t[j - 1].Substring(0, 3) == "***")
                    temp = "***";
                if (Prescription.p_t[j - 1].Substring(0, 4) == "****")
                    temp = "****";

                if (Prescription.p_t[j - 1].Substring(0, 1) == "+")
                    temp = "+";
                if (Prescription.p_t[j - 1].Substring(0, 2) == "++")
                    temp = "++";
                if (Prescription.p_t[j - 1].Substring(0, 3) == "+++")
                    temp = "+++";
                if (Prescription.p_t[j - 1].Substring(0, 4) == "++++")
                    temp = "++++";

                if (Prescription.p_t[j - 1].Substring(0, 1) == "#")
                    temp = "#";
                if (Prescription.p_t[j - 1].Substring(0, 2) == "##")
                    temp = "##";
                if (Prescription.p_t[j - 1].Substring(0, 3) == "###")
                    temp = "###";
                if (Prescription.p_t[j - 1].Substring(0, 4) == "####")
                    temp = "####";


                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    if ((richTextBox1.Lines[i].Substring(0, temp.Length) == temp) &&
                         (richTextBox1.Lines[i].Substring(temp.Length, 1) != "*") &&
                        (richTextBox1.Lines[i].Substring(temp.Length, 1) != "+") &&
                        (richTextBox1.Lines[i].Substring(temp.Length, 1) != "#"))
                    {
                        Prescription.p_t[j] = richTextBox1.Lines[i].ToString();
                        Prescription.p_f[j] = 1;
                        j++;
                    }

                }

            }
            Prescription frm = new Prescription();
            frm.ShowDialog();
        }

        private void fadesc_t_Click(object sender, EventArgs e)
        {
            fadesc_c.Width = 17;
            fadesc_c.Visible = true;
        }

        private void gendesc_t_Click(object sender, EventArgs e)
        {
            gendesc_c.Width = 17;
            gendesc_c.Visible = true;
        }

        private void alarm_t_Click(object sender, EventArgs e)
        {
            alarm_c.Width = 17;
            alarm_c.Visible = true;
        }

        private void advise_t_Click(object sender, EventArgs e)
        {
            advise_c.Width = 17;
            advise_c.Visible = true;
        }

        private void fadesc_c_Click(object sender, EventArgs e)
        {
            if (fadesc_c.Width != 22 + fadesc_t.Width)
                fadesc_c.Width = 22 + fadesc_t.Width;
        }

        private void gendesc_c_Click(object sender, EventArgs e)
        {
            if (gendesc_c.Width != 22 + gendesc_t.Width)
                gendesc_c.Width = 22 + gendesc_t.Width;
        }

        private void alarm_c_Click(object sender, EventArgs e)
        {
            if (alarm_c.Width != 22 + alarm_t.Width)
                alarm_c.Width = 22 + alarm_t.Width;
        }

        private void advise_c_Click(object sender, EventArgs e)
        {
            if (advise_c.Width != 22 + advise_t.Width)
                advise_c.Width = 22 + advise_t.Width;
        }

        private void fadesc_c_MouseHover(object sender, EventArgs e)
        {
            fadesc_c.Width = 22 + fadesc_t.Width;
            fadesc_c.SendToBack();
        }

        private void gendesc_c_MouseHover(object sender, EventArgs e)
        {
            gendesc_c.Width = 22 + gendesc_t.Width;
            gendesc_c.SendToBack();

        }

        private void alarm_c_MouseHover(object sender, EventArgs e)
        {
            alarm_c.Width = 22 + alarm_t.Width;
            alarm_c.SendToBack();
        }

        private void advise_c_MouseHover(object sender, EventArgs e)
        {
            advise_c.Width = 22 + advise_t.Width;
            advise_c.SendToBack();
        }

        private void fadesc_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            fadesc_t.Text = fadesc_c.Text;
            fadesc_c.Width = 17;
            fadesc_c.Visible = false;
            fadesc_t.Focus();
        }

        private void gendesc_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            gendesc_t.Text = gendesc_c.Text;
            gendesc_c.Width = 17;
            gendesc_c.Visible = false;
            gendesc_t.Focus();
        }

        private void alarm_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            alarm_t.Text = alarm_c.Text;
            alarm_c.Width = 17;
            alarm_c.Visible = false;
            alarm_t.Focus();
        }

        private void advise_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            advise_t.Text = advise_c.Text;
            advise_c.Width = 17;
            advise_c.Visible = false;
            advise_t.Focus();
        }

        private void Dosage_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            sqlcmd.CommandText = "Select count(*) from drug_tmp where fadesc = '" + fadesc_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into drug_tmp(fadesc) values('" + fadesc_t.Text + "')";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "Select count(*) from drug_tmp where gendesc = '" + gendesc_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into drug_tmp(gendesc) values('" + gendesc_t.Text + "')";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "Select count(*) from drug_tmp where advise = '" + advise_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into drug_tmp(advise) values('" + advise_t.Text + "')";
                sqlcmd.ExecuteNonQuery();
            }

            sqlcmd.CommandText = "Select count(*) from drug_tmp where alarm = '" + alarm_t.Text + "' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                sqlcmd.CommandText = "Insert into drug_tmp(alarm) values('" + alarm_t.Text + "')";
                sqlcmd.ExecuteNonQuery();
            }

            sqlconn.Close();
        }
    }
}