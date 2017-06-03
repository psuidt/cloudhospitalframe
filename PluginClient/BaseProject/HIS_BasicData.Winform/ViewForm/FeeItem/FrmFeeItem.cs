using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.Common;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_BasicData.Winform.IView.FeeItem;
using HIS_Entity.BasicData;
using HIS_Entity.BasicData.BusiEntity;

namespace HIS_BasicData.Winform.ViewForm.FeeItem
{
    /// <summary>
    /// 中心收费项目维护
    /// </summary>
    public partial class FrmFeeItem : BaseFormBusiness, IFrmFeeItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmFeeItem()
        {
            InitializeComponent();
            frmCFeeItemForm.AddItem(tbCenterItemName, "CenterItemName", true, "项目名称必须输入", InvalidType.Empty, null, EN_CH.CH, null);//项目名称
            frmCFeeItemForm.AddItem(tbCenterItemCode, "CenterItemCode", true, "项目代码必须输入", InvalidType.Empty, null, EN_CH.EN, null);//项目代码
            frmCFeeItemForm.AddItem(cboStatID, "StatID", false, null, InvalidType.Custom, null, EN_CH.EN, null);//项目分类
            frmCFeeItemForm.AddItem(diPrice, "Price", false, null, InvalidType.Custom, null, EN_CH.EN, null);//项目单价
            frmCFeeItemForm.AddItem(tbUnit, "Unit", false, null, InvalidType.Custom, null, EN_CH.CH, null);//项目单位
            frmCFeeItemForm.AddItem(tbExplain, "Explain", false, null, InvalidType.Custom, null, EN_CH.CH, null);//项目说明
            frmCFeeItemForm.Load(new Basic_CenterFeeItem { });
        }

        /// <summary>
        /// 当前选中中心收费项目
        /// </summary>
        private Basic_CenterFeeItem currentCFeeItem;

        /// <summary>
        /// 当前选中中心收费项目
        /// </summary>
        public Basic_CenterFeeItem CurrentCFeeItem
        {
            get
            {
                return currentCFeeItem;
            }

            set
            {
                currentCFeeItem = value;
                frmCFeeItemForm.Load(currentCFeeItem);
                //0为启用,1为停用
                if (currentCFeeItem.IsStop == (int)IsStopType.Disabled)
                {
                    toolbarFlag.Text = "启用(F3)";
                }
                else
                {
                    toolbarFlag.Text = "停用(F3)";
                }

                //0为未审核,1为已审核
                if (currentCFeeItem.AuditStatus == (int)AuditType.UnAudit)
                {
                    toolbarAudit.Text = "审核(F3)";
                }
                else
                {
                    toolbarAudit.Text = "反审核(F3)";
                }
            }
        }

        /// <summary>
        /// 统计大类ID
        /// </summary>
        private int GetFirstStatID
        {
            get
            {
                var dtStatID = cboStatID.ShowCardDataSource as DataTable;
                if (null != dtStatID && dtStatID.Rows.Count > 0)
                {
                    return int.Parse(dtStatID.Rows[0]["StatID"] + string.Empty);
                }

                return 0;
            }
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmFeeItem_OpenWindowBefore(object sender, EventArgs e)
        {
            bindGridSelectIndex(dgCenterFeeItem);
            InvokeController("LoadBasicData", this);
            InitComboboxExData();
            InvokeController("LoadBasicWorkers", this);
        }

        #region IFrmFeeItem

        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cboQueryWorker.DataSource = workers;
            InvokeController(
                "LoadCenterFeeItem", 
                cboQueryAudit.SelectedValue, 
                cboQueryStop.SelectedValue, 
                cboQueryWorker.SelectedValue, 
                tbKey.Text, 
                Tools.ToInt32(cboSearchStatID.MemberValue),
                pagerCenterFeeItem.pageNo, 
                pagerCenterFeeItem.pageSize, 
                this);
        }

