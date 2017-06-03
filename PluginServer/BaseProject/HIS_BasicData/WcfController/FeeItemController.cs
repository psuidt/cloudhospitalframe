using System;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_Entity.BasicData.BusiEntity;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 收费项目维护控制器
    /// </summary>
    [WCFController]
    public class FeeItemController : WcfServerController
    {
        #region CenterFeeItem

        /// <summary>
        /// 根据机构ID获取中心收费项目列表
        /// </summary>
        /// <returns>中心收费项目列表</returns>
        [WCFMethod]
        public ServiceResponseData GetCenterFeeItems()
        {
            var workId = requestData.GetData<int>(0);
            var iAudit = requestData.GetData<int>(1);
            var iStop = requestData.GetData<int>(2);
            var strKey = requestData.GetData<string>(3);
            var iStatID = requestData.GetData<int>(4);
            var pageIndex = requestData.GetData<int>(5);
            var pageSize = requestData.GetData<int>(6);
            var page = new PageInfo(pageSize, pageIndex);
            var cfeeitems = NewDao<IBasicDataFeeItemDao>().GetCenterFeeItemList(workId, iAudit, iStop, strKey, iStatID, ref page);
            responseData.AddData(cfeeitems);
            responseData.AddData(page.totalRecord);
            return responseData;
        }

        /// <summary>
        /// 根据中心收费项目ID获取中心收费项目
        /// </summary>
        /// <returns>中心收费项目列表</returns>
        [WCFMethod]
        public ServiceResponseData GetCenterFeeItem()
        {
            var cfeeitemid = requestData.GetData<int>(0);
            var cfeeitem = NewDao<IBasicDataFeeItemDao>().GetCenterFeeItem(cfeeitemid);
            responseData.AddData(cfeeitem);
            return responseData;
        }

        /// <summary>
        /// 启用与停用中心收费项目
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData FlagCFeeItem()
        {
            var cfiId = requestData.GetData<int>(0);
            var delFlag = requestData.GetData<int>(1);
            NewDao<IBasicDataFeeItemDao>().FlagCFeeItem(cfiId, delFlag);
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 审核与反审核中心收费项目
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData AuditCFeeItem()
        {
            var cfiId = requestData.GetData<int>(0);
            var auditFlag = requestData.GetData<int>(1);
            var auditor = requestData.GetData<int>(2);
            NewDao<IBasicDataFeeItemDao>().AuditCFeeItem(cfiId, auditFlag, auditor);
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 保存中心收费项目信息
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveCenterFeeItem()
        {
            var cfeeitem = requestData.GetData<Basic_CenterFeeItem>(0);
            if (cfeeitem.FeeID <= 0)
            {
                cfeeitem.IsStop = 0;
            }

            cfeeitem.AuditStatus = (int)AuditType.UnAudit;
            cfeeitem.CusCode = string.Empty;
            cfeeitem.PyCode = SpellAndWbCode.GetSpellCode(cfeeitem.CenterItemName);
            cfeeitem.WbCode = SpellAndWbCode.GetWBCode(cfeeitem.CenterItemName);
            cfeeitem.ModDate = DateTime.Now;
            this.BindDb(cfeeitem);
            cfeeitem.save();

            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <returns>大项目代码列表</returns>
        [WCFMethod]
        public ServiceResponseData GetBasicData()
        {
            var manage = NewObject<BasicDataManagement>();
            var dtStatID = manage.GetStatItem(false);
            responseData.AddData(dtStatID);

            return responseData;
        }

        #endregion

        #region HospFeeItem

        /// <summary>
        /// 根据机构ID获取本院收费项目列表
        /// </summary>
        /// <returns>本院收费项目列表</returns>
        [WCFMethod]
        public ServiceResponseData GetHospFeeItems()
        {
            var workId = requestData.GetData<int>(0);
            var iStatID = requestData.GetData<int>(1);
            var iStop = requestData.GetData<int>(2);
            var strKey = requestData.GetData<string>(3);
            var pageIndex = requestData.GetData<int>(4);
            var pageSize = requestData.GetData<int>(5);
            var page = new PageInfo(pageSize, pageIndex);
            var hfeeitems = NewDao<IBasicDataFeeItemDao>().GetHospFeeItemList(workId, iStatID, iStop, strKey, ref page);
            responseData.AddData(hfeeitems);
            responseData.AddData(page.totalRecord);
            return responseData;
        }

        /// <summary>
        /// 保存本院收费项目信息
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveHospFeeItem()
        {
            var hfeeitem = requestData.GetData<Basic_HospFeeItem>(0);
            var cfeeitem = requestData.GetData<Basic_CenterFeeItem>(1);
            if (cfeeitem.FeeID <= 0)
            {
                cfeeitem.IsStop = (int)IsStopType.Enabled;
                cfeeitem.AuditStatus = (int)AuditType.UnAudit;
                cfeeitem.CusCode = string.Empty;
                cfeeitem.PyCode = SpellAndWbCode.GetSpellCode(cfeeitem.CenterItemName);
                cfeeitem.WbCode = SpellAndWbCode.GetWBCode(cfeeitem.CenterItemName);
                cfeeitem.ModDate = DateTime.Now;
                this.BindDb(cfeeitem);
                cfeeitem.save();
            }

            hfeeitem.CenterItemID = cfeeitem.FeeID;
            hfeeitem.ItemCode = cfeeitem.CenterItemCode;
            hfeeitem.ItemName = cfeeitem.CenterItemName;
            hfeeitem.IsStop = (int)IsStopType.Enabled;
            hfeeitem.CusCode = string.Empty;
            hfeeitem.PyCode = SpellAndWbCode.GetSpellCode(hfeeitem.AliasName);
            hfeeitem.WbCode = SpellAndWbCode.GetWBCode(hfeeitem.AliasName);
            //hfeeitem.StatID = cfeeitem.StatID;
            hfeeitem.ModDate = DateTime.Now;
            BindDb(hfeeitem);
            hfeeitem.save();

            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 启用与停用本院收费项目
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData FlagHFeeItem()
        {
            var hfiId = requestData.GetData<int>(0);
            var delFlag = requestData.GetData<int>(1);
            NewDao<IBasicDataFeeItemDao>().FlagHFeeItem(hfiId, delFlag);
            responseData.AddData("OK");
            return responseData;
        }
        
        #endregion
    }
}
