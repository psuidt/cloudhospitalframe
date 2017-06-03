using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_DeptRelation", EntityType = EntityType.Table, IsGB = false)]
    public class DG_DeptRelation:AbstractEntity
    {
        private int  _drugdeptid;
        /// <summary>
        /// 药剂科室ID
        /// </summary>
        [Column(FieldName = "DrugDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugDeptID
        {
            get { return  _drugdeptid; }
            set {  _drugdeptid = value; }
        }

        private int  _relationdeptid;
        /// <summary>
        /// 往来科室ID
        /// </summary>
        [Column(FieldName = "RelationDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int RelationDeptID
        {
            get { return  _relationdeptid; }
            set {  _relationdeptid = value; }
        }

        private string  _relationdeptname;
        /// <summary>
        /// 往来科室名称
        /// </summary>
        [Column(FieldName = "RelationDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string RelationDeptName
        {
            get { return  _relationdeptname; }
            set {  _relationdeptname = value; }
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

        private DateTime  _updatetime;
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private int  _regempid;
        /// <summary>
        /// 记录员ID
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
        }

        private int _relationDeptType;
        /// <summary>
        /// 记录员ID
        /// </summary>
        [Column(FieldName = "RelationDeptType", DataKey = false, Match = "", IsInsert = true)]
        public int RelationDeptType
        {
            get { return _relationDeptType; }
            set { _relationDeptType = value; }
        }
    }
}
