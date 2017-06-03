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
    /// 说明性医嘱维护
    /// </summary>
    [WinformController(DefaultViewName = "FrmAttachAdvice")]//与系统菜单对应
    [WinformView(Name = "FrmAttachAdvice", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Entrust.FrmAttachAdvice")]
    public class AttachAdviceController : WcfClientController
    {
        /// <summary>
        /// 说明性医嘱接口
        /// </summary>
        IFrmAttachAdvice frmAttachAdvice;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmAttachAdvice = (IFrmAttachAdvice)DefaultView;
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
            frmAttachAdvice.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 获取单位列表
        /// </summary>
        [WinformMethod]
        public void LoadUnitInfo()
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "AttachAdviceController",
               "GetUintList",
               (request) =>
               {
               });
            var unitInfo = retdata.GetData<DataTable>(0);
            frmAttachAdvice.LoadUnitInfo(unitInfo);
        }

        /// <summary>
        /// 获取说明性医嘱列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        [WinformMethod]
        public void BindAttachAdvice(int workID, string name)
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "AttachAdviceController",
               "GetAttachAdviceList",
               (request) =>
               {
                   request.AddData(workID);
                   request.AddData(name);
               });
            var unitInfo = retdata.GetData<DataTable>(0);
            frmAttachAdvice.BindAttachAdvice(unitInfo);
        }

        /// <summary>
        /// 验证说明性医嘱是否存在
        /// </summary>
        /// <param name="id">说明性医嘱ID</param>
        /// <param name="name">名称</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        [WinformMethod]
        public bool CheckInfo(int id, string name,int workID)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "AttachAdviceController",
              "CheckAttachAdviceInfo",
              (request) =>
              {
                  request.AddData(id);
                  request.AddData(name);
                  request.AddData(workID);
              });
            return retdata.GetData<bool>(0);
        }

        /// <summary>
        /// 保存说明性医嘱数据
        /// </summary>
        /// <param name="enti">医嘱内容</param>
        /// <param name="workID">机构ID</param>
        /// <returns>保存成功的行数</returns>
        [WinformMethod]
        public int SaveAttachAdviceInfo(Basic_AttachAdvice enti,int workID)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "AttachAdviceController",
              "SaveAttachAdviceInfo",
              (request) =>
              {
                  enti.Uploader = LoginUserInfo.EmpId;
                  enti.UploadTime = System.DateTime.Now;
                  request.AddData(enti);
                  request.AddData(workID);
              });
            return retdata.GetData<int>(0);
        }
    }
}
