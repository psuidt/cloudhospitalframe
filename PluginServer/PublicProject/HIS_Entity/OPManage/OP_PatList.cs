using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_PatList", EntityType = EntityType.Table, IsGB = false)]
    public class OP_PatList:AbstractEntity
    {
        private int  _patlistid;
        /// <summary>
        /// 就诊流水号
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = true, Match = "", IsInsert = false)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 会员ＩＤ
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _memberaccountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MemberAccountID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberAccountID
        {
            get { return  _memberaccountid; }
            set {  _memberaccountid = value; }
        }

        private string  _cardno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CardNO", DataKey = false, Match = "", IsInsert = true)]
        public string CardNO
        {
            get { return  _cardno; }
            set {  _cardno = value; }
        }

        private int  _pattypeid;
        /// <summary>
        /// 病人类型代码
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return  _pattypeid; }
            set {  _pattypeid = value; }
        }

        private string  _visitno;
        /// <summary>
        /// 门诊号
        /// </summary>
        [Column(FieldName = "VisitNO", DataKey = false, Match = "", IsInsert = true)]
        public string VisitNO
        {
            get { return  _visitno; }
            set {  _visitno = value; }
        }

        private int  _regtypeid;
        /// <summary>
        /// 挂号类别代码
        /// </summary>
        [Column(FieldName = "RegTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int RegTypeID
        {
            get { return  _regtypeid; }
            set {  _regtypeid = value; }
        }

        private string  _regtypename;
        /// <summary>
        /// 挂号类别名称
        /// </summary>
        [Column(FieldName = "RegTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string RegTypeName
        {
            get { return  _regtypename; }
            set {  _regtypename = value; }
        }

        private int  _regdeptid;
        /// <summary>
        /// 挂号科室代码
        /// </summary>
        [Column(FieldName = "RegDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int RegDeptID
        {
            get { return  _regdeptid; }
            set {  _regdeptid = value; }
        }

        private int  _regempid;
        /// <summary>
        /// 挂号科室名称
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
        }

        private string  _regdocname;
        /// <summary>
        /// 挂号医生代码
        /// </summary>
        [Column(FieldName = "RegDocName", DataKey = false, Match = "", IsInsert = true)]
        public string RegDocName
        {
            get { return  _regdocname; }
            set {  _regdocname = value; }
        }

        private string  _regdeptname;
        /// <summary>
        /// 挂号医生名称
        /// </summary>
        [Column(FieldName = "RegDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string RegDeptName
        {
            get { return  _regdeptname; }
            set {  _regdeptname = value; }
        }

        private string  _patname;
        /// <summary>
        /// 病人姓名
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private string  _patsex;
        /// <summary>
        /// 病人性别
        /// </summary>
        [Column(FieldName = "PatSex", DataKey = false, Match = "", IsInsert = true)]
        public string PatSex
        {
            get { return  _patsex; }
            set {  _patsex = value; }
        }

        private DateTime  _birthday;
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(FieldName = "Birthday", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Birthday
        {
            get { return  _birthday; }
            set {  _birthday = value; }
        }

        private string  _age;
        /// <summary>
        /// 年龄
        /// </summary>
        [Column(FieldName = "Age", DataKey = false, Match = "", IsInsert = true)]
        public string Age
        {
            get { return  _age; }
            set {  _age = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PyCode", DataKey = false, Match = "", IsInsert = true)]
        public string PyCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WbCode", DataKey = false, Match = "", IsInsert = true)]
        public string WbCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private int  _curedeptid;
        /// <summary>
        /// 就诊科室代码
        /// </summary>
        [Column(FieldName = "CureDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int CureDeptID
        {
            get { return  _curedeptid; }
            set {  _curedeptid = value; }
        }

        private int  _cureempid;
        /// <summary>
        /// 就诊医生代码
        /// </summary>
        [Column(FieldName = "CureEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int CureEmpID
        {
            get { return  _cureempid; }
            set {  _cureempid = value; }
        }

        private string  _diseasecode;
        /// <summary>
        /// 疾病代码
        /// </summary>
        [Column(FieldName = "DiseaseCode", DataKey = false, Match = "", IsInsert = true)]
        public string DiseaseCode
        {
            get { return  _diseasecode; }
            set {  _diseasecode = value; }
        }

        private string  _diseasename;
        /// <summary>
        /// 疾病名称（由|分隔，前半部分是标准名称，后半部为用户输入）
        /// </summary>
        [Column(FieldName = "DiseaseName", DataKey = false, Match = "", IsInsert = true)]
        public string DiseaseName
        {
            get { return  _diseasename; }
            set {  _diseasename = value; }
        }

        private DateTime  _regdate;
        /// <summary>
        /// 就诊日期
        /// </summary>
        [Column(FieldName = "RegDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegDate
        {
            get { return  _regdate; }
            set {  _regdate = value; }
        }

        private int  _visitstatus;
        /// <summary>
        /// 病人就诊状态（0-候诊状态，1-就诊状态，2-结束状态）
        /// </summary>
        [Column(FieldName = "VisitStatus", DataKey = false, Match = "", IsInsert = true)]
        public int VisitStatus
        {
            get { return  _visitstatus; }
            set {  _visitstatus = value; }
        }

        private int  _costheadid;
        /// <summary>
        /// 结算ID
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _chargeflag;
        /// <summary>
        /// 0未收算 1已经收费
        /// </summary>
        [Column(FieldName = "ChargeFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ChargeFlag
        {
            get { return  _chargeflag; }
            set {  _chargeflag = value; }
        }

        private int  _regcategory;
        /// <summary>
        /// 挂号类别 0 普通1急诊2专家
        /// </summary>
        [Column(FieldName = "RegCategory", DataKey = false, Match = "", IsInsert = true)]
        public int RegCategory
        {
            get { return  _regcategory; }
            set {  _regcategory = value; }
        }

        private int  _regstatus;
        /// <summary>
        /// 挂号状态　０正常１退号
        /// </summary>
        [Column(FieldName = "RegStatus", DataKey = false, Match = "", IsInsert = true)]
        public int RegStatus
        {
            get { return  _regstatus; }
            set {  _regstatus = value; }
        }

        private int  _regtimerange;
        /// <summary>
        /// 挂号时段　１上午　２下午 3晚上
        /// </summary>
        [Column(FieldName = "RegTimeRange", DataKey = false, Match = "", IsInsert = true)]
        public int RegTimeRange
        {
            get { return  _regtimerange; }
            set {  _regtimerange = value; }
        }

        private int  _regsourceno;
        /// <summary>
        /// 号序。主要用于预约挂号
        /// </summary>
        [Column(FieldName = "RegSourceNo", DataKey = false, Match = "", IsInsert = true)]
        public int RegSourceNo
        {
            get { return  _regsourceno; }
            set {  _regsourceno = value; }
        }

        private string _idNumber;
        /// <summary>
        /// 身份证号
        /// </summary>
        [Column(FieldName = "IDNumber", DataKey = false, Match = "", IsInsert = true)]
        public string IDNumber
        {
            get { return _idNumber; }
            set { _idNumber = value; }
        }
        private string _workUnit;
        /// <summary>
        /// 工作单位
        /// </summary>
        [Column(FieldName = "WorkUnit", DataKey = false, Match = "", IsInsert = true)]
        public string WorkUnit
        {
            get { return _workUnit; }
            set { _workUnit = value; }
        }
        private string _allergies;
        /// <summary>
        /// 过敏史
        /// </summary>
        [Column(FieldName = "Allergies", DataKey = false, Match = "", IsInsert = true)]
        public string Allergies
        {
            get { return _allergies; }
            set { _allergies = value; }
        }

        private string _pattypename;
        /// <summary>
        /// 病人类型名称
        /// </summary>
        [Column(FieldName = "PatTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string PatTypeName
        {
            get { return _pattypename; }
            set { _pattypename = value; }
        }



            private int _operatorID;
        /// <summary>
        /// 操作员ID
        /// </summary>
        [Column(FieldName = "OperatorID", DataKey = false, Match = "", IsInsert = true)]
        public int OperatorID
        {
            get { return _operatorID; }
            set { _operatorID = value; }
        }


        private string _medicareCard;
        /// <summary>
        /// 医保卡号
        /// </summary>
        [Column(FieldName = "MedicareCard", DataKey = false, Match = "", IsInsert = true)]
        public string MedicareCard
        {
            get { return _medicareCard; }
            set { _medicareCard = value; }
        }

        private int _isNew;
        /// <summary>
        /// 是否是新病人标识
        /// </summary>
        [Column(FieldName = "IsNew", DataKey = false, Match = "", IsInsert = true)]
        public int IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
    }
}
