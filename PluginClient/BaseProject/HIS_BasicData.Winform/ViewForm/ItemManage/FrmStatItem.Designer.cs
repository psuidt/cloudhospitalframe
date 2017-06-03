namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    partial class FrmStatItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatItem));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.treeStat = new DevComponents.AdvTree.AdvTree();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader7 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader9 = new DevComponents.AdvTree.ColumnHeader();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtStatName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.ckAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.cbWorkers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btndetail = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.cbInFpItem = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbOutFpItem = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbPoItem = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbBaItem = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbCostItem = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbAccItem = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.frmFormItem = new EfwControls.CustomControl.frmForm(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeStat)).BeginInit();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.treeStat);
            this.panelEx1.Controls.Add(this.expandablePanel1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(924, 562);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "panelEx1";
            // 
            // treeStat
            // 
            this.treeStat.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeStat.AllowDrop = true;
            this.treeStat.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeStat.BackgroundStyle.Class = "TreeBorderKey";
            this.treeStat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeStat.Columns.Add(this.columnHeader2);
            this.treeStat.Columns.Add(this.columnHeader1);
            this.treeStat.Columns.Add(this.columnHeader3);
            this.treeStat.Columns.Add(this.columnHeader4);
            this.treeStat.Columns.Add(this.columnHeader5);
            this.treeStat.Columns.Add(this.columnHeader6);
            this.treeStat.Columns.Add(this.columnHeader7);
            this.treeStat.Columns.Add(this.columnHeader8);
            this.treeStat.Columns.Add(this.columnHeader9);
            this.treeStat.ColumnStyleNormal = this.elementStyle2;
            this.treeStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeStat.Location = new System.Drawing.Point(0, 0);
            this.treeStat.Name = "treeStat";
            this.treeStat.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.treeStat.NodesConnector = this.nodeConnector1;
            this.treeStat.NodeStyle = this.elementStyle1;
            this.treeStat.PathSeparator = ";";
            this.treeStat.Size = new System.Drawing.Size(609, 562);
            this.treeStat.Styles.Add(this.elementStyle1);
            this.treeStat.Styles.Add(this.elementStyle2);
            this.treeStat.TabIndex = 1;
            this.treeStat.Text = "advTree1";
            this.treeStat.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.treeStat_AfterNodeSelect);
            // 
            // columnHeader2
            // 
            this.columnHeader2.MinimumWidth = 150;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.MinimumWidth = 70;
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width.Absolute = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.MinimumWidth = 100;
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "会计分类";
            this.columnHeader3.Width.Absolute = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.MinimumWidth = 100;
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "核算分类";
            this.columnHeader4.Width.Absolute = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.MinimumWidth = 100;
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "病案分类";
            this.columnHeader5.Width.Absolute = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.MinimumWidth = 100;
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "医保分类";
            this.columnHeader6.Width.Absolute = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.MinimumWidth = 100;
            this.columnHeader7.Name = "columnHeader7";
            this.columnHeader7.Text = "门诊发票";
            this.columnHeader7.Width.Absolute = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.MinimumWidth = 100;
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.Text = "住院发票";
            this.columnHeader8.Width.Absolute = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.MinimumWidth = 100;
            this.columnHeader9.Name = "columnHeader9";
            this.columnHeader9.Text = "状态标识";
            this.columnHeader9.Width.Absolute = 100;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 6;
            this.elementStyle2.PaddingTop = 6;
            this.elementStyle2.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
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
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.txtStatName);
            this.expandablePanel1.Controls.Add(this.labelX8);
            this.expandablePanel1.Controls.Add(this.ckAll);
            this.expandablePanel1.Controls.Add(this.line1);
            this.expandablePanel1.Controls.Add(this.cbWorkers);
            this.expandablePanel1.Controls.Add(this.labelX1);
            this.expandablePanel1.Controls.Add(this.btndetail);
            this.expandablePanel1.Controls.Add(this.btnClose);
            this.expandablePanel1.Controls.Add(this.btnSave);
            this.expandablePanel1.Controls.Add(this.cbInFpItem);
            this.expandablePanel1.Controls.Add(this.labelX6);
            this.expandablePanel1.Controls.Add(this.cbOutFpItem);
            this.expandablePanel1.Controls.Add(this.labelX7);
            this.expandablePanel1.Controls.Add(this.cbPoItem);
            this.expandablePanel1.Controls.Add(this.labelX4);
            this.expandablePanel1.Controls.Add(this.cbBaItem);
            this.expandablePanel1.Controls.Add(this.labelX5);
            this.expandablePanel1.Controls.Add(this.cbCostItem);
            this.expandablePanel1.Controls.Add(this.labelX3);
            this.expandablePanel1.Controls.Add(this.cbAccItem);
            this.expandablePanel1.Controls.Add(this.labelX2);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(609, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(315, 562);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 2;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "明细分类设置";
            // 
            // txtStatName
            // 
            // 
            // 
            // 
            this.txtStatName.Border.Class = "TextBoxBorder";
            this.txtStatName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStatName.Enabled = false;
            this.txtStatName.Location = new System.Drawing.Point(105, 129);
            this.txtStatName.Name = "txtStatName";
            this.txtStatName.Size = new System.Drawing.Size(164, 21);
            this.txtStatName.TabIndex = 28;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(24, 129);
            this.labelX8.Name = "labelX8";
            this.labelX8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 27;
            this.labelX8.Text = "统计分类";
            // 
            // ckAll
            // 
            this.ckAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ckAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckAll.CheckValue = "0";
            this.ckAll.CheckValueChecked = "1";
            this.ckAll.CheckValueUnchecked = "0";
            this.ckAll.Location = new System.Drawing.Point(105, 76);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(100, 23);
            this.ckAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckAll.TabIndex = 26;
            this.ckAll.Text = "显示全部";
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Transparent;
            this.line1.ForeColor = System.Drawing.Color.Silver;
            this.line1.Location = new System.Drawing.Point(5, 106);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(307, 23);
            this.line1.TabIndex = 25;
            this.line1.Text = "line1";
            // 
            // cbWorkers
            // 
            this.cbWorkers.DisplayMember = "Text";
            this.cbWorkers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbWorkers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkers.FormattingEnabled = true;
            this.cbWorkers.ItemHeight = 15;
            this.cbWorkers.Location = new System.Drawing.Point(105, 48);
            this.cbWorkers.Name = "cbWorkers";
            this.cbWorkers.Size = new System.Drawing.Size(165, 21);
            this.cbWorkers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWorkers.TabIndex = 24;
            this.cbWorkers.SelectedIndexChanged += new System.EventHandler(this.cbWorkers_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(24, 48);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 23;
            this.labelX1.Text = "医疗机构";
            // 
            // btndetail
            // 
            this.btndetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btndetail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btndetail.Location = new System.Drawing.Point(105, 378);
            this.btndetail.Name = "btndetail";
            this.btndetail.Size = new System.Drawing.Size(165, 23);
            this.btndetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndetail.TabIndex = 22;
            this.btndetail.Text = "维护明细分类";
            this.btndetail.Click += new System.EventHandler(this.btndetail_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(195, 337);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(105, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbInFpItem
            // 
            // 
            // 
            // 
            this.cbInFpItem.Border.Class = "TextBoxBorder";
            this.cbInFpItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbInFpItem.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cbInFpItem.ButtonCustom.Image")));
            this.cbInFpItem.ButtonCustom.Visible = true;
            this.cbInFpItem.CardColumn = null;
            this.cbInFpItem.DisplayField = "";
            this.cbInFpItem.IsEnterShowCard = true;
            this.cbInFpItem.IsNumSelected = false;
            this.cbInFpItem.IsPage = true;
            this.cbInFpItem.IsShowLetter = false;
            this.cbInFpItem.IsShowPage = false;
            this.cbInFpItem.IsShowSeq = true;
            this.cbInFpItem.Location = new System.Drawing.Point(105, 293);
            this.cbInFpItem.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cbInFpItem.MemberField = "";
            this.cbInFpItem.MemberValue = null;
            this.cbInFpItem.Name = "cbInFpItem";
            this.cbInFpItem.QueryFields = new string[] {
        ""};
            this.cbInFpItem.QueryFieldsString = "";
            this.cbInFpItem.SelectedValue = null;
            this.cbInFpItem.ShowCardColumns = null;
            this.cbInFpItem.ShowCardDataSource = null;
            this.cbInFpItem.ShowCardHeight = 0;
            this.cbInFpItem.ShowCardWidth = 0;
            this.cbInFpItem.Size = new System.Drawing.Size(165, 21);
            this.cbInFpItem.TabIndex = 15;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(24, 293);
            this.labelX6.Name = "labelX6";
            this.labelX6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 14;
            this.labelX6.Text = "住院发票";
            // 
            // cbOutFpItem
            // 
            // 
            // 
            // 
            this.cbOutFpItem.Border.Class = "TextBoxBorder";
            this.cbOutFpItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbOutFpItem.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cbOutFpItem.ButtonCustom.Image")));
            this.cbOutFpItem.ButtonCustom.Visible = true;
            this.cbOutFpItem.CardColumn = null;
            this.cbOutFpItem.DisplayField = "";
            this.cbOutFpItem.IsEnterShowCard = true;
            this.cbOutFpItem.IsNumSelected = false;
            this.cbOutFpItem.IsPage = true;
            this.cbOutFpItem.IsShowLetter = false;
            this.cbOutFpItem.IsShowPage = false;
            this.cbOutFpItem.IsShowSeq = true;
            this.cbOutFpItem.Location = new System.Drawing.Point(105, 266);
            this.cbOutFpItem.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cbOutFpItem.MemberField = "";
            this.cbOutFpItem.MemberValue = null;
            this.cbOutFpItem.Name = "cbOutFpItem";
            this.cbOutFpItem.QueryFields = new string[] {
        ""};
            this.cbOutFpItem.QueryFieldsString = "";
            this.cbOutFpItem.SelectedValue = null;
            this.cbOutFpItem.ShowCardColumns = null;
            this.cbOutFpItem.ShowCardDataSource = null;
            this.cbOutFpItem.ShowCardHeight = 0;
            this.cbOutFpItem.ShowCardWidth = 0;
            this.cbOutFpItem.Size = new System.Drawing.Size(165, 21);
            this.cbOutFpItem.TabIndex = 13;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(24, 266);
            this.labelX7.Name = "labelX7";
            this.labelX7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 12;
            this.labelX7.Text = "门诊发票";
            // 
            // cbPoItem
            // 
            // 
            // 
            // 
            this.cbPoItem.Border.Class = "TextBoxBorder";
            this.cbPoItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbPoItem.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cbPoItem.ButtonCustom.Image")));
            this.cbPoItem.ButtonCustom.Visible = true;
            this.cbPoItem.CardColumn = null;
            this.cbPoItem.DisplayField = "";
            this.cbPoItem.IsEnterShowCard = true;
            this.cbPoItem.IsNumSelected = false;
            this.cbPoItem.IsPage = true;
            this.cbPoItem.IsShowLetter = false;
            this.cbPoItem.IsShowPage = false;
            this.cbPoItem.IsShowSeq = true;
            this.cbPoItem.Location = new System.Drawing.Point(105, 239);
            this.cbPoItem.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cbPoItem.MemberField = "";
            this.cbPoItem.MemberValue = null;
            this.cbPoItem.Name = "cbPoItem";
            this.cbPoItem.QueryFields = new string[] {
        ""};
            this.cbPoItem.QueryFieldsString = "";
            this.cbPoItem.SelectedValue = null;
            this.cbPoItem.ShowCardColumns = null;
            this.cbPoItem.ShowCardDataSource = null;
            this.cbPoItem.ShowCardHeight = 0;
            this.cbPoItem.ShowCardWidth = 0;
            this.cbPoItem.Size = new System.Drawing.Size(165, 21);
            this.cbPoItem.TabIndex = 11;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(24, 239);
            this.labelX4.Name = "labelX4";
            this.labelX4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "医保分类";
            // 
            // cbBaItem
            // 
            // 
            // 
            // 
            this.cbBaItem.Border.Class = "TextBoxBorder";
            this.cbBaItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbBaItem.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cbBaItem.ButtonCustom.Image")));
            this.cbBaItem.ButtonCustom.Visible = true;
            this.cbBaItem.CardColumn = null;
            this.cbBaItem.DisplayField = "";
            this.cbBaItem.IsEnterShowCard = true;
            this.cbBaItem.IsNumSelected = false;
            this.cbBaItem.IsPage = true;
            this.cbBaItem.IsShowLetter = false;
            this.cbBaItem.IsShowPage = false;
            this.cbBaItem.IsShowSeq = true;
            this.cbBaItem.Location = new System.Drawing.Point(105, 212);
            this.cbBaItem.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cbBaItem.MemberField = "";
            this.cbBaItem.MemberValue = null;
            this.cbBaItem.Name = "cbBaItem";
            this.cbBaItem.QueryFields = new string[] {
        ""};
            this.cbBaItem.QueryFieldsString = "";
            this.cbBaItem.SelectedValue = null;
            this.cbBaItem.ShowCardColumns = null;
            this.cbBaItem.ShowCardDataSource = null;
            this.cbBaItem.ShowCardHeight = 0;
            this.cbBaItem.ShowCardWidth = 0;
            this.cbBaItem.Size = new System.Drawing.Size(165, 21);
            this.cbBaItem.TabIndex = 9;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(24, 212);
            this.labelX5.Name = "labelX5";
            this.labelX5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "病案分类";
            // 
            // cbCostItem
            // 
            // 
            // 
            // 
            this.cbCostItem.Border.Class = "TextBoxBorder";
            this.cbCostItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbCostItem.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cbCostItem.ButtonCustom.Image")));
            this.cbCostItem.ButtonCustom.Visible = true;
            this.cbCostItem.CardColumn = null;
            this.cbCostItem.DisplayField = "";
            this.cbCostItem.IsEnterShowCard = true;
            this.cbCostItem.IsNumSelected = false;
            this.cbCostItem.IsPage = true;
            this.cbCostItem.IsShowLetter = false;
            this.cbCostItem.IsShowPage = false;
            this.cbCostItem.IsShowSeq = true;
            this.cbCostItem.Location = new System.Drawing.Point(105, 185);
            this.cbCostItem.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cbCostItem.MemberField = "";
            this.cbCostItem.MemberValue = null;
            this.cbCostItem.Name = "cbCostItem";
            this.cbCostItem.QueryFields = new string[] {
        ""};
            this.cbCostItem.QueryFieldsString = "";
            this.cbCostItem.SelectedValue = null;
            this.cbCostItem.ShowCardColumns = null;
            this.cbCostItem.ShowCardDataSource = null;
            this.cbCostItem.ShowCardHeight = 0;
            this.cbCostItem.ShowCardWidth = 0;
            this.cbCostItem.Size = new System.Drawing.Size(165, 21);
            this.cbCostItem.TabIndex = 7;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(24, 185);
            this.labelX3.Name = "labelX3";
            this.labelX3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "核算分类";
            // 
            // cbAccItem
            // 
            // 
            // 
            // 
            this.cbAccItem.Border.Class = "TextBoxBorder";
            this.cbAccItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbAccItem.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cbAccItem.ButtonCustom.Image")));
            this.cbAccItem.ButtonCustom.Visible = true;
            this.cbAccItem.CardColumn = null;
            this.cbAccItem.DisplayField = "";
            this.cbAccItem.IsEnterShowCard = true;
            this.cbAccItem.IsNumSelected = false;
            this.cbAccItem.IsPage = true;
            this.cbAccItem.IsShowLetter = false;
            this.cbAccItem.IsShowPage = false;
            this.cbAccItem.IsShowSeq = true;
            this.cbAccItem.Location = new System.Drawing.Point(105, 158);
            this.cbAccItem.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.cbAccItem.MemberField = "";
            this.cbAccItem.MemberValue = null;
            this.cbAccItem.Name = "cbAccItem";
            this.cbAccItem.QueryFields = new string[] {
        ""};
            this.cbAccItem.QueryFieldsString = "";
            this.cbAccItem.SelectedValue = null;
            this.cbAccItem.ShowCardColumns = null;
            this.cbAccItem.ShowCardDataSource = null;
            this.cbAccItem.ShowCardHeight = 0;
            this.cbAccItem.ShowCardWidth = 0;
            this.cbAccItem.Size = new System.Drawing.Size(165, 21);
            this.cbAccItem.TabIndex = 5;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(24, 158);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "会计分类";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "修改";
            // 
            // frmFormItem
            // 
            this.frmFormItem.IsSkip = true;
            // 
            // FrmStatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 562);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmStatItem";
            this.Text = "FrmStatItem";
            this.OpenWindowBefore += new System.EventHandler(this.FrmStatItem_OpenWindowBefore);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeStat)).EndInit();
            this.expandablePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.AdvTree.AdvTree treeStat;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private DevComponents.AdvTree.ColumnHeader columnHeader9;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private EfwControls.CustomControl.TextBoxCard cbAccItem;
        private DevComponents.DotNetBar.LabelX labelX2;
        private EfwControls.CustomControl.TextBoxCard cbCostItem;
        private DevComponents.DotNetBar.LabelX labelX3;
        private EfwControls.CustomControl.TextBoxCard cbBaItem;
        private DevComponents.DotNetBar.LabelX labelX5;
        private EfwControls.CustomControl.TextBoxCard cbPoItem;
        private DevComponents.DotNetBar.LabelX labelX4;
        private EfwControls.CustomControl.TextBoxCard cbOutFpItem;
        private DevComponents.DotNetBar.LabelX labelX7;
        private EfwControls.CustomControl.TextBoxCard cbInFpItem;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btndetail;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbWorkers;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckAll;
        private EfwControls.CustomControl.frmForm frmFormItem;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStatName;
        private DevComponents.DotNetBar.LabelX labelX8;
    }
}