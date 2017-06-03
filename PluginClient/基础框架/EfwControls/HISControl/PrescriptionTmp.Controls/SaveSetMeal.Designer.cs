namespace EfwControls.HISControl.PrescriptionTmp.Controls
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSetMealName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbDept = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
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
            this.labelX1.Text = "组套名称";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(10, 38);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "组套类型";
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
            this.txtSetMealName.Size = new System.Drawing.Size(173, 23);
            this.txtSetMealName.TabIndex = 2;
            // 
            // cbDept
            // 
            // 
            // 
            // 
            this.cbDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDept.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDept.Location = new System.Drawing.Point(69, 38);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(75, 23);
            this.cbDept.TabIndex = 3;
            this.cbDept.Text = "科室组套";
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
            this.cbUser.Location = new System.Drawing.Point(161, 38);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(75, 23);
            this.cbUser.TabIndex = 4;
            this.cbUser.Text = "个人组套";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(67, 78);
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
            this.btnClose.Location = new System.Drawing.Point(165, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "取消";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SaveSetMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 113);
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
    }
}