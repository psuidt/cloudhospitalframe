namespace HIS_BasicData.Winform.ViewForm.Channel
{
    partial class FrmExecBill
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
            EfwControls.CustomControl.DataGridViewSelectionCard dataGridViewSelectionCard1 = new EfwControls.CustomControl.DataGridViewSelectionCard();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.txtQueryName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbbWork = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnNew = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnStop = new DevComponents.DotNetBar.ButtonItem();
            this.panInfo = new DevComponents.DotNetBar.PanelEx();
            this.dgChannel = new EfwControls.CustomControl.GridBoxCard();
            this.ChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.intCode = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgExecBill = new EfwControls.CustomControl.DataGrid();
            this.BillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PYCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WBCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseFalgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgExecBill)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Controls.Add(this.btnQuery);
            this.panelEx1.Controls.Add(this.txtQueryName);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.cbbWork);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1029, 40);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(681, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭（&C）";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(589, 9);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询（&Q）";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQueryName
            // 
            // 
            // 
            // 
            this.txtQueryName.Border.Class = "TextBoxBorder";
            this.txtQueryName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQueryName.Location = new System.Drawing.Point(353, 10);
            this.txtQueryName.Name = "txtQueryName";
            this.txtQueryName.Size = new System.Drawing.Size(221, 21);
            this.txtQueryName.TabIndex = 9;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(297, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "检索条件";
            // 
            // cbbWork
            // 
            this.cbbWork.DisplayMember = "WORKNAME";
            this.cbbWork.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWork.FormattingEnabled = true;
            this.cbbWork.ItemHeight = 15;
            this.cbbWork.Location = new System.Drawing.Point(96, 10);
            this.cbbWork.Name = "cbbWork";
            this.cbbWork.Size = new System.Drawing.Size(184, 21);
            this.cbbWork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbWork.TabIndex = 7;
            this.cbbWork.ValueMember = "WORKID";
            this.cbbWork.SelectedIndexChanged += new System.EventHandler(this.cbbWork_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(34, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "医疗机构";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnStop});
            this.bar1.Location = new System.Drawing.Point(0, 40);
            this.bar1.Name = "bar1";
            this.bar1.PaddingLeft = 28;
            this.bar1.Size = new System.Drawing.Size(1029, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Text = "新增(&N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnStop
            // 
            this.btnStop.Name = "btnStop";
            this.btnStop.Text = "停用";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panInfo
            // 
            this.panInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.panInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panInfo.Controls.Add(this.dgChannel);
            this.panInfo.Controls.Add(this.intCode);
            this.panInfo.Controls.Add(this.labelX4);
            this.panInfo.Controls.Add(this.btnSave);
            this.panInfo.Controls.Add(this.btnCancel);
            this.panInfo.Controls.Add(this.txtName);
            this.panInfo.Controls.Add(this.labelX3);
            this.panInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panInfo.Location = new System.Drawing.Point(741, 65);
            this.panInfo.Name = "panInfo";
            this.panInfo.Size = new System.Drawing.Size(288, 384);
            this.panInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panInfo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panInfo.Style.GradientAngle = 90;
            this.panInfo.TabIndex = 3;
            // 
            // dgChannel
            // 
            this.dgChannel.AllowSortWhenClickColumnHeader = false;
            this.dgChannel.AllowUserToAddRows = false;
            this.dgChannel.AllowUserToDeleteRows = false;
            this.dgChannel.AllowUserToResizeColumns = false;
            this.dgChannel.AllowUserToResizeRows = false;
            this.dgChannel.BackgroundColor = System.Drawing.Color.White;
            this.dgChannel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgChannel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChannel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChannelID,
            this.ChannelName,
            this.btnDelete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgChannel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgChannel.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgChannel.HideSelectionCardWhenCustomInput = false;
            this.dgChannel.HighlightSelectedColumnHeaders = false;
            this.dgChannel.IsInputNumSelectedCard = true;
            this.dgChannel.IsShowLetter = false;
            this.dgChannel.IsShowPage = false;
            this.dgChannel.Location = new System.Drawing.Point(6, 83);
            this.dgChannel.Name = "dgChannel";
            this.dgChannel.ReadOnly = true;
            this.dgChannel.RowHeadersWidth = 30;
            this.dgChannel.RowTemplate.Height = 23;
            this.dgChannel.SelectAllSignVisible = false;
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
            this.dgChannel.SelectionCards = new EfwControls.CustomControl.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard1};
            this.dgChannel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChannel.SelectionNumKeyBoards = null;
            this.dgChannel.SeqVisible = true;
            this.dgChannel.SetCustomStyle = false;
            this.dgChannel.Size = new System.Drawing.Size(277, 250);
            this.dgChannel.TabIndex = 26;
            this.dgChannel.SelectCardRowSelected += new EfwControls.CustomControl.OnSelectCardRowSelectedHandle(this.dgChannel_SelectCardRowSelected);
            this.dgChannel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChannel_CellClick);
            // 
            // ChannelID
            // 
            this.ChannelID.DataPropertyName = "ChannelID";
            this.ChannelID.HeaderText = "编码";
            this.ChannelID.Name = "ChannelID";
            this.ChannelID.ReadOnly = true;
            this.ChannelID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChannelID.Width = 60;
            // 
            // ChannelName
            // 
            this.ChannelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChannelName.DataPropertyName = "ChannelName";
            this.ChannelName.HeaderText = "用法";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            this.ChannelName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnDelete
            // 
            this.btnDelete.FillWeight = 40F;
            this.btnDelete.HeaderText = "删除";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Text = "X";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 40;
            // 
            // intCode
            // 
            // 
            // 
            // 
            this.intCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intCode.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intCode.Location = new System.Drawing.Point(90, 51);
            this.intCode.MinValue = 1;
            this.intCode.Name = "intCode";
            this.intCode.Size = new System.Drawing.Size(193, 21);
            this.intCode.TabIndex = 25;
            this.intCode.Value = 1;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(5, 54);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 18);
            this.labelX4.TabIndex = 24;
            this.labelX4.Text = "报表文件编码";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(197, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存（&S）";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(106, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消（&C）";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(90, 17);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 21);
            this.txtName.TabIndex = 8;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(18, 20);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "执行单名称";
            // 
            // dgExecBill
            // 
            this.dgExecBill.AllowSortWhenClickColumnHeader = false;
            this.dgExecBill.AllowUserToAddRows = false;
            this.dgExecBill.AllowUserToDeleteRows = false;
            this.dgExecBill.AllowUserToResizeColumns = false;
            this.dgExecBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.dgExecBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgExecBill.BackgroundColor = System.Drawing.Color.White;
            this.dgExecBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExecBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgExecBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExecBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillName,
            this.PYCode,
            this.WBCode,
            this.ReportFile,
            this.UseFalgDesc});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExecBill.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgExecBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExecBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgExecBill.HighlightSelectedColumnHeaders = false;
            this.dgExecBill.Location = new System.Drawing.Point(0, 65);
            this.dgExecBill.MultiSelect = false;
            this.dgExecBill.Name = "dgExecBill";
            this.dgExecBill.ReadOnly = true;
            this.dgExecBill.RowHeadersWidth = 30;
            this.dgExecBill.RowTemplate.Height = 23;
            this.dgExecBill.SelectAllSignVisible = false;
            this.dgExecBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExecBill.SeqVisible = true;
            this.dgExecBill.SetCustomStyle = false;
            this.dgExecBill.Size = new System.Drawing.Size(741, 384);
            this.dgExecBill.TabIndex = 4;
            this.dgExecBill.CurrentCellChanged += new System.EventHandler(this.dgExecBill_CurrentCellChanged);
            // 
            // BillName
            // 
            this.BillName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillName.DataPropertyName = "BillName";
            this.BillName.HeaderText = "执行单名称";
            this.BillName.Name = "BillName";
            this.BillName.ReadOnly = true;
            this.BillName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PYCode
            // 
            this.PYCode.DataPropertyName = "PYCode";
            this.PYCode.HeaderText = "拼音码";
            this.PYCode.MinimumWidth = 150;
            this.PYCode.Name = "PYCode";
            this.PYCode.ReadOnly = true;
            this.PYCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PYCode.Width = 150;
            // 
            // WBCode
            // 
            this.WBCode.DataPropertyName = "WBCode";
            this.WBCode.HeaderText = "五笔码";
            this.WBCode.MinimumWidth = 150;
            this.WBCode.Name = "WBCode";
            this.WBCode.ReadOnly = true;
            this.WBCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WBCode.Width = 150;
            // 
            // ReportFile
            // 
            this.ReportFile.DataPropertyName = "ReportFile";
            this.ReportFile.HeaderText = "报表文件编码";
            this.ReportFile.MinimumWidth = 80;
            this.ReportFile.Name = "ReportFile";
            this.ReportFile.ReadOnly = true;
            this.ReportFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UseFalgDesc
            // 
            this.UseFalgDesc.DataPropertyName = "UseFalgDesc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UseFalgDesc.DefaultCellStyle = dataGridViewCellStyle5;
            this.UseFalgDesc.HeaderText = "状态";
            this.UseFalgDesc.Name = "UseFalgDesc";
            this.UseFalgDesc.ReadOnly = true;
            this.UseFalgDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmExecBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 449);
            this.Controls.Add(this.dgExecBill);
            this.Controls.Add(this.panInfo);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmExecBill";
            this.Text = "FrmExecBill";
            this.OpenWindowBefore += new System.EventHandler(this.FrmExecBill_OpenWindowBefore);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panInfo.ResumeLayout(false);
            this.panInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgExecBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelEx panInfo;
        private EfwControls.CustomControl.DataGrid dgExecBill;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQueryName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbWork;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonItem btnNew;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnStop;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PYCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WBCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseFalgDesc;
        private DevComponents.Editors.IntegerInput intCode;
        private EfwControls.CustomControl.GridBoxCard dgChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn btnDelete;
    }
}