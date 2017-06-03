namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    partial class FrmCenterStatItem
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.treeStat = new DevComponents.AdvTree.AdvTree();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader9 = new DevComponents.AdvTree.ColumnHeader();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.ckAll = new DevComponents.DotNetBar.CheckBoxItem();
            this.btnNew = new DevComponents.DotNetBar.ButtonItem();
            this.btnAlter = new DevComponents.DotNetBar.ButtonItem();
            this.btnStop = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.treeStat);
            this.panelEx1.Controls.Add(this.bar1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(685, 461);
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
            this.treeStat.Columns.Add(this.columnHeader9);
            this.treeStat.ColumnStyleNormal = this.elementStyle2;
            this.treeStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeStat.Location = new System.Drawing.Point(0, 27);
            this.treeStat.Name = "treeStat";
            this.treeStat.NodesConnector = this.nodeConnector1;
            this.treeStat.NodeStyle = this.elementStyle1;
            this.treeStat.PathSeparator = ";";
            this.treeStat.Size = new System.Drawing.Size(685, 434);
            this.treeStat.Styles.Add(this.elementStyle1);
            this.treeStat.Styles.Add(this.elementStyle2);
            this.treeStat.TabIndex = 3;
            this.treeStat.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.treeStat_AfterNodeSelect);
            // 
            // columnHeader2
            // 
            this.columnHeader2.MinimumWidth = 250;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width.Absolute = 250;
            // 
            // columnHeader1
            // 
            this.columnHeader1.MinimumWidth = 100;
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width.Absolute = 100;
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
            this.elementStyle2.PaddingBottom = 5;
            this.elementStyle2.PaddingTop = 5;
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
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ckAll,
            this.btnNew,
            this.btnAlter,
            this.btnStop,
            this.btnClose});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(685, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // ckAll
            // 
            this.ckAll.Name = "ckAll";
            this.ckAll.Text = "显示全部";
            this.ckAll.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.ckAll_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.BeginGroup = true;
            this.btnNew.FontBold = true;
            this.btnNew.Name = "btnNew";
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAlter
            // 
            this.btnAlter.FontBold = true;
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Text = "修改";
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // btnStop
            // 
            this.btnStop.FontBold = true;
            this.btnStop.Name = "btnStop";
            this.btnStop.Text = "停用";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClose
            // 
            this.btnClose.BeginGroup = true;
            this.btnClose.FontBold = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmCenterStatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 461);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmCenterStatItem";
            this.Text = "中心统计大类";
            this.OpenWindowBefore += new System.EventHandler(this.FrmCenterStatItem_OpenWindowBefore);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.AdvTree.AdvTree treeStat;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader9;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnNew;
        private DevComponents.DotNetBar.ButtonItem btnAlter;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.CheckBoxItem ckAll;
        private DevComponents.DotNetBar.ButtonItem btnStop;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
    }
}