using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.WinformFrame.Controller;

namespace base_reportmanage.winform.IView
{
    public interface IFrmReportDesigner : IBaseView
    {
        void loadreportfile(string reportfile);
    }
}
