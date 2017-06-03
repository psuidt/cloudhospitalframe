using System.Collections.Generic;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.ItemManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 统计大类控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmCenterStatItem")]//与系统菜单对应
    [WinformView(Name = "FrmCenterStatItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.ItemManage.FrmCenterStatItem")]
    [WinformView(Name = "FrmAddStatItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.ItemManage.FrmAddStatItem")]
    [WinformView(Name = "FrmStatItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.ItemManage.FrmStatItem")]
    [WinformView(Name = "FrmDetailClass", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.ItemManage.FrmDetailClass")]
    public class StatItemController : WcfClientController
    {
        /// <summary>
        /// 中心统计大类接口
        /// </summary>
        private IfrmCenterStatItem frmCenterStatItem;

        /// <summary>
        /// 新增统计大类接口
        /// </summary>
        private IfrmAddStatItem frmAddStatItem;

        /// <summary>
        /// 统计大类接口
        /// </summary>
        private IfrmStatItem frmStatItem;

        /// <summary>
        /// 分类明细接口
        /// </summary>
        private IfrmDetailClass frmDetailClass;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmCenterStatItem = iBaseView["FrmCenterStatItem"] as IfrmCenterStatItem;
            frmAddStatItem = iBaseView["FrmAddStatItem"] as IfrmAddStatItem;
            frmStatItem = iBaseView["FrmStatItem"] as IfrmStatItem;
            frmDetailClass = iBaseView["FrmDetailClass"] as IfrmDetailClass;
        }

        /// <summary>
        /// 获取统计大类
        /// </summary>
        /// <param name="isall">是否显示全部</param>
        [WinformMethod]
        public void GetStatItemData(int isall)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "StatItemController",
              "GetStatItemData",
              (request) =>
              {
                  request.AddData(isall);//只显示正常的
              });
            List<Basic_CenterStatItem> listStat = retdata.GetData<List<Basic_CenterStatItem>>(0);
            frmCenterStatItem.loadStatItemTree(listStat);
        }

        /// <summary>
        /// 停用/启用
        /// </summary>
        /// <param name="statID">统计大类ID</param>
        /// <param name="val">状态</param>
        [WinformMethod]
        public void StopStatItem(int statID, int val)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "StatItemController",
              "SwitchStatItem",
              (request) =>
              {
                  request.AddData(statID);
                  request.AddData(val == 1 ? 0 : 1);
              });
        }

        /// <summary>
        /// 保存统计大类
        /// </summary>
        /// <param name="statitem">统计大类数据</param>
        [WinformMethod]
        public void SaveStatItem(Basic_CenterStatItem statitem)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "StatItemController",
              "SaveStatItem",
              (request) =>
              {
                  request.AddData(statitem);
              });

            GetStatItemData(frmCenterStatItem.IsAll);
        }

        /// <summary>
        /// 初始化本院数据
        /// </summary>
        [WinformMethod]
        public void InitHostData()
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "StatItemController",
             "GetWorkerData");
            List<BaseWorkers> workers = retdata.GetData<List<BaseWorkers>>(0);
            frmStatItem.loadWorkers(ConvertExtend.ToDataTable(workers), LoginUserInfo.WorkId);

            GetHostStatItemData(0);
            GetAllSubClassData();
        }

        /// <summary>
        /// 加载分类明细数据
        /// </summary>
        /// <param name="subType">类型</param>
        /// <returns>分类明细数据</returns>
        private List<Basic_StatItemSubclass> loadSubClassData(int subType)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "StatItemController",
            "GetSubClassData",
            (request) =>
            {
                request.AddData(frmStatItem.CurrWorkID);
                request.AddData(subType);
            });

            List<Basic_StatItemSubclass> listsubclass = retdata.GetData<List<Basic_StatItemSubclass>>(0);
            return listsubclass;
        }

        /// <summary>
        /// 获取本院统计大类
        /// </summary>
        /// <param name="isAll">是否显示全部</param>
        [WinformMethod]
        public void GetHostStatItemData(int isAll)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "StatItemController",
             "GetHostStatItemData",
             (request) =>
             {
                 request.AddData(frmStatItem.CurrWorkID);
                 request.AddData(isAll);
             });

            List<Basic_CenterStatItem> listStat= retdata.GetData<List<Basic_CenterStatItem>>(0);
            List<Basic_StatItem> listItem = retdata.GetData<List<Basic_StatItem>>(1);
            List<Basic_StatItemSubclass> listsubclass = loadSubClassData(0);
            frmStatItem.loadStatItemTree(listStat, listItem,listsubclass);
        }

        /// <summary>
        /// 获取分类明细
        /// </summary>
        [WinformMethod]
        public void GetAllSubClassData()
        {
            List<Basic_StatItemSubclass> listsubclass = loadSubClassData(0);
            frmStatItem.loadSubClass(listsubclass);
        }

        /// <summary>
        /// 保存本院统计大类
        /// </summary>
        [WinformMethod]
        public void SaveHostStatItem()
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "StatItemController",
             "SaveHostStatItem",
             (request) =>
             {
                 request.AddData(frmStatItem.CurrWorkID);
                 request.AddData(frmStatItem.CurrStatItem);
             });

            MessageBoxShowSimple("保存成功！");
        }

        /// <summary>
        /// 获取分类明细数据
        /// </summary>
        /// <param name="subtype">类型</param>
        [WinformMethod]
        public void GetSubClassData(int subtype)
        {
            List<Basic_StatItemSubclass> listsubclass = loadSubClassData(subtype);
            frmDetailClass.loadSubClassGrid(listsubclass);
        }

        /// <summary>
        /// 保存分类明细
        /// </summary>
        [WinformMethod]
        public void SaveSubClass()
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "StatItemController",
             "SaveSubClass",
             (request) =>
             {
                 request.AddData(frmStatItem.CurrWorkID);
                 request.AddData(frmDetailClass.CurrSubClass);
             });

            MessageBoxShow("保存成功！",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information,System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
    }
}
