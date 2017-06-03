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
    public class SqlBasicDataEmpDao : AbstractDao, IBasicDataEmpDao
    {
        /// <summary>
        /// 启用或停用人员
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <param name="delFlag">启用或停用标志</param>
        /// <returns>true：操作成功</returns>
        public bool FlagEmpAndDetail(int empId, int delFlag)
        {
            var strSql = " UPDATE BaseEmployee SET DelFlag = {0} WHERE EmpId = {1} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, delFlag, empId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 获取人员详情
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <returns>人员详情</returns>
        public BaseEmployeeDetails GetEmpDetail(int empId)
        {
            var strSql = " SELECT * FROM BaseEmployeeDetails WHERE EmpID = {0} ";

            return oleDb
                .Query<BaseEmployeeDetails>(string.Format(strSql, empId), string.Empty)
                .FirstOrDefault();
        }

        /// <summary>
        /// 根据机构ID,科室ID获取人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="workId">机构ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="showAll">是否显示全部</param>
        /// <param name="defaultDept">默认科室</param>
        /// <returns>人员列表</returns>
        public List<BaseEmployee> GetEmpList(string name, int workId, int deptId, bool showAll, bool defaultDept = false)
        {
            var strSql = @"SELECT 
	            a.EmpId,
	            Name,
	            Sex,
                dbo.fnGetDictName(1001,Sex) AS StrSex,
	            Brithday,
	            Szm,
	            Pym,
	            Wbm,
	            DelFlag,
	            a.WorkId,
				b.Telephone,
				b.IDNumber
            FROM BaseEmployee a
			LEFT JOIN BaseEmployeeDetails b ON a.EmpId=b.EmpID AND a.WorkId=b.WorkID
            WHERE a.WorkId= {0} {1} ";
            var strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(name))
            {
                strWhere.Append(string.Format(" AND a.Name LIKE '%{0}%' ", name));
            }

            if (!showAll)
            {
                strWhere.Append(" AND a.DelFlag = 0 ");
            }

            if (deptId > 0)
            {
                strWhere.Append(string.Format(" AND a.EmpId IN (SELECT EmpId FROM BaseEmpDept WHERE WorkId = {0} AND DeptId = {1} {2} )", workId, deptId, defaultDept ? " AND DefaultFlag = 1 " : string.Empty));
            }

            return oleDb
            .Query<BaseEmployee>(string.Format(strSql, workId, strWhere), string.Empty)
            .ToList();
        }

        /// <summary>
        /// 根据人员ID获取关联病区
        /// </summary>
        /// <param name="workId">病区ID</param>
        /// <param name="empId">人员ID</param>
        /// <returns>关联病区列表</returns>
        public DataTable GetEmpRelWards(int workId, int empId)
        {
            string strsql = @"SELECT (SELECT COUNT(1) FROM BaseEmpWard WHERE BaseEmpWard.WardID=a.WardID AND BaseEmpWard.EmpID={1}) CK
                                ,a.WardID,a.WardName
                                ,(SELECT COUNT(1) FROM BaseEmpWard WHERE BaseEmpWard.WardID=a.WardID AND BaseEmpWard.EmpID={1} AND BaseEmpWard.DefaultFlag=1) DefaultCK 
                                FROM BaseWard a
                                WHERE a.WorkID={0} AND a.DelFlag=0  ";
            strsql = string.Format(strsql, workId, empId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 删除人员关联病区关系
        /// </summary>
        /// <param name="workId">病区ID</param>
        /// <param name="empId">人员ID</param>
        /// <returns>true解除成功</returns>
        public bool DelEmpRelWards(int workId, int empId)
        {
            string strsql = @"DELETE FROM BaseEmpWard WHERE WorkID={0} AND EmpID={1}";
            strsql = string.Format(strsql, workId, empId);
            oleDb.DoCommand(strsql);
            return true;
        }
    }
}
