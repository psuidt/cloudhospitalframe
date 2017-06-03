using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseMessage", EntityType = EntityType.Table, IsGB = false)]
    public class BaseMessage : AbstractEntity
    {
        private int _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Id", DataKey = true, Match = "", IsInsert = false)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _messagetypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MessagetypeID", DataKey = false, Match = "", IsInsert = true)]
        public int MessagetypeID
        {
            get { return _messagetypeid; }
            set { _messagetypeid = value; }
        }

        private string _messagetypecode;
        /// <summary>
        /// 消息类型代码
        /// </summary>
        [Column(FieldName = "MessageTypeCode", DataKey = false, Match = "", IsInsert = true)]
        public string MessageTypeCode
        {
            get { return _messagetypecode; }
            set { _messagetypecode = value; }
        }

        private int _sendempid;
        /// <summary>
        /// 发送人
        /// </summary>
        [Column(FieldName = "SendEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int SendEmpID
        {
            get { return _sendempid; }
            set { _sendempid = value; }
        }

        private int _senddept;
        /// <summary>
        /// 发送科室
        /// </summary>
        [Column(FieldName = "SendDept", DataKey = false, Match = "", IsInsert = true)]
        public int SendDept
        {
            get { return _senddept; }
            set { _senddept = value; }
        }

        private int _receivingdept;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ReceivingDept", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivingDept
        {
            get { return _receivingdept; }
            set { _receivingdept = value; }
        }

        private DateTime _sendtime;
        /// <summary>
        /// 消息发送时间
        /// </summary>
        [Column(FieldName = "SendTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime SendTime
        {
            get { return _sendtime; }
            set { _sendtime = value; }
        }

        private string _messagetitle;
        /// <summary>
        /// 消息标题
        /// </summary>
        [Column(FieldName = "MessageTitle", DataKey = false, Match = "", IsInsert = true)]
        public string MessageTitle
        {
            get { return _messagetitle; }
            set { _messagetitle = value; }
        }

        private string _messagecontent;
        /// <summary>
        /// 消息内容
        /// </summary>
        [Column(FieldName = "MessageContent", DataKey = false, Match = "", IsInsert = true)]
        public string MessageContent
        {
            get { return _messagecontent; }
            set { _messagecontent = value; }
        }

        private int _limittime;
        /// <summary>
        /// 消息有效期
        /// </summary>
        [Column(FieldName = "Limittime", DataKey = false, Match = "", IsInsert = true)]
        public int Limittime
        {
            get { return _limittime; }
            set { _limittime = value; }
        }

    }
}
