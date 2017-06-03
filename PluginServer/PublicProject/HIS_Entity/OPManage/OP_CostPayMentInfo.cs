using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_CostPayMentInfo", EntityType = EntityType.Table, IsGB = false)]
    public class OP_CostPayMentInfo:AbstractEntity
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

        private int  _costheadid;
        /// <summary>
        /// 结算主表ＩＤ
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _paymentid;
        /// <summary>
        /// 支付方式ID
        /// </summary>
        [Column(FieldName = "PayMentID", DataKey = false, Match = "", IsInsert = true)]
        public int PayMentID
        {
            get { return  _paymentid; }
            set {  _paymentid = value; }
        }

        private string  _paymentname;
        /// <summary>
        /// 支付方式名称
        /// </summary>
        [Column(FieldName = "PayMentName", DataKey = false, Match = "", IsInsert = true)]
        public string PayMentName
        {
            get { return  _paymentname; }
            set {  _paymentname = value; }
        }

        private string _payMentCode;
        /// <summary>
        /// 支付方式Code
        /// </summary>
        [Column(FieldName = "PayMentCode", DataKey = false, Match = "", IsInsert = true)]
        public string PayMentCode
        {
            get { return _payMentCode; }
            set { _payMentCode = value; }
        }

        private Decimal  _paymentmoney;
        /// <summary>
        /// 支付金额
        /// </summary>
        [Column(FieldName = "PayMentMoney", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PayMentMoney
        {
            get { return  _paymentmoney; }
            set {  _paymentmoney = value; }
        }

        private int  _accountid;
        /// <summary>
        /// 缴款ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private string  _pattype;
        /// <summary>
        /// 病人类型
        /// </summary>
        [Column(FieldName = "PatType", DataKey = false, Match = "", IsInsert = true)]
        public string PatType
        {
            get { return  _pattype; }
            set {  _pattype = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ＩＤ
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 姓名
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

    }
}
