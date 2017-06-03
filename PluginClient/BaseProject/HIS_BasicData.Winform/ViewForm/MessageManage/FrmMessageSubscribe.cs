using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.MessageManage;

namespace HIS_BasicData.Winform.ViewForm.MessageManage
{
    /// <summary>
    /// 消息订阅
    /// </summary>
    public partial class FrmMessageSubscribe : BaseFormBusiness, IMessageSubscribe
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMessageSubscribe()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 窗体打开前加载网格数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmMessageSubscribe_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("GetSubscribeMsgList");
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            DataTable msgTypeList = grdMessageList.DataSource as DataTable;
            DataRow[] msgArray = msgTypeList.Select("CheckFlag=1");
            if (msgArray.Length > 0)
            {
                InvokeController("SaveMessageTypeUserData", msgTypeList, true);
            }
        }

        /// <summary>
        /// 取消消息订阅
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancelSubscribe_Click(object sender, EventArgs e)
        {
            DataTable msgTypeList = grdMessageList.DataSource as DataTable;
            DataRow[] msgArray = msgTypeList.Select("CheckFlag=1");
            if (msgArray.Length > 0)
            {
                InvokeController("SaveMessageTypeUserData", msgTypeList, false);
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
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            DataTable msgTypeList = grdMessageList.DataSource as DataTable;
            if (msgTypeList != null && msgTypeList.Rows.Count > 0)
            {
                for (int i = 0; i < msgTypeList.Rows.Count; i++)
                {
                    msgTypeList.Rows[i]["CheckFlag"] = chkAll.Checked ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// 选中消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdMessageList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (grdMessageList.CurrentCell != null)
                {
                    int rowIndex = grdMessageList.CurrentCell.RowIndex;
                    DataTable msgDt = grdMessageList.DataSource as DataTable;
                    if (Tools.ToInt32(msgDt.Rows[rowIndex]["CheckFlag"]) == 1)
                    {
                        msgDt.Rows[rowIndex]["CheckFlag"] = 0;
                    }
                    else
                    {
                        msgDt.Rows[rowIndex]["CheckFlag"] = 1;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定消息类型列表
        /// </summary>
        /// <param name="msgTypeList">消息类型列表</param>
        public void Bind_MsgTypeList(DataTable msgTypeList)
        {
            grdMessageList.DataSource = msgTypeList;
            chkAll.Checked = false;
            if (msgTypeList.Rows.Count > 0)
            {
                // 已订阅显示蓝色
                for (int i = 0; i < msgTypeList.Rows.Count; i++)
                {
                    if (Tools.ToString(msgTypeList.Rows[i]["IsSubscribe"]).Equals("是"))
                    {
                        grdMessageList.SetRowColor(i, Color.Blue, true);
                    }
                }
            }
        }
    }
}
