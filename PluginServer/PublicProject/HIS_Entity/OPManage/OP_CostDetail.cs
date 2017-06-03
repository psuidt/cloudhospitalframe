using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.OPManage
{
    [Serializable]
    [Table(TableName = "OP_CostDetail", EntityType = EntityType.Table, IsGB = false)]
    public class OP_CostDetail:AbstractEntity
    {
        private int  _costdetailid;
        /// <summary>
        /// 结算明细ID
        /// </summary>
        [Column(FieldName = "CostDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int CostDetailID
        {
            get { return  _costdetailid; }
            set {  _costdetailid = value; }
        }

        private int  _costheadid;
        /// <summary>
        /// 结算头ID
        /// </summary>
        [Column(FieldName = "CostHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int CostHeadID
        {
            get { return  _costheadid; }
            set {  _costheadid = value; }
        }

        private int  _statid;
        /// <summary>
        /// 项目类型代码（对应统计大项目代码）
        /// </summary>
        [Column(FieldName = "StatID", DataKey = false, Match = "", IsInsert = true)]
        public int StatID
        {
            get { return  _statid; }
            set {  _statid = value; }
        }

        private Decimal  _totalfee;
        /// <summary>
        /// 单条明细合计
        /// </summary>
        [Column(FieldName = "TotalFee", DataKey = false, Match = "", IsInsert = true)]
        public Decimal TotalFee
        {
            get { return  _totalfee; }
            set {  _totalfee = value; }
        }

        private int  _feeitemheadid;
        /// <summary>
        /// 处方收费对应　OP_FeeItemHead表主键ＩＤ。挂号收费对应　OP_PatList表PatListID
        /// </summary>
        [Column(FieldName = "FeeItemHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int FeeItemHeadID
        {
            get { return  _feeitemheadid; }
            set {  _feeitemheadid = value; }
        }

        private int  _presempid;
        /// <summary>
        /// 开方医生ＩＤ
        /// </summary>
        [Column(FieldName = "PresEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int PresEmpID
        {
            get { return  _presempid; }
            set {  _presempid = value; }
        }

        private int  _presdeptid;
        /// <summary>
        /// 开方科室ＩＤ
        /// </summary>
        [Column(FieldName = "PresDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int PresDeptID
        {
            get { return  _presdeptid; }
            set {  _presdeptid = value; }
        }

        private int  _exedeptid;
        /// <summary>
        /// 执行科室ID
        /// </summary>
        [Column(FieldName = "ExeDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExeDeptID
        {
            get { return  _exedeptid; }
            set {  _exedeptid = value; }
        }

    }
}
