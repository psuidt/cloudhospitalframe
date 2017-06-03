using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;
using ProtoBuf;

namespace WinMainUIFrame.Entity
{
    [Serializable]
    [ProtoContract]
    [Table(TableName = "BaseMessage", EntityType = EntityType.Table, IsGB = false)]
    public class BaseMessage : AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Id", DataKey = true,  Match = "", IsInsert = false)]
        [ProtoMember(1)]
        public int Id
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private string  _messagetype;
        /// <summary>
        /// 消息类型
        /// </summary>
        [Column(FieldName = "MessageTypeCode", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(2)]
        public string MessageType
        {
            get { return  _messagetype; }
            set {  _messagetype = value; }
        }

        private string  _messagetitle;
        /// <summary>
        /// 消息标题
        /// </summary>
        [Column(FieldName = "MessageTitle", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(10)]
        public string MessageTitle
        {
            get { return  _messagetitle; }
            set {  _messagetitle = value; }
        }

        private string  _messagecontent;
        /// <summary>
        /// 消息内容
        /// </summary>
        [Column(FieldName = "MessageContent", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(11)]
        public string MessageContent
        {
            get { return  _messagecontent; }
            set {  _messagecontent = value; }
        }

    }
}
