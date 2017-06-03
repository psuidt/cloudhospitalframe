using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_InpatientReg", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_InpatientReg : AbstractEntity
    {
        private int _regid;
        /// <summary>
        /// 住院证ID
        /// </summary>
        [Column(FieldName = "RegID", DataKey = true, Match = "", IsInsert = false)]
        public int RegID
        {
            get { return _regid; }
            set { _regid = value; }
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

        private int _patlistid;
        /// <summary>
        /// 就诊ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private string _hospitalcode;
        /// <summary>
        /// 住院诊断编码
        /// </summary>
        [Column(FieldName = "HospitalCode", DataKey = false, Match = "", IsInsert = true)]
        public string HospitalCode
        {
            get { return _hospitalcode; }
            set { _hospitalcode = value; }
        }

        private string _outpatientdocdia;
        /// <summary>
        /// 门诊诊断
        /// </summary>
        [Column(FieldName = "OutPatientDocDia", DataKey = false, Match = "", IsInsert = true)]
        public string OutPatientDocDia
        {
            get { return _outpatientdocdia; }
            set { _outpatientdocdia = value; }
        }

        private string _hospitaldocdia;
        /// <summary>
        /// 住院诊断
        /// </summary>
        [Column(FieldName = "HospitalDocDia", DataKey = false, Match = "", IsInsert = true)]
        public string HospitalDocDia
        {
            get { return _hospitaldocdia; }
            set { _hospitaldocdia = value; }
        }

        private string _conditionstu;
        /// <summary>
        /// 病情状况 1.危重，2.急诊,3.一般,9.其他
        /// </summary>
        [Column(FieldName = "ConditionStu", DataKey = false, Match = "", IsInsert = true)]
        public string ConditionStu
        {
            get { return _conditionstu; }
            set { _conditionstu = value; }
        }

        private string _bodyposition;
        /// <summary>
        /// 体位 1-自动 2-平卧 3-半卧
        /// </summary>
        [Column(FieldName = "BodyPosition", DataKey = false, Match = "", IsInsert = true)]
        public string BodyPosition
        {
            get { return _bodyposition; }
            set { _bodyposition = value; }
        }

        private string _transway;
        /// <summary>
        /// 接送方式 1-自行 2-扶行 3-车送 4-抬送
        /// </summary>
        [Column(FieldName = "TransWay", DataKey = false, Match = "", IsInsert = true)]
        public string TransWay
        {
            get { return _transway; }
            set { _transway = value; }
        }

        private string _diet;
        /// <summary>
        /// 饮食 1-普通 2-半流 3-全流
        /// </summary>
        [Column(FieldName = "Diet", DataKey = false, Match = "", IsInsert = true)]
        public string Diet
        {
            get { return _diet; }
            set { _diet = value; }
        }

        private string _quarantine;
        /// <summary>
        /// 1-毋庸管理 2-呼吸道隔离 3-床边隔离
        /// </summary>
        [Column(FieldName = "Quarantine", DataKey = false, Match = "", IsInsert = true)]
        public string Quarantine
        {
            get { return _quarantine; }
            set { _quarantine = value; }
        }

        private int _indeptid;
        /// <summary>
        /// 住院科室代码
        /// </summary>
        [Column(FieldName = "InDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int InDeptID
        {
            get { return _indeptid; }
            set { _indeptid = value; }
        }

        private string _indeptname;
        /// <summary>
        /// 住院科室名称
        /// </summary>
        [Column(FieldName = "InDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string InDeptName
        {
            get { return _indeptname; }
            set { _indeptname = value; }
        }

        private Decimal _deposit;
        /// <summary>
        /// 押金
        /// </summary>
        [Column(FieldName = "Deposit", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        private string _attention;
        /// <summary>
        /// 注意事项
        /// </summary>
        [Column(FieldName = "Attention", DataKey = false, Match = "", IsInsert = true)]
        public string Attention
        {
            get { return _attention; }
            set { _attention = value; }
        }

        private int _signdoctorid;
        /// <summary>
        /// 签证医生ID
        /// </summary>
        [Column(FieldName = "SignDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int SignDoctorID
        {
            get { return _signdoctorid; }
            set { _signdoctorid = value; }
        }

        private string _signdocname;
        /// <summary>
        /// 签证医生名称
        /// </summary>
        [Column(FieldName = "SignDocName", DataKey = false, Match = "", IsInsert = true)]
        public string SignDocName
        {
            get { return _signdocname; }
            set { _signdocname = value; }
        }

        private DateTime _signtime;
        /// <summary>
        /// 签证时间
        /// </summary>
        [Column(FieldName = "SignTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime SignTime
        {
            get { return _signtime; }
            set { _signtime = value; }
        }

        private int _regempid;
        /// <summary>
        /// 登记人
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return _regempid; }
            set { _regempid = value; }
        }

        private DateTime _regdate;
        /// <summary>
        /// 登记时间
        /// </summary>
        [Column(FieldName = "RegDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegDate
        {
            get { return _regdate; }
            set { _regdate = value; }
        }

        private int _regstatus;
        /// <summary>
        /// 登记状态： 0.未登记 1.已经登记,2.门诊医生取消申请登记
        /// </summary>
        [Column(FieldName = "RegStatus", DataKey = false, Match = "", IsInsert = true)]
        public int RegStatus
        {
            get { return _regstatus; }
            set { _regstatus = value; }
        }

    }
}
