using System.Data;
using System.Text;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 执行单配置数据访问对象
    /// </summary>
    public class SqlBasicDataExecBillDao : AbstractDao, IBasicDataExceBillDao
    {
        /// <summary>
        /// 获取执行单配置列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <param name="py">拼音码</param>
        /// <param name="wb">五笔码</param>
        /// <returns>执行单配置列表</returns>
        public DataTable GetExecBillInfo(int workID, string name, string py, string wb)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" select ID,BillName,PYCode,WBCode,ReportFile,DelFlag,");
            sqlStr.Append(" WorkID,(CASE DelFlag WHEN 0 THEN '使用中' ELSE '停用' END) AS UseFalgDesc from Basic_ExecuteBills ");
            sqlStr.Append(" where (BillName like '%" + name + "%' or PYCode like '%" + py + "%' or WBCode like '%" + wb + "%') AND WorkID=" + workID);
            sqlStr.Append(" order by ID");
            return oleDb.GetDataTable(sqlStr.ToString());
        }

        /// <summary>
        /// 删除执行单信息
        /// </summary>
        /// <param name="id">执行单ID</param>
        /// <param name="useFlag">删除标志</param>
        /// <param name="workID">机构ID</param>
        /// <returns>删除的行数</returns>
        public int UpdateUseFlag(int id, int useFlag, int workID)
        {
            string sqlStr = " update Basic_ExecuteBills set DelFlag=" + useFlag + " where ID=" + id + " AND WorkID=" + workID;
            return oleDb.DoCommand(sqlStr);
        }

        /// <summary>
        /// 验证执行单名是否重复
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <returns>执行单信息</returns>
        public DataTable CheckExecBillName(int workID, string name)
        {
            string sqlStr = " select ID,BillName from Basic_ExecuteBills where BillName='" + name + "' and workid=" + workID;
            return oleDb.GetDataTable(sqlStr);
        }

        /// <summary>
        /// 获取用法列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <returns>用法列表</returns>
        public DataTable GetChannelInfo(int workID)
        {
            string sqlStr = " select ID, ChannelName,pycode,wbcode from Basic_Channel where delflag=0 ";
            sqlStr = sqlStr + "order by sortorder";
            return oleDb.GetDataTable(sqlStr);
        }

        /// <summary>
        /// 获取执行单关联的用法列表
        /// </summary>
        /// <param name="billID">执行单ID</param>
        /// <param name="workID">机构ID</param>
        /// <returns>执行单关联的用法列表</returns>
        public DataTable GetExecuteBillChannel(int billID, int workID)
        {
            string sqlStr = "select a.ID,ExecBillID,ChannelID,a.workID,ChannelName FROM Basic_ExecuteBillChannel a join Basic_Channel b on a.ChannelID=b.ID WHERE ExecBillID=" + billID + " and a.workid=" + workID;

            return oleDb.GetDataTable(sqlStr);
        }

        /// <summary>
        /// 删除执行单关联用法
        /// </summary>
        /// <param name="id">执行单ID</param>
        /// <returns>删除的行数</returns>
        public int DelChannel(string id)
        {
            string sqlStr = " Delete from Basic_ExecuteBillChannel where ID in (" + id + ")";
            return oleDb.DoCommand(sqlStr);
        }
    }
}
