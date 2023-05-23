namespace Clinical_Management
{
    partial class Rx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rx));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.change_b = new System.Windows.Forms.Button();
            this.changeall_b = new System.Windows.Forms.Button();
            this.ok_b = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 509);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.BulletIndent = 5;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.richTextBox1.Location = new System.Drawing.Point(22, 516);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(13, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(993, 169);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // change_b
            // 
            this.change_b.BackColor = System.Drawing.Color.Indigo;
            this.change_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.change_b.ForeColor = System.Drawing.Color.White;
            this.change_b.Location = new System.Drawing.Point(646, 689);
            this.change_b.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.change_b.Name = "change_b";
            this.change_b.Size = new System.Drawing.Size(153, 29);
            this.change_b.TabIndex = 2;
            this.change_b.Text = "Delete Last Line";
            this.change_b.UseVisualStyleBackColor = false;
            this.change_b.Click += new System.EventHandler(this.change_b_Click);
            // 
            // changeall_b
            // 
            this.changeall_b.BackColor = System.Drawing.Color.Indigo;
            this.changeall_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeall_b.ForeColor = System.Drawing.Color.White;
            this.changeall_b.Location = new System.Drawing.Point(807, 689);
            this.changeall_b.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.changeall_b.Name = "changeall_b";
            this.changeall_b.Size = new System.Drawing.Size(100, 29);
            this.changeall_b.TabIndex = 3;
            this.changeall_b.Text = "Clear All";
            this.changeall_b.UseVisualStyleBackColor = false;
            this.changeall_b.Click += new System.EventHandler(this.changeall_b_Click);
            // 
            // ok_b
            // 
            this.ok_b.BackColor = System.Drawing.Color.Indigo;
            this.ok_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_b.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ok_b.ForeColor = System.Drawing.Color.White;
            this.ok_b.Location = new System.Drawing.Point(915, 689);
            this.ok_b.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ok_b.Name = "ok_b";
            this.ok_b.Size = new System.Drawing.Size(100, 29);
            this.ok_b.TabIndex = 4;
            this.ok_b.Text = "u";
            this.ok_b.UseVisualStyleBackColor = false;
            this.ok_b.Click += new System.EventHandler(this.ok_b_Click);
            // 
            // Rx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 725);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ok_b);
            this.Controls.Add(this.changeall_b);
            this.Controls.Add(this.change_b);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Rx";
            this.Text = "Pharmaceuticals";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rx_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Rx_ResizeEnd);
            this.Load += new System.EventHandler(this.Rx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button change_b;
        private System.Windows.Forms.Button changeall_b;
        private System.Windows.Forms.Button ok_b;
    }
}