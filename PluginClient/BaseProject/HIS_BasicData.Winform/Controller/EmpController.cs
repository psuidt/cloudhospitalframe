using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.ViewForm.Employee;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 人员维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmEmp")]//与系统菜单对应
    [WinformView(Name = "FrmEmp", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Employee.FrmEmp")]
    [WinformView(Name = "FrmRelDepts", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Employee.FrmRelDepts")]
    [WinformView(Name = "FrmRelWard", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Employee.FrmRelWard")]
    public class EmpController : WcfClientController
    {
        /// <summary>
        /// 人员维护接口
        /// </summary>
        IFrmEmp frmEmp;

        /// <summary>
        /// 人员关联科室接口
        /// </summary>
        IFrmRelDepts frmRelDepts;

        /// <summary>
        /// 人员关联病区接口
        /// </summary>
        IFrmRelWards frmRelWards;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmEmp = (IFrmEmp)DefaultView;
            frmRelDepts = (IFrmRelDepts)iBaseView["FrmRelDepts"];
            frmRelWards = (IFrmRelWards)iBaseView["FrmRelWard"];
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
            frmEmp.LoadBasicWorkers(workers);
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
                "EmpController",
                "GetDepts",
                (request) =>
                {
                    request.AddData(workerId);
                });
            var depts = retdata.GetData<DataTable>(0);
            frmEmp.LoadBasicDepts(depts);
        }

        /// <summary>
        /// 加载科室下人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="workerId">机构ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="showAll">是否显示全部</param>
        [WinformMethod]
        public void LoadBasicEmps(string name, int workerId, int deptId, bool showAll)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "EmpController",
                "GetEmps",
                (request) =>
                {
                    request.AddData(workerId);
                    request.AddData(deptId);
                    request.AddData(name);
                    request.AddData(showAll);
                    request.AddData(false);
                });
            var emps = retdata.GetData<List<BaseEmployee>>(0);
            frmEmp.LoadBasicEmps(emps);
        }

        /// <summary>
        /// 获取下拉框数据源
        /// </summary>
        [WinformMethod]
        public void LoadBasicData()
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "EmpController",
                "GetBasicData",
                (request) =>
                {
                });
            var dtSex = retdata.GetData<DataTable>(0);
            var dtDegree = retdata.GetData<DataTable>(1);
            var dtNation = retdata.GetData<DataTable>(2);
            var dtMatrimony = retdata.GetData<DataTable>(3);
            var dtTitleCode = retdata.GetData<DataTable>(4);
            var dtPoliticalStatus = retdata.GetData<DataTable>(5);
            var dtJobClassifi = retdata.GetData<DataTable>(6);
            frmEmp.LoadBasicData(dtSex, dtDegree, dtNation, dtMatrimony, dtTitleCode, dtPoliticalStatus, dtJobClassifi);
        }

        /// <summary>
        /// 获取人员详情
        /// </summary>
        /// <param name="empId">人员ID</param>
        [WinformMethod]
        public void LoadEmpDetail(int empId)
        {
            BaseEmployeeDetails empdetail = null;
            if (empId != 0)
            {
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "EmpController",
                    "GetEmpDetail",
                    (request) =>
                    {
                        request.AddData(empId);
                    });
                empdetail = retdata.GetData<BaseEmployeeDetails>(0);
            }

            frmEmp.LoadEmpDetail(empdetail);
        }

        /// <summary>
        /// 保存人员信息
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="emp">人员</param>
        /// <param name="empDetail">人员详情</param>
        /// <returns>保存结果消息</returns>
        [WinformMethod]
        public string SaveEmpAndDetail(int workId,BaseEmployee emp, BaseEmployeeDetails empDetail)
        {
            try
            {
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "EmpController",
                    "SaveEmpAndDetail",
                    (request) =>
                    {
                        request.AddData(workId);
                        request.AddData(emp);
                        request.AddData(empDetail);
                    });

                var ret = retdata.GetData<string>(0);
                MessageBoxShowSimple("保存人员成功！");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return string.Empty;
        }

        /// <summary>
        /// 启用或停用人员
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <param name="delFlag">状态</param>
        /// <returns>操作结果消息</returns>
        [WinformMethod]
        public string FlagEmpAndDetail(int empId, int delFlag)
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
                "EmpController",
                "FlagEmpAndDetail",
                (request) =>
                {
                    request.AddData(empId);
                    request.AddData(delFlag);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 关联科室
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <param name="workId">机构ID</param>
        [WinformMethod]
        public void RelDepts(int empId, int workId)
        {
            frmRelDepts.EmpId = empId;
            frmRelDepts.WorkId = workId;
            frmRelDepts.Result = false;
            (frmRelDepts as Form).ShowDialog();
            if (frmRelDepts.Result)
            {
                MessageBoxShowSimple("保存成功！");
            }
        }

        /// <summary>
        /// 加载科室列表与人员关联关系
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="empId">人员ID</param>
        [WinformMethod]
        public void LoadRelDepts(int workId, int empId)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "DeptController",
                "GetEmpRelDepts",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(empId);
                });
            var depts = retdata.GetData<DataTable>(0);
            frmRelDepts.LoadRelDepts(depts);
        }

        /// <summary>
        /// 保存科室与人员关联关系
        /// </summary>
        /// <param name="dtDataSource">人员关联科室数据</param>
        /// <returns>保存结果消息</returns>
        [WinformMethod]
        public string SaveRelDepts(DataTable dtDataSource)
        {
            var iobj = ((IFrmRelDepts)iBaseView["FrmRelDepts"]);
            var empId = iobj.EmpId;
            var workId = iobj.WorkId;
            var relDepts = new List<BaseEmpDept>();
            foreach (DataRow dr in dtDataSource.Rows)
            {
                relDepts.Add(new BaseEmpDept
                {
                    Id = dr["Id"] + string.Empty == string.Empty ? 0 : int.Parse(dr["Id"] + string.Empty),
                    EmpId = empId,
                    DeptId = int.Parse(dr["DeptId"] + string.Empty),
                    DefaultFlag = int.Parse(dr["DefaultFlag"] + string.Empty),
                    //WorkId = workId,
                    IsRel = dr["EmpId"] + string.Empty == string.Empty ? false : int.Parse(dr["EmpId"] + string.Empty) > 0
                });
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "EmpController",
                "SaveEmpRelDepts",
                (request) =>
                {
                    request.AddData(relDepts);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 关联病区
        /// </summary>
        /// <param name="empId">人员ID</param>
        /// <param name="workId">机构ID</param>
        [WinformMethod]
        public void RelWards(int empId, int workId)
        {
            frmRelWards.EmpId = empId;
            frmRelWards.WorkId = workId;
            frmRelWards.Result = false;
            (frmRelWards as Form).ShowDialog();
            if (frmRelWards.Result)
            {
                MessageBoxShowSimple("保存成功！");
            }
        }

        /// <summary>
        /// 加载病区列表与人员关联关系
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="empId">人员ID</param>
        [WinformMethod]
        public void LoadRelWards(int workId, int empId)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "EmpController",
                "GetEmpRelWards",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(empId);
                });
            var wards = retdata.GetData<DataTable>(0);
            frmRelWards.LoadRelWards(wards);
        }

        /// <summary>
        /// 保存病区与人员关联关系
        /// </summary>
        /// <param name="dtDataSource">病区与人员关联关系数据</param>
        [WinformMethod]
        public void SaveRelWards(DataTable dtDataSource)
        {
            var empId = frmRelWards.EmpId;
            var workId = frmRelWards.WorkId;
            var relWards = new List<BaseEmpWard>();
            foreach (DataRow dr in dtDataSource.Rows)
            {
                if (Convert.ToInt32(dr["CK"]) == 1)
                {
                    relWards.Add(new BaseEmpWard
                    {
                        EmpID = empId,
                        WardID = int.Parse(dr["WardID"] + string.Empty),
                        DefaultFlag = int.Parse(dr["DefaultCK"] + string.Empty)
                    });
                }
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "EmpController",
                "SaveEmpRelWards",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(empId);
                    request.AddData(relWards);
                });
        }
    }
}
