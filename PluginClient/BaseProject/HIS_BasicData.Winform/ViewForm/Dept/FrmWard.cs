using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Dept
{
    /// <summary>
    /// 病区维护
    /// </summary>
    public partial class FrmWard : BaseFormBusiness, IFrmWard
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmWard()
        {
            InitializeComponent();
            frmWardForm.AddItem(tbWardName, "WardName", "病区名称必须输入", InvalidType.Empty, null);//病区名称
            frmWardForm.AddItem(txtResponsible, "Responsible");
            frmWardForm.AddItem(txtSickbedNum, "SickbedNum");
            frmWardForm.AddItem(txtSortOrder, "SortOrder");
            frmWardForm.AddItem(tbMemo, "Memo");//备注
        }

        /// <summary>
        /// 当前选中病区
        /// </summary>
        private BaseWard currentWard;

        /// <summary>
        /// 当前选中病区
        /// </summary>
        public BaseWard CurrentWard
        {
            get
            {
                return currentWard;
            }

            set
            {
                currentWard = value;
                frmWardForm.Load(currentWard);
                InvokeController("LoadWardDeptAndEmps", cboQueryWorker.SelectedValue, currentWard.WardID, Controller.RelDeptAndEmp.All);

                //0为启用,1为停用
                if (currentWard.DelFlag == 1)
                { 
                    toolbarFlag.Text = "启用(F3)";
                }
                else
                { 
                    toolbarFlag.Text = "停用(F3)";
                }
            }
        }

        /// <summary>
        /// 打开界面时加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmEmp_OpenWindowBefore(object sender, EventArgs e)
        {
            bindGridSelectIndex(dgWard);
            InvokeController("LoadBasicWorkers");

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cboQueryWorker.Enabled = true;
            }
            else
            {
                cboQueryWorker.Enabled = false;
            }
        }

        #region IFrmUser

        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cboQueryWorker.DataSource = workers;
            cboQueryWorker.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
            InvokeController("LoadBasicWards", tbQueryKey.Text, cboQueryWorker.SelectedValue, cbQuery.Checked);
            //InvokeController("LoadBasicDepts", cboQueryWorker.SelectedValue);
        }

        /// <summary>
        /// 加载科室查询下拉框
        /// </summary>
        /// <param name="depts">科室列表</param>
        public void LoadBasicQueryDepts(DataTable depts)
        {
            //tbcQueryDept.DisplayField = "Name";
            //tbcQueryDept.MemberField = "DeptId";
            //tbcQueryDept.CardColumn = "DeptId|科室标识|100,Name|科室名称|auto";
            //tbcQueryDept.QueryFieldsString = "Name,Pym,Wbm,Szm";
            //tbcQueryDept.ShowCardWidth = 350;
            //tbcQueryDept.ShowCardDataSource = depts;
            //if (null != depts && depts.Rows.Count > 0)
            //{
            //    tbcQueryDept.MemberValue = depts.Rows[0]["DeptId"];
            //}
            //else
            //{
            //    tbcQueryDept.MemberValue = null;
            //}
            //InvokeController("LoadBasicWards", tbQueryKey.Text, cboQueryWorker.SelectedValue, tbcQueryDept.MemberValue, cbQuery.Checked);
        }

        /// <summary>
        /// 加载病区列表
        /// </summary>
        /// <param name="wards">病区列表</param>
        public void LoadBasicWards(List<BaseWard> wards)
        {
            dgWard.DataSource = wards;
            if (wards.Count > 0)
            {
                dgWard_CurrentCellChanged(null, null);
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarRelDept.Enabled = true;
                barWard.Refresh();
            }
            else
            {
                toolbarAdd_Click(null, null);
                toolbarFlag.Enabled = false;
                toolbarRelDept.Enabled = false;
                barWard.Refresh();
            }

            for (int i = 0; i < wards.Count; i++)
            {
                if (wards[i].DelFlag == 1)
                {
                    dgWard.SetRowColor(i, Color.Red, true);
                }
            }
        }

        /// <summary>
        /// 加载关联的科室与人员
        /// </summary>
        /// <param name="dtSources">科室列表</param>
        public void LoadRelDeptAndEmps(DataTable[] dtSources)
        {
            dgDepts.DataSource = dtSources[0];
            //dgEmps.DataSource = dtSources[1];
        }

        #endregion

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
            toolbarAdd.Enabled = true;
            barWard.Refresh();
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("将不会保存新修改数据", "确定要取消本次操作吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { 
                return;
            }

            frmWardForm.Load(CurrentWard);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmWardForm.Validate())
            {
                frmWardForm.GetValue(CurrentWard);

                var ret = InvokeController("SaveWard", CurrentWard, Convert.ToInt32(cboQueryWorker.SelectedValue));
                toolbarRefresh_Click(sender, e);
                dgWard.Enabled = true;
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRefresh_Click(object sender, EventArgs e)
        {
            dgWard.Enabled = true;
            InvokeController("LoadBasicWards", tbQueryKey.Text, cboQueryWorker.SelectedValue, cbQuery.Checked);
            setGridSelectIndex(dgWard);

            if (dgWard.Rows.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarRelDept.Enabled = true;
                //toolbarRelEmp.Enabled = true;
                barWard.Refresh();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            dgWard.Enabled = false;
            CurrentWard = new BaseWard { };
            toolbarAdd.Enabled = false;
            toolbarFlag.Enabled = false;
            toolbarRelDept.Enabled = false;
            //toolbarRelEmp.Enabled = false;
            barWard.Refresh();

            tbWardName.Focus();
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("将不会保存新修改数据", "确定要取消本次操作吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { 
                return;
            }

            dgWard.Enabled = true;
            toolbarAdd.Enabled = true;
            if (dgWard.Rows.Count > 0)
            {
                toolbarFlag.Enabled = true;
                toolbarRelDept.Enabled = true;
                //toolbarRelEmp.Enabled = true;
            }

            barWard.Refresh();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgWard.Enabled = true;
            InvokeController("LoadBasicWards", tbQueryKey.Text, cboQueryWorker.SelectedValue, cbQuery.Checked);
        }

        /// <summary>
        /// 停用或启用病区
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarFlag_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(string.Format("确定{0}吗？", CurrentWard.DelFlag == 0 ? "停用" : "启用"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { 
                return;
            }

            InvokeController("FlagWard", CurrentWard.WardID, CurrentWard.DelFlag);
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgWard.Enabled = true;
            InvokeController("LoadBasicDepts", cboQueryWorker.SelectedValue);
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmEmp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    toolbarAdd_Click(null, null);
                    break;
                case Keys.F3:
                    toolbarFlag_Click(null, null);
                    break;
                case Keys.F4:
                    toolbarRelDept_Click(null, null);
                    break;
                case Keys.F5:
                    toolbarRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    btnReset_Click(null, null);
                    break;
                case Keys.F7:
                    btnQuit_Click(null, null);
                    break;
                case Keys.F8:
                    btnSave_Click(null, null);
                    break;
                case Keys.F9:
                    btnQuery_Click(null, null);
                    break;
                case Keys.F10:
                    btnCancel_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// 选中病区
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgWard_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //var dataSource = dgWard.DataSource as List<BaseWard>;
            //if (e.RowIndex >= 0)
            //{
            //    if (dataSource[e.RowIndex].DelFlag == 1)
            //    {
            //        dgWard.SetRowColor(e.RowIndex, Color.Red, true);
            //    }
            //}
        }

        /// <summary>
        /// 设置当前选中病区
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgWard_CurrentCellChanged(object sender, EventArgs e)
        {
            if (null == dgWard.CurrentRow)
            {
                return;
            }

            var rowIndex = dgWard.CurrentRow.Index;
            var dataSource = dgWard.DataSource as List<BaseWard>;
            CurrentWard = dataSource[rowIndex];
        }

        /// <summary>
        /// 关联科室
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRelDept_Click(object sender, EventArgs e)
        {
            var flag = InvokeController("RelDepts", CurrentWard.WardID, cboQueryWorker.SelectedValue) as bool?;
            if (flag.HasValue && flag.Value)
            {
                dgWard_CurrentCellChanged(null, null);
            }
        }
    }
}
