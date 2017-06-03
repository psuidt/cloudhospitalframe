using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_ConvertPoints", EntityType = EntityType.Table, IsGB = false)]
    public class ME_ConvertPoints:AbstractEntity
    {
        private int  _convertid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ConvertID", DataKey = true, Match = "", IsInsert = false)]
        public int ConvertID
        {
            get { return  _convertid; }
            set {  _convertid = value; }
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

        private int  _cash;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Cash", DataKey = false, Match = "", IsInsert = true)]
        public int Cash
        {
            get { return  _cash; }
            set {  _cash = value; }
        }

        private int  _score;
        /// <summary>
        /// 积分
        /// </summary>
        [Column(FieldName = "Score", DataKey = false, Match = "", IsInsert = true)]
        public int Score
        {
            get { return  _score; }
            set {  _score = value; }
        }

        private int _usework;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseWork", DataKey = false, Match = "", IsInsert = true)]
        public int UseWork
        {
            get { return _usework; }
            set { _usework = value; }
        }

        private int  _useflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseFlag", DataKey = false, Match = "", IsInsert = true)]
        public int UseFlag
        {
            get { return  _useflag; }
            set {  _useflag = value; }
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
