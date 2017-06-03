using System;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Winform.ViewForm.Employee
{
    /// <summary>
    /// 人员关联病区
    /// </summary>
    public partial class FrmRelWard : BaseFormBusiness, IFrmRelWards
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmRelWard()
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
        /// 加载关联病区列表
        /// </summary>
        /// <param name="depts">病区列表</param>
        public void LoadRelWards(DataTable depts)
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
            InvokeController("LoadRelWards", WorkId, EmpId);
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
            InvokeController("LoadRelWards", WorkId, EmpId);
        }

        /// <summary>
        /// 选中病区设置默认
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
                //默认病区
                if (colIndex == 3)
                {
                    for (var i = 0; i < dtDataSource.Rows.Count; i++)
                    {
                        dtDataSource.Rows[i]["DefaultCK"] = 0;
                    }

                    dtDataSource.Rows[rowIndex]["DefaultCK"] = 1;
                    dtDataSource.Rows[rowIndex]["CK"] = 1;
                }

                //关联病区
                if (colIndex == 0)
                {
                    var value = Convert.ToInt32(dtDataSource.Rows[rowIndex]["CK"]);
                    if (value==1)
                    {
                        dtDataSource.Rows[rowIndex]["CK"] = 0;
                        dtDataSource.Rows[rowIndex]["DefaultCK"] = 0;
                        //SetDefaultFlag(dtDataSource, iEmpId, rowIndex);
                    }
                    else
                    {
                        dtDataSource.Rows[rowIndex]["CK"] = 1;
                        //SetDefaultFlag(dtDataSource, 1, rowIndex);
                    }
                }
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
                InvokeController("SaveRelWards", dgRels.DataSource as DataTable);
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
                    dtDataSource.Rows[i]["CK"] = 1;
                }
            }
            else
            {
                for (int i = 0; i < dtDataSource.Rows.Count; i++)
                {
                    dtDataSource.Rows[i]["CK"] = 0;
                    dtDataSource.Rows[i]["DefaultCK"] = 0;
                }
            }
        }
    }
}
