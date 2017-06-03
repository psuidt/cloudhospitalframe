using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_FeeRefundHead", EntityType = EntityType.Table, IsGB = false)]
    public class OP_FeeRefundHead:AbstractEntity
    {
        private int  _reheadid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ReHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int ReHeadID
        {
            get { return  _reheadid; }
            set {  _reheadid = value; }
        }

        private int  _refunddocid;
        /// <summary>
        /// 退费医生ID
   
        /// </summary>
        [Column(FieldName = "RefundDocID", DataKey = false, Match = "", IsInsert = true)]
        public int RefundDocID
        {
            get { return  _refunddocid; }
            set {  _refunddocid = value; }
        }

        private DateTime  _refunddate;
        /// <summary>
        /// 退费日期
        /// </summary>
        [Column(FieldName = "RefundDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RefundDate
        {
            get { return  _refunddate; }
            set {  _refunddate = value; }
        }

        //private int  _distributeflag;
        ///// <summary>
        ///// 发药标志　０未发　１已发
        ///// </summary>
        //[Column(FieldName = "DistributeFlag", DataKey = false, Match = "", IsInsert = true)]
        //public int DistributeFlag
        //{
        //    get { return  _distributeflag; }
        //    set {  _distributeflag = value; }
        //}

        //private int  _refundflag;
        ///// <summary>
        ///// 退药标志　０未退　１已退
        ///// </summary>
        //[Column(FieldName = "RefundFlag", DataKey = false, Match = "", IsInsert = true)]
        //public int RefundFlag
        //{
        //    get { return  _refundflag; }
        //    set {  _refundflag = value; }
        //}

        private int  _refundpayflag;
        /// <summary>
        /// 0未退费　１已退费
        /// </summary>
        [Column(FieldName = "RefundPayFlag", DataKey = false, Match = "", IsInsert = true)]
        public int RefundPayFlag
        {
            get { return  _refundpayflag; }
            set {  _refundpayflag = value; }
        }

        private int  _flag;
        /// <summary>
        /// 0正常　１取消
        /// </summary>
        [Column(FieldName = "Flag", DataKey = false, Match = "", IsInsert = true)]
        public int Flag
        {
            get { return  _flag; }
            set {  _flag = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ＩＤ
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 姓名
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private string  _invoicenum;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "InvoiceNum", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNum
        {
            get { return  _invoicenum; }
            set {  _invoicenum = value; }
        }

    }
}
