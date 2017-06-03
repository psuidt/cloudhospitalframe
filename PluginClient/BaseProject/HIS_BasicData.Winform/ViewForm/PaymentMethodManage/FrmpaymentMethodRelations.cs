using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.Payment;

namespace HIS_BasicData.Winform.ViewForm.PaymentMethodManage
{
    /// <summary>
    /// 支付方式组合维护
    /// </summary>
    public partial class FrmpaymentMethodRelations : BaseFormBusiness, IfrmPaymentRel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmpaymentMethodRelations()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定病人类型列表
        /// </summary>
        /// <param name="dt">病人类型列表</param>
        public void loadPatTypeBox(DataTable dt)
        {
            cbPatType.DisplayMember = "PatTypeName";
            cbPatType.ValueMember = "PatTypeID";
            cbPatType.DataSource = dt;
            cbPatType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        /// <param name="dt">支付方式</param>
        public void loadPaymentBox(DataTable dt)
        {
            cbPayment.DisplayMember = "PayName";
            cbPayment.ValueMember = "PaymentID";
            cbPayment.DataSource = dt;
        }

        /// <summary>
        /// 绑定本院支付方式
        /// </summary>
        /// <param name="dt">本院支付方式</param>
        public void loadHospPaymentGrid(DataTable dt)
        {
            gridPayment.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DelFlag"]) == 1)
                {
                    gridPayment.SetRowColor(i, Color.Red, true);
                }

                gridPayment[6, i].Style.BackColor = Color.FromArgb(Convert.ToInt32(dt.Rows[i]["FontColor"]));
            }
        }

        /// <summary>
        /// 绑定业务系统列表
        /// </summary>
        /// <param name="dt">业务系统列表</param>
        public void loadSystemTypeBox(DataTable dt)
        {
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "ID";
            cbType.DataSource = dt;
            cbType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构ID</param>
        public void loadWorkerDataBox(DataTable dt, int defaultWorkID)
        {
            cbWorkers.DisplayMember = "WorkName";
            cbWorkers.ValueMember = "WorkId";
            cbWorkers.DataSource = dt;
            cbWorkers.SelectedValue = defaultWorkID;
            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbWorkers.Enabled = true;
            }
            else
            {
                cbWorkers.Enabled = false;
            }
        }

