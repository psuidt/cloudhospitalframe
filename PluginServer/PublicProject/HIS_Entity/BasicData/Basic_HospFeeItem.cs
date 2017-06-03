using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData.BusiEntity;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_HospFeeItem", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_HospFeeItem : AbstractEntity
    {
        private int _itemid;
        /// <summary>
        /// 本院项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = true, Match = "", IsInsert = false)]
        public int ItemID
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        private int _centeritemid;
        /// <summary>
        /// 中心项目ID
        /// </summary>
        [Column(FieldName = "CenterItemID", DataKey = false, Match = "", IsInsert = true)]
        public int CenterItemID
        {
            get { return _centeritemid; }
            set { _centeritemid = value; }
        }

        private string _itemcode;
        /// <summary>
        /// 项目代码
        /// </summary>
        [Column(FieldName = "ItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string ItemCode
        {
            get { return _itemcode; }
            set { _itemcode = value; }
        }

        private string _itemname;
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private string _aliasname;
        /// <summary>
        /// 项目别名
        /// </summary>
        [Column(FieldName = "AliasName", DataKey = false, Match = "", IsInsert = true)]
        public string AliasName
        {
            get { return _aliasname; }
            set { _aliasname = value; }
        }

        private string _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PyCode", DataKey = false, Match = "", IsInsert = true)]
        public string PyCode
        {
            get { return _pycode; }
            set { _pycode = value; }
        }

        private string _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WbCode", DataKey = false, Match = "", IsInsert = true)]
        public string WbCode
        {
            get { return _wbcode; }
            set { _wbcode = value; }
        }

        private string _cuscode;
        /// <summary>
        /// 自定义码
        /// </summary>
        [Column(FieldName = "CusCode", DataKey = false, Match = "", IsInsert = true)]
        public string CusCode
        {
            get { return _cuscode; }
            set { _cuscode = value; }
        }

        private Decimal _price;
        /// <summary>
        /// 项目价格
        /// </summary>
        [Column(FieldName = "Price", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private Decimal _one_level;
        /// <summary>
        /// 一级价格
        /// </summary>
        [Column(FieldName = "One_level", DataKey = false, Match = "", IsInsert = true)]
        public Decimal One_level
        {
            get { return _one_level; }
            set { _one_level = value; }
        }

        private Decimal _two_level;
        /// <summary>
        /// 二级价格
        /// </summary>
        [Column(FieldName = "Two_level", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Two_level
        {
            get { return _two_level; }
            set { _two_level = value; }
        }

        private Decimal _three_level;
        /// <summary>
        /// 三级价格
        /// </summary>
        [Column(FieldName = "Three_level", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Three_level
        {
            get { return _three_level; }
            set { _three_level = value; }
        }

        private int _statid;
        /// <summary>
        /// 统计项目ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        [Column(FieldName = "StatName", DataKey = false, Match = "", IsInsert = false)]
        public string StatName { get; set; }

        private int _isble;
        /// <summary>
        /// 处方可开
        /// </summary>
        [Column(FieldName = "IsBle", DataKey = false, Match = "", IsInsert = true)]
        public int IsBle
        {
            get { return _isble; }
            set { _isble = value; }
        }

        public string StrIsBle { get { return IsBle == 1 ? "处方可开" : "处方不可开"; } }

        private int _modempid;
        /// <summary>
        /// 修改人
        /// </summary>
        [Column(FieldName = "ModEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ModEmpID
        {
            get { return _modempid; }
            set { _modempid = value; }
        }

        private DateTime _moddate;
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(FieldName = "ModDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ModDate
        {
            get { return _moddate; }
            set { _moddate = value; }
        }

        private int _isstop;
        /// <summary>
        /// 是否停用
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return _isstop; }
            set { _isstop = value; }
        }
        public string StrIsStop
        {
            get
            {
                return IsStop
                    .ToEnum(IsStopType.Disabled)
                    .GetEnumDisplay();
            }
        }

        private int _mretype;
        /// <summary>
        /// 是否医保类型 0-否 1-甲类 2-乙类 3-丙类
        /// </summary>
        [Column(FieldName = "MedicateID", DataKey = false, Match = "", IsInsert = true)]
        public int MedicateID
        {
            get { return _mretype; }
            set { _mretype = value; }
        }

        /// <summary>
        /// 获取医保类型名称
        /// </summary>
        public string StrMreType
        {
            get
            {
                return MedicateID
                    .ToEnum(MreTypes.Default)
                    .GetEnumDisplay();
            }
        }
    }
}
