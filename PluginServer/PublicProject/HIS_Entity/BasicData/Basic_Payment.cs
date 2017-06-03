using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_Payment", EntityType = EntityType.Table, IsGB = true)]
    public class Basic_Payment:AbstractEntity
    {
        private int  _paymentid;
        /// <summary>
        /// 支付ID
        /// </summary>
        [Column(FieldName = "PaymentID", DataKey = true, Match = "", IsInsert = false)]
        public int PaymentID
        {
            get { return  _paymentid; }
            set {  _paymentid = value; }
        }

        private string  _paycode;
        /// <summary>
        /// 支付代码
        /// </summary>
        [Column(FieldName = "PayCode", DataKey = false, Match = "", IsInsert = true)]
        public string PayCode
        {
            get { return  _paycode; }
            set {  _paycode = value; }
        }

        private string  _payname;
        /// <summary>
        /// 支付名称
        /// </summary>
        [Column(FieldName = "PayName", DataKey = false, Match = "", IsInsert = true)]
        public string PayName
        {
            get { return  _payname; }
            set {  _payname = value; }
        }

        private int  _inputfrom;
        /// <summary>
        /// 金额来源  0--手工输入  1-接口获取
        /// </summary>
        [Column(FieldName = "InputFrom", DataKey = false, Match = "", IsInsert = true)]
        public int InputFrom
        {
            get { return  _inputfrom; }
            set {  _inputfrom = value; }
        }

        private string  _payrule;
        /// <summary>
        /// 支付规则
        /// </summary>
        [Column(FieldName = "PayRule", DataKey = false, Match = "", IsInsert = true)]
        public string PayRule
        {
            get { return  _payrule; }
            set {  _payrule = value; }
        }

        private int  _fontcolor;
        /// <summary>
        /// 显示颜色
        /// </summary>
        [Column(FieldName = "FontColor", DataKey = false, Match = "", IsInsert = true)]
        public int FontColor
        {
            get { return  _fontcolor; }
            set {  _fontcolor = value; }
        }

        private int  _sortorder;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return  _sortorder; }
            set {  _sortorder = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

        private string  _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

    }
}
