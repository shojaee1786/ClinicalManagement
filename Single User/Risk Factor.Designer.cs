namespace Clinical_Management
{
    partial class Risk_Factor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Risk_Factor));
            this.query_c = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.color_c = new System.Windows.Forms.ComboBox();
            this.save_b = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inactive_r = new System.Windows.Forms.RadioButton();
            this.active_r = new System.Windows.Forms.RadioButton();
            this.action_t = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // query_c
            // 
            this.query_c.FormattingEnabled = true;
            this.query_c.Location = new System.Drawing.Point(26, 84);
            this.query_c.Name = "query_c";
            this.query_c.Size = new System.Drawing.Size(356, 21);
            this.query_c.TabIndex = 0;
            this.query_c.SelectedIndexChanged += new System.EventHandler(this.query_c_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Risk Factor Query";
            // 
            // color_c
            // 
            this.color_c.FormattingEnabled = true;
            this.color_c.Items.AddRange(new object[] {
            "Purple",
            "Red",
            "Orange",
            "Yellow",
            "White",
            "Green",
            "Light Green",
            "Navy Blue",
            "Blue",
            "Light Blue"});
            this.color_c.Location = new System.Drawing.Point(26, 222);
            this.color_c.Name = "color_c";
            this.color_c.Size = new System.Drawing.Size(120, 21);
            this.color_c.TabIndex = 5;
            // 
            // save_b
            // 
            this.save_b.BackgroundImage = global::Clinical_Management.Properties.Resources.Save1;
            this.save_b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.save_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_b.Location = new System.Drawing.Point(26, 262);
            this.save_b.Name = "save_b";
            this.save_b.Size = new System.Drawing.Size(50, 33);
            this.save_b.TabIndex = 9;
            this.toolTip1.SetToolTip(this.save_b, "Save page");
            this.save_b.UseVisualStyleBackColor = true;
            this.save_b.Click += new System.EventHandler(this.save_b_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(22, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Action to be taken";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(22, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Choose Alert Color";
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::Clinical_Management.Properties.Resources.search_data;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(26, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 39);
            this.button6.TabIndex = 12;
            this.toolTip1.SetToolTip(this.button6, "Open to query translation");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.inactive_r);
            this.groupBox2.Controls.Add(this.active_r);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(751, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 48);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Risk Factor Alarm";
            // 
            // inactive_r
            // 
            this.inactive_r.AutoSize = true;
            this.inactive_r.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.inactive_r.ForeColor = System.Drawing.Color.Navy;
            this.inactive_r.Location = new System.Drawing.Point(89, 19);
            this.inactive_r.Name = "inactive_r";
            this.inactive_r.Size = new System.Drawing.Size(81, 20);
            this.inactive_r.TabIndex = 71;
            this.inactive_r.Text = "InActive";
            this.inactive_r.UseVisualStyleBackColor = true;
            // 
            // active_r
            // 
            this.active_r.AutoSize = true;
            this.active_r.Checked = true;
            this.active_r.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.active_r.ForeColor = System.Drawing.Color.Navy;
            this.active_r.Location = new System.Drawing.Point(14, 19);
            this.active_r.Name = "active_r";
            this.active_r.Size = new System.Drawing.Size(69, 20);
            this.active_r.TabIndex = 70;
            this.active_r.TabStop = true;
            this.active_r.Text = "Active";
            this.active_r.UseVisualStyleBackColor = true;
            // 
            // action_t
            // 
            this.action_t.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.action_t.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.action_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.action_t.Location = new System.Drawing.Point(26, 144);
            this.action_t.Multiline = true;
            this.action_t.Name = "action_t";
            this.action_t.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.action_t.Size = new System.Drawing.Size(236, 46);
            this.action_t.TabIndex = 74;
            this.action_t.Enter += new System.EventHandler(this.action_t_Enter);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Clinical_Management.Properties.Resources.help2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.Location = new System.Drawing.Point(975, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 39);
            this.button3.TabIndex = 75;
            this.toolTip1.SetToolTip(this.button3, "Help");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Clinical_Management.Properties.Resources.windel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(966, 690);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 44);
            this.button2.TabIndex = 76;
            this.toolTip1.SetToolTip(this.button2, "Delete Query");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Risk_Factor
            // 
            this.BackgroundImage = global::Clinical_Management.Properties.Resources.Photo_Archive1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.action_t);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.save_b);
            this.Controls.Add(this.color_c);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.query_c);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Risk_Factor";
            this.Text = "Risk Factor Alarm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Risk_Factor_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Risk_Factor_ResizeEnd);
            this.Load += new System.EventHandler(this.Risk_Factor_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox query_c;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox color_c;
        private System.Windows.Forms.Button save_b;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton inactive_r;
        private System.Windows.Forms.RadioButton active_r;
        private System.Windows.Forms.TextBox action_t;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
    }
}