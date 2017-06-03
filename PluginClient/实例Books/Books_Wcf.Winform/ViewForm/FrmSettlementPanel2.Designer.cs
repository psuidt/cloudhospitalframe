namespace Books_Wcf.Winform.ViewForm
{
    partial class FrmSettlementPanel2
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
            this.lblInvNo = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flpPayCtrl = new System.Windows.Forms.FlowLayoutPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbAccountSum = new DevComponents.DotNetBar.LabelX();
            this.lbFavorableSum = new DevComponents.DotNetBar.LabelX();
            this.lbPersonalSum = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtAmount = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lbSum = new DevComponents.DotNetBar.LabelX();
            this.btnGiveUp = new DevComponents.DotNetBar.ButtonX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInvNo
            // 
            this.lblInvNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInvNo.AutoSize = true;
            // 
            // 
            // 
            this.lblInvNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInvNo.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblInvNo.ForeColor = System.Drawing.Color.Red;
            this.lblInvNo.Location = new System.Drawing.Point(12, 191);
            this.lblInvNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblInvNo.Name = "lblInvNo";
            this.lblInvNo.Size = new System.Drawing.Size(133, 33);
            this.lblInvNo.TabIndex = 4;
            this.lblInvNo.Text = "当前发票号：";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Controls.Add(this.lblInvNo);
            this.panelEx1.Controls.Add(this.btnGiveUp);
            this.panelEx1.Controls.Add(this.btnConfirm);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(486, 223);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 5;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flpPayCtrl);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(0, 73);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(475, 104);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "  请按如下顺序逐项支付  ";
            // 
            // flpPayCtrl
            // 
            this.flpPayCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPayCtrl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPayCtrl.Location = new System.Drawing.Point(0, 0);
            this.flpPayCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.flpPayCtrl.Name = "flpPayCtrl";
            this.flpPayCtrl.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.flpPayCtrl.Size = new System.Drawing.Size(470, 81);
            this.flpPayCtrl.TabIndex = 0;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lbAccountSum);
            this.groupPanel1.Controls.Add(this.lbFavorableSum);
            this.groupPanel1.Controls.Add(this.lbPersonalSum);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.txtAmount);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.lbSum);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(486, 63);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 3;
            // 
            // lbAccountSum
            // 
            this.lbAccountSum.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.lbAccountSum.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbAccountSum.BackgroundStyle.BorderBottomWidth = 1;
            this.lbAccountSum.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbAccountSum.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbAccountSum.BackgroundStyle.BorderLeftWidth = 1;
            this.lbAccountSum.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbAccountSum.BackgroundStyle.BorderRightWidth = 1;
            this.lbAccountSum.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbAccountSum.BackgroundStyle.BorderTopWidth = 1;
            this.lbAccountSum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbAccountSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAccountSum.ForeColor = System.Drawing.Color.Black;
            this.lbAccountSum.Location = new System.Drawing.Point(353, 31);
            this.lbAccountSum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbAccountSum.Name = "lbAccountSum";
            this.lbAccountSum.Size = new System.Drawing.Size(96, 24);
            this.lbAccountSum.TabIndex = 3;
            this.lbAccountSum.Text = "0.00";
            this.lbAccountSum.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lbFavorableSum
            // 
            this.lbFavorableSum.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.lbFavorableSum.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbFavorableSum.BackgroundStyle.BorderBottomWidth = 1;
            this.lbFavorableSum.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbFavorableSum.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbFavorableSum.BackgroundStyle.BorderLeftWidth = 1;
            this.lbFavorableSum.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbFavorableSum.BackgroundStyle.BorderRightWidth = 1;
            this.lbFavorableSum.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbFavorableSum.BackgroundStyle.BorderTopWidth = 1;
            this.lbFavorableSum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbFavorableSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFavorableSum.ForeColor = System.Drawing.Color.Black;
            this.lbFavorableSum.Location = new System.Drawing.Point(353, 3);
            this.lbFavorableSum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbFavorableSum.Name = "lbFavorableSum";
            this.lbFavorableSum.Size = new System.Drawing.Size(96, 24);
            this.lbFavorableSum.TabIndex = 1;
            this.lbFavorableSum.Text = "0.00";
            this.lbFavorableSum.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lbPersonalSum
            // 
            this.lbPersonalSum.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.lbPersonalSum.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbPersonalSum.BackgroundStyle.BorderBottomWidth = 1;
            this.lbPersonalSum.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbPersonalSum.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbPersonalSum.BackgroundStyle.BorderLeftWidth = 1;
            this.lbPersonalSum.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbPersonalSum.BackgroundStyle.BorderRightWidth = 1;
            this.lbPersonalSum.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbPersonalSum.BackgroundStyle.BorderTopWidth = 1;
            this.lbPersonalSum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbPersonalSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPersonalSum.ForeColor = System.Drawing.Color.Black;
            this.lbPersonalSum.Location = new System.Drawing.Point(123, 31);
            this.lbPersonalSum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPersonalSum.Name = "lbPersonalSum";
            this.lbPersonalSum.Size = new System.Drawing.Size(96, 24);
            this.lbPersonalSum.TabIndex = 2;
            this.lbPersonalSum.Text = "0.00";
            this.lbPersonalSum.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(277, 5);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(65, 20);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "优惠金额";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(44, 31);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(65, 20);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "自付金额";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.txtAmount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmount.BackgroundStyle.BorderBottomWidth = 1;
            this.txtAmount.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtAmount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmount.BackgroundStyle.BorderLeftWidth = 1;
            this.txtAmount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmount.BackgroundStyle.BorderRightWidth = 1;
            this.txtAmount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmount.BackgroundStyle.BorderTopWidth = 1;
            this.txtAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Location = new System.Drawing.Point(123, 3);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(96, 24);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(277, 32);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 20);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "记账金额";
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbSum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSum.Location = new System.Drawing.Point(30, 4);
            this.lbSum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(79, 20);
            this.lbSum.TabIndex = 0;
            this.lbSum.Text = "处方总金额";
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGiveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGiveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGiveUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGiveUp.ImageTextSpacing = 6;
            this.btnGiveUp.Location = new System.Drawing.Point(365, 191);
            this.btnGiveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(103, 23);
            this.btnGiveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGiveUp.TabIndex = 2;
            this.btnGiveUp.Text = "取消(Esc)";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ImageTextSpacing = 6;
            this.btnConfirm.Location = new System.Drawing.Point(249, 191);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(103, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "结 算";
            // 
            // FrmSettlementPanel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 223);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettlementPanel2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "结算面板";
            this.Shown += new System.EventHandler(this.FrmSettlementPanel_Shown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnGiveUp;
        private DevComponents.DotNetBar.LabelX lblInvNo;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lbSum;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpPayCtrl;
        private DevComponents.DotNetBar.LabelX txtAmount;
        private DevComponents.DotNetBar.LabelX lbAccountSum;
        private DevComponents.DotNetBar.LabelX lbFavorableSum;
        private DevComponents.DotNetBar.LabelX lbPersonalSum;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
    }
}