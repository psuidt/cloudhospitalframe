using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_FeeItemRecord", EntityType = EntityType.Table, IsGB = false)]
    public class IP_FeeItemRecord : AbstractEntity
    {
        private int _feerecordid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FeeRecordID", DataKey = true, Match = "", IsInsert = false)]
        public int FeeRecordID
        {
            get { return _feerecordid; }
            set { _feerecordid = value; }
        }

        private int _generateid;
        /// <summary>
        /// 费用生成表ID
        /// </summary>
        [Column(FieldName = "GenerateID", DataKey = false, Match = "", IsInsert = true)]
        public int GenerateID
        {
            get { return _generateid; }
            set { _generateid = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 病人住院ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private string _patname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

        private int _patdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDeptID
        {
            get { return _patdeptid; }
            set { _patdeptid = value; }
        }

        private int _patdoctorid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDoctorID
        {
            get { return _patdoctorid; }
            set { _patdoctorid = value; }
        }

        private int _patnurseid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatNurseID", DataKey = false, Match = "", IsInsert = true)]
        public int PatNurseID
        {
            get { return _patnurseid; }
            set { _patnurseid = value; }
        }

        private int _babyid;
        /// <summary>
        /// 婴儿ID
        /// </summary>
        [Column(FieldName = "BabyID", DataKey = false, Match = "", IsInsert = true)]
        public int BabyID
        {
            get { return _babyid; }
            set { _babyid = value; }
        }

        private int _itemid;
        /// <summary>
        /// 项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        private string _itemname;
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private int _feeclass;
        /// <summary>
        /// 费用类型 1药品 2项目 3材料 
        /// </summary>
        [Column(FieldName = "FeeClass", DataKey = false, Match = "", IsInsert = true)]
        public int FeeClass
        {
            get { return _feeclass; }
            set { _feeclass = value; }
        }

        private int _feesource;
        /// <summary>
        /// 费用来源，0账单 1医嘱 2床位费 3手术室
        /// </summary>
        [Column(FieldName = "FeeSource", DataKey = false, Match = "", IsInsert = true)]
        public int FeeSource
        {
            get { return _feesource; }
            set { _feesource = value; }
        }

        private int _statid;
        /// <summary>
        /// 统计项目ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        private string _spec;
        /// <summary>
        /// 规格
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return _spec; }
            set { _spec = value; }
        }

        private string _unit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private Decimal _packamount;
        /// <summary>
        /// 划价系数
        /// </summary>
        [Column(FieldName = "PackAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PackAmount
        {
            get { return _packamount; }
            set { _packamount = value; }
        }

        private Decimal _inprice;
        /// <summary>
        /// 批发价
        /// </summary>
        [Column(FieldName = "InPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal InPrice
        {
            get { return _inprice; }
            set { _inprice = value; }
        }

        private Decimal _sellprice;
        /// <summary>
        /// 销售价
        /// </summary>
        [Column(FieldName = "SellPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SellPrice
        {
            get { return _sellprice; }
            set { _sellprice = value; }
        }

        private int _amount;
        /// <summary>
        /// 数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private int _doseamount;
        /// <summary>
        /// 处方帖数
        /// </summary>
        [Column(FieldName = "DoseAmount", DataKey = false, Match = "", IsInsert = true)]
        public int DoseAmount
        {
            get { return _doseamount; }
            set { _doseamount = value; }
        }

        private Decimal _totalfee;
        /// <summary>
        /// 总价格
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return _totalfee; }
            set { _totalfee = value; }
        }

        private int _presdeptid;
        /// <summary>
        /// 划价科室代码
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return _presdeptid; }
            set { _presdeptid = value; }
        }

        private int _presdoctorid;
        /// <summary>
        /// 划价医生代码
        /// </summary>
        [Column(FieldName = "PresDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDoctorID
        {
            get { return _presdoctorid; }
            set { _presdoctorid = value; }
        }

        private int _execdeptid;
        /// <summary>
        /// 执行科室代码
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return _execdeptid; }
            set { _execdeptid = value; }
        }

        private DateTime _presdate;
        /// <summary>
        /// 处方日期
        /// </summary>
        [Column(FieldName = "PresDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PresDate
        {
            get { return _presdate; }
            set { _presdate = value; }
        }

        private DateTime _chargedate;
        /// <summary>
        /// 记账时间
        /// </summary>
        [Column(FieldName = "ChargeDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ChargeDate
        {
            get { return _chargedate; }
            set { _chargedate = value; }
        }

        private int _drugflag;
        /// <summary>
        /// 发药标识
        /// </summary>
        [Column(FieldName = "DrugFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DrugFlag
        {
            get { return _drugflag; }
            set { _drugflag = value; }
        }

        private int _recordflag;
        /// <summary>
        /// 记录状态（0正常 1退费 2冲正）
        /// </summary>
        [Column(FieldName = "RecordFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RecordFlag
        {
            get { return _recordflag; }
            set { _recordflag = value; }
        }

        private int _oldfeerecordid;
        /// <summary>
        /// 退明细ID
        /// </summary>
        [Column(FieldName = "OldFeeRecordID", DataKey = false, Match = "", IsInsert = true)]
        public int OldFeeRecordID
        {
            get { return _oldfeerecordid; }
            set { _oldfeerecordid = value; }
        }

        private int _costheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return _costheadid; }
            set { _costheadid = value; }
        }

        private int _costtype;
        /// <summary>
        /// 结算标志(1，中途，2，出院，3，欠费)
        /// </summary>
        [Column(FieldName = "CostType", DataKey = false, Match = "", IsInsert = true)]
        public int CostType
        {
            get { return _costtype; }
            set { _costtype = value; }
        }

        private int _uploadid;
        /// <summary>
        /// 上传标识（0，1）
        /// </summary>
        [Column(FieldName = "UploadID", DataKey = false, Match = "", IsInsert = true)]
        public int UploadID
        {
            get { return _uploadid; }
            set { _uploadid = value; }
        }

        private string _packunit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PackUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnit
        {
            get { return _packunit; }
            set { _packunit = value; }
        }

        private int _orderid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private int _groupid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GroupID", DataKey = false, Match = "", IsInsert = true)]
        public int GroupID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        private int _ordertype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OrderType", DataKey = false, Match = "", IsInsert = true)]
        public int OrderType
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }

        private int _frequencyid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FrequencyID", DataKey = false, Match = "", IsInsert = true)]
        public int FrequencyID
        {
            get { return _frequencyid; }
            set { _frequencyid = value; }
        }

        private string _frequencyname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FrequencyName", DataKey = false, Match = "", IsInsert = true)]
        public string FrequencyName
        {
            get { return _frequencyname; }
            set { _frequencyname = value; }
        }

        private int _channelid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ChannelID", DataKey = false, Match = "", IsInsert = true)]
        public int ChannelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }

        private string _channelname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ChannelName", DataKey = false, Match = "", IsInsert = true)]
        public string ChannelName
        {
            get { return _channelname; }
            set { _channelname = value; }
        }
    }
}
