using System.Data;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 用法维护数据库访问对象
    /// </summary>
    public class SqlBasicDataChannelDao : AbstractDao, IBasicDataChannelDao
    {
        /// <summary>
        /// 根据机构ID获取用法信息
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="searchText">检索条件</param>
        /// <returns>用法列表</returns>
        public DataTable GetChannels(int workId, string searchText)
        {
            var strSql = @"SELECT * FROM Basic_Channel WHERE WorkId = {0}";
            if (!string.IsNullOrEmpty(searchText))
            {
                strSql = strSql + " AND (ChannelName like '%" + searchText + "%' or CName like '%" + searchText + "%' or EName like '%" + searchText + "%' or PYCode like '%" + searchText + "%' or WBCode like '%" + searchText + "%')";
            }

            strSql = strSql + " ORDER BY ID ASC";
            return oleDb
                .GetDataTable(string.Format(strSql, workId));
        }

        /// <summary>
        /// 根据用法ID获取用法联动费用
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <returns>用法联动费用信息</returns>
        public DataTable GetChannelFees(int channelId)
        {
            var strSql = @"SELECT 
                                       a.ItemName,a.ItemID,a.ItemAmount,a.ItemUnit,b.UnitPrice,
                                        CASE WHEN FeeClass=1 THEN '项目' ELSE '材料' END AS ItemClassName,
                                        CASE WHEN CalCostMode=0 THEN '按频次' ELSE '按周期' END AS ModeName 
                                        FROM Basic_ChannelFee a 
                                        LEFT JOIN ViewFeeItem_SimpleList b ON a.ItemID=b.ItemID 
                                        WHERE a.ChannelID={0}";
            return oleDb
                .GetDataTable(string.Format(strSql, channelId));
        }

        /// <summary>
        /// 启用停用用法信息
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <param name="status">状态</param>
        /// <returns>停用或启用成功</returns>
        public int StopChannel(string channelId, int status)
        {
            string strSql = @"UPDATE Basic_Channel SET DelFlag={1} WHERE ID={0}";
            return oleDb
    .DoCommand(string.Format(strSql, channelId, status));
        }

        /// <summary>
        /// 获取费用联动showcard
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>费用联动网格数据</returns>
        public DataTable LoadFeeInfoCard(int workId)
        {
            string strSql = @"SELECT ItemID,ItemName,Pym,Wbm,MiniUnitName,ItemClass,ItemClassName,UnitPrice FROM ViewFeeItem_SimpleList WHERE (ItemClass=2 OR ItemClass=3) AND WorkId = {0}";
            return oleDb.GetDataTable(string.Format(strSql, workId));
        }

        /// <summary>
        /// 根据用法ID删除用法联动费用
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <returns>1删除成功</returns>
        public int DeleteChannelFees(int channelId)
        {
            string strSql = @"DELETE FROM Basic_ChannelFee WHERE ChannelID={0}";
            return oleDb
    .DoCommand(string.Format(strSql, channelId));
        }
    }
}
