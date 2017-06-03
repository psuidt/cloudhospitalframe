using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using base_businessremind.Entity;
using EFWCoreLib.WinformFrame.Controller;

namespace base_businessremind.winform.IView
{
    public interface IfrmMessageType : IBaseView
    {
        void loadMessageTypeGrid(List<BaseMessageType> typeList);
        void loadGroupList(List<BaseGroup> groupList);
        void loadLimittimeData(DataTable dt);

        BaseMessageType currMessageType { get; set; }
    }
}
