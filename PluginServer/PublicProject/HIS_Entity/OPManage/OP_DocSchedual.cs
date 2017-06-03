using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_DocSchedual", EntityType = EntityType.Table, IsGB = false)]
    public class OP_DocSchedual:AbstractEntity
    {
        private int  _schedualid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "SchedualID", DataKey = true, Match = "", IsInsert = false)]
        public int SchedualID
        {
            get { return  _schedualid; }
            set {  _schedualid = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 科室ＩＤ
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _docempid;
        /// <summary>
        /// 医生ＩＤ
        /// </summary>
        [Column(FieldName = "DocEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int DocEmpID
        {
            get { return  _docempid; }
            set {  _docempid = value; }
        }
        private string _docProfessionName;
        /// <summary>
        /// 医生职称名称
        /// </summary>
        [Column(FieldName = "DocProfessionName", DataKey = false, Match = "", IsInsert = true)]
        public string DocProfessionName
        {
            get { return _docProfessionName; }
            set { _docProfessionName = value; }
        }

        private DateTime  _schedualdate;
        /// <summary>
        /// 排班日期
        /// </summary>
        [Column(FieldName = "SchedualDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime SchedualDate
        {
            get { return  _schedualdate; }
            set {  _schedualdate = value; }
        }

        private int  _schedualtimerange;
        /// <summary>
        /// １上午　２下午　３晚上
        /// </summary>
        [Column(FieldName = "SchedualTimeRange", DataKey = false, Match = "", IsInsert = true)]
        public int SchedualTimeRange
        {
            get { return  _schedualtimerange; }
            set {  _schedualtimerange = value; }
        }

        private int _flag;
        /// <summary>
        /// １出诊 0未出诊
        /// </summary>
        [Column(FieldName = "Flag", DataKey = false, Match = "", IsInsert = true)]
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

    }
}
