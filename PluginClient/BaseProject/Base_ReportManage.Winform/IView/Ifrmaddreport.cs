using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using base_reportmanage.Entity;

namespace base_reportmanage.winform.IView
{
    public interface IfrmAddReport:IBaseView
    {
        BaseReportTitle currTitle { get; set; }
        void loadsp(DataTable dt);//导入存储过程
        void loadreporttype(DataTable dt);//导入报表类型
    }
}
