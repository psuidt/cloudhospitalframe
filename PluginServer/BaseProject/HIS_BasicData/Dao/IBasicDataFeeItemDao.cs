using System.Collections.Generic;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 中心收费项目数据访问接口
    /// </summary>
    public interface IBasicDataFeeItemDao
    {
        /// <summary>
        /// 根据机构ID获取中心收费项目列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="iAudit">审核状态</param>
        /// <param name="iStop">停用状态</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="iStatID">统计大类ID</param>
        /// <param name="page">分页</param>
        /// <returns>收费项目列表</returns>
        List<Basic_CenterFeeItem> GetCenterFeeItemList(int workId, int iAudit, int iStop, string strKey, int iStatID, ref PageInfo page);

        /// <summary>
        /// 启用与停用中心收费项目
        /// </summary>
        /// <param name="cfiId">收费项目ID</param>
        /// <param name="delFlag">删除状态</param>
        /// <returns>true“删除成功</returns>
        bool FlagCFeeItem(int cfiId, int delFlag);

        /// <summary>
        /// 审核与反审核中心收费项目
        /// </summary>
        /// <param name="cfiId">项目ID</param>
        /// <param name="auditFlag">审核标志</param>
        /// <param name="auditor">操作员ID</param>
        /// <returns>true：操作成功</returns>
        bool AuditCFeeItem(int cfiId, int auditFlag, int auditor);

        /// <summary>
        /// 根据机构ID获取本院收费项目列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="iStatID">统计大类ID</param>
        /// <param name="iStop">停用标志</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="page">分页</param>
        /// <returns>本院收费项目列表</returns>
        List<Basic_HospFeeItem> GetHospFeeItemList(int workId, int iStatID, int iStop, string strKey, ref PageInfo page);

        /// <summary>
        /// 根据中心收费项目ID获取中心收费项目
        /// </summary>
        /// <param name="cfeeitemid">中心收费项目ID</param>
        /// <returns>中心收费项目</returns>
        Basic_CenterFeeItem GetCenterFeeItem(int cfeeitemid);

        /// <summary>
        /// 启用与停用本院收费项目
        /// </summary>
        /// <param name="hfiId">本元项目ID</param>
        /// <param name="delFlag">删除标志</param>
        /// <returns>true：操作成功</returns>
        bool FlagHFeeItem(int hfiId, int delFlag);
    }
}
