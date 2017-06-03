using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using WinMainUIFrame.Dao;

namespace WinMainUIFrame.ObjectModel.UserLogin
{
    public class Employee : AbstractObjectModel
    {

        public System.Data.DataTable GetEmpUserData(int[] deptId,string empName, PageInfo page)
        {
            return null;
        }

        /// <summary>
        /// 设置用户默认科室
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="defaultDeptId"></param>
        public void SetDefaultEmpDeptRole(int empId,int defaultDeptId)
        {
            NewDao<UserDao>().SetDefaultEmpDeptRole(empId, defaultDeptId);
        }

        /// <summary>
        /// 设置用户所管辖科室
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="deptId"></param>
        public void SetHaveEmpDeptRole(int empId, int[] deptId)
        {
            NewDao<UserDao>().SetHaveEmpDeptRole(empId, deptId);
        }

        public bool IsAdmin(int empId)
        {
            return NewDao<UserDao>().IsAdmin(empId);
        }


    }
}
