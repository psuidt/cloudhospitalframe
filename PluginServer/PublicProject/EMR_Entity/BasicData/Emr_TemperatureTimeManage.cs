using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_TemperatureTimeManage", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_TemperatureTimeManage : AbstractEntity
    {
        private int _timeid;
        /// <summary>
        /// 时间管理ID
        /// </summary>
        [Column(FieldName = "TimeID", DataKey = true, Match = "", IsInsert = false)]
        public int TimeID
        {
            get { return _timeid; }
            set { _timeid = value; }
        }

        private int _patListID;
        /// <summary>
        /// 三测单ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return _patListID; }
            set { _patListID = value; }
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

        private string _deptname;
        /// <summary>
        /// 记录科室名
        /// </summary>
        [Column(FieldName = "DeptName", DataKey = false, Match = "", IsInsert = true)]
        public string DeptName
        {
            get { return _deptname; }
            set { _deptname = value; }
        }

        private int _recordempid;
        /// <summary>
        /// 记录人ID
        /// </summary>
        [Column(FieldName = "RecordEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RecordEmpID
        {
            get { return _recordempid; }
            set { _recordempid = value; }
        }

        private string _recordempname;
        /// <summary>
        /// 记录人名
        /// </summary>
        [Column(FieldName = "RecordEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string RecordEmpName
        {
            get { return _recordempname; }
            set { _recordempname = value; }
        }

        private string _timetypecode;
        /// <summary>
        /// 时间类型Code
        /// </summary>
        [Column(FieldName = "TimeTypeCode", DataKey = false, Match = "", IsInsert = true)]
        public string TimeTypeCode
        {
            get { return _timetypecode; }
            set { _timetypecode = value; }
        }

        private DateTime _operationdate;
        /// <summary>
        /// 操作时间
        /// </summary>
        [Column(FieldName = "OperationDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperationDate
        {
            get { return _operationdate; }
            set { _operationdate = value; }
        }

        private DateTime _displaydate;
        /// <summary>
        /// 显示时间
        /// </summary>
        [Column(FieldName = "DisPlayDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime DisPlayDate
        {
            get { return _displaydate; }
            set { _displaydate = value; }
        }

        private int _delflag;
        /// <summary>
        /// 删除标志0正常，1删除
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }

    }
}