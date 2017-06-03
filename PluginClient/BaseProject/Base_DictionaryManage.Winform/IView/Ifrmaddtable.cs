using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using base_dictionarymanage.Entity;

namespace base_dictionarymanage.winform.IView
{
    public interface IfrmAddTable:IBaseView
    {
        BaseGeneralTitle currTitle { get; set; }
        void loadTable(DataTable dt);
    }
}
