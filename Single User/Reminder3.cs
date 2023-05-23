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
    public partial class Reminder3 : Form
    {
        
        public Reminder3()
        {
            InitializeComponent();
        }

        private void Reminder3_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Reminder3_Load(object sender, EventArgs e)
        {

            LanguageSelector.KeyboardLayout.Farsi();
            who_t.Focus();
            row_t.Text = Reminder.reminder_row[0].ToString();
            who_t.Text = Reminder.reminder_row[1].ToString();
            hour_t.Text = Reminder.reminder_row[2].ToString();
            days_t.Text = Reminder.reminder_row[3].ToString();
            day_t.Text = Reminder.reminder_row[4].ToString();
            month_t.Text = Reminder.reminder_row[5].ToString();
            year_t.Text = Reminder.reminder_row[6].ToString();
            what_t.Text = Reminder.reminder_row[7].ToString();
            instance_t.Text = Reminder.reminder_row[8].ToString();
            place_t.Text = Reminder.reminder_row[9].ToString();
            op_t.Text = Reminder.reminder_row[10].ToString();
            title_t.Text = Reminder.reminder_row[11].ToString();
            fname_t.Text = Reminder.reminder_row[12].ToString();
            family_t.Text = Reminder.reminder_row[13].ToString();
            tel_t.Text = Reminder.reminder_row[14].ToString();
            email_t.Text = Reminder.reminder_row[15].ToString();
            cause_t.Text = Reminder.reminder_row[16].ToString();
            desc_t.Text = Reminder.reminder_row[17].ToString();
            if (Reminder.reminder_row[18].ToString() == "True")
                tick_ch.Checked = true;
            else
                tick_ch.Checked = false;



            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select * from temp where form='" + this.Name + "' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();

            string s;
            int i = 0;
            sqlcmd.CommandText = "select distinct who from reminder_tmp where who<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["who"].ToString();
                who_t.AutoCompleteCustomSource.Add(s);
                who_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct what from reminder_tmp where what<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["what"].ToString();
                what_t.AutoCompleteCustomSource.Add(s);
                what_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct instance from reminder_tmp where instance<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["instance"].ToString();
                instance_t.AutoCompleteCustomSource.Add(s);
                instance_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct place from reminder_tmp where place<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["place"].ToString();
                place_t.AutoCompleteCustomSource.Add(s);
                place_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct op from reminder_tmp where op<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["op"].ToString();
                op_t.AutoCompleteCustomSource.Add(s);
                op_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct title from info where title<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["title"].ToString();
                title_t.AutoCompleteCustomSource.Add(s);
                title_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct cause from reminder_tmp where cause<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["cause"].ToString();
                cause_t.AutoCompleteCustomSource.Add(s);
                cause_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct desc1 from reminder_tmp where desc1<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["desc1"].ToString();
                desc_t.AutoCompleteCustomSource.Add(s);
                desc_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            i = 0;
            sqlcmd.CommandText = "select distinct days from reminder_tmp where days<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                s = data["days"].ToString();
                days_c.Items.Insert(i, s);
                i++;
            }
            data.Close();

            //sqlcmd.CommandText = "select distinct fname from info where fname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    fname_t.AutoCompleteCustomSource.Add(data["fname"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct mname from info where mname<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    family_t.AutoCompleteCustomSource.Add(data["mname"].ToString());
            //data.Close();

            //sqlcmd.CommandText = "select distinct tel from tel_tmp where tel<>''";
            //data = sqlcmd.ExecuteReader();
            //while (data.Read())
            //    tel_t.AutoCompleteCustomSource.Add(data["tel"].ToString());
            //data.Close();

            sqlcmd.CommandText = "select distinct email from reminder_tmp where email<>''";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
                email_t.AutoCompleteCustomSource.Add(data["email"].ToString());
            data.Close();



            sqlconn.Close();
        }

        private void Reminder3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SqlConnection sqlconn = new SqlConnection(cm.cs);
            //sqlconn.Open();
            //SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.Connection = sqlconn;
            //sqlcmd.CommandText = "update reminder set who='" + who_t.Text + "',hour1='" + hour_t.Text + "',days='" + days_t.Text + "',day1='" + day_t.Text + "',month1='" + month_t.Text + "',year1='" + year_t.Text + "',what='" + what_t.Text + "',instance='" + instance_t.Text + "',place='" + place_t.Text + "',op='" + op_t.Text + "',title='" + title_t.Text + "',fname='" + fname_t.Text + "',family='" + family_t.Text + "',tel='" + tel_t.Text + "',email='" + email_t.Text + "',cause='" + cause_t.Text + "',desc1='" + desc_t.Text + "' where row ='" + row_t.Text + "' ";
            //sqlcmd.ExecuteNonQuery();
            //sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reminder.reminder_edit_flag = true;
            Reminder.reminder_row[1] = who_t.Text;
            Reminder.reminder_row[2] = hour_t.Text;
            Reminder.reminder_row[3] = days_t.Text;
            Reminder.reminder_row[4] = day_t.Text;
            Reminder.reminder_row[5] = month_t.Text;
            Reminder.reminder_row[6] = year_t.Text;
            Reminder.reminder_row[7] = what_t.Text;
            Reminder.reminder_row[8] = instance_t.Text;
            Reminder.reminder_row[9] = place_t.Text;
            Reminder.reminder_row[10] = op_t.Text;
            Reminder.reminder_row[11] = title_t.Text;
            Reminder.reminder_row[12] = fname_t.Text;
            Reminder.reminder_row[13] = family_t.Text;
            Reminder.reminder_row[14] = tel_t.Text;
            Reminder.reminder_row[15] = email_t.Text;
            Reminder.reminder_row[16] = cause_t.Text;
            Reminder.reminder_row[17] = desc_t.Text;
            if (tick_ch.Checked == true)
                Reminder.reminder_row[18] = "True";
            else
                Reminder.reminder_row[18] = "False";

            this.Close();
        }

        private void who_t_Click(object sender, EventArgs e)
        {
            who_c.Width = 17;
            who_c.Visible = true;
        }

        private void days_t_Click(object sender, EventArgs e)
        {
            days_c.Width = 17;
            days_c.Visible = true;
        }

        private void month_t_Click(object sender, EventArgs e)
        {
            month_c.Width = 17;
            month_c.Visible = true;
        }

        private void what_t_Click(object sender, EventArgs e)
        {
            what_c.Width = 17;
            what_c.Visible = true;
        }

        private void instance_t_Click(object sender, EventArgs e)
        {
            instance_c.Width = 17;
            instance_c.Visible = true;
        }

        private void place_t_Click(object sender, EventArgs e)
        {
            place_c.Width = 17;
            place_c.Visible = true;
        }

        private void op_t_Click(object sender, EventArgs e)
        {
            op_c.Width = 17;
            op_c.Visible = true;
        }

        private void title_t_Click(object sender, EventArgs e)
        {
            title_c.Width = 17;
            title_c.Visible = true;
        }

        private void cause_t_Click(object sender, EventArgs e)
        {
            cause_c.Width = 17;
            cause_c.Visible = true;
        }

        private void desc_t_Click(object sender, EventArgs e)
        {
            desc_c.Width = 17;
            desc_c.Visible = true;
        }

        private void who_c_Click(object sender, EventArgs e)
        {
            if (who_c.Width != 22 + who_t.Width)
                who_c.Width = 22 + who_t.Width;
        }

        private void days_c_Click(object sender, EventArgs e)
        {
            if (days_c.Width != 22 + days_t.Width)
                days_c.Width = 22 + days_t.Width;
        }

        private void month_c_Click(object sender, EventArgs e)
        {
            if (month_c.Width != 22 + month_t.Width)
                month_c.Width = 22 + month_t.Width;
        }

        private void what_c_Click(object sender, EventArgs e)
        {
            if (what_c.Width != 22 + what_t.Width)
                what_c.Width = 22 + what_t.Width;
        }

        private void instance_c_Click(object sender, EventArgs e)
        {
            if (instance_c.Width != 22 + instance_t.Width)
                instance_c.Width = 22 + instance_t.Width;
        }

        private void place_c_Click(object sender, EventArgs e)
        {
            if (place_c.Width != 22 + place_t.Width)
                place_c.Width = 22 + place_t.Width;
        }

        private void op_c_Click(object sender, EventArgs e)
        {
            if (op_c.Width != 22 + op_t.Width)
                op_c.Width = 22 + op_t.Width;
        }

        private void title_c_Click(object sender, EventArgs e)
        {
            if (title_c.Width != 22 + title_t.Width)
                title_c.Width = 22 + title_t.Width;
        }

        private void cause_c_Click(object sender, EventArgs e)
        {
            if (cause_c.Width != 22 + cause_t.Width)
                cause_c.Width = 22 + cause_t.Width;
        }

        private void desc_c_Click(object sender, EventArgs e)
        {
            if (desc_c.Width != 22 + desc_t.Width)
                desc_c.Width = 22 + desc_t.Width;
        }

        private void who_c_MouseHover(object sender, EventArgs e)
        {
            who_c.Width = 22 + who_t.Width;
            who_c.SendToBack();
        }

        private void days_c_MouseHover(object sender, EventArgs e)
        {
            days_c.Width = 22 + days_t.Width;
            days_c.SendToBack();
        }

        private void month_c_MouseHover(object sender, EventArgs e)
        {
            month_c.Width = 22 + month_t.Width;
            month_c.SendToBack();
        }

        private void what_c_MouseHover(object sender, EventArgs e)
        {
            what_c.Width = 22 + what_t.Width;
            what_c.SendToBack();
        }

        private void instance_c_MouseHover(object sender, EventArgs e)
        {
            instance_c.Width = 22 + instance_t.Width;
            instance_c.SendToBack();
        }

        private void place_c_MouseHover(object sender, EventArgs e)
        {
            place_c.Width = 22 + place_t.Width;
            place_c.SendToBack();
        }

        private void op_c_MouseHover(object sender, EventArgs e)
        {
            op_c.Width = 22 + op_t.Width;
            op_c.SendToBack();
        }

        private void title_c_MouseHover(object sender, EventArgs e)
        {
            title_c.Width = 22 + title_t.Width;
            title_c.SendToBack();
        }

        private void cause_c_MouseHover(object sender, EventArgs e)
        {
            cause_c.Width = 22 + cause_t.Width;
            cause_c.SendToBack();
        }

        private void desc_c_MouseHover(object sender, EventArgs e)
        {
            desc_c.Width = 22 + desc_t.Width;
            desc_c.SendToBack();
        }

        private void who_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            who_t.Text = who_c.Text;
            who_c.Width = 17;
            who_c.Visible = false;
            who_t.Focus();
        }

        private void days_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            days_t.Text = days_c.Text;
            days_c.Width = 17;
            days_c.Visible = false;
            days_t.Focus();
        }

        private void month_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            month_t.Text = month_c.Text;
            month_c.Width = 17;
            month_c.Visible = false;
            month_t.Focus();
        }

        private void what_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            what_t.Text = what_c.Text;
            what_c.Width = 17;
            what_c.Visible = false;
            what_t.Focus();
        }

        private void instance_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            instance_t.Text = instance_c.Text;
            instance_c.Width = 17;
            instance_c.Visible = false;
            instance_t.Focus();
        }

        private void place_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            place_t.Text = place_c.Text;
            place_c.Width = 17;
            place_c.Visible = false;
            place_t.Focus();
        }

        private void op_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            op_t.Text = op_c.Text;
            op_c.Width = 17;
            op_c.Visible = false;
            op_t.Focus();
        }

        private void title_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            title_t.Text = title_c.Text;
            title_c.Width = 17;
            title_c.Visible = false;
            title_t.Focus();
        }

        private void cause_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            cause_t.Text = cause_c.Text;
            cause_c.Width = 17;
            cause_c.Visible = false;
            cause_t.Focus();
        }

        private void desc_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            desc_t.Text = desc_c.Text;
            desc_c.Width = 17;
            desc_c.Visible = false;
            desc_t.Focus();
        }

        private void email_t_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void email_t_Leave(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void hour_t_Enter(object sender, EventArgs e)
        {
            who_c.Visible = false;
        }

        private void day_t_Enter(object sender, EventArgs e)
        {
            days_c.Visible = false;
        }

        private void year_t_Enter(object sender, EventArgs e)
        {
            month_c.Visible = false;
        }

        private void instance_t_Enter(object sender, EventArgs e)
        {
            what_c.Visible = false;
        }

        private void place_t_Enter(object sender, EventArgs e)
        {
            instance_c.Visible = false;
        }

        private void op_t_Enter(object sender, EventArgs e)
        {
            place_c.Visible = false;
        }

        private void title_t_Enter(object sender, EventArgs e)
        {
            op_c.Visible = false;
        }

        private void fname_t_Enter(object sender, EventArgs e)
        {
            title_c.Visible = false;
        }

        private void desc_t_Enter(object sender, EventArgs e)
        {
            cause_c.Visible = false;
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            desc_c.Visible = false;
        }
    }
}