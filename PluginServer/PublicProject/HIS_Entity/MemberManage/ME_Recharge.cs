using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_Recharge", EntityType = EntityType.Table, IsGB = false)]
    public class ME_Recharge:AbstractEntity
    {
        private int  _rechargeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RechargeID", DataKey = true, Match = "", IsInsert = false)]
        public int RechargeID
        {
            get { return  _rechargeid; }
            set {  _rechargeid = value; }
        }

        private string  _rechargecode;
        /// <summary>
        /// 充值小票号码
        /// </summary>
        [Column(FieldName = "RechargeCode", DataKey = false, Match = "", IsInsert = true)]
        public string RechargeCode
        {
            get { return  _rechargecode; }
            set {  _rechargecode = value; }
        }

        private int  _accountid;
        /// <summary>
        /// 帐户ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private int  _typeid;
        /// <summary>
        /// 交易类型
        /// </summary>
        [Column(FieldName = "TypeID", DataKey = false, Match = "", IsInsert = true)]
        public int TypeID
        {
            get { return  _typeid; }
            set {  _typeid = value; }
        }

        private int  _paytype;
        /// <summary>
        /// 支付类型
        /// </summary>
        [Column(FieldName = "PayType", DataKey = false, Match = "", IsInsert = true)]
        public int PayType
        {
            get { return  _paytype; }
            set {  _paytype = value; }
        }

        private Decimal _money;
        /// <summary>
        /// 金额
        /// </summary>
        [Column(FieldName = "Money", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Money
        {
            get { return  _money; }
            set {  _money = value; }
        }

        private int  _account;
        /// <summary>
        /// 结算表ID
        /// </summary>
        [Column(FieldName = "Account", DataKey = false, Match = "", IsInsert = true)]
        public int Account
        {
            get { return  _account; }
            set {  _account = value; }
        }

        private int  _operateflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateFlag", DataKey = false, Match = "", IsInsert = true)]
        public int OperateFlag
        {
            get { return  _operateflag; }
            set {  _operateflag = value; }
        }

        private int  _operateid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateID", DataKey = false, Match = "", IsInsert = true)]
        public int OperateID
        {
            get { return  _operateid; }
            set {  _operateid = value; }
        }

        private DateTime  _operatetime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperateTime
        {
            get { return  _operatetime; }
            set {  _operatetime = value; }
        }

    }
}
