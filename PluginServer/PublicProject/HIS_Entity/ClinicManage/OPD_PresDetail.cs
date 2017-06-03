using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_PresDetail", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_PresDetail:AbstractEntity
    {
        private int _presdetailid;
        /// <summary>
        /// 处方明细ID
        /// </summary>
        [Column(FieldName = "PresDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int PresDetailID
        {
            get { return  _presdetailid; }
            set {  _presdetailid = value; }
        }

        private int _presheadid;
        /// <summary>
        /// 处方头ID
        /// </summary>
        [Column(FieldName = "PresHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int PresHeadID
        {
            get { return  _presheadid; }
            set {  _presheadid = value; }
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
        /// 剂量单位与基本单位的转换系数
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
        /// 数量（基本数量）
        /// </summary>
        [Column(FieldName = "ChargeAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ChargeAmount
        {
            get { return  _chargeamount; }
            set {  _chargeamount = value; }
        }

        private string  _chargeunit;
        /// <summary>
        /// 基本单位
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

        private string  _dropspec;
        /// <summary>
        /// 滴速
        /// </summary>
        [Column(FieldName = "DropSpec", DataKey = false, Match = "", IsInsert = true)]
        public string DropSpec
        {
            get { return  _dropspec; }
            set {  _dropspec = value; }
        }

        private int  _isast;
        /// <summary>
        /// 是否皮试 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsAst", DataKey = false, Match = "", IsInsert = true)]
        public int IsAst
        {
            get { return  _isast; }
            set {  _isast = value; }
        }

        private string  _astresult;
        /// <summary>
        /// 皮试结果   0-阴 1-阳
        /// </summary>
        [Column(FieldName = "AstResult", DataKey = false, Match = "", IsInsert = true)]
        public string AstResult
        {
            get { return  _astresult; }
            set {  _astresult = value; }
        }

        private int  _istake;
        /// <summary>
        /// 是否自备药 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsTake", DataKey = false, Match = "", IsInsert = true)]
        public int IsTake
        {
            get { return  _istake; }
            set {  _istake = value; }
        }

        private int  _ischarged;
        /// <summary>
        /// 是否已收费 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsCharged", DataKey = false, Match = "", IsInsert = true)]
        public int IsCharged
        {
            get { return  _ischarged; }
            set {  _ischarged = value; }
        }

        private int  _iscancel;
        /// <summary>
        /// 是否作废   0-否 1-是
        /// </summary>
        [Column(FieldName = "IsCancel", DataKey = false, Match = "", IsInsert = true)]
        public int IsCancel
        {
            get { return  _iscancel; }
            set {  _iscancel = value; }
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

        private int  _execnum;
        /// <summary>
        /// 本院执行次数
        /// </summary>
        [Column(FieldName = "ExecNum", DataKey = false, Match = "", IsInsert = true)]
        public int ExecNum
        {
            get { return  _execnum; }
            set {  _execnum = value; }
        }

        private int  _linkpresdetailid;
        /// <summary>
        /// 联动费用处方明细ID
        /// </summary>
        [Column(FieldName = "LinkPresDetailID", DataKey = false, Match = "", IsInsert = true)]
        public int LinkPresDetailID
        {
            get { return  _linkpresdetailid; }
            set {  _linkpresdetailid = value; }
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

        private int  _presdoctorid;
        /// <summary>
        /// 开方医生ID
        /// </summary>
        [Column(FieldName = "PresDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDoctorID
        {
            get { return  _presdoctorid; }
            set {  _presdoctorid = value; }
        }

        private int  _presdeptid;
        /// <summary>
        /// 开方科室ID
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return  _presdeptid; }
            set {  _presdeptid = value; }
        }

        private int  _execdeptid;
        /// <summary>
        /// 执行科室ID
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return  _execdeptid; }
            set {  _execdeptid = value; }
        }

        private DateTime  _presdate;
        /// <summary>
        /// 开方时间
        /// </summary>
        [Column(FieldName = "PresDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PresDate
        {
            get { return  _presdate; }
            set {  _presdate = value; }
        }

        private int  _isemergency;
        /// <summary>
        /// 急诊标志 0 否 1是
        /// </summary>
        [Column(FieldName = "IsEmergency", DataKey = false, Match = "", IsInsert = true)]
        public int IsEmergency
        {
            get { return  _isemergency; }
            set {  _isemergency = value; }
        }

        private int  _islunacyposion;
        /// <summary>
        /// 精毒标志 0 否 1是
        /// </summary>
        [Column(FieldName = "IsLunacyPosion", DataKey = false, Match = "", IsInsert = true)]
        public int IsLunacyPosion
        {
            get { return  _islunacyposion; }
            set {  _islunacyposion = value; }
        }
        private int _IsReimbursement;
        /// <summary>
        /// 是否医保报销标志 0 否 1是
        /// </summary>
        [Column(FieldName = "IsReimbursement", DataKey = false, Match = "", IsInsert = true)]
        public int IsReimbursement
        {
            get { return _IsReimbursement; }
            set { _IsReimbursement = value; }
        }
    }
}
