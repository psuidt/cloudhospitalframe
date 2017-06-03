using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using base_dictionarymanage.Entity;
using base_dictionarymanage.winform.IView;
using EFWCoreLib.WinformFrame.Controller;

namespace base_dictionarymanage.winform.ViewForm
{
    public partial class frmGeneralConfiguration : BaseForm, IfrmGeneralConfiguration
    {
        public frmGeneralConfiguration()
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
        }

        #region IfrmGeneralConfiguration 成员

        private void recursionLayer(List<BaseGeneralLayer> alllayerList, int pid, TreeNode pNode,List<BaseGeneralTitle> titleList)
        {
            List<BaseGeneralLayer> _layerList = alllayerList.FindAll(x => x.PId == pid);
            foreach (BaseGeneralLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                pNode.Nodes.Add(_node);
                loadTitle(titleList, val.GLayerId, _node);
                recursionLayer(alllayerList, val.GLayerId, _node,titleList);
            }
        }

        private void loadTitle(List<BaseGeneralTitle> titleList, int layerId, TreeNode node)
        {
            List<BaseGeneralTitle> _titlelist = titleList.FindAll(x => x.LayerId == layerId);
            foreach (BaseGeneralTitle val in _titlelist)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                _node.ForeColor = Color.Blue;
                node.Nodes.Add(_node);
            }
        }

        public void loadLayerTree(List<BaseGeneralLayer> layerList, List<BaseGeneralTitle> titleList)
        {
            treeView1.Nodes.Clear();
            List<BaseGeneralLayer> _layerList = layerList.FindAll(x => x.PId == -1);
            foreach (BaseGeneralLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                treeView1.Nodes.Add(_node);
                loadTitle(titleList, val.GLayerId, _node);
                recursionLayer(layerList, val.GLayerId, _node,titleList);
            }

            treeView1.ExpandAll();
        }

        public void loadFieldGrid(List<BaseGeneralField> fieldList)
        {
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = fieldList;
        }


        

        #endregion


        private void 新建分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int layerId = -1;
            if (treeView1.SelectedNode != null)
            {
                layerId = ((BaseGeneralLayer)treeView1.SelectedNode.Tag).GLayerId;
            }

            BaseGeneralLayer layer = InvokeController("NewLayer", layerId) as BaseGeneralLayer;
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
                InvokeController("DeleteLayer", ((BaseGeneralLayer)treeView1.SelectedNode.Tag).GLayerId);
                treeView1.SelectedNode.Remove();
            }
            
        }

        private void 新建字典ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InvokeController("NewTitle", ((BaseGeneralLayer)treeView1.SelectedNode.Tag).GLayerId);
        }
        private void 修改字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvokeController("AlterTitle", ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId);
        }
        private void 删除字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("你确实需要删除此节点？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                InvokeController("DeleteTitle", ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId);
                treeView1.SelectedNode.Remove();
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(BaseGeneralLayer))
            {
                BaseGeneralLayer layer = (BaseGeneralLayer)e.Node.Tag;
                if (e.Label != null)
                    layer.Name = e.Label;
                layer = (BaseGeneralLayer)InvokeController("AlterLayer", layer);
                e.Node.Tag = layer;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode.Tag.GetType() == typeof(BaseGeneralTitle))
            {
                this.新建分类ToolStripMenuItem.Enabled = false;
                this.修改分类ToolStripMenuItem.Enabled = false;
                this.删除分类ToolStripMenuItem.Enabled = false;
                this.新建字典ToolStripMenuItem.Enabled = false;
                this.修改字典ToolStripMenuItem.Enabled = true;
                this.删除字典ToolStripMenuItem.Enabled = true;
            }
            else
            {

                this.新建分类ToolStripMenuItem.Enabled = true;
                this.修改分类ToolStripMenuItem.Enabled = true;
                this.删除分类ToolStripMenuItem.Enabled = true;
                this.新建字典ToolStripMenuItem1.Enabled = true;
                this.修改字典ToolStripMenuItem.Enabled = false;
                this.删除字典ToolStripMenuItem.Enabled = false;
            }
            if (treeView1.SelectedNode.Tag.GetType() == typeof(BaseGeneralLayer))
            {
                InvokeController("LoadFieldList", 0, 0);
            }
            else
            {
                InvokeController("LoadFieldList", 1, ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId);
            }
        }

        private void frmGeneralConfiguration_Load(object sender, EventArgs e)
        {
            
            InvokeController("LoadLayerList");

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag.GetType() == typeof(BaseGeneralTitle))
            {
                if (MessageBoxEx.Show("你确实需要初始化此表的字段，将删除现有字段重新生成？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    InvokeController("StartInitField", ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId);
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

       

        
    }
}
