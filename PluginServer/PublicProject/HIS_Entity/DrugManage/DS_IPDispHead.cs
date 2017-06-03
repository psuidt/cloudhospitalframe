using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_IPDispHead", EntityType = EntityType.Table, IsGB = false)]
    public class DS_IPDispHead:AbstractEntity
    {
        private int  _dispheadid;
        /// <summary>
        /// 发/退药表头标识ID
        /// </summary>
        [Column(FieldName = "DispHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int DispHeadID
        {
            get { return  _dispheadid; }
            set {  _dispheadid = value; }
        }

        private long _billno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BillNO", DataKey = false, Match = "", IsInsert = true)]
        public long BillNO
        {
            get { return  _billno; }
            set {  _billno = value; }
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

        private int  _dispenserid;
        /// <summary>
        /// 配药人
        /// </summary>
        [Column(FieldName = "DispenserID", DataKey = false, Match = "", IsInsert = true)]
        public int DispenserID
        {
            get { return  _dispenserid; }
            set {  _dispenserid = value; }
        }

        private int  _pharmacistid;
        /// <summary>
        /// 发/退药人
        /// </summary>
        [Column(FieldName = "PharmacistID", DataKey = false, Match = "", IsInsert = true)]
        public int PharmacistID
        {
            get { return  _pharmacistid; }
            set {  _pharmacistid = value; }
        }

        private DateTime  _disptime;
        /// <summary>
        /// 发/退药时间
        /// </summary>
        [Column(FieldName = "DispTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime DispTime
        {
            get { return  _disptime; }
            set {  _disptime = value; }
        }

        private int  _refflag;
        /// <summary>
        /// 发/退药标识
        /// </summary>
        [Column(FieldName = "RefFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RefFlag
        {
            get { return  _refflag; }
            set {  _refflag = value; }
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
        /// 科室ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int _execDeptID;
        /// <summary>
        /// 药房ID
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return _execDeptID; }
            set { _execDeptID = value; }
        }

        private int _billTypeID;
        /// <summary>
        /// 统领单类型Id
        /// </summary>
        [Column(FieldName = "BillTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int BillTypeID
        {
            get { return _billTypeID; }
            set { _billTypeID = value; }
        }

    }
}
