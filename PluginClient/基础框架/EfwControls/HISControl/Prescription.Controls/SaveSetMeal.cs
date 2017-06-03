using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using EfwControls.HISControl.Prescription.Controls.Action;
using EfwControls.HISControl.Prescription.Controls.Entity;
using EFWCoreLib.CoreFrame.Business;

namespace EfwControls.HISControl.Prescription.Controls
{
    internal partial class SaveSetMeal : Office2007Form
    {
        #region 属性
        private PrescriptionControlController controller;//控件控制器对象
        private int presStyle;//保存类型
        public SaveSetMeal(PrescriptionControlController _controller, int prescriptionStyle)
        {
            controller = _controller;
            presStyle = prescriptionStyle - 1;
            InitializeComponent();
        }
        /// <summary>
        /// 另存为模板的类型
        /// </summary>
        public int MealType
        {
            get
            {
                if (cbHispital.Checked)
                    return 0;
                else if (cbDept.Checked)
                    return 1;
                else
                    return 2;
            }
        }
        /// <summary>
        /// 另存为模板的名称
        /// </summary>
        public string MealName
        {
            get { return txtSetMealName.Text; }
        }
        /// <summary>
        /// 另存为模板的父节点
        /// </summary>
        public int PId
        {
            get
            {
                if (treWestDrug.SelectedNode != null)
                    return Convert.ToInt32(treWestDrug.SelectedNode.Name);
                else
                    return 0;
            }
        }
        /// <summary>
        /// 是否保存
        /// </summary>
        public bool IsOK = false;
        #endregion

        public SaveSetMeal()
        {
            InitializeComponent();
        }

        #region 窗体事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSetMealName.Text.Trim() != "")
            {
                IsOK = true;
                this.Close();
            }
            else
            {
                txtSetMealName.Focus();
                return;
            }
        }

        private void SaveSetMeal_Load(object sender, EventArgs e)
        {
            GetPresTemplate(2, presStyle, treWestDrug);
        }

        private void cbDept_CheckedChanged(object sender, EventArgs e)
        {
            int intModilLevel = 0;
            if (cbHispital.Checked)
                intModilLevel = 0;
            else if (cbDept.Checked)
                intModilLevel = 1;
            else
                intModilLevel = 2;
            GetPresTemplate(intModilLevel, presStyle, treWestDrug);
        }

        #endregion

        #region 函数
        /// <summary>
        /// 创建树
        /// </summary>
        /// <param name="intLevel">模板级别</param>
        private void GetPresTemplate(int intLevel, int presType, AdvTree tree)
        {
            List<OPD_PresMouldHead> listHead = (List<OPD_PresMouldHead>)controller.PresLoadTemplate(intLevel, presType).Where(item => item.MouldType == 0).ToList();

            tree.Nodes.Clear();
            LoadTree(tree, listHead, "99999", null);
            if (tree.Nodes.Count > 0)
            {
                tree.SelectedNode = tree.Nodes[0];
            }
            tree.ExpandAll();
        }

        /// <summary>
        /// 递归遍历加载树节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="list"></param>
        /// <param name="pid"></param>
        /// <param name="pNode"></param>
        private void LoadTree(AdvTree treeView, List<OPD_PresMouldHead> list, string pid, Node pNode)
        {
            string sFilter = "PID=" + pid;
            Node parentNode = pNode;
            List<OPD_PresMouldHead> templist = list.Where(item => item.PID == Convert.ToInt32(pid)).ToList();
            foreach (OPD_PresMouldHead bd in templist)
            {
                Node tempNode = new Node();

                tempNode.Text = bd.ModuldName;
                tempNode.Name = bd.PresMouldHeadID.ToString();
                tempNode.AccessibleDescription = bd.MouldType.ToString();  //模板类型
                if (bd.MouldType == 0)
                {
                    tempNode.ImageIndex = 0;
                }
                else
                {
                    tempNode.ImageIndex = 1;
                }
                if (parentNode != null)
                    parentNode.Nodes.Add(tempNode);
                else
                    treeView.Nodes.Add(tempNode);
                LoadTree(treeView, list, bd.PresMouldHeadID.ToString(), tempNode);
            }
        }

        #endregion
    }
}
