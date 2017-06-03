using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_Register", EntityType = EntityType.Table, IsGB = false)]
    public class MI_Register:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _miid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MIID", DataKey = false, Match = "", IsInsert = true)]
        public int MIID
        {
            get { return  _miid; }
            set {  _miid = value; }
        }

        private int  _patienttype;
        /// <summary>
        /// 病人类型
        /// </summary>
        [Column(FieldName = "PatientType", DataKey = false, Match = "", IsInsert = true)]
        public int PatientType
        {
            get { return  _patienttype; }
            set {  _patienttype = value; }
        }

        private string  _medicalclass;
        /// <summary>
        /// 医保类型
   
   
        /// </summary>
        [Column(FieldName = "MedicalClass", DataKey = false, Match = "", IsInsert = true)]
        public string MedicalClass
        {
            get { return  _medicalclass; }
            set {  _medicalclass = value; }
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

        private string  _identitynum;
        /// <summary>
        /// 身份证号
   
        /// </summary>
        [Column(FieldName = "IdentityNum", DataKey = false, Match = "", IsInsert = true)]
        public string IdentityNum
        {
            get { return  _identitynum; }
            set {  _identitynum = value; }
        }

        private int  _patientid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatientID", DataKey = false, Match = "", IsInsert = true)]
        public int PatientID
        {
            get { return  _patientid; }
            set {  _patientid = value; }
        }

        private string  _patientname;
        /// <summary>
        /// 病人姓名
        /// </summary>
        [Column(FieldName = "PatientName", DataKey = false, Match = "", IsInsert = true)]
        public string PatientName
        {
            get { return  _patientname; }
            set {  _patientname = value; }
        }

        private int _deptid;
        /// <summary>
        /// 科室id
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return _deptid; }
            set { _deptid = value; }
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

        private string  _diagndocid;
        /// <summary>
        /// 医生ID
        /// </summary>
        [Column(FieldName = "DiagnDocID", DataKey = false, Match = "", IsInsert = true)]
        public string DiagnDocID
        {
            get { return  _diagndocid; }
            set {  _diagndocid = value; }
        }

        private string  _doctor;
        /// <summary>
        /// 医生名称
        /// </summary>
        [Column(FieldName = "Doctor", DataKey = false, Match = "", IsInsert = true)]
        public string Doctor
        {
            get { return  _doctor; }
            set {  _doctor = value; }
        }

        private string  _icdcode;
        /// <summary>
        /// 标准ICD诊断编码
        /// </summary>
        [Column(FieldName = "ICDCode", DataKey = false, Match = "", IsInsert = true)]
        public string ICDCode
        {
            get { return  _icdcode; }
            set {  _icdcode = value; }
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

        private string  _personalcode;
        /// <summary>
        /// 医保个人编号
        /// </summary>
        [Column(FieldName = "PersonalCode", DataKey = false, Match = "", IsInsert = true)]
        public string PersonalCode
        {
            get { return  _personalcode; }
            set {  _personalcode = value; }
        }

        private string  _staffid;
        /// <summary>
        /// 经办人ID
        /// </summary>
        [Column(FieldName = "StaffID", DataKey = false, Match = "", IsInsert = true)]
        public string StaffID
        {
            get { return  _staffid; }
            set {  _staffid = value; }
        }

        private string  _staffname;
        /// <summary>
        /// 经办人
        /// </summary>
        [Column(FieldName = "StaffName", DataKey = false, Match = "", IsInsert = true)]
        public string StaffName
        {
            get { return  _staffname; }
            set {  _staffname = value; }
        }

        private DateTime  _regtime;
        /// <summary>
        /// 登记时间
        /// </summary>
        [Column(FieldName = "RegTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegTime
        {
            get { return  _regtime; }
            set {  _regtime = value; }
        }

        private int  _validflag;
        /// <summary>
        /// 有效标志
        /// </summary>
        [Column(FieldName = "ValidFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ValidFlag
        {
            get { return  _validflag; }
            set {  _validflag = value; }
        }

        private Decimal  _ghfee;
        /// <summary>
        /// 挂号费
        /// </summary>
        [Column(FieldName = "GHFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal GHFee
        {
            get { return  _ghfee; }
            set {  _ghfee = value; }
        }

        private Decimal  _jcfee;
        /// <summary>
        /// 检查费
        /// </summary>
        [Column(FieldName = "JCFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal JCFee
        {
            get { return  _jcfee; }
            set {  _jcfee = value; }
        }

        private string  _serialno;
        /// <summary>
        /// 门诊号/住院号 0门诊 1住院
        /// </summary>
        [Column(FieldName = "SerialNO", DataKey = false, Match = "", IsInsert = true)]
        public string SerialNO
        {
            get { return  _serialno; }
            set {  _serialno = value; }
        }

        private string  _socialcreatenum;
        /// <summary>
        /// 医保登记流水号
        /// </summary>
        [Column(FieldName = "SocialCreateNum", DataKey = false, Match = "", IsInsert = true)]
        public string SocialCreateNum
        {
            get { return  _socialcreatenum; }
            set {  _socialcreatenum = value; }
        }

    }
}
