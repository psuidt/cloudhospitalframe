using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.FeeItem;
using HIS_Entity.BasicData;
using HIS_Entity.BasicData.BusiEntity;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 收费项目维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmFeeItem")]//与系统菜单对应
    [WinformView(Name = "FrmFeeItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FeeItem.FrmFeeItem")]
    //[WinformView(Name = "FrmHospFeeItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FeeItem.FrmHospFeeItem")]
    [WinformView(Name = "FrmRelFeeItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FeeItem.FrmRelFeeItem")]
    public class FeeItemController : WcfClientController
    {
        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
        }

        #region CenterFeeItem

        /// <summary>
        /// 加载中心收费项目列表
        /// </summary>
        /// <param name="iAudit">审核状态</param>
        /// <param name="iStop">停用或启用标志</param>
        /// <param name="workId">机构ID</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="iStatID">统计大类ID</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">总页数</param>
        /// <param name="frmFI">收费项目</param>
        [WinformMethod]
        public void LoadCenterFeeItem(int iAudit, int iStop, int workId, string strKey, int iStatID, int pageIndex, int pageSize, IFrmFeeItem frmFI)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "GetCenterFeeItems",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(iAudit);
                    request.AddData(iStop);
                    request.AddData(strKey);
                    request.AddData(iStatID);
                    request.AddData(pageIndex);
                    request.AddData(pageSize);
                });

            var cfeeitems = retdata.GetData<List<Basic_CenterFeeItem>>(0);
            var totalCount = retdata.GetData<int>(1);
            frmFI.LoadFeeItem(cfeeitems, totalCount);
        }

        /// <summary>
        /// 加载中心收费项目
        /// </summary>
        /// <param name="iCenterFeeItem">中心收费项目ID</param>
        /// <param name="frmFI">收费项目</param>
        [WinformMethod]
        public void LoadCFeeItem(int iCenterFeeItem, IFrmFeeItem frmFI)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "GetCenterFeeItem",
                (request) =>
                {
                    request.AddData(iCenterFeeItem);
                });

            var cfeeitem = retdata.GetData<Basic_CenterFeeItem>(0);
            frmFI.LoadCenterFeeItem(cfeeitem);
        }

        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        /// <param name="frmFI">收费项目接口</param>
        [WinformMethod]
        public void LoadBasicWorkers(IFrmFeeItem frmFI)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WorkerController",
                "GetWorkers",
                (request) =>
                {
                    request.AddData(false);
                });

            var workers = retdata.GetData<List<BaseWorkers>>(0);
            frmFI.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 启用与停用中心收费项目
        /// </summary>
        /// <param name="cfiId">ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string FlagCFeeItem(int cfiId, int delFlag)
        {
            if (delFlag == (int)IsStopType.Enabled)
            {
                delFlag = (int)IsStopType.Disabled;
            }
            else
            {
                delFlag = (int)IsStopType.Enabled;//0为启用,1为停用
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "FlagCFeeItem",
                (request) =>
                {
                    request.AddData(cfiId);
                    request.AddData(delFlag);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 审核与反审核中心收费项目
        /// </summary>
        /// <param name="cfiId">ID</param>
        /// <param name="auditFlag">状态</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string AuditCFeeItem(int cfiId, int auditFlag)
        {
            if (auditFlag == (int)AuditType.Audited)
            {
                auditFlag = (int)AuditType.UnAudit;
            }
            else
            {
                auditFlag = (int)AuditType.Audited;//0为未审核,1为已审核
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "AuditCFeeItem",
                (request) =>
                {
                    request.AddData(cfiId);
                    request.AddData(auditFlag);
                    request.AddData(GetUserInfo().UserId);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 保存中心收费项目
        /// </summary>
        /// <param name="cfeeitem">中心收费项目</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string SaveCFeeItem(Basic_CenterFeeItem cfeeitem)
        {
            try
            {
                var userinfo = GetUserInfo();
                cfeeitem.CreateWorkID = userinfo.WorkId;
                cfeeitem.ModEmpID = userinfo.UserId;
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "FeeItemController",
                    "SaveCenterFeeItem",
                    (request) =>
                    {
                        request.AddData(cfeeitem);
                    });

                var ret = retdata.GetData<string>(0);
                return ret;
            }
            catch (Exception ex)
            {
                MessageBoxShowError(ex.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取下拉框数据源
        /// </summary>
        /// <param name="frmFI">收费项目接口</param>
        [WinformMethod]
        public void LoadBasicData(IFrmFeeItem frmFI)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "GetBasicData",
                (request) =>
                {
                });

            var dtStatID = retdata.GetData<DataTable>(0);
            frmFI.LoadBasicData(dtStatID);
        }

        /// <summary>
        /// 弹出关联中心收费项目的窗口
        /// </summary>
        /// <param name="cfeeitemid">ID</param>
        /// <returns>中心收费项目</returns>
        [WinformMethod]
        public Basic_CenterFeeItem RelCFeeItems(int cfeeitemid)
        {
            var iobj = ((IFrmRelFeeItem)iBaseView["FrmRelFeeItem"]);
            iobj.WorkerId = LoginUserInfo.WorkId;
            iobj.CFeeItemID = cfeeitemid;
            (iBaseView["FrmRelFeeItem"] as Form).ShowDialog();
            if (iobj.CFeeItemID == -1)
            {
                return iobj.Result;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region HospFeeItem

        /// <summary>
        /// 加载本院收费项目列表
        /// </summary>
        /// <param name="iStatID">统计大类ID</param>
        /// <param name="iStop">状态</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">总页数</param>
        /// <param name="frmFI">收费项目接口</param>
        [WinformMethod]
        public void LoadHospFeeItem(int iStatID, int iStop, string strKey, int pageIndex, int pageSize, IFrmFeeItem frmFI)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "GetHospFeeItems",
                (request) =>
                {
                    request.AddData(LoginUserInfo.WorkId);
                    request.AddData(iStatID);
                    request.AddData(iStop);
                    request.AddData(strKey);
                    request.AddData(pageIndex);
                    request.AddData(pageSize);
                });

            var hfeeitems = retdata.GetData<List<Basic_HospFeeItem>>(0);
            var totalCount = retdata.GetData<int>(1);
            frmFI.LoadFeeItem(hfeeitems, totalCount);
        }

        /// <summary>
        /// 保存本院收费项目
        /// </summary>
        /// <param name="hfeeitem">本院收费项目</param>
        /// <param name="cfeeitem">中心收费项目</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string SaveHFeeItem(Basic_HospFeeItem hfeeitem, Basic_CenterFeeItem cfeeitem)
        {
            try
            {
                var userinfo = GetUserInfo();
                cfeeitem.CreateWorkID = userinfo.WorkId;
                cfeeitem.ModEmpID = userinfo.UserId;
                hfeeitem.ModEmpID = userinfo.UserId;
                hfeeitem.CenterItemID = cfeeitem.FeeID;
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "FeeItemController",
                    "SaveHospFeeItem",
                    (request) =>
                    {
                        request.AddData(hfeeitem);
                        request.AddData(cfeeitem);
                    });
                var ret = retdata.GetData<string>(0);
                return ret;
            }
            catch (Exception ex)
            {
                MessageBoxShowError(ex.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// 启用与停用本院收费项目
        /// </summary>
        /// <param name="hfiId">ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string FlagHFeeItem(int hfiId, int delFlag)
        {
            if (delFlag == (int)IsStopType.Enabled)
            {
                delFlag = (int)IsStopType.Disabled;
            }
            else
            {
                delFlag = (int)IsStopType.Enabled;//0为启用,1为停用
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "FlagHFeeItem",
                (request) =>
                {
                    request.AddData(hfiId);
                    request.AddData(delFlag);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }
        #endregion
    }
}
