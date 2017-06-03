using System;
using System.Data;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Winform.ViewForm.User
{
    /// <summary>
    /// 用户关联角色
    /// </summary>
    public partial class FrmRelGroups : BaseFormBusiness, IFrmRelGroups
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmRelGroups()
        {
            InitializeComponent();
        }

        #region IFrmRelGroups
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 绑定角色列表
        /// </summary>
        /// <param name="depts">角色列表</param>
        public void LoadRelGroups(DataTable depts)
        {
            dgRelGroups.DataSource = depts;
        }

        #endregion

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmRelDepts_Load(object sender, EventArgs e)
        {
            InvokeController("LoadRelGroups", WorkId, UserId);
        }

        /// <summary>
        /// 关闭界面
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
            InvokeController("LoadRelGroups", WorkId, UserId);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgRelGroups.DataSource != null)
            {
                InvokeController("SaveRelGroups", dgRelGroups.DataSource as DataTable);
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
        /// 选中角色
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgRelGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var colIndex = e.ColumnIndex;
            if (rowIndex >= 0 && colIndex == 0)
            {
                var dtDataSource = dgRelGroups.DataSource as DataTable;
                if (null == dtDataSource)
                {
                    return;
                }

                var value = dtDataSource.Rows[rowIndex]["bFlag"] as int?;
                if (value.HasValue)
                {
                    var iFlag = value.Value != 0 ? 0 : 1;
                    dtDataSource.Rows[rowIndex]["bFlag"] = iFlag;
                }
                else
                {
                    dtDataSource.Rows[rowIndex]["bFlag"] = 1;
                }
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            var dtDataSource = dgRelGroups.DataSource as DataTable;
            if (null == dtDataSource)
            {
                return;
            }

            if (ckAll.Checked)
            {
                for (int i = 0; i < dtDataSource.Rows.Count; i++)
                {
                    dtDataSource.Rows[i]["bFlag"] = 1;
                }
            }
            else
            {
                for (int i = 0; i < dtDataSource.Rows.Count; i++)
                {
                    dtDataSource.Rows[i]["bFlag"] = 0;
                }
            }
        }
    }
}
