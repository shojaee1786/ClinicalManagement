using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Clinical_Management
{
    public partial class Medical_Library : Form
    {
        public Medical_Library()
        {
            InitializeComponent();
        }

        /////// Farsi ///////
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";

            if (comboBox1.SelectedItem.ToString() == "عنوان")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct title from info where title<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["title"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "نام اول")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct fname from info where fname<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["fname"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "نام مياني")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct mname from info where mname<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["mname"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "نام آخر")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct lname from info where lname<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["lname"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "شغل")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct job from info where job<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["job"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "محل تولد")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct bplace from info where bplace<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["bplace"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "نوع بیمه")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct bimeh from info where bimeh<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["bimeh"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "وضعیت تاهل")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct marray from info where marray<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["marray"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "معرف")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct moaref from info where moaref<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["moaref"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "نام پدر")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct father from info where father<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["father"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "شماره شناسنامه")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct id from info where id<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["id"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "کد ملی")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct nid from info where nid<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["nid"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "کد پستی")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct zip from info where zip<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["zip"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "شهر یا روستا")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct city from info where city<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["city"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "محل صدور شناسنامه")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct sodor from info where sodor<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["sodor"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "معلولیت")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct malol from info where malol<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["malol"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "آدرس")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct adr from info where adr<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["adr"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "تحصیلات")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct tahsil from info where tahsil<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["tahsil"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }

            ///////////////////
            if (comboBox1.SelectedItem.ToString() == "علت مراجعه")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct cause from paziresh_tmp where cause<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["cause"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "محل")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct place from tel_tmp where place<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["place"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "توضيحات تلفن")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct desc1 from tel_tmp where desc1<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["desc1"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "شرح عمليات")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct op from acc_tmp where op<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["op"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "نام بانك")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct bank from acc_tmp where bank<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["bank"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "مرجع واريز")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct variz from acc_tmp where variz<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["variz"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "نام بيمارستان")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct hospital from acc_tmp where hospital<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["hospital"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "مجري")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct who from reminder_tmp where who<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["who"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "روزها")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct days from reminder_tmp where days<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["days"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "چه كند")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct what from reminder_tmp where what<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["what"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "مورد")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct instance from reminder_tmp where instance<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["instance"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            } if (comboBox1.SelectedItem.ToString() == "محل انجام")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct place from reminder_tmp where place<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["place"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "فعل انجام")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct op from reminder_tmp where op<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["op"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "علت يادآوري")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct cause from reminder_tmp where cause<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["cause"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            if (comboBox1.SelectedItem.ToString() == "توضيحات يادآوري")
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select distinct desc1 from reminder_tmp where desc1<>'' ", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                int i = 0;
                while (data.Read())
                {
                    listBox1.Items.Insert(i, data["desc1"].ToString());
                    i++;
                }
                data.Close();
                sqlconn.Close();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            catch { }
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Replace("'", "''");
                ///////////////////
                if (comboBox1.SelectedIndex == 18)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into paziresh_tmp(cause) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 19)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into tel_tmp(place) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 20)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into tel_tmp(desc1) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 21)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into acc_tmp(op) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 22)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into acc_tmp(bank) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 23)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into acc_tmp(variz) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 24)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into acc_tmp(hospital) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 25)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(who) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 26)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(days) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 27)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(what) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 28)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(instance) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                } 
                if (comboBox1.SelectedIndex == 29)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(place) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 30)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(op) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 31)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(cause) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 32)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into reminder_tmp(desc1) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }

                //////////////////////////

                if (comboBox1.SelectedIndex == 0)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select count(*) from info where title = '" + textBox1.Text.Trim() + "' ";
                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                    {
                        sqlcmd.CommandText = "insert into info(title) values('" + textBox1.Text.Trim() + "') ";
                        sqlcmd.ExecuteNonQuery();
                    }
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(fname) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(mname) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(lname) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 4)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(job) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 5)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(bplace) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 6)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(bimeh) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 7)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(marray) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 8)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(moaref) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 9)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(father) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 10)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(id) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 11)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(nid) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 12)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(zip) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 13)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(city) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 14)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(sodor) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 15)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(malol) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 16)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(adr) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 17)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("insert into info(tahsil) values('" + textBox1.Text.Trim() + "') ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
            }

        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox1.Text = textBox1.Text.Replace("'", "''");
                    ///////////////////
                    if (comboBox1.SelectedIndex == 18)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update paziresh_tmp set cause='" + textBox1.Text.Trim() + "' where cause='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 19)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set place='" + textBox1.Text.Trim() + "' where place='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 20)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set desc1='" + textBox1.Text.Trim() + "' where desc1='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 21)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set op='" + textBox1.Text.Trim() + "' where op='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 22)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set bank='" + textBox1.Text.Trim() + "' where bank='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 23)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set variz='" + textBox1.Text.Trim() + "' where variz='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 24)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set hospital='" + textBox1.Text.Trim() + "' where hospital='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 25)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set who='" + textBox1.Text.Trim() + "' where who='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 26)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set days='" + textBox1.Text.Trim() + "' where days='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 27)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set what='" + textBox1.Text.Trim() + "' where what='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 28)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set instance='" + textBox1.Text.Trim() + "' where instance='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 29)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set place='" + textBox1.Text.Trim() + "' where place='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 30)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set op='" + textBox1.Text.Trim() + "' where op='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 31)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set cause='" + textBox1.Text.Trim() + "' where cause='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 32)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set desc1='" + textBox1.Text.Trim() + "' where desc1='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }

                    //////////////////////////

                    if (comboBox1.SelectedIndex == 0)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set title='" + textBox1.Text.Trim() + "' where title='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set fname='" + textBox1.Text.Trim() + "' where fname='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set mname='" + textBox1.Text.Trim() + "' where mname='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set lname='" + textBox1.Text.Trim() + "' where lname='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set job='" + textBox1.Text.Trim() + "' where job='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set bplace='" + textBox1.Text.Trim() + "' where bplace='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 6)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set bimeh='" + textBox1.Text.Trim() + "' where bimeh='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 7)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set marray='" + textBox1.Text.Trim() + "' where marray='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 8)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set moaref='" + textBox1.Text.Trim() + "' where moaref='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 9)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set father='" + textBox1.Text.Trim() + "' where father='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 10)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set id='" + textBox1.Text.Trim() + "' where id='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 11)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set nid='" + textBox1.Text.Trim() + "' where nid='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 12)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set zip='" + textBox1.Text.Trim() + "' where zip='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 13)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set city='" + textBox1.Text.Trim() + "' where city='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 14)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set sodor='" + textBox1.Text.Trim() + "' where sodor='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 15)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set malol='" + textBox1.Text.Trim() + "' where malol='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 16)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set adr='" + textBox1.Text.Trim() + "' where adr='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }
                    if (comboBox1.SelectedIndex == 17)
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update info set tahsil='" + textBox1.Text.Trim() + "' where tahsil='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox1_SelectedIndexChanged(comboBox1, e);
                        sqlconn.Close();
                    }

                }

            }
            catch { }

        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ///////////////////
                if (comboBox1.SelectedIndex == 18)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update paziresh_tmp set cause='' where cause='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 19)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set place='' where place='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 20)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set desc1='' where desc1='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 21)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set op='' where op='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 22)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set bank='' where bank='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 23)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set variz='' where variz='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 24)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update acc_tmp set hospital='' where hospital='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 25)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set who='' where who='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 26)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set days='' where days='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 27)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set what='' where what='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 28)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set instance='' where instance='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 29)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set place='' where place='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 30)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set op='' where op='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 31)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set cause='' where cause='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 32)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update reminder_tmp set desc1='' where desc1='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }

                //////////////////////////
                if (comboBox1.SelectedIndex == 0)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set title = '' where title='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set fname='' where fname='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set mname='' where mname='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set lname='' where lname='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 4)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set job='' where job='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 5)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set bplace='' where bplace='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 6)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set bimeh='' where bimeh='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 7)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set marray='' where marray='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 8)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set moaref='' where moaref='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 9)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set father='' where father='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 10)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set id='' where id='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 11)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set nid='' where nid='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 12)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set zip='' where zip='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 13)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set city='' where city='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 14)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set sodor='' where sodor='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 15)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set malol='' where malol='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 16)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set adr='' where adr='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }
                if (comboBox1.SelectedIndex == 17)
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("Update info set tahsil='' where tahsil='" + listBox1.SelectedItem.ToString() + "' ", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    comboBox1_SelectedIndexChanged(comboBox1, e);
                    sqlconn.Close();
                }

            }
            catch { }

        }
        /////// End of Farsi ///////

        /////// English ///////
        private void lpnl_CheckedChanged(object sender, EventArgs e)
        {
            listBox2.Width = 588;
            listBox2.Height = 173;
            textBox2.Width = 588;
            comboBox2.Items.Clear();
            if (txt.Checked == true)
            {
                string[] s1 = new string[8]{ "CC", "PI", "PH", "FH", "PE", "Px", "IP", "OP" };
                for (int i = 0; i < 8; i++)
                    comboBox2.Items.Insert(i, s1[i]);
            }
            else
            {
                string[] s2 = new string[7] { "PI", "PH", "FH", "PE", "Px", "IP", "OP" };
                for (int i = 0; i < 7; i++)
                    comboBox2.Items.Insert(i, s2[i]);
            }

        }

        private void rpnl_CheckedChanged(object sender, EventArgs e)
        {
            listBox2.Width = 304;
            listBox2.Height = 173;
            textBox2.Width = 304;

            comboBox2.Items.Clear();
            if (txt.Checked == true)
            {
                string[] s1 = new string[9] { "NCC", "Sb", "Ob", "As", "Pl", "Px", "IP", "OP", "Co" };
                for (int i = 0; i < 9; i++)
                    comboBox2.Items.Insert(i, s1[i]);
            }
            else
            {
                string[] s2 = new string[8] { "Sb", "Ob", "As", "Pl", "Px", "IP", "OP", "Co" };
                for (int i = 0; i < 8; i++)
                    comboBox2.Items.Insert(i, s2[i]);
            }
        }

        private void parag_CheckedChanged(object sender, EventArgs e)
        {
            if (other_r.Checked == true)
                return;

            comboBox2.Items.Clear();
            if (lpnl.Checked == true)
            {
                string[] s1 = new string[7] { "PI", "PH", "FH", "PE", "Px", "IP", "OP" };
                for (int i = 0; i < 7; i++)
                    comboBox2.Items.Insert(i, s1[i]);
            }
            else
            {
                if (rpnl.Checked == true)
                {
                    string[] s2 = new string[8] { "Sb", "Ob", "As", "Pl", "Px", "IP", "OP", "Co" };
                    for (int i = 0; i < 8; i++)
                        comboBox2.Items.Insert(i, s2[i]);
                }
            }
        }

        private void txt_CheckedChanged(object sender, EventArgs e)
        {
            if (other_r.Checked == true)
                return;

            comboBox2.Items.Clear();
            if (lpnl.Checked == true)
            {
                string[] s1 = new string[8] { "CC", "PI", "PH", "FH", "PE", "Px", "IP", "OP" };
                for (int i = 0; i < 8; i++)
                    comboBox2.Items.Insert(i, s1[i]);
            }
            else
            {
                if (rpnl.Checked == true)
                {
                    string[] s2 = new string[9] { "NCC", "Sb", "Ob", "As", "Pl", "Px", "IP", "OP", "Co" };
                    for (int i = 0; i < 9; i++)
                        comboBox2.Items.Insert(i, s2[i]);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            textBox2.Text = "";

            ////////////////////////////////////////////////////
            /////////////////  Other   ////////////////////////
            ///////////////////////////////////////////////////
            if (other_r.Checked == true)
            {
                //         "Pharma - Disp.", 
                //"Pharma - Refill",
                //"",

                if (comboBox2.SelectedItem.ToString() == "Pharma - Generic")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct generic from drug_tmp where generic<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["generic"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Pharma - Refill")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct refill from drug_tmp where refill<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["refill"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Pharma - Disp.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct disp from drug_tmp where disp<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["disp"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Referral - Refer to")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct refer from referral where refer<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["refer"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Referral - Form")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct form from referral where form<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["form"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Tel - Email")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct email from tel_tmp where email<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["email"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Tel - Profession")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct profession from tel_tmp where profession<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["profession"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct chem_parag from preventive where chem_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["chem_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct chem_note from preventive where chem_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["chem_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct imm_child_parag from preventive where imm_child_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["imm_child_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct imm_child_note from preventive where imm_child_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["imm_child_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct imm_adult_note from preventive where imm_adult_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["imm_adult_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct imm_adult_parag from preventive where imm_adult_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["imm_adult_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct screen_parag from preventive where screen_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["screen_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct screen_note from preventive where screen_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["screen_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct screen from preventive where screen<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["screen"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct phe_adult_note from preventive where phe_adult_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["phe_adult_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct phe_adult_parag from preventive where phe_adult_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["phe_adult_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct phe_child_note from preventive where phe_child_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["phe_child_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct phe_child_parag from preventive where phe_child_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["phe_child_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Note")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_note from preventive where coun_note<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_note"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Parag.")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_parag from preventive where coun_parag<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_parag"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                
                
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct phe_child from preventive where phe_child<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["phe_child"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct phe_adult from preventive where phe_adult<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["phe_adult"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }


                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Alternative Therapy")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_therapy from preventive where coun_therapy<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_therapy"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Change Life Style")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_life from preventive where coun_life<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_life"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Vitamin Treatment")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_vitamin from preventive where coun_vitamin<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_vitamin"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Diet Treatment")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_diet from preventive where coun_diet<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_diet"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Contraceptive Method")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_contra from preventive where coun_contra<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_contra"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Tobacco Counseling")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_tobbacco from preventive where coun_tobbacco<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_tobbacco"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Sexuall Disease Prevention")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_sex from preventive where coun_sex<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_sex"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Injury Prevention")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_injury from preventive where coun_injury<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_injury"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }


                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Dental Care")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct coun_dental from preventive where coun_dental<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["coun_dental"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct imm_child from preventive where imm_child<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["imm_child"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                ////////////////
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct chem from preventive where chem<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["chem"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct imm_adult from preventive where imm_adult<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["imm_adult"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Consultation - Messenger")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct chat from consult where chat<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["chat"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Consultation - Favorite Sites")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct site from consult where site<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["site"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Research - Analytical Programs")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct p1 from research where p1<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["p1"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Research - Writing Programs")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct p2 from research where p2<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["p2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
            }
            ////////////////////////////////////
            ////// End of Other ////////////////

            if (txt.Checked == true && lpnl.Checked == true)
            {
                if (comboBox2.SelectedItem.ToString() == "CC")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct cc from firstvisit where cc<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["cc"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "PI")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct pi from firstvisit where pi<>'' and fpi = '"+ filter_c.Text +"' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["pi"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "PH")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ph from firstvisit where ph<>'' and fph = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ph"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "FH")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct fh from firstvisit where fh<>'' and ffh = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["fh"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "PE")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct pe from firstvisit where pe<>'' and fpe = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["pe"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Px")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct px from firstvisit where px<>'' and fpx = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["px"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "IP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ip from firstvisit where ip<>'' and fip = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ip"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "OP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct op from firstvisit where op<>'' and fop = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["op"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }


              

            }
            ////////////////////////////////////////////////
            if (txt.Checked == true && rpnl.Checked == true)
            {
                if (comboBox2.SelectedItem.ToString() == "NCC")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct cc from firstvisit where cc<>'' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["cc"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Sb")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct sb from secondvisit where sb<>'' and fsb = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["sb"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Ob")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ob from secondvisit where ob<>'' and fob = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ob"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "As")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ass from secondvisit where ass<>'' and fas = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ass"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Pl")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct pl from secondvisit where pl<>'' and fpl = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["pl"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Px")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct px from secondvisit where px<>'' and fpx = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["px"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "IP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ip from secondvisit where ip<>'' and fip = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ip"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "OP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct op from secondvisit where op<>'' and fop = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["op"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Co")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct co from secondvisit where co<>'' and fco = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["co"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

            }
            //////////////////////////////////////////////////
            if (parag.Checked == true && lpnl.Checked == true)
            {
                if (comboBox2.SelectedItem.ToString() == "PI")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct pi2 from firstvisit where pi2<>'' and fpi2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["pi2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "PH")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ph2 from firstvisit where ph2<>'' and fph2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ph2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "FH")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct fh2 from firstvisit where fh2<>'' and ffh2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["fh2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "PE")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct pe2 from firstvisit where pe2<>'' and fpe2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["pe2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Px")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct px2 from firstvisit where px2<>'' and fpx2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["px2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "IP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ip2 from firstvisit where ip2<>'' and fip2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ip2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "OP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct op2 from firstvisit where op2<>'' and fop2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["op2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

            }
            ////////////////////////////////////////////////////
            if (parag.Checked == true && rpnl.Checked == true)
            {
                if (comboBox2.SelectedItem.ToString() == "Sb")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct sb2 from secondvisit where sb2<>'' and fsb2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["sb2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Ob")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ob2 from secondvisit where ob2<>'' and fob2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ob2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "As")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ass2 from secondvisit where ass2<>'' and fas2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ass2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Pl")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct pl2 from secondvisit where pl2<>'' and fpl2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["pl2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Px")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct px2 from secondvisit where px2<>'' and fpx2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["px2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "IP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct ip2 from secondvisit where ip2<>'' and fip2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["ip2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "OP")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct op2 from secondvisit where op2<>'' and fop2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["op2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }
                if (comboBox2.SelectedItem.ToString() == "Co")
                {
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand("select distinct co2 from secondvisit where co2<>'' and fco2 = '" + filter_c.Text + "' ", sqlconn);
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    while (data.Read())
                    {
                        listBox2.Items.Insert(i, data["co2"].ToString());
                        i++;
                    }
                    data.Close();
                    sqlconn.Close();
                }

            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = listBox2.SelectedItem.ToString();
            }
            catch { }
        }

        private void Insert_Eng_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text.Replace("'", "''");
                    //////// Other ////////////
                    if (other_r.Checked == true)
                    {
                       
                        if (comboBox2.SelectedItem.ToString() == "Pharma - Generic")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(generic) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Pharma - Refill")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(refill) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Pharma - Disp.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into drug_tmp(disp) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(chem) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(imm_adult) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(phe_child) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(phe_adult) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Alternative Therapy")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_therapy) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Change Life Style")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_life) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Vitamin Treatment")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_vitamin) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Diet Treatment")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_diet) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Contraceptive Method")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_contra) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Tobacco Counseling")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_tobbacco) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Sexuall Disease Prevention")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_sex) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Injury Prevention")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_injury) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }


                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Dental Care")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_dental) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(imm_child) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        ///////////////
                        if (comboBox2.SelectedItem.ToString() == "Referral - Refer to")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into referral(refer) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Referral - Form")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into referral(form) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Printer\\" + textBox2.Text);
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Tel - Email")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into tel_tmp(email) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Tel - Profession")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into tel_tmp(profession) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(chem_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(chem_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(imm_child_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(imm_child_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(imm_adult_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(imm_adult_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(screen_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(screen_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(screen) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(phe_adult_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(phe_adult_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(phe_child_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(phe_child_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_note) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into preventive(coun_parag) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        ////////////////


                        if (comboBox2.SelectedItem.ToString() == "Research - Analytical Programs")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into research(p1) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Research - Writing Programs")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into research(p2) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Consultation - Messenger")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into consult(chat) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Consultation - Favorite Sites")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into consult(site) values('" + textBox2.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    /////// End of Other //////

                    if (txt.Checked == true && lpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "CC")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;
                            sqlcmd.CommandText = "select count(*) from firstvisit where cc='" + textBox2.Text + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into firstvisit(cc) values('" + textBox2.Text + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PI")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(pi,fpi) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(ph,fph) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "FH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(fh,ffh) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PE")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(pe,fpe) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(px,fpx) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(ip,fip) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(op,fop) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    ////////////////////////////////////////////////
                    if (txt.Checked == true && rpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "NCC")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlconn;
                            sqlcmd.CommandText = "select count(*) from firstvisit where cc='" + textBox2.Text + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into firstvisit(cc) values('" + textBox2.Text + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Sb")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(sb,fsb) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Ob")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(ob,fob) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "As")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(ass,fas) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Pl")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(pl,fpl) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(px,fpx) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(ip,fip) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(op,fop) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Co")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(co,fco) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    //////////////////////////////////////////////////
                    if (parag.Checked == true && lpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "PI")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(pi2,fpi2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(ph2,fph2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "FH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(fh2,ffh2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PE")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(pe2,fpe2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(px2,fpx2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(ip2,fip2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into firstvisit(op2,fop2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    ////////////////////////////////////////////////////
                    if (parag.Checked == true && rpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "Sb")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(sb2,fsb2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Ob")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(ob2,fob2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "As")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(ass2,fas2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Pl")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(pl2,fpl2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(px2,fpx2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(ip2,fip2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(op2,fop2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Co")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("insert into secondvisit(co2,fco2) values('" + textBox2.Text + "','" + filter_c.Text + "') ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    ////////////////////////////////////////////////////
                }

            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tree frm = new tree();
            frm.Show();
        }

        private void Medical_Library_Load(object sender, EventArgs e)
        {
            filter_c.Items.Clear();
            filter_c.Items.Insert(0, "General");

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct cc from firstvisit where cc<>'' ", sqlconn);
            SqlDataReader data = sqlcmd.ExecuteReader();
            int i = 1;
            while (data.Read())
            {
                filter_c.Items.Insert(i, data["cc"].ToString());
                i++;
            }
            data.Close();

            filter_c.SelectedIndex = 0;

            sqlcmd.CommandText = "select * from temp where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                this.Left = Int32.Parse(data["fleft"].ToString());
                this.Top = Int32.Parse(data["ftop"].ToString());
                this.Width = Int32.Parse(data["width"].ToString());
                this.Height = Int32.Parse(data["height"].ToString());
            }
            data.Close();
            
            sqlconn.Close();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox2.Width = 588;
            textBox2.Width = 588;
            const int str_cnt = 40;
            comboBox2.Items.Clear();
            string[] s = new string[str_cnt]
            {
                
                "Pharma - Disp.", 
                "Pharma - Refill",
                "Pharma - Generic",
                "Consultation - Messenger", 
                "Consultation - Favorite Sites",
                "Research - Analytical Programs",
                "Research - Writing Programs",
                "Preventive Care - Chemoprophylaxis",
                "Preventive Care - Immunisation - Adults",
                "Preventive Care - Immunisation - Children",
                "Preventive Care - Periodic Health Exam. - Adults",
                "Preventive Care - Periodic Health Exam. - Children",
                "Preventive Care - Counseling - Dental Care",
                "Preventive Care - Counseling - Injury Prevention",
                "Preventive Care - Counseling - Sexuall Disease Prevention",
                "Preventive Care - Counseling - Tobacco Counseling",
                "Preventive Care - Counseling - Contraceptive Method",
                "Preventive Care - Counseling - Diet Treatment",
                "Preventive Care - Counseling - Vitamin Treatment",
                "Preventive Care - Counseling - Change Life Style",
                "Preventive Care - Counseling - Alternative Therapy",
                "Tel - Profession",
                "Tel - Email",
                "Referral - Form",
                "Referral - Refer to",
                "Preventive Care - Periodic Health Exam. - Adults - Note",
                "Preventive Care - Periodic Health Exam. - Adults - Parag.",
                "Preventive Care - Periodic Health Exam. - Children - Note",
                "Preventive Care - Periodic Health Exam. - Children - Parag.",
                "Preventive Care - Counseling - Note",
                "Preventive Care - Counseling - Parag.",
                "Preventive Care - Screening",
                "Preventive Care - Screening - Note",
                "Preventive Care - Screening - Parag.",
                "Preventive Care - Immunisation - Adults - Parag.",
                "Preventive Care - Immunisation - Adults - Note",
                "Preventive Care - Immunisation - Children - Note",
                "Preventive Care - Immunisation - Children - Parag.",
                "Preventive Care - Chemoprophylaxis - Note",
                "Preventive Care - Chemoprophylaxis - Parag."



            };
            for (int i = 0; i < str_cnt; i++)
            {
                comboBox2.Items.Insert(i, s[i]);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text.Substring(textBox2.Text.Length - 1, 1) == "'")
            //{
            //    textBox2.Text = textBox2.Text + "' ";

            //}
        }

        private void Update_Eng_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text.Replace("'", "''");
                    //////// Other ////////////
                    if (other_r.Checked == true)
                    {

              
                        if (comboBox2.SelectedItem.ToString() == "Pharma - Disp.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set disp='" + textBox2.Text.Trim() + "' where disp='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }


                        if (comboBox2.SelectedItem.ToString() == "Pharma - Generic")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set generic='" + textBox2.Text.Trim() + "' where generic='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Pharma - Refill")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set refill='" + textBox2.Text.Trim() + "' where refill='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }






                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set chem='" + textBox2.Text.Trim() + "' where chem='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }


                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set chem='" + textBox2.Text.Trim() + "' where chem='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_adult='" + textBox2.Text.Trim() + "' where imm_adult='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_child='" + textBox2.Text.Trim() + "' where phe_child='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_adult='" + textBox2.Text.Trim() + "' where phe_adult='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Alternative Therapy")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_therapy='" + textBox2.Text.Trim() + "' where coun_therapy='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Change Life Style")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_life='" + textBox2.Text.Trim() + "' where coun_life='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }

                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Vitamin Treatment")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_vitamin='" + textBox2.Text.Trim() + "' where coun_vitamin='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Diet Treatment")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_diet='" + textBox2.Text.Trim() + "' where coun_diet='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Contraceptive Method")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_contra='" + textBox2.Text.Trim() + "' where coun_contra='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Tobacco Counseling")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_tobbacco='" + textBox2.Text.Trim() + "' where coun_tobbacco='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Sexuall Disease Prevention")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_sex='" + textBox2.Text.Trim() + "' where coun_sex='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Injury Prevention")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_injury='" + textBox2.Text.Trim() + "' where coun_injury='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }


                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Dental Care")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_dental='" + textBox2.Text.Trim() + "' where coun_dental='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            try
                            {
                                Directory.Move(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"), Application.StartupPath + "\\Printer\\" + textBox2.Text.Trim());
                            }
                            catch { }
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_child='" + textBox2.Text.Trim() + "' where imm_child='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        //////////////////
                        if (comboBox2.SelectedItem.ToString() == "Referral - Refer to")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update referral set refer='" + textBox2.Text.Trim() + "' where refer='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Referral - Form")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update referral set form='" + textBox2.Text.Trim() + "' where form='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Tel - Email")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set email='" + textBox2.Text.Trim() + "' where email='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Tel - Profession")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set profession='" + textBox2.Text.Trim() + "' where profession='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set chem_parag='" + textBox2.Text.Trim() + "' where chem_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set chem_note='" + textBox2.Text.Trim() + "' where chem_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_child_parag='" + textBox2.Text.Trim() + "' where imm_child_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_child_note='" + textBox2.Text.Trim() + "' where imm_child_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_adult_note='" + textBox2.Text.Trim() + "' where imm_adult_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_adult_parag='" + textBox2.Text.Trim() + "' where imm_adult_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set screen_parag='" + textBox2.Text.Trim() + "' where screen_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set screen_note='" + textBox2.Text.Trim() + "' where screen_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set screen='" + textBox2.Text.Trim() + "' where screen='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_adult_note='" + textBox2.Text.Trim() + "' where phe_adult_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_adult_parag='" + textBox2.Text.Trim() + "' where phe_adult_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_child_note='" + textBox2.Text.Trim() + "' where phe_child_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_child_parag='" + textBox2.Text.Trim() + "' where phe_child_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Note")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_note='" + textBox2.Text.Trim() + "' where coun_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Parag.")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_parag='" + textBox2.Text.Trim() + "' where coun_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        ////////////////


                        if (comboBox2.SelectedItem.ToString() == "Research - Analytical Programs")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update research set p1='" + textBox2.Text.Trim() + "' where p1='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Research - Writing Programs")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update research set p2='" + textBox2.Text.Trim() + "' where p2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Consultation - Messenger")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update consult set chat='" + textBox2.Text.Trim() + "' where chat='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Consultation - Favorite Sites")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update consult set site='" + textBox2.Text.Trim() + "' where site='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    /////// End of Other //////

                    if (txt.Checked == true && lpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "CC")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set cc='" + textBox2.Text.Trim() + "' where cc='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PI")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pi='" + textBox2.Text.Trim() + "' where pi='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ph='" + textBox2.Text.Trim() + "' where ph='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "FH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set fh='" + textBox2.Text.Trim() + "' where fh='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PE")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pe='" + textBox2.Text.Trim() + "' where pe='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set px='" + textBox2.Text.Trim() + "' where px='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ip='" + textBox2.Text.Trim() + "' where ip='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set op='" + textBox2.Text.Trim() + "' where op='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    ////////////////////////////////////////////////
                    if (txt.Checked == true && rpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "NCC")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set cc='" + textBox2.Text.Trim() + "' where cc='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Sb")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set sb='" + textBox2.Text.Trim() + "' where sb='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Ob")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ob='" + textBox2.Text.Trim() + "' where ob='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "As")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ass='" + textBox2.Text.Trim() + "' where ass='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Pl")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set pl='" + textBox2.Text.Trim() + "' where pl='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set px='" + textBox2.Text.Trim() + "' where px='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ip='" + textBox2.Text.Trim() + "' where ip='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set op='" + textBox2.Text.Trim() + "' where op='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Co")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set co='" + textBox2.Text.Trim() + "' where co='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    //////////////////////////////////////////////////
                    if (parag.Checked == true && lpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "PI")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pi2='" + textBox2.Text.Trim() + "' where pi2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ph2='" + textBox2.Text.Trim() + "' where ph2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "FH")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set fh2='" + textBox2.Text.Trim() + "' where fh2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "PE")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pe2='" + textBox2.Text.Trim() + "' where pe2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set px2='" + textBox2.Text.Trim() + "' where px2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ip2='" + textBox2.Text.Trim() + "' where ip2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update firstvisit set op2='" + textBox2.Text.Trim() + "' where op2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    ////////////////////////////////////////////////////
                    if (parag.Checked == true && rpnl.Checked == true)
                    {
                        if (comboBox2.SelectedItem.ToString() == "Sb")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set sb2='" + textBox2.Text.Trim() + "' where sb2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Ob")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ob2='" + textBox2.Text.Trim() + "' where ob2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "As")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ass2='" + textBox2.Text.Trim() + "' where ass2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Pl")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set pl2='" + textBox2.Text.Trim() + "' where pl2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Px")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set px2='" + textBox2.Text.Trim() + "' where px2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "IP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ip2='" + textBox2.Text.Trim() + "' where ip2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "OP")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set op2='" + textBox2.Text.Trim() + "' where op2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }
                        if (comboBox2.SelectedItem.ToString() == "Co")
                        {
                            SqlConnection sqlconn = new SqlConnection(cm.cs);
                            sqlconn.Open();
                            SqlCommand sqlcmd = new SqlCommand("Update secondvisit set co2='" + textBox2.Text.Trim() + "' where co2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                            sqlcmd.ExecuteNonQuery();
                            comboBox2_SelectedIndexChanged(comboBox2, e);
                            sqlconn.Close();
                        }

                    }
                    ////////////////////////////////////////////////////

                }
            }
            catch { }
        }

        private void Del_Eng_Click(object sender, EventArgs e)
        {
            try
            {
                //////// Other ////////////
                if (other_r.Checked == true)
                {
                    
                    if (comboBox2.SelectedItem.ToString() == "Pharma - Generic")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set generic='' where generic='" + listBox2.SelectedItem.ToString().Replace("'","''").Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Pharma - Refill")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set refill='' where refill='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Pharma - Disp.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update drug_tmp set disp='' where disp='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }


                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set chem='' where chem='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_adult='' where imm_adult='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_child='' where phe_child='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_adult='' where phe_adult='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Alternative Therapy")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_therapy='' where coun_therapy='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Change Life Style")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_life='' where coun_life='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Vitamin Treatment")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_vitamin='' where coun_vitamin='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Diet Treatment")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_diet='' where coun_diet='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Contraceptive Method")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_contra='' where coun_contra='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Tobacco Counseling")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_tobbacco='' where coun_tobbacco='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Sexuall Disease Prevention")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_sex='' where coun_sex='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Injury Prevention")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_injury='' where coun_injury='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }


                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Dental Care")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_dental='' where coun_dental='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_child='' where imm_child='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    ///////
                    if (comboBox2.SelectedItem.ToString() == "Referral - Refer to")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update referral set refer='' where refer='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Referral - Form")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update referral set form='' where form='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        try
                        {
                            Directory.Delete(Application.StartupPath + "\\Printer\\" + listBox2.SelectedItem.ToString().Replace("'", "''"));
                        }
                        catch { }
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Tel - Email")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set email='' where email='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Tel - Profession")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update tel_tmp set profession='' where profession='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set chem_parag='' where chem_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Chemoprophylaxis - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set chem_note='' where chem_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_child_parag='' where imm_child_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Children - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_child_note='' where imm_child_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_adult_note='' where imm_adult_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Immunisation - Adults - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set imm_adult_parag='' where imm_adult_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set screen_parag='' where screen_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set screen_note='' where screen_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Screening")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set screen='' where screen='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_adult_note='' where phe_adult_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Adults - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_adult_parag='' where phe_adult_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_child_note='' where phe_child_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Periodic Health Exam. - Children - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set phe_child_parag='' where phe_child_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Note")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_note='' where coun_note='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Preventive Care - Counseling - Parag.")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update preventive set coun_parag='' where coun_parag='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    ////////////////


                    if (comboBox2.SelectedItem.ToString() == "Research - Analytical Programs")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update research set p1='' where p1='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Research - Writing Programs")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update research set p2='' where p2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Consultation - Messenger")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update consult set chat='' where chat='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Consultation - Favorite Sites")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update consult set site='' where site='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                }
                /////// End of Other //////

                if (txt.Checked == true && lpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "CC")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set cc='' where cc='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PI")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pi='' where pi='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ph='' where ph='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "FH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set fh='' where fh='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PE")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pe='' where pe='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set px='' where px='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ip='' where ip='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set op='' where op='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                }
                ////////////////////////////////////////////////
                if (txt.Checked == true && rpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "NCC")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set cc='' where cc='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Sb")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set sb='' where sb='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Ob")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ob='' where ob='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "As")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ass='' where ass='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Pl")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set pl='' where pl='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set px='' where px='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ip='' where ip='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set op='' where op='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Co")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set co='' where co='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                }
                //////////////////////////////////////////////////
                if (parag.Checked == true && lpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "PI")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pi2='' where pi2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ph2='' where ph2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "FH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set fh2='' where fh2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PE")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set pe2='' where pe2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set px2='' where px2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ip2='' where ip2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update firstvisit set op2='' where op2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                }
                ////////////////////////////////////////////////////
                if (parag.Checked == true && rpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "Sb")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set sb2='' where sb2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Ob")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ob2='' where ob2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "As")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ass2='' where ass2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Pl")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set pl2='' where pl2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set px2='' where px2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set ip2='' where ip2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set op2='' where op2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Co")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("Update secondvisit set co2='' where co2='" + listBox2.SelectedItem.ToString().Replace("'","''") + "' ", sqlconn);
                        sqlcmd.ExecuteNonQuery();
                        comboBox2_SelectedIndexChanged(comboBox2, e);
                        sqlconn.Close();
                    }

                }
                ////////////////////////////////////////////////////

            }
            catch { }
        }

        private void Medical_Library_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            //if (textBox2.Text != "" && filter_c.Text != "")
            //{
            //    if (lpnl.Checked == true && txt.Checked == true)
            //    {
            //        if (comboBox2.Text == "PI")
            //        {
            //            SqlConnection sqlconn = new SqlConnection(cm.cs);
            //            sqlconn.Open();
            //            SqlCommand sqlcmd = new SqlCommand();
            //            sqlcmd.Connection = sqlconn;
            //            sqlcmd.CommandText = "Update firstvisit set fpi='"+ filter_c.Text +"' where pi = '"+  +"' ";
            //            sqlcmd.ExecuteNonQuery();
            //            sqlconn.Close();
            //        }
            //    }
            //}
        }

        private void filter_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            textBox2.Text = "";
            try
            {
                if (txt.Checked == true && lpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "CC")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct cc from firstvisit where cc<>'' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["cc"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PI")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct pi from firstvisit where pi<>'' and fpi = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["pi"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ph from firstvisit where ph<>'' and fph = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ph"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "FH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct fh from firstvisit where fh<>'' and ffh = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["fh"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PE")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct pe from firstvisit where pe<>'' and fpe = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["pe"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct px from firstvisit where px<>'' and fpx = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["px"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ip from firstvisit where ip<>'' and fip = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ip"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct op from firstvisit where op<>'' and fop = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["op"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }




                }
                ////////////////////////////////////////////////
                if (txt.Checked == true && rpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "NCC")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct cc from firstvisit where cc<>'' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["cc"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Sb")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct sb from secondvisit where sb<>'' and fsb = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["sb"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Ob")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ob from secondvisit where ob<>'' and fob = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ob"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "As")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ass from secondvisit where ass<>'' and fas = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ass"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Pl")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct pl from secondvisit where pl<>'' and fpl = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["pl"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct px from secondvisit where px<>'' and fpx = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["px"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ip from secondvisit where ip<>'' and fip = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ip"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct op from secondvisit where op<>'' and fop = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["op"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Co")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct co from secondvisit where co<>'' and fco = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["co"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }

                }
                //////////////////////////////////////////////////
                if (parag.Checked == true && lpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "PI")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct pi2 from firstvisit where pi2<>'' and fpi2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["pi2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ph2 from firstvisit where ph2<>'' and fph2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ph2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "FH")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct fh2 from firstvisit where fh2<>'' and ffh2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["fh2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "PE")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct pe2 from firstvisit where pe2<>'' and fpe2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["pe2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct px2 from firstvisit where px2<>'' and fpx2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["px2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ip2 from firstvisit where ip2<>'' and fip2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ip2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct op2 from firstvisit where op2<>'' and fop2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["op2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }

                }
                ////////////////////////////////////////////////////
                if (parag.Checked == true && rpnl.Checked == true)
                {
                    if (comboBox2.SelectedItem.ToString() == "Sb")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct sb2 from secondvisit where sb2<>'' and fsb2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["sb2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Ob")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ob2 from secondvisit where ob2<>'' and fob2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ob2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "As")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ass2 from secondvisit where ass2<>'' and fas2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ass2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Pl")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct pl2 from secondvisit where pl2<>'' and fpl2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["pl2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Px")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct px2 from secondvisit where px2<>'' and fpx2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["px2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "IP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct ip2 from secondvisit where ip2<>'' and fip2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["ip2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "OP")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct op2 from secondvisit where op2<>'' and fop2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["op2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }
                    if (comboBox2.SelectedItem.ToString() == "Co")
                    {
                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand("select distinct co2 from secondvisit where co2<>'' and fco2 = '" + filter_c.Text + "' ", sqlconn);
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        while (data.Read())
                        {
                            listBox2.Items.Insert(i, data["co2"].ToString());
                            i++;
                        }
                        data.Close();
                        sqlconn.Close();
                    }

                }
            }
            catch { }


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for Text File...";
            dlg.Filter = "Text Documents(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int myindex;
                string query = File.ReadAllText(dlg.FileName);
                query = query.Replace("\r", "");
                string mydata, myfilter = "General";

                while (true)
                {
                    if (query.Contains("\n") == true)
                    {
                        myindex = query.IndexOf("\n");
                        mydata = query.Substring(0, myindex);

                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlconn;
                        if (comboBox2.Text == "CC")
                        {
                            sqlcmd.CommandText = "select count(*) from firstvisit where cc = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into firstvisit(cc) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                        }

                        if (other_r.Checked == true)
                        {
                            if (comboBox2.Text == "Consultation - Favorite Sites")
                            {
                                sqlcmd.CommandText = "select count(*) from consult where site = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into consult(site) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Chemoprophylaxis")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where chem = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(chem) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Immunisation - Adults")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where imm_adult = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(imm_adult) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Immunisation - Children")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where imm_child = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(imm_child) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Adults")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where phe_adult = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(phe_adult) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Children")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where phe_child = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(phe_child) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Tel - Profession")
                            {
                                sqlcmd.CommandText = "select count(*) from tel where profession = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into tel(profession) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Adults - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where phe_adult_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(phe_adult_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Children - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where phe_child_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(phe_child_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Counseling - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where coun_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(coun_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Screening")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where screen = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(screen) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Screening - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where screen_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(screen_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Immunisation - Adults - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where imm_adult_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(imm_adult_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Immunisation - Children - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where imm_child_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(imm_child_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                            if (comboBox2.Text == "Preventive Care - Chemoprophylaxis - Note")
                            {
                                sqlcmd.CommandText = "select count(*) from preventive where chem_note = '" + mydata + "' ";
                                if (sqlcmd.ExecuteScalar().ToString() == "0")
                                {
                                    sqlcmd.CommandText = "insert into preventive(chem_note) values('" + mydata + "') ";
                                    sqlcmd.ExecuteNonQuery();
                                }
                            }

                        } // End of Others

                        if (lpnl.Checked == true && txt.Checked == true)
                        {
                            if (comboBox2.Text == "PI")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where pi = '" + mydata + "' and fpi = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(pi,fpi) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "PH")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where ph = '" + mydata + "' and fph = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(ph,fph) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "FH")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where fh = '" + mydata + "' and ffh = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(fh,ffh) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "PE")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where pe = '" + mydata + "' and fpe = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(pe,fpe) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "Px")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where px = '" + mydata + "' and fpx = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(px,fpx) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "IP")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where ip = '" + mydata + "' and fip = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(ip,fip) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "OP")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from firstvisit where op = '" + mydata + "' and fop = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into firstvisit(op,fop) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                        } // End of lpnl and txt

                        if (rpnl.Checked == true && txt.Checked == true)
                        {
                            if (comboBox2.Text == "Sb")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where sb = '" + mydata + "' and fsb = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(sb,fsb) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "Ob")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where ob = '" + mydata + "' and fob = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(ob,fob) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "As")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where ass = '" + mydata + "' and fas = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(ass,fas) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "Pl")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where pl = '" + mydata + "' and fpl = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(pl,fpl) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "Px")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where px = '" + mydata + "' and fpx = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(px,fpx) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "IP")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where ip = '" + mydata + "' and fip = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(ip,fip) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "OP")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where op = '" + mydata + "' and fop = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(op,fop) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (comboBox2.Text == "Co")
                            {
                                if (mydata.Contains("Filter") == true)
                                {
                                    myfilter = mydata.Substring(9, mydata.Length - 9);
                                }
                                else
                                {
                                    sqlcmd.CommandText = "select count(*) from secondvisit where co = '" + mydata + "' and fco = '" + myfilter + "' ";
                                    if (sqlcmd.ExecuteScalar().ToString() == "0")
                                    {
                                        sqlcmd.CommandText = "insert into secondvisit(co,fco) values('" + mydata + "','" + myfilter + "') ";
                                        sqlcmd.ExecuteNonQuery();
                                    }
                                }
                            }


                        } // End of rpnl and txt

                        sqlconn.Close();
                    }
                    else
                        break;

                    try
                    {
                        query = query.Substring(myindex + 1, query.Length - myindex - 1);
                    }
                    catch
                    {
                        query = "";
                    }

                }

                comboBox2_SelectedIndexChanged(comboBox2, e);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Documents(*.txt)|*.txt";
            dlg.Title = "Export as Notepad...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                if (comboBox2.Text == "CC")
                {
                    sqlcmd.CommandText = "select distinct cc from  firstvisit where cc<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    int i = 0;
                    string[] s = new string[4000];

                    while (data.Read())
                    {
                        s[i] = data["cc"].ToString();
                        i++;
                    }
                    data.Close();

                    File.WriteAllLines(dlg.FileName, s);
                }
                if (other_r.Checked == true)
                {
                    if (comboBox2.Text == "Consultation - Favorite Sites")
                    {
                        sqlcmd.CommandText = "select distinct site from  consult where site<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["site"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Chemoprophylaxis")
                    {
                        sqlcmd.CommandText = "select distinct chem from  preventive where chem<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["chem"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Immunisation - Adults")
                    {
                        sqlcmd.CommandText = "select distinct imm_adult from  preventive where imm_adult<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["imm_adult"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Immunisation - Children")
                    {
                        sqlcmd.CommandText = "select distinct imm_child from  preventive where imm_child<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["imm_child"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Adults")
                    {
                        sqlcmd.CommandText = "select distinct phe_adult from  preventive where phe_adult<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["phe_adult"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Children")
                    {
                        sqlcmd.CommandText = "select distinct phe_child from  preventive where phe_child<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["phe_child"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Tel - Profession")
                    {
                        sqlcmd.CommandText = "select distinct profession from  preventive where profession<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["profession"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Adults - Note")
                    {
                        sqlcmd.CommandText = "select distinct phe_adult_note from  preventive where phe_adult_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["phe_adult_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Children - Note")
                    {
                        sqlcmd.CommandText = "select distinct phe_child_note from  preventive where phe_child_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["phe_child_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Counseling - Note")
                    {
                        sqlcmd.CommandText = "select distinct coun_note from  preventive where coun_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["coun_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Screening")
                    {
                        sqlcmd.CommandText = "select distinct screen from  preventive where screen<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["screen"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Screening - Note")
                    {
                        sqlcmd.CommandText = "select distinct screen_note from  preventive where screen_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["screen_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Immunisation - Adults - Note")
                    {
                        sqlcmd.CommandText = "select distinct imm_adult_note from  preventive where imm_adult_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["imm_adult_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Immunisation - Children - Note")
                    {
                        sqlcmd.CommandText = "select distinct imm_child_note from  preventive where imm_child_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["imm_child_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Preventive Care - Chemoprophylaxis - Note")
                    {
                        sqlcmd.CommandText = "select distinct chem_note from  preventive where chem_note<>'' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];

                        while (data.Read())
                        {
                            s[i] = data["chem_note"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }


                }

                if (rpnl.Checked == true && txt.Checked == true)
                {
                    if (comboBox2.Text == "Sb")
                    {
                        sqlcmd.CommandText = "select distinct sb from  secondvisit where sb<>'' and fsb = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["sb"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Ob")
                    {
                        sqlcmd.CommandText = "select distinct ob from  secondvisit where ob<>'' and fob = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["ob"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "As")
                    {
                        sqlcmd.CommandText = "select distinct ass from  secondvisit where ass<>'' and fas = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["ass"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Pl")
                    {
                        sqlcmd.CommandText = "select distinct pl from  secondvisit where pl<>'' and fpl = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["pl"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Px")
                    {
                        sqlcmd.CommandText = "select distinct px from  secondvisit where px<>'' and fpx = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["px"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "IP")
                    {
                        sqlcmd.CommandText = "select distinct ip from  secondvisit where ip<>'' and fip = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["ip"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "OP")
                    {
                        sqlcmd.CommandText = "select distinct op from  secondvisit where op<>'' and fop = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["op"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Co")
                    {
                        sqlcmd.CommandText = "select distinct co from  secondvisit where co<>'' and fco = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["co"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                } // End of Right Panel And txt

                if (lpnl.Checked == true && txt.Checked == true)
                {
                    if (comboBox2.Text == "PI")
                    {
                        sqlcmd.CommandText = "select distinct pi from  firstvisit where pi<>'' and fpi = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["pi"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "PH")
                    {
                        sqlcmd.CommandText = "select distinct ph from  firstvisit where ph<>'' and fph = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["ph"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "FH")
                    {
                        sqlcmd.CommandText = "select distinct fh from  firstvisit where fh<>'' and ffh = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["fh"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "PE")
                    {
                        sqlcmd.CommandText = "select distinct pe from  firstvisit where pe<>'' and fpe = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["pe"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "Px")
                    {
                        sqlcmd.CommandText = "select distinct px from  firstvisit where px<>'' and fpx = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["px"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "IP")
                    {
                        sqlcmd.CommandText = "select distinct ip from  firstvisit where ip<>'' and fip = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["ip"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                    if (comboBox2.Text == "OP")
                    {
                        sqlcmd.CommandText = "select distinct op from  firstvisit where op<>'' and fop = '" + filter_c.Text + "' ";
                        SqlDataReader data = sqlcmd.ExecuteReader();
                        int i = 0;
                        string[] s = new string[4000];
                        s[i] = "Filter : " + filter_c.Text;
                        i++;
                        while (data.Read())
                        {
                            s[i] = data["op"].ToString();
                            i++;
                        }
                        data.Close();

                        File.WriteAllLines(dlg.FileName, s);
                    }

                } // End of left panel and txt
                sqlconn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;

            string myfilter = filter_c.Text;

            if (comboBox2.Text == "CC")
            {
                sqlcmd.CommandText = "Update firstvisit set cc = null ";
                sqlcmd.ExecuteNonQuery();
            }
            else
            if (lpnl.Checked == true && txt.Checked == true)
            {
                if (comboBox2.Text == "PI")
                {
                    sqlcmd.CommandText = "Update firstvisit set pi = null where fpi= '"+ myfilter +"' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (comboBox2.Text == "PH")
                {
                    sqlcmd.CommandText = "Update firstvisit set ph = null where fph= '" + myfilter + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (comboBox2.Text == "FH")
                {
                    sqlcmd.CommandText = "Update firstvisit set fh = null where ffh= '" + myfilter + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (comboBox2.Text == "PE")
                {
                    sqlcmd.CommandText = "Update firstvisit set pe = null where fpe= '" + myfilter + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (comboBox2.Text == "Px")
                {
                    sqlcmd.CommandText = "Update firstvisit set px = null where fpx= '" + myfilter + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (comboBox2.Text == "IP")
                {
                    sqlcmd.CommandText = "Update firstvisit set ip = null where fip= '" + myfilter + "' ";
                    sqlcmd.ExecuteNonQuery();
                }

                if (comboBox2.Text == "OP")
                {
                    sqlcmd.CommandText = "Update firstvisit set op = null where fop= '" + myfilter + "' ";
                    sqlcmd.ExecuteNonQuery();
                }
            } // End OF Left Panel And txt

        if (rpnl.Checked == true && txt.Checked == true)
        {
            if (comboBox2.Text == "Sb")
            {
                sqlcmd.CommandText = "Update secondvisit set sb = null where fsb= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Ob")
            {
                sqlcmd.CommandText = "Update secondvisit set ob = null where fob= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "As")
            {
                sqlcmd.CommandText = "Update secondvisit set ass = null where fas= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Pl")
            {
                sqlcmd.CommandText = "Update secondvisit set pl = null where fpl= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Px")
            {
                sqlcmd.CommandText = "Update secondvisit set px = null where fpx= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "IP")
            {
                sqlcmd.CommandText = "Update secondvisit set ip = null where fip= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "OP")
            {
                sqlcmd.CommandText = "Update secondvisit set op = null where fop= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Co")
            {
                sqlcmd.CommandText = "Update secondvisit set co = null where fco= '" + myfilter + "' ";
                sqlcmd.ExecuteNonQuery();
            }
        } // End OF Left Panel And txt
        if (other_r.Checked == true)
        {
            if (comboBox2.Text == "Consultation - Favorite Sites")
            {
                sqlcmd.CommandText = "Update consult set site = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Chemoprophylaxis")
            {
                sqlcmd.CommandText = "Update preventive set chem = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Immunisation - Adults")
            {
                sqlcmd.CommandText = "Update preventive set imm_adult = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Immunisation - Children")
            {
                sqlcmd.CommandText = "Update preventive set imm_child = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Adults")
            {
                sqlcmd.CommandText = "Update preventive set phe_adult = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Children")
            {
                sqlcmd.CommandText = "Update preventive set phe_child = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Tel - Profession")
            {
                sqlcmd.CommandText = "Update tel set profession = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Adults - Note")
            {
                sqlcmd.CommandText = "Update preventive set phe_adult_note = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Periodic Health Exam. - Children - Note")
            {
                sqlcmd.CommandText = "Update preventive set phe_child_note = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Counseling - Note")
            {
                sqlcmd.CommandText = "Update preventive set coun_note = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Screening")
            {
                sqlcmd.CommandText = "Update preventive set screen = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Screening - Note")
            {
                sqlcmd.CommandText = "Update preventive set screen_note = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Immunisation - Adults - Note")
            {
                sqlcmd.CommandText = "Update preventive set imm_adult_note = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Immunisation - Children - Note")
            {
                sqlcmd.CommandText = "Update preventive set imm_child_note = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox2.Text == "Preventive Care - Chemoprophylaxis - Note")
            {
                sqlcmd.CommandText = "Update preventive set chem_note = null ";
                sqlcmd.ExecuteNonQuery();
            }
        }// End of Others






            comboBox2_SelectedIndexChanged(comboBox2, e);
            sqlconn.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for Text File...";
            dlg.Filter = "Text Documents(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int myindex;
                string query = File.ReadAllText(dlg.FileName);
                query = query.Replace("\r", "");
                string mydata;

                while (true)
                {
                    if (query.Contains("\n") == true)
                    {
                        myindex = query.IndexOf("\n");
                        mydata = query.Substring(0, myindex);

                        SqlConnection sqlconn = new SqlConnection(cm.cs);
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlconn;
                        if (comboBox1.Text == "نام اول")
                        {
                            sqlcmd.CommandText = "select count(*) from info where fname = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(fname) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "عنوان")
                        {
                            sqlcmd.CommandText = "select count(*) from info where title = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(title) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "نام مياني")
                        {
                            sqlcmd.CommandText = "select count(*) from info where mname = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(mname) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "نام آخر")
                        {
                            sqlcmd.CommandText = "select count(*) from info where lname = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(lname) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "شغل")
                        {
                            sqlcmd.CommandText = "select count(*) from info where job = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(job) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "محل تولد")
                        {
                            sqlcmd.CommandText = "select count(*) from info where bplace = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(bplace) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "نام پدر")
                        {
                            sqlcmd.CommandText = "select count(*) from info where father = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(father) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "شهر یا روستا")
                        {
                            sqlcmd.CommandText = "select count(*) from info where city = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(city) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }
                        if (comboBox1.Text == "محل صدور شناسنامه")
                        {
                            sqlcmd.CommandText = "select count(*) from info where sodor = '" + mydata + "' ";
                            if (sqlcmd.ExecuteScalar().ToString() == "0")
                            {
                                sqlcmd.CommandText = "insert into info(sodor) values('" + mydata + "') ";
                                sqlcmd.ExecuteNonQuery();
                            }
                            comboBox1_SelectedIndexChanged(comboBox1, e);
                        }

                        sqlconn.Close();
                    }
                    else
                        break;

                    try
                    {
                        query = query.Substring(myindex + 1, query.Length - myindex - 1);
                    }
                    catch
                    {
                        query = "";
                    }

                }

            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Documents(*.txt)|*.txt";
            dlg.Title = "Export as Notepad...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName, true);

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                if (comboBox1.Text == "عنوان")
                {
                    sqlcmd.CommandText = "select distinct title from  info where title<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["title"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "نام اول")
                {
                    sqlcmd.CommandText = "select distinct fname from  info where fname<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["fname"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    sqlcmd.CommandText = "select distinct mname from  info where mname<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["mname"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "نام آخر")
                {
                    sqlcmd.CommandText = "select distinct lname from  info where lname<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["lname"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "شغل")
                {
                    sqlcmd.CommandText = "select distinct job from  info where job<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["job"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "محل تولد")
                {
                    sqlcmd.CommandText = "select distinct bplace from  info where bplace<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["bplace"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "نوع بيمه")
                {
                    sqlcmd.CommandText = "select distinct bimeh from  info where bimeh<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["bimeh"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "نام پدر")
                {
                    sqlcmd.CommandText = "select distinct father from  info where father<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["father"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "شهر یا روستا")
                {
                    sqlcmd.CommandText = "select distinct city from  info where city<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["city"].ToString());
                    }
                    data.Close();
                }

                if (comboBox1.Text == "محل صدور شناسنامه")
                {
                    sqlcmd.CommandText = "select distinct sodor from  info where sodor<>'' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();

                    while (data.Read())
                    {
                        sw.WriteLine(data["sodor"].ToString());
                    }
                    data.Close();
                }


                sqlconn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;


            if (comboBox1.Text == "عنوان")
            {
                sqlcmd.CommandText = "Update info set title = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "نام اول")
            {
                sqlcmd.CommandText = "Update info set fname = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text.Contains("يان") == true)
            {
                sqlcmd.CommandText = "Update info set mname = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "نام آخر")
            {
                sqlcmd.CommandText = "Update info set lname = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "شغل")
            {
                sqlcmd.CommandText = "Update info set job = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "محل تولد")
            {
                sqlcmd.CommandText = "Update info set bplace = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "نوع بيمه")
            {
                sqlcmd.CommandText = "Update info set bimeh = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "نام پدر")
            {
                sqlcmd.CommandText = "Update info set father = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "شهر يا روستا")
            {
                sqlcmd.CommandText = "Update info set city = null ";
                sqlcmd.ExecuteNonQuery();
            }

            if (comboBox1.Text == "محل صدور شناسنامه")
            {
                sqlcmd.CommandText = "Update info set sodor = null ";
                sqlcmd.ExecuteNonQuery();
            }

         


            comboBox1_SelectedIndexChanged(comboBox1, e);
            sqlconn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Medical Literature.doc");
            }
            catch { }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Medical Literature.doc");
            }
            catch { }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.English();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            LanguageSelector.KeyboardLayout.Farsi();
        }
        /////// End of English  ///////
    }
}