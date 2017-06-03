using System.Data;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 基础数据-用法维护
    /// </summary>
    public interface IBasicDataChannelDao
    {
        /// <summary>
        /// 根据机构ID获取用法信息
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="searchText">检索条件</param>
        /// <returns>用法信息</returns>
        DataTable GetChannels(int workId,string searchText);

        /// <summary>
        /// 根据用法ID获取用法联动费用
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <returns>用法联动费用信息</returns>
        DataTable GetChannelFees(int channelId);

        /// <summary>
        /// 启用停用用法信息
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <param name="status">状态</param>
        /// <returns>停用或启用成功</returns>
        int StopChannel(string channelId, int status);

        /// <summary>
        /// 获取费用联动showcard
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>费用联动网格数据</returns>
        DataTable LoadFeeInfoCard(int workId);

        /// <summary>
        /// 根据用法ID删除用法联动费用
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <returns>1删除成功</returns>
        int DeleteChannelFees(int channelId);
    }
}
