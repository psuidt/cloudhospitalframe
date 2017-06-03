using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 病区数据访问对象
    /// </summary>
    public class SqlBasicDataWardDao : AbstractDao, IBasicDataWardDao
    {
        /// <summary>
        /// 启用与停用病区
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>true：操作成功</returns>
        public bool FlagWard(int wardId, int delFlag)
        {
            var strSql = " UPDATE BaseWard SET DelFlag = {0} WHERE WardID = {1} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, delFlag, wardId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 根据机构ID,科室ID获取病区列表
        /// </summary>
        /// <param name="name">检索条件</param>
        /// <param name="workId">机构ID</param>
        /// <param name="showAll">是否显示全部选项</param>
        /// <returns>病区列表</returns>
        public List<BaseWard> GetWardList(string name, int workId, bool showAll)
        {
            var strSql = @" SELECT 
	            WardID,
	            WardName,
                SickbedNum,
                Responsible,
	            Pym,
	            Wbm,
	            Szm,
	            DelFlag,
	            SortOrder,
	            Memo,
	            WorkID
            FROM BaseWard 
            WHERE WorkID = {0} {1} ";
            var strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(name))
            {
                strWhere.Append(string.Format(" AND ( WardName LIKE '%{0}%' OR Pym LIKE '%{0}%' OR Wbm LIKE '%{0}%' OR Szm LIKE '%{0}%' ) ", name));
            }

            if (!showAll)
            {
                strWhere.Append(" AND DelFlag = 0 ");
            }

            return oleDb
            .Query<BaseWard>(string.Format(strSql, workId, strWhere), string.Empty)
            .ToList();
        }

        /// <summary>
        /// 加载病区关联的科室
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="isAll">是否显示所有</param>
        /// <returns>病区关联科室列表</returns>
        public DataTable GetWardRelDepts(int workId, int wardId, bool isAll)
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
	            warddept.ID,
                ISNULL(warddept.ID, 0) AS bFlag
            FROM BaseDept dept
            LEFT JOIN BaseWardDept warddept ON dept.DeptId = warddept.DeptID AND warddept.WorkID = {0} AND warddept.WardID = {1}
            WHERE dept.DelFlag=0 AND dept.WorkId = {0} {2} ";
            var strWhere = string.Empty;
            if (!isAll)
            {
                strWhere = " AND warddept.ID IS NOT NULL ";
            }

            return oleDb
                .GetDataTable(string.Format(strSql, workId, wardId, strWhere));
        }

        /// <summary>
        /// 加载病区关联的人员
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="isAll">是否显示所有</param>
        /// <returns>病区关联的人员列表</returns>
        public DataTable GetWardRelEmps(int workId, int wardId, bool isAll)
        {
            var strSql = @" SELECT 
	            emp.EmpId,
	            Name,
	            Sex,
                dbo.fnGetDictName(1001,Sex) AS StrSex,
	            Brithday,
	            Szm,
	            Pym,
	            Wbm,
	            DelFlag,
	            emp.WorkId,
	            empward.ID,
                ISNULL(empward.ID, 0) AS bFlag
            FROM BaseEmployee emp
            LEFT JOIN BaseEmpWard empward ON emp.EmpId = empward.EmpID AND empward.WorkID = {0} AND empward.WardID = {1}
            WHERE emp.WorkId = {0} {2} ";
            var strWhere = string.Empty;
            if (!isAll)
            {
                strWhere = " AND empward.ID IS NOT NULL ";
            }

            return oleDb
                .GetDataTable(string.Format(strSql, workId, wardId, strWhere));
        }
    }
}
