using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_CenterSpecDic", EntityType = EntityType.Table, IsGB = false)]
    public class MW_CenterSpecDic:AbstractEntity
    {
        private int  _centermatid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenterMatID", DataKey = true, Match = "", IsInsert = false)]
        public int CenterMatID
        {
            get { return  _centermatid; }
            set {  _centermatid = value; }
        }

        private string  _centermatcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenterMatCode", DataKey = false, Match = "", IsInsert = true)]
        public string CenterMatCode
        {
            get { return  _centermatcode; }
            set {  _centermatcode = value; }
        }

        private string  _centermatname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenterMatName", DataKey = false, Match = "", IsInsert = true)]
        public string CenterMatName
        {
            get { return  _centermatname; }
            set {  _centermatname = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PyCode", DataKey = false, Match = "", IsInsert = true)]
        public string PyCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WbCode", DataKey = false, Match = "", IsInsert = true)]
        public string WbCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private string  _cuscode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CusCode", DataKey = false, Match = "", IsInsert = true)]
        public string CusCode
        {
            get { return  _cuscode; }
            set {  _cuscode = value; }
        }

        private string  _spec;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Spec", DataKey = false, Match = "", IsInsert = true)]
        public string Spec
        {
            get { return  _spec; }
            set {  _spec = value; }
        }

        private int  _unitid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UnitID", DataKey = false, Match = "", IsInsert = true)]
        public int UnitID
        {
            get { return  _unitid; }
            set {  _unitid = value; }
        }

        private string  _unitname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UnitName", DataKey = false, Match = "", IsInsert = true)]
        public string UnitName
        {
            get { return  _unitname; }
            set {  _unitname = value; }
        }

        private Decimal  _stockprice;
        /// <summary>
        /// 参考进价
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
        }

        private Decimal  _retailprice;
        /// <summary>
        /// 参考售价
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return  _retailprice; }
            set {  _retailprice = value; }
        }

        private int  _typeid;
        /// <summary>
        /// 物资分类
        /// </summary>
        [Column(FieldName = "TypeID", DataKey = false, Match = "", IsInsert = true)]
        public int TypeID
        {
            get { return  _typeid; }
            set {  _typeid = value; }
        }

        private int  _statid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
        }

        private int  _modempid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ModEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ModEmpID
        {
            get { return  _modempid; }
            set {  _modempid = value; }
        }

        private DateTime  _moddate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ModDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ModDate
        {
            get { return  _moddate; }
            set {  _moddate = value; }
        }

        private int  _createworkid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CreateWorkID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateWorkID
        {
            get { return  _createworkid; }
            set {  _createworkid = value; }
        }

        private int  _auditstatus;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditStatus", DataKey = false, Match = "", IsInsert = true)]
        public int AuditStatus
        {
            get { return  _auditstatus; }
            set {  _auditstatus = value; }
        }

        private int  _auditor;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Auditor", DataKey = false, Match = "", IsInsert = true)]
        public int Auditor
        {
            get { return  _auditor; }
            set {  _auditor = value; }
        }

        private DateTime  _audittime;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AuditTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AuditTime
        {
            get { return  _audittime; }
            set {  _audittime = value; }
        }

        private int  _isstop;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return  _isstop; }
            set {  _isstop = value; }
        }

    }
}
