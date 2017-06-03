using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MemberManage
{
    [Serializable]
    [Table(TableName = "ME_PromotionProjectHead", EntityType = EntityType.Table, IsGB = false)]
    public class ME_PromotionProjectHead:AbstractEntity
    {
        private int  _promid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PromID", DataKey = true, Match = "", IsInsert = false)]
        public int PromID
        {
            get { return  _promid; }
            set {  _promid = value; }
        }

        private string  _promname;
        /// <summary>
        /// 促销方案名称
        /// </summary>
        [Column(FieldName = "PromName", DataKey = false, Match = "", IsInsert = true)]
        public string PromName
        {
            get { return  _promname; }
            set {  _promname = value; }
        }

        private DateTime  _startdate;
        /// <summary>
        /// 优惠开始时间
        /// </summary>
        [Column(FieldName = "StartDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime StartDate
        {
            get { return  _startdate; }
            set {  _startdate = value; }
        }

        private DateTime  _enddate;
        /// <summary>
        /// 优惠结束时间
        /// </summary>
        [Column(FieldName = "EndDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime EndDate
        {
            get { return  _enddate; }
            set {  _enddate = value; }
        }

        private int  _useflag;
        /// <summary>
        /// 方案状态
        /// </summary>
        [Column(FieldName = "UseFlag", DataKey = false, Match = "", IsInsert = true)]
        public int UseFlag
        {
            get { return  _useflag; }
            set {  _useflag = value; }
        }

        private DateTime  _operatedate;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OperateDate
        {
            get { return  _operatedate; }
            set {  _operatedate = value; }
        }

        private int  _operateid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "OperateID", DataKey = false, Match = "", IsInsert = true)]
        public int OperateID
        {
            get { return  _operateid; }
            set {  _operateid = value; }
        }

    }
}
