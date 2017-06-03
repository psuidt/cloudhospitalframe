using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_CostHead", EntityType = EntityType.Table, IsGB = false)]
    public class IP_CostHead : AbstractEntity
    {
        private int _costheadid;
        /// <summary>
        /// 结算ID
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int CostHeadID
        {
            get { return _costheadid; }
            set { _costheadid = value; }
        }

        private int _memberid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return _memberid; }
            set { _memberid = value; }
        }

        private int _memberaccountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MemberAccountID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberAccountID
        {
            get { return _memberaccountid; }
            set { _memberaccountid = value; }
        }

        private string _cardno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CardNO", DataKey = false, Match = "", IsInsert = true)]
        public string CardNO
        {
            get { return _cardno; }
            set { _cardno = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 病人列表ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private string _patname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

        private int _deptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return _deptid; }
            set { _deptid = value; }
        }

        private int _pattypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return _pattypeid; }
            set { _pattypeid = value; }
        }

        private int _costtype;
        /// <summary>
        /// 结算类型(1 中途,2 出院,3 欠费)
        /// </summary>
        [Column(FieldName = "CostType", DataKey = false, Match = "", IsInsert = true)]
        public int CostType
        {
            get { return _costtype; }
            set { _costtype = value; }
        }

        private DateTime _costdate;
        /// <summary>
        /// 结算日期
        /// </summary>
        [Column(FieldName = "CostDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CostDate
        {
            get { return _costdate; }
            set { _costdate = value; }
        }

        private int _costempid;
        /// <summary>
        /// 结算人
        /// </summary>
        [Column(FieldName = "CostEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int CostEmpID
        {
            get { return _costempid; }
            set { _costempid = value; }
        }

        private DateTime _costbegindate;
        /// <summary>
        /// 结算起止日期
        /// </summary>
        [Column(FieldName = "CostBeginDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CostBeginDate
        {
            get { return _costbegindate; }
            set { _costbegindate = value; }
        }

        private DateTime _costenddate;
        /// <summary>
        /// 结算终止日期
        /// </summary>
        [Column(FieldName = "CostEndDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CostEndDate
        {
            get { return _costenddate; }
            set { _costenddate = value; }
        }

        private int _invoiceid;
        /// <summary>
        /// 发票ID
        /// </summary>
        [Column(FieldName = "InvoiceID", DataKey = false, Match = "", IsInsert = true)]
        public int InvoiceID
        {
            get { return _invoiceid; }
            set { _invoiceid = value; }
        }

        private string _invoiceno;
        /// <summary>
        /// 票据号
        /// </summary>
        [Column(FieldName = "InvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNO
        {
            get { return _invoiceno; }
            set { _invoiceno = value; }
        }

        private Decimal _totalfee;
        /// <summary>
        /// 总金额-
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return _totalfee; }
            set { _totalfee = value; }
        }

        private Decimal _deptositfee;
        /// <summary>
        /// 预交金
        /// </summary>
        [Column(FieldName = "DeptositFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DeptositFee
        {
            get { return _deptositfee; }
            set { _deptositfee = value; }
        }

        private Decimal _balancefee;
        /// <summary>
        /// 预交金结余
        /// </summary>
        [Column(FieldName = "BalanceFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal BalanceFee
        {
            get { return _balancefee; }
            set { _balancefee = value; }
        }

        private int _status;
        /// <summary>
        /// 记录状态（0正常，1被退，2，红冲）
        /// </summary>
        [Column(FieldName = "Status", DataKey = false, Match = "", IsInsert = true)]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _oldcostheadid;
        /// <summary>
        /// 退ID
        /// </summary>
        [Column(FieldName = "OldCostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int OldCostHeadID
        {
            get { return _oldcostheadid; }
            set { _oldcostheadid = value; }
        }

        private int _accountid;
        /// <summary>
        /// 交款ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return _accountid; }
            set { _accountid = value; }
        }

        private Decimal _cashfee;
        /// <summary>
        /// 现金金额
        /// </summary>
        [Column(FieldName = "CashFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CashFee
        {
            get { return _cashfee; }
            set { _cashfee = value; }
        }

        private Decimal _posfee;
        /// <summary>
        /// ＰＯＳ金额
        /// </summary>
        [Column(FieldName = "PosFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PosFee
        {
            get { return _posfee; }
            set { _posfee = value; }
        }

        private Decimal _promfee;
        /// <summary>
        /// 优惠金额
        /// </summary>
        [Column(FieldName = "PromFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PromFee
        {
            get { return _promfee; }
            set { _promfee = value; }
        }

        private Decimal _roundingfee;
        /// <summary>
        /// 凑整金额
        /// </summary>
        [Column(FieldName = "RoundingFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RoundingFee
        {
            get { return _roundingfee; }
            set { _roundingfee = value; }
        }

    }
}
