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
    public partial class frmEditField : DialogForm, IfrmEditField
    {
        public frmEditField()
        {
            InitializeComponent();
            frmForm1.AddItem(textBoxX1, "Name", "请输入中文名称");
            frmForm1.AddItem(textBoxX2, "ColName");
            frmForm1.AddItem(checkBoxX1, "IsKey");
            frmForm1.AddItem(checkBoxX2, "IsMust");
            frmForm1.AddItem(comboBoxEx1, "UiType");
            frmForm1.AddItem(comboBoxEx2, "DataUnitId");
            frmForm1.AddItem(textBoxX7, "DynamicSQL");
            frmForm1.AddItem(textBoxX8, "MatchRegular");
        }

        #region IfrmEditField 成员
        private BaseGeneralField _currField;
        public BaseGeneralField currField
        {
            get
            {
                frmForm1.GetValue<BaseGeneralField>(_currField);
                return _currField;
            }
            set
            {
                _currField = value;
                frmForm1.Load<BaseGeneralField>(_currField);
                if (_currField.DataUnitId == null || _currField.DataUnitId == "")
                    comboBoxEx2.SelectedValue = -1;
                else
                    comboBoxEx2.SelectedValue = Convert.ToInt32(_currField.DataUnitId);
            }
        }

        public void loadUitype(DataTable dt)
        {
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "name";
            comboBoxEx1.ValueMember = "id";
        }

        public void loadUnitType(List<BaseGeneralDataUnit> unitList)
        {
            comboBoxEx2.DataSource = unitList;
            comboBoxEx2.DisplayMember = "Name";
            comboBoxEx2.ValueMember = "DataUnitId";
        }


        #endregion

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEx1.Text == "combobox")
            {
                comboBoxEx2.Enabled = true;
                textBoxX7.Enabled = true;
                buttonX1.Enabled = true;
            }
            else
            {
                comboBoxEx2.Enabled = false;
                textBoxX7.Enabled = false;
                buttonX1.Enabled = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            InvokeController("ShowUnitData", comboBoxEx2.SelectedValue, textBoxX7.Text);
        }

        private void frmEditField_SaveEventHandler(object sender, EventArgs e)
        {
            InvokeController("SaveField");
        }
    }
}
