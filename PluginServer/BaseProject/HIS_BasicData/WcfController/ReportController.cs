using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 报表控制器
    /// </summary>
    [WCFController]
    public class ReportController : WcfServerController
    {
        /// <summary>
        /// 获取机构数据
        /// </summary>
        /// <returns>机构数据列表</returns>
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
        /// <returns>列表</returns>
        [WCFMethod]
        public ServiceResponseData GetSystemTypeData()
        {
            DataTable dt = NewDao<IBasicDataReportDao>().GetSystemTypeData();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <returns>报表数据</returns>
        [WCFMethod]
        public ServiceResponseData GetReportData()
        {
            int workId = requestData.GetData<int>(0);
            int sysType = requestData.GetData<int>(1);
            string searchStr = requestData.GetData<string>(2);

            DataTable dt = NewDao<IBasicDataReportDao>().GetReportData(workId, sysType, searchStr);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 保存报表
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveReport()
        {
            int workId = requestData.GetData<int>(0);
            Basic_ReportConfig report = requestData.GetData<Basic_ReportConfig>(1);
            SetWorkId(workId);
            //新增报表才验证
            if (report.ID == 0 && NewDao<IBasicDataReportDao>().ExistReport(report.EnumValue, workId) == true)
            {
                throw new Exception("同机构报表编号不能重复！");
            }

            report.PYCode = SpellAndWbCode.GetSpellCode(report.ReportTitle);
            report.WBCode = SpellAndWbCode.GetWBCode(report.ReportTitle);
            report.FileName = string.Empty;
            report.Modifyer = LoginUserInfo.EmpId.ToString();
            NewDao<IBasicDataReportDao>().SaveReport(report);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 获取报表文件
        /// </summary>
        /// <returns>报表文件信息</returns>
        [WCFMethod]
        public ServiceResponseData GetReportFile()
        {
            int id = requestData.GetData<int>(0);
            byte[] data = NewDao<IBasicDataReportDao>().GetReportFile(id);
            responseData.AddData(data);
            return responseData;
        }

        /// <summary>
        /// 上传报表文件
        /// </summary>
        /// <returns>true上传成功</returns>
        [WCFMethod]
        public ServiceResponseData UploadReportFile()
        {
            int id = requestData.GetData<int>(0);
            byte[] buffur = requestData.GetData<byte[]>(1);
            string fileName = requestData.GetData<string>(2);
            int modifyer = requestData.GetData<int>(3);
            DateTime updateTime = requestData.GetData<DateTime>(4);
            NewDao<IBasicDataReportDao>().UploadReportFile(id, buffur,fileName,modifyer,updateTime);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 停用启用报表
        /// </summary>
        /// <returns>true：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData SwitchReport()
        {
            int id = requestData.GetData<int>(0);
            int val = requestData.GetData<int>(1);
            NewDao<IBasicDataReportDao>().SwitchReport(id, val);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 获取报表基础数据
        /// </summary>
        /// <returns>报表基础数据列表</returns>
        [WCFMethod]
        public ServiceResponseData GetReportBasicData()
        {
            DataTable dt = NewDao<IBasicDataReportDao>().GetReportBasicData();
            responseData.AddData(dt);
            return responseData;
        }
    }
}
