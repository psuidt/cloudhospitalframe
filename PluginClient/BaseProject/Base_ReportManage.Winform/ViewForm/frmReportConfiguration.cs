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

namespace base_reportmanage.winform.ViewForm
{
    public partial class frmReportConfiguration : BaseForm, IfrmReportConfiguration
    {
        public frmReportConfiguration()
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
        }

        #region IfrmReportConfiguration 成员
        private void recursionLayer(List<BaseReportLayer> alllayerList, int pid, TreeNode pNode, List<BaseReportTitle> titleList)
        {
            List<BaseReportLayer> _layerList = alllayerList.FindAll(x => x.PLayerId == pid);
            foreach (BaseReportLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                pNode.Nodes.Add(_node);
                loadTitle(titleList, val.LayerId, _node);
                recursionLayer(alllayerList, val.LayerId, _node, titleList);
            }
        }

        private void loadTitle(List<BaseReportTitle> titleList, int layerId, TreeNode node)
        {
            List<BaseReportTitle> _titlelist = titleList.FindAll(x => x.LayerId == layerId);
            foreach (BaseReportTitle val in _titlelist)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                _node.ForeColor = Color.Blue;
                node.Nodes.Add(_node);
            }
        }

        public void loadLayerTree(List<BaseReportLayer> layerList, List<BaseReportTitle> titleList)
        {
            treeView1.Nodes.Clear();
            List<BaseReportLayer> _layerList = layerList.FindAll(x => x.PLayerId == -1);
            foreach (BaseReportLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                treeView1.Nodes.Add(_node);
                loadTitle(titleList, val.LayerId, _node);
                recursionLayer(layerList, val.LayerId, _node, titleList);
            }

            treeView1.ExpandAll();
        }

        public void loadFieldGrid(List<BaseReportField> fieldList)
        {
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = fieldList;
        }

        #endregion

        private void frmReportConfiguration_Load(object sender, EventArgs e)
        {
            InvokeController("LoadLayerList");
        }


        private void 新建分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int layerId = -1;
            if (treeView1.SelectedNode != null)
            {
                layerId=((BaseReportLayer)treeView1.SelectedNode.Tag).LayerId;
            }
            BaseReportLayer layer = InvokeController("NewLayer", layerId) as BaseReportLayer;
            TreeNode _node = new TreeNode();
            _node.Text = layer.Name;
            _node.Tag = layer;
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Nodes.Add(_node);
            }
            else
            {
                treeView1.Nodes.Add(_node);
            }
        }

        private void 修改分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.SelectedNode.BeginEdit();
        }

        private void 删除分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("你确实需要删除此节点？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                InvokeController("DeleteLayer", ((BaseReportLayer)treeView1.SelectedNode.Tag).LayerId);
                treeView1.SelectedNode.Remove();
            }
        }

        private void 新建报表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InvokeController("NewTitle", ((BaseReportLayer)treeView1.SelectedNode.Tag).LayerId);
        }

        private void 修改报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvokeController("AlterTitle", ((BaseReportTitle)treeView1.SelectedNode.Tag).TitleId);
        }

        private void 删除报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("你确实需要删除此节点？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                InvokeController("DeleteTitle", ((BaseReportTitle)treeView1.SelectedNode.Tag).TitleId);
                treeView1.SelectedNode.Remove();
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(BaseReportLayer))
            {
                BaseReportLayer layer = (BaseReportLayer)e.Node.Tag;
                if (e.Label != null)
                    layer.Name = e.Label;
                layer = (BaseReportLayer)InvokeController("AlterLayer", layer);
                e.Node.Tag = layer;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode.Tag.GetType() == typeof(BaseReportTitle))
            {
                this.新建分类ToolStripMenuItem.Enabled = false;
                this.修改分类ToolStripMenuItem.Enabled = false;
                this.删除分类ToolStripMenuItem.Enabled = false;
                this.新建报表ToolStripMenuItem.Enabled = false;
                this.修改报表ToolStripMenuItem.Enabled = true;
                this.删除报表ToolStripMenuItem.Enabled = true;
            }
            else
            {

                this.新建分类ToolStripMenuItem.Enabled = true;
                this.修改分类ToolStripMenuItem.Enabled = true;
                this.删除分类ToolStripMenuItem.Enabled = true;
                this.新建报表ToolStripMenuItem.Enabled = true;
                this.修改报表ToolStripMenuItem.Enabled = false;
                this.删除报表ToolStripMenuItem.Enabled = false;
            }

            if (treeView1.SelectedNode.Tag.GetType() == typeof(BaseReportLayer))
            {
                InvokeController("LoadFieldList", 0, 0);
            }
            else
            {
                InvokeController("LoadFieldList", 1, ((BaseReportTitle)treeView1.SelectedNode.Tag).TitleId);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag.GetType() == typeof(BaseReportTitle))
            {
                if (MessageBoxEx.Show("你确实需要初始化此表的字段，将删除现有字段重新生成？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    InvokeController("StartInitField", ((BaseReportTitle)treeView1.SelectedNode.Tag).TitleId);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择左边蓝色的节点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int fieldId = Convert.ToInt32(dataGrid1["FieldId", dataGrid1.CurrentCell.RowIndex].Value);
                InvokeController("AlterField", fieldId);
            }
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int fieldId = Convert.ToInt32(dataGrid1["FieldId", dataGrid1.CurrentCell.RowIndex].Value);
                InvokeController("AlterField", fieldId);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
        
    }
}
