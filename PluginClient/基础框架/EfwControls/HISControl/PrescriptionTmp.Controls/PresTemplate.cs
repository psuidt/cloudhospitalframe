using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.HISControl.PrescriptionTmp.Controls.Action;
using DevComponents.AdvTree;
using EfwControls.Common;

namespace EfwControls.HISControl.PrescriptionTmp.Controls
{
    internal partial class PresTemplate : Office2007Form
    {
        private PrescriptionControlController controller;
        private int mealCls = 0;
        public bool isOk = false;
        public int[] checkIds;
        public PresTemplate(PrescriptionControlController _controller)
        {
            controller = _controller;
            InitializeComponent();
            dataGridPres.AutoGenerateColumns = false;
            if (controller.IfrmView.PrescriptionStyle == PrescriptionStyle.全部)
            {
                rbAll.Enabled = true;
                rbWest.Enabled = true;
                rbMid.Enabled = true;
                rbAll.Checked = true;
                mealCls = 0;
            }
            else if (controller.IfrmView.PrescriptionStyle == PrescriptionStyle.西药与中成药)
            {
                rbAll.Enabled = false;
                rbWest.Enabled = false;
                rbMid.Enabled = false;
                rbWest.Checked = true;
                mealCls = 1;
            }
            else if (controller.IfrmView.PrescriptionStyle == PrescriptionStyle.中草药)
            {
                rbAll.Enabled = false;
                rbWest.Enabled = false;
                rbMid.Enabled = false;
                rbMid.Checked = true;
                mealCls = 2;
            }
        }

        private void BindTreeView(DataTable dt, TreeNode node, string parentId)
        {
            foreach (DataRow row in dt.Select("ParentId='" + parentId + "'"))
            {
                TreeNode createNode = new TreeNode();
                createNode.Text = Tools.ToString(row["NodeName"]);
                createNode.Name = Tools.ToString(row["ParentID"]);
                //createNode.AccessibleDescription = Tools.ToString(row["MealCls"]);
                //createNode.AccessibleName = Tools.ToString(row["StaffID"]);
                //createNode.DataKey = Tools.ToString(row["SystemNode"]) + "#" + Tools.ToString(row["IsFolder"]);
                if (dt.Select("ParentId='" + row["Id"].ToString() + "'").Length>0)
                {
                    createNode.ImageIndex = 0;
                    createNode.SelectedImageIndex = 1;
                }
                else
                {
                    createNode.Tag = Tools.ToString(row["ID"]);
                    createNode.ImageIndex = 2;
                    createNode.SelectedImageIndex = 2;
                }
                node.Nodes.Add(createNode);
                BindTreeView(dt, createNode, row["Id"].ToString());
            }
        }
        //协定处方
        public void InitCommonPres()
        {
            
            treePres.Nodes.Clear();
            //加载模板
            DataTable dt = controller.PrescripttionDataSource.LoadTemplateList(controller.IfrmView.PresDeptCode, controller.IfrmView.PresDoctorId,mealCls);
            if (dt == null) return;

            TreeNode RootNode = new TreeNode();
            RootNode.Tag = "0";
            RootNode.Text = "套餐节点";
            BindTreeView(dt, RootNode, "0");
            treePres.Nodes.Add(RootNode);
            RootNode.Expand();

            dataGridPres.DataSource = null;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataTable data = dataGridPres.DataSource as DataTable;
            List<int> vl = new List<int>();
            foreach (DataRow dr in data.Select("ck=1"))
            {
                vl.Add(Convert.ToInt32(dr["ID"]));
            }
            checkIds = vl.ToArray();
            this.isOk = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PresTemplate_Load(object sender, EventArgs e)
        {
            InitCommonPres();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if ((sender as Control).Name == "rbAll")
                {
                    mealCls = 0;
                    InitCommonPres();
                }
                else if ((sender as Control).Name == "rbWest")
                {
                    mealCls = 1;
                    InitCommonPres();
                }
                else if ((sender as Control).Name == "rbMid")
                {
                    mealCls = 2;
                    InitCommonPres();
                }
            }
        }

        private void treePres_DoubleClick(object sender, EventArgs e)
        {
            if (treePres.SelectedNode != null && treePres.SelectedNode.Tag != null)
            {
                DataTable data = controller.PrescripttionDataSource.LoadTemplateDetail(Convert.ToInt32(treePres.SelectedNode.Tag));
                dataGridPres.DataSource = data;
            }
            else
                dataGridPres.DataSource = null;
        }

        private void dataGridPres_Click(object sender, EventArgs e)
        {
            if (dataGridPres.CurrentCell != null)
            {
                DataTable data = dataGridPres.DataSource as DataTable;
                int groupid = Convert.ToInt32(data.Rows[dataGridPres.CurrentCell.RowIndex]["GroupID"]);
                int ck = Convert.ToInt32(data.Rows[dataGridPres.CurrentCell.RowIndex]["ck"]);
                foreach (DataRow dr in data.Select("GroupID=" + groupid))
                {
                    dr["ck"] = ck == 0 ? 1 : 0;
                }
            }
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            DataTable data = dataGridPres.DataSource as DataTable;
            if (data != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["ck"] = ckAll.Checked ? 1 : 0;
                }
            }
        }
    }
}