        /// <summary>
        /// 加载中心收费项目列表
        /// </summary>
        /// <param name="cfeeitems">中心收费项目列表</param>
        /// <param name="totalCount">数据行数</param>
        public void LoadFeeItem<Basic_CenterFeeItem>(List<Basic_CenterFeeItem> cfeeitems, int totalCount)
        {
            //dgCenterFeeItem.DataSource = cfeeitems;
            //pagerCenterFeeItem.totalRecord = totalCount;
            pagerCenterFeeItem.SetPagerDataSource(totalCount, ConvertExtend.ToDataTable(cfeeitems));
            pagerCenterFeeItem.Refresh();

            if (cfeeitems.Count > 0)
            {
                dgCenterFeeItem_CurrentCellChanged(null, null);
                dgCenterFeeItem.Enabled = true;
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarAudit.Enabled = true;
                barCFeeItem.Refresh();
            }
        }

        /// <summary>
        /// 加载基础数据
        /// </summary>
        /// <param name="dtDataSource">基础数据源</param>
        public void LoadBasicData(params DataTable[] dtDataSource)
        {
            var dtStatID = dtDataSource[0];
            cboStatID.DisplayField = "StatName";
            cboStatID.MemberField = "StatID";
            cboStatID.CardColumn = "StatName|名称|auto,PyCode|拼音码|auto,WbCode|五笔码|auto";
            cboStatID.QueryFieldsString = "StatName,PyCode,WbCode";
            cboStatID.ShowCardWidth = 350;
            cboStatID.ShowCardDataSource = dtStatID;
            DataTable dtSearchStatID = dtStatID.Copy();
            cboSearchStatID.DisplayField = "StatName";
            cboSearchStatID.MemberField = "StatID";
            cboSearchStatID.CardColumn = "StatName|名称|auto,PyCode|拼音码|auto,WbCode|五笔码|auto";
            cboSearchStatID.QueryFieldsString = "StatName,PyCode,WbCode";
            cboSearchStatID.ShowCardWidth = 350;
            cboSearchStatID.ShowCardDataSource = dtSearchStatID;
        }

        /// <summary>
        /// 加载中心收费项目列表
        /// </summary>
        /// <param name="cfeeitem">中心收费项目列表</param>
        public void LoadCenterFeeItem(Basic_CenterFeeItem cfeeitem)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// 初始化下拉框数据
        /// </summary>
        private void InitComboboxExData()
        {
            var datasource = new[]
            {
                new { Text = "全部", Value = (int)AuditType.Default },
                new { Text = "未审核", Value = (int)AuditType.UnAudit },
                new { Text = "已审核", Value = (int)AuditType.Audited }
            };

            cboQueryAudit.DataSource = datasource;
            datasource = new[]
            {
                new { Text = "全部", Value = (int)IsStopType.Default },
                new { Text = "已启用", Value = (int)IsStopType.Enabled },
                new { Text = "已停用", Value = (int)IsStopType.Disabled }
            };

            cboQueryStop.DataSource = datasource;
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页数</param>
        private void pagerCenterFeeItem_PageNoChanged(object sender, int pageNo, int pageSize)
        {
            if (null == cboQueryWorker.SelectedValue || null == cboQueryAudit.SelectedValue || null == cboQueryStop.SelectedValue)
            {
                return;
            }

            InvokeController(
                "LoadCenterFeeItem", 
                cboQueryAudit.SelectedValue, 
                cboQueryStop.SelectedValue, 
                cboQueryWorker.SelectedValue, 
                tbKey.Text, 
                Tools.ToInt32(cboSearchStatID.MemberValue),
                pageNo,
                pageSize,
                this);
        }

        /// <summary>
        /// 选中中心收费项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgCenterFeeItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if (null == dgCenterFeeItem.CurrentRow)
            {
                return;
            }

            var rowIndex = dgCenterFeeItem.CurrentRow.Index;
            var dataSource = ConvertExtend.ToList<Basic_CenterFeeItem>(dgCenterFeeItem.DataSource as DataTable);
            CurrentCFeeItem = dataSource[rowIndex];
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            dgCenterFeeItem.Enabled = false;
            CurrentCFeeItem = new Basic_CenterFeeItem
            {
                StatID = GetFirstStatID
            };

            toolbarAdd.Enabled = false;
            toolbarFlag.Enabled = false;
            toolbarAudit.Enabled = false;
            barCFeeItem.Refresh();
            tbCenterItemName.Focus();
        }

