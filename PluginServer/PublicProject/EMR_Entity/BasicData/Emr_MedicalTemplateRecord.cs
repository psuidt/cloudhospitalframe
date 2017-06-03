using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_MedicalTemplateRecord", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_MedicalTemplateRecord:AbstractEntity
    {
        private int  _templateid;
        /// <summary>
        /// 模板编码
        /// </summary>
        [Column(FieldName = "TemplateId", DataKey = true, Match = "", IsInsert = false)]
        public int TemplateId
        {
            get { return  _templateid; }
            set {  _templateid = value; }
        }

        private string  _templatename;
        /// <summary>
        /// 模板名称
        /// </summary>
        [Column(FieldName = "TemplateName", DataKey = false, Match = "", IsInsert = true)]
        public string TemplateName
        {
            get { return  _templatename; }
            set {  _templatename = value; }
        }

        private string  _templatecontent;
        /// <summary>
        /// 模板内容
        /// </summary>
        [Column(FieldName = "TemplateContent", DataKey = false, Match = "", IsInsert = true)]
        public string TemplateContent
        {
            get { return  _templatecontent; }
            set {  _templatecontent = value; }
        }

        private int  _roletype;
        /// <summary>
        /// 模板权限(1 全院模板 2 科室模板 3个人模板)
        /// </summary>
        [Column(FieldName = "RoleType", DataKey = false, Match = "", IsInsert = true)]
        public int RoleType
        {
            get { return  _roletype; }
            set {  _roletype = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 科室ID(关联科室表ID,当为全院模板时，科室ID为0)
        /// </summary>
        [Column(FieldName = "DeptId", DataKey = false, Match = "", IsInsert = true)]
        public int DeptId
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private string  _deptname;
        /// <summary>
        /// 科室名称
        /// </summary>
        [Column(FieldName = "DeptName", DataKey = false, Match = "", IsInsert = true)]
        public string DeptName
        {
            get { return  _deptname; }
            set {  _deptname = value; }
        }

        private int  _doctorid;
        /// <summary>
        /// 医生ID
        /// </summary>
        [Column(FieldName = "DoctorID", DataKey = false, Match = "", IsInsert = true)]
        public int DoctorID
        {
            get { return  _doctorid; }
            set {  _doctorid = value; }
        }

        private string  _doctorname;
        /// <summary>
        /// 医生名称
        /// </summary>
        [Column(FieldName = "DoctorName", DataKey = false, Match = "", IsInsert = true)]
        public string DoctorName
        {
            get { return  _doctorname; }
            set {  _doctorname = value; }
        }

        private int  _temptypeid;
        /// <summary>
        /// 模板类型(关联病历树表ID)
        /// </summary>
        [Column(FieldName = "TempTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int TempTypeID
        {
            get { return  _temptypeid; }
            set {  _temptypeid = value; }
        }

        private int  _illnesstype;
        /// <summary>
        /// 病患类型(0 男 1 女 2 通用)
        /// </summary>
        [Column(FieldName = "IllnessType", DataKey = false, Match = "", IsInsert = true)]
        public int IllnessType
        {
            get { return  _illnesstype; }
            set {  _illnesstype = value; }
        }

        private int  _edittype;
        /// <summary>
        /// 编辑方式(1 普通模式 2 表单模式 3 小按钮模式)
        /// </summary>
        [Column(FieldName = "EditType", DataKey = false, Match = "", IsInsert = true)]
        public int EditType
        {
            get { return  _edittype; }
            set {  _edittype = value; }
        }

        private int  _isforbidden;
        /// <summary>
        /// 是否禁用(0 否 1 是)
        /// </summary>
        [Column(FieldName = "IsForbidden", DataKey = false, Match = "", IsInsert = true)]
        public int IsForbidden
        {
            get { return  _isforbidden; }
            set {  _isforbidden = value; }
        }

        private string  _remark;
        /// <summary>
        /// 备注说明
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private DateTime  _addtime;
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column(FieldName = "AddTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AddTime
        {
            get { return  _addtime; }
            set {  _addtime = value; }
        }

        private DateTime  _updatetime;
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private int  _workid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WorkID", DataKey = false, Match = "", IsInsert = true)]
        public int WorkID
        {
            get { return _workid; }
            set { _workid = value; }
        }

        private string _pycode;
        /// <summary>
        /// 拼音
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return _pycode; }
            set { _pycode = value; }
        }

    }
}
