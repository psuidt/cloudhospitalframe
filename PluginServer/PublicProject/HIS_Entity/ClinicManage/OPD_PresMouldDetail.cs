using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_PresMouldDetail", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_PresMouldDetail:AbstractEntity
    {
        private int _presmoulddetailid;
        /// <summary>
        /// 模板明细ID
        /// </summary>
        [Column(FieldName = "PresMouldDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int PresMouldDetailID
        {
            get { return  _presmoulddetailid; }
            set {  _presmoulddetailid = value; }
        }

        private int _presmouldheadid;
        /// <summary>
        /// 模板ID
        /// </summary>
        [Column(FieldName = "PresMouldHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int PresMouldHeadID
        {
            get { return  _presmouldheadid; }
            set {  _presmouldheadid = value; }
        }

        private int  _presno;
        /// <summary>
        /// 处方号
        /// </summary>
        [Column(FieldName = "PresNO", DataKey = false, Match = "", IsInsert = true)]
        public int PresNO
        {
            get { return  _presno; }
            set {  _presno = value; }
        }

        private int  _groupid;
        /// <summary>
        /// 组号
        /// </summary>
        [Column(FieldName = "GroupID", DataKey = false, Match = "", IsInsert = true)]
        public int GroupID
        {
            get { return  _groupid; }
            set {  _groupid = value; }
        }

        private int  _groupsortno;
        /// <summary>
        /// 组内序号
        /// </summary>
        [Column(FieldName = "GroupSortNO", DataKey = false, Match = "", IsInsert = true)]
        public int GroupSortNO
        {
            get { return  _groupsortno; }
            set {  _groupsortno = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
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

        private string  _spec;
        /// <summary>
        /// 规格
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return  _spec; }
            set {  _spec = value; }
        }

        private Decimal  _dosage;
        /// <summary>
        /// 剂量
        /// </summary>
        [Column(FieldName = "Dosage", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Dosage
        {
            get { return  _dosage; }
            set {  _dosage = value; }
        }

        private string  _dosageunit;
        /// <summary>
        /// 剂量单位
        /// </summary>
        [Column(FieldName = "DosageUnit", DataKey = false, Match = "", IsInsert = true)]
        public string DosageUnit
        {
            get { return  _dosageunit; }
            set {  _dosageunit = value; }
        }

        private Decimal  _factor;
        /// <summary>
        /// 剂量单位与小单位的转换系数
        /// </summary>
        [Column(FieldName = "Factor", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Factor
        {
            get { return  _factor; }
            set {  _factor = value; }
        }

        private int  _channelid;
        /// <summary>
        /// 用法ID
        /// </summary>
        [Column(FieldName = "ChannelID", DataKey = false, Match = "", IsInsert = true)]
        public int ChannelID
        {
            get { return  _channelid; }
            set {  _channelid = value; }
        }

        private int  _frequencyid;
        /// <summary>
        /// 频次ID （如果是皮试或手术套餐带出来的明细则存放父记录的ItemID）
        /// </summary>
        [Column(FieldName = "FrequencyID", DataKey = false, Match = "", IsInsert = true)]
        public int FrequencyID
        {
            get { return  _frequencyid; }
            set {  _frequencyid = value; }
        }

        private string  _entrust;
        /// <summary>
        /// 嘱托
        /// </summary>
        [Column(FieldName = "Entrust", DataKey = false, Match = "", IsInsert = true)]
        public string Entrust
        {
            get { return  _entrust; }
            set {  _entrust = value; }
        }

        private int  _dosenum;
        /// <summary>
        /// 中药剂数
        /// </summary>
        [Column(FieldName = "DoseNum", DataKey = false, Match = "", IsInsert = true)]
        public int DoseNum
        {
            get { return  _dosenum; }
            set {  _dosenum = value; }
        }

        private Decimal  _chargeamount;
        /// <summary>
        /// 总量
        /// </summary>
        [Column(FieldName = "ChargeAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ChargeAmount
        {
            get { return  _chargeamount; }
            set {  _chargeamount = value; }
        }

        private string  _chargeunit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "ChargeUnit", DataKey = false, Match = "", IsInsert = true)]
        public string ChargeUnit
        {
            get { return  _chargeunit; }
            set {  _chargeunit = value; }
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

        private int  _days;
        /// <summary>
        /// 天数
        /// </summary>
        [Column(FieldName = "Days", DataKey = false, Match = "", IsInsert = true)]
        public int Days
        {
            get { return  _days; }
            set {  _days = value; }
        }

        private Decimal  _presamount;
        /// <summary>
        /// 处方总量  需要增加列cPresAmount
        /// </summary>
        [Column(FieldName = "PresAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PresAmount
        {
            get { return  _presamount; }
            set {  _presamount = value; }
        }

        private string  _presamountunit;
        /// <summary>
        /// 处方总量单位需要增加列cPresAmountUnit
        /// </summary>
        [Column(FieldName = "PresAmountUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PresAmountUnit
        {
            get { return  _presamountunit; }
            set {  _presamountunit = value; }
        }

        private int  _presfactor;
        /// <summary>
        /// 包装系数
        /// </summary>
        [Column(FieldName = "PresFactor", DataKey = false, Match = "", IsInsert = true)]
        public int PresFactor
        {
            get { return  _presfactor; }
            set {  _presfactor = value; }
        }

    }
}
