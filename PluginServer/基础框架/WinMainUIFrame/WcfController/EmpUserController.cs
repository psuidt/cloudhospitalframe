using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ServerController;
using WinMainUIFrame.Entity;
using WinMainUIFrame.ObjectModel.RightManager;
using WinMainUIFrame.ObjectModel.UserLogin;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace WinMainUIFrame.WcfController
{
    [WCFController]
    public class EmpUserController : WcfServerController
    {
        [WCFMethod]
        public ServiceResponseData LoadDeptData()
        {
            List<BaseDeptLayer> layerlist = NewObject<BaseDeptLayer>().getlist<BaseDeptLayer>();
            List<BaseDept> deptlist = NewObject<BaseDept>().getlist<BaseDept>();

            responseData.AddData(layerlist);
            responseData.AddData(deptlist);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SaveDeptLayer()
        {
            int layerId = requestData.GetData<int>(0);
            string layername = requestData.GetData<string>(1);
            int pId = requestData.GetData<int>(2);

            BaseDeptLayer layer = NewObject<BaseDeptLayer>();
            layer.LayerId = layerId;
            layer.Name = layername;
            layer.PId = pId;
            layer.save();

            responseData.AddData(layer);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData DeleteDeptLayer()
        {
            int layerId = requestData.GetData<int>(0);
            NewObject<BaseDeptLayer>().delete(layerId);

            
            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SaveDept()
        {
            int deptId = requestData.GetData<int>(0);
            string deptname = requestData.GetData<string>(1);
            int layerId = requestData.GetData<int>(2);

            BaseDept dept = NewObject<BaseDept>();
            dept.DeptId = deptId;
            dept.Layer = layerId;
            dept.Name = deptname;
            dept.Pym = SpellAndWbCode.GetSpellCode(deptname);
            dept.Wbm = SpellAndWbCode.GetWBCode(deptname);
            dept.save();

            
            responseData.AddData(dept);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData DeleteDept()
        {
            int deptId = requestData.GetData<int>(0);
            NewObject<BaseDept>().delete(deptId);

           
            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData LoadUserData()
        {
            int[] deptIds = requestData.GetData<int[]>(0);
            DataTable dt = NewObject<User>().GetUserData(deptIds);

            
            responseData.AddData(dt);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData LoadUserData_Key()
        {
            string key = requestData.GetData<string>(0);
            DataTable dt = NewObject<User>().GetUserData(key);

            
            responseData.AddData(dt);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData NewUser()
        {
            BaseEmployee currEmp = NewObject<BaseEmployee>();
            BaseUser currUser = NewObject<BaseUser>();
            List<BaseGroup> grouplist = NewObject<BaseGroup>().getlist<BaseGroup>();
            List<BaseDept> deptlist = NewObject<BaseDept>().getlist<BaseDept>();

            responseData.AddData(currEmp);
            responseData.AddData(currUser);
            responseData.AddData(grouplist);
            responseData.AddData(deptlist);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData AlterUser()
        {
            int empid = requestData.GetData<int>(0);
            int userid = requestData.GetData<int>(1);

            BaseEmployee currEmp = (BaseEmployee)NewObject<BaseEmployee>().getmodel(empid);
            BaseUser currUser = (BaseUser)NewObject<BaseUser>().getmodel(userid);
            List<BaseGroup> grouplist = NewObject<BaseGroup>().getlist<BaseGroup>();
            List<BaseDept> deptlist = NewObject<BaseDept>().getlist<BaseDept>();

            List<BaseGroup> usergroup = NewObject<Group>().GetGroupList(userid);
            List<BaseDept> empdept = NewObject<Dept>().GetHaveDept(empid);
            BaseDept currdept = NewObject<Dept>().GetDefaultDept(empid);

            responseData.AddData(currEmp);
            responseData.AddData(currdept == null ? -1 : currdept.DeptId);
            responseData.AddData(currUser);
            responseData.AddData(grouplist);
            responseData.AddData(deptlist);
            responseData.AddData(usergroup);
            responseData.AddData(empdept);
            responseData.AddData(currdept);

            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SaveUser()
        {
            BaseEmployee emp = requestData.GetData<BaseEmployee>(0);
            BaseUser user = requestData.GetData<BaseUser>(1);
            int[] currEmpDeptList = requestData.GetData<int[]>(2);
            int currDefaultEmpDept = requestData.GetData<int>(3);
            int[] currGroupUserList = requestData.GetData<int[]>(4);

            emp.BindDb(oleDb, _container,_cache,_pluginName);
            user.BindDb(oleDb, _container, _cache, _pluginName);

            if (emp.EmpId == 0)
            {
                if (NewObject<User>().GetUser(user.Code) != null)
                {
                    responseData.AddData(false);
                    return responseData;
                }
            }

            emp.Pym = SpellAndWbCode.GetSpellCode(emp.Name);
            emp.Wbm = SpellAndWbCode.GetWBCode(emp.Name);
            emp.Brithday = DateTime.Now;
            emp.save();
            user.EmpId = emp.EmpId;
            user.PassWord = ConvertExtend.ToPassWord("1");
            //user.IsAdmin = 0;
            user.save();

            NewObject<Employee>().SetHaveEmpDeptRole(emp.EmpId, currEmpDeptList);
            NewObject<Employee>().SetDefaultEmpDeptRole(emp.EmpId, currDefaultEmpDept);
            NewObject<User>().SetGroupUserRole(user.UserId, currGroupUserList);

            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData ResetUserPass()
        {
            int userId = requestData.GetData<int>(0);
            NewObject<User>().ResetPassword(userId);

            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData LoadWorkerList()
        {
            List<BaseWorkers> workerlist = NewObject<BaseWorkers>().getlist<BaseWorkers>();

            responseData.AddData(workerlist);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData GetCurrWorker()
        {
            int workId = requestData.GetData<int>(0);
            BaseWorkers worker = NewObject<BaseWorkers>().getmodel(workId) as BaseWorkers;

            responseData.AddData(worker);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData NewWorker()
        {
            BaseWorkers worker = NewObject<BaseWorkers>();
            worker.DelFlag = -1;//-1新建 0启用 1禁用

            responseData.AddData(worker);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SaveWorker()
        {
            BaseWorkers worker = requestData.GetData<BaseWorkers>(0);
            worker.BindDb(oleDb, _container, _cache, _pluginName);
            worker.save();

            //修改必须重新启用
            if (worker.DelFlag == 0)
            {
                //TurnOnOffWorker(worker.WorkId);
                worker.DelFlag = 1;
            }

            responseData.AddData(worker);
            return responseData;
        }

        //启用禁用机构，先判读注册码是否正确
        [WCFMethod]
        public ServiceResponseData TurnOnOffWorker()
        {
            int workId = requestData.GetData<int>(0);
            BaseWorkers worker = NewObject<BaseWorkers>().getmodel(workId) as BaseWorkers;
            string msgText = "";

            if (worker.DelFlag == -1)//新建的启用
            {
                //判读注册码是否正确
                string regkey = worker.RegKey;
                DESEncryptor des = new DESEncryptor();
                des.InputString = regkey;
                des.DesDecrypt();
                string[] ret = (des.OutString == null ? "" : des.OutString).Split(new char[] { '|' });
                if (ret.Length == 2 && ret[0] == worker.WorkName && Convert.ToDateTime(ret[1]) > DateTime.Now)
                {
                    //新建机构，增加用户、关联科室、关联角色
                    oleDb.WorkId = worker.WorkId;
                    //修改状态为0
                    worker.DelFlag = 0;
                    worker.save();
                    //MessageBoxEx.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msgText = "操作成功！";
                }
                else
                {
                    msgText = "机构注册码不正确！";
                }
            }
            else if (worker.DelFlag == 1)//禁用的启用
            {
                //判读注册码是否正确
                string regkey = worker.RegKey;
                DESEncryptor des = new DESEncryptor();
                des.InputString = regkey;
                des.DesDecrypt();
                string[] ret = (des.OutString == null ? "" : des.OutString).Split(new char[] { '|' });
                if (ret.Length == 2 && ret[0] == worker.WorkName && Convert.ToDateTime(ret[1]) > DateTime.Now)
                {
                    //修改状态为0
                    worker.DelFlag = 0;
                    worker.save();
                    //MessageBoxEx.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msgText = "操作成功！";
                }
                else
                {
                    //MessageBoxEx.Show("机构注册码不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msgText = "机构注册码不正确！";
                }
            }
            else//禁用
            {
                //修改状态为1
                worker.DelFlag = 1;
                worker.save();
                //MessageBoxEx.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msgText = "操作成功！";
            }

            responseData.AddData(worker);
            responseData.AddData(msgText);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData InitWorkerUser()
        {
            int workId = requestData.GetData<int>(0);

            BaseEmployee currEmp = NewObject<BaseEmployee>();
            BaseUser currUser = NewObject<BaseUser>();
            List<BaseGroup> grouplist = NewObject<BaseGroup>().getlist<BaseGroup>();
            List<BaseDept> deptlist = NewObject<BaseDept>().getlist<BaseDept>();

            currUser.IsAdmin = 1;

            responseData.AddData(currEmp);
            responseData.AddData(currUser);
            responseData.AddData(grouplist);
            responseData.AddData(deptlist);
            return responseData;
        }

    }
}
