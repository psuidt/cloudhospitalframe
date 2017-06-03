using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using base_reportmanage.winform.IView;
using EFWCoreLib.WinformFrame.Controller;
using DevComponents.DotNetBar;
using base_reportmanage.Entity;
//using WinMainUIFrame.Entity;

namespace base_reportmanage.winform.ViewForm
{
    public partial class frmGroupReport : BaseForm, IfrmGroupReport
    {
        public frmGroupReport()
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
        }

        #region IfrmGroupReport 成员

        public void loadGroupGrid(List<BaseGroup> groupList)
        {
            this.dataGrid1.DataSource = null;
            this.dataGrid1.DataSource = groupList;
        }
        private void recursionLayer(List<BaseReportLayer> alllayerList, int pid, TreeNode pNode, List<BaseReportTitle> titleList, List<BaseReportTitle> grouptitleList)
        {
            List<BaseReportLayer> _layerList = alllayerList.FindAll(x => x.PLayerId == pid);
            foreach (BaseReportLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                pNode.Nodes.Add(_node);
                loadTitle(titleList, val.LayerId, _node,grouptitleList);
                recursionLayer(alllayerList, val.LayerId, _node, titleList,grouptitleList);
            }
        }

        private void loadTitle(List<BaseReportTitle> titleList, int layerId, TreeNode node, List<BaseReportTitle> grouptitleList)
        {
            List<BaseReportTitle> _titlelist = titleList.FindAll(x => x.LayerId == layerId);
            foreach (BaseReportTitle val in _titlelist)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                _node.ForeColor = Color.Blue;
                _node.Checked = grouptitleList.FindIndex(x => x.TitleId == val.TitleId) != -1 ? true : false;
                node.Nodes.Add(_node);
            }
        }
        public void loadTableTree(List<BaseReportLayer> layerList, List<BaseReportTitle> titleList, List<BaseReportTitle> grouptitleList)
        {
            treeView1.Nodes.Clear();
            List<BaseReportLayer> _layerList = layerList.FindAll(x => x.PLayerId == -1);
            foreach (BaseReportLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                treeView1.Nodes.Add(_node);
                loadTitle(titleList, val.LayerId, _node,grouptitleList);
                recursionLayer(layerList, val.LayerId, _node, titleList,grouptitleList);
            }

            treeView1.ExpandAll();
        }

        #endregion

        private void dataGrid2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int rowindex = dataGrid1.CurrentCell.RowIndex;
                int groupId = Convert.ToInt32(dataGrid1["groupId", rowindex].Value.ToString());
                InvokeController("LoadGroupTitle", groupId);
            }
        }

        private void frmGroupReport_Load(object sender, EventArgs e)
        {
            InvokeController("LoadGroupList");
        }

        private void recursionCheckNode(TreeNode node, bool check)
        {
            foreach (TreeNode _node in node.Nodes)
            {

                _node.Checked = check;

                recursionCheckNode(_node, check);
            }
        }

        private void recursionGetNodeCheck(TreeNode node, List<int> menuIdList)
        {
            foreach (TreeNode _node in node.Nodes)
            {

                if (_node.Checked == true && _node.Tag.GetType() == typeof(BaseReportTitle))
                    menuIdList.Add(((BaseReportTitle)_node.Tag).TitleId);
                recursionGetNodeCheck(_node, menuIdList);
            }
        }

        private int[] GetNodeCheck()
        {
            List<int> menuIdList = new List<int>();
            foreach (TreeNode _node in treeView1.Nodes)
            {
                if (_node.Checked == true && _node.Tag.GetType() == typeof(BaseReportTitle))
                    menuIdList.Add(((BaseReportTitle)_node.Tag).TitleId);
                recursionGetNodeCheck(_node, menuIdList);
            }

            return menuIdList.ToArray();
        }



        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            if (treeView1.SelectedNode != null)
            {
                bool check = treeView1.SelectedNode.Checked;
                treeView1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
                recursionCheckNode(treeView1.SelectedNode, check);
                treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);


                if (dataGrid1.CurrentCell != null)
                {
                    int rowindex = dataGrid1.CurrentCell.RowIndex;
                    int groupId = Convert.ToInt32(dataGrid1["groupId", rowindex].Value.ToString());
                    InvokeController("SetGroupTitle", groupId, GetNodeCheck());
                }

            }
        }
    }
}
