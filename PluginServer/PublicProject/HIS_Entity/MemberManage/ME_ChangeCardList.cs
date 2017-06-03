using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_ChangeCardList", EntityType = EntityType.Table, IsGB = false)]
    public class ME_ChangeCardList:AbstractEntity
    {
        private int  _changeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ChangeID", DataKey = true, Match = "", IsInsert = false)]
        public int ChangeID
        {
            get { return  _changeid; }
            set {  _changeid = value; }
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

        private string  _oldcardno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OldCardNO", DataKey = false, Match = "", IsInsert = true)]
        public string OldCardNO
        {
            get { return  _oldcardno; }
            set {  _oldcardno = value; }
        }

        private string  _newcardno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "NewCardNO", DataKey = false, Match = "", IsInsert = true)]
        public string NewCardNO
        {
            get { return  _newcardno; }
            set {  _newcardno = value; }
        }

        private Decimal  _amount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
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
