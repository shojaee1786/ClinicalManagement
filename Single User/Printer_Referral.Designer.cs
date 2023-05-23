namespace Clinical_Management
{
    partial class Printer_Referral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Printer_Referral));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Dx_t = new System.Windows.Forms.TextBox();
            this.PI_t = new System.Windows.Forms.TextBox();
            this.CC_t = new System.Windows.Forms.TextBox();
            this.DDx_t = new System.Windows.Forms.TextBox();
            this.name_t = new System.Windows.Forms.TextBox();
            this.refer_c = new System.Windows.Forms.ComboBox();
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
            this.button4.Location = new System.Drawing.Point(173, 472);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 39);
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
            this.button2.Location = new System.Drawing.Point(818, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 39);
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
            this.button3.Location = new System.Drawing.Point(173, 541);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 39);
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
            this.button1.Location = new System.Drawing.Point(818, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 39);
            this.button1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.button1, "Printer");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::Clinical_Management.Properties.Resources.ref4533;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Dx_t);
            this.panel1.Controls.Add(this.PI_t);
            this.panel1.Controls.Add(this.CC_t);
            this.panel1.Controls.Add(this.DDx_t);
            this.panel1.Controls.Add(this.name_t);
            this.panel1.Controls.Add(this.refer_c);
            this.panel1.Location = new System.Drawing.Point(282, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 650);
            this.panel1.TabIndex = 0;
            // 
            // Dx_t
            // 
            this.Dx_t.Location = new System.Drawing.Point(52, 296);
            this.Dx_t.Name = "Dx_t";
            this.Dx_t.Size = new System.Drawing.Size(378, 20);
            this.Dx_t.TabIndex = 15;
            this.Dx_t.Enter += new System.EventHandler(this.Dx_t_Enter);
            // 
            // PI_t
            // 
            this.PI_t.Location = new System.Drawing.Point(52, 355);
            this.PI_t.Name = "PI_t";
            this.PI_t.Size = new System.Drawing.Size(378, 20);
            this.PI_t.TabIndex = 14;
            this.PI_t.Enter += new System.EventHandler(this.PI_t_Enter);
            // 
            // CC_t
            // 
            this.CC_t.Location = new System.Drawing.Point(52, 323);
            this.CC_t.Name = "CC_t";
            this.CC_t.Size = new System.Drawing.Size(378, 20);
            this.CC_t.TabIndex = 13;
            this.CC_t.Enter += new System.EventHandler(this.CC_t_Enter);
            // 
            // DDx_t
            // 
            this.DDx_t.Location = new System.Drawing.Point(52, 384);
            this.DDx_t.Name = "DDx_t";
            this.DDx_t.Size = new System.Drawing.Size(378, 20);
            this.DDx_t.TabIndex = 11;
            this.DDx_t.Enter += new System.EventHandler(this.DDx_t_Enter);
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(189, 235);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(151, 20);
            this.name_t.TabIndex = 10;
            this.name_t.Enter += new System.EventHandler(this.name_t_Enter);
            // 
            // refer_c
            // 
            this.refer_c.FormattingEnabled = true;
            this.refer_c.Location = new System.Drawing.Point(52, 140);
            this.refer_c.Name = "refer_c";
            this.refer_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.refer_c.Size = new System.Drawing.Size(378, 21);
            this.refer_c.TabIndex = 0;
            // 
            // Printer_Referral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 740);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(400, 0);
            this.Name = "Printer_Referral";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Printer-Referral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Printer_Referral_MouseMove);
            this.ResizeEnd += new System.EventHandler(this.Printer_Referral_ResizeEnd);
            this.Load += new System.EventHandler(this.Printer_Referral_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox refer_c;
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
        private System.Windows.Forms.TextBox PI_t;
        private System.Windows.Forms.TextBox CC_t;
        private System.Windows.Forms.TextBox DDx_t;
        private System.Windows.Forms.TextBox Dx_t;


    }
}