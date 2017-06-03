using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_ExamType", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_ExamType : AbstractEntity
    {
        private int _examtypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ExamTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int ExamTypeID
        {
            get { return _examtypeid; }
            set { _examtypeid = value; }
        }

        private int _examclass;
        /// <summary>
        /// 检查/检验/治疗  1--检查类型   2--检验类型 3-治疗类型 4手术
        /// </summary>
        [Column(FieldName = "ExamClass", DataKey = false, Match = "", IsInsert = true)]
        public int ExamClass
        {
            get { return _examclass; }
            set { _examclass = value; }
        }

        private string _examtypename;
        /// <summary>
        /// 类型名称  如:CT检查、DR检查等, 血常规检查、尿液检查、生化检查等
        /// </summary>
        [Column(FieldName = "ExamTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string ExamTypeName
        {
            get { return _examtypename; }
            set { _examtypename = value; }
        }

        private int _mergeresult;
        /// <summary>
        /// 合并检查结果 1-合并
        /// </summary>
        [Column(FieldName = "MergeResult", DataKey = false, Match = "", IsInsert = true)]
        public int MergeResult
        {
            get { return _mergeresult; }
            set { _mergeresult = value; }
        }

        private int _execdeptid;
        /// <summary>
        /// 执行科室
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return _execdeptid; }
            set { _execdeptid = value; }
        }

        private string _deptdescript;
        /// <summary>
        /// 科室指引描叙
        /// </summary>
        [Column(FieldName = "DeptDescript", DataKey = false, Match = "", IsInsert = true)]
        public string DeptDescript
        {
            get { return _deptdescript; }
            set { _deptdescript = value; }
        }

        private int _examformid;
        /// <summary>
        /// 申请单格式ID
        /// </summary>
        [Column(FieldName = "ExamFormID", DataKey = false, Match = "", IsInsert = true)]
        public int ExamFormID
        {
            get { return _examformid; }
            set { _examformid = value; }
        }

        private int _sampleid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "SampleID", DataKey = false, Match = "", IsInsert = true)]
        public int SampleID
        {
            get { return _sampleid; }
            set { _sampleid = value; }
        }

        private int _delflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }

        private int _reportno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ReportNo", DataKey = false, Match = "", IsInsert = true)]
        public int ReportNo
        {
            get { return _reportno; }
            set { _reportno = value; }
        }

    }
}
