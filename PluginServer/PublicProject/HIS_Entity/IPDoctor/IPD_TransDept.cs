using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPDoctor
{
    [Serializable]
    [Table(TableName = "IPD_TransDept", EntityType = EntityType.Table, IsGB = false)]
    public class IPD_TransDept:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
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

        private int  _olddeptid;
        /// <summary>
        /// 原科室ID
        /// </summary>
        [Column(FieldName = "OldDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int OldDeptID
        {
            get { return  _olddeptid; }
            set {  _olddeptid = value; }
        }

        private int  _newdeptid;
        /// <summary>
        /// 转到科室ID
        /// </summary>
        [Column(FieldName = "NewDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int NewDeptID
        {
            get { return  _newdeptid; }
            set {  _newdeptid = value; }
        }

        private DateTime  _transdate;
        /// <summary>
        /// 转科日期
        /// </summary>
        [Column(FieldName = "TransDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime TransDate
        {
            get { return  _transdate; }
            set {  _transdate = value; }
        }

        private DateTime  _operdate;
        /// <summary>
        /// 操作日期
        /// </summary>
        [Column(FieldName = "OperDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperDate
        {
            get { return  _operdate; }
            set {  _operdate = value; }
        }

        private int  _operator;
        /// <summary>
        /// 操作人
        /// </summary>
        [Column(FieldName = "Operator", DataKey = false, Match = "", IsInsert = true)]
        public int Operator
        {
            get { return  _operator; }
            set {  _operator = value; }
        }

        private string  _memo;
        /// <summary>
        /// 描述
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

        private int  _cancelflag;
        /// <summary>
        /// 取消标志
        /// </summary>
        [Column(FieldName = "CancelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int CancelFlag
        {
            get { return  _cancelflag; }
            set {  _cancelflag = value; }
        }

        private DateTime  _canceldate;
        /// <summary>
        /// 取消日期
        /// </summary>
        [Column(FieldName = "CancelDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CancelDate
        {
            get { return  _canceldate; }
            set {  _canceldate = value; }
        }

        private int  _cancelempid;
        /// <summary>
        /// 取消人
        /// </summary>
        [Column(FieldName = "CancelEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int CancelEmpID
        {
            get { return  _cancelempid; }
            set {  _cancelempid = value; }
        }

        private int  _orderid;
        /// <summary>
        /// 医嘱ID
        /// </summary>
        [Column(FieldName = "OrderID", DataKey = false, Match = "", IsInsert = true)]
        public int OrderID
        {
            get { return  _orderid; }
            set {  _orderid = value; }
        }

        private int  _finishflag;
        /// <summary>
        /// 完成标志 0=未成 1=完成
        /// </summary>
        [Column(FieldName = "FinishFlag", DataKey = false, Match = "", IsInsert = true)]
        public int FinishFlag
        {
            get { return  _finishflag; }
            set {  _finishflag = value; }
        }

    }
}
