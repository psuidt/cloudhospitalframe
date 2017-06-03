using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.SqlAly;
using HIS_PublicManage.ObjectModel;

namespace HIS_PublicManage.CommonSql
{
    public class SqlServerProcess
    {
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <typeparam name="T">表实体对象</typeparam>
        /// <param name="andWhere">and 条件</param>
        /// <param name="orWhere">OR 条件 </param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetExecutSql<T>(List<Tuple<string, string, SqlOperator>> andWhere = null, List<Tuple<string, string, SqlOperator>> orWhere = null
            ) where T : AbstractEntity
        {
            StringBuilder stb = new StringBuilder();
            stb.AppendFormat("select * from {0} where 1=1", EntityTableManage.GetTableName<T>());
            stb.Append(GetCondition(andWhere, orWhere));
            return stb.ToString();
        }

        /// <summary>
        /// 查询条件构造
        /// </summary>
        /// <param name="andWhere"></param>
        /// <param name="orWhere"></param>
        /// <returns></returns>
        public static String GetCondition(List<Tuple<string, string, SqlOperator>> andWhere = null, List<Tuple<string, string, SqlOperator>> orWhere = null)
        {
            StringBuilder stb = new StringBuilder();
            if (andWhere != null)
            {
                foreach (var kp in andWhere)
                {
                    stb.AppendFormat(" and {0} ", ProcessSqlEnum(kp.Item1, kp.Item2, kp.Item3));
                }
            }
            if (orWhere != null && orWhere.Count > 0)
            {
                stb.Append(" AND ( ");
                var t = 0;
                foreach (var kp in orWhere)
                {
                    if (t == 0)
                    {
                        stb.AppendFormat(ProcessSqlEnum(kp.Item1, kp.Item2, kp.Item3));
                    }
                    else
                    {

                        stb.AppendFormat(" or {0} ", ProcessSqlEnum(kp.Item1, kp.Item2, kp.Item3));
                    }
                    ++t;
                }
                stb.Append(" ) ");
            }
            return stb.ToString();
        }


        public static string ProcessSqlEnum(string key, string value, SqlOperator op)
        {
            switch (op)
            {
                case SqlOperator.Equal:
                    return String.Format(" {0} = '{1}' ", key, value);
                case SqlOperator.Large:
                    return String.Format(" {0} > '{1}' ", key, value);
                case SqlOperator.Like:
                    return String.Format(" {0} like '{1}%' ", key, value);
                case SqlOperator.Less:
                    return String.Format(" {0} < '{1}' ", key, value);
                case SqlOperator.NoEqual:
                    return String.Format(" {0} != '{1}' ", key, value);
                case SqlOperator.In:
                    return String.Format(" {0} in ({1}) ", key, value);
                default:
                    return String.Format(" {0} = '{1}' ", key, value);
            }
        }
    }
}
