using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.Entrust;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 嘱托维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmEntrust")]//与系统菜单对应
    [WinformView(Name = "FrmEntrust", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Entrust.FrmEntrust")]
    public class EntrustController : WcfClientController
    {
        /// <summary>
        /// 嘱托维护接口
        /// </summary>
        IFrmEntrust frmEntrust;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmEntrust = (IFrmEntrust)DefaultView;
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
            frmEntrust.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 加载嘱托
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="entrustName">检索条件</param>
        [WinformMethod]
        public void LoadEntrustInfo(int workID, string entrustName)
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "EntrustController",
               "GetEntrustList",
               (request) =>
               {
                   request.AddData(workID);
                   request.AddData(entrustName);
               });

            var entrustInfo = retdata.GetData<DataTable>(0);
            frmEntrust.BindEntrust(entrustInfo);
        }

        /// <summary>
        /// 保存嘱托
        /// </summary>
        /// <param name="ent">嘱托</param>
        /// <param name="workID">机构ID</param>
        /// <returns>大于0保存成功</returns>
        [WinformMethod]
        public int SaveEntrust(Basic_Entrust ent, int workID)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "EntrustController",
              "SaveEntrust",
              (request) =>
              {
                  request.AddData(ent);
                  request.AddData(workID);
              });

            return retdata.GetData<int>(0);
        }

        /// <summary>
        /// 检查嘱托是个重复
        /// </summary>
        /// <param name="id">嘱托ID</param>
        /// <param name="entrustName">嘱托名</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        [WinformMethod]
        public bool CheckEntrustName(int id, string entrustName, int workID)
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "EntrustController",
               "CheckEntrustName",
               (request) =>
               {
                   request.AddData(id);
                   request.AddData(entrustName);
                   request.AddData(workID);
               });

            return retdata.GetData<bool>(0);
        }
    }
}
