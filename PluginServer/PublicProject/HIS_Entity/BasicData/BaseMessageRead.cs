using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseMessageRead", EntityType = EntityType.Table, IsGB = false)]
    public class BaseMessageRead : AbstractEntity
    {
        private int _id;
        /// <summary>
        /// 消息读取ID
        /// </summary>
        [Column(FieldName = "Id", DataKey = true, Match = "", IsInsert = false)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _messageid;
        /// <summary>
        /// 消息ID
        /// </summary>
        [Column(FieldName = "MessageId", DataKey = false, Match = "", IsInsert = true)]
        public int MessageId
        {
            get { return _messageid; }
            set { _messageid = value; }
        }

        private int _empid;
        /// <summary>
        /// 人员ID
        /// </summary>
        [Column(FieldName = "EmpId", DataKey = false, Match = "", IsInsert = true)]
        public int EmpId
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private DateTime _sendtime;
        /// <summary>
        /// 发送时间
        /// </summary>
        [Column(FieldName = "SendTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime SendTime
        {
            get { return _sendtime; }
            set { _sendtime = value; }
        }

        private DateTime _readtime;
        /// <summary>
        /// 读取时间
        /// </summary>
        [Column(FieldName = "ReadTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ReadTime
        {
            get { return _readtime; }
            set { _readtime = value; }
        }

        private int _isread;
        /// <summary>
        /// 是否已读0=未读，1=已读
        /// </summary>
        [Column(FieldName = "IsRead", DataKey = false, Match = "", IsInsert = true)]
        public int IsRead
        {
            get { return _isread; }
            set { _isread = value; }
        }

    }
}
