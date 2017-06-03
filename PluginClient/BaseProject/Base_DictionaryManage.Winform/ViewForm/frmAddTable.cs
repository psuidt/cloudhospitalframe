using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using base_dictionarymanage.Entity;
using base_dictionarymanage.winform.IView;
using EfwControls.CustomControl;
using EFWCoreLib.WinformFrame.Controller;

namespace base_dictionarymanage.winform.ViewForm
{
    public partial class frmAddTable : DialogForm,IfrmAddTable
    {
        public frmAddTable()
        {
            InitializeComponent();
            frmForm1.AddItem(textBoxX1, "Name", "请输入名称");
            frmForm1.AddItem(comboBoxEx1, "TableName", "请选择一个表");
            frmForm1.AddItem(textBoxX2, "Memo");
        }

        #region IfrmAddTable 成员
        private BaseGeneralTitle _currTitle;
        public BaseGeneralTitle currTitle
        {
            get
            {
                frmForm1.GetValue<BaseGeneralTitle>(_currTitle);
                return _currTitle;
            }
            set
            {
                _currTitle = value;
                frmForm1.Load<BaseGeneralTitle>(_currTitle);
            }
        }

        public void loadTable(DataTable dt)
        {
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "tabname";
            comboBoxEx1.ValueMember = "tabname";
        }

        #endregion

        private void frmAddTable_SaveEventHandler(object sender, EventArgs e)
        {
            InvokeController("SaveTitle");
        }
    }
}
