using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_Disease", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_Disease:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 病种ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private string  _icdcode;
        /// <summary>
        /// 病种编码
        /// </summary>
        [Column(FieldName = "ICDCode", DataKey = false, Match = "", IsInsert = true)]
        public string ICDCode
        {
            get { return  _icdcode; }
            set {  _icdcode = value; }
        }

        private string  _name;
        /// <summary>
        /// 病种名称
        /// </summary>
        [Column(FieldName = "Name", DataKey = false, Match = "", IsInsert = true)]
        public string Name
        {
            get { return  _name; }
            set {  _name = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 病种拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 病种五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private string  _type;
        /// <summary>
        /// 类型
        /// </summary>
        [Column(FieldName = "Type", DataKey = false, Match = "", IsInsert = true)]
        public string Type
        {
            get { return  _type; }
            set {  _type = value; }
        }

    }
}
