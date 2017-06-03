using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_MemberAccount", EntityType = EntityType.Table, IsGB = false)]
    public class ME_MemberAccount:AbstractEntity
    {
        private int  _accountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = true, Match = "", IsInsert = false)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _cardtypeid;
        /// <summary>
        /// 卡片类型ID
        /// </summary>
        [Column(FieldName = "CardTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int CardTypeID
        {
            get { return  _cardtypeid; }
            set {  _cardtypeid = value; }
        }

        private string  _cardno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CardNO", DataKey = false, Match = "", IsInsert = true)]
        public string CardNO
        {
            get { return  _cardno; }
            set {  _cardno = value; }
        }

        private DateTime _regdate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegDate
        {
            get { return _regdate; }
            set { _regdate = value; }
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

        private int _UseFlag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseFlag", DataKey = false, Match = "", IsInsert = true)]
        public int UseFlag
        {
            get { return _UseFlag; }
            set { _UseFlag = value; }
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
