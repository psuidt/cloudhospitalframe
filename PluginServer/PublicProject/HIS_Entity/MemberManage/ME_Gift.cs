using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_Gift", EntityType = EntityType.Table, IsGB = false)]
    public class ME_Gift:AbstractEntity
    {
        private int  _giftid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GiftID", DataKey = true, Match = "", IsInsert = false)]
        public int GiftID
        {
            get { return  _giftid; }
            set {  _giftid = value; }
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

        private string  _giftname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GiftName", DataKey = false, Match = "", IsInsert = true)]
        public string GiftName
        {
            get { return  _giftname; }
            set {  _giftname = value; }
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

        private int _useflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseFlag", DataKey = false, Match = "", IsInsert = true)]
        public int UseFlag
        {
            get { return  _useflag; }
            set { _useflag = value; }
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
