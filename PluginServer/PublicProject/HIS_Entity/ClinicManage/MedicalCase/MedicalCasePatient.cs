using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_Entity.ClinicManage
{
    /// <summary>
    /// 病案首页病人对象
    /// </summary>
    public class MedicalCasePatient
    {
        private string _casenumber;
        /// <summary>
        /// 住院病案号
        /// </summary>
        public string CaseNumber
        {
            get { return _casenumber; }
            set { _casenumber = value; }
        }

        private string _patdatcardno;
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string PatDatCardNo
        {
            get { return _patdatcardno; }
            set { _patdatcardno = value; }
        }

        private int _pattypeid;
        /// <summary>
        /// 病人类型ID
        /// </summary>
        public int PatTypeID
        {
            get { return _pattypeid; }
            set { _pattypeid = value; }
        }

        private int _times;
        /// <summary>
        /// 住院次数
        /// </summary>
        public int Times
        {
            get { return _times; }
            set { _times = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 住院入院记录ID
        /// </summary>
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private string _patname;
        /// <summary>
        /// 病人名称
        /// </summary>
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

        private string _sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private DateTime _birthday;
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _age;
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private string _nationality;
        /// <summary>
        /// 国籍
        /// </summary>
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        private string _weight;
        /// <summary>
        /// 新生儿体重
        /// </summary>
        public string Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private string _nation;
        /// <summary>
        /// 名族
        /// </summary>
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        private string _native;
        /// <summary>
        /// 籍贯
        /// </summary>
        public string Native
        {
            get { return _native; }
            set { _native = value; }
        }

        private string _birthplace;
        /// <summary>
        /// 出生地
        /// </summary>
        public string Birthplace
        {
            get { return _birthplace; }
            set { _birthplace = value; }
        }

        private string _identitynum;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdentityNum
        {
            get { return _identitynum; }
            set { _identitynum = value; }
        }

        private string _matrimony;
        /// <summary>
        /// 婚否
        /// </summary>
        public string Matrimony
        {
            get { return _matrimony; }
            set { _matrimony = value; }
        }

        private string _naddress;
        /// <summary>
        /// 现住地址
        /// </summary>
        public string NAddress
        {
            get { return _naddress; }
            set { _naddress = value; }
        }

        private string _nzipcode;
        /// <summary>
        /// 现住邮编
        /// </summary>
        public string NZipCode
        {
            get { return _nzipcode; }
            set { _nzipcode = value; }
        }

        private string _phone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _dregisteraddr;
        /// <summary>
        /// 户籍住址
        /// </summary>
        public string DRegisterAddr
        {
            get { return _dregisteraddr; }
            set { _dregisteraddr = value; }
        }

        private string _dzipcode;
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string DZipCode
        {
            get { return _dzipcode; }
            set { _dzipcode = value; }
        }

        private string _unitname;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName
        {
            get { return _unitname; }
            set { _unitname = value; }
        }

        private string _unitphone;
        /// <summary>
        /// 单位电话
        /// </summary>
        public string UnitPhone
        {
            get { return _unitphone; }
            set { _unitphone = value; }
        }

        private string _uzipcode;
        /// <summary>
        /// 单位邮政编码
        /// </summary>
        public string UZipCode
        {
            get { return _uzipcode; }
            set { _uzipcode = value; }
        }

        private string _relationname;
        /// <summary>
        /// 联系人
        /// </summary>
        public string RelationName
        {
            get { return _relationname; }
            set { _relationname = value; }
        }

        private string _relation;
        /// <summary>
        /// 联系人关系
        /// </summary>
        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }

        private string _rphone;
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string RPhone
        {
            get { return _rphone; }
            set { _rphone = value; }
        }

        private int _sourceway;
        /// <summary>
        /// 入院途径
        /// </summary>
        public int SourceWay
        {
            get { return _sourceway; }
            set { _sourceway = value; }
        }

        private string _entersituation;
        /// <summary>
        /// 入院情况
        /// </summary>
        public string EnterSituation
        {
            get { return _entersituation; }
            set { _entersituation = value; }
        }
    }
}
