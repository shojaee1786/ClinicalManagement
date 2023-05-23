namespace Clinical_Management
{
    partial class Rest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rest));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cause_c = new System.Windows.Forms.ComboBox();
            this.date2_t = new System.Windows.Forms.TextBox();
            this.name_t = new System.Windows.Forms.TextBox();
            this.date1_t = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Clinical_Management.Properties.Resources.Save;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(492, 685);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(52, 46);
            this.button5.TabIndex = 11;
            this.toolTip1.SetToolTip(this.button5, "À»  œ— ”«»ﬁÂ");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Clinical_Management.Properties.Resources.Edit1;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(176, 541);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 41);
            this.button3.TabIndex = 10;
            this.toolTip1.SetToolTip(this.button3, "To Alter the contents of the combos");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Clinical_Management.Properties.Resources.Input;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(176, 470);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 41);
            this.button4.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button4, "Changing template picture");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Clinical_Management.Properties.Resources.dcvbrfgt;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(810, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 41);
            this.button2.TabIndex = 7;
            this.toolTip1.SetToolTip(this.button2, "Preview");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Clinical_Management.Properties.Resources.printer;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(810, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 41);
            this.button1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.button1, "Printer");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::Clinical_Management.Properties.Resources.Slide3100;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cause_c);
            this.panel1.Controls.Add(this.date2_t);
            this.panel1.Controls.Add(this.name_t);
            this.panel1.Controls.Add(this.date1_t);
            this.panel1.Location = new System.Drawing.Point(282, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 650);
            this.panel1.TabIndex = 0;
            // 
            // cause_c
            // 
            this.cause_c.FormattingEnabled = true;
            this.cause_c.Location = new System.Drawing.Point(85, 252);
            this.cause_c.Name = "cause_c";
            this.cause_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cause_c.Size = new System.Drawing.Size(294, 21);
            this.cause_c.TabIndex = 14;
            // 
            // date2_t
            // 
            this.date2_t.AutoCompleteCustomSource.AddRange(new string[] {
            "Â„«‰ —Ê“"});
            this.date2_t.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.date2_t.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.date2_t.Location = new System.Drawing.Point(85, 289);
            this.date2_t.Name = "date2_t";
            this.date2_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date2_t.Size = new System.Drawing.Size(120, 20);
            this.date2_t.TabIndex = 11;
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(199, 215);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(180, 20);
            this.name_t.TabIndex = 10;
            // 
            // date1_t
            // 
            this.date1_t.Location = new System.Drawing.Point(253, 289);
            this.date1_t.Name = "date1_t";
            this.date1_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date1_t.Size = new System.Drawing.Size(86, 20);
            this.date1_t.TabIndex = 5;
            // 
            // Rest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 740);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(400, 0);
            this.Name = "Rest";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Printer-Rest Verification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Rest_MouseMove);
            this.ResizeEnd += new System.EventHandler(this.Rest_ResizeEnd);
            this.Load += new System.EventHandler(this.Rest_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox date1_t;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox name_t;
        private System.Windows.Forms.TextBox date2_t;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cause_c;
        private System.Windows.Forms.Button button5;


    }
}