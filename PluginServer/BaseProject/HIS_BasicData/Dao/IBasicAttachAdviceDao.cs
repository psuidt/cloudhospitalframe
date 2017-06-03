using System.Data;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 说明性医嘱数据访问接口
    /// </summary>
    public interface IBasicAttachAdviceDao
    {
        /// <summary>
        /// 获取说明性医嘱列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        /// <returns>说明性医嘱列表</returns>
        DataTable GetAttachAdviceInfo(int workID, string name);

        /// <summary>
        /// 检查说明性医嘱是否重复
        /// </summary>
        /// <param name="id">医嘱ID</param>
        /// <param name="name">医嘱名</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        DataTable CheckAttachAdviceInfo(int id, string name,int workID);
    }
}
