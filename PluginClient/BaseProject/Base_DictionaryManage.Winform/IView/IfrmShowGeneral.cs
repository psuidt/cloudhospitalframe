using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using base_dictionarymanage.Entity;

namespace base_dictionarymanage.winform.IView
{
    public interface IfrmShowGeneral:IBaseView
    {
        void loadLayerTree(List<BaseGeneralLayer> layerList, List<BaseGeneralTitle> grouptitleList);
        void loadfieldsCombo(List<BaseGeneralField> fieldList);
        void createGridColumn(List<BaseGeneralField> fieldList);
        DataTable resultGrid { get; set; }
    }
}
