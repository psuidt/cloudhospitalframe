using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.IView.MessageManage
{
    /// <summary>
    /// 查看业务消息接口
    /// </summary>
    public interface IMessageManage: IBaseView
    {
        /// <summary>
        /// 绑定已读或未读消息列表
        /// </summary>
        /// <param name="msgListDt">消息列表</param>
        /// <param name="totalCount">数据总行数</param>
        void Bind_MessageList(DataTable msgListDt,int totalCount);
    }
}
