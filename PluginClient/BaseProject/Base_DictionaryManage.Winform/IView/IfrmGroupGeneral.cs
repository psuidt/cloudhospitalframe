using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WinformFrame.Controller;
using base_dictionarymanage.Entity;
//using WinMainUIFrame.Entity;

namespace base_dictionarymanage.winform.IView
{
    public interface IfrmGroupGeneral:IBaseView
    {
        void loadGroupGrid(List<BaseGroup> groupList);
        void loadTableTree(List<BaseGeneralLayer> layerList, List<BaseGeneralTitle> titleList, List<BaseGeneralTitle> grouptitleList);
    }
}
