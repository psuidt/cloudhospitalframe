using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_MedicalTemplateType", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_MedicalTemplateType:AbstractEntity
    {
        private int  _temptypeid;
        /// <summary>
        /// 分类ID
        /// </summary>
        [Column(FieldName = "TempTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int TempTypeID
        {
            get { return  _temptypeid; }
            set {  _temptypeid = value; }
        }

        private string  _temptypecode;
        /// <summary>
        /// 分类编码
        /// </summary>
        [Column(FieldName = "TempTypeCode", DataKey = false, Match = "", IsInsert = true)]
        public string TempTypeCode
        {
            get { return  _temptypecode; }
            set {  _temptypecode = value; }
        }

        private string  _temptypename;
        /// <summary>
        /// 分类名称
        /// </summary>
        [Column(FieldName = "TempTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string TempTypeName
        {
            get { return  _temptypename; }
            set {  _temptypename = value; }
        }

        private int  _treeid;
        /// <summary>
        /// 病历树ID
        /// </summary>
        [Column(FieldName = "TreeID", DataKey = false, Match = "", IsInsert = true)]
        public int TreeID
        {
            get { return  _treeid; }
            set {  _treeid = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PyCode", DataKey = false, Match = "", IsInsert = true)]
        public string PyCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WbCode", DataKey = false, Match = "", IsInsert = true)]
        public string WbCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private string  _remark;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private int  _isstop;
        /// <summary>
        /// 停用状态 0 启用 1 停用
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return  _isstop; }
            set {  _isstop = value; }
        }

    }
}
