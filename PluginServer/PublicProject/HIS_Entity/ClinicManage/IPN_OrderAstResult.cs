using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "IPN_OrderAstResult", EntityType = EntityType.Table, IsGB = false)]
    public class IPN_OrderAstResult:AbstractEntity
    {
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

        private int  _execempid;
        /// <summary>
        /// 执行人ID
        /// </summary>
        [Column(FieldName = "ExecEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecEmpID
        {
            get { return  _execempid; }
            set {  _execempid = value; }
        }

        private int  _execdeptid;
        /// <summary>
        /// 执行科室ID
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return  _execdeptid; }
            set {  _execdeptid = value; }
        }

        private DateTime  _execdate;
        /// <summary>
        /// 执行日期
        /// </summary>
        [Column(FieldName = "ExecDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ExecDate
        {
            get { return  _execdate; }
            set {  _execdate = value; }
        }

        private string  _结束时间;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "结束时间", DataKey = false, Match = "", IsInsert = true)]
        public string 结束时间
        {
            get { return  _结束时间; }
            set {  _结束时间 = value; }
        }

        private int  _astresult;
        /// <summary>
        /// 皮试结果   0-阴 1-阳
        /// </summary>
        [Column(FieldName = "AstResult", DataKey = false, Match = "", IsInsert = true)]
        public int AstResult
        {
            get { return  _astresult; }
            set {  _astresult = value; }
        }

    }
}
