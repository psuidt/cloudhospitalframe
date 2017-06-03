namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    partial class OrderFee
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            EfwControls.CustomControl.DataGridViewSelectionCard dataGridViewSelectionCard1 = new EfwControls.CustomControl.DataGridViewSelectionCard();
            EfwControls.CustomControl.DataGridViewSelectionCard dataGridViewSelectionCard2 = new EfwControls.CustomControl.DataGridViewSelectionCard();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.grdFeeList = new EfwControls.CustomControl.GridBoxCard();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalCostMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.grdFeeList);
            this.panelEx1.Controls.Add(this.bar2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(947, 255);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnSave});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.PaddingLeft = 22;
            this.bar2.Size = new System.Drawing.Size(947, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 4;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "新增(&N)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Text = "删除(&D)";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdFeeList
            // 
            this.grdFeeList.AllowSortWhenClickColumnHeader = false;
            this.grdFeeList.AllowUserToAddRows = false;
            this.grdFeeList.AllowUserToDeleteRows = false;
            this.grdFeeList.AllowUserToResizeColumns = false;
            this.grdFeeList.AllowUserToResizeRows = false;
            this.grdFeeList.BackgroundColor = System.Drawing.Color.White;
            this.grdFeeList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFeeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFeeList.ColumnHeadersHeight = 20;
            this.grdFeeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.Column26,
            this.Column27,
            this.Column28,
            this.Column29,
            this.Column30,
            this.Column31,
            this.Column32,
            this.CalCostMode});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFeeList.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdFeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFeeList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdFeeList.HideSelectionCardWhenCustomInput = false;
            this.grdFeeList.HighlightSelectedColumnHeaders = false;
            this.grdFeeList.IsInputNumSelectedCard = true;
            this.grdFeeList.IsShowLetter = false;
            this.grdFeeList.IsShowPage = true;
            this.grdFeeList.Location = new System.Drawing.Point(0, 25);
            this.grdFeeList.Name = "grdFeeList";
            this.grdFeeList.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFeeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdFeeList.RowHeadersWidth = 30;
            this.grdFeeList.RowTemplate.Height = 23;
            this.grdFeeList.SelectAllSignVisible = false;
            dataGridViewSelectionCard1.BindColumnIndex = 0;
            dataGridViewSelectionCard1.CardColumn = "ItemCode|编码|50,ItemName|项目名称|250,Standard|规格|100,UnitPrice|单价|70,StoreAmount|库存数|" +
    "80,ExecDeptName|执行科室|130";
            dataGridViewSelectionCard1.CardSize = new System.Drawing.Size(680, 280);
            dataGridViewSelectionCard1.DataSource = null;
            dataGridViewSelectionCard1.FilterResult = null;
            dataGridViewSelectionCard1.IsPage = true;
            dataGridViewSelectionCard1.Memo = "费用";
            dataGridViewSelectionCard1.PageTotalRecord = 0;
            dataGridViewSelectionCard1.QueryFields = new string[] {
        "ItemCode",
        "ItemName",
        "Pym",
        "Wbm"};
            dataGridViewSelectionCard1.QueryFieldsString = "ItemCode,ItemName,Pym,Wbm";
            dataGridViewSelectionCard1.SelectCardFilterType = EfwControls.CustomControl.MatchModes.ByAnyString;
            dataGridViewSelectionCard1.ShowCardColumns = null;
            dataGridViewSelectionCard2.BindColumnIndex = 0;
            dataGridViewSelectionCard2.CardColumn = null;
            dataGridViewSelectionCard2.CardSize = new System.Drawing.Size(350, 276);
            dataGridViewSelectionCard2.DataSource = null;
            dataGridViewSelectionCard2.FilterResult = null;
            dataGridViewSelectionCard2.IsPage = true;
            dataGridViewSelectionCard2.Memo = null;
            dataGridViewSelectionCard2.PageTotalRecord = 0;
            dataGridViewSelectionCard2.QueryFields = new string[] {
        ""};
            dataGridViewSelectionCard2.QueryFieldsString = "";
            dataGridViewSelectionCard2.SelectCardFilterType = EfwControls.CustomControl.MatchModes.ByAnyString;
            dataGridViewSelectionCard2.ShowCardColumns = null;
            this.grdFeeList.SelectionCards = new EfwControls.CustomControl.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard1,
        dataGridViewSelectionCard2};
            this.grdFeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFeeList.SelectionNumKeyBoards = null;
            this.grdFeeList.SeqVisible = true;
            this.grdFeeList.SetCustomStyle = false;
            this.grdFeeList.Size = new System.Drawing.Size(947, 230);
            this.grdFeeList.TabIndex = 5;
            this.grdFeeList.SelectCardRowSelected += new EfwControls.CustomControl.OnSelectCardRowSelectedHandle(this.grdFeeList_SelectCardRowSelected);
            this.grdFeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeeList_CellClick);
            this.grdFeeList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeeList_CellValueChanged);
            this.grdFeeList.CurrentCellChanged += new System.EventHandler(this.grdFeeList_CurrentCellChanged);
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ItemID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemID.HeaderText = "编码";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemID.Width = 80;
            // 
            // Column26
            // 
            this.Column26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column26.DataPropertyName = "ItemName";
            this.Column26.HeaderText = "项目名称";
            this.Column26.MinimumWidth = 160;
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column27
            // 
            this.Column27.DataPropertyName = "Spec";
            this.Column27.HeaderText = "规格";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column27.Width = 120;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "ExecDeptName";
            this.Column28.HeaderText = "执行科室";
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            this.Column28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column29
            // 
            this.Column29.DataPropertyName = "SellPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.Column29.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column29.HeaderText = "价格";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column29.Width = 80;
            // 
            // Column30
            // 
            this.Column30.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column30.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column30.HeaderText = "数量";
            this.Column30.Name = "Column30";
            this.Column30.ReadOnly = true;
            this.Column30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column30.Width = 90;
            // 
            // Column31
            // 
            this.Column31.DataPropertyName = "Unit";
            this.Column31.HeaderText = "单位";
            this.Column31.Name = "Column31";
            this.Column31.ReadOnly = true;
            this.Column31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column31.Width = 80;
            // 
            // Column32
            // 
            this.Column32.DataPropertyName = "TotalFee";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Column32.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column32.HeaderText = "金额";
            this.Column32.Name = "Column32";
            this.Column32.ReadOnly = true;
            this.Column32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column32.Width = 90;
            // 
            // CalCostMode
            // 
            this.CalCostMode.DataPropertyName = "CalCostModeName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CalCostMode.DefaultCellStyle = dataGridViewCellStyle6;
            this.CalCostMode.HeaderText = "计费模式";
            this.CalCostMode.Name = "CalCostMode";
            this.CalCostMode.ReadOnly = true;
            this.CalCostMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CalCostMode.Width = 80;
            // 
            // OrderFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.panelEx1);
            this.Name = "OrderFee";
            this.Size = new System.Drawing.Size(947, 255);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private CustomControl.GridBoxCard grdFeeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalCostMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
    }
}
