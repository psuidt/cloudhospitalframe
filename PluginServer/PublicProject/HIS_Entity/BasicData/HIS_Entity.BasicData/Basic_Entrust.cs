using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_Entrust", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_Entrust:AbstractEntity
    {
        private int  _entrustid;
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "EntrustID", DataKey = true, Match = "", IsInsert = false)]
        public int EntrustID
        {
            get { return  _entrustid; }
            set {  _entrustid = value; }
        }

        private string  _entrustname;
        /// <summary>
        /// 嘱托内容
        /// </summary>
        [Column(FieldName = "EntrustName", DataKey = false, Match = "", IsInsert = true)]
        public string EntrustName
        {
            get { return  _entrustname; }
            set {  _entrustname = value; }
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

        private int  _delflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
