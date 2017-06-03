using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_BasicData.Winform.IView.FeeItem;
using HIS_Entity.BasicData;
using HIS_Entity.BasicData.BusiEntity;

namespace HIS_BasicData.Winform.ViewForm.FeeItem
{
    /// <summary>
    /// 本院收费项目维护
    /// </summary>
    public partial class frmHospFeeItemManage : BaseFormBusiness, IHospFeeItemManage
    {
        /// <summary>
        /// 当前选中本院收费项目
        /// </summary>
        private Basic_HospFeeItem currentHFeeItem;

        /// <summary>
        /// 当前选中本院收费项目
        /// </summary>
        public Basic_HospFeeItem CurrentHFeeItem
        {
            get
            {
                frmHostFeeItem.GetValue(currentHFeeItem);
                return currentHFeeItem;
            }

            set
            {
                currentHFeeItem = value;

                frmHostFeeItem.Load(currentHFeeItem);
                if (currentHFeeItem.CenterItemID > 0)
                {
                    InvokeController("LoadCFeeItem", currentHFeeItem.CenterItemID);
                }

                //0为启用,1为停用
                if (currentHFeeItem.IsStop == (int)IsStopType.Disabled)
                {
                    toolbarFlag.Text = "启用(F3)";
                }
                else
                {
                    toolbarFlag.Text = "停用(F3)";
                }
            }
        }

        /// <summary>
        /// 关联中心项目后，当前界面的中心项目数据不可编辑
        /// </summary>
        private bool isRel = false;

        /// <summary>
        /// 当前选中中心收费项目
        /// </summary>
        private Basic_CenterFeeItem currentCFeeItem = new Basic_CenterFeeItem();

