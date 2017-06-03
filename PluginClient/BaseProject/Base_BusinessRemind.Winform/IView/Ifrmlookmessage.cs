using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using base_businessremind.Entity;
using EFWCoreLib.WinformFrame.Controller;

namespace base_businessremind.winform.IView
{
    public interface IfrmLookMessage:IBaseView
    {
        void loadMessageList(List<BaseMessage> messageList);

    }
}
