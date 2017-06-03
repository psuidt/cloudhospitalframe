using DevComponents.DotNetBar;
using EfwControls.HISControl.Orders.Controls.Controller;
using EfwControls.HISControl.Orders.Controls.Entity;
using EfwControls.HISControl.Orders.Controls.IView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    public partial class OrdersControl : UserControl, IOrdersControlView
    {
        public OrdersControlController controller;
        public OrdersControl()
        {
            InitializeComponent();
            controller = new OrdersControlController(this); 
        }
        [Description("医嘱保存时费用联动")]
        public event PrescriptionCostoflinkage Costoflinkage;
        [Description("开皮试医嘱时增加皮试医嘱")]
        public event PrescriptionAstoflinkage Astoflinkage;
        [Description("保存医嘱时错误提示定位")]
        public event PrescriptionSaveChecklinkage SaveCheckoflinkage;
        [Description("保存医嘱时消息提法")]
        public event PrescriptionMessageShowlinkage MessageShowoflinkage;
        [Description("医嘱费用显示")]
        public event PrescriptionFeeShowlinkage FeeShowoflinkage;
        [Description("病人信息刷新")]
        public event PrescriptionFreshlinkage Freshlinkage;
        [Description("药品信息显示")]
        public event PrescriptionDrugDetailShowlinkage DetailShowlinkage;

        #region 自定义属性
        private bool _isShowToolBar = true;
        [Description("是否显示工具栏")]
        public bool IsShowToolBar
        {
            get { return _isShowToolBar; }
            set
            {
                _isShowToolBar = value;
                this.btnBar.Visible = _isShowToolBar;
            }
        }

        private OrderCategory _orderCategory = OrderCategory.长期医嘱;
        [Description("医嘱类别")]
        public OrderCategory OrderStyle
        {
            get { return _orderCategory; }
            set
            {
                _orderCategory = value;
                if (_orderCategory == OrderCategory.长期医嘱)
                {
                    ShowDoseNum.Visible = false;
                    ShowFirstNum.Visible = true;
                    ShowTeminalNum.Visible = true;
                    EOrderDocName.Visible = true;
                    EOrderDate.Visible = true;
                    Amount.Visible = false;
                    Unit.Visible = false;
                    TsmSelfOrder.Visible = true;
                    TsmGivePat.Visible = false;
                    TsmOutOrder.Visible = false;
                    取消停嘱ToolStripMenuItem.Visible = true;
                }
                else
                {
                    ShowDoseNum.Visible = true;
                    ShowFirstNum.Visible = false;
                    ShowTeminalNum.Visible = false;
                    EOrderDocName.Visible = false;
                    EOrderDate.Visible = false;
                    Amount.Visible = true;
                    Unit.Visible = true;
                    TsmSelfOrder.Visible = true;
                    TsmGivePat.Visible = true;
                    TsmOutOrder.Visible = true;
                    取消停嘱ToolStripMenuItem.Visible = false;
                }
            }
        }

        private string[] _oldhideColName;
        private string[] _hideColName;
        [Description("需要隐藏的列名")]
        public string[] HideColName
        {
            get { return _hideColName; }
            set
            {
                _hideColName = value;
                if (_oldhideColName != null && _oldhideColName.Length > 0)
                {
                    for (int i = 0; i < _oldhideColName.Length; i++)
                    {
                        if (_oldhideColName[i].Trim() != "")
                        {
                            if (dgvOrders.Columns.Contains(_oldhideColName[i]) == true)
                            {
                                dgvOrders.Columns[_oldhideColName[i]].Visible = true;
                            }
                        }
                    }
                }
                if (_hideColName != null && _hideColName.Length > 0)
                {
                    for (int i = 0; i < _hideColName.Length; i++)
                    {
                        if (_hideColName[i].Trim() != "")
                        {
                            if (dgvOrders.Columns.Contains(_hideColName[i]) == true)
                            {
                                dgvOrders.Columns[_hideColName[i]].Visible = false;
                            }
                        }
                    }
                }

                _oldhideColName = _hideColName;
            }
        }
        #endregion

        #region 接口事件
        public void SaveCostoflinkage(List<Entity.OrderRecord> data)
        {
            if (Costoflinkage != null)
            {
                Costoflinkage(CurrPatListId, data);
            }
        }
        public void SaveAstoflinkage(List<Entity.OrderRecord> data)
        {
            if (Astoflinkage != null)
            {
                Astoflinkage(CurrPatListId, data);
            }
        }
        public void SaveOrderCheckoflinkage(int orderCategory,int rowindex,string colName)
        {
            if (SaveCheckoflinkage != null)
            {
                SaveCheckoflinkage(orderCategory, rowindex,colName);
            }
        }
        #endregion

        #region 接口数据源数据
        public void InitDbHelper(IOrderDbHelper iOrderDbHelper)
        {
            controller.BindCardDataSource(iOrderDbHelper);
        }
        private string enterDate;
        /// <summary>
        /// 数据补始化
        /// </summary>
        /// <param name="patListID">病人ID</param>
        /// <param name="patStatus">病人状态</param>
        /// <param name="presDeptCode">开嘱科室</param>
        /// <param name="presDeptName">开嘱科室名称</param>
        /// <param name="presDoctorId">开嘱医生</param>
        /// <param name="presDoctorName">开嘱医生姓名</param>
        public void LoadPatData(int patListID, int isLeaveHosOrder, int presDeptCode, string presDeptName, int presDoctorId, string presDoctorName, int patDeptId, string defaultDrugStore, string _enterDate,bool hasNotFinishTrans)
        {
            CurrPatListId = patListID;
            PresDeptId = presDeptCode;
            PresDeptName = presDeptName;
            PresDoctorId = presDoctorId;
            PresDoctorName = presDoctorName;
            IsLeaveHosOrder = isLeaveHosOrder;
            PatDeptID = patDeptId;
            enterDate = _enterDate;
            HasNotFinishTrans = hasNotFinishTrans;
            if (_drugStoreDeptID != defaultDrugStore)
            {
                _drugStoreDeptID = defaultDrugStore;
                controller.RefreshOrderShowCard(_drugStoreDeptID, false);
            }
            (controller as OrdersControlController).BindOrderData();
            this.dgvOrders.Refresh();
            FeeShowoflinkage(-1, 0, 0, "", 3, 0);
            DetailShowlinkage(null, "");
        }
        /// <summary>
        /// 选择药房刷新数据源
        /// </summary>
        /// <param name="defaultDrugStore"></param>
        public void RefreshDrugData(string defaultDrugStore)
        {
            if (_drugStoreDeptID != defaultDrugStore)
            {
                _drugStoreDeptID = defaultDrugStore;
                controller.RefreshOrderShowCard(_drugStoreDeptID, false);
                if (dgvOrders != null && dgvOrders.CurrentCell != null)
                {                 
                    if (dgvOrders["ShowOrderBdate", dgvOrders.CurrentCell.RowIndex].Value == DBNull.Value)
                    {
                        int destRowIndex = dgvOrders.CurrentCell.RowIndex;
                        DataTable tbPresc = (DataTable)dgvOrders.DataSource;
                        int statid = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["StatId"]);
                        int itemtype = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["ItemType"]);
                        controller.ShowCardItemDrugChange(statid, itemtype, "(0)", false);
                        dgvOrders.CurrentCell = this.dgvOrders["Dosage", dgvOrders.CurrentCell.RowIndex];
                        dgvOrders.CurrentCell = this.dgvOrders["ItemName", dgvOrders.CurrentCell.RowIndex];
                    }
                    else
                    {
                        dgvOrders.CurrentCell = this.dgvOrders["Dosage", dgvOrders.CurrentCell.RowIndex];
                        dgvOrders.CurrentCell = this.dgvOrders["ItemName", dgvOrders.CurrentCell.RowIndex];
                    }
                }
            }
        }
        public void InitializeCardData()
        {
            DataSet cardDataSource = controller.CardDataSource;            
            this.dgvOrders.BindSelectionCardDataSource(1, cardDataSource.Tables["usagedic"]);//用法
            this.dgvOrders.BindSelectionCardDataSource(2, cardDataSource.Tables["frequencydic"]);//频次  
            this.dgvOrders.BindSelectionCardDataSource(3, cardDataSource.Tables["unitdic"]);//单位         
            this.dgvOrders.BindSelectionCardDataSource(4, cardDataSource.Tables["entrustdic"]);//嘱托
            this.dgvOrders.BindSelectionCardDataSource(0, cardDataSource.Tables["itemdrug"]);//药品项目 
        }

        public void ShowCardItemDrugSet(DataTable dtItemDrug)
        {
            this.dgvOrders.BindSelectionCardDataSource(0, dtItemDrug);//药品项目     
        }
        public void ShowCardUnitSet(DataTable dtUnit)
        {
            this.dgvOrders.BindSelectionCardDataSource(3, dtUnit);//药品单位    
        }
        public void ShowCardEntrustSet(DataTable dtEntrust)
        {
            this.dgvOrders.BindSelectionCardDataSource(4, dtEntrust);//嘱托 
        }
        public void LoadGridOrderData(DataTable orderData)
        {
            dgvOrders.EndEdit();
            dgvOrders.CurrentCellChanged -= dgvOrders_CurrentCellChanged;
            dgvOrders.DataSource = orderData;
            dgvOrders.CurrentCellChanged += dgvOrders_CurrentCellChanged;
        }
        #endregion

        #region 接口属性实现 
        //显示所有医嘱还是有效医嘱     
        private bool _isshowAllOrder;
        [Browsable(false)]
        public bool IsShowAllOrder
        {
            get
            {
                return _isshowAllOrder;
            }
            set
            {
                _isshowAllOrder = value;
            }
        }
        private string _drugStoreDeptID;

        private int _patDeptID;
        [Browsable(false)]
        public int PatDeptID
        {
            get
            {
                return _patDeptID;
            }

            set
            {
                _patDeptID = value;
            }
        }
        private int _currpatlistid;
        [Browsable(false)]
        public int CurrPatListId
        {
            get
            {
                return _currpatlistid;
            }

            set
            {
                _currpatlistid = value;
            }
        }
        private int _presdeptid;
        [Browsable(false)]
        public int PresDeptId
        {
            get
            {
                return _presdeptid;
            }

            set
            {
                _presdeptid = value;
            }
        }
        private string _presdeptname;
        [Browsable(false)]
        public string PresDeptName
        {
            get
            {
                return _presdeptname;
            }

            set
            {
                _presdeptname = value;
            }
        }
        private int _presdoctorid;
        [Browsable(false)]
        public int PresDoctorId
        {
            get
            {
                return _presdoctorid;
            }

            set
            {
                _presdoctorid = value;
            }
        }
        private string _presdoctorname;
        [Browsable(false)]
        public string PresDoctorName
        {
            get
            {
                return _presdoctorname;
            }

            set
            {
                _presdoctorname = value;
            }
        }
        private int _isLeaveHosOrder;
        [Browsable(false)]
        public int IsLeaveHosOrder
        {
            get
            {
                return _isLeaveHosOrder;
            }

            set
            {
                _isLeaveHosOrder = value;
            }
        }
        private bool _hasNotFinishTrans;
        [Browsable(false)]
        public bool HasNotFinishTrans
        {
            get
            {
                return _hasNotFinishTrans;
            }

            set
            {
                _hasNotFinishTrans = value;
            }
        }
        public DataTable GetGridOrder
        {
            get
            {
                return (DataTable)dgvOrders.DataSource;
            }
        }
        [Browsable(false)]
        public int GridRowIndex
        {
            get
            {
                if (dgvOrders.CurrentCell != null)
                    return dgvOrders.CurrentCell.RowIndex;
                else
                    return -1;
            }
        }
        #endregion

        #region 网格外观控制
        //设置颜色
        public void SetGridColor()
        {
            if (dgvOrders != null && dgvOrders.Rows.Count > 0)
            {
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    int flag = Convert.IsDBNull(dgvOrders[Status.Name, i].Value) ? 0 : Convert.ToInt32(dgvOrders[Status.Name, i].Value);
                    int _modifyFlag = Convert.IsDBNull(dgvOrders[ModifyFlag.Name, i].Value) ? 0 : Convert.ToInt32(dgvOrders[ModifyFlag.Name, i].Value);
                    int groupFlag = Convert.IsDBNull(dgvOrders[GroupFlag.Name, i].Value) ? 0 : Convert.ToInt32(dgvOrders[GroupFlag.Name, i].Value);
                    int ordertype = Convert.IsDBNull(dgvOrders[ordertypename.Name, i].Value) ? 0 : Convert.ToInt32(dgvOrders[ordertypename.Name, i].Value);
                    if (flag == (int)OrderStatus.医生新开)
                    {
                        dgvOrders.SetRowColor(i, Color.Black, true);
                    }
                    else if (flag == (int)OrderStatus.医生保存 && _modifyFlag == 0)
                    {
                        dgvOrders.SetRowColor(i, Color.Black, Color.Honeydew);
                    }
                    else if (flag == (int)OrderStatus.医生发送 && _modifyFlag == 0)
                    {
                        dgvOrders.SetRowColor(i, Color.SeaGreen, Color.White);
                    }
                    else if (flag != (int)OrderStatus.医生新开 && _modifyFlag == 1)
                    {
                        dgvOrders.SetRowColor(i, Color.Black, Color.Orange);
                    }
                    else if (flag == (int)OrderStatus.已经转抄)
                    {
                        dgvOrders.SetRowColor(i, Color.Blue, Color.White);
                    }
                    else if (flag == (int)OrderStatus.医生停嘱)
                    {
                        dgvOrders.SetRowColor(i, Color.Gray, Color.White);
                    }
                    else if (flag == (int)OrderStatus.转抄停嘱)
                    {
                        dgvOrders.SetRowColor(i, Color.Maroon, Color.WhiteSmoke);
                    }
                    else if (flag == (int)OrderStatus.执行完毕)
                    {
                        dgvOrders.SetRowColor(i, Color.Black, Color.WhiteSmoke);
                    }
                    else if (flag != (int)OrderStatus.医生新开 && _modifyFlag == 1)
                    {
                        dgvOrders.SetRowColor(i, Color.Black, Color.White);
                    }
                    if (ordertype == (int)OrderType.转科医嘱 || ordertype == (int)OrderType.死亡医嘱 || ordertype == (int)OrderType.出院医嘱)
                    {
                        dgvOrders.SetRowColor(i, Color.Red, true);
                    }
                }
            }
        }
        //设置只读
        public void SetReadOnly(ReadOnlyType readonlyType)
        {
            if (readonlyType == ReadOnlyType.全部只读)
            {
                dgvOrders.ReadOnly = true;
            }
            else
            {
                dgvOrders.ReadOnly = false;
                ShowTeminalNum.ReadOnly = true;
                OrderDocName.ReadOnly = true;
                ExecNurseName.ReadOnly = true;
                ExecDate.ReadOnly = true;
                EOrderDocName.ReadOnly = true;
                EOrderDate.ReadOnly = true;
                DosageUnit.ReadOnly = true;
                Unit.ReadOnly = true;

                ShowOrderBdate.ReadOnly = true;
                ShowChannel.ReadOnly = true;
                ShowFrency.ReadOnly = true;
                ShowFirstNum.ReadOnly = true;
                ShowTeminalNum.ReadOnly = true;

                Entrust.ReadOnly = true;
                ShowDoseNum.ReadOnly = true;
                Amount.ReadOnly = true;
                ItemName.ReadOnly = true;
                DropSpec.ReadOnly = true;
                Dosage.ReadOnly = true;
                if (readonlyType == ReadOnlyType.新开)
                {
                    ItemName.ReadOnly = false;
                    Dosage.ReadOnly = false;                                    
                }
                if (readonlyType == ReadOnlyType.皮试医嘱)
                {                    
                    Dosage.ReadOnly = false;
                    ShowFrency.ReadOnly = false;
                    Entrust.ReadOnly = false;
                }
                if (readonlyType == ReadOnlyType.皮试生成医嘱)
                {
                    Dosage.ReadOnly = false;
                    Entrust.ReadOnly = false;
                }
                if (readonlyType == ReadOnlyType.不能修改)
                {

                }
                if (readonlyType == ReadOnlyType.自由录入)
                {
                    dgvOrders.HideSelectionCardWhenCustomInput = true;
                    ItemName.ReadOnly = false;
                    Dosage.ReadOnly = false;
                    ShowChannel.ReadOnly = false;
                    ShowFrency.ReadOnly = false;
                    Entrust.ReadOnly = false;
                }
                if (readonlyType == ReadOnlyType.出院带药)
                {
                   // ItemName.ReadOnly = false;
                    ShowChannel.ReadOnly = false;
                    ShowFrency.ReadOnly = false;
                    ShowFirstNum.ReadOnly = false;
                    Entrust.ReadOnly = false;
                    DropSpec.ReadOnly = false;
                    Dosage.ReadOnly = false;
                    if (OrderStyle == OrderCategory.临时医嘱)
                    {
                        Unit.ReadOnly = false;
                        Amount.ReadOnly = false;
                    }
                }
                if (readonlyType == ReadOnlyType.中草药)
                {
                  //  Unit.ReadOnly = false;
                    ShowDoseNum.ReadOnly = false;
                    Dosage.ReadOnly = false;
                  //  Amount.ReadOnly = false;
                    ShowChannel.ReadOnly = false;
                    ShowFrency.ReadOnly = false;
                    Entrust.ReadOnly = false;
                    ItemName.ReadOnly = false;
                }
                if (readonlyType == ReadOnlyType.项目)
                {
                    if (OrderStyle == OrderCategory.临时医嘱)
                    {
                        ItemName.ReadOnly = false;
                       // Amount.ReadOnly = false;                       
                        ShowChannel.ReadOnly = false;
                        ShowFrency.ReadOnly = false;
                        Entrust.ReadOnly = false;
                        Dosage.ReadOnly = false;
                    }
                    if (OrderStyle == OrderCategory.长期医嘱)
                    {
                        ItemName.ReadOnly = false;
                        ShowChannel.ReadOnly = false;
                        ShowFrency.ReadOnly = false;
                        ShowFirstNum.ReadOnly = false;
                        Entrust.ReadOnly = false;
                        Dosage.ReadOnly = false;
                    }
                }
                if (readonlyType == ReadOnlyType.药品非中草药)
                {
                    ItemName.ReadOnly = false;
                    ShowChannel.ReadOnly = false;
                    ShowFrency.ReadOnly = false;
                    ShowFirstNum.ReadOnly = false;
                    Entrust.ReadOnly = false;
                    DropSpec.ReadOnly = false;
                    Dosage.ReadOnly = false;
                    //if (OrderStyle == OrderCategory.临时医嘱)
                    //{
                    //    Unit.ReadOnly = false;
                    //    Amount.ReadOnly = false;
                    //}
                }
                if (readonlyType == ReadOnlyType.同组增加)
                {
                    ItemName.ReadOnly = false;
                    Dosage.ReadOnly = false;
                    Entrust.ReadOnly = false;
                    //Unit.ReadOnly = false;
                    //Amount.ReadOnly = false;
                }
            }
        }
        public void SetGridCurrentCell(int rowIndex, int colIndex)
        {
            this.dgvOrders.Focus();
            if (rowIndex > -1 && this.dgvOrders.Rows.Count > 0)
            {
                this.dgvOrders.CurrentCell = this.dgvOrders[colIndex, rowIndex];
            }
        }
        public void SetGridCurrentCell(int rowIndex, string colName)
        {
            this.dgvOrders.Focus();
            if (rowIndex > -1 && this.dgvOrders.Rows.Count > 0)
            {
                this.dgvOrders.CurrentCell = this.dgvOrders[colName, rowIndex];
            }
        }
        #endregion

        #region 网格事件
        private void dgvOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentCell != null)
            {
                if (e.ColumnIndex == dgvOrders.Columns[Dosage.Name].Index)
                {
                    controller.CaculateTempOrderAmout(e.RowIndex);
                    dgvOrders.Refresh();
                }
            }
        }
        private void dgvOrders_CurrentCellChanged(object sender, EventArgs e)
        {
            //控制网格读写状态
            if (dgvOrders.CurrentCell != null)
            {
                int currentRowIndex = dgvOrders.CurrentCell.RowIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;               
                int groupid = Convert.ToInt32(dt.Rows[currentRowIndex]["GroupId"]);
                int orderStatus = Convert.ToInt32(dt.Rows[currentRowIndex]["orderStatus"]);
                int orderType= Convert.ToInt32(dt.Rows[currentRowIndex]["orderType"]);
                int itemType = Convert.ToInt32(dt.Rows[currentRowIndex]["ItemType"]);//类型
                controller.SetReadOnly(currentRowIndex);
                if (!this.dgvOrders.CurrentCell.ReadOnly
                   && this.dgvOrders.CurrentCell.ColumnIndex != this.ItemName.Index)
                {
                    this.dgvOrders.BeginEdit(true);
                }
                if (FeeShowoflinkage != null)
                {
                    FeeShowoflinkage(CurrPatListId, groupid, PresDeptId, PresDeptName, orderStatus,orderType);
                }
                if (itemType == 1 && DetailShowlinkage != null)//显示药品明细
                {
                    DataRow dr = controller.GetDrugDetail(Convert.ToInt32(dt.Rows[currentRowIndex]["ItemID"]==null?0: dt.Rows[currentRowIndex]["ItemID"]));
                    DetailShowlinkage(dr, dt.Rows[currentRowIndex]["ExecDeptName"] == null ? "" : dt.Rows[currentRowIndex]["ExecDeptName"].ToString());
                }
                else
                {
                    DetailShowlinkage(null,"");
                }
                if (OrderStyle == OrderCategory.临时医嘱)
                {
                    if (this.dgvOrders.CurrentCell.ColumnIndex == dgvOrders.Columns[Unit.Name].Index)
                    {                      
                        if (Convert.ToInt32(dt.Rows[GridRowIndex]["OrderStatus"]) < 2 && Convert.ToInt32(dt.Rows[GridRowIndex]["ModifyFlag"]) == 1 && (Convert.ToInt32(dt.Rows[GridRowIndex]["OrderType"]) == (int)OrderType.出院带药医嘱 || Convert.ToInt32(dt.Rows[GridRowIndex]["OrderType"]) == (int)OrderType.交病人医嘱))
                        {
                            controller.GetUnit(Convert.ToInt32(dt.Rows[GridRowIndex]["ItemID"]));
                        }
                    }
                }
            }
            else
            {
                FeeShowoflinkage(-1, 0, 0, "", 3,0);
                DetailShowlinkage(null,"");
            }
        }
        private void dgvOrders_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            dgvOrders.CurrentCellChanged -= dgvOrders_CurrentCellChanged;
            dgvOrders.EndEdit();
            bool result = true;
            controller.SelectCardBindData(dgvOrders.CurrentCell.RowIndex, (DataRow)SelectedValue, dgvOrders.Columns[dgvOrders.CurrentCell.ColumnIndex].Name, ref result);
            if (result == false)
            {
                stop = true;
                dgvOrders.CurrentCellChanged += new EventHandler(dgvOrders_CurrentCellChanged);
                return;
            }
            DataTable dt = (DataTable)dgvOrders.DataSource;
            int itemtype = Convert.ToInt32(dt.Rows[dgvOrders.CurrentCell.RowIndex]["ItemType"]);

            if (OrderStyle == OrderCategory.临时医嘱 && dgvOrders.Columns[dgvOrders.CurrentCell.ColumnIndex].Name == "ShowFrency")
            {
                if (itemtype == 1)
                {
                    controller.AddEmptyRow(dgvOrders.CurrentCell.RowIndex + 1, 1);
                }
                else
                {
                    controller.AddEmptyRow(dgvOrders.CurrentCell.RowIndex + 1, 0);
                }
                dgvOrders.CurrentCell = this.dgvOrders[1, dgvOrders.CurrentCell.RowIndex + 1];
                stop = true;
                dgvOrders.CurrentCellChanged += new EventHandler(dgvOrders_CurrentCellChanged);

            }
            else if (dgvOrders.Columns[dgvOrders.CurrentCell.ColumnIndex].Name == "Entrust")
            {
                int status = Convert.ToInt32(dgvOrders["Status", dgvOrders.CurrentCell.RowIndex].Value);
                if (status == -1)
                {
                    if (itemtype == 1)
                    {
                        controller.AddEmptyRow(dgvOrders.Rows.Count, 1);
                    }
                    else
                    {
                        controller.AddEmptyRow(dgvOrders.Rows.Count, 0);
                    }
                }
            //    dgvOrders.CurrentCell = this.dgvOrders[1, dgvOrders.CurrentCell.RowIndex + 1];
                stop = true;
                dgvOrders.CurrentCellChanged += new EventHandler(dgvOrders_CurrentCellChanged);
            }

            dgvOrders.Refresh();
        }
        private void dgvOrders_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            DataTable dtt = (DataTable)dgvOrders.DataSource;
            //if (Convert.ToInt32( dtt.Rows[rowIndex]["orderstatus"]) != (int)OrderStatus.医生新开)
            //{
            //    return;
            //}
            int itemid = Convert.ToInt32(dtt.Rows[rowIndex]["ItemID"]);
            if (itemid == 0)
            {
                jumpStop = true;
                return;
            }
            if (itemid == -1)
            {
                dgvOrders.EndEdit();
                jumpStop = true;
                NewOrder(true);
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;
                dt.Rows[rowindex]["OrderType"] = 4;
                dt.Rows[rowindex]["ItemType"] = 5;
                dt.Rows[rowindex]["ItemID"] = -1;
                return;
            }
            int groupFlag = Convert.ToInt32(dtt.Rows[rowIndex]["groupFlag"]);
            int itemtype = Convert.ToInt32(dtt.Rows[rowIndex]["ItemType"]);
            if (OrderStyle == OrderCategory.长期医嘱)
            {
                if (colIndex >= ShowFirstNum.Index && groupFlag == 1)
                {
                    if (itemtype == 1)//药品分组
                    {
                        controller.AddEmptyRow(rowIndex + 1, 1);
                        jumpStop = true;
                        dgvOrders.CurrentCell = this.dgvOrders[1, rowIndex + 1];
                        return;
                    }
                    else//只有药品才分组
                    {
                        jumpStop = true;
                        NewOrder(false);
                        return;
                    }
                }
                if (colIndex >= Dosage.Index && groupFlag == 0)
                {
                    if (itemtype == 1)
                    {
                        controller.AddEmptyRow(rowIndex + 1, 1);
                        jumpStop = true;
                        dgvOrders.CurrentCell = this.dgvOrders[1, rowIndex + 1];
                        return;
                    }
                    else
                    {
                        jumpStop = true;
                        NewOrder(false);
                        return;
                    }
                }
            }
            else
            {
                if (colIndex >= Amount.Index && itemtype != 1)
                {
                    jumpStop = true;
                    NewOrder(false);
                    return;
                }
                if (colIndex >= ShowDoseNum.Index && itemtype == 1 && groupFlag==1)
                {
                    controller.AddEmptyRow(rowIndex + 1, 1);
                    jumpStop = true;
                    dgvOrders.CurrentCell = this.dgvOrders[1, rowIndex + 1];
                    return;
                }
                if (colIndex >= Dosage.Index && groupFlag==0)
                {
                    if (itemtype == 1)
                    {
                        controller.AddEmptyRow(rowIndex + 1, 1);
                        jumpStop = true;
                        dgvOrders.CurrentCell = this.dgvOrders[1, rowIndex + 1];
                        return;
                    }
                    else
                    {
                        jumpStop = true;
                        NewOrder(false);
                        return;
                    }
                }
                //if (colIndex >= ShowDoseNum.Index)
                //{
                //    if (itemtype == 1)
                //    {
                //        controller.AddEmptyRow(rowIndex + 1, 1);
                //        jumpStop = true;
                //        dgvOrders.CurrentCell = this.dgvOrders[1, rowIndex + 1];
                //        return;
                //    }
                //    else
                //    {
                //        jumpStop = true;
                //        NewOrder(false);
                //        return;
                //    }
                //}                   
            }
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 新开
        /// </summary>
        /// <param name="selfInput">true 自由录入 false新开</param>
        public void NewOrder(bool selfInput)
        {
            if (!controller.CanEditOrder())
            {
                return;
            }          
            if (selfInput)
            {
                dgvOrders.HideSelectionCardWhenCustomInput = true;
            }
            else
            {
                dgvOrders.HideSelectionCardWhenCustomInput = false;
            }
            if (dgvOrders.Rows.Count == 0)
            {
                controller.AddEmptyRow(dgvOrders.Rows.Count, 0);
                dgvOrders.CurrentCell = dgvOrders[ItemName.Name, dgvOrders.Rows.Count - 1];
            }
            else
            {
                if (dgvOrders["ItemName", dgvOrders.Rows.Count - 1].Value.ToString() != "")
                {                  
                    controller.AddEmptyRow(dgvOrders.Rows.Count, 0);
                    dgvOrders.CurrentCell = dgvOrders[ItemName.Name, dgvOrders.Rows.Count - 1];
                }
                else
                {                  
                    DataTable dtcopy = (DataTable)dgvOrders.DataSource;
                    DataTable dt = dtcopy.Copy();
                    dt.Rows.RemoveAt(dgvOrders.Rows.Count - 1);
                    dgvOrders.DataSource = dt;
                    dgvOrders.Refresh();            
                    controller.AddEmptyRow(dgvOrders.Rows.Count, 0);
                    dgvOrders.CurrentCell = dgvOrders[ItemName.Name, dgvOrders.Rows.Count - 1];
                }
            }           
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshOrder()
        {
            List<OrderRecord> notSaveRecores = GetNotSaveOrders();
            if (notSaveRecores.Count > 0)
            {
                string strName = "";
                foreach (OrderRecord order in notSaveRecores)
                {
                    strName += order.ItemName + "\n";
                }
                if (MessageBox.Show("还有下列医嘱未保存:\n" + strName + "是否继续刷新？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.BindOrderData();
                }
            }
            else
            {
                controller.BindOrderData();
            }
        }
        public List<OrderRecord> GetNotSaveOrders()
        {
            DataTable dt = (DataTable)dgvOrders.DataSource;
            List<OrderRecord> listRecords = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<OrderRecord>(dt);
            List<OrderRecord> notSaveRecores = listRecords.Where(p => p.ModifyFlag == 1 && !string.IsNullOrEmpty(p.ItemName)).ToList();
            return notSaveRecores;
        }
        /// <summary>
        /// 医嘱保存
        /// </summary>
        public bool SaveOrder()
        {
            if (!controller.CanEditOrder())
            {
                return false;
            }
            dgvOrders.EndEdit();
            List<OrderRecord> notSaveRecores = GetNotSaveOrders();
            if (notSaveRecores.Count > 0)
            {
               return  controller.SaveRecores(notSaveRecores);
            }
            else
            {
                controller.BindOrderData();
                return true;
            }
        }
        /// <summary>
        /// 医嘱发送
        /// </summary>
        public void SendOrder()
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            dgvOrders.EndEdit();
            List<OrderRecord> notSaveRecores = GetNotSaveOrders();
            if (notSaveRecores.Count == 0)
            {
                controller.SendOrderRecord();
                controller.BindOrderData();
            }
            else
            {
                string strName = "";
                foreach (OrderRecord order in notSaveRecores)
                {
                    strName += order.ItemName + "\n";
                }
                MessageBox.Show("还有下列医嘱未保存:\n" + strName + ",请先保存医嘱");
            }
        }
        /// <summary>
        /// 医嘱停嘱
        /// </summary>
        public void StopOrder()
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;
                int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                if (status != 2)
                {
                    MessageBox.Show("只有已经转抄的长嘱才能停嘱");
                    return;
                }
                DateTime bdate = Convert.ToDateTime(dt.Rows[rowindex]["OrderBdate"]);
                int firstNums = Convert.ToInt32(dt.Rows[rowindex]["FirstNum"]);
                //根据频次得到默认执行次数和最大执行次数
                int defaultNums = 0;
                //停嘱日期和开嘱日期相同，默认末次取首次
                if (bdate.Date == DateTime.Now.Date)
                {
                    defaultNums = firstNums;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[rowindex]["FrenquencyID"]) > 0)
                    {
                        defaultNums = controller.GetTeminalExecCount(Convert.ToInt32(dt.Rows[rowindex]["FrenquencyID"]), DateTime.Now);
                    }
                }            
                FrmStopOrder frmStop = new FrmStopOrder(DateTime.Now, defaultNums, 5, firstNums);
                frmStop.ShowDialog();
                if (!frmStop.isOk)
                {
                    return;
                }
                int begnum = 0;
                int endnum = 0;
                FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                List<OrderRecord> list = new List<Entity.OrderRecord>();
                for (int index = endnum; index >= begnum; index--)
                {
                    dt.Rows[index]["EOrderDoc"] = PresDoctorId;                           
                    dt.Rows[index]["OrderStatus"] = OrderStatus.医生停嘱;
                    dt.Rows[index]["TeminalNum"] = frmStop.stopNum;
                    if (index == begnum)
                    {
                        dt.Rows[index]["ShowTeminalNum"] = frmStop.stopNum;                       
                        dt.Rows[index]["EOrderDocName"] = PresDoctorName;
                        dt.Rows[index]["EOrderDate"] = frmStop.stopDate;
                    }                   
                    OrderRecord stopRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                    stopRecord.EOrderDate = frmStop.stopDate;
                    list.Add(stopRecord);
                }
                if (controller.StopOrderRecord(list))
                {
                    this.SetGridColor();
                }
            }
        }
        /// <summary>
        /// 出院带药
        /// </summary>
        private void OutDrugOrder()
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;               
                if (!checkOrders(rowindex,dt,true))
                {
                    return;
                }
                int begnum = 0;
                int endnum = 0;
                FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                List<OrderRecord> list = new List<Entity.OrderRecord>();
                for (int index = endnum; index >= begnum; index--)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[index]["ItemName"].ToString()))
                    {
                        dt.Rows[index]["OrderType"] = (int)OrderType.出院带药医嘱;
                        dt.Rows[index]["ItemName"] = dt.Rows[index]["ItemName"] + "【出院带药】";
                        OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                        list.Add(record);
                    }
                    //dt.Rows[index]["ModifyFlag"] = 1;
                }
                controller.SaveRecores(list);    
                this.SetGridColor();
                //交病人后定位到单前行，可以修改数量和单位
                for (int index = endnum; index >= begnum; index--)
                {
                    controller.SetOrderModifyStatus(index);
                }
                dgvOrders.CurrentCell = dgvOrders[Amount.Index, rowindex];
            }
        }
        /// <summary>
        /// 交病人
        /// </summary>
        private void GivePatDrugOrder()
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;               
                if (!checkOrders(rowindex, dt,true))
                {
                    return;
                }
                int begnum = 0;
                int endnum = 0;
                FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                List<OrderRecord> list = new List<Entity.OrderRecord>();                   
                for (int index = endnum; index >= begnum; index--)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[index]["ItemName"].ToString()))
                    {
                        dt.Rows[index]["OrderType"] = (int)OrderType.交病人医嘱;                    
                        dt.Rows[index]["ItemName"] = dt.Rows[index]["ItemName"] + "【交病人】";
                        //dt.Rows[index]["ModifyFlag"] = 1;
                        OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                        list.Add(record);
                    }                    
                }
                controller.SaveRecores(list);
                this.SetGridColor();
                //交病人后定位到单前行，可以修改数量和单位
                for (int index = endnum; index >= begnum; index--)
                {
                    controller.SetOrderModifyStatus(index);
                }
                dgvOrders.CurrentCell = dgvOrders[Amount.Index, rowindex];
            }
        }
        /// <summary>
        /// 自备
        /// </summary>
        private void SelfDrugOrder()
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;
                if (!checkOrders(rowindex, dt,false))
                {
                    return;
                }
                dt.Rows[rowindex]["OrderType"] = (int)OrderType.自备医嘱;
                dt.Rows[rowindex]["ItemName"] = dt.Rows[rowindex]["ItemName"] + "【自备】";
                //     dt.Rows[rowindex]["ModifyFlag"] = 1;
                List<OrderRecord> list = new List<Entity.OrderRecord>();
                OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                list.Add(record);
                controller.SaveRecores(list);
                this.SetGridColor();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowindex"></param>
        /// <param name="dt"></param>
        /// <param name="isTemp">是否只适用临时医嘱</param>
        /// <returns></returns>
        private bool checkOrders(int rowindex,DataTable dt,bool isTemp)
        {
            string itemName = dt.Rows[rowindex]["ItemName"].ToString().Trim();
            if (itemName == "")
            {
                return false;
            }
            int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
            int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
            if (status ==-1)
            {
                MessageBox.Show("医嘱保存后才能标记");
                return false;
            }
            int itemtype = Convert.ToInt32(dt.Rows[rowindex]["ItemType"]);
            int orderType = Convert.ToInt32(dt.Rows[rowindex]["orderType"]);           
            if (isTemp && OrderStyle == OrderCategory.长期医嘱)
            {
                MessageBox.Show("长期医嘱不能标记");
                return false;
            }
            if (status > 1)
            {
                MessageBox.Show("医嘱已经转抄，不能标记");
                return false;
            }
            if (itemtype != 1)
            {
                MessageBox.Show("只有药品才能标记");
                return false;
            }
            if (Convert.ToInt32(dt.Rows[rowindex]["AstOrderID"]) > 0 || dt.Rows[rowindex]["Memo"].ToString().Trim() == "PsDrug")
            {
                MessageBox.Show("皮试关联医嘱不能标记");
                return false;
            }
            if (orderType != 0)
            {
                if (orderType == (int)OrderType.交病人医嘱)
                {
                    MessageBox.Show("已标为交病人医嘱");
                    return false;
                }
                if (orderType == (int)OrderType.出院带药医嘱)
                {
                    MessageBox.Show("已标为出院带药医嘱");
                    return false;
                }
                if (orderType == (int)OrderType.自备医嘱)
                {
                    MessageBox.Show("已标为自备医嘱");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 转科医嘱
        /// </summary>
        /// <param name="curNO"></param>
        /// <param name="patName"></param>
        /// <param name="patSex"></param>
        /// <param name="bedNo"></param>
        /// <param name="diagnose"></param>
        /// <returns></returns>
        public bool TransferDept(string curNO, string patName, string patSex, string bedNo, string diagnose)
        {
            if (!controller.CanEditOrder())
            {
                return false;
            }
            if (controller.GetNotExsistOrders())
            {
                FrmTransDept frmTrans = new FrmTransDept(CurrPatListId, curNO, patName, bedNo, diagnose, PresDeptId);               
                frmTrans.dtDept = controller.getIpDepts();
                frmTrans.ShowDialog();
                if (frmTrans.isOk)
                {
                    DateTime transedate = frmTrans.transDeptDate;
                    int transDeptid = frmTrans.transDeptId;
                    string transDeptName = frmTrans.transDeptName;
                    DataTable dtNotStopOrders = new DataTable();
                    if (StopAllOrders(transedate, OrderType.转科医嘱, out dtNotStopOrders))
                    {
                       return controller.SpeciOrder(dtNotStopOrders, OrderType.转科医嘱, transedate, transDeptid, transDeptName);
                    }
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 出院医嘱
        /// </summary>
        /// <param name="curNO"></param>
        /// <param name="patName"></param>
        /// <param name="patSex"></param>
        /// <param name="bedNo"></param>
        /// <param name="diagnose"></param>
        /// <returns></returns>
        public bool OutHospital(string curNO, string patName, string patSex, string bedNo, string diagnose)
        {
            if (!controller.CanEditOrder())
            {
                return false;
            }
            if (controller.GetNotExsistOrders())
            {
                FrmOutHospital frmTrans = new FrmOutHospital(CurrPatListId, curNO, patName, bedNo, diagnose);
                frmTrans._dtDisease = controller.getDisease();
                frmTrans._dtOutSituation = controller.getOutsituation();
                frmTrans.ShowDialog();
                if (frmTrans.isOk)
                {
                    DateTime outdate = frmTrans.outDate;
                    string outDiseaseName = frmTrans.outDiseaseName;
                    string outDiseaseCode = frmTrans.outDiseaseCode;
                    string outSituation = frmTrans.outSituationCode;                   
                    DataTable dtNotStopOrders = new DataTable();
                    if (StopAllOrders(outdate, OrderType.出院医嘱, out dtNotStopOrders))
                    {
                        return controller.OutHospOrder(dtNotStopOrders, OrderType.出院医嘱, outdate, outDiseaseName,outDiseaseCode, outSituation);
                    }
                }
                return false;
            }
            return false;
        }
        public bool DeathOrder(string curNO, string patName, string patSex, string bedNo, string diagnose,DateTime enterDate)
        {
            if (!controller.CanEditOrder())
            {
                return false;
            }
            if (controller.GetNotExsistOrders())
            {
                FrmDeathOrder frmTrans = new FrmDeathOrder(CurrPatListId, curNO, patName, bedNo, diagnose, enterDate);
                frmTrans._dtDisease = controller.getDisease();               
                frmTrans.ShowDialog();
                if (frmTrans.isOk)
                {
                    DateTime outdate = frmTrans.outDate;
                    string outDiseaseName = frmTrans.outDiseaseName;
                    string outDiseaseCode = frmTrans.outDiseaseCode;
                    string outSituation = frmTrans.outSituationCode;
                    DataTable dtNotStopOrders = new DataTable();
                    if (StopAllOrders(outdate, OrderType.死亡医嘱, out dtNotStopOrders))
                    {
                        return controller.OutHospOrder(dtNotStopOrders, OrderType.死亡医嘱, outdate, outDiseaseName, outDiseaseCode, outSituation);
                    }
                }
                return false;
            }
            return false;
        }

        private bool StopAllOrders(DateTime stopDate, OrderType orderType, out DataTable dtNotStopOrders)
        {
            dtNotStopOrders = controller.GetNotStopLongOrders();
            if (dtNotStopOrders.Rows.Count > 0)
            {
                for (int i = 0; i < dtNotStopOrders.Rows.Count; i++)
                {
                    DateTime bdate = Convert.ToDateTime(dtNotStopOrders.Rows[i]["OrderBdate"]);
                    int firstNums = Convert.ToInt32(dtNotStopOrders.Rows[i]["FirstNum"]);
                    if (bdate.Date == stopDate.Date)
                    {
                        dtNotStopOrders.Rows[i]["TeminalNum"] = firstNums;
                    }
                    else
                    {
                        dtNotStopOrders.Rows[i]["TeminalNum"] = controller.GetTeminalExecCount(Convert.ToInt32(dtNotStopOrders.Rows[i]["FrenquencyID"]), stopDate);
                    }
                }
                FrmUpdateTerminalNum frmUpdateNum = new FrmUpdateTerminalNum(dtNotStopOrders);
                frmUpdateNum.ShowDialog();
                if (frmUpdateNum.isOk)
                {
                    dtNotStopOrders = frmUpdateNum.dtUpdateNums;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion 

        #region 右键事件
        private void 修改医嘱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders.CurrentCell != null)
            {
                int rowIndex = dgvOrders.CurrentCell.RowIndex;
                int status = Convert.ToInt32(dgvOrders["Status", rowIndex].Value);
                if (status == -1)
                {
                    return;
                }
                DataTable dt = (DataTable)dgvOrders.DataSource;
                if (Convert.ToInt32(dt.Rows[rowIndex]["ItemType"]) == 4)
                {
                    //调用医技申请界面修改
                    MessageBox.Show("该医嘱是医嘱申请生成医嘱，不能修改，请到医技申请界面选择修改");
                    return;
                }
                else
                {
                    if (status == 0 || status == 1)
                    {
                        int ordertype= Convert.ToInt32(dgvOrders[ordertypename.Index, rowIndex].Value);
                        if (ordertype == (int)OrderType.出院医嘱 || ordertype == (int)OrderType.转科医嘱 || ordertype == (int)OrderType.死亡医嘱)
                        {
                            MessageBox.Show("该医嘱不能修改");
                            return;
                        }
                        dgvOrders.HideSelectionCardWhenCustomInput = false;
                        int beNum = rowIndex;
                        int endNum = rowIndex;
                        FindBeginEnd(rowIndex, dt, ref beNum, ref endNum);
                        for (int i = beNum; i <= endNum; i++)
                        {
                            controller.SetOrderModifyStatus(i);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该医嘱已经转抄或执行，不能修改");
                    }
                }
            }
        }
        private void 插入一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders.CurrentCell != null && dgvOrders.Rows.Count>0)
            {               
                int rowIndex = dgvOrders.CurrentCell.RowIndex;                
                int status = Convert.ToInt32(dgvOrders["Status", rowIndex].Value);
                if (status <= 1)
                {
                    dgvOrders.HideSelectionCardWhenCustomInput = false;
                    DataTable dt = (DataTable)dgvOrders.DataSource;
                    if (dt.Rows[rowIndex]["ItemName"].ToString().Trim() == "")
                    {
                        return;
                    }
                    if (Convert.ToInt32(dt.Rows[rowIndex]["ItemType"]) == 1)
                    {
                        if (Convert.ToInt32(dt.Rows[rowIndex]["AstOrderID"]) > 0 || dt.Rows[rowIndex]["Memo"].ToString().Trim() == "PsDrug")
                        {
                            MessageBox.Show("生成的皮试关联医嘱不能插入一行");
                            return;
                        }
                        controller.AddEmptyRow(rowIndex + 1, 1);
                        dgvOrders.CurrentCell = dgvOrders[1, rowIndex + 1];
                    }
                    else
                    {
                        if (dgvOrders["ItemName", rowIndex].Value.ToString() != "")
                        {
                            controller.AddEmptyRow(rowIndex + 1, 0);
                            dgvOrders.CurrentCell = dgvOrders[ItemName.Name, rowIndex + 1];
                        }
                        else
                        {
                            dgvOrders.CurrentCell = dgvOrders[ItemName.Name, rowIndex];
                        }
                    }
                }
            }
        }     
        public void RefreshShowCardFromDataBase()
        {
            List<OrderRecord> notSaveRecores = GetNotSaveOrders();
            if (notSaveRecores.Count > 0)
            {
                string strName = "";
                foreach (OrderRecord order in notSaveRecores)
                {
                    strName += order.ItemName + "\n";
                }
                if (MessageBox.Show("还有下列医嘱未保存:\n" + strName + "是否继续刷新？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.BindOrderData();
                    controller.RefreshOrderShowCard(_drugStoreDeptID, true);
                }
            }
            else
            {              
                controller.RefreshOrderShowCard(_drugStoreDeptID, true);
            }
            //刷新嘱托
            controller.GetRefreshEntrust();
        }
        private void 删除一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //如果特殊医嘱，还需要恢复停嘱
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int delindex = rowindex + 1;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dtcopy = (DataTable)dgvOrders.DataSource;
                DataTable dt = dtcopy.Copy();
                int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                int orderType = Convert.ToInt32(dt.Rows[rowindex]["orderType"]);
                if (status > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能删除");
                    return;
                }
                if (Convert.ToInt32(dt.Rows[rowindex]["ItemType"]) == 4)
                {
                    //调用医技申请界面修改
                    MessageBox.Show("该医嘱是医嘱申请生成医嘱，不能删除，请到医技申请界面选择修改");
                    return;
                }
                if (orderType == (int)OrderType.转科医嘱 || orderType == (int)OrderType.出院医嘱 || orderType == (int)OrderType.死亡医嘱)
                {
                    if (MessageBox.Show("该医嘱属于转科/出院/死亡医嘱，您确定删除吗", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }
                    List<OrderRecord> listDel = new List<OrderRecord>();
                    OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                    delRecord.DeleteFlag = 1;
                    listDel.Add(delRecord);
                    if (controller.DeleteRecored(listDel))
                    {
                        if (Freshlinkage != null)
                        {
                            Freshlinkage();
                        }
                    }                   
                    return;
                }
                if (Convert.ToInt32(dt.Rows[rowindex]["AstOrderID"]) > 0 || dt.Rows[rowindex]["Memo"].ToString().Trim() == "PsDrug")
                {
                    MessageBox.Show("生成的皮试医嘱不能一行删除");
                    return;
                }
                bool astOrder = false;
                if (Convert.ToInt32(dt.Rows[rowindex]["AstFlag"]) == 0 && Convert.ToInt32(dt.Rows[rowindex]["AstOrderID"])==0)
                {
                    if (MessageBox.Show("该医嘱产生了皮试医嘱，删除时会把生成皮试医嘱删除，您确定要删除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        astOrder = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("确定要删除第" + delindex + "行医嘱吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                }
                List<OrderRecord> list = new List<Entity.OrderRecord>();
                dgvOrders.EndEdit();
                dgvOrders.CurrentCellChanged -= dgvOrders_CurrentCellChanged;              
                if (groupFlag == 0)
                {
                    if (status != -1)
                    {                   
                        OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                        delRecord.DeleteFlag = 1;
                        if (delRecord.OrderID == 0)
                        {
                            dt.Rows.RemoveAt(rowindex);                           
                        }
                        else
                        {
                          //  List<OrderRecord> list = new List<Entity.OrderRecord>();
                            list.Add(delRecord);
                            if (controller.DeleteRecored(list))
                            {
                                 dt.Rows.RemoveAt(rowindex);                                
                            }                         
                        }
                    }
                    else
                    {
                        dt.Rows.RemoveAt(rowindex);
                       
                    }

                }
                else
                {
                    int begnum = 0;
                    int endnum = 0;
                    FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                    if (begnum == endnum)
                    {
                        if (status != -1)
                        {                        
                            OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                            delRecord.DeleteFlag = 1;
                            if (delRecord.OrderID == 0)
                            {
                                dt.Rows.RemoveAt(rowindex);                            
                            }
                            else
                            {                           
                                list.Add(delRecord);
                                if (controller.DeleteRecored(list))
                                {
                                     dt.Rows.RemoveAt(rowindex);                                  
                                }
                               
                            }
                        }
                        else
                        {
                             dt.Rows.RemoveAt(rowindex);                    
                        }

                    }
                    else
                    {
                        if (dt.Rows[rowindex + 1]["ItemName"].ToString().Trim() != "")
                        {
                            dt.Rows[rowindex + 1]["ShowDoseNum"] = dt.Rows[rowindex]["ShowDoseNum"];
                            dt.Rows[rowindex + 1]["ShowChannel"] = dt.Rows[rowindex]["ShowChannel"];
                            dt.Rows[rowindex + 1]["ShowFrency"] = dt.Rows[rowindex]["ShowFrency"];
                            dt.Rows[rowindex + 1]["ShowFirstNum"] = dt.Rows[rowindex]["ShowFirstNum"];
                        }
                        dt.Rows[rowindex + 1]["ShowOrderBdate"] = dt.Rows[rowindex]["ShowOrderBdate"];                       
                        dt.Rows[rowindex + 1]["GroupFlag"] = 1;
                        if (status != -1)
                        {                          
                            OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                            delRecord.DeleteFlag = 1;
                            if (delRecord.OrderID == 0)
                            {
                                 dt.Rows.RemoveAt(rowindex);                               
                            }
                            else
                            {                          
                                list.Add(delRecord);
                                if (controller.DeleteRecored(list))
                                {
                                    dt.Rows.RemoveAt(rowindex);
                                 
                                }
                              
                            }
                        }
                        else
                        {
                             dt.Rows.RemoveAt(rowindex);                          
                        }
                    }
                }
                try
                {
                    FeeShowoflinkage(-1, 0, 0, "", 3,0);
                    if (OrderStyle == OrderCategory.长期医嘱)
                    {
                        if (astOrder)
                        {
                            SaveAstoflinkage(list);
                        }
                        if (rowindex > 0)
                        {
                            dgvOrders.CurrentCell = dgvOrders["ItemName", rowindex - 1];
                        }
                        else
                        {
                            dgvOrders.CurrentCell = null;
                        }
                    }
                    else
                    {
                        if (astOrder)
                        {
                            int astGroupID = 0;
                            for (int i = dt.Rows.Count - 1; i >= 0; i--)
                            {
                                if (Convert.ToInt32(dt.Rows[i]["AstOrderID"]) == list[0].OrderID)
                                {
                                    astGroupID = Convert.ToInt32(dt.Rows[i]["GroupID"]);
                                    break;
                                }
                            }
                            if (astGroupID > 0)
                            {
                                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                                {
                                    if (Convert.ToInt32(dt.Rows[i]["GroupID"]) == astGroupID && Convert.ToInt32(dt.Rows[i]["Status"])<=1)
                                    {
                                        dt.Rows.RemoveAt(i);
                                    }
                                }

                            }
                        }
                    }
                    dgvOrders.DataSource = dt;
                    dgvOrders.CurrentCell = null;
                    dgvOrders.Refresh();
                    dgvOrders.CurrentCellChanged += dgvOrders_CurrentCellChanged;                   
                    SetGridColor();                  
                }
                catch
                {
                    dgvOrders.CurrentCellChanged += dgvOrders_CurrentCellChanged;
                    SetGridColor();
                }
            }
        }
        private void 删除一组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!controller.CanEditOrder())
            //{
            //    return;
            //}
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int delindex = rowindex + 1;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dtCopy = (DataTable)dgvOrders.DataSource;
                DataTable dt = dtCopy.Copy();
                int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                int orderType =Convert.ToInt32(dt.Rows[rowindex]["orderType"]);
                if (status > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能删除");
                    return;
                }
                if (Convert.ToInt32(dt.Rows[rowindex]["ItemType"]) == 4)
                {
                    //调用医技申请界面修改
                    MessageBox.Show("该医嘱是医嘱申请生成医嘱，不能删除，请到医技申请界面选择修改");
                    return;
                }
                if (orderType == (int)OrderType.转科医嘱 || orderType == (int)OrderType.出院医嘱 || orderType == (int)OrderType.死亡医嘱)
                {
                    if (MessageBox.Show("该医嘱属于转科/出院/死亡医嘱，您确定删除吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }
                    List<OrderRecord> listDel = new List<OrderRecord>();
                    OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                    delRecord.DeleteFlag = 1;
                    listDel.Add(delRecord);
                    if (controller.DeleteRecored(listDel))
                    {
                        if (Freshlinkage != null)
                        {
                            Freshlinkage();
                        }
                    }
                    return;
                }
                if (MessageBox.Show("确定要删除第" + delindex + "行所在一组医嘱吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
                dgvOrders.CurrentCellChanged -= dgvOrders_CurrentCellChanged;                
                dgvOrders.EndEdit();
                int begnum = 0;
                int endnum = 0;
                FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                List<OrderRecord> list = new List<Entity.OrderRecord>();
                bool astOrder = false;
                if (Convert.ToInt32(dt.Rows[begnum]["AstOrderID"]) > 0)
                {
                    if (MessageBox.Show("该组医嘱是皮试关联产生的医嘱，删除后皮试医嘱会改为免试，确定要删除第" + delindex + "行所在一组医嘱吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                    else
                    {
                        astOrder = true;
                    }
                }                
                for (int index = endnum; index >= begnum; index--)
                {
                    OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                    if (delRecord.AstFlag == 0)
                    {
                        if (Convert.ToInt32(dt.Rows[index]["AstFlag"]) == 0 && Convert.ToInt32(dt.Rows[rowindex]["AstOrderID"])==0)
                        {
                            if (MessageBox.Show("" + delRecord.ItemName + "产生了皮试关联医嘱，删除时会把生成皮试医嘱删除，您确定要删除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                            {
                                return;
                            }
                        }
                    }
                }
                for (int index = endnum; index >= begnum; index--)
                {
                    if (status != -1)
                    {
                        OrderRecord delRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                        delRecord.DeleteFlag = 1;
                        if (delRecord.OrderID==0)
                        {
                             dt.Rows.RemoveAt(rowindex);                         
                        }
                        else
                        {
                            list.Add(delRecord);
                        }
                    }
                    else
                    {
                        dt.Rows.RemoveAt(index);                       
                    }
                }
                if (status != -1)
                {
                    if (controller.DeleteRecored(list))
                    {
                        for (int index = endnum; index >= begnum; index--)
                        {
                             dt.Rows.RemoveAt(index);                           
                        }
                    }
                    if (OrderStyle == OrderCategory.长期医嘱)
                    {
                        if (astOrder)
                        {
                            SaveAstoflinkage(list);
                        }                       
                    }
                    else
                    {
                        int astGroupID = 0;
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (Convert.ToInt32(dt.Rows[i]["AstOrderID"]) == list[0].OrderID)
                            {
                                astGroupID = Convert.ToInt32(dt.Rows[i]["GroupID"]);
                                break;
                            }
                        }
                        if (astGroupID > 0)
                        {
                            for (int i = dt.Rows.Count - 1; i >= 0; i--)
                            {
                                if (Convert.ToInt32(dt.Rows[i]["GroupID"]) == astGroupID)
                                {
                                    dt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                  
                }
                try
                {
                    FeeShowoflinkage(-1, 0, 0, "", 3,0);
                    dgvOrders.DataSource = dt;
                    if (dgvOrders.Rows.Count > 0)
                    {
                        dgvOrders.CurrentCell = dgvOrders["ItemName", dgvOrders.Rows.Count - 1];
                    }
                    else
                    {
                        dgvOrders.CurrentCell = dgvOrders["ItemName", 0];
                    }
                    dgvOrders.CurrentCell = null;
                    dgvOrders.Refresh();
                    dgvOrders.CurrentCellChanged += dgvOrders_CurrentCellChanged;
                    SetGridColor();
                }
                catch
                { }
            }
        }
     
        private void 自由录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders == null || !controller.CanEditOrder())
            {
                dgvOrders.HideSelectionCardWhenCustomInput = false;
                return;
            }
            dgvOrders.CurrentCellChanged -= dgvOrders_CurrentCellChanged;
            NewOrder(true);           
            int rowindex = dgvOrders.CurrentCell.RowIndex;
            int colindex = dgvOrders.CurrentCell.ColumnIndex;
            DataTable dt = (DataTable)dgvOrders.DataSource;
            dt.Rows[rowindex]["OrderType"] = 4;
            dt.Rows[rowindex]["ItemType"] = 5;
            dt.Rows[rowindex]["ItemID"] = -1;
            dgvOrders.CurrentCellChanged += dgvOrders_CurrentCellChanged;
        }
        private void 取消停嘱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrderStyle == OrderCategory.长期医嘱)
            {
                if (!controller.CanEditOrder())
                {
                    return;
                }
                if (dgvOrders != null && dgvOrders.CurrentCell != null)
                {
                    int rowindex = dgvOrders.CurrentCell.RowIndex;
                    int colindex = dgvOrders.CurrentCell.ColumnIndex;
                    DataTable dt = (DataTable)dgvOrders.DataSource;
                    int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                    int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                    if (status != 3)
                    {
                        MessageBox.Show("只有已经停嘱的长嘱才能取消停嘱");
                        return;
                    }                   
                    int begnum = 0;
                    int endnum = 0;
                    FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                    List<OrderRecord> list = new List<Entity.OrderRecord>();
                    for (int index = endnum; index >= begnum; index--)
                    {
                        dt.Rows[index]["EOrderDate"] = DBNull.Value;
                        dt.Rows[index]["EOrderDoc"] = DBNull.Value;
                        dt.Rows[index]["EOrderDocName"] = DBNull.Value;
                        dt.Rows[index]["OrderStatus"] = OrderStatus.已经转抄;
                        dt.Rows[index]["TeminalNum"] = DBNull.Value;
                        if (index == begnum)
                        {
                            dt.Rows[index]["ShowTeminalNum"] = DBNull.Value;
                        }
                        OrderRecord stopRecord = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                        list.Add(stopRecord);
                    }
                    if (controller.CancelStopOrderRecord(list))
                    {
                        this.SetGridColor();
                    }
                }
            }
        }
        private void TsmSelfOrder_Click(object sender, EventArgs e)
        {
            //if (OrderStyle == OrderCategory.临时医嘱)
            //{
                if (!controller.CanEditOrder())
                {
                    return;
                }
                if (dgvOrders != null && dgvOrders.CurrentCell != null)
                {
                    int rowindex = dgvOrders.CurrentCell.RowIndex;
                    int colindex = dgvOrders.CurrentCell.ColumnIndex;
                    DataTable dt = (DataTable)dgvOrders.DataSource;
                    int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                    if (TsmSelfOrder.Text == "自备")
                    {
                        SelfDrugOrder();
                        return;
                    }
                    int _orderType = Convert.ToInt32(dt.Rows[rowindex]["orderType"]);
                    if (_orderType != (int)OrderType.自备医嘱)
                    {
                        return;
                    }
                    int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                    if (status >1)
                    {
                        MessageBox.Show("医嘱已经转抄，不能取消");
                        return;
                    }
                    dt.Rows[rowindex]["orderType"] = 0;
                    int sindex = dt.Rows[rowindex]["ItemName"].ToString().IndexOf('【');
                    if (sindex > 0)
                    {
                        dt.Rows[rowindex]["ItemName"] = dt.Rows[rowindex]["ItemName"].ToString().Substring(0,sindex -1);
                        List<OrderRecord> list = new List<Entity.OrderRecord>();
                        OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, rowindex);
                        list.Add(record);
                        controller.SaveRecores(list);
                    }                
                    this.SetGridColor();                 
                //}
            }
        }
        private void TsmOutOrder_Click(object sender, EventArgs e)
        {
            if (OrderStyle == OrderCategory.临时医嘱)
            {
                if (!controller.CanEditOrder())
                {
                    return;
                }
                if (dgvOrders != null && dgvOrders.CurrentCell != null)
                {
                    int rowindex = dgvOrders.CurrentCell.RowIndex;
                    int colindex = dgvOrders.CurrentCell.ColumnIndex;
                    DataTable dt = (DataTable)dgvOrders.DataSource;
                    int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                    if (TsmOutOrder.Text == "出院带药")
                    {
                        OutDrugOrder();
                        return;
                    }
                    int _orderType = Convert.ToInt32(dt.Rows[rowindex]["orderType"]);
                    if (_orderType != (int)OrderType.出院带药医嘱)
                    {
                        return;
                    }
                    int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                    if (status > 1)
                    {
                        MessageBox.Show("医嘱已经转抄，不能取消");
                        return;
                    }
                    int begnum = 0;
                    int endnum = 0;
                    FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                    List<OrderRecord> list = new List<Entity.OrderRecord>();
                    for (int index = endnum; index >= begnum; index--)
                    {
                        dt.Rows[index]["orderType"] = 0;
                        //   dt.Rows[index]["ModifyFlag"] =1;
                        int sindex = dt.Rows[index]["ItemName"].ToString().IndexOf('【');
                        if (sindex > 0)
                        {
                            dt.Rows[index]["ItemName"] = dt.Rows[index]["ItemName"].ToString().Substring(0, sindex - 1);
                        }
                        OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                        list.Add(record);
                    }
                    controller.SaveRecores(list);
                    this.SetGridColor();
                    //交病人后定位到单前行，可以修改数量和单位
                    for (int index = endnum; index >= begnum; index--)
                    {
                        dt.Rows[index]["ModifyFlag"] = 1;
                    }
                    dgvOrders.CurrentCell = dgvOrders[Amount.Index, rowindex];
                }
            }
        }
        private void TsmGivePat_Click(object sender, EventArgs e)
        {
            if (OrderStyle == OrderCategory.临时医嘱)
            {
                if (!controller.CanEditOrder())
                {
                    return;
                }
                if (dgvOrders != null && dgvOrders.CurrentCell != null)
                {
                    int rowindex = dgvOrders.CurrentCell.RowIndex;
                    int colindex = dgvOrders.CurrentCell.ColumnIndex;
                    DataTable dt = (DataTable)dgvOrders.DataSource;
                    int groupFlag = Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]);
                    if (TsmGivePat.Text == "交病人")
                    {
                        GivePatDrugOrder();
                        return;
                    }
                    int _orderType = Convert.ToInt32(dt.Rows[rowindex]["orderType"]);
                    if (_orderType != (int)OrderType.交病人医嘱)
                    {
                        return;
                    }
                    int status = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                    if (status > 1)
                    {
                        MessageBox.Show("医嘱已经转抄，不能取消");
                        return;
                    }
                    int begnum = 0;
                    int endnum = 0;
                    FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                    List<OrderRecord> list = new List<Entity.OrderRecord>();
                    for (int index = endnum; index >= begnum; index--)
                    {
                        dt.Rows[index]["orderType"] = 0;
                      //  dt.Rows[index]["ModifyFlag"] = 1;
                        int sindex = dt.Rows[index]["ItemName"].ToString().IndexOf('【');
                        if (sindex > 0)
                        {
                            dt.Rows[index]["ItemName"] = dt.Rows[index]["ItemName"].ToString().Substring(0, sindex - 1);
                        }
                        OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                        list.Add(record);
                    }
                    controller.SaveRecores(list);
                    this.SetGridColor();
                    
                }
            }
        }
        private void TsmChange()
        {
            //if (!controller.CanEditOrder())
            //{
            //    return;
            //}
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;
                int orderStatus = Convert.ToInt32(dt.Rows[rowindex]["orderStatus"]);
                if (orderStatus==-1 || orderStatus > (int)OrderStatus.医生发送)
                {
                    TsmSelfOrder.Enabled = false;
                    TsmOutOrder.Enabled = false;
                    TsmGivePat.Enabled = false;
                    return;
                }
                int itemType = Convert.ToInt32(dt.Rows[rowindex]["itemType"]==DBNull.Value?-1: dt.Rows[rowindex]["itemType"]);
                if (itemType != 1)
                {
                    TsmSelfOrder.Enabled = false;
                    TsmOutOrder.Enabled = false;
                    TsmGivePat.Enabled = false;
                    return;
                }               
                int _orderType = Convert.ToInt32(dt.Rows[rowindex]["orderType"]);
                if (_orderType == 0)
                {
                    TsmSelfOrder.Text = "自备";
                    TsmOutOrder.Text = "出院带药";
                    TsmGivePat.Text = "交病人";
                    TsmSelfOrder.Enabled = true;
                    TsmOutOrder.Enabled = true;
                    TsmGivePat.Enabled = true;
                    return;
                }
                if (_orderType == (int)OrderType.自备医嘱)
                {
                    TsmSelfOrder.Text = "取消自备";
                    TsmSelfOrder.Enabled = true;
                    TsmOutOrder.Enabled = false;
                    TsmGivePat.Enabled = false;
                    return;
                }
                if (_orderType == (int)OrderType.出院带药医嘱)
                {
                    TsmOutOrder.Text = "取消出院带药";
                    TsmSelfOrder.Enabled = false;
                    TsmOutOrder.Enabled = true;
                    TsmGivePat.Enabled = false;
                    return;
                }
                if (_orderType == (int)OrderType.交病人医嘱)
                {
                    TsmGivePat.Text = "取消交病人";
                    TsmSelfOrder.Enabled = false;
                    TsmOutOrder.Enabled = false;
                    TsmGivePat.Enabled = true;
                    return;
                }
            }
        }
        public void OrderCopy()
        {
            //if (!controller.CanEditOrder())
            //{
            //    return;
            //}
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                DataTable dt = (DataTable)dgvOrders.DataSource;
                int begnum = 0;
                int endnum = 0;
                FindBeginEnd(rowindex, dt, ref begnum, ref endnum);
                List<OrderRecord> list = new List<Entity.OrderRecord>();
                for (int index = begnum; index <= endnum; index++)
                {
                    OrderRecord record = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<OrderRecord>(dt, index);
                    if (record.OrderType == (int)OrderType.出院医嘱 || record.OrderType == (int)OrderType.死亡医嘱 || record.OrderType == (int)OrderType.转科医嘱)
                    {
                        MessageBox.Show("该医嘱不能复制");
                        return;
                    }
                    if (record.AstOrderID>0 || record.Memo== "PsDrug")
                    {
                        MessageBox.Show("皮试关联医嘱不能复制");
                        return;
                    }
                    list.Add(record);
                }
                if (list.Count > 0)
                {
                    controller.OrderCopy(list);
                }
            }
        }
        public void OrderPaster()
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            dgvOrders.CurrentCellChanged -= dgvOrders_CurrentCellChanged;
            controller.OrderPaster();
            dgvOrders.CurrentCellChanged += dgvOrders_CurrentCellChanged;
            dgvOrders.Refresh();
        }
        //医嘱复制
        private void TsmOrderCopy_Click(object sender, EventArgs e)
        {           
            OrderCopy();
        }
        /// <summary>
        /// 医嘱粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmOrderPaster_Click(object sender, EventArgs e)
        {
            OrderPaster();
        }

        public void AddTempOrder(List<OrderRecord> list )
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            controller.AddOrders(list);
        }
        #endregion

        #region 其他    
        /// <summary>
        /// 医嘱时间修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!controller.CanEditOrder())
            {
                return;
            }
            if (dgvOrders != null && dgvOrders.CurrentCell != null)
            {
                int rowindex = dgvOrders.CurrentCell.RowIndex;
                int colindex = dgvOrders.CurrentCell.ColumnIndex;
                if (colindex != 0)
                {
                    return;
                }
                DataTable dt = (DataTable)dgvOrders.DataSource;
                if (Convert.ToInt32(dt.Rows[rowindex]["GroupFlag"]) == 0)
                {
                    return;
                }
                if (dt.Rows[rowindex]["ItemName"].ToString() == "")
                {
                    return;
                }
                if (Convert.ToInt32(dt.Rows[rowindex]["orderStatus"].ToString().Trim()) > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能修改录入时间");
                    return;
                }
                if (Convert.ToInt32(dt.Rows[rowindex]["ItemType"]) == 4)
                {
                    MessageBox.Show("该医嘱属于医技申请生成医嘱，不能修改录入时间");
                    return;
                }
                FrmOrderTime ftime = new FrmOrderTime(Convert.ToDateTime(dt.Rows[rowindex]["OrderBdate"].ToString()), Convert.ToDateTime(enterDate));
                ftime.ShowDialog();
                if (ftime.Ok)
                {
                    DateTime btime = ftime.alterDate;
                    dt.Rows[rowindex]["ShowOrderBdate"] = btime;
                    dt.Rows[rowindex]["ModifyFlag"] = 1;
                    dt.Rows[rowindex]["OrderBdate"] = btime;
                    if (Convert.ToInt32(dt.Rows[rowindex]["orderStatus"].ToString().Trim()) != -1)
                    {
                        controller.ChangeValue(dt, rowindex, "ShowOrderBdate");
                        SetGridColor();
                    }
                }

            }
        }
        #region 医嘱管理界面中获得一组医嘱的起始点和终点
        /// <summary>
        /// 医嘱管理界面中获得一组医嘱的起始点和终点  
        /// </summary>
        /// <param name="nrow"></param>
        /// <param name="myTb"></param>
        /// <param name="beginNum"></param>
        /// <param name="endNum"></param>
        public void FindBeginEnd(int nrow, DataTable myTb, ref int beginNum, ref int endNum)
        {          
            if (myTb.Rows.Count > 0)
            {
                int groupid = Convert.ToInt32(myTb.Rows[nrow]["GroupID"] == DBNull.Value ? -1 : myTb.Rows[nrow]["GroupID"]);
                int i = 0;
                beginNum = nrow;
                endNum = nrow;
                for (i = nrow; i <= myTb.Rows.Count - 1; i++)
                {
                    if (i + 1 == myTb.Rows.Count)
                    {
                        endNum = i;
                        break;
                    }
                    if (myTb.Rows[i + 1]["GroupID"].ToString() == groupid.ToString() && Convert.ToInt32(myTb.Rows[i + 1]["GroupFlag"]) == 0)
                    {
                        endNum = i + 1;
                    }
                    else break;
                }
                for (i = nrow; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        beginNum = i;
                        break;
                    }
                    if (myTb.Rows[i]["GroupID"].ToString() == groupid.ToString() && Convert.ToInt32(myTb.Rows[i]["GroupFlag"]) == 1)
                    {
                        beginNum = i;
                        break;
                    }
                   
                }
            }
        }

        public void GridEndEdit()
        {
            dgvOrders.EndEdit();
        }
        #endregion
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count == 0)
            {
                controller.AddEmptyRow(dgvOrders.Rows.Count, 0);
                dgvOrders.CurrentCell = dgvOrders[ItemName.Name, dgvOrders.Rows.Count - 1];
            }
            else
            {
                if (dgvOrders["ItemName", dgvOrders.Rows.Count - 1].Value.ToString() != "")
                {
                    controller.AddEmptyRow(dgvOrders.Rows.Count - 1, 0);
                    dgvOrders.CurrentCell = dgvOrders[ItemName.Name, dgvOrders.Rows.Count - 1];
                }
                else
                {
                    dgvOrders.CurrentCell = dgvOrders[ItemName.Name, dgvOrders.Rows.Count - 1];
                }
            }
        }

        private void dgvOrders_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);//组线画笔
            int x1, y1, x2, y2, y3, y4;//y1为组头横线位置，y2为组线底位置，y3为组线顶位置，y4为组尾横线位置
            x1 = y1 = x2 = y2 = 0;
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                int beginNum = 0;
                int endNum = 0;

                this.FindBeginEnd(i, (DataTable)dgvOrders.DataSource, ref beginNum, ref endNum);

                if (beginNum != endNum)
                {
                    for (int j = beginNum; j < endNum + 1; j++)
                    {
                        x1 = dgvOrders.GetCellDisplayRectangle(0, j, false).Right - 5;
                        x2 = dgvOrders.GetCellDisplayRectangle(0, j, false).Right;
                        y1 = dgvOrders.GetCellDisplayRectangle(0, j, false).Top + dgvOrders.GetCellDisplayRectangle(0, j, false).Height * 1 / 5;
                        y2 = dgvOrders.GetCellDisplayRectangle(0, j, false).Bottom;
                        y3 = dgvOrders.GetCellDisplayRectangle(0, j, false).Top;
                        y4 = dgvOrders.GetCellDisplayRectangle(0, j, false).Bottom - dgvOrders.GetCellDisplayRectangle(0, j, false).Height * 1 / 5;
                        if (j == beginNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y1, x2, y1);
                            e.Graphics.DrawLine(pen, x1, y1, x1, y2);
                        }
                        else if (j == endNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y4);
                            e.Graphics.DrawLine(pen, x1, y4, x2, y4);
                        }
                        else
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y2);
                        }
                    }
                }
                i = endNum;
            }
        }
        public bool CloseCheck()
        {
            if (!controller.CanEditOrder())
            {
                return true;
            }
            List<OrderRecord> notSaveRecores = GetNotSaveOrders();
            if (notSaveRecores.Count == 0)
            {
                return true;
            }
            else
            {
                string strName = "";
                foreach (OrderRecord order in notSaveRecores)
                {
                    strName += order.ItemName + "\n";
                }
                if (MessageBox.Show("还有下列医嘱未保存:\n" + strName + "是否继续关闭？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
            }
            return false;
        }
        public void ShowMessage(string message)
        {
            // MessageBox.Show(message);
            if (MessageShowoflinkage != null)
            {
                MessageShowoflinkage(message);
            }
        }

        #endregion

        private void ctMenuOrder_Opening(object sender, CancelEventArgs e)
        {
            dgvOrders.EndEdit();
            //if (OrderStyle == OrderCategory.临时医嘱)
            //{
                TsmChange();
            //}
        }      
    }
    //医嘱保存时费用联动
    public delegate void PrescriptionCostoflinkage(int patListId, List<Entity.OrderRecord> data);
    /// <summary>
    /// 开医嘱时增加皮试医嘱
    /// </summary>
    /// <param name="patListId"></param>
    /// <param name="data"></param>
    public delegate void PrescriptionAstoflinkage(int patListId, List<Entity.OrderRecord> data);
    /// <summary>
    /// 医嘱保存时
    /// </summary>
    /// <param name="orderCategore"></param>
    /// <param name="rowindex"></param>
    /// <param name="colName"></param>
    public delegate void PrescriptionSaveChecklinkage(int orderCategory,int rowindex,string colName);
    /// <summary>
    /// 提示信息弹出
    /// </summary>
    /// <param name="message"></param>
    public delegate void PrescriptionMessageShowlinkage(string message);
    /// <summary>
    /// 医嘱费用
    /// </summary>
    /// <param name="PatListID"></param>
    /// <param name="GroupID"></param>
    /// <param name="ExecDeptID"></param>
    /// <param name="ExecDeptName"></param>
    /// <param name="orderStatus"></param>
    public delegate void PrescriptionFeeShowlinkage(int PatListID, int GroupID, int ExecDeptID, string ExecDeptName,int orderStatus,int orderType);
    public delegate void PrescriptionFreshlinkage();
    //药品信息显示
    public delegate void PrescriptionDrugDetailShowlinkage(DataRow rowDrug,string execDeptName);
}