        /// <summary>
        /// 当前选中中心收费项目
        /// </summary>
        public Basic_CenterFeeItem CurrentCFeeItem
        {
            get
            {
                frmCentreFeeItem.GetValue(currentCFeeItem);
                return currentCFeeItem;
            }

            set
            {
                currentCFeeItem = value;
                frmCentreFeeItem.Load(currentCFeeItem);
                if (currentCFeeItem.FeeID != 0)
                {
                    // 关联中心项目后，当前界面的中心项目数据不可编辑
                    SetCenterFeeEnabled(false);
                    if (isRel)
                    {
                        btnRel.Enabled = true;
                    }
                }
                else
                {
                    // 选择新建中心项目，当前界面的中心项目数据可编辑
                    SetCenterFeeEnabled(true);
                    if (isRel)
                    {
                        btnRel.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmHospFeeItemManage()
        {
            InitializeComponent();
            // 本院
            frmHostFeeItem.AddItem(tbHospItemName, "AliasName");//本院名称
            frmHostFeeItem.AddItem(cboHospStatID, "StatID");//项目分类
            frmHostFeeItem.AddItem(diHospPrice, "Price");
            frmHostFeeItem.AddItem(diOnePrice, "One_level");
            frmHostFeeItem.AddItem(diTwoPrice, "Two_level");
            frmHostFeeItem.AddItem(diThreePrice, "Three_level");
            frmHostFeeItem.AddItem(cboMreType, "MedicateID");//医保类型
            frmHostFeeItem.AddItem(cboIsBle, "IsBle");

            // 中心
            frmCentreFeeItem.AddItem(tbCenterItemName, "CenterItemName");//项目名称
            frmCentreFeeItem.AddItem(tbCenterItemCode, "CenterItemCode");//项目代码
            frmCentreFeeItem.AddItem(cboStatID, "StatID");//项目分类
            frmCentreFeeItem.AddItem(tbUnit, "Unit");//项目单位
            frmCentreFeeItem.AddItem(diPrice, "Price");//项目单价
            frmCentreFeeItem.AddItem(tbExplain, "Explain");//项目说明
        }

        /// <summary>
        /// 查询本院收费项目列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            InvokeController(
                "LoadHospFeeItem",
                Tools.ToInt32(cboQueryStatID.MemberValue),
                cboQueryStop.SelectedValue,
                tbKey.Text,
                1,
                pagerHospFeeItem.pageSize);
        }

        /// <summary>
        /// 窗体打开前加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void frmHospFeeItemManage_OpenWindowBefore(object sender, EventArgs e)
        {
            // 设置Grid选中行
            bindGridSelectIndex(dgHospFeeItem);
            // 初始化下拉框数据
            InitComboboxExData();
            // 加载网格数据
            InvokeController(
                "LoadHospFeeItem",
                Tools.ToInt32(cboQueryStatID.MemberValue),
                cboQueryStop.SelectedValue,
                tbKey.Text,
                pagerHospFeeItem.pageNo,
                pagerHospFeeItem.pageSize);
        }

        /// <summary>
        /// 做成项目状态、医保类型数据
        /// </summary>
        private void InitComboboxExData()
        {
            // 项目状态
            var datasource = new[]
            {
                new { Text = "全部", Value = (int)IsStopType.Default },
                new { Text = "已启用", Value = (int)IsStopType.Enabled },
                new { Text = "已停用", Value = (int)IsStopType.Disabled }
            };

            cboQueryStop.DataSource = datasource;
            // 医保类型
            datasource = new[]
            {
                new { Text = "否", Value = (int)MreTypes.Default },
                new { Text = "甲类", Value = (int)MreTypes.A },
                new { Text = "乙类", Value = (int)MreTypes.B },
                new { Text = "丙类", Value = (int)MreTypes.C }
            };

            cboMreType.DataSource = datasource;
        }

        /// <summary>
        /// 绑定项目分类列表
        /// </summary>
        /// <param name="statDt">项目分类列表</param>
        public void Bind_BasicData(DataTable statDt)
        {
            cboStatID.DisplayField = "StatName";
            cboStatID.MemberField = "StatID";
            cboStatID.CardColumn = "StatName|名称|auto,PyCode|拼音码|auto,WbCode|五笔码|auto";
            cboStatID.QueryFieldsString = "StatName,PyCode,WbCode";
            cboStatID.ShowCardWidth = 350;
            cboStatID.ShowCardDataSource = statDt;
            cboHospStatID.DisplayField = "StatName";
            cboHospStatID.MemberField = "StatID";
            cboHospStatID.CardColumn = "StatName|名称|auto,PyCode|拼音码|auto,WbCode|五笔码|auto";
            cboHospStatID.QueryFieldsString = "StatName,PyCode,WbCode";
            cboHospStatID.ShowCardWidth = 350;
            cboHospStatID.ShowCardDataSource = statDt;
            var dtQueryStatID = statDt.Copy();
            var dr = dtQueryStatID.NewRow();
            dr["StatID"] = 0;
            dr["StatName"] = "全部";
            dtQueryStatID.Rows.InsertAt(dr, 0);
            cboQueryStatID.DisplayField = "StatName";
            cboQueryStatID.MemberField = "StatID";
            cboQueryStatID.CardColumn = "StatName|名称|auto,PyCode|拼音码|auto,WbCode|五笔码|auto";
            cboQueryStatID.QueryFieldsString = "StatName,PyCode,WbCode";
            cboQueryStatID.ShowCardWidth = 350;
            cboQueryStatID.ShowCardDataSource = dtQueryStatID;
        }

        /// <summary>
        /// 绑定本院收费项目数据列表
        /// </summary>
        /// <param name="hfeeitems">本院收费项目数据列表</param>
        /// <param name="totalCount">数据总行数</param>
        public void Bind_HostFeeItemList(List<Basic_HospFeeItem> hfeeitems, int totalCount)
        {
            // 绑定网格数据
            pagerHospFeeItem.SetPagerDataSource(totalCount, ConvertExtend.ToDataTable(hfeeitems));
            pagerHospFeeItem.Refresh();
            if (hfeeitems.Count > 0)
            {
                // 停用的消息显示红色
                for (int i = 0; i < hfeeitems.Count; i++)
                {
                    if (hfeeitems[i].IsStop == 1)
                    {
                        dgHospFeeItem.SetRowColor(i, Color.Red, true);
                    }
                }
            }

            // 重新绑定数据时，中心项目数据不可用
            SetCenterFeeEnabled(false);
            setGridSelectIndex(dgHospFeeItem);
        }

        /// <summary>
        /// 新增本院收费项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            tbHospItemName.Focus();
            toolbarAdd.Enabled = false;
            toolbarFlag.Enabled = false;
            CurrentHFeeItem = new Basic_HospFeeItem();
            CurrentCFeeItem = new Basic_CenterFeeItem();
            // 新增时中心项目可编辑
            SetCenterFeeEnabled(true);
            isRel = true;
        }

        /// <summary>
        /// 选中项目数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgHospFeeItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgHospFeeItem.CurrentCell != null)
            {
                int rowIndex = dgHospFeeItem.CurrentRow.Index;
                DataTable hostFeeItemDt = dgHospFeeItem.DataSource as DataTable;
                // 选中网格数据，加载本院收费项目和中心收费项目详细数据
                CurrentHFeeItem = ConvertExtend.ToObject<Basic_HospFeeItem>(hostFeeItemDt, rowIndex);
            }
        }

