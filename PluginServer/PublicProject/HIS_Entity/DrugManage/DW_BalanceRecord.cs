using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DW_BalanceRecord", EntityType = EntityType.Table, IsGB = false)]
    public class DW_BalanceRecord:AbstractEntity
    {
        private int  _balanceid;
        /// <summary>
        /// 结账历史标识ID
        /// </summary>
        [Column(FieldName = "BalanceID", DataKey = true, Match = "", IsInsert = false)]
        public int BalanceID
        {
            get { return  _balanceid; }
            set {  _balanceid = value; }
        }

        private int  _balanceyear;
        /// <summary>
        /// 结账年份
        /// </summary>
        [Column(FieldName = "BalanceYear", DataKey = false, Match = "", IsInsert = true)]
        public int BalanceYear
        {
            get { return  _balanceyear; }
            set {  _balanceyear = value; }
        }

        private int  _balancemonth;
        /// <summary>
        /// 结账月份
        /// </summary>
        [Column(FieldName = "BalanceMonth", DataKey = false, Match = "", IsInsert = true)]
        public int BalanceMonth
        {
            get { return  _balancemonth; }
            set {  _balancemonth = value; }
        }

        private DateTime  _begintime;
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column(FieldName = "BeginTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime BeginTime
        {
            get { return  _begintime; }
            set {  _begintime = value; }
        }

        private DateTime  _endtime;
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column(FieldName = "EndTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime EndTime
        {
            get { return  _endtime; }
            set {  _endtime = value; }
        }

        private int  _regempid;
        /// <summary>
        /// 登记人员
        /// </summary>
        [Column(FieldName = "RegEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int RegEmpID
        {
            get { return  _regempid; }
            set {  _regempid = value; }
        }

        private string  _regempname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RegEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string RegEmpName
        {
            get { return  _regempname; }
            set {  _regempname = value; }
        }

        private DateTime  _regtime;
        /// <summary>
        /// 登记时间
        /// </summary>
        [Column(FieldName = "RegTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime RegTime
        {
            get { return  _regtime; }
            set {  _regtime = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 部门ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

    }
}
