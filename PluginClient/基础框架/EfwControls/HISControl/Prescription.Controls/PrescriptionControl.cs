using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.HISControl.Prescription.Controls.Action;
using EfwControls.HISControl.Prescription.Controls.Entity;
using EfwControls.Common.Licensing;

namespace EfwControls.HISControl.Prescription.Controls
{
    [LicenseProvider(typeof(EfwControls.Common.Licensing.ComponentLicenseProvider))]
    public partial class PrescriptionControl : UserControl, IPrescriptionControl, IPrescription
    {
        private DataSet CardDataSource;//选项卡数据源

        #region 许可证
        [Browsable(false)]
        public static string DeveloperKey { get; set; }
        private bool _isDemo = true;
        //private static string _licKey = "";
        [Category("许可证"), Description("设置许可证你才能使用此控件")]
        public string LicenseKey
        {
            get { return DeveloperKey; }
            set
            {
                DeveloperKey = value;
                //CheckLicense();
                this.Invalidate();
            }
        }
        private void CheckLicense()
        {
            ComponentLicense lic = LicenseManager.Validate(typeof(PrescriptionControl), this) as ComponentLicense;
            if (lic != null)
            {
                _isDemo = lic.IsDemo;
                if (_isDemo)
                {
                    MessageBox.Show("正确设置[PrescriptionControl]控件的许可证，才能使用！");
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //CheckLicense();
        }
        #endregion

        public PrescriptionControl()
        {
            InitializeComponent();

            //初始化控制器
            controller = new PrescriptionControlController(this);
        }

        public PrescriptionControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //初始化控制器
            controller = new PrescriptionControlController(this);
        }



        #region 自定义事件
        [Description("单张处方打印")]
        public event SinglePrescriptionPrint SinglePresPrint;
        [Description("未收费费用清单打印")]
        public event NochargeCostListPrint CostListPrint;

        [Description("保存处方时检查病人诊断是否为空")]
        public event CheckPatPrescriptionDisease PrescriptionDisease;
        [Description("处方保存时费用联动")]
        public event PrescriptionCostoflinkage Costoflinkage;
        [Description("处方另存为模板")]
        public event AsSavePrescriptionModule AsSavePres;
        [Description("保存医嘱时消息提法")]
        public event PrescriptionMessageShowlinkage MessageShowoflinkage;
        #endregion

        #region 自定义属性
        private bool _isShowToolBar = true;
        [Description("是否显示工具栏")]
        public bool IsShowToolBar
        {
            get { return _isShowToolBar; }
            set
            {
                _isShowToolBar = value;
                this.Toolbar.Visible = _isShowToolBar;
            }
        }

        private bool _isShowMenu = true;
        [Description("是否显示右键菜单")]
        public bool IsShowMenu
        {
            get { return _isShowMenu; }
            set
            {
                _isShowMenu = value;
            }
        }

        private bool _isShowFootText = true;
        [Description("是否显示脚本标签")]
        public bool IsShowFootText
        {
            get { return _isShowFootText; }
            set
            {
                _isShowFootText = value;
                this.panelFoot.Visible = _isShowFootText;
            }
        }

        private PrescriptionStyle _prescriptionStyle = PrescriptionStyle.全部;
        [Description("处方类型")]
        public PrescriptionStyle PrescriptionStyle
        {
            get { return _prescriptionStyle; }
            set
            {
                _prescriptionStyle = value;

                btnMergeGroup.Visible = true;

                Standard.Visible = true;
                Usage_Amount.Visible = true;
                Usage_Unit.Visible = true;
                Dosage.Visible = true;
                Usage_Name.Visible = true;
                Frequency_Name.Visible = true;
                Days.Visible = true;
                Entrust.Visible = true;
                Memo.Visible = false;
                Additional.Visible = false;
                //toolStripSeparator2.Visible = true;
                //tSMnuIGrouping.Visible = true;
                tSMnuICancelGroup.Visible = true;
                tSMnuIFootNote.Visible = true;
                tSMnuISelfDrug.Visible = true;
                tSMnuIPresPrint.Visible = true;
                tSMnuIFeePrint.Visible = true;
                tSMnuIDownRow.Visible = false;
                tSMnuIUpRow.Visible = false;
                tSMnuIOne.Visible = false;
                tSMnuIMany.Visible = false;
                tSMnuIReimbursement.Visible = true;
                if (_prescriptionStyle == PrescriptionStyle.全部)
                {

                }
                else if (_prescriptionStyle == PrescriptionStyle.西药与中成药)
                {
                    Dosage.Visible = false;
                    Memo.Visible = true;
                    tSMnuIFootNote.Visible = false;
                    tSMnuIFeePrint.Visible = false;
                    tSMnuIDownRow.Visible = true;
                    tSMnuIUpRow.Visible = true;
                    tSMnuIOne.Visible = true;
                    tSMnuIMany.Visible = true;
                }
                else if (_prescriptionStyle == PrescriptionStyle.中草药)
                {
                    btnMergeGroup.Visible = false;

                    Days.Visible = false;

                    toolStripSeparator2.Visible = false;
                    tSMnuIGrouping.Visible = false;
                    tSMnuICancelGroup.Visible = false;
                    tSMnuISelfDrug.Visible = false;
                    tSMnuIFeePrint.Visible = false;
                    tSMnuIReimbursement.Visible = false;

                }
                else if (_prescriptionStyle == PrescriptionStyle.收费项目)
                {
                    btnMergeGroup.Visible = false;

                    PresNo.Visible = false;
                    Standard.Visible = false;
                    //Usage_Amount.Visible = false;
                    //Usage_Unit.Visible = false;
                    Dosage.Visible = false;
                    Usage_Name.Visible = false;
                    Frequency_Name.Visible = false;
                    Days.Visible = false;
                    Entrust.Visible = false;
                    Additional.Visible = true;
                    Item_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    toolStripSeparator2.Visible = false;
                    tSMnuIGrouping.Visible = false;
                    tSMnuICancelGroup.Visible = false;
                    tSMnuIFootNote.Visible = false;
                    tSMnuISelfDrug.Visible = false;
                    tSMnuIPresPrint.Visible = false;
                    tSMnuIReimbursement.Visible = false;
                    tsMnuIPresPrints.Visible = false;
                }
            }
        }

        private string[] _oldhideColName;
        private string[] _hideColName;
        [Description("需要隐藏的列名")]
        public string[] HideColName
        {
            get { return _hideColName; }
            set
            {
                _hideColName = value;
                if (_oldhideColName != null && _oldhideColName.Length > 0)
                {
                    for (int i = 0; i < _oldhideColName.Length; i++)
                    {
                        if (_oldhideColName[i].Trim() != "")
                        {
                            if (gridPresDetail.Columns.Contains(_oldhideColName[i]) == true)
                            {
                                gridPresDetail.Columns[_oldhideColName[i]].Visible = true;
                            }
                        }
                    }
                }
                if (_hideColName != null && _hideColName.Length > 0)
                {
                    for (int i = 0; i < _hideColName.Length; i++)
                    {
                        if (_hideColName[i].Trim() != "")
                        {
                            if (gridPresDetail.Columns.Contains(_hideColName[i]) == true)
                            {
                                gridPresDetail.Columns[_hideColName[i]].Visible = false;
                            }
                        }
                    }
                }

                _oldhideColName = _hideColName;
            }
        }
        #endregion

        #region 控件事件（工具栏按钮和右键菜单）
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PrescriptionSave != null)
                //    PrescriptionSave(sender, e);
                (controller as PrescriptionControlController).PresSave();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //新开
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PrescriptionNew != null)
                //    PrescriptionNew(sender, e);

