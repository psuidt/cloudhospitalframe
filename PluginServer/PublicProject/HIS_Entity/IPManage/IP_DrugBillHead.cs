using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_DrugBillHead", EntityType = EntityType.Table, IsGB = false)]
    public class IP_DrugBillHead : AbstractEntity
    {
        private int _billheadid;
        /// <summary>
        /// 发药消息头表ID
        /// </summary>
        [Column(FieldName = "BillHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int BillHeadID
        {
            get { return _billheadid; }
            set { _billheadid = value; }
        }

        private int _billclass;
        /// <summary>
        /// 单据分类 0发药 1退药
        /// </summary>
        [Column(FieldName = "BillClass", DataKey = false, Match = "", IsInsert = true)]
        public int BillClass
        {
            get { return _billclass; }
            set { _billclass = value; }
        }

        private int _billtypeid;
        /// <summary>
        /// 统领单类型 1长期药品针剂单
        /// </summary>
        [Column(FieldName = "BillTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int BillTypeID
        {
            get { return _billtypeid; }
            set { _billtypeid = value; }
        }

        private int _presdeptid;
        /// <summary>
        /// 开方科室
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return _presdeptid; }
            set { _presdeptid = value; }
        }

        private int _execdeptid;
        /// <summary>
        /// 发药科室
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return _execdeptid; }
            set { _execdeptid = value; }
        }

        private DateTime _makedate;
        /// <summary>
        /// 发送时间
        /// </summary>
        [Column(FieldName = "MakeDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime MakeDate
        {
            get { return _makedate; }
            set { _makedate = value; }
        }

        private int _makeempid;
        /// <summary>
        /// 发送人员
        /// </summary>
        [Column(FieldName = "MakeEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int MakeEmpID
        {
            get { return _makeempid; }
            set { _makeempid = value; }
        }

        private string _makeempname;
        /// <summary>
        /// 发送人员姓名
        /// </summary>
        [Column(FieldName = "MakeEmpName", DataKey = false, Match = "", IsInsert = true)]
        public string MakeEmpName
        {
            get { return _makeempname; }
            set { _makeempname = value; }
        }

        private string _patname;
        /// <summary>
        /// 病人名
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return _patname; }
            set { _patname = value; }
        }

    }
}
