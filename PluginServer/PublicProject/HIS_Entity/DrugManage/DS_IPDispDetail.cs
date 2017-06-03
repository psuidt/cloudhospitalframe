using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_IPDispDetail", EntityType = EntityType.Table, IsGB = false)]
    public class DS_IPDispDetail:AbstractEntity
    {
        private int  _dispdetailid;
        /// <summary>
        /// 发/退药明细ID
        /// </summary>
        [Column(FieldName = "DispDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int DispDetailID
        {
            get { return  _dispdetailid; }
            set {  _dispdetailid = value; }
        }

        private int  _dispheadid;
        /// <summary>
        /// 发/退药表头标识ID
        /// </summary>
        [Column(FieldName = "DispHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int DispHeadID
        {
            get { return  _dispheadid; }
            set {  _dispheadid = value; }
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

        private int  _drugspecid;
        /// <summary>
        /// 规格典标识ID
        /// </summary>
        [Column(FieldName = "DrugSpecID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugSpecID
        {
            get { return  _drugspecid; }
            set {  _drugspecid = value; }
        }

        private string  _chemname;
        /// <summary>
        /// 化学名称
        /// </summary>
        [Column(FieldName = "ChemName", DataKey = false, Match = "", IsInsert = true)]
        public string ChemName
        {
            get { return  _chemname; }
            set {  _chemname = value; }
        }

        private string  _drugspec;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DrugSpec", DataKey = false, Match = "", IsInsert = true)]
        public string DrugSpec
        {
            get { return  _drugspec; }
            set {  _drugspec = value; }
        }

        private string _productName;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ProductName", DataKey = false, Match = "", IsInsert = true)]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
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

        private int  _unitamount;
        /// <summary>
        /// 单位数量
        /// </summary>
        [Column(FieldName = "UnitAmount", DataKey = false, Match = "", IsInsert = true)]
        public int UnitAmount
        {
            get { return  _unitamount; }
            set {  _unitamount = value; }
        }

        private Decimal  _dispamount;
        /// <summary>
        /// 发/退药数量
        /// </summary>
        [Column(FieldName = "DispAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DispAmount
        {
            get { return  _dispamount; }
            set {  _dispamount = value; }
        }

        private int  _dosage;
        /// <summary>
        /// 发/退药剂数
        /// </summary>
        [Column(FieldName = "Dosage", DataKey = false, Match = "", IsInsert = true)]
        public int Dosage
        {
            get { return  _dosage; }
            set {  _dosage = value; }
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

        private Decimal  _stockfee;
        /// <summary>
        /// 批发金额
        /// </summary>
        [Column(FieldName = "StockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockFee
        {
            get { return  _stockfee; }
            set {  _stockfee = value; }
        }

        private int  _feelid;
        /// <summary>
        /// 处方明细标识ID
        /// </summary>
        [Column(FieldName = "FeelID", DataKey = false, Match = "", IsInsert = true)]
        public int FeelID
        {
            get { return  _feelid; }
            set {  _feelid = value; }
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

        private int  _chargerid;
        /// <summary>
        /// 收款人
        /// </summary>
        [Column(FieldName = "ChargerID", DataKey = false, Match = "", IsInsert = true)]
        public int ChargerID
        {
            get { return  _chargerid; }
            set {  _chargerid = value; }
        }

        private int  _msgheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MsgHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int MsgHeadID
        {
            get { return  _msgheadid; }
            set {  _msgheadid = value; }
        }

        private int  _msgdetaillid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MsgDetaillID", DataKey = false, Match = "", IsInsert = true)]
        public int MsgDetaillID
        {
            get { return  _msgdetaillid; }
            set {  _msgdetaillid = value; }
        }

        private int  _groupno;
        /// <summary>
        /// 处方号
        /// </summary>
        [Column(FieldName = "GroupNO", DataKey = false, Match = "", IsInsert = true)]
        public int GroupNO
        {
            get { return  _groupno; }
            set {  _groupno = value; }
        }

        private string  _inpatientno;
        /// <summary>
        /// 住院号
        /// </summary>
        [Column(FieldName = "InpatientNO", DataKey = false, Match = "", IsInsert = true)]
        public string InpatientNO
        {
            get { return  _inpatientno; }
            set {  _inpatientno = value; }
        }

        private int  _inpatientid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "InPatientID", DataKey = false, Match = "", IsInsert = true)]
        public int InPatientID
        {
            get { return  _inpatientid; }
            set {  _inpatientid = value; }
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

        private string  _bedno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BedNo", DataKey = false, Match = "", IsInsert = true)]
        public string BedNo
        {
            get { return  _bedno; }
            set {  _bedno = value; }
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

        private Decimal  _useamount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal UseAmount
        {
            get { return  _useamount; }
            set {  _useamount = value; }
        }

        private string  _useway;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseWay", DataKey = false, Match = "", IsInsert = true)]
        public string UseWay
        {
            get { return  _useway; }
            set {  _useway = value; }
        }

        private string  _frequency;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Frequency", DataKey = false, Match = "", IsInsert = true)]
        public string Frequency
        {
            get { return  _frequency; }
            set {  _frequency = value; }
        }

        private string  _useunit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseUnit", DataKey = false, Match = "", IsInsert = true)]
        public string UseUnit
        {
            get { return  _useunit; }
            set {  _useunit = value; }
        }

        private string  _packunit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PackUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnit
        {
            get { return  _packunit; }
            set {  _packunit = value; }
        }

        private string  _orders;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Orders", DataKey = false, Match = "", IsInsert = true)]
        public string Orders
        {
            get { return _orders; }
            set { _orders = value; }
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

        private int _retflag;
        /// <summary>
        /// 发/退药标识
        /// </summary>
        [Column(FieldName = "RetFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RetFlag
        {
            get { return _retflag; }
            set { _retflag = value; }
        }
    }
}
