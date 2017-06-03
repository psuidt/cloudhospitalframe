using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.FeeItem
{
    /// <summary>
    /// 本院收费项目维护接口
    /// </summary>
    public interface IHospFeeItemManage: IBaseView
    {
        /// <summary>
        /// 本院收费项目
        /// </summary>
        Basic_HospFeeItem CurrentHFeeItem { get; set; }

        /// <summary>
        /// 中心收费项目
        /// </summary>
        Basic_CenterFeeItem CurrentCFeeItem { get; set; }

        /// <summary>
        /// 绑定项目分类列表
        /// </summary>
        /// <param name="statDt">项目分类列表</param>
        void Bind_BasicData(DataTable statDt);

        /// <summary>
        /// 绑定本院收费项目数据列表
        /// </summary>
        /// <param name="hfeeitems">本院收费项目数据列表</param>
        /// <param name="totalCount">数据总行数</param>
        void Bind_HostFeeItemList(List<Basic_HospFeeItem> hfeeitems, int totalCount);
    }
}
