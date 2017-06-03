using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_AdjHead", EntityType = EntityType.Table, IsGB = false)]
    public class DG_AdjHead:AbstractEntity
    {
        private int  _adjheadid;
        /// <summary>
        /// 调价表头标识ID
        /// </summary>
        [Column(FieldName = "AdjHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int AdjHeadID
        {
            get { return  _adjheadid; }
            set {  _adjheadid = value; }
        }

        private long  _billno;
        /// <summary>
        /// 单据号码
        /// </summary>
        [Column(FieldName = "BillNO", DataKey = false, Match = "", IsInsert = true)]
        public long BillNO
        {
            get { return  _billno; }
            set {  _billno = value; }
        }

        private int  _regempid;
        /// <summary>
        /// 登记人员
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
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

        private string  _adjcode;
        /// <summary>
        /// 调价文号
        /// </summary>
        [Column(FieldName = "AdjCode", DataKey = false, Match = "", IsInsert = true)]
        public string AdjCode
        {
            get { return  _adjcode; }
            set {  _adjcode = value; }
        }

        private DateTime  _exectime;
        /// <summary>
        /// 调价执行日期
        /// </summary>
        [Column(FieldName = "ExecTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ExecTime
        {
            get { return  _exectime; }
            set {  _exectime = value; }
        }

        private int  _execflag;
        /// <summary>
        /// 调价完成标识
        /// </summary>
        [Column(FieldName = "ExecFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ExecFlag
        {
            get { return  _execflag; }
            set {  _execflag = value; }
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
