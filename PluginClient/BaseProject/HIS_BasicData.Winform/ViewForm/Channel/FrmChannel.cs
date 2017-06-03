using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.ViewForm.Channel
{
    /// <summary>
    /// 用法维护界面
    /// </summary>
    public partial class FrmChannel : BaseFormBusiness, IFrmChannel
    {
        /// <summary>
        /// 新增标志
        /// </summary>
        private bool isNew;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmChannel()
        {
            InitializeComponent();
            bindGridSelectIndex(dgChannel);
            frmCommon.AddItem(txtChannelName, "ChannelName", "标准名称必须输入", InvalidType.Empty, null);
            frmCommon.AddItem(txtCName, "CName");
            frmCommon.AddItem(txtEName, "EName");
            frmCommon.AddItem(txtPycode, "PYCode");
            frmCommon.AddItem(txtWbcode, "WBCode");
            frmCommon.AddItem(txtSortOrder, "SortOrder");
            frmCommon.AddItem(cbOutUsed, "OutUsed");
            frmCommon.AddItem(cbInUsed, "InUsed");
            frmCommon.AddItem(cbWestDrug, "WestDrug");
            frmCommon.AddItem(cbMidDrug, "MidDrug");
        }

        /// <summary>
        /// 用法对象
        /// </summary>
        public Basic_Channel CurrentData { get; set; }

        /// <summary>
        /// 用法关联费用列表
        /// </summary>
        public List<Basic_ChannelFee> ChannelFeeList { get; set; }

        /// <summary>
        /// 费用列表
        /// </summary>
        private DataTable dtFeeData;

        /// <summary>
        /// 用法关联的费用
        /// </summary>
        private DataTable currentFeeData;

        #region 接口

        /// <summary>
        /// 绑定机构下拉框,并继续绑定科室分类树
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cboWorker.DataSource = workers;
            cboWorker.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
            InvokeController("LoadFeeInfoCard");
            InvokeController("LoadChannel", cboWorker.SelectedValue, txtName.Text);
        }

        /// <summary>
        /// 绑定用法信息网格
        /// </summary>
        /// <param name="channels">用法列表</param>
        public void LoadChannel(DataTable channels)
        {
            if (channels != null)
            {
                if (channels.Rows.Count > 0)
                {
                    dgChannel.CurrentCellChanged -= dgChannel_CurrentCellChanged;
                    dgChannel.DataSource = channels;
                    for (int i = 0; i < channels.Rows.Count; i++)
                    {
                        string channelid = channels.Rows[i]["ID"] + string.Empty;
                        InvokeController("LoadChannelFee", Convert.ToInt32(channelid), 1);
                        for (int j = 0; j < currentFeeData.Rows.Count; j++)
                        {
                            DataRow drfee = dtFeeData.Select("ItemID=" + currentFeeData.Rows[j]["ItemID"] + string.Empty).FirstOrDefault();
                            if (drfee == null)
                            {
                                dgChannel.SetRowColor(i, Color.Blue, true);
                                break;
                            }
                        }

                        if (channels.Rows[i]["DelFlag"] + string.Empty == "1")
                        {
                            dgChannel.SetRowColor(i, Color.Red, true);
                        }
                    }

                    dgChannel.CurrentCellChanged += dgChannel_CurrentCellChanged;
                    dgChannel.CurrentCell = dgChannel[1, 0];
                }
                else
                {
                    dgChannel.DataSource = channels;
                    InvokeController("LoadChannelFee", 0, 0);
                }
            }
        }

        /// <summary>
        /// 绑定用法费用联动信息
        /// </summary>
        /// <param name="channelFees">用法联动费用列表</param>
        public void LoadChannelFee(DataTable channelFees)
        {
            dgFree.CellValueChanged -= dgFree_CellValueChanged;
            if (channelFees != null)
            {
                dgFree.EndEdit();
                if (channelFees.Rows.Count > 0)
                {
                    dgFree.DataSource = channelFees;
                    dgFree.CurrentCell = dgFree[1, 0];
                }
                else
                {
                    dgFree.DataSource = channelFees;
                }
            }

            dgFree.CellValueChanged += dgFree_CellValueChanged;
        }

        /// <summary>
        /// 绑定用法费用联动信息
        /// </summary>
        /// <param name="channelFees">用法联动费用列表</param>
        public void LoadChannelFeeDt(DataTable channelFees)
        {
            currentFeeData = channelFees;
        }

        /// <summary>
        /// 保存完成后执行的方法
        /// </summary>
        /// <param name="result">大于0保存成功</param>
        public void SaveComplete(int result)
        {
            if (result > 0)
            {
                MessageBoxShowSimple("保存成功");
                InvokeController("LoadChannel", cboWorker.SelectedValue, txtName.Text);
            }
            else
            {
                MessageBoxEx.Show("已存在相同记录");
            }
        }

        /// <summary>
        /// 绑定费用联动录入ShowCard
        /// </summary>
        /// <param name="dtFeeInfo">费用联动信息</param>
        public void BindFeeInfoCard(DataTable dtFeeInfo)
        {
            dtFeeData = dtFeeInfo;
            dgFree.SelectionCards[0].BindColumnIndex = 0;
            dgFree.SelectionCards[0].CardColumn = "ItemID|编码|55,ItemName|项目名称|auto,ItemClassName|项目类型|120,MiniUnitName|单位|40";
            dgFree.SelectionCards[0].CardSize = new System.Drawing.Size(400, 276);
            dgFree.SelectionCards[0].QueryFieldsString = "ItemName,Pym,Wbm";
            dgFree.SelectionCards[0].SelectCardFilterType = EfwControls.CustomControl.MatchModes.ByFirstChar;
            dgFree.BindSelectionCardDataSource(0, dtFeeInfo);
        }

        /// <summary>
        /// 绑定计费模式ShowCard
        /// </summary>
        public void BindModeInfoCard()
        {
            DataTable dtMode = InitMode();
            dgFree.SelectionCards[1].BindColumnIndex = 6;
            dgFree.SelectionCards[1].CardColumn = "CalCostMode|计费模式|100";
            dgFree.SelectionCards[1].CardSize = new System.Drawing.Size(150, 100);
            dgFree.BindSelectionCardDataSource(1, dtMode);
        }

        #endregion

        /// <summary>
        /// 初始化用法联动费用计费模式
        /// </summary>
        /// <returns>计费模式列表</returns>
        public DataTable InitMode()
        {
            DataTable dtMode = new DataTable();
            dtMode.Columns.Add("CalCostMode");
            DataRow dr = dtMode.NewRow();
            dr["CalCostMode"] = "按频次";
            dtMode.Rows.Add(dr);
            dr = dtMode.NewRow();
            dr["CalCostMode"] = "按周期";
            dtMode.Rows.Add(dr);
            return dtMode;
        }

        /// <summary>
        /// 检查网格
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="checkRows">检查行(为空表全部)</param>
        /// <param name="uniqueCol">唯一列名(为空则没有主键)</param>
        /// <param name="errMsg">错误信息</param>
        /// <param name="errCol">错误列名</param>
        /// <param name="errRow">错误行索引</param>
        /// <returns>false：验证不通过</returns>
        public bool CheckDetails(
            DataTable dtSource,
            List<int> checkRows,
            string[] uniqueCol,
            out string errMsg,
            out string errCol,
            out int errRow)
        {
            errMsg = string.Empty;
            errCol = string.Empty;
            errRow = -1;
            for (int index = 0; index < dtSource.Rows.Count; index++)
            {
                if (checkRows != null &&
                    checkRows.FindIndex((x) => { return x == index; }) < 0)
                {
                    continue;
                }

                DataRow dRow = dtSource.Rows[index];
                //重复性检查
                if (uniqueCol != null)
                {
                    string colName = string.Empty;
                    for (int temp = index + 1; temp < dtSource.Rows.Count; temp++)
                    {
                        bool isUnique = false;
                        foreach (string name in uniqueCol)
                        {
                            errCol = name;
                            colName += (name + ",");
                            if (dRow[name].ToString() != dtSource.Rows[temp][name].ToString())
                            {
                                isUnique = true;
                                break;
                            }
                        }

                        if (!isUnique)
                        {
                            errRow = temp;
                            errMsg = "【{0}】不允许重复，请重新录入";
                            return false;
                        }
                    }
                }

                //按每列对正则表达式判断
                for (int count = 0; count < dtSource.Columns.Count; count++)
                {
                    object key = "Regex";
                    if (dtSource.Columns[count].ExtendedProperties.Contains(key))
                    {
                        string express = dtSource.Columns[count].ExtendedProperties[key].ToString();
                        if (express != string.Empty)
                        {
                            if (Regex.IsMatch(dRow[count].ToString(), express))
                            {
                                continue;
                            }
                            else
                            {
                                errMsg = "【{0}】的录入数据格式不正确，请重新录入";
                                errCol = dtSource.Columns[count].ColumnName;
                                errRow = index;
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 获取费用联动网格列表
        /// </summary>
        /// <param name="dtFee">费用信息</param>
        public void GetFeeList(DataTable dtFee)
        {
            ChannelFeeList = new List<Basic_ChannelFee>();
            for (int i = 0; i < dtFee.Rows.Count; i++)
            {
                Basic_ChannelFee newFee = new Basic_ChannelFee();
                if (CurrentData != null)
                {
                    if (!string.IsNullOrEmpty(dtFee.Rows[i]["ItemName"].ToString()))
                    {
                        newFee.FeeClass = dtFee.Rows[i]["ItemClassName"].ToString() == "项目" ? 1 : 2;
                        newFee.ItemAmount = Convert.ToInt32(dtFee.Rows[i]["ItemAmount"].ToString());
                        newFee.ItemID = Convert.ToInt32(dtFee.Rows[i]["ItemID"].ToString());
                        newFee.ItemName = dtFee.Rows[i]["ItemName"].ToString();
                        newFee.ItemUnit = dtFee.Rows[i]["ItemUnit"].ToString();
                        newFee.CalCostMode = dtFee.Rows[i]["ModeName"].ToString() == "按频次" ? 0 : 1;
                    }
                }

                if (!string.IsNullOrEmpty(newFee.ItemName))
                {
                    ChannelFeeList.Add(newFee);
                }
            }
        }

        /// <summary>
        /// 窗体打开前加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmChannel_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("LoadBasicWorkers");
            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cboWorker.Enabled = true;
            }
            else
            {
                cboWorker.Enabled = false;
            }

            BindModeInfoCard();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmCommon.Validate())
            {
                Basic_Channel bchannel = null;
                if (CurrentData != null)
                {
                    bchannel = CurrentData;
                }
                else
                {
                    bchannel = new Basic_Channel();
                }

                try
                {
                    frmCommon.GetValue<Basic_Channel>(bchannel);
                    CurrentData = bchannel;
                    DataTable dtSource = (DataTable)dgFree.DataSource;
                    string errMsg = string.Empty;
                    string errCol = string.Empty;
                    int errRow = -1;
                    if (!CheckDetails(dtSource, null, new string[1] { "ItemID" }, out errMsg, out errCol, out errRow))
                    {
                        MessageBoxEx.Show(string.Format(errMsg, dgFree.Columns[errCol].HeaderText));
                        dgFree.CurrentCell = dgFree[errCol, errRow];
                        return;
                    }

                    GetFeeList(dtSource);
                    InvokeController("SaveChannel", cboWorker.SelectedValue);
                    if (isNew)
                    {
                        setGridSelectIndex(dgChannel, dgChannel.RowCount - 1);
                    }
                    else
                    {
                        setGridSelectIndex(dgChannel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("保存失败" + ex.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// 选择用法加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgChannel_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgChannel.CurrentCell == null)
            {
                return;
            }

            CurrentData = null;
            int rowindex = dgChannel.CurrentCell.RowIndex;
            if (rowindex > 0)
            {
                isNew = false;
            }

            DataTable dt = (DataTable)dgChannel.DataSource;
            Basic_Channel bchannel = new Basic_Channel();
            bchannel = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_Channel>(dt, rowindex);
            CurrentData = bchannel;
            frmCommon.Load<Basic_Channel>(bchannel);
            if (bchannel != null)
            {
                InvokeController("LoadChannelFee", bchannel.ID, 0);
            }

            //0为启用,1为停用
            if (CurrentData.DelFlag == 1)
            {
                btnStop.Text = "启用(F4)";
            }
            else
            {
                btnStop.Text = "停用(F4)";
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            InvokeController("LoadChannel", cboWorker.SelectedValue, txtName.Text);
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
        /// 新增用法
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            CurrentData = null;
            this.frmCommon.Clear();
            this.txtChannelName.Focus();
            InvokeController("LoadChannelFee", 0, 0);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvokeController("LoadFeeInfoCard");
            InvokeController("LoadChannel", cboWorker.SelectedValue, txtName.Text);
        }

        /// <summary>
        /// 停用用法
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            string info = "启用";
            int status = 0;
            if (CurrentData != null)
            {
                if (CurrentData.DelFlag == 0)
                {
                    info = "停用";
                    status = 1;
                }
            }

            if (MessageBoxEx.Show("确定" + info + "吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (null == dgChannel.CurrentRow)
                {
                    return;
                }

                var rowIndex = dgChannel.CurrentRow.Index;
                var dataSource = dgChannel.DataSource as DataTable;
                string channelid = dataSource.Rows[rowIndex]["ID"].ToString();
                InvokeController("StopChannel", channelid, status);
                MessageBoxEx.Show(string.Empty + info + "成功");
                InvokeController("LoadChannel", cboWorker.SelectedValue, txtName.Text);
                setGridSelectIndex(dgChannel);
            }
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmChannel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAdd_Click(null, null);
                    break;
                case Keys.F3:
                    btnSave_Click(null, null);
                    break;
                case Keys.F4:
                    btnStop_Click(null, null);
                    break;
                case Keys.F5:
                    btnRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    btnFeeAdd_Click(null, null);
                    break;
                case Keys.F7:
                    btnDel_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// 新增用法费用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnFeeAdd_Click(object sender, EventArgs e)
        {
            dgFree.AddRow();
        }

        /// <summary>
        /// 删除用法费用数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        //private void btnFeeFresh_Click(object sender, EventArgs e)
        //{
        //    //if (CurrentData != null)
        //    //{
        //    //    InvokeController("LoadChannelFee", CurrentData.ID);
        //    //}

        //    if (dgFree.CurrentCell != null)
        //    {
        //        int rowid = this.dgFree.CurrentCell.RowIndex;
        //        DataTable dt = (DataTable)dgFree.DataSource;
        //        dt.Rows.RemoveAt(rowid);
        //    }
        //}

        /// <summary>
        /// 删除用法费用数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgFree.CurrentCell != null)
            {
                int rowid = this.dgFree.CurrentCell.RowIndex;
                DataTable dt = (DataTable)dgFree.DataSource;
                dt.Rows.RemoveAt(rowid);
            }
        }

        /// <summary>
        /// 输入用法名自动生成拼音码和五笔码
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void txtChannelName_TextChanged(object sender, EventArgs e)
        {
            txtPycode.Text = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(txtChannelName.Text);
            txtWbcode.Text = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(txtChannelName.Text);
        }

        /// <summary>
        /// 用法费用弹出网格数据选择
        /// </summary>
        /// <param name="selectedValue">选中的数据</param>
        /// <param name="stop">Stop标志</param>
        /// <param name="customNextColumnIndex">下一个获得光标的列</param>
        private void dgFree_SelectCardRowSelected(object selectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            DataRow selectRow = (DataRow)selectedValue;
            int colId = dgFree.CurrentCell.ColumnIndex;
            int rowId = dgFree.CurrentCell.RowIndex;
            DataTable dtSource = (DataTable)dgFree.DataSource;
            if (customNextColumnIndex == 0)
            {
                dtSource.Rows[rowId]["ItemID"] = selectRow["ItemID"];
                dtSource.Rows[rowId]["ItemName"] = selectRow["ItemName"];
                dtSource.Rows[rowId]["ItemClassName"] = selectRow["ItemClassName"];
                dtSource.Rows[rowId]["UnitPrice"] = selectRow["UnitPrice"];
                dtSource.Rows[rowId]["ItemUnit"] = selectRow["MiniUnitName"];
                dtSource.Rows[rowId]["ItemAmount"] = "1";
                dtSource.Rows[rowId]["ModeName"] = "按频次";
            }

            if (customNextColumnIndex == 6)
            {
                dtSource.Rows[rowId]["ModeName"] = selectRow["CalCostMode"];
            }
            dgFree.Refresh();
        }

        /// <summary>
        /// 修改用法费用数量
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgFree_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            //数量列
            if (e.ColumnIndex == 5)
            {
                DataRow currentRow = ((DataTable)dgFree.DataSource).Rows[e.RowIndex];
                if (currentRow["ItemAmount"].ToString() == string.Empty || currentRow["ItemAmount"].ToString() == "0")
                {
                    currentRow["ItemAmount"] = "1";
                }
            }
        }

        /// <summary>
        /// 输入检索条件自动查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQuery_Click(null, null);
            }
        }
    }
}
