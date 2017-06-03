using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 系统参数数据访问对象
    /// </summary>
    public class SqlBasicDataParameterDao : AbstractDao, IBasicDataParameterDao
    {
        /// <summary>
        /// 是否存在此系统参数
        /// </summary>
        /// <param name="paraId">参数ID</param>
        /// <param name="workID">机构ID</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="sysType">参数类型</param>
        /// <returns>true：存在</returns>
        public bool ExistSystemConfig(string paraId, int workID, int deptID, int sysType)
        {
            string strsql = @"SELECT COUNT(ID) FROM Basic_SystemConfig WHERE ParaID='{0}' AND WorkID={1} AND DeptID={2} AND SystemType={3}";
            strsql = string.Format(strsql, paraId,workID,deptID,sysType);
            return Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0;
        }

        /// <summary>
        /// 获取系统参数列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="sysType">参数类型</param>
        /// <param name="searchKey">检索条件</param>
        /// <returns>系统参数列表</returns>
        public DataTable GetSystemConfigData(int workID, int sysType, string searchKey)
        {
            string strsql = @"SELECT 0 CK,a.*
                                ,(CASE SystemType WHEN 0 THEN '基础' WHEN 1 THEN '门诊' WHEN 2 THEN '住院' WHEN 3 THEN '药品' WHEN 4 THEN '物资' END) TypeName
                                ,dbo.fnGetDeptName(DeptID) DeptName
                                ,(CASE Delflag WHEN 1 THEN '已停用' ELSE '已启用' END) StopState
                                FROM Basic_SystemConfig a 
                                WHERE WorkID={0} AND SystemType={1} AND (ParaID LIKE '%{2}%' OR ParaName LIKE '%{2}%')";
            strsql = string.Format(strsql, workID, sysType, searchKey);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取系统参数类型列表
        /// </summary>
        /// <returns>系统参数类型列表</returns>
        public DataTable GetSystemTypeData()
        {
            return oleDb.GetDataTable(@"SELECT * FROM View_GetSystemType");
        }

        /// <summary>
        /// 删除系统参数
        /// </summary>
        /// <param name="sysId">参数ID</param>
        /// <param name="val">删除状态</param>
        /// <returns>true：删除成功</returns>
        public bool SwitchSystemConfig(int sysId, int val)
        {
            string strsql = @"UPDATE Basic_SystemConfig SET Delflag={1} WHERE ID={0}";
            strsql = string.Format(strsql, sysId, val);
            oleDb.DoCommand(strsql);
            return true;
        }
    }
}
