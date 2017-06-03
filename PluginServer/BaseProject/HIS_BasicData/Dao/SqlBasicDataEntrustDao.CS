using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 嘱托维护数据访问对象
    /// </summary>
    public class SqlBasicDataEntrustDao : AbstractDao, IBasicDataEntrustDao
    {
        /// <summary>
        /// 获取嘱托列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        /// <returns>嘱托列表</returns>
        public DataTable GetEntrustList(int workID, string name)
        {
            string sqlStr = "select EntrustID,EntrustName,PYCode,WBCode,DelFlag,WorkID, (CASE DelFlag WHEN 0 THEN '使用中' ELSE '停用' END) AS UseFalgDesc from Basic_Entrust  where 1=1";
            if (workID>0)
            {
                sqlStr = sqlStr + "  AND WorkID="+ workID;
            }

            if (string.IsNullOrEmpty(name) ==false)
            {
                sqlStr = sqlStr + "  AND (EntrustName like '%" + name + "%' or pycode like '%" + name + "%' or wbcode like '%" + name + "%')";
            }

            sqlStr = sqlStr + " ORDER BY EntrustID ";
            return oleDb.GetDataTable(@sqlStr);
        }

        /// <summary>
        /// 检查嘱托是否重复
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="entrustID">嘱托ID</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        public bool CheckEntrustName(string name,int entrustID,int workID)
        {
            string sqlStr = " select EntrustID from Basic_Entrust where EntrustName = '" + name + "' AND workID="+ workID;
             
            DataTable dt = oleDb.GetDataTable(@sqlStr);
            if (dt.Rows.Count>0)
            {
                if (entrustID > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["EntrustID"]) == entrustID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
