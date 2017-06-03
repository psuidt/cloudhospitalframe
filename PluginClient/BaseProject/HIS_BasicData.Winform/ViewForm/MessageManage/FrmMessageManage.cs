using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.MessageManage;

namespace HIS_BasicData.Winform.ViewForm.MessageManage
{
    /// <summary>
    /// 查看业务消息
    /// </summary>
    public partial class FrmMessageManage : BaseFormBusiness, IMessageManage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMessageManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体打开加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmMessageManage_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("GetAllMessage", chkNoRead.Checked ? 0 : 1, 1, pgMessage.pageSize);
        }

        /// <summary>
        /// 查询所有未读消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void chkNoRead_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoRead.Checked)
            {
                pgMessage.pageNo = 1;
                ClearMsgData();
                InvokeController("GetAllMessage", 0, 1, pgMessage.pageSize);
            }
        }

        /// <summary>
        /// 清空界面当前选中的业务消息内容
        /// </summary>
        private void ClearMsgData()
        {
            txtMsgContent.Text = string.Empty;
            txtMsgTitle.Text = string.Empty;
            txtSendUser.Text = string.Empty;
        }

        /// <summary>
        /// 查询所有已读消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void chkRead_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRead.Checked)
            {
                pgMessage.pageNo = 1;
                ClearMsgData();
                InvokeController("GetAllMessage", 1, 1, pgMessage.pageSize);
            }
        }

        /// <summary>
        /// 将消息标记为已读
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            DataTable msgDt = grdMsgList.DataSource as DataTable;
            if (msgDt.Rows.Count > 0)
            {
                StringBuilder readId = new StringBuilder();
                for (int i = 0; i < msgDt.Rows.Count; i++)
                {
                    if (Tools.ToInt32(msgDt.Rows[i]["CheckFlag"]) == 1)
                    {
                        readId.Append(Tools.ToString(msgDt.Rows[i]["Id"]));
                        readId.Append(",");
                    }
                }

                if (readId.Length > 0)
                {
                    string strReadId = readId.ToString().Substring(0, readId.ToString().Length - 1);
                    // 将消息标记为已读
                    InvokeController("SaveMsgReadData", strReadId);
                    // 重新加载消息列表
                    InvokeController("GetAllMessage", chkNoRead.Checked ? 0 : 1, 1, pgMessage.pageSize);
                }
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
        /// 绑定已读或未读消息列表
        /// </summary>
        /// <param name="msgListDt">消息列表</param>
        /// <param name="totalCount">数据总行数</param>
        public void Bind_MessageList(DataTable msgListDt, int totalCount)
        {
            pgMessage.SetPagerDataSource(totalCount, msgListDt);
            chkAll.Checked = false;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            if (grdMsgList.Rows.Count > 0)
            {
                if (chkNoRead.Checked)
                {
                    // 未读消息显示黑色粗体
                    for (int i = 0; i < grdMsgList.Rows.Count; i++)
                    {
                        grdMsgList.SetRowColor(i, Color.Black, true);
                        Font f = new Font("宋体", 9, FontStyle.Bold);
                        style.Font = f;
                        style.ForeColor = Color.Black;
                        style.SelectionForeColor = Color.Black;
                        grdMsgList.DefaultCellStyle = style;
                    }
                }
                else if (chkRead.Checked)
                {
                    // 已读消息显示灰色
                    for (int i = 0; i < grdMsgList.Rows.Count; i++)
                    {
                        grdMsgList.SetRowColor(i, Color.Black, true);
                        Font f = new Font("宋体", 9, FontStyle.Regular);
                        style.Font = f;
                        style.ForeColor = Color.Gray;
                        style.SelectionForeColor = Color.Black;
                        grdMsgList.DefaultCellStyle = style;
                    }
                }
            }
        }

        /// <summary>
        /// 选中消息显示消息详细数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdMsgList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdMsgList.CurrentCell != null)
            {
                int rowIndex = grdMsgList.CurrentCell.RowIndex;
                DataTable msgDt = grdMsgList.DataSource as DataTable;
                txtMsgTitle.Text = Tools.ToString(msgDt.Rows[rowIndex]["MessageTitle"]);
                txtSendUser.Text = Tools.ToString(msgDt.Rows[rowIndex]["UserName"]);
                txtMsgContent.Text = Tools.ToString(msgDt.Rows[rowIndex]["MessageContent"]);
            }
        }

        /// <summary>
        /// 选中消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void grdMsgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdMsgList.CurrentCell != null)
            {
                if (e.ColumnIndex == 0)
                {
                    int rowIndex = grdMsgList.CurrentCell.RowIndex;
                    DataTable msgDt = grdMsgList.DataSource as DataTable;
                    msgDt.Rows[rowIndex]["CheckFlag"] = Tools.ToInt32(msgDt.Rows[rowIndex]["CheckFlag"]) == 0 ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// 全选消息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            DataTable msgList = grdMsgList.DataSource as DataTable;
            if (msgList != null && msgList.Rows.Count > 0)
            {
                for (int i = 0; i < msgList.Rows.Count; i++)
                {
                    msgList.Rows[i]["CheckFlag"] = chkAll.Checked ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// 切换页数
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">总页数</param>
        private void pgMessage_PageNoChanged(object sender, int pageNo, int pageSize)
        {
            InvokeController("GetAllMessage", chkNoRead.Checked ? 0 : 1, pageNo, pageSize);
        }
    }
}
