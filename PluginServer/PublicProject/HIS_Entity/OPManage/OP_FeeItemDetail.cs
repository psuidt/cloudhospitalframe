using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_FeeItemDetail", EntityType = EntityType.Table, IsGB = false)]
    public class OP_FeeItemDetail:AbstractEntity
    {
        private int  _presdetailid;
        /// <summary>
        /// 明细ID
        /// </summary>
        [Column(FieldName = "PresDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int PresDetailID
        {
            get { return  _presdetailid; }
            set {  _presdetailid = value; }
        }

        private int  _feeitemheadid;
        /// <summary>
        /// 处方头ID
        /// </summary>
        [Column(FieldName = "FeeItemHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeItemHeadID
        {
            get { return  _feeitemheadid; }
            set {  _feeitemheadid = value; }
        }

        private int _memberid;
        /// <summary>
        /// 会员ＩＤ
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 就诊ID号
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 项目编号
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemtype;
        /// <summary>
        /// 项目类型
        /// </summary>
        [Column(FieldName = "ItemType", DataKey = false, Match = "", IsInsert = true)]
        public string ItemType
        {
            get { return  _itemtype; }
            set {  _itemtype = value; }
        }

        private int  _statid;
        /// <summary>
        /// 大项目代码
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
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

        private string _packUnit;
        /// <summary>
        /// 包装单位
        /// </summary>
        [Column(FieldName = "PackUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnit
        {
            get { return _packUnit; }
            set { _packUnit = value; }
        }

        private string _miniUnit;
        /// <summary>
        /// 基本单位
        /// </summary>
        [Column(FieldName = "MiniUnit", DataKey = false, Match = "", IsInsert = true)]
        public string MiniUnit
        {
            get { return _miniUnit; }
            set { _miniUnit = value; }
        }

        private Decimal  _unitno;
        /// <summary>
        /// 包装系数
        /// </summary>
        [Column(FieldName = "UnitNO", DataKey = false, Match = "", IsInsert = true)]
        public Decimal UnitNO
        {
            get { return  _unitno; }
            set {  _unitno = value; }
        }

        private Decimal  _stockprice;
        /// <summary>
        /// 进价
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
        }

        private Decimal  _retailprice;
        /// <summary>
        /// 零售价
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return  _retailprice; }
            set {  _retailprice = value; }
        }

        private Decimal  _amount;
        /// <summary>
        /// 数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private int  _presamount;
        /// <summary>
        /// 处方贴数
        /// </summary>
        [Column(FieldName = "PresAmount", DataKey = false, Match = "", IsInsert = true)]
        public int PresAmount
        {
            get { return  _presamount; }
            set {  _presamount = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 合计费用
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
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

        private int  _docpresdetailid;
        /// <summary>
        /// 医生处方明细ＩＤ
        /// </summary>
        [Column(FieldName = "DocPresDetailID", DataKey = false, Match = "", IsInsert = true)]
        public int DocPresDetailID
        {
            get { return  _docpresdetailid; }
            set {  _docpresdetailid = value; }
        }
        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
       
        private DateTime _docPresDate;
        /// <summary>
        /// 医生开方时间
        /// </summary>
        [Column(FieldName = "DocPresDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime DocPresDate
        {
            get { return _docPresDate; }
            set { _docPresDate = value; }
        }
    }
}
