using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_ScoreList", EntityType = EntityType.Table, IsGB = false)]
    public class ME_ScoreList:AbstractEntity
    {
        private int  _scorelistid;
        /// <summary>
        /// 积分明细表ID
        /// </summary>
        [Column(FieldName = "ScoreListID", DataKey = true, Match = "", IsInsert = false)]
        public int ScoreListID
        {
            get { return  _scorelistid; }
            set {  _scorelistid = value; }
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

        private int  _scoretype;
        /// <summary>
        /// 操作类型
        /// </summary>
        [Column(FieldName = "ScoreType", DataKey = false, Match = "", IsInsert = true)]
        public int ScoreType
        {
            get { return  _scoretype; }
            set {  _scoretype = value; }
        }

        private string  _documentno;
        /// <summary>
        /// 消费单据号
        /// </summary>
        [Column(FieldName = "DocumentNo", DataKey = false, Match = "", IsInsert = true)]
        public string DocumentNo
        {
            get { return  _documentno; }
            set {  _documentno = value; }
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
