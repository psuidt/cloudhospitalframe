using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevComponents.AdvTree;
using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_BasicData.Winform.IView.ItemManage;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.ItemManage
{
    /// <summary>
    /// 统计大类维护
    /// </summary>
    public partial class FrmStatItem : BaseFormBusiness, IfrmStatItem
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public int CurrWorkID
        {
            get
            {
                return Convert.ToInt32(cbWorkers.SelectedValue);
            }
        }

        /// <summary>
        /// 统计大类列表
        /// </summary>
        private List<Basic_CenterStatItem> listStat;

        /// <summary>
        /// 中心统计大类列表
        /// </summary>
        List<Basic_CenterStatItem> ListStat
        {
            get
            {
                return listStat;
            }
        }

        /// <summary>
        /// 统计大类列表
        /// </summary>
        private List<Basic_StatItem> listitem;

        /// <summary>
        /// 统计大类列表
        /// </summary>
        List<Basic_StatItem> Listitem
        {
            get
            {
                return listitem;
            }
        }

        /// <summary>
        /// 统计大类分类明细
        /// </summary>
        private List<Basic_StatItemSubclass> listsubclass;

        /// <summary>
        /// 统计大类分类明细
        /// </summary>
        List<Basic_StatItemSubclass> Listsubclass
        {
            get
            {
                return listsubclass;
            }
        }

        /// <summary>
        /// 选中的统计大类
        /// </summary>
        private Basic_StatItem currStatItem;

        /// <summary>
        /// 选中的统计大类
        /// </summary>
        public Basic_StatItem CurrStatItem
        {
            get
            {
                return currStatItem;
            }
        }

        /// <summary>
        /// 显示格式
        /// </summary>
        DevComponents.DotNetBar.ElementStyle centerStyle;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmStatItem()
        {
            InitializeComponent();
            centerStyle = new DevComponents.DotNetBar.ElementStyle();
            centerStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            frmFormItem.AddItem(txtStatName, "StatName");
            frmFormItem.AddItem(cbAccItem, "AccItemID");
            frmFormItem.AddItem(cbCostItem, "CostItemID");
            frmFormItem.AddItem(cbBaItem, "BaItemID");
            frmFormItem.AddItem(cbPoItem, "PoItemID");
            frmFormItem.AddItem(cbOutFpItem, "OutFpItemID");
            frmFormItem.AddItem(cbInFpItem, "InFpItemID");
        }
        
        /// <summary>
        /// 绑定统计大类列表
        /// </summary>
        /// <param name="listStat">中心统计大类</param>
        /// <param name="listitem">本院统计大类</param>
        /// <param name="listsubclass">分类明细</param>
        public void loadStatItemTree(List<Basic_CenterStatItem> listStat, List<Basic_StatItem> listitem, List<Basic_StatItemSubclass> listsubclass)
        {
            this.listStat = listStat;
            this.listitem = listitem;
            this.listsubclass = listsubclass;

            treeStat.Nodes.Clear();
            treeStat.BeginUpdate();
            foreach (Basic_CenterStatItem item in listStat.FindAll(x => x.PStatID == -1))
            {
                Node node = new Node();
                node.DragDropEnabled = false;
                node.Tag = item;
                node.Text = item.StatName;
                node.Cells.Add(new Cell(item.StatID.ToString(), centerStyle));
                node.Cells.Add(new Cell(getcellname(1, item.StatID)));
                node.Cells.Add(new Cell(getcellname(2, item.StatID)));
                node.Cells.Add(new Cell(getcellname(3, item.StatID)));
                node.Cells.Add(new Cell(getcellname(4, item.StatID)));
                node.Cells.Add(new Cell(getcellname(5, item.StatID)));
                node.Cells.Add(new Cell(getcellname(6, item.StatID)));
                node.Cells.Add(new Cell(item.DelFlag == 1 ? "已停用" : "已启用", centerStyle));
                if (item.DelFlag == 1)
                {
                    node.Style = new DevComponents.DotNetBar.ElementStyle(Color.Red);
                }

                treeStat.Nodes.Add(node);
                loadchildtree(listStat, listitem, listsubclass, node, item.StatID);
                node.ExpandVisibility = eNodeExpandVisibility.Auto;
            }

            treeStat.EndUpdate();
            treeStat.ExpandAll();
        }

        /// <summary>
        /// 获取统计大类名
        /// </summary>
        /// <param name="subtype">类型</param>
        /// <param name="statID">统计大类ID</param>
        /// <returns>统计大类名</returns>
        private string getcellname(int subtype, int statID)
        {
            Basic_StatItem subitem = Listitem.Find(x => x.StatID == statID);
            if (subitem == null)
            {
                return string.Empty;
            }

            Basic_StatItemSubclass subclass = null;
            switch (subtype)
            {
                case 1:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.AccItemID);
                    break;
                case 2:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.CostItemID);
                    break;
                case 3:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.BaItemID);
                    break;
                case 4:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.PoItemID);
                    break;
                case 5:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.OutFpItemID);
                    break;
                case 6:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.InFpItemID);
                    break;
            }

            if (subclass == null)
            {
                return string.Empty;
            }

            return subclass.SubName;
        }

        /// <summary>
        /// 获取分类明细ID
        /// </summary>
        /// <param name="subtype">类型</param>
        /// <param name="statID">统计大类ID</param>
        /// <returns>分类明细ID</returns>
        private int getsubclassId(int subtype, int statID)
        {
            Basic_StatItem subitem = Listitem.Find(x => x.StatID == statID);
            if (subitem == null)
            {
                return 0;
            }

            Basic_StatItemSubclass subclass = null;
            switch (subtype)
            {
                case 1:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.AccItemID);
                    break;
                case 2:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.CostItemID);
                    break;
                case 3:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.BaItemID);
                    break;
                case 4:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.PoItemID);
                    break;
                case 5:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.OutFpItemID);
                    break;
                case 6:
                    subclass = Listsubclass.Find(x => x.SubID == subitem.InFpItemID);
                    break;
            }

            if (subclass == null)
            {
                return 0;
            }

            return subclass.SubID;
        }

        /// <summary>
        /// 获取统计大类ID
        /// </summary>
        /// <param name="statID">中心统计大类ID</param>
        /// <returns>本院统计大类ID</returns>
        private int getsubitemId(int statID)
        {
            Basic_StatItem subitem = Listitem.Find(x => x.StatID == statID);
            if (subitem == null)
            {
                return 0;
            }

            return subitem.ID;
        }

        /// <summary>
        /// 绑定统计大类树
        /// </summary>
        /// <param name="listStat">中心统计大类</param>
        /// <param name="listitem">本院统计大类</param>
        /// <param name="listsubclass">分类明细</param>
        /// <param name="pnode">父节点</param>
        /// <param name="pstatid">父节点ID</param>
        private void loadchildtree(List<Basic_CenterStatItem> listStat, List<Basic_StatItem> listitem, List<Basic_StatItemSubclass> listsubclass, Node pnode, int pstatid)
        {
            foreach (Basic_CenterStatItem item in listStat.FindAll(x => x.PStatID == pstatid))
            {
                Node node = new Node();
                node.DragDropEnabled = false;
                node.Tag = item;
                node.Text = item.StatName;
                node.Cells.Add(new Cell(item.StatID.ToString(),centerStyle));
                node.Cells.Add(new Cell(getcellname(1, item.StatID)));
                node.Cells.Add(new Cell(getcellname(2, item.StatID)));
                node.Cells.Add(new Cell(getcellname(3, item.StatID)));
                node.Cells.Add(new Cell(getcellname(4, item.StatID)));
                node.Cells.Add(new Cell(getcellname(5, item.StatID)));
                node.Cells.Add(new Cell(getcellname(6, item.StatID)));
                node.Cells.Add(new Cell(item.DelFlag == 1 ? "已停用" : "已启用",centerStyle));
                if (item.DelFlag == 1)
                { 
                    node.Style = new DevComponents.DotNetBar.ElementStyle(Color.Red);
                }

                pnode.Nodes.Add(node);
                loadchildtree(listStat,listitem,listsubclass, node, item.StatID);
                node.ExpandVisibility = eNodeExpandVisibility.Auto;
            }
        }

        /// <summary>
        /// 绑定分类明细
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="dt">分类明细</param>
        private void bindSubClass(EfwControls.CustomControl.TextBoxCard control, DataTable dt)
        {
            control.IsShowSeq = false;
            control.DisplayField = "SubName";
            control.MemberField = "SubID";
            control.CardColumn = "SubName|名称|auto";
            control.QueryFieldsString = "SubName,PyCode,WbCode";
            control.ShowCardDataSource = dt;
        }

        /// <summary>
        /// 绑定分类明细
        /// </summary>
        /// <param name="listsubclass">分类明细</param>
        public void loadSubClass(List<Basic_StatItemSubclass> listsubclass)
        {
            bindSubClass(cbAccItem, ConvertExtend.ToDataTable(listsubclass.FindAll(x => x.SubType == 1)));
            bindSubClass(cbCostItem, ConvertExtend.ToDataTable(listsubclass.FindAll(x => x.SubType == 2)));
            bindSubClass(cbBaItem, ConvertExtend.ToDataTable(listsubclass.FindAll(x => x.SubType == 3)));
            bindSubClass(cbPoItem, ConvertExtend.ToDataTable(listsubclass.FindAll(x => x.SubType == 4)));
            bindSubClass(cbOutFpItem, ConvertExtend.ToDataTable(listsubclass.FindAll(x => x.SubType == 5)));
            bindSubClass(cbInFpItem, ConvertExtend.ToDataTable(listsubclass.FindAll(x => x.SubType == 6)));
        }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构ID</param>
        public void loadWorkers(DataTable dt, int defaultWorkID)
        {
            cbWorkers.DisplayMember = "WorkName";
            cbWorkers.ValueMember = "WorkId";
            cbWorkers.DataSource = dt;
            cbWorkers.SelectedValue = defaultWorkID;
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
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmStatItem_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("InitHostData");

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbWorkers.Enabled = true;
            }
            else
            {
                cbWorkers.Enabled = false;
            }
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cbWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWorkers.SelectedValue != null)
            {
                int isAll = Convert.ToInt32(ckAll.CheckValue);
                InvokeController("GetHostStatItemData", isAll);
                InvokeController("GetAllSubClassData");
                frmFormItem.Clear();
                treeStat.Focus();
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            int isAll = ckAll.Checked ? 1 : 0;
            InvokeController("GetHostStatItemData", isAll);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treeStat.SelectedNode == null)
            {
                return;
            }

            frmFormItem.GetValue(currStatItem);
            InvokeController("SaveHostStatItem");
            int isAll = ckAll.Checked ? 1 : 0;
            InvokeController("GetHostStatItemData", isAll);
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
            currStatItem = new Basic_StatItem();
            currStatItem.ID = getsubitemId(item.StatID);
            currStatItem.StatID = item.StatID;
            currStatItem.StatName = item.StatName;
            currStatItem.AccItemID = getsubclassId(1, item.StatID);
            currStatItem.CostItemID= getsubclassId(2, item.StatID);
            currStatItem.BaItemID = getsubclassId(3, item.StatID);
            currStatItem.PoItemID= getsubclassId(4, item.StatID);
            currStatItem.OutFpItemID= getsubclassId(5, item.StatID);
            currStatItem.InFpItemID = getsubclassId(6, item.StatID);
            frmFormItem.Load(currStatItem);
        }

        /// <summary>
        /// 维护明细分类
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btndetail_Click(object sender, EventArgs e)
        {
            InvokeController("ShowDialog", "FrmDetailClass");
            InvokeController("GetAllSubClassData");
        }
    }
}
