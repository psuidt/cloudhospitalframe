using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_MemberInfo", EntityType = EntityType.Table, IsGB = false)]
    public class ME_MemberInfo:AbstractEntity
    {
        private int  _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = true, Match = "", IsInsert = false)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private string  _name;
        /// <summary>
        /// 会员姓名
        /// </summary>
        [Column(FieldName = "Name", DataKey = false, Match = "", IsInsert = true)]
        public string Name
        {
            get { return  _name; }
            set {  _name = value; }
        }

        private string  _sex;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Sex", DataKey = false, Match = "", IsInsert = true)]
        public string Sex
        {
            get { return  _sex; }
            set {  _sex = value; }
        }

        private DateTime  _birthday;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Birthday", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Birthday
        {
            get { return  _birthday; }
            set {  _birthday = value; }
        }

        private string  _idnumber;
        /// <summary>
        /// 身份证号
        /// </summary>
        [Column(FieldName = "IDNumber", DataKey = false, Match = "", IsInsert = true)]
        public string IDNumber
        {
            get { return  _idnumber; }
            set {  _idnumber = value; }
        }

        private string  _medicarecard;
        /// <summary>
        /// 医保卡号
        /// </summary>
        [Column(FieldName = "MedicareCard", DataKey = false, Match = "", IsInsert = true)]
        public string MedicareCard
        {
            get { return  _medicarecard; }
            set {  _medicarecard = value; }
        }

        private int  _registerwork;
        /// <summary>
        /// 注册机构
        /// </summary>
        [Column(FieldName = "RegisterWork", DataKey = false, Match = "", IsInsert = true)]
        public int RegisterWork
        {
            get { return  _registerwork; }
            set {  _registerwork = value; }
        }

        private string  _matrimony;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Matrimony", DataKey = false, Match = "", IsInsert = true)]
        public string Matrimony
        {
            get { return  _matrimony; }
            set {  _matrimony = value; }
        }

        private string  _pattype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatType", DataKey = false, Match = "", IsInsert = true)]
        public string PatType
        {
            get { return  _pattype; }
            set {  _pattype = value; }
        }

        private string  _mobile;
        /// <summary>
        /// 手机
        /// </summary>
        [Column(FieldName = "Mobile", DataKey = false, Match = "", IsInsert = true)]
        public string Mobile
        {
            get { return  _mobile; }
            set {  _mobile = value; }
        }

        private string  _nationality;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Nationality", DataKey = false, Match = "", IsInsert = true)]
        public string Nationality
        {
            get { return  _nationality; }
            set {  _nationality = value; }
        }

        private string  _nation;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Nation", DataKey = false, Match = "", IsInsert = true)]
        public string Nation
        {
            get { return  _nation; }
            set {  _nation = value; }
        }

        private string  _citycode;
        /// <summary>
        /// 市
        /// </summary>
        [Column(FieldName = "CityCode", DataKey = false, Match = "", IsInsert = true)]
        public string CityCode
        {
            get { return  _citycode; }
            set {  _citycode = value; }
        }

        private string  _cityname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CityName", DataKey = false, Match = "", IsInsert = true)]
        public string CityName
        {
            get { return  _cityname; }
            set {  _cityname = value; }
        }

        private string  _address;
        /// <summary>
        /// 常用地址
        /// </summary>
        [Column(FieldName = "Address", DataKey = false, Match = "", IsInsert = true)]
        public string Address
        {
            get { return  _address; }
            set {  _address = value; }
        }

        private int  _route;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Route", DataKey = false, Match = "", IsInsert = true)]
        public int Route
        {
            get { return  _route; }
            set {  _route = value; }
        }

        private string  _degree;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Degree", DataKey = false, Match = "", IsInsert = true)]
        public string Degree
        {
            get { return  _degree; }
            set {  _degree = value; }
        }

        private string  _occupation;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Occupation", DataKey = false, Match = "", IsInsert = true)]
        public string Occupation
        {
            get { return  _occupation; }
            set {  _occupation = value; }
        }

        private string  _workunit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WorkUnit", DataKey = false, Match = "", IsInsert = true)]
        public string WorkUnit
        {
            get { return  _workunit; }
            set {  _workunit = value; }
        }

        private string  _workadd;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WorkADD", DataKey = false, Match = "", IsInsert = true)]
        public string WorkADD
        {
            get { return  _workadd; }
            set {  _workadd = value; }
        }

        private string  _worktele;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WorkTele", DataKey = false, Match = "", IsInsert = true)]
        public string WorkTele
        {
            get { return  _worktele; }
            set {  _worktele = value; }
        }

        private string  _allergies;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Allergies", DataKey = false, Match = "", IsInsert = true)]
        public string Allergies
        {
            get { return  _allergies; }
            set {  _allergies = value; }
        }

        private string  _relationname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RelationName", DataKey = false, Match = "", IsInsert = true)]
        public string RelationName
        {
            get { return  _relationname; }
            set {  _relationname = value; }
        }

        private string  _relation;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Relation", DataKey = false, Match = "", IsInsert = true)]
        public string Relation
        {
            get { return  _relation; }
            set {  _relation = value; }
        }

        private string  _relationtele;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RelationTele", DataKey = false, Match = "", IsInsert = true)]
        public string RelationTele
        {
            get { return  _relationtele; }
            set {  _relationtele = value; }
        }

        private DateTime  _opendate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OpenDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OpenDate
        {
            get { return  _opendate; }
            set {  _opendate = value; }
        }

        private DateTime _RegisterDate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegisterDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegisterDate
        {
            get { return _RegisterDate; }
            set { _RegisterDate = value; }
        }

        private int  _useflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseFlag", DataKey = false, Match = "", IsInsert = true)]
        public int UseFlag
        {
            get { return  _useflag; }
            set {  _useflag = value; }
        }

        private DateTime  _operatedate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperateDate
        {
            get { return  _operatedate; }
            set {  _operatedate = value; }
        }

        private int  _operateid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateID", DataKey = false, Match = "", IsInsert = true)]
        public int OperateID
        {
            get { return  _operateid; }
            set {  _operateid = value; }
        }

    }
}
