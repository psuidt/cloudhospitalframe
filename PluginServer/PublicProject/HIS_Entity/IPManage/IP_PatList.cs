using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_PatList", EntityType = EntityType.Table, IsGB = false)]
    public class IP_PatList : AbstractEntity
    {
        private int _patlistid;
        /// <summary>
        /// 住院入院记录ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = true, Match = "", IsInsert = false)]
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private int _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return _memberid; }
            set { _memberid = value; }
        }

        private int _memberaccountid;
        /// <summary>
        /// 会员账户ID
        /// </summary>
        [Column(FieldName = "MemberAccountID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberAccountID
        {
            get { return _memberaccountid; }
            set { _memberaccountid = value; }
        }

        private string _cardno;
        /// <summary>
        /// 卡号
        /// </summary>
        [Column(FieldName = "CardNO", DataKey = false, Match = "", IsInsert = true)]
        public string CardNO
        {
            get { return _cardno; }
            set { _cardno = value; }
        }

        private Decimal _serialnumber;
        /// <summary>
        /// 住院流水号
        /// </summary>
        [Column(FieldName = "SerialNumber", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SerialNumber
        {
            get { return _serialnumber; }
            set { _serialnumber = value; }
        }

        private string _casenumber;
        /// <summary>
        /// 住院病案号
        /// </summary>
        [Column(FieldName = "CaseNumber", DataKey = false, Match = "", IsInsert = true)]
        public string CaseNumber
        {
            get { return _casenumber; }
            set { _casenumber = value; }
        }

        private string _patdatcardno;
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        [Column(FieldName = "PatDatCardNo", DataKey = false, Match = "", IsInsert = true)]
        public string PatDatCardNo
        {
            get { return _patdatcardno; }
            set { _patdatcardno = value; }
        }

        private int _times;
        /// <summary>
        /// 住院次数
        /// </summary>
        [Column(FieldName = "Times", DataKey = false, Match = "", IsInsert = true)]
        public int Times
        {
            get { return _times; }
            set { _times = value; }
        }

        private int _pattypeid;
        /// <summary>
        /// 病人类型ID
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return _pattypeid; }
            set { _pattypeid = value; }
        }

        private string _patname;
        /// <summary>
        /// 病人名称
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

        private string _ename;
        /// <summary>
        /// 英文名
        /// </summary>
        [Column(FieldName = "EName", DataKey = false, Match = "", IsInsert = true)]
        public string EName
        {
            get { return _ename; }
            set { _ename = value; }
        }

        private string _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return _pycode; }
            set { _pycode = value; }
        }

        private string _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return _wbcode; }
            set { _wbcode = value; }
        }

        private string _sex;
        /// <summary>
        /// 性别
        /// </summary>
        [Column(FieldName = "Sex", DataKey = false, Match = "", IsInsert = true)]
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private DateTime _birthday;
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(FieldName = "Birthday", DataKey = false, Match = "", IsInsert = true)]
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _age;
        /// <summary>
        /// 年龄
        /// </summary>
        [Column(FieldName = "Age", DataKey = false, Match = "", IsInsert = true)]
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private int _status;
        /// <summary>
        /// 病人状态
        /// 1.新入院
        /// 2.在床
        /// 3.出院未结算
        /// 4.出院结算
        /// 9.取消入院
        /// </summary>
        [Column(FieldName = "Status", DataKey = false, Match = "", IsInsert = true)]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _enterhdate;
        /// <summary>
        /// 入院日期
        /// </summary>
        [Column(FieldName = "EnterHDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime EnterHDate
        {
            get { return _enterhdate; }
            set { _enterhdate = value; }
        }

        private DateTime _leavehdate;
        /// <summary>
        /// 出院日期
        /// </summary>
        [Column(FieldName = "LeaveHDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime LeaveHDate
        {
            get { return _leavehdate; }
            set { _leavehdate = value; }
        }

        private int _enterdeptid;
        /// <summary>
        /// 入院科室
        /// </summary>
        [Column(FieldName = "EnterDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int EnterDeptID
        {
            get { return _enterdeptid; }
            set { _enterdeptid = value; }
        }

        private int _enterwardid;
        /// <summary>
        /// 入院病区
        /// </summary>
        [Column(FieldName = "EnterWardID", DataKey = false, Match = "", IsInsert = true)]
        public int EnterWardID
        {
            get { return _enterwardid; }
            set { _enterwardid = value; }
        }

        private string _enterdiseasecode;
        /// <summary>
        /// 入院诊断代码
        /// </summary>
        [Column(FieldName = "EnterDiseaseCode", DataKey = false, Match = "", IsInsert = true)]
        public string EnterDiseaseCode
        {
            get { return _enterdiseasecode; }
            set { _enterdiseasecode = value; }
        }

        private string _enterdiseasename;
        /// <summary>
        /// 入院诊断名称
        /// </summary>
        [Column(FieldName = "EnterDiseaseName", DataKey = false, Match = "", IsInsert = true)]
        public string EnterDiseaseName
        {
            get { return _enterdiseasename; }
            set { _enterdiseasename = value; }
        }

        private int _enterdoctorid;
        /// <summary>
        /// 入院医生代码
        /// </summary>
        [Column(FieldName = "EnterDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int EnterDoctorID
        {
            get { return _enterdoctorid; }
            set { _enterdoctorid = value; }
        }

        private int _enternurseid;
        /// <summary>
        /// 入院护士代码
        /// </summary>
        [Column(FieldName = "EnterNurseID", DataKey = false, Match = "", IsInsert = true)]
        public int EnterNurseID
        {
            get { return _enternurseid; }
            set { _enternurseid = value; }
        }

        private string _bedno;
        /// <summary>
        /// 床位号
        /// </summary>
        [Column(FieldName = "BedNo", DataKey = false, Match = "", IsInsert = true)]
        public string BedNo
        {
            get { return _bedno; }
            set { _bedno = value; }
        }

        private int _currdeptid;
        /// <summary>
        /// 当前科室
        /// </summary>
        [Column(FieldName = "CurrDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int CurrDeptID
        {
            get { return _currdeptid; }
            set { _currdeptid = value; }
        }

        private int _currwardid;
        /// <summary>
        /// 当前病区
        /// </summary>
        [Column(FieldName = "CurrWardID", DataKey = false, Match = "", IsInsert = true)]
        public int CurrWardID
        {
            get { return _currwardid; }
            set { _currwardid = value; }
        }

        private int _currdoctorid;
        /// <summary>
        /// 当前医生代码
        /// </summary>
        [Column(FieldName = "CurrDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int CurrDoctorID
        {
            get { return _currdoctorid; }
            set { _currdoctorid = value; }
        }

        private int _currnurseid;
        /// <summary>
        /// 当前护士代码
        /// </summary>
        [Column(FieldName = "CurrNurseID", DataKey = false, Match = "", IsInsert = true)]
        public int CurrNurseID
        {
            get { return _currnurseid; }
            set { _currnurseid = value; }
        }

        private string _entersituation;
        /// <summary>
        /// 入院情况
        /// </summary>
        [Column(FieldName = "EnterSituation", DataKey = false, Match = "", IsInsert = true)]
        public string EnterSituation
        {
            get { return _entersituation; }
            set { _entersituation = value; }
        }

        private string _outsituation;
        /// <summary>
        /// 出院情况（好转）
        /// </summary>
        [Column(FieldName = "OutSituation", DataKey = false, Match = "", IsInsert = true)]
        public string OutSituation
        {
            get { return _outsituation; }
            set { _outsituation = value; }
        }

        private DateTime _makerdate;
        /// <summary>
        /// 登记时间
        /// </summary>
        [Column(FieldName = "MakerDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime MakerDate
        {
            get { return _makerdate; }
            set { _makerdate = value; }
        }

        private int _makerempid;
        /// <summary>
        /// 登记人
        /// </summary>
        [Column(FieldName = "MakerEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int MakerEmpID
        {
            get { return _makerempid; }
            set { _makerempid = value; }
        }

        private int _sourceway;
        /// <summary>
        /// 来源途经，0个人 1推荐 2活动
        /// </summary>
        [Column(FieldName = "SourceWay", DataKey = false, Match = "", IsInsert = true)]
        public int SourceWay
        {
            get { return _sourceway; }
            set { _sourceway = value; }
        }

        private string _sourceperson;
        /// <summary>
        /// 来源介绍人
        /// </summary>
        [Column(FieldName = "SourcePerson", DataKey = false, Match = "", IsInsert = true)]
        public string SourcePerson
        {
            get { return _sourceperson; }
            set { _sourceperson = value; }
        }

        private string _medicarecard;
        /// <summary>
        /// 医保卡号
        /// </summary>
        [Column(FieldName = "MedicareCard", DataKey = false, Match = "", IsInsert = true)]
        public string MedicareCard
        {
            get { return _medicarecard; }
            set { _medicarecard = value; }
        }

        private string _nursinglever;
        /// <summary>
        /// 护理级别
        /// </summary>
        [Column(FieldName = "NursingLever", DataKey = false, Match = "", IsInsert = true)]
        public string NursingLever
        {
            get { return _nursinglever; }
            set { _nursinglever = value; }
        }

        private string _diettype;
        /// <summary>
        /// 饮食类型
        /// </summary>
        [Column(FieldName = "DietType", DataKey = false, Match = "", IsInsert = true)]
        public string DietType
        {
            get { return _diettype; }
            set { _diettype = value; }
        }

        private int _isleavehosorder;
        /// <summary>
        /// 是否已开出院医嘱，0=未开1=已开并且医嘱已发送
        /// </summary>
        [Column(FieldName = "IsLeaveHosOrder", DataKey = false, Match = "", IsInsert = true)]
        public int IsLeaveHosOrder
        {
            get { return _isleavehosorder; }
            set { _isleavehosorder = value; }
        }

    }
}
