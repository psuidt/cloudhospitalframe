using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseEmployeeDetails", EntityType = EntityType.Table, IsGB = false)]
    public class BaseEmployeeDetails : AbstractEntity
    {
        //[Column(FieldName = "WorkId", DataKey = false, Match = "", IsInsert = true)]
        //public int WorkId { get; set; }

        private int _id;
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _empid;
        /// <summary>
        /// 员工ID
        /// </summary>
        [Column(FieldName = "EmpID", DataKey = false, Match = "", IsInsert = true)]
        public int EmpID
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private string _nation;
        /// <summary>
        /// 民族代码  GB 3304-1991 (人事管理-民族)
        /// </summary>
        [Column(FieldName = "Nation", DataKey = false, Match = "", IsInsert = true)]
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        private string _degreecode;
        /// <summary>
        /// 文化程度代码 (人事管理-学历)
        /// </summary>
        [Column(FieldName = "DegreeCode", DataKey = false, Match = "", IsInsert = true)]
        public string DegreeCode
        {
            get { return _degreecode; }
            set { _degreecode = value; }
        }

        private string _address;
        /// <summary>
        /// 户籍地址
        /// </summary>
        [Column(FieldName = "Address", DataKey = false, Match = "", IsInsert = true)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _nowaddress;
        /// <summary>
        /// 现住址
        /// </summary>
        [Column(FieldName = "NowAddress", DataKey = false, Match = "", IsInsert = true)]
        public string NowAddress
        {
            get { return _nowaddress; }
            set { _nowaddress = value; }
        }

        private string _contact;
        /// <summary>
        /// 联系人姓名
        /// </summary>
        [Column(FieldName = "Contact", DataKey = false, Match = "", IsInsert = true)]
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        private string _telephone;
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(FieldName = "Telephone", DataKey = false, Match = "", IsInsert = true)]
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        private string _profession_code;
        /// <summary>
        /// 专业名称
        /// </summary>
        [Column(FieldName = "Profession_Code", DataKey = false, Match = "", IsInsert = true)]
        public string Profession_Code
        {
            get { return _profession_code; }
            set { _profession_code = value; }
        }

        private string _emp_position;
        /// <summary>
        /// 职务
        /// </summary>
        [Column(FieldName = "Emp_Position", DataKey = false, Match = "", IsInsert = true)]
        public string Emp_Position
        {
            get { return _emp_position; }
            set { _emp_position = value; }
        }

        private string _emp_level;
        /// <summary>
        /// 级别
        /// </summary>
        [Column(FieldName = "Emp_Level", DataKey = false, Match = "", IsInsert = true)]
        public string Emp_Level
        {
            get { return _emp_level; }
            set { _emp_level = value; }
        }

        private string _emptitle_code;
        /// <summary>
        /// 技术职称代码
        /// </summary>
        [Column(FieldName = "EmpTitle_Code", DataKey = false, Match = "", IsInsert = true)]
        public string EmpTitle_Code
        {
            get { return _emptitle_code; }
            set { _emptitle_code = value; }
        }

        private string _email;
        /// <summary>
        /// 电子邮件地址
        /// </summary>
        [Column(FieldName = "Email", DataKey = false, Match = "", IsInsert = true)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _related_no;
        /// <summary>
        /// 紧密联系人电话
        /// </summary>
        [Column(FieldName = "Related_No", DataKey = false, Match = "", IsInsert = true)]
        public string Related_No
        {
            get { return _related_no; }
            set { _related_no = value; }
        }

        private DateTime _workdate;
        /// <summary>
        /// 参加工作日期
        /// </summary>
        [Column(FieldName = "WorkDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime WorkDate
        {
            get { return _workdate; }
            set { _workdate = value; }
        }

        private int _on_flag;
        /// <summary>
        /// 在位标志：'1'-在职 '0'-不在职
        /// </summary>
        [Column(FieldName = "On_Flag", DataKey = false, Match = "", IsInsert = true)]
        public int On_Flag
        {
            get { return _on_flag; }
            set { _on_flag = value; }
        }

        private string _native;
        /// <summary>
        /// 籍贯
        /// </summary>
        [Column(FieldName = "Native", DataKey = false, Match = "", IsInsert = true)]
        public string Native
        {
            get { return _native; }
            set { _native = value; }
        }

        private string _politicalstatus;
        /// <summary>
        /// 政治面貌
        /// </summary>
        [Column(FieldName = "PoliticalStatus", DataKey = false, Match = "", IsInsert = true)]
        public string PoliticalStatus
        {
            get { return _politicalstatus; }
            set { _politicalstatus = value; }
        }

        private DateTime _politicaldate;
        /// <summary>
        /// 何时参党或团
        /// </summary>
        [Column(FieldName = "PoliticalDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PoliticalDate
        {
            get { return _politicaldate; }
            set { _politicaldate = value; }
        }

        private string _memo;
        /// <summary>
        /// 人事管理-备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private string _matrimony;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        [Column(FieldName = "Matrimony", DataKey = false, Match = "", IsInsert = true)]
        public string Matrimony
        {
            get { return _matrimony; }
            set { _matrimony = value; }
        }

        private string _shortnum;
        /// <summary>
        /// 短号
        /// </summary>
        [Column(FieldName = "ShortNum", DataKey = false, Match = "", IsInsert = true)]
        public string ShortNum
        {
            get { return _shortnum; }
            set { _shortnum = value; }
        }

        private string _transfernote;
        /// <summary>
        /// 转科记录
        /// </summary>
        [Column(FieldName = "TransferNote", DataKey = false, Match = "", IsInsert = true)]
        public string TransferNote
        {
            get { return _transfernote; }
            set { _transfernote = value; }
        }

        private string _graduateinst;
        /// <summary>
        /// 毕业院校
        /// </summary>
        [Column(FieldName = "GraduateInst", DataKey = false, Match = "", IsInsert = true)]
        public string GraduateInst
        {
            get { return _graduateinst; }
            set { _graduateinst = value; }
        }

        private DateTime _graduatedate;
        /// <summary>
        /// 毕业时间
        /// </summary>
        [Column(FieldName = "GraduateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime GraduateDate
        {
            get { return _graduatedate; }
            set { _graduatedate = value; }
        }

        private string _jobclassifi;
        /// <summary>
        /// 岗位分类
        /// </summary>
        [Column(FieldName = "JobClassifi", DataKey = false, Match = "", IsInsert = true)]
        public string JobClassifi
        {
            get { return _jobclassifi; }
            set { _jobclassifi = value; }
        }

        private string _personcategory;
        /// <summary>
        /// 人员分类0-未分类 1-干部人员 2-职工人员 3-聘用人员 4-临时 5-借调
        /// </summary>
        [Column(FieldName = "PersonCategory", DataKey = false, Match = "", IsInsert = true)]
        public string PersonCategory
        {
            get { return _personcategory; }
            set { _personcategory = value; }
        }

        private DateTime _leavedate;
        /// <summary>
        /// 离职时间
        /// </summary>
        [Column(FieldName = "LeaveDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime LeaveDate
        {
            get { return _leavedate; }
            set { _leavedate = value; }
        }

        private string _certificatenum;
        /// <summary>
        /// 资格证编号
        /// </summary>
        [Column(FieldName = "CertificateNum", DataKey = false, Match = "", IsInsert = true)]
        public string CertificateNum
        {
            get { return _certificatenum; }
            set { _certificatenum = value; }
        }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Column(FieldName = "IDNumber", DataKey = false, Match = "", IsInsert = true)]
        public string IDNumber { get; set; }
    }
}
