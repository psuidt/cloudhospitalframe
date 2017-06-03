using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_BasicData.Winform.IView.MessageManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.MessageManage
{
    /// <summary>
    /// 业务消息类型管理界面
    /// </summary>
    public partial class MsgTypeManage : BaseFormBusiness, IMsgTypeManage
    {
        #region "属性"

        /// <summary>
        /// 消息类型
        /// </summary>
        private BaseMessageType messageType = new BaseMessageType();

        /// <summary>
        /// 消息类型
        /// </summary>
        public BaseMessageType MessageType
        {
            get
            {
                frmMsgType.GetValue<BaseMessageType>(messageType);
                return messageType;
            }

            set
            {
                messageType = value;
                frmMsgType.Load(messageType);
            }
        }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int WorkID
        {
            get
            {
                return Tools.ToInt32(cbWorkers.SelectedValue);
            }
        }

        /// <summary>
        /// 业务消息类型名
        /// </summary>
        public string MsgTypeName
        {
            get
            {
                return txtName.Text.Trim();
            }
        }

        #endregion

        #region "事件"

        /// <summary>
        /// 构造函数
        /// </summary>
        public MsgTypeManage()
        {
            InitializeComponent();
            frmMsgType.AddItem(txtMsgTypeCode, "Code");
            frmMsgType.AddItem(txtMsgTypeName, "Name");
            frmMsgType.AddItem(txtLimittime, "Limittime");
        }

        /// <summary>
        /// 查询业务消息类型列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            InvokeController("GetMessageTypeList", Tools.ToInt32(cbWorkers.SelectedValue), txtName.Text.Trim(), false);
            btnCancel_Click(null, null);
        }

        /// <summary>
        /// 窗体打开前界面加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void MsgTypeManage_OpenWindowBefore(object sender, EventArgs e)
        {
            // 界面初始化时类型详细显示控件不可编辑
            txtLimittime.Enabled = false;
            txtMsgTypeCode.Enabled = false;
            txtMsgTypeName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            bindGridSelectIndex(grdMsgTypeList);
        }

        /// <summary>
        /// 新增业务消息类型
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageType = new BaseMessageType();
            MessageType.Status = 0;
            txtMsgTypeCode.Enabled = true;
            txtMsgTypeName.Enabled = true;
            txtLimittime.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnStop.Enabled = false;
            txtMsgTypeCode.Focus();
        }

        /// <summary>
        /// 编辑业务消息类型
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grdMsgTypeList.CurrentCell != null)
            {
                txtMsgTypeCode.Enabled = false;
                txtMsgTypeName.Enabled = true;
                txtLimittime.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnStop.Enabled = false;
                txtMsgTypeName.Focus();
            }
        }

        /// <summary>
        /// 停用业务消息类型
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (grdMsgTypeList.CurrentCell != null)
            {
                int rowIndex = grdMsgTypeList.CurrentCell.RowIndex;
                DataTable typeList = grdMsgTypeList.DataSource as DataTable;
                MessageType = ConvertExtend.ToObject<BaseMessageType>(typeList, rowIndex);

                string msg = string.Empty;
                // 设置停用或者启用
                if (MessageType.Status == 0)
                {
                    msg = "确定要停用选中业务消息吗？";
                }
                else
                {
                    msg = "确定要启用选中业务消息吗？";
                }

                if (MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }

                MessageType.Status = MessageType.Status == 0 ? 1 : 0;
                InvokeController("SaveBaseMessageType", Tools.ToInt32(cbWorkers.SelectedValue));
                InvokeController("GetMessageTypeList", Tools.ToInt32(cbWorkers.SelectedValue), txtName.Text.Trim(), false);
            }
        }

        /// <summary>
        /// 刷新业务消息类型列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvokeController("GetMessageTypeList", Tools.ToInt32(cbWorkers.SelectedValue), txtName.Text.Trim(), false);
            btnCancel_Click(null, null);
        }

        /// <summary>
        /// 取消业务消息类型编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (grdMsgTypeList.CurrentCell != null)
            {
                int rowIndex = grdMsgTypeList.CurrentCell.RowIndex;
                DataTable typeList = grdMsgTypeList.DataSource as DataTable;
                MessageType = ConvertExtend.ToObject<BaseMessageType>(typeList, rowIndex);
                txtMsgTypeCode.Enabled = false;
                txtMsgTypeName.Enabled = false;
                txtLimittime.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnStop.Enabled = true;
            }
            else
            {
                txtMsgTypeCode.Enabled = false;
                txtMsgTypeName.Enabled = false;
                txtLimittime.Enabled = false;
                txtMsgTypeCode.Text = string.Empty;
                txtMsgTypeName.Text = string.Empty;
                txtLimittime.Text = string.Empty;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnStop.Enabled = true;
            }
        }

        /// <summary>
        /// 保存业务消息类型
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tools.ToString(txtMsgTypeCode.Text)))
            {
                InvokeController("MessageShow", "消息代码不能为空！");
                txtMsgTypeCode.Focus();
                return;
            }
            else
            {
                // 验证文本框内容是否包含特殊字符
                string pattern = @"^[a-zA-Z0-9]{0,10}$";
                if (!Regex.IsMatch(txtMsgTypeCode.Text.Trim(), pattern))
                {
                    InvokeController("MessageShow", "消息代码只能是半角数字或半角字母！");
                    txtMsgTypeCode.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(Tools.ToString(txtMsgTypeName.Text)))
            {
                InvokeController("MessageShow", "消息名称不能为空！");
                txtMsgTypeName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Tools.ToString(txtLimittime.Text)) || txtLimittime.Value <= 0)
            {
                InvokeController("MessageShow", "请输入正确的有效时间！");
                txtLimittime.Focus();
                return;
            }

            // 保存业务消息数据
            bool result = (bool)InvokeController("SaveBaseMessageType", Tools.ToInt32(cbWorkers.SelectedValue));
            if (result)
            {
                // 重新加载网格数据
                if (MessageType.Id == 0)
                {
                    InvokeController("GetMessageTypeList", Tools.ToInt32(cbWorkers.SelectedValue), txtName.Text.Trim(), true);
                }
                else
                {
                    InvokeController("GetMessageTypeList", Tools.ToInt32(cbWorkers.SelectedValue), txtName.Text.Trim(), false);
                }

                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnStop.Enabled = true;
            }
            else
            {
                InvokeController("MessageShow", "保存失败当前机构下已存在相同的消息代码，请重新输入！");
            }
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
        /// 选中业务消息数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdMsgTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdMsgTypeList.CurrentCell != null)
            {
                int rowIndex = grdMsgTypeList.CurrentCell.RowIndex;
                DataTable msgTypeList = grdMsgTypeList.DataSource as DataTable;
                MessageType = ConvertExtend.ToObject<BaseMessageType>(msgTypeList, rowIndex);
                if (MessageType.Status == 0)
                {
                    btnStop.Text = "停用(F8)";
                }
                else
                {
                    btnStop.Text = "启用(F8)";
                }

                txtLimittime.Enabled = false;
                txtMsgTypeCode.Enabled = false;
                txtMsgTypeName.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        /// <summary>
        /// 双击消息类型进入编辑状态
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdMsgTypeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdMsgTypeList.CurrentCell != null)
            {
                btnUpdate_Click(null, null);
                //int rowIndex = grdMsgTypeList.CurrentCell.RowIndex;
                //DataTable msgTypeList = grdMsgTypeList.DataSource as DataTable;
                //MessageType = ConvertExtend.ToObject<BaseMessageType>(msgTypeList, rowIndex);
                //if (MessageType.Status == 0)
                //{
                //    btnStop.Text = "停用(F8)";
                //}
                //else
                //{
                //    btnStop.Text = "启用(F8)";
                //}
                //txtLimittime.Enabled = false;
                //txtMsgTypeCode.Enabled = false;
                //txtMsgTypeName.Enabled = false;
                //btnSave.Enabled = false;
                //btnCancel.Enabled = false;
            }
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void MsgTypeManage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    // 新增业务消息
                    btnAdd_Click(null, null);
                    break;
                case Keys.F7:
                    // 编辑业务消息
                    btnUpdate_Click(null, null);
                    break;
                case Keys.F8:
                    // 停用或启用业务消息
                    btnStop_Click(null, null);
                    break;
                case Keys.F9:
                    // 刷新网格数据
                    btnRefresh_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region "数据绑定"

        /// <summary>
        /// 绑定业务消息类型列表
        /// </summary>
        /// <param name="msgTypeList">业务消息类型列表</param>
        /// <param name="isAdd">是否为新增后绑定</param>
        public void Bind_MsgTypeList(DataTable msgTypeList, bool isAdd)
        {
            grdMsgTypeList.DataSource = msgTypeList;
            if (isAdd)
            {
                setGridSelectIndex(grdMsgTypeList, msgTypeList.Rows.Count - 1);
            }
            else
            {
                setGridSelectIndex(grdMsgTypeList);
            }

            if (msgTypeList.Rows.Count > 0)
            {
                // 停用的消息显示红色
                for (int i = 0; i < msgTypeList.Rows.Count; i++)
                {
                    if (Tools.ToInt32(msgTypeList.Rows[i]["Status"]) == 1)
                    {
                        grdMsgTypeList.SetRowColor(i, Color.Red, true);
                    }
                }

                if (grdMsgTypeList.CurrentCell != null)
                {
                    int rowIndex = grdMsgTypeList.CurrentCell.RowIndex;
                    MessageType = ConvertExtend.ToObject<BaseMessageType>(msgTypeList, rowIndex);
                    if (MessageType.Status == 0)
                    {
                        btnStop.Text = "停用(F8)";
                    }
                    else
                    {
                        btnStop.Text = "启用(F8)";
                    }
                }
            }
            else
            {
                txtLimittime.Text = string.Empty;
                txtMsgTypeCode.Text = string.Empty;
                txtMsgTypeName.Text = string.Empty;
            }

            txtLimittime.Enabled = false;
            txtMsgTypeCode.Enabled = false;
            txtMsgTypeName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workDt">机构列表</param>
        /// <param name="defaultWorkID">默认选中的机构ID</param>
        public void loadWorkerDataBox(DataTable workDt, int defaultWorkID)
        {
            cbWorkers.DisplayMember = "WorkName";
            cbWorkers.ValueMember = "WorkId";
            cbWorkers.DataSource = workDt;
            cbWorkers.SelectedValue = defaultWorkID;
        }

        #endregion
    }
}
