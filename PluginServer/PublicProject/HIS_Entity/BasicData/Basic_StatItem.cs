using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_StatItem", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_StatItem:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _statid;
        /// <summary>
        /// 统计大类ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
        }

        private string  _statname;
        /// <summary>
        /// 大类名称
        /// </summary>
        [Column(FieldName = "StatName", DataKey = false, Match = "", IsInsert = true)]
        public string StatName
        {
            get { return  _statname; }
            set {  _statname = value; }
        }

        private int  _accitemid;
        /// <summary>
        /// 会计分类
        /// </summary>
        [Column(FieldName = "AccItemID", DataKey = false, Match = "", IsInsert = true)]
        public int AccItemID
        {
            get { return  _accitemid; }
            set {  _accitemid = value; }
        }

        private int  _costitemid;
        /// <summary>
        /// 核算分类
        /// </summary>
        [Column(FieldName = "CostItemID", DataKey = false, Match = "", IsInsert = true)]
        public int CostItemID
        {
            get { return  _costitemid; }
            set {  _costitemid = value; }
        }

        private int  _baitemid;
        /// <summary>
        /// 病案分类
        /// </summary>
        [Column(FieldName = "BaItemID", DataKey = false, Match = "", IsInsert = true)]
        public int BaItemID
        {
            get { return  _baitemid; }
            set {  _baitemid = value; }
        }

        private int  _infpitemid;
        /// <summary>
        /// 住院发票分类
        /// </summary>
        [Column(FieldName = "InFpItemID", DataKey = false, Match = "", IsInsert = true)]
        public int InFpItemID
        {
            get { return  _infpitemid; }
            set {  _infpitemid = value; }
        }

        private int  _outfpitemid;
        /// <summary>
        /// 门诊发票分类
        /// </summary>
        [Column(FieldName = "OutFpItemID", DataKey = false, Match = "", IsInsert = true)]
        public int OutFpItemID
        {
            get { return  _outfpitemid; }
            set {  _outfpitemid = value; }
        }

        private int  _poitemid;
        /// <summary>
        /// 医保分类
        /// </summary>
        [Column(FieldName = "PoItemID", DataKey = false, Match = "", IsInsert = true)]
        public int PoItemID
        {
            get { return  _poitemid; }
            set {  _poitemid = value; }
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
