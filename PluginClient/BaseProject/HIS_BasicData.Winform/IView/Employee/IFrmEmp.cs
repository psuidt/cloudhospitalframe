using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Employee
{
    /// <summary>
    /// 人员维护接口
    /// </summary>
    public interface IFrmEmp : IBaseView
    {
        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 绑定科室列表
        /// </summary>
        /// <param name="depts">科室列表</param>
        void LoadBasicDepts(DataTable depts);

        /// <summary>
        /// 绑定人员列表
        /// </summary>
        /// <param name="emps">人员列表</param>
        void LoadBasicEmps(List<BaseEmployee> emps);

        /// <summary>
        /// 绑定基础数据
        /// </summary>
        /// <param name="dtDataSource">基础数据集</param>
        void LoadBasicData(params DataTable[] dtDataSource);

        /// <summary>
        /// 显示人员详情
        /// </summary>
        /// <param name="empDetail">人员详情</param>
        void LoadEmpDetail(BaseEmployeeDetails empDetail);
    }
}
