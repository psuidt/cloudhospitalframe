using System.Data;
using System.Linq;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 机构维护控制器
    /// </summary>
    [WCFController]
    public class WorkerController : WcfServerController
    {
        /// <summary>
        /// 获取所有机构
        /// </summary>
        /// <returns>所有机构</returns>
        [WCFMethod]
        public ServiceResponseData GetWorkers()
        {
            var isAll = requestData.GetData<bool>(0);
            var workers = NewObject<BaseWorkers>()
                .getlist<BaseWorkers>(isAll ? string.Empty : " DelFlag = 0 ")
                .OrderBy(n => n.WorkId);
            responseData.AddData(workers);
            return responseData;
        }

        /// <summary>
        /// 获取机构详细
        /// </summary>
        /// <returns>机构详细</returns>
        [WCFMethod]
        public ServiceResponseData GetWorkerDetails()
        {
            var iID = requestData.GetData<int>(0);
            var details = NewDao<IBasicDataWorkerDao>().GetWorkerDetail(iID);
            responseData.AddData(details);
            return responseData;
        }

        /// <summary>
        /// 根据类别获取基础数据
        /// </summary>
        /// <returns>基础数据集合</returns>
        [WCFMethod]
        public ServiceResponseData GetBasicData()
        {
            var dataType = requestData.GetData<int>(0);
            var dtBasicData = NewObject<BasicDataManagement>().GetBasicData((WorkDataSourceType)dataType, false);
            responseData.AddData(dtBasicData);
            return responseData;
        }

        /// <summary>
        /// 保存机构
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveWorkerAndDetail()
        {
            var worker = requestData.GetData<BaseWorkers>(0);
            var workerDetail = requestData.GetData<BaseWorkesDetails>(1);
            this.BindDb(worker);
            worker.save();
            this.BindDb(workerDetail);
            workerDetail.WorkId = worker.WorkId;
            workerDetail.save();
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 启用和停用机构
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData FlagWorkerAndDetail()
        {
            var workerId = requestData.GetData<int>(0);
            var delFlag = requestData.GetData<int>(1);
            NewDao<IBasicDataWorkerDao>().FlagWorkerAndDetail(workerId, delFlag);
            responseData.AddData("OK");
            return responseData;
        }
    }
}
