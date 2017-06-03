using System.Collections.Generic;
using System.Data;
using System.Linq;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 科室维护数据访问对象
    /// </summary>
    public class SqlBasicDataDeptDao : AbstractDao, IBasicDataDeptDao
    {
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <returns>科室列表</returns>
        public List<BaseDeptLayer> GetDeptLayers(int workId)
        {
            var strSql = @" SELECT 
                LayerId,
	            PId,
	            Name,
	            WorkId
                FROM BaseDeptLayer WHERE WorkId = {0} ";

            return oleDb
                .Query<BaseDeptLayer>(string.Format(strSql, workId), string.Empty)
                .ToList();
        }

        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="layer">科室级别</param>
        /// <param name="searchvalue">检索条件</param>
        /// <returns>科室列表</returns>
        public DataTable GetDeptList(int workId, string layer, string searchvalue)
        {
            var strSql = @"SELECT 
            DeptId,
            WorkID,
            Name,
            Pym,
            Wbm,
            (CASE DelFlag WHEN 1 THEN '已停用' ELSE '已启用' END) as DelFlag
            FROM BaseDept WHERE WorkId ={0} and Layer={1}";
            if (!string.IsNullOrEmpty(searchvalue))
            {
                strSql = strSql + " and (Name like '%{2}%' or Pym like '%{2}%' or Wbm like '%{2}%')";
            }

            return oleDb.GetDataTable(string.Format(strSql, workId, layer, searchvalue));
        }

        /// <summary>
        /// 根据科室ID获取科室详细信息
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <returns>科室详细信息</returns>
        public BaseDeptDetails GetDeptDetail(int deptId)
        {
            var strSql = " SELECT * FROM BaseDeptDetails WHERE WorkID={0} AND DeptID = {1} ";

            return oleDb
    .Query<BaseDeptDetails>(string.Format(strSql, oleDb.WorkId, deptId), string.Empty)
    .FirstOrDefault();
        }

        /// <summary>
        /// 根据科室ID删除科室
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <param name="status">状态</param>
        /// <returns>删除行数</returns>
        public int DeleteDept(int deptId, int status)
        {
            var strSql = " Update BaseDept Set DelFlag={1} WHERE DeptID = {0} ";
            return oleDb.DoCommand(string.Format(strSql, deptId, status));
        }

        /// <summary>
        /// 根据科室ID修改科室名称
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <param name="deptname">科室名</param>
        /// <returns>修改的行数</returns>
        public int SaveDept(int deptId, string deptname)
        {
            var strSql = " Update BaseDept Set Name='{0}' WHERE DeptID = {1} ";
            return oleDb.DoCommand(string.Format(strSql, deptname, deptId));
        }

        /// <summary>
        /// 获取科室关联人员信息
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="empId">人员ID</param>
        /// <returns>科室关联人员信息</returns>
        public DataTable GetEmpRelDepts(int workId, int empId)
        {
            var strSql = @" SELECT 
	            dept.DeptId,
	            Layer,
	            Name,
	            Pym,
	            Wbm,
	            Szm,
	            Code,
	            DelFlag,
	            SortOrder,
	            Memo,
	            dept.WorkId,
                empdept.Id,
	            empdept.EmpId,
	            empdept.DefaultFlag
            FROM BaseDept dept
            LEFT JOIN BaseEmpDept empdept ON dept.DeptId = empdept.DeptId  AND empdept.WorkId = {0} AND empdept.EmpId = {1}
            WHERE dept.WorkId = {0} ";
            return oleDb.GetDataTable(string.Format(strSql, workId, empId));
        }
    }
}
