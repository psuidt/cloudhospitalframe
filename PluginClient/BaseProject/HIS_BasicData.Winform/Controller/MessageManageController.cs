using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;
using HIS_BasicData.Winform.IView.MessageManage;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 查看业务消息控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmMessageManage")]
    [WinformView(Name = "FrmMessageManage", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.MessageManage.FrmMessageManage")]
    public class MessageManageController: WcfClientController
    {
        /// <summary>
        /// 查看业务消息接口
        /// </summary>
        IMessageManage messageManage;

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            messageManage = (IMessageManage)iBaseView["FrmMessageManage"];
        }

        /// <summary>
        /// 获取所有已读或未读消息
        /// </summary>
        /// <param name="isRead">0：未读/1：已读</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">总页数</param>
        [WinformMethod]
        public void GetAllMessage(int isRead,int pageIndex,int pageSize)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(LoginUserInfo.EmpId);
                request.AddData(isRead);
                request.AddData(pageIndex);
                request.AddData(pageSize);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "GetAllMessage", requestAction);
            DataTable msgListDt = retdata.GetData<DataTable>(0);
            int totalCount = retdata.GetData<int>(1);
            messageManage.Bind_MessageList(msgListDt, totalCount);
        }

        /// <summary>
        /// 将选中消息标记为已读
        /// </summary>
        /// <param name="msgId">待标记消息ID集合</param>
        [WinformMethod]
        public void SaveMsgReadData(string msgId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(msgId);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "SaveMsgReadData", requestAction);
            MessageBoxShowSimple("所选消息已成功标记已读！");
        }
    }
}
