namespace EfwControls.CustomControl
{
    partial class GridDesignReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridDesignReport));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnUpload = new DevComponents.DotNetBar.ButtonItem();
            this.btnDownLoad = new DevComponents.DotNetBar.ButtonItem();
            this.axGRDesigner = new Axgrdes6Lib.AxGRDesigner();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axGRDesigner)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("宋体", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSave,
            this.btnUpload,
            this.btnDownLoad});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(784, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存本地";
            // 
            // btnUpload
            // 
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Text = "上传服务器";
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Text = "下载覆盖";
            // 
            // axGRDesigner
            // 
            this.axGRDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGRDesigner.Enabled = true;
            this.axGRDesigner.Location = new System.Drawing.Point(0, 27);
            this.axGRDesigner.Name = "axGRDesigner";
            this.axGRDesigner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGRDesigner.OcxState")));
            this.axGRDesigner.Size = new System.Drawing.Size(784, 535);
            this.axGRDesigner.TabIndex = 1;
            // 
            // GridDesignReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGRDesigner);
            this.Controls.Add(this.bar1);
            this.Name = "GridDesignReport";
            this.Size = new System.Drawing.Size(784, 562);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axGRDesigner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnUpload;
        private Axgrdes6Lib.AxGRDesigner axGRDesigner;
        private DevComponents.DotNetBar.ButtonItem btnDownLoad;
    }
}