using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_InstoreHead", EntityType = EntityType.Table, IsGB = false)]
    public class DS_InstoreHead:AbstractEntity
    {
        private int  _inheadid;
        /// <summary>
        /// 入库表头标识ID
        /// </summary>
        [Column(FieldName = "InHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int InHeadID
        {
            get { return  _inheadid; }
            set {  _inheadid = value; }
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

        private int  _opempid;
        /// <summary>
        /// 经手人标识ID
        /// </summary>
        [Column(FieldName = "OpEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int OpEmpID
        {
            get { return  _opempid; }
            set {  _opempid = value; }
        }

        private string  _opempname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OpEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string OpEmpName
        {
            get { return  _opempname; }
            set {  _opempname = value; }
        }

        private int  _auditflag;
        /// <summary>
        /// 审核标志
        /// </summary>
        [Column(FieldName = "AuditFlag", DataKey = false, Match = "", IsInsert = true)]
        public int AuditFlag
        {
            get { return  _auditflag; }
            set {  _auditflag = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
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

        private DateTime  _audittime;
        /// <summary>
        /// 审核时间
        /// </summary>
        [Column(FieldName = "AuditTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AuditTime
        {
            get { return  _audittime; }
            set {  _audittime = value; }
        }

        private int  _auditempid;
        /// <summary>
        /// 审核人员标识ID
        /// </summary>
        [Column(FieldName = "AuditEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int AuditEmpID
        {
            get { return  _auditempid; }
            set {  _auditempid = value; }
        }

        private string  _auditempname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string AuditEmpName
        {
            get { return  _auditempname; }
            set {  _auditempname = value; }
        }

        private DateTime  _regtime;
        /// <summary>
        /// 登记时间
        /// </summary>
        [Column(FieldName = "RegTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegTime
        {
            get { return  _regtime; }
            set {  _regtime = value; }
        }

        private int  _regempid;
        /// <summary>
        /// 登记人员标识ID
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
        }

        private string  _regempname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string RegEmpName
        {
            get { return  _regempname; }
            set {  _regempname = value; }
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

        private string  _invoiceno;
        /// <summary>
        /// 发票号
        /// </summary>
        [Column(FieldName = "InvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNO
        {
            get { return  _invoiceno; }
            set {  _invoiceno = value; }
        }

        private DateTime  _invoicedate;
        /// <summary>
        /// 发票日期
        /// </summary>
        [Column(FieldName = "InvoiceDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime InvoiceDate
        {
            get { return  _invoicedate; }
            set {  _invoicedate = value; }
        }

        private DateTime  _billtime;
        /// <summary>
        /// 单据日期
        /// </summary>
        [Column(FieldName = "BillTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime BillTime
        {
            get { return  _billtime; }
            set {  _billtime = value; }
        }

        private int  _supplierid;
        /// <summary>
        /// 供应商标识ID
        /// </summary>
        [Column(FieldName = "SupplierID", DataKey = false, Match = "", IsInsert = true)]
        public int SupplierID
        {
            get { return  _supplierid; }
            set {  _supplierid = value; }
        }

        private string  _suppliername;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "SupplierName", DataKey = false, Match = "", IsInsert = true)]
        public string SupplierName
        {
            get { return  _suppliername; }
            set {  _suppliername = value; }
        }

        private string  _deliveryno;
        /// <summary>
        /// 送货单号
        /// </summary>
        [Column(FieldName = "DeliveryNO", DataKey = false, Match = "", IsInsert = true)]
        public string DeliveryNO
        {
            get { return  _deliveryno; }
            set {  _deliveryno = value; }
        }

        private int  _payflag;
        /// <summary>
        /// 付款标识
        /// </summary>
        [Column(FieldName = "PayFlag", DataKey = false, Match = "", IsInsert = true)]
        public int PayFlag
        {
            get { return  _payflag; }
            set {  _payflag = value; }
        }

        private int  _payrecordid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayRecordID", DataKey = false, Match = "", IsInsert = true)]
        public int PayRecordID
        {
            get { return  _payrecordid; }
            set {  _payrecordid = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 对应部门ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        /// <summary>
        /// 对应出库单的表头ID
        /// </summary>
        [Column(FieldName = "OutStoreHeadID ", DataKey = false, Match = "", IsInsert = true)]
        public int OutStoreHeadID { set; get; }
    }
}
