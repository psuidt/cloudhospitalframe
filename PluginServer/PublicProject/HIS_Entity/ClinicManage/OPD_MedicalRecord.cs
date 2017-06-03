using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_MedicalRecord", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_MedicalRecord:AbstractEntity
    {
        private int  _medicalrecordid;
        /// <summary>
        /// 门诊病历记录表ID
        /// </summary>
        [Column(FieldName = "MedicalRecordID", DataKey = true, Match = "", IsInsert = false)]
        public int MedicalRecordID
        {
            get { return  _medicalrecordid; }
            set {  _medicalrecordid = value; }
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

        private int  _presdoctorid;
        /// <summary>
        /// 开方医生ID
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

        private string  _symptoms;
        /// <summary>
        /// 主诉
        /// </summary>
        [Column(FieldName = "Symptoms", DataKey = false, Match = "", IsInsert = true)]
        public string Symptoms
        {
            get { return  _symptoms; }
            set {  _symptoms = value; }
        }

        private string  _sicknesshistory;
        /// <summary>
        /// 病史
        /// </summary>
        [Column(FieldName = "SicknessHistory", DataKey = false, Match = "", IsInsert = true)]
        public string SicknessHistory
        {
            get { return  _sicknesshistory; }
            set {  _sicknesshistory = value; }
        }

        private string  _physicalexam;
        /// <summary>
        /// 体查
        /// </summary>
        [Column(FieldName = "PhysicalExam", DataKey = false, Match = "", IsInsert = true)]
        public string PhysicalExam
        {
            get { return  _physicalexam; }
            set {  _physicalexam = value; }
        }

        private string  _docadvise;
        /// <summary>
        /// 医生建议
        /// </summary>
        [Column(FieldName = "DocAdvise", DataKey = false, Match = "", IsInsert = true)]
        public string DocAdvise
        {
            get { return  _docadvise; }
            set {  _docadvise = value; }
        }

        private string  _auxiliaryexam;
        /// <summary>
        /// 辅助检查
        /// </summary>
        [Column(FieldName = "AuxiliaryExam", DataKey = false, Match = "", IsInsert = true)]
        public string AuxiliaryExam
        {
            get { return  _auxiliaryexam; }
            set {  _auxiliaryexam = value; }
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

    }
}
