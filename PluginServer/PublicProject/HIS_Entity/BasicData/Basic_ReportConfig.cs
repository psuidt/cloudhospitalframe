using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_ReportConfig", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_ReportConfig:AbstractEntity
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

        private int  _reporttype;
        /// <summary>
        /// 报表分类，0平台 1门诊 2住院 3药品
        /// </summary>
        [Column(FieldName = "ReportType", DataKey = false, Match = "", IsInsert = true)]
        public int ReportType
        {
            get { return  _reporttype; }
            set {  _reporttype = value; }
        }

        private int  _enumvalue;
        /// <summary>
        /// 报表编码
        /// </summary>
        [Column(FieldName = "EnumValue", DataKey = false, Match = "", IsInsert = true)]
        public int EnumValue
        {
            get { return  _enumvalue; }
            set {  _enumvalue = value; }
        }

        private string  _reporttitle;
        /// <summary>
        /// 报表名称
        /// </summary>
        [Column(FieldName = "ReportTitle", DataKey = false, Match = "", IsInsert = true)]
        public string ReportTitle
        {
            get { return  _reporttitle; }
            set {  _reporttitle = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _filename;
        /// <summary>
        /// 文件名称
        /// </summary>
        [Column(FieldName = "FileName", DataKey = false, Match = "", IsInsert = true)]
        public string FileName
        {
            get { return  _filename; }
            set {  _filename = value; }
        }

        private Byte[]  _format;
        /// <summary>
        /// 存储报表文件
        /// </summary>
        [Column(FieldName = "Format", DataKey = false, Match = "", IsInsert = true)]
        public Byte[] Format
        {
            get { return  _format; }
            set {  _format = value; }
        }

        private DateTime  _updatetime;
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private string  _modifyer;
        /// <summary>
        /// 修改人
        /// </summary>
        [Column(FieldName = "Modifyer", DataKey = false, Match = "", IsInsert = true)]
        public string Modifyer
        {
            get { return  _modifyer; }
            set {  _modifyer = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
