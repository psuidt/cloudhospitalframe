using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using WinMainUIFrame.Entity;
using WinMainUIFrame.Winform.IView.RightManager;
using EFWCoreLib.WcfFrame.DataSerialize;
using System.Windows.Forms;

namespace WinMainUIFrame.Winform.Controller
{
    [WinformController(DefaultViewName = "frmMenu")]//与系统菜单对应
    [WinformView(Name = "frmMenu", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.RightManager.frmMenu")]
    [WinformView(Name = "frmGroupMenu", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.RightManager.frmGroupMenu")]
    [WinformView(Name = "frmAddGroup", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.RightManager.frmAddGroup")]
    [WinformView(Name = "frmAddModule", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.RightManager.frmAddModule")]
    public class wcfclientRightController : WcfClientController
    {
        IfrmMenu frmMenu;
        IfrmGroupMenu frmgroupmenu;
        IfrmAddGroup frmaddgroup;
        IfrmAddmodule frmaddmodule;
        public override void Init()
        {
            frmMenu = (IfrmMenu)iBaseView["frmMenu"];
            frmgroupmenu = (IfrmGroupMenu)iBaseView["frmGroupMenu"];
            frmaddgroup = (IfrmAddGroup)iBaseView["frmAddGroup"];
            frmaddmodule = (IfrmAddmodule)iBaseView["frmAddModule"];
        }

        #region 菜单维护

        [WinformMethod]
        public void InitMenuData()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "InitMenuData");
            List<BaseModule> modulelist = retdata.GetData<List<BaseModule>>(0);
            List<BaseMenu> menulist = retdata.GetData<List<BaseMenu>>(1);

            frmMenu.loadMenuTree(modulelist, menulist);
        }
        [WinformMethod]
        public void NewMenu()
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(frmMenu.currentMenu.MenuId);
                request.AddData(frmMenu.currentMenu.ModuleId);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "NewMenu",requestAction);
            BaseMenu menu = retdata.GetData<BaseMenu>(0);
            frmMenu.currentMenu = menu;
        }
        [WinformMethod]
        public void SaveMenu()
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(frmMenu.currentMenu);
            });

            Object retdata = InvokeWcfService("MainFrame.Service", "RightController", "SaveMenu", requestAction);
            InitMenuData();
        }
        [WinformMethod]
        public void DeleteMenu(int menuId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(menuId);
            });

            Object retdata = InvokeWcfService("MainFrame.Service", "RightController", "DeleteMenu", requestAction);
            InitMenuData();
        }

        #endregion

        #region 角色权限设置

