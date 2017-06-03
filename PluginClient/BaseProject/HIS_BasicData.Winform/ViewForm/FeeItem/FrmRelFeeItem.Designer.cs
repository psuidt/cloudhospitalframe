namespace HIS_BasicData.Winform.ViewForm.FeeItem
{
    partial class FrmRelFeeItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelToolBar = new DevComponents.DotNetBar.PanelEx();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.cboStatID = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.tbKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnQuit = new DevComponents.DotNetBar.ButtonX();
            this.pagerCenterFeeItem = new EfwControls.CustomControl.Pager();
            this.dgCenterFeeItem = new EfwControls.CustomControl.DataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrAuditStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrMreType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrIsStop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Explain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCenterFeeItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolBar
            // 
            this.panelToolBar.AutoSize = true;
            this.panelToolBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelToolBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelToolBar.Controls.Add(this.btnAdd);
            this.panelToolBar.Controls.Add(this.cboStatID);
            this.panelToolBar.Controls.Add(this.labelX12);
            this.panelToolBar.Controls.Add(this.btnQuery);
            this.panelToolBar.Controls.Add(this.tbKey);
            this.panelToolBar.Controls.Add(this.labelX4);
            this.panelToolBar.Controls.Add(this.btnSave);
            this.panelToolBar.Controls.Add(this.btnQuit);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolBar.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(915, 31);
            this.panelToolBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelToolBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelToolBar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelToolBar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelToolBar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelToolBar.Style.GradientAngle = 90;
            this.panelToolBar.TabIndex = 165;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(666, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新建(F2)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboStatID
            // 
            this.cboStatID.DisplayMember = "StatName";
            this.cboStatID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatID.FormattingEnabled = true;
            this.cboStatID.ItemHeight = 19;
            this.cboStatID.Location = new System.Drawing.Point(73, 2);
            this.cboStatID.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatID.Name = "cboStatID";
            this.cboStatID.Size = new System.Drawing.Size(91, 25);
            this.cboStatID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboStatID.TabIndex = 1;
            this.cboStatID.ValueMember = "StatID";
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(9, 4);
            this.labelX12.Margin = new System.Windows.Forms.Padding(2);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(60, 21);
            this.labelX12.TabIndex = 231;
            this.labelX12.Text = "项目分类";
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(443, 2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 25);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询(F9)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbKey
            // 
            this.tbKey.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbKey.Border.Class = "TextBoxBorder";
            this.tbKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbKey.ForeColor = System.Drawing.Color.Black;
            this.tbKey.Location = new System.Drawing.Point(219, 2);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(220, 25);
            this.tbKey.TabIndex = 2;
            this.tbKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKey_KeyDown);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(168, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 21);
            this.labelX4.TabIndex = 168;
            this.labelX4.Text = "关键字";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(747, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "确定(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuit.Location = new System.Drawing.Point(828, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 25);
            this.btnQuit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "关闭(F7)";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // pagerCenterFeeItem
            // 
            this.pagerCenterFeeItem.BindDataControl = this.dgCenterFeeItem;
            this.pagerCenterFeeItem.DataSource = null;
            this.pagerCenterFeeItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerCenterFeeItem.IsPage = false;
            this.pagerCenterFeeItem.Location = new System.Drawing.Point(0, 408);
            this.pagerCenterFeeItem.Name = "pagerCenterFeeItem";
            this.pagerCenterFeeItem.pageNo = 1;
            this.pagerCenterFeeItem.pageSize = 20;
            this.pagerCenterFeeItem.PageSizeType = EfwControls.CustomControl.pageSizeType.Size20;
            this.pagerCenterFeeItem.Size = new System.Drawing.Size(915, 28);
            this.pagerCenterFeeItem.TabIndex = 7;
            this.pagerCenterFeeItem.totalRecord = 100;
            this.pagerCenterFeeItem.PageNoChanged += new EfwControls.CustomControl.PagerEventHandler(this.pagerCenterFeeItem_PageNoChanged);
            // 
            // dgCenterFeeItem
            // 
            this.dgCenterFeeItem.AllowSortWhenClickColumnHeader = false;
            this.dgCenterFeeItem.AllowUserToAddRows = false;
            this.dgCenterFeeItem.AllowUserToDeleteRows = false;
            this.dgCenterFeeItem.AllowUserToResizeColumns = false;
            this.dgCenterFeeItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgCenterFeeItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCenterFeeItem.BackgroundColor = System.Drawing.Color.White;
            this.dgCenterFeeItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCenterFeeItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCenterFeeItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.CenterItemCode,
            this.CenterItemName,
            this.StatName,
            this.StrAuditStatus,
            this.Unit,
            this.Price,
            this.StrMreType,
            this.StrIsStop,
            this.Explain});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCenterFeeItem.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgCenterFeeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCenterFeeItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgCenterFeeItem.HighlightSelectedColumnHeaders = false;
            this.dgCenterFeeItem.Location = new System.Drawing.Point(0, 31);
            this.dgCenterFeeItem.MultiSelect = false;
            this.dgCenterFeeItem.Name = "dgCenterFeeItem";
            this.dgCenterFeeItem.ReadOnly = true;
            this.dgCenterFeeItem.RowHeadersVisible = false;
            this.dgCenterFeeItem.RowHeadersWidth = 30;
            this.dgCenterFeeItem.RowTemplate.Height = 23;
            this.dgCenterFeeItem.SelectAllSignVisible = false;
            this.dgCenterFeeItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCenterFeeItem.SeqVisible = false;
            this.dgCenterFeeItem.SetCustomStyle = true;
            this.dgCenterFeeItem.Size = new System.Drawing.Size(915, 377);
            this.dgCenterFeeItem.TabIndex = 4;
            this.dgCenterFeeItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCenterFeeItem_CellDoubleClick);
            this.dgCenterFeeItem.CurrentCellChanged += new System.EventHandler(this.dgCenterFeeItem_CurrentCellChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FeeID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "中心项目ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CenterItemCode
            // 
            this.CenterItemCode.DataPropertyName = "CenterItemCode";
            this.CenterItemCode.HeaderText = "中心项目编码";
            this.CenterItemCode.MinimumWidth = 120;
            this.CenterItemCode.Name = "CenterItemCode";
            this.CenterItemCode.ReadOnly = true;
            this.CenterItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CenterItemCode.Width = 120;
            // 
            // CenterItemName
            // 
            this.CenterItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CenterItemName.DataPropertyName = "CenterItemName";
            this.CenterItemName.HeaderText = "中心项目名称";
            this.CenterItemName.MinimumWidth = 120;
            this.CenterItemName.Name = "CenterItemName";
            this.CenterItemName.ReadOnly = true;
            this.CenterItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StatName
            // 
            this.StatName.DataPropertyName = "StatName";
            this.StatName.HeaderText = "项目分类";
            this.StatName.Name = "StatName";
            this.StatName.ReadOnly = true;
            this.StatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StrAuditStatus
            // 
            this.StrAuditStatus.DataPropertyName = "StrAuditStatus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StrAuditStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.StrAuditStatus.HeaderText = "审核状态";
            this.StrAuditStatus.Name = "StrAuditStatus";
            this.StrAuditStatus.ReadOnly = true;
            this.StrAuditStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StrAuditStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StrAuditStatus.Width = 70;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "项目单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unit.Width = 80;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle5;
            this.Price.HeaderText = "项目单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StrMreType
            // 
            this.StrMreType.DataPropertyName = "StrMreType";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StrMreType.DefaultCellStyle = dataGridViewCellStyle6;
            this.StrMreType.HeaderText = "医保类型";
            this.StrMreType.Name = "StrMreType";
            this.StrMreType.ReadOnly = true;
            this.StrMreType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StrMreType.Width = 80;
            // 
            // StrIsStop
            // 
            this.StrIsStop.DataPropertyName = "StrIsStop";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StrIsStop.DefaultCellStyle = dataGridViewCellStyle7;
            this.StrIsStop.HeaderText = "状态";
            this.StrIsStop.Name = "StrIsStop";
            this.StrIsStop.ReadOnly = true;
            this.StrIsStop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StrIsStop.Width = 60;
            // 
            // Explain
            // 
            this.Explain.DataPropertyName = "Explain";
            this.Explain.HeaderText = "项目说明";
            this.Explain.Name = "Explain";
            this.Explain.ReadOnly = true;
            this.Explain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmRelFeeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 436);
            this.Controls.Add(this.dgCenterFeeItem);
            this.Controls.Add(this.pagerCenterFeeItem);
            this.Controls.Add(this.panelToolBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelFeeItem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关联中心收费项目";
            this.Load += new System.EventHandler(this.FrmRelFeeItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelFeeItem_KeyDown);
            this.panelToolBar.ResumeLayout(false);
            this.panelToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCenterFeeItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelToolBar;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnQuit;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.TextBoxX tbKey;
        private DevComponents.DotNetBar.LabelX labelX4;
        private EfwControls.CustomControl.Pager pagerCenterFeeItem;
        private EfwControls.CustomControl.DataGrid dgCenterFeeItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboStatID;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrAuditStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrMreType;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrIsStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Explain;
    }
}