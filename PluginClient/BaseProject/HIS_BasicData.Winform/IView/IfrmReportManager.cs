using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView
{
    /// <summary>
    /// 报表管理接口
    /// </summary>
    public interface IfrmReportManager : IBaseView
    {
        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构</param>
        void loadWorkerDataBox(DataTable dt, int defaultWorkID);

        /// <summary>
        /// 绑定系统类型列表
        /// </summary>
        /// <param name="dt">系统类型列表</param>
        void loadSystemTypeBox(DataTable dt);

        /// <summary>
        /// 绑定报表列表
        /// </summary>
        /// <param name="dt">报表列表</param>
        void loadReportGrid(DataTable dt);

        /// <summary>
        /// 选中的报表配置
        /// </summary>
        Basic_ReportConfig CurrReport { get; set; }

        /// <summary>
        /// 取得机构ID
        /// </summary>
        int getWorkId { get; }

        /// <summary>
        /// 取得报表类型
        /// </summary>
        int getSysType { get; }
    }
}
