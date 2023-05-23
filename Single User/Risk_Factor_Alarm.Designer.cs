namespace Clinical_Management
{
    partial class Risk_Factor_Alarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Risk_Factor_Alarm));
            this.query_t = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.action_t = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // query_t
            // 
            this.query_t.BackColor = System.Drawing.Color.GhostWhite;
            this.query_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.query_t.Location = new System.Drawing.Point(-2, 1);
            this.query_t.Name = "query_t";
            this.query_t.ReadOnly = true;
            this.query_t.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.query_t.ShowSelectionMargin = true;
            this.query_t.Size = new System.Drawing.Size(257, 119);
            this.query_t.TabIndex = 3;
            this.query_t.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // action_t
            // 
            this.action_t.BackColor = System.Drawing.Color.AntiqueWhite;
            this.action_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.action_t.Location = new System.Drawing.Point(-2, 122);
            this.action_t.Name = "action_t";
            this.action_t.ReadOnly = true;
            this.action_t.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.action_t.ShowSelectionMargin = true;
            this.action_t.Size = new System.Drawing.Size(257, 71);
            this.action_t.TabIndex = 4;
            this.action_t.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Clinical_Management.Properties.Resources.red;
            this.pictureBox1.Location = new System.Drawing.Point(254, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Risk_Factor_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(298, 193);
            this.Controls.Add(this.action_t);
            this.Controls.Add(this.query_t);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Risk_Factor_Alarm";
            this.ShowInTaskbar = false;
            this.Text = "Risk Factor Alarm";
            this.Load += new System.EventHandler(this.Risk_Factor_Alarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox query_t;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox action_t;
    }
}