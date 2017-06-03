using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseMessageTypeUser", EntityType = EntityType.Table, IsGB = false)]
    public class BaseMessageTypeUser : AbstractEntity
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
        [Column(FieldName = "MessageTypeId", DataKey = false, Match = "", IsInsert = true)]
        public int MessageTypeId
        {
            get { return _messagetypeid; }
            set { _messagetypeid = value; }
        }

        private int _empid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "EmpId", DataKey = false, Match = "", IsInsert = true)]
        public int EmpId
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private DateTime _receivetime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ReceiveTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ReceiveTime
        {
            get { return _receivetime; }
            set { _receivetime = value; }
        }

    }
}