        /// <summary>
        /// 刷新网格数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRefresh_Click(object sender, EventArgs e)
        {
            // 重新加载网格数据
            btnQuery_Click(null, null);
            isRel = false;
        }

        /// <summary>
        /// 停用或启用本院收费项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarFlag_Click(object sender, EventArgs e)
        {
            bool result = (bool)InvokeController("FlagHFeeItem", CurrentHFeeItem.ItemID, CurrentHFeeItem.IsStop);
            // 重新加载网格数据
            if (result)
            {
                btnQuery_Click(null, null);
            }
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页数</param>
        private void pagerHospFeeItem_PageNoChanged(object sender, int pageNo, int pageSize)
        {
            if (pageNo == 0)
            {
                pageNo = 1;
            }

            if (null == cboQueryStop.SelectedValue)
            {
                return;
            }

            InvokeController("LoadHospFeeItem", Tools.ToInt32(cboQueryStatID.MemberValue), cboQueryStop.SelectedValue, tbKey.Text, pageNo, pageSize);
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 关联中心收费项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRel_Click(object sender, EventArgs e)
        {
            Basic_CenterFeeItem cfeeitem = (Basic_CenterFeeItem)InvokeController("RelCFeeItems", CurrentCFeeItem.FeeID);
            if (cfeeitem != null)
            {
                if (cfeeitem.StatID == 0)
                {
                    int statID = 0;
                    DataTable dtStatID = cboStatID.ShowCardDataSource as DataTable;
                    if (null != dtStatID && dtStatID.Rows.Count > 0)
                    {
                        statID = Tools.ToInt32(dtStatID.Rows[0]["StatID"]);
                    }

                    cfeeitem.StatID = statID;
                }

                CurrentCFeeItem = cfeeitem;
            }
        }

        /// <summary>
        /// 保存收费项目数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 中心收费项目名称
            if (tbCenterItemName.Enabled)
            {
                if (string.IsNullOrEmpty(tbCenterItemName.Text.Trim()))
                {
                    InvokeController("MessageShow", "中心收费项目名称不能为空！");
                    tbCenterItemName.Focus();
                    return;
                }
            }

            // 中心收费项目编码
            if (tbCenterItemCode.Enabled)
            {
                if (string.IsNullOrEmpty(tbCenterItemCode.Text.Trim()))
                {
                    InvokeController("MessageShow", "中心收费项目编码不能为空！");
                    tbCenterItemCode.Focus();
                    return;
                }
            }

            // 中心收费项目名称
            if (string.IsNullOrEmpty(tbHospItemName.Text.Trim()))
            {
                InvokeController("MessageShow", "本院收费项目名称不能为空！");
                tbHospItemName.Focus();
                return;
            }

            bool isAdd = CurrentHFeeItem.ItemID == 0 ? true : false;
            bool result = (bool)InvokeController("SaveHFeeItem");
            if (result)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                btnQuery_Click(null, null);
                if (isAdd)
                {
                    setGridSelectIndex(dgHospFeeItem, 0);
                }

                isRel = false;
            }
        }

        /// <summary>
        /// 取消编辑收费项目
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!toolbarAdd.Enabled && !toolbarFlag.Enabled)
            {
                // 取消编辑中心收费项目详细数据控件恢复到初始状态
                SetCenterFeeEnabled(false);
                isRel = false;
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                if (dgHospFeeItem.CurrentCell != null)
                {
                    int rowIndex = dgHospFeeItem.CurrentRow.Index;
                    DataTable hostFeeItemDt = dgHospFeeItem.DataSource as DataTable;
                    // 选中网格数据，加载本院收费项目和中心收费项目详细数据
                    CurrentHFeeItem = ConvertExtend.ToObject<Basic_HospFeeItem>(hostFeeItemDt, rowIndex);
                }
            }
        }

        /// <summary>
        /// 控制中心收费项目控件状态
        /// </summary>
        /// <param name="isEnabled">true：可用/false：不可用</param>
        private void SetCenterFeeEnabled(bool isEnabled)
        {
            tbCenterItemName.Enabled = isEnabled;
            btnRel.Enabled = isEnabled;
            tbCenterItemCode.Enabled = isEnabled;
            cboStatID.Enabled = isEnabled;
            diPrice.Enabled = isEnabled;
            tbUnit.Enabled = isEnabled;
            tbExplain.Enabled = isEnabled;
            dgHospFeeItem.Enabled = isEnabled ? false : true;
        }

        /// <summary>
        /// 按下回车键自动查询
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
