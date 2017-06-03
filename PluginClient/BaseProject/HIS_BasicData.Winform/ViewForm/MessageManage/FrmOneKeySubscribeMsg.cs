using System;
using System.Data;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.MessageManage;

namespace HIS_BasicData.Winform.ViewForm.MessageManage
{
    /// <summary>
    /// 根据角色一键订阅业务消息
    /// </summary>
    public partial class FrmOneKeySubscribeMsg : BaseFormBusiness, IOneKeySubscribeMsg
    {
        /// <summary>
        /// 选中标志
        /// </summary>
        private bool checkFlg = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOneKeySubscribeMsg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体打开前加载业务消息类型列表、角色列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmOneKeySubscribeMsg_OpenWindowBefore(object sender, EventArgs e)
        {
            bindGridSelectIndex(grdMessageList);
            bindGridSelectIndex(grdGroupList);
            bindGridSelectIndex(grdGroupUserList);
            InvokeController("GetSubscribeMsgList");
            InvokeController("GetBaseGroup");
        }

        /// <summary>
        /// 绑定业务消息类型列表
        /// </summary>
        /// <param name="msgTypeList">业务消息类型列表</param>
        public void Bind_MsgTypeList(DataTable msgTypeList)
        {
            grdMessageList.DataSource = msgTypeList;
            setGridSelectIndex(grdMessageList);
        }

        /// <summary>
        /// 绑定角色列表
        /// </summary>
        /// <param name="grouopDt">角色列表</param>
        public void Bind_GroupList(DataTable grouopDt)
        {
            grdGroupList.DataSource = grouopDt;
            setGridSelectIndex(grdGroupList);
        }

        /// <summary>
        /// 绑定角色关联用户列表
        /// </summary>
        /// <param name="grouopUserDt">角色关联用户列表</param>
        public void Bind_GroupUserList(DataTable grouopUserDt)
        {
            grdGroupUserList.DataSource = grouopUserDt;
            checkFlg = false;
            chkAll.Checked = false;
            checkFlg = true;
            setGridSelectIndex(grdGroupUserList);
        }

        /// <summary>
        /// 选中角色加载用户列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdGroupList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdGroupList.CurrentCell != null && grdMessageList.CurrentCell != null)
            {
                int rowIndex = grdGroupList.CurrentCell.RowIndex;
                DataTable groupDt = grdGroupList.DataSource as DataTable;
                int msgIndex = grdMessageList.CurrentCell.RowIndex;
                DataTable msgDt = grdMessageList.DataSource as DataTable;
                InvokeController(
                    "GetUserGroup", 
                    Tools.ToInt32(groupDt.Rows[rowIndex]["GroupId"]),
                    Tools.ToInt32(msgDt.Rows[msgIndex]["Id"]));
            }
        }

        /// <summary>
        /// 选中用户
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdGroupUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdGroupUserList.CurrentCell != null)
            {
                int rowIndex = grdGroupUserList.CurrentCell.RowIndex;
                DataTable groupUserDt = grdGroupUserList.DataSource as DataTable;
                if (Tools.ToInt32(groupUserDt.Rows[rowIndex]["CheckFlag"]) == 0)
                {
                    groupUserDt.Rows[rowIndex]["CheckFlag"] = 1;
                }
                else
                {
                    groupUserDt.Rows[rowIndex]["CheckFlag"] = 0;
                }
            }
        }

        /// <summary>
        /// 全选所有用户
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFlg)
            {
                DataTable groupUserDt = grdGroupUserList.DataSource as DataTable;
                if (groupUserDt != null && groupUserDt.Rows.Count > 0)
                {
                    for (int i = 0; i < groupUserDt.Rows.Count; i++)
                    {
                        groupUserDt.Rows[i]["CheckFlag"] = chkAll.Checked ? 1 : 0;
                    }
                }
            }
        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 一键订阅消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            // 未选择消息类型
            if (grdMessageList.CurrentCell == null)
            {
                InvokeController("MessageShow", "请选择需要订阅的消息类型！");
                return;
            }

            // 未选择角色类型
            if (grdGroupList.CurrentCell == null)
            {
                InvokeController("MessageShow", "请选择角色类型！");
                return;
            }

            int msgIndex = grdMessageList.CurrentCell.RowIndex;
            DataTable msgDt = grdMessageList.DataSource as DataTable;
            DataTable userDt = grdGroupUserList.DataSource as DataTable;
            InvokeController("SaveMessageTypeUserData", userDt, Tools.ToInt32(msgDt.Rows[msgIndex]["Id"]));
        }

        /// <summary>
        /// 切换消息类型重新加载用户列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdMessageList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdMessageList.CurrentCell != null)
            {
                // 当前选中的消息类型
                int msgIndex = grdMessageList.CurrentCell.RowIndex;
                DataTable msgDt = grdMessageList.DataSource as DataTable;

                // 当前选中的角色类型
                int rowIndex = 0;
                if (grdGroupList.CurrentCell != null)
                {
                    // 根据消息类型ID加载当前当前选中角色类型的用户列表
                    rowIndex = grdGroupList.CurrentCell.RowIndex;
                    DataTable groupDt = grdGroupList.DataSource as DataTable;
                    InvokeController(
                        "GetUserGroup", 
                        Tools.ToInt32(groupDt.Rows[rowIndex]["GroupId"]),
                        Tools.ToInt32(msgDt.Rows[msgIndex]["Id"]));
                }
                else
                {
                    // 未选中角色类型,并且角色列表有数据
                    if (grdGroupList.DataSource != null && ((DataTable)grdGroupList.DataSource).Rows.Count > 0)
                    {
                        // 加载角色列表第一行的关联用户列表
                        DataTable groupDt = grdGroupList.DataSource as DataTable;
                        InvokeController(
                            "GetUserGroup", 
                            Tools.ToInt32(groupDt.Rows[rowIndex]["GroupId"]),
                            Tools.ToInt32(msgDt.Rows[msgIndex]["Id"]));
                    }
                }
            }
        }

        /// <summary>
        /// 刷新网格数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvokeController("GetSubscribeMsgList");
            InvokeController("GetBaseGroup");
        }
    }
}
