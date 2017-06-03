using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_Dept_Type", EntityType = EntityType.Table, IsGB = false)]
    public class DG_Dept_Type:AbstractEntity
    {
        private int  _relationid;
        /// <summary>
        /// 科室类型表标识ID
        /// </summary>
        [Column(FieldName = "RelationID", DataKey = true, Match = "", IsInsert = false)]
        public int RelationID
        {
            get { return  _relationid; }
            set {  _relationid = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 对应部门ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _drugtypeid;
        /// <summary>
        /// 药品类型标识ID
        /// </summary>
        [Column(FieldName = "DrugTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugTypeID
        {
            get { return  _drugtypeid; }
            set {  _drugtypeid = value; }
        }

        private int  _mattypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int MatTypeID
        {
            get { return  _mattypeid; }
            set {  _mattypeid = value; }
        }

    }
}
