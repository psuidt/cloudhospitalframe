using System.Collections.Generic;
using System.Data;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 用户维护数据访问接口
    /// </summary>
    public interface IBasicDataUserDao
    {
        /// <summary>
        /// 获取未增加用户的所有员工
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>员工列表</returns>
        DataTable GetEmpList(int workId);

        /// <summary>
        /// 根据机构ID,科室ID获取人员列表
        /// </summary>
        /// <param name="name">检索条件</param>
        /// <param name="workId">机构ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="showAll">锁定标记</param>
        /// <returns>人员列表</returns>
        List<BaseUser> GetUserList(string name, int workId, int deptId, bool showAll);

        /// <summary>
        /// 启用与停用用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="delFlag">停用或启用标志</param>
        /// <returns>true：操作成功</returns>
        bool FlagUser(int userId, int delFlag);

        /// <summary>
        /// 根据用户ID加载角色列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>角色列表</returns>
        List<BaseGroup> GetUserGroups(int workId, int userId);

        /// <summary>
        /// 加载所有角色与用户关联关系
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>角色与用户关系列表</returns>
        DataTable GetUserRelGroups(int workId, int userId);

        /// <summary>
        /// 删除角色与用户关联关系
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>true：删除成功</returns>
        bool DelUserRelGroups(int workId, int userId);

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="empId">用户ID</param>
        /// <returns>true：存在</returns>
        bool ExistUser(int empId);

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="code">用户代码</param>
        /// <returns>true：存在</returns>
        bool ExistUser(string code);
    }
}
