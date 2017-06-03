using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.User
{
    /// <summary>
    /// 用户维护接口
    /// </summary>
    public interface IFrmUser : IBaseView
    {
        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 加载用户列表
        /// </summary>
        /// <param name="users">用户列表</param>
        void LoadBasicUsers(List<BaseUser> users);

        /// <summary>
        /// 加载下拉框数据
        /// </summary>
        /// <param name="dtDataSource">基础数据列表</param>
        void LoadBasicData(params DataTable[] dtDataSource);

        /// <summary>
        /// 加载科室查询下拉框
        /// </summary>
        /// <param name="depts">科室列表</param>
        void LoadBasicQueryDepts(DataTable depts);

        /// <summary>
        /// 加载员工下拉框 
        /// </summary>
        /// <param name="emps">员工列表</param>
        void LoadBasicEmps(DataTable emps);

        /// <summary>
        /// 加载用户角色列表
        /// </summary>
        /// <param name="groups">用户角色列表</param>
        void LoadBasicUserGroups(List<BaseGroup> groups);
    }
}
