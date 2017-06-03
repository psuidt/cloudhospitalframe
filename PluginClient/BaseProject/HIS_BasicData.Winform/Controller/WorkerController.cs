//using HIS_PublicManage.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.Worker;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 机构维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmWorker")]//与系统菜单对应
    [WinformView(Name = "FrmWorker", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Worker.FrmWorker")]
    public class WorkerController : WcfClientController
    {
        /// <summary>
        /// 机构维护接口
        /// </summary>
        IFrmWorker frmWorkers;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmWorkers = (IFrmWorker)DefaultView;
        }

        /// <summary>
        /// 获取机构
        /// </summary>
        [WinformMethod]
        public void LoadWorkerList()
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WorkerController",
                "GetWorkers",
                (request) =>
                {
                    request.AddData(true);
                });

            var dtWorkers = retdata.GetData<List<BaseWorkers>>(0);
            frmWorkers.LoadWorkers(dtWorkers);
        }

        /// <summary>
        /// 获取机构详细
        /// </summary>
        /// <param name="iID">机构ID</param>
        [WinformMethod]
        public void LoadWorkerDetail(int iID)
        {
            BaseWorkesDetails workerDetail = null;
            if (iID != 0)
            {
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "WorkerController",
                    "GetWorkerDetails",
                    (request) =>
                    {
                        request.AddData(iID);
                    });

                workerDetail = retdata.GetData<BaseWorkesDetails>(0);
            }

            frmWorkers.LoadWorkerDetail(workerDetail);
        }

        /// <summary>
        /// 获取下拉框数据源
        /// </summary>
        /// <param name="dataType">类型</param>
        [WinformMethod]
        public void LoadBasicData(int dataType)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WorkerController",
                "GetBasicData",
                (request) =>
                {
                    request.AddData(dataType);
                });

            var dtDataSource = retdata.GetData<DataTable>(0);
            switch (dataType)
            {
                case 0:
                        frmWorkers.LoadBasicDataForGrade(dtDataSource);
                    break;
                case 1:
                        frmWorkers.LoadBasicDataForClass(dtDataSource);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 保存机构
        /// </summary>
        /// <param name="worker">机构</param>
        /// <param name="workerDetail">机构想详情</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string SaveWorkerAndDetail(BaseWorkers worker, BaseWorkesDetails workerDetail)
        {
            try
            {
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "WorkerController",
                    "SaveWorkerAndDetail",
                    (request) =>
                    {
                        request.AddData(worker);
                        request.AddData(workerDetail);
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
        /// 启用与停用机构
        /// </summary>
        /// <param name="workerId">机构ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string FlagWorkerAndDetail(int workerId, int delFlag)
        {
            if (delFlag == 0)
            {
                delFlag = 1;
            }
            else
            {
                delFlag = 0;//0为启用,1为停用
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WorkerController",
                "FlagWorkerAndDetail",
                (request) =>
                {
                    request.AddData(workerId);
                    request.AddData(delFlag);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }
    }
}