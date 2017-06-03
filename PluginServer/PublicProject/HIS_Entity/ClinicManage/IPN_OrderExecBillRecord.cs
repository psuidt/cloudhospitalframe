using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "IPN_OrderExecBillRecord", EntityType = EntityType.Table, IsGB = false)]
    public class IPN_OrderExecBillRecord:AbstractEntity
    {
        private long  _recordid;
        /// <summary>
        /// 执行记录ID
        /// </summary>
        [Column(FieldName = "RecordID", DataKey = true, Match = "", IsInsert = false)]
        public long RecordID
        {
            get { return  _recordid; }
            set {  _recordid = value; }
        }

        private int  _exebilltypeid;
        /// <summary>
        /// 执行单类型
        /// </summary>
        [Column(FieldName = "ExeBillTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int ExeBillTypeID
        {
            get { return  _exebilltypeid; }
            set {  _exebilltypeid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private long  _orderid;
        /// <summary>
        /// 医嘱ID
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public long OrderID
        {
            get { return  _orderid; }
            set {  _orderid = value; }
        }

        private DateTime  _execdate;
        /// <summary>
        /// 执行日期
        /// </summary>
        [Column(FieldName = "ExecDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ExecDate
        {
            get { return  _execdate; }
            set {  _execdate = value; }
        }

        private int  _printempid;
        /// <summary>
        /// 打印人ID
        /// </summary>
        [Column(FieldName = "PrintEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int PrintEmpID
        {
            get { return  _printempid; }
            set {  _printempid = value; }
        }

        private DateTime  _printdate;
        /// <summary>
        /// 打印时间
        /// </summary>
        [Column(FieldName = "PrintDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PrintDate
        {
            get { return  _printdate; }
            set {  _printdate = value; }
        }

    }
}
