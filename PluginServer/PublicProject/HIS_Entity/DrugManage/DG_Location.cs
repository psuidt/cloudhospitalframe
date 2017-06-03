using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_Location", EntityType = EntityType.Table, IsGB = false)]
    public class DG_Location:AbstractEntity
    {
        private int  _locationid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LocationID", DataKey = true, Match = "", IsInsert = false)]
        public int LocationID
        {
            get { return  _locationid; }
            set {  _locationid = value; }
        }

        private int  _parentid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ParentID", DataKey = false, Match = "", IsInsert = true)]
        public int ParentID
        {
            get { return  _parentid; }
            set {  _parentid = value; }
        }

        private string  _locationname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LocationName", DataKey = false, Match = "", IsInsert = true)]
        public string LocationName
        {
            get { return  _locationname; }
            set {  _locationname = value; }
        }

        private int  _isleafnode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsLeafNode", DataKey = false, Match = "", IsInsert = true)]
        public int IsLeafNode
        {
            get { return  _isleafnode; }
            set {  _isleafnode = value; }
        }

        private string  _remark;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

    }
}
