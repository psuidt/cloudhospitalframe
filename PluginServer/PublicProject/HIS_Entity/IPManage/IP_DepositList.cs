using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    /// <summary>
    /// 住院预交金
    /// </summary>
    [Serializable]
    [Table(TableName = "IP_DepositList", EntityType = EntityType.Table, IsGB = false)]
    public class IP_DepositList : AbstractEntity
    {
        private int _depositid;
        /// <summary>
        /// 预交金ID
        /// </summary>
        [Column(FieldName = "DepositID", DataKey = true, Match = "", IsInsert = false)]
        public int DepositID
        {
            get { return _depositid; }
            set { _depositid = value; }
        }

        private int _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return _memberid; }
            set { _memberid = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 病人登记ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private int _deptid;
        /// <summary>
        /// 病人科室
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return _deptid; }
            set { _deptid = value; }
        }

        private Decimal _serialnumber;
        /// <summary>
        /// 住院流水号
        /// </summary>
        [Column(FieldName = "SerialNumber", DataKey = false, Match = "", IsInsert = true)]
        public Decimal SerialNumber
        {
            get { return _serialnumber; }
            set { _serialnumber = value; }
        }

        private string _invoiceno;
        /// <summary>
        /// 票据号
        /// </summary>
        [Column(FieldName = "InvoiceNO", DataKey = false, Match = "", IsInsert = true)]
        public string InvoiceNO
        {
            get { return _invoiceno; }
            set { _invoiceno = value; }
        }

        private int _olddepositid;
        /// <summary>
        /// 退票据号关联ID
        /// </summary>
        [Column(FieldName = "OldDepositID", DataKey = false, Match = "", IsInsert = true)]
        public int OldDepositID
        {
            get { return _olddepositid; }
            set { _olddepositid = value; }
        }

        private string _paytype;
        /// <summary>
        /// 收费类型(现金、pos、支票等)
        /// </summary>
        [Column(FieldName = "PayType", DataKey = false, Match = "", IsInsert = true)]
        public string PayType
        {
            get { return _paytype; }
            set { _paytype = value; }
        }

        private Decimal _totalfee;
        /// <summary>
        /// 总金额
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return _totalfee; }
            set { _totalfee = value; }
        }

        private int _makerempid;
        /// <summary>
        /// 收费人代码
        /// </summary>
        [Column(FieldName = "MakerEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int MakerEmpID
        {
            get { return _makerempid; }
            set { _makerempid = value; }
        }

        private DateTime _makerdate;
        /// <summary>
        /// 收费时间
        /// </summary>
        [Column(FieldName = "MakerDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime MakerDate
        {
            get { return _makerdate; }
            set { _makerdate = value; }
        }

        private int _costheadid;
        /// <summary>
        /// 结算的ID，结算后反写
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return _costheadid; }
            set { _costheadid = value; }
        }

        private int _costtype;
        /// <summary>
        /// 结算类型
        /// </summary>
        [Column(FieldName = "CostType", DataKey = false, Match = "", IsInsert = true)]
        public int CostType
        {
            get { return _costtype; }
            set { _costtype = value; }
        }

        private int _accountid;
        /// <summary>
        /// 交款ID，交款后反写
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = false, Match = "", IsInsert = true)]
        public int AccountID
        {
            get { return _accountid; }
            set { _accountid = value; }
        }

        private int _status;
        /// <summary>
        /// 状态(0，正常，1，冲账，2，退费)
        /// </summary>
        [Column(FieldName = "Status", DataKey = false, Match = "", IsInsert = true)]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _printtimes;
        /// <summary>
        /// 打印次数
        /// </summary>
        [Column(FieldName = "PrintTimes", DataKey = false, Match = "", IsInsert = true)]
        public int PrintTimes
        {
            get { return _printtimes; }
            set { _printtimes = value; }
        }

    }
}
