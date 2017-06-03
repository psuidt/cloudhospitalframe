using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_ChildTypeDic", EntityType = EntityType.Table, IsGB = false)]
    public class DG_ChildTypeDic:AbstractEntity
    {
        private int  _ctypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int CTypeID
        {
            get { return  _ctypeid; }
            set {  _ctypeid = value; }
        }

        private int  _typeid;
        /// <summary>
        /// 药品类型标识ID
        /// </summary>
        [Column(FieldName = "TypeID", DataKey = false, Match = "", IsInsert = true)]
        public int TypeID
        {
            get { return  _typeid; }
            set {  _typeid = value; }
        }

        private string  _ctypename;
        /// <summary>
        /// 类型名称
        /// </summary>
        [Column(FieldName = "CTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string CTypeName
        {
            get { return  _ctypename; }
            set {  _ctypename = value; }
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
