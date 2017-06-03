using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView
{
    /// <summary>
    /// 参数维护接口
    /// </summary>
    public interface IfrmParameter: IBaseView
    {
        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构</param>
        void loadWorkerDataBox(DataTable dt, int defaultWorkID);

        /// <summary>
        /// 加载系统参数类型列表
        /// </summary>
        /// <param name="dt">系统参数类型列表</param>
        void loadSystemTypeBox(DataTable dt);

        /// <summary>
        /// 绑定系统参数列表
        /// </summary>
        /// <param name="dt">系统参数列表</param>
        void loadSystemConfigGrid(DataTable dt);

        /// <summary>
        /// 选中参数
        /// </summary>
        Basic_SystemConfig CurrConfig { get; set; }
    }
}
