using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_InStoreDetail", EntityType = EntityType.Table, IsGB = false)]
    public class MW_InStoreDetail:AbstractEntity
    {
        private int  _indetailid;
        /// <summary>
        /// 入库明细标识ID
        /// </summary>
        [Column(FieldName = "InDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int InDetailID
        {
            get { return  _indetailid; }
            set {  _indetailid = value; }
        }

        private int  _inheadid;
        /// <summary>
        /// 入库表头标识ID
        /// </summary>
        [Column(FieldName = "InHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int InHeadID
        {
            get { return  _inheadid; }
            set {  _inheadid = value; }
        }

        private string  _batchno;
        /// <summary>
        /// 生产批号
        /// </summary>
        [Column(FieldName = "BatchNo", DataKey = false, Match = "", IsInsert = true)]
        public string BatchNo
        {
            get { return  _batchno; }
            set {  _batchno = value; }
        }

        private DateTime  _validitydate;
        /// <summary>
        /// 到效日期
        /// </summary>
        [Column(FieldName = "ValidityDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ValidityDate
        {
            get { return  _validitydate; }
            set {  _validitydate = value; }
        }

        private Decimal  _amount;
        /// <summary>
        /// 入库数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
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

        private Decimal  _stockprice;
        /// <summary>
        /// 进价
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
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

        private Decimal  _stockfee;
        /// <summary>
        /// 进货金额
        /// </summary>
        [Column(FieldName = "StockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockFee
        {
            get { return  _stockfee; }
            set {  _stockfee = value; }
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

        private long  _billno;
        /// <summary>
        /// 单据号
        /// </summary>
        [Column(FieldName = "BillNo", DataKey = false, Match = "", IsInsert = true)]
        public long BillNo
        {
            get { return  _billno; }
            set {  _billno = value; }
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

        private string  _remark;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

    }
}
