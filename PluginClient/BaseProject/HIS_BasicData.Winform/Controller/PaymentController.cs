using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;
using HIS_BasicData.Winform.IView.Payment;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 支付方式维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmPaymentMethodManage")]//与系统菜单对应
    [WinformView(Name = "FrmPaymentMethodManage", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.PaymentMethodManage.FrmPaymentMethodManage")]
    [WinformView(Name = "FrmpaymentMethodRelations", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.PaymentMethodManage.FrmpaymentMethodRelations")]
    public class PaymentController : WcfClientController
    {
        /// <summary>
        /// 支付方式维护接口
        /// </summary>
        IfrmPaymentMgr frmPaymentMgr;

        /// <summary>
        /// 支付方式组合接口
        /// </summary>
        IfrmPaymentRel frmPaymentRel;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmPaymentMgr = iBaseView["FrmPaymentMethodManage"] as IfrmPaymentMgr;
            frmPaymentRel = iBaseView["FrmpaymentMethodRelations"] as IfrmPaymentRel;
        }

        #region 中心支付方式

        /// <summary>
        /// 加载数据
        /// </summary>
        [WinformMethod]
        public void InitLoadData()
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "PaymentController",
            "GetPayInputFrom");

            DataTable dt = retdata.GetData<DataTable>(0);
            frmPaymentMgr.loadInputFromBox(dt);

            GetPaymentData();
        }

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        [WinformMethod]
        public void GetPaymentData()
        {
            var retdata = InvokeWcfService(
           "BaseProject.Service",
           "PaymentController",
           "GetPaymentData");

            DataTable dt = retdata.GetData<DataTable>(0);
            frmPaymentMgr.loadPaymentGrid(dt);
        }

        /// <summary>
        /// 停用支付方式
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="val">状态</param>
        [WinformMethod]
        public void StopPayment(int id, int val)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "PaymentController",
             "SwitchPayment",
             (request) =>
             {
                 request.AddData(id);
                 request.AddData(val);
             });
            MessageBoxShowSimple("操作成功！");
        }

        /// <summary>
        /// 保存支付方式
        /// </summary>
        [WinformMethod]
        public void SavePayment()
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "PaymentController",
              "SavePayment",
              (request) =>
              {
                  request.AddData(frmPaymentMgr.CurrPayment);
              });

            MessageBoxShowSimple("保存支付方式成功！");
        }

        #endregion

        /// <summary>
        /// 加载本院支付方式列表
        /// </summary>
        [WinformMethod]
        public void HospInitLoadData()
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "PaymentController",
            "GetWorkerData");
            List<BaseWorkers> workers = retdata.GetData<List<BaseWorkers>>(0);
            frmPaymentRel.loadWorkerDataBox(ConvertExtend.ToDataTable(workers), LoginUserInfo.WorkId);

            retdata = InvokeWcfService(
            "BaseProject.Service",
            "PaymentController",
            "GetPayTypeData");
            DataTable paydt = retdata.GetData<DataTable>(0);
            frmPaymentRel.loadSystemTypeBox(paydt);

            retdata = InvokeWcfService(
            "BaseProject.Service",
            "PaymentController",
            "GetPatTypeData");
            DataTable patdt = retdata.GetData<DataTable>(0);
            frmPaymentRel.loadPatTypeBox(patdt);

            retdata = InvokeWcfService(
           "BaseProject.Service",
           "PaymentController",
           "GetCenterPaymentData");
            DataTable cpaydt = retdata.GetData<DataTable>(0);
            frmPaymentRel.loadPaymentBox(cpaydt);
        }

        /// <summary>
        /// 获取本院支付方式
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="patTypeId">支付方式类型ID</param>
        [WinformMethod]
        public void GetHospPaymentData(int workId, int userType, int patTypeId)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "PaymentController",
             "GetHospPaymentData",
             (request) =>
             {
                 request.AddData(workId);
                 request.AddData(userType);
                 request.AddData(patTypeId);
             });

            DataTable dt = retdata.GetData<DataTable>(0);
            frmPaymentRel.loadHospPaymentGrid(dt);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="patTypeId">类型ID</param>
        /// <param name="paymentId">支付方式ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="payorder">排序</param>
        [WinformMethod]
        public void AddHospPayment(int workId, int patTypeId, int paymentId, int userType, int payorder)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "PaymentController",
             "AddHospPayment",
             (request) =>
             {
                 request.AddData(workId);
                 request.AddData(patTypeId);
                 request.AddData(paymentId);
                 request.AddData(userType);
                 request.AddData(payorder);
             });

            MessageBoxShowSimple("保存支付方式成功！");
        }

        /// <summary>
        /// 删除支付方式
        /// </summary>
        /// <param name="id">ID</param>
        [WinformMethod]
        public void DeleteHospPayment(int id)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "PaymentController",
             "DeleteHospPaymentData",
             (request) =>
             {
                 request.AddData(id);
             });

            MessageBoxShowSimple("删除支付方式成功！");
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="dtPayment">支付方式列表</param>
        [WinformMethod]
        public void SortPayment(DataTable dtPayment)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(dtPayment);
            });

            InvokeWcfService("BaseProject.Service", "PaymentController", "SortPayment", requestAction);
        }
    }
}
