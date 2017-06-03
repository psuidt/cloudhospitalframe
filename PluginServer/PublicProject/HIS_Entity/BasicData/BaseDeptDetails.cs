using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseDeptDetails", EntityType = EntityType.Table, IsGB = false)]
    public class BaseDeptDetails:AbstractEntity
    {
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

        //private int _workid;
        ///// <summary>
        ///// 机构ID
        ///// </summary>
        //[Column(FieldName = "WorkId", DataKey = false, Match = "", IsInsert = true)]
        //public int WorkId
        //{
        //    get { return _workid; }
        //    set { _workid = value; }
        //}

        private int  _deptid;
        /// <summary>
        /// 科室ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

        private int  _depttype;
        /// <summary>
        /// 科室类别 '0'-普通 '1'-重点
        /// </summary>
        [Column(FieldName = "DeptType", DataKey = false, Match = "", IsInsert = true)]
        public int DeptType
        {
            get { return  _depttype; }
            set {  _depttype = value; }
        }

        private string  _principal;
        /// <summary>
        /// 负责人
        /// </summary>
        [Column(FieldName = "Principal", DataKey = false, Match = "", IsInsert = true)]
        public string Principal
        {
            get { return  _principal; }
            set {  _principal = value; }
        }

        private string  _telephone;
        /// <summary>
        /// 电话
        /// </summary>
        [Column(FieldName = "Telephone", DataKey = false, Match = "", IsInsert = true)]
        public string Telephone
        {
            get { return  _telephone; }
            set {  _telephone = value; }
        }

        private int  _member_num;
        /// <summary>
        /// 人数
        /// </summary>
        [Column(FieldName = "Member_Num", DataKey = false, Match = "", IsInsert = true)]
        public int Member_Num
        {
            get { return  _member_num; }
            set {  _member_num = value; }
        }

        private int  _bed_num;
        /// <summary>
        /// 床位数
        /// </summary>
        [Column(FieldName = "Bed_Num", DataKey = false, Match = "", IsInsert = true)]
        public int Bed_Num
        {
            get { return  _bed_num; }
            set {  _bed_num = value; }
        }

        private int  _outused;
        /// <summary>
        /// 是否门诊科室
        /// </summary>
        [Column(FieldName = "OutUsed", DataKey = false, Match = "", IsInsert = true)]
        public int OutUsed
        {
            get { return  _outused; }
            set {  _outused = value; }
        }

        private int  _inused;
        /// <summary>
        /// 是否住院科室
        /// </summary>
        [Column(FieldName = "InUsed", DataKey = false, Match = "", IsInsert = true)]
        public int InUsed
        {
            get { return  _inused; }
            set {  _inused = value; }
        }

        private int  _prtwardused;
        /// <summary>
        /// 是否病区
        /// </summary>
        [Column(FieldName = "PrtWardUsed", DataKey = false, Match = "", IsInsert = true)]
        public int PrtWardUsed
        {
            get { return  _prtwardused; }
            set {  _prtwardused = value; }
        }

        private int  _pharmacyused;
        /// <summary>
        /// 是否药房
        /// </summary>
        [Column(FieldName = "PharmacyUsed", DataKey = false, Match = "", IsInsert = true)]
        public int PharmacyUsed
        {
            get { return  _pharmacyused; }
            set {  _pharmacyused = value; }
        }

        private int  _examineused;
        /// <summary>
        /// 检查科室
        /// </summary>
        [Column(FieldName = "ExamineUsed", DataKey = false, Match = "", IsInsert = true)]
        public int ExamineUsed
        {
            get { return  _examineused; }
            set {  _examineused = value; }
        }

        private int  _drugused;
        /// <summary>
        /// 是否药库仓库
        /// </summary>
        [Column(FieldName = "DrugUsed", DataKey = false, Match = "", IsInsert = true)]
        public int DrugUsed
        {
            get { return  _drugused; }
            set {  _drugused = value; }
        }

        private int  _materialsused;
        /// <summary>
        /// 是否物资仓库
        /// </summary>
        [Column(FieldName = "MaterialsUsed", DataKey = false, Match = "", IsInsert = true)]
        public int MaterialsUsed
        {
            get { return  _materialsused; }
            set {  _materialsused = value; }
        }

        private string  _deptaddress;
        /// <summary>
        /// 科室所在位置
        /// </summary>
        [Column(FieldName = "DeptAddress", DataKey = false, Match = "", IsInsert = true)]
        public string DeptAddress
        {
            get { return  _deptaddress; }
            set {  _deptaddress = value; }
        }

    }
}
