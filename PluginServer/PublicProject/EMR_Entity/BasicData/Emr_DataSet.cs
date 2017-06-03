using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_DataSet", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_DataSet:AbstractEntity
    {
        private int  _datasetid;
        /// <summary>
        /// 数据集唯一标识
        /// </summary>
        [Column(FieldName = "DataSetID", DataKey = true, Match = "", IsInsert = false)]
        public int DataSetID
        {
            get { return  _datasetid; }
            set {  _datasetid = value; }
        }

        private string  _code;
        /// <summary>
        /// 数据集编码
        /// </summary>
        [Column(FieldName = "Code", DataKey = false, Match = "", IsInsert = true)]
        public string Code
        {
            get { return  _code; }
            set {  _code = value; }
        }

        private string  _datasetname;
        /// <summary>
        /// 数据集名称
        /// </summary>
        [Column(FieldName = "DataSetName", DataKey = false, Match = "", IsInsert = true)]
        public string DataSetName
        {
            get { return  _datasetname; }
            set {  _datasetname = value; }
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

        private string  _describe;
        /// <summary>
        /// 数据集描述
        /// </summary>
        [Column(FieldName = "Describe", DataKey = false, Match = "", IsInsert = true)]
        public string Describe
        {
            get { return  _describe; }
            set {  _describe = value; }
        }

        private int  _bindtype;
        /// <summary>
        /// 绑定类型 0类实体1Datatable
        /// </summary>
        [Column(FieldName = "BindType", DataKey = false, Match = "", IsInsert = true)]
        public int BindType
        {
            get { return  _bindtype; }
            set {  _bindtype = value; }
        }

        private string  _classname;
        /// <summary>
        /// 类名或表名
        /// </summary>
        [Column(FieldName = "ClassName", DataKey = false, Match = "", IsInsert = true)]
        public string ClassName
        {
            get { return  _classname; }
            set {  _classname = value; }
        }

        private string  _readservice;
        /// <summary>
        /// 读取数据服务标识
        /// </summary>
        [Column(FieldName = "ReadService", DataKey = false, Match = "", IsInsert = true)]
        public string ReadService
        {
            get { return  _readservice; }
            set {  _readservice = value; }
        }

        private string  _updateservice;
        /// <summary>
        /// 更新数据服务标识
        /// </summary>
        [Column(FieldName = "UpdateService", DataKey = false, Match = "", IsInsert = true)]
        public string UpdateService
        {
            get { return  _updateservice; }
            set {  _updateservice = value; }
        }

        private int  _isautoupdate;
        /// <summary>
        /// 保存时自动更新 0不更新1自动更新
        /// </summary>
        [Column(FieldName = "IsAutoUpdate", DataKey = false, Match = "", IsInsert = true)]
        public int IsAutoUpdate
        {
            get { return  _isautoupdate; }
            set {  _isautoupdate = value; }
        }

        private int  _iscenter;
        /// <summary>
        /// 是否中心数据集：0中心1本院
        /// </summary>
        [Column(FieldName = "IsCenter", DataKey = false, Match = "", IsInsert = true)]
        public int IsCenter
        {
            get { return  _iscenter; }
            set {  _iscenter = value; }
        }

    }
}
