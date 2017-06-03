using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 机构维护数据访问接口
    /// </summary>
    public interface IBasicDataWorkerDao 
    {
        /// <summary>
        /// 根据机构ID获取机构详细
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>机构详细</returns>
        BaseWorkesDetails GetWorkerDetail(int workId);

        /// <summary>
        /// 启用和停用机构
        /// </summary>
        /// <param name="workerId">机构ID</param>
        /// <param name="delFlag">停用或启用标志</param>
        /// <returns>true：操作成功</returns>
        bool FlagWorkerAndDetail(int workerId, int delFlag);
    }
}
