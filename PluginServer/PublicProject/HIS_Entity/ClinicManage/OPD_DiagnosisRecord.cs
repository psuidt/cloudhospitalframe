using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_DiagnosisRecord", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_DiagnosisRecord:AbstractEntity
    {
        private int  _diagnosisrecordid;
        /// <summary>
        /// 诊断记录ID
        /// </summary>
        [Column(FieldName = "DiagnosisRecordID", DataKey = true, Match = "", IsInsert = false)]
        public int DiagnosisRecordID
        {
            get { return  _diagnosisrecordid; }
            set {  _diagnosisrecordid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 就诊ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _diagnosiscode;
        /// <summary>
        /// 诊断代码
        /// </summary>
        [Column(FieldName = "DiagnosisCode", DataKey = false, Match = "", IsInsert = true)]
        public string DiagnosisCode
        {
            get { return  _diagnosiscode; }
            set {  _diagnosiscode = value; }
        }

        private string  _diagnosisname;
        /// <summary>
        /// 诊断名称
        /// </summary>
        [Column(FieldName = "DiagnosisName", DataKey = false, Match = "", IsInsert = true)]
        public string DiagnosisName
        {
            get { return  _diagnosisname; }
            set {  _diagnosisname = value; }
        }

        private int  _presdoctorid;
        /// <summary>
        /// 开发医生ID
        /// </summary>
        [Column(FieldName = "PresDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDoctorID
        {
            get { return  _presdoctorid; }
            set {  _presdoctorid = value; }
        }

        private int  _presdeptid;
        /// <summary>
        /// 开方科室ID
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return  _presdeptid; }
            set {  _presdeptid = value; }
        }

        private DateTime  _diagnosisdate;
        /// <summary>
        /// 下诊断时间
        /// </summary>
        [Column(FieldName = "DiagnosisDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime DiagnosisDate
        {
            get { return  _diagnosisdate; }
            set {  _diagnosisdate = value; }
        }

        private int  _sortno;
        /// <summary>
        /// 序号
        /// </summary>
        [Column(FieldName = "SortNo", DataKey = false, Match = "", IsInsert = true)]
        public int SortNo
        {
            get { return  _sortno; }
            set {  _sortno = value; }
        }

    }
}
