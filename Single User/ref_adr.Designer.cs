namespace Clinical_Management
{
    partial class ref_adr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ref_adr));
            this.adr2_t = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.adr3_t = new System.Windows.Forms.TextBox();
            this.adr4_t = new System.Windows.Forms.TextBox();
            this.adr5_t = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // adr2_t
            // 
            this.adr2_t.Location = new System.Drawing.Point(8, 37);
            this.adr2_t.Name = "adr2_t";
            this.adr2_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.adr2_t.Size = new System.Drawing.Size(409, 20);
            this.adr2_t.TabIndex = 87;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.Color.DarkGreen;
            this.label13.Location = new System.Drawing.Point(185, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 89;
            this.label13.Text = "آدرس";
            // 
            // adr3_t
            // 
            this.adr3_t.Location = new System.Drawing.Point(8, 63);
            this.adr3_t.Name = "adr3_t";
            this.adr3_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.adr3_t.Size = new System.Drawing.Size(409, 20);
            this.adr3_t.TabIndex = 91;
            // 
            // adr4_t
            // 
            this.adr4_t.Location = new System.Drawing.Point(8, 89);
            this.adr4_t.Name = "adr4_t";
            this.adr4_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.adr4_t.Size = new System.Drawing.Size(409, 20);
            this.adr4_t.TabIndex = 95;
            // 
            // adr5_t
            // 
            this.adr5_t.Location = new System.Drawing.Point(8, 115);
            this.adr5_t.Name = "adr5_t";
            this.adr5_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.adr5_t.Size = new System.Drawing.Size(409, 20);
            this.adr5_t.TabIndex = 99;
            // 
            // ref_adr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 159);
            this.Controls.Add(this.adr5_t);
            this.Controls.Add(this.adr4_t);
            this.Controls.Add(this.adr3_t);
            this.Controls.Add(this.adr2_t);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ref_adr";
            this.ResizeEnd += new System.EventHandler(this.ref_adr_ResizeEnd);
            this.Load += new System.EventHandler(this.ref_adr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox adr2_t;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox adr3_t;
        private System.Windows.Forms.TextBox adr4_t;
        private System.Windows.Forms.TextBox adr5_t;
    }
}