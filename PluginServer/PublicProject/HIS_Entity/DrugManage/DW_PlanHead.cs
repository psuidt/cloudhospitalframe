using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DW_PlanHead", EntityType = EntityType.Table, IsGB = false)]
    public class DW_PlanHead:AbstractEntity
    {
        private int  _planheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PlanHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int PlanHeadID
        {
            get { return  _planheadid; }
            set {  _planheadid = value; }
        }

        private DateTime  _regtime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegTime
        {
            get { return  _regtime; }
            set {  _regtime = value; }
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

        private int  _regempid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
        }

        private Decimal  _retailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailFee
        {
            get { return  _retailfee; }
            set {  _retailfee = value; }
        }

        private Decimal  _stockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockFee
        {
            get { return  _stockfee; }
            set {  _stockfee = value; }
        }

        private DateTime  _updatetime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _auditflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditFlag", DataKey = false, Match = "", IsInsert = true)]
        public int AuditFlag
        {
            get { return  _auditflag; }
            set {  _auditflag = value; }
        }

        private DateTime  _audittime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AuditTime
        {
            get { return  _audittime; }
            set {  _audittime = value; }
        }

        private int  _auditempid;
        /// <summary>
        /// 
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

        private DateTime planDate;
        
        /// <summary>
        /// 计划日期
        /// </summary>
        [Column(FieldName = "PlanDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PlanDate
        {
            get { return planDate; }
            set { planDate = value; }
        }
    }
}
