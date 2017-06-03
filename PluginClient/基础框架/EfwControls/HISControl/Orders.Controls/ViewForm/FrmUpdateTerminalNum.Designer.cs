namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    partial class FrmUpdateTerminalNum
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.radDefault = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radUpdate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.NumInput = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.dataGrid1 = new EfwControls.CustomControl.DataGrid();
            this.ShowOrderBdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DosageUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeminalNum = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.DropSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecNurseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(22, 337);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(89, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "末日执行次数";
            // 
            // radDefault
            // 
            // 
            // 
            // 
            this.radDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radDefault.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radDefault.Checked = true;
            this.radDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radDefault.CheckValue = "Y";
            this.radDefault.Location = new System.Drawing.Point(112, 336);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(72, 23);
            this.radDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radDefault.TabIndex = 2;
            this.radDefault.Text = "默认值";
            this.radDefault.CheckedChanged += new System.EventHandler(this.radDefault_CheckedChanged);
            // 
            // radUpdate
            // 
            // 
            // 
            // 
            this.radUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radUpdate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radUpdate.Location = new System.Drawing.Point(190, 335);
            this.radUpdate.Name = "radUpdate";
            this.radUpdate.Size = new System.Drawing.Size(116, 23);
            this.radUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radUpdate.TabIndex = 3;
            this.radUpdate.Text = "全部修改相同值";
            // 
            // NumInput
            // 
            this.NumInput.Location = new System.Drawing.Point(312, 337);
            this.NumInput.Name = "NumInput";
            this.NumInput.Size = new System.Drawing.Size(60, 21);
            this.NumInput.TabIndex = 4;
            this.NumInput.ValueChanged += new System.EventHandler(this.NumInput_ValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(841, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(937, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowSortWhenClickColumnHeader = false;
            this.dataGrid1.AllowUserToAddRows = false;
            this.dataGrid1.AllowUserToResizeColumns = false;
            this.dataGrid1.AllowUserToResizeRows = false;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowOrderBdate,
            this.ItemName,
            this.Dosage,
            this.DosageUnit,
            this.ChannelName,
            this.Frequency,
            this.FirstNum,
            this.TeminalNum,
            this.DropSpec,
            this.Entrust,
            this.ExecNurseName,
            this.ExecDate});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGrid1.HighlightSelectedColumnHeaders = false;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGrid1.RowHeadersWidth = 30;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGrid1.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGrid1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGrid1.RowTemplate.Height = 23;
            this.dataGrid1.SelectAllSignVisible = false;
            this.dataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid1.SeqVisible = true;
            this.dataGrid1.SetCustomStyle = false;
            this.dataGrid1.Size = new System.Drawing.Size(1047, 329);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellValueChanged);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGrid1_Paint);
            // 
            // ShowOrderBdate
            // 
            this.ShowOrderBdate.DataPropertyName = "ShowOrderBdate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss";
            this.ShowOrderBdate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ShowOrderBdate.HeaderText = "录入时间";
            this.ShowOrderBdate.Name = "ShowOrderBdate";
            this.ShowOrderBdate.ReadOnly = true;
            this.ShowOrderBdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ShowOrderBdate.Width = 126;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ItemName.HeaderText = "医嘱内容";
            this.ItemName.MinimumWidth = 160;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Dosage
            // 
            this.Dosage.DataPropertyName = "Dosage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Dosage.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dosage.HeaderText = "剂量";
            this.Dosage.Name = "Dosage";
            this.Dosage.ReadOnly = true;
            this.Dosage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dosage.Width = 70;
            // 
            // DosageUnit
            // 
            this.DosageUnit.DataPropertyName = "DosageUnit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DosageUnit.DefaultCellStyle = dataGridViewCellStyle5;
            this.DosageUnit.HeaderText = "单位";
            this.DosageUnit.Name = "DosageUnit";
            this.DosageUnit.ReadOnly = true;
            this.DosageUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DosageUnit.Width = 60;
            // 
            // ChannelName
            // 
            this.ChannelName.DataPropertyName = "ChannelName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ChannelName.DefaultCellStyle = dataGridViewCellStyle6;
            this.ChannelName.HeaderText = "用法";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            this.ChannelName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChannelName.Width = 60;
            // 
            // Frequency
            // 
            this.Frequency.DataPropertyName = "Frequency";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Frequency.DefaultCellStyle = dataGridViewCellStyle7;
            this.Frequency.HeaderText = "频次";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency.Width = 70;
            // 
            // FirstNum
            // 
            this.FirstNum.DataPropertyName = "FirstNum";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.FirstNum.DefaultCellStyle = dataGridViewCellStyle8;
            this.FirstNum.HeaderText = "首次";
            this.FirstNum.Name = "FirstNum";
            this.FirstNum.ReadOnly = true;
            this.FirstNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FirstNum.Width = 60;
            // 
            // TeminalNum
            // 
            // 
            // 
            // 
            this.TeminalNum.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.TeminalNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TeminalNum.DataPropertyName = "TeminalNum";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.TeminalNum.DefaultCellStyle = dataGridViewCellStyle9;
            this.TeminalNum.HeaderText = "末次";
            this.TeminalNum.Name = "TeminalNum";
            this.TeminalNum.ReadOnly = true;
            this.TeminalNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TeminalNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeminalNum.Width = 70;
            // 
            // DropSpec
            // 
            this.DropSpec.DataPropertyName = "DropSpec";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DropSpec.DefaultCellStyle = dataGridViewCellStyle10;
            this.DropSpec.HeaderText = "滴速";
            this.DropSpec.Name = "DropSpec";
            this.DropSpec.ReadOnly = true;
            this.DropSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DropSpec.Width = 60;
            // 
            // Entrust
            // 
            this.Entrust.DataPropertyName = "Entrust";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Entrust.DefaultCellStyle = dataGridViewCellStyle11;
            this.Entrust.HeaderText = "嘱托";
            this.Entrust.Name = "Entrust";
            this.Entrust.ReadOnly = true;
            this.Entrust.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExecNurseName
            // 
            this.ExecNurseName.DataPropertyName = "ExecNurseName";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ExecNurseName.DefaultCellStyle = dataGridViewCellStyle12;
            this.ExecNurseName.HeaderText = "执行人";
            this.ExecNurseName.Name = "ExecNurseName";
            this.ExecNurseName.ReadOnly = true;
            this.ExecNurseName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExecNurseName.Width = 70;
            // 
            // ExecDate
            // 
            this.ExecDate.DataPropertyName = "ExecDate";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.Format = "yyyy-MM-dd HH:mm:ss";
            this.ExecDate.DefaultCellStyle = dataGridViewCellStyle13;
            this.ExecDate.HeaderText = "执行时间";
            this.ExecDate.Name = "ExecDate";
            this.ExecDate.ReadOnly = true;
            this.ExecDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExecDate.Width = 120;
            // 
            // FrmUpdateTerminalNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 367);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.NumInput);
            this.Controls.Add(this.radUpdate);
            this.Controls.Add(this.radDefault);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dataGrid1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateTerminalNum";
            this.Text = "修改末日执行次数";
            ((System.ComponentModel.ISupportInitialize)(this.NumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EfwControls.CustomControl.DataGrid dataGrid1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX radDefault;
        private DevComponents.DotNetBar.Controls.CheckBoxX radUpdate;
        private System.Windows.Forms.NumericUpDown NumInput;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowOrderBdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DosageUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNum;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn TeminalNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DropSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrust;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecNurseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecDate;
    }
}