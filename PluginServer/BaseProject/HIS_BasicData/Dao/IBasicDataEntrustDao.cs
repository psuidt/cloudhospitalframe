using System.Data;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 嘱托维护数据访问接口
    /// </summary>
    public interface IBasicDataEntrustDao
    {
        /// <summary>
        /// 获取嘱托列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        /// <returns>嘱托列表</returns>
        DataTable GetEntrustList(int workID, string name);

        /// <summary>
        /// 检查嘱托是否重复
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="entrustID">嘱托ID</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        bool CheckEntrustName(string name, int entrustID, int workID);
    }
}
