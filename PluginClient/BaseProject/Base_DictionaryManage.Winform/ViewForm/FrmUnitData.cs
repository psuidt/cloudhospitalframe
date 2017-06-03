using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using base_dictionarymanage.winform.IView;
using EFWCoreLib.WinformFrame.Controller;

namespace base_dictionarymanage.winform.ViewForm
{
    public partial class FrmUnitData : BaseForm, IfrmUnitData
    {
        public FrmUnitData()
        {
            InitializeComponent();
        }

        #region IfrmUnitData 成员

        public void loadUnitData(DataTable dt)
        {
            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.DataSource = dt;
        }

        #endregion

        #region IfrmUnitData 成员


        public void UnitDataShowDialog()
        {
            this.ShowDialog();
        }

        #endregion
    }
}
