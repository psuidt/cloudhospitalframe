using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "Basic_ChannelFee", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_ChannelFee:AbstractEntity
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

        private int  _feeclass;
        /// <summary>
        /// 费用类别，1项目 2材料
        /// </summary>
        [Column(FieldName = "FeeClass", DataKey = false, Match = "", IsInsert = true)]
        public int FeeClass
        {
            get { return  _feeclass; }
            set {  _feeclass = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private string  _itemunit;
        /// <summary>
        /// 项目单位
        /// </summary>
        [Column(FieldName = "ItemUnit", DataKey = false, Match = "", IsInsert = true)]
        public string ItemUnit
        {
            get { return  _itemunit; }
            set {  _itemunit = value; }
        }

        private int  _itemamount;
        /// <summary>
        /// 项目数量
        /// </summary>
        [Column(FieldName = "ItemAmount", DataKey = false, Match = "", IsInsert = true)]
        public int ItemAmount
        {
            get { return  _itemamount; }
            set {  _itemamount = value; }
        }

        private int  _calcostmode;
        /// <summary>
        /// 计费模式，0按频次 1按周期
        /// </summary>
        [Column(FieldName = "CalCostMode", DataKey = false, Match = "", IsInsert = true)]
        public int CalCostMode
        {
            get { return  _calcostmode; }
            set {  _calcostmode = value; }
        }

    }
}
