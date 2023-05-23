using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Management;


namespace Clinical_Management
{
    public partial class login : Form
    {
        public static string log_username, log_pass,log_name,log_family,log_prf;
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

            ////////////////////////////////
            if (File.Exists(Application.StartupPath + "\\userenv.cmm") == false)
            {
                MessageBox.Show("Missing Some Files, Please Reinstall Clinical Management", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            ///////////////////////////////////////
            // SQl Test
            try
            {
                SqlConnection Sqlconn1 = new SqlConnection("Data Source=(local)\\cm_express;Integrated Security=True");
                Sqlconn1.Open();
                Sqlconn1.Close();
            }
            catch
            {
                MessageBox.Show("Please first Install 'Microsoft SQL Server 2005 Express Edition'. ");
                this.Close();
            }

            // Copy DB
            if (File.Exists(Application.StartupPath + "\\Temporary\\cm_Data.mdf") == true && File.Exists(Application.StartupPath + "\\DB\\cm_Data.mdf") == false)
            {
                try
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\DB");
                    File.Copy(Application.StartupPath + "\\Temporary\\cm_Data.mdf", Application.StartupPath + "\\DB\\cm_Data.mdf");
                    File.Copy(Application.StartupPath + "\\Temporary\\cm_data_log.ldf", Application.StartupPath + "\\DB\\cm_data_log.ldf");
                }
                catch { }
            }

            // DB Test
            try
            {
                SqlConnection Sqlconn2 = new SqlConnection("Data Source=(local)\\cm_express;Integrated Security=True");
                Sqlconn2.Open();
                SqlCommand sqlcmd2 = new SqlCommand();
                sqlcmd2.Connection = Sqlconn2;

                try
                {
                    sqlcmd2.CommandText = "EXEC sp_attach_db @dbname = N'cm', @filename1 = N'" + Application.StartupPath + "\\DB\\cm_data.mdf" + " ', @filename2 = N'" + Application.StartupPath + "\\DB\\cm_data_log.ldf" + " ' ";
                    sqlcmd2.ExecuteNonQuery();
                }
                catch { }

                try
                {
                    sqlcmd2.CommandText = @"sp_addlogin";
                    sqlcmd2.Parameters.Add(new SqlParameter("@loginame", SqlDbType.NChar));
                    sqlcmd2.Parameters["@loginame"].Value = "cm_usr";
                    sqlcmd2.Parameters.Add(new SqlParameter("@passwd", SqlDbType.NChar));
                    sqlcmd2.Parameters["@passwd"].Value = "123456";

                    sqlcmd2.Parameters.Add(new SqlParameter("@defdb", SqlDbType.NChar));
                    sqlcmd2.Parameters["@defdb"].Value = "cm";
                    sqlcmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd2.ExecuteNonQuery();
                }
                catch { }

                Sqlconn2.Close();

                Sqlconn2.ConnectionString = "Data Source=(local)\\cm_express;Initial Catalog = cm;Integrated Security=True";
                Sqlconn2.Open();
             
                sqlcmd2.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd2.Parameters.Clear();

                try
                {
                    sqlcmd2.CommandText = @"sp_grantdbaccess";
                    sqlcmd2.Parameters.Add(new SqlParameter("@loginame", SqlDbType.NChar));
                    sqlcmd2.Parameters["@loginame"].Value = "cm_usr";
                    sqlcmd2.Parameters.Add(new SqlParameter("@name_in_db", SqlDbType.NChar));
                    sqlcmd2.Parameters["@name_in_db"].Value = "cm_usr";
                    sqlcmd2.ExecuteNonQuery();
                }
                catch { }

                sqlcmd2.Parameters.Clear();

                try
                {
                    sqlcmd2.CommandText = "myrole";
                    sqlcmd2.CommandType = CommandType.StoredProcedure;
                    sqlcmd2.ExecuteNonQuery();
                }
                catch { }

                Sqlconn2.Close();

            }
            catch//(Exception ex)
            {
            //   MessageBox.Show(ex.Message);
                //this.Close();
            }
            //////////////////////////////////////////////////

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from WIN32_DiskDrive");

            bool ff = false;
            try
            {
                foreach (ManagementObject share in searcher.Get())
                {
                    if (ff == true)
                        break;
                    foreach (PropertyData PC in share.Properties)
                    {
                        if (PC.Value != null && PC.Value.ToString() != "" && PC.Name.ToString() == "Signature")
                        {
                            Register.first_id = PC.Value.ToString();
                            while (Register.first_id.Length < 10)
                                Register.first_id = Register.first_id + "1";
                            ff = true;
                            break;
                        }
                    }
                }
            }
            catch //(Exception exp)
            {
                //MessageBox.Show(exp.Message);
                Register.first_id = "1978625413";
            }

            Int64 n;

            try
            {
                n = Int64.Parse(Register.first_id) * 13;
            }
            catch
            {
                Register.first_id = "1978625413";
                n = Int64.Parse(Register.first_id) * 13;
            }
            string s = n.ToString().Substring(0, 10);
            string ss = "";
            for (int i = 0; i < 10; i++)
            {
                switch (s[i])
                {
                    case '0':
                        {
                            if (i == 0)
                                ss = ss + "ZX4";
                            else
                                ss = ss + "Y";

                            break;
                        }
                    case '1':
                        {
                            if (i == 0)
                                ss = ss + "ZX9";
                            else
                                ss = ss + "2";

                            break;
                        }
                    case '2':
                        {
                            if (i == 0)
                                ss = ss + "ZX7";
                            else
                                ss = ss + "D";

                            break;
                        }
                    case '3':
                        {
                            if (i == 0)
                                ss = ss + "ZX3";
                            else
                                ss = ss + "1";

                            break;
                        }
                    case '4':
                        {
                            if (i == 0)
                                ss = ss + "ZX8";
                            else
                                ss = ss + "Q";

                            break;
                        }
                    case '5':
                        {
                            if (i == 0)
                                ss = ss + "ZX2";
                            else
                                ss = ss + "Z";

                            break;
                        }
                    case '6':
                        {
                            if (i == 0)
                                ss = ss + "ZX6";
                            else
                                ss = ss + "X";

                            break;
                        }
                    case '7':
                        {
                            if (i == 0)
                                ss = ss + "ZX5";
                            else
                                ss = ss + "F";

                            break;
                        }
                    case '8':
                        {
                            if (i == 0)
                                ss = ss + "ZX0";
                            else
                                ss = ss + "W";

                            break;
                        }
                    case '9':
                        {
                            if (i == 0)
                                ss = ss + "ZX1";
                            else
                                ss = ss + "T";

                            break;
                        }

                }
            }


            string query = File.ReadAllText(Application.StartupPath + "\\userenv.cmm");
            //MessageBox.Show(ss);

            // Remove comments for registering ***************
            //if (query.Substring(query.LastIndexOf("|||"), 15) != "|||" + ss)
            //{
            //    if (query.Contains("|||000000000000") == false)
            //    {
            //        MessageBox.Show("Missing Some Files, Please Reinstall Clinical Management", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        this.Close();
            //        return;
            //    }
            //    Register.second_id = ss;
                // Remove comments for registering ***************
                //Register frm = new Register();
                //frm.ShowDialog();
                //if (Register.close != 0)  
                //{
                //    this.Close();
                //}
              
            //}
          // Remove comments for registering ***************
            ////////////////////////////////


            if (File.Exists(Application.StartupPath + "\\info.ini") == true)
            {
                try
                {
                    string defaultpass = "";
                    string defaultuser = File.ReadAllText(Application.StartupPath + "\\info.ini");
                    defaultuser = cm.MyDecoding(defaultuser).Replace("\0", "");
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    SqlDataReader data;
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "select pass from doctor where username ='" + defaultuser + "' ";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        defaultpass = cm.MyDecoding(data["pass"].ToString()).Replace("\0", "");
                    }
                    data.Close();

                    sqlconn.Close();

                    if (defaultpass != "")
                    {
                        username_t.Text = defaultuser;
                        pass_t.Text = defaultpass;
                        login_ch.Checked = true;
                    }
                }
                catch { }
            }
            username_t.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + "\\info.ini");
            }
            catch { }

            string mypass = cm.MyEncoding(pass_t.Text);

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select count(*) from doctor where username ='"+ username_t.Text +"' and pass = '"+ mypass +"' ";
            if (sqlcmd.ExecuteScalar().ToString() == "0")
            {
                MessageBox.Show("Invalid username or password", "Notification");
            }
            else
            {
                if (login_ch.Checked == true)
                {
                    try
                    {
                        File.WriteAllText(Application.StartupPath + "\\info.ini", cm.MyEncoding(username_t.Text));
                    }
                    catch { }
                }

                sqlcmd.CommandText = "select * from doctor where username ='" + username_t.Text + "' and pass = '" + mypass + "' ";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    log_username = data["username"].ToString();
                    log_pass = cm.MyDecoding(data["pass"].ToString());
                    log_name = data["name"].ToString();
                    log_family = data["family"].ToString();
                    log_prf = data["prf"].ToString();
                }

                data.Close();

                this.Visible = false;


                SW1 frm = new SW1();
                frm.ShowDialog();

                //SW3 frm = new SW3();
                //frm.ShowDialog();

                this.Close();
            }
            sqlconn.Close();
        }

        private void pass_t_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    File.Delete(Application.StartupPath + "\\info.ini");
                }
                catch { }

                string mypass = cm.MyEncoding(pass_t.Text);

                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select count(*) from doctor where username ='" + username_t.Text + "' and pass = '" + mypass + "' ";
                if (sqlcmd.ExecuteScalar().ToString() == "0")
                {
                    MessageBox.Show("Invalid username or password", "Notification");
                }
                else
                {
                    if (login_ch.Checked == true)
                    {
                        try
                        {
                            File.WriteAllText(Application.StartupPath + "\\info.ini", cm.MyEncoding(username_t.Text));
                        }
                        catch { }
                    }

                    sqlcmd.CommandText = "select * from doctor where username ='" + username_t.Text + "' and pass = '" + mypass + "' ";
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        log_username = data["username"].ToString();
                        log_pass = cm.MyDecoding(data["pass"].ToString());
                        log_name = data["name"].ToString();
                        log_family = data["family"].ToString();
                        log_prf = data["prf"].ToString();
                    }

                    data.Close();

                    this.Visible = false;


                    SW1 frm = new SW1();
                    frm.ShowDialog();

                    //SW3 frm = new SW3();
                    //frm.ShowDialog();

                    this.Close();
                }
                sqlconn.Close();
            }
        }
    }
}