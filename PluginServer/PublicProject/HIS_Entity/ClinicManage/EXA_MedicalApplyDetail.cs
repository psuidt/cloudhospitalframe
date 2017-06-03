using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "EXA_MedicalApplyDetail", EntityType = EntityType.Table, IsGB = false)]
    public class EXA_MedicalApplyDetail:AbstractEntity
    {
        private int  _applydetailid;
        /// <summary>
        /// 申请明细ID
        /// </summary>
        [Column(FieldName = "ApplyDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int ApplyDetailID
        {
            get { return  _applydetailid; }
            set {  _applydetailid = value; }
        }

        private long  _applyheadid;
        /// <summary>
        /// 申请头表ID
        /// </summary>
        [Column(FieldName = "ApplyHeadID", DataKey = false, Match = "", IsInsert = true)]
        public long ApplyHeadID
        {
            get { return  _applyheadid; }
            set {  _applyheadid = value; }
        }

        private long  _presdetailid;
        /// <summary>
        /// 处方明细ID
        /// </summary>
        [Column(FieldName = "PresDetailID", DataKey = false, Match = "", IsInsert = true)]
        public long PresDetailID
        {
            get { return  _presdetailid; }
            set {  _presdetailid = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 组合项目名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private Decimal  _price;
        /// <summary>
        /// 价格
        /// </summary>
        [Column(FieldName = "Price", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Price
        {
            get { return  _price; }
            set {  _price = value; }
        }

        private int  _amount;
        /// <summary>
        /// 数量
        /// </summary>
        [Column(FieldName = "Amount", DataKey = false, Match = "", IsInsert = true)]
        public int Amount
        {
            get { return  _amount; }
            set {  _amount = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 总金额
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
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

        private int _applystatus;
        /// <summary>
        /// 申请状态：0申请1收费2确费
        /// </summary>
        [Column(FieldName = "ApplyStatus", DataKey = false, Match = "", IsInsert = true)]
        public int ApplyStatus
        {
            get { return _applystatus; }
            set { _applystatus = value; }
        }

        private int _isreturns;
        /// <summary>
        /// 退费状态：0未退费1已退费
        /// </summary>
        [Column(FieldName = "IsReturns", DataKey = false, Match = "", IsInsert = true)]
        public int IsReturns
        {
            get { return _isreturns; }
            set { _isreturns = value; }
        }

        private int _systemtype;
        /// <summary>
        /// 系统类型（0门诊医生站，1住院医生站）
        /// </summary>
        [Column(FieldName = "SystemType", DataKey = false, Match = "", IsInsert = true)]
        public int SystemType
        {
            get { return _systemtype; }
            set { _systemtype = value; }
        }
    }
}
