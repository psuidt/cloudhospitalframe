using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Orm;

namespace HIS_PublicManage.ObjectModel
{
   public static class EntityTableManage
    {
        /// <summary>
        /// 根据表实体 获取表名称 
        /// </summary>
        /// <typeparam name="T">表实体对象  T必须有TableName 的Attributes 标识</typeparam>
        /// <returns>表名 </returns>
        public static string GetTableName<T>() where T : AbstractEntity
       {
            var prop = typeof(T).GetCustomAttributes().FirstOrDefault(i => i.GetType() == typeof(TableAttribute));
            if (prop!=null && prop.GetType().GetProperty("TableName") != null)
            {
               return prop.GetType().GetProperty("TableName").GetValue(prop).ToString();
            }
            else
            {
                throw  new ArgumentException("非表实体对象");
            }
       }
    }
}
