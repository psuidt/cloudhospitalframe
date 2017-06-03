using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.Payment;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.PaymentMethodManage
{
    /// <summary>
    /// 支付方式维护
    /// </summary>
    public partial class FrmPaymentMethodManage : BaseFormBusiness, IfrmPaymentMgr
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmPaymentMethodManage()
        {
            InitializeComponent();
            //记录网格上次选定行
            bindGridSelectIndex(gridPayment);
        }

        /// <summary>
        /// 选中的支付方式
        /// </summary>
        private Basic_Payment currPayment;

        /// <summary>
        /// 选中的支付方式
        /// </summary>
        public Basic_Payment CurrPayment
        {
            get
            {
                currPayment.PayCode = txtpaycode.Text;
                currPayment.PayName = txtName.Text;
                currPayment.InputFrom = Convert.ToInt32(cbInputFrom.SelectedValue);
                currPayment.FontColor = btnColor.SelectedColor.ToArgb();
                currPayment.SortOrder = txtOrder.Value;
                currPayment.Memo = txtMemo.Text;
                return currPayment;
            }

            set
            {
                currPayment = value;
                txtpaycode.Text = currPayment.PayCode;
                txtName.Text = currPayment.PayName;
                cbInputFrom.SelectedValue = currPayment.InputFrom;
                btnColor.SelectedColor = Color.FromArgb(currPayment.FontColor);
                txtOrder.Value = currPayment.SortOrder;
                txtMemo.Text = currPayment.Memo;
            }
        }

        /// <summary>
        /// 绑定计算方式列表
        /// </summary>
        /// <param name="dt">计算方式列表</param>
        public void loadInputFromBox(DataTable dt)
        {
            cbInputFrom.DisplayMember = "Name";
            cbInputFrom.ValueMember = "ID";
            cbInputFrom.DataSource = dt;
            cbInputFrom.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定支付方式列表
        /// </summary>
        /// <param name="dt">支付方式列表</param>
        public void loadPaymentGrid(DataTable dt)
        {
            gridPayment.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DelFlag"]) == 1)
                {
                    gridPayment.SetRowColor(i, Color.Red, true);
                }

                gridPayment[4, i].Style.BackColor = Color.FromArgb(Convert.ToInt32(dt.Rows[i]["FontColor"]));
                gridPayment[4, i].Style.ForeColor = Color.FromArgb(Convert.ToInt32(dt.Rows[i]["FontColor"]));
            }

            //设置网格定位当前行
            setGridSelectIndex(gridPayment);
        }

        /// <summary>
        /// 设置界面控件状态
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnState(OperType type)
        {
            if (type == OperType.新增)
            {
                txtpaycode.Enabled = true;
            }
            else
            {
                txtpaycode.Enabled = false;
            }
        }

        /// <summary>
        /// 打开界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmPaymentMethodManage_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("InitLoadData");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetbtnState(OperType.新增);
            CurrPayment = new Basic_Payment();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtpaycode.Text == string.Empty)
            {
                MessageBox.Show("支付代码不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpaycode.Focus();
                return;
            }

            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            bool isNew = currPayment.PaymentID == 0 ? true : false;

            InvokeController("SavePayment");
            InvokeController("GetPaymentData");

            //新增记录定位到最后一行
            if (isNew)
            {
                setGridSelectIndex(gridPayment, gridPayment.RowCount - 1);
            }
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (gridPayment.CurrentCell != null)
            {
                DataTable dt = gridPayment.DataSource as DataTable;
                int id = Convert.ToInt32(dt.Rows[gridPayment.CurrentCell.RowIndex]["PaymentID"]);
                int delflag = Convert.ToInt32(dt.Rows[gridPayment.CurrentCell.RowIndex]["DelFlag"]);
                if (MessageBox.Show(string.Format("是否{0}此支付方式？", delflag == 1 ? "启用" : "停用"), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    delflag = delflag == 1 ? 0 : 1;
                    InvokeController("StopPayment", id, delflag);
                    InvokeController("GetPaymentData");
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRef_Click(object sender, EventArgs e)
        {
            InvokeController("GetPaymentData");
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 选中网格
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridPayment_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridPayment.CurrentCell != null)
            {
                DataTable dt = gridPayment.DataSource as DataTable;
                Basic_Payment payment = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_Payment>(dt, gridPayment.CurrentCell.RowIndex);
                CurrPayment = payment;

                SetbtnState(OperType.默认);

                if (payment.DelFlag == 1)
                {
                    btnStop.Text = "启用";
                }
                else
                {
                    btnStop.Text = "停用";
                }
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
}