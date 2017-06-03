using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_Account", EntityType = EntityType.Table, IsGB = false)]
    public class OP_Account:AbstractEntity
    {
        private int  _accountid;
        /// <summary>
        /// 账单ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = true, Match = "", IsInsert = false)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private DateTime  _lastdate;
        /// <summary>
        /// 最后交账日期
        /// </summary>
        [Column(FieldName = "LastDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime LastDate
        {
            get { return  _lastdate; }
            set {  _lastdate = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 总费用
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
        }

        private Decimal  _cashfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CashFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CashFee
        {
            get { return  _cashfee; }
            set {  _cashfee = value; }
        }

        private Decimal  _promfee;
        /// <summary>
        /// 优惠金额
        /// </summary>
        [Column(FieldName = "PromFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PromFee
        {
            get { return  _promfee; }
            set {  _promfee = value; }
        }

        private Decimal  _posfee;
        /// <summary>
        /// POS金额
        /// </summary>
        [Column(FieldName = "PosFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PosFee
        {
            get { return  _posfee; }
            set {  _posfee = value; }
        }

        private int  _accountempid;
        /// <summary>
        /// 交款人
        /// </summary>
        [Column(FieldName = "AccountEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountEmpID
        {
            get { return  _accountempid; }
            set {  _accountempid = value; }
        }

        private DateTime  _accountdate;
        /// <summary>
        /// 交款时间
        /// </summary>
        [Column(FieldName = "AccountDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AccountDate
        {
            get { return  _accountdate; }
            set {  _accountdate = value; }
        }

        private int  _accountflag;
        /// <summary>
        /// 0未交账　１已经交账
        /// </summary>
        [Column(FieldName = "AccountFlag", DataKey = false, Match = "", IsInsert = true)]
        public int AccountFlag
        {
            get { return  _accountflag; }
            set {  _accountflag = value; }
        }

        private int  _receivflag;
        /// <summary>
        /// 0未收款１已经收款
        /// </summary>
        [Column(FieldName = "ReceivFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivFlag
        {
            get { return  _receivflag; }
            set {  _receivflag = value; }
        }

        private int  _receivempid;
        /// <summary>
        /// 收款操作员
        /// </summary>
        [Column(FieldName = "ReceivEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivEmpID
        {
            get { return  _receivempid; }
            set {  _receivempid = value; }
        }

        private DateTime  _receivdate;
        /// <summary>
        /// 缴款时间
        /// </summary>
        [Column(FieldName = "ReceivDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ReceivDate
        {
            get { return  _receivdate; }
            set {  _receivdate = value; }
        }

        private int  _receivbillno;
        /// <summary>
        /// 缴款单号
        /// </summary>
        [Column(FieldName = "ReceivBillNO", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivBillNO
        {
            get { return  _receivbillno; }
            set {  _receivbillno = value; }
        }

        private int _invoicecount;
        /// <summary>
        /// 收费票据张数
        /// </summary>
        [Column(FieldName = "InvoiceCount", DataKey = false, Match = "", IsInsert = true)]
        public int InvoiceCount
        {
            get { return _invoicecount; }
            set { _invoicecount = value; }
        }

        private int _refundInvoicecount;
        /// <summary>
        /// 退费票据张数
        /// </summary>
        [Column(FieldName = "RefundInvoiceCount", DataKey = false, Match = "", IsInsert = true)]
        public int RefundInvoiceCount
        {
            get { return _refundInvoicecount; }
            set { _refundInvoicecount = value; }
        }
        private Decimal _roundingFee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RoundingFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RoundingFee
        {
            get { return _roundingFee; }
            set { _roundingFee = value; }
        }

        private int _accountType;
        /// <summary>
        /// 交款类型 0 收费挂号 1 会员充值
        /// </summary>
        [Column(FieldName = "AccountType", DataKey = false, Match = "", IsInsert = true)]
        public int AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        private string _accountEmpName;
        /// <summary>
        /// 收费员名
        /// </summary>
        [Column(FieldName = "AccountEmpName", DataKey = false, Match = "", IsInsert = false)]
        public string AccountEmpName
        {
            get { return _accountEmpName; }
            set { _accountEmpName = value; }
        }
    }
}
