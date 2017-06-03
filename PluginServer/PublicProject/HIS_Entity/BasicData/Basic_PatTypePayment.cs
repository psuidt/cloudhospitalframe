using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_PatTypePayment", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_PatTypePayment:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = false, Match = "", IsInsert = true)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _pattypeid;
        /// <summary>
        /// 病人类型ID
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return  _pattypeid; }
            set {  _pattypeid = value; }
        }

        private int  _paymentid;
        /// <summary>
        /// 支付方式ID
        /// </summary>
        [Column(FieldName = "PaymentID", DataKey = false, Match = "", IsInsert = true)]
        public int PaymentID
        {
            get { return  _paymentid; }
            set {  _paymentid = value; }
        }

        private int  _usetype;
        /// <summary>
        /// 门诊住院使用，0门诊 1住院
        /// </summary>
        [Column(FieldName = "UseType", DataKey = false, Match = "", IsInsert = true)]
        public int UseType
        {
            get { return  _usetype; }
            set {  _usetype = value; }
        }

        private int  _payorder;
        /// <summary>
        /// 支付顺序
        /// </summary>
        [Column(FieldName = "PayOrder", DataKey = false, Match = "", IsInsert = true)]
        public int PayOrder
        {
            get { return  _payorder; }
            set {  _payorder = value; }
        }

    }
}
