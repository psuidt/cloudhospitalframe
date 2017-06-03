using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_PatType", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_PatType:AbstractEntity
    {
        private int  _pattypeid;
        /// <summary>
        /// 病人类型ID
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int PatTypeID
        {
            get { return  _pattypeid; }
            set {  _pattypeid = value; }
        }

        private string  _pattypecode;
        /// <summary>
        /// 病人类型代码
        /// </summary>
        [Column(FieldName = "PatTypeCode", DataKey = false, Match = "", IsInsert = true)]
        public string PatTypeCode
        {
            get { return  _pattypecode; }
            set {  _pattypecode = value; }
        }

        private string  _pattypename;
        /// <summary>
        /// 病人类型名称
        /// </summary>
        [Column(FieldName = "PatTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string PatTypeName
        {
            get { return  _pattypename; }
            set {  _pattypename = value; }
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

        private int  _sortorder;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return  _sortorder; }
            set {  _sortorder = value; }
        }

    }
}
