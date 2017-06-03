using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 执行单配置数据访问接口
    /// </summary>
    public interface IBasicDataExceBillDao
    {
        /// <summary>
        /// 获取执行单配置列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <param name="py">拼音码</param>
        /// <param name="wb">五笔码</param>
        /// <returns>执行单配置列表</returns>
        DataTable GetExecBillInfo(int workID,string name, string py, string wb);

        /// <summary>
        /// 验证执行单名是否重复
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <returns>执行单信息</returns>
        DataTable CheckExecBillName(int workID, string name);

        /// <summary>
        /// 获取用法列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <returns>用法列表</returns>
        DataTable GetChannelInfo(int workID);

        /// <summary>
        /// 获取执行单关联的用法列表
        /// </summary>
        /// <param name="billID">执行单ID</param>
        /// <param name="workID">机构ID</param>
        /// <returns>执行单关联的用法列表</returns>
        DataTable GetExecuteBillChannel(int billID, int workID);

        /// <summary>
        /// 删除执行单关联用法
        /// </summary>
        /// <param name="id">执行单ID</param>
        /// <returns>删除的行数</returns>
        int DelChannel(string id);

        /// <summary>
        /// 删除执行单信息
        /// </summary>
        /// <param name="id">执行单ID</param>
        /// <param name="useFlag">删除标志</param>
        /// <param name="workID">机构ID</param>
        /// <returns>删除的行数</returns>
        int UpdateUseFlag(int id, int useFlag,int workID);
    }
}
