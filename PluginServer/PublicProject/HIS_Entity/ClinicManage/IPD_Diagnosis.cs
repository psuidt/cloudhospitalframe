using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "IPD_Diagnosis", EntityType = EntityType.Table, IsGB = false)]
    public class IPD_Diagnosis:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
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

        private int  _dgsdocid;
        /// <summary>
        /// 诊断医生
        /// </summary>
        [Column(FieldName = "DgsDocID", DataKey = false, Match = "", IsInsert = true)]
        public int DgsDocID
        {
            get { return  _dgsdocid; }
            set {  _dgsdocid = value; }
        }

        private DateTime  _diagnosistime;
        /// <summary>
        /// 诊断日期
        /// </summary>
        [Column(FieldName = "DiagnosisTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime DiagnosisTime
        {
            get { return  _diagnosistime; }
            set {  _diagnosistime = value; }
        }

        private int  _diagnosisclass;
        /// <summary>
        /// 诊断类型
        /// </summary>
        [Column(FieldName = "DiagnosisClass", DataKey = false, Match = "", IsInsert = true)]
        public int DiagnosisClass
        {
            get { return  _diagnosisclass; }
            set {  _diagnosisclass = value; }
        }

        private int  _main;
        /// <summary>
        /// 是否主诊断 1=主诊断
        /// </summary>
        [Column(FieldName = "Main", DataKey = false, Match = "", IsInsert = true)]
        public int Main
        {
            get { return  _main; }
            set {  _main = value; }
        }

        private string  _diagnosisname;
        /// <summary>
        /// 诊断名称
        /// </summary>
        [Column(FieldName = "DiagnosisName", DataKey = false, Match = "", IsInsert = true)]
        public string DiagnosisName
        {
            get { return  _diagnosisname; }
            set {  _diagnosisname = value; }
        }

        private int  _diagnosisid;
        /// <summary>
        /// 引用诊断ID
        /// </summary>
        [Column(FieldName = "DiagnosisID", DataKey = false, Match = "", IsInsert = true)]
        public int DiagnosisID
        {
            get { return  _diagnosisid; }
            set {  _diagnosisid = value; }
        }

        private string   _icdcode;
        /// <summary>
        /// ICD10编码
        /// </summary>
        [Column(FieldName = "ICDCode", DataKey = false, Match = "", IsInsert = true)]
        public string ICDCode
        {
            get { return  _icdcode; }
            set {  _icdcode = value; }
        }

        private string  _effect;
        /// <summary>
        /// 情况
        /// </summary>
        [Column(FieldName = "Effect", DataKey = false, Match = "", IsInsert = true)]
        public string Effect
        {
            get { return  _effect; }
            set {  _effect = value; }
        }

        private int  _orderid;
        /// <summary>
        /// 对应医嘱ID
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public int OrderID
        {
            get { return  _orderid; }
            set {  _orderid = value; }
        }

    }
}
