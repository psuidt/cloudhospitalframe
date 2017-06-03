using System.Data;
using System.Text;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 说明性医嘱数据访问对象
    /// </summary>
    public class SqlBascAttachAdviceDao: AbstractDao,IBasicAttachAdviceDao
    {
        /// <summary>
        /// 获取说明性医嘱列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        /// <returns>说明性医嘱列表</returns>
        public DataTable GetAttachAdviceInfo(int workID, string name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select ID,ItemCode,ItemName,ItemSpec,Unit,dbo.fnGetUintName(Unit) as UnitName,PYCode,WBCode,Uploader,UploadTime,DelFlag,WorkID,");
            sql.Append(" (CASE DelFlag WHEN 0 THEN '使用中' ELSE '停用' END) AS UseFalgDesc from Basic_AttachAdvice  where 1=1 ");
            if (workID > 0)
            {
                sql.Append("  AND WorkID=" + workID);
            }

            if (string.IsNullOrEmpty(name) == false)
            {
                sql.Append("   AND (ItemName like '%" + name + "%' or ItemName like '%" + name + "%' or ItemName like '%" + name + "%') ");
            }

            sql.Append("  ORDER BY ID ");
            return oleDb.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 检查说明性医嘱是否重复
        /// </summary>
        /// <param name="id">医嘱ID</param>
        /// <param name="name">医嘱名</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        public DataTable CheckAttachAdviceInfo(int id, string name,int workID)
        {
            string sqlStr = " select ID,ItemName AS CheckInfo from Basic_AttachAdvice where ItemName = '" + name + "' AND workID=" + workID;
            return  oleDb.GetDataTable(@sqlStr);
        }
    }
}
