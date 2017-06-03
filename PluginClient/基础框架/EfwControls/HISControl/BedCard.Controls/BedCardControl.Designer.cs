namespace EfwControls.HISControl.BedCard.Controls
{
    partial class BedCardControl
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
            this.flpBed = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpBed
            // 
            this.flpBed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBed.Location = new System.Drawing.Point(0, 0);
            this.flpBed.Name = "flpBed";
            this.flpBed.Size = new System.Drawing.Size(422, 163);
            this.flpBed.TabIndex = 0;
            // 
            // BedCardControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpBed);
            this.Name = "BedCardControl";
            this.Size = new System.Drawing.Size(422, 163);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBed;
    }
}
