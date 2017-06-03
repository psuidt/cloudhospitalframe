using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_PointsExchange", EntityType = EntityType.Table, IsGB = false)]
    public class ME_PointsExchange:AbstractEntity
    {
        private int  _exchangeid;
        /// <summary>
        /// 兑换业务ID
        /// </summary>
        [Column(FieldName = "ExchangeID", DataKey = true, Match = "", IsInsert = false)]
        public int ExchangeID
        {
            get { return  _exchangeid; }
            set {  _exchangeid = value; }
        }

        private int  _giftid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GiftID", DataKey = false, Match = "", IsInsert = true)]
        public int GiftID
        {
            get { return  _giftid; }
            set {  _giftid = value; }
        }

        private int  _amount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public int Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private int  _accountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private int  _score;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Score", DataKey = false, Match = "", IsInsert = true)]
        public int Score
        {
            get { return  _score; }
            set {  _score = value; }
        }

        private DateTime  _operatedate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperateDate
        {
            get { return  _operatedate; }
            set {  _operatedate = value; }
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

    }
}
