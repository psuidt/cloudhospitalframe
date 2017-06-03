using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Init;
using EFWCoreLib.WcfFrame.ClientController;
using WinMainUIFrame.Entity;
using WinMainUIFrame.Winform.Common;
using WinMainUIFrame.Winform.IView;
using EfwControls.CustomControl;
using System.Xml;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace WinMainUIFrame.Winform.Controller
{
    [WinformController(DefaultViewName = "FrmLogin")]//与系统菜单对应
    [WinformView(Name = "FrmLogin", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmLogin")]
    [WinformView(Name = "FrmMain", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmMain")]
    [WinformView(Name = "FrmMainRibbon", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmMainRibbon")]
    [WinformView(Name = "FrmSetting", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmSetting")]
    [WinformView(Name = "ReDept", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.ReDept")]
    [WinformView(Name = "FrmPassWord", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmPassWord")]
    [WinformView(Name = "FrmWeclome", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmWeclome")]
    [WinformView(Name = "FrmWebBrowser", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.WebBrowser.FrmWebBrowser")]
    public class wcfclientLoginController : WcfClientController
    {
        public IfrmLogin frmlogin;
        public IfrmMain frmmain;

        //private Form _frmsplash;

        //public Form Frmsplash
        //{
        //    get { return _frmsplash; }
        //    set { _frmsplash = value; }
        //}

        public override void Init()
        {
            frmlogin = (IfrmLogin)iBaseView["FrmLogin"];

            int mainStyle = CustomConfigManager.GetMainStyle();
            if (mainStyle == 0)
                frmmain = (IfrmMain)iBaseView["FrmMain"];
            else
                frmmain = (IfrmMain)iBaseView["FrmMainRibbon"];

            //创建连接
            EFWCoreLib.WcfFrame.ClientLinkManage.CreateConnection("MainFrame.Service");
        }

        [WinformMethod]
        public void ShowWeclomeForm()
        {
            string tabId = "view" + iBaseView["FrmWeclome"].GetHashCode();
            frmmain.ShowForm((Form)iBaseView["FrmWeclome"], "首页", tabId);
        }
        [WinformMethod]
        public string GetBackGroundImage()
        {
            return CustomConfigManager.GetBackgroundImage();
        }
        [WinformMethod]
        public void ReLogin()
        {
            frmlogin.isReLogin = true;
            ((Form)frmlogin).ShowDialog();
        }


        #region 登录
        [WinformMethod]
        public void UserLogin()
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(frmlogin.usercode);
                request.AddData(frmlogin.password);
            });


            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "LoginController", "UserLogin", requestAction);
            
            frmmain.UserName = retdata.GetData<string>(0);
            frmmain.DeptName = retdata.GetData<string>(1);
            frmmain.WorkName = retdata.GetData<string>(2);

            frmmain.modules = retdata.GetData<List<BaseModule>>(3);
            frmmain.menus = retdata.GetData<List<BaseMenu>>(4);
            frmmain.depts = retdata.GetData<List<BaseDept>>(5);

            AppGlobal.cache.Add("RoleUser", retdata.GetData<SysLoginRight>(6));

            frmmain.showSysMenu();
            ShowWeclomeForm();
            //((Form)frmmain).Icon = System.Drawing.Icon.ExtractAssociatedIcon(EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"images\msn.ico");
            ((Form)frmmain).Show();
            EFWCoreLib.WinformFrame.WinformGlobal.winfromMain.MainForm = (System.Windows.Forms.Form)frmmain;
            ////InitMessageForm();//?
            CustomConfigManager.xmlDoc = null;
        }

        #endregion

        #region 设置
        [WinformMethod]
        public void OpenSetting()
        {
            List<InputLanguage> list = new List<InputLanguage>();
            foreach (InputLanguage val in InputLanguage.InstalledInputLanguages)
            {
                list.Add(val);
            }
            ((IfrmSetting)iBaseView["FrmSetting"]).languageList = list;
            ((IfrmSetting)iBaseView["FrmSetting"]).inputMethod_CH = CustomConfigManager.GetInputMethod(EN_CH.CH);
            ((IfrmSetting)iBaseView["FrmSetting"]).inputMethod_EN = CustomConfigManager.GetInputMethod(EN_CH.EN);

            //打印机
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;
            string _classname = "SELECT * FROM Win32_Printer";

            query = new ManagementObjectSearcher(_classname);
            queryCollection = query.Get();
            ((IfrmSetting)iBaseView["FrmSetting"]).loadPrinter(queryCollection, CustomConfigManager.GetPrinter(0), CustomConfigManager.GetPrinter(1), CustomConfigManager.GetPrinter(2));
            //消息
            ((IfrmSetting)iBaseView["FrmSetting"]).runacceptMessage = CustomConfigManager.GetrunacceptMessage() == 1 ? true : false;
            ((IfrmSetting)iBaseView["FrmSetting"]).displayWay = CustomConfigManager.GetDisplayWay() == 1 ? true : false;
            ((IfrmSetting)iBaseView["FrmSetting"]).setbackgroundImage = CustomConfigManager.GetBackgroundImage();
            ((IfrmSetting)iBaseView["FrmSetting"]).mainStyle = CustomConfigManager.GetMainStyle();
            ((Form)iBaseView["FrmSetting"]).ShowDialog();
        }
        [WinformMethod]
        public void SaveSetting()
        {
            ((Form)iBaseView["FrmSetting"]).Close();
            CustomConfigManager.SaveConfig(((IfrmSetting)iBaseView["FrmSetting"]).inputMethod_EN, ((IfrmSetting)iBaseView["FrmSetting"]).inputMethod_CH, ((IfrmSetting)iBaseView["FrmSetting"]).printfirst, ((IfrmSetting)iBaseView["FrmSetting"]).printsecond, ((IfrmSetting)iBaseView["FrmSetting"]).printthree, ((IfrmSetting)iBaseView["FrmSetting"]).runacceptMessage ? 1 : 0, ((IfrmSetting)iBaseView["FrmSetting"]).displayWay ? 1 : 0, ((IfrmSetting)iBaseView["FrmSetting"]).setbackgroundImage, ((IfrmSetting)iBaseView["FrmSetting"]).mainStyle);
        }
        #endregion

        #region 切换科室
        [WinformMethod]
        public void OpenReDept()
        {
            ((IfrmReSetDept)iBaseView["ReDept"]).UserName = base.LoginUserInfo.EmpName;
            ((IfrmReSetDept)iBaseView["ReDept"]).WorkName = base.LoginUserInfo.WorkName;
            ((IfrmReSetDept)iBaseView["ReDept"]).loadDepts(frmmain.depts, LoginUserInfo.DeptId);
            ((Form)iBaseView["ReDept"]).ShowDialog();
        }
        [WinformMethod]
        public void SaveReDept()
        {
            BaseDept dept = ((IfrmReSetDept)iBaseView["ReDept"]).getDept();
            ((SysLoginRight)EFWCoreLib.CoreFrame.Init.AppGlobal.cache.GetData("RoleUser")).DeptId = dept.DeptId;
            ((SysLoginRight)EFWCoreLib.CoreFrame.Init.AppGlobal.cache.GetData("RoleUser")).DeptName = dept.Name;
            frmmain.DeptName = dept.Name;

            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(dept.DeptId);
                request.AddData(dept.Name);
            });
            InvokeWcfService("MainFrame.Service", "LoginController", "SaveReDept", requestAction);
        }
        #endregion

        #region 修改密码
        [WinformMethod]
        public void OpenPass()
        {
            ((IfrmPassWord)iBaseView["FrmPassWord"]).clearPass();
            ((Form)iBaseView["FrmPassWord"]).ShowDialog();
        }
        [WinformMethod]
        public void AlterPass()
        {
            string oldpass = ((IfrmPassWord)iBaseView["FrmPassWord"]).oldpass;
            string newpass = ((IfrmPassWord)iBaseView["FrmPassWord"]).newpass;

            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(LoginUserInfo.UserId);
                request.AddData(oldpass);
                request.AddData(newpass);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "LoginController", "AlterPass", requestAction);
            if (retdata.GetData<bool>(0) == false)
                throw new Exception("您输入的原始密码不正确！");
        }
        #endregion

        [WinformMethod]
        public List<BaseMessage> GetNotReadMessages()
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(LoginUserInfo.EmpId);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "LoginController", "GetNotReadMessages", requestAction);
            return retdata.GetData<List<BaseMessage>>(0);
        }

        [WinformMethod]
        public void MessageRead(int[] messageIds)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(messageIds);
                //request.AddData(LoginUserInfo.EmpId);
            });
            Object retdata = InvokeWcfService("MainFrame.Service", "LoginController", "MessageRead", requestAction);
        }

        [WinformMethod]
        public string GetSysName()
        {
            string val = AppPluginManage.getbaseinfoDataValue(_pluginName, "SystemName");
            return val ?? "";
        }
        [WinformMethod]
        public string GetLoginBackgroundImage()
        {
            return AppGlobal.AppRootPath + "images\\login.png";
        }
        [WinformMethod]
        public string GetWebserverUrl()
        {
            string val = AppPluginManage.getbaseinfoDataValue(_pluginName, "WEB_serverUrl");
            return val ?? "";
        }

        [WinformMethod]
        public void ShowForm(Form form, string tabName, string tabId)
        {
            frmmain.ShowForm(form, tabName, tabId);
        }

        [WinformMethod]
        public void ShowBalloonMessage(string CaptionText, string Text)
        {
            frmmain.ShowBalloon(CaptionText, Text);
        }

        [WinformMethod]
        public void CloseForm(string tabId)
        {
            frmmain.CloseForm(tabId);
        }

        [WinformMethod]
        public void ShowRightForm(Form form, int width, bool Collapsed)
        {
            frmmain.ShowRightForm(form, width, Collapsed);
        }

        [WinformMethod]
        public void ShowBrowser(string tabName,string url)
        {
            frmmain.ShowBrowser(tabName, url);
        }

        /// <summary>
        /// 展示报表弹窗
        /// </summary>
        [WinformMethod]
        public void ShowConfigure()
        {
            InvokeController("MainFrame.UI", "ReportConfigureController", "ShowConfigure");
        }
    }
}
