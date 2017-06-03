using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_Catalog", EntityType = EntityType.Table, IsGB = false)]
    public class MI_Catalog:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _miid;
        /// <summary>
        /// 医保类型ID
        /// </summary>
        [Column(FieldName = "MIID", DataKey = false, Match = "", IsInsert = true)]
        public int MIID
        {
            get { return  _miid; }
            set {  _miid = value; }
        }

        private int  _itemtype;
        /// <summary>
        /// 目录类型
        /// </summary>
        [Column(FieldName = "ItemType", DataKey = false, Match = "", IsInsert = true)]
        public int ItemType
        {
            get { return  _itemtype; }
            set {  _itemtype = value; }
        }

        private string  _itemcode;
        /// <summary>
        /// 项目编码
        /// </summary>
        [Column(FieldName = "ItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string ItemCode
        {
            get { return  _itemcode; }
            set {  _itemcode = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private string  _itemlevel;
        /// <summary>
        /// 项目级别
        /// </summary>
        [Column(FieldName = "ItemLevel", DataKey = false, Match = "", IsInsert = true)]
        public string ItemLevel
        {
            get { return  _itemlevel; }
            set {  _itemlevel = value; }
        }

        private int  _isybflag;
        /// <summary>
        /// 是否医保可报:0不可报销/1可报销
        /// </summary>
        [Column(FieldName = "IsYBFlag", DataKey = false, Match = "", IsInsert = true)]
        public int IsYBFlag
        {
            get { return  _isybflag; }
            set {  _isybflag = value; }
        }

        private string  _eitemname;
        /// <summary>
        /// 英文名
        /// </summary>
        [Column(FieldName = "EItemName", DataKey = false, Match = "", IsInsert = true)]
        public string EItemName
        {
            get { return  _eitemname; }
            set {  _eitemname = value; }
        }

        private string  _unit;
        /// <summary>
        /// 项目单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return  _unit; }
            set {  _unit = value; }
        }

        private string  _dosage;
        /// <summary>
        /// 项目剂型
        /// </summary>
        [Column(FieldName = "Dosage", DataKey = false, Match = "", IsInsert = true)]
        public string Dosage
        {
            get { return  _dosage; }
            set {  _dosage = value; }
        }

        private string  _spec;
        /// <summary>
        /// 项目规格
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return  _spec; }
            set {  _spec = value; }
        }

        private string  _factory;
        /// <summary>
        /// 项目厂家
        /// </summary>
        [Column(FieldName = "Factory", DataKey = false, Match = "", IsInsert = true)]
        public string Factory
        {
            get { return  _factory; }
            set {  _factory = value; }
        }

        private Decimal  _price;
        /// <summary>
        /// 价格
        /// </summary>
        [Column(FieldName = "Price", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Price
        {
            get { return  _price; }
            set {  _price = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private int  _matchstate;
        /// <summary>
        /// 匹配状态
        /// </summary>
        [Column(FieldName = "MatchState", DataKey = false, Match = "", IsInsert = true)]
        public int MatchState
        {
            get { return  _matchstate; }
            set {  _matchstate = value; }
        }

    }
}
