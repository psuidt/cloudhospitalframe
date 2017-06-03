using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseWardDept", EntityType = EntityType.Table, IsGB = false)]
    public class BaseWardDept : AbstractEntity
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

        private int _deptid;
        /// <summary>
        /// 科室ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return _deptid; }
            set { _deptid = value; }
        }

        /// <summary>
        /// 是否关联(用于业务)
        /// </summary>
        public bool IsRel { get; set; }
    }
}
