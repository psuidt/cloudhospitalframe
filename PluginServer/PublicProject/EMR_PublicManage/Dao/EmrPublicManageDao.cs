using System.Data;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_PublicManage.Dao
{
    /// <summary>
    /// Emr基础数据处理对象
    /// </summary>
    public class EmrPublicManageDao : AbstractDao, IEmrPublicManageDao
    {
        /// <summary>
        /// 获取三测单时间管理类型数据
        /// </summary>
        /// <returns>时间类型列表</returns>
        public DataTable GetTimeManageData()
        {
            string strSql = 
                @"SELECT A.* FROM Emr_DictContent A 
                LEFT JOIN Emr_DictClass B ON A.ClassId=B.ClassId 
                WHERE B.ClassId='1041' AND A.WorkID = {0}";
            strSql = string.Format(strSql, oleDb.WorkId);
            return oleDb.GetDataTable(strSql);
        }
    }
}
