using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_CardTypeList", EntityType = EntityType.Table, IsGB = false)]
    public class ME_CardTypeList:AbstractEntity
    {
        private int  _cardtypeid;
        /// <summary>
        /// 卡片类型ID
        /// </summary>
        [Column(FieldName = "CardTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int CardTypeID
        {
            get { return  _cardtypeid; }
            set {  _cardtypeid = value; }
        }

        private string  _cardtypename;
        /// <summary>
        /// 卡片类型名称
        /// </summary>
        [Column(FieldName = "CardTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string CardTypeName
        {
            get { return  _cardtypename; }
            set {  _cardtypename = value; }
        }

        private int  _cardtype;
        /// <summary>
        /// 卡片类型
        /// </summary>
        [Column(FieldName = "CardType", DataKey = false, Match = "", IsInsert = true)]
        public int CardType
        {
            get { return  _cardtype; }
            set {  _cardtype = value; }
        }

        private string  _cardinterface;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CardInterface", DataKey = false, Match = "", IsInsert = true)]
        public string CardInterface
        {
            get { return  _cardinterface; }
            set {  _cardinterface = value; }
        }

        private string _CardPrefix;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CardPrefix", DataKey = false, Match = "", IsInsert = true)]
        public string CardPrefix
        {
            get { return _CardPrefix; }
            set { _CardPrefix = value; }
        }

        private int  _findflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FindFlag", DataKey = false, Match = "", IsInsert = true)]
        public int FindFlag
        {
            get { return  _findflag; }
            set {  _findflag = value; }
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
