using System.Collections.Generic;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 统计大类Dao
    /// </summary>
    public interface IBasicDataStatItemDao
    {
        /// <summary>
        /// 删除统计大类
        /// </summary>
        /// <param name="statID">统计大类ID</param>
        /// <param name="val">删除标志</param>
        /// <returns>true：删除成功</returns>
        bool SwitchStatItem(int statID, int val);

        /// <summary>
        /// 获取本院统计大类
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <returns>本院统计大类</returns>
        List<Basic_StatItem> GetHostStatItemData(int workID);

        /// <summary>
        /// 获取统计明细分类
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="subType">统计大类类型</param>
        /// <returns>统计明细分类</returns>
        List<Basic_StatItemSubclass> GetSubClassData(int workID,int subType);
    }
}
