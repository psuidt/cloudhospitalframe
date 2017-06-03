using System.Collections.Generic;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.ItemManage
{
    /// <summary>
    /// 中心统计大类维护接口
    /// </summary>
    public interface IfrmCenterStatItem : IBaseView
    {
        /// <summary>
        /// 绑定统计大类树
        /// </summary>
        /// <param name="listStat">统计大类数据</param>
        void loadStatItemTree(List<Basic_CenterStatItem> listStat);

        /// <summary>
        /// 中心统计大类
        /// </summary>
        Basic_CenterStatItem CurrStatItem { get; set; }

        /// <summary>
        /// 全选
        /// </summary>
        int IsAll { get; }
    }
}
