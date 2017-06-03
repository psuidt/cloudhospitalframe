using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_CenterStatItem", EntityType = EntityType.Table, IsGB = true)]
    public class Basic_CenterStatItem:AbstractEntity
    {
        private int  _statid;
        /// <summary>
        /// 统计大类ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = true, Match = "", IsInsert = false)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
        }

        private int  _pstatid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PStatID", DataKey = false, Match = "", IsInsert = true)]
        public int PStatID
        {
            get { return  _pstatid; }
            set {  _pstatid = value; }
        }

        private string  _statname;
        /// <summary>
        /// 大类名称
        /// </summary>
        [Column(FieldName = "StatName", DataKey = false, Match = "", IsInsert = true)]
        public string StatName
        {
            get { return  _statname; }
            set {  _statname = value; }
        }
        /// <summary>
        /// 父类名称
        /// </summary>
        public string PStatName
        {
            get;
            set;
        }

        private string  _numcode;
        /// <summary>
        /// 大类编码
        /// </summary>
        [Column(FieldName = "NumCode", DataKey = false, Match = "", IsInsert = true)]
        public string NumCode
        {
            get { return  _numcode; }
            set {  _numcode = value; }
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
