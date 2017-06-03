using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EfwControls.HISControl.Orders.Controls.Controller;
using EfwControls.HISControl.Orders.Controls.IView;

namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    /// <summary>
    /// 医嘱费用维护
    /// </summary>
    public partial class OrderFee : UserControl, IOrderFeeControlView
    {
        #region "属性"

        /// <summary>
        /// 是否已加载网格弹出框数据
        /// </summary>
        private bool IsInitShowCardData = false;

        /// <summary>
        /// 医嘱费用控件控制器
        /// </summary>
        private OrderFeeControlController m_OrderFeeControlController;

        /// <summary>
        /// 设置网格编辑状态
        /// </summary>
        public bool SetOrderDetailstGridState
        {
            set
            {
                bool b = value;
                if (b == false)
                {
                    grdFeeList.ReadOnly = false;
                    grdFeeList.Columns[0].ReadOnly = false;// 编码
                    grdFeeList.Columns[1].ReadOnly = true;
                    grdFeeList.Columns[2].ReadOnly = true;
                    grdFeeList.Columns[3].ReadOnly = true;
                    grdFeeList.Columns[4].ReadOnly = true;
                    grdFeeList.Columns[5].ReadOnly = false;// 数量
                    grdFeeList.Columns[6].ReadOnly = true;
                    grdFeeList.Columns[7].ReadOnly = true;
                    grdFeeList.Columns[8].ReadOnly = false;
                }
                else
                {
                    grdFeeList.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 病人入院登记ID
        /// </summary>
        private int m_PatListID = 0;
        /// <summary>
        /// 病人入院登记ID
        /// </summary>
        public int PatListID
        {
            get
            {
                return m_PatListID;
            }
            set
            {
                m_PatListID = value;
            }
        }

        /// <summary>
        /// 医嘱组号ID
        /// </summary>
        private int m_GroupID = 0;
        /// <summary>
        /// 医嘱组号ID
        /// </summary>
        public int GroupID
        {
            get
            {
                return m_GroupID;
            }
            set
            {
                m_GroupID = value;
            }
        }

        /// <summary>
        /// 执行科室ID
        /// </summary>
        private int m_ExecDeptID = 0;

        /// <summary>
        /// 执行科室名
        /// </summary>
        private string m_ExecDeptName = string.Empty;

        /// <summary>
        /// 网格是否可编辑
        /// </summary>
        private bool IsEnabled = true;

        private bool IsLoad = false;

        #endregion

        #region "构造函数"

        /// <summary>
        /// 构造函数
        /// </summary>
        public OrderFee()
        {
            InitializeComponent();
            // 控件初始化
            m_OrderFeeControlController = new OrderFeeControlController(this);
        }

        #endregion

        #region "外部接口"

        /// <summary>
        /// 绑定医嘱关联费用数据
        /// </summary>
        /// <param name="PatListID">病人ID</param>
        /// <param name="GroupID">医嘱组号ID</param>
        /// <param name="ExecDeptID">执行科室ID</param>
        /// <param name="ExecDeptName">执行科室名</param>
        public void LoadOrderFeeGridData(int PatListID, int GroupID, int ExecDeptID, string ExecDeptName)
        {
            IsLoad = false;
            grdFeeList.EndEdit();
            SetOrderDetailstGridState = true;
            m_PatListID = PatListID;
            m_GroupID = GroupID;
            m_ExecDeptID = ExecDeptID;
            m_ExecDeptName = ExecDeptName;
            DataTable OrderFeeList = m_OrderFeeControlController.LoadOrderFeeGridData();
            grdFeeList.DataSource = OrderFeeList;
            // 首次加载数据时为网格弹出框加载数据源
            if (!IsInitShowCardData)
            {
                DataTable ShowCardDataList = m_OrderFeeControlController.GetDocFeeItemList();
                grdFeeList.BindSelectionCardDataSource(0, ShowCardDataList);
                DataTable ModeDt = InitMode();
                grdFeeList.SelectionCards[1].BindColumnIndex = CalCostMode.Index;
                grdFeeList.SelectionCards[1].CardColumn = "CalCostMode|计费模式|100";
                grdFeeList.SelectionCards[1].CardSize = new System.Drawing.Size(150, 100);
                grdFeeList.BindSelectionCardDataSource(1, ModeDt);
                IsInitShowCardData = true;
            }
            IsLoad = true;
        }

        /// <summary>
        /// 做成计费模式数据
        /// </summary>
        /// <returns></returns>
        private DataTable InitMode()
        {
            DataTable dtMode = new DataTable();
            dtMode.Columns.Add("CalCostMode");
            DataRow dr = dtMode.NewRow();
            dr["CalCostMode"] = "按频次";
            dtMode.Rows.Add(dr);
            dr = dtMode.NewRow();
            dr["CalCostMode"] = "按周期";
            dtMode.Rows.Add(dr);
            return dtMode;
        }

        /// <summary>
        /// 设置控件是否可编辑
        /// </summary>
        /// <param name="Enabled">状态标识</param>
        public void SetButtonEnabled(bool Enabled)
        {
            btnAdd.Enabled = Enabled; // 新增
            btnDel.Enabled = Enabled; // 删除
            btnSave.Enabled = Enabled; // 保存
            bar2.Visible = Enabled;
            IsEnabled = Enabled;
            // 设置网格为不可编辑状态
            if (!Enabled)
            {
                SetOrderDetailstGridState = true;
            }
        }

        #endregion

        #region "网格操作事件"

        /// <summary>
        /// 新增医嘱费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 验证医嘱是否已转抄，已转抄的医嘱不允许补录费用
            if (m_OrderFeeControlController.CheckOrderStatus(m_PatListID, m_GroupID))
            {
                m_OrderFeeControlController.MessageShow("当前医嘱已转抄，无法继续补录费用！");
                return;
            }

            if (grdFeeList.DataSource != null)
            {
                // 设置费用网格为可编辑状态
                SetOrderDetailstGridState = false;
                // 新增医嘱费用
                grdFeeList.AddRow();
                DataTable dt = grdFeeList.DataSource as DataTable;
            }
        }

        /// <summary>
        /// 删除医嘱费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdFeeList.DataSource != null)
            {
                // 判断

                if (grdFeeList.CurrentCell != null)
                {
                    // 如果选中的是医嘱本身则不允许删除
                    int rowIndex = grdFeeList.CurrentCell.RowIndex;
                    DataTable FeeList = grdFeeList.DataSource as DataTable;
                    if (!string.IsNullOrEmpty(FeeList.Rows[rowIndex]["FeeSource"].ToString()))
                    {
                        if (Convert.ToInt32(FeeList.Rows[rowIndex]["FeeSource"].ToString()) == 0)
                        {
                            return;
                        }
                    }

                    // 询问是否确认删除
                    if (MessageBox.Show("确定要删除选中费用吗！删除后将不可恢复？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // 设置网格不可编辑
                        SetOrderDetailstGridState = true;
                        grdFeeList.EndEdit();
                        // 取得选中的数据进行删除
                        //int rowIndex = grdFeeList.CurrentCell.RowIndex;
                        //DataTable FeeList = grdFeeList.DataSource as DataTable;
                        int GenerateID = 0;
                        if (!string.IsNullOrEmpty(FeeList.Rows[rowIndex]["GenerateID"].ToString()))
                        {
                            GenerateID = Convert.ToInt32(FeeList.Rows[rowIndex]["GenerateID"]);
                        }
                        FeeList.Rows.RemoveAt(rowIndex);
                        // 判断当前选中的数据是否存在数据库中
                        if (GenerateID > 0)
                        {
                            m_OrderFeeControlController.DelFeeItemData(GenerateID);
                        }
                        m_OrderFeeControlController.MessageShow("医嘱费用删除成功！");
                    }
                }
            }
        }

        /// <summary>
        /// 保存医嘱费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            IsLoad = false;
            if (grdFeeList.DataSource != null)
            {
                SetOrderDetailstGridState = true;
                grdFeeList.EndEdit();
                DataTable FeeDt = grdFeeList.DataSource as DataTable;
                if (FeeDt == null || FeeDt.Rows.Count <= 0)
                {
                    return;
                }

                // 检查是否存在数量为0的数据
                for (int i = 0; i < FeeDt.Rows.Count; i++)
                {
                    // 判断是否为医嘱本身
                    if (!string.IsNullOrEmpty(FeeDt.Rows[i]["FeeSource"].ToString()))
                    {
                        if (Convert.ToInt32(FeeDt.Rows[i]["FeeSource"].ToString()) == 0)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(FeeDt.Rows[i]["Amount"].ToString()) <= 0)
                        {
                            grdFeeList.CurrentCell = grdFeeList[5, i];
                            grdFeeList.BeginEdit(true);
                            m_OrderFeeControlController.MessageShow("数量不能为0！");
                            return;
                        }
                    }
                }

                //  保存医嘱关联费用数据
                if (m_OrderFeeControlController.SaveFeeItemData(FeeDt))
                {
                    // 重新加载网格数据
                    DataTable OrderFeeList = m_OrderFeeControlController.LoadOrderFeeGridData();
                    grdFeeList.DataSource = OrderFeeList;
                }
            }
            IsLoad = true;
        }

        /// <summary>
        /// 弹出网格选中事件
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <param name="stop"></param>
        /// <param name="customNextColumnIndex"></param>
        private void grdFeeList_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            DataRow row = (DataRow)SelectedValue;
            int rowid = this.grdFeeList.CurrentCell.RowIndex;
            DataTable dt = (DataTable)grdFeeList.DataSource;
            if (customNextColumnIndex == ItemID.Index)
            {
                // 判断是否存在相同的项目，相同的项目只能录一条数据
                string strWhere = string.Format("ItemID = {0}", row["ItemID"]);
                DataRow[] feeDr = dt.Select(strWhere);
                // 当前行未选中数据
                if (string.IsNullOrEmpty(dt.Rows[rowid]["ItemID"].ToString()))
                {
                    if (feeDr.Length > 0)
                    {
                        m_OrderFeeControlController.MessageShow(
                            string.Format("费用明细中已存在【{0}】,请不要重复录入！", row["ItemName"]));
                        return;
                    }
                }
                //else
                //{
                //    // 当前行已选中数据
                //    if (feeDr.Length > 1)
                //    {

                //        return;
                //    }
                //}
                if (string.IsNullOrEmpty(dt.Rows[rowid]["GenerateID"].ToString()))
                {
                    dt.Rows[rowid]["GenerateID"] = 0;
                }
                dt.Rows[rowid]["PatListID"] = m_PatListID;  // 病人登记ID
                dt.Rows[rowid]["BabyID"] = 0;   // BadyId
                dt.Rows[rowid]["ItemID"] = row["ItemID"]; // 项目ID
                dt.Rows[rowid]["ItemName"] = row["ItemName"]; // 项目名
                dt.Rows[rowid]["FeeClass"] = row["ItemClass"]; // 项目类型
                int ItemClass = Convert.ToInt32(row["ItemClass"]);
                dt.Rows[rowid]["StatID"] = row["StatID"]; // 大项目ID
                dt.Rows[rowid]["Spec"] = row["Standard"]; // 规格
                dt.Rows[rowid]["Unit"] = row["MiniUnitName"]; // 单位
                dt.Rows[rowid]["PackAmount"] = row["MiniConvertNum"]; // 划价系数
                dt.Rows[rowid]["InPrice"] = row["InPrice"];  // 批发价
                dt.Rows[rowid]["SellPrice"] = row["SellPrice"]; // 销售价
                dt.Rows[rowid]["Amount"] = 0;  // 数量
                dt.Rows[rowid]["TotalFee"] = 0; // 总金额
                dt.Rows[rowid]["DoseAmount"] = 0;// 处方帖数
                if (ItemClass == 2)
                {
                    dt.Rows[rowid]["ExecDeptDoctorID"] = m_ExecDeptID; // 执行科室ID
                    dt.Rows[rowid]["ExecDeptName"] = m_ExecDeptName; // 执行科室名
                }
                else
                {
                    dt.Rows[rowid]["ExecDeptDoctorID"] = row["ExecDeptId"]; // 执行科室ID
                    dt.Rows[rowid]["ExecDeptName"] = row["ExecDeptName"]; // 执行科室名
                }
                dt.Rows[rowid]["PresDate"] = DateTime.Now.ToString("yyyy-MM-dd"); // 处方日期
                dt.Rows[rowid]["MarkDate"] = DateTime.Now; // 划价时间
                // 计费模式
                dt.Rows[rowid]["CalCostMode"] = 0;
                dt.Rows[rowid]["CalCostModeName"] = "按频次";
                // 已改动的数据标识
                dt.Rows[rowid]["UpdFlg"] = 1;
                // 费用来源
                dt.Rows[rowid]["FeeSource"] = 2;
            }
            else if (customNextColumnIndex == CalCostMode.Index)
            {
                // 修改计费模式
                dt.Rows[rowid]["CalCostModeName"] = row["CalCostMode"];
                // 修改成按频次计费
                if (row["CalCostMode"].ToString().Contains("按频次"))
                {
                    dt.Rows[rowid]["CalCostMode"] = 0;
                }
                else
                {
                    // 修改成按周期计费
                    dt.Rows[rowid]["CalCostMode"] = 1;
                }
                // 已改动的数据标识
                dt.Rows[rowid]["UpdFlg"] = 1;
            }

            grdFeeList.Refresh();
        }

        /// <summary>
        /// 费用数据选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdFeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 8)
            {
                // 如果选中的是药品数据时，则不允许修改
                int rowIndex = grdFeeList.CurrentCell.RowIndex;
                DataTable FeeItemDt = grdFeeList.DataSource as DataTable;
                if (!string.IsNullOrEmpty(FeeItemDt.Rows[rowIndex]["FeeSource"].ToString()))
                {
                    if (Convert.ToInt32(FeeItemDt.Rows[rowIndex]["FeeSource"].ToString()) == 0)
                    {
                        SetOrderDetailstGridState = true;
                    }
                    else
                    {
                        SetOrderDetailstGridState = false;
                    }
                }
            }
        }

        /// <summary>
        /// 根据数量计算总金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdFeeList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (grdFeeList.CurrentCell != null)
                {
                    int rowIndex = grdFeeList.CurrentCell.RowIndex;
                    DataTable dt = grdFeeList.DataSource as DataTable;
                    if (grdFeeList.CurrentCell.DataGridView[e.ColumnIndex, rowIndex].Value is DBNull)
                    {
                        return;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[rowIndex]["Amount"].ToString())
                    && !string.IsNullOrEmpty(dt.Rows[rowIndex]["PackAmount"].ToString()))
                    {
                        // 根据数量计算总价格（数量*单价/划价系数）
                        int count = int.Parse(dt.Rows[rowIndex]["Amount"].ToString());
                        decimal PackAmount = decimal.Parse(dt.Rows[rowIndex]["PackAmount"].ToString());
                        decimal price = decimal.Parse(dt.Rows[rowIndex]["SellPrice"].ToString());
                        dt.Rows[rowIndex]["TotalFee"] = Math.Round(count * price / PackAmount, 2);
                        dt.Rows[rowIndex]["UpdFlg"] = 1;
                    }
                    grdFeeList.Refresh();
                }
            }
        }

        /// <summary>
        /// 选中数据为药品数据时设置选中行为不可编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdFeeList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdFeeList.DataSource != null)
            {
                if (grdFeeList.CurrentCell != null)
                {
                    if (IsLoad)
                    {
                        if (IsEnabled)
                        {
                            int rowIndex = grdFeeList.CurrentCell.RowIndex;
                            DataTable FeeItemDt = grdFeeList.DataSource as DataTable;
                            if (!string.IsNullOrEmpty(FeeItemDt.Rows[rowIndex]["FeeSource"].ToString()))
                            {
                                if (Convert.ToInt32(FeeItemDt.Rows[rowIndex]["FeeSource"].ToString()) == 0)
                                {
                                    SetOrderDetailstGridState = true;
                                }
                                else
                                {
                                    SetOrderDetailstGridState = false;
                                }
                            }
                            else
                            {
                                SetOrderDetailstGridState = false;
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
