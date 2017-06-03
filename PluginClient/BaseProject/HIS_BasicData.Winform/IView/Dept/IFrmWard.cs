using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Dept
{
    /// <summary>
    /// 病区维护接口
    /// </summary>
    public interface IFrmWard : IBaseView
    {
        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 加载科室查询下拉框
        /// </summary>
        /// <param name="depts">科室列表</param>
        void LoadBasicQueryDepts(DataTable depts);

        /// <summary>
        /// 加载病区列表
        /// </summary>
        /// <param name="wards">病区列表</param>
        void LoadBasicWards(List<BaseWard> wards);

        /// <summary>
        /// 加载关联的科室与人员
        /// </summary>
        /// <param name="dtSources">科室列表</param>
        void LoadRelDeptAndEmps(params DataTable[] dtSources);
    }
}
