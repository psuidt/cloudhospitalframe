using System.Data;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 消息类型数据访问接口
    /// </summary>
    public interface IMsgTypeManageDao
    {
        /// <summary>
        /// 获取业务消息类型列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="msgName">业务消息类型名称</param>
        /// <returns>业务消息类型列表</returns>
        DataTable GetMessageTypeList(int workID, string msgName);

        /// <summary>
        /// 获取用户所有已订阅和未订阅消息列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>用户所有已订阅和未订阅消息列表</returns>
        DataTable GetSubscribeMsgList(int userID);

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="msgTypeId">消息类型ID集合</param>
        /// <param name="userId">用户ID</param>
        /// <returns>true订阅成功</returns>
        bool SubscribeMsg(string msgTypeId, int userId);

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="subscribeId">订阅ID集合</param>
        /// <returns>true：取消订阅成功</returns>
        bool CancelSubscribe(string subscribeId);

        /// <summary>
        /// 获取所有已读或未读消息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="isRead">0：未读/1：已读</param>
        /// <param name="page">分页</param>
        /// <returns>所有已读或未读消息</returns>
        DataTable GetAllMessage(int userId, int isRead, ref PageInfo page);

        /// <summary>
        /// 获取所有未读消息(框架读取用)
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>所有未读消息</returns>
        DataTable GetAllMessage(int userId);

        /// <summary>
        /// 将消息标记为已读
        /// </summary>
        /// <param name="readMsgId">待标记消息ID集合</param>
        /// <returns>true：标记成功</returns>
        bool SetReadMessage(string readMsgId);

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>角色列表</returns>
        DataTable GetBaseGroup();

        /// <summary>
        /// 获取机构关联的用户列表
        /// </summary>
        /// <param name="groupId">机构ID</param>
        /// <param name="msgTypeId">消息类型ID</param>
        /// <returns>机构关联的用户列表</returns>
        DataTable GetGroupUser(int groupId, int msgTypeId);
    }
}
