using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.ItemManage
{
    /// <summary>
    /// 统计大类维护接口
    /// </summary>
    public interface IfrmStatItem : IBaseView
    {
        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构ID</param>
        void loadWorkers(DataTable dt, int defaultWorkID);

        /// <summary>
        /// 绑定统计大类列表
        /// </summary>
        /// <param name="listStat">中心统计大类</param>
        /// <param name="listitem">本院统计大类</param>
        /// <param name="listsubclass">分类明细</param>
        void loadStatItemTree(List<Basic_CenterStatItem> listStat, List<Basic_StatItem> listitem, List<Basic_StatItemSubclass> listsubclass);

        /// <summary>
        /// 绑定分类明细
        /// </summary>
        /// <param name="listsubclass">分类明细</param>
        void loadSubClass(List<Basic_StatItemSubclass> listsubclass);

        /// <summary>
        /// 机构ID
        /// </summary>
        int CurrWorkID { get; }

        /// <summary>
        /// 选中的统计大类
        /// </summary>
        Basic_StatItem CurrStatItem { get; }
    }
}
