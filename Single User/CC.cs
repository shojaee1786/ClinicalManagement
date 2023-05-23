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
    public partial class CC : Form
    {
        public static string str = "";
        public static string myword = "";

        public CC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    if (str == "")
                        str = str + checkedListBox1.Items[i].ToString();
                    else
                        str = str + ", " + checkedListBox1.Items[i].ToString(); 
    
            this.Close();
        }

        private void CC_Load(object sender, EventArgs e)
        {
            myword = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                    checkedListBox1.SetItemChecked(i, false);

            str = "";

            SqlConnection sqlconn = new SqlConnection(cm.cs);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("select distinct cc,-ccf from firstvisit where cc<>'' order by -ccf ", sqlconn);

            SqlDataReader data = sqlcmd.ExecuteReader();
            while (data.Read())
                checkedListBox1.Items.Add(data["cc"].ToString());
            
            data.Close();

            sqlconn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Width = checkedListBox1.Width + 20;
            this.Width = this.Width + 20;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.GetItemChecked(e.Index) == false)
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("Update firstvisit set ccf = ccf + 1 where cc = '" + checkedListBox1.Items[e.Index].ToString() + "' ", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string select = "", word = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    select = checkedListBox1.Items[i].ToString();
                    break;
                }

            try
            {
                SqlConnection sqlconn = new SqlConnection(cm.cs);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand("select word from algorithm where cc='" + select + "'", sqlconn);
                SqlDataReader data = sqlcmd.ExecuteReader();
                while (data.Read())
                    word = data["word"].ToString();
                data.Close();
                sqlconn.Close();
                myword = word;
               // this.Close();
            }
            catch
            {
                MessageBox.Show("Algorithm not found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Width >= 320)
            {
                checkedListBox1.Width = checkedListBox1.Width - 20;
                this.Width = this.Width - 20;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    Patient.filter = checkedListBox1.Items[i].ToString();
                    break;
                }

           // this.Close();
        }
        
    }
}