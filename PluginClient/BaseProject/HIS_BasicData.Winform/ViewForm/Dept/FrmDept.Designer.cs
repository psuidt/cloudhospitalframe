namespace HIS_BasicData.Winform.ViewForm.Dept
{
    partial class FrmDept
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ListSearch = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.DeptGrid = new EfwControls.CustomControl.DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDeptDetails = new DevComponents.DotNetBar.PanelEx();
            this.DeptNameLabel = new DevComponents.DotNetBar.LabelX();
            this.DeptName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PrtWardUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnQuit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.ExamineUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.MaterialsUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.DrugUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.InUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.OutUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.DeptType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.DeptType1 = new DevComponents.Editors.ComboItem();
            this.DeptType2 = new DevComponents.Editors.ComboItem();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.Member_Num = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.Bed_Num = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.DeptAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.Telephone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.Principal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.DeptID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PharmacyUsed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.DetailAdd = new DevComponents.DotNetBar.ButtonItem();
            this.DetailDel = new DevComponents.DotNetBar.ButtonItem();
            this.DeptRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.SearchValue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.treeDeptLayer = new DevComponents.AdvTree.AdvTree();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.toolbarAdd = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarEdit = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarDel = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboWorker = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.frmDeptForm = new EfwControls.CustomControl.frmForm(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeptGrid)).BeginInit();
            this.panelDeptDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.panelEx4.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeDeptLayer)).BeginInit();
            this.treeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListSearch
            // 
            this.ListSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ListSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ListSearch.Location = new System.Drawing.Point(324, 6);
            this.ListSearch.Name = "ListSearch";
            this.ListSearch.Size = new System.Drawing.Size(75, 22);
            this.ListSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ListSearch.TabIndex = 7;
            this.ListSearch.Text = "查询";
            this.ListSearch.Click += new System.EventHandler(this.ListSearch_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.DeptGrid);
            this.panelEx1.Controls.Add(this.panelDeptDetails);
            this.panelEx1.Controls.Add(this.bar2);
            this.panelEx1.Controls.Add(this.panelEx4);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(255, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panelEx1.Size = new System.Drawing.Size(912, 487);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Style.MarginRight = 10;
            this.panelEx1.TabIndex = 4;
            // 
            // DeptGrid
            // 
            this.DeptGrid.AllowSortWhenClickColumnHeader = false;
            this.DeptGrid.AllowUserToAddRows = false;
            this.DeptGrid.AllowUserToDeleteRows = false;
            this.DeptGrid.AllowUserToResizeColumns = false;
            this.DeptGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            this.DeptGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DeptGrid.BackgroundColor = System.Drawing.Color.White;
            this.DeptGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeptGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DeptGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.DelFlag});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DeptGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.DeptGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeptGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DeptGrid.HighlightSelectedColumnHeaders = false;
            this.DeptGrid.Location = new System.Drawing.Point(4, 60);
            this.DeptGrid.MultiSelect = false;
            this.DeptGrid.Name = "DeptGrid";
            this.DeptGrid.ReadOnly = true;
            this.DeptGrid.RowHeadersVisible = false;
            this.DeptGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DeptGrid.RowTemplate.Height = 23;
            this.DeptGrid.SelectAllSignVisible = false;
            this.DeptGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeptGrid.SeqVisible = false;
            this.DeptGrid.SetCustomStyle = true;
            this.DeptGrid.Size = new System.Drawing.Size(477, 427);
            this.DeptGrid.TabIndex = 2;
            this.DeptGrid.CurrentCellChanged += new System.EventHandler(this.DeptGrid_CurrentCellChanged);
            this.DeptGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DeptGrid_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "DeptID";
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "科室名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Pym";
            this.Column3.HeaderText = "拼音码";
            this.Column3.MinimumWidth = 80;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Wbm";
            this.Column4.HeaderText = "五笔码";
            this.Column4.MinimumWidth = 80;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DelFlag
            // 
            this.DelFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DelFlag.DataPropertyName = "DelFlag";
            this.DelFlag.HeaderText = "状态标识";
            this.DelFlag.MinimumWidth = 70;
            this.DelFlag.Name = "DelFlag";
            this.DelFlag.ReadOnly = true;
            this.DelFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panelDeptDetails
            // 
            this.panelDeptDetails.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDeptDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDeptDetails.Controls.Add(this.DeptNameLabel);
            this.panelDeptDetails.Controls.Add(this.DeptName);
            this.panelDeptDetails.Controls.Add(this.PrtWardUsed);
            this.panelDeptDetails.Controls.Add(this.btnQuit);
            this.panelDeptDetails.Controls.Add(this.btnSave);
            this.panelDeptDetails.Controls.Add(this.btnReset);
            this.panelDeptDetails.Controls.Add(this.ExamineUsed);
            this.panelDeptDetails.Controls.Add(this.labelX13);
            this.panelDeptDetails.Controls.Add(this.MaterialsUsed);
            this.panelDeptDetails.Controls.Add(this.DrugUsed);
            this.panelDeptDetails.Controls.Add(this.InUsed);
            this.panelDeptDetails.Controls.Add(this.OutUsed);
            this.panelDeptDetails.Controls.Add(this.DeptType);
            this.panelDeptDetails.Controls.Add(this.labelX10);
            this.panelDeptDetails.Controls.Add(this.Member_Num);
            this.panelDeptDetails.Controls.Add(this.labelX9);
            this.panelDeptDetails.Controls.Add(this.Bed_Num);
            this.panelDeptDetails.Controls.Add(this.labelX8);
            this.panelDeptDetails.Controls.Add(this.DeptAddress);
            this.panelDeptDetails.Controls.Add(this.labelX7);
            this.panelDeptDetails.Controls.Add(this.Telephone);
            this.panelDeptDetails.Controls.Add(this.labelX4);
            this.panelDeptDetails.Controls.Add(this.Principal);
            this.panelDeptDetails.Controls.Add(this.labelX5);
            this.panelDeptDetails.Controls.Add(this.DeptID);
            this.panelDeptDetails.Controls.Add(this.PharmacyUsed);
            this.panelDeptDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDeptDetails.Location = new System.Drawing.Point(481, 60);
            this.panelDeptDetails.Name = "panelDeptDetails";
            this.panelDeptDetails.Size = new System.Drawing.Size(431, 427);
            this.panelDeptDetails.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDeptDetails.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDeptDetails.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDeptDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDeptDetails.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDeptDetails.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDeptDetails.Style.GradientAngle = 90;
            this.panelDeptDetails.TabIndex = 8;
            // 
            // DeptNameLabel
            // 
            this.DeptNameLabel.AutoSize = true;
            this.DeptNameLabel.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.DeptNameLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DeptNameLabel.ForeColor = System.Drawing.Color.DarkViolet;
            this.DeptNameLabel.Location = new System.Drawing.Point(31, 30);
            this.DeptNameLabel.Name = "DeptNameLabel";
            this.DeptNameLabel.Size = new System.Drawing.Size(56, 18);
            this.DeptNameLabel.SymbolColor = System.Drawing.Color.Transparent;
            this.DeptNameLabel.TabIndex = 115;
            this.DeptNameLabel.Text = "科室名称";
            this.DeptNameLabel.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DeptName
            // 
            // 
            // 
            // 
            this.DeptName.Border.Class = "TextBoxBorder";
            this.DeptName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DeptName.Location = new System.Drawing.Point(91, 28);
            this.DeptName.Name = "DeptName";
            this.DeptName.Size = new System.Drawing.Size(120, 21);
            this.DeptName.TabIndex = 114;
            // 
            // PrtWardUsed
            // 
            // 
            // 
            // 
            this.PrtWardUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PrtWardUsed.Location = new System.Drawing.Point(171, 224);
            this.PrtWardUsed.Name = "PrtWardUsed";
            this.PrtWardUsed.Size = new System.Drawing.Size(120, 23);
            this.PrtWardUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PrtWardUsed.TabIndex = 98;
            this.PrtWardUsed.Text = "病区";
            this.PrtWardUsed.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuit.Location = new System.Drawing.Point(342, 265);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 25);
            this.btnQuit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuit.TabIndex = 22;
            this.btnQuit.Text = "关闭(F8)";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(261, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "保存(F7)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(180, 265);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "重置(F6)";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ExamineUsed
            // 
            // 
            // 
            // 
            this.ExamineUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ExamineUsed.Location = new System.Drawing.Point(91, 224);
            this.ExamineUsed.Name = "ExamineUsed";
            this.ExamineUsed.Size = new System.Drawing.Size(120, 23);
            this.ExamineUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ExamineUsed.TabIndex = 95;
            this.ExamineUsed.Text = "医技科室";
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(31, 160);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(56, 18);
            this.labelX13.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX13.TabIndex = 113;
            this.labelX13.Text = "科室类型";
            this.labelX13.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // MaterialsUsed
            // 
            // 
            // 
            // 
            this.MaterialsUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialsUsed.Location = new System.Drawing.Point(270, 191);
            this.MaterialsUsed.Name = "MaterialsUsed";
            this.MaterialsUsed.Size = new System.Drawing.Size(120, 23);
            this.MaterialsUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MaterialsUsed.TabIndex = 94;
            this.MaterialsUsed.Text = "物资仓库";
            // 
            // DrugUsed
            // 
            // 
            // 
            // 
            this.DrugUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DrugUsed.Location = new System.Drawing.Point(171, 190);
            this.DrugUsed.Name = "DrugUsed";
            this.DrugUsed.Size = new System.Drawing.Size(120, 23);
            this.DrugUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DrugUsed.TabIndex = 92;
            this.DrugUsed.Text = "药库仓库";
            // 
            // InUsed
            // 
            // 
            // 
            // 
            this.InUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.InUsed.Location = new System.Drawing.Point(171, 158);
            this.InUsed.Name = "InUsed";
            this.InUsed.Size = new System.Drawing.Size(120, 23);
            this.InUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.InUsed.TabIndex = 91;
            this.InUsed.Text = "住院科室";
            // 
            // OutUsed
            // 
            // 
            // 
            // 
            this.OutUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OutUsed.Location = new System.Drawing.Point(91, 158);
            this.OutUsed.Name = "OutUsed";
            this.OutUsed.Size = new System.Drawing.Size(120, 23);
            this.OutUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.OutUsed.TabIndex = 90;
            this.OutUsed.Text = "门诊科室";
            // 
            // DeptType
            // 
            this.DeptType.DisplayMember = "Text";
            this.DeptType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DeptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeptType.FormattingEnabled = true;
            this.DeptType.ItemHeight = 15;
            this.DeptType.Items.AddRange(new object[] {
            this.DeptType1,
            this.DeptType2});
            this.DeptType.Location = new System.Drawing.Point(297, 94);
            this.DeptType.Name = "DeptType";
            this.DeptType.Size = new System.Drawing.Size(121, 21);
            this.DeptType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DeptType.TabIndex = 83;
            // 
            // DeptType1
            // 
            this.DeptType1.Text = "普通";
            this.DeptType1.Value = "0";
            // 
            // DeptType2
            // 
            this.DeptType2.Text = "重点";
            this.DeptType2.Value = "1";
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(238, 96);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(56, 18);
            this.labelX10.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX10.TabIndex = 110;
            this.labelX10.Text = "科室类别";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Member_Num
            // 
            // 
            // 
            // 
            this.Member_Num.Border.Class = "TextBoxBorder";
            this.Member_Num.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Member_Num.Location = new System.Drawing.Point(91, 94);
            this.Member_Num.Name = "Member_Num";
            this.Member_Num.Size = new System.Drawing.Size(120, 21);
            this.Member_Num.TabIndex = 89;
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(19, 96);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(68, 18);
            this.labelX9.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX9.TabIndex = 109;
            this.labelX9.Text = "医务人员数";
            this.labelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Bed_Num
            // 
            // 
            // 
            // 
            this.Bed_Num.Border.Class = "TextBoxBorder";
            this.Bed_Num.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Bed_Num.Location = new System.Drawing.Point(91, 127);
            this.Bed_Num.Name = "Bed_Num";
            this.Bed_Num.Size = new System.Drawing.Size(120, 21);
            this.Bed_Num.TabIndex = 88;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(19, 129);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(68, 18);
            this.labelX8.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX8.TabIndex = 108;
            this.labelX8.Text = "科室床位数";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DeptAddress
            // 
            // 
            // 
            // 
            this.DeptAddress.Border.Class = "TextBoxBorder";
            this.DeptAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DeptAddress.Location = new System.Drawing.Point(91, 61);
            this.DeptAddress.Name = "DeptAddress";
            this.DeptAddress.Size = new System.Drawing.Size(120, 21);
            this.DeptAddress.TabIndex = 86;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(31, 63);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 18);
            this.labelX7.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX7.TabIndex = 106;
            this.labelX7.Text = "科室地址";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Telephone
            // 
            // 
            // 
            // 
            this.Telephone.Border.Class = "TextBoxBorder";
            this.Telephone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Telephone.Location = new System.Drawing.Point(297, 61);
            this.Telephone.Name = "Telephone";
            this.Telephone.Size = new System.Drawing.Size(120, 21);
            this.Telephone.TabIndex = 85;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(226, 63);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(68, 18);
            this.labelX4.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX4.TabIndex = 105;
            this.labelX4.Text = "负责人电话";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Principal
            // 
            // 
            // 
            // 
            this.Principal.Border.Class = "TextBoxBorder";
            this.Principal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Principal.Location = new System.Drawing.Point(297, 28);
            this.Principal.Name = "Principal";
            this.Principal.Size = new System.Drawing.Size(120, 21);
            this.Principal.TabIndex = 84;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.DarkViolet;
            this.labelX5.Location = new System.Drawing.Point(226, 30);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(68, 18);
            this.labelX5.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX5.TabIndex = 104;
            this.labelX5.Text = "科室负责人";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DeptID
            // 
            // 
            // 
            // 
            this.DeptID.Border.Class = "TextBoxBorder";
            this.DeptID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DeptID.Location = new System.Drawing.Point(297, 126);
            this.DeptID.Name = "DeptID";
            this.DeptID.Size = new System.Drawing.Size(120, 21);
            this.DeptID.TabIndex = 79;
            // 
            // PharmacyUsed
            // 
            // 
            // 
            // 
            this.PharmacyUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PharmacyUsed.Location = new System.Drawing.Point(91, 190);
            this.PharmacyUsed.Name = "PharmacyUsed";
            this.PharmacyUsed.Size = new System.Drawing.Size(120, 23);
            this.PharmacyUsed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PharmacyUsed.TabIndex = 101;
            this.PharmacyUsed.Text = "药房";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.DetailAdd,
            this.DetailDel,
            this.DeptRefresh});
            this.bar2.Location = new System.Drawing.Point(4, 35);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(908, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 26;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // DetailAdd
            // 
            this.DetailAdd.Name = "DetailAdd";
            this.DetailAdd.Text = "新增(F2)";
            this.DetailAdd.Click += new System.EventHandler(this.DetailAdd_Click);
            // 
            // DetailDel
            // 
            this.DetailDel.Name = "DetailDel";
            this.DetailDel.Text = "删除(F4)";
            this.DetailDel.Click += new System.EventHandler(this.DetailDel_Click);
            // 
            // DeptRefresh
            // 
            this.DeptRefresh.Name = "DeptRefresh";
            this.DeptRefresh.Text = "刷新(F5)";
            this.DeptRefresh.Click += new System.EventHandler(this.DeptRefresh_Click);
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.SearchValue);
            this.panelEx4.Controls.Add(this.labelX2);
            this.panelEx4.Controls.Add(this.ListSearch);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(4, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(908, 35);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 25;
            // 
            // SearchValue
            // 
            // 
            // 
            // 
            this.SearchValue.Border.Class = "TextBoxBorder";
            this.SearchValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SearchValue.Location = new System.Drawing.Point(68, 6);
            this.SearchValue.Name = "SearchValue";
            this.SearchValue.Size = new System.Drawing.Size(250, 21);
            this.SearchValue.TabIndex = 9;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(6, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "科室名称";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.treeDeptLayer);
            this.panelEx2.Controls.Add(this.bar1);
            this.panelEx2.Controls.Add(this.panelEx3);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(255, 487);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 6;
            // 
            // treeDeptLayer
            // 
            this.treeDeptLayer.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeDeptLayer.AllowDrop = true;
            this.treeDeptLayer.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeDeptLayer.BackgroundStyle.Class = "TreeBorderKey";
            this.treeDeptLayer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeDeptLayer.CellEdit = true;
            this.treeDeptLayer.ColumnsVisible = false;
            this.treeDeptLayer.ContextMenuStrip = this.treeMenu;
            this.treeDeptLayer.DisplayMembers = "Name";
            this.treeDeptLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDeptLayer.DragDropEnabled = false;
            this.treeDeptLayer.DragDropNodeCopyEnabled = false;
            this.treeDeptLayer.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeDeptLayer.GridColumnLines = false;
            this.treeDeptLayer.GridRowLines = true;
            this.treeDeptLayer.Location = new System.Drawing.Point(0, 60);
            this.treeDeptLayer.Name = "treeDeptLayer";
            this.treeDeptLayer.NodesConnector = this.nodeConnector1;
            this.treeDeptLayer.NodeStyle = this.elementStyle1;
            this.treeDeptLayer.PathSeparator = ";";
            this.treeDeptLayer.Size = new System.Drawing.Size(255, 427);
            this.treeDeptLayer.Styles.Add(this.elementStyle1);
            this.treeDeptLayer.TabIndex = 1;
            this.treeDeptLayer.Tag = "";
            this.treeDeptLayer.AfterCellEditComplete += new DevComponents.AdvTree.CellEditEventHandler(this.treeDeptLayer_AfterCellEditComplete);
            this.treeDeptLayer.SelectedIndexChanged += new System.EventHandler(this.treeDeptLayer_SelectedIndexChanged);
            // 
            // treeMenu
            // 
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuAdd,
            this.toolMenuEdit,
            this.toolMenuDel});
            this.treeMenu.Name = "contextMenuStrip1";
            this.treeMenu.Size = new System.Drawing.Size(101, 70);
            // 
            // toolMenuAdd
            // 
            this.toolMenuAdd.Name = "toolMenuAdd";
            this.toolMenuAdd.Size = new System.Drawing.Size(100, 22);
            this.toolMenuAdd.Text = "新增";
            this.toolMenuAdd.Click += new System.EventHandler(this.toolMenuAdd_Click);
            // 
            // toolMenuEdit
            // 
            this.toolMenuEdit.Name = "toolMenuEdit";
            this.toolMenuEdit.Size = new System.Drawing.Size(100, 22);
            this.toolMenuEdit.Text = "修改";
            this.toolMenuEdit.Click += new System.EventHandler(this.toolMenuEdit_Click);
            // 
            // toolMenuDel
            // 
            this.toolMenuDel.Name = "toolMenuDel";
            this.toolMenuDel.Size = new System.Drawing.Size(100, 22);
            this.toolMenuDel.Text = "删除";
            this.toolMenuDel.Click += new System.EventHandler(this.toolMenuDel_Click);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolbarAdd,
            this.toolbarEdit,
            this.toolbarDel});
            this.bar1.Location = new System.Drawing.Point(0, 35);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(255, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // toolbarAdd
            // 
            this.toolbarAdd.Name = "toolbarAdd";
            this.toolbarAdd.Text = "新增";
            this.toolbarAdd.Click += new System.EventHandler(this.toolbarAdd_Click);
            // 
            // toolbarEdit
            // 
            this.toolbarEdit.Name = "toolbarEdit";
            this.toolbarEdit.Text = "修改";
            this.toolbarEdit.Click += new System.EventHandler(this.toolbarEdit_Click);
            // 
            // toolbarDel
            // 
            this.toolbarDel.Name = "toolbarDel";
            this.toolbarDel.Text = "删除";
            this.toolbarDel.Click += new System.EventHandler(this.toolbarDel_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.labelX1);
            this.panelEx3.Controls.Add(this.cboWorker);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(255, 35);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(3, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 29;
            this.labelX1.Text = "医疗机构";
            // 
            // cboWorker
            // 
            this.cboWorker.DisplayMember = "WorkName";
            this.cboWorker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorker.FormattingEnabled = true;
            this.cboWorker.ItemHeight = 15;
            this.cboWorker.Location = new System.Drawing.Point(60, 6);
            this.cboWorker.Name = "cboWorker";
            this.cboWorker.Size = new System.Drawing.Size(189, 21);
            this.cboWorker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboWorker.TabIndex = 28;
            this.cboWorker.ValueMember = "WorkId";
            this.cboWorker.SelectedIndexChanged += new System.EventHandler(this.cboWorker_SelectedIndexChanged);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "新增";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "删除";
            // 
            // frmDeptForm
            // 
            this.frmDeptForm.IsSkip = true;
            // 
            // FrmDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 487);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Name = "FrmDept";
            this.Text = "科室";
            this.OpenWindowBefore += new System.EventHandler(this.FrmDept_OpenWindowBefore);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDept_KeyDown);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeptGrid)).EndInit();
            this.panelDeptDetails.ResumeLayout(false);
            this.panelDeptDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeDeptLayer)).EndInit();
            this.treeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX ListSearch;
        private EfwControls.CustomControl.DataGrid DeptGrid;
        private EfwControls.CustomControl.frmForm frmDeptForm;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.AdvTree.AdvTree treeDeptLayer;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboWorker;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem DetailAdd;
        private DevComponents.DotNetBar.ButtonItem DetailDel;
        private DevComponents.DotNetBar.ButtonItem DeptRefresh;
        private DevComponents.DotNetBar.Controls.TextBoxX SearchValue;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
        private System.Windows.Forms.ToolStripMenuItem toolMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem toolMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem toolMenuDel;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem toolbarAdd;
        private DevComponents.DotNetBar.ButtonItem toolbarEdit;
        private DevComponents.DotNetBar.ButtonItem toolbarDel;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.PanelEx panelDeptDetails;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnQuit;
        private DevComponents.DotNetBar.Controls.CheckBoxX PharmacyUsed;
        private DevComponents.DotNetBar.Controls.CheckBoxX ExamineUsed;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Controls.CheckBoxX MaterialsUsed;
        private DevComponents.DotNetBar.Controls.CheckBoxX DrugUsed;
        private DevComponents.DotNetBar.Controls.CheckBoxX InUsed;
        private DevComponents.DotNetBar.Controls.CheckBoxX OutUsed;
        private DevComponents.DotNetBar.Controls.ComboBoxEx DeptType;
        private DevComponents.DotNetBar.Controls.TextBoxX Member_Num;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX Bed_Num;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX DeptAddress;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX Telephone;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX Principal;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX DeptID;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.Editors.ComboItem DeptType1;
        private DevComponents.Editors.ComboItem DeptType2;
        private DevComponents.DotNetBar.Controls.CheckBoxX PrtWardUsed;
        private DevComponents.DotNetBar.LabelX DeptNameLabel;
        private DevComponents.DotNetBar.Controls.TextBoxX DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelFlag;
    }
}