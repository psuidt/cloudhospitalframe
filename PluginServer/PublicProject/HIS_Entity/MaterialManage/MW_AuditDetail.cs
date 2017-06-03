using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_AuditDetail", EntityType = EntityType.Table, IsGB = false)]
    public class MW_AuditDetail:AbstractEntity
    {
        private int  _auditdetailid;
        /// <summary>
        /// 盘点明细标识ID
        /// </summary>
        [Column(FieldName = "AuditDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int AuditDetailID
        {
            get { return  _auditdetailid; }
            set {  _auditdetailid = value; }
        }

        private int  _storageid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StorageID", DataKey = false, Match = "", IsInsert = true)]
        public int StorageID
        {
            get { return  _storageid; }
            set {  _storageid = value; }
        }

        private string  _place;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Place", DataKey = false, Match = "", IsInsert = true)]
        public string Place
        {
            get { return  _place; }
            set {  _place = value; }
        }

        private string  _batchno;
        /// <summary>
        /// 生产批号
        /// </summary>
        [Column(FieldName = "BatchNO", DataKey = false, Match = "", IsInsert = true)]
        public string BatchNO
        {
            get { return  _batchno; }
            set {  _batchno = value; }
        }

        private DateTime  _validitydate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ValidityDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ValidityDate
        {
            get { return  _validitydate; }
            set {  _validitydate = value; }
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

        private Decimal  _factamount;
        /// <summary>
        /// 盘存数量
        /// </summary>
        [Column(FieldName = "FactAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FactAmount
        {
            get { return  _factamount; }
            set {  _factamount = value; }
        }

        private Decimal  _factstockfee;
        /// <summary>
        /// 盘存批发金额
        /// </summary>
        [Column(FieldName = "FactStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FactStockFee
        {
            get { return  _factstockfee; }
            set {  _factstockfee = value; }
        }

        private Decimal  _factretailfee;
        /// <summary>
        /// 盘存零售金额
        /// </summary>
        [Column(FieldName = "FactRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FactRetailFee
        {
            get { return  _factretailfee; }
            set {  _factretailfee = value; }
        }

        private Decimal  _actamount;
        /// <summary>
        /// 帐存数量
        /// </summary>
        [Column(FieldName = "ActAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ActAmount
        {
            get { return  _actamount; }
            set {  _actamount = value; }
        }

        private Decimal  _actstockfee;
        /// <summary>
        /// 帐存批发金额
        /// </summary>
        [Column(FieldName = "ActStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ActStockFee
        {
            get { return  _actstockfee; }
            set {  _actstockfee = value; }
        }

        private Decimal  _actretailfee;
        /// <summary>
        /// 帐存零售金额
        /// </summary>
        [Column(FieldName = "ActRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ActRetailFee
        {
            get { return  _actretailfee; }
            set {  _actretailfee = value; }
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

        private int  _auditheadid;
        /// <summary>
        /// 盘点表头标识ID
        /// </summary>
        [Column(FieldName = "AuditHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int AuditHeadID
        {
            get { return  _auditheadid; }
            set {  _auditheadid = value; }
        }

        private int  _materialid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MaterialID", DataKey = false, Match = "", IsInsert = true)]
        public int MaterialID
        {
            get { return  _materialid; }
            set {  _materialid = value; }
        }

    }
}