        [WinformMethod]
        public void InitWorkersData()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "GetWorkerData");
            DataTable workers = retdata.GetData<DataTable>(0);
            frmgroupmenu.loadWorkers(workers, LoginUserInfo.WorkId);
        }

        [WinformMethod]
        public void InitGroupData()
        {
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "InitGroupData",
                (request) =>
                {
                    request.AddData(frmgroupmenu.CurrWorkId);
                });
            List<BaseGroup> grouplist = retdata.GetData<List<BaseGroup>>(0);
            frmgroupmenu.loadGroupGrid(grouplist);
        }
        [WinformMethod]
        public void LoadGroupMenuData(int groupId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
            });

            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "LoadGroupMenuData", requestAction);

            List<BaseModule> modulelist = retdata.GetData<List<BaseModule>>(0);
            List<BaseMenu> menulist = retdata.GetData<List<BaseMenu>>(1);
            List<BaseMenu> groupmenulist = retdata.GetData<List<BaseMenu>>(2);

            frmgroupmenu.loadMenuTree(modulelist, menulist, groupmenulist);
        }
        [WinformMethod]
        public void SetGroupMenu(int groupId, int[] menuIds)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
                request.AddData(menuIds);
            });

            Object retdata = InvokeWcfService("MainFrame.Service", "RightController", "SetGroupMenu", requestAction);
        }

        #endregion

        #region 页面权限
        [WinformMethod]
        public void GetPageMenuData()
        {
            frmgroupmenu.panelPageEnabled = false;
            if (frmgroupmenu.currGroupId == -1 || frmgroupmenu.currMenu == null)
            {
                frmgroupmenu.loadPageMenu(null);
            }
            else
            {
                if (frmgroupmenu.currMenu.FunName.Trim() == "" && frmgroupmenu.currMenu.UrlName.Trim() == "")
                    frmgroupmenu.panelPageEnabled = false;
                else
                    frmgroupmenu.panelPageEnabled = true;

                Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
                {
                    request.AddData(frmgroupmenu.currGroupId);
                    request.AddData(frmgroupmenu.currMenu.MenuId);
                });

                ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "GetPageMenuData", requestAction);

                DataTable dt = retdata.GetData<DataTable>(0);
                frmgroupmenu.loadPageMenu(dt);
            }
        }
        [WinformMethod]
        public void SavePageMenu(int moduleId, int menuId, string code, string name)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(moduleId);
                request.AddData(menuId);
                request.AddData(code);
                request.AddData(name);
            });
            Object retdata = InvokeWcfService("MainFrame.Service", "RightController", "SavePageMenu", requestAction);

            GetPageMenuData();
        }
        [WinformMethod]
        public void DeletePageMenu(int pageId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(pageId);
            });
            Object retdata = InvokeWcfService("MainFrame.Service", "RightController", "DeletePageMenu", requestAction);

            GetPageMenuData();
        }
        [WinformMethod]
        public void SetGroupPage(int groupId, int pageId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
                request.AddData(pageId);
            });
            Object retdata = InvokeWcfService("MainFrame.Service", "RightController", "SetGroupPage", requestAction);

            GetPageMenuData();
        }
        #endregion

        #region 角色维护

        [WinformMethod]
        public void NewGroup()
        {
            (frmaddgroup as Form).Text = "添加角色";

            BaseGroup group = NewObject<BaseGroup>();
            group.Name = "";
            group.Memo = "";
            frmaddgroup.currGroup = group;
            (frmaddgroup as Form).ShowDialog();
        }

        [WinformMethod]
        public void AlterGroup(int groupId)
        {
            (frmaddgroup as Form).Text = "修改角色";

            //BaseGroup group = NewObject<BaseGroup>().getmodel(groupId) as BaseGroup;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "AlterGroup", requestAction);
            frmaddgroup.currGroup = retdata.GetData<BaseGroup>(0);
            (frmaddgroup as Form).ShowDialog();
        }

        [WinformMethod]
        public bool DeleteGroupisExist(int groupId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "DeleteGroupisExist", requestAction);
            return retdata.GetData<bool>(0);
        }

        [WinformMethod]
        public void DeleteGroup(int groupId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(groupId);
            });
            InvokeWcfService("MainFrame.Service", "RightController", "DeleteGroup", requestAction);

            InitGroupData();
        }

        [WinformMethod]
        public void SaveGroup()
        {
            BaseGroup group = frmaddgroup.currGroup;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(frmgroupmenu.CurrWorkId);
                request.AddData(group);
            });
            InvokeWcfService("MainFrame.Service", "RightController", "SaveGroup", requestAction);

            InitGroupData();
        }
        #endregion

        #region 子系统模块维护
        [WinformMethod]
        public void NewModule()
        {
            (frmaddmodule as Form).Text = "添加模块";

            BaseModule module = NewObject<BaseModule>();
            module.Name = "";
            module.Memo = "";
            frmaddmodule.currModule = module;
            (frmaddmodule as Form).ShowDialog();
        }

        [WinformMethod]
        public void AlterModule(int moduleId)
        {
            (frmaddmodule as Form).Text = "修改模块";

            //BaseModule module = NewObject<BaseModule>().getmodel(moduleId) as BaseModule;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(moduleId);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "RightController", "AlterModule", requestAction);

            frmaddmodule.currModule = retdata.GetData<BaseModule>(0);
            (frmaddmodule as Form).ShowDialog();
        }

        [WinformMethod]
        public void DeleteModule(int moduleId)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(moduleId);
            });
            InvokeWcfService("MainFrame.Service", "RightController", "DeleteModule", requestAction);

            InitMenuData();
        }

        [WinformMethod]
        public void SaveModule()
        {
            BaseModule module = frmaddmodule.currModule;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(module);
            });
            InvokeWcfService("MainFrame.Service", "RightController", "SaveModule", requestAction);

            InitMenuData();
        }
        #endregion
    }
}
