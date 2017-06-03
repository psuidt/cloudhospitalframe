using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_HospMakerDic", EntityType = EntityType.Table, IsGB = false)]
    public class DG_HospMakerDic:AbstractEntity
    {
        private int  _drugid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = true, Match = "", IsInsert = false)]
        public int DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
        }

        private int  _centedrugid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CenteDrugID", DataKey = false, Match = "", IsInsert = true)]
        public int CenteDrugID
        {
            get { return  _centedrugid; }
            set {  _centedrugid = value; }
        }

        private string  _tradename;
        /// <summary>
        /// 商品名
        /// </summary>
        [Column(FieldName = "TradeName", DataKey = false, Match = "", IsInsert = true)]
        public string TradeName
        {
            get { return  _tradename; }
            set {  _tradename = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 商品名拼音码
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

        private string  _approvalno;
        /// <summary>
        /// 批准文号
        /// </summary>
        [Column(FieldName = "ApprovalNO", DataKey = false, Match = "", IsInsert = true)]
        public string ApprovalNO
        {
            get { return  _approvalno; }
            set {  _approvalno = value; }
        }

        private int  _defusgid;
        /// <summary>
        /// 默认用法
        /// </summary>
        [Column(FieldName = "DefUsgID", DataKey = false, Match = "", IsInsert = true)]
        public int DefUsgID
        {
            get { return  _defusgid; }
            set {  _defusgid = value; }
        }

        private int  _deffcyid;
        /// <summary>
        /// 默认频次
        /// </summary>
        [Column(FieldName = "DefFcyID", DataKey = false, Match = "", IsInsert = true)]
        public int DefFcyID
        {
            get { return  _deffcyid; }
            set {  _deffcyid = value; }
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
        /// 参考销售价
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

        private int  _roundingmode;
        /// <summary>
        /// 取整方式 0-总量取整、1-单次取整
        /// </summary>
        [Column(FieldName = "RoundingMode", DataKey = false, Match = "", IsInsert = true)]
        public int RoundingMode
        {
            get { return  _roundingmode; }
            set {  _roundingmode = value; }
        }

        private int  _opfree;
        /// <summary>
        /// 门诊免发
        /// </summary>
        [Column(FieldName = "OPFree", DataKey = false, Match = "", IsInsert = true)]
        public int OPFree
        {
            get { return  _opfree; }
            set {  _opfree = value; }
        }

        private int  _ipfree;
        /// <summary>
        /// 住院免发
        /// </summary>
        [Column(FieldName = "IPFree", DataKey = false, Match = "", IsInsert = true)]
        public int IPFree
        {
            get { return  _ipfree; }
            set {  _ipfree = value; }
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

        private string  _drugdirection;
        /// <summary>
        /// 药品说明书
        /// </summary>
        [Column(FieldName = "DrugDirection", DataKey = false, Match = "", IsInsert = true)]
        public string DrugDirection
        {
            get { return  _drugdirection; }
            set {  _drugdirection = value; }
        }


        /// <summary>
        /// 药品有效期限
        /// </summary>
        [Column(FieldName = "Duration", DataKey = false, Match = "", IsInsert = true)]
        public int Duration
        {
            set; get;
        }


        private int  _modstaff;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ModStaff", DataKey = false, Match = "", IsInsert = true)]
        public int ModStaff
        {
            get { return  _modstaff; }
            set {  _modstaff = value; }
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

        /// <summary>
        /// 国家准字号
        /// </summary>
        private string _nationalcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "NationalCode", DataKey = false, Match = "", IsInsert = true)]
        public string NationalCode
        {
            get { return _nationalcode; }
            set { _nationalcode = value; }
        }

        private int _maker;
        /// <summary>
        /// 进口国产 0-进口、1-国产
        /// </summary>
        [Column(FieldName = "Maker", DataKey = false, Match = "", IsInsert = true)]
        public int Maker
        {
            get { return _maker; }
            set { _maker = value; }
        }

    }
}
