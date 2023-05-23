namespace Clinical_Management
{
    partial class Paziresh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paziresh));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dselectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mselectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.doctorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.causeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bimehDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bimehnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expireDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pazireshBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmDataSet12 = new Clinical_Management.cmDataSet12();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pazireshTableAdapter = new Clinical_Management.cmDataSet12TableAdapters.pazireshTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pazireshBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmDataSet12)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column25,
            this.rowDataGridViewTextBoxColumn,
            this.dselectDataGridViewTextBoxColumn,
            this.Column27,
            this.mselectDataGridViewTextBoxColumn,
            this.Column29,
            this.doctorDataGridViewTextBoxColumn,
            this.prfDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.fnameDataGridViewTextBoxColumn,
            this.familyDataGridViewTextBoxColumn,
            this.causeDataGridViewTextBoxColumn,
            this.bimehDataGridViewTextBoxColumn,
            this.bimehnoDataGridViewTextBoxColumn,
            this.expireDataGridViewTextBoxColumn,
            this.serialDataGridViewTextBoxColumn,
            this.nidDataGridViewTextBoxColumn,
            this.visitDataGridViewTextBoxColumn,
            this.consultDataGridViewTextBoxColumn,
            this.service1DataGridViewTextBoxColumn,
            this.service2DataGridViewTextBoxColumn,
            this.incomeDataGridViewTextBoxColumn,
            this.retDataGridViewTextBoxColumn,
            this.parDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.pazireshBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.Color.Black;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Size = new System.Drawing.Size(1024, 617);
            this.dataGridView2.TabIndex = 42;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView2_UserAddedRow);
            this.dataGridView2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView2_UserDeletingRow);
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "‰„«Ì‘ —œÌ› Å–Ì—‘";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Text = "";
            this.Column1.ToolTipText = "›—„ ⁄„ÊœÌ";
            this.Column1.Width = 15;
            // 
            // Column25
            // 
            this.Column25.Frozen = true;
            this.Column25.HeaderText = "Õ–›";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column25.Width = 45;
            // 
            // rowDataGridViewTextBoxColumn
            // 
            this.rowDataGridViewTextBoxColumn.DataPropertyName = "row";
            this.rowDataGridViewTextBoxColumn.Frozen = true;
            this.rowDataGridViewTextBoxColumn.HeaderText = "—œÌ›";
            this.rowDataGridViewTextBoxColumn.Name = "rowDataGridViewTextBoxColumn";
            this.rowDataGridViewTextBoxColumn.ReadOnly = true;
            this.rowDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dselectDataGridViewTextBoxColumn
            // 
            this.dselectDataGridViewTextBoxColumn.DataPropertyName = "dselect";
            this.dselectDataGridViewTextBoxColumn.Frozen = true;
            this.dselectDataGridViewTextBoxColumn.HeaderText = "«‰ Œ«» Å“‘ﬂ";
            this.dselectDataGridViewTextBoxColumn.Name = "dselectDataGridViewTextBoxColumn";
            this.dselectDataGridViewTextBoxColumn.ReadOnly = true;
            this.dselectDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column27
            // 
            this.Column27.Frozen = true;
            this.Column27.HeaderText = "PP";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column27.Text = "";
            this.Column27.ToolTipText = "Patient Profile";
            this.Column27.Width = 15;
            // 
            // mselectDataGridViewTextBoxColumn
            // 
            this.mselectDataGridViewTextBoxColumn.DataPropertyName = "mselect";
            this.mselectDataGridViewTextBoxColumn.Frozen = true;
            this.mselectDataGridViewTextBoxColumn.HeaderText = "«‰ Œ«» „‰‘Ì";
            this.mselectDataGridViewTextBoxColumn.Name = "mselectDataGridViewTextBoxColumn";
            this.mselectDataGridViewTextBoxColumn.ReadOnly = true;
            this.mselectDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column29
            // 
            this.Column29.Frozen = true;
            this.Column29.HeaderText = "Å—Ê‰œÂ";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column29.ToolTipText = "Å—Ê‰œÂ";
            this.Column29.Width = 15;
            // 
            // doctorDataGridViewTextBoxColumn
            // 
            this.doctorDataGridViewTextBoxColumn.DataPropertyName = "doctor";
            this.doctorDataGridViewTextBoxColumn.HeaderText = "‰«„ Å“‘ﬂ";
            this.doctorDataGridViewTextBoxColumn.Name = "doctorDataGridViewTextBoxColumn";
            this.doctorDataGridViewTextBoxColumn.ReadOnly = true;
            this.doctorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // prfDataGridViewTextBoxColumn
            // 
            this.prfDataGridViewTextBoxColumn.DataPropertyName = "prf";
            this.prfDataGridViewTextBoxColumn.HeaderText = "‰Ê⁄  Œ’’";
            this.prfDataGridViewTextBoxColumn.Name = "prfDataGridViewTextBoxColumn";
            this.prfDataGridViewTextBoxColumn.ReadOnly = true;
            this.prfDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "⁄‰Ê«‰";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fnameDataGridViewTextBoxColumn
            // 
            this.fnameDataGridViewTextBoxColumn.DataPropertyName = "fname";
            this.fnameDataGridViewTextBoxColumn.HeaderText = "‰«„ «Ê·";
            this.fnameDataGridViewTextBoxColumn.Name = "fnameDataGridViewTextBoxColumn";
            this.fnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fnameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // familyDataGridViewTextBoxColumn
            // 
            this.familyDataGridViewTextBoxColumn.DataPropertyName = "family";
            this.familyDataGridViewTextBoxColumn.HeaderText = "‰«„ Œ«‰Ê«œêÌ";
            this.familyDataGridViewTextBoxColumn.Name = "familyDataGridViewTextBoxColumn";
            this.familyDataGridViewTextBoxColumn.ReadOnly = true;
            this.familyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // causeDataGridViewTextBoxColumn
            // 
            this.causeDataGridViewTextBoxColumn.DataPropertyName = "cause";
            this.causeDataGridViewTextBoxColumn.HeaderText = "⁄·  „—«Ã⁄Â";
            this.causeDataGridViewTextBoxColumn.Name = "causeDataGridViewTextBoxColumn";
            this.causeDataGridViewTextBoxColumn.ReadOnly = true;
            this.causeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bimehDataGridViewTextBoxColumn
            // 
            this.bimehDataGridViewTextBoxColumn.DataPropertyName = "bimeh";
            this.bimehDataGridViewTextBoxColumn.HeaderText = "‰Ê⁄ »Ì„Â";
            this.bimehDataGridViewTextBoxColumn.Name = "bimehDataGridViewTextBoxColumn";
            this.bimehDataGridViewTextBoxColumn.ReadOnly = true;
            this.bimehDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bimehnoDataGridViewTextBoxColumn
            // 
            this.bimehnoDataGridViewTextBoxColumn.DataPropertyName = "bimehno";
            this.bimehnoDataGridViewTextBoxColumn.HeaderText = "‘„«—Â œ› —çÂ »Ì„Â";
            this.bimehnoDataGridViewTextBoxColumn.Name = "bimehnoDataGridViewTextBoxColumn";
            this.bimehnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.bimehnoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // expireDataGridViewTextBoxColumn
            // 
            this.expireDataGridViewTextBoxColumn.DataPropertyName = "expire";
            this.expireDataGridViewTextBoxColumn.HeaderText = " «—ÌŒ «⁄ »«—";
            this.expireDataGridViewTextBoxColumn.Name = "expireDataGridViewTextBoxColumn";
            this.expireDataGridViewTextBoxColumn.ReadOnly = true;
            this.expireDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // serialDataGridViewTextBoxColumn
            // 
            this.serialDataGridViewTextBoxColumn.DataPropertyName = "serial";
            this.serialDataGridViewTextBoxColumn.HeaderText = "‘„«—Â ”—Ì«· »Ì„Â";
            this.serialDataGridViewTextBoxColumn.Name = "serialDataGridViewTextBoxColumn";
            this.serialDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nidDataGridViewTextBoxColumn
            // 
            this.nidDataGridViewTextBoxColumn.DataPropertyName = "nid";
            this.nidDataGridViewTextBoxColumn.HeaderText = "ﬂœ „·Ì";
            this.nidDataGridViewTextBoxColumn.Name = "nidDataGridViewTextBoxColumn";
            this.nidDataGridViewTextBoxColumn.ReadOnly = true;
            this.nidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // visitDataGridViewTextBoxColumn
            // 
            this.visitDataGridViewTextBoxColumn.DataPropertyName = "visit";
            this.visitDataGridViewTextBoxColumn.HeaderText = "Õﬁ ÊÌ“Ì ";
            this.visitDataGridViewTextBoxColumn.Name = "visitDataGridViewTextBoxColumn";
            this.visitDataGridViewTextBoxColumn.ReadOnly = true;
            this.visitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // consultDataGridViewTextBoxColumn
            // 
            this.consultDataGridViewTextBoxColumn.DataPropertyName = "consult";
            this.consultDataGridViewTextBoxColumn.HeaderText = "Õﬁ „‘«Ê—Â";
            this.consultDataGridViewTextBoxColumn.Name = "consultDataGridViewTextBoxColumn";
            this.consultDataGridViewTextBoxColumn.ReadOnly = true;
            this.consultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // service1DataGridViewTextBoxColumn
            // 
            this.service1DataGridViewTextBoxColumn.DataPropertyName = "service1";
            this.service1DataGridViewTextBoxColumn.HeaderText = "”—ÊÌ” Â«Ì œÌê—";
            this.service1DataGridViewTextBoxColumn.Name = "service1DataGridViewTextBoxColumn";
            this.service1DataGridViewTextBoxColumn.ReadOnly = true;
            this.service1DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // service2DataGridViewTextBoxColumn
            // 
            this.service2DataGridViewTextBoxColumn.DataPropertyName = "service2";
            this.service2DataGridViewTextBoxColumn.HeaderText = "*”—ÊÌ” Â«Ì œÌê—";
            this.service2DataGridViewTextBoxColumn.Name = "service2DataGridViewTextBoxColumn";
            this.service2DataGridViewTextBoxColumn.ReadOnly = true;
            this.service2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // incomeDataGridViewTextBoxColumn
            // 
            this.incomeDataGridViewTextBoxColumn.DataPropertyName = "income";
            this.incomeDataGridViewTextBoxColumn.HeaderText = "œ—¬„œÂ«Ì œÌê—";
            this.incomeDataGridViewTextBoxColumn.Name = "incomeDataGridViewTextBoxColumn";
            this.incomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.incomeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // retDataGridViewTextBoxColumn
            // 
            this.retDataGridViewTextBoxColumn.DataPropertyName = "ret";
            this.retDataGridViewTextBoxColumn.HeaderText = "⁄Êœ  ÊÃÂ";
            this.retDataGridViewTextBoxColumn.Name = "retDataGridViewTextBoxColumn";
            this.retDataGridViewTextBoxColumn.ReadOnly = true;
            this.retDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // parDataGridViewTextBoxColumn
            // 
            this.parDataGridViewTextBoxColumn.DataPropertyName = "par";
            this.parDataGridViewTextBoxColumn.HeaderText = "‘„«—Â Å—Ê‰œÂ";
            this.parDataGridViewTextBoxColumn.Name = "parDataGridViewTextBoxColumn";
            this.parDataGridViewTextBoxColumn.ReadOnly = true;
            this.parDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pazireshBindingSource
            // 
            this.pazireshBindingSource.DataMember = "paziresh";
            this.pazireshBindingSource.DataSource = this.cmDataSet12;
            // 
            // cmDataSet12
            // 
            this.cmDataSet12.DataSetName = "cmDataSet12";
            this.cmDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(985, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "œ—Ã";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pazireshTableAdapter
            // 
            this.pazireshTableAdapter.ClearBeforeFill = true;
            // 
            // Paziresh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 617);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Paziresh";
            this.Text = "Å–Ì—‘";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Paziresh_FormClosing);
            this.Load += new System.EventHandler(this.Paziresh_Load);
            this.ResizeEnd += new System.EventHandler(this.Paziresh_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pazireshBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmDataSet12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private cmDataSet12 cmDataSet12;
        private System.Windows.Forms.BindingSource pazireshBindingSource;
        private Clinical_Management.cmDataSet12TableAdapters.pazireshTableAdapter pazireshTableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dselectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column27;
        private System.Windows.Forms.DataGridViewButtonColumn mselectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn causeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bimehDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bimehnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expireDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn service1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn service2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parDataGridViewTextBoxColumn;
    }
}