using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_ApplyDetail", EntityType = EntityType.Table, IsGB = false)]
    public class DS_ApplyDetail:AbstractEntity
    {
        private int  _applydetailid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ApplyDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int ApplyDetailID
        {
            get { return  _applydetailid; }
            set {  _applydetailid = value; }
        }

        private int  _applyheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ApplyHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyHeadID
        {
            get { return  _applyheadid; }
            set {  _applyheadid = value; }
        }

        private int  _storageid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StorageID", DataKey = false, Match = "", IsInsert = true)]
        public int StorageID
        {
            get { return  _storageid; }
            set {  _storageid = value; }
        }

        private int  _ctypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "CTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int CTypeID
        {
            get { return  _ctypeid; }
            set {  _ctypeid = value; }
        }

        private int  _drugid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public int DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
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

        private Decimal  _factamount;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FactAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal FactAmount
        {
            get { return  _factamount; }
            set {  _factamount = value; }
        }

        private string  _batchno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BatchNO", DataKey = false, Match = "", IsInsert = true)]
        public string BatchNO
        {
            get { return  _batchno; }
            set {  _batchno = value; }
        }

        private DateTime  _validdate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ValidDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ValidDate
        {
            get { return  _validdate; }
            set {  _validdate = value; }
        }

    }
}
