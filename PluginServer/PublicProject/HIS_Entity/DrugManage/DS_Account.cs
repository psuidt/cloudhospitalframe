using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_Account", EntityType = EntityType.Table, IsGB = false)]
    public class DS_Account:AbstractEntity
    {
        private int  _accountid;
        /// <summary>
        /// 台帐标识ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = true, Match = "", IsInsert = false)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private int  _balanceyear;
        /// <summary>
        /// 会计年份
        /// </summary>
        [Column(FieldName = "BalanceYear", DataKey = false, Match = "", IsInsert = true)]
        public int BalanceYear
        {
            get { return  _balanceyear; }
            set {  _balanceyear = value; }
        }

        private int  _balancemonth;
        /// <summary>
        /// 会计月份
        /// </summary>
        [Column(FieldName = "BalanceMonth", DataKey = false, Match = "", IsInsert = true)]
        public int BalanceMonth
        {
            get { return  _balancemonth; }
            set {  _balancemonth = value; }
        }

        private int  _accounttype;
        /// <summary>
        /// 台帐类型
        /// </summary>
        [Column(FieldName = "AccountType", DataKey = false, Match = "", IsInsert = true)]
        public int AccountType
        {
            get { return  _accounttype; }
            set {  _accounttype = value; }
        }

        private Decimal  _retailprice;
        /// <summary>
        /// 零售价
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return  _retailprice; }
            set {  _retailprice = value; }
        }

        private Decimal  _stockprice;
        /// <summary>
        /// 批发价
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
        }

        private string  _busitype;
        /// <summary>
        /// 业务类型
        /// </summary>
        [Column(FieldName = "BusiType", DataKey = false, Match = "", IsInsert = true)]
        public string BusiType
        {
            get { return  _busitype; }
            set {  _busitype = value; }
        }

        private long  _billno;
        /// <summary>
        /// 单据号
        /// </summary>
        [Column(FieldName = "BillNO", DataKey = false, Match = "", IsInsert = true)]
        public long BillNO
        {
            get { return  _billno; }
            set {  _billno = value; }
        }

        private int  _unitid;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "UnitID", DataKey = false, Match = "", IsInsert = true)]
        public int UnitID
        {
            get { return  _unitid; }
            set {  _unitid = value; }
        }

        private int  _unitamount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UnitAmount", DataKey = false, Match = "", IsInsert = true)]
        public int UnitAmount
        {
            get { return  _unitamount; }
            set {  _unitamount = value; }
        }

        private string  _unitname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UnitName", DataKey = false, Match = "", IsInsert = true)]
        public string UnitName
        {
            get { return  _unitname; }
            set {  _unitname = value; }
        }

        private DateTime  _regtime;
        /// <summary>
        /// 登记日期
        /// </summary>
        [Column(FieldName = "RegTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegTime
        {
            get { return  _regtime; }
            set {  _regtime = value; }
        }

        private Decimal  _debitamount;
        /// <summary>
        /// 贷方数量
        /// </summary>
        [Column(FieldName = "DebitAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DebitAmount
        {
            get { return  _debitamount; }
            set {  _debitamount = value; }
        }

        private Decimal  _overamount;
        /// <summary>
        /// 余额数量
        /// </summary>
        [Column(FieldName = "OverAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal OverAmount
        {
            get { return  _overamount; }
            set {  _overamount = value; }
        }

        private Decimal  _debitretailfee;
        /// <summary>
        /// 贷方金额
        /// </summary>
        [Column(FieldName = "DebitRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DebitRetailFee
        {
            get { return  _debitretailfee; }
            set {  _debitretailfee = value; }
        }

        private Decimal  _lendretailfee;
        /// <summary>
        /// 借方金额
        /// </summary>
        [Column(FieldName = "LendRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LendRetailFee
        {
            get { return  _lendretailfee; }
            set {  _lendretailfee = value; }
        }

        private Decimal  _debitstockfee;
        /// <summary>
        /// 贷方金额
        /// </summary>
        [Column(FieldName = "DebitStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DebitStockFee
        {
            get { return  _debitstockfee; }
            set {  _debitstockfee = value; }
        }

        private Decimal  _lendstockfee;
        /// <summary>
        /// 借方金额
        /// </summary>
        [Column(FieldName = "LendStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LendStockFee
        {
            get { return  _lendstockfee; }
            set {  _lendstockfee = value; }
        }

        private Decimal  _overstockfee;
        /// <summary>
        /// 余额
        /// </summary>
        [Column(FieldName = "OverStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal OverStockFee
        {
            get { return  _overstockfee; }
            set {  _overstockfee = value; }
        }

        private Decimal  _overretailfee;
        /// <summary>
        /// 余额
        /// </summary>
        [Column(FieldName = "OverRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal OverRetailFee
        {
            get { return  _overretailfee; }
            set {  _overretailfee = value; }
        }

        private int  _balanceflag;
        /// <summary>
        /// 月结标志
        /// </summary>
        [Column(FieldName = "BalanceFlag", DataKey = false, Match = "", IsInsert = true)]
        public int BalanceFlag
        {
            get { return  _balanceflag; }
            set {  _balanceflag = value; }
        }

        private int  _balanceid;
        /// <summary>
        /// 月结历史记录标识ID
        /// </summary>
        [Column(FieldName = "BalanceID", DataKey = false, Match = "", IsInsert = true)]
        public int BalanceID
        {
            get { return  _balanceid; }
            set {  _balanceid = value; }
        }

        private int  _drugid;
        /// <summary>
        /// 厂家典标识ID
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
        }

        private int  _ctypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int CTypeID
        {
            get { return  _ctypeid; }
            set {  _ctypeid = value; }
        }

        private string  _batchno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BatchNO", DataKey = false, Match = "", IsInsert = true)]
        public string BatchNO
        {
            get { return  _batchno; }
            set {  _batchno = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 部门ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _detailid;
        /// <summary>
        /// 对应明细ID
        /// </summary>
        [Column(FieldName = "DetailID", DataKey = false, Match = "", IsInsert = true)]
        public int DetailID
        {
            get { return  _detailid; }
            set {  _detailid = value; }
        }

        /// <summary>
        /// 对应明细ID
        /// </summary>
        [Column(FieldName = "LendAmount", DataKey = false, Match = "", IsInsert = true)]
        public decimal LendAmount { set; get; }

    }
}
