using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_AccountPatMentInfo", EntityType = EntityType.Table, IsGB = false)]
    public class OP_AccountPatMentInfo:AbstractEntity
    {
        private int  _accountpayinfoid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AccountPayInfoID", DataKey = true, Match = "", IsInsert = false)]
        public int AccountPayInfoID
        {
            get { return  _accountpayinfoid; }
            set {  _accountpayinfoid = value; }
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

        private int  _paymentid;
        /// <summary>
        /// 支付式方ＩＤ
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

        private int _paymentCount;
        /// <summary>
        /// 支付次数
        /// </summary>
        [Column(FieldName = "PayMentCount", DataKey = false, Match = "", IsInsert = true)]
        public int PayMentCount
        {
            get { return _paymentCount; }
            set { _paymentCount = value; }
        }
    }
}
