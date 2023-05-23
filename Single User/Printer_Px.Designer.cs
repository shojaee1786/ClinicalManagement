namespace Clinical_Management
{
    partial class Printer_Px
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Printer_Px));
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
            this.px4_t = new System.Windows.Forms.TextBox();
            this.name_t = new System.Windows.Forms.TextBox();
            this.px3_t = new System.Windows.Forms.TextBox();
            this.px1_t = new System.Windows.Forms.TextBox();
            this.px2_t = new System.Windows.Forms.TextBox();
            this.markaz_c = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.button4.Location = new System.Drawing.Point(160, 472);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 39);
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
            this.button2.Size = new System.Drawing.Size(46, 39);
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
            this.button3.Location = new System.Drawing.Point(160, 541);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 39);
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
            this.button1.Size = new System.Drawing.Size(46, 39);
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
            this.button5.Location = new System.Drawing.Point(810, 406);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 39);
            this.button5.TabIndex = 10;
            this.button5.Text = "u";
            this.toolTip1.SetToolTip(this.button5, "Next Template");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::Clinical_Management.Properties.Resources.wafrewedr;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.px4_t);
            this.panel1.Controls.Add(this.name_t);
            this.panel1.Controls.Add(this.px3_t);
            this.panel1.Controls.Add(this.px1_t);
            this.panel1.Controls.Add(this.px2_t);
            this.panel1.Controls.Add(this.markaz_c);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(282, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 650);
            this.panel1.TabIndex = 0;
            // 
            // px4_t
            // 
            this.px4_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.px4_t.Location = new System.Drawing.Point(90, 387);
            this.px4_t.Multiline = true;
            this.px4_t.Name = "px4_t";
            this.px4_t.Size = new System.Drawing.Size(329, 81);
            this.px4_t.TabIndex = 5;
            this.px4_t.TextChanged += new System.EventHandler(this.px4_t_TextChanged);
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(106, 197);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(161, 20);
            this.name_t.TabIndex = 1;
            this.name_t.Enter += new System.EventHandler(this.name_t_Enter);
            // 
            // px3_t
            // 
            this.px3_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.px3_t.Location = new System.Drawing.Point(90, 310);
            this.px3_t.Name = "px3_t";
            this.px3_t.Size = new System.Drawing.Size(329, 21);
            this.px3_t.TabIndex = 4;
            // 
            // px1_t
            // 
            this.px1_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.px1_t.Location = new System.Drawing.Point(90, 258);
            this.px1_t.Name = "px1_t";
            this.px1_t.Size = new System.Drawing.Size(329, 21);
            this.px1_t.TabIndex = 2;
            this.px1_t.Enter += new System.EventHandler(this.px1_t_Enter);
            // 
            // px2_t
            // 
            this.px2_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.px2_t.Location = new System.Drawing.Point(90, 284);
            this.px2_t.Name = "px2_t";
            this.px2_t.Size = new System.Drawing.Size(329, 21);
            this.px2_t.TabIndex = 3;
            this.px2_t.Enter += new System.EventHandler(this.px2_t_Enter);
            // 
            // markaz_c
            // 
            this.markaz_c.FormattingEnabled = true;
            this.markaz_c.Location = new System.Drawing.Point(209, 143);
            this.markaz_c.Name = "markaz_c";
            this.markaz_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.markaz_c.Size = new System.Drawing.Size(124, 21);
            this.markaz_c.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(64, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(406, 596);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Printer_Px
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Navy;
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
            this.Name = "Printer_Px";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Printer-Diagnostic Procedure & Tertiary Care";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Printer_Px_MouseMove);
            this.ResizeEnd += new System.EventHandler(this.Printer_Px_ResizeEnd);
            this.Load += new System.EventHandler(this.Printer_Px_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox markaz_c;
        private System.Windows.Forms.TextBox px2_t;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox px1_t;
        private System.Windows.Forms.TextBox name_t;
        private System.Windows.Forms.TextBox px3_t;
        private System.Windows.Forms.TextBox px4_t;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;


    }
}