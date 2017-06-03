using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_FeeItemRelationship", EntityType = EntityType.Table, IsGB = false)]
    public class IP_FeeItemRelationship : AbstractEntity
    {
        private int _id;
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private long  _orderid;
        /// <summary>
        /// 医嘱ID
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public long OrderID
        {
            get { return  _orderid; }
            set {  _orderid = value; }
        }

        private int  _generateid;
        /// <summary>
        /// 费用生成ID
        /// </summary>
        [Column(FieldName = "GenerateID", DataKey = false, Match = "", IsInsert = true)]
        public int GenerateID
        {
            get { return  _generateid; }
            set {  _generateid = value; }
        }

        private int _feesource;
        /// <summary>
        /// 费用来源，0账单 1医嘱 2床位费 3手术室
        /// </summary>
        [Column(FieldName = "FeeSource", DataKey = false, Match = "", IsInsert = true)]
        public int FeeSource
        {
            get { return _feesource; }
            set { _feesource = value; }
        }

        private DateTime  _execdate;
        /// <summary>
        /// 执行时间
        /// </summary>
        [Column(FieldName = "ExecDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ExecDate
        {
            get { return  _execdate; }
            set {  _execdate = value; }
        }

        private DateTime  _chargedate;
        /// <summary>
        /// 记账时间
        /// </summary>
        [Column(FieldName = "ChargeDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ChargeDate
        {
            get { return  _chargedate; }
            set {  _chargedate = value; }
        }

        private int  _chargeempid;
        /// <summary>
        /// 记账人
        /// </summary>
        [Column(FieldName = "ChargeEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ChargeEmpID
        {
            get { return  _chargeempid; }
            set {  _chargeempid = value; }
        }

    }
}
