using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_Match_HIS", EntityType = EntityType.Table, IsGB = false)]
    public class MI_Match_HIS:AbstractEntity
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
        /// HIS项目编码
        /// </summary>
        [Column(FieldName = "ItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string ItemCode
        {
            get { return  _itemcode; }
            set {  _itemcode = value; }
        }

        private string  _hospitemname;
        /// <summary>
        /// HIS项目名称
        /// </summary>
        [Column(FieldName = "HospItemName", DataKey = false, Match = "", IsInsert = true)]
        public string HospItemName
        {
            get { return  _hospitemname; }
            set {  _hospitemname = value; }
        }

        private string  _ybitemcode;
        /// <summary>
        /// 医保中心项目编码
        /// </summary>
        [Column(FieldName = "YBItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string YBItemCode
        {
            get { return  _ybitemcode; }
            set {  _ybitemcode = value; }
        }

        private string  _ybitemname;
        /// <summary>
        /// 医保中心项目名称
        /// </summary>
        [Column(FieldName = "YBItemName", DataKey = false, Match = "", IsInsert = true)]
        public string YBItemName
        {
            get { return  _ybitemname; }
            set {  _ybitemname = value; }
        }

        private string  _ybitemlevel;
        /// <summary>
        /// c医保中心项目级别
        /// </summary>
        [Column(FieldName = "YBItemLevel", DataKey = false, Match = "", IsInsert = true)]
        public string YBItemLevel
        {
            get { return  _ybitemlevel; }
            set {  _ybitemlevel = value; }
        }

        private int  _ybflag;
        /// <summary>
        /// 医保中心是否可报
        /// </summary>
        [Column(FieldName = "YBFlag", DataKey = false, Match = "", IsInsert = true)]
        public int YBFlag
        {
            get { return  _ybflag; }
            set {  _ybflag = value; }
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
        /// 药品剂型
        /// </summary>
        [Column(FieldName = "Dosage", DataKey = false, Match = "", IsInsert = true)]
        public string Dosage
        {
            get { return  _dosage; }
            set {  _dosage = value; }
        }

        private string  _spec;
        /// <summary>
        /// 药品规格
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return  _spec; }
            set {  _spec = value; }
        }

        private string  _factory;
        /// <summary>
        /// 厂家
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

        private int  _validflag;
        /// <summary>
        /// 是否有效
        /// </summary>
        [Column(FieldName = "ValidFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ValidFlag
        {
            get { return  _validflag; }
            set {  _validflag = value; }
        }

        private int  _auditflag;
        /// <summary>
        /// 是否审核
        /// </summary>
        [Column(FieldName = "AuditFlag", DataKey = false, Match = "", IsInsert = true)]
        public int AuditFlag
        {
            get { return  _auditflag; }
            set {  _auditflag = value; }
        }

        private DateTime  _auditdate;
        /// <summary>
        /// 审核时间
        /// </summary>
        [Column(FieldName = "AuditDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AuditDate
        {
            get { return  _auditdate; }
            set {  _auditdate = value; }
        }

        private Decimal  _selfscale;
        /// <summary>
        /// 自付比例
        /// </summary>
        [Column(FieldName = "SelfScale", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SelfScale
        {
            get { return  _selfscale; }
            set {  _selfscale = value; }
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

        private string  _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

    }
}
