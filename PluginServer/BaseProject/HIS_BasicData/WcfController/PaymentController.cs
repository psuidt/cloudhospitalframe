using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 支付方式控制器
    /// </summary>
    [WCFController]
    public class PaymentController : WcfServerController
    {
        #region 中心支付方式
        /// <summary>
        /// 获取支付方式计算方式
        /// </summary>
        /// <returns>支付方式计算方式</returns>
        [WCFMethod]
        public ServiceResponseData GetPayInputFrom()
        {
            DataTable dt = NewDao<IBasicDataPaymentDao>().GetPayInputFrom();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 停用启用支付方式
        /// </summary>
        /// <returns>true：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData SwitchPayment()
        {
            int paymentId = requestData.GetData<int>(0);
            int val = requestData.GetData<int>(1);
            NewDao<IBasicDataPaymentDao>().SwitchPayment(paymentId, val);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        /// <returns>支付方式列表</returns>
        [WCFMethod]
        public ServiceResponseData GetPaymentData()
        {
            DataTable dt = NewDao<IBasicDataPaymentDao>().GetPaymentData();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 保存支付方式
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SavePayment()
        {
            Basic_Payment report = requestData.GetData<Basic_Payment>(0);
            this.BindDb(report);
            report.save();
            responseData.AddData(true);
            return responseData;
        }
        #endregion

        #region 本院支付方式
        /// <summary>
        /// 获取机构数据
        /// </summary>
        /// <returns>机构列表</returns>
        [WCFMethod]
        public ServiceResponseData GetWorkerData()
        {
            //机构
            List<BaseWorkers> workers = NewObject<BaseWorkers>()
                .getlist<BaseWorkers>(" DelFlag = 0 ");
            responseData.AddData(workers);
            return responseData;
        }

        /// <summary>
        /// 获取业务系统
        /// </summary>
        /// <returns>支付方式类型列表</returns>
        [WCFMethod]
        public ServiceResponseData GetPayTypeData()
        {
            DataTable dt = NewDao<IBasicDataPaymentDao>().GetPayTypeData();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取病人类型
        /// </summary>
        /// <returns>病人类型列表</returns>
        [WCFMethod]
        public ServiceResponseData GetPatTypeData()
        {
            DataTable dt = NewObject<BasicDataManagement>().GetPatType();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取中心支付方式
        /// </summary>
        /// <returns>中心支付方式列表</returns>
        [WCFMethod]
        public ServiceResponseData GetCenterPaymentData()
        {
            DataTable dt = NewObject<IBasicDataPaymentDao>().GetCenterPaymentData();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <returns>true：顺序调整成功</returns>
        [WCFMethod]
        public ServiceResponseData SortPayment()
        {
            DataTable dtPayment = requestData.GetData<DataTable>(0);
            NewObject<IBasicDataPaymentDao>().SortPayment(dtPayment);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 获取本院支付方式
        /// </summary>
        /// <returns>本院支付方式列表</returns>
        [WCFMethod]
        public ServiceResponseData GetHospPaymentData()
        {
            int workId = requestData.GetData<int>(0);
            int userType = requestData.GetData<int>(1);
            int patTypeId = requestData.GetData<int>(2);

            DataTable dt = NewObject<IBasicDataPaymentDao>().GetHostPaymentData(workId,userType,patTypeId);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 删除本院支付方式
        /// </summary>
        /// <returns>true：删除成功</returns>
        [WCFMethod]
        public ServiceResponseData DeleteHospPaymentData()
        {
            int id = requestData.GetData<int>(0);
            NewObject<IBasicDataPaymentDao>().DeleteHostPaymentData(id);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 新增本院支付方式
        /// </summary>
        /// <returns>true：新增成功</returns>
        [WCFMethod]
        public ServiceResponseData AddHospPayment()
        {
            int workId = requestData.GetData<int>(0);
            int patTypeId = requestData.GetData<int>(1);
            int paymentId = requestData.GetData<int>(2);
            int userType = requestData.GetData<int>(3);
            int payorder= requestData.GetData<int>(4);

            NewObject<IBasicDataPaymentDao>().AddHospPayment(workId, patTypeId, paymentId, userType, payorder);
            responseData.AddData(true);
            return responseData;
        }
        #endregion
    }
}
