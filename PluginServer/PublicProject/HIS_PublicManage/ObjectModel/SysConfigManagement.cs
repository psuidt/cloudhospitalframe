using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 系统参数处理
    /// </summary>
    public class SysConfigManagement: AbstractObjectModel
    {
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="paraID"></param>
        /// <returns></returns>
        public string GetSystemConfigValue(string paraID)
        {
            return NewDao<IPublicManageDao>().GetSystemConfigValue(0, paraID);
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="deptID">科室ID</param>
        /// <param name="paraID">参数ID</param>
        /// <returns></returns>
        public string GetSystemConfigValue(int deptID,string paraID)
        {
            return NewDao<IPublicManageDao>().GetSystemConfigValue(deptID, paraID);
        }
    }
}
