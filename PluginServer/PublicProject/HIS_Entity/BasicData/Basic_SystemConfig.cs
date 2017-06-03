using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_SystemConfig", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_SystemConfig:AbstractEntity
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

        private int  _systemtype;
        /// <summary>
        /// 参数类型，0平台 1门诊 2住院 3药品
        /// </summary>
        [Column(FieldName = "SystemType", DataKey = false, Match = "", IsInsert = true)]
        public int SystemType
        {
            get { return  _systemtype; }
            set {  _systemtype = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 科室，药品参数需要区分科室
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private string  _paraid;
        /// <summary>
        /// 参数标识
        /// </summary>
        [Column(FieldName = "ParaID", DataKey = false, Match = "", IsInsert = true)]
        public string ParaID
        {
            get { return  _paraid; }
            set {  _paraid = value; }
        }

        private string  _paraname;
        /// <summary>
        /// 参数名称
        /// </summary>
        [Column(FieldName = "ParaName", DataKey = false, Match = "", IsInsert = true)]
        public string ParaName
        {
            get { return  _paraname; }
            set {  _paraname = value; }
        }

        private string  _value;
        /// <summary>
        /// 参数值
        /// </summary>
        [Column(FieldName = "Value", DataKey = false, Match = "", IsInsert = true)]
        public string Value
        {
            get { return  _value; }
            set {  _value = value; }
        }

        private int  _datatype;
        /// <summary>
        /// 数据类型 0文本 1下拉
        /// </summary>
        [Column(FieldName = "DataType", DataKey = false, Match = "", IsInsert = true)]
        public int DataType
        {
            get { return  _datatype; }
            set {  _datatype = value; }
        }

        private string  _prompt;
        /// <summary>
        /// 下拉数据
        /// </summary>
        [Column(FieldName = "Prompt", DataKey = false, Match = "", IsInsert = true)]
        public string Prompt
        {
            get { return  _prompt; }
            set {  _prompt = value; }
        }

        private string  _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

        private int _delflag;
        /// <summary>
        /// 数据类型 0文本 1下拉
        /// </summary>
        [Column(FieldName = "Delflag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }
    }
}
