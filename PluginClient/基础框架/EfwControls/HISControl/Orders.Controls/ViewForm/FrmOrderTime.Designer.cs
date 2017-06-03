namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    partial class FrmOrderTime
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
            this.dtpOrderTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrderTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpOrderTime
            // 
            // 
            // 
            // 
            this.dtpOrderTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpOrderTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOrderTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpOrderTime.ButtonDropDown.Visible = true;
            this.dtpOrderTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpOrderTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpOrderTime.IsPopupCalendarOpen = false;
            this.dtpOrderTime.Location = new System.Drawing.Point(25, 24);
            // 
            // 
            // 
            this.dtpOrderTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpOrderTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOrderTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpOrderTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpOrderTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOrderTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            this.dtpOrderTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpOrderTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpOrderTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpOrderTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpOrderTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpOrderTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpOrderTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOrderTime.MonthCalendar.TodayButtonVisible = true;
            this.dtpOrderTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpOrderTime.Name = "dtpOrderTime";
            this.dtpOrderTime.Size = new System.Drawing.Size(224, 21);
            this.dtpOrderTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpOrderTime.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(45, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(150, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmOrderTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 96);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpOrderTime);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrderTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改医嘱时间";
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrderTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpOrderTime;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}