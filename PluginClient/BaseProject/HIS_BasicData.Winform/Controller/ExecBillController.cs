using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.Channel;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 执行单配置控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmExecBill")]//与系统菜单对应
    [WinformView(Name = "FrmExecBill", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Channel.FrmExecBill")]
    public class ExecBillController : WcfClientController
    {
        /// <summary>
        /// 执行单配置接口
        /// </summary>
        IFrmExecBill frmExecBill;

        /// <summary>
        /// 初始化控制器
        /// </summary>
        public override void Init()
        {
            frmExecBill = (IFrmExecBill)DefaultView;
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
            frmExecBill.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 加载执行单数据
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="queryStr">检索条件</param>
        [WinformMethod]
        public void BindExecBillInfo(int workID, string queryStr)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ExceBillController",
                "GetExecBillInfo",
                (request) =>
                {
                    request.AddData(workID);
                    request.AddData(queryStr);
                });

            var execBillInfo = retdata.GetData<DataTable>(0);
            frmExecBill.BingExecBillInfo(execBillInfo);
        }

        /// <summary>
        /// 加载用法数据
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <returns>用法列表</returns>
        [WinformMethod]
        public DataTable BindChannelInfo(int workID)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ExceBillController",
                "GetChannelInfo",
                (request) =>
                {
                    request.AddData(workID);
                });

            return retdata.GetData<DataTable>(0);
        }

        /// <summary>
        /// 获取执行单关联用法数据
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="id">执行单ID</param>
        [WinformMethod]
        public void GetExecuteBillChannel(int workID, int id)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ExceBillController",
                "GetExecuteBillChannel",
                (request) =>
                {
                    request.AddData(workID);
                    request.AddData(id);
                });

            frmExecBill.BindChannelInfo(retdata.GetData<DataTable>(0));
        }

        /// <summary>
        /// 检查执行单名是否重复
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="id">执行单ID</param>
        /// <param name="name">名称</param>
        /// <returns>false：重复</returns>
        [WinformMethod]
        public bool CheckName(int workID, int id, string name)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ExceBillController",
                "CheckName",
                (request) =>
                {
                    request.AddData(workID);
                    request.AddData(id);
                    request.AddData(name);
                });

            return retdata.GetData<bool>(0);
        }

        /// <summary>
        /// 保存执行单
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="billEntity">执行单数据</param>
        /// <param name="channelList">用法列表</param>
        /// <param name="deleteList">删除数据</param>
        /// <returns>大于0保存成功</returns>
        [WinformMethod]
        public int SaveBillChannelInfo(int workID, Basic_ExecuteBills billEntity, List<Basic_ExecuteBillChannel> channelList, List<Basic_ExecuteBillChannel> deleteList)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ExceBillController",
                "SaveBillChannelInfo",
                (request) =>
                {
                    request.AddData(workID);
                    request.AddData(billEntity);
                    request.AddData(channelList);
                    request.AddData(deleteList);
                });

            return retdata.GetData<int>(0);
        }

        /// <summary>
        /// 更新执行单使用状态
        /// </summary>
        /// <param name="id">执行单ID</param>
        /// <param name="useFlag">使用状态：0使用中，1停用</param>
        /// <returns>大于0更新成功</returns>
        [WinformMethod]
        public int UpdateFlag(int id, int useFlag)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "ExceBillController",
                "UpdateFlag",
                (request) =>
                {
                    request.AddData(LoginUserInfo.WorkId);
                    request.AddData(id);
                    request.AddData(useFlag);
                });

            return retdata.GetData<int>(0);
        }
    }
}
