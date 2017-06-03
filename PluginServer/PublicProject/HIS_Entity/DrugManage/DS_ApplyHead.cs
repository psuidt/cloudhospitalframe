using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_ApplyHead", EntityType = EntityType.Table, IsGB = false)]
    public class DS_ApplyHead:AbstractEntity
    {
        private int  _applyheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ApplyHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int ApplyHeadID
        {
            get { return  _applyheadid; }
            set {  _applyheadid = value; }
        }

        private int  _outstoreheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OutStoreHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int OutStoreHeadID
        {
            get { return  _outstoreheadid; }
            set {  _outstoreheadid = value; }
        }

        private long  _relationno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RelationNO", DataKey = false, Match = "", IsInsert = true)]
        public long RelationNO
        {
            get { return  _relationno; }
            set {  _relationno = value; }
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

        private int  _applydeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ApplyDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyDeptID
        {
            get { return  _applydeptid; }
            set {  _applydeptid = value; }
        }

        private int  _todeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ToDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ToDeptID
        {
            get { return  _todeptid; }
            set {  _todeptid = value; }
        }

        private string  _applydeptname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ApplyDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string ApplyDeptName
        {
            get { return  _applydeptname; }
            set {  _applydeptname = value; }
        }

        private string _todeptname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ToDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string ToDeptName
        {
            get { return  _todeptname; }
            set {  _todeptname = value; }
        }

        private long  _billno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BillNO", DataKey = false, Match = "", IsInsert = true)]
        public long BillNO
        {
            get { return  _billno; }
            set {  _billno = value; }
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

    }
}
