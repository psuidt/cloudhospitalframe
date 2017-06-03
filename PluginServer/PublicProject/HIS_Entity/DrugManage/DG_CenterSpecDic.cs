using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_CenterSpecDic", EntityType = EntityType.Table, IsGB = true)]
    public class DG_CenterSpecDic : AbstractEntity
    {
        private int _centedrugid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenteDrugID", DataKey = true, Match = "", IsInsert = false)]
        public int CenteDrugID
        {
            get { return _centedrugid; }
            set { _centedrugid = value; }
        }

        private string _centerdrugcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenterDrugCode", DataKey = false, Match = "", IsInsert = true)]
        public string CenterDrugCode
        {
            get { return _centerdrugcode; }
            set { _centerdrugcode = value; }
        }

        private string _chemname;
        /// <summary>
        /// 通用名
        /// </summary>
        [Column(FieldName = "ChemName", DataKey = false, Match = "", IsInsert = true)]
        public string ChemName
        {
            get { return _chemname; }
            set { _chemname = value; }
        }

        private string _latinname;
        /// <summary>
        /// 英文名
        /// </summary>
        [Column(FieldName = "LatinName", DataKey = false, Match = "", IsInsert = true)]
        public string LatinName
        {
            get { return _latinname; }
            set { _latinname = value; }
        }

        private string _pycode;
        /// <summary>
        /// 通用名拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return _pycode; }
            set { _pycode = value; }
        }

        private string _wbcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return _wbcode; }
            set { _wbcode = value; }
        }

        private string _cuscode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CusCode", DataKey = false, Match = "", IsInsert = true)]
        public string CusCode
        {
            get { return _cuscode; }
            set { _cuscode = value; }
        }

        private string _spec;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return _spec; }
            set { _spec = value; }
        }

        private int _packunitid;
        /// <summary>
        /// 包装单位ID
        /// </summary>
        [Column(FieldName = "PackUnitID", DataKey = false, Match = "", IsInsert = true)]
        public int PackUnitID
        {
            get { return _packunitid; }
            set { _packunitid = value; }
        }

        private string _packunit;
        /// <summary>
        /// 包装单位
        /// </summary>
        [Column(FieldName = "PackUnit", DataKey = false, Match = "", IsInsert = true)]
        public string PackUnit
        {
            get { return _packunit; }
            set { _packunit = value; }
        }

        private int _miniunitid;
        /// <summary>
        /// 最小单位
        /// </summary>
        [Column(FieldName = "MiniUnitID", DataKey = false, Match = "", IsInsert = true)]
        public int MiniUnitID
        {
            get { return _miniunitid; }
            set { _miniunitid = value; }
        }

        private string _miniunit;
        /// <summary>
        /// 最小单位
        /// </summary>
        [Column(FieldName = "MiniUnit", DataKey = false, Match = "", IsInsert = true)]
        public string MiniUnit
        {
            get { return _miniunit; }
            set { _miniunit = value; }
        }

        private int _doseunitid;
        /// <summary>
        /// 剂量单位
        /// </summary>
        [Column(FieldName = "DoseUnitID", DataKey = false, Match = "", IsInsert = true)]
        public int DoseUnitID
        {
            get { return _doseunitid; }
            set { _doseunitid = value; }
        }

        private string _doseunit;
        /// <summary>
        /// 剂量单位
        /// </summary>
        [Column(FieldName = "DoseUnit", DataKey = false, Match = "", IsInsert = true)]
        public string DoseUnit
        {
            get { return _doseunit; }
            set { _doseunit = value; }
        }

        private Decimal _packamount;
        /// <summary>
        /// 换算系数，多少支一盒
        /// </summary>
        [Column(FieldName = "PackAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal PackAmount
        {
            get { return _packamount; }
            set { _packamount = value; }
        }

        private Decimal _doseamount;
        /// <summary>
        /// 剂量系数，多少mg一支
        /// </summary>
        [Column(FieldName = "DoseAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DoseAmount
        {
            get { return _doseamount; }
            set { _doseamount = value; }
        }

        private Decimal _stockprice;
        /// <summary>
        /// 参考进价
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return _stockprice; }
            set { _stockprice = value; }
        }

        private Decimal _retailprice;
        /// <summary>
        /// 参考售价
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return _retailprice; }
            set { _retailprice = value; }
        }

        private int _ctypeid;
        /// <summary>
        /// 药品类型
        /// </summary>
        [Column(FieldName = "CTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int CTypeID
        {
            get { return _ctypeid; }
            set { _ctypeid = value; }
        }

        private int _statid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        private int _pharmid;
        /// <summary>
        /// 药理分类ID
        /// </summary>
        [Column(FieldName = "PharmID", DataKey = false, Match = "", IsInsert = true)]
        public int PharmID
        {
            get { return _pharmid; }
            set { _pharmid = value; }
        }

        private int _dosageid;
        /// <summary>
        /// 剂型
        /// </summary>
        [Column(FieldName = "DosageID", DataKey = false, Match = "", IsInsert = true)]
        public int DosageID
        {
            get { return _dosageid; }
            set { _dosageid = value; }
        }

        private int _isgmp;
        /// <summary>
        /// 是否GMP认证 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsGMP", DataKey = false, Match = "", IsInsert = true)]
        public int IsGMP
        {
            get { return _isgmp; }
            set { _isgmp = value; }
        }

        private int _isaze;
        /// <summary>
        /// 是否麻醉药 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsAze", DataKey = false, Match = "", IsInsert = true)]
        public int IsAze
        {
            get { return _isaze; }
            set { _isaze = value; }
        }

        private int _isposion;
        /// <summary>
        /// 是否毒性药 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsPosion", DataKey = false, Match = "", IsInsert = true)]
        public int IsPosion
        {
            get { return _isposion; }
            set { _isposion = value; }
        }

        private int _isbasic;
        /// <summary>
        /// 是否基本用药 0-否 1- 省基目录  2-国基目录  3国、省基目录
        /// </summary>
        [Column(FieldName = "IsBasic", DataKey = false, Match = "", IsInsert = true)]
        public int IsBasic
        {
            get { return _isbasic; }
            set { _isbasic = value; }
        }

        private int _iscostly;
        /// <summary>
        /// 是否贵重药 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsCostly", DataKey = false, Match = "", IsInsert = true)]
        public int IsCostly
        {
            get { return _iscostly; }
            set { _iscostly = value; }
        }

        private int _islunacy;
        /// <summary>
        /// 是否精神药 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsLunacy", DataKey = false, Match = "", IsInsert = true)]
        public int IsLunacy
        {
            get { return _islunacy; }
            set { _islunacy = value; }
        }

        private int _isbid;
        /// <summary>
        /// 是否中标 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsBid", DataKey = false, Match = "", IsInsert = true)]
        public int IsBid
        {
            get { return _isbid; }
            set { _isbid = value; }
        }

        private int _isskin;
        /// <summary>
        /// 是否皮试药 0-否 1-是
        /// </summary>
        [Column(FieldName = "IsSkin", DataKey = false, Match = "", IsInsert = true)]
        public int IsSkin
        {
            get { return _isskin; }
            set { _isskin = value; }
        }

        private int _antid;
        /// <summary>
        /// 是否抗生素 0-否 1-是可分级
        /// </summary>
        [Column(FieldName = "AntID", DataKey = false, Match = "", IsInsert = true)]
        public int AntID
        {
            get { return _antid; }
            set { _antid = value; }
        }

        private int _modempid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ModEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ModEmpID
        {
            get { return _modempid; }
            set { _modempid = value; }
        }

        private DateTime _moddate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ModDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ModDate
        {
            get { return _moddate; }
            set { _moddate = value; }
        }

        private int _createworkid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CreateWorkID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateWorkID
        {
            get { return _createworkid; }
            set { _createworkid = value; }
        }

        private int _auditstatus;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditStatus", DataKey = false, Match = "", IsInsert = true)]
        public int AuditStatus
        {
            get { return _auditstatus; }
            set { _auditstatus = value; }
        }

        private int _auditor;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Auditor", DataKey = false, Match = "", IsInsert = true)]
        public int Auditor
        {
            get { return _auditor; }
            set { _auditor = value; }
        }

        private DateTime _audittime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AuditTime
        {
            get { return _audittime; }
            set { _audittime = value; }
        }

        private int _isstop;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return _isstop; }
            set { _isstop = value; }
        }

        private int _typeID;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "TypeID", DataKey = false, Match = "", IsInsert = true)]
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }


        [Column(FieldName = "IsRecipe", DataKey = false, Match = "", IsInsert = true)]
        public int IsRecipe { set; get; }

        [Column(FieldName = "IsBigTransfu", DataKey = false, Match = "", IsInsert = true)]
        public int IsBigTransfu { set; get; }

        /// <summary>
        /// 0:非精神 1:精1  2：精2
        /// </summary>
        [Column(FieldName = "LunacyGrade", DataKey = false, Match = "", IsInsert = true)]
        public int LunacyGrade { set; get; }

    }
}
