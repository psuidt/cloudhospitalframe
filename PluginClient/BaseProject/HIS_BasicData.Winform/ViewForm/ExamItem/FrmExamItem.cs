using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.ExamItem;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.ExamItem
{
    /// <summary>
    /// 组合项目维护
    /// </summary>
    public partial class FrmExamItem : BaseFormBusiness, IFrmExamItem
    {
        /// <summary>
        /// 组合项目
        /// </summary>
        private Basic_ExamItem currExamItem;

        /// <summary>
        /// 组合项目
        /// </summary>
        public Basic_ExamItem CurrExamItem
        {
            get
            {
                frmFormExamItem.GetValue<Basic_ExamItem>(currExamItem);
                return currExamItem;
            }

            set
            {
                currExamItem = value;
                frmFormExamItem.Load<Basic_ExamItem>(currExamItem);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmExamItem()
        {
            InitializeComponent();
            bindGridSelectIndex(gridExamType, gridExamItem, gridExamFee);
            frmFormExamItem.AddItem(cbStatItem, "StatID");
            frmFormExamItem.AddItem(cbExamType, "ExamTypeID");
            frmFormExamItem.AddItem(txtExamItemName, "ExamItemName");
            frmFormExamItem.AddItem(txtShortName, "ItemShortName");
            frmFormExamItem.AddItem(ckExamItem, "DelFlag");
            frmForm.AddItem(txtExamTypeName, "ExamTypeName");
            frmForm.AddItem(cbExecDept, "ExecDeptID");
            frmForm.AddItem(cbSample, "SampleID");
            frmForm.AddItem(txtReportNo, "ReportNo");
            frmForm.AddItem(ckExamType, "DelFlag");
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmExamItem_OpenWindowBefore(object sender, EventArgs e)
        {
            SetbtnETState(OperType.默认);
            leftPanel.Expanded = false;
        }

        #region 查询数据

        /// <summary>
        /// 切换组合项目分类加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void CbExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeController("GetExamTypeData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbExamClass.SelectedValue));
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void CbWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeController("ChangeWorker", Convert.ToInt32(cbWorkers.SelectedValue));
            InvokeController("GetSampleList", Convert.ToInt32(cbWorkers.SelectedValue));// 加载样品列表
            InvokeController("GetExamTypeData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbExamClass.SelectedValue));
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSearchExam_Click(object sender, EventArgs e)
        {
            InvokeController("GetExamItemData", Convert.ToInt32(cbWorkers.SelectedValue), -1, txtSearchExam.Text);
        }

        /// <summary>
        /// 选中组合项目类型
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridExamType_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridExamType.CurrentCell != null)
                {
                    loadExamFeeGrid(null);

                    int examtypeId = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["ExamTypeID"]);
                    string examTypeName = (gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["ExamTypeName"].ToString();
                    int execDeptID = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["ExecDeptID"]);
                    int delFlag = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["DelFlag"]);
                    int sampleId = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["SampleID"]);
                    int reportNo = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["ReportNo"]);
                    InvokeController("GetExamItemData", Convert.ToInt32(cbWorkers.SelectedValue), examtypeId, string.Empty);

                    cbExamType.SelectedValue = examtypeId;
                    SetbtnETState(OperType.默认);
                    txtExamTypeName.Text = examTypeName;
                    cbExecDept.MemberValue = execDeptID;
                    cbSample.MemberValue = sampleId;
                    txtReportNo.Value = reportNo;
                    ckExamType.CheckValue = delFlag;
                    //bindGridSelectIndex(gridExamType);
                }
                else
                {
                    txtExamTypeName.Text = string.Empty;
                    cbExecDept.Text = string.Empty;
                    cbSample.Text = string.Empty;
                    txtReportNo.Text = string.Empty;
                    ckExamType.CheckValue = 0;
                    gridExamItem.DataSource = null;
                    gridExamFee.DataSource = null;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 选中组合项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridExamItem_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridExamItem.CurrentCell != null)
                {
                    int examItemID = Convert.ToInt32((gridExamItem.DataSource as DataTable).Rows[gridExamItem.CurrentCell.RowIndex]["ExamItemID"]);
                    InvokeController("GetExamFeeData", examItemID);

                    CurrExamItem = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_ExamItem>(gridExamItem.DataSource as DataTable, gridExamItem.CurrentCell.RowIndex);
                    SetbtnEIState(OperType.默认);
                }
                else
                {
                    CurrExamItem = new Basic_ExamItem();
                    //gridExamFee.DataSource = null;
                }

                SetGridExamFeeState = true;
            }
            catch
            {
            }
        }
        #endregion

        #region 组合项目类型

        /// <summary>
        /// 设置界面按钮是否可用
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnETState(OperType type)
        {
            if (type == OperType.新增)
            {
                btnNewET.Enabled = false;
                btnSaveET.Enabled = true;
                //btnDelET.Enabled = false;
                txtExamTypeName.Text = string.Empty;
                cbExecDept.Text = string.Empty;
                cbSample.Text = string.Empty;
                txtReportNo.Value = 0;
                ckExamType.CheckValue = 0;
            }
            else
            {
                btnNewET.Enabled = true;
                btnSaveET.Enabled = true;
                //btnDelET.Enabled = true;
            }
        }

        /// <summary>
        /// 新增组合项目类型
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNewET_Click(object sender, EventArgs e)
        {
            //if (gridExamType.CurrentCell == null) return;
            SetbtnETState(OperType.新增);
            txtExamTypeName.Focus();
        }

        /// <summary>
        /// 保存组合项目分类
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSaveET_Click(object sender, EventArgs e)
        {
            if (txtExamTypeName.Text == string.Empty)
            {
                MessageBox.Show("类型名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExamTypeName.Focus();
                return;
            }

            if (cbExecDept.Text == string.Empty)
            {
                MessageBox.Show("执行科室不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbExecDept.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtReportNo.Text) || txtReportNo.Value <= 0)
            {
                MessageBox.Show("报表编号不能小于等于0或为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReportNo.Focus();
                return;
            }

            int delflag = ckExamType.Checked ? 1 : 0;
            if (btnNewET.Enabled == true && gridExamType.CurrentCell != null)
            {
                int examtypeId = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["ExamTypeID"]);
                int examClass = Convert.ToInt32((gridExamType.DataSource as DataTable).Rows[gridExamType.CurrentCell.RowIndex]["ExamClass"]);
                InvokeController(
                    "SaveExamType",
                    Convert.ToInt32(cbWorkers.SelectedValue),
                    examtypeId, 
                    examClass,
                    txtExamTypeName.Text,
                    Convert.ToInt32(cbExecDept.MemberValue),
                    delflag,
                    Tools.ToInt32(cbSample.MemberValue),
                    Tools.ToInt32(txtReportNo.Value));
                InvokeController("GetExamTypeData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbExamClass.SelectedValue));
            }
            else if (btnNewET.Enabled == false)
            {
                InvokeController(
                    "SaveExamType",
                    Convert.ToInt32(cbWorkers.SelectedValue),
                    0,
                    Convert.ToInt32(cbExamClass.SelectedValue),
                    txtExamTypeName.Text,
                    Convert.ToInt32(cbExecDept.MemberValue),
                    delflag,
                    Tools.ToInt32(cbSample.MemberValue),
                    Tools.ToInt32(txtReportNo.Value));
                InvokeController("GetExamTypeData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbExamClass.SelectedValue));
                setGridSelectIndex(gridExamType, gridExamType.RowCount - 1);
            }

            SetbtnETState(OperType.默认);
        }

        #endregion

        #region 组合项目

        /// <summary>
        /// 设置组合项目维护按钮是否可用
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnEIState(OperType type)
        {
            if (type == OperType.新增)
            {
                btnNewEI.Enabled = false;
                btnSaveEI.Enabled = true;
                CurrExamItem = new Basic_ExamItem();
            }
            else
            {
                btnNewEI.Enabled = true;
                btnSaveEI.Enabled = true;
            }
        }

        /// <summary>
        /// 新增组合项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNewEI_Click(object sender, EventArgs e)
        {
            SetbtnEIState(OperType.新增);
            cbStatItem.Focus();
        }

        /// <summary>
        /// 保存组合项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSaveEI_Click(object sender, EventArgs e)
        {
            bool isNew = false;
            if (cbStatItem.Text == string.Empty)
            {
                MessageBox.Show("统计分类不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbStatItem.Focus();
                return;
            }

            if (cbExamType.SelectedValue == null)
            {
                MessageBox.Show("项目类型不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbExamType.Focus();
                return;
            }

            if (txtExamItemName.Text == string.Empty)
            {
                MessageBox.Show("组合项目名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExamItemName.Focus();
                return;
            }

            if (btnNewEI.Enabled == true)
            {
                isNew = false;
            }
            else
            {
                isNew = true;
            }

            InvokeController("SaveExamItem", Convert.ToInt32(cbWorkers.SelectedValue));
            InvokeController("GetExamItemData", Convert.ToInt32(cbWorkers.SelectedValue), currExamItem.ExamTypeID, string.Empty);

            if (isNew == true)
            {
                setGridSelectIndex(gridExamItem, gridExamItem.RowCount - 1);
            }

            SetbtnEIState(OperType.默认);
        }

        #endregion

        #region 对应费用

        /// <summary>
        /// 费用网格状态
        /// </summary>
        public bool SetGridExamFeeState
        {
            set
            {
                bool b = value;
                if (b == false)
                {
                    gridExamFee.ReadOnly = false;
                    gridExamFee.Columns[0].ReadOnly = true;
                    gridExamFee.Columns[1].ReadOnly = false;
                    gridExamFee.Columns[2].ReadOnly = true;
                    gridExamFee.Columns[3].ReadOnly = true;
                    gridExamFee.Columns[4].ReadOnly = true;
                    gridExamFee.Columns[5].ReadOnly = false;
                }
                else
                {
                    gridExamFee.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 新增费用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNewEF_Click(object sender, EventArgs e)
        {
            if (gridExamItem.CurrentCell == null)
            {
                return;
            }

            SetGridExamFeeState = false;
            gridExamFee.AddRow();
        }

        /// <summary>
        /// 修改费用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnAlterEF_Click(object sender, EventArgs e)
        {
            SetGridExamFeeState = false;
        }

        /// <summary>
        /// 去掉空白行
        /// </summary>
        /// <param name="dt">费用数据</param>
        private void RemoveLastEmptyRow(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }

            DataRow dr = dt.NewRow();
            DataRow lastdr = dt.Rows[dt.Rows.Count - 1];
            bool isHave = true;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dr[i].Equals(lastdr[i]) == false)
                {
                    isHave = false;
                }
            }

            if (isHave)
            {
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
            }
        }

        /// <summary>
        /// 保存组合项目费用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSaveEF_Click(object sender, EventArgs e)
        {
            gridExamFee.EndEdit();

            DataTable dt = (DataTable)gridExamFee.DataSource;

            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }

            RemoveLastEmptyRow(dt);
            if (dt.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ItemID"] == DBNull.Value)
                {
                    continue;
                }

                if (Convert.ToInt32(dt.Rows[i]["ItemAmount"]) < 1)
                {
                    gridExamFee.CurrentCell = gridExamFee[5, i];
                    gridExamFee.BeginEdit(true);
                    MessageBoxShowSimple("数量必须大于0！");
                    return;
                }
            }

            int examItemID = Convert.ToInt32((gridExamItem.DataSource as DataTable).Rows[gridExamItem.CurrentCell.RowIndex]["ExamItemID"]);
            InvokeController("SaveExamFee", Convert.ToInt32(cbWorkers.SelectedValue), examItemID, dt);
            InvokeController("GetExamFeeData", examItemID);
            SetGridExamFeeState = true;
        }

        /// <summary>
        /// 删除组合项目费用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnDelEF_Click(object sender, EventArgs e)
        {
            if (gridExamFee.CurrentCell != null)
            {
                int rowid = this.gridExamFee.CurrentCell.RowIndex;
                DataTable dt = (DataTable)gridExamFee.DataSource;
                dt.Rows.RemoveAt(rowid);
            }
        }

        /// <summary>
        /// 弹出网格选中组合项目费用
        /// </summary>
        /// <param name="selectedValue">选中的费用数据</param>
        /// <param name="stop">Stop标志</param>
        /// <param name="customNextColumnIndex">下一个获得焦点的列</param>
        private void gridExamFee_SelectCardRowSelected(object selectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            try
            {
                DataRow row = (DataRow)selectedValue;
                int rowid = this.gridExamFee.CurrentCell.RowIndex;
                DataTable dt = (DataTable)gridExamFee.DataSource;
                int examItemID = Convert.ToInt32((gridExamItem.DataSource as DataTable).Rows[gridExamItem.CurrentCell.RowIndex]["ExamItemID"]);
                dt.Rows[rowid]["ExamItemID"] = examItemID;
                dt.Rows[rowid]["FeeClass"] = row["ItemClass"];
                dt.Rows[rowid]["ItemID"] = row["ItemID"];
                dt.Rows[rowid]["ItemName"] = row["ItemName"];
                dt.Rows[rowid]["ItemUnit"] = row["UnPickUnit"];
                dt.Rows[rowid]["SellPrice"] = row["SellPrice"];
                dt.Rows[rowid]["ItemAmount"] = 0;
                dt.Rows[rowid]["FeeClassName"] = row["ItemClassName"];

                gridExamFee.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        #endregion

        #region 接口

        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构</param>
        public void loadWorkerDataBox(DataTable dt, int defaultWorkID)
        {
            cbWorkers.DisplayMember = "WorkName";
            cbWorkers.ValueMember = "WorkId";
            cbWorkers.DataSource = dt;
            cbWorkers.SelectedValue = defaultWorkID;
        }

        /// <summary>
        /// 加载组合项目类型
        /// </summary>
        /// <param name="dt">组合项目类型列表</param>
        public void loadExamClassBox(DataTable dt)
        {
            cbExamClass.DisplayMember = "Name";
            cbExamClass.ValueMember = "ID";
            cbExamClass.DataSource = dt;
            cbExamClass.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载组合项目
        /// </summary>
        /// <param name="dt">组合项目列表</param>
        public void loadDeptDataBox(DataTable dt)
        {
            cbExecDept.DisplayField = "Name";
            cbExecDept.MemberField = "DeptId";
            cbExecDept.CardColumn = "Name|科室名称|auto";
            cbExecDept.QueryFieldsString = "Name,Pym,Wbm";
            cbExecDept.ShowCardDataSource = dt;
            cbExecDept.MemberValue = 0;
        }

        /// <summary>
        /// 绑定组合项目类型
        /// </summary>
        /// <param name="dt">组合项目类型</param>
        public void loadExamTypeGrid(DataTable dt)
        {
            gridExamType.DataSource = dt;

            DataView dv = new DataView(dt.Copy());
            dv.RowFilter = "DelFlag=0";

            loadExamTypeBox(dv.ToTable());

            setGridSelectIndex(gridExamType);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DelFlag"]) == 1)
                {
                    gridExamType.SetRowColor(i, Color.Red, true);
                }
            }
        }

        /// <summary>
        /// 绑定组合项目类型
        /// </summary>
        /// <param name="dt">组合项目类型</param>
        public void loadExamTypeBox(DataTable dt)
        {
            cbExamType.DisplayMember = "ExamTypeName";
            cbExamType.ValueMember = "ExamTypeID";
            cbExamType.DataSource = dt;
            //cbExamType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定统计大类列表
        /// </summary>
        /// <param name="dt">统计大类列表</param>
        public void loadStatItemBox(DataTable dt)
        {
            cbStatItem.DisplayField = "StatName";
            cbStatItem.MemberField = "StatID";
            cbStatItem.CardColumn = "StatName|名称|auto";
            cbStatItem.QueryFieldsString = "StatName,PyCode,WbCode";
            cbStatItem.ShowCardDataSource = dt;
        }

        /// <summary>
        /// 绑定组合项目列表
        /// </summary>
        /// <param name="dt">组合项目列表</param>
        public void loadExamItemGrid(DataTable dt)
        {
            gridExamItem.DataSource = dt;

            setGridSelectIndex(gridExamItem);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DelFlag"]) == 1)
                {
                    gridExamItem.SetRowColor(i, Color.Red, true);
                }
            }
        }

        /// <summary>
        /// 绑定组合项目费用列表
        /// </summary>
        /// <param name="dt">组合项目费用列表</param>
        public void loadExamFeeGrid(DataTable dt)
        {
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                decimal totalFee = 0.00M;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalFee += Tools.ToDecimal(dt.Rows[i]["SellPrice"]) * Tools.ToInt32(dt.Rows[i]["ItemAmount"]);
                }

                dr["FeeClassName"] = "合计";
                dr["SellPrice"] = totalFee;
                dt.Rows.Add(dr);
            }

            gridExamFee.DataSource = dt;
        }

        /// <summary>
        /// 绑定组合项目弹出网格费用数据源
        /// </summary>
        /// <param name="dt">弹出网格费用数据源</param>
        public void loadExamFeeShowCard(DataTable dt)
        {
            gridExamFee.SelectionCards[0].BindColumnIndex = 1;
            gridExamFee.SelectionCards[0].CardColumn = "ItemId|项目ID|50,ItemCode|编码|80,ItemName|项目名称|150,UnitPrice|单价|auto";
            gridExamFee.SelectionCards[0].CardSize = new System.Drawing.Size(350, 300);
            gridExamFee.SelectionCards[0].QueryFieldsString = "ItemName,PYm,WBm";
            gridExamFee.BindSelectionCardDataSource(0, dt);
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        public void registerEvent()
        {
            cbWorkers.SelectedIndexChanged += CbWorkers_SelectedIndexChanged;
            cbExamClass.SelectedIndexChanged += CbExamClass_SelectedIndexChanged;
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbWorkers.Enabled = true;
            }
            else
            {
                cbWorkers.Enabled = false;
            }
        }
        #endregion

        /// <summary>
        /// 输入检索条件自动检索
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void txtSearchExam_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchExam_Click(null, null);
            }
        }

        /// <summary>
        /// 界面关闭将费用网格结束编辑模式
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmExamItem_VisibleChanged(object sender, EventArgs e)
        {
            gridExamFee.EndEdit();
        }

        /// <summary>
        /// 绑定样本列表
        /// </summary>
        /// <param name="sampleDt">样本列表</param>
        public void loadSampleList(DataTable sampleDt)
        {
            cbSample.DisplayField = "Name";
            cbSample.MemberField = "Id";
            cbSample.CardColumn = "Name|样本名称|auto";
            cbSample.QueryFieldsString = "Id,Name,Pym,Wbm";
            cbSample.ShowCardDataSource = sampleDt;
            cbSample.MemberValue = 0;
        }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperType
    {
        默认, 新增
    }
}
