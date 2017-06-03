using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WinformFrame.Controller;
using base_dictionarymanage.Entity;

namespace base_dictionarymanage.winform.IView
{
    public interface IfrmGeneralConfiguration:IBaseView
    {
        void loadLayerTree(List<BaseGeneralLayer> layerList, List<BaseGeneralTitle> titleList);
        void loadFieldGrid(List<BaseGeneralField> fieldList);
    }
}
