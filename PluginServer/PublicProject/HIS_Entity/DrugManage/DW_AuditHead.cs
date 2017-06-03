using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DW_AuditHead", EntityType = EntityType.Table, IsGB = false)]
    public class DW_AuditHead:AbstractEntity
    {
        private int  _auditheadid;
        /// <summary>
        /// 盘点表头标识ID
        /// </summary>
        [Column(FieldName = "AuditHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int AuditHeadID
        {
            get { return  _auditheadid; }
            set {  _auditheadid = value; }
        }

        private long  _billno;
        /// <summary>
        /// 单据号
        /// </summary>
        [Column(FieldName = "BillNO", DataKey = false, Match = "", IsInsert = true)]
        public long BillNO
        {
            get { return  _billno; }
            set {  _billno = value; }
        }

        private int  _empid;
        /// <summary>
        /// 审核人员标识ID
        /// </summary>
        [Column(FieldName = "EmpID", DataKey = false, Match = "", IsInsert = true)]
        public int EmpID
        {
            get { return  _empid; }
            set {  _empid = value; }
        }

        private string  _empname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "EmpName", DataKey = false, Match = "", IsInsert = true)]
        public string EmpName
        {
            get { return  _empname; }
            set {  _empname = value; }
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

        private Decimal  _profitretailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ProfitRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ProfitRetailFee
        {
            get { return  _profitretailfee; }
            set {  _profitretailfee = value; }
        }

        private Decimal  _profitstockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ProfitStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ProfitStockFee
        {
            get { return  _profitstockfee; }
            set {  _profitstockfee = value; }
        }

        private Decimal  _lossretailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LossRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LossRetailFee
        {
            get { return  _lossretailfee; }
            set {  _lossretailfee = value; }
        }

        private Decimal  _lossstockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LossStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LossStockFee
        {
            get { return  _lossstockfee; }
            set {  _lossstockfee = value; }
        }

        private Decimal  _checkstockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CheckStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CheckStockFee
        {
            get { return  _checkstockfee; }
            set {  _checkstockfee = value; }
        }

        private Decimal  _actstockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ActStockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ActStockFee
        {
            get { return  _actstockfee; }
            set {  _actstockfee = value; }
        }

        private Decimal  _checkretailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CheckRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CheckRetailFee
        {
            get { return  _checkretailfee; }
            set {  _checkretailfee = value; }
        }

        private Decimal  _actretailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ActRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ActRetailFee
        {
            get { return  _actretailfee; }
            set {  _actretailfee = value; }
        }

    }
}
