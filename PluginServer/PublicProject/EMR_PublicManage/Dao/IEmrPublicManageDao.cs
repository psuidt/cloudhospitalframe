using System.Data;

namespace EMR_PublicManage.Dao
{
    /// <summary>
    /// Emr基础数据处理接口
    /// </summary>
    public interface IEmrPublicManageDao
    {
        /// <summary>
        /// 获取三测单时间管理类型数据
        /// </summary>
        /// <returns>时间类型列表</returns>
        DataTable GetTimeManageData();
    }
}
