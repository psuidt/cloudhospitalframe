using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_Account", EntityType = EntityType.Table, IsGB = false)]
    public class IP_Account:AbstractEntity
    {
        private int  _accountid;
        /// <summary>
        /// 结账ID
        /// </summary>
        [Column(FieldName = "AccountID", DataKey = true, Match = "", IsInsert = false)]
        public int AccountID
        {
            get { return  _accountid; }
            set {  _accountid = value; }
        }

        private int  _accounttype;
        /// <summary>
        /// 结算类型0预交金1结算
        /// </summary>
        [Column(FieldName = "AccountType", DataKey = false, Match = "", IsInsert = true)]
        public int AccountType
        {
            get { return  _accounttype; }
            set {  _accounttype = value; }
        }

        private DateTime  _lastdate;
        /// <summary>
        /// 上次交款时间
        /// </summary>
        [Column(FieldName = "LastDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime LastDate
        {
            get { return  _lastdate; }
            set {  _lastdate = value; }
        }

        private string  _accountempid;
        /// <summary>
        /// 交款人
        /// </summary>
        [Column(FieldName = "AccountEmpID", DataKey = false, Match = "", IsInsert = true)]
        public string AccountEmpID
        {
            get { return  _accountempid; }
            set {  _accountempid = value; }
        }

        private DateTime  _accountdate;
        /// <summary>
        /// 交款时间
        /// </summary>
        [Column(FieldName = "AccountDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AccountDate
        {
            get { return  _accountdate; }
            set {  _accountdate = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 实际交款总金额
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
        }

        private int  _receivflag;
        /// <summary>
        /// 0未收款１已经收款
        /// </summary>
        [Column(FieldName = "ReceivFlag", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivFlag
        {
            get { return  _receivflag; }
            set {  _receivflag = value; }
        }

        private int  _receivempid;
        /// <summary>
        /// 收款操作员
        /// </summary>
        [Column(FieldName = "ReceivEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivEmpID
        {
            get { return  _receivempid; }
            set {  _receivempid = value; }
        }

        private DateTime  _receivdate;
        /// <summary>
        /// 缴款时间
        /// </summary>
        [Column(FieldName = "ReceivDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ReceivDate
        {
            get { return  _receivdate; }
            set {  _receivdate = value; }
        }

        private int  _receivbillno;
        /// <summary>
        /// 缴款单号
        /// </summary>
        [Column(FieldName = "ReceivBillNO", DataKey = false, Match = "", IsInsert = true)]
        public int ReceivBillNO
        {
            get { return  _receivbillno; }
            set {  _receivbillno = value; }
        }

        private int  _printtimes;
        /// <summary>
        /// 打印次数
        /// </summary>
        [Column(FieldName = "PrintTimes", DataKey = false, Match = "", IsInsert = true)]
        public int PrintTimes
        {
            get { return  _printtimes; }
            set {  _printtimes = value; }
        }

    }
}
