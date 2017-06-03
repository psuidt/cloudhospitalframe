using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPDoctor
{
    [Serializable]
    [Table(TableName = "IPD_OrderModelDetail", EntityType = EntityType.Table, IsGB = false)]
    public class IPD_OrderModelDetail:AbstractEntity
    {
        private int  _modeldetailid;
        /// <summary>
        /// 模板明细ID
        /// </summary>
        [Column(FieldName = "ModelDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int ModelDetailID
        {
            get { return  _modeldetailid; }
            set {  _modeldetailid = value; }
        }

        private int  _modelheadid;
        /// <summary>
        /// 模板ID
        /// </summary>
        [Column(FieldName = "ModelHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int ModelHeadID
        {
            get { return  _modelheadid; }
            set {  _modelheadid = value; }
        }

        private int  _ordercategory;
        /// <summary>
        /// 0长期医嘱1临时医嘱
        /// </summary>
        [Column(FieldName = "OrderCategory", DataKey = false, Match = "", IsInsert = true)]
        public int OrderCategory
        {
            get { return  _ordercategory; }
            set {  _ordercategory = value; }
        }

        private int  _groupid;
        /// <summary>
        /// 医嘱组号
        /// </summary>
        [Column(FieldName = "GroupID", DataKey = false, Match = "", IsInsert = true)]
        public int GroupID
        {
            get { return  _groupid; }
            set {  _groupid = value; }
        }

        private int  _itemtype;
        /// <summary>
        /// 医嘱类别
        /// </summary>
        [Column(FieldName = "ItemType", DataKey = false, Match = "", IsInsert = true)]
        public int ItemType
        {
            get { return  _itemtype; }
            set {  _itemtype = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 医嘱项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 项目内容
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
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
        /// 剂量与基本单位转换系数
        /// </summary>
        [Column(FieldName = "Factor", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Factor
        {
            get { return  _factor; }
            set {  _factor = value; }
        }

        private string  _channelname;
        /// <summary>
        /// 用法名称
        /// </summary>
        [Column(FieldName = "ChannelName", DataKey = false, Match = "", IsInsert = true)]
        public string ChannelName
        {
            get { return  _channelname; }
            set {  _channelname = value; }
        }

        private int  _channelid;
        /// <summary>
        /// 用法ＩＤ
        /// </summary>
        [Column(FieldName = "ChannelID", DataKey = false, Match = "", IsInsert = true)]
        public int ChannelID
        {
            get { return  _channelid; }
            set {  _channelid = value; }
        }

        private int  _frenquencyid;
        /// <summary>
        /// 频次ID
        /// </summary>
        [Column(FieldName = "FrenquencyID", DataKey = false, Match = "", IsInsert = true)]
        public int FrenquencyID
        {
            get { return  _frenquencyid; }
            set {  _frenquencyid = value; }
        }

        private string  _frenquency;
        /// <summary>
        /// 频次
        /// </summary>
        [Column(FieldName = "Frenquency", DataKey = false, Match = "", IsInsert = true)]
        public string Frenquency
        {
            get { return  _frenquency; }
            set {  _frenquency = value; }
        }

        private Decimal  _dosenum;
        /// <summary>
        /// 中药剂数
        /// </summary>
        [Column(FieldName = "DoseNum", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DoseNum
        {
            get { return  _dosenum; }
            set {  _dosenum = value; }
        }

        private Decimal  _amount;
        /// <summary>
        /// 开药数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private string  _unit;
        /// <summary>
        /// 数量单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return  _unit; }
            set {  _unit = value; }
        }

        private Decimal  _unitno;
        /// <summary>
        /// 数量单位系数
        /// </summary>
        [Column(FieldName = "UnitNO", DataKey = false, Match = "", IsInsert = true)]
        public Decimal UnitNO
        {
            get { return  _unitno; }
            set {  _unitno = value; }
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

        private int  _firstnum;
        /// <summary>
        /// 首次
        /// </summary>
        [Column(FieldName = "FirstNum", DataKey = false, Match = "", IsInsert = true)]
        public int FirstNum
        {
            get { return  _firstnum; }
            set {  _firstnum = value; }
        }

        private int  _execdeptid;
        /// <summary>
        /// 执行科室ID
        /// </summary>
        [Column(FieldName = "ExecDeptId", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptId
        {
            get { return  _execdeptid; }
            set {  _execdeptid = value; }
        }

        private int  _examitemid;
        /// <summary>
        /// 套餐ID
        /// </summary>
        [Column(FieldName = "ExamItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ExamItemID
        {
            get { return  _examitemid; }
            set {  _examitemid = value; }
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

        private int  _flag;
        /// <summary>
        /// 0使用1停用
        /// </summary>
        [Column(FieldName = "Flag", DataKey = false, Match = "", IsInsert = true)]
        public int Flag
        {
            get { return  _flag; }
            set {  _flag = value; }
        }

    }
}
