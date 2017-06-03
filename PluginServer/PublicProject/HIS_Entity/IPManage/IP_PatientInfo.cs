using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_PatientInfo", EntityType = EntityType.Table, IsGB = false)]
    public class IP_PatientInfo:AbstractEntity
    {
        private int  _patientid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatientID", DataKey = true, Match = "", IsInsert = false)]
        public int PatientID
        {
            get { return  _patientid; }
            set {  _patientid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _identitynum;
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Column(FieldName = "IdentityNum", DataKey = false, Match = "", IsInsert = true)]
        public string IdentityNum
        {
            get { return  _identitynum; }
            set {  _identitynum = value; }
        }

        private string  _nationality;
        /// <summary>
        /// 国籍
        /// </summary>
        [Column(FieldName = "Nationality", DataKey = false, Match = "", IsInsert = true)]
        public string Nationality
        {
            get { return  _nationality; }
            set {  _nationality = value; }
        }

        private string  _nation;
        /// <summary>
        /// 名族
        /// </summary>
        [Column(FieldName = "Nation", DataKey = false, Match = "", IsInsert = true)]
        public string Nation
        {
            get { return  _nation; }
            set {  _nation = value; }
        }

        private string  _native;
        /// <summary>
        /// 籍贯
        /// </summary>
        [Column(FieldName = "Native", DataKey = false, Match = "", IsInsert = true)]
        public string Native
        {
            get { return  _native; }
            set {  _native = value; }
        }

        private string  _matrimony;
        /// <summary>
        /// 婚否
        /// </summary>
        [Column(FieldName = "Matrimony", DataKey = false, Match = "", IsInsert = true)]
        public string Matrimony
        {
            get { return  _matrimony; }
            set {  _matrimony = value; }
        }

        private string  _occupation;
        /// <summary>
        /// 职业
        /// </summary>
        [Column(FieldName = "Occupation", DataKey = false, Match = "", IsInsert = true)]
        public string Occupation
        {
            get { return  _occupation; }
            set {  _occupation = value; }
        }

        private string  _culturallevel;
        /// <summary>
        /// 教育程度
        /// </summary>
        [Column(FieldName = "CulturalLevel", DataKey = false, Match = "", IsInsert = true)]
        public string CulturalLevel
        {
            get { return  _culturallevel; }
            set {  _culturallevel = value; }
        }

        private string  _birthplace;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Birthplace", DataKey = false, Match = "", IsInsert = true)]
        public string Birthplace
        {
            get { return  _birthplace; }
            set {  _birthplace = value; }
        }

        private string  _birthplacedetail;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BirthplaceDetail", DataKey = false, Match = "", IsInsert = true)]
        public string BirthplaceDetail
        {
            get { return  _birthplacedetail; }
            set {  _birthplacedetail = value; }
        }

        private string  _phone;
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(FieldName = "Phone", DataKey = false, Match = "", IsInsert = true)]
        public string Phone
        {
            get { return  _phone; }
            set {  _phone = value; }
        }

        private string  _dregisteraddr;
        /// <summary>
        /// 户籍住址
        /// </summary>
        [Column(FieldName = "DRegisterAddr", DataKey = false, Match = "", IsInsert = true)]
        public string DRegisterAddr
        {
            get { return  _dregisteraddr; }
            set {  _dregisteraddr = value; }
        }

        private string  _dzipcode;
        /// <summary>
        /// 邮政编码
        /// </summary>
        [Column(FieldName = "DZipCode", DataKey = false, Match = "", IsInsert = true)]
        public string DZipCode
        {
            get { return  _dzipcode; }
            set {  _dzipcode = value; }
        }

        private string  _dregisteraddrdetail;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DRegisterAddrDetail", DataKey = false, Match = "", IsInsert = true)]
        public string DRegisterAddrDetail
        {
            get { return  _dregisteraddrdetail; }
            set {  _dregisteraddrdetail = value; }
        }

        private string  _naddress;
        /// <summary>
        /// 现住地址
        /// </summary>
        [Column(FieldName = "NAddress", DataKey = false, Match = "", IsInsert = true)]
        public string NAddress
        {
            get { return  _naddress; }
            set {  _naddress = value; }
        }

        private string  _nzipcode;
        /// <summary>
        /// 现住邮编
        /// </summary>
        [Column(FieldName = "NZipCode", DataKey = false, Match = "", IsInsert = true)]
        public string NZipCode
        {
            get { return  _nzipcode; }
            set {  _nzipcode = value; }
        }

        private string  _naddressdetail;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "NAddressDetail", DataKey = false, Match = "", IsInsert = true)]
        public string NAddressDetail
        {
            get { return  _naddressdetail; }
            set {  _naddressdetail = value; }
        }

        private string  _unitname;
        /// <summary>
        /// 单位名称
        /// </summary>
        [Column(FieldName = "UnitName", DataKey = false, Match = "", IsInsert = true)]
        public string UnitName
        {
            get { return  _unitname; }
            set {  _unitname = value; }
        }

        private string  _unitphone;
        /// <summary>
        /// 单位电话
        /// </summary>
        [Column(FieldName = "UnitPhone", DataKey = false, Match = "", IsInsert = true)]
        public string UnitPhone
        {
            get { return  _unitphone; }
            set {  _unitphone = value; }
        }

        private string  _uzipcode;
        /// <summary>
        /// 单位邮政编码
        /// </summary>
        [Column(FieldName = "UZipCode", DataKey = false, Match = "", IsInsert = true)]
        public string UZipCode
        {
            get { return  _uzipcode; }
            set {  _uzipcode = value; }
        }

        private string  _relationname;
        /// <summary>
        /// 联系人
        /// </summary>
        [Column(FieldName = "RelationName", DataKey = false, Match = "", IsInsert = true)]
        public string RelationName
        {
            get { return  _relationname; }
            set {  _relationname = value; }
        }

        private string  _relation;
        /// <summary>
        /// 关系
        /// </summary>
        [Column(FieldName = "Relation", DataKey = false, Match = "", IsInsert = true)]
        public string Relation
        {
            get { return  _relation; }
            set {  _relation = value; }
        }

        private string  _rphone;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RPhone", DataKey = false, Match = "", IsInsert = true)]
        public string RPhone
        {
            get { return  _rphone; }
            set {  _rphone = value; }
        }

        private string  _raddress;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RAddress", DataKey = false, Match = "", IsInsert = true)]
        public string RAddress
        {
            get { return  _raddress; }
            set {  _raddress = value; }
        }

        private string  _raddressdetail;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RAddressDetail", DataKey = false, Match = "", IsInsert = true)]
        public string RAddressDetail
        {
            get { return  _raddressdetail; }
            set {  _raddressdetail = value; }
        }

    }
}
