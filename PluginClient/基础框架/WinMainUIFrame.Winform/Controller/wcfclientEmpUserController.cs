using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using WinMainUIFrame.Entity;
using WinMainUIFrame.Winform.IView.EmpUserManager;
using DevComponents.DotNetBar;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace WinMainUIFrame.Winform.Controller
{
    [WinformController(DefaultViewName = "FrmDeptEmp")]//与系统菜单对应
    [WinformView(Name = "FrmDeptEmp", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.EmpUserManager.FrmDeptEmp")]
    [WinformView(Name = "frmAddUser", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.EmpUserManager.frmAddUser")]
    [WinformView(Name = "frmWorker", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.EmpUserManager.frmWorker")]
    public class wcfclientEmpUserController : WcfClientController
    {
        IfrmDeptEmp frmDeptEmp;
        IfrmWorker frmWorker;
        public override void Init()
        {
            frmDeptEmp = (IfrmDeptEmp)iBaseView["FrmDeptEmp"];
            frmWorker = (IfrmWorker)iBaseView["frmWorker"];
        }
        [WinformMethod]
        public void LoadDeptData()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "LoadDeptData");

            List<BaseDeptLayer> layerlist = retdata.GetData<List<BaseDeptLayer>>(0);
            List <BaseDept> deptlist = retdata.GetData<List<BaseDept>>(1);
            frmDeptEmp.loadDeptTree(layerlist, deptlist);
        }
        [WinformMethod]
        public BaseDeptLayer SaveDeptLayer(int layerId, string layername, int pId)
        {
            
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(layerId);
                request.AddData(layername);
                request.AddData(pId);
            });

            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "LoadDeptData", requestAction);
            return retdata.GetData<BaseDeptLayer>(0);
        }
        [WinformMethod]
        public void DeleteDeptLayer(int layerId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(layerId);
            });
            InvokeWcfService("MainFrame.Service", "EmpUserController", "DeleteDeptLayer", requestAction);
        }
        [WinformMethod]
        public BaseDept SaveDept(int deptId,string deptname,int layerId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(deptId);
                request.AddData(deptname);
                request.AddData(layerId);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "SaveDept", requestAction);
            return retdata.GetData<BaseDept>(0);
        }
        [WinformMethod]
        public void DeleteDept(int deptId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(deptId);
            });
            InvokeWcfService("MainFrame.Service", "EmpUserController", "DeleteDept", requestAction);
        }
        [WinformMethod]
        public void LoadUserData(int[] deptIds)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(deptIds);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "LoadUserData", requestAction);
            DataTable dt = retdata.GetData<DataTable>(0);
            frmDeptEmp.loadUserGrid(dt);
        }
        [WinformMethod]
        public void LoadUserData_Key(string key)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(key);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "LoadUserData_Key", requestAction);
            DataTable dt = retdata.GetData<DataTable>(0);
            frmDeptEmp.loadUserGrid(dt);
        }
        [WinformMethod]
        public DialogResult NewUser()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "NewUser");
            BaseEmployee _currEmp = retdata.GetData<BaseEmployee>(0);
            BaseUser _currUser = retdata.GetData<BaseUser>(1);
            List<BaseGroup> _grouplist = retdata.GetData<List<BaseGroup>>(2);
            List<BaseDept> _deptlist = retdata.GetData<List<BaseDept>>(3);
            ((IfrmAddUser)iBaseView["frmAddUser"]).loadAddUserView(_currEmp, -1, _currUser, _grouplist, _deptlist, null, null);
            (iBaseView["frmAddUser"] as Form).Text = "新增用户";
            return (iBaseView["frmAddUser"] as Form).ShowDialog();
        }
        [WinformMethod]
        public void AlterUser(int empid, int userid)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(empid);
                request.AddData(userid);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "AlterUser", requestAction);
            BaseEmployee _currEmp = retdata.GetData<BaseEmployee>(0);
            int currDeptId = retdata.GetData<int>(1);

            BaseUser _currUser = retdata.GetData<BaseUser>(2);
            List<BaseGroup> _grouplist = retdata.GetData<List<BaseGroup>>(3);
            List<BaseDept> _deptlist = retdata.GetData<List<BaseDept>>(4);

            List<BaseGroup> _usergroup = retdata.GetData<List<BaseGroup>>(5);
            List<BaseDept> _empdept = retdata.GetData<List<BaseDept>>(6);

            BaseDept currdept = retdata.GetData<BaseDept>(7);

            ((IfrmAddUser)iBaseView["frmAddUser"]).loadAddUserView(_currEmp, currDeptId, _currUser, _grouplist, _deptlist, _usergroup, _empdept);

            (iBaseView["frmAddUser"] as Form).Text = "修改用户";
            (iBaseView["frmAddUser"] as Form).ShowDialog();
        }
        [WinformMethod]
        public void SaveUser()
        {
            BaseEmployee emp = (iBaseView["frmAddUser"] as IfrmAddUser).currEmp;
            BaseUser user = (iBaseView["frmAddUser"] as IfrmAddUser).currUser;
            List<int> currEmpDeptList = (iBaseView["frmAddUser"] as IfrmAddUser).currEmpDeptList;
            int currDefaultEmpDept = (iBaseView["frmAddUser"] as IfrmAddUser).currDefaultEmpDept;
            List<int> currGroupUserList = (iBaseView["frmAddUser"] as IfrmAddUser).currGroupUserList;

            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(emp);
                request.AddData(user);
                request.AddData(currEmpDeptList);
                request.AddData(currDefaultEmpDept);
                request.AddData(currGroupUserList);
            });

            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "SaveUser", requestAction);
            if (retdata.GetData<bool>(0) == false)
            {
                throw new Exception("该用户名已存在！");
            }
        }
        [WinformMethod]
        public void ResetUserPass(int userId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(userId);
            });

            Object retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "ResetUserPass", requestAction);
        }
        [WinformMethod]
        public void LoadWorkerList()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "LoadWorkerList");
            List<BaseWorkers> workerlist = retdata.GetData<List<BaseWorkers>>(0);
            frmWorker.loadWorkerGrid(workerlist);
        }
        [WinformMethod]
        public void GetCurrWorker(int workId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(workId);
            });

            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "GetCurrWorker", requestAction);
            BaseWorkers worker = retdata.GetData<BaseWorkers>(0);
            frmWorker.currWorker = worker;
        }
        [WinformMethod]
        public void NewWorker()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "NewWorker");
            BaseWorkers worker = retdata.GetData<BaseWorkers>(0);
            frmWorker.currWorker = worker;
        }
        [WinformMethod]
        public void SaveWorker()
        {
            BaseWorkers worker = frmWorker.currWorker;

            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(worker);
            });

            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "SaveWorker", requestAction);
            frmWorker.currWorker = retdata.GetData<BaseWorkers>(0);
        }

        //启用禁用机构，先判读注册码是否正确
        [WinformMethod]
        public void TurnOnOffWorker(int workId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(workId);
            });

            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "EmpUserController", "TurnOnOffWorker", requestAction);
            BaseWorkers worker = retdata.GetData<BaseWorkers>(0);
            string msg = retdata.GetData<string>(1);
            MessageBoxEx.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmWorker.currWorker = worker;
        }
    }
}
