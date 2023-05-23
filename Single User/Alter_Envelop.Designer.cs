namespace Clinical_Management
{
    partial class Alter_Envelop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alter_Envelop));
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.mytextbox = new System.Windows.Forms.TextBox();
            this.mylistbox = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(273, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(47, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Add/Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // mytextbox
            // 
            this.mytextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.mytextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.mytextbox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.mytextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mytextbox.Location = new System.Drawing.Point(47, 160);
            this.mytextbox.Name = "mytextbox";
            this.mytextbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mytextbox.Size = new System.Drawing.Size(273, 20);
            this.mytextbox.TabIndex = 21;
            this.mytextbox.Enter += new System.EventHandler(this.mytextbox_Enter);
            // 
            // mylistbox
            // 
            this.mylistbox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.mylistbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mylistbox.FormattingEnabled = true;
            this.mylistbox.Location = new System.Drawing.Point(47, 74);
            this.mylistbox.Name = "mylistbox";
            this.mylistbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mylistbox.Size = new System.Drawing.Size(273, 82);
            this.mylistbox.TabIndex = 20;
            this.mylistbox.SelectedIndexChanged += new System.EventHandler(this.mylistbox_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "‰«„ Â„ﬂ«—«‰ „Œ«ÿ»"});
            this.comboBox1.Location = new System.Drawing.Point(47, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(273, 21);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(44, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "To Edit : Delete, then add the correct word";
            // 
            // Alter_Envelop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 299);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.mytextbox);
            this.Controls.Add(this.mylistbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Alter_Envelop";
            this.Text = "Alter Combos";
            this.ResizeEnd += new System.EventHandler(this.Alter_Envelop_ResizeEnd);
            this.Load += new System.EventHandler(this.Alter_Envelop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox mytextbox;
        private System.Windows.Forms.ListBox mylistbox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}