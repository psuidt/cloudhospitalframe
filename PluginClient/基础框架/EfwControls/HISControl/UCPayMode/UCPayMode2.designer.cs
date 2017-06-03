namespace EfwControls.HISControl.UCPayMode
{
    partial class UCPayMode2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPayMode2));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lbTitle = new DevComponents.DotNetBar.LabelX();
            this.btnPay = new DevComponents.DotNetBar.ButtonX();
            this.diPayMoney = new DevComponents.Editors.DoubleInput();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diPayMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lbTitle);
            this.panelEx1.Controls.Add(this.btnPay);
            this.panelEx1.Controls.Add(this.diPayMoney);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(535, 40);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.panelEx1.Style.CornerDiameter = 4;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // lbTitle
            // 
            // 
            // 
            // 
            this.lbTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTitle.Location = new System.Drawing.Point(3, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(140, 26);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "城乡医保";
            this.lbTitle.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnPay
            // 
            this.btnPay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPay.Enabled = false;
            this.btnPay.Location = new System.Drawing.Point(478, 7);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(44, 26);
            this.btnPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPay.TabIndex = 1;
            this.btnPay.TabStop = false;
            this.btnPay.Text = "操作";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // diPayMoney
            // 
            this.diPayMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.diPayMoney.BackgroundStyle.Class = "DateTimeInputBackground";
            this.diPayMoney.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.diPayMoney.ButtonCustom.Enabled = false;
            this.diPayMoney.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("diPayMoney.ButtonCustom.Image")));
            this.diPayMoney.Increment = 1D;
            this.diPayMoney.InputMouseWheelEnabled = false;
            this.diPayMoney.Location = new System.Drawing.Point(146, 7);
            this.diPayMoney.Margin = new System.Windows.Forms.Padding(0);
            this.diPayMoney.MinValue = 0D;
            this.diPayMoney.Name = "diPayMoney";
            this.diPayMoney.Size = new System.Drawing.Size(328, 26);
            this.diPayMoney.TabIndex = 0;
            this.diPayMoney.ValueChanged += new System.EventHandler(this.diPayMoney_ValueChanged);
            // 
            // UCPayMode2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UCPayMode2";
            this.Size = new System.Drawing.Size(535, 40);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diPayMoney)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX lbTitle;
        public DevComponents.DotNetBar.ButtonX btnPay;
        public DevComponents.Editors.DoubleInput diPayMoney;
    }
}
