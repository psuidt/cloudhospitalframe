using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 系统参数数据访问接口
    /// </summary>
    public interface IBasicDataParameterDao
    {
        /// <summary>
        /// 获取系统参数类型列表
        /// </summary>
        /// <returns>系统参数类型列表</returns>
        DataTable GetSystemTypeData();

        /// <summary>
        /// 获取系统参数列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="sysType">参数类型</param>
        /// <param name="searchKey">检索条件</param>
        /// <returns>系统参数列表</returns>
        DataTable GetSystemConfigData(int workID, int sysType, string searchKey);

        /// <summary>
        /// 删除系统参数
        /// </summary>
        /// <param name="sysId">参数ID</param>
        /// <param name="val">删除状态</param>
        /// <returns>true：删除成功</returns>
        bool SwitchSystemConfig(int sysId, int val);

        /// <summary>
        /// 是否存在此系统参数
        /// </summary>
        /// <param name="paraId">参数ID</param>
        /// <param name="workID">机构ID</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="sysType">参数类型</param>
        /// <returns>true：存在</returns>
        bool ExistSystemConfig(string paraId,int workID,int deptID,int sysType);
    }
}
