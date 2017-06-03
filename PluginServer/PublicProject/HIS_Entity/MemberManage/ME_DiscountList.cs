using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_DiscountList", EntityType = EntityType.Table, IsGB = false)]
    public class ME_DiscountList:AbstractEntity
    {
        private int  _discountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DiscountID", DataKey = true, Match = "", IsInsert = false)]
        public int DiscountID
        {
            get { return  _discountid; }
            set {  _discountid = value; }
        }

        private int  _accountid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private string  _settlementno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "SettlementNO", DataKey = false, Match = "", IsInsert = true)]
        public string SettlementNO
        {
            get { return  _settlementno; }
            set {  _settlementno = value; }
        }

        private int  _promid;
        /// <summary>
        /// 促销方案ID
        /// </summary>
        [Column(FieldName = "PromID", DataKey = false, Match = "", IsInsert = true)]
        public int PromID
        {
            get { return  _promid; }
            set {  _promid = value; }
        }

        private string  _promname;
        /// <summary>
        /// 促销方案名称
        /// </summary>
        [Column(FieldName = "PromName", DataKey = false, Match = "", IsInsert = true)]
        public string PromName
        {
            get { return  _promname; }
            set {  _promname = value; }
        }

        private int  _promsunid;
        /// <summary>
        /// 促销方案明细表ID
        /// </summary>
        [Column(FieldName = "PromSunID", DataKey = false, Match = "", IsInsert = true)]
        public int PromSunID
        {
            get { return  _promsunid; }
            set {  _promsunid = value; }
        }

        private int  _costtypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CostTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int CostTypeID
        {
            get { return  _costtypeid; }
            set {  _costtypeid = value; }
        }

        private int  _cardtypeid;
        /// <summary>
        /// 卡片类型ID
        /// </summary>
        [Column(FieldName = "CardTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int CardTypeID
        {
            get { return  _cardtypeid; }
            set {  _cardtypeid = value; }
        }

        private int  _patienttype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatientType", DataKey = false, Match = "", IsInsert = true)]
        public int PatientType
        {
            get { return  _patienttype; }
            set {  _patienttype = value; }
        }

        private int  _promtypeid;
        /// <summary>
        /// 优惠类型
        /// </summary>
        [Column(FieldName = "PromTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PromTypeID
        {
            get { return  _promtypeid; }
            set {  _promtypeid = value; }
        }

        private int  _promclass;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PromClass", DataKey = false, Match = "", IsInsert = true)]
        public int PromClass
        {
            get { return  _promclass; }
            set {  _promclass = value; }
        }

        private int  _prompro;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PromPro", DataKey = false, Match = "", IsInsert = true)]
        public int PromPro
        {
            get { return  _prompro; }
            set {  _prompro = value; }
        }

        private int  _prombase;
        /// <summary>
        /// 优惠类型
        /// </summary>
        [Column(FieldName = "PromBase", DataKey = false, Match = "", IsInsert = true)]
        public int PromBase
        {
            get { return  _prombase; }
            set {  _prombase = value; }
        }

        private int  _prom;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Prom", DataKey = false, Match = "", IsInsert = true)]
        public int Prom
        {
            get { return  _prom; }
            set {  _prom = value; }
        }

        private int  _discountnumber;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DiscountNumber", DataKey = false, Match = "", IsInsert = true)]
        public int DiscountNumber
        {
            get { return  _discountnumber; }
            set {  _discountnumber = value; }
        }

        private Decimal  _amount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private Decimal  _discounttotal;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DiscountTotal", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DiscountTotal
        {
            get { return  _discounttotal; }
            set {  _discounttotal = value; }
        }

        private DateTime  _operatedate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperateDate
        {
            get { return  _operatedate; }
            set {  _operatedate = value; }
        }

        private int  _operateid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateID", DataKey = false, Match = "", IsInsert = true)]
        public int OperateID
        {
            get { return  _operateid; }
            set {  _operateid = value; }
        }

        private int  _accid;
        /// <summary>
        /// 收费结算ID
        /// </summary>
        [Column(FieldName = "AccID", DataKey = false, Match = "", IsInsert = true)]
        public int AccID
        {
            get { return  _accid; }
            set {  _accid = value; }
        }

        private int  _isvalid;
        /// <summary>
        /// 是否生效
        /// </summary>
        [Column(FieldName = "IsValid", DataKey = false, Match = "", IsInsert = true)]
        public int IsValid
        {
            get { return  _isvalid; }
            set {  _isvalid = value; }
        }

    }
}
