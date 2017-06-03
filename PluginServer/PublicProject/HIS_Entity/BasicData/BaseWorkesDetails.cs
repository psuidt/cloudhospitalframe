using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseWorkesDetails", EntityType = EntityType.Table, IsGB = true)]
    public class BaseWorkesDetails : AbstractEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID { get; set; }

        /// <summary>
        /// WorkId
        /// </summary>
        [Column(FieldName = "WorkId", DataKey = false, Match = "", IsInsert = true)]
        public int WorkId { get; set; }

        private string _workname;
        /// <summary>
        /// 医疗机构名称
        /// </summary>
        [Column(FieldName = "WorkName", DataKey = false, Match = "", IsInsert = true)]
        public string WorkName
        {
            get { return _workname; }
            set { _workname = value; }
        }

        private string _shortname;
        /// <summary>
        /// 机构简称
        /// </summary>
        [Column(FieldName = "ShortName", DataKey = false, Match = "", IsInsert = true)]
        public string ShortName
        {
            get { return _shortname; }
            set { _shortname = value; }
        }

        private string _organization_code;
        /// <summary>
        /// 医疗机构组织机构代码
        /// </summary>
        [Column(FieldName = "Organization_Code", DataKey = false, Match = "", IsInsert = true)]
        public string Organization_Code 
        {
            get { return _organization_code; }
            set { _organization_code = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _property_code;
        /// <summary>
        /// 医疗机构属性代码
        /// </summary>
        [Column(FieldName = "Property_Code", DataKey = false, Match = "", IsInsert = true)]
        public string Property_Code
        {
            get { return _property_code; }
            set { _property_code = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _class_code;
        /// <summary>
        /// 医疗机构类别代码
        /// </summary>
        [Column(FieldName = "Class_Code", DataKey = false, Match = "", IsInsert = true)]
        public string Class_Code
        {
            get { return _class_code; }
            set { _class_code = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _grade_code;
        /// <summary>
        /// 医疗机构等级  
        //01--三级甲等  02--三级乙等  03--三级丙等
        //04--二级甲等  05--二级乙等  06--二级丙等
        //07--一级甲等  08--一级乙等  08--一级丙等
        //04--二级甲等  05--二级乙等  06--二级丙等
        //07--一级甲等  08--一级乙等  08--一级丙等
        /// </summary>
        [Column(FieldName = "Grade_Code", DataKey = false, Match = "", IsInsert = true)]
        public string Grade_Code
        {
            get { return _grade_code; }
            set { _grade_code = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _server_object;
        /// <summary>
        /// 服务对象范围
        /// </summary>
        [Column(FieldName = "Server_Object", DataKey = false, Match = "", IsInsert = true)]
        public string Server_Object
        {
            get { return _server_object; }
            set { _server_object = value; }
        }

        private string _mercantile_flag;
        /// <summary>
        /// 营利标志 '1'-营利 '2'-非营利 '9'-其他卫生机构
        /// </summary>
        [Column(FieldName = "Mercantile_Flag", DataKey = false, Match = "", IsInsert = true)]
        public string Mercantile_Flag { get { return _mercantile_flag; } set { _mercantile_flag = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); } }

        private string _medicare_promise;
        /// <summary>
        /// 医保约定状态：非约定，正常，暂停，取消
        /// </summary>
        [Column(FieldName = "Medicare_Promise", DataKey = false, Match = "", IsInsert = true)]
        public string Medicare_Promise
        {
            get { return _medicare_promise; }
            set { _medicare_promise = value; }
        }

        private string _wound_promise;
        /// <summary>
        /// 工伤约定状态：非约定，正常，暂停，取消
        /// </summary>
        [Column(FieldName = "Wound_Promise", DataKey = false, Match = "", IsInsert = true)]
        public string Wound_Promise
        {
            get { return _wound_promise; }
            set { _wound_promise = value; }
        }

        private string _birth_promise;
        /// <summary>
        /// 生育约定状态：非约定，正常，暂停，取消
        /// </summary>
        [Column(FieldName = "Birth_Promise", DataKey = false, Match = "", IsInsert = true)]
        public string Birth_Promise
        {
            get { return _birth_promise; }
            set { _birth_promise = value; }
        }

        private string _charge_name;
        /// <summary>
        /// 主管单位名称
        /// </summary>
        [Column(FieldName = "Charge_Name", DataKey = false, Match = "", IsInsert = true)]
        public string Charge_Name
        {
            get { return _charge_name; }
            set { _charge_name = value; }
        }

        private string _province;
        /// <summary>
        /// 省
        /// </summary>
        [Column(FieldName = "Province", DataKey = false, Match = "", IsInsert = true)]
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _city;
        /// <summary>
        /// 地区（市）
        /// </summary>
        [Column(FieldName = "City", DataKey = false, Match = "", IsInsert = true)]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _district;
        /// <summary>
        /// 区（县）
        /// </summary>
        [Column(FieldName = "District", DataKey = false, Match = "", IsInsert = true)]
        public string District
        {
            get { return _district; }
            set { _district = value; }
        }

        private string _corporation;
        /// <summary>
        /// 法人代表
        /// </summary>
        [Column(FieldName = "Corporation", DataKey = false, Match = "", IsInsert = true)]
        public string Corporation
        {
            get { return _corporation; }
            set { _corporation = value; }
        }

        private string _corporate_phone;
        /// <summary>
        /// 法人电话
        /// </summary>
        [Column(FieldName = "Corporate_Phone", DataKey = false, Match = "", IsInsert = true)]
        public string Corporate_Phone
        {
            get { return _corporate_phone; }
            set { _corporate_phone = value; }
        }

        private string _principal;
        /// <summary>
        /// 医院负责人
        /// </summary>
        [Column(FieldName = "Principal", DataKey = false, Match = "", IsInsert = true)]
        public string Principal
        {
            get { return _principal; }
            set { _principal = value; }
        }

        private string _principal_phone;
        /// <summary>
        /// 医院负责人电话
        /// </summary>
        [Column(FieldName = "Principal_Phone", DataKey = false, Match = "", IsInsert = true)]
        public string Principal_Phone
        {
            get { return _principal_phone; }
            set { _principal_phone = value; }
        }

        private string _address;
        /// <summary>
        /// 通讯地址
        /// </summary>
        [Column(FieldName = "Address", DataKey = false, Match = "", IsInsert = true)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _postalcode;
        /// <summary>
        /// 邮政编码
        /// </summary>
        [Column(FieldName = "PostalCode", DataKey = false, Match = "", IsInsert = true)]
        public string PostalCode
        {
            get { return _postalcode; }
            set { _postalcode = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _fax;
        /// <summary>
        /// 传真号码
        /// </summary>
        [Column(FieldName = "Fax", DataKey = false, Match = "", IsInsert = true)]
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _email;
        /// <summary>
        /// 电子信箱
        /// </summary>
        [Column(FieldName = "Email", DataKey = false, Match = "", IsInsert = true)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _economic_kind;
        /// <summary>
        /// 经济性质代码
        /// </summary>
        [Column(FieldName = "Economic_Kind", DataKey = false, Match = "", IsInsert = true)]
        public string Economic_Kind
        {
            get { return _economic_kind; }
            set { _economic_kind = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _account_bank;
        /// <summary>
        /// 开户银行
        /// </summary>
        [Column(FieldName = "Account_Bank", DataKey = false, Match = "", IsInsert = true)]
        public string Account_Bank
        {
            get { return _account_bank; }
            set { _account_bank = value; }
        }

        private string _account_name;
        /// <summary>
        /// 开户户名
        /// </summary>
        [Column(FieldName = "Account_Name", DataKey = false, Match = "", IsInsert = true)]
        public string Account_Name
        {
            get { return _account_name; }
            set { _account_name = value; }
        }

        private string _account_num;
        /// <summary>
        /// 开户账号
        /// </summary>
        [Column(FieldName = "Account_Num", DataKey = false, Match = "", IsInsert = true)]
        public string Account_Num
        {
            get { return _account_num; }
            set { _account_num = value; }
        }

        private string _licence_no;
        /// <summary>
        /// 执行许可证编号
        /// </summary>
        [Column(FieldName = "Licence_No", DataKey = false, Match = "", IsInsert = true)]
        public string Licence_No
        {
            get { return _licence_no; }
            set { _licence_no = value; }
        }

        private DateTime _licence_begin;
        /// <summary>
        /// 执行许可证有效期限（起）
        /// </summary>
        [Column(FieldName = "Licence_Begin", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Licence_Begin
        {
            get { return _licence_begin; }
            set { _licence_begin = value; }
        }

        private DateTime _licence_end;
        /// <summary>
        /// 执行许可证有效期限（止）
        /// </summary>
        [Column(FieldName = "Licence_End", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Licence_End
        {
            get { return _licence_end; }
            set { _licence_end = value; }
        }

        private string _deal_scale;
        /// <summary>
        /// 执业证经营范围
        /// </summary>
        [Column(FieldName = "Deal_Scale", DataKey = false, Match = "", IsInsert = true)]
        public string Deal_Scale
        {
            get { return _deal_scale; }
            set { _deal_scale = value; }
        }

        private string _medicare_scale;
        /// <summary>
        /// 医保批准经营范围
        /// </summary>
        [Column(FieldName = "Medicare_Scale", DataKey = false, Match = "", IsInsert = true)]
        public string Medicare_Scale
        {
            get { return _medicare_scale; }
            set { _medicare_scale = value; }
        }

        private DateTime _sign_date;
        /// <summary>
        /// 签约日期
        /// </summary>
        [Column(FieldName = "Sign_Date", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Sign_Date
        {
            get { return _sign_date; }
            set { _sign_date = value; }
        }

        private DateTime _sign_begindate;
        /// <summary>
        /// 签约有效起始时间
        /// </summary>
        [Column(FieldName = "Sign_BeginDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Sign_BeginDate
        {
            get { return _sign_begindate; }
            set { _sign_begindate = value; }
        }

        private DateTime _sign_enddate;
        /// <summary>
        /// 签约有效终止时间
        /// </summary>
        [Column(FieldName = "Sign_EndDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Sign_EndDate
        {
            get { return _sign_enddate; }
            set { _sign_enddate = value; }
        }

        private string _medicare_apanage;
        /// <summary>
        /// 医保机构管理属地
        /// </summary>
        [Column(FieldName = "Medicare_Apanage", DataKey = false, Match = "", IsInsert = true)]
        public string Medicare_Apanage
        {
            get { return _medicare_apanage; }
            set { _medicare_apanage = value; }
        }

        private string _manage_target;
        /// <summary>
        /// 管理指标
        /// </summary>
        [Column(FieldName = "Manage_Target", DataKey = false, Match = "", IsInsert = true)]
        public string Manage_Target
        {
            get { return _manage_target; }
            set { _manage_target = value; }
        }

        private string _land_area;
        /// <summary>
        /// 占地面积
        /// </summary>
        [Column(FieldName = "Land_Area", DataKey = false, Match = "", IsInsert = true)]
        public string Land_Area
        {
            get { return _land_area; }
            set { _land_area = value; }
        }

        private string _medical_area;
        /// <summary>
        /// 医疗用地面积
        /// </summary>
        [Column(FieldName = "Medical_Area", DataKey = false, Match = "", IsInsert = true)]
        public string Medical_Area
        {
            get { return _medical_area; }
            set { _medical_area = value; }
        }

        private string _business_area;
        /// <summary>
        /// 办公和业务用房面积
        /// </summary>
        [Column(FieldName = "Business_Area", DataKey = false, Match = "", IsInsert = true)]
        public string Business_Area
        {
            get { return _business_area; }
            set { _business_area = value; }
        }

        private int _regulars;
        /// <summary>
        /// 编内在职人数
        /// </summary>
        [Column(FieldName = "Regulars", DataKey = false, Match = "", IsInsert = true)]
        public int Regulars
        {
            get { return _regulars; }
            set { _regulars = value; }
        }

        private int _employers;
        /// <summary>
        /// 聘用在职人数
        /// </summary>
        [Column(FieldName = "Employers", DataKey = false, Match = "", IsInsert = true)]
        public int Employers
        {
            get { return _employers; }
            set { _employers = value; }
        }

        private int _check_beds;
        /// <summary>
        /// 核定床位数
        /// </summary>
        [Column(FieldName = "Check_Beds", DataKey = false, Match = "", IsInsert = true)]
        public int Check_Beds
        {
            get { return _check_beds; }
            set { _check_beds = value; }
        }

        private int _open_beds;
        /// <summary>
        /// 开放床位数
        /// </summary>
        [Column(FieldName = "Open_Beds", DataKey = false, Match = "", IsInsert = true)]
        public int Open_Beds
        {
            get { return _open_beds; }
            set { _open_beds = value; }
        }

        private string _servicephone;
        /// <summary>
        /// 对外公共的医疗服务电话
        /// </summary>
        [Column(FieldName = "ServicePhone", DataKey = false, Match = "", IsInsert = true)]
        public string ServicePhone
        {
            get { return _servicephone; }
            set { _servicephone = value; }
        }

        private int _peoples;
        /// <summary>
        /// 辖区人居民总数
        /// </summary>
        [Column(FieldName = "Peoples", DataKey = false, Match = "", IsInsert = true)]
        public int Peoples
        {
            get { return _peoples; }
            set { _peoples = value; }
        }

        private int _fpeoples;
        /// <summary>
        /// 辖区内流动总数
        /// </summary>
        [Column(FieldName = "FPeoples", DataKey = false, Match = "", IsInsert = true)]
        public int FPeoples
        {
            get { return _fpeoples; }
            set { _fpeoples = value; }
        }

        private int _familys;
        /// <summary>
        /// 辖区内家庭户数
        /// </summary>
        [Column(FieldName = "Familys", DataKey = false, Match = "", IsInsert = true)]
        public int Familys
        {
            get { return _familys; }
            set { _familys = value; }
        }

        private string _sarno;
        /// <summary>
        /// 行政区号
        /// </summary>
        [Column(FieldName = "SARNo", DataKey = false, Match = "", IsInsert = true)]
        public string SARNo
        {
            get { return _sarno; }
            set { _sarno = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _townshipcode;
        /// <summary>
        /// 按照国家标准GB/T10114-2003标准编辑的编码
        /// </summary>
        [Column(FieldName = "TownshipCode", DataKey = false, Match = "", IsInsert = true)]
        public string TownshipCode
        {
            get { return _townshipcode; }
            set { _townshipcode = string.IsNullOrEmpty(value) ? "" : value.TrimEnd(); }
        }

        private string _monitorweb;
        /// <summary>
        /// 医院监控网址
        /// </summary>
        [Column(FieldName = "MonitorWeb", DataKey = false, Match = "", IsInsert = true)]
        public string MonitorWeb
        {
            get { return _monitorweb; }
            set { _monitorweb = value; }
        }

        private int _level;
        /// <summary>
        /// 医疗机构级别代码
        //1  村卫生室 
        //2  乡镇卫生院 
        //3  县级医疗机构 
        //4  地市级医疗机构 
        //5  省级及以上医疗机构 
        //9  其他医疗机构
        /// </summary>
        [Column(FieldName = "Level", DataKey = false, Match = "", IsInsert = true)]
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        private int _areacode;
        /// <summary>
        /// 区域代码
        /// </summary>
        [Column(FieldName = "AreaCode", DataKey = false, Match = "", IsInsert = true)]
        public int AreaCode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }

        private int _provincecode;
        /// <summary>
        /// 省份代码
        /// </summary>
        [Column(FieldName = "ProvinceCode", DataKey = false, Match = "", IsInsert = true)]
        public int ProvinceCode
        {
            get { return _provincecode; }
            set { _provincecode = value; }
        }

        private int _citycode;
        /// <summary>
        /// 城市代码
        /// </summary>
        [Column(FieldName = "CityCode", DataKey = false, Match = "", IsInsert = true)]
        public int CityCode
        {
            get { return _citycode; }
            set { _citycode = value; }
        }

        private int _countycode;
        /// <summary>
        /// 县级代码
        /// </summary>
        [Column(FieldName = "CountyCode", DataKey = false, Match = "", IsInsert = true)]
        public int CountyCode
        {
            get { return _countycode; }
            set { _countycode = value; }
        }

        private int _buffercode;
        /// <summary>
        /// 扩展码，预留码
        /// </summary>
        [Column(FieldName = "BufferCode", DataKey = false, Match = "", IsInsert = true)]
        public int BufferCode
        {
            get { return _buffercode; }
            set { _buffercode = value; }
        }

        private string _cardprefix;
        /// <summary>
        /// 诊疗卡前缀
        /// </summary>
        [Column(FieldName = "CardPrefix", DataKey = false, Match = "", IsInsert = true)]
        public string CardPrefix
        {
            get { return _cardprefix; }
            set { _cardprefix = value; }
        }

        private int _cardlength;
        /// <summary>
        /// 诊疗卡长度
        /// </summary>
        [Column(FieldName = "CardLength", DataKey = false, Match = "", IsInsert = true)]
        public int CardLength
        {
            get { return _cardlength; }
            set { _cardlength = value; }
        }

    }
}
