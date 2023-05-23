namespace Clinical_Management
{
    partial class Full_Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Full_Summary));
            this.full_r = new System.Windows.Forms.RadioButton();
            this.summary_r = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // full_r
            // 
            this.full_r.AutoSize = true;
            this.full_r.BackColor = System.Drawing.Color.Transparent;
            this.full_r.Cursor = System.Windows.Forms.Cursors.Hand;
            this.full_r.Font = new System.Drawing.Font("Arial Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.full_r.ForeColor = System.Drawing.Color.Yellow;
            this.full_r.Location = new System.Drawing.Point(106, 20);
            this.full_r.Name = "full_r";
            this.full_r.Size = new System.Drawing.Size(64, 27);
            this.full_r.TabIndex = 0;
            this.full_r.Text = "Full";
            this.full_r.UseVisualStyleBackColor = false;
            this.full_r.Click += new System.EventHandler(this.full_r_Click);
            // 
            // summary_r
            // 
            this.summary_r.AutoSize = true;
            this.summary_r.BackColor = System.Drawing.Color.Transparent;
            this.summary_r.Checked = true;
            this.summary_r.Cursor = System.Windows.Forms.Cursors.Hand;
            this.summary_r.Font = new System.Drawing.Font("Arial Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary_r.ForeColor = System.Drawing.Color.Yellow;
            this.summary_r.Location = new System.Drawing.Point(106, 63);
            this.summary_r.Name = "summary_r";
            this.summary_r.Size = new System.Drawing.Size(118, 27);
            this.summary_r.TabIndex = 1;
            this.summary_r.TabStop = true;
            this.summary_r.Text = "Summary";
            this.summary_r.UseVisualStyleBackColor = false;
            this.summary_r.MouseClick += new System.Windows.Forms.MouseEventHandler(this.summary_r_MouseClick);
            this.summary_r.Click += new System.EventHandler(this.summary_r_Click);
            // 
            // Full_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Clinical_Management.Properties.Resources._0113;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(301, 119);
            this.Controls.Add(this.summary_r);
            this.Controls.Add(this.full_r);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Full_Summary";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton full_r;
        private System.Windows.Forms.RadioButton summary_r;
    }
}