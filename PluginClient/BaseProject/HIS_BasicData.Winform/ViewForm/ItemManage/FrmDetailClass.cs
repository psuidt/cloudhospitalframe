using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.ItemManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    /// <summary>
    /// 明细分类维护
    /// </summary>
    public partial class FrmDetailClass : BaseFormBusiness, IfrmDetailClass
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmDetailClass()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 统计大类分类明细
        /// </summary>
        private Basic_StatItemSubclass currSubClass;

        /// <summary>
        /// 统计大类分类明细
        /// </summary>
        public Basic_StatItemSubclass CurrSubClass
        {
            get
            {
                currSubClass.SubName = txtItemName.Text;
                currSubClass.OrderNum = txtOrder.Value;
                currSubClass.DelFlag = ckdelflag.Checked ? 1 : 0;
                currSubClass.PyCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(currSubClass.SubName);
                currSubClass.WbCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(currSubClass.SubName);
                return currSubClass;
            }

            set
            {
                currSubClass = value;
                txtItemName.Text = currSubClass.SubName;
                txtOrder.Value = currSubClass.OrderNum;
                ckdelflag.Checked = currSubClass.DelFlag == 1 ? true : false;
            }
        }

        /// <summary>
        /// 绑定统计大类分类明细
        /// </summary>
        /// <param name="listsubclass">统计大类分类明细列表</param>
        public void loadSubClassGrid(List<Basic_StatItemSubclass> listsubclass)
        {
            gridDetail.DataSource = listsubclass;
            for (int i = 0; i < listsubclass.Count; i++)
            {
                if (listsubclass[i].DelFlag == 1)
                {
                    gridDetail.SetRowColor(i, Color.Red, true);
                }
            }
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmDetailClass_Shown(object sender, EventArgs e)
        {
            treeClass.ExpandAll();
            treeClass_AfterSelect(null, null);
        }

        /// <summary>
        /// 选中分类
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void treeClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeClass.SelectedNode != null && Convert.ToInt32(treeClass.SelectedNode.Tag)>0)
            {
                InvokeController("GetSubClassData", Convert.ToInt32(treeClass.SelectedNode.Tag));
                Editpanel.Enabled = true;
            }
            else
            {
                gridDetail.DataSource = null;
                Editpanel.Enabled = false;
            }
        }

        /// <summary>
        /// 选中明细分类
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridDetail.CurrentCell != null)
            {
                List<Basic_StatItemSubclass> listsubclass = gridDetail.DataSource as List<Basic_StatItemSubclass>;
                CurrSubClass = listsubclass[gridDetail.CurrentCell.RowIndex];
                SetbtnState(OperType.默认);
            }
        }

        /// <summary>
        /// 这是界面控件状态
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnState(OperType type)
        {
            if (type == OperType.新增)
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                txtItemName.Text = string.Empty;
                txtOrder.Value = 0;
                ckdelflag.Checked = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (treeClass.SelectedNode != null && Convert.ToInt32(treeClass.SelectedNode.Tag) > 0)
            {
                SetbtnState(OperType.新增);
                currSubClass = new Basic_StatItemSubclass();
                currSubClass.SubType = Convert.ToInt32(treeClass.SelectedNode.Tag);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == string.Empty)
            {
                MessageBox.Show("名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemName.Focus();
                return;
            }

            InvokeController("SaveSubClass");
            InvokeController("GetSubClassData", currSubClass.SubType);

            SetbtnState(OperType.默认);
        }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperType
    {
        默认, 新增
    }
}
