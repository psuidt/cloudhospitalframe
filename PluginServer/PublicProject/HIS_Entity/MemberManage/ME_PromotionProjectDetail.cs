using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_PromotionProjectDetail", EntityType = EntityType.Table, IsGB = false)]
    public class ME_PromotionProjectDetail:AbstractEntity
    {
        private int  _promsunid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PromSunID", DataKey = true, Match = "", IsInsert = false)]
        public int PromSunID
        {
            get { return  _promsunid; }
            set {  _promsunid = value; }
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

        private int  _costtype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CostType", DataKey = false, Match = "", IsInsert = true)]
        public int CostType
        {
            get { return  _costtype; }
            set {  _costtype = value; }
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

        private Decimal  _discountnumber;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DiscountNumber", DataKey = false, Match = "", IsInsert = true)]
        public Decimal DiscountNumber
        {
            get { return  _discountnumber; }
            set {  _discountnumber = value; }
        }

        private int  _usefalg;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UseFlag", DataKey = false, Match = "", IsInsert = true)]
        public int UseFlag
        {
            get { return  _usefalg; }
            set {  _usefalg = value; }
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

    }
}
