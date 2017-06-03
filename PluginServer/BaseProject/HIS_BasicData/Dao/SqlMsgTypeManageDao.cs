using System.Data;
using System.Text;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 消息类型维护数据访问对象
    /// </summary>
    public class SqlMsgTypeManageDao : AbstractDao, IMsgTypeManageDao
    {
        /// <summary>
        /// 获取业务消息类型列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="msgName">业务消息类型名称</param>
        /// <returns>业务消息类型列表</returns>
        public DataTable GetMessageTypeList(int workID, string msgName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT Id ");
            strSql.Append(" ,Code ");
            strSql.Append(" ,Name ");
            strSql.Append(" ,WorkFlag ");
            strSql.Append(" ,DeptFlag ");
            strSql.Append(" ,SendGroup ");
            strSql.Append(" ,ReceiveGroup ");
            strSql.Append(" ,Limittime ");
            strSql.Append(" ,Memo ");
            strSql.Append(" ,WorkId ");
            strSql.Append(" ,Status ");
            strSql.Append(" ,Limittime+'天' AS TermOfValidity ");
            strSql.Append(" ,CASE Status WHEN 0 THEN '正常' ELSE '停用' END AS States ");
            strSql.Append(" FROM BaseMessageType ");
            strSql.AppendFormat(" WHERE WorkID = {0} ", workID);
            if (!string.IsNullOrEmpty(msgName))
            {
                strSql.AppendFormat(" AND Name LIKE '%{0}%' ", msgName);
            }

            strSql.Append(" ORDER BY Id");
            return oleDb.GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获取用户所有已订阅和未订阅消息列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>用户所有已订阅和未订阅消息列表</returns>
        public DataTable GetSubscribeMsgList(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  0 CheckFlag , ");
            strSql.Append(" A.Id , ");
            strSql.Append(" A.Code , ");
            strSql.Append(" A.Name , ");
            strSql.Append(" A.Limittime + '天' AS Limittime, ");
            strSql.Append(" B.Id AS SubscribeId , ");
            strSql.Append(" CASE WHEN B.Id IS NULL THEN '否' ");
            strSql.Append(" ELSE '是' ");
            strSql.Append(" END AS IsSubscribe ");
            strSql.Append(" FROM BaseMessageType A ");
            strSql.AppendFormat(" LEFT JOIN BaseMessageTypeUser B ON A.Id = B.MessageTypeId AND B.EmpId = {0} ", userID);
            strSql.Append(" WHERE A.Status = 0 AND A.WorkId = 1 ");
            return oleDb.GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="msgTypeId">消息类型ID集合</param>
        /// <param name="userId">用户ID</param>
        /// <returns>true订阅成功</returns>
        public bool SubscribeMsg(string msgTypeId, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO BaseMessageTypeUser ");
            strSql.Append(" (MessageTypeId ");
            strSql.Append(" , EmpId ");
            strSql.Append(" , ReceiveTime,WorkID) ");
            strSql.AppendFormat(" SELECT Id,{1} AS EmpId, GETDATE() AS ReceiveTime,{0} AS WorkID ", oleDb.WorkId, userId);
            strSql.AppendFormat(" FROM BaseMessageType B WHERE B.Id IN({0}) ", msgTypeId);
            return oleDb.DoCommand(strSql.ToString()) > 0;
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="subscribeId">订阅ID</param>
        /// <returns>true：取消订阅成功</returns>
        public bool CancelSubscribe(string subscribeId)
        {
            string strSql = string.Format(@" DELETE FROM BaseMessageTypeUser WHERE Id IN ({0})", subscribeId);
            return oleDb.DoCommand(strSql) > 0;
        }

        /// <summary>
        /// 获取所有已读或未读消息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="isRead">0：未读/1：已读</param>
        /// <param name="page">分页</param>
        /// <returns>所有已读或未读消息</returns>
        public DataTable GetAllMessage(int userId, int isRead, ref PageInfo page)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT 0 AS CheckFlag , ");
            strSql.Append(" A.Id , ");
            strSql.Append(" A.MessageId , ");
            strSql.Append(" A.EmpId , ");
            strSql.Append(" A.ReadTime , ");
            strSql.Append(" A.IsRead , ");
            strSql.Append(" B.Id AS MsgID , ");
            strSql.Append(" B.SendEmpID , ");
            strSql.Append(" B.SendDept , ");
            strSql.Append(" B.ReceivingDept , ");
            strSql.Append(" B.SendTime , ");
            strSql.Append(" B.MessageTitle , ");
            strSql.Append(" B.MessageContent , ");
            strSql.Append(" B.Limittime , ");
            strSql.Append(" C.Code , ");
            strSql.Append(" C.Name , ");
            strSql.Append(" D.Name As UserName ");
            strSql.Append(" FROM BaseMessageRead A ");
            strSql.Append(" LEFT JOIN BaseMessage B ON A.MessageId = B.Id ");
            strSql.Append(" LEFT JOIN BaseMessageType C ON B.MessagetypeID = C.Id ");
            strSql.Append(" LEFT JOIN BaseEmployee D ON B.SendEmpID = D.EmpId ");
            strSql.AppendFormat(" WHERE A.EmpId = {0} ", userId);
            strSql.AppendFormat(" AND A.IsRead = {0} AND A.WorkID = {1} ", isRead, oleDb.WorkId);
            //strSql.Append(" AND B.Limittime >= DATEDIFF(DAY, B.SendTime, GETDATE()) ");
            strSql.AppendFormat(" AND C.Status = 0 AND B.MessagetypeID IN(SELECT MessageTypeId FROM BaseMessageTypeUser WHERE EmpId = {0})", userId);
            page.KeyName = "Id";

            return oleDb.GetDataTable(SqlPage.FormatSql(strSql.ToString(), page, oleDb));
        }

        /// <summary>
        /// 获取所有未读消息(框架读取用)
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>所有未读消息</returns>
        public DataTable GetAllMessage(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ");
            strSql.Append(" A.Id , ");
            strSql.Append(" A.MessageId , ");
            strSql.Append(" A.EmpId , ");
            strSql.Append(" A.ReadTime , ");
            strSql.Append(" A.IsRead , ");
            strSql.Append(" B.Id AS MsgID , ");
            strSql.Append(" B.SendEmpID , ");
            strSql.Append(" B.SendDept , ");
            strSql.Append(" B.ReceivingDept , ");
            strSql.Append(" B.SendTime , ");
            strSql.Append(" B.MessageTitle , ");
            strSql.Append(" B.MessageContent , ");
            strSql.Append(" B.Limittime , ");
            strSql.Append(" C.Code , ");  // 消息类型代码
            strSql.Append(" C.Name , ");  // 消息名
            strSql.Append(" D.Name As UserName "); // 发送人姓名
            strSql.Append(" FROM BaseMessageRead A ");
            strSql.Append(" LEFT JOIN BaseMessage B ON A.MessageId = B.Id ");
            strSql.Append(" LEFT JOIN BaseMessageType C ON B.MessagetypeID = C.Id ");
            strSql.Append(" LEFT JOIN BaseEmployee D ON B.SendEmpID = D.EmpId ");
            strSql.AppendFormat(" WHERE A.EmpId = {0} ", userId);
            strSql.AppendFormat(" AND A.IsRead = 0  AND A.WorkID = {0} ", oleDb.WorkId);
            strSql.Append(" AND B.Limittime >= DATEDIFF(DAY, B.SendTime, GETDATE()) ");
            strSql.AppendFormat(" AND C.Status = 0 AND B.MessagetypeID IN(SELECT MessageTypeId FROM BaseMessageTypeUser WHERE EmpId = {0})", userId);
            return oleDb.GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 将消息标记为已读
        /// </summary>
        /// <param name="readMsgId">待标记消息ID集合</param>
        /// <returns>true：标记成功</returns>
        public bool SetReadMessage(string readMsgId)
        {
            string strSql = @"UPDATE BaseMessageRead SET IsRead = 1,ReadTime = GETDATE() WHERE Id IN ({0}) ";
            strSql = string.Format(strSql, readMsgId);
            return oleDb.DoCommand(strSql) > 0;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>角色列表</returns>
        public DataTable GetBaseGroup()
        {
            string strSql = string.Format(@"SELECT * FROM BaseGroup WHERE WorkId = {0} AND DelFlag = 0 ", oleDb.WorkId);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取机构关联的用户列表
        /// </summary>
        /// <param name="groupId">机构ID</param>
        /// <param name="msgTypeId">消息类型ID</param>
        /// <returns>机构关联的用户列表</returns>
        public DataTable GetGroupUser(int groupId,int msgTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT u.UserID , ");
            strSql.Append(" u.EmpID , ");
            strSql.Append(" u.Code , ");
            strSql.Append(" u.GroupId , ");
            strSql.Append(" u.WorkId , ");
            strSql.Append(" emp.Name, ");
            strSql.AppendFormat(" CASE dbo.fnMessageTypeUser(u.EmpID,{0}) WHEN 1 THEN 1 ELSE 0 END  AS CheckFlag ", msgTypeId);
            //strSql.AppendFormat(" CASE dbo.fnMessageTypeUser(u.EmpID,{0}) WHEN 1 THEN 1 ELSE 0 END  AS SaveFlag ", msgTypeId);
            strSql.Append(" FROM    BaseUser u ");
            strSql.Append(" LEFT JOIN BaseEmployee emp ON u.EmpID = emp.EmpId ");
            strSql.Append(" AND emp.WorkId = u.WorkId ");
            strSql.Append(" LEFT JOIN BaseGroupUser gu ON u.UserID = gu.UserId ");
            strSql.Append(" WHERE u.Lock = 0 ");
            strSql.AppendFormat(" AND gu.GroupId = {0} ", groupId);
            strSql.AppendFormat(" AND u.WorkId = {0} ", oleDb.WorkId);
            return oleDb.GetDataTable(strSql.ToString());
        }
    }
}
