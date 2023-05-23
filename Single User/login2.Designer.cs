namespace Clinical_Management
{
    partial class login2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login2));
            this.button1 = new System.Windows.Forms.Button();
            this.username_t = new System.Windows.Forms.TextBox();
            this.pass_t = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_ch = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Clinical_Management.Properties.Resources.shell32_dll_104;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(124, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 54);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // username_t
            // 
            this.username_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.username_t.Location = new System.Drawing.Point(56, 30);
            this.username_t.Name = "username_t";
            this.username_t.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.username_t.Size = new System.Drawing.Size(140, 22);
            this.username_t.TabIndex = 0;
            // 
            // pass_t
            // 
            this.pass_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pass_t.Location = new System.Drawing.Point(56, 75);
            this.pass_t.Name = "pass_t";
            this.pass_t.PasswordChar = '*';
            this.pass_t.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pass_t.Size = new System.Drawing.Size(140, 22);
            this.pass_t.TabIndex = 1;
            this.pass_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass_t_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(202, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "‰«„ ﬂ«—»—Ì";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(211, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "ﬂ·„Â ⁄»Ê—";
            // 
            // login_ch
            // 
            this.login_ch.AutoSize = true;
            this.login_ch.BackColor = System.Drawing.Color.Transparent;
            this.login_ch.ForeColor = System.Drawing.Color.Navy;
            this.login_ch.Location = new System.Drawing.Point(68, 125);
            this.login_ch.Name = "login_ch";
            this.login_ch.Size = new System.Drawing.Size(205, 17);
            this.login_ch.TabIndex = 5;
            this.login_ch.Text = "»Â Œ«ÿ— ”Å—œ‰ ‰«„ ﬂ«—»—Ì Ê ﬂ·„Â ⁄»Ê—";
            this.login_ch.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clinical_Management.Properties.Resources.STARTM;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Clinical_Management.Properties.Resources._0110;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.login_ch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_t);
            this.Controls.Add(this.username_t);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "’›ÕÂ Ê—Êœ";
            this.Load += new System.EventHandler(this.login2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox username_t;
        private System.Windows.Forms.TextBox pass_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox login_ch;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}