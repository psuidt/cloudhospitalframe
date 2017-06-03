using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_RegItemFee", EntityType = EntityType.Table, IsGB = false)]
    public class OP_RegItemFee:AbstractEntity
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

        private int  _regtypeID;
        /// <summary>
        /// 挂号类型代码
        /// </summary>
        [Column(FieldName = "RegTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int RegTypeID
        {
            get { return  _regtypeID; }
            set {  _regtypeID = value; }
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

        private int  _flag;
        /// <summary>
        /// 是否是附加费
        /// </summary>
        [Column(FieldName = "Flag", DataKey = false, Match = "", IsInsert = true)]
        public int Flag
        {
            get { return  _flag; }
            set {  _flag = value; }
        }

    }
}
