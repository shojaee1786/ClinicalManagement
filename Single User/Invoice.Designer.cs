namespace Clinical_Management
{
    partial class Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_t = new System.Windows.Forms.TextBox();
            this.price4_c = new System.Windows.Forms.ComboBox();
            this.price3_c = new System.Windows.Forms.ComboBox();
            this.price2_c = new System.Windows.Forms.ComboBox();
            this.price1_c = new System.Windows.Forms.ComboBox();
            this.date_t = new System.Windows.Forms.TextBox();
            this.service4_c = new System.Windows.Forms.ComboBox();
            this.service3_c = new System.Windows.Forms.ComboBox();
            this.service2_c = new System.Windows.Forms.ComboBox();
            this.service1_c = new System.Windows.Forms.ComboBox();
            this.price_c = new System.Windows.Forms.ComboBox();
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
            // button4
            // 
            this.button4.BackgroundImage = global::Clinical_Management.Properties.Resources.Input;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(179, 470);
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
            // button3
            // 
            this.button3.BackgroundImage = global::Clinical_Management.Properties.Resources.Edit1;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(179, 541);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 41);
            this.button3.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button3, "To Alter the contents of the combos");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // button5
            // 
            this.button5.BackgroundImage = global::Clinical_Management.Properties.Resources.Save;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(483, 685);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(52, 46);
            this.button5.TabIndex = 12;
            this.toolTip1.SetToolTip(this.button5, "À»  œ— ”«»ﬁÂ");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::Clinical_Management.Properties.Resources.New_P120000;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.name_t);
            this.panel1.Controls.Add(this.price4_c);
            this.panel1.Controls.Add(this.price3_c);
            this.panel1.Controls.Add(this.price2_c);
            this.panel1.Controls.Add(this.price1_c);
            this.panel1.Controls.Add(this.date_t);
            this.panel1.Controls.Add(this.service4_c);
            this.panel1.Controls.Add(this.service3_c);
            this.panel1.Controls.Add(this.service2_c);
            this.panel1.Controls.Add(this.service1_c);
            this.panel1.Controls.Add(this.price_c);
            this.panel1.Location = new System.Drawing.Point(282, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 650);
            this.panel1.TabIndex = 0;
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(186, 370);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(161, 20);
            this.name_t.TabIndex = 10;
            // 
            // price4_c
            // 
            this.price4_c.FormattingEnabled = true;
            this.price4_c.Items.AddRange(new object[] {
            "çÂ«— Â“«—  Ê„«‰",
            "Å‰Ã Â“«—  Ê„«‰"});
            this.price4_c.Location = new System.Drawing.Point(85, 338);
            this.price4_c.Name = "price4_c";
            this.price4_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price4_c.Size = new System.Drawing.Size(100, 21);
            this.price4_c.TabIndex = 9;
            // 
            // price3_c
            // 
            this.price3_c.FormattingEnabled = true;
            this.price3_c.Location = new System.Drawing.Point(85, 312);
            this.price3_c.Name = "price3_c";
            this.price3_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price3_c.Size = new System.Drawing.Size(100, 21);
            this.price3_c.TabIndex = 8;
            // 
            // price2_c
            // 
            this.price2_c.FormattingEnabled = true;
            this.price2_c.Items.AddRange(new object[] {
            "çÂ«— Â“«—  Ê„«‰",
            "Å‰Ã Â“«—  Ê„«‰"});
            this.price2_c.Location = new System.Drawing.Point(85, 283);
            this.price2_c.Name = "price2_c";
            this.price2_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price2_c.Size = new System.Drawing.Size(100, 21);
            this.price2_c.TabIndex = 7;
            // 
            // price1_c
            // 
            this.price1_c.FormattingEnabled = true;
            this.price1_c.Location = new System.Drawing.Point(85, 256);
            this.price1_c.Name = "price1_c";
            this.price1_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price1_c.Size = new System.Drawing.Size(100, 21);
            this.price1_c.TabIndex = 6;
            // 
            // date_t
            // 
            this.date_t.Location = new System.Drawing.Point(186, 396);
            this.date_t.Name = "date_t";
            this.date_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date_t.Size = new System.Drawing.Size(120, 20);
            this.date_t.TabIndex = 5;
            // 
            // service4_c
            // 
            this.service4_c.FormattingEnabled = true;
            this.service4_c.Items.AddRange(new object[] {
            "Õﬁ ÊÌ“Ì ",
            "Õﬁ „‘«Ê—Â",
            "‰Ê«— ﬁ·»"});
            this.service4_c.Location = new System.Drawing.Point(191, 338);
            this.service4_c.Name = "service4_c";
            this.service4_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.service4_c.Size = new System.Drawing.Size(187, 21);
            this.service4_c.TabIndex = 4;
            // 
            // service3_c
            // 
            this.service3_c.FormattingEnabled = true;
            this.service3_c.Location = new System.Drawing.Point(191, 312);
            this.service3_c.Name = "service3_c";
            this.service3_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.service3_c.Size = new System.Drawing.Size(187, 21);
            this.service3_c.TabIndex = 3;
            // 
            // service2_c
            // 
            this.service2_c.FormattingEnabled = true;
            this.service2_c.Items.AddRange(new object[] {
            "Õﬁ ÊÌ“Ì ",
            "Õﬁ „‘«Ê—Â",
            "‰Ê«— ﬁ·»"});
            this.service2_c.Location = new System.Drawing.Point(191, 283);
            this.service2_c.Name = "service2_c";
            this.service2_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.service2_c.Size = new System.Drawing.Size(187, 21);
            this.service2_c.TabIndex = 2;
            // 
            // service1_c
            // 
            this.service1_c.FormattingEnabled = true;
            this.service1_c.Location = new System.Drawing.Point(191, 256);
            this.service1_c.Name = "service1_c";
            this.service1_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.service1_c.Size = new System.Drawing.Size(187, 21);
            this.service1_c.TabIndex = 1;
            // 
            // price_c
            // 
            this.price_c.FormattingEnabled = true;
            this.price_c.Location = new System.Drawing.Point(170, 218);
            this.price_c.Name = "price_c";
            this.price_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price_c.Size = new System.Drawing.Size(162, 21);
            this.price_c.TabIndex = 0;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Gold;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 740);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(400, 0);
            this.Name = "Invoice";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Printer-Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Invoice_MouseMove);
            this.ResizeEnd += new System.EventHandler(this.Invoice_ResizeEnd);
            this.Load += new System.EventHandler(this.Invoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox service4_c;
        private System.Windows.Forms.ComboBox service3_c;
        private System.Windows.Forms.ComboBox service2_c;
        private System.Windows.Forms.ComboBox service1_c;
        private System.Windows.Forms.ComboBox price_c;
        private System.Windows.Forms.TextBox date_t;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox price4_c;
        private System.Windows.Forms.ComboBox price3_c;
        private System.Windows.Forms.ComboBox price2_c;
        private System.Windows.Forms.ComboBox price1_c;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox name_t;
        private System.Windows.Forms.Button button5;


    }
}