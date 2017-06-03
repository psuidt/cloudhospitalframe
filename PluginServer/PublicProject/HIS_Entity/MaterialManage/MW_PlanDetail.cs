using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_PlanDetail", EntityType = EntityType.Table, IsGB = false)]
    public class MW_PlanDetail:AbstractEntity
    {
        private int  _plandetailid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PlanDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int PlanDetailID
        {
            get { return  _plandetailid; }
            set {  _plandetailid = value; }
        }

        private int  _planheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PlanHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int PlanHeadID
        {
            get { return  _planheadid; }
            set {  _planheadid = value; }
        }

        private int  _materialid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MaterialID", DataKey = false, Match = "", IsInsert = true)]
        public int MaterialID
        {
            get { return  _materialid; }
            set {  _materialid = value; }
        }

        private Decimal  _retailprice;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RetailPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailPrice
        {
            get { return  _retailprice; }
            set {  _retailprice = value; }
        }

        private Decimal  _stockprice;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StockPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockPrice
        {
            get { return  _stockprice; }
            set {  _stockprice = value; }
        }

        private Decimal  _stockfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StockFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal StockFee
        {
            get { return  _stockfee; }
            set {  _stockfee = value; }
        }

        private Decimal  _retailfee;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RetailFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal RetailFee
        {
            get { return  _retailfee; }
            set {  _retailfee = value; }
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

    }
}
