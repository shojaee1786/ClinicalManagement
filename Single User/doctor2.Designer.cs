namespace Clinical_Management
{
    partial class doctor2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doctor2));
            this.username_t = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.family_t = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prf_t = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name_t = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pass2_t = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pass_t = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // username_t
            // 
            this.username_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.username_t.Location = new System.Drawing.Point(142, 126);
            this.username_t.Name = "username_t";
            this.username_t.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.username_t.Size = new System.Drawing.Size(196, 21);
            this.username_t.TabIndex = 3;
            this.username_t.Enter += new System.EventHandler(this.username_t_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(49, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "User Name :";
            // 
            // family_t
            // 
            this.family_t.Location = new System.Drawing.Point(297, 53);
            this.family_t.Name = "family_t";
            this.family_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.family_t.Size = new System.Drawing.Size(196, 20);
            this.family_t.TabIndex = 1;
            this.family_t.Enter += new System.EventHandler(this.family_t_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(503, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "نام خانوادگي";
            // 
            // prf_t
            // 
            this.prf_t.Location = new System.Drawing.Point(297, 89);
            this.prf_t.Name = "prf_t";
            this.prf_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.prf_t.Size = new System.Drawing.Size(196, 20);
            this.prf_t.TabIndex = 2;
            this.prf_t.Enter += new System.EventHandler(this.prf_t_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(501, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "نوع تخصص";
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(297, 16);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(196, 20);
            this.name_t.TabIndex = 0;
            this.name_t.Enter += new System.EventHandler(this.name_t_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(501, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "نام";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(386, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "تغييرات ثبت شود";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pass2_t
            // 
            this.pass2_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pass2_t.Location = new System.Drawing.Point(142, 199);
            this.pass2_t.Name = "pass2_t";
            this.pass2_t.PasswordChar = '*';
            this.pass2_t.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pass2_t.Size = new System.Drawing.Size(196, 21);
            this.pass2_t.TabIndex = 5;
            this.pass2_t.Enter += new System.EventHandler(this.pass2_t_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(5, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 15);
            this.label4.TabIndex = 70;
            this.label4.Text = "Confirm Password :";
            // 
            // pass_t
            // 
            this.pass_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pass_t.Location = new System.Drawing.Point(142, 163);
            this.pass_t.Name = "pass_t";
            this.pass_t.PasswordChar = '*';
            this.pass_t.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pass_t.Size = new System.Drawing.Size(196, 21);
            this.pass_t.TabIndex = 4;
            this.pass_t.Enter += new System.EventHandler(this.pass_t_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(59, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 69;
            this.label5.Text = "Password :";
            // 
            // doctor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(591, 239);
            this.Controls.Add(this.pass2_t);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pass_t);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.name_t);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.username_t);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.family_t);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prf_t);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "doctor2";
            this.Text = "فرم عمودي";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.doctor2_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.doctor2_ResizeEnd);
            this.Load += new System.EventHandler(this.doctor2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_t;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox family_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prf_t;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name_t;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pass2_t;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pass_t;
        private System.Windows.Forms.Label label5;

    }
}