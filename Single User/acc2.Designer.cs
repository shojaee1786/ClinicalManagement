namespace Clinical_Management
{
    partial class acc2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(acc2));
            this.hospital_t = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.remaining_t = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.variz_t = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bank_t = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkdate_t = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.income_t = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.remainder_t = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.outcome_t = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sanad_t = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.op_t = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.par_t = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.date_t = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.variz_c = new System.Windows.Forms.ComboBox();
            this.hospital_c = new System.Windows.Forms.ComboBox();
            this.op_c = new System.Windows.Forms.ComboBox();
            this.bank_c = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hospital_t
            // 
            this.hospital_t.Location = new System.Drawing.Point(45, 276);
            this.hospital_t.Name = "hospital_t";
            this.hospital_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hospital_t.Size = new System.Drawing.Size(196, 20);
            this.hospital_t.TabIndex = 8;
            this.hospital_t.Click += new System.EventHandler(this.hospital_t_Click);
            this.hospital_t.Enter += new System.EventHandler(this.hospital_t_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DarkGreen;
            this.label13.Location = new System.Drawing.Point(247, 279);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 63;
            this.label13.Text = "نام بيمارستان";
            // 
            // remaining_t
            // 
            this.remaining_t.Enabled = false;
            this.remaining_t.Location = new System.Drawing.Point(45, 425);
            this.remaining_t.Name = "remaining_t";
            this.remaining_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.remaining_t.Size = new System.Drawing.Size(196, 20);
            this.remaining_t.TabIndex = 12;
            this.remaining_t.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DarkGreen;
            this.label14.Location = new System.Drawing.Point(247, 428);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 62;
            this.label14.Text = "مانده";
            // 
            // variz_t
            // 
            this.variz_t.Location = new System.Drawing.Point(45, 235);
            this.variz_t.Name = "variz_t";
            this.variz_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.variz_t.Size = new System.Drawing.Size(196, 20);
            this.variz_t.TabIndex = 7;
            this.variz_t.Click += new System.EventHandler(this.variz_t_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkGreen;
            this.label10.Location = new System.Drawing.Point(251, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "مرجع واريز";
            // 
            // bank_t
            // 
            this.bank_t.Location = new System.Drawing.Point(45, 163);
            this.bank_t.Name = "bank_t";
            this.bank_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bank_t.Size = new System.Drawing.Size(196, 20);
            this.bank_t.TabIndex = 5;
            this.bank_t.Click += new System.EventHandler(this.bank_t_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkGreen;
            this.label11.Location = new System.Drawing.Point(251, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "نام بانك";
            // 
            // checkdate_t
            // 
            this.checkdate_t.Location = new System.Drawing.Point(45, 199);
            this.checkdate_t.Name = "checkdate_t";
            this.checkdate_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkdate_t.Size = new System.Drawing.Size(196, 20);
            this.checkdate_t.TabIndex = 6;
            this.checkdate_t.Enter += new System.EventHandler(this.checkdate_t_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DarkGreen;
            this.label12.Location = new System.Drawing.Point(251, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "تاريخ چك";
            // 
            // income_t
            // 
            this.income_t.Location = new System.Drawing.Point(45, 389);
            this.income_t.Name = "income_t";
            this.income_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.income_t.Size = new System.Drawing.Size(196, 20);
            this.income_t.TabIndex = 11;
            this.income_t.Text = "0";
            this.income_t.Leave += new System.EventHandler(this.income_t_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(247, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "(بستانكار(درآمد";
            // 
            // remainder_t
            // 
            this.remainder_t.Location = new System.Drawing.Point(45, 316);
            this.remainder_t.Name = "remainder_t";
            this.remainder_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.remainder_t.Size = new System.Drawing.Size(196, 20);
            this.remainder_t.TabIndex = 9;
            this.remainder_t.Text = "0";
            this.remainder_t.Enter += new System.EventHandler(this.remainder_t_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(247, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "مانده حساب بيمار";
            // 
            // outcome_t
            // 
            this.outcome_t.Location = new System.Drawing.Point(45, 353);
            this.outcome_t.Name = "outcome_t";
            this.outcome_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.outcome_t.Size = new System.Drawing.Size(196, 20);
            this.outcome_t.TabIndex = 10;
            this.outcome_t.Text = "0";
            this.outcome_t.Leave += new System.EventHandler(this.outcome_t_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(247, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "(بدهكار(هزينه";
            // 
            // sanad_t
            // 
            this.sanad_t.Location = new System.Drawing.Point(45, 127);
            this.sanad_t.Name = "sanad_t";
            this.sanad_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sanad_t.Size = new System.Drawing.Size(196, 20);
            this.sanad_t.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(251, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "شماره سند - چك";
            // 
            // op_t
            // 
            this.op_t.Location = new System.Drawing.Point(45, 55);
            this.op_t.Name = "op_t";
            this.op_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.op_t.Size = new System.Drawing.Size(196, 20);
            this.op_t.TabIndex = 2;
            this.op_t.Click += new System.EventHandler(this.op_t_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(251, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "شرح عمليات";
            // 
            // par_t
            // 
            this.par_t.Location = new System.Drawing.Point(45, 91);
            this.par_t.Name = "par_t";
            this.par_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.par_t.Size = new System.Drawing.Size(196, 20);
            this.par_t.TabIndex = 3;
            this.par_t.Enter += new System.EventHandler(this.par_t_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(251, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "شماره پرونده";
            // 
            // date_t
            // 
            this.date_t.Location = new System.Drawing.Point(45, 18);
            this.date_t.Name = "date_t";
            this.date_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date_t.Size = new System.Drawing.Size(196, 20);
            this.date_t.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(249, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "تاريخ";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(93, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "تغييرات ثبت شود";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // variz_c
            // 
            this.variz_c.BackColor = System.Drawing.Color.LemonChiffon;
            this.variz_c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variz_c.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.variz_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.variz_c.ForeColor = System.Drawing.Color.Black;
            this.variz_c.FormattingEnabled = true;
            this.variz_c.Location = new System.Drawing.Point(24, 230);
            this.variz_c.Name = "variz_c";
            this.variz_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.variz_c.Size = new System.Drawing.Size(17, 28);
            this.variz_c.TabIndex = 110;
            this.variz_c.Visible = false;
            this.variz_c.SelectedIndexChanged += new System.EventHandler(this.variz_c_SelectedIndexChanged);
            this.variz_c.Click += new System.EventHandler(this.variz_c_Click);
            this.variz_c.MouseHover += new System.EventHandler(this.variz_c_MouseHover);
            // 
            // hospital_c
            // 
            this.hospital_c.BackColor = System.Drawing.Color.LemonChiffon;
            this.hospital_c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hospital_c.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hospital_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.hospital_c.ForeColor = System.Drawing.Color.Black;
            this.hospital_c.FormattingEnabled = true;
            this.hospital_c.Location = new System.Drawing.Point(24, 271);
            this.hospital_c.Name = "hospital_c";
            this.hospital_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hospital_c.Size = new System.Drawing.Size(17, 28);
            this.hospital_c.TabIndex = 109;
            this.hospital_c.Visible = false;
            this.hospital_c.SelectedIndexChanged += new System.EventHandler(this.hospital_c_SelectedIndexChanged);
            this.hospital_c.Click += new System.EventHandler(this.hospital_c_Click);
            this.hospital_c.MouseHover += new System.EventHandler(this.hospital_c_MouseHover);
            // 
            // op_c
            // 
            this.op_c.BackColor = System.Drawing.Color.LemonChiffon;
            this.op_c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.op_c.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.op_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.op_c.ForeColor = System.Drawing.Color.Black;
            this.op_c.FormattingEnabled = true;
            this.op_c.Location = new System.Drawing.Point(24, 50);
            this.op_c.Name = "op_c";
            this.op_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.op_c.Size = new System.Drawing.Size(17, 28);
            this.op_c.TabIndex = 108;
            this.op_c.Visible = false;
            this.op_c.SelectedIndexChanged += new System.EventHandler(this.op_c_SelectedIndexChanged);
            this.op_c.Click += new System.EventHandler(this.op_c_Click);
            this.op_c.MouseHover += new System.EventHandler(this.op_c_MouseHover);
            // 
            // bank_c
            // 
            this.bank_c.BackColor = System.Drawing.Color.LemonChiffon;
            this.bank_c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bank_c.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bank_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bank_c.ForeColor = System.Drawing.Color.Black;
            this.bank_c.FormattingEnabled = true;
            this.bank_c.Location = new System.Drawing.Point(24, 158);
            this.bank_c.Name = "bank_c";
            this.bank_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bank_c.Size = new System.Drawing.Size(17, 28);
            this.bank_c.TabIndex = 107;
            this.bank_c.Visible = false;
            this.bank_c.SelectedIndexChanged += new System.EventHandler(this.bank_c_SelectedIndexChanged);
            this.bank_c.Click += new System.EventHandler(this.bank_c_Click);
            this.bank_c.MouseHover += new System.EventHandler(this.bank_c_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clinical_Management.Properties.Resources.Bateaux_dans_le_port_de_Honfleur;
            this.pictureBox1.Location = new System.Drawing.Point(44, 492);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 111;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 468);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "صثبصثب";
            // 
            // acc2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(350, 697);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.variz_c);
            this.Controls.Add(this.hospital_c);
            this.Controls.Add(this.op_c);
            this.Controls.Add(this.bank_c);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date_t);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hospital_t);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.remaining_t);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.variz_t);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bank_t);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkdate_t);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.income_t);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remainder_t);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outcome_t);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sanad_t);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.op_t);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.par_t);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "acc2";
            this.Text = "فرم عمودي";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acc2_FormClosing);
            this.Load += new System.EventHandler(this.acc2_Load);
            this.ResizeEnd += new System.EventHandler(this.acc2_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hospital_t;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox remaining_t;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox variz_t;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox bank_t;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox checkdate_t;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox income_t;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox remainder_t;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox outcome_t;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sanad_t;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox op_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox par_t;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox date_t;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox variz_c;
        private System.Windows.Forms.ComboBox hospital_c;
        private System.Windows.Forms.ComboBox op_c;
        private System.Windows.Forms.ComboBox bank_c;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
    }
}