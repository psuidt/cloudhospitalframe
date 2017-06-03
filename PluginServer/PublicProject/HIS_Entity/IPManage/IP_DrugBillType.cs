using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_DrugBillType", EntityType = EntityType.Table, IsGB = false)]
    public class IP_DrugBillType:AbstractEntity
    {
        private int  _billtypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BillTypeID", DataKey = true, Match = "", IsInsert = false)]
        public int BillTypeID
        {
            get { return  _billtypeid; }
            set {  _billtypeid = value; }
        }

        private string  _billtypename;
        /// <summary>
        /// 单据名称
        /// </summary>
        [Column(FieldName = "BillTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string BillTypeName
        {
            get { return  _billtypename; }
            set {  _billtypename = value; }
        }

        private int  _sortorder;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return  _sortorder; }
            set {  _sortorder = value; }
        }

        private string  _billrule;
        /// <summary>
        /// 单据生成规则
        /// </summary>
        [Column(FieldName = "BillRule", DataKey = false, Match = "", IsInsert = true)]
        public string BillRule
        {
            get { return  _billrule; }
            set {  _billrule = value; }
        }

    }
}
