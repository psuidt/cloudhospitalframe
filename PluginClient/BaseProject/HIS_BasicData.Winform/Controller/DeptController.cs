using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.ViewForm.Dept;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 科室维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmDept")]//与系统菜单对应
    [WinformView(Name = "FrmDept", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Dept.FrmDept")]

    public class DeptController : WcfClientController
    {
        /// <summary>
        /// 科室维护接口
        /// </summary>
        IFrmDept frmWorkers;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmWorkers = (IFrmDept)DefaultView;
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
            frmWorkers.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 根据机构ID获取科室分类树
        /// </summary>
        /// <param name="workerId">结构ID</param>
        [WinformMethod]
        public void LoadDeptlayerTree(int workerId)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "DeptController",
                "GetDeptLayers",
                (request) =>
                {
                    request.AddData(workerId);
                });
            var deptLayers = retdata.GetData<List<BaseDeptLayer>>(0);
            frmWorkers.LoadDeptlayerTree(deptLayers);
        }

        /// <summary>
        /// 根据机构ID获取科室列表
        /// </summary>
        /// <param name="workerId">机构ID</param>
        /// <param name="layer">类型</param>
        /// <param name="searchvalue">检索条件</param>
        [WinformMethod]
        public void LoadDeptList(int workerId, string layer, string searchvalue)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "GetDeptList",
              (request) =>
              {
                  request.AddData(workerId);
                  request.AddData(layer);
                  request.AddData(searchvalue);
              });
            var deptList = retdata.GetData<DataTable>(0);
            frmWorkers.LoadDeptList(deptList);
        }

        /// <summary>
        /// 读取科室详细信息
        /// </summary>
        /// <param name="deptId">科室ID</param>
        [WinformMethod]
        public void LoadDeptDetail(int deptId)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "GetDeptDetail",
              (request) =>
              {
                  request.AddData(deptId);
              });
            var deptDetails = retdata.GetData<BaseDeptDetails>(0);
            frmWorkers.LoadDeptDetail(deptDetails);
        }

        /// <summary>
        /// 保存科室详情
        /// </summary>
        /// <param name="deptDetail">科室详情</param>
        /// <returns>保存结果消息</returns>
        [WinformMethod]
        public string SaveDeptDetail(BaseDeptDetails deptDetail)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "SaveDeptDetail",
              (request) =>
              {
                  request.AddData(deptDetail);
              });
            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="dept">科室</param>
        /// <param name="deptDetail">科室详情</param>
        /// <returns>保存结果消息</returns>
        [WinformMethod]
        public string AddDept(BaseDept dept, BaseDeptDetails deptDetail)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "AddDept",
              (request) =>
              {
                  request.AddData(dept);
                  request.AddData(deptDetail);
                  request.AddData(LoginUserInfo.WorkId);
              });
            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 添加科室节点
        /// </summary>
        /// <param name="deptlayer">科室类型</param>
        /// <returns>保存结果消息</returns>
        [WinformMethod]
        public string SaveDeptLayer(BaseDeptLayer deptlayer)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "SaveDeptLayer",
              (request) =>
              {
                  request.AddData(deptlayer);
                  request.AddData(LoginUserInfo.WorkId);
              });
            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        ///  保存科室名称
        /// </summary>
        /// <param name="deptid">科室ID</param>
        /// <param name="deptname">科室名</param>
        /// <returns>保存结果消息</returns>
        [WinformMethod]
        public string SaveDept(int deptid,string deptname)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "SaveDept",
              (request) =>
              {
                  request.AddData(deptid);
                  request.AddData(deptname);
              });
            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="deptid">科室ID</param>
        /// <param name="status">状态</param>
        /// <returns>删除结果消息</returns>
        [WinformMethod]
        public string DeleteDept(string deptid,int status)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "DeleteDept",
              (request) =>
              {
                  request.AddData(deptid);
                  request.AddData(status);
              });
            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 删除科室节点
        /// </summary>
        /// <param name="layer">科室分类</param>
        /// <returns>删除结果消息</returns>
        [WinformMethod]
        public string DelDeptLayer(BaseDeptLayer layer)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
             "DeptController",
             "DelDeptLayer",
              (request) =>
              {
                  request.AddData(layer);
              });
            var ret = retdata.GetData<string>(0);
            return ret;
        }
    }
}
