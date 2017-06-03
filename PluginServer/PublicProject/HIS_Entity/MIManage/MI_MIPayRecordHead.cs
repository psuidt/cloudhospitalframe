using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_MIPayRecordHead", EntityType = EntityType.Table, IsGB = false)]
    public class MI_MIPayRecordHead:AbstractEntity
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

        private int  _payrecordid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayRecordId", DataKey = false, Match = "", IsInsert = true)]
        public int PayRecordId
        {
            get { return  _payrecordid; }
            set {  _payrecordid = value; }
        }

        private Decimal  _medicine;
        /// <summary>
        /// 西药
        /// </summary>
        [Column(FieldName = "medicine", DataKey = false, Match = "", IsInsert = true)]
        public Decimal medicine
        {
            get { return  _medicine; }
            set {  _medicine = value; }
        }

        private Decimal  _tmedicine;
        /// <summary>
        /// 中成药
        /// </summary>
        [Column(FieldName = "tmedicine", DataKey = false, Match = "", IsInsert = true)]
        public Decimal tmedicine
        {
            get { return  _tmedicine; }
            set {  _tmedicine = value; }
        }

        private Decimal  _therb;
        /// <summary>
        /// 中草药
        /// </summary>
        [Column(FieldName = "therb", DataKey = false, Match = "", IsInsert = true)]
        public Decimal therb
        {
            get { return  _therb; }
            set {  _therb = value; }
        }

        private Decimal  _examine;
        /// <summary>
        /// 检查费
        /// </summary>
        [Column(FieldName = "examine", DataKey = false, Match = "", IsInsert = true)]
        public Decimal examine
        {
            get { return  _examine; }
            set {  _examine = value; }
        }

        private Decimal  _labexam;
        /// <summary>
        /// 化验
        /// </summary>
        [Column(FieldName = "labexam", DataKey = false, Match = "", IsInsert = true)]
        public Decimal labexam
        {
            get { return  _labexam; }
            set {  _labexam = value; }
        }

        private Decimal  _treatment;
        /// <summary>
        /// 治疗费
        /// </summary>
        [Column(FieldName = "treatment", DataKey = false, Match = "", IsInsert = true)]
        public Decimal treatment
        {
            get { return  _treatment; }
            set {  _treatment = value; }
        }

        private Decimal  _operation;
        /// <summary>
        /// 手术费
        /// </summary>
        [Column(FieldName = "operation", DataKey = false, Match = "", IsInsert = true)]
        public Decimal operation
        {
            get { return  _operation; }
            set {  _operation = value; }
        }

        private Decimal  _material;
        /// <summary>
        /// 材料费
        /// </summary>
        [Column(FieldName = "material", DataKey = false, Match = "", IsInsert = true)]
        public Decimal material
        {
            get { return  _material; }
            set {  _material = value; }
        }

        private Decimal  _other;
        /// <summary>
        /// 其他
        /// </summary>
        [Column(FieldName = "other", DataKey = false, Match = "", IsInsert = true)]
        public Decimal other
        {
            get { return  _other; }
            set {  _other = value; }
        }

        private Decimal  _xray;
        /// <summary>
        /// 放射-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "xray", DataKey = false, Match = "", IsInsert = true)]
        public Decimal xray
        {
            get { return  _xray; }
            set {  _xray = value; }
        }

        private Decimal  _ultrasonic;
        /// <summary>
        /// B超-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "ultrasonic", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ultrasonic
        {
            get { return  _ultrasonic; }
            set {  _ultrasonic = value; }
        }

        private Decimal  _ct;
        /// <summary>
        /// CT-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "CT", DataKey = false, Match = "", IsInsert = true)]
        public Decimal CT
        {
            get { return  _ct; }
            set {  _ct = value; }
        }

        private Decimal  _mri;
        /// <summary>
        /// 核磁-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "mri", DataKey = false, Match = "", IsInsert = true)]
        public Decimal mri
        {
            get { return  _mri; }
            set {  _mri = value; }
        }

        private Decimal  _oxygen;
        /// <summary>
        /// 输氧费-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "oxygen", DataKey = false, Match = "", IsInsert = true)]
        public Decimal oxygen
        {
            get { return  _oxygen; }
            set {  _oxygen = value; }
        }

        private Decimal  _bloodt;
        /// <summary>
        /// 输血费-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "bloodt", DataKey = false, Match = "", IsInsert = true)]
        public Decimal bloodt
        {
            get { return  _bloodt; }
            set {  _bloodt = value; }
        }

        private Decimal  _orthodontics;
        /// <summary>
        /// 正畸费-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "orthodontics", DataKey = false, Match = "", IsInsert = true)]
        public Decimal orthodontics
        {
            get { return  _orthodontics; }
            set {  _orthodontics = value; }
        }

        private Decimal  _prosthesis;
        /// <summary>
        /// 镶牙费-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "prosthesis", DataKey = false, Match = "", IsInsert = true)]
        public Decimal prosthesis
        {
            get { return  _prosthesis; }
            set {  _prosthesis = value; }
        }

        private Decimal  _forensic_expertise;
        /// <summary>
        /// 司法鉴定-门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "forensic_expertise", DataKey = false, Match = "", IsInsert = true)]
        public Decimal forensic_expertise
        {
            get { return  _forensic_expertise; }
            set {  _forensic_expertise = value; }
        }

        private Decimal  _diagnosis;
        /// <summary>
        /// 诊察费-新门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "diagnosis", DataKey = false, Match = "", IsInsert = true)]
        public Decimal diagnosis
        {
            get { return  _diagnosis; }
            set {  _diagnosis = value; }
        }

        private Decimal  _medicalservice;
        /// <summary>
        /// 医事服务费-新门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "medicalservice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal medicalservice
        {
            get { return  _medicalservice; }
            set {  _medicalservice = value; }
        }

        private Decimal  _commonservice;
        /// <summary>
        /// 一般诊疗费-新门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "commonservice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal commonservice
        {
            get { return  _commonservice; }
            set {  _commonservice = value; }
        }

        private Decimal  _registfee;
        /// <summary>
        /// 挂号费-新门诊收据上的相应内容
        /// </summary>
        [Column(FieldName = "registfee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal registfee
        {
            get { return  _registfee; }
            set {  _registfee = value; }
        }

        private string  _tradeno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "tradeno", DataKey = false, Match = "", IsInsert = true)]
        public string tradeno
        {
            get { return  _tradeno; }
            set {  _tradeno = value; }
        }

    }
}
