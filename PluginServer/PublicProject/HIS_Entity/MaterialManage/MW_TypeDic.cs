using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_TypeDic", EntityType = EntityType.Table, IsGB = false)]
    public class MW_TypeDic:AbstractEntity
    {
        private int  _typeid;
        /// <summary>
        /// 药品类型标识ID
        /// </summary>
        [Column(FieldName = "TypeID", DataKey = true, Match = "", IsInsert = false)]
        public int TypeID
        {
            get { return  _typeid; }
            set {  _typeid = value; }
        }

        private int  _parentid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ParentID", DataKey = false, Match = "", IsInsert = true)]
        public int ParentID
        {
            get { return  _parentid; }
            set {  _parentid = value; }
        }

        private string  _typename;
        /// <summary>
        /// 类型名称
        /// </summary>
        [Column(FieldName = "TypeName", DataKey = false, Match = "", IsInsert = true)]
        public string TypeName
        {
            get { return  _typename; }
            set {  _typename = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private int  _level;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Level", DataKey = false, Match = "", IsInsert = true)]
        public int Level
        {
            get { return  _level; }
            set {  _level = value; }
        }

    }
}
