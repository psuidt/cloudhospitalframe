using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "EXA_MedicalConfirDetail", EntityType = EntityType.Table, IsGB = false)]
    public class EXA_MedicalConfirDetail:AbstractEntity
    {
        private int  _confirdetailid;
        /// <summary>
        /// 确费明细自增长ID
        /// </summary>
        [Column(FieldName = "ConfirDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int ConfirDetailID
        {
            get { return  _confirdetailid; }
            set {  _confirdetailid = value; }
        }

        private int  _confirid;
        /// <summary>
        /// 确费ID
        /// </summary>
        [Column(FieldName = "ConfirID", DataKey = false, Match = "", IsInsert = true)]
        public int ConfirID
        {
            get { return  _confirid; }
            set {  _confirid = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private int _examitemid;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        [Column(FieldName = "ExamItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ExamItemID
        {
            get { return _examitemid; }
            set { _examitemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private Decimal  _itemprice;
        /// <summary>
        /// 项目价格
        /// </summary>
        [Column(FieldName = "ItemPrice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ItemPrice
        {
            get { return  _itemprice; }
            set {  _itemprice = value; }
        }

        private int  _amount;
        /// <summary>
        /// 项目数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public int Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private string  _unit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return  _unit; }
            set {  _unit = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 金额
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
        }

        private int  _feedetailid;
        /// <summary>
        /// 门诊费用明细表ID和住院费用明细表ID
        /// </summary>
        [Column(FieldName = "FeeDetailID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeDetailID
        {
            get { return  _feedetailid; }
            set {  _feedetailid = value; }
        }

        private int _markflag;
        /// <summary>
        /// 门诊确费=0,住院确费=1
        /// </summary>
        [Column(FieldName = "MarkFlag", DataKey = false, Match = "", IsInsert = true)]
        public int MarkFlag
        {
            get { return _markflag; }
            set { _markflag = value; }
        }
    }
}
