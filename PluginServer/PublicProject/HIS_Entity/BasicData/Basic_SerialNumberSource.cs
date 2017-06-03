using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_SerialNumberSource", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_SerialNumberSource:AbstractEntity
    {
        private int  _sntype;
        /// <summary>
        /// 流水号类型，0门诊流水号 1住院流水号
        /// </summary>
        [Column(FieldName = "SNType", DataKey = false, Match = "", IsInsert = true)]
        public int SNType
        {
            get { return  _sntype; }
            set {  _sntype = value; }
        }

        private DateTime  _currdate;
        /// <summary>
        /// 当前日期
        /// </summary>
        [Column(FieldName = "CurrDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CurrDate
        {
            get { return  _currdate; }
            set {  _currdate = value; }
        }

        private int  _currsequence;
        /// <summary>
        /// 当前序号
        /// </summary>
        [Column(FieldName = "CurrSequence", DataKey = false, Match = "", IsInsert = true)]
        public int CurrSequence
        {
            get { return  _currsequence; }
            set {  _currsequence = value; }
        }

    }
}
