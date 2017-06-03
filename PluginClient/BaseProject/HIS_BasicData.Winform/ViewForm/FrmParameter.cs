using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm
{
    /// <summary>
    /// 参数维护
    /// </summary>
    public partial class FrmParameter : BaseFormBusiness, IfrmParameter
    {
        /// <summary>
        /// 选中参数
        /// </summary>
        private Basic_SystemConfig currConfig;

        /// <summary>
        /// 选中参数
        /// </summary>
        public Basic_SystemConfig CurrConfig
        {
            get
            {
                frmFormConfig.GetValue(currConfig);
                return currConfig;
            }

            set
            {
                currConfig = value;
                frmFormConfig.Load(currConfig);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmParameter()
        {
            InitializeComponent();
            frmFormConfig.AddItem(txtParaName, "ParaName");
            frmFormConfig.AddItem(txtParaID, "ParaID");
            frmFormConfig.AddItem(txtParaValue, "Value");
            frmFormConfig.AddItem(txtMemo1, "Memo");
            bindGridSelectIndex(gridConfig);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            InvokeController("GetSystemConfigData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbSysType.SelectedValue), txtSearch.Text);
        }

        /// <summary>
        /// 设置界面控件是否可用
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnState(OperType type)
        {
            if (type == OperType.新增)
            {
                txtParaID.Enabled = true;
                txtParaName.Enabled = true;
            }
            else
            {
                txtParaID.Enabled = false;
                txtParaName.Enabled = false;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            currConfig = new Basic_SystemConfig();
            currConfig.SystemType = Convert.ToInt32(cbSysType.SelectedValue);
            CurrConfig = currConfig;
            SetbtnState(OperType.新增);
        }

        /// <summary>
        /// 停用或启用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridConfig.CurrentCell != null)
            {
                DataTable dt = gridConfig.DataSource as DataTable;
                int sysId = Convert.ToInt32(dt.Rows[gridConfig.CurrentCell.RowIndex]["ID"]);
                int delflag = Convert.ToInt32(dt.Rows[gridConfig.CurrentCell.RowIndex]["Delflag"]);
                if (MessageBox.Show(string.Format("是否{0}此系统参数？", delflag == 1 ? "启用" : "停用"), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    delflag = delflag == 1 ? 0 : 1;
                    InvokeController("SwitchSystemConfig", sysId, delflag);
                    InvokeController("GetSystemConfigData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbSysType.SelectedValue), txtSearch.Text);
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
            if (txtParaName.Text == string.Empty)
            {
                MessageBox.Show("参数名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParaName.Focus();
                return;
            }

            if (txtParaID.Text == string.Empty)
            {
                MessageBox.Show("参数标识不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParaID.Focus();
                return;
            }

            bool isNew = currConfig.ID == 0 ? true : false;

            InvokeController("SaveSystemConfig", Convert.ToInt32(cbWorkers.SelectedValue));
            InvokeController("GetSystemConfigData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbSysType.SelectedValue), txtSearch.Text);

            if (isNew)
            {
                setGridSelectIndex(gridConfig, gridConfig.RowCount - 1);
            }

            SetbtnState(OperType.默认);
        }

        /// <summary>
        /// 选中系统参数
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridSysConfig_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridConfig.CurrentCell != null)
            {
                DataTable dt = gridConfig.DataSource as DataTable;
                currConfig = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_SystemConfig>(dt, gridConfig.CurrentCell.RowIndex);
                CurrConfig = currConfig;
                if (currConfig.DelFlag == 1)
                {
                    btnDel.Text = "启用";
                }
                else
                {
                    btnDel.Text = "停用";
                }
            }
            else
            {
                frmFormConfig.Clear();
            }

            SetbtnState(OperType.默认);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构</param>
        public void loadWorkerDataBox(DataTable dt, int defaultWorkID)
        {
            cbWorkers.DisplayMember = "WorkName";
            cbWorkers.ValueMember = "WorkId";
            cbWorkers.DataSource = dt;
            cbWorkers.SelectedValue = defaultWorkID;
        }

        /// <summary>
        /// 加载系统参数类型列表
        /// </summary>
        /// <param name="dt">系统参数类型列表</param>
        public void loadSystemTypeBox(DataTable dt)
        {
            cbSysType.DisplayMember = "Name";
            cbSysType.ValueMember = "ID";
            cbSysType.DataSource = dt;
            cbSysType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定系统参数列表
        /// </summary>
        /// <param name="dt">系统参数列表</param>
        public void loadSystemConfigGrid(DataTable dt)
        {
            gridConfig.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["Delflag"]) == 1)
                {
                    gridConfig.SetRowColor(i, Color.Red, true);
                }
            }

            setGridSelectIndex(gridConfig);
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmParameter_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("InitLoad");

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbWorkers.Enabled = true;
            }
            else
            {
                cbWorkers.Enabled = false;
            }

            SetbtnState(OperType.默认);
        }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperType
    {
        默认, 新增
    }
}
