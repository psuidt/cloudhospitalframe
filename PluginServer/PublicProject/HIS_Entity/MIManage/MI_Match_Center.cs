using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_Match_Center", EntityType = EntityType.Table, IsGB = false)]
    public class MI_Match_Center:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = false, Match = "", IsInsert = true)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _miid;
        /// <summary>
        /// 医保类型ID
        /// </summary>
        [Column(FieldName = "MIID", DataKey = false, Match = "", IsInsert = true)]
        public int MIID
        {
            get { return  _miid; }
            set {  _miid = value; }
        }

        private int  _itemtype;
        /// <summary>
        /// 目录类型
        /// </summary>
        [Column(FieldName = "ItemType", DataKey = false, Match = "", IsInsert = true)]
        public int ItemType
        {
            get { return  _itemtype; }
            set {  _itemtype = value; }
        }

        private string  _centeritemcode;
        /// <summary>
        /// 中心目录编码
        /// </summary>
        [Column(FieldName = "CenterItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string CenterItemCode
        {
            get { return  _centeritemcode; }
            set {  _centeritemcode = value; }
        }

        private string  _ybitemcode;
        /// <summary>
        /// 医保目录编码
        /// </summary>
        [Column(FieldName = "YBItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string YBItemCode
        {
            get { return  _ybitemcode; }
            set {  _ybitemcode = value; }
        }

        private string  _ybitemname;
        /// <summary>
        /// 医保目录名称
        /// </summary>
        [Column(FieldName = "YBItemName", DataKey = false, Match = "", IsInsert = true)]
        public string YBItemName
        {
            get { return  _ybitemname; }
            set {  _ybitemname = value; }
        }

    }
}