        /// <summary>
        /// 设置界面控件是否可用
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnState(OperType type)
        {
            if (type == OperType.新增)
            {
                groupAdd.Enabled = true;
                groupSearch.Enabled = false;
            }
            else
            {
                groupAdd.Enabled = false;
                groupSearch.Enabled = true;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            InvokeController("GetHospPaymentData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbType.SelectedValue), Convert.ToInt32(cbPatType.SelectedValue));
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetbtnState(OperType.新增);
            txtOrder.Value = 0;
            cbPayment.Text = string.Empty;
            DataTable dt = gridPayment.DataSource as DataTable;
            if (dt == null)
            {
                return;
            }

            if (dt.Rows.Count == 0)
            {
                return;
            }

            txtOrder.Value = Tools.ToInt32(dt.Rows[dt.Rows.Count - 1]["PayOrder"]) + 1;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbPayment.Text == string.Empty)
            {
                MessageBox.Show("请先选择一种支付方式！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPayment.Focus();
                return;
            }

            InvokeController(
                "AddHospPayment",
                 Convert.ToInt32(cbWorkers.SelectedValue),
                 Convert.ToInt32(cbPatType.SelectedValue),
                 Convert.ToInt32(cbPayment.SelectedValue),
                 Convert.ToInt32(cbType.SelectedValue),
                 txtOrder.Value);
            InvokeController(
                "GetHospPaymentData",
                 Convert.ToInt32(cbWorkers.SelectedValue),
                 Convert.ToInt32(cbType.SelectedValue),
                 Convert.ToInt32(cbPatType.SelectedValue));
            setGridSelectIndex(gridPayment, gridPayment.RowCount - 1);
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetbtnState(OperType.默认);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridPayment.CurrentCell != null)
            {
                DataTable dt = gridPayment.DataSource as DataTable;
                int id = Convert.ToInt32(dt.Rows[gridPayment.CurrentCell.RowIndex]["ID"]);
                if (MessageBox.Show("是否删除此支付方式？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    InvokeController("DeleteHospPayment", id);
                    InvokeController(
                        "GetHospPaymentData",
                        Convert.ToInt32(cbWorkers.SelectedValue),
                        Convert.ToInt32(cbType.SelectedValue),
                        Convert.ToInt32(cbPatType.SelectedValue));
                }
            }
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
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmpaymentMethodRelations_OpenWindowBefore(object sender, EventArgs e)
        {
            bindGridSelectIndex(gridPayment);
            InvokeController("HospInitLoadData");
            InvokeController("GetHospPaymentData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbType.SelectedValue), Convert.ToInt32(cbPatType.SelectedValue));

            SetbtnState(OperType.默认);
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public enum OperType
        {
            默认, 新增
        }

        /// <summary>
        /// 选中支付方式
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridPayment_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridPayment.CurrentCell != null)
            {
                SetbtnState(OperType.默认);
            }
        }

        /// <summary>
        /// 顺序调整
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (gridPayment.Rows.Count <= 0)
            {
                return;
            }

            //得到当前选中行的索引
            int rowIndex = gridPayment.SelectedRows[0].Index;

            if (rowIndex == 0)
            {
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < gridPayment.Columns.Count; i++)
            {
                if (gridPayment.SelectedRows[0].Cells[i].Value == null)
                {
                    list.Add(string.Empty);
                }
                else
                {
                    list.Add(gridPayment.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
                }
            }

            for (int j = 0; j < gridPayment.Columns.Count; j++)
            {
                gridPayment.Rows[rowIndex].Cells[j].Value = gridPayment.Rows[rowIndex - 1].Cells[j].Value;
                gridPayment.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }

            gridPayment.Rows[rowIndex - 1].Selected = true;
            gridPayment.Rows[rowIndex].Selected = false;
            gridPayment.CurrentCell = gridPayment[0, rowIndex - 1];
            DataTable dt = (DataTable)gridPayment.DataSource;
            InvokeController("SortPayment", dt);
            InvokeController("GetHospPaymentData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbType.SelectedValue), Convert.ToInt32(cbPatType.SelectedValue));
            setGridSelectIndex(gridPayment, rowIndex - 1);
        }

        /// <summary>
        /// 顺序调整
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (gridPayment.Rows.Count <= 0)
            {
                return;
            }

            //得到当前选中行的索引
            int rowIndex = gridPayment.SelectedRows[0].Index;

            if (rowIndex == gridPayment.Rows.Count - 1)
            {
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < gridPayment.Columns.Count; i++)
            {
                if (gridPayment.SelectedRows[0].Cells[i].Value == null)
                {
                    list.Add(string.Empty);
                }
                else
                {
                    list.Add(gridPayment.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
                }
            }

            for (int j = 0; j < gridPayment.Columns.Count; j++)
            {
                gridPayment.Rows[rowIndex].Cells[j].Value = gridPayment.Rows[rowIndex + 1].Cells[j].Value;
                gridPayment.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }

            gridPayment.Rows[rowIndex + 1].Selected = true;
            gridPayment.Rows[rowIndex].Selected = false;
            gridPayment.CurrentCell = gridPayment[0, rowIndex + 1];
            DataTable dt = (DataTable)gridPayment.DataSource;
            InvokeController("SortPayment", dt);
            InvokeController("GetHospPaymentData", Convert.ToInt32(cbWorkers.SelectedValue), Convert.ToInt32(cbType.SelectedValue), Convert.ToInt32(cbPatType.SelectedValue));
            setGridSelectIndex(gridPayment, rowIndex + 1);
        }
    }
}