using System.Collections.Generic;
using System.Data;
using System.Text;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_Entity.MIManage.Common;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 消息维护服务端控制器
    /// </summary>
    [WCFController]
    public class MsgTypeManageController : WcfServerController
    {
        #region "业务消息维护"

        /// <summary>
        /// 获取业务消息类型列表
        /// </summary>
        /// <returns>消息类型列表</returns>
        [WCFMethod]
        public ServiceResponseData GetMessageTypeList()
        {
            // 当前登录用户所属机构ID
            int workID = requestData.GetData<int>(0);
            // 消息类型名
            string msgTypeName = requestData.GetData<string>(1);
            // 获取业务消息类型列表
            DataTable msgTypeList = NewDao<IMsgTypeManageDao>().GetMessageTypeList(workID, msgTypeName);
            // 将业务消息类型列表返回到客户端
            responseData.AddData(msgTypeList);
            return responseData;
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <returns>机构列表</returns>
        [WCFMethod]
        public ServiceResponseData InitLoadData()
        {
            // 获取机构列表
            List<BaseWorkers> workers = NewObject<BaseWorkers>()
                .getlist<BaseWorkers>(" DelFlag = 0 ");
            // 将机构列表返回到客户端
            responseData.AddData(workers);
            return responseData;
        }

        /// <summary>
        /// 保存业务消息数据
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveBaseMessageType()
        {
            // 当前登录用户所属机构ID
            int workId = requestData.GetData<int>(0);
            // 实例化消息类型
            BaseMessageType messageType = NewObject<BaseMessageType>();
            messageType = requestData.GetData<BaseMessageType>(1);
            // 新增消息类型时设置WorkId
            if (messageType.Id == 0)
            {
                // 设置机构ID
                SetWorkId(workId);

                // 根据机构ID判断当前机构下是否已存在相同的消息类型代码
                string strWhere = string.Format("WorkID={0} AND Code='{1}'", workId, messageType.Code);
                List<BaseMessageType> baseMessageType = NewObject<BaseMessageType>().getlist<BaseMessageType>(strWhere);
                // 如果当前机构下存在相同的消息类型，则返回false，保存消息类型失败。 
                if (baseMessageType != null && baseMessageType.Count > 0)
                {
                    responseData.AddData(false);
                    return responseData;
                }
            }

            // 保存消息类型数据
            this.BindDb(messageType);
            messageType.save();

            // 返回保存结果（true：保存成功）
            responseData.AddData(true);
            return responseData;
        }

        #endregion

        #region "消息订阅"

        /// <summary>
        /// 获取用户所有已订阅和未订阅消息列表
        /// </summary>
        /// <returns>消息列表</returns>
        [WCFMethod]
        public ServiceResponseData GetSubscribeMsgList()
        {
            int userID = requestData.GetData<int>(0);
            DataTable msgList = NewDao<IMsgTypeManageDao>().GetSubscribeMsgList(userID);
            responseData.AddData(msgList);
            return responseData;
        }

        /// <summary>
        /// 订阅/取消消息订阅
        /// </summary>
        /// <returns>true：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveMessageTypeUserData()
        {
            DataTable subscribeDt = requestData.GetData<DataTable>(0);
            bool isSubscribe = requestData.GetData<bool>(1);
            int userId = requestData.GetData<int>(2);
            StringBuilder str = new StringBuilder();
            StringBuilder msgTypeId = new StringBuilder();
            for (int i = 0; i < subscribeDt.Rows.Count; i++)
            {
                // 是选中的数据
                if (Tools.ToInt32(subscribeDt.Rows[i]["CheckFlag"].ToString(), 0) == 1)
                {
                    if (isSubscribe)
                    {
                        // 判断选中数据是否已被订阅
                        if (subscribeDt.Rows[i]["IsSubscribe"].ToString().Equals("是"))
                        {
                            str.Append(subscribeDt.Rows[i]["Code"].ToString());
                            str.Append("、");
                            continue;
                        }

                        msgTypeId.Append(subscribeDt.Rows[i]["Id"].ToString());
                        msgTypeId.Append(",");
                    }
                    else
                    {
                        // 判断选中数据是否未订阅
                        if (subscribeDt.Rows[i]["IsSubscribe"].ToString().Equals("否"))
                        {
                            str.Append(subscribeDt.Rows[i]["Code"].ToString());
                            str.Append("、");
                            continue;
                        }

                        msgTypeId.Append(subscribeDt.Rows[i]["SubscribeId"].ToString());
                        msgTypeId.Append(",");
                    }
                }
            }

            if (msgTypeId.Length > 0)
            {
                string typeId = msgTypeId.ToString().Substring(0, msgTypeId.ToString().Length - 1);
                if (isSubscribe)
                {
                    // 订阅
                    NewDao<IMsgTypeManageDao>().SubscribeMsg(typeId, userId);
                }
                else
                {
                    // 取消订阅
                    NewDao<IMsgTypeManageDao>().CancelSubscribe(typeId);
                }

                responseData.AddData(true);
                responseData.AddData(str.ToString());
                return responseData;
            }
            else
            {
                responseData.AddData(false);
                responseData.AddData(str.ToString());
                return responseData;
            }
        }

        #endregion

        #region "查看业务消息"

        /// <summary>
        /// 获取所有已读或未读消息
        /// </summary>
        /// <returns>消息列表</returns>
        [WCFMethod]
        public ServiceResponseData GetAllMessage()
        {
            int userId = requestData.GetData<int>(0);
            int isRead = requestData.GetData<int>(1);
            int pageIndex = requestData.GetData<int>(2);
            int pageSize = requestData.GetData<int>(3);
            PageInfo page = new PageInfo(pageSize, pageIndex);
            DataTable msgListDt = NewDao<IMsgTypeManageDao>().GetAllMessage(userId, isRead, ref page);
            responseData.AddData(msgListDt);
            responseData.AddData(page.totalRecord);
            return responseData;
        }

        /// <summary>
        /// 将所选消息标记为已读
        /// </summary>
        /// <returns>true：标记成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveMsgReadData()
        {
            string msgId = requestData.GetData<string>(0);
            bool result = NewDao<IMsgTypeManageDao>().SetReadMessage(msgId);
            responseData.AddData(result);
            return responseData;
        }

        #endregion

        #region "按角色一键订阅业务消息"

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>角色列表</returns>
        [WCFMethod]
        public ServiceResponseData GetBaseGroup()
        {
            DataTable groupDt = NewDao<IMsgTypeManageDao>().GetBaseGroup();
            responseData.AddData(groupDt);
            return responseData;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>角色列表</returns>
        [WCFMethod]
        public ServiceResponseData GetGroupUser()
        {
            int groupId = requestData.GetData<int>(0);
            int msgTypeId = requestData.GetData<int>(1);
            DataTable groupUserDt = NewDao<IMsgTypeManageDao>().GetGroupUser(groupId, msgTypeId);
            responseData.AddData(groupUserDt);
            return responseData;
        }

        /// <summary>
        /// 按角色一键订阅业务消息
        /// </summary>
        /// <returns>true：订阅成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData OneKeySubscribeMsg()
        {
            DataTable messageTypeUserDt = requestData.GetData<DataTable>(0);
            int megTypeId = requestData.GetData<int>(1);
            NewObject<BusinessMessage>().OneKeySubscribeMsg(messageTypeUserDt, megTypeId);
            return responseData;
        }

        #endregion
    }
}
