using System;
using System.Collections.Generic;
using System.Drawing;
using DevComponents.AdvTree;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.ItemManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    /// <summary>
    /// 中心统计大类维护
    /// </summary>
    public partial class FrmCenterStatItem : BaseFormBusiness, IfrmCenterStatItem
    {
        /// <summary>
        /// 中心统计大类
        /// </summary>
        private Basic_CenterStatItem currStatItem;

        /// <summary>
        /// 中心统计大类
        /// </summary>
        public Basic_CenterStatItem CurrStatItem
        {
            get
            {
                return currStatItem;
            }

            set
            {
                currStatItem = value;
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        public int IsAll
        {
            get
            {
                return ckAll.Checked ? 1 : 0;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmCenterStatItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定统计大类树
        /// </summary>
        /// <param name="listStat">统计大类数据</param>
        public void loadStatItemTree(List<Basic_CenterStatItem> listStat)
        {
            treeStat.Nodes.Clear();
            treeStat.BeginUpdate();
            foreach (Basic_CenterStatItem item in listStat.FindAll(x => x.PStatID == -1))
            {
                Node node = new Node();
                node.DragDropEnabled = false;
                node.Tag = item;
                node.Text = item.StatName;
                node.Cells.Add(new Cell(item.StatID.ToString()));
                node.Cells.Add(new Cell(item.DelFlag == 1 ? "已停用" : "已启用"));
                if (item.DelFlag == 1)
                {
                    node.Style = new DevComponents.DotNetBar.ElementStyle(Color.Red);
                }

                treeStat.Nodes.Add(node);
                loadchildtree(listStat, node, item.StatID);
                node.ExpandVisibility = eNodeExpandVisibility.Auto;
            }

            treeStat.EndUpdate();
            treeStat.ExpandAll();
        }

        /// <summary>
        /// 加载统计大类
        /// </summary>
        /// <param name="listStat">统计大类列表</param>
        /// <param name="pnode">选中节点</param>
        /// <param name="pstatid">父ID</param>
        private void loadchildtree(List<Basic_CenterStatItem> listStat, Node pnode, int pstatid)
        {
            foreach (Basic_CenterStatItem item in listStat.FindAll(x => x.PStatID == pstatid))
            {
                Node node = new Node();
                node.DragDropEnabled = false;
                node.Tag = item;
                node.Text = item.StatName;
                node.Cells.Add(new Cell(item.StatID.ToString()));
                node.Cells.Add(new Cell(item.DelFlag == 1 ? "已停用" : "已启用"));
                if (item.DelFlag == 1)
                {
                    node.Style = new DevComponents.DotNetBar.ElementStyle(Color.Red);
                }

                pnode.Nodes.Add(node);
                loadchildtree(listStat, node, item.StatID);
                node.ExpandVisibility = eNodeExpandVisibility.Auto;
            }
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmCenterStatItem_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("GetStatItemData", ckAll.Checked ? 1 : 0);
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void ckAll_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            InvokeController("GetStatItemData", ckAll.Checked ? 1 : 0);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            CurrStatItem = new Basic_CenterStatItem();
            if (treeStat.SelectedNode != null)
            {
                Basic_CenterStatItem item = treeStat.SelectedNode.Tag as Basic_CenterStatItem;
                CurrStatItem.PStatID = item.StatID;
                CurrStatItem.PStatName = item.StatName;
            }
            else
            {
                CurrStatItem.PStatID = -1;
                CurrStatItem.PStatName = string.Empty;
            }

            InvokeController("ShowDialog", "FrmAddStatItem");
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (treeStat.SelectedNode == null)
            {
                return;
            }

            CurrStatItem = treeStat.SelectedNode.Tag as Basic_CenterStatItem;
            InvokeController("ShowDialog", "FrmAddStatItem");
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (treeStat.SelectedNode == null)
            {
                return;
            }

            Basic_CenterStatItem item = treeStat.SelectedNode.Tag as Basic_CenterStatItem;
            InvokeController("StopStatItem", item.StatID, item.DelFlag);
            InvokeController("GetStatItemData", ckAll.Checked ? 1 : 0);
        }

        /// <summary>
        /// 选中统计大类
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void treeStat_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }

            Basic_CenterStatItem item = e.Node.Tag as Basic_CenterStatItem;
            if (item.DelFlag == 0)
            {
                btnStop.Text = "停用";
            }
            else
            {
                btnStop.Text = "启用";
            }

            bar1.Refresh();
        }
    }
}
