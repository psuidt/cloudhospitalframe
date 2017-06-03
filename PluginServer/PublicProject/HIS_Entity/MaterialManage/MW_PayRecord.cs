using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_PayRecord", EntityType = EntityType.Table, IsGB = true)]
    public class MW_PayRecord:AbstractEntity
    {
        private int  _payrecordid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayRecordID", DataKey = true, Match = "", IsInsert = false)]
        public int PayRecordID
        {
            get { return  _payrecordid; }
            set {  _payrecordid = value; }
        }

        private DateTime  _paytime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PayTime
        {
            get { return  _paytime; }
            set {  _paytime = value; }
        }

        private string  _payempname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string PayEmpName
        {
            get { return  _payempname; }
            set {  _payempname = value; }
        }

        private int  _payempid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int PayEmpID
        {
            get { return  _payempid; }
            set {  _payempid = value; }
        }

        private string  _remark;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
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

        private int  _supportname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "SupportName", DataKey = false, Match = "", IsInsert = true)]
        public int SupportName
        {
            get { return  _supportname; }
            set {  _supportname = value; }
        }

        private Decimal  _totalretailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "TotalRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalRetailFee
        {
            get { return  _totalretailfee; }
            set {  _totalretailfee = value; }
        }

        private Decimal  _totalstockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "TotalStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalStockFee
        {
            get { return  _totalstockfee; }
            set {  _totalstockfee = value; }
        }

        private int  _paydeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PayDeptID
        {
            get { return  _paydeptid; }
            set {  _paydeptid = value; }
        }

    }
}
