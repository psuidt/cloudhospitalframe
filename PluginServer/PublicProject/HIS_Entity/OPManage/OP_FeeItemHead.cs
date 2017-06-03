using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_FeeItemHead", EntityType = EntityType.Table, IsGB = false)]
    public class OP_FeeItemHead:AbstractEntity
    {
        private int  _feeitemheadid;
        /// <summary>
        /// 处方头ID
        /// </summary>
        [Column(FieldName = "FeeItemHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int FeeItemHeadID
        {
            get { return  _feeitemheadid; }
            set {  _feeitemheadid = value; }
        }

        private int  _costheadid;
        /// <summary>
        /// 本张处方对应的结算记录编号
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 病人ID（预留）
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
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

        private string  _prestype;
        /// <summary>
        /// 处方类型
        /// </summary>
        [Column(FieldName = "PresType", DataKey = false, Match = "", IsInsert = true)]
        public string PresType
        {
            get { return  _prestype; }
            set {  _prestype = value; }
        }

        private int  _presempid;
        /// <summary>
        /// 开方医生代码
        /// </summary>
        [Column(FieldName = "PresEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int PresEmpID
        {
            get { return  _presempid; }
            set {  _presempid = value; }
        }

        private int  _presdeptid;
        /// <summary>
        /// 开方科室代码
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return  _presdeptid; }
            set {  _presdeptid = value; }
        }

        private int  _execempid;
        /// <summary>
        /// 执行医生代码（暂不用）
        /// </summary>
        [Column(FieldName = "ExecEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecEmpID
        {
            get { return  _execempid; }
            set {  _execempid = value; }
        }

        private int  _execdeptid;
        /// <summary>
        /// 执行科室代码
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return  _execdeptid; }
            set {  _execdeptid = value; }
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

        private int  _presamount;
        /// <summary>
        /// 处方数量
        /// </summary>
        [Column(FieldName = "PresAmount", DataKey = false, Match = "", IsInsert = true)]
        public int PresAmount
        {
            get { return  _presamount; }
            set {  _presamount = value; }
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

        private int  _oldid;
        /// <summary>
        /// 对应冲正的记录ID
        /// </summary>
        [Column(FieldName = "OldID", DataKey = false, Match = "", IsInsert = true)]
        public int OldID
        {
            get { return  _oldid; }
            set {  _oldid = value; }
        }

        private string  _invoiceno;
        /// <summary>
        /// 小票号码（在正式结算后回写）
        /// </summary>
        [Column(FieldName = "InvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNO
        {
            get { return  _invoiceno; }
            set {  _invoiceno = value; }
        }

        private string  _reciptno;
        /// <summary>
        /// 正式发票号码(补打)
        /// </summary>
        [Column(FieldName = "ReciptNO", DataKey = false, Match = "", IsInsert = true)]
        public string ReciptNO
        {
            get { return  _reciptno; }
            set {  _reciptno = value; }
        }

        private int  _chargestatus;
        /// <summary>
        /// 记录状态（0-正常 1-退费，2-冲正的负记录，3-收费取消 9预算）
        /// </summary>
        [Column(FieldName = "ChargeStatus", DataKey = false, Match = "", IsInsert = true)]
        public int ChargeStatus
        {
            get { return  _chargestatus; }
            set {  _chargestatus = value; }
        }

        private int  _chargeflag;
        /// <summary>
        /// 收费标识（0-为未收费 1-已收费）
        /// </summary>
        [Column(FieldName = "ChargeFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ChargeFlag
        {
            get { return  _chargeflag; }
            set {  _chargeflag = value; }
        }

        private int  _distributeflag;
        /// <summary>
        /// 发药确费标识（0-未发药未确费 1-已发药已确费）
        /// </summary>
        [Column(FieldName = "DistributeFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DistributeFlag
        {
            get { return  _distributeflag; }
            set {  _distributeflag = value; }
        }

        private DateTime  _execdate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ExecDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ExecDate
        {
            get { return  _execdate; }
            set {  _execdate = value; }
        }

        private DateTime  _presdate;
        /// <summary>
        /// 处方日期
        /// </summary>
        [Column(FieldName = "PresDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PresDate
        {
            get { return  _presdate; }
            set {  _presdate = value; }
        }

        private Decimal  _roungingfee;
        /// <summary>
        /// 处方舍入金额
        /// </summary>
        [Column(FieldName = "RoungingFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RoungingFee
        {
            get { return  _roungingfee; }
            set {  _roungingfee = value; }
        }

        private int  _docpresheadid;
        /// <summary>
        /// 医生处方ID
        /// </summary>
        [Column(FieldName = "DocPresHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int DocPresHeadID
        {
            get { return  _docpresheadid; }
            set {  _docpresheadid = value; }
        }

        private Decimal  _discountfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DiscountFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DiscountFee
        {
            get { return  _discountfee; }
            set {  _discountfee = value; }
        }

        private Decimal  _feeno;
        /// <summary>
        /// 费用流水号
        /// </summary>
        [Column(FieldName = "FeeNo", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeNo
        {
            get { return  _feeno; }
            set {  _feeno = value; }
        }

        private DateTime  _chargedate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ChargeDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ChargeDate
        {
            get { return  _chargedate; }
            set {  _chargedate = value; }
        }


        private int _regflag;
        /// <summary>
        /// 0收费 1挂号
        /// </summary>
        [Column(FieldName = "RegFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RegFlag
        {
            get { return _regflag; }
            set { _regflag = value; }
        }
        private int _docpresno;
        /// <summary>
        /// 医生处方号
        /// </summary>
        [Column(FieldName = "DocPresNO", DataKey = false, Match = "", IsInsert = true)]
        public int DocPresNO
        {
            get { return _docpresno; }
            set { _docpresno = value; }
        }

    }
}
