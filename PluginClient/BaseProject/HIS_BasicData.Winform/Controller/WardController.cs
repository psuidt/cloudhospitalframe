using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.ViewForm.Dept;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 病区维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmWard")]//与系统菜单对应
    [WinformView(Name = "FrmWard", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Dept.FrmWard")]
    [WinformView(Name = "FrmRelDepts", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Dept.FrmRelDepts")]
    [WinformView(Name = "FrmRelEmps", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Dept.FrmRelEmps")]
    public class WardController : WcfClientController
    {
        /// <summary>
        /// 病区维护接口
        /// </summary>
        IFrmWard frmWard;

        /// <summary>
        /// 关联科室接口
        /// </summary>
        IFrmRels frmRelDept;

        /// <summary>
        /// 关联人员接口
        /// </summary>
        IFrmRels frmRelEmp;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmWard = (IFrmWard)DefaultView;
            frmRelDept = (IFrmRels)iBaseView["FrmRelDepts"];
            frmRelEmp = (IFrmRels)iBaseView["FrmRelEmps"];
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
            frmWard.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 加载科室下拉框
        /// </summary>
        /// <param name="workerId">机构ID</param>
        [WinformMethod]
        public void LoadBasicDepts(int workerId)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "DeptController",
                "GetDepts",
                (request) =>
                {
                    request.AddData(workerId);
                });

            var depts = retdata.GetData<DataTable>(0);
            frmWard.LoadBasicQueryDepts(depts);
        }

        /// <summary>
        /// 加载科室下用户列表
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="workerId">机构ID</param>
        /// <param name="showAll">是否显示全部</param>
        [WinformMethod]
        public void LoadBasicWards(string name, int workerId, bool showAll)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WardController",
                "GetWards",
                (request) =>
                {
                    request.AddData(workerId);
                    request.AddData(name);
                    request.AddData(showAll);
                });

            var wards = retdata.GetData<List<BaseWard>>(0);
            frmWard.LoadBasicWards(wards);
        }

        /// <summary>
        /// 启用与停用病区
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string FlagWard(int wardId, int delFlag)
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
                "WardController",
                "FlagWard",
                (request) =>
                {
                    request.AddData(wardId);
                    request.AddData(delFlag);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 保存病区
        /// </summary>
        /// <param name="ward">病区数据</param>
        /// <param name="workId">机构ID</param>
        [WinformMethod]
        public void SaveWard(BaseWard ward, int workId)
        {
            try
            {
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "WardController",
                    "SaveWard",
                    (request) =>
                    {
                        request.AddData(workId);
                        request.AddData(ward);
                    });

                var ret = retdata.GetData<string>(0);
                MessageBoxShowSimple("保存病区成功！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 加载病区关联科室与人员
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="wardId">病区ID</param>
        /// <param name="relDE">关联关系</param>
        [WinformMethod]
        public void LoadWardDeptAndEmps(int workId, int wardId, RelDeptAndEmp relDE)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WardController",
                "GetWardRelDeptAndEmps",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(wardId);
                    request.AddData(relDE == RelDeptAndEmp.All ? false : true);
                });

            var depts = retdata.GetData<DataTable>(0);
            var emps = retdata.GetData<DataTable>(1);
            switch (relDE)
            {
                case RelDeptAndEmp.All:
                    frmWard.LoadRelDeptAndEmps(depts, emps);
                    break;
                case RelDeptAndEmp.Dept:
                    frmRelDept.LoadRels(depts);
                    break;
                case RelDeptAndEmp.Emp:
                    frmRelEmp.LoadRels(emps);
                    break;
            }
        }

        /// <summary>
        /// 弹出病区关联科室窗口
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <param name="workId">机构ID</param>
        /// <returns>true：关联成功</returns>
        [WinformMethod]
        public bool RelDepts(int wardId, int workId)
        {
            var iobj = ((IFrmRels)iBaseView["FrmRelDepts"]);
            iobj.WardId = wardId;
            iobj.WorkId = workId;
            (iBaseView["FrmRelDepts"] as Form).ShowDialog();
            return iobj.Result;
        }

        /// <summary>
        /// 弹出病区关联人员窗口
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <param name="workId">机构ID</param>
        /// <returns>true：关联成功</returns>
        [WinformMethod]
        public bool RelEmps(int wardId, int workId)
        {
            var iobj = ((IFrmRels)iBaseView["FrmRelEmps"]);
            iobj.WardId = wardId;
            iobj.WorkId = workId;
            (iBaseView["FrmRelEmps"] as Form).ShowDialog();
            return iobj.Result;
        }

        /// <summary>
        /// 保存病区与科室关联关系
        /// </summary>
        /// <param name="dtDataSource">病区与科室关联关系数据</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string SaveRelDepts(DataTable dtDataSource)
        {
            if (null == dtDataSource)
            {
                MessageBoxShowError("保存失败请重试");
                return string.Empty;
            }

            var iobj = ((IFrmRels)iBaseView["FrmRelDepts"]);
            var wardId = iobj.WardId;
            var workId = iobj.WorkId;
            var relDepts = new List<BaseWardDept>();
            foreach (DataRow dr in dtDataSource.Rows)
            {
                relDepts.Add(new BaseWardDept
                {
                    ID = int.Parse(dr["ID"] + string.Empty),
                    WardID = wardId,
                    //WorkId = workId,
                    DeptID = int.Parse(dr["DeptId"] + string.Empty),
                    IsRel = dr["bFlag"] + string.Empty == string.Empty ? false : int.Parse(dr["bFlag"] + string.Empty) > 0
                });
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WardController",
                "SaveWardRelDepts",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(relDepts);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }
    }

    /// <summary>
    /// 病区关联科室与人员的取数枚举
    /// </summary>
    public enum RelDeptAndEmp
    {
        /// <summary>
        /// 主界面
        /// </summary>
        All = 1,

        /// <summary>
        /// 关联科室弹窗
        /// </summary>
        Dept = 2,

        /// <summary>
        /// 关联人员弹窗
        /// </summary>
        Emp = 3
    }
}
