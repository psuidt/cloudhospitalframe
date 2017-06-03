using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_HospMakerDic", EntityType = EntityType.Table, IsGB = false)]
    public class MW_HospMakerDic:AbstractEntity
    {
        private int  _materialid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MaterialID", DataKey = true, Match = "", IsInsert = false)]
        public int MaterialID
        {
            get { return  _materialid; }
            set {  _materialid = value; }
        }

        private int  _centermatid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenterMatID", DataKey = false, Match = "", IsInsert = true)]
        public int CenterMatID
        {
            get { return  _centermatid; }
            set {  _centermatid = value; }
        }

        private string  _matcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MatCode", DataKey = false, Match = "", IsInsert = true)]
        public string MatCode
        {
            get { return  _matcode; }
            set {  _matcode = value; }
        }

        private string  _matname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MatName", DataKey = false, Match = "", IsInsert = true)]
        public string MatName
        {
            get { return  _matname; }
            set {  _matname = value; }
        }

        private string  _aliasname;
        /// <summary>
        /// 材料别名
        /// </summary>
        [Column(FieldName = "AliasName", DataKey = false, Match = "", IsInsert = true)]
        public string AliasName
        {
            get { return  _aliasname; }
            set {  _aliasname = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private int  _agricultural;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Agricultural", DataKey = false, Match = "", IsInsert = true)]
        public int Agricultural
        {
            get { return  _agricultural; }
            set {  _agricultural = value; }
        }

        private int  _medicareid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MedicareID", DataKey = false, Match = "", IsInsert = true)]
        public int MedicareID
        {
            get { return  _medicareid; }
            set {  _medicareid = value; }
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

        private Decimal  _stockprice;
        /// <summary>
        /// 进价
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
        }

        private Decimal  _retailprice;
        /// <summary>
        /// 销售价
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return  _retailprice; }
            set {  _retailprice = value; }
        }

        private int  _statid;
        /// <summary>
        /// 统计项目ID
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
        }

        private int  _productid;
        /// <summary>
        /// 厂家ID
        /// </summary>
        [Column(FieldName = "ProductID", DataKey = false, Match = "", IsInsert = true)]
        public int ProductID
        {
            get { return  _productid; }
            set {  _productid = value; }
        }

        private int  _isble;
        /// <summary>
        /// 处方可开  0- 否 1-是
        /// </summary>
        [Column(FieldName = "IsBle", DataKey = false, Match = "", IsInsert = true)]
        public int IsBle
        {
            get { return  _isble; }
            set {  _isble = value; }
        }

        private int  _isuse;
        /// <summary>
        /// 药房可发  0- 否 1-是
        /// </summary>
        [Column(FieldName = "IsUse", DataKey = false, Match = "", IsInsert = true)]
        public int IsUse
        {
            get { return  _isuse; }
            set {  _isuse = value; }
        }

        private int  _modempid;
        /// <summary>
        /// 修改人
        /// </summary>
        [Column(FieldName = "ModEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ModEmpID
        {
            get { return  _modempid; }
            set {  _modempid = value; }
        }

        private DateTime  _moddate;
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(FieldName = "ModDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ModDate
        {
            get { return  _moddate; }
            set {  _moddate = value; }
        }

        private int  _isstop;
        /// <summary>
        /// 是否停用
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return  _isstop; }
            set {  _isstop = value; }
        }

    }
}
