using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_MIPayRecordDetail", EntityType = EntityType.Table, IsGB = false)]
    public class MI_MIPayRecordDetail:AbstractEntity
    {
        private int  _payrecordid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PayRecordId", DataKey = false, Match = "", IsInsert = true)]
        public int PayRecordId
        {
            get { return  _payrecordid; }
            set {  _payrecordid = value; }
        }

        private string  _tradeno;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "tradeno", DataKey = false, Match = "", IsInsert = true)]
        public string tradeno
        {
            get { return  _tradeno; }
            set {  _tradeno = value; }
        }

        private string  _itemno;
        /// <summary>
        /// 项目序号
        /// </summary>
        [Column(FieldName = "itemno", DataKey = false, Match = "", IsInsert = true)]
        public string itemno
        {
            get { return  _itemno; }
            set {  _itemno = value; }
        }

        private string  _recipeno;
        /// <summary>
        /// 处方序号
        /// </summary>
        [Column(FieldName = "recipeno", DataKey = false, Match = "", IsInsert = true)]
        public string recipeno
        {
            get { return  _recipeno; }
            set {  _recipeno = value; }
        }

        private string  _hiscode;
        /// <summary>
        /// HIS项目代码
        /// </summary>
        [Column(FieldName = "hiscode", DataKey = false, Match = "", IsInsert = true)]
        public string hiscode
        {
            get { return  _hiscode; }
            set {  _hiscode = value; }
        }

        private string  _itemcode;
        /// <summary>
        /// 医保项目代码
        /// </summary>
        [Column(FieldName = "itemcode", DataKey = false, Match = "", IsInsert = true)]
        public string itemcode
        {
            get { return  _itemcode; }
            set {  _itemcode = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 医保项目名称
        /// </summary>
        [Column(FieldName = "itemname", DataKey = false, Match = "", IsInsert = true)]
        public string itemname
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private int  _itemtype;
        /// <summary>
        /// 项目类别
        /// </summary>
        [Column(FieldName = "itemtype", DataKey = false, Match = "", IsInsert = true)]
        public int itemtype
        {
            get { return  _itemtype; }
            set {  _itemtype = value; }
        }

        private Decimal  _unitprice;
        /// <summary>
        /// 单价
        /// </summary>
        [Column(FieldName = "unitprice", DataKey = false, Match = "", IsInsert = true)]
        public Decimal unitprice
        {
            get { return  _unitprice; }
            set {  _unitprice = value; }
        }

        private Decimal  _count;
        /// <summary>
        /// 数量
        /// </summary>
        [Column(FieldName = "count", DataKey = false, Match = "", IsInsert = true)]
        public Decimal count
        {
            get { return  _count; }
            set {  _count = value; }
        }

        private Decimal  _fee;
        /// <summary>
        /// 项目总金额
        /// </summary>
        [Column(FieldName = "fee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal fee
        {
            get { return  _fee; }
            set {  _fee = value; }
        }

        private Decimal  _feein;
        /// <summary>
        /// 医保内总金额-如：医保内金额=0则为全自付   医保外金额=0则为无自付   其他为有自付
        /// </summary>
        [Column(FieldName = "feein", DataKey = false, Match = "", IsInsert = true)]
        public Decimal feein
        {
            get { return  _feein; }
            set {  _feein = value; }
        }

        private Decimal  _feeout;
        /// <summary>
        /// 医保外总金额
        /// </summary>
        [Column(FieldName = "feeout", DataKey = false, Match = "", IsInsert = true)]
        public Decimal feeout
        {
            get { return  _feeout; }
            set {  _feeout = value; }
        }

        private Decimal  _selfpay2;
        /// <summary>
        /// 个人自付2
        /// </summary>
        [Column(FieldName = "selfpay2", DataKey = false, Match = "", IsInsert = true)]
        public Decimal selfpay2
        {
            get { return  _selfpay2; }
            set {  _selfpay2 = value; }
        }

        private int  _state;
        /// <summary>
        /// 分解状态：0正常，1不符合特殊标识，2医保目录内不存在，3对照错误，4不符合特殊定额管理要求，5未对照，6医保外处方
        /// </summary>
        [Column(FieldName = "state", DataKey = false, Match = "", IsInsert = true)]
        public int state
        {
            get { return  _state; }
            set {  _state = value; }
        }

        private string  _feetype;
        /// <summary>
        /// 收费类别
        /// </summary>
        [Column(FieldName = "feetype", DataKey = false, Match = "", IsInsert = true)]
        public string feetype
        {
            get { return  _feetype; }
            set {  _feetype = value; }
        }

        private Decimal  _preferentialfee;
        /// <summary>
        /// 社区优惠金额
        /// </summary>
        [Column(FieldName = "preferentialfee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal preferentialfee
        {
            get { return  _preferentialfee; }
            set {  _preferentialfee = value; }
        }

        private Decimal  _preferentialscale;
        /// <summary>
        /// 社区优惠比例
        /// </summary>
        [Column(FieldName = "preferentialscale", DataKey = false, Match = "", IsInsert = true)]
        public Decimal preferentialscale
        {
            get { return  _preferentialscale; }
            set {  _preferentialscale = value; }
        }

        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

    }
}
