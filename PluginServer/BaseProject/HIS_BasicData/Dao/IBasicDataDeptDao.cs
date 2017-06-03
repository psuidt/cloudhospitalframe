using System.Collections.Generic;
using System.Data;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 科室维护数据访问接口
    /// </summary>
    public interface IBasicDataDeptDao
    {
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>科室列表</returns>
        List<BaseDeptLayer> GetDeptLayers(int workId);

        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="layer">科室级别</param>
        /// <param name="searchvalue">检索条件</param>
        /// <returns>科室列表</returns>
        DataTable GetDeptList(int workId, string layer, string searchvalue);

        /// <summary>
        /// 根据科室ID获取科室详细信息
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <returns>科室详细信息</returns>
        BaseDeptDetails GetDeptDetail(int deptId);

        /// <summary>
        /// 根据科室ID删除科室
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <param name="status">状态</param>
        /// <returns>删除行数</returns>
        int DeleteDept(int deptId,int status);

        /// <summary>
        /// 根据科室ID修改科室名称
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <param name="deptname">科室名</param>
        /// <returns>修改的行数</returns>
        int SaveDept(int deptId, string deptname);

        /// <summary>
        /// 获取科室关联人员信息
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="empId">人员ID</param>
        /// <returns>科室关联人员信息</returns>
        DataTable GetEmpRelDepts(int workId, int empId);
    }
}
