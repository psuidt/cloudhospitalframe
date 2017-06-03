using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_FeeRefundDetail", EntityType = EntityType.Table, IsGB = false)]
    public class OP_FeeRefundDetail:AbstractEntity
    {
        private int  _redetailid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ReDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int ReDetailID
        {
            get { return  _redetailid; }
            set {  _redetailid = value; }
        }

        private int  _reheadid;
        /// <summary>
        /// 退费头ＩＤ
        /// </summary>
        [Column(FieldName = "ReHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int ReHeadID
        {
            get { return  _reheadid; }
            set {  _reheadid = value; }
        }

        private int  _feeitemheadid;
        /// <summary>
        /// 费用头ＩＤ
        /// </summary>
        [Column(FieldName = "FeeItemHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeItemHeadID
        {
            get { return  _feeitemheadid; }
            set {  _feeitemheadid = value; }
        }

        private int  _feeitemdetailid;
        /// <summary>
        /// 费用头明细ＩＤ
        /// </summary>
        [Column(FieldName = "FeeItemDetailID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeItemDetailID
        {
            get { return  _feeitemdetailid; }
            set {  _feeitemdetailid = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 药品项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 药品项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private decimal _oldamount;
        /// <summary>
        /// 原数量
        /// </summary>
        [Column(FieldName = "OldAmount", DataKey = false, Match = "", IsInsert = true)]
        public decimal  OldAmount
        {
            get { return  _oldamount; }
            set {  _oldamount = value; }
        }

        private decimal _refundamount;
        /// <summary>
        /// 退数量
        /// </summary>
        [Column(FieldName = "RefundAmount", DataKey = false, Match = "", IsInsert = true)]
        public decimal RefundAmount
        {
            get { return  _refundamount; }
            set {  _refundamount = value; }
        }

        private decimal _newamount;
        /// <summary>
        /// 新数量
        /// </summary>
        [Column(FieldName = "NewAmount", DataKey = false, Match = "", IsInsert = true)]
        public decimal NewAmount
        {
            get { return  _newamount; }
            set {  _newamount = value; }
        }

        private decimal _refundFee;
        /// <summary>
        /// 退药金额
        /// </summary>
        [Column(FieldName = "RefundFee", DataKey = false, Match = "", IsInsert = true)]
        public decimal RefundFee
        {
            get { return _refundFee; }
            set { _refundFee = value; }
        }
        private decimal _refundPresAmount;
        /// <summary>
        /// 退付数
        /// </summary>
        [Column(FieldName = "RefundPresAmount", DataKey = false, Match = "", IsInsert = true)]
        public decimal RefundPresAmount
        {
            get { return _refundPresAmount; }
            set { _refundPresAmount = value; }
        }

        private int _distributeflag;
        /// <summary>
        /// 发药标志　０未发　１已发
        /// </summary>
        [Column(FieldName = "DistributeFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DistributeFlag
        {
            get { return _distributeflag; }
            set { _distributeflag = value; }
        }

        private int _refundflag;
        /// <summary>
        /// 退药标志　０未退　１已退
        /// </summary>
        [Column(FieldName = "RefundFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RefundFlag
        {
            get { return _refundflag; }
            set { _refundflag = value; }
        }
    }
}
