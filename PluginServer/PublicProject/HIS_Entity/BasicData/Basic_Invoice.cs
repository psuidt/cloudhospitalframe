using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_Invoice", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_Invoice:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 发票卷ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _invoicetype;
        /// <summary>
        /// 0-收费票 1-挂号票　２住院预交金票 3住院结算
        /// </summary>
        [Column(FieldName = "InvoiceType", DataKey = false, Match = "", IsInsert = true)]
        public int InvoiceType
        {
            get { return  _invoicetype; }
            set {  _invoicetype = value; }
        }

        private int  _empid;
        /// <summary>
        /// 领用人ID。对应人员表EMPLOYEEID
        /// </summary>
        [Column(FieldName = "EmpID", DataKey = false, Match = "", IsInsert = true)]
        public int EmpID
        {
            get { return  _empid; }
            set {  _empid = value; }
        }

        private int  _startno;
        /// <summary>
        /// 开始号
        /// </summary>
        [Column(FieldName = "StartNO", DataKey = false, Match = "", IsInsert = true)]
        public int StartNO
        {
            get { return  _startno; }
            set {  _startno = value; }
        }

        private int  _endno;
        /// <summary>
        /// 结束号
        /// </summary>
        [Column(FieldName = "EndNO", DataKey = false, Match = "", IsInsert = true)]
        public int EndNO
        {
            get { return  _endno; }
            set {  _endno = value; }
        }

        private int  _currentno;
        /// <summary>
        /// 当前待用号
        /// </summary>
        [Column(FieldName = "CurrentNO", DataKey = false, Match = "", IsInsert = true)]
        public int CurrentNO
        {
            get { return  _currentno; }
            set {  _currentno = value; }
        }

        private int  _status;
        /// <summary>
        /// 状态（0-在用，1-用完，2-备用，3-停用）
        /// </summary>
        [Column(FieldName = "Status", DataKey = false, Match = "", IsInsert = true)]
        public int Status
        {
            get { return  _status; }
            set {  _status = value; }
        }

        private DateTime  _allotdate;
        /// <summary>
        /// 分配日期
        /// </summary>
        [Column(FieldName = "AllotDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime AllotDate
        {
            get { return  _allotdate; }
            set {  _allotdate = value; }
        }

        private int  _allotempid;
        /// <summary>
        /// 分配人
        /// </summary>
        [Column(FieldName = "AllotEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int AllotEmpID
        {
            get { return  _allotempid; }
            set {  _allotempid = value; }
        }

        private string  _perfchar;
        /// <summary>
        /// 前缀字符
        /// </summary>
        [Column(FieldName = "PerfChar", DataKey = false, Match = "", IsInsert = true)]
        public string PerfChar
        {
            get { return  _perfchar; }
            set {  _perfchar = value; }
        }

    }
}
