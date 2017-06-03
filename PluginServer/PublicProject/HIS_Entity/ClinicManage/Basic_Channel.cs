using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "Basic_Channel", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_Channel:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 用法ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private string  _channelname;
        /// <summary>
        /// 用法名称
        /// </summary>
        [Column(FieldName = "ChannelName", DataKey = false, Match = "", IsInsert = true)]
        public string ChannelName
        {
            get { return  _channelname; }
            set {  _channelname = value; }
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

        private int  _outused;
        /// <summary>
        /// 门诊使用
        /// </summary>
        [Column(FieldName = "OutUsed", DataKey = false, Match = "", IsInsert = true)]
        public int OutUsed
        {
            get { return  _outused; }
            set {  _outused = value; }
        }

        private int  _inused;
        /// <summary>
        /// 住院使用
        /// </summary>
        [Column(FieldName = "InUsed", DataKey = false, Match = "", IsInsert = true)]
        public int InUsed
        {
            get { return  _inused; }
            set {  _inused = value; }
        }

        private int  _westdrug;
        /// <summary>
        /// 西药使用
        /// </summary>
        [Column(FieldName = "WestDrug", DataKey = false, Match = "", IsInsert = true)]
        public int WestDrug
        {
            get { return  _westdrug; }
            set {  _westdrug = value; }
        }

        private int  _middrug;
        /// <summary>
        /// 中药使用
        /// </summary>
        [Column(FieldName = "MidDrug", DataKey = false, Match = "", IsInsert = true)]
        public int MidDrug
        {
            get { return  _middrug; }
            set {  _middrug = value; }
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
