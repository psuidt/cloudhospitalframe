using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 通用函数
    /// </summary>
    public class CommonFunctions
    {
        ///// <summary>
        ///// 将DataTable里面时间类型列的初始化值改为NULL
        ///// </summary>
        ///// <param name="dtSource">需要改的DataTable</param>
        ///// <param name="colNames">时间类型列集合</param>
        //public static void ChangeDateTimeNullValue(ref DataTable dtSource,List<string> colNames)
        //{
        //    foreach (DataRow dr in dtSource.Rows)
        //    {
        //        foreach (string colName in colNames)
        //        {
        //            dr[colName] = (dr[colName].ToString().Trim().Contains("0001-01-01") || dr[colName].ToString().Trim().Contains("1900-01-01")) ? DBNull.Value : dr[colName];
        //        }
        //    }
        //}
    }
}
