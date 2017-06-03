using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.Frequency;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 频次维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmFrequency")]//与系统菜单对应
    [WinformView(Name = "FrmFrequency", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Frequency.FrmFrequency")]
    public class FrequencyController : WcfClientController
    {
        /// <summary>
        /// 频次维护接口
        /// </summary>
        IFrmFrequency frmFrequency;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmFrequency = (IFrmFrequency)DefaultView;
        }

        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        [WinformMethod]
        public void LoadBasicWorkers()
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
            frmFrequency.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 绑定频次信息到风格
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="py">拼音码</param>
        /// <param name="wb">五笔码</param>
        /// <param name="workID">机构ID</param>
        [WinformMethod]
        public void BindFrequencyInfo(string name, string py, string wb, int workID)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FrequencyController",
                "QueryFrequencyInfo",
                (request) =>
                {
                    request.AddData(workID);
                    request.AddData(name);
                    request.AddData(py);
                    request.AddData(wb);
                });

            var dtFrequencyInfo = retdata.GetData<DataTable>(0);
            frmFrequency.BindFrequencyInfo(dtFrequencyInfo);
        }

        /// <summary>
        /// 保存频次信息
        /// </summary>
        /// <param name="freqEntity">频次信息</param>
        /// <param name="workID">机构ID</param>
        /// <returns>大于0保存成功</returns>
        [WinformMethod]
        public int SaveFrequencyInfo(Basic_Frequency freqEntity, int workID)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "FrequencyController",
                "SaveFrequency",
                (request) =>
                {
                    request.AddData(workID);
                    request.AddData(freqEntity);
                });

            return retdata.GetData<int>(0);
        }

        /// <summary>
        /// 检查频次是否重复
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="workID">机构ID</param>
        /// <param name="freqID">ID</param>
        /// <returns>false：重复</returns>
        [WinformMethod]
        public bool CheckFrequencyName(string name, int workID, int freqID)
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "FrequencyController",
               "CheckFrequencyName",
               (request) =>
               {
                   request.AddData(workID);
                   request.AddData(name);
                   request.AddData(freqID);
               });

            return retdata.GetData<bool>(0);
        }
    }
}
