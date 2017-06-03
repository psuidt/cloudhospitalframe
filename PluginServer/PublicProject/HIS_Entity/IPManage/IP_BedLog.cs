using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_BedLog", EntityType = EntityType.Table, IsGB = false)]
    public class IP_BedLog:AbstractEntity
    {
        private int  _bedlogid;
        /// <summary>
        /// 分配ID
        /// </summary>
        [Column(FieldName = "BedLogID", DataKey = true, Match = "", IsInsert = false)]
        public int BedLogID
        {
            get { return  _bedlogid; }
            set {  _bedlogid = value; }
        }

        private int  _bedid;
        /// <summary>
        /// 床位ID
        /// </summary>
        [Column(FieldName = "BedID", DataKey = false, Match = "", IsInsert = true)]
        public int BedID
        {
            get { return  _bedid; }
            set {  _bedid = value; }
        }

        private string  _bedno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BedNo", DataKey = false, Match = "", IsInsert = true)]
        public string BedNo
        {
            get { return  _bedno; }
            set {  _bedno = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 科室代码
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _wardid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WardID", DataKey = false, Match = "", IsInsert = true)]
        public int WardID
        {
            get { return  _wardid; }
            set {  _wardid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private string  _patsex;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatSex", DataKey = false, Match = "", IsInsert = true)]
        public string PatSex
        {
            get { return  _patsex; }
            set {  _patsex = value; }
        }

        private int  _patdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDeptID
        {
            get { return  _patdeptid; }
            set {  _patdeptid = value; }
        }

        private int  _patdoctorid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDoctorID
        {
            get { return  _patdoctorid; }
            set {  _patdoctorid = value; }
        }

        private int  _patnurseid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatNurseID", DataKey = false, Match = "", IsInsert = true)]
        public int PatNurseID
        {
            get { return  _patnurseid; }
            set {  _patnurseid = value; }
        }

        private int  _babyid;
        /// <summary>
        /// 婴儿代码
        /// </summary>
        [Column(FieldName = "BabyID", DataKey = false, Match = "", IsInsert = true)]
        public int BabyID
        {
            get { return  _babyid; }
            set {  _babyid = value; }
        }

        private DateTime  _assigndate;
        /// <summary>
        /// 变更日期
        /// </summary>
        [Column(FieldName = "AssignDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AssignDate
        {
            get { return  _assigndate; }
            set {  _assigndate = value; }
        }

        private int  _assignempid;
        /// <summary>
        /// 变更人
        /// </summary>
        [Column(FieldName = "AssignEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int AssignEmpID
        {
            get { return  _assignempid; }
            set {  _assignempid = value; }
        }

    }
}
