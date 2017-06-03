using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_OPDispHead", EntityType = EntityType.Table, IsGB = false)]
    public class DS_OPDispHead:AbstractEntity
    {
        private int  _dispheadid;
        /// <summary>
        /// 发/退药表头标识ID
        /// </summary>
        [Column(FieldName = "DispHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int DispHeadID
        {
            get { return  _dispheadid; }
            set {  _dispheadid = value; }
        }

        private long  _billno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BillNO", DataKey = false, Match = "", IsInsert = true)]
        public long BillNO
        {
            get { return  _billno; }
            set {  _billno = value; }
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

        private Decimal  _retailfee;
        /// <summary>
        /// 零售金额
        /// </summary>
        [Column(FieldName = "RetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailFee
        {
            get { return  _retailfee; }
            set {  _retailfee = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 病人姓名
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private string  _patsex;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatSex", DataKey = false, Match = "", IsInsert = true)]
        public string PatSex
        {
            get { return  _patsex; }
            set {  _patsex = value; }
        }

        private string  _diagnose;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Diagnose", DataKey = false, Match = "", IsInsert = true)]
        public string Diagnose
        {
            get { return  _diagnose; }
            set {  _diagnose = value; }
        }

        private string  _patage;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatAge", DataKey = false, Match = "", IsInsert = true)]
        public string PatAge
        {
            get { return  _patage; }
            set {  _patage = value; }
        }

        private int  _presdocid;
        /// <summary>
        /// 医生ID
        /// </summary>
        [Column(FieldName = "PresDocID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDocID
        {
            get { return  _presdocid; }
            set {  _presdocid = value; }
        }

        private string  _presdocname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PresDocName", DataKey = false, Match = "", IsInsert = true)]
        public string PresDocName
        {
            get { return  _presdocname; }
            set {  _presdocname = value; }
        }

        private int  _presdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return  _presdeptid; }
            set {  _presdeptid = value; }
        }

        private string  _presdeptname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PresDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string PresDeptName
        {
            get { return  _presdeptname; }
            set {  _presdeptname = value; }
        }

        private int  _dispenserid;
        /// <summary>
        /// 配药人
        /// </summary>
        [Column(FieldName = "DispenserID", DataKey = false, Match = "", IsInsert = true)]
        public int DispenserID
        {
            get { return  _dispenserid; }
            set {  _dispenserid = value; }
        }

        private string  _dispensername;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DispenserName", DataKey = false, Match = "", IsInsert = true)]
        public string DispenserName
        {
            get { return  _dispensername; }
            set {  _dispensername = value; }
        }

        private int  _pharmacistid;
        /// <summary>
        /// 发/退药人
        /// </summary>
        [Column(FieldName = "PharmacistID", DataKey = false, Match = "", IsInsert = true)]
        public int PharmacistID
        {
            get { return  _pharmacistid; }
            set {  _pharmacistid = value; }
        }

        private string  _pharmacistname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PharmacistName", DataKey = false, Match = "", IsInsert = true)]
        public string PharmacistName
        {
            get { return  _pharmacistname; }
            set {  _pharmacistname = value; }
        }

        private int  _refundflag;
        /// <summary>
        /// 发/退药标识
        /// </summary>
        [Column(FieldName = "RefundFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RefundFlag
        {
            get { return  _refundflag; }
            set {  _refundflag = value; }
        }

        private DateTime  _disptime;
        /// <summary>
        /// 发/退药时间
        /// </summary>
        [Column(FieldName = "DispTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime DispTime
        {
            get { return  _disptime; }
            set {  _disptime = value; }
        }

        private string  _feeno;
        /// <summary>
        /// 发票号
        /// </summary>
        [Column(FieldName = "FeeNO", DataKey = false, Match = "", IsInsert = true)]
        public string FeeNO
        {
            get { return  _feeno; }
            set {  _feeno = value; }
        }

        private string  _invoiceno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "InvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNO
        {
            get { return  _invoiceno; }
            set {  _invoiceno = value; }
        }

        private DateTime  _chargetime;
        /// <summary>
        /// 收费日期
        /// </summary>
        [Column(FieldName = "ChargeTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ChargeTime
        {
            get { return  _chargetime; }
            set {  _chargetime = value; }
        }

        private int  _chargeempid;
        /// <summary>
        /// 收款人
        /// </summary>
        [Column(FieldName = "ChargeEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ChargeEmpID
        {
            get { return  _chargeempid; }
            set {  _chargeempid = value; }
        }

        private string  _chargeempname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ChargeEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string ChargeEmpName
        {
            get { return  _chargeempname; }
            set {  _chargeempname = value; }
        }

        private int  _feeitemheadid;
        /// <summary>
        /// 结算收据号
        /// </summary>
        [Column(FieldName = "FeeItemHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeItemHeadID
        {
            get { return  _feeitemheadid; }
            set {  _feeitemheadid = value; }
        }

        private int  _recipeid;
        /// <summary>
        /// 处方号
        /// </summary>
        [Column(FieldName = "RecipeID", DataKey = false, Match = "", IsInsert = true)]
        public int RecipeID
        {
            get { return  _recipeid; }
            set {  _recipeid = value; }
        }

        private string  _recipetype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RecipeType", DataKey = false, Match = "", IsInsert = true)]
        public string RecipeType
        {
            get { return  _recipetype; }
            set {  _recipetype = value; }
        }

        private int  _recipeamount;
        /// <summary>
        /// 处方贴数
        /// </summary>
        [Column(FieldName = "RecipeAmount", DataKey = false, Match = "", IsInsert = true)]
        public int RecipeAmount
        {
            get { return  _recipeamount; }
            set {  _recipeamount = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 科室ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

    }
}
