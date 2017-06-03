using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WinformFrame.Controller;
using base_reportmanage.Entity;

namespace base_reportmanage.winform.IView
{
    public interface IfrmShowReport:IBaseView
    {
        void loadLayerTree(List<BaseReportLayer> layerList, List<BaseReportTitle> usertitleList);
        void loadQueryControl(List<BaseReportField> fieldList);
    }
}
