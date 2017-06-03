using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_BasicData.Winform.IView.FeeItem;
using HIS_Entity.BasicData;
using HIS_Entity.BasicData.BusiEntity;

namespace HIS_BasicData.Winform.ViewForm.FeeItem
{
    /// <summary>
    /// 本院收费项目关联中心收费项目
    /// </summary>
    public partial class FrmRelFeeItem : BaseFormBusiness, IFrmRelFeeItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmRelFeeItem()
        {
            InitializeComponent();
        }

        #region IFrmFeeItem

        /// <summary>
        /// 当前选中中心收费项目
        /// </summary>
        public Basic_CenterFeeItem Result { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int WorkerId { get; set; }

        /// <summary>
        /// 中心收费项目ID
        /// </summary>
        public int CFeeItemID { get; set; }

        /// <summary>
        /// 加载下拉框数据
        /// </summary>
        /// <param name="dtDataSource">数据源</param>
        public void LoadBasicData(params DataTable[] dtDataSource)
        {
            var dtStatID = dtDataSource[0];
            var dr = dtStatID.NewRow();
            dr["StatID"] = 0;
            dr["StatName"] = "全部";
            dtStatID.Rows.InsertAt(dr, 0);
            cboStatID.DataSource = dtStatID; //项目分类
        }

        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 加载中心收费项目
        /// </summary>
        /// <typeparam name="Basic_CenterFeeItem">中心收费项目</typeparam>
        /// <param name="cfeeitems">中心收费项目列表</param>
        /// <param name="totalCount">项目数</param>
        public void LoadFeeItem<Basic_CenterFeeItem>(List<Basic_CenterFeeItem> cfeeitems, int totalCount)
        {
            pagerCenterFeeItem.SetPagerDataSource(totalCount, ConvertExtend.ToDataTable(cfeeitems));
            pagerCenterFeeItem.Refresh();
            if (cfeeitems.Count > 0)
            {
                dgCenterFeeItem_CurrentCellChanged(null, null);
            }
            else
            {
                Result = new HIS_Entity.BasicData.Basic_CenterFeeItem { };
            }
        }

        /// <summary>
        /// 加载中心收费项目
        /// </summary>
        /// <param name="cfeeitem">中心收费项目</param>
        public void LoadCenterFeeItem(Basic_CenterFeeItem cfeeitem)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmRelFeeItem_Load(object sender, EventArgs e)
        {
            InvokeController("LoadBasicData", this);
            Result = new Basic_CenterFeeItem { };
            tbKey.Text = CFeeItemID > 0 ? CFeeItemID.ToString() : string.Empty;
            InvokeController("LoadCenterFeeItem", (int)AuditType.Audited, (int)IsStopType.Enabled, 0, tbKey.Text, cboStatID.SelectedValue, pagerCenterFeeItem.pageNo, pagerCenterFeeItem.pageSize, this);
        }

        /// <summary>
        /// 选中收费项目
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
            Result = dataSource[rowIndex];
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            CFeeItemID = -1;
            Result = null;
            this.Close();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            InvokeController(
                "LoadCenterFeeItem",
                (int)AuditType.Audited,
                (int)IsStopType.Enabled,
                0,
                tbKey.Text,
                cboStatID.SelectedValue,
                pagerCenterFeeItem.pageNo,
                pagerCenterFeeItem.pageSize,
                this);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            CFeeItemID = -1;
            this.Close();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">总页数</param>
        private void pagerCenterFeeItem_PageNoChanged(object sender, int pageNo, int pageSize)
        {
            if (pageNo <= 0)
            {
                pageNo = 1;
            }

            InvokeController("LoadCenterFeeItem", (int)AuditType.Audited, (int)IsStopType.Enabled, 0, tbKey.Text, cboStatID.SelectedValue, pageNo, pageSize, this);
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CFeeItemID = -1;
            Result = new Basic_CenterFeeItem { };
            this.Close();
        }

        /// <summary>
        /// 双击选中关联
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgCenterFeeItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave_Click(null, null);
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmRelFeeItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAdd_Click(null, null);
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
            }
        }

        /// <summary>
        /// 输入检索条件自动检查
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void tbKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnQuery_Click(null, null);
            }
        }
    }
}
