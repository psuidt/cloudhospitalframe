using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.WinformFrame.Controller;

namespace WinMainUIFrame.Winform.IView
{
    public interface IFrmReportConfigure : IBaseView
    {
        /// <summary>
        /// 读取报表数据
        /// </summary>
        /// <param name="dt">数据集</param>
        void LoadReportGrid(DataTable dt);
    }
}
