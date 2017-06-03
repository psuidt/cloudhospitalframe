using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_CaseRecord", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_CaseRecord:AbstractEntity
    {
        private int  _caserecordid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CaseRecordID", DataKey = true, Match = "", IsInsert = false)]
        public int CaseRecordID
        {
            get { return  _caserecordid; }
            set {  _caserecordid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private DateTime  _createtime;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(FieldName = "CreateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CreateTime
        {
            get { return  _createtime; }
            set {  _createtime = value; }
        }

        private int  _createuserid;
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(FieldName = "CreateUserID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateUserID
        {
            get { return  _createuserid; }
            set {  _createuserid = value; }
        }

        private string  _createusername;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CreateUserName", DataKey = false, Match = "", IsInsert = true)]
        public string CreateUserName
        {
            get { return  _createusername; }
            set {  _createusername = value; }
        }

        private int  _createdeptid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CreateDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateDeptID
        {
            get { return  _createdeptid; }
            set {  _createdeptid = value; }
        }

        private string  _createdeptname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CreateDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string CreateDeptName
        {
            get { return  _createdeptname; }
            set {  _createdeptname = value; }
        }

        private int  _deletestatus;
        /// <summary>
        /// 0正常1删除
        /// </summary>
        [Column(FieldName = "DeleteStatus", DataKey = false, Match = "", IsInsert = true)]
        public int DeleteStatus
        {
            get { return  _deletestatus; }
            set {  _deletestatus = value; }
        }

        private int  _uploadstatus;
        /// <summary>
        /// 0未上传 1已上传
        /// </summary>
        [Column(FieldName = "UploadStatus", DataKey = false, Match = "", IsInsert = true)]
        public int UploadStatus
        {
            get { return  _uploadstatus; }
            set {  _uploadstatus = value; }
        }

        private DateTime  _updatetime;
        /// <summary>
        /// 最后一次保存时间
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private int  _updateuserid;
        /// <summary>
        /// 最后修改人ID
        /// </summary>
        [Column(FieldName = "UpdateUserID", DataKey = false, Match = "", IsInsert = true)]
        public int UpdateUserID
        {
            get { return  _updateuserid; }
            set {  _updateuserid = value; }
        }

        private string  _updateusername;
        /// <summary>
        /// 最后修改人姓名
        /// </summary>
        [Column(FieldName = "UpdateUserName", DataKey = false, Match = "", IsInsert = true)]
        public string UpdateUserName
        {
            get { return  _updateusername; }
            set {  _updateusername = value; }
        }      

        private string  _mongocaseid;
        /// <summary>
        /// Mongo文档标识
        /// </summary>
        [Column(FieldName = "MongoCaseID", DataKey = false, Match = "", IsInsert = true)]
        public string MongoCaseID
        {
            get { return  _mongocaseid; }
            set {  _mongocaseid = value; }
        }

        private DateTime  _uploadtime;
        /// <summary>
        /// 上传时间
        /// </summary>
        [Column(FieldName = "UpLoadTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpLoadTime
        {
            get { return  _uploadtime; }
            set {  _uploadtime = value; }
        }

    }
}
