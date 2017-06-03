using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;
using HIS_BasicData.Winform.IView.MessageManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 消息类型维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "MsgTypeManage")]
    [WinformView(Name = "MsgTypeManage", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.MessageManage.MsgTypeManage")]
    public class MsgTypeManageController: WcfClientController
    {
        /// <summary>
        /// 消息类型接口
        /// </summary>
        IMsgTypeManage msgTypeManage;

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            msgTypeManage = (IMsgTypeManage)iBaseView["MsgTypeManage"];
        }

        /// <summary>
        /// 基础数据集合
        /// </summary>
        private List<object> asynData = new List<object>();

        /// <summary>
        /// 异步加载数据
        /// </summary>
        public override void AsynInit()
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "MsgTypeManageController",
               "InitLoadData");
            // 获取机构列表
            List<BaseWorkers> workers = retdata.GetData<List<BaseWorkers>>(0);
            asynData.Add(workers);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public override void AsynInitCompleted()
        {
            // 绑定机构列表
            List<BaseWorkers> workers = asynData[0] as List<BaseWorkers>;
            msgTypeManage.loadWorkerDataBox(ConvertExtend.ToDataTable(workers), LoginUserInfo.WorkId);
        }

        /// <summary>
        /// 获取业务消息类型列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="msgTypeName">业务消息类型名称</param>
        /// <param name="isAdd">是否为新增</param>
        [WinformMethod]
        public void GetMessageTypeList(int workID,string msgTypeName,bool isAdd)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(workID);
                request.AddData(msgTypeName);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "GetMessageTypeList", requestAction);
            DataTable msgTypeList = retdata.GetData<DataTable>(0);
            // 绑定业务消息类型列表
            msgTypeManage.Bind_MsgTypeList(msgTypeList, isAdd);
        }

        /// <summary>
        /// 保存业务消息类型数据
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>true:保存成功</returns>
        [WinformMethod]
        public bool SaveBaseMessageType(int workId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(workId);
                request.AddData(msgTypeManage.MessageType);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "SaveBaseMessageType", requestAction);
            return retdata.GetData<bool>(0);
        }

        #region "共用方法"

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        [WinformMethod]
        public void MessageShow(string msg)
        {
            MessageBoxShowSimple(msg);
        }
        #endregion
    }
}
