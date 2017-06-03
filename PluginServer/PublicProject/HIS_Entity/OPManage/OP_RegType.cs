using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_RegType", EntityType = EntityType.Table, IsGB = false)]
    public class OP_RegType:AbstractEntity
    {
        private int  _regtypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int RegTypeID
        {
            get { return  _regtypeid; }
            set {  _regtypeid = value; }
        }

        private string  _regtypecode;
        /// <summary>
        /// 挂号类型代码
        /// </summary>
        [Column(FieldName = "RegTypeCode", DataKey = false, Match = "", IsInsert = true)]
        public string RegTypeCode
        {
            get { return  _regtypecode; }
            set {  _regtypecode = value; }
        }

        private string  _regtypename;
        /// <summary>
        /// 挂号类型名称
        /// </summary>
        [Column(FieldName = "RegTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string RegTypeName
        {
            get { return  _regtypename; }
            set {  _regtypename = value; }
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

        private int  _flag;
        /// <summary>
        /// 有效标识 1有效 0无效
        /// </summary>
        [Column(FieldName = "Flag", DataKey = false, Match = "", IsInsert = true)]
        public int Flag
        {
            get { return  _flag; }
            set {  _flag = value; }
        }

    }
}
