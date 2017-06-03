using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 报表配置控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmReportManager")]//与系统菜单对应
    [WinformView(Name = "FrmReportManager", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FrmReportManager")]
    public class ReportController : WcfClientController
    {
        /// <summary>
        /// 报表维护接口
        /// </summary>
        IfrmReportManager frmReportManager;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmReportManager = iBaseView["FrmReportManager"] as IfrmReportManager;
        }

        /// <summary>
        /// 加载基础数据
        /// </summary>
        [WinformMethod]
        public void InitLoadData()
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "ReportController",
             "GetWorkerData");
            List<BaseWorkers> workers = retdata.GetData<List<BaseWorkers>>(0);
            frmReportManager.loadWorkerDataBox(ConvertExtend.ToDataTable(workers), LoginUserInfo.WorkId);

            retdata = InvokeWcfService(
             "BaseProject.Service",
             "ReportController",
             "GetSystemTypeData");
            DataTable dt = retdata.GetData<DataTable>(0);
            frmReportManager.loadSystemTypeBox(dt);

            GetReportData(LoginUserInfo.WorkId, frmReportManager.getSysType, string.Empty);
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="workId">机构id</param>
        /// <param name="sysType">类型</param>
        /// <param name="searchStr">检索条件</param>
        [WinformMethod]
        public void GetReportData(int workId, int sysType, string searchStr)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ReportController",
            "GetReportData",
            (request) =>
            {
                request.AddData(workId);
                request.AddData(sysType);
                request.AddData(searchStr);
            });

            DataTable dt = retdata.GetData<DataTable>(0);
            frmReportManager.loadReportGrid(dt);
        }

        /// <summary>
        /// 保存报表配置
        /// </summary>
        [WinformMethod]
        public void SaveReport()
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ReportController",
              "SaveReport",
              (request) =>
              {
                  request.AddData(frmReportManager.getWorkId);
                  request.AddData(frmReportManager.CurrReport);
              });

            MessageBoxShowSimple("保存报表成功！");
        }

        /// <summary>
        /// 停用/启用
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="val">状态</param>
        [WinformMethod]
        public void StopReport(int id, int val)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "ReportController",
             "SwitchReport",
             (request) =>
             {
                 request.AddData(id);
                 request.AddData(val);
             });
            MessageBoxShowSimple("操作成功！");
        }

        /// <summary>
        /// 下载报表文件
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="filename">文件名</param>
        /// <param name="reportfile">报表文件</param>
        /// <param name="updateTime">修改时间</param>
        [WinformMethod]
        public void GetReportFile(int id, string filename, string reportfile, DateTime updateTime)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ReportController",
                "GetReportFile",
                (request) =>
                {
                    request.AddData(id);
                });
            byte[] data = retdata.GetData<byte[]>(0);
            using (FileStream fsWrite = new FileStream(reportfile, FileMode.Create))
            {
                fsWrite.Write(data, 0, data.Length);
            }

            UpgradeFileConfigManager.AddReport(filename, updateTime);

            MessageBoxShowSimple("报表文件下载完成！");
        }

        /// <summary>
        /// 上传报表
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="filename">文件名</param>
        /// <param name="reportfile">报表文件</param>
        /// <param name="updateTime">修改时间</param>
        [WinformMethod]
        public void UploadReportFile(int id, string filename, string reportfile, DateTime updateTime)
        {
            FileStream fs = new FileStream(reportfile, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fs.Length];
            fs.Read(buffur, 0, (int)fs.Length);
            if (fs != null)
            {
                //关闭资源  
                fs.Close();
            }

            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "ReportController",
               "UploadReportFile",
               (request) =>
               {
                   request.AddData(id);
                   request.AddData(buffur);
                   request.AddData(filename);
                   request.AddData(LoginUserInfo.EmpId);
                   request.AddData(updateTime);
               });

            MessageBoxShowSimple("报表文件上传完成！");
        }
    }
}
