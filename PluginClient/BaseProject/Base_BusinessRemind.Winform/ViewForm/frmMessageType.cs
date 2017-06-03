using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.WinformFrame.Controller;
using base_businessremind.winform.IView;
using base_businessremind.Entity;
using DevComponents.DotNetBar;

namespace base_businessremind.winform.Viewform
{
    public partial class frmMessageType : BaseForm, IfrmMessageType
    {
        public frmMessageType()
        {
            InitializeComponent();

            frmForm1.AddItem(textBoxX1, "Code", "请输入编码");
            frmForm1.AddItem(textBoxX2, "Name", "请输入名称");
            frmForm1.AddItem(checkBoxX1, "WorkFlag");
            frmForm1.AddItem(checkBoxX2, "DeptFlag");
            frmForm1.AddItem(integerInput1, "Limittime1", "请输入有效时间");
            frmForm1.AddItem(comboBoxEx1, "Limittime2", "请选择有效时间类型");
            frmForm1.AddItem(textBoxX4, "titletpl");
            frmForm1.AddItem(textBoxX5, "texttpl");
            dataGrid1.AutoGenerateColumns = false;
        }

        #region IfrmMessageType 成员

        public void loadMessageTypeGrid(List<BaseMessageType> typeList)
        {
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = typeList;
        }

        private List<BaseGroup> _groupList;
        public void loadGroupList(List<BaseGroup> groupList)
        {
            _groupList = groupList;
            checkedListBox1.Items.Clear();
            foreach (BaseGroup val in groupList)
            {
                checkedListBox1.Items.Add(val.Name);
            }
        }

        public void loadLimittimeData(DataTable dt)
        {
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "Name";
            comboBoxEx1.ValueMember = "Id";
        }

        private BaseMessageType _currMessageType;
        public BaseMessageType currMessageType
        {
            get
            {
                frmForm1.GetValue<BaseMessageType>(_currMessageType);
                string _ReceiveGroup = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true)
                    {
                        if (_ReceiveGroup == "") _ReceiveGroup += _groupList[i].GroupId.ToString();
                        else
                            _ReceiveGroup += "," + _groupList[i].GroupId.ToString();
                    }
                }
                _currMessageType.ReceiveGroup = _ReceiveGroup;
                _currMessageType.Limittime = integerInput1.Value.ToString() + comboBoxEx1.SelectedValue.ToString();

                return _currMessageType;
            }
            set
            {
                _currMessageType = value;
                frmForm1.Load<BaseMessageType>(_currMessageType);

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }

                if (_currMessageType.ReceiveGroup != null)
                {
                    string[] _receiveGroups = _currMessageType.ReceiveGroup.Split(new char[] { ',' });
                    if (_receiveGroups[0] != "")
                    {

                        foreach (string val in _receiveGroups)
                        {
                            checkedListBox1.SetItemChecked(_groupList.FindIndex(x => x.GroupId == Convert.ToInt32(val)), true);
                        }
                    }
                }
                if (_currMessageType.Limittime != null)
                {
                    integerInput1.Value = Convert.ToInt32(_currMessageType.Limittime.Substring(0, _currMessageType.Limittime.Length - 1));
                    comboBoxEx1.SelectedValue = _currMessageType.Limittime.Substring(_currMessageType.Limittime.Length - 1, 1);
                }
                else
                {
                    integerInput1.Value = 1;
                    comboBoxEx1.SelectedValue = "Y";
                }
            }
        }

        #endregion

        private void frmMessageType_Load(object sender, EventArgs e)
        {
            InvokeController("LoadMessageTypeData");
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int id = Convert.ToInt32(dataGrid1["Id", dataGrid1.CurrentCell.RowIndex].Value);
                InvokeController("GetCurrMessageType", id);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            InvokeController("NewMessageType");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (frmForm1.Validate())
            {
                InvokeController("SaveMessageType");
                MessageBoxEx.Show("消息类型保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrid1.Columns["btnDel"].Index && e.RowIndex > -1)
            {
                if (MessageBoxEx.Show("你确实需要删除此消息类型？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    int Id = Convert.ToInt32(dataGrid1["Id", e.RowIndex].Value);
                    InvokeController("DeleteMessageType", Id);
                }
            }
        }

    }
}
