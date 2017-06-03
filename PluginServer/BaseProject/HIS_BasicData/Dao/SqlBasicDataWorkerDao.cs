using System.Linq;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 机构维护数据访问对象
    /// </summary>
    public class SqlBasicDataWorkerDao : AbstractDao, IBasicDataWorkerDao 
    {
        /// <summary>
        /// 启用和停用机构
        /// </summary>
        /// <param name="workerId">机构ID</param>
        /// <param name="delFlag">停用或启用标志</param>
        /// <returns>true：操作成功</returns>
        public bool FlagWorkerAndDetail(int workerId, int delFlag)
        {
            var strSql = " UPDATE BaseWorkers SET DelFlag = {0} WHERE WorkId = {1} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, delFlag, workerId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 根据机构ID获取机构详细
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>机构详细</returns>
        public BaseWorkesDetails GetWorkerDetail(int workId)
        {
            var strSql = " SELECT * FROM BaseWorkesDetails WHERE WorkId = {0} ";

            return oleDb
                .Query<BaseWorkesDetails>(string.Format(strSql, workId), string.Empty)
                .FirstOrDefault();
        }
    }
}
