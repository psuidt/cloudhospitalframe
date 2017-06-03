using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using ProtoBuf;

namespace WinMainUIFrame.Entity
{
    [Serializable]
    [ProtoContract]
    [Table(TableName = "BaseGroupUser", EntityType = EntityType.Table, IsGB = false)]
    public class BaseGroupUser:EFWCoreLib.CoreFrame.Business.AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 编号
        /// </summary>
        [Column(FieldName = "Id", DataKey = true,  Match = "", IsInsert = false)]
        [ProtoMember(1)]
        public int Id
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _userid;
        /// <summary>
        /// 用户编号
        /// </summary>
        [Column(FieldName = "UserId", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(2)]
        public int UserId
        {
            get { return  _userid; }
            set {  _userid = value; }
        }

        private int  _groupid;
        /// <summary>
        /// 组编号
        /// </summary>
        [Column(FieldName = "GroupId", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(3)]
        public int GroupId
        {
            get { return  _groupid; }
            set {  _groupid = value; }
        }

        private string  _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(4)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

    }
}
