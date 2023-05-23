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
    public partial class Bimeh_j : Form
    {
        public Bimeh_j()
        {
            InitializeComponent();
        }

        private void Bimeh_j_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "select distinct bimeh from info where bimeh<>'' ";
            SqlDataReader data = sqlcmd.ExecuteReader();
            string s;
            while (data.Read())
            {
                s = data["bimeh"].ToString();
                bimeh_t.AutoCompleteCustomSource.Add(s);
                bimeh2_t.AutoCompleteCustomSource.Add(s);
                bimeh3_t.AutoCompleteCustomSource.Add(s);
                bimeh4_t.AutoCompleteCustomSource.Add(s);
            }
            data.Close();
            
            sqlconn.Close();
            bimeh_t.Text = all_info.bimeh;
            bimeh2_t.Text = all_info.bimeh2;
            bimeh3_t.Text = all_info.bimeh3;
            bimeh4_t.Text = all_info.bimeh4;

            bimehno_t.Text = all_info.bimehno;
            bimehno2_t.Text = all_info.bimehno2;
            bimehno3_t.Text = all_info.bimehno3;
            bimehno4_t.Text = all_info.bimehno4;

            serial_t.Text = all_info.serial;
            serial2_t.Text = all_info.serial2;
            serial3_t.Text = all_info.serial3;
            serial4_t.Text = all_info.serial4;

            expire_t.Text = all_info.expire;
            expire2_t.Text = all_info.expire2;
            expire3_t.Text = all_info.expire3;
            expire4_t.Text = all_info.expire4;

        }

        private void Bimeh_j_FormClosing(object sender, FormClosingEventArgs e)
        {
            all_info.bimeh = bimeh_t.Text;
            all_info.bimehno = bimehno_t.Text;
            all_info.serial = serial_t.Text;
            all_info.expire = expire_t.Text;

            all_info.bimeh2 = bimeh2_t.Text;
            all_info.bimehno2 = bimehno2_t.Text;
            all_info.serial2 = serial2_t.Text;
            all_info.expire2 = expire2_t.Text;

            all_info.bimeh3 = bimeh3_t.Text;
            all_info.bimehno3 = bimehno3_t.Text;
            all_info.serial3 = serial3_t.Text;
            all_info.expire3 = expire3_t.Text;

            all_info.bimeh4 = bimeh4_t.Text;
            all_info.bimehno4 = bimehno4_t.Text;
            all_info.serial4 = serial4_t.Text;
            all_info.expire4 = expire4_t.Text;
        }
    }
}