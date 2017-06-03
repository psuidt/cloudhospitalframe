using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 频次维护数据访问接口
    /// </summary>
    public interface IBasicFrequencyDao
    {
        /// <summary>
        /// 获取频次信息
        /// </summary>
        /// <param name="name">检索条件</param>
        /// <param name="pyCode">拼音码</param>
        /// <param name="wbCode">五笔码</param>
        /// <param name="workID">机构ID</param>
        /// <returns>频次信息</returns>
        DataTable QueryFrequencyInfo(string name, string pyCode, string wbCode, int workID);

        /// <summary>
        /// 用于检查是否有频次名称相同的数据集
        /// </summary>
        /// <param name="name">频次名</param>
        /// <param name="workID">机构ID</param>
        /// <returns>频次信息</returns>
        DataTable CheckFrequencyName(string name, int workID);
    }
}
