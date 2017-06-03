using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DW_Batch", EntityType = EntityType.Table, IsGB = false)]
    public class DW_Batch:AbstractEntity
    {
        private int  _batchid;
        /// <summary>
        /// ID编号
        /// </summary>
        [Column(FieldName = "BatchID", DataKey = true, Match = "", IsInsert = false)]
        public int BatchID
        {
            get { return  _batchid; }
            set {  _batchid = value; }
        }

        private int  _storageid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StorageID", DataKey = false, Match = "", IsInsert = true)]
        public int StorageID
        {
            get { return  _storageid; }
            set {  _storageid = value; }
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

        private int  _drugid;
        /// <summary>
        /// 厂家典ID
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
        }

        private string  _batchno;
        /// <summary>
        /// 批次号
        /// </summary>
        [Column(FieldName = "BatchNO", DataKey = false, Match = "", IsInsert = true)]
        public string BatchNO
        {
            get { return  _batchno; }
            set {  _batchno = value; }
        }

        private Decimal  _stockprice;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
        }

        private Decimal  _retailprice;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return  _retailprice; }
            set {  _retailprice = value; }
        }

        private DateTime  _instoretime;
        /// <summary>
        /// 入库时间
        /// </summary>
        [Column(FieldName = "InstoreTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime InstoreTime
        {
            get { return  _instoretime; }
            set {  _instoretime = value; }
        }

        private Decimal  _batchamount;
        /// <summary>
        /// 当前数量
        /// </summary>
        [Column(FieldName = "BatchAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal BatchAmount
        {
            get { return  _batchamount; }
            set {  _batchamount = value; }
        }

        private int  _unitid;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "UnitID", DataKey = false, Match = "", IsInsert = true)]
        public int UnitID
        {
            get { return  _unitid; }
            set {  _unitid = value; }
        }

        private string  _unitname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UnitName", DataKey = false, Match = "", IsInsert = true)]
        public string UnitName
        {
            get { return  _unitname; }
            set {  _unitname = value; }
        }

        private DateTime  _validitytime;
        /// <summary>
        /// 到效日期
        /// </summary>
        [Column(FieldName = "ValidityTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ValidityTime
        {
            get { return  _validitytime; }
            set {  _validitytime = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标识（1已删除，0未删除）
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
