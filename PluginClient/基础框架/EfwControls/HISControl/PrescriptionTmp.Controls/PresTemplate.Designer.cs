namespace EfwControls.HISControl.PrescriptionTmp.Controls
{
    partial class PresTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresTemplate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treePres = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridPres = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMid = new System.Windows.Forms.RadioButton();
            this.rbWest = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.ckAll = new System.Windows.Forms.CheckBox();
            this.ck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPres)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 297);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treePres);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridPres);
            this.splitContainer1.Size = new System.Drawing.Size(677, 297);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 0;
            // 
            // treePres
            // 
            this.treePres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePres.ImageIndex = 0;
            this.treePres.ImageList = this.imageList1;
            this.treePres.Location = new System.Drawing.Point(0, 0);
            this.treePres.Name = "treePres";
            this.treePres.SelectedImageIndex = 0;
            this.treePres.Size = new System.Drawing.Size(225, 297);
            this.treePres.TabIndex = 0;
            this.treePres.DoubleClick += new System.EventHandler(this.treePres_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderClosed.png");
            this.imageList1.Images.SetKeyName(1, "FolderOpen.png");
            this.imageList1.Images.SetKeyName(2, "Document.png");
            // 
            // dataGridPres
            // 
            this.dataGridPres.AllowUserToAddRows = false;
            this.dataGridPres.AllowUserToDeleteRows = false;
            this.dataGridPres.AllowUserToResizeColumns = false;
            this.dataGridPres.AllowUserToResizeRows = false;
            this.dataGridPres.BackgroundColor = System.Drawing.Color.White;
            this.dataGridPres.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ck,
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridPres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPres.Location = new System.Drawing.Point(0, 0);
            this.dataGridPres.Name = "dataGridPres";
            this.dataGridPres.ReadOnly = true;
            this.dataGridPres.RowHeadersVisible = false;
            this.dataGridPres.RowTemplate.Height = 23;
            this.dataGridPres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPres.Size = new System.Drawing.Size(448, 297);
            this.dataGridPres.TabIndex = 0;
            this.dataGridPres.Click += new System.EventHandler(this.dataGridPres_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckAll);
            this.panel2.Controls.Add(this.rbMid);
            this.panel2.Controls.Add(this.rbWest);
            this.panel2.Controls.Add(this.rbAll);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 47);
            this.panel2.TabIndex = 1;
            // 
            // rbMid
            // 
            this.rbMid.AutoSize = true;
            this.rbMid.Location = new System.Drawing.Point(156, 12);
            this.rbMid.Name = "rbMid";
            this.rbMid.Size = new System.Drawing.Size(59, 16);
            this.rbMid.TabIndex = 4;
            this.rbMid.Text = "中草药";
            this.rbMid.UseVisualStyleBackColor = true;
            this.rbMid.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbWest
            // 
            this.rbWest.AutoSize = true;
            this.rbWest.Location = new System.Drawing.Point(61, 12);
            this.rbWest.Name = "rbWest";
            this.rbWest.Size = new System.Drawing.Size(89, 16);
            this.rbWest.TabIndex = 3;
            this.rbWest.Text = "西药/中成药";
            this.rbWest.UseVisualStyleBackColor = true;
            this.rbWest.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(8, 12);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(571, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(462, 12);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ckAll
            // 
            this.ckAll.AutoSize = true;
            this.ckAll.Checked = true;
            this.ckAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAll.Location = new System.Drawing.Point(229, 11);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(78, 16);
            this.ckAll.TabIndex = 5;
            this.ckAll.Text = "全选/反选";
            this.ckAll.UseVisualStyleBackColor = true;
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // ck
            // 
            this.ck.DataPropertyName = "ck";
            this.ck.FalseValue = "0";
            this.ck.HeaderText = "";
            this.ck.Name = "ck";
            this.ck.ReadOnly = true;
            this.ck.TrueValue = "1";
            this.ck.Width = 20;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "GroupID";
            this.Column9.HeaderText = "组号";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 60;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FeeID";
            this.Column1.HeaderText = "项目编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FeeName";
            this.Column2.HeaderText = "项目名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Dosage";
            this.Column3.HeaderText = "剂量";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DosageUnit";
            this.Column4.HeaderText = "单位";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "FrequencyName";
            this.Column5.HeaderText = "频次";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ChannelName";
            this.Column6.HeaderText = "用法";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Days";
            this.Column7.HeaderText = "天数";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 70;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Memo";
            this.Column8.HeaderText = "嘱托";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // PresTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 344);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Name = "PresTemplate";
            this.Text = "处方模板";
            this.Load += new System.EventHandler(this.PresTemplate_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPres)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TreeView treePres;
        private System.Windows.Forms.DataGridView dataGridPres;
        private System.Windows.Forms.RadioButton rbMid;
        private System.Windows.Forms.RadioButton rbWest;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox ckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}