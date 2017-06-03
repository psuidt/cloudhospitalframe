namespace WinMainUIFrame.Winform.ViewForm
{
    partial class FrmReportConfigure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportConfigure));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            EfwControls.CustomControl.DataGridViewSelectionCard dataGridViewSelectionCard1 = new EfwControls.CustomControl.DataGridViewSelectionCard();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnSet = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.gridReport = new EfwControls.CustomControl.GridBoxCard();
            this.EnumValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSave,
            this.btnSet,
            this.btnClose});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(642, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSet
            // 
            this.btnSet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.Name = "btnSet";
            this.btnSet.Text = "批量设置";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClose
            // 
            this.btnClose.BeginGroup = true;
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridReport
            // 
            this.gridReport.AllowSortWhenClickColumnHeader = false;
            this.gridReport.AllowUserToAddRows = false;
            this.gridReport.AllowUserToDeleteRows = false;
            this.gridReport.AllowUserToResizeColumns = false;
            this.gridReport.AllowUserToResizeRows = false;
            this.gridReport.BackgroundColor = System.Drawing.Color.White;
            this.gridReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnumValue,
            this.ReportTitle,
            this.PrintIndex});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReport.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridReport.HideSelectionCardWhenCustomInput = false;
            this.gridReport.HighlightSelectedColumnHeaders = false;
            this.gridReport.IsInputNumSelectedCard = false;
            this.gridReport.IsShowLetter = false;
            this.gridReport.IsShowPage = false;
            this.gridReport.Location = new System.Drawing.Point(0, 25);
            this.gridReport.Name = "gridReport";
            this.gridReport.RowHeadersWidth = 30;
            this.gridReport.RowTemplate.Height = 23;
            this.gridReport.SelectAllSignVisible = false;
            dataGridViewSelectionCard1.BindColumnIndex = 0;
            dataGridViewSelectionCard1.CardColumn = null;
            dataGridViewSelectionCard1.CardSize = new System.Drawing.Size(350, 276);
            dataGridViewSelectionCard1.DataSource = null;
            dataGridViewSelectionCard1.FilterResult = null;
            dataGridViewSelectionCard1.IsPage = true;
            dataGridViewSelectionCard1.Memo = null;
            dataGridViewSelectionCard1.PageTotalRecord = 0;
            dataGridViewSelectionCard1.QueryFields = new string[] {
        ""};
            dataGridViewSelectionCard1.QueryFieldsString = "";
            dataGridViewSelectionCard1.SelectCardFilterType = EfwControls.CustomControl.MatchModes.ByAnyString;
            dataGridViewSelectionCard1.ShowCardColumns = null;
            this.gridReport.SelectionCards = new EfwControls.CustomControl.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard1};
            this.gridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReport.SelectionNumKeyBoards = null;
            this.gridReport.SeqVisible = true;
            this.gridReport.SetCustomStyle = false;
            this.gridReport.Size = new System.Drawing.Size(642, 346);
            this.gridReport.TabIndex = 3;
            this.gridReport.SelectCardRowSelected += new EfwControls.CustomControl.OnSelectCardRowSelectedHandle(this.gridReport_SelectCardRowSelected);
            // 
            // EnumValue
            // 
            this.EnumValue.DataPropertyName = "EnumValue";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EnumValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.EnumValue.HeaderText = "报表编号";
            this.EnumValue.MinimumWidth = 120;
            this.EnumValue.Name = "EnumValue";
            this.EnumValue.ReadOnly = true;
            this.EnumValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EnumValue.Width = 150;
            // 
            // ReportTitle
            // 
            this.ReportTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReportTitle.DataPropertyName = "ReportTitle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ReportTitle.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReportTitle.HeaderText = "报表名称";
            this.ReportTitle.Name = "ReportTitle";
            this.ReportTitle.ReadOnly = true;
            this.ReportTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrintIndex
            // 
            this.PrintIndex.DataPropertyName = "PrintIndex";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PrintIndex.DefaultCellStyle = dataGridViewCellStyle4;
            this.PrintIndex.HeaderText = "打印机配置";
            this.PrintIndex.MinimumWidth = 150;
            this.PrintIndex.Name = "PrintIndex";
            this.PrintIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PrintIndex.Width = 150;
            // 
            // FrmReportConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 371);
            this.Controls.Add(this.gridReport);
            this.Controls.Add(this.bar1);
            this.Name = "FrmReportConfigure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表配置打印机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReportConfigure_FormClosing);
            this.Load += new System.EventHandler(this.FrmReportConfigure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private EfwControls.CustomControl.GridBoxCard gridReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnumValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintIndex;
        private DevComponents.DotNetBar.ButtonItem btnSet;
    }
}