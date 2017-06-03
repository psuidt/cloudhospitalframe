using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;
using HIS_BasicData.Winform.IView.MessageManage;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 一键订阅消息
    /// </summary>
    [WinformController(DefaultViewName = "FrmOneKeySubscribeMsg")]
    [WinformView(Name = "FrmOneKeySubscribeMsg", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.MessageManage.FrmOneKeySubscribeMsg")]
    public class OneKeySubscribeMsgController : WcfClientController
    {
        /// <summary>
        /// 一键订阅接口
        /// </summary>
        IOneKeySubscribeMsg oneKeySubscribeMsg;

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            oneKeySubscribeMsg = (IOneKeySubscribeMsg)iBaseView["FrmOneKeySubscribeMsg"];
        }

        /// <summary>
        /// 获取消息类型列表
        /// </summary>
        [WinformMethod]
        public void GetSubscribeMsgList()
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(LoginUserInfo.EmpId);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "GetSubscribeMsgList", requestAction);
            DataTable msgList = retdata.GetData<DataTable>(0);
            oneKeySubscribeMsg.Bind_MsgTypeList(msgList);
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        [WinformMethod]
        public void GetBaseGroup()
        {
            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "GetBaseGroup");
            DataTable grouopDt = retdata.GetData<DataTable>(0);
            oneKeySubscribeMsg.Bind_GroupList(grouopDt);
        }

        /// <summary>
        /// 获取角色关联的用户列表
        /// </summary>
        /// <param name="groupId">角色ID</param>
        /// <param name="msgTypeId">消息类型ID</param>
        [WinformMethod]
        public void GetUserGroup(int groupId, int msgTypeId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
                request.AddData(msgTypeId);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "GetGroupUser", requestAction);
            DataTable groupUserDt = retdata.GetData<DataTable>(0);
            oneKeySubscribeMsg.Bind_GroupUserList(groupUserDt);
        }

        /// <summary>
        /// 保存消息订阅
        /// </summary>
        /// <param name="messageTypeUserDt">订阅数据列表</param>
        /// <param name="magId">消息ID</param>
        [WinformMethod]
        public void SaveMessageTypeUserData(DataTable messageTypeUserDt, int magId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(messageTypeUserDt);
                request.AddData(magId);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "OneKeySubscribeMsg", requestAction);
            MessageBoxShowSimple("保存成功");
        }

        #region "共用方法"

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="msg">消息类型</param>
        [WinformMethod]
        public void MessageShow(string msg)
        {
            MessageBoxShowSimple(msg);
        }
        #endregion
    }
}
