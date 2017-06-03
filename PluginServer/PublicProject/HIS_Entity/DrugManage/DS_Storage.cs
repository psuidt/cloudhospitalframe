using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_Storage", EntityType = EntityType.Table, IsGB = false)]
    public class DS_Storage:AbstractEntity
    {
        private int  _storageid;
        /// <summary>
        /// 库存量标识ID
        /// </summary>
        [Column(FieldName = "StorageID", DataKey = true, Match = "", IsInsert = false)]
        public int StorageID
        {
            get { return  _storageid; }
            set {  _storageid = value; }
        }

        private long  _drugid;
        /// <summary>
        /// 厂家典标识ID
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public long DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
        }

        private Decimal  _amount;
        /// <summary>
        /// 当前库存量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private string  _place;
        /// <summary>
        /// 存放位置
        /// </summary>
        [Column(FieldName = "Place", DataKey = false, Match = "", IsInsert = true)]
        public string Place
        {
            get { return  _place; }
            set {  _place = value; }
        }

        private Decimal  _laststockprice;
        /// <summary>
        /// 上次进价
        /// </summary>
        [Column(FieldName = "LastStockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LastStockPrice
        {
            get { return  _laststockprice; }
            set {  _laststockprice = value; }
        }

        private DateTime _regtime;
        /// <summary>
        /// 记录时间
        /// </summary>
        [Column(FieldName = "RegTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegTime
        {
            get { return  _regtime; }
            set {  _regtime = value; }
        }

        private Decimal  _upperlimit;
        /// <summary>
        /// 库存上限
        /// </summary>
        [Column(FieldName = "UpperLimit", DataKey = false, Match = "", IsInsert = true)]
        public Decimal UpperLimit
        {
            get { return  _upperlimit; }
            set {  _upperlimit = value; }
        }

        private Decimal  _lowerlimit;
        /// <summary>
        /// 库存下限
        /// </summary>
        [Column(FieldName = "LowerLimit", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LowerLimit
        {
            get { return  _lowerlimit; }
            set {  _lowerlimit = value; }
        }

        private int _unitID;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "UnitID", DataKey = false, Match = "", IsInsert = true)]
        public int UnitID
        {
            get { return _unitID; }
            set { _unitID = value; }
        }

        private string _unitName;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "UnitName", DataKey = false, Match = "", IsInsert = true)]
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
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

        private int  _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
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

        private int  _resolveflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ResolveFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ResolveFlag
        {
            get { return  _resolveflag; }
            set {  _resolveflag = value; }
        }

        private int  _locationid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LocationID", DataKey = false, Match = "", IsInsert = true)]
        public int LocationID
        {
            get { return  _locationid; }
            set {  _locationid = value; }
        }

        private string packUnit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PackUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnit
        {
            get { return packUnit; }
            set { packUnit = value; }
        }
    }
}
