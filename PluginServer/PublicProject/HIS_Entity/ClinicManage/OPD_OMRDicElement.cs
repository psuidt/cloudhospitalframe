using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_OMRDicElement", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_OMRDicElement:AbstractEntity
    {
        private int  _omrdicelementid;
        /// <summary>
        /// 门诊病历库元素ID
        /// </summary>
        [Column(FieldName = "OMRDicElementID", DataKey = true, Match = "", IsInsert = false)]
        public int OMRDicElementID
        {
            get { return  _omrdicelementid; }
            set {  _omrdicelementid = value; }
        }

        private int  _omrdiccategoryid;
        /// <summary>
        /// 门诊病历库分类ID
        /// </summary>
        [Column(FieldName = "OMRDicCategoryID", DataKey = false, Match = "", IsInsert = true)]
        public int OMRDicCategoryID
        {
            get { return  _omrdiccategoryid; }
            set {  _omrdiccategoryid = value; }
        }

        private string  _elementname;
        /// <summary>
        /// 元素名称
        /// </summary>
        [Column(FieldName = "ElementName", DataKey = false, Match = "", IsInsert = true)]
        public string ElementName
        {
            get { return  _elementname; }
            set {  _elementname = value; }
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
