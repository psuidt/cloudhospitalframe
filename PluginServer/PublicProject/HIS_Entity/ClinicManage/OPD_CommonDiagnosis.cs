using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_CommonDiagnosis", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_CommonDiagnosis:AbstractEntity
    {
        private int  _commondiagnosisid;
        /// <summary>
        /// 常用诊断ID
        /// </summary>
        [Column(FieldName = "CommonDiagnosisID", DataKey = true, Match = "", IsInsert = false)]
        public int CommonDiagnosisID
        {
            get { return  _commondiagnosisid; }
            set {  _commondiagnosisid = value; }
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

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private int  _recorddoctorid;
        /// <summary>
        /// 所属医生代码
        /// </summary>
        [Column(FieldName = "RecordDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int RecordDoctorID
        {
            get { return  _recorddoctorid; }
            set {  _recorddoctorid = value; }
        }

        private int  _frequency;
        /// <summary>
        /// 使用频率
        /// </summary>
        [Column(FieldName = "Frequency", DataKey = false, Match = "", IsInsert = true)]
        public int Frequency
        {
            get { return  _frequency; }
            set {  _frequency = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
