namespace base_reportmanage.winform.ViewForm
{
    partial class FrmReportDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportDesigner));
            this.BasepanelEx = new DevComponents.DotNetBar.PanelEx();
            this.axGRDesigner1 = new AxgrdesLib.AxGRDesigner();
            this.BasepanelEx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGRDesigner1)).BeginInit();
            this.SuspendLayout();
            // 
            // BasepanelEx
            // 
            this.BasepanelEx.Controls.Add(this.axGRDesigner1);
            this.BasepanelEx.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.BasepanelEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasepanelEx.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.BasepanelEx.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.BasepanelEx.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.BasepanelEx.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.BasepanelEx.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.BasepanelEx.Style.GradientAngle = 90;
            // 
            // axGRDesigner1
            // 
            this.axGRDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGRDesigner1.Enabled = true;
            this.axGRDesigner1.Location = new System.Drawing.Point(0, 0);
            this.axGRDesigner1.Name = "axGRDesigner1";
            this.axGRDesigner1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGRDesigner1.OcxState")));
            this.axGRDesigner1.Size = new System.Drawing.Size(992, 532);
            this.axGRDesigner1.TabIndex = 0;
            // 
            // FrmReportDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 532);
            this.DoubleBuffered = true;
            this.Controls.Add(this.BasepanelEx);
            this.Name = "FrmReportDesigner";
            this.Text = "报表设计";
            this.BasepanelEx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGRDesigner1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx BasepanelEx;
        private AxgrdesLib.AxGRDesigner axGRDesigner1;

        //private AxgrdesLib.AxGRDesigner axGRDesigner1;
    }
}