using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_TypeDic", EntityType = EntityType.Table, IsGB = true)]
    public class DG_TypeDic:AbstractEntity
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

    }
}
