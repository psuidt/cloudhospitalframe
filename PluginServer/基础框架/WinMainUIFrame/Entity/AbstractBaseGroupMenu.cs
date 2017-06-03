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
    [Table(TableName = "BaseGroupMenu", EntityType = EntityType.Table, IsGB = true)]
    public class BaseGroupMenu:EFWCoreLib.CoreFrame.Business.AbstractEntity
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

        private int  _groupid;
        /// <summary>
        /// 组编号
        /// </summary>
        [Column(FieldName = "GroupId", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(2)]
        public int GroupId
        {
            get { return  _groupid; }
            set {  _groupid = value; }
        }

        private int  _moduleid;
        /// <summary>
        /// 模块编号
        /// </summary>
        [Column(FieldName = "ModuleId", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(3)]
        public int ModuleId
        {
            get { return  _moduleid; }
            set {  _moduleid = value; }
        }

        private int  _menuid;
        /// <summary>
        /// 菜单编号
        /// </summary>
        [Column(FieldName = "MenuId", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(4)]
        public int MenuId
        {
            get { return  _menuid; }
            set {  _menuid = value; }
        }

    }
}
