using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_DeptDic", EntityType = EntityType.Table, IsGB = false)]
    public class DG_DeptDic:AbstractEntity
    {
        private int  _deptdicid;
        /// <summary>
        /// 药剂科室典标识ID
        /// </summary>
        [Column(FieldName = "DeptDicID", DataKey = true, Match = "", IsInsert = false)]
        public int DeptDicID
        {
            get { return  _deptdicid; }
            set {  _deptdicid = value; }
        }

        private string  _deptname;
        /// <summary>
        /// 科室名称
        /// </summary>
        [Column(FieldName = "DeptName", DataKey = false, Match = "", IsInsert = true)]
        public string DeptName
        {
            get { return  _deptname; }
            set {  _deptname = value; }
        }

        private string  _deptcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DeptCode", DataKey = false, Match = "", IsInsert = true)]
        public string DeptCode
        {
            get { return  _deptcode; }
            set {  _deptcode = value; }
        }

        private int  _depttype;
        /// <summary>
        /// 科室类型
        /// </summary>
        [Column(FieldName = "DeptType", DataKey = false, Match = "", IsInsert = true)]
        public int DeptType
        {
            get { return  _depttype; }
            set {  _depttype = value; }
        }

        private int  _stopflag;
        /// <summary>
        /// 启用标识
        /// </summary>
        [Column(FieldName = "StopFlag", DataKey = false, Match = "", IsInsert = true)]
        public int StopFlag
        {
            get { return  _stopflag; }
            set {  _stopflag = value; }
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

        private int  _checkstatus;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CheckStatus", DataKey = false, Match = "", IsInsert = true)]
        public int CheckStatus
        {
            get { return  _checkstatus; }
            set {  _checkstatus = value; }
        }

    }
}
