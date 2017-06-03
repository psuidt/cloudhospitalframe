using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using WinMainUIFrame.Winform.IView;

namespace WinMainUIFrame.Winform.Controller
{
    [WinformController(DefaultViewName = "FrmReportConfigure")]//与系统菜单对应
    [WinformView(Name = "FrmReportConfigure", DllName = "WinMainUIFrame.Winform.dll", ViewTypeName = "WinMainUIFrame.Winform.ViewForm.FrmReportConfigure")]
    public class ReportConfigureController : WcfClientController
    {
        IFrmReportConfigure frmReportConfigure;
        public override void Init()
        {
            frmReportConfigure = iBaseView["FrmReportConfigure"] as IFrmReportConfigure;
        }
        /// <summary>
        /// 展示报表弹窗
        /// </summary>
        [WinformMethod]
        public void ShowConfigure()
        {
            (frmReportConfigure as Form).ShowDialog();
        }

        /// <summary>
        /// 读取报表数据
        /// </summary>
        [WinformMethod]
        public void GetReportData()
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ReportController",
            "GetReportBasicData");
            DataTable dt = retdata.GetData<DataTable>(0);
            frmReportConfigure.LoadReportGrid(dt);
        }
    }
}
