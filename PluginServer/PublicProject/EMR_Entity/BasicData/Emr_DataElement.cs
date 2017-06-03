using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_DataElement", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_DataElement:AbstractEntity
    {
        private int  _dataelementid;
        /// <summary>
        /// 数据元素唯一标识
        /// </summary>
        [Column(FieldName = "DataElementID", DataKey = true, Match = "", IsInsert = false)]
        public int DataElementID
        {
            get { return  _dataelementid; }
            set {  _dataelementid = value; }
        }

        private int  _datasetid;
        /// <summary>
        /// 数据集唯一标识
        /// </summary>
        [Column(FieldName = "DataSetID", DataKey = false, Match = "", IsInsert = true)]
        public int DataSetID
        {
            get { return  _datasetid; }
            set {  _datasetid = value; }
        }

        private string  _code;
        /// <summary>
        /// 数据元编码
        /// </summary>
        [Column(FieldName = "Code", DataKey = false, Match = "", IsInsert = true)]
        public string Code
        {
            get { return  _code; }
            set {  _code = value; }
        }

        private string  _elementname;
        /// <summary>
        /// 数据元名称
        /// </summary>
        [Column(FieldName = "ElementName", DataKey = false, Match = "", IsInsert = true)]
        public string ElementName
        {
            get { return  _elementname; }
            set {  _elementname = value; }
        }

        private int  _datatype;
        /// <summary>
        /// 数据类型 0=字符1=数字2=时间日期3=多选
        /// </summary>
        [Column(FieldName = "DataType", DataKey = false, Match = "", IsInsert = true)]
        public int DataType
        {
            get { return  _datatype; }
            set {  _datatype = value; }
        }

        private string  _propertyname;
        /// <summary>
        /// 字段属性名
        /// </summary>
        [Column(FieldName = "PropertyName", DataKey = false, Match = "", IsInsert = true)]
        public string PropertyName
        {
            get { return  _propertyname; }
            set {  _propertyname = value; }
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

    }
}
