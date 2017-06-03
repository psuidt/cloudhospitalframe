using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseUser", EntityType = EntityType.Table, IsGB = false)]
    public class BaseUser : AbstractEntity
    {

        private int _userid;
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "UserID", DataKey = true, Match = "", IsInsert = false)]
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private int _empid;
        /// <summary>
        /// 人员编号
        /// </summary>
        [Column(FieldName = "EmpID", DataKey = false, Match = "", IsInsert = true)]
        public int EmpID
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private string _code;
        /// <summary>
        /// 用户名
        /// </summary>
        [Column(FieldName = "Code", DataKey = false, Match = "", IsInsert = true)]
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>
        [Column(FieldName = "PassWord", DataKey = false, Match = "", IsInsert = true)]
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _groupid;
        /// <summary>
        /// 所属组
        /// </summary>
        [Column(FieldName = "GroupId", DataKey = false, Match = "", IsInsert = true)]
        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        private int _lock;
        /// <summary>
        /// 锁定标记
        /// </summary>
        [Column(FieldName = "Lock", DataKey = false, Match = "", IsInsert = true)]
        public int Lock
        {
            get { return _lock; }
            set { _lock = value; }
        }

        [Column(FieldName = "StrLock", DataKey = false, Match = "", IsInsert = false)]
        public string StrLock
        {
            get
            {
                switch (Lock)
                {
                    case 0: return "已启用";
                    case 1: return "已停用";
                }
                return "已停用";
            }
            set
            {
                //nothing 
            }
        }

        private string _memo;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private int _usertype;
        /// <summary>
        /// 0普通 1收费员 2医生 3护士 4药剂
        /// </summary>
        [Column(FieldName = "UserType", DataKey = false, Match = "", IsInsert = true)]
        public int UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        public string StrUserType
        {
            get
            {
                switch (UserType)
                {
                    case 0: return "普通";
                    case 1: return "收费员";
                    case 2: return "医生";
                    case 3: return "护士";
                    case 4: return "药剂";
                }
                return "普通";
            }
            set
            {
                //nothing 
            }
        }

        private string _doctorpost;
        /// <summary>
        /// 医生岗位
        /// </summary>
        [Column(FieldName = "DoctorPost", DataKey = false, Match = "", IsInsert = true)]
        public string DoctorPost
        {
            get { return _doctorpost; }
            set { _doctorpost = value; }
        }

        [Column(FieldName = "StrDoctorPost", DataKey = false, Match = "", IsInsert = false)]
        public string StrDoctorPost { get; set; }

        private string _nursepost;
        /// <summary>
        /// 护士岗位
        /// </summary>
        [Column(FieldName = "NursePost", DataKey = false, Match = "", IsInsert = true)]
        public string NursePost
        {
            get { return _nursepost; }
            set { _nursepost = value; }
        }

        [Column(FieldName = "StrNursePost", DataKey = false, Match = "", IsInsert = false)]
        public string StrNursePost { get; set; }

        private int _isadmin;
        /// <summary>
        /// 0普通用户 1机构管理员 2超级管理员
        /// </summary>
        [Column(FieldName = "IsAdmin", DataKey = false, Match = "", IsInsert = true)]
        public int IsAdmin
        {
            get { return _isadmin; }
            set { _isadmin = value; }
        }

        public string StrIsAdmin
        {
            get
            {
                switch (IsAdmin)
                {
                    case 0: return "普通用户";
                    case 1: return "机构管理员";
                    case 2: return "超级管理员";
                }
                return "普通用户";
            }
            set
            {
                //nothing 
            }
        }

        [Column(FieldName = "Name", DataKey = false, Match = "", IsInsert = false)]
        public string Name { get; set; }

        [Column(FieldName = "DeptId", DataKey = false, Match = "", IsInsert = false)]
        public int DeptId { get; set; }

        [Column(FieldName = "DeptName", DataKey = false, Match = "", IsInsert = false)]
        public string DeptName { get; set; }
    }
}
