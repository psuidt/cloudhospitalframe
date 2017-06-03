using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.FeeItem;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 本院收费项目维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "frmHospFeeItemManage")]
    [WinformView(Name = "frmHospFeeItemManage", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FeeItem.frmHospFeeItemManage")]
    [WinformView(Name = "FrmRelFeeItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FeeItem.FrmRelFeeItem")]
    public class HospFeeItemManageController : WcfClientController
    {
        /// <summary>
        /// 本院收费项目接口
        /// </summary>
        IHospFeeItemManage hospFeeItemManage;

        /// <summary>
        /// 关联中心收费项目接口
        /// </summary>
        IFrmRelFeeItem relFeeItem;

        /// <summary>
        /// 基础数据集合
        /// </summary>
        private DataTable baseDataDt = new DataTable();

        /// <summary>
        /// 初始化控制器
        /// </summary>
        public override void Init()
        {
            hospFeeItemManage = (IHospFeeItemManage)DefaultView;
            relFeeItem = iBaseView["FrmRelFeeItem"] as IFrmRelFeeItem;
        }

        /// <summary>
        /// 异步加载数据
        /// </summary>
        public override void AsynInit()
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "FeeItemController",
               "GetBasicData",
               (request) =>
               {
               });

            baseDataDt = retdata.GetData<DataTable>(0);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public override void AsynInitCompleted()
        {
            // 绑定基础数据
            hospFeeItemManage.Bind_BasicData(baseDataDt);
        }

        /// <summary>
        /// 加载本院收费项目列表
        /// </summary>
        /// <param name="iStatID">项目分类ID</param>
        /// <param name="iStop">项目状态</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">总页数</param>
        [WinformMethod]
        public void LoadHospFeeItem(int iStatID, int iStop, string strKey, int pageIndex, int pageSize)
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

            List<Basic_HospFeeItem> hfeeitems = retdata.GetData<List<Basic_HospFeeItem>>(0);
            int totalCount = retdata.GetData<int>(1);
            hospFeeItemManage.Bind_HostFeeItemList(hfeeitems, totalCount);
        }

        /// <summary>
        /// 加载中心收费项目
        /// </summary>
        /// <param name="iCenterFeeItem">中心收费项目ID</param>
        [WinformMethod]
        public void LoadCFeeItem(int iCenterFeeItem)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "GetCenterFeeItem",
                (request) =>
                {
                    request.AddData(iCenterFeeItem);
                });

            Basic_CenterFeeItem cfeeitem = retdata.GetData<Basic_CenterFeeItem>(0);
            hospFeeItemManage.CurrentCFeeItem = cfeeitem;
        }

        /// <summary>
        /// 保存本院收费项目
        /// </summary>
        /// <returns>true：成功</returns>
        [WinformMethod]
        public bool SaveHFeeItem()
        {
            hospFeeItemManage.CurrentHFeeItem.ModEmpID = LoginUserInfo.EmpId;  // 操作用户ID
            hospFeeItemManage.CurrentCFeeItem.CreateWorkID = LoginUserInfo.WorkId;  // 保存的中心收费项目机构ID
            hospFeeItemManage.CurrentCFeeItem.ModEmpID = LoginUserInfo.EmpId;  // 操作用户ID
            // 保存本院收费项目
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "SaveHospFeeItem",
                (request) =>
                {
                    request.AddData(hospFeeItemManage.CurrentHFeeItem);
                    request.AddData(hospFeeItemManage.CurrentCFeeItem);
                });

            MessageBoxShowSimple("本院收费项目保存成功！");
            return true;
        }

        /// <summary>
        /// 启用与停用本院收费项目
        /// </summary>
        /// <param name="hfiId">中心收费项目ID</param>
        /// <param name="delFlag">0：待停用/1：待启用</param>
        /// <returns>true：成功</returns>
        [WinformMethod]
        public bool FlagHFeeItem(int hfiId, int delFlag)
        {
            // 提示确认Msg
            string msg = string.Format("确定要{0}选中项目吗？", delFlag == 0 ? "停用" : "启用");
            if (MessageBoxShowYesNo(msg) != DialogResult.Yes)
            {
                return false;
            }

            // 停用或启用标志
            delFlag = delFlag == 0 ? 1 : 0;
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FeeItemController",
                "FlagHFeeItem",
                (request) =>
                {
                    request.AddData(hfiId);
                    request.AddData(delFlag);
                });

            return true;
        }

        #region "关联中心收费项目"

        /// <summary>
        /// 弹出关联中心收费项目的窗口
        /// </summary>
        /// <param name="cfeeitemid">项目ID</param>
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
        /// 加载中心收费项目列表
        /// </summary>
        /// <param name="iAudit">审核状态</param>
        /// <param name="iStop">停用标志</param>
        /// <param name="workId">机构ID</param>
        /// <param name="strKey">检索条件</param>
        /// <param name="iStatID">统计大类ID</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">总页数</param>
        /// <param name="frmFI">收费项目接口</param>
        [WinformMethod]
        public void LoadCenterFeeItem(
            int iAudit,
            int iStop,
            int workId,
            string strKey,
            int iStatID,
            int pageIndex,
            int pageSize,
            IFrmFeeItem frmFI)
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

        #endregion

        #region "共用方法"

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        [WinformMethod]
        public void MessageShow(string msg)
        {
            MessageBoxShowSimple(msg);
        }
        #endregion
    }
}
