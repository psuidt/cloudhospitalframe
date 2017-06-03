using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_ExamItemFee", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_ExamItemFee:AbstractEntity
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

        private int  _examitemid;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        [Column(FieldName = "ExamItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ExamItemID
        {
            get { return  _examitemid; }
            set {  _examitemid = value; }
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
        /// 数量
        /// </summary>
        [Column(FieldName = "ItemAmount", DataKey = false, Match = "", IsInsert = true)]
        public int ItemAmount
        {
            get { return  _itemamount; }
            set {  _itemamount = value; }
        }

    }
}
