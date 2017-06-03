using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_FeeItemGenerate", EntityType = EntityType.Table, IsGB = false)]
    public class IP_FeeItemGenerate : AbstractEntity
    {
        private int _generateid;
        /// <summary>
        /// 费用生成ID
        /// </summary>
        [Column(FieldName = "GenerateID", DataKey = true, Match = "", IsInsert = false)]
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
        /// 病人姓名
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

        private int _patdeptid;
        /// <summary>
        /// 病人科室Id
        /// </summary>
        [Column(FieldName = "PatDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDeptID
        {
            get { return _patdeptid; }
            set { _patdeptid = value; }
        }

        private int _patdoctorid;
        /// <summary>
        /// 病人医生Id
        /// </summary>
        [Column(FieldName = "PatDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDoctorID
        {
            get { return _patdoctorid; }
            set { _patdoctorid = value; }
        }

        private int _patnurseid;
        /// <summary>
        /// 病人护士Id
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

        private string _packunit;
        /// <summary>
        /// 包装单位
        /// </summary>
        [Column(FieldName = "PackUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnit
        {
            get { return _packunit; }
            set { _packunit = value; }
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

        private int _execdeptdoctorid;
        /// <summary>
        /// 执行科室代码
        /// </summary>
        [Column(FieldName = "ExecDeptDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptDoctorID
        {
            get { return _execdeptdoctorid; }
            set { _execdeptdoctorid = value; }
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

        private DateTime _markdate;
        /// <summary>
        /// 划价时间
        /// </summary>
        [Column(FieldName = "MarkDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime MarkDate
        {
            get { return _markdate; }
            set { _markdate = value; }
        }

        private int _markempid;
        /// <summary>
        /// 记账人代码
        /// </summary>
        [Column(FieldName = "MarkEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int MarkEmpID
        {
            get { return _markempid; }
            set { _markempid = value; }
        }

        private int _sortorder;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return _sortorder; }
            set { _sortorder = value; }
        }

        private int _orderid;
        /// <summary>
        /// 医嘱ID
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private int _groupid;
        /// <summary>
        /// 组ID
        /// </summary>
        [Column(FieldName = "GroupID", DataKey = false, Match = "", IsInsert = true)]
        public int GroupID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        private int _ordertype;
        /// <summary>
        /// 医嘱类型
        /// </summary>
        [Column(FieldName = "OrderType", DataKey = false, Match = "", IsInsert = true)]
        public int OrderType
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }

        private int _frequencyid;
        /// <summary>
        /// 频次ID
        /// </summary>
        [Column(FieldName = "FrequencyID", DataKey = false, Match = "", IsInsert = true)]
        public int FrequencyID
        {
            get { return _frequencyid; }
            set { _frequencyid = value; }
        }

        private string _frequencyname;
        /// <summary>
        /// 频次名称
        /// </summary>
        [Column(FieldName = "FrequencyName", DataKey = false, Match = "", IsInsert = true)]
        public string FrequencyName
        {
            get { return _frequencyname; }
            set { _frequencyname = value; }
        }

        private int _channelid;
        /// <summary>
        /// 用法ID
        /// </summary>
        [Column(FieldName = "ChannelID", DataKey = false, Match = "", IsInsert = true)]
        public int ChannelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }

        private string _channelname;
        /// <summary>
        /// 用法名称
        /// </summary>
        [Column(FieldName = "ChannelName", DataKey = false, Match = "", IsInsert = true)]
        public string ChannelName
        {
            get { return _channelname; }
            set { _channelname = value; }
        }

        private int _isstop;
        /// <summary>
        /// 停用标志 0启用1停用
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return _isstop; }
            set { _isstop = value; }
        }

        private int _feesource;
        /// <summary>
        /// 费用来源，0医嘱本身费用、1组合项目明细费用、2用法联动费用、3账单、4床位费
        /// </summary>
        [Column(FieldName = "FeeSource", DataKey = false, Match = "", IsInsert = true)]
        public int FeeSource
        {
            get { return _feesource; }
            set { _feesource = value; }
        }

        private int _calcostmode;
        /// <summary>
        /// 计费模式，0按频次 1按周期
        /// </summary>
        [Column(FieldName = "CalCostMode", DataKey = false, Match = "", IsInsert = true)]
        public int CalCostMode
        {
            get { return _calcostmode; }
            set { _calcostmode = value; }
        }

        private int _bedid;
        /// <summary>
        /// 床位ID
        /// </summary>
        [Column(FieldName = "BedID", DataKey = false, Match = "", IsInsert = true)]
        public int BedID
        {
            get { return _bedid; }
            set { _bedid = value; }
        }

    }
}