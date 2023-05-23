namespace Clinical_Management
{
    partial class Prescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prescription));
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
            this.t16 = new System.Windows.Forms.TextBox();
            this.t15 = new System.Windows.Forms.TextBox();
            this.t14 = new System.Windows.Forms.TextBox();
            this.t13 = new System.Windows.Forms.TextBox();
            this.t12 = new System.Windows.Forms.TextBox();
            this.t11 = new System.Windows.Forms.TextBox();
            this.t10 = new System.Windows.Forms.TextBox();
            this.t9 = new System.Windows.Forms.TextBox();
            this.t8 = new System.Windows.Forms.TextBox();
            this.t7 = new System.Windows.Forms.TextBox();
            this.t6 = new System.Windows.Forms.TextBox();
            this.t5 = new System.Windows.Forms.TextBox();
            this.t4 = new System.Windows.Forms.TextBox();
            this.t3 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.t1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ccdx_t = new System.Windows.Forms.TextBox();
            this.age_t = new System.Windows.Forms.TextBox();
            this.name_t = new System.Windows.Forms.TextBox();
            this.date_t = new System.Windows.Forms.TextBox();
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
            this.button4.Location = new System.Drawing.Point(188, 470);
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
            this.button3.Location = new System.Drawing.Point(188, 541);
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
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button5.ForeColor = System.Drawing.Color.Maroon;
            this.button5.Location = new System.Drawing.Point(810, 412);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 39);
            this.button5.TabIndex = 11;
            this.button5.Text = "u";
            this.toolTip1.SetToolTip(this.button5, "Next Template");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::Clinical_Management.Properties.Resources.New_Picture__2_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.t16);
            this.panel1.Controls.Add(this.t15);
            this.panel1.Controls.Add(this.t14);
            this.panel1.Controls.Add(this.t13);
            this.panel1.Controls.Add(this.t12);
            this.panel1.Controls.Add(this.t11);
            this.panel1.Controls.Add(this.t10);
            this.panel1.Controls.Add(this.t9);
            this.panel1.Controls.Add(this.t8);
            this.panel1.Controls.Add(this.t7);
            this.panel1.Controls.Add(this.t6);
            this.panel1.Controls.Add(this.t5);
            this.panel1.Controls.Add(this.t4);
            this.panel1.Controls.Add(this.t3);
            this.panel1.Controls.Add(this.t2);
            this.panel1.Controls.Add(this.t1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ccdx_t);
            this.panel1.Controls.Add(this.age_t);
            this.panel1.Controls.Add(this.name_t);
            this.panel1.Controls.Add(this.date_t);
            this.panel1.Location = new System.Drawing.Point(282, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 650);
            this.panel1.TabIndex = 0;
            // 
            // t16
            // 
            this.t16.Location = new System.Drawing.Point(56, 556);
            this.t16.Name = "t16";
            this.t16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t16.Size = new System.Drawing.Size(370, 20);
            this.t16.TabIndex = 29;
            // 
            // t15
            // 
            this.t15.Location = new System.Drawing.Point(56, 533);
            this.t15.Name = "t15";
            this.t15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t15.Size = new System.Drawing.Size(370, 20);
            this.t15.TabIndex = 28;
            // 
            // t14
            // 
            this.t14.Location = new System.Drawing.Point(56, 510);
            this.t14.Name = "t14";
            this.t14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t14.Size = new System.Drawing.Size(370, 20);
            this.t14.TabIndex = 27;
            // 
            // t13
            // 
            this.t13.Location = new System.Drawing.Point(56, 487);
            this.t13.Name = "t13";
            this.t13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t13.Size = new System.Drawing.Size(370, 20);
            this.t13.TabIndex = 26;
            // 
            // t12
            // 
            this.t12.Location = new System.Drawing.Point(56, 464);
            this.t12.Name = "t12";
            this.t12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t12.Size = new System.Drawing.Size(370, 20);
            this.t12.TabIndex = 25;
            // 
            // t11
            // 
            this.t11.Location = new System.Drawing.Point(56, 441);
            this.t11.Name = "t11";
            this.t11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t11.Size = new System.Drawing.Size(370, 20);
            this.t11.TabIndex = 24;
            // 
            // t10
            // 
            this.t10.Location = new System.Drawing.Point(56, 418);
            this.t10.Name = "t10";
            this.t10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t10.Size = new System.Drawing.Size(370, 20);
            this.t10.TabIndex = 23;
            // 
            // t9
            // 
            this.t9.Location = new System.Drawing.Point(56, 395);
            this.t9.Name = "t9";
            this.t9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t9.Size = new System.Drawing.Size(370, 20);
            this.t9.TabIndex = 22;
            // 
            // t8
            // 
            this.t8.Location = new System.Drawing.Point(56, 372);
            this.t8.Name = "t8";
            this.t8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t8.Size = new System.Drawing.Size(370, 20);
            this.t8.TabIndex = 21;
            // 
            // t7
            // 
            this.t7.Location = new System.Drawing.Point(56, 349);
            this.t7.Name = "t7";
            this.t7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t7.Size = new System.Drawing.Size(370, 20);
            this.t7.TabIndex = 20;
            // 
            // t6
            // 
            this.t6.Location = new System.Drawing.Point(56, 326);
            this.t6.Name = "t6";
            this.t6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t6.Size = new System.Drawing.Size(370, 20);
            this.t6.TabIndex = 19;
            // 
            // t5
            // 
            this.t5.Location = new System.Drawing.Point(56, 303);
            this.t5.Name = "t5";
            this.t5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t5.Size = new System.Drawing.Size(370, 20);
            this.t5.TabIndex = 18;
            // 
            // t4
            // 
            this.t4.Location = new System.Drawing.Point(56, 280);
            this.t4.Name = "t4";
            this.t4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t4.Size = new System.Drawing.Size(370, 20);
            this.t4.TabIndex = 17;
            // 
            // t3
            // 
            this.t3.Location = new System.Drawing.Point(56, 257);
            this.t3.Name = "t3";
            this.t3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t3.Size = new System.Drawing.Size(370, 20);
            this.t3.TabIndex = 16;
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(56, 234);
            this.t2.Name = "t2";
            this.t2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t2.Size = new System.Drawing.Size(370, 20);
            this.t2.TabIndex = 15;
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(56, 211);
            this.t1.Name = "t1";
            this.t1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t1.Size = new System.Drawing.Size(370, 20);
            this.t1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palace Script MT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 45);
            this.label1.TabIndex = 13;
            this.label1.Text = "Rx";
            // 
            // ccdx_t
            // 
            this.ccdx_t.Location = new System.Drawing.Point(56, 130);
            this.ccdx_t.Name = "ccdx_t";
            this.ccdx_t.Size = new System.Drawing.Size(205, 20);
            this.ccdx_t.TabIndex = 12;
            // 
            // age_t
            // 
            this.age_t.Location = new System.Drawing.Point(306, 154);
            this.age_t.Name = "age_t";
            this.age_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.age_t.Size = new System.Drawing.Size(120, 20);
            this.age_t.TabIndex = 11;
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(306, 130);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(120, 20);
            this.name_t.TabIndex = 10;
            // 
            // date_t
            // 
            this.date_t.Location = new System.Drawing.Point(306, 178);
            this.date_t.Name = "date_t";
            this.date_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date_t.Size = new System.Drawing.Size(120, 20);
            this.date_t.TabIndex = 5;
            // 
            // Prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Maroon;
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
            this.Name = "Prescription";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Printer-Prescription";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Prescription_MouseMove);
            this.ResizeEnd += new System.EventHandler(this.Prescription_ResizeEnd);
            this.Load += new System.EventHandler(this.Prescription_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox date_t;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox name_t;
        private System.Windows.Forms.TextBox ccdx_t;
        private System.Windows.Forms.TextBox age_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t16;
        private System.Windows.Forms.TextBox t15;
        private System.Windows.Forms.TextBox t14;
        private System.Windows.Forms.TextBox t13;
        private System.Windows.Forms.TextBox t12;
        private System.Windows.Forms.TextBox t11;
        private System.Windows.Forms.TextBox t10;
        private System.Windows.Forms.TextBox t9;
        private System.Windows.Forms.TextBox t8;
        private System.Windows.Forms.TextBox t7;
        private System.Windows.Forms.TextBox t6;
        private System.Windows.Forms.TextBox t5;
        private System.Windows.Forms.TextBox t4;
        private System.Windows.Forms.TextBox t3;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.Button button5;


    }
}