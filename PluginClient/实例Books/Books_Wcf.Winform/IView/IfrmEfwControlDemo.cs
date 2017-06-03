using EFWCoreLib.WinformFrame.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Wcf.Winform.IView
{
    public interface IfrmEfwControlDemo: IBaseView
    {
        void bindDisease_textboxcard(DataTable dt);
        void bindDept_multiSelectText(DataTable dt);
        void bindDisease_datagridpage(DataTable dt,int totalCount);
        void bindDiaease_gridboxcardSD(DataTable sourceDt);
        void bindDiaease_gridboxcard(DataTable dt);
    }
}
