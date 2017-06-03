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
    [Table(TableName = "BaseGroup", EntityType = EntityType.Table, IsGB = false)]
    public class BaseGroup:EFWCoreLib.CoreFrame.Business.AbstractEntity
    {
        private int  _groupid;
        /// <summary>
        /// 编号
        /// </summary>
        [Column(FieldName = "GroupId", DataKey = true,  Match = "", IsInsert = false)]
        [ProtoMember(1)]
        public int GroupId
        {
            get { return  _groupid; }
            set {  _groupid = value; }
        }

        private string  _name="";
        /// <summary>
        /// 名称
        /// </summary>
        [Column(FieldName = "Name", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(2)]
        public string Name
        {
            get { return  _name; }
            set {  _name = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标记
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(3)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

        private int  _admin;
        /// <summary>
        /// 是否高级管理员
        /// </summary>
        [Column(FieldName = "Admin", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(4)]
        public int Admin
        {
            get { return  _admin; }
            set {  _admin = value; }
        }

        private int  _everyone;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Everyone", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(5)]
        public int Everyone
        {
            get { return  _everyone; }
            set {  _everyone = value; }
        }

        private string  _memo="";
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(6)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

        private string  _property="";
        /// <summary>
        /// 属性
        /// </summary>
        [Column(FieldName = "Property", DataKey = false,  Match = "", IsInsert = true)]
        [ProtoMember(7)]
        public string Property
        {
            get { return  _property; }
            set {  _property = value; }
        }

    }
}
