using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_CostHead", EntityType = EntityType.Table, IsGB = false)]
    public class OP_CostHead:AbstractEntity
    {
        private int  _costheadid;
        /// <summary>
        /// 结算表头ID
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _memberaccountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MemberAccountID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberAccountID
        {
            get { return  _memberaccountid; }
            set {  _memberaccountid = value; }
        }

        private string  _cardno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CardNO", DataKey = false, Match = "", IsInsert = true)]
        public string CardNO
        {
            get { return  _cardno; }
            set {  _cardno = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人就诊ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private int  _pattypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return  _pattypeid; }
            set {  _pattypeid = value; }
        }

        private string  _beinvoiceno;
        /// <summary>
        /// 发票号（包含在分配的发票号中）
        /// </summary>
        [Column(FieldName = "BeInvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string BeInvoiceNO
        {
            get { return  _beinvoiceno; }
            set {  _beinvoiceno = value; }
        }

        private string  _endinvoiceno;
        /// <summary>
        /// 发票号（预留给手工录入发票号的功能用）
        /// </summary>
        [Column(FieldName = "EndInvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string EndInvoiceNO
        {
            get { return  _endinvoiceno; }
            set {  _endinvoiceno = value; }
        }

        private int  _chargeempid;
        /// <summary>
        /// 收费员代码
        /// </summary>
        [Column(FieldName = "ChargeEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ChargeEmpID
        {
            get { return  _chargeempid; }
            set {  _chargeempid = value; }
        }

        private string  _chargeempname;
        /// <summary>
        /// 收费员名称
        /// </summary>
        [Column(FieldName = "ChargeEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string ChargeEmpName
        {
            get { return  _chargeempname; }
            set {  _chargeempname = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 结算总费用
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
        }

        private Decimal  _cashfee;
        /// <summary>
        /// 现金金额
        /// </summary>
        [Column(FieldName = "CashFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CashFee
        {
            get { return  _cashfee; }
            set {  _cashfee = value; }
        }

        private Decimal  _posfee;
        /// <summary>
        /// ＰＯＳ金额
        /// </summary>
        [Column(FieldName = "PosFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PosFee
        {
            get { return  _posfee; }
            set {  _posfee = value; }
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

        private int  _recipeflag;
        /// <summary>
        /// 发票打印标识(0未打1已打）
        /// </summary>
        [Column(FieldName = "RecipeFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RecipeFlag
        {
            get { return  _recipeflag; }
            set {  _recipeflag = value; }
        }

        private DateTime  _costdate;
        /// <summary>
        /// 结算日期
        /// </summary>
        [Column(FieldName = "CostDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CostDate
        {
            get { return  _costdate; }
            set {  _costdate = value; }
        }

        private int  _coststatus;
        /// <summary>
        /// 记录状态【0-正常，1-退费（由0状态改变），2-冲正（新生成的负记录，对应状态1的记录）３取消结算９预算】
        /// </summary>
        [Column(FieldName = "CostStatus", DataKey = false, Match = "", IsInsert = true)]
        public int CostStatus
        {
            get { return  _coststatus; }
            set {  _coststatus = value; }
        }

        private int  _oldid;
        /// <summary>
        /// 被冲正的记录编号
        /// </summary>
        [Column(FieldName = "OldID", DataKey = false, Match = "", IsInsert = true)]
        public int OldID
        {
            get { return  _oldid; }
            set {  _oldid = value; }
        }

        private int  _accountid;
        /// <summary>
        /// 交账ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private int  _regflag;
        /// <summary>
        /// 挂号标识(0,收费 1挂号)
        /// </summary>
        [Column(FieldName = "RegFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RegFlag
        {
            get { return  _regflag; }
            set {  _regflag = value; }
        }

        private int  _regcategory;
        /// <summary>
        /// 0普通 1急诊
        /// </summary>
        [Column(FieldName = "RegCategory", DataKey = false, Match = "", IsInsert = true)]
        public int RegCategory
        {
            get { return  _regcategory; }
            set {  _regcategory = value; }
        }
        private decimal _roundingFee;
        /// <summary>
        /// 舍入金额
        /// </summary>
        [Column(FieldName = "RoundingFee", DataKey = false, Match = "", IsInsert = true)]
        public decimal RoundingFee
        {
            get { return _roundingFee; }
            set { _roundingFee = value; }
        }
        private int _invoiceID;
        /// <summary>
        /// 发票卷序号
        /// </summary>
        [Column(FieldName = "InvoiceID", DataKey = false, Match = "", IsInsert = true)]
        public int InvoiceID
        {
            get { return _invoiceID; }
            set { _invoiceID = value; }
        }
    }
}
