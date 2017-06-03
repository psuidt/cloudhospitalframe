using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 用户维护数据访问对象
    /// </summary>
    public class SqlBasicDataUserDao : AbstractDao, IBasicDataUserDao
    {
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="code">用户代码</param>
        /// <returns>true：存在</returns>
        public bool ExistUser(string code)
        {
            string strsql = @"SELECT COUNT(1)FROM BaseUser WHERE Code = '{0}'";
            strsql = string.Format(strsql, code);
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="empId">用户ID</param>
        /// <returns>true：存在</returns>
        public bool ExistUser(int empId)
        {
            string strsql = @"SELECT COUNT(1) FROM BaseUser WHERE EmpID={0}";
            strsql = string.Format(strsql, empId);
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 启用与停用用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="delFlag">停用或启用标志</param>
        /// <returns>true：操作成功</returns>
        public bool FlagUser(int userId, int delFlag)
        {
            var strSql = " UPDATE BaseUser SET Lock = {0} WHERE UserID = {1} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, delFlag, userId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 获取未增加用户的所有员工
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>员工列表</returns>
        public DataTable GetEmpList(int workId)
        {
            string strsql = @"SELECT a.EmpId,a.Name,a.Pym,a.Wbm FROM BaseEmployee a 
                                WHERE a.WorkId={0}";
            strsql = string.Format(strsql, workId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 根据用户ID加载角色列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>角色列表</returns>
        public List<BaseGroup> GetUserGroups(int workId, int userId)
        {
            var strSql = @" SELECT 
                bg.GroupId,
	            Name,
	            DelFlag,
	            Admin,
	            Everyone,
	            bg.Memo,
	            Property,
	            bg.WorkId,
	            bgu.Id
            FROM BaseGroup bg
            LEFT JOIN BaseGroupUser bgu ON bg.GroupId = bgu.GroupId AND bgu.WorkId = {0} AND bgu.UserId = {1}
            WHERE bg.WorkId = {0} AND bgu.Id IS NOT NULL ";

            return oleDb
                .Query<BaseGroup>(string.Format(strSql, workId, userId), string.Empty)
                .ToList();
        }

        /// <summary>
        /// 根据机构ID,科室ID获取人员列表
        /// </summary>
        /// <param name="name">检索条件</param>
        /// <param name="workId">机构ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="showAll">锁定标记</param>
        /// <returns>人员列表</returns>
        public List<BaseUser> GetUserList(string name, int workId, int deptId, bool showAll)
        {
            var strSql = @" SELECT 
	            UserID,
	            u.EmpID,
	            Code,
	            PassWord,
	            GroupId,
	            Lock,
	            Memo,
	            UserType,
	            DoctorPost,
                dbo.fnGetDictName(1022,DoctorPost) AS StrDoctorPost,
	            NursePost,
                dbo.fnGetDictName(1023,NursePost) AS StrNursePost,
	            IsAdmin,
	            u.WorkId,
	            emp.Name,
                (SELECT top 1 dbo.fnGetDeptName(DeptId) FROM BaseEmpDept WHERE DefaultFlag=1 AND EmpId=emp.EmpId) DeptName
            FROM BaseUser u
            LEFT JOIN BaseEmployee emp ON u.EmpID = emp.EmpId AND emp.WorkId =  u.WorkId
            WHERE u.WorkId = {0} {1}";
            var strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(name))
            {
                strWhere.Append(string.Format(" AND ( u.Code LIKE '%{0}%' OR emp.Name LIKE '%{0}%' ) ", name));
            }

            if (!showAll)
            {
                strWhere.Append(" AND u.Lock = 0 ");
            }

            if (deptId > 0)
            {
                strWhere.Append(string.Format(" AND (SELECT COUNT(1) FROM BaseEmpDept WHERE DefaultFlag=1 AND EmpId=emp.EmpId AND DeptId={0})>0", deptId));
            }

            return oleDb
            .Query<BaseUser>(string.Format(strSql, workId, strWhere), string.Empty)
            .ToList();
        }

        /// <summary>
        /// 加载所有角色与用户关联关系
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>角色与用户关系列表</returns>
        public DataTable GetUserRelGroups(int workId, int userId)
        {
            var strSql = @" SELECT a.GroupId,a.Name,a.DelFlag,a.Admin,a.Everyone,a.Memo,a.Property
                            ,(SELECT COUNT(1) FROM BaseGroupUser WHERE BaseGroupUser.UserId={1} AND BaseGroupUser.GroupId=a.GroupId) bFlag 
                            FROM BaseGroup a WHERE DelFlag=0 AND WorkId={0}";
            return oleDb
                .GetDataTable(string.Format(strSql, workId, userId));
        }

        /// <summary>
        /// 删除角色与用户关联关系
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>true：删除成功</returns>
        public bool DelUserRelGroups(int workId, int userId)
        {
            string strsql = @"DELETE FROM BaseGroupUser WHERE UserId={1} AND WorkId={0}";
            oleDb.DoCommand(string.Format(strsql, workId, userId));
            return true;
        }
    }
}