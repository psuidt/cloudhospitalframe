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
using EFWCoreLib.WinformFrame.Controller;

namespace base_dictionarymanage.winform.ViewForm
{
    public partial class frmShowGeneral : BaseForm, IfrmShowGeneral
    {
        public frmShowGeneral()
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
        }

        #region IfrmShowGeneral 成员
        private void recursionLayer(List<BaseGeneralLayer> alllayerList, int pid, TreeNode pNode, List<BaseGeneralTitle> grouptitleList)
        {
            List<BaseGeneralLayer> _layerList = alllayerList.FindAll(x => x.PId == pid);
            foreach (BaseGeneralLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                pNode.Nodes.Add(_node);
                loadTitle(grouptitleList, val.GLayerId, _node);
                recursionLayer(alllayerList, val.GLayerId, _node, grouptitleList);
            }
        }

        private void loadTitle(List<BaseGeneralTitle> grouptitleList, int layerId, TreeNode node)
        {
            List<BaseGeneralTitle> _titlelist = grouptitleList.FindAll(x => x.LayerId == layerId);
            foreach (BaseGeneralTitle val in _titlelist)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                _node.ForeColor = Color.Blue;
                node.Nodes.Add(_node);
            }
        }
        public void loadLayerTree(List<BaseGeneralLayer> layerList, List<BaseGeneralTitle> grouptitleList)
        {
            treeView1.Nodes.Clear();
            List<BaseGeneralLayer> _layerList = layerList.FindAll(x => x.PId == -1);
            foreach (BaseGeneralLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                treeView1.Nodes.Add(_node);
                loadTitle(grouptitleList, val.GLayerId, _node);
                recursionLayer(layerList, val.GLayerId, _node, grouptitleList);
            }

            treeView1.ExpandAll();
        }

        public void loadfieldsCombo(List<BaseGeneralField> fieldList)
        {
            toolStripComboBox1.Items.Clear();
            foreach (BaseGeneralField val in fieldList)
            {
                toolStripComboBox1.Items.Add(val.ColName);
            }
        }

        private DataTable _resultGrid;
        public DataTable resultGrid
        {
            get
            {
                return _resultGrid;
            }
            set
            {
                _resultGrid = value;
                dataGrid1.AutoGenerateColumns = false;
                dataGrid1.DataSource = _resultGrid;
            }
        }

        public void createGridColumn(List<BaseGeneralField> fieldList)
        {
            dataGrid1.Columns.Clear();
            List<BaseGeneralField> _fieldList = fieldList.FindAll(x => x.UiType > 0);
            foreach (BaseGeneralField val in _fieldList)
            {
                DataGridViewColumn col;
                if (val.UiType == 1)
                {
                    col = new DataGridViewTextBoxColumn();
                    col.DataPropertyName = val.ColName;
                    col.HeaderText = val.Name;
                    col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                }
                else if (val.UiType == 5)
                {
                    col = new DataGridViewComboBoxColumn();
                    col.DataPropertyName = val.ColName;
                    col.HeaderText = val.Name;
                    col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                    (col as DataGridViewComboBoxColumn).DisplayMember = "name";
                    (col as DataGridViewComboBoxColumn).ValueMember = "code";

                    int unitId = 0;
                    if (val.DataUnitId == null || val.DataUnitId == "") unitId = -1;
                    else
                        unitId=Convert.ToInt32(val.DataUnitId);
                    (col as DataGridViewComboBoxColumn).DataSource = (DataTable)InvokeController("GetGridColComboDataSource", unitId, val.DynamicSQL);
                }
                else if (val.UiType == 6)
                {
                    col = new DataGridViewCheckBoxColumn();
                    col.DataPropertyName = val.ColName;
                    col.HeaderText = val.Name;
                    col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                    (col as DataGridViewCheckBoxColumn).FalseValue = 0;
                    (col as DataGridViewCheckBoxColumn).TrueValue = 1;

                }
                else
                {
                    col = new DataGridViewTextBoxColumn();
                    col.DataPropertyName = val.ColName;
                    col.HeaderText = val.Name;
                    col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                }
                col.Tag = val;
                dataGrid1.Columns.Add(col);
            }
        }

        #endregion

        private void frmShowGeneral_Load(object sender, EventArgs e)
        {
            InvokeController("LoadShowLayerList");
        }

       

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType() == typeof(BaseGeneralLayer))
            {
                InvokeController("LoadShowFields", 0, 0);
                dataGrid1.Columns.Clear();
                dataGrid1.DataSource = null;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
            }
            else
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                InvokeController("LoadShowFields", 1, ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId);
                InvokeController("LoadShowSearchResult", ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId, toolStripComboBox1.Text, toolStripTextBox1.Text);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType() == typeof(BaseGeneralLayer))
            {
                dataGrid1.DataSource = null;
            }
            else
            {
                InvokeController("LoadShowSearchResult", ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId, toolStripComboBox1.Text, toolStripTextBox1.Text);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (_resultGrid != null)
            {
                InvokeController("AddResultDataTable");
            }
        }
        //保存
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int titleId = ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId;
                int rowindex = dataGrid1.CurrentCell.RowIndex;

                string IdName = null;
                object IdValue = null;
                Dictionary<string, object> fieldAndValue = new Dictionary<string, object>();
                int iskeyIndex = 0;
                for (int i = 0; i < dataGrid1.Columns.Count; i++)
                {
                    if ((dataGrid1.Columns[i].Tag as BaseGeneralField).IsKey == 1)
                    {
                        IdName = (dataGrid1.Columns[i].Tag as BaseGeneralField).ColName;
                        IdValue = dataGrid1[i, rowindex].Value;
                        iskeyIndex = i;
                    }
                    else
                    {
                        object val = null;
                        if ((dataGrid1.Columns[i].Tag as BaseGeneralField).UiType == 6)
                        {
                            val = dataGrid1[i, rowindex].Selected ? 1 : 0;
                        }
                        else if ((dataGrid1.Columns[i].Tag as BaseGeneralField).UiType == 5)
                        {
                            val = dataGrid1[i, rowindex].Value;
                        }
                        else
                        {
                            val = dataGrid1[i, rowindex].Value;
                        }
                        fieldAndValue.Add((dataGrid1.Columns[i].Tag as BaseGeneralField).ColName, val);
                    }
                }

                dataGrid1[iskeyIndex, rowindex].Value = InvokeController("SaveResultDataTable", titleId, IdName, IdValue, fieldAndValue);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int titleId = ((BaseGeneralTitle)treeView1.SelectedNode.Tag).TitleId;
                int rowindex = dataGrid1.CurrentCell.RowIndex;

                string IdName = null;
                object IdValue = null;

                for (int i = 0; i < dataGrid1.Columns.Count; i++)
                {
                    if ((dataGrid1.Columns[i].Tag as BaseGeneralField).IsKey == 1)
                    {
                        IdName = (dataGrid1.Columns[i].Tag as BaseGeneralField).ColName;
                        IdValue = dataGrid1[i, rowindex].Value;
                        break;
                    }
                }

                if (IdValue != null && IdValue.Equals(System.DBNull.Value) == false)
                {
                    InvokeController("DeleteResultDataTable", titleId, IdName, IdValue);
                }

                dataGrid1.Rows.Remove(dataGrid1.Rows[rowindex]);
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                if ((dataGrid1.Columns[dataGrid1.CurrentCell.ColumnIndex].Tag as BaseGeneralField).IsKey == 1)
                    dataGrid1.Columns[dataGrid1.CurrentCell.ColumnIndex].ReadOnly = true;
            }
        }

        private void dataGrid1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
