using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseEmpWard", EntityType = EntityType.Table, IsGB = false)]
    public class BaseEmpWard : AbstractEntity
    {
        //[Column(FieldName = "WorkId", DataKey = false, Match = "", IsInsert = true)]
        //public int WorkId { get; set; }

        private int _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _empid;
        /// <summary>
        /// 员工ID
        /// </summary>
        [Column(FieldName = "EmpID", DataKey = false, Match = "", IsInsert = true)]
        public int EmpID
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private int _wardid;
        /// <summary>
        /// 病区ID
        /// </summary>
        [Column(FieldName = "WardID", DataKey = false, Match = "", IsInsert = true)]
        public int WardID
        {
            get { return _wardid; }
            set { _wardid = value; }
        }

        private int _defaultflag;
        /// <summary>
        /// 默认科室标识
        /// </summary>
        [Column(FieldName = "DefaultFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DefaultFlag
        {
            get { return _defaultflag; }
            set { _defaultflag = value; }
        }
    }
}
