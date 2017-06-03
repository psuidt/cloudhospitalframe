using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "EXA_MedicalConfir", EntityType = EntityType.Table, IsGB = false)]
    public class EXA_MedicalConfir:AbstractEntity
    {
        private int  _confirid;
        /// <summary>
        /// 确费自增长ID
        /// </summary>
        [Column(FieldName = "ConfirID", DataKey = true, Match = "", IsInsert = false)]
        public int ConfirID
        {
            get { return  _confirid; }
            set {  _confirid = value; }
        }

        private int  _markflag;
        /// <summary>
        /// 门诊确费=0,住院确费=1
        /// </summary>
        [Column(FieldName = "MarkFlag", DataKey = false, Match = "", IsInsert = true)]
        public int MarkFlag
        {
            get { return  _markflag; }
            set {  _markflag = value; }
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
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private int  _confirdoctorid;
        /// <summary>
        /// 确认医生ID
        /// </summary>
        [Column(FieldName = "ConfirDoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int ConfirDoctorID
        {
            get { return  _confirdoctorid; }
            set {  _confirdoctorid = value; }
        }

        private string  _confirdoctorname;
        /// <summary>
        /// 确认医生名称
        /// </summary>
        [Column(FieldName = "ConfirDoctorName", DataKey = false, Match = "", IsInsert = true)]
        public string ConfirDoctorName
        {
            get { return  _confirdoctorname; }
            set {  _confirdoctorname = value; }
        }

        private int  _confirdeptid;
        /// <summary>
        /// 确认科室ID
        /// </summary>
        [Column(FieldName = "ConfirDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ConfirDeptID
        {
            get { return  _confirdeptid; }
            set {  _confirdeptid = value; }
        }

        private string  _confirdeptname;
        /// <summary>
        /// 确认科室名称
        /// </summary>
        [Column(FieldName = "ConfirDeptName", DataKey = false, Match = "", IsInsert = true)]
        public string ConfirDeptName
        {
            get { return  _confirdeptname; }
            set {  _confirdeptname = value; }
        }

        private DateTime  _confirdate;
        /// <summary>
        /// 确认日期
        /// </summary>
        [Column(FieldName = "ConfirDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ConfirDate
        {
            get { return  _confirdate; }
            set {  _confirdate = value; }
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

        private Decimal  _fee;
        /// <summary>
        /// 金额
        /// </summary>
        [Column(FieldName = "Fee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Fee
        {
            get { return  _fee; }
            set {  _fee = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 组合项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private int  _presdetailid;
        /// <summary>
        /// 申请单明细ID
        /// </summary>
        [Column(FieldName = "PresDetailID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDetailID
        {
            get { return  _presdetailid; }
            set {  _presdetailid = value; }
        }

        private int  _cancelflag;
        /// <summary>
        /// 取消确费标志 取消=0 确费=1
        /// </summary>
        [Column(FieldName = "CancelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int CancelFlag
        {
            get { return  _cancelflag; }
            set {  _cancelflag = value; }
        }

        private int _isCancel;
        /// <summary>
        /// 取消确费标志 不作废=0 作废=1
        /// </summary>
        [Column(FieldName = "IsCancel", DataKey = false, Match = "", IsInsert = true)]
        public int IsCancel
        {
            get { return _isCancel; }
            set { _isCancel = value; }
        }
    }
}
