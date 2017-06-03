namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    partial class FrmDeathOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeathOrder));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpOutDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtDialoge = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtCureNO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtBedNO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtPatName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtOutDialog = new EfwControls.CustomControl.TextBoxCard(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOutDate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.dtpOutDate);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.txtOutDialog);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtDialoge);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.txtCureNO);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.txtBedNO);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.txtPatName);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(472, 222);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(377, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(296, 190);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(351, 152);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(77, 23);
            this.labelX8.TabIndex = 35;
            this.labelX8.Text = "停长期医嘱";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(428, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "√";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpOutDate
            // 
            // 
            // 
            // 
            this.dtpOutDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpOutDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOutDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpOutDate.ButtonDropDown.Visible = true;
            this.dtpOutDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpOutDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpOutDate.IsPopupCalendarOpen = false;
            this.dtpOutDate.Location = new System.Drawing.Point(64, 116);
            // 
            // 
            // 
            this.dtpOutDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpOutDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOutDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpOutDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpOutDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOutDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 11, 1, 0, 0, 0, 0);
            this.dtpOutDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpOutDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpOutDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpOutDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpOutDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpOutDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpOutDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpOutDate.MonthCalendar.TodayButtonVisible = true;
            this.dtpOutDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpOutDate.Name = "dtpOutDate";
            this.dtpOutDate.Size = new System.Drawing.Size(281, 21);
            this.dtpOutDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpOutDate.TabIndex = 21;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(7, 115);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 23);
            this.labelX7.TabIndex = 20;
            this.labelX7.Text = "死亡时间";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(6, 152);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(57, 23);
            this.labelX5.TabIndex = 16;
            this.labelX5.Text = "死亡诊断";
            // 
            // txtDialoge
            // 
            // 
            // 
            // 
            this.txtDialoge.Border.Class = "TextBoxBorder";
            this.txtDialoge.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDialoge.Location = new System.Drawing.Point(64, 70);
            this.txtDialoge.Name = "txtDialoge";
            this.txtDialoge.ReadOnly = true;
            this.txtDialoge.Size = new System.Drawing.Size(390, 21);
            this.txtDialoge.TabIndex = 15;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(9, 70);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(59, 23);
            this.labelX4.TabIndex = 14;
            this.labelX4.Text = "医生诊断";
            // 
            // txtCureNO
            // 
            // 
            // 
            // 
            this.txtCureNO.Border.Class = "TextBoxBorder";
            this.txtCureNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCureNO.Location = new System.Drawing.Point(64, 24);
            this.txtCureNO.Name = "txtCureNO";
            this.txtCureNO.ReadOnly = true;
            this.txtCureNO.Size = new System.Drawing.Size(112, 21);
            this.txtCureNO.TabIndex = 13;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(22, 24);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(46, 23);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = "住院号";
            // 
            // txtBedNO
            // 
            // 
            // 
            // 
            this.txtBedNO.Border.Class = "TextBoxBorder";
            this.txtBedNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBedNO.Location = new System.Drawing.Point(377, 24);
            this.txtBedNO.Name = "txtBedNO";
            this.txtBedNO.ReadOnly = true;
            this.txtBedNO.Size = new System.Drawing.Size(77, 21);
            this.txtBedNO.TabIndex = 11;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(336, 22);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(35, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "床号";
            // 
            // txtPatName
            // 
            // 
            // 
            // 
            this.txtPatName.Border.Class = "TextBoxBorder";
            this.txtPatName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPatName.Location = new System.Drawing.Point(218, 24);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.ReadOnly = true;
            this.txtPatName.Size = new System.Drawing.Size(112, 21);
            this.txtPatName.TabIndex = 9;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(177, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(35, 23);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "姓名";
            // 
            // txtOutDialog
            // 
            // 
            // 
            // 
            this.txtOutDialog.Border.Class = "TextBoxBorder";
            this.txtOutDialog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOutDialog.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtOutDialog.ButtonCustom.Image")));
            this.txtOutDialog.ButtonCustom.Visible = true;
            this.txtOutDialog.CardColumn = null;
            this.txtOutDialog.DisplayField = "";
            this.txtOutDialog.IsEnterShowCard = true;
            this.txtOutDialog.IsNumSelected = false;
            this.txtOutDialog.IsPage = true;
            this.txtOutDialog.IsShowLetter = false;
            this.txtOutDialog.IsShowPage = false;
            this.txtOutDialog.IsShowSeq = true;
            this.txtOutDialog.Location = new System.Drawing.Point(64, 154);
            this.txtOutDialog.MatchMode = EfwControls.CustomControl.MatchModes.ByAnyString;
            this.txtOutDialog.MemberField = "";
            this.txtOutDialog.MemberValue = null;
            this.txtOutDialog.Name = "txtOutDialog";
            this.txtOutDialog.QueryFields = new string[] {
        ""};
            this.txtOutDialog.QueryFieldsString = "";
            this.txtOutDialog.SelectedValue = null;
            this.txtOutDialog.ShowCardColumns = null;
            this.txtOutDialog.ShowCardDataSource = null;
            this.txtOutDialog.ShowCardHeight = 0;
            this.txtOutDialog.ShowCardWidth = 0;
            this.txtOutDialog.Size = new System.Drawing.Size(283, 21);
            this.txtOutDialog.TabIndex = 17;
            // 
            // FrmDeathOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 222);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeathOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "死亡医嘱";
            this.Load += new System.EventHandler(this.FrmDeathOrder_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOutDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDialoge;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCureNO;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBedNO;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX7;
        private CustomControl.TextBoxCard txtOutDialog;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpOutDate;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
    }
}