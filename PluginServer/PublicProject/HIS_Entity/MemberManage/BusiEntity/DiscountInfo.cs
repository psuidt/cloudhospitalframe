using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MemberManage
{
    public class DiscountInfo
    {
        private int _operateID;
        /// <summary>
        /// 操作员ID
        /// </summary>
        public int OperateID
        {
            get { return _operateID; }
            set { _operateID = value; }
        }
        /// <summary>
        /// 结算单号
        /// </summary>
        private string _settlementNO;
        public string SettlementNO
        {
            get { return _settlementNO; }
            set { _settlementNO = value; }
        }
        private int _accountID;
        /// <summary>
        /// 帐户ID
        /// </summary>
        public int AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }

        private int _patientType;
        /// <summary>
        /// 病人类型（1、门诊；2、住院）
        /// </summary>
        public int PatientType
        {
            get { return _patientType; }
            set { _patientType = value; }
        }

        private int _costType;
        /// <summary>
        /// 费用类型ID
        /// </summary>
        public int CostType
        {
            get { return _costType; }
            set { _costType = value; }
        }

        private decimal _amount;
        /// <summary>
        /// 本次需要进行优惠计算的合计金额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private DataTable _dtDetail;
        /// <summary>
        /// 需要进行优惠计算的明细项目与项目金额
        /// </summary>
        public DataTable DtDetail
        {
            get { return _dtDetail; }
            set { _dtDetail = value; }
        }
        /// <summary>
        /// 需要进行优惠计算的明细项目分类与项目分类金额
        /// </summary>
        private DataTable _dtClass;
        public DataTable DtClass
        {
            get { return _dtClass; }
            set { _dtClass = value; }
        }
        /// <summary>
        /// 优惠金额合计
        /// </summary>
        private decimal _disAmount;
        public decimal DisAmount
        {
            get { return _disAmount; }
            set { _disAmount = value; }
        }
        /// <summary>
        /// 优惠计算明细
        /// </summary>
        private List<ME_DiscountList> _discountList;

        public List<ME_DiscountList> DiscountList
        {
            get { return _discountList; }
            set { _discountList = value; }
        }

        private bool _isSave;
        /// <summary>
        /// 是否保存优惠明细
        /// </summary>
        public bool IsSave
        {
            get { return _isSave; }
            set { _isSave = value; }
        }

        private int _accID;

        /// <summary>
        /// 结算ID
        /// </summary>
        public int AccID
        {
            get { return _accID; }
            set { _accID = value; }
        }

        public DiscountInfo()
        {
            DtClass = new DataTable();
            DtDetail = new DataTable();

            #region  构造明细表
           
            DataColumn col = new DataColumn();
            col.ColumnName = "ItemTypeID";
            col.DataType = typeof(System.Decimal);
            DtDetail.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "PresDetailId";
            col.DataType = typeof(System.Int32);
            DtDetail.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "ItemAmount";
            col.DataType = typeof(System.Decimal);
            DtDetail.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "PromAmount";
            col.DataType = typeof(System.Decimal);
            DtDetail.Columns.Add(col);

            #endregion

            #region 构造分类表             
            col = new DataColumn();
            col.ColumnName = "ClassTypeID";
            col.DataType = typeof(System.String);
            DtClass.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "ClassAmount";
            col.DataType = typeof(System.Decimal);
            DtClass.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "PromAmount";
            col.DataType = typeof(System.Decimal);
            DtClass.Columns.Add(col);
            #endregion



        }
    }
}
