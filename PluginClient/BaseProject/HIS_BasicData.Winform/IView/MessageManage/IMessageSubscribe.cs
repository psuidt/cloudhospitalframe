using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.IView.MessageManage
{
    /// <summary>
    /// 订阅消息接口
    /// </summary>
    public interface IMessageSubscribe: IBaseView
    {
        /// <summary>
        /// 绑定消息类型列表
        /// </summary>
        /// <param name="msgTypeList">消息类型列表</param>
        void Bind_MsgTypeList(DataTable msgTypeList);
    }
}
