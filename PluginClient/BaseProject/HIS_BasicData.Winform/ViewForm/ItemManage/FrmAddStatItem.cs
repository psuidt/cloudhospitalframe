using System;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.Controller;
using HIS_BasicData.Winform.IView.ItemManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    /// <summary>
    /// 统计大类
    /// </summary>
    public partial class FrmAddStatItem : BaseFormBusiness, IfrmAddStatItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmAddStatItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 统计大类
        /// </summary>
        Basic_CenterStatItem currStatItem;

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmAddStatItem_Shown(object sender, EventArgs e)
        {
            currStatItem = ((InvokeController("this") as StatItemController).iBaseView["FrmCenterStatItem"] as IfrmCenterStatItem).CurrStatItem;

            //新增
            if (currStatItem.StatID == 0)
            {
                this.Text = "新增统计大类";
                ckroot.Enabled = true;
                if (currStatItem.PStatID == -1)
                {
                    ckroot.Enabled = false;
                    ckroot.Checked = true;
                }
                else
                {
                    ckroot.Checked = false;
                }

                txtupstat.Text = currStatItem.PStatName;
                txtStatName.Text = string.Empty;
                ckDelflag.CheckValue = 0;
                txtStatName.Focus();
            }
            else
            {
                this.Text = "修改统计大类";
                ckroot.Enabled = false;
                if (currStatItem.PStatID == -1)
                {
                    ckroot.Checked = true;
                }
                else
                {
                    ckroot.Checked = false;
                }

                txtupstat.Text = currStatItem.PStatName;
                txtStatName.Text = currStatItem.StatName;
                ckDelflag.CheckValue = currStatItem.DelFlag;
                txtStatName.Focus();
            }
        }

        /// <summary>
        /// 是否为根节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void ckroot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckroot.Checked)
            {
                txtupstat.Text = string.Empty;
            }
            else
            {
                txtupstat.Text = currStatItem.PStatName;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatName.Text == string.Empty)
                {
                    MessageBox.Show("名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ckroot.Checked)
                {
                    currStatItem.PStatID = -1;
                }

                currStatItem.StatName = txtStatName.Text;
                currStatItem.DelFlag = Convert.ToInt32(ckDelflag.CheckValue);
                currStatItem.PyCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(currStatItem.StatName);
                currStatItem.WbCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(currStatItem.StatName);
                InvokeController("SaveStatItem", currStatItem);
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("保存统计大类失败！\n" + err.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
