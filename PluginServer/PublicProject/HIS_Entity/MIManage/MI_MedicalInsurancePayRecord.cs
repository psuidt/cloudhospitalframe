using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_MedicalInsurancePayRecord", EntityType = EntityType.Table, IsGB = false)]
    public class MI_MedicalInsurancePayRecord:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }


        private int  _patienttype;
        /// <summary>
        /// 门诊住院:0门诊/1住院
        /// </summary>
        [Column(FieldName = "PatientType", DataKey = false, Match = "", IsInsert = true)]
        public int PatientType
        {
            get { return  _patienttype; }
            set {  _patienttype = value; }
        }

        private string  _tradeno;
        /// <summary>
        /// 交易流水号
        /// </summary>
        [Column(FieldName = "TradeNO", DataKey = false, Match = "", IsInsert = true)]
        public string TradeNO
        {
            get { return  _tradeno; }
            set {  _tradeno = value; }
        }

        private DateTime  _tradetime;
        /// <summary>
        /// 交易日期/时间
        /// </summary>
        [Column(FieldName = "TradeTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime TradeTime
        {
            get { return  _tradetime; }
            set {  _tradetime = value; }
        }

        private Decimal  _feeall;
        /// <summary>
        /// 费用总金额
        /// </summary>
        [Column(FieldName = "FeeAll", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeAll
        {
            get { return  _feeall; }
            set {  _feeall = value; }
        }

        private Decimal  _feefund;
        /// <summary>
        /// 基金支付金额
        /// </summary>
        [Column(FieldName = "FeeFund", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeFund
        {
            get { return  _feefund; }
            set {  _feefund = value; }
        }

        private Decimal  _feecash;
        /// <summary>
        /// 现金支付金额
        /// </summary>
        [Column(FieldName = "FeeCash", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeCash
        {
            get { return  _feecash; }
            set {  _feecash = value; }
        }

        private Decimal  _personcountpay;
        /// <summary>
        /// 个人账户支付金额
        /// </summary>
        [Column(FieldName = "PersonCountPay", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PersonCountPay
        {
            get { return  _personcountpay; }
            set {  _personcountpay = value; }
        }

        private Decimal  _personcount;
        /// <summary>
        /// 个人帐户余额
        /// </summary>
        [Column(FieldName = "PersonCount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PersonCount
        {
            get { return  _personcount; }
            set {  _personcount = value; }
        }

        private Decimal  _feemiin;
        /// <summary>
        /// 医保内总金额
        /// </summary>
        [Column(FieldName = "FeeMIIn", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeMIIn
        {
            get { return  _feemiin; }
            set {  _feemiin = value; }
        }

        private Decimal  _feemiout;
        /// <summary>
        /// 医保外总金额
        /// </summary>
        [Column(FieldName = "FeeMIOut", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeMIOut
        {
            get { return  _feemiout; }
            set {  _feemiout = value; }
        }

        private Decimal  _feedeductible;
        /// <summary>
        /// 本次付起付线金额
        /// </summary>
        [Column(FieldName = "FeeDeductible", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeDeductible
        {
            get { return  _feedeductible; }
            set {  _feedeductible = value; }
        }

        private Decimal  _feeselfpay;
        /// <summary>
        /// 个人自付2
        /// </summary>
        [Column(FieldName = "FeeSelfPay", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeSelfPay
        {
            get { return  _feeselfpay; }
            set {  _feeselfpay = value; }
        }

        private Decimal  _feebigpay;
        /// <summary>
        /// 门诊大额支付金额
        /// </summary>
        [Column(FieldName = "FeeBigPay", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeBigPay
        {
            get { return  _feebigpay; }
            set {  _feebigpay = value; }
        }

        private Decimal  _feebigselfpay;
        /// <summary>
        /// 门诊大额自付金额
        /// </summary>
        [Column(FieldName = "FeeBigSelfPay", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeBigSelfPay
        {
            get { return  _feebigselfpay; }
            set {  _feebigselfpay = value; }
        }

        private Decimal  _feeoutofpay;
        /// <summary>
        /// 超大额自付金额
        /// </summary>
        [Column(FieldName = "FeeOutOFPay", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FeeOutOFPay
        {
            get { return  _feeoutofpay; }
            set {  _feeoutofpay = value; }
        }

        private Decimal  _feebcbx;
        /// <summary>
        /// 补充保险支付金额
        /// </summary>
        [Column(FieldName = "Feebcbx", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Feebcbx
        {
            get { return  _feebcbx; }
            set {  _feebcbx = value; }
        }

        private Decimal  _feejcbz;
        /// <summary>
        /// 军残补助保险金额
        /// </summary>
        [Column(FieldName = "Feejcbz", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Feejcbz
        {
            get { return  _feejcbz; }
            set {  _feejcbz = value; }
        }

        private string  _applyno;
        /// <summary>
        /// 医保应用号
        /// </summary>
        [Column(FieldName = "ApplyNO", DataKey = false, Match = "", IsInsert = true)]
        public string ApplyNO
        {
            get { return  _applyno; }
            set {  _applyno = value; }
        }

        private string  _patientname;
        /// <summary>
        /// 患者姓名
        /// </summary>
        [Column(FieldName = "PatientName", DataKey = false, Match = "", IsInsert = true)]
        public string PatientName
        {
            get { return  _patientname; }
            set {  _patientname = value; }
        }

        private string  _medicaltype;
        /// <summary>
        /// 医疗类型
        /// </summary>
        [Column(FieldName = "MedicalType", DataKey = false, Match = "", IsInsert = true)]
        public string MedicalType
        {
            get { return  _medicaltype; }
            set {  _medicaltype = value; }
        }

        private int  _state;
        /// <summary>
        /// 状态:0-预算信息，1-结算信息，2取消信息
        /// </summary>
        [Column(FieldName = "state", DataKey = false, Match = "", IsInsert = true)]
        public int state
        {
            get { return  _state; }
            set {  _state = value; }
        }

        private string  _feeno;
        /// <summary>
        /// 收费单据号
        /// </summary>
        [Column(FieldName = "FeeNO", DataKey = false, Match = "", IsInsert = true)]
        public string FeeNO
        {
            get { return  _feeno; }
            set {  _feeno = value; }
        }

        private int  _tradetype;
        /// <summary>
        /// 交易类型 1:登记,2:收费
        /// </summary>
        [Column(FieldName = "TradeType", DataKey = false, Match = "", IsInsert = true)]
        public int TradeType
        {
            get { return  _tradetype; }
            set {  _tradetype = value; }
        }

        private int  _regid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegId", DataKey = false, Match = "", IsInsert = true)]
        public int RegId
        {
            get { return  _regid; }
            set {  _regid = value; }
        }

    }
}
