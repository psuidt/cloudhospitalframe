using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_PlanHead", EntityType = EntityType.Table, IsGB = false)]
    public class MW_PlanHead:AbstractEntity
    {
        private int  _planheadid;
        /// <summary>
        /// 计划头表ID
        /// </summary>
        [Column(FieldName = "PlanHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int PlanHeadID
        {
            get { return  _planheadid; }
            set {  _planheadid = value; }
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

        private DateTime  _audittime;
        /// <summary>
        /// 审核日期
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
        /// 审核人员姓名
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

        private string  _regempname;
        /// <summary>
        /// 登记人员名称
        /// </summary>
        [Column(FieldName = "RegEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string RegEmpName
        {
            get { return  _regempname; }
            set {  _regempname = value; }
        }

        private int  _regempid;
        /// <summary>
        /// 登记人ID
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
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

        private DateTime  _updatetime;
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 科室ID
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
