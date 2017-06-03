namespace EfwControls.CustomControl
{
    partial class Pager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pager));
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.refresh = new DevComponents.DotNetBar.ButtonX();
            this.lastpage = new DevComponents.DotNetBar.ButtonX();
            this.nextpage = new DevComponents.DotNetBar.ButtonX();
            this.previouspage = new DevComponents.DotNetBar.ButtonX();
            this.headpage = new DevComponents.DotNetBar.ButtonX();
            this.currentpage = new DevComponents.Editors.IntegerInput();
            this.labtotalPage = new DevComponents.DotNetBar.LabelX();
            this.pageCount = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labtotalCount = new DevComponents.DotNetBar.LabelX();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentpage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.refresh);
            this.panelEx3.Controls.Add(this.lastpage);
            this.panelEx3.Controls.Add(this.nextpage);
            this.panelEx3.Controls.Add(this.previouspage);
            this.panelEx3.Controls.Add(this.headpage);
            this.panelEx3.Controls.Add(this.currentpage);
            this.panelEx3.Controls.Add(this.labtotalPage);
            this.panelEx3.Controls.Add(this.pageCount);
            this.panelEx3.Controls.Add(this.labelX3);
            this.panelEx3.Controls.Add(this.labtotalCount);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(607, 28);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 7;
            // 
            // refresh
            // 
            this.refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refresh.Image")));
            this.refresh.Location = new System.Drawing.Point(573, 5);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(16, 16);
            this.refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.refresh.TabIndex = 20;
            this.refresh.Click += new System.EventHandler(this.page_ValueChanged);
            // 
            // lastpage
            // 
            this.lastpage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.lastpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lastpage.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.lastpage.Image = ((System.Drawing.Image)(resources.GetObject("lastpage.Image")));
            this.lastpage.Location = new System.Drawing.Point(549, 5);
            this.lastpage.Name = "lastpage";
            this.lastpage.Size = new System.Drawing.Size(16, 16);
            this.lastpage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lastpage.TabIndex = 19;
            this.lastpage.Click += new System.EventHandler(this.page_ValueChanged);
            // 
            // nextpage
            // 
            this.nextpage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.nextpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextpage.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.nextpage.Image = ((System.Drawing.Image)(resources.GetObject("nextpage.Image")));
            this.nextpage.Location = new System.Drawing.Point(525, 5);
            this.nextpage.Name = "nextpage";
            this.nextpage.Size = new System.Drawing.Size(16, 16);
            this.nextpage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.nextpage.TabIndex = 18;
            this.nextpage.Click += new System.EventHandler(this.page_ValueChanged);
            // 
            // previouspage
            // 
            this.previouspage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.previouspage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previouspage.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.previouspage.Image = ((System.Drawing.Image)(resources.GetObject("previouspage.Image")));
            this.previouspage.Location = new System.Drawing.Point(432, 5);
            this.previouspage.Name = "previouspage";
            this.previouspage.Size = new System.Drawing.Size(16, 16);
            this.previouspage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.previouspage.TabIndex = 17;
            this.previouspage.Click += new System.EventHandler(this.page_ValueChanged);
            // 
            // headpage
            // 
            this.headpage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.headpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.headpage.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.headpage.Image = ((System.Drawing.Image)(resources.GetObject("headpage.Image")));
            this.headpage.Location = new System.Drawing.Point(408, 5);
            this.headpage.Name = "headpage";
            this.headpage.Size = new System.Drawing.Size(16, 16);
            this.headpage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.headpage.TabIndex = 16;
            this.headpage.Click += new System.EventHandler(this.page_ValueChanged);
            // 
            // currentpage
            // 
            this.currentpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.currentpage.BackgroundStyle.Class = "DateTimeInputBackground";
            this.currentpage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.currentpage.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.currentpage.Location = new System.Drawing.Point(454, 3);
            this.currentpage.MinValue = 1;
            this.currentpage.Name = "currentpage";
            this.currentpage.Size = new System.Drawing.Size(41, 21);
            this.currentpage.TabIndex = 15;
            this.currentpage.Value = 1;
            this.currentpage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.currentpage_KeyUp);
            // 
            // labtotalPage
            // 
            this.labtotalPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labtotalPage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtotalPage.Location = new System.Drawing.Point(495, 5);
            this.labtotalPage.Name = "labtotalPage";
            this.labtotalPage.Size = new System.Drawing.Size(34, 16);
            this.labtotalPage.TabIndex = 14;
            this.labtotalPage.Text = "/25";
            // 
            // pageCount
            // 
            this.pageCount.AutoCompleteCustomSource.AddRange(new string[] {
            "10",
            "20",
            "50",
            "100"});
            this.pageCount.DisplayMember = "Text";
            this.pageCount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pageCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageCount.FormattingEnabled = true;
            this.pageCount.ItemHeight = 15;
            this.pageCount.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5});
            this.pageCount.Location = new System.Drawing.Point(117, 3);
            this.pageCount.Name = "pageCount";
            this.pageCount.Size = new System.Drawing.Size(55, 21);
            this.pageCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pageCount.TabIndex = 5;
            this.pageCount.SelectedIndexChanged += new System.EventHandler(this.pageCount_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "10";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "20";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "50";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "100";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "200";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX3.Location = new System.Drawing.Point(62, 0);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(59, 28);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "每页显示";
            // 
            // labtotalCount
            // 
            // 
            // 
            // 
            this.labtotalCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtotalCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labtotalCount.Location = new System.Drawing.Point(0, 0);
            this.labtotalCount.Name = "labtotalCount";
            this.labtotalCount.PaddingLeft = 5;
            this.labtotalCount.Size = new System.Drawing.Size(62, 28);
            this.labtotalCount.TabIndex = 6;
            this.labtotalCount.Text = "共213条";
            // 
            // Pager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx3);
            this.Name = "Pager";
            this.Size = new System.Drawing.Size(607, 28);
            this.SizeChanged += new System.EventHandler(this.Pager_SizeChanged);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentpage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx pageCount;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labtotalCount;
        private DevComponents.Editors.IntegerInput currentpage;
        private DevComponents.DotNetBar.LabelX labtotalPage;
        private DevComponents.DotNetBar.ButtonX headpage;
        private DevComponents.DotNetBar.ButtonX refresh;
        private DevComponents.DotNetBar.ButtonX lastpage;
        private DevComponents.DotNetBar.ButtonX nextpage;
        private DevComponents.DotNetBar.ButtonX previouspage;
    }
}
