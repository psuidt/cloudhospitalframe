using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_OMRDicCategory", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_OMRDicCategory:AbstractEntity
    {
        private int  _omrdiccategoryid;
        /// <summary>
        /// 门诊病历库分类ID
        /// </summary>
        [Column(FieldName = "OMRDicCategoryID", DataKey = true, Match = "", IsInsert = false)]
        public int OMRDicCategoryID
        {
            get { return  _omrdiccategoryid; }
            set {  _omrdiccategoryid = value; }
        }

        private int  _pid;
        /// <summary>
        /// 父节点ID
        /// </summary>
        [Column(FieldName = "PID", DataKey = false, Match = "", IsInsert = true)]
        public int PID
        {
            get { return  _pid; }
            set {  _pid = value; }
        }

        private string  _categoryname;
        /// <summary>
        /// 分类名
        /// </summary>
        [Column(FieldName = "CategoryName", DataKey = false, Match = "", IsInsert = true)]
        public string CategoryName
        {
            get { return  _categoryname; }
            set {  _categoryname = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

    }
}
