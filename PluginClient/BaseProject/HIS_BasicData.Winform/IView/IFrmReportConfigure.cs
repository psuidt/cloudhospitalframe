using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.IView
{
    /// <summary>
    /// 打印机配置接口
    /// </summary>
    public interface IFrmReportConfigure : IBaseView
    {
        /// <summary>
        /// 读取报表数据
        /// </summary>
        /// <param name="dt">数据集</param>
        void LoadReportGrid(DataTable dt);
    }
}
