using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 打印机配置控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmReportConfigure")]//与系统菜单对应
    [WinformView(Name = "FrmReportConfigure", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.FrmReportConfigure")]
    public class ReportConfigureController : WcfClientController
    {
        /// <summary>
        /// 打印机配置接口
        /// </summary>
        IFrmReportConfigure frmReportConfigure;

        /// <summary>
        /// 控制器初始化
        /// </summary>
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
