using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_BedInfo", EntityType = EntityType.Table, IsGB = false)]
    public class IP_BedInfo : AbstractEntity
    {
        private int _bedid;
        /// <summary>
        /// 床位ID
        /// </summary>
        [Column(FieldName = "BedID", DataKey = true, Match = "", IsInsert = false)]
        public int BedID
        {
            get { return _bedid; }
            set { _bedid = value; }
        }

        private int _deptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return _deptid; }
            set { _deptid = value; }
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

        private string _roomno;
        /// <summary>
        /// 房间号
        /// </summary>
        [Column(FieldName = "RoomNO", DataKey = false, Match = "", IsInsert = true)]
        public string RoomNO
        {
            get { return _roomno; }
            set { _roomno = value; }
        }

        private string _bedno;
        /// <summary>
        /// 床号
        /// </summary>
        [Column(FieldName = "BedNO", DataKey = false, Match = "", IsInsert = true)]
        public string BedNO
        {
            get { return _bedno; }
            set { _bedno = value; }
        }

        private int _beddoctorid;
        /// <summary>
        /// 主治医生
        /// </summary>
        [Column(FieldName = "BedDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int BedDoctorID
        {
            get { return _beddoctorid; }
            set { _beddoctorid = value; }
        }

        private int _bednurseid;
        /// <summary>
        /// 住院医生
        /// </summary>
        [Column(FieldName = "BedNurseID", DataKey = false, Match = "", IsInsert = true)]
        public int BedNurseID
        {
            get { return _bednurseid; }
            set { _bednurseid = value; }
        }

        private int _isplus;
        /// <summary>
        /// 是否加床
        /// </summary>
        [Column(FieldName = "IsPlus", DataKey = false, Match = "", IsInsert = true)]
        public int IsPlus
        {
            get { return _isplus; }
            set { _isplus = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private string _patname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

        private string _patsex;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatSex", DataKey = false, Match = "", IsInsert = true)]
        public string PatSex
        {
            get { return _patsex; }
            set { _patsex = value; }
        }

        private int _patdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDeptID
        {
            get { return _patdeptid; }
            set { _patdeptid = value; }
        }

        private int _patdoctorid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PatDoctorID
        {
            get { return _patdoctorid; }
            set { _patdoctorid = value; }
        }

        private int _patnurseid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatNurseID", DataKey = false, Match = "", IsInsert = true)]
        public int PatNurseID
        {
            get { return _patnurseid; }
            set { _patnurseid = value; }
        }

        private int _babyid;
        /// <summary>
        /// 婴儿ID
        /// </summary>
        [Column(FieldName = "BabyID", DataKey = false, Match = "", IsInsert = true)]
        public int BabyID
        {
            get { return _babyid; }
            set { _babyid = value; }
        }

        private int _isused;
        /// <summary>
        /// 是否在用
        /// </summary>
        [Column(FieldName = "IsUsed", DataKey = false, Match = "", IsInsert = true)]
        public int IsUsed
        {
            get { return _isused; }
            set { _isused = value; }
        }

        private int _isstoped;
        /// <summary>
        /// 是否停用
        /// </summary>
        [Column(FieldName = "IsStoped", DataKey = false, Match = "", IsInsert = true)]
        public int IsStoped
        {
            get { return _isstoped; }
            set { _isstoped = value; }
        }

        private int _ispack;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsPack", DataKey = false, Match = "", IsInsert = true)]
        public int IsPack
        {
            get { return _ispack; }
            set { _ispack = value; }
        }

    }
}
