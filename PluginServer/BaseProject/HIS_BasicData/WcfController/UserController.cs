using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 用户维护控制器
    /// </summary>
    [WCFController]
    public class UserController : WcfServerController
    {
        /// <summary>
        /// 科室数据相关，带“全部”项的下拉选项
        /// </summary>
        /// <returns>科室列表</returns>
        [WCFMethod]
        public ServiceResponseData GetDepts()
        {
            var workerId = requestData.GetData<int>(0);
            SetWorkId(workerId);
            DataTable dt = NewObject<BasicDataManagement>().GetBasicData(DeptDataSourceType.全部科室, true);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 根据机构ID,科室ID获取人员列表
        /// </summary>
        /// <returns>人员列表</returns>
        [WCFMethod]
        public ServiceResponseData GetUsers()
        {
            var workerId = requestData.GetData<int>(0);
            var deptId = requestData.GetData<int>(1);
            var name = requestData.GetData<string>(2);
            var showAll = requestData.GetData<bool>(3);
            var users = NewDao<IBasicDataUserDao>().GetUserList(name, workerId, deptId, showAll);
            responseData.AddData(users);
            return responseData;
        }

        /// <summary>
        /// 获取未增加用户的所有员工
        /// </summary>
        /// <returns>未增加用户的所有员工</returns>
        [WCFMethod]
        public ServiceResponseData GetEmps()
        {
            var workerId = requestData.GetData<int>(0);
            var depts = NewDao<IBasicDataUserDao>().GetEmpList(workerId);
            responseData.AddData(depts);
            return responseData;
        }

        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <returns>基础数据集合</returns>
        [WCFMethod]
        public ServiceResponseData GetBasicData()
        {
            var manage = NewObject<BasicDataManagement>();
            var dtDoctorPost = manage.GetBasicData(BasicDictType.医生职称, false);
            responseData.AddData(dtDoctorPost);

            var dtNursePost = manage.GetBasicData(BasicDictType.护士职称, false);
            responseData.AddData(dtNursePost);

            return responseData;
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveUser()
        {
            int workId = requestData.GetData<int>(0);
            var user = requestData.GetData<BaseUser>(1);
            SetWorkId(workId);

            if(user.UserID==0)
            {
                if(NewDao<IBasicDataUserDao>().ExistUser(user.EmpID))
                {
                    throw new Exception("该员工已经创建用户！");
                }

                if (NewDao<IBasicDataUserDao>().ExistUser(user.Code))
                {
                    throw new Exception("该用户名已存在！");
                }
            }

            user.PassWord = ConvertExtend.ToPassWord("1");
            BindDb(user);
            user.save();
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 启用与停用用户
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData FlagUser()
        {
            var userId = requestData.GetData<int>(0);
            var delFlag = requestData.GetData<int>(1);
            NewDao<IBasicDataUserDao>().FlagUser(userId, delFlag);
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 根据用户标识加载关联的角色
        /// </summary>
        /// <returns>用户关联的角色列表</returns>
        [WCFMethod]
        public ServiceResponseData GetUserGroups()
        {
            var workId = requestData.GetData<int>(0);
            var userId = requestData.GetData<int>(1);
            var groups = NewDao<IBasicDataUserDao>().GetUserGroups(workId, userId);
            responseData.AddData(groups);
            return responseData;
        }

        /// <summary>
        /// 加载所有角色与用户关联关系
        /// </summary>
        /// <returns>角色关联用户列表</returns>
        [WCFMethod]
        public ServiceResponseData GetUserRelGroups()
        {
            var workId = requestData.GetData<int>(0);
            var userId = requestData.GetData<int>(1);
            var groups = NewDao<IBasicDataUserDao>().GetUserRelGroups(workId, userId);
            responseData.AddData(groups);
            return responseData;
        }

        /// <summary>
        /// 保存用户与角色关联关系
        /// </summary>
        /// <returns>用户与角色关联关系</returns>
        [WCFMethod]
        public ServiceResponseData SaveUserRelGroups()
        {
            int workId = requestData.GetData<int>(0);
            int userId = requestData.GetData<int>(1);
            var relGroups = requestData.GetData<List<BaseGroupUser>>(2);
            //删除所有关联角色
            NewDao<IBasicDataUserDao>().DelUserRelGroups(workId, userId);
            SetWorkId(workId);
            foreach (var entity in relGroups)
            {
                BindDb(entity);
                entity.save();
            }

            responseData.AddData("OK");
            return responseData;
        }
    }
}
