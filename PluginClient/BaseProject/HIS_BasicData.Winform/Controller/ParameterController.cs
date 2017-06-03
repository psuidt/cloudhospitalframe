using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 系统参数维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmParameter")]//与系统菜单对应
    [WinformView(Name = "FrmParameter", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FrmParameter")]
    public class ParameterController:WcfClientController
    {
        /// <summary>
        /// 系统参数接口
        /// </summary>
        IfrmParameter frmParameter;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmParameter = iBaseView["FrmParameter"] as IfrmParameter;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        [WinformMethod]
        public void InitLoad()
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ParameterController",
            "GetWorkerData");
            List<BaseWorkers> workers = retdata.GetData<List<BaseWorkers>>(0);
            frmParameter.loadWorkerDataBox(ConvertExtend.ToDataTable(workers), LoginUserInfo.WorkId);

            retdata = InvokeWcfService(
            "BaseProject.Service",
            "ParameterController",
            "GetSystemTypeData");
            DataTable dt = retdata.GetData<DataTable>(0);
            frmParameter.loadSystemTypeBox(dt);

            GetSystemConfigData(LoginUserInfo.WorkId, 0, string.Empty);
        }

        /// <summary>
        /// 获取系统参数列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="sysType">类型</param>
        /// <param name="searchKey">检索条件</param>
        [WinformMethod]
        public void GetSystemConfigData(int workID, int sysType, string searchKey)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ParameterController",
              "GetSystemConfigData",
              (request) =>
              {
                  request.AddData(workID);
                  request.AddData(sysType);
                  request.AddData(searchKey);
              });

            DataTable dt = retdata.GetData<DataTable>(0);
            frmParameter.loadSystemConfigGrid(dt);
        }

        /// <summary>
        /// 保存系统消息
        /// </summary>
        /// <param name="workID">机构ID</param>
        [WinformMethod]
        public void SaveSystemConfig(int workID)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ParameterController",
              "SaveSystemConfig",
              (request) =>
              {
                  request.AddData(workID);
                  request.AddData(frmParameter.CurrConfig);
              });

            MessageBoxShowSimple("保存系统参数成功！");
        }

        /// <summary>
        /// 停用启用系统参数
        /// </summary>
        /// <param name="sysId">ID</param>
        /// <param name="val">状态</param>
        [WinformMethod]
        public void SwitchSystemConfig(int sysId,int val)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ParameterController",
              "SwitchSystemConfig",
              (request) =>
              {
                  request.AddData(sysId);
                  request.AddData(val);
              });
            MessageBoxShowSimple("操作成功！");
        }
    }
}
