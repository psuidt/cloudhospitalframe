using System.Collections.Generic;
using System.Linq;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 统计大项目分类数据访问对象
    /// </summary>
    public class SqlBasicDataStatItemDao : AbstractDao, IBasicDataStatItemDao
    {
        /// <summary>
        /// 获取本院统计大类
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <returns>本院统计大类</returns>
        public List<Basic_StatItem> GetHostStatItemData(int workID)
        {
            string strsql = @"SELECT * FROM Basic_StatItem WHERE WorkID="+workID;
            return oleDb.Query<Basic_StatItem>(strsql, null).ToList();
        }

        /// <summary>
        /// 获取统计明细分类
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="subType">统计大类类型</param>
        /// <returns>统计明细分类</returns>
        public List<Basic_StatItemSubclass> GetSubClassData(int workID, int subType)
        {
            string strsql = @"SELECT * FROM Basic_StatItemSubclass WHERE DelFlag=0 AND (SubType={0} or 0={0}) And WorkID={1} ORDER BY OrderNum";
            strsql = string.Format(strsql, subType,workID);
            return oleDb.Query<Basic_StatItemSubclass>(strsql, null).ToList();
        }

        /// <summary>
        /// 删除统计大类
        /// </summary>
        /// <param name="statID">统计大类ID</param>
        /// <param name="val">删除标志</param>
        /// <returns>true：删除成功</returns>
        public bool SwitchStatItem(int statID,int val)
        {
            string strsql = @"UPDATE Basic_CenterStatItem SET DelFlag={1} WHERE StatID={0}";
            strsql = string.Format(strsql, statID, val);
            oleDb.DoCommand(strsql);
            return true;
        }
    }
}
