using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_DrugBillDetail", EntityType = EntityType.Table, IsGB = false)]
    public class IP_DrugBillDetail:AbstractEntity
    {
        private int  _billdetailid;
        /// <summary>
        /// 发药消息明细ID
        /// </summary>
        [Column(FieldName = "BillDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int BillDetailID
        {
            get { return  _billdetailid; }
            set {  _billdetailid = value; }
        }

        private int  _billheadid;
        /// <summary>
        /// 消息头表ID
        /// </summary>
        [Column(FieldName = "BillHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int BillHeadID
        {
            get { return  _billheadid; }
            set {  _billheadid = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 药品厂家典ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 药品化学名
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private string  _spec;
        /// <summary>
        /// 药品规格
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return  _spec; }
            set {  _spec = value; }
        }

        private string  _bedno;
        /// <summary>
        /// 床号
        /// </summary>
        [Column(FieldName = "BedNO", DataKey = false, Match = "", IsInsert = true)]
        public string BedNO
        {
            get { return  _bedno; }
            set {  _bedno = value; }
        }

        private Decimal  _serialnumber;
        /// <summary>
        /// 住院流水号
        /// </summary>
        [Column(FieldName = "SerialNumber", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SerialNumber
        {
            get { return  _serialnumber; }
            set {  _serialnumber = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 
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

        private int  _patdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDeptID
        {
            get { return  _patdeptid; }
            set {  _patdeptid = value; }
        }

        private int  _patdoctorid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDoctorID
        {
            get { return  _patdoctorid; }
            set {  _patdoctorid = value; }
        }

        private int  _amount;
        /// <summary>
        /// 数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public int Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private int  _doseamount;
        /// <summary>
        /// 处方帖数
        /// </summary>
        [Column(FieldName = "DoseAmount", DataKey = false, Match = "", IsInsert = true)]
        public int DoseAmount
        {
            get { return  _doseamount; }
            set {  _doseamount = value; }
        }

        private string  _unit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return  _unit; }
            set {  _unit = value; }
        }

        private Decimal  _packamount;
        /// <summary>
        /// 划价系数
        /// </summary>
        [Column(FieldName = "PackAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PackAmount
        {
            get { return  _packamount; }
            set {  _packamount = value; }
        }

        private string  _dosename;
        /// <summary>
        /// 药品剂型
        /// </summary>
        [Column(FieldName = "DoseName", DataKey = false, Match = "", IsInsert = true)]
        public string DoseName
        {
            get { return  _dosename; }
            set {  _dosename = value; }
        }

        private Decimal  _inprice;
        /// <summary>
        /// 批发价
        /// </summary>
        [Column(FieldName = "InPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal InPrice
        {
            get { return  _inprice; }
            set {  _inprice = value; }
        }

        private Decimal  _sellprice;
        /// <summary>
        /// 销售价
        /// </summary>
        [Column(FieldName = "SellPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SellPrice
        {
            get { return  _sellprice; }
            set {  _sellprice = value; }
        }

        private Decimal _stockFee;
        /// <summary>
        /// 批发金额
        /// </summary>
        [Column(FieldName = "StockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RETAILFEE
        {
            get { return _stockFee; }
            set { _stockFee = value; }
        }

        private Decimal  _sellfee;
        /// <summary>
        /// 零售金额
        /// </summary>
        [Column(FieldName = "SellFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SellFee
        {
            get { return  _sellfee; }
            set {  _sellfee = value; }
        }

        private int  _feerecordid;
        /// <summary>
        /// 处方明细ID
        /// </summary>
        [Column(FieldName = "FeeRecordID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeRecordID
        {
            get { return  _feerecordid; }
            set {  _feerecordid = value; }
        }

        private int  _costempid;
        /// <summary>
        /// 记账员ID
        /// </summary>
        [Column(FieldName = "CostEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int CostEmpID
        {
            get { return  _costempid; }
            set {  _costempid = value; }
        }

        private DateTime  _costdate;
        /// <summary>
        /// 记账时间
        /// </summary>
        [Column(FieldName = "CostDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CostDate
        {
            get { return  _costdate; }
            set {  _costdate = value; }
        }

        private int  _ordertype;
        /// <summary>
        /// 医嘱类型
        /// </summary>
        [Column(FieldName = "OrderType", DataKey = false, Match = "", IsInsert = true)]
        public int OrderType
        {
            get { return  _ordertype; }
            set {  _ordertype = value; }
        }

        private int  _orderid;
        /// <summary>
        /// 住院医嘱编号
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public int OrderID
        {
            get { return  _orderid; }
            set {  _orderid = value; }
        }

        private int  _ordergroupid;
        /// <summary>
        /// 医嘱组号
        /// </summary>
        [Column(FieldName = "OrderGroupID", DataKey = false, Match = "", IsInsert = true)]
        public int OrderGroupID
        {
            get { return  _ordergroupid; }
            set {  _ordergroupid = value; }
        }

        private int  _dispdrugflag;
        /// <summary>
        /// 发药标识
        /// </summary>
        [Column(FieldName = "DispDrugFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DispDrugFlag
        {
            get { return  _dispdrugflag; }
            set {  _dispdrugflag = value; }
        }
        private int _dispHeadID;
        /// <summary>
        /// 发药头ID
        /// </summary>
        [Column(FieldName = "DispHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int DispHeadID
        {
            get { return _dispHeadID; }
            set { _dispHeadID = value; }
        }
        
        private int  _nodrugflag;
        /// <summary>
        /// 缺药标识
        /// </summary>
        [Column(FieldName = "NoDrugFlag", DataKey = false, Match = "", IsInsert = true)]
        public int NoDrugFlag
        {
            get { return  _nodrugflag; }
            set {  _nodrugflag = value; }
        }

        private int  _specdicid;
        /// <summary>
        /// 药品规格典ID
        /// </summary>
        [Column(FieldName = "SpecDicID", DataKey = false, Match = "", IsInsert = true)]
        public int SpecDicID
        {
            get { return  _specdicid; }
            set {  _specdicid = value; }
        }

    }
}
