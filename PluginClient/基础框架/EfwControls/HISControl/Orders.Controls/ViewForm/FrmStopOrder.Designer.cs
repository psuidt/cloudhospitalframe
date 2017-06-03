namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    partial class FrmStopOrder
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtUpdateNum = new System.Windows.Forms.NumericUpDown();
            this.radUpdate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblDefaultNum = new DevComponents.DotNetBar.LabelX();
            this.radDefault = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dtpStopDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStopDate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.Controls.Add(this.txtUpdateNum);
            this.panelEx1.Controls.Add(this.radUpdate);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.lblDefaultNum);
            this.panelEx1.Controls.Add(this.radDefault);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.dtpStopDate);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(257, 142);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(143, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(37, 109);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtUpdateNum
            // 
            this.txtUpdateNum.Location = new System.Drawing.Point(189, 74);
            this.txtUpdateNum.Name = "txtUpdateNum";
            this.txtUpdateNum.Size = new System.Drawing.Size(53, 21);
            this.txtUpdateNum.TabIndex = 7;
            // 
            // radUpdate
            // 
            // 
            // 
            // 
            this.radUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radUpdate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radUpdate.Location = new System.Drawing.Point(122, 71);
            this.radUpdate.Name = "radUpdate";
            this.radUpdate.Size = new System.Drawing.Size(67, 23);
            this.radUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radUpdate.TabIndex = 6;
            this.radUpdate.Text = "修改值";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(101, 74);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(15, 23);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "次";
            // 
            // lblDefaultNum
            // 
            // 
            // 
            // 
            this.lblDefaultNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDefaultNum.Location = new System.Drawing.Point(75, 72);
            this.lblDefaultNum.Name = "lblDefaultNum";
            this.lblDefaultNum.Size = new System.Drawing.Size(27, 23);
            this.lblDefaultNum.TabIndex = 4;
            this.lblDefaultNum.Text = "0";
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
            this.radDefault.Location = new System.Drawing.Point(10, 72);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(65, 23);
            this.radDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radDefault.TabIndex = 3;
            this.radDefault.Text = "默认值";
            this.radDefault.CheckedChanged += new System.EventHandler(this.radDefault_CheckedChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(10, 43);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(85, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "末日执行次数:";
            // 
            // dtpStopDate
            // 
            // 
            // 
            // 
            this.dtpStopDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpStopDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStopDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpStopDate.ButtonDropDown.Visible = true;
            this.dtpStopDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStopDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpStopDate.IsPopupCalendarOpen = false;
            this.dtpStopDate.Location = new System.Drawing.Point(70, 14);
            // 
            // 
            // 
            this.dtpStopDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStopDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStopDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpStopDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpStopDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStopDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 11, 1, 0, 0, 0, 0);
            this.dtpStopDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpStopDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpStopDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStopDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpStopDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStopDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpStopDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStopDate.MonthCalendar.TodayButtonVisible = true;
            this.dtpStopDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.Size = new System.Drawing.Size(172, 21);
            this.dtpStopDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpStopDate.TabIndex = 1;
            this.dtpStopDate.ValueChanged += new System.EventHandler(this.dtpStopDate_ValueChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(54, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "停嘱时间";
            // 
            // FrmStopOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 142);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStopOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "长嘱停嘱";
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStopDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStopDate;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.NumericUpDown txtUpdateNum;
        private DevComponents.DotNetBar.Controls.CheckBoxX radUpdate;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblDefaultNum;
        private DevComponents.DotNetBar.Controls.CheckBoxX radDefault;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}