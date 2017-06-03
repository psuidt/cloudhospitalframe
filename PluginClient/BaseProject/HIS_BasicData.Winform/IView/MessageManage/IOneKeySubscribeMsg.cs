using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.IView.MessageManage
{
    /// <summary>
    /// 一键订阅消息接口
    /// </summary>
    public interface IOneKeySubscribeMsg : IBaseView
    {
        /// <summary>
        /// 绑定消息类型列表
        /// </summary>
        /// <param name="msgTypeList">消息类型列表</param>
        void Bind_MsgTypeList(DataTable msgTypeList);

        /// <summary>
        /// 绑定角色列表
        /// </summary>
        /// <param name="grouopDt">角色列表</param>
        void Bind_GroupList(DataTable grouopDt);

        /// <summary>
        /// 绑定角色关联用户列表
        /// </summary>
        /// <param name="grouopUserDt">角色关联用户列表</param>
        void Bind_GroupUserList(DataTable grouopUserDt);
    }
}
