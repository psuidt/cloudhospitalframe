using System.Collections.Generic;
using System.Data;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 用户维护数据访问接口
    /// </summary>
    public interface IBasicDataEmpDao
    {
        /// <summary>
        /// 根据机构ID,科室ID获取人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="workId">机构ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="showAll">是否显示全部</param>
        /// <param name="defaultDept">默认科室</param>
        /// <returns>人员列表</returns>
        List<BaseEmployee> GetEmpList(string name, int workId, int deptId, bool showAll, bool defaultDept = false);

        /// <summary>
        /// 获取人员详情
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <returns>人员详情</returns>
        BaseEmployeeDetails GetEmpDetail(int empId);

        /// <summary>
        /// 启用或停用人员
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <param name="delFlag">启用或停用标志</param>
        /// <returns>true：操作成功</returns>
        bool FlagEmpAndDetail(int empId, int delFlag);

        /// <summary>
        /// 根据人员ID获取关联病区
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="empId">人员ID</param>
        /// <returns>关联病区列表</returns>
        DataTable GetEmpRelWards(int workId,int empId);

        /// <summary>
        /// 删除人员关联病区关系
        /// </summary>
        /// <param name="workId">病区ID</param>
        /// <param name="empId">人员ID</param>
        /// <returns>true解除成功</returns>
        bool DelEmpRelWards(int workId, int empId);
    }
}
