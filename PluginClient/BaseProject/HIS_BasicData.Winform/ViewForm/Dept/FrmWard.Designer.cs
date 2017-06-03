namespace HIS_BasicData.Winform.ViewForm.Dept
{
    partial class FrmWard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.cbQuery = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboQueryWorker = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbQueryKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.toolbarRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarFlag = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarAdd = new DevComponents.DotNetBar.ButtonItem();
            this.barWard = new DevComponents.DotNetBar.Bar();
            this.toolbarRelDept = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.dgWard = new EfwControls.CustomControl.DataGrid();
            this.ColWardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrDelFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.txtSortOrder = new DevComponents.Editors.IntegerInput();
            this.txtSickbedNum = new DevComponents.Editors.IntegerInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtResponsible = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX33 = new DevComponents.DotNetBar.LabelX();
            this.tbWardName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX37 = new DevComponents.DotNetBar.LabelX();
            this.panelEx7 = new DevComponents.DotNetBar.PanelEx();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgDepts = new EfwControls.CustomControl.DataGrid();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frmWardForm = new EfwControls.CustomControl.frmForm(this.components);
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barWard)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWard)).BeginInit();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSickbedNum)).BeginInit();
            this.panelEx7.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(286, 9);
            this.labelX1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 27;
            this.labelX1.Text = "关键字";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(710, 7);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 22);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询(F9)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.cbQuery);
            this.panelEx4.Controls.Add(this.cboQueryWorker);
            this.panelEx4.Controls.Add(this.labelX3);
            this.panelEx4.Controls.Add(this.tbQueryKey);
            this.panelEx4.Controls.Add(this.labelX1);
            this.panelEx4.Controls.Add(this.btnQuery);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(974, 35);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 25;
            // 
            // cbQuery
            // 
            // 
            // 
            // 
            this.cbQuery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbQuery.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.cbQuery.Location = new System.Drawing.Point(606, 10);
            this.cbQuery.Margin = new System.Windows.Forms.Padding(2);
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Size = new System.Drawing.Size(85, 16);
            this.cbQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbQuery.TabIndex = 4;
            this.cbQuery.Text = "显示停用";
            // 
            // cboQueryWorker
            // 
            this.cboQueryWorker.DisplayMember = "WorkName";
            this.cboQueryWorker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQueryWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryWorker.FormattingEnabled = true;
            this.cboQueryWorker.ItemHeight = 15;
            this.cboQueryWorker.Location = new System.Drawing.Point(75, 8);
            this.cboQueryWorker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboQueryWorker.Name = "cboQueryWorker";
            this.cboQueryWorker.Size = new System.Drawing.Size(197, 21);
            this.cboQueryWorker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboQueryWorker.TabIndex = 1;
            this.cboQueryWorker.ValueMember = "WorkId";
            this.cboQueryWorker.SelectedIndexChanged += new System.EventHandler(this.cboWorker_SelectedIndexChanged);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 9);
            this.labelX3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 32;
            this.labelX3.Text = "医疗机构";
            // 
            // tbQueryKey
            // 
            this.tbQueryKey.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbQueryKey.Border.Class = "TextBoxBorder";
            this.tbQueryKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbQueryKey.ForeColor = System.Drawing.Color.Black;
            this.tbQueryKey.Location = new System.Drawing.Point(334, 8);
            this.tbQueryKey.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbQueryKey.Name = "tbQueryKey";
            this.tbQueryKey.Size = new System.Drawing.Size(250, 21);
            this.tbQueryKey.TabIndex = 3;
            // 
            // toolbarRefresh
            // 
            this.toolbarRefresh.Name = "toolbarRefresh";
            this.toolbarRefresh.Text = "刷新(F5)";
            this.toolbarRefresh.Click += new System.EventHandler(this.toolbarRefresh_Click);
            // 
            // toolbarFlag
            // 
            this.toolbarFlag.Name = "toolbarFlag";
            this.toolbarFlag.Text = "启用(F3)";
            this.toolbarFlag.Click += new System.EventHandler(this.toolbarFlag_Click);
            // 
            // toolbarAdd
            // 
            this.toolbarAdd.Name = "toolbarAdd";
            this.toolbarAdd.Text = "新增(F2)";
            this.toolbarAdd.Click += new System.EventHandler(this.toolbarAdd_Click);
            // 
            // barWard
            // 
            this.barWard.AntiAlias = true;
            this.barWard.Dock = System.Windows.Forms.DockStyle.Top;
            this.barWard.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.barWard.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barWard.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolbarAdd,
            this.toolbarFlag,
            this.toolbarRefresh,
            this.toolbarRelDept,
            this.btnClose});
            this.barWard.Location = new System.Drawing.Point(0, 0);
            this.barWard.Margin = new System.Windows.Forms.Padding(0);
            this.barWard.Name = "barWard";
            this.barWard.Size = new System.Drawing.Size(651, 25);
            this.barWard.Stretch = true;
            this.barWard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barWard.TabIndex = 26;
            this.barWard.TabStop = false;
            this.barWard.Text = "bar1";
            // 
            // toolbarRelDept
            // 
            this.toolbarRelDept.Name = "toolbarRelDept";
            this.toolbarRelDept.Text = "关联科室(F4)";
            this.toolbarRelDept.Click += new System.EventHandler(this.toolbarRelDept_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx6);
            this.panelEx1.Controls.Add(this.panelEx7);
            this.panelEx1.Controls.Add(this.panelEx4);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(2, 3, 10, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(974, 417);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Style.MarginRight = 10;
            this.panelEx1.TabIndex = 2;
            // 
            // panelEx6
            // 
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.dgWard);
            this.panelEx6.Controls.Add(this.panelEx3);
            this.panelEx6.Controls.Add(this.barWard);
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx6.Location = new System.Drawing.Point(0, 35);
            this.panelEx6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(651, 382);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 30;
            // 
            // dgWard
            // 
            this.dgWard.AllowSortWhenClickColumnHeader = false;
            this.dgWard.AllowUserToAddRows = false;
            this.dgWard.AllowUserToDeleteRows = false;
            this.dgWard.AllowUserToResizeColumns = false;
            this.dgWard.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgWard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWard.BackgroundColor = System.Drawing.Color.White;
            this.dgWard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgWard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColWardName,
            this.Column1,
            this.Column2,
            this.ColumnMemo,
            this.StrDelFlag});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWard.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgWard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWard.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgWard.HighlightSelectedColumnHeaders = false;
            this.dgWard.Location = new System.Drawing.Point(253, 25);
            this.dgWard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgWard.MultiSelect = false;
            this.dgWard.Name = "dgWard";
            this.dgWard.ReadOnly = true;
            this.dgWard.RowHeadersVisible = false;
            this.dgWard.RowHeadersWidth = 30;
            this.dgWard.RowTemplate.Height = 23;
            this.dgWard.SelectAllSignVisible = false;
            this.dgWard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWard.SeqVisible = false;
            this.dgWard.SetCustomStyle = true;
            this.dgWard.Size = new System.Drawing.Size(398, 357);
            this.dgWard.TabIndex = 2;
            this.dgWard.CurrentCellChanged += new System.EventHandler(this.dgWard_CurrentCellChanged);
            this.dgWard.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgWard_RowPrePaint);
            // 
            // ColWardName
            // 
            this.ColWardName.DataPropertyName = "WardName";
            this.ColWardName.HeaderText = "病区名称";
            this.ColWardName.MinimumWidth = 120;
            this.ColWardName.Name = "ColWardName";
            this.ColWardName.ReadOnly = true;
            this.ColWardName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWardName.Width = 120;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Responsible";
            this.Column1.HeaderText = "负责人";
            this.Column1.MinimumWidth = 80;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SickbedNum";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "床位数";
            this.Column2.MinimumWidth = 80;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.MinimumWidth = 100;
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StrDelFlag
            // 
            this.StrDelFlag.DataPropertyName = "StrDelFlag";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StrDelFlag.DefaultCellStyle = dataGridViewCellStyle4;
            this.StrDelFlag.HeaderText = "状态标识";
            this.StrDelFlag.MinimumWidth = 70;
            this.StrDelFlag.Name = "StrDelFlag";
            this.StrDelFlag.ReadOnly = true;
            this.StrDelFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StrDelFlag.Width = 70;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.txtSortOrder);
            this.panelEx3.Controls.Add(this.txtSickbedNum);
            this.panelEx3.Controls.Add(this.labelX5);
            this.panelEx3.Controls.Add(this.labelX4);
            this.panelEx3.Controls.Add(this.txtResponsible);
            this.panelEx3.Controls.Add(this.labelX2);
            this.panelEx3.Controls.Add(this.tbMemo);
            this.panelEx3.Controls.Add(this.btnCancel);
            this.panelEx3.Controls.Add(this.btnSave);
            this.panelEx3.Controls.Add(this.labelX33);
            this.panelEx3.Controls.Add(this.tbWardName);
            this.panelEx3.Controls.Add(this.labelX37);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx3.Location = new System.Drawing.Point(0, 25);
            this.panelEx3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(253, 357);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 28;
            // 
            // txtSortOrder
            // 
            // 
            // 
            // 
            this.txtSortOrder.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSortOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSortOrder.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSortOrder.Location = new System.Drawing.Point(68, 88);
            this.txtSortOrder.MinValue = 0;
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.ShowUpDown = true;
            this.txtSortOrder.Size = new System.Drawing.Size(169, 21);
            this.txtSortOrder.TabIndex = 215;
            // 
            // txtSickbedNum
            // 
            // 
            // 
            // 
            this.txtSickbedNum.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSickbedNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSickbedNum.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSickbedNum.Location = new System.Drawing.Point(68, 61);
            this.txtSickbedNum.MinValue = 0;
            this.txtSickbedNum.Name = "txtSickbedNum";
            this.txtSickbedNum.ShowUpDown = true;
            this.txtSickbedNum.Size = new System.Drawing.Size(169, 21);
            this.txtSickbedNum.TabIndex = 214;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(171)))));
            this.labelX5.Location = new System.Drawing.Point(30, 87);
            this.labelX5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX5.Size = new System.Drawing.Size(31, 18);
            this.labelX5.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX5.TabIndex = 213;
            this.labelX5.Text = "排序";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(171)))));
            this.labelX4.Location = new System.Drawing.Point(17, 63);
            this.labelX4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX4.Size = new System.Drawing.Size(44, 18);
            this.labelX4.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX4.TabIndex = 211;
            this.labelX4.Text = "床位数";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtResponsible
            // 
            // 
            // 
            // 
            this.txtResponsible.Border.Class = "TextBoxBorder";
            this.txtResponsible.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResponsible.Location = new System.Drawing.Point(68, 33);
            this.txtResponsible.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtResponsible.MaxLength = 25;
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(169, 21);
            this.txtResponsible.TabIndex = 208;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(171)))));
            this.labelX2.Location = new System.Drawing.Point(17, 36);
            this.labelX2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX2.Size = new System.Drawing.Size(44, 18);
            this.labelX2.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX2.TabIndex = 209;
            this.labelX2.Text = "负责人";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbMemo
            // 
            // 
            // 
            // 
            this.tbMemo.Border.Class = "TextBoxBorder";
            this.tbMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMemo.Location = new System.Drawing.Point(68, 114);
            this.tbMemo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbMemo.MaxLength = 100;
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(169, 108);
            this.tbMemo.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(147, 245);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消(F10)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(68, 245);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 22);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX33
            // 
            this.labelX33.AutoSize = true;
            this.labelX33.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX33.Location = new System.Drawing.Point(30, 116);
            this.labelX33.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX33.Name = "labelX33";
            this.labelX33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX33.Size = new System.Drawing.Size(31, 18);
            this.labelX33.TabIndex = 207;
            this.labelX33.Text = "备注";
            this.labelX33.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbWardName
            // 
            // 
            // 
            // 
            this.tbWardName.Border.Class = "TextBoxBorder";
            this.tbWardName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbWardName.Location = new System.Drawing.Point(68, 6);
            this.tbWardName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbWardName.MaxLength = 25;
            this.tbWardName.Name = "tbWardName";
            this.tbWardName.Size = new System.Drawing.Size(169, 21);
            this.tbWardName.TabIndex = 6;
            // 
            // labelX37
            // 
            this.labelX37.AutoSize = true;
            this.labelX37.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX37.ForeColor = System.Drawing.Color.Purple;
            this.labelX37.Location = new System.Drawing.Point(5, 8);
            this.labelX37.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelX37.Name = "labelX37";
            this.labelX37.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX37.Size = new System.Drawing.Size(56, 18);
            this.labelX37.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX37.TabIndex = 142;
            this.labelX37.Text = "病区名称";
            this.labelX37.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panelEx7
            // 
            this.panelEx7.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx7.Controls.Add(this.expandablePanel1);
            this.panelEx7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx7.Location = new System.Drawing.Point(651, 35);
            this.panelEx7.Margin = new System.Windows.Forms.Padding(2);
            this.panelEx7.Name = "panelEx7";
            this.panelEx7.Size = new System.Drawing.Size(323, 382);
            this.panelEx7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx7.Style.GradientAngle = 90;
            this.panelEx7.TabIndex = 224;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.dgDepts);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.expandablePanel1.Size = new System.Drawing.Size(323, 382);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 222;
            this.expandablePanel1.TitleHeight = 25;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "关联科室";
            // 
            // dgDepts
            // 
            this.dgDepts.AllowSortWhenClickColumnHeader = false;
            this.dgDepts.AllowUserToAddRows = false;
            this.dgDepts.AllowUserToDeleteRows = false;
            this.dgDepts.AllowUserToResizeColumns = false;
            this.dgDepts.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            this.dgDepts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgDepts.BackgroundColor = System.Drawing.Color.White;
            this.dgDepts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDepts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgDepts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupName,
            this.Memo});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDepts.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgDepts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDepts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgDepts.HighlightSelectedColumnHeaders = false;
            this.dgDepts.Location = new System.Drawing.Point(4, 25);
            this.dgDepts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgDepts.MultiSelect = false;
            this.dgDepts.Name = "dgDepts";
            this.dgDepts.ReadOnly = true;
            this.dgDepts.RowHeadersVisible = false;
            this.dgDepts.RowHeadersWidth = 30;
            this.dgDepts.RowTemplate.Height = 23;
            this.dgDepts.SelectAllSignVisible = false;
            this.dgDepts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDepts.SeqVisible = false;
            this.dgDepts.SetCustomStyle = true;
            this.dgDepts.Size = new System.Drawing.Size(319, 357);
            this.dgDepts.TabIndex = 28;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "Name";
            this.groupName.HeaderText = "科室名称";
            this.groupName.MinimumWidth = 120;
            this.groupName.Name = "groupName";
            this.groupName.ReadOnly = true;
            this.groupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.groupName.Width = 120;
            // 
            // Memo
            // 
            this.Memo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmWardForm
            // 
            this.frmWardForm.IsSkip = true;
            // 
            // FrmWard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 417);
            this.Controls.Add(this.panelEx1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmWard";
            this.Text = "";
            this.OpenWindowBefore += new System.EventHandler(this.FrmEmp_OpenWindowBefore);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEmp_KeyDown);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barWard)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWard)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSickbedNum)).EndInit();
            this.panelEx7.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDepts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EfwControls.CustomControl.frmForm frmWardForm;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.ButtonItem toolbarRefresh;
        private DevComponents.DotNetBar.ButtonItem toolbarFlag;
        private DevComponents.DotNetBar.ButtonItem toolbarAdd;
        private DevComponents.DotNetBar.Bar barWard;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private EfwControls.CustomControl.DataGrid dgWard;
        private DevComponents.DotNetBar.Controls.TextBoxX tbQueryKey;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboQueryWorker;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonItem toolbarRelDept;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX33;
        private DevComponents.DotNetBar.Controls.TextBoxX tbWardName;
        private DevComponents.DotNetBar.LabelX labelX37;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbQuery;
        private EfwControls.CustomControl.DataGrid dgDepts;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMemo;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.PanelEx panelEx7;
        private System.Windows.Forms.DataGridViewTextBoxColumn WardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtResponsible;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private DevComponents.Editors.IntegerInput txtSickbedNum;
        private DevComponents.Editors.IntegerInput txtSortOrder;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrDelFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWardName;
    }
}