using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_CostDetail", EntityType = EntityType.Table, IsGB = false)]
    public class IP_CostDetail:AbstractEntity
    {
        private int  _costdetailid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CostDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int CostDetailID
        {
            get { return  _costdetailid; }
            set {  _costdetailid = value; }
        }

        private int  _costheadid;
        /// <summary>
        /// 结算ID
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人列表ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 病人名称
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 病人科室
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _doctorid;
        /// <summary>
        /// 病人医生
        /// </summary>
        [Column(FieldName = "DoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int DoctorID
        {
            get { return  _doctorid; }
            set {  _doctorid = value; }
        }

        private int  _execdeptid;
        /// <summary>
        /// 执行科室
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return  _execdeptid; }
            set {  _execdeptid = value; }
        }

        private int  _invoiceid;
        /// <summary>
        /// 发票ID
        /// </summary>
        [Column(FieldName = "InvoiceID", DataKey = false, Match = "", IsInsert = true)]
        public int InvoiceID
        {
            get { return  _invoiceid; }
            set {  _invoiceid = value; }
        }

        private string  _invoiceno;
        /// <summary>
        /// 票据号
        /// </summary>
        [Column(FieldName = "InvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNO
        {
            get { return  _invoiceno; }
            set {  _invoiceno = value; }
        }

        private int  _statid;
        /// <summary>
        /// 大项目ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 金额
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
        }

    }
}
