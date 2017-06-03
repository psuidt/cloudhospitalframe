using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using base_businessremind.Entity;
using EFWCoreLib.WinformFrame.Controller;

namespace base_businessremind.winform.IView
{
    public interface IfrmMessageSubscribe : IBaseView
    {
        void loadMessageTypeDt(DataTable dt);
        void loadTime(DataTable dt);
    }
}
