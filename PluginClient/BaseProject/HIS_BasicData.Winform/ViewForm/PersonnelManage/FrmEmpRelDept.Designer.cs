namespace WinMainUIFrame.Winform.ViewForm.EmpUserManager
{
    partial class FrmEmpRelDept
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelToolBar = new DevComponents.DotNetBar.PanelEx();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnQuit = new DevComponents.DotNetBar.ButtonX();
            this.dataGrid1 = new EfwControls.CustomControl.DataGrid();
            this.Item3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Item1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolBar
            // 
            this.panelToolBar.AutoSize = true;
            this.panelToolBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelToolBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelToolBar.Controls.Add(this.btnReset);
            this.panelToolBar.Controls.Add(this.btnSave);
            this.panelToolBar.Controls.Add(this.btnQuit);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(441, 29);
            this.panelToolBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelToolBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelToolBar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
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
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 48;
            this.btnReset.Text = "重置";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(273, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "保存";
            // 
            // btnQuit
            // 
            this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuit.Location = new System.Drawing.Point(354, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "退出";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowSortWhenClickColumnHeader = false;
            this.dataGrid1.AllowUserToAddRows = false;
            this.dataGrid1.AllowUserToDeleteRows = false;
            this.dataGrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item3,
            this.Item1,
            this.Item2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGrid1.HighlightSelectedColumnHeaders = false;
            this.dataGrid1.Location = new System.Drawing.Point(0, 29);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.RowHeadersWidth = 25;
            this.dataGrid1.RowTemplate.Height = 23;
            this.dataGrid1.SelectAllSignVisible = false;
            this.dataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid1.SeqVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(441, 249);
            this.dataGrid1.TabIndex = 166;
            // 
            // Item3
            // 
            this.Item3.DataPropertyName = "Item3";
            this.Item3.FalseValue = "false";
            this.Item3.HeaderText = "已选";
            this.Item3.IndeterminateValue = "false";
            this.Item3.Name = "Item3";
            this.Item3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Item3.TrueValue = "true";
            // 
            // Item1
            // 
            this.Item1.DataPropertyName = "Item1";
            this.Item1.HeaderText = "ID";
            this.Item1.Name = "Item1";
            this.Item1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item1.Width = 60;
            // 
            // Item2
            // 
            this.Item2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item2.DataPropertyName = "Item2";
            this.Item2.HeaderText = "科室名称";
            this.Item2.Name = "Item2";
            this.Item2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmEmpRelDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 278);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panelToolBar);
            this.Name = "FrmEmpRelDept";
            this.Text = "FrmEmpRelDept";
            this.panelToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelToolBar;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnQuit;
        private EfwControls.CustomControl.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Item3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item2;
    }
}