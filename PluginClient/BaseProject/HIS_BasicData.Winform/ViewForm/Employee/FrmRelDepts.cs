using System;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Winform.ViewForm.Employee
{
    /// <summary>
    /// 人员关联科室
    /// </summary>
    public partial class FrmRelDepts : BaseFormBusiness, IFrmRelDepts
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmRelDepts()
        {
            InitializeComponent();
        }

        #region IFrmRelDepts

        /// <summary>
        /// 人员ID
        /// </summary>
        public int EmpId { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 加载科室列表
        /// </summary>
        /// <param name="depts">科室列表</param>
        public void LoadRelDepts(DataTable depts)
        {
            dgRels.DataSource = depts;
        }

        #endregion

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmRelDepts_Load(object sender, EventArgs e)
        {
            InvokeController("LoadRelDepts", WorkId, EmpId);
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            InvokeController("LoadRelDepts", WorkId, EmpId);
        }

        /// <summary>
        /// 选中科室设置成默认科室
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgRelDepts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                var dtDataSource = dgRels.DataSource as DataTable;
                if (null == dtDataSource)
                {
                    return;
                }

                var colIndex = e.ColumnIndex;
                if (colIndex == 3)
                {
                    for (var i = 0; i < dtDataSource.Rows.Count; i++)
                    {
                        dtDataSource.Rows[i]["DefaultFlag"] = 0;
                    }

                    dtDataSource.Rows[rowIndex]["DefaultFlag"] = 1;
                    dtDataSource.Rows[rowIndex]["EmpId"] = 1;
                }

                if (colIndex == 0)
                {
                    var value = dtDataSource.Rows[rowIndex]["EmpId"] as int?;
                    if (value.HasValue)
                    {
                        var iEmpId = value.Value != 0 ? 0 : 1;
                        dtDataSource.Rows[rowIndex]["EmpId"] = iEmpId;
                        SetDefaultFlag(dtDataSource, iEmpId, rowIndex);
                    }
                    else
                    {
                        dtDataSource.Rows[rowIndex]["EmpId"] = 1;
                        SetDefaultFlag(dtDataSource, 1, rowIndex);
                    }
                }
            }
        }

        /// <summary>
        /// 设置默认科室
        /// </summary>
        /// <param name="dtDataSource">科室列表</param>
        /// <param name="iEmpId">人员ID</param>
        /// <param name="rowIndex">选中行</param>
        private void SetDefaultFlag(DataTable dtDataSource, int iEmpId, int rowIndex)
        {
            switch (iEmpId)
            {
                case 0:
                    {
                        if (dtDataSource.Rows[rowIndex]["DefaultFlag"] + string.Empty == "1")
                        {
                            for (var i = 0; i < dtDataSource.Rows.Count; i++)
                            {
                                dtDataSource.Rows[i]["DefaultFlag"] = 0;
                            }

                            for (var i = 0; i < dtDataSource.Rows.Count; i++)
                            {
                                if (int.Parse(dtDataSource.Rows[i]["EmpId"] + string.Empty) > 0)
                                {
                                    dtDataSource.Rows[i]["DefaultFlag"] = 1;
                                    break;
                                }
                            }
                        }
                    }

                    break;
                case 1:
                    {
                        if (dtDataSource.Rows[rowIndex]["DefaultFlag"] + string.Empty != "1")
                        {
                            var addflag = true;
                            for (var i = 0; i < dtDataSource.Rows.Count; i++)
                            {
                                if (dtDataSource.Rows[i]["DefaultFlag"] + string.Empty == "1" && int.Parse(dtDataSource.Rows[i]["EmpId"] + string.Empty) > 0)
                                {
                                    addflag = false;
                                }
                            }

                            if (addflag)
                            {
                                for (var i = 0; i < dtDataSource.Rows.Count; i++)
                                {
                                    dtDataSource.Rows[i]["DefaultFlag"] = 0;
                                }

                                dtDataSource.Rows[rowIndex]["DefaultFlag"] = 1;
                            }
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgRels.DataSource != null)
            {
                InvokeController("SaveRelDepts", dgRels.DataSource as DataTable);
                Result = true;
                this.Close();
            }
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmRelDepts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    btnReset_Click(null, null);
                    break;
                case Keys.F7:
                    btnQuit_Click(null, null);
                    break;
                case Keys.F8:
                    btnSave_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            var dtDataSource = dgRels.DataSource as DataTable;
            if (null == dtDataSource)
            {
                return;
            }

            if (ckAll.Checked)
            {
                for (int i = 0; i < dtDataSource.Rows.Count; i++)
                {
                    dtDataSource.Rows[i]["EmpId"] = 1;
                    SetDefaultFlag(dtDataSource, 1, i);
                }
            }
            else
            {
                for (int i = 0; i < dtDataSource.Rows.Count; i++)
                {
                    dtDataSource.Rows[i]["EmpId"] = 0;
                    SetDefaultFlag(dtDataSource, 0, i);
                }
            }
        }
    }
}
