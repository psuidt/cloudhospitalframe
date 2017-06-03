using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Employee
{
    /// <summary>
    /// 人员维护
    /// </summary>
    public partial class FrmEmp : BaseFormBusiness, IFrmEmp
    {
        /// <summary>
        /// 新增标志
        /// </summary>
        private bool isNew = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmEmp()
        {
            InitializeComponent();
            bindGridSelectIndex(dgEmp);
            frmEmpForm.AddItem(tbName, "Name", "姓名必须输入", InvalidType.Empty, null);//姓名
            frmEmpForm.AddItem(cboSex, "Sex", "性别必须输入", InvalidType.Empty, null);//性别
            frmEmpForm.AddItem(tbPosition, "Emp_Position");//职务
            frmEmpForm.AddItem(tbCertificateNum, "CertificateNum");//资格证编号
            frmEmpForm.AddItem(cboTitleCode, "EmpTitle_Code");//技术职称
            frmEmpForm.AddItem(tbIDNumber, "IDNumber", "身份证号码格式不正确", InvalidType.Custom, @"^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$");//身份证号码
            frmEmpForm.AddItem(tbTel, "Telephone", "联系电话格式不正确", InvalidType.Custom, @"^[1][358]\d{9}$|^(0\d{2,3}-)?(\d{7,8})(-(\d{1,3}))?$");//联系电话
            frmEmpForm.AddItem(tbShortNum, "ShortNum", "短号格式不正确", InvalidType.Custom, @"[0-9]{1}");//短号
            frmEmpForm.AddItem(tbEmail, "Email", "邮箱格式不正确", InvalidType.Custom, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");//邮箱
            frmEmpForm.AddItem(tbContact, "Contact");//联系人
            frmEmpForm.AddItem(tbNowAddress, "NowAddress");//现住址
            frmEmpForm.AddItem(tbAddress, "Address");//户籍地址
            frmEmpForm.AddItem(tbNative, "Native");//籍贯
            frmEmpForm.AddItem(cboPersonCategory, "PersonCategory");//人员分类
            frmEmpForm.AddItem(cboJobClassifi, "JobClassifi");//岗位分类
            frmEmpForm.AddItem(cboMatrimony, "Matrimony");//婚姻状况
            frmEmpForm.AddItem(dtBrithday, "Brithday", "出生日期不能为空", InvalidType.Empty, null);//出生日期
            frmEmpForm.AddItem(dtWorkDate, "WorkDate", "参加工作日期不能为空", InvalidType.Empty, null);//参加工作日期
            frmEmpForm.AddItem(tbGraduateInst, "GraduateInst");//毕业院校
            frmEmpForm.AddItem(dtGraduateDate, "GraduateDate", "毕业日期不能为空", InvalidType.Empty, null);//毕业时间
            frmEmpForm.AddItem(dtLeaveDate, "LeaveDate");//离职日期
            frmEmpForm.AddItem(cboNation, "Nation");//民族
            frmEmpForm.AddItem(tbProfessionCode, "Profession_Code");//专业名称
            frmEmpForm.AddItem(cboOnFlag, "On_Flag");//在职标志
            frmEmpForm.AddItem(dtPoliticalDate, "PoliticalDate");//参党(团)日期
            frmEmpForm.AddItem(cboPoliticalStatus, "PoliticalStatus");//政治面貌
            frmEmpForm.AddItem(cboDegreeCode, "DegreeCode");//文化程度
            frmEmpForm.AddItem(tbMemo, "Memo");//备注
            frmEmpForm.Load(InitBaseEmp);
            frmEmpForm.Load(InitBaseEmpDetail);
        }

        /// <summary>
        /// 当前选中的人员
        /// </summary>
        private BaseEmployee currentEmp;

        /// <summary>
        /// 当前选中的人员
        /// </summary>
        public BaseEmployee CurrentEmp
        {
            get
            {
                return currentEmp;
            }

            set
            {
                currentEmp = value;
                InvokeController("LoadEmpDetail", currentEmp.EmpId);
                frmEmpForm.Load(currentEmp);

                //0为启用,1为停用
                if (currentEmp.DelFlag == 1)
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
        /// 用户详情
        /// </summary>
        public BaseEmployeeDetails CurrentEmpDetail { get; set; }

        /// <summary>
        /// 用户详情
        /// </summary>
        public BaseEmployeeDetails InitBaseEmpDetail
        {
            get
            {
                return new BaseEmployeeDetails
                {
                    GraduateDate = DateTime.Now,
                    WorkDate = DateTime.Now,
                    On_Flag = 1,
                    PersonCategory = "3"
                };
            }
        }

        /// <summary>
        /// 人员
        /// </summary>
        public BaseEmployee InitBaseEmp
        {
            get
            {
                return new BaseEmployee
                {
                    Brithday = DateTime.Now
                };
            }
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmEmp_OpenWindowBefore(object sender, EventArgs e)
        {
            InitComboboxExData();
            InvokeController("LoadBasicData");
            InvokeController("LoadBasicWorkers");

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cboWorker.Enabled = true;
            }
            else
            {
                cboWorker.Enabled = false;
            }

            btnSave.Enabled = false;
        }

        #region IFrmEmp

        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cboWorker.DataSource = workers;
            cboWorker.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
            InvokeController("LoadBasicDepts", cboWorker.SelectedValue);
        }

        /// <summary>
        /// 绑定科室列表
        /// </summary>
        /// <param name="depts">科室列表</param>
        public void LoadBasicDepts(DataTable depts)
        {
            tbcDept.DisplayField = "Name";
            tbcDept.MemberField = "DeptId";
            tbcDept.CardColumn = "DeptId|科室标识|100,Name|科室名称|auto";
            tbcDept.QueryFieldsString = "Name,Pym,Wbm,Szm";
            tbcDept.ShowCardWidth = 350;
            tbcDept.ShowCardDataSource = depts;
            tbcDept.MemberValue = -1;
            InvokeController("LoadBasicEmps", tbQueryName.Text, cboWorker.SelectedValue, tbcDept.MemberValue, cbQuery.Checked);
        }

        /// <summary>
        /// 绑定人员列表
        /// </summary>
        /// <param name="emps">人员列表</param>
        public void LoadBasicEmps(List<BaseEmployee> emps)
        {
            dgEmp.CurrentCellChanged -= dgEmp_CurrentCellChanged;
            dgEmp.DataSource = emps;
            dgEmp.CurrentCellChanged += dgEmp_CurrentCellChanged;
            if (emps.Count > 0)
            {
                dgEmp_CurrentCellChanged(null, null);
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarRel.Enabled = true;
                barEmp.Refresh();
            }
            else
            {
                toolbarAdd_Click(null, null);
                toolbarAdd.Enabled = false;
                toolbarFlag.Enabled = false;
                toolbarRel.Enabled = false;
                barEmp.Refresh();
            }

            setGridSelectIndex(dgEmp);
        }

        /// <summary>
        /// 绑定基础数据
        /// </summary>
        /// <param name="dtDataSource">基础数据集</param>
        public void LoadBasicData(params DataTable[] dtDataSource)
        {
            cboSex.DataSource = dtDataSource[0];//性别
            cboDegreeCode.DataSource = dtDataSource[1];//文化程度
            cboNation.DataSource = dtDataSource[2];//民族
            cboMatrimony.DataSource = dtDataSource[3];//婚姻状况
            cboTitleCode.DataSource = dtDataSource[4];//技术职称
            cboPoliticalStatus.DataSource = dtDataSource[5];//政治面貌
            cboJobClassifi.DataSource = dtDataSource[6];//岗位分类
        }

        /// <summary>
        /// 显示人员详情
        /// </summary>
        /// <param name="empDetail">人员详情</param>
        public void LoadEmpDetail(BaseEmployeeDetails empDetail)
        {
            if (null == empDetail)
            {
                empDetail = InitBaseEmpDetail;
            }

            CurrentEmpDetail = empDetail;
            frmEmpForm.Load(empDetail);
        }

        #endregion

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitComboboxExData()
        {
            var datasource = new[] 
            {
                new
                {
                    Text = "未分类",
                    Value = "0"
                },
                new
                {
                    Text = "干部人员",
                    Value = "1"
                },
                new
                {
                    Text = "职工人员",
                    Value = "2"
                },
                new
                {
                    Text = "聘用人员",
                    Value = "3"
                },
                new
                {
                    Text = "临时",
                    Value = "4"
                },
                new
                {
                    Text = "借调",
                    Value = "5"
                }
            };

            cboPersonCategory.DataSource = datasource;
            var onflagdatasource = new[] 
            {
                new
                {
                    Text = "在职",
                    Value = 1
                },
                new
                {
                    Text = "不在职",
                    Value = 0
                }
            };

            cboOnFlag.DataSource = onflagdatasource;
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
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

            frmEmpForm.Load(CurrentEmp);
            frmEmpForm.Load(CurrentEmpDetail);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmEmpForm.Validate())
            {
                frmEmpForm.GetValue(CurrentEmp);
                //CurrentEmp.WorkId = int.Parse(cboWorker.SelectedValue + "");
                frmEmpForm.GetValue(CurrentEmpDetail);

                var ret = InvokeController("SaveEmpAndDetail", cboWorker.SelectedValue, CurrentEmp, CurrentEmpDetail);
                dgEmp.Enabled = true;
                toolbarRefresh_Click(sender, e);
                btnSave.Enabled = false;
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRefresh_Click(object sender, EventArgs e)
        {
            dgEmp.Enabled = true;
            InvokeController("LoadBasicEmps", tbQueryName.Text, cboWorker.SelectedValue, tbcDept.MemberValue, cbQuery.Checked);
            if (isNew)
            {
                setGridSelectIndex(dgEmp, dgEmp.RowCount - 1);
            }
            else
            {
                setGridSelectIndex(dgEmp);
            }

            if (dgEmp.Rows.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                toolbarRel.Enabled = true;
                barEmp.Refresh();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            dgEmp.Enabled = false;
            btnSave.Enabled = true;
            CurrentEmp = InitBaseEmp;

            toolbarAdd.Enabled = false;
            toolbarFlag.Enabled = false;
            toolbarRel.Enabled = false;
            barEmp.Refresh();

            tbName.Focus();
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

            dgEmp.Enabled = true;
            toolbarAdd.Enabled = true;
            if (dgEmp.Rows.Count > 0)
            {
                toolbarFlag.Enabled = true;
                toolbarRel.Enabled = true;
            }

            barEmp.Refresh();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgEmp.Enabled = true;
            InvokeController("LoadBasicEmps", tbQueryName.Text, cboWorker.SelectedValue, tbcDept.MemberValue, cbQuery.Checked);
        }

        /// <summary>
        /// 启用或停用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarFlag_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(string.Format("确定{0}吗？", CurrentEmp.DelFlag == 0 ? "停用" : "启用"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            InvokeController("FlagEmpAndDetail", CurrentEmp.EmpId, CurrentEmp.DelFlag);
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgEmp.Enabled = true;
            InvokeController("LoadBasicDepts", cboWorker.SelectedValue);
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
                    btnUpdate_Click(null, null);
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
        /// 获取当前选中的人员
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgEmp_CurrentCellChanged(object sender, EventArgs e)
        {
            if (null == dgEmp.CurrentRow)
            {
                return;
            }

            var rowIndex = dgEmp.CurrentRow.Index;
            var dataSource = dgEmp.DataSource as List<BaseEmployee>;
            CurrentEmp = dataSource[rowIndex];
        }

        /// <summary>
        /// 这只网格当前行颜色
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgEmp_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var dataSource = dgEmp.DataSource as List<BaseEmployee>;
            if (e.RowIndex > 0)
            {
                if (dataSource[e.RowIndex].DelFlag == 1)
                {
                    dgEmp.SetRowColor(e.RowIndex, Color.Red, true);
                }
            }
        }

        /// <summary>
        /// 关联科室
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRel_Click(object sender, EventArgs e)
        {
            var flag = InvokeController("RelDepts", CurrentEmp.EmpId, cboWorker.SelectedValue) as bool?;
        }

        /// <summary>
        /// 关联病区
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRelWard_Click(object sender, EventArgs e)
        {
            InvokeController("RelWards", CurrentEmp.EmpId, cboWorker.SelectedValue);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isNew = false;
            btnSave.Enabled = true;
        }
    }
}
