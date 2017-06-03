namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    partial class FrmAddStatItem
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
            this.ckroot = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtupstat = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ckDelflag = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtStatName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.ckroot);
            this.panelEx1.Controls.Add(this.txtupstat);
            this.panelEx1.Controls.Add(this.ckDelflag);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnSave);
            this.panelEx1.Controls.Add(this.txtStatName);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(393, 162);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // ckroot
            // 
            // 
            // 
            // 
            this.ckroot.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckroot.Location = new System.Drawing.Point(284, 28);
            this.ckroot.Name = "ckroot";
            this.ckroot.Size = new System.Drawing.Size(100, 23);
            this.ckroot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckroot.TabIndex = 20;
            this.ckroot.Text = "根节点";
            this.ckroot.CheckedChanged += new System.EventHandler(this.ckroot_CheckedChanged);
            // 
            // txtupstat
            // 
            // 
            // 
            // 
            this.txtupstat.Border.Class = "TextBoxBorder";
            this.txtupstat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtupstat.Enabled = false;
            this.txtupstat.Location = new System.Drawing.Point(104, 28);
            this.txtupstat.Name = "txtupstat";
            this.txtupstat.Size = new System.Drawing.Size(173, 21);
            this.txtupstat.TabIndex = 19;
            // 
            // ckDelflag
            // 
            // 
            // 
            // 
            this.ckDelflag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckDelflag.CheckValue = "0";
            this.ckDelflag.CheckValueChecked = "1";
            this.ckDelflag.CheckValueUnchecked = "0";
            this.ckDelflag.Location = new System.Drawing.Point(104, 80);
            this.ckDelflag.Name = "ckDelflag";
            this.ckDelflag.Size = new System.Drawing.Size(100, 23);
            this.ckDelflag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckDelflag.TabIndex = 18;
            this.ckDelflag.Text = "停用";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(23, 28);
            this.labelX8.Name = "labelX8";
            this.labelX8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 16;
            this.labelX8.Text = "上级大类";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(194, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(104, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStatName
            // 
            // 
            // 
            // 
            this.txtStatName.Border.Class = "TextBoxBorder";
            this.txtStatName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStatName.Location = new System.Drawing.Point(104, 55);
            this.txtStatName.Name = "txtStatName";
            this.txtStatName.Size = new System.Drawing.Size(246, 21);
            this.txtStatName.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "大类名称";
            // 
            // FrmAddStatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 162);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddStatItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "统计大类";
            this.Shown += new System.EventHandler(this.FrmAddStatItem_Shown);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStatName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckDelflag;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtupstat;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckroot;
    }
}