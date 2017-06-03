using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DW_OutStoreDetail", EntityType = EntityType.Table, IsGB = false)]
    public class DW_OutStoreDetail:AbstractEntity
    {
        private int  _outdetailid;
        /// <summary>
        /// 出库明细标识ID
        /// </summary>
        [Column(FieldName = "OutDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int OutDetailID
        {
            get { return  _outdetailid; }
            set {  _outdetailid = value; }
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
        /// 药品厂家典标识ID
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
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

        private Decimal  _amount;
        /// <summary>
        /// 出库数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
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

        private string  _lostreason;
        /// <summary>
        /// 报损原因
        /// </summary>
        [Column(FieldName = "LostReason", DataKey = false, Match = "", IsInsert = true)]
        public string LostReason
        {
            get { return  _lostreason; }
            set {  _lostreason = value; }
        }

        private int  _todeptid;
        /// <summary>
        /// 出库部门ID
        /// </summary>
        [Column(FieldName = "ToDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ToDeptID
        {
            get { return  _todeptid; }
            set {  _todeptid = value; }
        }

        private int  _outheadid;
        /// <summary>
        /// 出库表头标识ID
        /// </summary>
        [Column(FieldName = "OutHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int OutHeadID
        {
            get { return  _outheadid; }
            set {  _outheadid = value; }
        }

        private int  _instoredetailid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "InStoreDetailID", DataKey = false, Match = "", IsInsert = true)]
        public int InStoreDetailID
        {
            get { return  _instoredetailid; }
            set {  _instoredetailid = value; }
        }

        private int  _unitdicid;
        /// <summary>
        /// 药品单位标识ID
        /// </summary>
        [Column(FieldName = "UnitDicID", DataKey = false, Match = "", IsInsert = true)]
        public int UnitDicID
        {
            get { return  _unitdicid; }
            set {  _unitdicid = value; }
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

    }
}
