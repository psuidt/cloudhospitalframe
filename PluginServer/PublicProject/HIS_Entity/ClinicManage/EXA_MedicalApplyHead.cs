using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "EXA_MedicalApplyHead", EntityType = EntityType.Table, IsGB = false)]
    public class EXA_MedicalApplyHead:AbstractEntity
    {
        private int  _applyheadid;
        /// <summary>
        /// 申请头表ID
        /// </summary>
        [Column(FieldName = "ApplyHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int ApplyHeadID
        {
            get { return  _applyheadid; }
            set {  _applyheadid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 就诊ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private int  _systemtype;
        /// <summary>
        /// 系统类型（0门诊医生站，1住院医生站）
        /// </summary>
        [Column(FieldName = "SystemType", DataKey = false, Match = "", IsInsert = true)]
        public int SystemType
        {
            get { return  _systemtype; }
            set {  _systemtype = value; }
        }

        private int  _applytype;
        /// <summary>
        /// 医技申请类型（0=化验，1=检查，2=治疗）
        /// </summary>
        [Column(FieldName = "ApplyType", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyType
        {
            get { return  _applytype; }
            set {  _applytype = value; }
        }

        private int  _examtypeid;
        /// <summary>
        /// 医技项目类型ID 
        /// </summary>
        [Column(FieldName = "ExamTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int ExamTypeID
        {
            get { return  _examtypeid; }
            set {  _examtypeid = value; }
        }

        private string  _applycontent;
        /// <summary>
        /// 申请内容：XML格式
        /// </summary>
        [Column(FieldName = "ApplyContent", DataKey = false, Match = "", IsInsert = true)]
        public string ApplyContent
        {
            get { return  _applycontent; }
            set {  _applycontent = value; }
        }

        private int  _applydoctorid;
        /// <summary>
        /// 申请医生ID
        /// </summary>
        [Column(FieldName = "ApplyDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyDoctorID
        {
            get { return  _applydoctorid; }
            set {  _applydoctorid = value; }
        }

        private int  _applydeptid;
        /// <summary>
        /// 申请科室ID
        /// </summary>
        [Column(FieldName = "ApplyDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyDeptID
        {
            get { return  _applydeptid; }
            set {  _applydeptid = value; }
        }

        private int  _executedeptid;
        /// <summary>
        /// 执行科室ID
        /// </summary>
        [Column(FieldName = "ExecuteDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecuteDeptID
        {
            get { return  _executedeptid; }
            set {  _executedeptid = value; }
        }

        private DateTime  _applydate;
        /// <summary>
        /// 申请时间
        /// </summary>
        [Column(FieldName = "ApplyDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ApplyDate
        {
            get { return  _applydate; }
            set {  _applydate = value; }
        }

        private int  _applystatus;
        /// <summary>
        /// 申请状态：0申请1收费2确费3退费
        /// </summary>
        [Column(FieldName = "ApplyStatus", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyStatus
        {
            get { return  _applystatus; }
            set {  _applystatus = value; }
        }

        private string  _remark;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private DateTime _checkdate;
        /// <summary>
        /// 检查时间
        /// </summary>
        [Column(FieldName = "CheckDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CheckDate
        {
            get { return _checkdate; }
            set { _checkdate = value; }
        }

    }
}
