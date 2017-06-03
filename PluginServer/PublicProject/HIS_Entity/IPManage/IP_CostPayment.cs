using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_CostPayment", EntityType = EntityType.Table, IsGB = false)]
    public class IP_CostPayment:AbstractEntity
    {
        private int  _costpaymentid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CostPaymentID", DataKey = true, Match = "", IsInsert = false)]
        public int CostPaymentID
        {
            get { return  _costpaymentid; }
            set {  _costpaymentid = value; }
        }

        private int  _costheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private int  _paymentid;
        /// <summary>
        /// 支付方式ID
        /// </summary>
        [Column(FieldName = "PaymentID", DataKey = false, Match = "", IsInsert = true)]
        public int PaymentID
        {
            get { return  _paymentid; }
            set {  _paymentid = value; }
        }

        private int  _pattypeid;
        /// <summary>
        /// 病人类型ID
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return  _pattypeid; }
            set {  _pattypeid = value; }
        }

        private string  _payname;
        /// <summary>
        /// 支付方式名称
        /// </summary>
        [Column(FieldName = "PayName", DataKey = false, Match = "", IsInsert = true)]
        public string PayName
        {
            get { return  _payname; }
            set {  _payname = value; }
        }

        private Decimal  _costmoney;
        /// <summary>
        /// 金额
        /// </summary>
        [Column(FieldName = "CostMoney", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CostMoney
        {
            get { return  _costmoney; }
            set {  _costmoney = value; }
        }

        private int  _accountid;
        /// <summary>
        /// 交款ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

    }
}
