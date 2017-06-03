using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.FeeItem
{
    /// <summary>
    /// 中心收费项目维护接口
    /// </summary>
    public interface IFrmFeeItem : IBaseView
    {
        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 加载中心收费项目列表
        /// </summary>
        /// <param name="feeitems">中心收费项目列表</param>
        /// <param name="totalCount">数据行数</param>
        void LoadFeeItem<T>(List<T> feeitems, int totalCount);

        /// <summary>
        /// 加载基础数据
        /// </summary>
        /// <param name="dtStatID">基础数据源</param>
        void LoadBasicData(params DataTable[] dtStatID);

        /// <summary>
        /// 加载中心收费项目列表
        /// </summary>
        /// <param name="cfeeitem">中心收费项目列表</param>
        void LoadCenterFeeItem(Basic_CenterFeeItem cfeeitem);
    }

    /// <summary>
    /// 本院收费项目关联中心收费项目接口
    /// </summary>
    public interface IFrmRelFeeItem : IFrmFeeItem
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        int WorkerId { get; set; }

        /// <summary>
        /// 中心收费项目ID
        /// </summary>
        int CFeeItemID { get; set; }

        /// <summary>
        /// 当前选中中心收费项目
        /// </summary>
        Basic_CenterFeeItem Result { get; set; }
    }
}
