namespace EfwControls.HISControl.CustomDocument.Controls
{
    partial class CustomDocumentControl
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
            this.pcbFormBack = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pcbFormBack
            // 
            this.pcbFormBack.BackColor = System.Drawing.Color.White;
            this.pcbFormBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbFormBack.Location = new System.Drawing.Point(12, 12);
            this.pcbFormBack.Name = "pcbFormBack";
            this.pcbFormBack.Size = new System.Drawing.Size(602, 400);
            this.pcbFormBack.TabIndex = 1;
            // 
            // CustomDocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.pcbFormBack);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomDocumentControl";
            this.Size = new System.Drawing.Size(785, 426);
            this.Resize += new System.EventHandler(this.palView_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pcbFormBack;

    }
}
