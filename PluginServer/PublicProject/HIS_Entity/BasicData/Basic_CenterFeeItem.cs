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
    [Table(TableName = "Basic_CenterFeeItem", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_CenterFeeItem : AbstractEntity
    {
        private int _feeid;
        /// <summary>
        /// 中心项目ID
        /// </summary>
        [Column(FieldName = "FeeID", DataKey = true, Match = "", IsInsert = false)]
        public int FeeID
        {
            get { return _feeid; }
            set { _feeid = value; }
        }

        private string _centeritemcode;
        /// <summary>
        /// 中心项目代码
        /// </summary>
        [Column(FieldName = "CenterItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string CenterItemCode
        {
            get { return _centeritemcode; }
            set { _centeritemcode = value; }
        }

        private string _centeritemname;
        /// <summary>
        /// 中心项目名称
        /// </summary>
        [Column(FieldName = "CenterItemName", DataKey = false, Match = "", IsInsert = true)]
        public string CenterItemName
        {
            get { return _centeritemname; }
            set { _centeritemname = value; }
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

        private string _unit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private Decimal _price;
        /// <summary>
        /// 参考价格
        /// </summary>
        [Column(FieldName = "Price", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _explain;
        /// <summary>
        /// 项目说明
        /// </summary>
        [Column(FieldName = "Explain", DataKey = false, Match = "", IsInsert = true)]
        public string Explain
        {
            get { return _explain; }
            set { _explain = value; }
        }

        private int _statid;
        /// <summary>
        /// 统计分类ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        [Column(FieldName = "StatName", DataKey = false, Match = "", IsInsert = false)]
        public string StatName { get; set; }

        private int _mretype;
        /// <summary>
        /// 是否医保类型 0-否 1-甲类 2-乙类 3-丙类
        /// </summary>
        [Column(FieldName = "MreType", DataKey = false, Match = "", IsInsert = true)]
        public int MreType
        {
            get { return _mretype; }
            set { _mretype = value; }
        }

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

        private int _createworkid;
        /// <summary>
        /// 创建医院ID
        /// </summary>
        [Column(FieldName = "CreateWorkID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateWorkID
        {
            get { return _createworkid; }
            set { _createworkid = value; }
        }

        private int _auditstatus;
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(FieldName = "AuditStatus", DataKey = false, Match = "", IsInsert = true)]
        public int AuditStatus
        {
            get { return _auditstatus; }
            set { _auditstatus = value; }
        }

        private int _auditor;
        /// <summary>
        /// 审核人
        /// </summary>
        [Column(FieldName = "Auditor", DataKey = false, Match = "", IsInsert = true)]
        public int Auditor
        {
            get { return _auditor; }
            set { _auditor = value; }
        }

        private DateTime _audittime;
        /// <summary>
        /// 审核时间
        /// </summary>
        [Column(FieldName = "AuditTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AuditTime
        {
            get { return _audittime; }
            set { _audittime = value; }
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

        public string StrAuditStatus
        {
            get
            {
                return AuditStatus
                    .ToEnum(AuditType.UnAudit)
                    .GetEnumDisplay();
            }
        }

        public string StrMreType
        {
            get
            {
                return MreType
                    .ToEnum(MreTypes.Default)
                    .GetEnumDisplay();
            }
        }
    }
}
