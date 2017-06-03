namespace HIS_BasicData.Winform.ViewForm.Entrust
{
    partial class FrmAttachAdvice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAttachAdvice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.txtQueryName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbbWork = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnNew = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnStop = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtSpec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtWB = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtPY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgEntrust = new EfwControls.CustomControl.DataGrid();
            this.tbUnit = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PYCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WBCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseFalgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntrust)).BeginInit();
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
            this.panelEx1.Size = new System.Drawing.Size(1157, 46);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(658, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭（&C）";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(566, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 4;
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
            this.txtQueryName.Location = new System.Drawing.Point(330, 12);
            this.txtQueryName.Name = "txtQueryName";
            this.txtQueryName.Size = new System.Drawing.Size(221, 21);
            this.txtQueryName.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(292, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "名称";
            // 
            // cbbWork
            // 
            this.cbbWork.DisplayMember = "WORKNAME";
            this.cbbWork.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWork.FormattingEnabled = true;
            this.cbbWork.ItemHeight = 15;
            this.cbbWork.Location = new System.Drawing.Point(91, 12);
            this.cbbWork.Name = "cbbWork";
            this.cbbWork.Size = new System.Drawing.Size(184, 21);
            this.cbbWork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbWork.TabIndex = 1;
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
            this.labelX1.Location = new System.Drawing.Point(29, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "医疗机构";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnStop,
            this.btnRefresh});
            this.bar2.Location = new System.Drawing.Point(0, 46);
            this.bar2.Name = "bar2";
            this.bar2.PaddingLeft = 28;
            this.bar2.Size = new System.Drawing.Size(1157, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 6;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
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
            // btnRefresh
            // 
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.dgEntrust);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 71);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(842, 452);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 9;
            this.panelEx3.Text = "panelEx3";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.tbUnit);
            this.panelEx2.Controls.Add(this.labelX8);
            this.panelEx2.Controls.Add(this.txtSpec);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.txtCode);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.Controls.Add(this.btnCancel);
            this.panelEx2.Controls.Add(this.txtWB);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.txtPY);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.txtName);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx2.Location = new System.Drawing.Point(842, 71);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(315, 452);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 8;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(26, 138);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(31, 18);
            this.labelX8.TabIndex = 24;
            this.labelX8.Text = "单位";
            // 
            // txtSpec
            // 
            // 
            // 
            // 
            this.txtSpec.Border.Class = "TextBoxBorder";
            this.txtSpec.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSpec.Enabled = false;
            this.txtSpec.Location = new System.Drawing.Point(66, 96);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(236, 21);
            this.txtSpec.TabIndex = 23;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(26, 99);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(31, 18);
            this.labelX7.TabIndex = 22;
            this.labelX7.Text = "规格";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(64, 18);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(236, 21);
            this.txtCode.TabIndex = 21;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(26, 21);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(31, 18);
            this.labelX6.TabIndex = 20;
            this.labelX6.Text = "编码";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(227, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存（&S）";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(136, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消（&C）";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtWB
            // 
            // 
            // 
            // 
            this.txtWB.Border.Class = "TextBoxBorder";
            this.txtWB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWB.Enabled = false;
            this.txtWB.Location = new System.Drawing.Point(67, 213);
            this.txtWB.Name = "txtWB";
            this.txtWB.Size = new System.Drawing.Size(236, 21);
            this.txtWB.TabIndex = 17;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(16, 216);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(44, 18);
            this.labelX5.TabIndex = 16;
            this.labelX5.Text = "五笔码";
            // 
            // txtPY
            // 
            // 
            // 
            // 
            this.txtPY.Border.Class = "TextBoxBorder";
            this.txtPY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPY.Enabled = false;
            this.txtPY.Location = new System.Drawing.Point(67, 174);
            this.txtPY.Name = "txtPY";
            this.txtPY.Size = new System.Drawing.Size(236, 21);
            this.txtPY.TabIndex = 15;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(16, 177);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 18);
            this.labelX4.TabIndex = 14;
            this.labelX4.Text = "拼音码";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(65, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 21);
            this.txtName.TabIndex = 13;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Purple;
            this.labelX3.Location = new System.Drawing.Point(27, 60);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(31, 18);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = "名称";
            // 
            // dgEntrust
            // 
            this.dgEntrust.AllowSortWhenClickColumnHeader = false;
            this.dgEntrust.AllowUserToAddRows = false;
            this.dgEntrust.AllowUserToDeleteRows = false;
            this.dgEntrust.AllowUserToResizeColumns = false;
            this.dgEntrust.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgEntrust.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEntrust.BackgroundColor = System.Drawing.Color.White;
            this.dgEntrust.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEntrust.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgEntrust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntrust.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemName,
            this.ItemSpec,
            this.Unit,
            this.PYCode,
            this.WBCode,
            this.UseFalgDesc,
            this.DelFlag});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEntrust.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgEntrust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEntrust.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgEntrust.HighlightSelectedColumnHeaders = false;
            this.dgEntrust.Location = new System.Drawing.Point(0, 0);
            this.dgEntrust.MultiSelect = false;
            this.dgEntrust.Name = "dgEntrust";
            this.dgEntrust.ReadOnly = true;
            this.dgEntrust.RowHeadersWidth = 30;
            this.dgEntrust.RowTemplate.Height = 23;
            this.dgEntrust.SelectAllSignVisible = false;
            this.dgEntrust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEntrust.SeqVisible = true;
            this.dgEntrust.SetCustomStyle = false;
            this.dgEntrust.Size = new System.Drawing.Size(842, 452);
            this.dgEntrust.TabIndex = 3;
            this.dgEntrust.CurrentCellChanged += new System.EventHandler(this.dgEntrust_CurrentCellChanged);
            // 
            // tbUnit
            // 
            // 
            // 
            // 
            this.tbUnit.Border.Class = "TextBoxBorder";
            this.tbUnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUnit.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("tbUnit.ButtonCustom.Image")));
            this.tbUnit.ButtonCustom.Visible = true;
            this.tbUnit.CardColumn = null;
            this.tbUnit.DisplayField = "";
            this.tbUnit.Enabled = false;
            this.tbUnit.IsEnterShowCard = true;
            this.tbUnit.IsNumSelected = false;
            this.tbUnit.IsPage = true;
            this.tbUnit.IsShowLetter = false;
            this.tbUnit.IsShowPage = false;
            this.tbUnit.IsShowSeq = true;
            this.tbUnit.Location = new System.Drawing.Point(67, 135);
            this.tbUnit.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.tbUnit.MemberField = "";
            this.tbUnit.MemberValue = null;
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.QueryFields = new string[] {
        ""};
            this.tbUnit.QueryFieldsString = "";
            this.tbUnit.SelectedValue = null;
            this.tbUnit.ShowCardColumns = null;
            this.tbUnit.ShowCardDataSource = null;
            this.tbUnit.ShowCardHeight = 0;
            this.tbUnit.ShowCardWidth = 0;
            this.tbUnit.Size = new System.Drawing.Size(233, 21);
            this.tbUnit.TabIndex = 26;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "编码";
            this.ItemCode.MinimumWidth = 100;
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "说明性医嘱名称";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemSpec
            // 
            this.ItemSpec.DataPropertyName = "ItemSpec";
            this.ItemSpec.HeaderText = "规格";
            this.ItemSpec.Name = "ItemSpec";
            this.ItemSpec.ReadOnly = true;
            this.ItemSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UnitName";
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PYCode
            // 
            this.PYCode.DataPropertyName = "PYCode";
            this.PYCode.HeaderText = "拼音码";
            this.PYCode.MinimumWidth = 80;
            this.PYCode.Name = "PYCode";
            this.PYCode.ReadOnly = true;
            this.PYCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WBCode
            // 
            this.WBCode.DataPropertyName = "WBCode";
            this.WBCode.HeaderText = "五笔码";
            this.WBCode.MinimumWidth = 80;
            this.WBCode.Name = "WBCode";
            this.WBCode.ReadOnly = true;
            this.WBCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UseFalgDesc
            // 
            this.UseFalgDesc.DataPropertyName = "UseFalgDesc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UseFalgDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.UseFalgDesc.HeaderText = "状态";
            this.UseFalgDesc.MinimumWidth = 50;
            this.UseFalgDesc.Name = "UseFalgDesc";
            this.UseFalgDesc.ReadOnly = true;
            this.UseFalgDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DelFlag
            // 
            this.DelFlag.HeaderText = "DelFlag";
            this.DelFlag.Name = "DelFlag";
            this.DelFlag.ReadOnly = true;
            this.DelFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DelFlag.Visible = false;
            // 
            // FrmAttachAdvice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 523);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmAttachAdvice";
            this.Text = "FrmAttachAdvice";
            this.OpenWindowBefore += new System.EventHandler(this.FrmAttachAdvice_OpenWindowBefore);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntrust)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQueryName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbWork;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnNew;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnStop;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private EfwControls.CustomControl.DataGrid dgEntrust;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSpec;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWB;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPY;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private EfwControls.CustomControl.TextBoxCard tbUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PYCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WBCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseFalgDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelFlag;
    }
}