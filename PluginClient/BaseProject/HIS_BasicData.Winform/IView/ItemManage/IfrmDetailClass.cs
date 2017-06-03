using System.Collections.Generic;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.ItemManage
{
    /// <summary>
    /// 明细分类维护接口
    /// </summary>
    public interface IfrmDetailClass : IBaseView
    {
        /// <summary>
        /// 绑定统计大类分类明细
        /// </summary>
        /// <param name="listsubclass">统计大类分类明细列表</param>
        void loadSubClassGrid(List<Basic_StatItemSubclass> listsubclass);

        /// <summary>
        /// 统计大类分类明细
        /// </summary>
        Basic_StatItemSubclass CurrSubClass { get; set; }
    }
}
