namespace HIS_BasicData.Winform.ViewForm.FeeItem
{
    partial class FrmFeeItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeeItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.WorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.cboSearchStatID = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboQueryWorker = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboQueryAudit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnQuit = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.cboQueryStop = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.cboStatID = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.tbUnit = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.diPrice = new DevComponents.Editors.DoubleInput();
            this.tbCenterItemCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.tbExplain = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.tbCenterItemName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.barCFeeItem = new DevComponents.DotNetBar.Bar();
            this.toolbarAdd = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarFlag = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarAudit = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.dgCenterFeeItem = new EfwControls.CustomControl.DataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrAuditStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrIsStop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Explain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagerCenterFeeItem = new EfwControls.CustomControl.Pager();
            this.frmCFeeItemForm = new EfwControls.CustomControl.frmForm(this.components);
            this.panelEx4.SuspendLayout();
            this.panelEx6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diPrice)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCFeeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCenterFeeItem)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkId
            // 
            this.WorkId.DataPropertyName = "WorkId";
            this.WorkId.HeaderText = "ID";
            this.WorkId.Name = "WorkId";
            this.WorkId.ReadOnly = true;
            this.WorkId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WorkId.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "WorkNo";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "WorkName";
            this.Column3.HeaderText = "性别";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Memo";
            this.Column4.HeaderText = "出生日期";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.cboSearchStatID);
            this.panelEx4.Controls.Add(this.labelX6);
            this.panelEx4.Controls.Add(this.labelX4);
            this.panelEx4.Controls.Add(this.cboQueryWorker);
            this.panelEx4.Controls.Add(this.cboQueryAudit);
            this.panelEx4.Controls.Add(this.labelX3);
            this.panelEx4.Controls.Add(this.tbKey);
            this.panelEx4.Controls.Add(this.btnQuit);
            this.panelEx4.Controls.Add(this.labelX2);
            this.panelEx4.Controls.Add(this.labelX1);
            this.panelEx4.Controls.Add(this.btnQuery);
            this.panelEx4.Controls.Add(this.cboQueryStop);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(1223, 35);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 27;
            // 
            // cboSearchStatID
            // 
            // 
            // 
            // 
            this.cboSearchStatID.Border.Class = "TextBoxBorder";
            this.cboSearchStatID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboSearchStatID.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboSearchStatID.ButtonCustom.Image")));
            this.cboSearchStatID.ButtonCustom.Visible = true;
            this.cboSearchStatID.CardColumn = null;
            this.cboSearchStatID.DisplayField = "";
            this.cboSearchStatID.IsEnterShowCard = true;
            this.cboSearchStatID.IsNumSelected = false;
            this.cboSearchStatID.IsPage = true;
            this.cboSearchStatID.IsShowLetter = false;
            this.cboSearchStatID.IsShowPage = false;
            this.cboSearchStatID.IsShowSeq = true;
            this.cboSearchStatID.Location = new System.Drawing.Point(588, 7);
            this.cboSearchStatID.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cboSearchStatID.MemberField = "";
            this.cboSearchStatID.MemberValue = null;
            this.cboSearchStatID.Name = "cboSearchStatID";
            this.cboSearchStatID.QueryFields = new string[] {
        ""};
            this.cboSearchStatID.QueryFieldsString = "";
            this.cboSearchStatID.SelectedValue = null;
            this.cboSearchStatID.ShowCardColumns = null;
            this.cboSearchStatID.ShowCardDataSource = null;
            this.cboSearchStatID.ShowCardHeight = 0;
            this.cboSearchStatID.ShowCardWidth = 0;
            this.cboSearchStatID.Size = new System.Drawing.Size(221, 21);
            this.cboSearchStatID.TabIndex = 255;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(524, 8);
            this.labelX6.Margin = new System.Windows.Forms.Padding(2);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(56, 18);
            this.labelX6.TabIndex = 254;
            this.labelX6.Text = "项目分类";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(819, 8);
            this.labelX4.Name = "labelX4";
            this.labelX4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX4.Size = new System.Drawing.Size(44, 18);
            this.labelX4.TabIndex = 34;
            this.labelX4.Text = "关键字";
            // 
            // cboQueryWorker
            // 
            this.cboQueryWorker.DisplayMember = "WorkName";
            this.cboQueryWorker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQueryWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryWorker.FormattingEnabled = true;
            this.cboQueryWorker.ItemHeight = 15;
            this.cboQueryWorker.Location = new System.Drawing.Point(395, 7);
            this.cboQueryWorker.Name = "cboQueryWorker";
            this.cboQueryWorker.Size = new System.Drawing.Size(121, 21);
            this.cboQueryWorker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboQueryWorker.TabIndex = 3;
            this.cboQueryWorker.ValueMember = "WorkId";
            // 
            // cboQueryAudit
            // 
            this.cboQueryAudit.DisplayMember = "Text";
            this.cboQueryAudit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQueryAudit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryAudit.FormattingEnabled = true;
            this.cboQueryAudit.ItemHeight = 15;
            this.cboQueryAudit.Location = new System.Drawing.Point(47, 7);
            this.cboQueryAudit.Name = "cboQueryAudit";
            this.cboQueryAudit.Size = new System.Drawing.Size(121, 21);
            this.cboQueryAudit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboQueryAudit.TabIndex = 1;
            this.cboQueryAudit.ValueMember = "Value";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(10, 8);
            this.labelX3.Name = "labelX3";
            this.labelX3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX3.Size = new System.Drawing.Size(31, 18);
            this.labelX3.TabIndex = 32;
            this.labelX3.Text = "审核";
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
            this.tbKey.Location = new System.Drawing.Point(864, 7);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(175, 21);
            this.tbKey.TabIndex = 4;
            // 
            // btnQuit
            // 
            this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuit.Location = new System.Drawing.Point(1125, 6);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 22);
            this.btnQuit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuit.TabIndex = 250;
            this.btnQuit.Text = "关闭(F7)";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(171, 8);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX2.Size = new System.Drawing.Size(31, 18);
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "状态";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(332, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 27;
            this.labelX1.Text = "创建机构";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(1045, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 22);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询(F9)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboQueryStop
            // 
            this.cboQueryStop.DisplayMember = "Text";
            this.cboQueryStop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQueryStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryStop.FormattingEnabled = true;
            this.cboQueryStop.ItemHeight = 15;
            this.cboQueryStop.Location = new System.Drawing.Point(208, 7);
            this.cboQueryStop.Name = "cboQueryStop";
            this.cboQueryStop.Size = new System.Drawing.Size(121, 21);
            this.cboQueryStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboQueryStop.TabIndex = 2;
            this.cboQueryStop.ValueMember = "Value";
            // 
            // panelEx6
            // 
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.cboStatID);
            this.panelEx6.Controls.Add(this.tbUnit);
            this.panelEx6.Controls.Add(this.btnCancel);
            this.panelEx6.Controls.Add(this.btnSave);
            this.panelEx6.Controls.Add(this.diPrice);
            this.panelEx6.Controls.Add(this.tbCenterItemCode);
            this.panelEx6.Controls.Add(this.labelX11);
            this.panelEx6.Controls.Add(this.labelX22);
            this.panelEx6.Controls.Add(this.labelX14);
            this.panelEx6.Controls.Add(this.labelX12);
            this.panelEx6.Controls.Add(this.tbExplain);
            this.panelEx6.Controls.Add(this.labelX21);
            this.panelEx6.Controls.Add(this.tbCenterItemName);
            this.panelEx6.Controls.Add(this.labelX17);
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx6.Location = new System.Drawing.Point(867, 35);
            this.panelEx6.Margin = new System.Windows.Forms.Padding(2);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(356, 423);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 32;
            // 
            // cboStatID
            // 
            // 
            // 
            // 
            this.cboStatID.Border.Class = "TextBoxBorder";
            this.cboStatID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboStatID.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboStatID.ButtonCustom.Image")));
            this.cboStatID.ButtonCustom.Visible = true;
            this.cboStatID.CardColumn = null;
            this.cboStatID.DisplayField = "";
            this.cboStatID.IsEnterShowCard = true;
            this.cboStatID.IsNumSelected = false;
            this.cboStatID.IsPage = true;
            this.cboStatID.IsShowLetter = false;
            this.cboStatID.IsShowPage = false;
            this.cboStatID.IsShowSeq = true;
            this.cboStatID.Location = new System.Drawing.Point(83, 67);
            this.cboStatID.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cboStatID.MemberField = "";
            this.cboStatID.MemberValue = null;
            this.cboStatID.Name = "cboStatID";
            this.cboStatID.QueryFields = new string[] {
        ""};
            this.cboStatID.QueryFieldsString = "";
            this.cboStatID.SelectedValue = null;
            this.cboStatID.ShowCardColumns = null;
            this.cboStatID.ShowCardDataSource = null;
            this.cboStatID.ShowCardHeight = 0;
            this.cboStatID.ShowCardWidth = 0;
            this.cboStatID.Size = new System.Drawing.Size(255, 21);
            this.cboStatID.TabIndex = 253;
            // 
            // tbUnit
            // 
            this.tbUnit.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbUnit.Border.Class = "TextBoxBorder";
            this.tbUnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUnit.ForeColor = System.Drawing.Color.Black;
            this.tbUnit.Location = new System.Drawing.Point(83, 120);
            this.tbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.tbUnit.MaxLength = 10;
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.Size = new System.Drawing.Size(90, 21);
            this.tbUnit.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(263, 190);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 248;
            this.btnCancel.Text = "取消(F10)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(184, 190);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 22);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 247;
            this.btnSave.Text = "保存(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // diPrice
            // 
            this.diPrice.AllowEmptyState = false;
            // 
            // 
            // 
            this.diPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.diPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.diPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.diPrice.Increment = 1D;
            this.diPrice.Location = new System.Drawing.Point(83, 94);
            this.diPrice.Margin = new System.Windows.Forms.Padding(2);
            this.diPrice.MaxValue = 99999D;
            this.diPrice.MinValue = 0D;
            this.diPrice.Name = "diPrice";
            this.diPrice.ShowUpDown = true;
            this.diPrice.Size = new System.Drawing.Size(90, 21);
            this.diPrice.TabIndex = 10;
            // 
            // tbCenterItemCode
            // 
            this.tbCenterItemCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbCenterItemCode.Border.Class = "TextBoxBorder";
            this.tbCenterItemCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCenterItemCode.ForeColor = System.Drawing.Color.Black;
            this.tbCenterItemCode.Location = new System.Drawing.Point(83, 41);
            this.tbCenterItemCode.Margin = new System.Windows.Forms.Padding(2);
            this.tbCenterItemCode.MaxLength = 10;
            this.tbCenterItemCode.Name = "tbCenterItemCode";
            this.tbCenterItemCode.Size = new System.Drawing.Size(255, 21);
            this.tbCenterItemCode.TabIndex = 7;
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.ForeColor = System.Drawing.Color.Purple;
            this.labelX11.Location = new System.Drawing.Point(19, 43);
            this.labelX11.Margin = new System.Windows.Forms.Padding(2);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(56, 18);
            this.labelX11.TabIndex = 241;
            this.labelX11.Text = "项目编码";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX22
            // 
            this.labelX22.AutoSize = true;
            this.labelX22.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Location = new System.Drawing.Point(19, 95);
            this.labelX22.Margin = new System.Windows.Forms.Padding(2);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(56, 18);
            this.labelX22.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX22.TabIndex = 234;
            this.labelX22.Text = "参考单价";
            this.labelX22.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(19, 122);
            this.labelX14.Margin = new System.Windows.Forms.Padding(2);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(56, 18);
            this.labelX14.TabIndex = 231;
            this.labelX14.Text = "项目单位";
            this.labelX14.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(19, 69);
            this.labelX12.Margin = new System.Windows.Forms.Padding(2);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(56, 18);
            this.labelX12.TabIndex = 229;
            this.labelX12.Text = "项目分类";
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbExplain
            // 
            this.tbExplain.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbExplain.Border.Class = "TextBoxBorder";
            this.tbExplain.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbExplain.ForeColor = System.Drawing.Color.Black;
            this.tbExplain.Location = new System.Drawing.Point(83, 146);
            this.tbExplain.Margin = new System.Windows.Forms.Padding(2);
            this.tbExplain.MaxLength = 250;
            this.tbExplain.Multiline = true;
            this.tbExplain.Name = "tbExplain";
            this.tbExplain.Size = new System.Drawing.Size(255, 37);
            this.tbExplain.TabIndex = 11;
            // 
            // labelX21
            // 
            this.labelX21.AutoSize = true;
            this.labelX21.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Location = new System.Drawing.Point(19, 148);
            this.labelX21.Margin = new System.Windows.Forms.Padding(2);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(56, 18);
            this.labelX21.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX21.TabIndex = 225;
            this.labelX21.Text = "项目说明";
            this.labelX21.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbCenterItemName
            // 
            this.tbCenterItemName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbCenterItemName.Border.Class = "TextBoxBorder";
            this.tbCenterItemName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCenterItemName.ForeColor = System.Drawing.Color.Black;
            this.tbCenterItemName.Location = new System.Drawing.Point(83, 15);
            this.tbCenterItemName.Margin = new System.Windows.Forms.Padding(2);
            this.tbCenterItemName.MaxLength = 50;
            this.tbCenterItemName.Name = "tbCenterItemName";
            this.tbCenterItemName.Size = new System.Drawing.Size(255, 21);
            this.tbCenterItemName.TabIndex = 6;
            // 
            // labelX17
            // 
            this.labelX17.AutoSize = true;
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.ForeColor = System.Drawing.Color.Purple;
            this.labelX17.Location = new System.Drawing.Point(19, 17);
            this.labelX17.Margin = new System.Windows.Forms.Padding(2);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(56, 18);
            this.labelX17.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX17.TabIndex = 216;
            this.labelX17.Text = "项目名称";
            this.labelX17.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.barCFeeItem);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 35);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panelEx2.Size = new System.Drawing.Size(867, 26);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 33;
            // 
            // barCFeeItem
            // 
            this.barCFeeItem.AntiAlias = true;
            this.barCFeeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCFeeItem.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.barCFeeItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barCFeeItem.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolbarAdd,
            this.toolbarFlag,
            this.toolbarAudit,
            this.toolbarRefresh});
            this.barCFeeItem.Location = new System.Drawing.Point(1, 0);
            this.barCFeeItem.Margin = new System.Windows.Forms.Padding(0);
            this.barCFeeItem.Name = "barCFeeItem";
            this.barCFeeItem.Size = new System.Drawing.Size(865, 25);
            this.barCFeeItem.Stretch = true;
            this.barCFeeItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barCFeeItem.TabIndex = 26;
            this.barCFeeItem.TabStop = false;
            // 
            // toolbarAdd
            // 
            this.toolbarAdd.Name = "toolbarAdd";
            this.toolbarAdd.Text = "新增(F2)";
            this.toolbarAdd.Click += new System.EventHandler(this.toolbarAdd_Click);
            // 
            // toolbarFlag
            // 
            this.toolbarFlag.Name = "toolbarFlag";
            this.toolbarFlag.Text = "启用(F3)";
            this.toolbarFlag.Click += new System.EventHandler(this.toolbarFlag_Click);
            // 
            // toolbarAudit
            // 
            this.toolbarAudit.Name = "toolbarAudit";
            this.toolbarAudit.Text = "审核(F4)";
            this.toolbarAudit.Click += new System.EventHandler(this.toolbarAudit_Click);
            // 
            // toolbarRefresh
            // 
            this.toolbarRefresh.Name = "toolbarRefresh";
            this.toolbarRefresh.Text = "刷新(F5)";
            this.toolbarRefresh.Click += new System.EventHandler(this.toolbarRefresh_Click);
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
            this.StrIsStop,
            this.Explain});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCenterFeeItem.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgCenterFeeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCenterFeeItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgCenterFeeItem.HighlightSelectedColumnHeaders = false;
            this.dgCenterFeeItem.Location = new System.Drawing.Point(0, 61);
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
            this.dgCenterFeeItem.Size = new System.Drawing.Size(867, 369);
            this.dgCenterFeeItem.TabIndex = 34;
            this.dgCenterFeeItem.CurrentCellChanged += new System.EventHandler(this.dgCenterFeeItem_CurrentCellChanged);
            this.dgCenterFeeItem.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgCenterFeeItem_RowPrePaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FeeID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "中心编码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CenterItemCode
            // 
            this.CenterItemCode.DataPropertyName = "CenterItemCode";
            this.CenterItemCode.HeaderText = "中心项目编码";
            this.CenterItemCode.MinimumWidth = 100;
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
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle5;
            this.Price.HeaderText = "项目单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StrIsStop
            // 
            this.StrIsStop.DataPropertyName = "StrIsStop";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StrIsStop.DefaultCellStyle = dataGridViewCellStyle6;
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
            // pagerCenterFeeItem
            // 
            this.pagerCenterFeeItem.BindDataControl = this.dgCenterFeeItem;
            this.pagerCenterFeeItem.DataSource = null;
            this.pagerCenterFeeItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerCenterFeeItem.IsPage = false;
            this.pagerCenterFeeItem.Location = new System.Drawing.Point(0, 430);
            this.pagerCenterFeeItem.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.pagerCenterFeeItem.Name = "pagerCenterFeeItem";
            this.pagerCenterFeeItem.pageNo = 1;
            this.pagerCenterFeeItem.pageSize = 20;
            this.pagerCenterFeeItem.PageSizeType = EfwControls.CustomControl.pageSizeType.Size20;
            this.pagerCenterFeeItem.Size = new System.Drawing.Size(867, 28);
            this.pagerCenterFeeItem.TabIndex = 35;
            this.pagerCenterFeeItem.totalRecord = 100;
            this.pagerCenterFeeItem.PageNoChanged += new EfwControls.CustomControl.PagerEventHandler(this.pagerCenterFeeItem_PageNoChanged);
            // 
            // frmCFeeItemForm
            // 
            this.frmCFeeItemForm.IsSkip = true;
            // 
            // FrmFeeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 458);
            this.Controls.Add(this.dgCenterFeeItem);
            this.Controls.Add(this.pagerCenterFeeItem);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx6);
            this.Controls.Add(this.panelEx4);
            this.Name = "FrmFeeItem";
            this.Text = "中心收费项目";
            this.OpenWindowBefore += new System.EventHandler(this.FrmFeeItem_OpenWindowBefore);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFeeItem_KeyDown);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.panelEx6.ResumeLayout(false);
            this.panelEx6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diPrice)).EndInit();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barCFeeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCenterFeeItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private EfwControls.CustomControl.frmForm frmCFeeItemForm;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboQueryWorker;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboQueryAudit;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbKey;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboQueryStop;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUnit;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnQuit;
        private DevComponents.Editors.DoubleInput diPrice;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCenterItemCode;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX22;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX tbExplain;
        private DevComponents.DotNetBar.LabelX labelX21;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCenterItemName;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Bar barCFeeItem;
        private DevComponents.DotNetBar.ButtonItem toolbarAdd;
        private DevComponents.DotNetBar.ButtonItem toolbarFlag;
        private DevComponents.DotNetBar.ButtonItem toolbarAudit;
        private DevComponents.DotNetBar.ButtonItem toolbarRefresh;
        private EfwControls.CustomControl.DataGrid dgCenterFeeItem;
        private EfwControls.CustomControl.Pager pagerCenterFeeItem;
        private EfwControls.CustomControl.TextBoxCard cboStatID;
        private EfwControls.CustomControl.TextBoxCard cboSearchStatID;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrAuditStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrIsStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Explain;
    }
}