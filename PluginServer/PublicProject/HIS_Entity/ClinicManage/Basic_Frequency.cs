using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "Basic_Frequency", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_Frequency:AbstractEntity
    {
        private int  _frequencyid;
        /// <summary>
        /// 频次ID
        /// </summary>
        [Column(FieldName = "FrequencyID", DataKey = true, Match = "", IsInsert = false)]
        public int FrequencyID
        {
            get { return  _frequencyid; }
            set {  _frequencyid = value; }
        }

        private string  _frequencyname;
        /// <summary>
        /// 频次名称
        /// </summary>
        [Column(FieldName = "FrequencyName", DataKey = false, Match = "", IsInsert = true)]
        public string FrequencyName
        {
            get { return  _frequencyname; }
            set {  _frequencyname = value; }
        }

        private string  _cname;
        /// <summary>
        /// 中文名
        /// </summary>
        [Column(FieldName = "CName", DataKey = false, Match = "", IsInsert = true)]
        public string CName
        {
            get { return  _cname; }
            set {  _cname = value; }
        }

        private string  _ename;
        /// <summary>
        /// 英文名
        /// </summary>
        [Column(FieldName = "EName", DataKey = false, Match = "", IsInsert = true)]
        public string EName
        {
            get { return  _ename; }
            set {  _ename = value; }
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

        private int  _westdrug;
        /// <summary>
        /// 西药处方使用
        /// </summary>
        [Column(FieldName = "WestDrug", DataKey = false, Match = "", IsInsert = true)]
        public int WestDrug
        {
            get { return  _westdrug; }
            set {  _westdrug = value; }
        }

        private int  _middrug;
        /// <summary>
        /// 中药处方使用
        /// </summary>
        [Column(FieldName = "MidDrug", DataKey = false, Match = "", IsInsert = true)]
        public int MidDrug
        {
            get { return  _middrug; }
            set {  _middrug = value; }
        }

        private int  _executetype;
        /// <summary>
        /// 执行公式类别
        /// </summary>
        [Column(FieldName = "ExecuteType", DataKey = false, Match = "", IsInsert = true)]
        public int ExecuteType
        {
            get { return  _executetype; }
            set {  _executetype = value; }
        }

        private string  _executecode;
        /// <summary>
        /// 执行代码,最后一个字符不能@，以便统一管理分隔，0123456@D@1@16,36 ==> 1@16,36(可能出现1@而没有时间部分)
        /// </summary>
        [Column(FieldName = "ExecuteCode", DataKey = false, Match = "", IsInsert = true)]
        public string ExecuteCode
        {
            get { return  _executecode; }
            set {  _executecode = value; }
        }

        private int  _sortorder;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return  _sortorder; }
            set {  _sortorder = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
