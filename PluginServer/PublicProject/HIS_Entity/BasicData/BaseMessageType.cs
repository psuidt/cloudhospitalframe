using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseMessageType", EntityType = EntityType.Table, IsGB = false)]
    public class BaseMessageType:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 类型ID
        /// </summary>
        [Column(FieldName = "Id", DataKey = true, Match = "", IsInsert = false)]
        public int Id
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private string  _code;
        /// <summary>
        /// 消息类型编号
        /// </summary>
        [Column(FieldName = "Code", DataKey = false, Match = "", IsInsert = true)]
        public string Code
        {
            get { return  _code; }
            set {  _code = value; }
        }

        private string  _name;
        /// <summary>
        /// 消息类型名称
        /// </summary>
        [Column(FieldName = "Name", DataKey = false, Match = "", IsInsert = true)]
        public string Name
        {
            get { return  _name; }
            set {  _name = value; }
        }

        private int  _workflag;
        /// <summary>
        /// 接收系统模块
        /// </summary>
        [Column(FieldName = "WorkFlag", DataKey = false, Match = "", IsInsert = true)]
        public int WorkFlag
        {
            get { return  _workflag; }
            set {  _workflag = value; }
        }

        private int  _deptflag;
        /// <summary>
        /// 接收菜单模块
        /// </summary>
        [Column(FieldName = "DeptFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DeptFlag
        {
            get { return  _deptflag; }
            set {  _deptflag = value; }
        }

        private string  _sendgroup;
        /// <summary>
        /// 接收科室
        /// </summary>
        [Column(FieldName = "SendGroup", DataKey = false, Match = "", IsInsert = true)]
        public string SendGroup
        {
            get { return  _sendgroup; }
            set {  _sendgroup = value; }
        }

        private string  _receivegroup;
        /// <summary>
        /// 接收人
        /// </summary>
        [Column(FieldName = "ReceiveGroup", DataKey = false, Match = "", IsInsert = true)]
        public string ReceiveGroup
        {
            get { return  _receivegroup; }
            set {  _receivegroup = value; }
        }

        private string  _limittime;
        /// <summary>
        /// 格式为数字加后缀（D表示天，H表示小时，M表示分钟），如1D
        /// </summary>
        [Column(FieldName = "Limittime", DataKey = false, Match = "", IsInsert = true)]
        public string Limittime
        {
            get { return  _limittime; }
            set {  _limittime = value; }
        }

        private string  _memo;
        /// <summary>
        /// 消息类型说明
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

        private int  _status;
        /// <summary>
        /// 消息类型状态0=启用，1=停用
        /// </summary>
        [Column(FieldName = "Status", DataKey = false, Match = "", IsInsert = true)]
        public int Status
        {
            get { return  _status; }
            set {  _status = value; }
        }

    }
}
