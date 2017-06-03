using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 组合项目数据访问接口
    /// </summary>
    public interface IBasicDataExamItemDao
    {
        /// <summary>
        /// 获取分类
        /// </summary>
        /// <returns>组合项目分类</returns>
        DataTable GetExamClass();

        /// <summary>
        /// 获取组合项目类型列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examclass">分类</param>
        /// <returns>组合项目类型列表</returns>
        DataTable GetExamType(int workId,int examclass);

        /// <summary>
        /// 获取组合项目
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examtypeId">组合项目类型ID</param>
        /// <param name="searchStr">检索条件</param>
        /// <returns>组合项目列表</returns>
        DataTable GetExamItem(int workId, int examtypeId, string searchStr);

        /// <summary>
        /// 获取组合项目费用
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        /// <returns>组合项目费用列表</returns>
        DataTable GetExamFee(int examitemId);

        /// <summary>
        /// 删除组合项目类型
        /// </summary>
        /// <param name="examtypeId">组合项目类型ID</param>
        /// <returns>true：删除成功</returns>
        bool DeleteExamType(int examtypeId);

        /// <summary>
        /// 删除组合项目
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        /// <returns>true删除成功</returns>
        bool DeleteExamItem(int examitemId);

        /// <summary>
        /// 删除组合项目关联费用
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        /// <returns>true删除成功</returns>
        bool DeleteExamFee(int examitemId);
    }
}
