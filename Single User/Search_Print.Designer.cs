namespace Clinical_Management
{
    partial class Search_Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_Print));
            this.search_b = new System.Windows.Forms.Button();
            this.name_t = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rest = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Invoice = new System.Windows.Forms.RadioButton();
            this.Del_print = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_b
            // 
            this.search_b.BackgroundImage = global::Clinical_Management.Properties.Resources.dcvbrfgt;
            this.search_b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.search_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_b.Location = new System.Drawing.Point(630, 79);
            this.search_b.Name = "search_b";
            this.search_b.Size = new System.Drawing.Size(47, 42);
            this.search_b.TabIndex = 2;
            this.toolTip1.SetToolTip(this.search_b, "Ã” ÃÊ");
            this.search_b.UseVisualStyleBackColor = true;
            this.search_b.Click += new System.EventHandler(this.search_b_Click);
            // 
            // name_t
            // 
            this.name_t.Location = new System.Drawing.Point(566, 52);
            this.name_t.Name = "name_t";
            this.name_t.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_t.Size = new System.Drawing.Size(168, 20);
            this.name_t.TabIndex = 1;
            this.name_t.Enter += new System.EventHandler(this.name_t_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(609, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "‰«„ Ê ‰«„ Œ«‰Ê«œêÌ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 587);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rest);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.Invoice);
            this.panel1.Location = new System.Drawing.Point(329, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 106);
            this.panel1.TabIndex = 4;
            // 
            // rest
            // 
            this.rest.AutoSize = true;
            this.rest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rest.Location = new System.Drawing.Point(16, 77);
            this.rest.Name = "rest";
            this.rest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rest.Size = new System.Drawing.Size(100, 17);
            this.rest.TabIndex = 2;
            this.rest.Text = "êÊ«ÂÌ «” —«Õ ";
            this.rest.UseVisualStyleBackColor = true;
            this.rest.CheckedChanged += new System.EventHandler(this.rest_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.Location = new System.Drawing.Point(48, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton1.Size = new System.Drawing.Size(69, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "—”Ìœ ÊÃÂ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Invoice
            // 
            this.Invoice.AutoSize = true;
            this.Invoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Invoice.Location = new System.Drawing.Point(42, 11);
            this.Invoice.Name = "Invoice";
            this.Invoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Invoice.Size = new System.Drawing.Size(77, 17);
            this.Invoice.TabIndex = 0;
            this.Invoice.Text = "’Ê— Õ”«»";
            this.Invoice.UseVisualStyleBackColor = true;
            this.Invoice.CheckedChanged += new System.EventHandler(this.Invoice_CheckedChanged);
            // 
            // Del_print
            // 
            this.Del_print.BackColor = System.Drawing.Color.Ivory;
            this.Del_print.BackgroundImage = global::Clinical_Management.Properties.Resources.Delete_All;
            this.Del_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Del_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Del_print.Enabled = false;
            this.Del_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Del_print.Location = new System.Drawing.Point(33, 52);
            this.Del_print.Name = "Del_print";
            this.Del_print.Size = new System.Drawing.Size(39, 34);
            this.Del_print.TabIndex = 5;
            this.toolTip1.SetToolTip(this.Del_print, "Õ–›  „«„ »«Ìê«‰Ì „Ê—œ «‰ Œ«» ‘œÂ");
            this.Del_print.UseVisualStyleBackColor = false;
            this.Del_print.Click += new System.EventHandler(this.Del_print_Click);
            // 
            // Search_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.Del_print);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_t);
            this.Controls.Add(this.search_b);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_Print";
            this.Text = "Ã” ÃÊÌ êÊ«ÂÌ Â«";
            this.ResizeEnd += new System.EventHandler(this.Search_Print_ResizeEnd);
            this.Load += new System.EventHandler(this.Search_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_b;
        private System.Windows.Forms.TextBox name_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Invoice;
        private System.Windows.Forms.RadioButton rest;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button Del_print;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}