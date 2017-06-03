using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_AdjDetail", EntityType = EntityType.Table, IsGB = false)]
    public class DG_AdjDetail:AbstractEntity
    {
        private int  _adjdetailid;
        /// <summary>
        /// 调价明细标识ID
        /// </summary>
        [Column(FieldName = "AdjDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int AdjDetailID
        {
            get { return  _adjdetailid; }
            set {  _adjdetailid = value; }
        }

        private int  _adjheadid;
        /// <summary>
        /// 调价表头标识ID
        /// </summary>
        [Column(FieldName = "AdjHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int AdjHeadID
        {
            get { return  _adjheadid; }
            set {  _adjheadid = value; }
        }

        private int  _drugid;
        /// <summary>
        /// 厂家典标识ID
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
        }

        private int  _unitid;
        /// <summary>
        /// 基本单位ID
        /// </summary>
        [Column(FieldName = "UnitID", DataKey = false, Match = "", IsInsert = true)]
        public int UnitID
        {
            get { return  _unitid; }
            set {  _unitid = value; }
        }

        private string _unitname;
        /// <summary>
        /// 单位名称
        /// </summary>
        [Column(FieldName = "UnitName", DataKey = false, Match = "", IsInsert = true)]
        public string UnitName
        {
            get { return _unitname; }
            set { _unitname = value; }
        }


        private int _packunitid;
        /// <summary>
        /// 单位名称
        /// </summary>
        [Column(FieldName = "PackUnitID", DataKey = false, Match = "", IsInsert = true)]
        public int PackUnitID
        {
            get { return _packunitid; }
            set { _packunitid = value; }
        }



        private string _packunitname;
        /// <summary>
        /// 单位名称
        /// </summary>
        [Column(FieldName = "PackUnitName", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnitName
        {
            get { return _packunitname; }
            set { _packunitname = value; }
        }



        private int  _unitamount;
        /// <summary>
        /// 单位数量
        /// </summary>
        [Column(FieldName = "UnitAmount", DataKey = false, Match = "", IsInsert = true)]
        public int UnitAmount
        {
            get { return  _unitamount; }
            set {  _unitamount = value; }
        }

        private Decimal  _oldretailprice;
        /// <summary>
        /// 原批发价
        /// </summary>
        [Column(FieldName = "OldRetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal OldRetailPrice
        {
            get { return  _oldretailprice; }
            set {  _oldretailprice = value; }
        }

        private Decimal  _newretailprice;
        /// <summary>
        /// 新批发价
        /// </summary>
        [Column(FieldName = "NewRetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal NewRetailPrice
        {
            get { return  _newretailprice; }
            set {  _newretailprice = value; }
        }

        private Decimal  _adjretailfee;
        /// <summary>
        /// 调整批发金额
        /// </summary>
        [Column(FieldName = "AdjRetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal AdjRetailFee
        {
            get { return  _adjretailfee; }
            set {  _adjretailfee = value; }
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

        private string  _batchno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BatchNO", DataKey = false, Match = "", IsInsert = true)]
        public string BatchNO
        {
            get { return  _batchno; }
            set {  _batchno = value; }
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

        private int  _auditflag;
        /// <summary>
        /// 审核标识位
        /// </summary>
        [Column(FieldName = "AuditFlag", DataKey = false, Match = "", IsInsert = true)]
        public int AuditFlag
        {
            get { return  _auditflag; }
            set {  _auditflag = value; }
        }

        private Decimal  _adjamount;
        /// <summary>
        /// 调价数量
        /// </summary>
        [Column(FieldName = "AdjAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal AdjAmount
        {
            get { return  _adjamount; }
            set {  _adjamount = value; }
        }

    }
}
