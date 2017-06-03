using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPNurse
{
    [Serializable]
    [Table(TableName = "IPN_OrderExecBillRecord", EntityType = EntityType.Table, IsGB = false)]
    public class IPN_OrderExecBillRecord:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 执行记录ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _recordid;
        /// <summary>
        /// 执行记录ID
        /// </summary>
        [Column(FieldName = "RecordID", DataKey = false, Match = "", IsInsert = true)]
        public int RecordID
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

        private int  _ordercategory;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OrderCategory", DataKey = false, Match = "", IsInsert = true)]
        public int OrderCategory
        {
            get { return  _ordercategory; }
            set {  _ordercategory = value; }
        }

        private int  _groupid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GroupID", DataKey = false, Match = "", IsInsert = true)]
        public int GroupID
        {
            get { return  _groupid; }
            set {  _groupid = value; }
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

        private string  _ordername;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OrderName", DataKey = false, Match = "", IsInsert = true)]
        public string OrderName
        {
            get { return  _ordername; }
            set {  _ordername = value; }
        }

        private int  _presdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return  _presdeptid; }
            set {  _presdeptid = value; }
        }

        private int  _presdoctorid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PresDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDoctorID
        {
            get { return  _presdoctorid; }
            set {  _presdoctorid = value; }
        }

        private string  _spec;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return  _spec; }
            set {  _spec = value; }
        }

        private Decimal  _dosage;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Dosage", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Dosage
        {
            get { return  _dosage; }
            set {  _dosage = value; }
        }

        private string  _unit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return  _unit; }
            set {  _unit = value; }
        }

        private int  _channelid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ChannelID", DataKey = false, Match = "", IsInsert = true)]
        public int ChannelID
        {
            get { return  _channelid; }
            set {  _channelid = value; }
        }

        private int  _frenquencyid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FrenquencyID", DataKey = false, Match = "", IsInsert = true)]
        public int FrenquencyID
        {
            get { return  _frenquencyid; }
            set {  _frenquencyid = value; }
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
