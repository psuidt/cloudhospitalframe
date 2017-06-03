namespace Books_Wcf.Winform.ViewForm
{
    partial class FrmIPDOrder
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
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.长期医嘱 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.临时医嘱 = new DevComponents.DotNetBar.SuperTabItem();
            this.ordersControl1 = new EfwControls.HISControl.Orders.Controls.ViewForm.OrdersControl();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(846, 515);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.长期医嘱,
            this.临时医嘱});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.ordersControl1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(846, 487);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.长期医嘱;
            // 
            // 长期医嘱
            // 
            this.长期医嘱.AttachedControl = this.superTabControlPanel1;
            this.长期医嘱.GlobalItem = false;
            this.长期医嘱.Name = "长期医嘱";
            this.长期医嘱.Text = "长期医嘱";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(846, 487);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.临时医嘱;
            // 
            // 临时医嘱
            // 
            this.临时医嘱.AttachedControl = this.superTabControlPanel2;
            this.临时医嘱.GlobalItem = false;
            this.临时医嘱.Name = "临时医嘱";
            this.临时医嘱.Text = "临时医嘱";
            // 
            // ordersControl1
            // 
            this.ordersControl1.CurrPatListId = 0;
            this.ordersControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersControl1.HideColName = null;
            this.ordersControl1.IsShowToolBar = true;
            this.ordersControl1.Location = new System.Drawing.Point(0, 0);
            this.ordersControl1.Name = "ordersControl1";
            this.ordersControl1.OrderStyle = EfwControls.HISControl.Orders.Controls.Entity.OrderCategory.长期医嘱;
            this.ordersControl1.IsLeaveHosOrder = 0;
            this.ordersControl1.PresDeptId = 0;
            this.ordersControl1.PresDeptName = null;
            this.ordersControl1.PresDoctorId = 0;
            this.ordersControl1.PresDoctorName = null;
            this.ordersControl1.Size = new System.Drawing.Size(846, 487);
            this.ordersControl1.TabIndex = 0;
            // 
            // FrmIPDOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 515);
            this.Controls.Add(this.superTabControl1);
            this.Name = "FrmIPDOrder";
            this.Text = "住院医嘱";
            this.Load += new System.EventHandler(this.FrmIPDOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EfwControls.HISControl.Orders.Controls.ViewForm.OrdersControl ordersControl1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem 长期医嘱;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem 临时医嘱;
    }
}