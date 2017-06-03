namespace HIS_BasicData.Winform.ViewForm.Employee
{
    partial class FrmRelDepts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelToolBar = new DevComponents.DotNetBar.PanelEx();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnQuit = new DevComponents.DotNetBar.ButtonX();
            this.dgRels = new EfwControls.CustomControl.DataGrid();
            this.ColumnEmpId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ckAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRels)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolBar
            // 
            this.panelToolBar.AutoSize = true;
            this.panelToolBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelToolBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelToolBar.Controls.Add(this.ckAll);
            this.panelToolBar.Controls.Add(this.btnReset);
            this.panelToolBar.Controls.Add(this.btnSave);
            this.panelToolBar.Controls.Add(this.btnQuit);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(441, 29);
            this.panelToolBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelToolBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelToolBar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelToolBar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelToolBar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelToolBar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelToolBar.Style.GradientAngle = 90;
            this.panelToolBar.TabIndex = 165;
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(192, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 48;
            this.btnReset.Text = "重置(F6)";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(273, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 22);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "保存(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuit.Location = new System.Drawing.Point(354, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 22);
            this.btnQuit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "关闭(F7)";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // dgRels
            // 
            this.dgRels.AllowSortWhenClickColumnHeader = false;
            this.dgRels.AllowUserToAddRows = false;
            this.dgRels.AllowUserToDeleteRows = false;
            this.dgRels.AllowUserToResizeColumns = false;
            this.dgRels.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            this.dgRels.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgRels.BackgroundColor = System.Drawing.Color.White;
            this.dgRels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgRels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEmpId,
            this.DeptId,
            this.ColumnName,
            this.DefaultFlag});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgRels.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgRels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRels.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgRels.HighlightSelectedColumnHeaders = false;
            this.dgRels.Location = new System.Drawing.Point(0, 29);
            this.dgRels.Name = "dgRels";
            this.dgRels.ReadOnly = true;
            this.dgRels.RowHeadersVisible = false;
            this.dgRels.RowHeadersWidth = 30;
            this.dgRels.RowTemplate.Height = 23;
            this.dgRels.SelectAllSignVisible = false;
            this.dgRels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRels.SeqVisible = false;
            this.dgRels.SetCustomStyle = true;
            this.dgRels.Size = new System.Drawing.Size(441, 249);
            this.dgRels.TabIndex = 166;
            this.dgRels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRelDepts_CellClick);
            // 
            // ColumnEmpId
            // 
            this.ColumnEmpId.DataPropertyName = "EmpId";
            this.ColumnEmpId.FalseValue = "0";
            this.ColumnEmpId.HeaderText = "已选";
            this.ColumnEmpId.IndeterminateValue = "";
            this.ColumnEmpId.Name = "ColumnEmpId";
            this.ColumnEmpId.ReadOnly = true;
            this.ColumnEmpId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnEmpId.TrueValue = "1";
            // 
            // DeptId
            // 
            this.DeptId.DataPropertyName = "DeptId";
            this.DeptId.HeaderText = "编码";
            this.DeptId.Name = "DeptId";
            this.DeptId.ReadOnly = true;
            this.DeptId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeptId.Width = 60;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "科室名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DefaultFlag
            // 
            this.DefaultFlag.DataPropertyName = "DefaultFlag";
            this.DefaultFlag.FalseValue = "0";
            this.DefaultFlag.HeaderText = "是否默认科室";
            this.DefaultFlag.IndeterminateValue = "";
            this.DefaultFlag.Name = "DefaultFlag";
            this.DefaultFlag.ReadOnly = true;
            this.DefaultFlag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultFlag.TrueValue = "1";
            // 
            // ckAll
            // 
            // 
            // 
            // 
            this.ckAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckAll.Location = new System.Drawing.Point(13, 3);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(100, 23);
            this.ckAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckAll.TabIndex = 50;
            this.ckAll.Text = "全选";
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // FrmRelDepts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 278);
            this.Controls.Add(this.dgRels);
            this.Controls.Add(this.panelToolBar);
            this.Name = "FrmRelDepts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关联科室";
            this.Load += new System.EventHandler(this.FrmRelDepts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelDepts_KeyDown);
            this.panelToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelToolBar;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnQuit;
        private EfwControls.CustomControl.DataGrid dgRels;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DefaultFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnEmpId;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckAll;
    }
}