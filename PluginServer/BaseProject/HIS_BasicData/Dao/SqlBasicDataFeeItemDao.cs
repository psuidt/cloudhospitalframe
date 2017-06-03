using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 中心收费项目数据访问对象
    /// </summary>
    public class SqlBasicDataFeeItemDao : AbstractDao, IBasicDataFeeItemDao
    {
        /// <summary>
        /// 审核与反审核中心收费项目
        /// </summary>
        /// <param name="cfiId">项目ID</param>
        /// <param name="auditFlag">审核标志</param>
        /// <param name="auditor">操作员ID</param>
        /// <returns>true：操作成功</returns>
        public bool AuditCFeeItem(int cfiId, int auditFlag, int auditor)
        {
            var datetime = DateTime.Now;
            var strSql = " UPDATE Basic_CenterFeeItem SET AuditStatus = {0}, Auditor = '{1}', AuditTime = '{2}' WHERE FeeID = {3} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, auditFlag, auditor, datetime, cfiId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 启用与停用本院收费项目
        /// </summary>
        /// <param name="hfiId">本元项目ID</param>
        /// <param name="delFlag">删除标志</param>
        /// <returns>true：操作成功</returns>
        public bool FlagHFeeItem(int hfiId, int delFlag)
        {
            var strSql = " UPDATE Basic_HospFeeItem SET IsStop = {0} WHERE ItemID = {1} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, delFlag, hfiId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 启用与停用中心收费项目
        /// </summary>
        /// <param name="cfiId">收费项目ID</param>
        /// <param name="delFlag">删除状态</param>
        /// <returns>true“删除成功</returns>
        public bool FlagCFeeItem(int cfiId, int delFlag)
        {
            var strSql = " UPDATE Basic_CenterFeeItem SET IsStop = {0} WHERE FeeID = {1} ";
            var count = oleDb
                .Query<int>(string.Format(strSql, delFlag, cfiId), string.Empty)
                .FirstOrDefault();
            return count > 0;
        }

        /// <summary>
        /// 根据中心收费项目ID获取中心收费项目
        /// </summary>
        /// <param name="cfeeitemid">中心收费项目ID</param>
        /// <returns>中心收费项目</returns>
        public Basic_CenterFeeItem GetCenterFeeItem(int cfeeitemid)
        {
            var strSql = @" SELECT 
	            FeeID,
	            CenterItemCode,
	            CenterItemName,
	            PyCode,
	            WbCode,
	            CusCode,
	            Unit,
	            Price,
	            Explain,
	            StatID,
                dbo.fnGetStatItemName(StatID) AS StatName,
	            MreType,
	            ModEmpID,
	            ModDate,
	            CreateWorkID,
	            AuditStatus,
	            Auditor,
	            AuditTime,
	            IsStop,
	            WorkID
            FROM Basic_CenterFeeItem
            WHERE FeeID = {0} ";
            return oleDb
                .Query<Basic_CenterFeeItem>(string.Format(strSql, cfeeitemid), string.Empty)
                .FirstOrDefault();
        }

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
        public List<Basic_CenterFeeItem> GetCenterFeeItemList(int workId, int iAudit, int iStop, string strKey, int iStatID, ref PageInfo page)
        {
            var strSql = @" SELECT 
	            FeeID,
	            CenterItemCode,
	            CenterItemName,
	            PyCode,
	            WbCode,
	            CusCode,
	            Unit,
	            Price,
	            Explain,
	            StatID,
                dbo.fnGetStatItemName(StatID) AS StatName,
	            MreType,
	            ModEmpID,
	            ModDate,
	            CreateWorkID,
	            AuditStatus,
	            Auditor,
	            AuditTime,
	            IsStop,
	            WorkID
            FROM Basic_CenterFeeItem
            WHERE 1 = 1 {0} ";
            var strWhere = new StringBuilder();
            if (workId != 0)
            {
                strWhere.Append(string.Format(" AND CreateWorkID = {0} ", workId));
            }

            if (!string.IsNullOrEmpty(strKey))
            {
                strWhere.Append(string.Format(" AND ( FeeID LIKE '{0}' OR CenterItemCode LIKE '%{0}%' OR CenterItemName LIKE '%{0}%' OR PyCode LIKE '%{0}%' OR WbCode LIKE '%{0}%' ) ", strKey));
            }

            if (iAudit != 9)
            {
                strWhere.Append(string.Format(" AND AuditStatus = {0} ", iAudit));
            }

            if (iStop != 9)
            {
                strWhere.Append(string.Format(" AND IsStop = {0} ", iStop));
            }

            if (iStatID != 0 && iStatID != -1)
            {
                strWhere.Append(string.Format(" AND StatID = {0} ", iStatID));
            }

            page.KeyName = "FeeID";
            return oleDb
                .Query<Basic_CenterFeeItem>(SqlPage.FormatSql(string.Format(strSql, strWhere), page, oleDb), string.Empty)
                .ToList();
        }

        /// <summary>
        /// 根据机构ID获取本院收费项目列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="iStatID">统计大类ID</param>
        /// <param name="iStop">停用标志</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="page">分页</param>
        /// <returns>本院收费项目列表</returns>
        public List<Basic_HospFeeItem> GetHospFeeItemList(int workId, int iStatID, int iStop, string strKey, ref PageInfo page)
        {
            var strSql = @" SELECT 
	            ItemID,
	            CenterItemID,
	            cfi.CenterItemCode AS ItemCode,
	            cfi.CenterItemName AS ItemName,
	            AliasName,
	            hfi.PyCode,
	            hfi.WbCode,
	            hfi.CusCode,
	            hfi.Price,
	            One_level,
	            Two_level,
	            Three_level,
	            hfi.StatID,
                dbo.fnGetStatItemName(hfi.StatID) AS StatName,
	            IsBle,
	            hfi.ModEmpID,
	            hfi.ModDate,
	            hfi.IsStop,
	            hfi.WorkID,
                hfi.MedicateID
            FROM Basic_HospFeeItem hfi
            INNER JOIN Basic_CenterFeeItem cfi ON hfi.CenterItemID = cfi.FeeID AND hfi.WorkID = cfi.WorkID
            WHERE 1 = 1 {0} ";
            var strWhere = new StringBuilder();
            if (workId != 0)
            {
                strWhere.Append(string.Format(" AND hfi.WorkID = {0} ", workId));
            }

            if (!string.IsNullOrEmpty(strKey))
            {
                strWhere.Append(string.Format(" AND ( cfi.CenterItemCode LIKE '%{0}%' OR cfi.CenterItemName LIKE '%{0}%' OR AliasName LIKE '%{0}%' OR hfi.PyCode LIKE '%{0}%' OR hfi.WbCode LIKE '%{0}%' ) ", strKey));
            }

            if (iStatID != 0 && iStatID != -1)
            {
                strWhere.Append(string.Format(" AND hfi.StatID = {0} ", iStatID));
            }

            if (iStop != 9)
            {
                strWhere.Append(string.Format(" AND hfi.IsStop = {0} ", iStop));
            }

            page.KeyName = "ItemID";
            return oleDb
                .Query<Basic_HospFeeItem>(SqlPage.FormatSql(string.Format(strSql, strWhere), page, oleDb), string.Empty)
                .ToList();
        }
    }
}
