using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Dept
{
    /// <summary>
    /// 科室维护接口
    /// </summary>
    public interface IFrmDept : IBaseView
    {
        /// <summary>
        /// 绑定机构下拉框,并继续绑定科室分类树
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 加载科室分类树
        /// </summary>
        /// <param name="deptLayers">科室列表</param>
        void LoadDeptlayerTree(List<BaseDeptLayer> deptLayers);

        /// <summary>
        /// 加载科室列表信息
        /// </summary>
        /// <param name="deptlist">科室列表</param>
        void LoadDeptList(DataTable deptlist);

        /// <summary>
        /// 获取当前选中科室详情
        /// </summary>
        /// <param name="deptDetail">科室详情</param>
        void LoadDeptDetail(BaseDeptDetails deptDetail);
    }
}
