using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "Basic_ExecuteBillChannel", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_ExecuteBillChannel:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _execbillid;
        /// <summary>
        /// 执行单ID
        /// </summary>
        [Column(FieldName = "ExecBillID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecBillID
        {
            get { return  _execbillid; }
            set {  _execbillid = value; }
        }

        private int  _channelid;
        /// <summary>
        /// 用法ID
        /// </summary>
        [Column(FieldName = "ChannelID", DataKey = false, Match = "", IsInsert = true)]
        public int ChannelID
        {
            get { return  _channelid; }
            set {  _channelid = value; }
        }

    }
}
