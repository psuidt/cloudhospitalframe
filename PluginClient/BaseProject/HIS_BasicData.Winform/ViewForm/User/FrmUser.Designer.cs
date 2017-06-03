namespace HIS_BasicData.Winform.ViewForm.User
{
    partial class FrmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.cbQuery = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tbcQueryDept = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.cboQueryWorker = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbQueryKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.toolbarRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarFlag = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarAdd = new DevComponents.DotNetBar.ButtonItem();
            this.barUser = new DevComponents.DotNetBar.Bar();
            this.toolbarRel = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.dgUser = new EfwControls.CustomControl.DataGrid();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NursePost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrLock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.dgGroups = new EfwControls.CustomControl.DataGrid();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.cboUserName = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.cboNursePost = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cboDoctorPost = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cboUserType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnQuit = new DevComponents.DotNetBar.ButtonX();
            this.cboIsAdmin = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.tbCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX37 = new DevComponents.DotNetBar.LabelX();
            this.frmUserForm = new EfwControls.CustomControl.frmForm(this.components);
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barUser)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.panelEx5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroups)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(203, 8);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "所属科室";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(393, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 27;
            this.labelX1.Text = "关键字";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(660, 6);
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
            this.panelEx4.Controls.Add(this.tbcQueryDept);
            this.panelEx4.Controls.Add(this.cboQueryWorker);
            this.panelEx4.Controls.Add(this.labelX3);
            this.panelEx4.Controls.Add(this.tbQueryKey);
            this.panelEx4.Controls.Add(this.labelX2);
            this.panelEx4.Controls.Add(this.labelX1);
            this.panelEx4.Controls.Add(this.btnQuery);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(985, 35);
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
            this.cbQuery.Location = new System.Drawing.Point(570, 10);
            this.cbQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Size = new System.Drawing.Size(85, 16);
            this.cbQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbQuery.TabIndex = 4;
            this.cbQuery.Text = "显示停用";
            // 
            // tbcQueryDept
            // 
            // 
            // 
            // 
            this.tbcQueryDept.Border.Class = "TextBoxBorder";
            this.tbcQueryDept.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbcQueryDept.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("tbcQueryDept.ButtonCustom.Image")));
            this.tbcQueryDept.ButtonCustom.Visible = true;
            this.tbcQueryDept.CardColumn = null;
            this.tbcQueryDept.DisplayField = "";
            this.tbcQueryDept.IsEnterShowCard = true;
            this.tbcQueryDept.IsNumSelected = false;
            this.tbcQueryDept.IsPage = true;
            this.tbcQueryDept.IsShowLetter = false;
            this.tbcQueryDept.IsShowPage = false;
            this.tbcQueryDept.IsShowSeq = true;
            this.tbcQueryDept.Location = new System.Drawing.Point(268, 6);
            this.tbcQueryDept.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.tbcQueryDept.MemberField = "";
            this.tbcQueryDept.MemberValue = null;
            this.tbcQueryDept.Name = "tbcQueryDept";
            this.tbcQueryDept.QueryFields = new string[] {
        ""};
            this.tbcQueryDept.QueryFieldsString = "";
            this.tbcQueryDept.SelectedValue = null;
            this.tbcQueryDept.ShowCardColumns = null;
            this.tbcQueryDept.ShowCardDataSource = null;
            this.tbcQueryDept.ShowCardHeight = 0;
            this.tbcQueryDept.ShowCardWidth = 0;
            this.tbcQueryDept.Size = new System.Drawing.Size(120, 21);
            this.tbcQueryDept.TabIndex = 2;
            // 
            // cboQueryWorker
            // 
            this.cboQueryWorker.DisplayMember = "WorkName";
            this.cboQueryWorker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQueryWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryWorker.FormattingEnabled = true;
            this.cboQueryWorker.ItemHeight = 15;
            this.cboQueryWorker.Location = new System.Drawing.Point(77, 6);
            this.cboQueryWorker.Name = "cboQueryWorker";
            this.cboQueryWorker.Size = new System.Drawing.Size(121, 21);
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
            this.labelX3.Location = new System.Drawing.Point(12, 8);
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
            this.tbQueryKey.Location = new System.Drawing.Point(445, 6);
            this.tbQueryKey.Name = "tbQueryKey";
            this.tbQueryKey.Size = new System.Drawing.Size(120, 21);
            this.tbQueryKey.TabIndex = 1;
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
            // barUser
            // 
            this.barUser.AntiAlias = true;
            this.barUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.barUser.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.barUser.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barUser.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolbarAdd,
            this.toolbarFlag,
            this.toolbarRefresh,
            this.toolbarRel});
            this.barUser.Location = new System.Drawing.Point(0, 35);
            this.barUser.Margin = new System.Windows.Forms.Padding(0);
            this.barUser.Name = "barUser";
            this.barUser.Size = new System.Drawing.Size(985, 25);
            this.barUser.Stretch = true;
            this.barUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barUser.TabIndex = 26;
            this.barUser.TabStop = false;
            this.barUser.Text = "bar1";
            // 
            // toolbarRel
            // 
            this.toolbarRel.Name = "toolbarRel";
            this.toolbarRel.Text = "关联角色(F4)";
            this.toolbarRel.Click += new System.EventHandler(this.toolbarRel_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx6);
            this.panelEx1.Controls.Add(this.panelEx5);
            this.panelEx1.Controls.Add(this.panelEx3);
            this.panelEx1.Controls.Add(this.barUser);
            this.panelEx1.Controls.Add(this.panelEx4);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(985, 437);
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
            this.panelEx6.Controls.Add(this.dgUser);
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx6.Location = new System.Drawing.Point(241, 60);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(459, 377);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 30;
            this.panelEx6.Text = "panelEx6";
            // 
            // dgUser
            // 
            this.dgUser.AllowSortWhenClickColumnHeader = false;
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AllowUserToDeleteRows = false;
            this.dgUser.AllowUserToResizeColumns = false;
            this.dgUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUser.BackgroundColor = System.Drawing.Color.White;
            this.dgUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.colName,
            this.IsAdmin,
            this.UserType,
            this.Column1,
            this.DoctorPost,
            this.NursePost,
            this.StrLock});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUser.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgUser.HighlightSelectedColumnHeaders = false;
            this.dgUser.Location = new System.Drawing.Point(0, 0);
            this.dgUser.MultiSelect = false;
            this.dgUser.Name = "dgUser";
            this.dgUser.ReadOnly = true;
            this.dgUser.RowHeadersVisible = false;
            this.dgUser.RowHeadersWidth = 30;
            this.dgUser.RowTemplate.Height = 23;
            this.dgUser.SelectAllSignVisible = false;
            this.dgUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUser.SeqVisible = false;
            this.dgUser.SetCustomStyle = true;
            this.dgUser.Size = new System.Drawing.Size(459, 377);
            this.dgUser.TabIndex = 2;
            this.dgUser.CurrentCellChanged += new System.EventHandler(this.dgUser_CurrentCellChanged);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "用户编号";
            this.Code.MinimumWidth = 60;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Code.Width = 80;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "用户姓名";
            this.colName.MinimumWidth = 80;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsAdmin
            // 
            this.IsAdmin.DataPropertyName = "StrIsAdmin";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IsAdmin.DefaultCellStyle = dataGridViewCellStyle3;
            this.IsAdmin.HeaderText = "用户级别";
            this.IsAdmin.MinimumWidth = 80;
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.ReadOnly = true;
            this.IsAdmin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsAdmin.Width = 80;
            // 
            // UserType
            // 
            this.UserType.DataPropertyName = "StrUserType";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UserType.DefaultCellStyle = dataGridViewCellStyle4;
            this.UserType.HeaderText = "用户类型";
            this.UserType.MinimumWidth = 80;
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserType.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DeptName";
            this.Column1.HeaderText = "默认科室";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DoctorPost
            // 
            this.DoctorPost.DataPropertyName = "StrDoctorPost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DoctorPost.DefaultCellStyle = dataGridViewCellStyle5;
            this.DoctorPost.HeaderText = "医生职称";
            this.DoctorPost.MinimumWidth = 100;
            this.DoctorPost.Name = "DoctorPost";
            this.DoctorPost.ReadOnly = true;
            this.DoctorPost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NursePost
            // 
            this.NursePost.DataPropertyName = "StrNursePost";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NursePost.DefaultCellStyle = dataGridViewCellStyle6;
            this.NursePost.HeaderText = "护士职称";
            this.NursePost.MinimumWidth = 100;
            this.NursePost.Name = "NursePost";
            this.NursePost.ReadOnly = true;
            this.NursePost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StrLock
            // 
            this.StrLock.DataPropertyName = "StrLock";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StrLock.DefaultCellStyle = dataGridViewCellStyle7;
            this.StrLock.HeaderText = "状态标识";
            this.StrLock.MinimumWidth = 100;
            this.StrLock.Name = "StrLock";
            this.StrLock.ReadOnly = true;
            this.StrLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panelEx5
            // 
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.dgGroups);
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx5.Location = new System.Drawing.Point(700, 60);
            this.panelEx5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panelEx5.Size = new System.Drawing.Size(285, 377);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 221;
            // 
            // dgGroups
            // 
            this.dgGroups.AllowSortWhenClickColumnHeader = false;
            this.dgGroups.AllowUserToAddRows = false;
            this.dgGroups.AllowUserToDeleteRows = false;
            this.dgGroups.AllowUserToResizeColumns = false;
            this.dgGroups.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            this.dgGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupName,
            this.Memo});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGroups.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGroups.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgGroups.HighlightSelectedColumnHeaders = false;
            this.dgGroups.Location = new System.Drawing.Point(4, 0);
            this.dgGroups.Name = "dgGroups";
            this.dgGroups.ReadOnly = true;
            this.dgGroups.RowHeadersVisible = false;
            this.dgGroups.RowHeadersWidth = 25;
            this.dgGroups.RowTemplate.Height = 23;
            this.dgGroups.SelectAllSignVisible = false;
            this.dgGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGroups.SeqVisible = false;
            this.dgGroups.SetCustomStyle = true;
            this.dgGroups.Size = new System.Drawing.Size(281, 377);
            this.dgGroups.TabIndex = 28;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "Name";
            this.groupName.HeaderText = "角色名称";
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
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.cboUserName);
            this.panelEx3.Controls.Add(this.cboNursePost);
            this.panelEx3.Controls.Add(this.labelX10);
            this.panelEx3.Controls.Add(this.cboDoctorPost);
            this.panelEx3.Controls.Add(this.labelX9);
            this.panelEx3.Controls.Add(this.cboUserType);
            this.panelEx3.Controls.Add(this.labelX8);
            this.panelEx3.Controls.Add(this.labelX5);
            this.panelEx3.Controls.Add(this.btnCancel);
            this.panelEx3.Controls.Add(this.btnReset);
            this.panelEx3.Controls.Add(this.btnSave);
            this.panelEx3.Controls.Add(this.btnQuit);
            this.panelEx3.Controls.Add(this.cboIsAdmin);
            this.panelEx3.Controls.Add(this.labelX23);
            this.panelEx3.Controls.Add(this.tbCode);
            this.panelEx3.Controls.Add(this.labelX37);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx3.Location = new System.Drawing.Point(0, 60);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(241, 377);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 28;
            // 
            // cboUserName
            // 
            // 
            // 
            // 
            this.cboUserName.Border.Class = "TextBoxBorder";
            this.cboUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboUserName.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboUserName.ButtonCustom.Image")));
            this.cboUserName.ButtonCustom.Visible = true;
            this.cboUserName.CardColumn = null;
            this.cboUserName.DisplayField = "";
            this.cboUserName.IsEnterShowCard = true;
            this.cboUserName.IsNumSelected = false;
            this.cboUserName.IsPage = true;
            this.cboUserName.IsShowLetter = false;
            this.cboUserName.IsShowPage = false;
            this.cboUserName.IsShowSeq = false;
            this.cboUserName.Location = new System.Drawing.Point(72, 34);
            this.cboUserName.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cboUserName.MemberField = "";
            this.cboUserName.MemberValue = null;
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.QueryFields = new string[] {
        ""};
            this.cboUserName.QueryFieldsString = "";
            this.cboUserName.SelectedValue = null;
            this.cboUserName.ShowCardColumns = null;
            this.cboUserName.ShowCardDataSource = null;
            this.cboUserName.ShowCardHeight = 0;
            this.cboUserName.ShowCardWidth = 0;
            this.cboUserName.Size = new System.Drawing.Size(156, 21);
            this.cboUserName.TabIndex = 221;
            // 
            // cboNursePost
            // 
            this.cboNursePost.DisplayMember = "Name";
            this.cboNursePost.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNursePost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNursePost.FormattingEnabled = true;
            this.cboNursePost.ItemHeight = 15;
            this.cboNursePost.Location = new System.Drawing.Point(72, 146);
            this.cboNursePost.Name = "cboNursePost";
            this.cboNursePost.Size = new System.Drawing.Size(156, 21);
            this.cboNursePost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboNursePost.TabIndex = 13;
            this.cboNursePost.ValueMember = "Code";
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(6, 148);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(56, 18);
            this.labelX10.TabIndex = 220;
            this.labelX10.Text = "护士职称";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboDoctorPost
            // 
            this.cboDoctorPost.DisplayMember = "Name";
            this.cboDoctorPost.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDoctorPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctorPost.FormattingEnabled = true;
            this.cboDoctorPost.ItemHeight = 15;
            this.cboDoctorPost.Location = new System.Drawing.Point(72, 118);
            this.cboDoctorPost.Name = "cboDoctorPost";
            this.cboDoctorPost.Size = new System.Drawing.Size(156, 21);
            this.cboDoctorPost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDoctorPost.TabIndex = 12;
            this.cboDoctorPost.ValueMember = "Code";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(6, 120);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(56, 18);
            this.labelX9.TabIndex = 218;
            this.labelX9.Text = "医生职称";
            this.labelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboUserType
            // 
            this.cboUserType.DisplayMember = "Text";
            this.cboUserType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserType.FormattingEnabled = true;
            this.cboUserType.ItemHeight = 15;
            this.cboUserType.Location = new System.Drawing.Point(72, 90);
            this.cboUserType.Name = "cboUserType";
            this.cboUserType.Size = new System.Drawing.Size(156, 21);
            this.cboUserType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboUserType.TabIndex = 11;
            this.cboUserType.ValueMember = "Value";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(6, 92);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(56, 18);
            this.labelX8.TabIndex = 216;
            this.labelX8.Text = "用户类型";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Far;
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
            this.labelX5.Location = new System.Drawing.Point(6, 36);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX5.TabIndex = 211;
            this.labelX5.Text = "员工姓名";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(72, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消(F10)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(72, 173);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "重置(F6)";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(153, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuit.Location = new System.Drawing.Point(153, 204);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 25);
            this.btnQuit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuit.TabIndex = 17;
            this.btnQuit.Text = "关闭(F7)";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // cboIsAdmin
            // 
            this.cboIsAdmin.DisplayMember = "Text";
            this.cboIsAdmin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboIsAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsAdmin.FormattingEnabled = true;
            this.cboIsAdmin.ItemHeight = 15;
            this.cboIsAdmin.Location = new System.Drawing.Point(72, 62);
            this.cboIsAdmin.Name = "cboIsAdmin";
            this.cboIsAdmin.Size = new System.Drawing.Size(156, 21);
            this.cboIsAdmin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboIsAdmin.TabIndex = 10;
            this.cboIsAdmin.ValueMember = "Value";
            // 
            // labelX23
            // 
            this.labelX23.AutoSize = true;
            this.labelX23.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX23.Location = new System.Drawing.Point(6, 64);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(56, 18);
            this.labelX23.TabIndex = 199;
            this.labelX23.Text = "用户级别";
            this.labelX23.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbCode
            // 
            // 
            // 
            // 
            this.tbCode.Border.Class = "TextBoxBorder";
            this.tbCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCode.Location = new System.Drawing.Point(72, 6);
            this.tbCode.MaxLength = 25;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(156, 21);
            this.tbCode.TabIndex = 6;
            // 
            // labelX37
            // 
            this.labelX37.AutoSize = true;
            this.labelX37.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX37.ForeColor = System.Drawing.Color.DarkViolet;
            this.labelX37.Location = new System.Drawing.Point(6, 8);
            this.labelX37.Name = "labelX37";
            this.labelX37.Size = new System.Drawing.Size(56, 18);
            this.labelX37.SymbolColor = System.Drawing.Color.Transparent;
            this.labelX37.TabIndex = 142;
            this.labelX37.Text = "用户编号";
            this.labelX37.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // frmUserForm
            // 
            this.frmUserForm.IsSkip = true;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 437);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmUser";
            this.Text = "";
            this.OpenWindowBefore += new System.EventHandler(this.FrmEmp_OpenWindowBefore);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEmp_KeyDown);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barUser)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.panelEx5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGroups)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EfwControls.CustomControl.frmForm frmUserForm;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.ButtonItem toolbarRefresh;
        private DevComponents.DotNetBar.ButtonItem toolbarFlag;
        private DevComponents.DotNetBar.ButtonItem toolbarAdd;
        private DevComponents.DotNetBar.Bar barUser;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private EfwControls.CustomControl.DataGrid dgUser;
        private DevComponents.DotNetBar.Controls.TextBoxX tbQueryKey;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboQueryWorker;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonItem toolbarRel;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnQuit;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIsAdmin;
        private DevComponents.DotNetBar.LabelX labelX23;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCode;
        private DevComponents.DotNetBar.LabelX labelX37;
        private EfwControls.CustomControl.TextBoxCard tbcQueryDept;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbQuery;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUserType;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboNursePost;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDoctorPost;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private EfwControls.CustomControl.DataGrid dgGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private EfwControls.CustomControl.TextBoxCard cboUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn NursePost;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
    }
}