                this.gridPresDetail.Focus();
                (controller as PrescriptionControlController).PresAddRow();

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (PrescriptionEdit != null)
            //    PrescriptionEdit(sender, e);

            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresAlter();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }
        //刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PrescriptionRefresh != null)
                //    PrescriptionRefresh(sender, e);

                (controller as PrescriptionControlController).BindPresData();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //换方
        private void btnChangePres_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PrescriptionChange != null)
                //    PrescriptionChange(sender, e);
                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresChange();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //合组
        private void btnMergeGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PrescriptionMergeGroup != null)
                //    PrescriptionMergeGroup(sender, e);

                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresMergeGroup();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //模板
        private void btnTpl_Click(object sender, EventArgs e)
        {
            PresTemplate presT = new PresTemplate(controller);
            presT.ShowDialog();
            if (presT.isOk)
            {
                (controller as PrescriptionControlController).PresLoadTemplateRow(presT.checkIds);
                this.gridPresDetail.Refresh();
            }
        }

        private void tSMnuIInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridInsertRow != null)
                //    GridInsertRow(sender, e);

                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresInsertRow();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridDeleteRow != null)
                //    GridDeleteRow(sender, e);
                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresDeleteRow();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIUpRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridPresDetail.Rows.Count <= 0)
                    return;
                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresUpRow();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIDownRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridPresDetail.Rows.Count <= 0)
                    return;
                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresDownRow();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIDelPres_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridDeletePres != null)
                //    GridDeletePres(sender, e);
                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresDeleteNo();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIGrouping_Click(object sender, EventArgs e)
        {
            //if (GridBeginGroup != null)
            //    GridBeginGroup(sender, e);
        }

        private void tSMnuICancelGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridEndGroup != null)
                //    GridEndGroup(sender, e);

                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresCancelGroup();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //中药脚注
        private void tSMnuIFootNote_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridFootnote != null)
                //    GridFootnote(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 处方打印单页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMnuIPresPrints_Click(object sender, EventArgs e)
        {
            try
            {
                if (SinglePresPrint != null)
                {
                    if (gridPresDetail.CurrentCell != null)
                    {
                        int presNo = Convert.ToInt32(PresGridDataSource.Rows[GridRowIndex]["PresNo"]);
                        SinglePresPrint(CurrPatListId, (int)PrescriptionStyle, presNo, false);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //处方打印
        private void tSMnuIPresPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (SinglePresPrint != null)
                {
                    if (gridPresDetail.CurrentCell != null)
                    {
                        int presNo = Convert.ToInt32(PresGridDataSource.Rows[GridRowIndex]["PresNo"]);
                        SinglePresPrint(CurrPatListId, (int)PrescriptionStyle, presNo, true);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //费用打印
        private void tSMnuIFeePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CostListPrint != null)
                    CostListPrint(CurrPatListId);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIPresCopy_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridCopyPres != null)
                //    GridCopyPres(sender, e);

                (controller as PrescriptionControlController).PresCopy();
                MessageBox.Show("复制处方成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tSMnuIPresPaste_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridPastePres != null)
                //    GridPastePres(sender, e);

                this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
                (controller as PrescriptionControlController).PresPaste();
                this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //自备
        private void tSMnuISelfDrug_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridSelfDrug != null)
                //    GridSelfDrug(sender, e);
                if (gridPresDetail.CurrentCell == null)
                    return;
                int columnIndex = gridPresDetail.CurrentCell.ColumnIndex;
                (controller as PrescriptionControlController).PresSelfDrug(columnIndex);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //存为模板
        private void tSMnuISaveAsMould_Click(object sender, EventArgs e)
        {
            try
            {
                if (AsSavePres != null)
                {
                    List<Entity.Prescription> data = (controller as PrescriptionControlController).PresAsSaveModule();
                    AsSavePres((int)PrescriptionStyle, data);
                }
                else
                {
                    List<Entity.Prescription> data = (controller as PrescriptionControlController).PresAsSaveModule();
                    if (data.Count > 0)
                    {
                        if (data.FirstOrDefault().Status == PresStatus.编辑状态)
                        {
                            MessageBoxEx.Show("未保存的处方不能存为模板");
                        }
                        else
                        {
                            //先弹出界面输入模板名，再点击保存
                            SaveSetMeal setMeal = new SaveSetMeal(controller, (int)PrescriptionStyle);
                            setMeal.ShowDialog();
                            if (setMeal.IsOK)
                            {
                                controller.AsSavePresTemplate(setMeal.PId, setMeal.MealType, setMeal.MealName, (int)PrescriptionStyle - 1, data);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBoxEx.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //修改数据
        private void tSMnuAlterPres_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GridSelfDrug != null)
                //    GridSelfDrug(sender, e);
                PrescriptionEdit();
                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }



        #region 处方网格事件
        //药品项目分页查询
        private void gridPresDetail_PageNoChanged(object sender, int index, int pageNo, int pageSize, string fiterChar)
        {
            (controller as PrescriptionControlController).FilterDrugItemDataSource(pageNo, pageSize, fiterChar);
        }
        //选中数据
        private void gridPresDetail_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            if (SelectedValue == null)
            {
                stop = true;
                return;
            }
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            int colid = this.gridPresDetail.CurrentCell.ColumnIndex;
            int rowid = this.gridPresDetail.CurrentCell.RowIndex;
            (controller as PrescriptionControlController).PresSelectCard(colid, SelectedValue);
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            if (PrescriptionStyle == PrescriptionStyle.西药与中成药)
            {
                if (colid == this.Item_Unit.Index)
                {
                    (controller as PrescriptionControlController).PresAddRow();
                    stop = true;
                }
            }
            else if (PrescriptionStyle == PrescriptionStyle.中草药)
            {
                if (colid == this.Frequency_Name.Index)
                {
                    (controller as PrescriptionControlController).PresAddRow();
                    stop = true;
                }
            }

            if (colid == this.Entrust.Index)
            {
                (controller as PrescriptionControlController).PresAddRow();
                stop = true;
            }

            this.gridPresDetail.Refresh();
        }

        private void gridPresDetail_UserAddGirdRow(DataRow dataRow)
        {
            (controller as PrescriptionControlController).PresAddRow();
        }

        //回车控制网格焦点
        private void gridPresDetail_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            //if (colIndex == this.Entrust.Index)
            //{
            //    (controller as PrescriptionControlController).PresAddRow();
            //    jumpStop = true;
            //    //控制水平滑动条
            //    for (int index = 0; index < this.gridPresDetail.Controls.Count; index++)
            //    {
            //        if (this.gridPresDetail.Controls[index].GetType().ToString() == "System.Windows.Forms.HScrollBar")
            //        {
            //            HScrollBar scrollbar = (System.Windows.Forms.HScrollBar)this.gridPresDetail.Controls[index];
            //            scrollbar.Value = 0;
            //        }
            //    }
            //}
            if ((this.gridPresDetail.DataSource as DataTable).Rows[this.gridPresDetail.CurrentCell.RowIndex]["Status"].ToString() == "4" &&
                (this.gridPresDetail.DataSource as DataTable).Rows[this.gridPresDetail.CurrentCell.RowIndex]["Item_Id_S"].ToString() == "")
            {
                jumpStop = true;
                return;
            }
            if (PrescriptionStyle == PrescriptionStyle.收费项目)
            {
                int colid = this.gridPresDetail.CurrentCell.ColumnIndex;
                if (colid == this.Usage_Amount.Index)
                {
                    (controller as PrescriptionControlController).PresAddRow();
                    jumpStop = true;
                }
            }
        }
        //画分组线
        private void gridPresDetail_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (controller != null)
                    (controller as PrescriptionControlController).PresPaintLine(e.Graphics, PrescriptionStyle);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //Cell只读
        private void gridPresDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.gridPresDetail.CurrentCell != null)
            {
                if ((gridPresDetail.DataSource as DataTable).Rows[this.gridPresDetail.CurrentCell.RowIndex]["Status"] == DBNull.Value)
                    return;
                (controller as PrescriptionControlController).SettingReadOnly(this.gridPresDetail.CurrentCell.RowIndex);
                (controller as PrescriptionControlController).UploadCardDataSource(this.gridPresDetail.CurrentCell.RowIndex, this.gridPresDetail.CurrentCell.ColumnIndex);

                DataTable dt = this.PresGridDataSource;
                if (Convert.ToInt32(dt.Rows[this.gridPresDetail.CurrentCell.RowIndex]["SelfDrug_Flag"]) == 0)
                {
                    tSMnuISelfDrug.Text = "自备药品(Ctrl+B)";
                }
                else
                {
                    tSMnuISelfDrug.Text = "取消自备(Ctrl+B)";
                }
                if (Convert.ToInt32(dt.Rows[this.gridPresDetail.CurrentCell.RowIndex]["IsReimbursement"]) == 0)
                {
                    tSMnuIReimbursement.Text = "医保外处方";
                }
                else
                {
                    tSMnuIReimbursement.Text = "取消医保外处方";
                }
                if (!this.gridPresDetail.CurrentCell.ReadOnly
                    && this.gridPresDetail.CurrentCell.ColumnIndex != this.Item_Id.Index
                     && this.gridPresDetail.CurrentCell.ColumnIndex != this.Entrust.Index)
                {
                    this.gridPresDetail.BeginEdit(true);
                }
            }

        }

        private void gridPresDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.gridPresDetail.CurrentCell != null)
            {
                int rowid = e.RowIndex;
                int colid = e.ColumnIndex;

                if (this.Usage_Amount.Index == colid || this.Dosage.Index == colid || this.Days.Index == colid || this.Item_Amount.Index == colid)
                {
                    (controller as PrescriptionControlController).PresSelectCard(colid, null);
                }

                this.gridPresDetail.Refresh();
            }
        }

        private void gridPresDetail_DataSourceChanged(object sender, EventArgs e)
        {
            //this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            //this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);
        }
        #endregion

        #region IPrescriptionControl 外观
        [Browsable(false)]
        internal PrescriptionControlController controller
        {
            get;
            set;
        }

        public void InitializeCardData(DataSet cardDataSource)
        {
            CardDataSource = cardDataSource;//选项卡数据源
            //    this.gridPresDetail.BindSelectionCardDataSource(0, cardDataSource.Tables["itemdrug"]);//药品项目
            //    this.gridPresDetail.BindSelectionCardDataSource(1, cardDataSource.Tables["execdept"]);//执行科室
            //    this.gridPresDetail.BindSelectionCardDataSource(2, cardDataSource.Tables["unitdic"]);//单位
            //    this.gridPresDetail.BindSelectionCardDataSource(3, cardDataSource.Tables["usagedic"]);//用法
            //    this.gridPresDetail.BindSelectionCardDataSource(4, cardDataSource.Tables["frequencydic"]);//频次
            //    this.gridPresDetail.BindSelectionCardDataSource(5, cardDataSource.Tables["packunitdic"]);//单位
            //    this.gridPresDetail.BindSelectionCardDataSource(6, cardDataSource.Tables["entrustdic"]);//嘱托
            //
        }

        public void InitializeAsynCardData()
        {
            this.gridPresDetail.BindSelectionCardDataSource(0, CardDataSource.Tables["itemdrug"]);//药品项目
            this.gridPresDetail.BindSelectionCardDataSource(1, CardDataSource.Tables["execdept"]);//执行科室
            this.gridPresDetail.BindSelectionCardDataSource(2, CardDataSource.Tables["unitdic"]);//单位
            this.gridPresDetail.BindSelectionCardDataSource(3, CardDataSource.Tables["usagedic"]);//用法
            this.gridPresDetail.BindSelectionCardDataSource(4, CardDataSource.Tables["frequencydic"]);//频次
            this.gridPresDetail.BindSelectionCardDataSource(5, CardDataSource.Tables["packunitdic"]);//单位
            this.gridPresDetail.BindSelectionCardDataSource(6, CardDataSource.Tables["entrustdic"]);//嘱托
        }

        public void LoadGridPresData(DataTable presData)
        {
            gridPresDetail.EndEdit();
            if (this.gridPresDetail.DataSource != null)
            {
                this.gridPresDetail.DataSource = null;
            }
            this.gridPresDetail.DataSource = presData;
            this.gridPresDetail.Refresh();
            for (int index = 0; index < PresGridDataSource.Rows.Count; index++)
            {
                (controller as PrescriptionControlController).SetCellColor(index, -1);
            }
        }

        public DataTable PresGridDataSource
        {
            get { return (DataTable)this.gridPresDetail.DataSource; }
        }

        public Rectangle GridCellBounds(int rowIndex)
        {
            Rectangle rectangle = new Rectangle(this.gridPresDetail.GetCellDisplayRectangle(this.Item_Id.Index, rowIndex, false).X,
                    this.gridPresDetail.GetCellDisplayRectangle(this.Item_Id.Index, rowIndex, false).Y,
                    this.gridPresDetail.GetCellDisplayRectangle(this.Item_Id.Index, rowIndex, false).Width + this.gridPresDetail.GetCellDisplayRectangle(this.Item_Name.Index, rowIndex, false).Width,
                    this.gridPresDetail.GetCellDisplayRectangle(this.Item_Id.Index, rowIndex, false).Height);

            return rectangle;
        }

        //网格选择行
        [Browsable(false)]
        public int GridRowIndex
        {
            get
            {
                if (gridPresDetail.CurrentCell != null)
                    return gridPresDetail.CurrentCell.RowIndex;
                else
                    return -1;
            }
        }


        public PresCellReadOnlyStatus CellReadOnly
        {
            set
            {
                this.Item_Id.ReadOnly = true;
                this.Dept_Name.ReadOnly = true;
                this.Usage_Amount.ReadOnly = true;
                this.Usage_Unit.ReadOnly = true;
                this.Dosage.ReadOnly = true;
                this.Usage_Name.ReadOnly = true;
                this.Frequency_Name.ReadOnly = true;
                this.Days.ReadOnly = true;
                this.Item_Amount.ReadOnly = true;
                this.Item_Unit.ReadOnly = true;
                this.Entrust.ReadOnly = true;
                this.Memo.ReadOnly = true;
                this.Additional.ReadOnly = true;

                switch (value)
                {
                    case PresCellReadOnlyStatus.全部只读:
                        break;
                    case PresCellReadOnlyStatus.皮试:
                        this.Item_Id.ReadOnly = true;
                        this.Usage_Amount.ReadOnly = false;
                        this.Usage_Unit.ReadOnly = true;
                        this.Usage_Name.ReadOnly = true;
                        this.Frequency_Name.ReadOnly = true;
                        this.Days.ReadOnly = true;
                        this.Item_Amount.ReadOnly = true;
                        this.Item_Unit.ReadOnly = true;
                        this.Entrust.ReadOnly = false;
                        break;
                    case PresCellReadOnlyStatus.药品处方:
                        this.Item_Id.ReadOnly = false;
                        this.Usage_Amount.ReadOnly = false;
                        this.Usage_Unit.ReadOnly = false;
                        this.Usage_Name.ReadOnly = false;
                        this.Frequency_Name.ReadOnly = false;
                        this.Days.ReadOnly = false;
                        this.Item_Amount.ReadOnly = false;
                        this.Item_Unit.ReadOnly = false;
                        this.Entrust.ReadOnly = false;
                        break;
                    case PresCellReadOnlyStatus.甲类药品处方:
                        this.Item_Id.ReadOnly = false;
                        this.Usage_Amount.ReadOnly = false;
                        this.Usage_Unit.ReadOnly = false;
                        this.Usage_Name.ReadOnly = false;
                        this.Frequency_Name.ReadOnly = false;
                        this.Item_Amount.ReadOnly = false;
                        this.Item_Unit.ReadOnly = false;
                        this.Entrust.ReadOnly = false;
                        break;
                    case PresCellReadOnlyStatus.中药处方:
                        this.Item_Id.ReadOnly = false;
                        this.Usage_Amount.ReadOnly = false;
                        this.Usage_Unit.ReadOnly = false;
                        this.Dosage.ReadOnly = false;
                        this.Usage_Name.ReadOnly = false;
                        this.Frequency_Name.ReadOnly = false;
                        this.Entrust.ReadOnly = false;
                        break;
                    case PresCellReadOnlyStatus.项目:
                        this.Item_Id.ReadOnly = false;
                        this.Usage_Amount.ReadOnly = false;
                        //this.Usage_Unit.ReadOnly = false;
                        break;
                    case PresCellReadOnlyStatus.新行:
                        this.Item_Id.ReadOnly = false;
                        break;
                }
            }
        }



        public Prescription.Controls.Entity.PresColor CellColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    bool bSmallSum = false;
                    for (int r = 0; r < this.gridPresDetail.Columns.Count; r++)
                    {
                        string status_flag = this.gridPresDetail.Rows[value.rowIndex].Cells[r].Value.ToString();
                        Color foreColor = ColorTranslator.FromHtml("#1e5aab");
                        if (status_flag == "小计：")
                        {
                            bSmallSum = true;
                            this.gridPresDetail.Rows[value.rowIndex].Cells[r].Style.ForeColor = foreColor;
                        }
                        else
                        {
                            if (bSmallSum == true)
                            {
                                this.gridPresDetail.Rows[value.rowIndex].Cells[r].Style.ForeColor = foreColor;
                            }
                            else
                            {
                                this.gridPresDetail.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                            }
                        }
                        this.gridPresDetail.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    this.gridPresDetail.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    this.gridPresDetail.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }

        #endregion

        #region IPrescriptionControl 数据
        [Browsable(false)]
        public int CurrPatListId
        {
            get;
            set;
        }
        [Browsable(false)]
        public int PresDeptCode
        {
            get;
            set;
        }
        [Browsable(false)]
        public string PresDeptName
        {
            get;
            set;
        }
        [Browsable(false)]
        public int PresDoctorId
        {
            get;
            set;
        }
        [Browsable(false)]
        public string PresDoctorName
        {
            get;
            set;
        }
        [Browsable(false)]
        public int PresCount
        {
            get;
            set;
        }
        [Browsable(false)]
        public int DrugRepeatWarn
        {
            get;
            set;
        }
        [Browsable(false)]
        public int DayGreater30
        {
            get;
            set;
        }
        public void SetGridCurrentCell(int rowIndex, int colIndex)
        {
            this.gridPresDetail.Focus();
            if (rowIndex > -1 && this.gridPresDetail.Rows.Count > 0)
                this.gridPresDetail.CurrentCell = this.gridPresDetail[colIndex, rowIndex];
        }
        [Browsable(false)]
        public PresColumnIndex AllColumnIndex
        {
            get
            {
                PresColumnIndex presColumnIndex = new PresColumnIndex();
                presColumnIndex.ItemIdIndex = this.Item_Id.Index;
                presColumnIndex.ItemNameIndex = this.Item_Name.Index;
                presColumnIndex.DeptNameIndex = this.Dept_Name.Index;
                presColumnIndex.UsageAmountIndex = this.Usage_Amount.Index;
                presColumnIndex.UsageUnitIndex = this.Usage_Unit.Index;
                presColumnIndex.DosageIndex = this.Dosage.Index;
                presColumnIndex.UsageIndex = this.Usage_Name.Index;
                presColumnIndex.FrequencyIndex = this.Frequency_Name.Index;
                presColumnIndex.DaysIndex = this.Days.Index;
                presColumnIndex.ItemAmountIndex = this.Item_Amount.Index;
                presColumnIndex.ItemUnitIndex = this.Item_Unit.Index;
                presColumnIndex.EntrustIndex = this.Entrust.Index;
                return presColumnIndex;
            }
        }
        [Browsable(false)]
        public int[] GridSelectedRows
        {
            get
            {
                List<int> rowsIn = new List<int>();
                for (int i = 0; i < this.gridPresDetail.SelectedCells.Count; i++)
                {
                    int Index = this.gridPresDetail.SelectedCells[i].RowIndex;
                    if (rowsIn.IndexOf(Index) == -1)
                        rowsIn.Add(Index);
                }

                return rowsIn.OrderBy(x => x).ToArray();
            }
        }

        public bool CheckDisease()
        {
            if (PrescriptionDisease != null)
            {
                return PrescriptionDisease(CurrPatListId);
            }

            return true;
        }

        public void SaveCostoflinkage(List<Entity.Prescription> data)
        {
            if (Costoflinkage != null)
            {
                Costoflinkage(CurrPatListId, data);
            }
        }

        public bool PromptController(string text)
        {
            if (MessageBox.Show(text, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            return false;
        }

        #endregion

        #region IPrescription 成员
        public void PrescriptionPaste()
        {
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresPaste();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        public void PrescriptionCopy()
        {
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresCopy();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
            MessageBox.Show("复制处方成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void InitDbHelper(IPrescripttionDbHelper iPresDbHelper)
        {
            //Prescription.PrescripttionDataSource = iPresDbHelper;
            (controller as PrescriptionControlController).BindCardDataSource(iPresDbHelper);
        }

        public void LoadPatData(int patListID, int presDeptCode, string presDeptName, int presDoctorId, string presDoctorName)
        {
            CurrPatListId = patListID;
            PresDeptCode = presDeptCode;
            PresDeptName = presDeptName;
            PresDoctorId = presDoctorId;
            PresDoctorName = presDoctorName;

            this.gridPresDetail.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPresDetail_Paint);
            (controller as PrescriptionControlController).BindPresData();
            this.gridPresDetail.Refresh();
        }

        public void PrescriptionSave()
        {
            (controller as PrescriptionControlController).PresSave();
        }

        public void PrescriptionNew()
        {
            this.gridPresDetail.Focus();
            if (this.gridPresDetail.RowCount > 0) this.SetGridCurrentCell(0, this.Item_Name.Index);
            (controller as PrescriptionControlController).PresAddRow();

            this.gridPresDetail.Refresh();
        }

        public void PrescriptionEdit()
        {
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresAlter();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        public void SetSeletedDrugRoomID(int deptID)
        {
            this.gridPresDetail.EndEdit();
            DataTable dtDrug = (controller as PrescriptionControlController).SetSeletedDrugRoomID(deptID);
            this.gridPresDetail.BindSelectionCardDataSource(0, dtDrug);//药品项目
        }
        /// <summary>
        /// 刷新药品选项卡数据
        /// </summary>
        public void RefreshDrugData()
        {
            this.gridPresDetail.EndEdit();
            DataTable dtDrug = (controller as PrescriptionControlController).RefreshDrugData();
            this.gridPresDetail.BindSelectionCardDataSource(0, dtDrug);//药品项目
        }
        public void PrescriptionDelete()
        {
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresDeleteNo();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        public void PrescriptionRefresh()
        {
            (controller as PrescriptionControlController).BindPresData();
        }

        public void PrescriptionChange()
        {
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresChange();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        public void PrescriptionMergeGroup()
        {
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresMergeGroup();
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        public void PrescriptionPrint()
        {

        }

        public void PrescriptionLoadTemplate(int tplId)
        {
            this.gridPresDetail.EndEdit();
            (controller as PrescriptionControlController).PresLoadTemplate(tplId);
            this.gridPresDetail.Refresh();
        }

        public void PrescriptionLoadTemplateRow(int[] tpldetailId)
        {
            this.gridPresDetail.EndEdit();
            (controller as PrescriptionControlController).PresLoadTemplateRow(tpldetailId);
            this.gridPresDetail.Refresh();
        }

        public void PrescriptionLoadList(List<Prescription.Controls.Entity.Prescription> data)
        {
            throw new NotImplementedException();
        }

        public void AddContextMenu(List<ToolStripMenuItem> menuList)
        {
            if (menuList != null && menuList.Count > 0)
            {
                ToolStripSeparator sep = new ToolStripSeparator();
                ctMnuSPres.Items.Insert(0, sep);
                for (int i = 0; i < menuList.Count; i++)
                {
                    ctMnuSPres.Items.Insert(i, menuList[i]);
                }
            }
        }

        #endregion

        #region IBaseView 成员

        [Browsable(false)]
        public int currModuleID
        {
            get { throw new NotImplementedException(); }
        }
        [Browsable(false)]
        public int currSysID
        {
            get { throw new NotImplementedException(); }
        }




        #endregion

        public void ShowMessage(string message)
        {
            // MessageBoxEx.Show(message);
            if (MessageShowoflinkage != null)
            {
                MessageShowoflinkage(message);
            }
        }

        private void gridPresDetail_Click(object sender, EventArgs e)
        {


        }

        private void gridPresDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void gridPresDetail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                if (gridPresDetail.Rows[e.RowIndex].Cells["Item_Name"].Value.ToString() != "小计：")
                {
                    if (IsShowMenu == true)
                    {
                        ctMnuSPres.Show(MousePosition);
                    }
                }
            }
        }

        private void tSMnuIOne_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itemMenu = (ToolStripMenuItem)sender;
            string menuText = itemMenu.Text;
            int execTimes = Convert.ToInt32(itemMenu.Tag);
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).PresInjectTimes(menuText, execTimes);
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        private void tsmRefundFee_Click(object sender, EventArgs e)
        {
            if (gridPresDetail.CurrentCell == null)
                return;
            this.gridPresDetail.CurrentCellChanged -= new EventHandler(gridPresDetail_CurrentCellChanged);
            (controller as PrescriptionControlController).RefundFee(gridPresDetail.CurrentCell.RowIndex);
            this.gridPresDetail.CurrentCellChanged += new EventHandler(gridPresDetail_CurrentCellChanged);

            this.gridPresDetail.Refresh();
        }

        private void tSMnuIReimbursement_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridPresDetail.CurrentCell == null)
                    return;
                int columnIndex = gridPresDetail.CurrentCell.ColumnIndex;
                (controller as PrescriptionControlController).PresReimbursement(columnIndex);

                this.gridPresDetail.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
    //保存处方时检测病人诊断是否为空
    public delegate bool CheckPatPrescriptionDisease(int patListId);
    //单张处方打印
    public delegate void SinglePrescriptionPrint(int patListId, int presType, int presNo, bool isDoublePrint);
    //未收费费用清单打印
    public delegate void NochargeCostListPrint(int patListId);
    //处方保存时费用联动
    public delegate void PrescriptionCostoflinkage(int patListId, List<Entity.Prescription> data);
    //存为模板
    public delegate void AsSavePrescriptionModule(int presType, List<Entity.Prescription> data);
    /// <summary>
    /// 提示信息弹出
    /// </summary>
    /// <param name="message"></param>
    public delegate void PrescriptionMessageShowlinkage(string message);

    public enum PrescriptionStyle
    {
        全部 = 0, 西药与中成药 = 1, 中草药 = 2, 收费项目 = 3
    }
}
