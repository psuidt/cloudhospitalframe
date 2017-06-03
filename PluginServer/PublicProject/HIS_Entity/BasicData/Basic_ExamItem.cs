using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_ExamItem", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_ExamItem:AbstractEntity
    {
        private int  _examitemid;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        [Column(FieldName = "ExamItemID", DataKey = true, Match = "", IsInsert = false)]
        public int ExamItemID
        {
            get { return  _examitemid; }
            set {  _examitemid = value; }
        }
        

        private int  _examtypeid;
        /// <summary>
        /// 外键
        /// </summary>
        [Column(FieldName = "ExamTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int ExamTypeID
        {
            get { return  _examtypeid; }
            set {  _examtypeid = value; }
        }

        private int _statid;
        /// <summary>
        /// 外键
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        private string  _examitemname;
        /// <summary>
        /// 检验项目名称
        /// </summary>
        [Column(FieldName = "ExamItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ExamItemName
        {
            get { return  _examitemname; }
            set {  _examitemname = value; }
        }

        private string  _itemshortname;
        /// <summary>
        /// 检查项目简称，用于在有限的位置打印
        /// </summary>
        [Column(FieldName = "ItemShortName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemShortName
        {
            get { return  _itemshortname; }
            set {  _itemshortname = value; }
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

        private string  _examitemdesc;
        /// <summary>
        /// 组合项目描叙
        /// </summary>
        [Column(FieldName = "ExamItemDesc", DataKey = false, Match = "", IsInsert = true)]
        public string ExamItemDesc
        {
            get { return  _examitemdesc; }
            set {  _examitemdesc = value; }
        }

        private int  _filmflag;
        /// <summary>
        /// 是否需要胶片标志
        /// </summary>
        [Column(FieldName = "FilmFlag", DataKey = false, Match = "", IsInsert = true)]
        public int FilmFlag
        {
            get { return  _filmflag; }
            set {  _filmflag = value; }
        }

        private int  _cdromflag;
        /// <summary>
        /// 是否需要数据光盘标志
        /// </summary>
        [Column(FieldName = "CdromFlag", DataKey = false, Match = "", IsInsert = true)]
        public int CdromFlag
        {
            get { return  _cdromflag; }
            set {  _cdromflag = value; }
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
