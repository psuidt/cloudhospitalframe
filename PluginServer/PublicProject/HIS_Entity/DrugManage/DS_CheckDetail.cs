using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_CheckDetail", EntityType = EntityType.Table, IsGB = false)]
    public class DS_CheckDetail:AbstractEntity
    {
        private int  _checkdetailid;
        /// <summary>
        /// 盘点明细标识ID
        /// </summary>
        [Column(FieldName = "CheckDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int CheckDetailID
        {
            get { return  _checkdetailid; }
            set {  _checkdetailid = value; }
        }

        private int  _storageid;
        /// <summary>
        /// 库存ID
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

        private int  _auditflag;
        /// <summary>
        /// 审核标识
        /// </summary>
        [Column(FieldName = "AuditFlag", DataKey = false, Match = "", IsInsert = true)]
        public int AuditFlag
        {
            get { return  _auditflag; }
            set {  _auditflag = value; }
        }

        private DateTime  _billtime;
        /// <summary>
        /// 单据时间
        /// </summary>
        [Column(FieldName = "BillTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime BillTime
        {
            get { return  _billtime; }
            set {  _billtime = value; }
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

        private int  _checkheadid;
        /// <summary>
        /// 盘点表头标识ID
        /// </summary>
        [Column(FieldName = "CheckHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CheckHeadID
        {
            get { return  _checkheadid; }
            set {  _checkheadid = value; }
        }

    }
}
