using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WinformFrame.Controller;
using base_reportmanage.Entity;
//using WinMainUIFrame.Entity;

namespace base_reportmanage.winform.IView
{
    public interface IfrmGroupReport:IBaseView
    {
        void loadGroupGrid(List<BaseGroup> groupList);
        void loadTableTree(List<BaseReportLayer> layerList, List<BaseReportTitle> titleList, List<BaseReportTitle> grouptitleList);
    }
}
