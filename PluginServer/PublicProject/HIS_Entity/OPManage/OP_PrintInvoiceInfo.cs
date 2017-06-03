using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_PrintInvoiceInfo", EntityType = EntityType.Table, IsGB = false)]
    public class OP_PrintInvoiceInfo:AbstractEntity
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

        private int  _feeitemheadid;
        /// <summary>
        /// 对应费用头ＩＤ
        /// </summary>
        [Column(FieldName = "FeeItemHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeItemHeadID
        {
            get { return  _feeitemheadid; }
            set {  _feeitemheadid = value; }
        }

        private string  _oldinvoicenumber;
        /// <summary>
        /// 原票据号
        /// </summary>
        [Column(FieldName = "OldInvoiceNumber", DataKey = false, Match = "", IsInsert = true)]
        public string OldInvoiceNumber
        {
            get { return  _oldinvoicenumber; }
            set {  _oldinvoicenumber = value; }
        }

        private string  _newinvoicenumber;
        /// <summary>
        /// 新票据号
        /// </summary>
        [Column(FieldName = "NewInvoiceNumber", DataKey = false, Match = "", IsInsert = true)]
        public string NewInvoiceNumber
        {
            get { return  _newinvoicenumber; }
            set {  _newinvoicenumber = value; }
        }

        private DateTime  _printdate;
        /// <summary>
        /// 打印日期
        /// </summary>
        [Column(FieldName = "PrintDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PrintDate
        {
            get { return  _printdate; }
            set {  _printdate = value; }
        }

        private int  _printempid;
        /// <summary>
        /// 打印人员
        /// </summary>
        [Column(FieldName = "PrintEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int PrintEmpID
        {
            get { return  _printempid; }
            set {  _printempid = value; }
        }

        private Decimal  _invoicefee;
        /// <summary>
        /// 票据金额
        /// </summary>
        [Column(FieldName = "InvoiceFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal InvoiceFee
        {
            get { return  _invoicefee; }
            set {  _invoicefee = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 就诊ＩＤ
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

        private int  _printtype;
        /// <summary>
        /// 0发票打印　　１票据补打
        /// </summary>
        [Column(FieldName = "PrintType", DataKey = false, Match = "", IsInsert = true)]
        public int PrintType
        {
            get { return  _printtype; }
            set {  _printtype = value; }
        }
        private int _costheadid;
        /// <summary>
        ///结算ID
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return _costheadid; }
            set { _costheadid = value; }
        }

    }
}
