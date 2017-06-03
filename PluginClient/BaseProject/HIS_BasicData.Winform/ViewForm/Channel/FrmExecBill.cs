using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_BasicData.Winform.IView.Channel;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.ViewForm.Channel
{
    /// <summary>
    /// 执行单配置
    /// </summary>
    public partial class FrmExecBill : BaseFormBusiness, IFrmExecBill
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmExecBill()
        {
            InitializeComponent();
            bindGridSelectIndex(dgExecBill);
        }

        /// <summary>
        /// 执行单关联用法列表
        /// </summary>
        private List<Basic_ExecuteBillChannel> deleteList;

        /// <summary>
        /// 执行单关联用法列表
        /// </summary>
        public List<Basic_ExecuteBillChannel> DeleteList
        {
            get
            {
                return deleteList;
            }

            set
            {
                deleteList = value;
            }
        }

        /// <summary>
        /// 执行单网格当前选中行
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// 执行单网格当前选中行
        /// </summary>
        public int RowIndex
        {
            get
            {
                return rowIndex;
            }

            set
            {
                rowIndex = value;
            }
        }

        /// <summary>
        /// 执行单ID
        /// </summary>
        private int id;

        /// <summary>
        /// 执行单ID
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private string deleteStr;

        ///// <summary>
        ///// 
        ///// </summary>
        //public string DeleteStr
        //{
        //    get
        //    {
        //        return deleteStr;
        //    }
        //    set
        //    {
        //        deleteStr = value;
        //    }
        //}

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cbbWork.DataSource = workers;
        }

        /// <summary>
        /// 绑定执行单数据
        /// </summary>
        /// <param name="dt">执行单列表</param>
        public void BingExecBillInfo(DataTable dt)
        {
            dgExecBill.DataSource = dt;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["DelFlag"] + string.Empty == "1")
                        {
                            dgExecBill.SetRowColor(i, Color.Red, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选中执行单加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgExecBill_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgExecBill.CurrentCell == null)
            {
                return;
            }

            RowIndex = dgExecBill.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgExecBill.DataSource;
            ID = Convert.ToInt32(dt.Rows[RowIndex]["ID"]);
            txtName.Text = Convert.ToString(dt.Rows[RowIndex]["BillName"]);
            intCode.Value = Convert.ToInt32(dt.Rows[RowIndex]["ReportFile"]);
            //获取执行单关联用法
            InvokeController("GetExecuteBillChannel", Convert.ToInt32(cbbWork.SelectedValue), ID);
            //0为启用,1为停用
            if (Convert.ToInt32(dt.Rows[RowIndex]["DelFlag"]) == 1)
            { 
                btnStop.Text = "启用(&U)";
            }
            else
            { 
                btnStop.Text = "停用(&U)";
            }

            panInfo.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnStop.Enabled = true;
            btnQuery.Enabled = true;
            panInfo.Enabled = false;
            dgChannel.ReadOnly = true;
        }

        /// <summary>
        /// 绑定执行单数据
        /// </summary>
        /// <param name="dt">执行单列表</param>
        public void BindChannelInfo(DataTable dt)
        {
            dgChannel.DataSource = dt;
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmExecBill_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("LoadBasicWorkers");
            //DeleteStr = string.Empty;

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbbWork.Enabled = true;
            }
            else
            {
                cbbWork.Enabled = false;
            }

            cbbWork.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
            DeleteList = new List<Basic_ExecuteBillChannel>();
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cbbWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtChannel = (DataTable)InvokeController("BindChannelInfo", Convert.ToInt32(cbbWork.SelectedValue));
            bind_SimpleFeeItemData(dtChannel);
            InvokeController("BindExecBillInfo", Convert.ToInt32(cbbWork.SelectedValue), txtQueryName.Text);
        }

        /// <summary>
        /// 绑定弹出网格数据源
        /// </summary>
        /// <param name="dtChannel">弹出网格数据源</param>
        public void bind_SimpleFeeItemData(DataTable dtChannel)
        {
            // 长期医嘱
            dgChannel.SelectionCards[0].BindColumnIndex = 0;
            dgChannel.SelectionCards[0].CardColumn = "ID|编码|60,ChannelName|项目名称|120,pycode|拼音码|80,wbcode|五笔码|auto";
            dgChannel.SelectionCards[0].CardSize = new System.Drawing.Size(380, 260);
            dgChannel.SelectionCards[0].QueryFieldsString = "ChannelName,pycode,wbcode";
            dgChannel.BindSelectionCardDataSource(0, dtChannel);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            InvokeController("BindExecBillInfo", Convert.ToInt32(cbbWork.SelectedValue), txtQueryName.Text);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            InvokeController("GetExecuteBillChannel", Convert.ToInt32(cbbWork.SelectedValue), 0);
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnStop.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnQuery.Enabled = false;
            panInfo.Enabled = true;
            txtName.Text = string.Empty;
            intCode.Value = 1;
            ID = 0;

            // 设置费用网格为可编辑状态
            dgChannel.ReadOnly = false;
            dgChannel.Columns[0].ReadOnly = false;
            dgChannel.Columns[1].ReadOnly = true;
            dgChannel.Columns[2].ReadOnly = true;
            dgChannel.AddRow();
            txtName.Focus();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnStop.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnQuery.Enabled = false;
            panInfo.Enabled = true;

            dgChannel.ReadOnly = false;
            dgChannel.Columns[0].ReadOnly = false;
            dgChannel.Columns[1].ReadOnly = true;
            dgChannel.Columns[2].ReadOnly = true;
            dgChannel.AddRow();
            txtName.Focus();
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnStop.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnQuery.Enabled = true;
            panInfo.Enabled = false;
        }

        /// <summary>
        /// 选中用法
        /// </summary>
        /// <param name="selectedValue">选中的数据</param>
        /// <param name="stop">Stop标志</param>
        /// <param name="customNextColumnIndex">下一个得到焦点的列</param>
        private void dgChannel_SelectCardRowSelected(object selectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            DataRow row = (DataRow)selectedValue;
            int rowid = this.dgChannel.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgChannel.DataSource;
            DataRow[] drCheck = dt.Select("ChannelID=" + Convert.ToInt32(row["ID"]));
            if (drCheck.Length > 0)
            {
                return;
            }

            dt.Rows[rowid]["ChannelID"] = row["ID"];
            dt.Rows[rowid]["ChannelName"] = row["ChannelName"];
            dgChannel.Refresh();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)==true)
            {
                MessageBoxEx.Show("执行单名称不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToBoolean(InvokeController("CheckName", Convert.ToInt32(cbbWork.SelectedValue), ID, txtName.Text)) == false)
            {
                MessageBoxEx.Show("执行单名称不能重复！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(intCode.Text))
            {
                MessageBoxEx.Show("报表文件编码不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (intCode.Value <=0)
            {
                MessageBoxEx.Show("请输入正确的报表文件编码！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flag = ID;
            Basic_ExecuteBills billEntity = new Basic_ExecuteBills();
            billEntity.ID = ID;
            billEntity.BillName = txtName.Text;
            billEntity.ReportFile = intCode.Text;
            billEntity.PYCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(txtName.Text);
            billEntity.WBCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(txtName.Text);
            if (flag==0)
            {
                billEntity.DelFlag = 0;
            }

            List<Basic_ExecuteBillChannel> channelList= new List<Basic_ExecuteBillChannel>();
            DataTable dtChannel = dgChannel.DataSource as DataTable;

            for (int i = 0; i< dtChannel.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(Convert.ToString(dtChannel.Rows[i]["ChannelName"])) == false)
                { 
                    Basic_ExecuteBillChannel channelEntity = new Basic_ExecuteBillChannel();
                    if  (string.IsNullOrEmpty(Convert.ToString(dtChannel.Rows[i]["ID"]))==false)
                    {
                        channelEntity.ID = Convert.ToInt32(dtChannel.Rows[i]["ID"]);
                    }

                    channelEntity.ExecBillID = ID;
                    channelEntity.ChannelID = Convert.ToInt32(dtChannel.Rows[i]["ChannelID"]);
                    channelList.Add(channelEntity);
                }
            }

            if (Convert.ToInt32(InvokeController("SaveBillChannelInfo", Convert.ToInt32(cbbWork.SelectedValue), billEntity, channelList,DeleteList))>0)
            {
                InvokeController("BindExecBillInfo", Convert.ToInt32(cbbWork.SelectedValue), txtQueryName.Text);
                if (flag>0)
                {
                    setGridSelectIndex(dgExecBill);
                }
                else
                {
                    setGridSelectIndex(dgExecBill, dgExecBill.Rows.Count - 1);
                }

                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnStop.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnQuery.Enabled = true;
                panInfo.Enabled = false;
                dgChannel.ReadOnly = true;
                dgChannel.EndEdit();
                //DeleteStr = string.Empty;
            }
        }

        /// <summary>
        /// 停用或启用执行单
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dgExecBill.CurrentCell == null)
            {
                return;
            }

            RowIndex = dgExecBill.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgExecBill.DataSource;
            Basic_ExecuteBills billEntity = new Basic_ExecuteBills();
            billEntity = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_ExecuteBills>(dt, RowIndex);
            if (btnStop.Text == "启用(&U)")
            {
                billEntity.DelFlag = 0;
            }
            else
            {
                billEntity.DelFlag = 1;
            }

            List<Basic_ExecuteBillChannel> channelList = new List<Basic_ExecuteBillChannel>();
            if (Convert.ToInt32(InvokeController("UpdateFlag",  billEntity.ID, billEntity.DelFlag)) > 0)
            {
                InvokeController("BindExecBillInfo", cbbWork.SelectedValue, txtQueryName.Text);
                setGridSelectIndex(dgExecBill);
            }
        }

        /// <summary>
        /// 删除用法
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgChannel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgChannel.Columns.IndexOf(dgChannel.Columns["btnDelete"])==e.ColumnIndex)
            {
                DataTable dt = dgChannel.DataSource as DataTable;
                DeleteList.Add(ConvertExtend.ToObject<Basic_ExecuteBillChannel>(dt, e.RowIndex));
                dt.Rows.RemoveAt(e.RowIndex);
                dt.AcceptChanges();
            }
        }
    }
}
