using System.Collections.Generic;
using System.Data;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 病区数据访问接口
    /// </summary>
    public interface IBasicDataWardDao
    {
        /// <summary>
        /// 根据机构ID,科室ID获取病区列表
        /// </summary>
        /// <param name="name">检索条件</param>
        /// <param name="workId">机构ID</param>
        /// <param name="showAll">是否显示全部</param>
        /// <returns>病区列表</returns>
        List<BaseWard> GetWardList(string name, int workId, bool showAll);

        /// <summary>
        /// 启用与停用病区
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>true：操作成功</returns>
        bool FlagWard(int wardId, int delFlag);

        /// <summary>
        /// 加载病区关联的科室
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="isAll">是否显示所有</param>
        /// <returns>病区关联科室列表</returns>
        DataTable GetWardRelDepts(int workId, int wardId, bool isAll);

        /// <summary>
        /// 加载病区关联的人员
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="isAll">是否显示所有</param>
        /// <returns>病区关联的人员列表</returns>
        DataTable GetWardRelEmps(int workId, int wardId, bool isAll);
    }
}