        /// <summary>
        /// 停用或启用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarFlag_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(string.Format("确定{0}吗？", CurrentCFeeItem.IsStop == (int)IsStopType.Enabled ? "停用" : "启用"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            InvokeController("FlagCFeeItem", CurrentCFeeItem.FeeID, CurrentCFeeItem.IsStop);
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRefresh_Click(object sender, EventArgs e)
        {
            dgCenterFeeItem.Enabled = true;
            InvokeController("LoadCenterFeeItem", cboQueryAudit.SelectedValue, cboQueryStop.SelectedValue, cboQueryWorker.SelectedValue, tbKey.Text, Tools.ToInt32(cboSearchStatID.MemberValue), pagerCenterFeeItem.pageNo, pagerCenterFeeItem.pageSize, this);
            setGridSelectIndex(dgCenterFeeItem);

            if (dgCenterFeeItem.Rows.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarAudit.Enabled = true;
                barCFeeItem.Refresh();
            }
        }

        /// <summary>
        /// 设置网格选中行颜色
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgCenterFeeItem_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //var dataSource = ConvertExtend.ToList<Basic_CenterFeeItem>(dgCenterFeeItem.DataSource as DataTable);
            //if (e.RowIndex >= 0)
            //{
            //    if (dataSource[e.RowIndex].IsStop == (int)IsStopType.Disabled)
            //    {
            //        dgCenterFeeItem.SetRowColor(e.RowIndex, Color.Red, true);
            //    }
            //}
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAudit_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(string.Format("确定{0}本条记录吗？", CurrentCFeeItem.AuditStatus == (int)AuditType.Audited ? "反审核" : "审核"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            InvokeController("AuditCFeeItem", CurrentCFeeItem.FeeID, CurrentCFeeItem.AuditStatus);
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            pagerCenterFeeItem.pageNo = 1;
            //pagerCenterFeeItem.Refresh();
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
            toolbarAdd.Enabled = true;
            toolbarFlag.Enabled = true;
            toolbarAudit.Enabled = true;
            barCFeeItem.Refresh();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("将不会保存新修改数据", "确定要取消本次操作吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            frmCFeeItemForm.Load(CurrentCFeeItem);
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("将不会保存新修改数据", "确定要取消本次操作吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            dgCenterFeeItem.Enabled = true;
            toolbarRefresh_Click(null, null);
            toolbarAdd.Enabled = true;
            if (dgCenterFeeItem.Rows.Count > 0)
            {
                toolbarFlag.Enabled = true;
                toolbarAudit.Enabled = true;
            }

            barCFeeItem.Refresh();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmCFeeItemForm.Validate())
            {
                frmCFeeItemForm.GetValue(CurrentCFeeItem);
                var ret = InvokeController("SaveCFeeItem", CurrentCFeeItem);
                if (!string.IsNullOrEmpty(ret + string.Empty))
                {
                    dgCenterFeeItem.Enabled = true;
                    MessageBoxEx.Show("保存成功");

                    var flag = CurrentCFeeItem.FeeID <= 0;
                    toolbarRefresh_Click(null, null);
                    if (flag)
                    {
                        setGridSelectIndex(dgCenterFeeItem, 0);
                    }
                }
                else
                {
                    MessageBoxEx.Show("保存失败,请重试");
                }
            }
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmFeeItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    toolbarAdd_Click(null, null);
                    break;
                case Keys.F3:
                    toolbarFlag_Click(null, null);
                    break;
                case Keys.F4:
                    toolbarAudit_Click(null, null);
                    break;
                case Keys.F5:
                    toolbarRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    btnReset_Click(null, null);
                    break;
                case Keys.F7:
                    btnQuit_Click(null, null);
                    break;
                case Keys.F8:
                    btnSave_Click(null, null);
                    break;
                case Keys.F9:
                    btnQuery_Click(null, null);
                    break;
                case Keys.F10:
                    btnCancel_Click(null, null);
                    break;
            }
        }
    }
}
