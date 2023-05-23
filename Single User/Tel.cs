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
    public partial class Tel : Form
    {
        public static object[] tel_row = new object[55];
        public static bool tel_flag = false;
        public static bool tel_flag_search = false;
        public static bool tel_edit_flag = false;
        public static string tel_query;

        public Tel()
        {
            InitializeComponent();
        }

        private void Tel_Load(object sender, EventArgs e)
        {
            //for (int ii = 0; ii < 54; ii++)
            //    dataGridView2.Columns[ii].Visible = true;

            LanguageSelector.KeyboardLayout.Farsi();
            tel_flag_search = false;
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

            sqlcmd.CommandText = "select * from grid_size where form='" + this.Name + "' ";
            data = sqlcmd.ExecuteReader();

            while (data.Read())
            {
                for (int i = 0; i < 14; i++)
                    dataGridView2.Columns[i].Width = Int32.Parse(data[i + 1].ToString());//"'"+s+"'"
            }
            data.Close();

            sqlcmd.CommandText = "select * from tel";
            data = sqlcmd.ExecuteReader();
            while (data.Read())
            {
                tel_row[0] = "";
                tel_row[1] = data["place"].ToString();
                tel_row[2] = data["title"].ToString();
                tel_row[3] = data["fname"].ToString();
                tel_row[4] = data["family"].ToString();
                tel_row[5] = data["profession"].ToString();
                tel_row[6] = data["job"].ToString();
                tel_row[7] = data["tel1"].ToString();
                tel_row[8] = data["desc1"].ToString();
                tel_row[9] = data["city"].ToString();
                tel_row[10] = data["adr1"].ToString();
                tel_row[11] = data["zip"].ToString();
                tel_row[12] = data["email1"].ToString();
                tel_row[13] = data["edr1"].ToString();

                tel_row[14] = data["email2"].ToString();
                tel_row[15] = data["email3"].ToString();
                tel_row[16] = data["email4"].ToString();
                tel_row[17] = data["email5"].ToString();
                tel_row[18] = data["email6"].ToString();
                tel_row[19] = data["email7"].ToString();
                tel_row[20] = data["email8"].ToString();
                tel_row[21] = data["email9"].ToString();
                tel_row[22] = data["email10"].ToString();

                tel_row[23] = data["edr2"].ToString();
                tel_row[24] = data["edr3"].ToString();
                tel_row[25] = data["edr4"].ToString();
                tel_row[26] = data["edr5"].ToString();
                tel_row[27] = data["edr6"].ToString();
                tel_row[28] = data["edr7"].ToString();
                tel_row[29] = data["edr8"].ToString();
                tel_row[30] = data["edr9"].ToString();
                tel_row[31] = data["edr10"].ToString();

                tel_row[32] = data["adr2"].ToString();
                tel_row[33] = data["adr3"].ToString();
                tel_row[34] = data["adr4"].ToString();
                tel_row[35] = data["adr5"].ToString();

                tel_row[36] = data["tel2"].ToString();
                tel_row[37] = data["tel3"].ToString();
                tel_row[38] = data["tel4"].ToString();
                tel_row[39] = data["tel5"].ToString();
                tel_row[40] = data["tel6"].ToString();
                tel_row[41] = data["tel7"].ToString();
                tel_row[42] = data["tel8"].ToString();
                tel_row[43] = data["tel9"].ToString();
                tel_row[44] = data["tel10"].ToString();

                tel_row[45] = data["desc2"].ToString();
                tel_row[46] = data["desc3"].ToString();
                tel_row[47] = data["desc4"].ToString();
                tel_row[48] = data["desc5"].ToString();
                tel_row[49] = data["desc6"].ToString();
                tel_row[50] = data["desc7"].ToString();
                tel_row[51] = data["desc8"].ToString();
                tel_row[52] = data["desc9"].ToString();
                tel_row[53] = data["desc10"].ToString();
               
              
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count-1, tel_row);
            }
            data.Close();

            sqlconn.Close();
        }

        private void Tel_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] my_str = new string[55];

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlConnection sqlconn2 = new SqlConnection(cm.cs);
            sqlconn2.Open();
            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.Connection = sqlconn2;

            SqlCommand sqlcmd = new SqlCommand("delete grid_size where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into grid_size(form,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14) values('" + this.Name + "','" + dataGridView2.Columns[0].Width + "','" + dataGridView2.Columns[1].Width + "','" + dataGridView2.Columns[2].Width + "','" + dataGridView2.Columns[3].Width + "','" + dataGridView2.Columns[4].Width + "','" + dataGridView2.Columns[5].Width + "','" + dataGridView2.Columns[6].Width + "','" + dataGridView2.Columns[7].Width + "','" + dataGridView2.Columns[8].Width + "','" + dataGridView2.Columns[9].Width + "','" + dataGridView2.Columns[10].Width + "','" + dataGridView2.Columns[11].Width + "','" + dataGridView2.Columns[12].Width + "','" + dataGridView2.Columns[13].Width + "')";
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Delete from tel_temp2";
            sqlcmd.ExecuteNonQuery();

            if (tel_flag_search == false)
            {
                sqlcmd.CommandText = "select * from tel";
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                {
                    my_str[1] = data["place"].ToString();
                    my_str[2] = data["title"].ToString();
                    my_str[3] = data["fname"].ToString();
                    my_str[4] = data["family"].ToString();
                    my_str[5] = data["profession"].ToString();
                    my_str[6] = data["job"].ToString();
                    my_str[7] = data["tel1"].ToString();
                    my_str[8] = data["desc1"].ToString();
                    my_str[9] = data["city"].ToString();
                    my_str[10] = data["adr1"].ToString();
                    my_str[11] = data["zip"].ToString();
                    my_str[12] = data["email1"].ToString();
                    my_str[13] = data["edr1"].ToString();

                    my_str[14] = data["email2"].ToString();
                    my_str[15] = data["email3"].ToString();
                    my_str[16] = data["email4"].ToString();
                    my_str[17] = data["email5"].ToString();
                    my_str[18] = data["email6"].ToString();
                    my_str[19] = data["email7"].ToString();
                    my_str[20] = data["email8"].ToString();
                    my_str[21] = data["email9"].ToString();
                    my_str[22] = data["email10"].ToString();

                    my_str[23] = data["edr2"].ToString();
                    my_str[24] = data["edr3"].ToString();
                    my_str[25] = data["edr4"].ToString();
                    my_str[26] = data["edr5"].ToString();
                    my_str[27] = data["edr6"].ToString();
                    my_str[28] = data["edr7"].ToString();
                    my_str[29] = data["edr8"].ToString();
                    my_str[30] = data["edr9"].ToString();
                    my_str[31] = data["edr10"].ToString();

                    my_str[32] = data["adr2"].ToString();
                    my_str[33] = data["adr3"].ToString();
                    my_str[34] = data["adr4"].ToString();
                    my_str[35] = data["adr5"].ToString();

                    my_str[36] = data["tel2"].ToString();
                    my_str[37] = data["tel3"].ToString();
                    my_str[38] = data["tel4"].ToString();
                    my_str[39] = data["tel5"].ToString();
                    my_str[40] = data["tel6"].ToString();
                    my_str[41] = data["tel7"].ToString();
                    my_str[42] = data["tel8"].ToString();
                    my_str[43] = data["tel9"].ToString();
                    my_str[44] = data["tel10"].ToString();

                    my_str[45] = data["desc2"].ToString();
                    my_str[46] = data["desc3"].ToString();
                    my_str[47] = data["desc4"].ToString();
                    my_str[48] = data["desc5"].ToString();
                    my_str[49] = data["desc6"].ToString();
                    my_str[50] = data["desc7"].ToString();
                    my_str[51] = data["desc8"].ToString();
                    my_str[52] = data["desc9"].ToString();
                    my_str[53] = data["desc10"].ToString();

                    sqlcmd2.CommandText = "Insert into tel_temp2(place,title,fname,family,profession,job,tel1,desc1,city,adr1,zip,email1,edr1,email2,email3,email4,email5,email6,email7,email8,email9,email10,edr2,edr3,edr4,edr5,edr6,edr7,edr8,edr9,edr10,adr2,adr3,adr4,adr5,tel2,tel3,tel4,tel5,tel6,tel7,tel8,tel9,tel10,desc2,desc3,desc4,desc5,desc6,desc7,desc8,desc9,desc10) values('" + my_str[1] + "','" + my_str[2] + "','" + my_str[3] + "','" + my_str[4] + "','" + my_str[5] + "','" + my_str[6] + "','" + my_str[7] + "','" + my_str[8] + "','" + my_str[9] + "','" + my_str[10] + "','" + my_str[11] + "','" + my_str[12] + "','" + my_str[13] + "','" + my_str[14] + "','" + my_str[15] + "','" + my_str[16] + "','" + my_str[17] + "','" + my_str[18] + "','" + my_str[19] + "','" + my_str[20] + "','" + my_str[21] + "','" + my_str[22] + "','" + my_str[23] + "','" + my_str[24] + "','" + my_str[25] + "','" + my_str[26] + "','" + my_str[27] + "','" + my_str[28] + "','" + my_str[29] + "','" + my_str[30] + "','" + my_str[31] + "','" + my_str[32] + "','" + my_str[33] + "','" + my_str[34] + "','" + my_str[35] + "','" + my_str[36] + "','" + my_str[37] + "','" + my_str[38] + "','" + my_str[39] + "','" + my_str[40] + "','" + my_str[41] + "','" + my_str[42] + "','" + my_str[43] + "','" + my_str[44] + "','" + my_str[45] + "','" + my_str[46] + "','" + my_str[47] + "','" + my_str[48] + "','" + my_str[49] + "','" + my_str[50] + "','" + my_str[51] + "','" + my_str[52] + "','" + my_str[53] + "') ";
                    sqlcmd2.ExecuteNonQuery();
                }
                data.Close();

                sqlcmd.CommandText = "Delete from tel";
                sqlcmd.ExecuteNonQuery();

                try
                {
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        sqlcmd.CommandText = "insert into tel(place,title,fname,family,profession,job,tel1,desc1,city,adr1,zip,email1,edr1,email2,email3,email4,email5,email6,email7,email8,email9,email10,edr2,edr3,edr4,edr5,edr6,edr7,edr8,edr9,edr10,adr2,adr3,adr4,adr5,tel2,tel3,tel4,tel5,tel6,tel7,tel8,tel9,tel10,desc2,desc3,desc4,desc5,desc6,desc7,desc8,desc9,desc10) values('" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[22].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[23].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[24].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[25].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[26].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[27].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[28].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[29].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[30].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[31].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[32].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[33].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[34].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[35].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[36].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[37].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[38].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[39].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[40].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[41].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[42].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[43].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[44].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[45].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[46].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[47].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[48].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[49].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[50].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[51].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[52].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[53].Value.ToString() + "') ";
                        sqlcmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    sqlcmd.CommandText = "Delete from tel";
                    sqlcmd.ExecuteNonQuery();

                    sqlcmd.CommandText = "select * from tel_temp2";
                    data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        my_str[1] = data["place"].ToString();
                        my_str[2] = data["title"].ToString();
                        my_str[3] = data["fname"].ToString();
                        my_str[4] = data["family"].ToString();
                        my_str[5] = data["profession"].ToString();
                        my_str[6] = data["job"].ToString();
                        my_str[7] = data["tel1"].ToString();
                        my_str[8] = data["desc1"].ToString();
                        my_str[9] = data["city"].ToString();
                        my_str[10] = data["adr1"].ToString();
                        my_str[11] = data["zip"].ToString();
                        my_str[12] = data["email1"].ToString();
                        my_str[13] = data["edr1"].ToString();

                        my_str[14] = data["email2"].ToString();
                        my_str[15] = data["email3"].ToString();
                        my_str[16] = data["email4"].ToString();
                        my_str[17] = data["email5"].ToString();
                        my_str[18] = data["email6"].ToString();
                        my_str[19] = data["email7"].ToString();
                        my_str[20] = data["email8"].ToString();
                        my_str[21] = data["email9"].ToString();
                        my_str[22] = data["email10"].ToString();

                        my_str[23] = data["edr2"].ToString();
                        my_str[24] = data["edr3"].ToString();
                        my_str[25] = data["edr4"].ToString();
                        my_str[26] = data["edr5"].ToString();
                        my_str[27] = data["edr6"].ToString();
                        my_str[28] = data["edr7"].ToString();
                        my_str[29] = data["edr8"].ToString();
                        my_str[30] = data["edr9"].ToString();
                        my_str[31] = data["edr10"].ToString();

                        my_str[32] = data["adr2"].ToString();
                        my_str[33] = data["adr3"].ToString();
                        my_str[34] = data["adr4"].ToString();
                        my_str[35] = data["adr5"].ToString();

                        my_str[36] = data["tel2"].ToString();
                        my_str[37] = data["tel3"].ToString();
                        my_str[38] = data["tel4"].ToString();
                        my_str[39] = data["tel5"].ToString();
                        my_str[40] = data["tel6"].ToString();
                        my_str[41] = data["tel7"].ToString();
                        my_str[42] = data["tel8"].ToString();
                        my_str[43] = data["tel9"].ToString();
                        my_str[44] = data["tel10"].ToString();

                        my_str[45] = data["desc2"].ToString();
                        my_str[46] = data["desc3"].ToString();
                        my_str[47] = data["desc4"].ToString();
                        my_str[48] = data["desc5"].ToString();
                        my_str[49] = data["desc6"].ToString();
                        my_str[50] = data["desc7"].ToString();
                        my_str[51] = data["desc8"].ToString();
                        my_str[52] = data["desc9"].ToString();
                        my_str[53] = data["desc10"].ToString();

                        sqlcmd2.CommandText = "Insert into tel(place,title,fname,family,profession,job,tel1,desc1,city,adr1,zip,email1,edr1,email2,email3,email4,email5,email6,email7,email8,email9,email10,edr2,edr3,edr4,edr5,edr6,edr7,edr8,edr9,edr10,adr2,adr3,adr4,adr5,tel2,tel3,tel4,tel5,tel6,tel7,tel8,tel9,tel10,desc2,desc3,desc4,desc5,desc6,desc7,desc8,desc9,desc10) values('" + my_str[1] + "','" + my_str[2] + "','" + my_str[3] + "','" + my_str[4] + "','" + my_str[5] + "','" + my_str[6] + "','" + my_str[7] + "','" + my_str[8] + "','" + my_str[9] + "','" + my_str[10] + "','" + my_str[11] + "','" + my_str[12] + "','" + my_str[13] + "','" + my_str[14] + "','" + my_str[15] + "','" + my_str[16] + "','" + my_str[17] + "','" + my_str[18] + "','" + my_str[19] + "','" + my_str[20] + "','" + my_str[21] + "','" + my_str[22] + "','" + my_str[23] + "','" + my_str[24] + "','" + my_str[25] + "','" + my_str[26] + "','" + my_str[27] + "','" + my_str[28] + "','" + my_str[29] + "','" + my_str[30] + "','" + my_str[31] + "','" + my_str[32] + "','" + my_str[33] + "','" + my_str[34] + "','" + my_str[35] + "','" + my_str[36] + "','" + my_str[37] + "','" + my_str[38] + "','" + my_str[39] + "','" + my_str[40] + "','" + my_str[41] + "','" + my_str[42] + "','" + my_str[43] + "','" + my_str[44] + "','" + my_str[45] + "','" + my_str[46] + "','" + my_str[47] + "','" + my_str[48] + "','" + my_str[49] + "','" + my_str[50] + "','" + my_str[51] + "','" + my_str[52] + "','" + my_str[53] + "') ";
                        sqlcmd2.ExecuteNonQuery();
                    }
                    data.Close();

                }
            }

            sqlconn.Close();
        }

        private void Tel_ResizeEnd(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("delete temp where form = '" + this.Name + "' ", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = "Insert into temp(form,width,height,ftop,fleft) values('" + this.Name + "','" + this.Width + "','" + this.Height + "','" + this.Top + "','" + this.Left + "')";
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count-1)
            {
                tel_row[0] = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                tel_row[1] = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                tel_row[2] = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                tel_row[3] = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                tel_row[4] = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                tel_row[5] = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                tel_row[6] = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                tel_row[7] = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                tel_row[8] = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                tel_row[9] = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                
                tel_row[10] = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                tel_row[11] = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
                tel_row[12] = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                tel_row[13] = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
                tel_row[14] = dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString();
                tel_row[15] = dataGridView2.Rows[e.RowIndex].Cells[16].Value.ToString();
                tel_row[16] = dataGridView2.Rows[e.RowIndex].Cells[17].Value.ToString();
                tel_row[17] = dataGridView2.Rows[e.RowIndex].Cells[18].Value.ToString();
                tel_row[18] = dataGridView2.Rows[e.RowIndex].Cells[19].Value.ToString();

                tel_row[19] = dataGridView2.Rows[e.RowIndex].Cells[20].Value.ToString();
                tel_row[20] = dataGridView2.Rows[e.RowIndex].Cells[21].Value.ToString();
                tel_row[21] = dataGridView2.Rows[e.RowIndex].Cells[22].Value.ToString();
                tel_row[22] = dataGridView2.Rows[e.RowIndex].Cells[23].Value.ToString();
                tel_row[23] = dataGridView2.Rows[e.RowIndex].Cells[24].Value.ToString();
                tel_row[24] = dataGridView2.Rows[e.RowIndex].Cells[25].Value.ToString();
                tel_row[25] = dataGridView2.Rows[e.RowIndex].Cells[26].Value.ToString();
                tel_row[26] = dataGridView2.Rows[e.RowIndex].Cells[27].Value.ToString();
                tel_row[27] = dataGridView2.Rows[e.RowIndex].Cells[28].Value.ToString();

                tel_row[28] = dataGridView2.Rows[e.RowIndex].Cells[29].Value.ToString();
                tel_row[29] = dataGridView2.Rows[e.RowIndex].Cells[30].Value.ToString();
                tel_row[30] = dataGridView2.Rows[e.RowIndex].Cells[31].Value.ToString();
                tel_row[31] = dataGridView2.Rows[e.RowIndex].Cells[32].Value.ToString();
                tel_row[32] = dataGridView2.Rows[e.RowIndex].Cells[33].Value.ToString();
                tel_row[33] = dataGridView2.Rows[e.RowIndex].Cells[34].Value.ToString();
                tel_row[34] = dataGridView2.Rows[e.RowIndex].Cells[35].Value.ToString();
                tel_row[35] = dataGridView2.Rows[e.RowIndex].Cells[36].Value.ToString();
                tel_row[36] = dataGridView2.Rows[e.RowIndex].Cells[37].Value.ToString();

                tel_row[37] = dataGridView2.Rows[e.RowIndex].Cells[38].Value.ToString();
                tel_row[38] = dataGridView2.Rows[e.RowIndex].Cells[39].Value.ToString();
                tel_row[39] = dataGridView2.Rows[e.RowIndex].Cells[40].Value.ToString();
                tel_row[40] = dataGridView2.Rows[e.RowIndex].Cells[41].Value.ToString();
                tel_row[41] = dataGridView2.Rows[e.RowIndex].Cells[42].Value.ToString();
                tel_row[42] = dataGridView2.Rows[e.RowIndex].Cells[43].Value.ToString();
                tel_row[43] = dataGridView2.Rows[e.RowIndex].Cells[44].Value.ToString();
                tel_row[44] = dataGridView2.Rows[e.RowIndex].Cells[45].Value.ToString();
                tel_row[45] = dataGridView2.Rows[e.RowIndex].Cells[46].Value.ToString();

                tel_row[46] = dataGridView2.Rows[e.RowIndex].Cells[47].Value.ToString();
                tel_row[47] = dataGridView2.Rows[e.RowIndex].Cells[48].Value.ToString();
                tel_row[48] = dataGridView2.Rows[e.RowIndex].Cells[49].Value.ToString();
                tel_row[49] = dataGridView2.Rows[e.RowIndex].Cells[50].Value.ToString();
                tel_row[50] = dataGridView2.Rows[e.RowIndex].Cells[51].Value.ToString();
                tel_row[51] = dataGridView2.Rows[e.RowIndex].Cells[52].Value.ToString();
                tel_row[52] = dataGridView2.Rows[e.RowIndex].Cells[53].Value.ToString();
                //tel_row[44] = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                //tel_row[45] = dataGridView2.Rows[e.RowIndex].Cells[46].Value.ToString();


                Tel2 frm = new Tel2();
                frm.ShowDialog();

                if (tel_edit_flag == true)
                {
                    tel_edit_flag = false;
                    for (i = 1; i <= 53; i++)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[i].Value = tel_row[i].ToString();
                    }
                }
                else
                if (tel_flag_search == true)
                {
                    
                    dataGridView2.Rows.Clear();
                    
                    SqlConnection sqlconn = new SqlConnection(cm.cs);
                    sqlconn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = tel_query;
                    SqlDataReader data = sqlcmd.ExecuteReader();
                    while (data.Read())
                    {
                        tel_row[0] = "";
                        tel_row[1] = data["place"].ToString();
                        tel_row[2] = data["title"].ToString();
                        tel_row[3] = data["fname"].ToString();
                        tel_row[4] = data["family"].ToString();
                        tel_row[5] = data["profession"].ToString();
                        tel_row[6] = data["job"].ToString();
                        tel_row[7] = data["tel1"].ToString();
                        tel_row[8] = data["desc1"].ToString();
                        tel_row[9] = data["city"].ToString();
                        tel_row[10] = data["adr1"].ToString();
                        tel_row[11] = data["zip"].ToString();
                        tel_row[12] = data["email1"].ToString();
                        tel_row[13] = data["edr1"].ToString();

                        tel_row[14] = data["email2"].ToString();
                        tel_row[15] = data["email3"].ToString();
                        tel_row[16] = data["email4"].ToString();
                        tel_row[17] = data["email5"].ToString();
                        tel_row[18] = data["email6"].ToString();
                        tel_row[19] = data["email7"].ToString();
                        tel_row[20] = data["email8"].ToString();
                        tel_row[21] = data["email9"].ToString();
                        tel_row[22] = data["email10"].ToString();

                        tel_row[23] = data["edr2"].ToString();
                        tel_row[24] = data["edr3"].ToString();
                        tel_row[25] = data["edr4"].ToString();
                        tel_row[26] = data["edr5"].ToString();
                        tel_row[27] = data["edr6"].ToString();
                        tel_row[28] = data["edr7"].ToString();
                        tel_row[29] = data["edr8"].ToString();
                        tel_row[30] = data["edr9"].ToString();
                        tel_row[31] = data["edr10"].ToString();

                        tel_row[32] = data["adr2"].ToString();
                        tel_row[33] = data["adr3"].ToString();
                        tel_row[34] = data["adr4"].ToString();
                        tel_row[35] = data["adr5"].ToString();

                        tel_row[36] = data["email2"].ToString();
                        tel_row[37] = data["email3"].ToString();
                        tel_row[38] = data["email4"].ToString();
                        tel_row[39] = data["email5"].ToString();
                        tel_row[40] = data["email6"].ToString();
                        tel_row[41] = data["email7"].ToString();
                        tel_row[42] = data["email8"].ToString();
                        tel_row[43] = data["email9"].ToString();
                        tel_row[44] = data["email10"].ToString();

                        tel_row[45] = data["edr2"].ToString();
                        tel_row[46] = data["edr3"].ToString();
                        tel_row[47] = data["edr4"].ToString();
                        tel_row[48] = data["edr5"].ToString();
                        tel_row[49] = data["edr6"].ToString();
                        tel_row[50] = data["edr7"].ToString();
                        tel_row[51] = data["edr8"].ToString();
                        tel_row[52] = data["edr9"].ToString();
                        tel_row[53] = data["edr10"].ToString();




                        dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, tel_row);
                    }
                    data.Close();
                    sqlconn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tel2 frm = new Tel2();
            Tel2.insert_mode = true;
            frm.ShowDialog();
            
            if (tel_flag == true)
            {
                tel_flag = false;
                tel_row[0] = "";
                dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, tel_row);
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //MessageBox.Show("'" + e.Row.Cells[2].Value.ToString() + "'");
            //SqlConnection sqlconn = new SqlConnection(cm.cs);
            //sqlconn.Open();
            //SqlCommand sqlcmd = new SqlCommand("delete tel where title = '" + e.Row.Cells[2].Value.ToString() + "' and fname  = '" + e.Row.Cells[3].Value.ToString() + "' and family  = '" + e.Row.Cells[4].Value.ToString() + "'", sqlconn);
            //sqlcmd.ExecuteNonQuery();
            //sqlconn.Close();
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 1; i <= 53; i++)
            {

                if (dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value == null)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = " ";
                }
            }
        }
    }
}