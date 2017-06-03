using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.ViewForm.User;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 用户维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmUser")]//与系统菜单对应
    [WinformView(Name = "FrmUser", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.User.FrmUser")]
    [WinformView(Name = "FrmRelGroups", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.User.FrmRelGroups")]
    public class UserController : WcfClientController
    {
        /// <summary>
        /// 用户维护接口
        /// </summary>
        IFrmUser frmEmp;

        /// <summary>
        /// 关联角色接口
        /// </summary>
        IFrmRelGroups frmRelGroups;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmEmp = (IFrmUser)DefaultView;
            frmRelGroups = (IFrmRelGroups)iBaseView["FrmRelGroups"];
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
                "UserController",
                "GetDepts",
                (request) =>
                {
                    request.AddData(workerId);
                });

            var depts = retdata.GetData<DataTable>(0);
            frmEmp.LoadBasicQueryDepts(depts);
        }

        /// <summary>
        /// 加载科室下用户列表
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="workerId">机构ID</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="showAll">是否显示全部</param>
        [WinformMethod]
        public void LoadBasicUsers(string name, int workerId, int deptId, bool showAll)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "UserController",
                "GetUsers",
                (request) =>
                {
                    request.AddData(workerId);
                    request.AddData(deptId);
                    request.AddData(name);
                    request.AddData(showAll);
                });

            var users = retdata.GetData<List<BaseUser>>(0);
            frmEmp.LoadBasicUsers(users);
        }

        /// <summary>
        /// 获取下拉框数据源
        /// </summary>
        [WinformMethod]
        public void LoadBasicData()
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "UserController",
                "GetBasicData",
                (request) =>
                {
                });
            var dtDoctorPost = retdata.GetData<DataTable>(0);
            var dtNursePost = retdata.GetData<DataTable>(1);
            frmEmp.LoadBasicData(dtDoctorPost, dtNursePost);
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="user">用户数据</param>
        [WinformMethod]
        public void SaveUser(int workId, BaseUser user)
        {
            try
            {
                var retdata = InvokeWcfService(
                    "BaseProject.Service",
                    "UserController",
                    "SaveUser",
                    (request) =>
                    {
                        request.AddData(workId);
                        request.AddData(user);
                    });

                var ret = retdata.GetData<string>(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 启用与停用用户
        /// </summary>
        /// <param name="empId">人员id</param>
        /// <param name="delFlag">状态</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string FlagUser(int empId, int delFlag)
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
                "UserController",
                "FlagUser",
                (request) =>
                {
                    request.AddData(empId);
                    request.AddData(delFlag);
                });

            var ret = retdata.GetData<string>(0);
            return ret;
        }

        /// <summary>
        /// 弹出关联角色的窗口
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="workId">机构ID</param>
        /// <returns>true：关联成功</returns>
        [WinformMethod]
        public bool RelGroups(int userId, int workId)
        {
            var iobj = ((IFrmRelGroups)iBaseView["FrmRelGroups"]);
            iobj.UserId = userId;
            iobj.WorkId = workId;
            iobj.Result = false;
            (iBaseView["FrmRelGroups"] as Form).ShowDialog();
            return iobj.Result;
        }

        /// <summary>
        /// 加载科室下人员列表
        /// </summary>
        /// <param name="workerId">机构ID</param>
        [WinformMethod]
        public void LoadBasicEmps(int workerId)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "UserController",
                "GetEmps",
                (request) =>
                {
                    request.AddData(workerId);
                });

            var emps = retdata.GetData<DataTable>(0);
            frmEmp.LoadBasicEmps(emps);
        }

        /// <summary>
        /// 加载用户角色列表
        /// </summary>
        /// <param name="workerId">机构ID</param>
        /// <param name="userId">用户ID</param>
        [WinformMethod]
        public void LoadUserGroups(int workerId, int userId)
        {
            if (userId == 0)
            {
                frmEmp.LoadBasicUserGroups(new List<BaseGroup>());
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "UserController",
                "GetUserGroups",
                (request) =>
                {
                    request.AddData(workerId);
                    request.AddData(userId);
                });

            var groups = retdata.GetData<List<BaseGroup>>(0);
            frmEmp.LoadBasicUserGroups(groups);
        }

        /// <summary>
        /// 加载关联的角色列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userId">用户ID</param>
        [WinformMethod]
        public void LoadRelGroups(int workId, int userId)
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "UserController",
                "GetUserRelGroups",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(userId);
                });

            var depts = retdata.GetData<DataTable>(0);
            frmRelGroups.LoadRelGroups(depts);
        }

        /// <summary>
        /// 保存用户与角色的关联关系
        /// </summary>
        /// <param name="dtDataSource">用户与角色的关联关系数据</param>
        /// <returns>操作消息</returns>
        [WinformMethod]
        public string SaveRelGroups(DataTable dtDataSource)
        {
            var userId = frmRelGroups.UserId;
            var workId = frmRelGroups.WorkId;
            var relDepts = new List<BaseGroupUser>();
            foreach (DataRow dr in dtDataSource.Rows)
            {
                if (Convert.ToInt32(dr["bFlag"]) > 0)
                {
                    relDepts.Add(new BaseGroupUser
                    {
                        GroupId = int.Parse(dr["GroupId"] + string.Empty),
                        UserId = userId,
                        Memo = string.Empty
                    });
                }
            }

            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "UserController",
                "SaveUserRelGroups",
                (request) =>
                {
                    request.AddData(workId);
                    request.AddData(userId);
                    request.AddData(relDepts);
                });
            var ret = retdata.GetData<string>(0);
            return ret;
        }
    }
}
