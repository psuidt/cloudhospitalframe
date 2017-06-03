using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DW_Storage", EntityType = EntityType.Table, IsGB = false)]
    public class DW_Storage:AbstractEntity
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

        private Decimal  _lstockprice;
        /// <summary>
        /// 上次进价
        /// </summary>
        [Column(FieldName = "LStockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal LStockPrice
        {
            get { return  _lstockprice; }
            set {  _lstockprice = value; }
        }

        private DateTime  _regtime;
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

    }
}
