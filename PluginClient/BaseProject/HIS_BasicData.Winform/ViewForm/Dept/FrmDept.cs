using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Dept
{
    /// <summary>
    /// 科室维护
    /// </summary>
    public partial class FrmDept : BaseFormBusiness, IFrmDept
    {
        /// <summary>
        /// 新增标志
        /// </summary>
        private bool isNew;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmDept()
        {
            InitializeComponent();
            bindGridSelectIndex(DeptGrid);
            frmDeptForm.AddItem(Principal, "Principal", "负责人名称必须输入", InvalidType.Empty, null);//负责人
            frmDeptForm.AddItem(Telephone, "Telephone", "负责人联系电话格式不正确", InvalidType.Custom, @"^[1][358]\d{9}$|^(0\d{2,3}-)?(\d{7,8})(-(\d{1,3}))?$");//负责人电话
            frmDeptForm.AddItem(DeptAddress, "DeptAddress");//科室地址
            frmDeptForm.AddItem(Member_Num, "Member_Num", "医务人员数必须是数字", InvalidType.Custom, @"^[0-9]\d*$");//医务人员数
            frmDeptForm.AddItem(Bed_Num, "Bed_Num", "床位数必须是数字", InvalidType.Custom, @"^[0-9]\d*$");//床位数
            frmDeptForm.AddItem(DeptType, "DeptType");//科室类别
            frmDeptForm.AddItem(OutUsed, "OutUsed");//是否门诊科室    
            frmDeptForm.AddItem(InUsed, "InUsed");//是否住院科室
            frmDeptForm.AddItem(PrtWardUsed, "PrtWardUsed");//是否病区
            frmDeptForm.AddItem(PharmacyUsed, "PharmacyUsed");//是否药房
            frmDeptForm.AddItem(DrugUsed, "DrugUsed");//是否药库仓库
            frmDeptForm.AddItem(MaterialsUsed, "MaterialsUsed");//是否物资仓库
            frmDeptForm.AddItem(ExamineUsed, "ExamineUsed");//是否检查科室
            frmDeptForm.AddItem(DeptName, "DeptName", "科室名称必须输入", InvalidType.Empty, null);//科室名称
            frmDeptForm.Load(InitBaseDept);
            frmDeptForm.Load(InitBaseDeptDetails);
        }

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        //private List<BaseDeptLayer> _DeptLayers;

        /// <summary>
        /// 科室详情
        /// </summary>
        private BaseDeptDetails InitBaseDeptDetails
        {
            get
            {
                return new BaseDeptDetails
                {
                    Bed_Num = 0,
                    Member_Num = 0,
                    DeptType = 0
                };
            }
        }

        /// <summary>
        /// 网格选中行
        /// </summary>
        private DataRow currentDept;

        /// <summary>
        /// 网格选中行
        /// </summary>
        public DataRow CurrentDept
        {
            get
            {
                return currentDept;
            }

            set
            {
                currentDept = value;
                InvokeController("LoadDeptDetail", currentDept["DeptId"]);
                frmDeptForm.Load(CurrentDeptDetails);
                if (CurrentDeptDetails.DeptID > 0)
                {
                    DeptID.Text = CurrentDeptDetails.DeptID.ToString();
                }
                else
                {
                    DeptID.Text = CurrentDept["DeptID"].ToString();
                }

                DeptName.Text = CurrentDept["Name"].ToString();
                DeptType.SelectedIndex = CurrentDeptDetails.DeptType;
                DeptID.ReadOnly = true;
                //0为启用,1为停用
                if (currentDept["DelFlag"].ToString() == "已停用")
                {
                    DetailDel.Text = "启用(F3)";
                }
                else
                {
                    DetailDel.Text = "停用(F3)";
                }
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        private BaseDept InitBaseDept
        {
            get
            {
                return new BaseDept
                {
                    DelFlag = 1
                };
            }
        }

        /// <summary>
        /// 科室详情
        /// </summary>
        public BaseDeptDetails CurrentDeptDetails
        {
            get; set;
        }

        #endregion

        #region  函数
        /// <summary>
        /// 绑定机构下拉框,并继续绑定科室分类树
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cboWorker.DataSource = workers;
            cboWorker.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
            InvokeController("LoadDeptlayerTree", cboWorker.SelectedValue);
        }

        /// <summary>
        /// 加载科室分类树
        /// </summary>
        /// <param name="deptLayers">科室列表</param>
        public void LoadDeptlayerTree(List<BaseDeptLayer> deptLayers)
        {
            treeDeptLayer.Nodes.Clear();
            LoadTree(this.treeDeptLayer, deptLayers, "0", null);
            if (this.treeDeptLayer.Nodes.Count > 0)
            {
                this.treeDeptLayer.SelectedNode = this.treeDeptLayer.Nodes[0];
            }

            this.treeDeptLayer.ExpandAll();
        }

        /// <summary>
        /// 递归遍历加载树节点
        /// </summary>
        /// <param name="treeView">树型控件</param>
        /// <param name="list">科室列表</param>
        /// <param name="pid">父ID</param>
        /// <param name="pNode">父节点</param>
        public void LoadTree(AdvTree treeView, List<BaseDeptLayer> list, string pid, Node pNode)
        {
            string sFilter = "ParentID=" + pid;
            Node parentNode = pNode;
            List<BaseDeptLayer> newList = list.Where(item => item.PId == Convert.ToInt32(pid)).ToList();
            foreach (BaseDeptLayer bd in newList)
            {
                Node tempNode = new Node();
                tempNode.Text = bd.Name;
                tempNode.Name = bd.LayerId.ToString();
                if (parentNode != null)
                { 
                    parentNode.Nodes.Add(tempNode);
                }
                else
                { 
                    treeView.Nodes.Add(tempNode);
                }

                LoadTree(treeView, list, bd.LayerId.ToString(), tempNode);
            }
        }

        /// <summary>
        /// 加载科室列表信息
        /// </summary>
        /// <param name="deptlist">科室列表</param>
        public void LoadDeptList(DataTable deptlist)
        {
            this.DeptGrid.DataSource = deptlist;
            for (int i = 0; i < deptlist.Rows.Count; i++)
            {
                if (deptlist.Rows[i]["DelFlag"] + string.Empty == "已停用")
                {
                    DeptGrid.SetRowColor(i, Color.Red, true);
                }
            }

            if (isNew)
            {
                setGridSelectIndex(DeptGrid, DeptGrid.RowCount - 1);
            }
            else
            {
                setGridSelectIndex(DeptGrid);
            }
        }

        /// <summary>
        /// 获取当前选中科室详情
        /// </summary>
        /// <param name="deptDetails">科室详情</param>
        public void LoadDeptDetail(BaseDeptDetails deptDetails)
        {
            if (null == deptDetails)
            {
                deptDetails = InitBaseDeptDetails;
            }

            CurrentDeptDetails = deptDetails;
            frmDeptForm.Load(deptDetails);
        }

        /// <summary>
        /// 删除当前节点
        /// </summary>
        public void DelLayer()
        {
            if (MessageBoxEx.Show("删除后无法恢复，确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string layerid = this.treeDeptLayer.SelectedNode.Name;
                BaseDeptLayer layer = new BaseDeptLayer();
                layer.LayerId = Convert.ToInt32(layerid);
                InvokeController("DelDeptLayer", layer);
                this.treeDeptLayer.SelectedNode.Remove();
            }
        }

        /// <summary>
        /// 新增节点
        /// </summary>
        public void AddLayer()
        {
            BaseDeptLayer deptlayer = new BaseDeptLayer();
            if (this.treeDeptLayer.SelectedNode != null && !string.IsNullOrEmpty(this.treeDeptLayer.SelectedNode.Name))
            {
                deptlayer.PId = Convert.ToInt32(this.treeDeptLayer.SelectedNode.Name);
            }
            else
            {
                deptlayer.PId = 0;
            }

            deptlayer.Name = "输入节点名称";
            //deptlayer.WorkId = Convert.ToInt32(cboWorker.SelectedValue);
            var result = InvokeController("SaveDeptLayer", deptlayer);
            var node = new DevComponents.AdvTree.Node("输入节点名称");
            node.Name = result.ToString();
            if (this.treeDeptLayer.SelectedNode != null)
            {
                this.treeDeptLayer.SelectedNode.Nodes.Add(node);
            }
            else
            {
                this.treeDeptLayer.Nodes.Add(node);
            }

            this.treeDeptLayer.SelectNode(node, DevComponents.AdvTree.eTreeAction.Code);
            node.BeginEdit();
        }

        /// <summary>
        /// 清除详情数据
        /// </summary>
        private void ClearData()
        {
            DeptID.ReadOnly = false;
            DeptID.Text = string.Empty;
            DeptName.Text = string.Empty;
            Principal.Text = string.Empty;
            Telephone.Text = string.Empty;
            DeptAddress.Text = string.Empty;
            Member_Num.Text = "0";
            Bed_Num.Text = "0";
            DeptType.SelectedIndex = 0;
            OutUsed.Checked = false;
            InUsed.Checked = false;
            PrtWardUsed.Checked = false;
            PharmacyUsed.Checked = false;
            DrugUsed.Checked = false;
            MaterialsUsed.Checked = false;
            ExamineUsed.Checked = false;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 界面打开时加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmDept_OpenWindowBefore(object sender, EventArgs e)
        {
            treeDeptLayer.SelectedIndexChanged -= treeDeptLayer_SelectedIndexChanged;
            InvokeController("LoadBasicWorkers");
            if (treeDeptLayer.SelectedNode != null)
            {
                InvokeController("LoadDeptList", cboWorker.SelectedValue, treeDeptLayer.SelectedNode.Name, string.Empty);
            }

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cboWorker.Enabled = true;
            }
            else
            {
                cboWorker.Enabled = false;
            }

            treeDeptLayer.SelectedIndexChanged += treeDeptLayer_SelectedIndexChanged;
            DeptID.Hide();
            toolbarDel.Enabled = false;
            toolMenuDel.Enabled = false;
        }

        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolMenuAdd_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarDel_Click(object sender, EventArgs e)
        {
            DelLayer();
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolMenuDel_Click(object sender, EventArgs e)
        {
            DelLayer();
        }

        /// <summary>
        /// 编辑节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolMenuEdit_Click(object sender, EventArgs e)
        {
            this.treeDeptLayer.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// 编辑节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarEdit_Click(object sender, EventArgs e)
        {
            this.treeDeptLayer.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            frmDeptForm.Load(CurrentDeptDetails);
            DeptID.Text = CurrentDeptDetails.DeptID.ToString();
            DeptType.SelectedIndex = CurrentDeptDetails.DeptType;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Telephone.Text))
            //{
            if (frmDeptForm.Validate())
            {
                if (CurrentDeptDetails != null)
                {
                    CurrentDeptDetails.DeptType = DeptType.SelectedIndex;
                }

                //CurrentDeptDetails.WorkId = Convert.ToInt32(cboWorker.SelectedValue);
                //frmDeptForm.GetValue(CurrentDept);
                if (DeptID.ReadOnly)
                {
                    frmDeptForm.GetValue(CurrentDeptDetails);
                    if (CurrentDeptDetails.DeptID == 0)
                    {
                        CurrentDeptDetails.DeptID = Convert.ToInt32(CurrentDept["DeptID"].ToString());
                    }

                    InvokeController("SaveDept", CurrentDeptDetails.DeptID, DeptName.Text);
                    InvokeController("SaveDeptDetail", CurrentDeptDetails);
                    MessageBoxShowSimple("保存成功");
                }
                else
                {
                    if (treeDeptLayer.SelectedNode != null)
                    {
                        BaseDept newdept = new BaseDept();
                        newdept.Name = DeptName.Text;
                        newdept.Pym = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(DeptName.Text);
                        newdept.Wbm = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(DeptName.Text);
                        newdept.DelFlag = 0;
                        newdept.SortOrder = 0;
                        newdept.Layer = Convert.ToInt32(treeDeptLayer.SelectedNode.Name);
                        if (CurrentDeptDetails == null)
                        {
                            CurrentDeptDetails = new BaseDeptDetails();
                        }

                        frmDeptForm.GetValue(CurrentDeptDetails);
                        InvokeController("AddDept", newdept, CurrentDeptDetails);
                        MessageBoxShowSimple("保存成功");
                    }
                    else
                    {
                        MessageBoxEx.Show("请先添加科室节点");
                    }
                }
            }

            if (treeDeptLayer.SelectedNode != null)
            {
                InvokeController("LoadDeptList", cboWorker.SelectedValue, treeDeptLayer.SelectedNode.Name, string.Empty);
            }
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void DetailDel_Click(object sender, EventArgs e)
        {
            string info = "启用";
            int status = 0;
            if (CurrentDept["DelFlag"].ToString() == "已启用")
            {
                info = "停用";
                status = 1;
            }

            if (MessageBoxEx.Show("确定" + info + "吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (null == DeptGrid.CurrentRow)
                {
                    return;
                }

                var rowIndex = DeptGrid.CurrentRow.Index;
                var dataSource = DeptGrid.DataSource as DataTable;
                string deptid = dataSource.Rows[rowIndex]["DeptId"].ToString();
                InvokeController("DeleteDept", deptid, status);
                MessageBoxEx.Show(string.Empty + info + "成功");
                InvokeController("LoadDeptList", cboWorker.SelectedValue, treeDeptLayer.SelectedNode.Name, string.Empty);
            }
        }

        /// <summary>
        /// 新增科室
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void DetailAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            ClearData();
            DeptName.Focus();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void DeptRefresh_Click(object sender, EventArgs e)
        {
            if (treeDeptLayer.SelectedNode != null)
            {
                InvokeController("LoadDeptList", cboWorker.SelectedValue, treeDeptLayer.SelectedNode.Name, SearchValue.Text);
                setGridSelectIndex(DeptGrid);
            }
        }

        /// <summary>
        /// 获取选中行的科室数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void DeptGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (null == DeptGrid.CurrentRow)
            {
                return;
            }

            var rowIndex = DeptGrid.CurrentRow.Index;
            var dataSource = DeptGrid.DataSource as DataTable;
            CurrentDept = dataSource.Rows[rowIndex];
        }

        /// <summary>
        /// 选中科室节点记载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void treeDeptLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            if (treeDeptLayer.SelectedNode != null && !string.IsNullOrEmpty(this.treeDeptLayer.SelectedNode.Name))
            {
                InvokeController("LoadDeptList", cboWorker.SelectedValue, treeDeptLayer.SelectedNode.Name, string.Empty);
            }
            else
            {
                DeptGrid.DataSource = null;
            }

            if (DeptGrid.Rows.Count > 0)
            {
                toolbarDel.Enabled = false;
                toolMenuDel.Enabled = false;
            }
            else
            {
                toolbarDel.Enabled = true;
                toolMenuDel.Enabled = true;
            }
        }

        /// <summary>
        /// 保存科室节点
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void treeDeptLayer_AfterCellEditComplete(object sender, CellEditEventArgs e)
        {
            Node curentNode = this.treeDeptLayer.SelectedNode;
            BaseDeptLayer layer = new BaseDeptLayer();
            layer.LayerId = Convert.ToInt32(curentNode.Name);
            layer.Name = curentNode.Text;
            if (curentNode.Parent != null)
            {
                layer.PId = Convert.ToInt32(curentNode.Parent.Name);
            }

            InvokeController("SaveDeptLayer", layer);
        }

        /// <summary>
        /// 加载科室列表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void ListSearch_Click(object sender, EventArgs e)
        {
            if (treeDeptLayer.SelectedNode != null)
            {
                InvokeController("LoadDeptList", cboWorker.SelectedValue, treeDeptLayer.SelectedNode.Name, SearchValue.Text);
            }
            else
            {
                MessageBoxEx.Show("请先添加科室节点");
            }
        }

        /// <summary>
        /// 加载科室分类
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeController("LoadDeptlayerTree", cboWorker.SelectedValue);
            if (cboWorker.SelectedValue.ToString() != (InvokeController("this") as AbstractController).LoginUserInfo.WorkId.ToString())
            {
                DetailDel.Enabled = false;
                btnSave.Enabled = false;
                DetailAdd.Enabled = false;
                bar1.Enabled = false;
                treeMenu.Enabled = false;
                btnReset.Enabled = false;
            }
            else
            {
                DetailDel.Enabled = true;
                btnSave.Enabled = true;
                DetailAdd.Enabled = true;
                bar1.Enabled = true;
                treeMenu.Enabled = true;
                btnReset.Enabled = true;
            }
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmDept_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    DetailAdd_Click(null, null);
                    break;
                case Keys.F4:
                    DetailDel_Click(null, null);
                    break;
                case Keys.F5:
                    DeptRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    btnReset_Click(null, null);
                    break;
                case Keys.F8:
                    btnQuit_Click(null, null);
                    break;
                case Keys.F7:
                    btnSave_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// 选中科室加载科室详情
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void DeptGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (null == DeptGrid.CurrentRow)
            {
                return;
            }

            var rowIndex = DeptGrid.CurrentRow.Index;
            if (rowIndex > 0)
            {
                isNew = false;
            }

            var dataSource = DeptGrid.DataSource as DataTable;
            CurrentDept = dataSource.Rows[rowIndex];
        }

        #endregion
    }
}
