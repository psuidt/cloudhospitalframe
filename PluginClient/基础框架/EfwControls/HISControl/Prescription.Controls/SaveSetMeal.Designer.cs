namespace EfwControls.HISControl.Prescription.Controls
{
    partial class SaveSetMeal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveSetMeal));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSetMealName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbDept = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.cbHispital = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.treWestDrug = new DevComponents.AdvTree.AdvTree();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector5 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            ((System.ComponentModel.ISupportInitialize)(this.treWestDrug)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "模板名称";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(10, 40);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "模板类型";
            // 
            // txtSetMealName
            // 
            // 
            // 
            // 
            this.txtSetMealName.Border.Class = "TextBoxBorder";
            this.txtSetMealName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSetMealName.Location = new System.Drawing.Point(67, 8);
            this.txtSetMealName.Name = "txtSetMealName";
            this.txtSetMealName.Size = new System.Drawing.Size(247, 23);
            this.txtSetMealName.TabIndex = 2;
            // 
            // cbDept
            // 
            // 
            // 
            // 
            this.cbDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDept.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDept.Location = new System.Drawing.Point(152, 38);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(75, 23);
            this.cbDept.TabIndex = 3;
            this.cbDept.Text = "科室模板";
            this.cbDept.CheckedChanged += new System.EventHandler(this.cbDept_CheckedChanged);
            // 
            // cbUser
            // 
            // 
            // 
            // 
            this.cbUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbUser.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbUser.Checked = true;
            this.cbUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUser.CheckValue = "Y";
            this.cbUser.Location = new System.Drawing.Point(239, 38);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(75, 23);
            this.cbUser.TabIndex = 4;
            this.cbUser.Text = "个人模板";
            this.cbUser.CheckedChanged += new System.EventHandler(this.cbDept_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(77, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(175, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "取消";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbHispital
            // 
            // 
            // 
            // 
            this.cbHispital.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbHispital.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbHispital.Location = new System.Drawing.Point(66, 38);
            this.cbHispital.Name = "cbHispital";
            this.cbHispital.Size = new System.Drawing.Size(75, 23);
            this.cbHispital.TabIndex = 7;
            this.cbHispital.Text = "全院模板";
            this.cbHispital.CheckedChanged += new System.EventHandler(this.cbDept_CheckedChanged);
            // 
            // treWestDrug
            // 
            this.treWestDrug.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treWestDrug.AllowDrop = true;
            this.treWestDrug.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treWestDrug.BackgroundStyle.Class = "TreeBorderKey";
            this.treWestDrug.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treWestDrug.DragDropEnabled = false;
            this.treWestDrug.DragDropNodeCopyEnabled = false;
            this.treWestDrug.ImageList = this.imgList;
            this.treWestDrug.Location = new System.Drawing.Point(12, 65);
            this.treWestDrug.Name = "treWestDrug";
            this.treWestDrug.NodesConnector = this.nodeConnector5;
            this.treWestDrug.NodeStyle = this.elementStyle5;
            this.treWestDrug.PathSeparator = ";";
            this.treWestDrug.Size = new System.Drawing.Size(348, 205);
            this.treWestDrug.Styles.Add(this.elementStyle5);
            this.treWestDrug.TabIndex = 8;
            this.treWestDrug.Text = "advTree2";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "包类型.png");
            this.imgList.Images.SetKeyName(1, "Order.png");
            // 
            // nodeConnector5
            // 
            this.nodeConnector5.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle5
            // 
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // SaveSetMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 310);
            this.Controls.Add(this.treWestDrug);
            this.Controls.Add(this.cbHispital);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.cbDept);
            this.Controls.Add(this.txtSetMealName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveSetMeal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "存为模板";
            this.Load += new System.EventHandler(this.SaveSetMeal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treWestDrug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSetMealName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbDept;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbUser;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbHispital;
        private DevComponents.AdvTree.AdvTree treWestDrug;
        private DevComponents.AdvTree.NodeConnector nodeConnector5;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private System.Windows.Forms.ImageList imgList;
    }
}