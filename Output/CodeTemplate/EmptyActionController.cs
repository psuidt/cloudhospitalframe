using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormFrame.Common.Controller;
using ${Form.AppName}.FormUI.IViewform;
using ${Form.AppName}.FormUI.Viewform;

namespace ${Form.AppName}.FormUI.Ation
{
    [WinFormFrame.Common.Menu(DefaultName = "${Form.MenuDefaultName}", Memo = "")]
    [WinFormFrame.Common.View(ViewType = typeof(${Form.ViewformName}), Memo = "")]
    [WinFormFrame.Common.Service(ServiceType = typeof(${Form.ServiceName}), Memo = "")]
    public class ${Form.ClassName} : BaseController
    {
        public ${Form.IViewformName} _iView;
        private ${Form.ServiceName} _service;



        public ${Form.ClassName}(${Form.IViewformName} iView, ${Form.ServiceName} service)
            : base(iView, service)
        {
            _iView = iView;
            _service = service;
        }

        public override object UI_ControllerEvent(string eventname, params object[] objs)
        {
            return base.UI_ControllerEvent(eventname, objs);
        }
    }
}
