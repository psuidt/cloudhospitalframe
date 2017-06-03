using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EFWCoreLib.WcfFrame.ServerController;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using WinMainUIFrame.Entity;
using WinMainUIFrame.ObjectModel.RightManager;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace WinMainUIFrame.WcfController
{
    [WCFController]
    public class RightController : WcfServerController
    {
        #region 菜单维护
        [WCFMethod]
        public ServiceResponseData InitMenuData()
        {
            List<BaseModule> modulelist = NewObject<BaseModule>().getlist<BaseModule>();
            List<BaseMenu> menulist = NewObject<BaseMenu>().getlist<BaseMenu>();

            responseData.AddData(modulelist);
            responseData.AddData(menulist);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData NewMenu()
        {
            int selectMenuId = requestData.GetData<int>(0);
            int selectModuleId = requestData.GetData<int>(1);

            BaseMenu menu = NewObject<BaseMenu>();
            menu.PMenuId = selectMenuId;
            menu.ModuleId = selectModuleId;

            responseData.AddData(menu);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SaveMenu()
        {
            BaseMenu menu = requestData.GetData<BaseMenu>(0);
            this.BindDb(menu);
            menu.save();

            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData DeleteMenu()
        {
            int menuId = requestData.GetData<int>(0);
            NewObject<BaseMenu>().delete(menuId);

            responseData.AddData(true);
            return responseData;
        }
        #endregion

        #region 角色权限
        /// <summary>
        /// 获取机构数据
        /// </summary>
        /// <returns></returns>
        [WCFMethod]
        public ServiceResponseData GetWorkerData()
        {
            //机构
            DataTable workers = NewObject<BaseWorkers>().gettable(" DelFlag = 0 ");
            responseData.AddData(workers);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData InitGroupData()
        {
            int workid = requestData.GetData<int>(0);
            SetWorkId(workid);

            List<BaseGroup> grouplist = NewObject<BaseGroup>().getlist<BaseGroup>();
            responseData.AddData(grouplist);

            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData LoadGroupMenuData()
        {
            int groupId = requestData.GetData<int>(0);

            List<BaseModule> modulelist = NewObject<BaseModule>().getlist<BaseModule>();
            List<BaseMenu> menulist = NewObject<BaseMenu>().getlist<BaseMenu>();
            List<BaseMenu> groupmenulist = NewObject<Menu>().GetGroupMenuList(groupId);

            responseData.AddData(modulelist);
            responseData.AddData(menulist);
            responseData.AddData(groupmenulist);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SetGroupMenu()
        {
            int groupId= requestData.GetData<int>(0);
            int[] menuIds = requestData.GetData<int[]>(1);
            NewObject<Group>().SetGroupMenu(groupId, menuIds);

            responseData.AddData(true);
            return responseData;
        }
        #endregion

        #region 页面权限
        [WCFMethod]
        public ServiceResponseData GetPageMenuData()
        {
            int currGroupId = requestData.GetData<int>(0);
            int menuId = requestData.GetData<int>(1);

            string strsql = @"SELECT Id,Code,Name,
                                        (CASE WHEN (SELECT COUNT(*) FROM dbo.BaseGroupPage WHERE GroupId={0} AND PageId=BasePageMenu.Id)>0 THEN 1 ELSE 0 END) IsUse
                                         FROM BasePageMenu
                                         WHERE menuid={1}";
            strsql = string.Format(strsql, currGroupId, menuId);
            DataTable dt = oleDb.GetDataTable(strsql);

            responseData.AddData(dt);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData SavePageMenu()
        {
            int moduleId = requestData.GetData<int>(0);
            int menuId = requestData.GetData<int>(1);
            string code = requestData.GetData<string>(2);
            string name = requestData.GetData<string>(3);

            string strsql = @" INSERT INTO dbo.BasePageMenu
                                         ( ModuleId ,MenuId ,Code ,Name)
                                         VALUES  ({0},{1},'{2}','{3}')";
            strsql = string.Format(strsql, moduleId, menuId, code, name);
            oleDb.DoCommand(strsql);

            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData DeletePageMenu()
        {
            int pageId = requestData.GetData<int>(0);

            string strsql = @"delete from basepagemenu where id=" + pageId;
            oleDb.DoCommand(strsql);

            responseData.AddData(true);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData SetGroupPage()
        {
            int groupId= requestData.GetData<int>(0);
            int pageId = requestData.GetData<int>(1);

            string strsql = @"select count(*) from BaseGroupPage where GroupId={0} and PageId={1}";
            strsql = string.Format(strsql, groupId, pageId);
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0)
            {
                strsql = @"delete from BaseGroupPage where GroupId={0} and PageId={1}";
                strsql = string.Format(strsql, groupId, pageId);
                oleDb.DoCommand(strsql);
            }
            else
            {
                strsql = @"INSERT INTO BaseGroupPage(GroupId,PageId) VALUES({0},{1})";
                strsql = string.Format(strsql, groupId, pageId);
                oleDb.DoCommand(strsql);
            }

            responseData.AddData(true);
            return responseData;
        }
        #endregion

        #region 维护用户组

        [WCFMethod]
        public ServiceResponseData AlterGroup()
        {
            int groupId= requestData.GetData<int>(0);

            BaseGroup group = NewObject<BaseGroup>().getmodel(groupId) as BaseGroup;
            responseData.AddData<BaseGroup>(group);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData DeleteGroupisExist()
        {
            int groupId = requestData.GetData<int>(0);

            bool ret = true;

            string strsql = @"select count(*) from basegroupuser where groupid=" + groupId;
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0)
                ret = false;
            strsql = @"select count(*) from basegroupmenu where groupid=" + groupId;
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0)
                ret = false;
            responseData.AddData(ret);
            return responseData;
        }

        [WCFMethod]
        public void DeleteGroup()
        {
            int groupId = requestData.GetData<int>(0);

            string strsql = @"delete from basegroup where groupid=" + groupId;
            oleDb.DoCommand(strsql);
        }

        [WCFMethod]
        public void SaveGroup()
        {
            int workid = requestData.GetData<int>(0);
            BaseGroup group = requestData.GetData<BaseGroup>(1);
            SetWorkId(workid);
            this.BindDb(group);
            group.save();
        }
        #endregion

        #region 维护系统模块

        [WCFMethod]
        public ServiceResponseData AlterModule()
        {
            int moduleId = requestData.GetData<int>(0);
            BaseModule module = NewObject<BaseModule>().getmodel(moduleId) as BaseModule;
            responseData.AddData(module);
            return responseData;
        }

        [WCFMethod]
        public void DeleteModule()
        {
            int moduleId = requestData.GetData<int>(0);
            string strsql = @"delete from BaseModule where ModuleId=" + moduleId;
            oleDb.DoCommand(strsql);
        }

        [WCFMethod]
        public void SaveModule()
        {
            BaseModule module = requestData.GetData<BaseModule>(0);
            this.BindDb(module);
            module.save();
        }
        #endregion
    }
}
