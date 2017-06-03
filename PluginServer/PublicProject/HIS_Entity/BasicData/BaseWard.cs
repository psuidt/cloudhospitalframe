using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseWard", EntityType = EntityType.Table, IsGB = false)]
    public class BaseWard : AbstractEntity
    {

        private int _wardid;
        /// <summary>
        /// 病区ID
        /// </summary>
        [Column(FieldName = "WardID", DataKey = true, Match = "", IsInsert = false)]
        public int WardID
        {
            get { return _wardid; }
            set { _wardid = value; }
        }

        private string _wardname;
        /// <summary>
        /// 病区名称
        /// </summary>
        [Column(FieldName = "WardName", DataKey = false, Match = "", IsInsert = true)]
        public string WardName
        {
            get { return _wardname; }
            set { _wardname = value; }
        }
        
        private int _sickbedNum;
        /// <summary>
        /// 病区编制床位数
        /// </summary>
        [Column(FieldName = "SickbedNum", DataKey = false, Match = "", IsInsert = true)]
        public int SickbedNum
        {
            get { return _sickbedNum; }
            set { _sickbedNum = value; }
        }

        private string _responsible;
        /// <summary>
        /// 责任人
        /// </summary>
        [Column(FieldName = "Responsible", DataKey = false, Match = "", IsInsert = true)]
        public string Responsible
        {
            get { return _responsible; }
            set { _responsible = value; }
        }

        private string _pym;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "Pym", DataKey = false, Match = "", IsInsert = true)]
        public string Pym
        {
            get { return _pym; }
            set { _pym = value; }
        }

        private string _wbm;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "Wbm", DataKey = false, Match = "", IsInsert = true)]
        public string Wbm
        {
            get { return _wbm; }
            set { _wbm = value; }
        }

        private string _szm;
        /// <summary>
        /// 数字码
        /// </summary>
        [Column(FieldName = "Szm", DataKey = false, Match = "", IsInsert = true)]
        public string Szm
        {
            get { return _szm; }
            set { _szm = value; }
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

        private int _sortorder;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return _sortorder; }
            set { _sortorder = value; }
        }

        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public string StrDelFlag
        {
            get
            {
                switch (DelFlag)
                {
                    case 0: return "已启用";
                    case 1: return "已停用";
                }
                return "已停用";
            }
            set
            {
                //nothing 
            }
        }
    }
}
