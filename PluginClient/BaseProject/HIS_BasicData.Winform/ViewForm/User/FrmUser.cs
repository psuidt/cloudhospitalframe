using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.User
{
    /// <summary>
    /// 用户维护
    /// </summary>
    public partial class FrmUser : BaseFormBusiness, IFrmUser
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmUser()
        {
            InitializeComponent();
            frmUserForm.AddItem(tbCode, "Code", "用户编号必须输入", InvalidType.Empty, null);//用户编号
            frmUserForm.AddItem(cboUserName, "EmpID", "员工姓名必须选择", InvalidType.Empty, null);//用户姓名
            frmUserForm.AddItem(cboIsAdmin, "IsAdmin");//用户级别
            frmUserForm.AddItem(cboUserType, "UserType");//用户类型
            frmUserForm.AddItem(cboDoctorPost, "DoctorPost");//医生职称
            frmUserForm.AddItem(cboNursePost, "NursePost");//护士职称
            frmUserForm.Load<BaseUser>(new BaseUser { });
        }

        /// <summary>
        /// 当前选中用户
        /// </summary>
        private BaseUser currentUser;

        /// <summary>
        /// 当前选中用户
        /// </summary>
        public BaseUser CurrentUser
        {
            get
            {
                return currentUser;
            }

            set
            {
                currentUser = value;

                frmUserForm.Load(currentUser);

                InvokeController("LoadUserGroups", cboQueryWorker.SelectedValue, currentUser.UserID);

                //0为启用,1为停用
                if (currentUser.Lock == 1)
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
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmEmp_OpenWindowBefore(object sender, EventArgs e)
        {
            bindGridSelectIndex(dgUser);
            InitComboboxExData();
            InvokeController("LoadBasicData");
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
            cboQueryWorker.DisplayMember = "WorkName";
            cboQueryWorker.ValueMember = "WorkId";
            cboQueryWorker.DataSource = workers;
            cboQueryWorker.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
        }

        /// <summary>
        /// 加载科室查询下拉框
        /// </summary>
        /// <param name="depts">科室列表</param>
        public void LoadBasicQueryDepts(DataTable depts)
        {
            tbcQueryDept.DisplayField = "Name";
            tbcQueryDept.MemberField = "DeptId";
            tbcQueryDept.CardColumn = "DeptId|科室标识|100,Name|科室名称|auto";
            tbcQueryDept.QueryFieldsString = "Name,Pym,Wbm,Szm";
            tbcQueryDept.ShowCardWidth = 350;
            tbcQueryDept.ShowCardDataSource = depts;
            tbcQueryDept.MemberValue = -1;
        }

        /// <summary>
        /// 加载用户列表
        /// </summary>
        /// <param name="users">用户列表</param>
        public void LoadBasicUsers(List<BaseUser> users)
        {
            dgUser.DataSource = users;

            if (users.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarRel.Enabled = true;
                barUser.Refresh();
            }
            else
            {
                toolbarFlag.Enabled = false;
                toolbarRel.Enabled = false;
                barUser.Refresh();
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Lock == 1)
                {
                    dgUser.SetRowColor(i, Color.Red, true);
                }
            }
        }

        /// <summary>
        /// 加载下拉框数据
        /// </summary>
        /// <param name="dtDataSource">基础数据列表</param>
        public void LoadBasicData(params DataTable[] dtDataSource)
        {
            var dtDoctorPost = dtDataSource[0];
            var drDoctorPost = dtDoctorPost.NewRow();
            drDoctorPost["Name"] = "无";
            drDoctorPost["Code"] = "0";
            dtDoctorPost.Rows.InsertAt(drDoctorPost, 0);
            cboDoctorPost.DataSource = dtDoctorPost;//医生职称
            var dtNursePost = dtDataSource[1];
            var drNursePost = dtNursePost.NewRow();
            drNursePost["Name"] = "无";
            drNursePost["Code"] = "0";
            dtNursePost.Rows.InsertAt(drNursePost, 0);
            cboNursePost.DataSource = dtNursePost;//护士职称
        }

        /// <summary>
        /// 加载员工下拉框 
        /// </summary>
        /// <param name="emps">员工列表</param>
        public void LoadBasicEmps(DataTable emps)
        {
            cboUserName.DisplayField = "Name";
            cboUserName.MemberField = "EmpId";
            cboUserName.CardColumn = "Name|人员|auto";
            cboUserName.QueryFieldsString = "Name,Pym,Wbm";
            cboUserName.ShowCardDataSource = emps;
        }

        /// <summary>
        /// 加载用户角色列表
        /// </summary>
        /// <param name="groups">用户角色列表</param>
        public void LoadBasicUserGroups(List<BaseGroup> groups)
        {
            dgGroups.DataSource = groups;
        }

        #endregion

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitComboboxExData()
        {
            var datasource = new[] 
            {
                new { Text = "普通用户", Value = 0 },
                new { Text = "机构管理员", Value = 1 },
                new { Text = "超级管理员", Value = 2 }
            };

            cboIsAdmin.DataSource = datasource;
            datasource = new[] 
            {
                new { Text = "普通", Value = 0 },
                new { Text = "收费员", Value = 1 },
                new { Text = "医生", Value = 2 },
                new { Text = "护士", Value = 3 },
                new { Text = "药剂", Value = 4 }
            };

            cboUserType.DataSource = datasource;
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
            toolbarAdd.Enabled = true;
            barUser.Refresh();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("将不会保存新修改数据", "确定要取消本次操作吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            frmUserForm.Load(CurrentUser);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmUserForm.Validate())
            {
                frmUserForm.GetValue(CurrentUser);
                bool isNew = CurrentUser.UserID == 0 ? true : false;
                InvokeController("SaveUser", Convert.ToInt32(cboQueryWorker.SelectedValue), CurrentUser);
                toolbarRefresh_Click(sender, e);
                dgUser.Enabled = true;
                if (isNew)
                {
                    setGridSelectIndex(dgUser, dgUser.RowCount - 1);
                }
                else
                {
                    setGridSelectIndex(dgUser);
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRefresh_Click(object sender, EventArgs e)
        {
            dgUser.Enabled = true;
            InvokeController("LoadBasicUsers", tbQueryKey.Text, cboQueryWorker.SelectedValue, tbcQueryDept.MemberValue, cbQuery.Checked);

            if (dgUser.Rows.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarRel.Enabled = true;
                barUser.Refresh();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            var dtDoctorPost = cboDoctorPost.DataSource as DataTable;
            var strDoctorPost = string.Empty;
            if (null != dtDoctorPost && dtDoctorPost.Rows.Count > 0)
            {
                strDoctorPost = dtDoctorPost.Rows[0]["Code"] + string.Empty;
            }

            var dtNursePost = cboDoctorPost.DataSource as DataTable;
            var strNursePost = string.Empty;
            if (null != dtNursePost && dtNursePost.Rows.Count > 0)
            {
                strNursePost = dtNursePost.Rows[0]["Code"] + string.Empty;
            }

            CurrentUser = new BaseUser { DoctorPost = strDoctorPost, NursePost = strNursePost };
            tbCode.Enabled = true;
            cboUserName.Enabled = true;
            dgUser.Enabled = false;
            toolbarAdd.Enabled = false;
            toolbarFlag.Enabled = false;
            toolbarRel.Enabled = false;
            barUser.Refresh();
            tbCode.Focus();
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

            dgUser.Enabled = true;
            toolbarAdd.Enabled = true;
            if (dgUser.Rows.Count > 0)
            {
                toolbarFlag.Enabled = true;
                toolbarRel.Enabled = true;
            }

            barUser.Refresh();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgUser.Enabled = true;
            InvokeController("LoadBasicUsers", tbQueryKey.Text, cboQueryWorker.SelectedValue, tbcQueryDept.MemberValue, cbQuery.Checked);
        }

        /// <summary>
        /// 停用或启用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarFlag_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(string.Format("确定{0}吗？", CurrentUser.Lock == 0 ? "停用" : "启用"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            InvokeController("FlagUser", CurrentUser.UserID, CurrentUser.Lock);
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgUser.Enabled = true;
            InvokeController("LoadBasicDepts", cboQueryWorker.SelectedValue);
            InvokeController("LoadBasicEmps", Convert.ToInt32(cboQueryWorker.SelectedValue));
            InvokeController("LoadBasicUsers", tbQueryKey.Text, cboQueryWorker.SelectedValue, tbcQueryDept.MemberValue, cbQuery.Checked);
        }

        /// <summary>
        /// 关联角色
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRel_Click(object sender, EventArgs e)
        {
            var flag = InvokeController("RelGroups", CurrentUser.UserID, cboQueryWorker.SelectedValue) as bool?;
            if (flag.HasValue && flag.Value)
            {
                MessageBoxShowSimple("保存成功！");
                dgUser_CurrentCellChanged(null, null);
            }
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
                    toolbarRel_Click(null, null);
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
        /// 选中用户
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgUser_CurrentCellChanged(object sender, EventArgs e)
        {
            if (null == dgUser.CurrentRow)
            {
                return;
            }

            var rowIndex = dgUser.CurrentRow.Index;
            var dataSource = dgUser.DataSource as List<BaseUser>;
            CurrentUser = dataSource[rowIndex];
            tbCode.Enabled = false;
            cboUserName.Enabled = false;
        }
    }
}
