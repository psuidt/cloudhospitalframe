using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_BedFee", EntityType = EntityType.Table, IsGB = false)]
    public class IP_BedFee:AbstractEntity
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

        private int  _bedid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BedID", DataKey = false, Match = "", IsInsert = true)]
        public int BedID
        {
            get { return  _bedid; }
            set {  _bedid = value; }
        }

        private int  _feetype;
        /// <summary>
        /// 床位费类型 0默认床位费 1包床床位费
        /// </summary>
        [Column(FieldName = "FeeType", DataKey = false, Match = "", IsInsert = true)]
        public int FeeType
        {
            get { return  _feetype; }
            set {  _feetype = value; }
        }

        private int  _feeclass;
        /// <summary>
        /// 费用类别，1项目 2材料 3药品
        /// </summary>
        [Column(FieldName = "FeeClass", DataKey = false, Match = "", IsInsert = true)]
        public int FeeClass
        {
            get { return  _feeclass; }
            set {  _feeclass = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private string  _itemunit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ItemUnit", DataKey = false, Match = "", IsInsert = true)]
        public string ItemUnit
        {
            get { return  _itemunit; }
            set {  _itemunit = value; }
        }

        private int  _itemamount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ItemAmount", DataKey = false, Match = "", IsInsert = true)]
        public int ItemAmount
        {
            get { return  _itemamount; }
            set {  _itemamount = value; }
        }

    }
}
