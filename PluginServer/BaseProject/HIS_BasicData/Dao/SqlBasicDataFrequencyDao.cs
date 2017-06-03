using System.Data;
using System.Text;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 频次维护数据访问对象
    /// </summary>
    public class SqlBasicDataFrequencyDao: AbstractDao, IBasicFrequencyDao
    {
        /// <summary>
        /// 获取频次信息
        /// </summary>
        /// <param name="name">检索条件</param>
        /// <param name="pyCode">拼音码</param>
        /// <param name="wbCode">五笔码</param>
        /// <param name="workID">机构ID</param>
        /// <returns>频次信息</returns>
        public DataTable QueryFrequencyInfo(string name, string pyCode, string wbCode,int workID)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" select FrequencyID,FrequencyName,CName,EName,PYCode,WBCode,WestDrug,MidDrug,ExecuteType,ExecuteCode,SortOrder,DelFlag,");
            sqlStr.Append(" (CASE WestDrug WHEN 0 THEN '' ELSE '适用' END) AS WestDrugDesc, ");
            sqlStr.Append(" (CASE MidDrug WHEN 0 THEN '' ELSE '适用' END) AS MidDrugDesc, ");
            sqlStr.Append(" WorkID,(CASE DelFlag WHEN 0 THEN '使用中' ELSE '停用' END) AS UseFalgDesc from Basic_Frequency ");
            sqlStr.Append(" where (FrequencyName like '%"+ name+ "%' or PYCode like '%"+ pyCode+ "%' or WBCode like '%"+ wbCode+ "%') AND WorkID="+ workID);
            sqlStr.Append(" order by FrequencyID");
            return oleDb.GetDataTable(sqlStr.ToString());
        }

        /// <summary>
        /// 用于检查是否有频次名称相同的数据集
        /// </summary>
        /// <param name="name">频次名</param>
        /// <param name="workID">机构ID</param>
        /// <returns>频次信息</returns>
        public DataTable CheckFrequencyName(string name,int workID)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" select FrequencyID,FrequencyName,CName,EName,PYCode,WBCode,WestDrug,MidDrug,ExecuteType,ExecuteCode,SortOrder,DelFlag,");
            sqlStr.Append(" WorkID,(CASE DelFlag WHEN 0 THEN '使用中' ELSE '停用' END) AS UseFalgDesc from Basic_Frequency ");
            sqlStr.Append(" where FrequencyName = '" + name + "' AND  WorkID = " + workID);
            sqlStr.Append(" order by FrequencyID");
            return oleDb.GetDataTable(sqlStr.ToString());
        }
    }
}
